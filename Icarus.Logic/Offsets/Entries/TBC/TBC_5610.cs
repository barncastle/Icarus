using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class TBC_5610 : IOffset
    {
        public virtual int Build { get; } = 5610;
        public int WorldEnables { get; } = 0xC8D0DC;
        public int CurWorldFrame { get; } = 0xB5C824;
        public int CameraOffset { get; } = 0x65B8;
        public int CameraFieldOffset { get; } = 8;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternVanilla();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}