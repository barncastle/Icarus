using System;

namespace Icarus.Logic.Game.Enums
{
    [Flags]
    public enum InputMask : ushort
    {
        None = 0x0,
        Forward = 0x1,
        Backward = 0x2,
        Left = 0x4,
        Right = 0x8,
        Ascend = 0x10,
        Descend = 0x20,
        Fast = 0x40,
        Slow = 0x80,
        Toggle = 0x8000
    }
}