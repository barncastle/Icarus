using System.Numerics;
using System.Runtime.InteropServices;

namespace Icarus.Logic.Game.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct CSimpleCamera
    {
        //public uint VTablePtr;
        //public uint UnkPtr; // added 0.11.0
        public Vector3 Position;

        public Vector3 Forward;
        public Vector3 Right;
        public Vector3 Up;
        public float NearZ;
        public float FarZ;
        public float Fov;
        public float Aspect;
    }
}