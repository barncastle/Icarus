using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Beta_3694 : IOffset
    {
        public int Build { get; } = 3694;
        public int WorldEnables { get; } = 0xE6DEA0;
        public int CurWorldFrame { get; } = 0xE00DC0;
        public int CameraOffset { get; } = 0x64CC;
        public int CameraFieldOffset { get; } = 4;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternAlpha();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}