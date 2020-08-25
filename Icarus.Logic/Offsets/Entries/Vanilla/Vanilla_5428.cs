using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Vanilla_5428 : IOffset
    {
        public virtual int Build { get; } = 5428;
        public int WorldEnables { get; } = 0xC6F094;
        public int CurWorldFrame { get; } = 0xB3F634;
        public int CameraOffset { get; } = 0x65B8;
        public int CameraFieldOffset { get; } = 8;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternVanilla();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}