using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Vanilla_4044 : IOffset
    {
        public int Build { get; } = 4044;
        public int WorldEnables { get; } = 0xAA7A84;
        public int CurWorldFrame { get; } = 0x992A00;
        public int CameraOffset { get; } = 0x6518;
        public int CameraFieldOffset { get; } = 8;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternVanilla();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}