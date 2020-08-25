using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Vanilla_4125 : IOffset
    {
        public virtual int Build { get; } = 4125;
        public int WorldEnables { get; } = 0xA9FE7C;
        public int CurWorldFrame { get; } = 0x98AE00;
        public int CameraOffset { get; } = 0x6558;
        public int CameraFieldOffset { get; } = 8;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternVanilla();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}