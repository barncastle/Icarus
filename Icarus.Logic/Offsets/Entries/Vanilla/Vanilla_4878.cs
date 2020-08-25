using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Vanilla_4878 : IOffset
    {
        public virtual int Build { get; } = 4878;
        public virtual int WorldEnables { get; } = 0xBEC94C;
        public int CurWorldFrame { get; } = 0xADFAEC;
        public int CameraOffset { get; } = 0x6570;
        public int CameraFieldOffset { get; } = 8;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternVanilla();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}