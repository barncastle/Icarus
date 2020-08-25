using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Alpha_3494 : IOffset
    {
        public int Build { get; } = 3494;
        public int WorldEnables { get; } = 0xE4DD34;
        public int CurWorldFrame { get; } = 0xDEAE24;
        public int CameraOffset { get; } = 0x64BC;
        public int CameraFieldOffset { get; } = 4;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternAlpha();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}