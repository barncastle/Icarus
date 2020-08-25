using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Beta_3702 : IOffset
    {
        public virtual int Build { get; } = 3702;
        public int WorldEnables { get; } = 0xE6EEB0;
        public int CurWorldFrame { get; } = 0xE01DC0;
        public int CameraOffset { get; } = 0x64CC;
        public int CameraFieldOffset { get; } = 4;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternAlpha();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}