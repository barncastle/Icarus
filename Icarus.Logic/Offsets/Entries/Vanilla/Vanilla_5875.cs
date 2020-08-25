using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Vanilla_5875 : IOffset
    {
        public virtual int Build { get; } = 5875;
        public int WorldEnables { get; } = 0xC7B2A4;
        public int CurWorldFrame { get; } = 0xB4B2BC;
        public int CameraOffset { get; } = 0x65B8;
        public int CameraFieldOffset { get; } = 8;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternVanilla();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}