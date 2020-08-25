﻿using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Beta_3892 : IOffset
    {
        public int Build { get; } = 3892;
        public int WorldEnables { get; } = 0xEA5C00;
        public int CurWorldFrame { get; } = 0xE07878;
        public int CameraOffset { get; } = 0x64E4;
        public int CameraFieldOffset { get; } = 4;
        public Pattern CalcThirdPerson { get; } = new Pattern(CameraPattern, CameraPatch);
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();

        private static readonly short[] CameraPattern = new short[]
        {
            0x89, 0x11, 0xD9, 0x5D, 0xF8, 0x8B, 0x45, 0xF8, 0xDD,
            0xD8, 0x89, 0x41, 0x04, 0xDD, 0xD8, 0xD9, 0x45, 0xF0,
            0xD8, 0x65, 0xE4, 0xD9, 0x5D, 0xFC, 0xD9, 0x86, 0x04,
            0x01, 0x00, 0x00, 0x8B, 0x55, 0xFC, 0xD9, 0xE1, 0xD8,
            0x15, 0x14, 0xA1, 0x80, 0x00, 0x89, 0x51, 0x08
        };

        private static readonly short[] CameraPatch = new short[]
        {
           0x90, 0x90, 0xD9, 0x5D, 0xF8, 0x8B, 0x45, 0xF8, 0xDD,
           0xD8, 0x90, 0x90, 0x90, 0xDD, 0xD8, 0xD9, 0x45, 0xF0,
           0xD8, 0x65, 0xE4, 0xD9, 0x5D, 0xFC, 0xD9, 0x86, 0x04,
           0x01, 0x00, 0x00, 0x8B, 0x55, 0xFC, 0xD9, 0xE1, 0xD8,
           0x15, 0x14, 0xA1, 0x80, 0x00, 0x90, 0x90, 0x90
        };
    }
}