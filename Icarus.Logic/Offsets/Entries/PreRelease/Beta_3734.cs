using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Beta_3734 : IOffset
    {
        public int Build { get; } = 3734;
        public int WorldEnables { get; } = 0xE96C30;
        public int CurWorldFrame { get; } = 0xE11190;
        public int CameraOffset { get; } = 0x64CC;
        public int CameraFieldOffset { get; } = 4;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternAlpha();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}