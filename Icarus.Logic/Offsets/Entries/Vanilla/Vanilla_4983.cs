using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Vanilla_4983 : IOffset
    {
        public virtual int Build { get; } = 4983;
        public int WorldEnables { get; } = 0xC023A4;
        public int CurWorldFrame { get; } = 0xAF4620;
        public int CameraOffset { get; } = 0x6578;
        public int CameraFieldOffset { get; } = 8;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternVanilla();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}