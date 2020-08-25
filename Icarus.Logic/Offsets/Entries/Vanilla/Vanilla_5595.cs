using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Vanilla_5595 : IOffset
    {
        public virtual int Build { get; } = 5595;
        public int WorldEnables { get; } = 0xC7AD94;
        public int CurWorldFrame { get; } = 0xB4AEBC;
        public int CameraOffset { get; } = 0x65B8;
        public int CameraFieldOffset { get; } = 8;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternVanilla();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}