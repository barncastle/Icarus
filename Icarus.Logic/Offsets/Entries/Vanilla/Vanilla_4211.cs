using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Vanilla_4211 : IOffset
    {
        public virtual int Build { get; } = 4211;
        public int WorldEnables { get; } = 0xAA7844;
        public int CurWorldFrame { get; } = 0x992718;
        public int CameraOffset { get; } = 0x6558;
        public int CameraFieldOffset { get; } = 8;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternVanilla();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}