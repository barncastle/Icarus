using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Vanilla_4735 : IOffset
    {
        public virtual int Build { get; } = 4735;
        public virtual int WorldEnables { get; } = 0xBEC93C;
        public int CurWorldFrame { get; } = 0xADFAE4;
        public int CameraOffset { get; } = 0x6570;
        public int CameraFieldOffset { get; } = 8;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternVanilla();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}