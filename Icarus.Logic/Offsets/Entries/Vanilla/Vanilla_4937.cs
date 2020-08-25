using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Vanilla_4937 : IOffset
    {
        public virtual int Build { get; } = 4937;
        public int WorldEnables { get; } = 0xC00F7C;
        public int CurWorldFrame { get; } = 0xAF3220;
        public int CameraOffset { get; } = 0x6578;
        public int CameraFieldOffset { get; } = 8;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternVanilla();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}