using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Icarus.Logic.Hooks.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LowLevelMouseInputEvent
    {
        public Point Point;
        public int MouseData;
        public int Flags;
        public int TimeStamp;
        public IntPtr AdditionalInformation;
    }
}