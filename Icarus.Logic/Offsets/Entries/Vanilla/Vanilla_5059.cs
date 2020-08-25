using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Vanilla_5059 : IOffset
    {
        public virtual int Build { get; } = 5059;
        public int WorldEnables { get; } = 0xC01BBC;
        public int CurWorldFrame { get; } = 0xAF3E24;
        public int CameraOffset { get; } = 0x6578;
        public int CameraFieldOffset { get; } = 8;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternVanilla();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}