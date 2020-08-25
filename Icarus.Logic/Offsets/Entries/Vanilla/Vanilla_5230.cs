using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Vanilla_5230 : IOffset
    {
        public virtual int Build { get; } = 5230;
        public int WorldEnables { get; } = 0xC20EDC;
        public int CurWorldFrame { get; } = 0xB108A4;
        public int CameraOffset { get; } = 0x65C0;
        public int CameraFieldOffset { get; } = 8;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternVanilla();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}