using Icarus.Logic.Game.Enums;
using Icarus.Logic.Game.Structs;
using Icarus.Logic.Offsets;
using System.Numerics;

namespace Icarus.Logic.Game
{
    internal class CameraObject
    {
        public bool Activated { get; private set; }
        public float MovementSpeed { get; set; } = 1f;

        private long CameraPtr;
        private IOffset Offsets;
        private Enables DefaultRenderFlags;
        private bool Loaded;

        private readonly ProcessManager Process;

        public CameraObject(ProcessManager process)
        {
            Process = process;
        }

        public CameraStatus LoadOffsets()
        {
            Loaded = Activated = false;

            // try to load the offsets for this build
            if (!OffsetStore.TryGetOffset(Process.Build, out Offsets))
                return CameraStatus.BuildNotFound;

            // try to read the camera pointer
            if ((CameraPtr = Process.ReadPointer(Offsets.CurWorldFrame, Offsets.CameraOffset)) <= 0)
                return CameraStatus.CameraNotFound;

            // push the pointer to the start of the fields
            CameraPtr += Offsets.CameraFieldOffset;

            try
            {
                // check the pointer isn't pointing an invalid region or not instantiated
                if (Process.Read<CSimpleCamera>(CameraPtr).Equals(default(CSimpleCamera)))
                    return CameraStatus.CameraNotFound;

                // attemp to resolve the camera pattern and patch
                if (!Offsets.CalcThirdPerson.Resolve(Process))
                    return CameraStatus.PatternNotFound;
            }
            catch (System.ComponentModel.Win32Exception)
            {
                return CameraStatus.MemoryAccess;
            }

            Loaded = true;
            DefaultRenderFlags = GetRenderFlags();
            DisableFreeMove();
            DisableFarclip();

            return CameraStatus.OK;
        }

        #region Movement

        public bool EnableFreeMove()
        {
            if (!Loaded || Process.HasExited())
                return false;
            if (Process.Write(Offsets.CalcThirdPerson.Offset, Offsets.CalcThirdPerson.Patch))
                return Activated = true;

            return false;
        }

        public bool DisableFreeMove()
        {
            if (!Loaded || Process.HasExited())
                return false;
            if (Process.Write(Offsets.CalcThirdPerson.Offset, Offsets.CalcThirdPerson.Source))
                return !(Activated = false);

            return false;
        }

        public void UpdatePosition(InputMask mask)
        {
            bool HasFlag(InputMask flag) => (mask & flag) == flag;

            if (!Loaded)
                return;

            var camera = Process.Read<CSimpleCamera>(CameraPtr);

            float speed = MovementSpeed;
            if (HasFlag(InputMask.Fast))
                speed *= 2f;
            if (HasFlag(InputMask.Slow))
                speed /= 2f;

            if (HasFlag(InputMask.Forward))
                camera.Position += Vector3.Multiply(speed, camera.Forward);
            if (HasFlag(InputMask.Backward))
                camera.Position -= Vector3.Multiply(speed, camera.Forward);
            if (HasFlag(InputMask.Right))
                camera.Position -= Vector3.Multiply(speed, camera.Right);
            if (HasFlag(InputMask.Left))
                camera.Position += Vector3.Multiply(speed, camera.Right);
            if (HasFlag(InputMask.Ascend))
                camera.Position += Vector3.Multiply(speed, camera.Up);
            if (HasFlag(InputMask.Descend))
                camera.Position -= Vector3.Multiply(speed, camera.Up);

            Process.Write(CameraPtr + (uint)FieldOffsets.Position, camera.Position);
        }

        #endregion Movement

        #region Rendering

        public Enables GetRenderFlags() => Loaded ? Process.Read<Enables>(Offsets.WorldEnables) : 0;

        public bool ResetRenderFlags() => Loaded && Process.Write(Offsets.WorldEnables, DefaultRenderFlags);

        public bool SetRenderFlags(Enables flags) => Loaded && Process.Write(Offsets.WorldEnables, flags);

        public bool SetRenderFlags(Enables flags, bool enabled)
        {
            if (enabled)
                return SetRenderFlags(GetRenderFlags() | flags);
            else
                return SetRenderFlags(GetRenderFlags() & ~flags);
        }

        private bool DisableFarclip()
        {
            if (Loaded && Offsets.SetFarclipPattern.Resolve(Process))
                return Process.Write(Offsets.SetFarclipPattern.Offset, Offsets.SetFarclipPattern.Patch);

            return false;
        }

        #endregion Rendering
    }
}