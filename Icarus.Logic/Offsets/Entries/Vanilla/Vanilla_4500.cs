using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Vanilla_4500 : IOffset
    {
        public virtual int Build { get; } = 4500;
        public int WorldEnables { get; } = 0xA4CCAC;
        public int CurWorldFrame { get; } = 0x9495E4;
        public int CameraOffset { get; } = 0x6550;
        public int CameraFieldOffset { get; } = 8;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternVanilla();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}