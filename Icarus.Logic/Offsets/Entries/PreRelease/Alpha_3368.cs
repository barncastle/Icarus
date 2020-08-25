using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Alpha_3368 : IOffset
    {
        public int Build { get; } = 3368;
        public int WorldEnables { get; } = 0xE4046C;
        public int CurWorldFrame { get; } = 0xDDDC94;
        public int CameraOffset { get; } = 0x64BC;
        public int CameraFieldOffset { get; } = 4;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternAlpha();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}