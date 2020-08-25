using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Beta_3807 : IOffset
    {
        public virtual int Build { get; } = 3807;
        public int WorldEnables { get; } = 0xE90200;
        public int CurWorldFrame { get; } = 0xDF2670;
        public int CameraOffset { get; } = 0x64CC;
        public int CameraFieldOffset { get; } = 4;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternAlpha();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}