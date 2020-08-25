using Icarus.Logic.Game.Enums;
using Icarus.Logic.Hooks;
using Icarus.Logic.Hooks.Enums;
using Icarus.Logic.Hooks.Events;
using System;
using System.Threading;

namespace Icarus.Logic.Game
{
    public class CameraManager : IDisposable
    {
        public event EventHandler<CameraStatus> CameraBound;

        public event EventHandler CameraUnbound;

        public event EventHandler<bool> FreeMoveStatusChanged;

        public float MovementSpeed
        {
            get => Camera.MovementSpeed;
            set => Camera.MovementSpeed = value;
        }

        private const int Framerate = (int)(1000f / 60f);
        private readonly GlobalHook GlobalHook;
        private readonly ProcessManager ProcessManager;
        private readonly CameraObject Camera;
        private readonly Timer Timer;

        private bool IsBound;
        private bool IsActiveWindow;
        private InputMask InputMask = 0;

        public CameraManager(GlobalHook globalHook, ProcessManager process)
        {
            GlobalHook = globalHook ?? throw new ArgumentNullException(nameof(globalHook));
            ProcessManager = process ?? throw new ArgumentNullException(nameof(process));
            Camera = new CameraObject(process);
            Timer = new Timer(UpdateMovement, null, Timeout.Infinite, Timeout.Infinite);

            GlobalHook.HookKeyboard();
            GlobalHook.HookWindowChange();

            GlobalHook.KeyboardPressed += GlobalHook_KeyboardPressed;
            GlobalHook.WindowChanged += GlobalHook_WindowChanged;
            ProcessManager.ProcessAttached += Process_ProcessAttached;
            ProcessManager.ProcessDetached += Process_ProcessDetached;
        }

        #region Movement

        public bool EnableFreeMove()
        {
            return IsBound && Camera.EnableFreeMove() && Timer.Change(0, Framerate);
        }

        public bool DisableFreeMove()
        {
            if (IsBound && Timer.Change(Timeout.Infinite, Timeout.Infinite))
            {
                Thread.Sleep(Framerate); // wait for next tick
                return Camera.DisableFreeMove();
            }

            return false;
        }

        public bool ToggleFreeMove()
        {
            bool success;
            if (Camera.Activated)
                success = DisableFreeMove();
            else
                success = EnableFreeMove();

            if (success)
                FreeMoveStatusChanged?.Invoke(this, Camera.Activated);

            return success;
        }

        private void UpdateMovement(object state)
        {
            if (IsBound && Camera.Activated && InputMask != InputMask.None && IsActiveWindow)
                Camera.UpdatePosition(InputMask);
        }

        #endregion Movement

        #region Rendering

        public Enables GetRenderFlags()
        {
            return IsBound ? Camera.GetRenderFlags() : 0;
        }

        public bool ResetRenderFlags()
        {
            return IsBound && Camera.ResetRenderFlags();
        }

        public bool SetRenderFlags(Enables flags)
        {
            return IsBound && Camera.SetRenderFlags(flags);
        }

        public bool SetRenderFlags(Enables flags, bool enabled)
        {
            return IsBound && Camera.SetRenderFlags(flags, enabled);
        }

        #endregion Rendering

        #region Event Binding

        private void GlobalHook_KeyboardPressed(object sender, GlobalKeyboardHookEventArgs e)
        {
            if (IsBound && IsActiveWindow)
            {
                if (KeyBinding.TryGet(e.Data.VirtualCode, out var mask))
                {
                    bool keydown = e.State == KeyboardState.KeyDown || e.State == KeyboardState.SysKeyDown;

                    if (e.Handled = mask == InputMask.Toggle)
                    {
                        if (keydown) ToggleFreeMove();
                    }
                    else if (e.Handled = Camera.Activated)
                    {
                        if (keydown)
                            InputMask |= mask;
                        else
                            InputMask &= ~mask;
                    }
                }
            }
        }

        private void GlobalHook_WindowChanged(object sender, IntPtr e)
        {
            IsActiveWindow = e == ProcessManager.WindowHandle;

            if (!IsActiveWindow)
                InputMask = InputMask.None;
        }

        private void Process_ProcessAttached(object sender, EventArgs e)
        {
            IsBound = true;
            IsActiveWindow = GlobalHook.IsActiveWindow(ProcessManager.WindowHandle);
            var status = Camera.LoadOffsets();

            CameraBound?.Invoke(this, status);
        }

        private void Process_ProcessDetached(object sender, EventArgs e)
        {
            IsBound = IsActiveWindow = false;
            InputMask = InputMask.None;
            Timer.Change(Timeout.Infinite, Timeout.Infinite);

            CameraUnbound?.Invoke(this, EventArgs.Empty);
            FreeMoveStatusChanged?.Invoke(this, false);
        }

        #endregion Event Binding

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                GlobalHook.KeyboardPressed -= GlobalHook_KeyboardPressed;
                GlobalHook.WindowChanged -= GlobalHook_WindowChanged;
                ProcessManager.ProcessAttached -= Process_ProcessAttached;
                ProcessManager.ProcessDetached -= Process_ProcessDetached;

                if (!ProcessManager.HasExited())
                {
                    DisableFreeMove();
                    ResetRenderFlags();
                }

                IsBound = IsActiveWindow = false;
                InputMask = InputMask.None;
                Timer.Change(Timeout.Infinite, Timeout.Infinite);
                Timer.Dispose();
            }
        }

        ~CameraManager() => Dispose(false);
    }
}