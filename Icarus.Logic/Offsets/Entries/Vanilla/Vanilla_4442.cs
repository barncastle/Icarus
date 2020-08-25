using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Vanilla_4442 : IOffset
    {
        public virtual int Build { get; } = 4442;
        public int WorldEnables { get; } = 0xA4F5DC;
        public int CurWorldFrame { get; } = 0x9497F4;
        public int CameraOffset { get; } = 0x6540;
        public int CameraFieldOffset { get; } = 8;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternVanilla();
        public Pattern SetFarclipPattern { get; } = new Pattern(FarclipPattern, FarclipPatch);

        private static readonly short[] FarclipPattern = new short[]
        {
            0x74, 0x0F, 0x8B, 0x4C, 0x24, 0x04, 0x51, 0xE8, -0x1, -0x1, -0x1, -0x1,
            0xB0, 0x01, 0xC2, 0x08, 0x00, 0x33, 0xD2, 0xB9, -0x1, -0x1, -0x1, -0x1,
            0xE8, -0x1, -0x1, -0x1, -0x1, 0x32, 0xC0, 0xC2, 0x08, 0x00, 0x90, 0x90,
            0x90, 0x90, 0x8B, 0x44, 0x24, 0x04, 0x50, 0xE8, -0x1, -0x1, -0x1, -0x1,
            0xD9, 0x54, 0x24, 0x04
        };

        private static readonly short[] FarclipPatch = new short[]
        {
            0x90, 0x90
        };
    }
}