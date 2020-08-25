using Icarus.Logic.Hooks.Enums;
using System;
using System.Runtime.InteropServices;

namespace Icarus.Logic.Hooks.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LowLevelKeyboardInputEvent
    {
        public Keys VirtualCode;
        public int HardwareScanCode;
        public int Flags;
        public int TimeStamp;
        public IntPtr AdditionalInformation;
    }
}