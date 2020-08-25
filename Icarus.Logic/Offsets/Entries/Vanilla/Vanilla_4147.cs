using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Vanilla_4147 : IOffset
    {
        public virtual int Build { get; } = 4147;
        public int WorldEnables { get; } = 0xAA53FC;
        public int CurWorldFrame { get; } = 0x9902F0;
        public int CameraOffset { get; } = 0x6558;
        public int CameraFieldOffset { get; } = 8;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternVanilla();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}