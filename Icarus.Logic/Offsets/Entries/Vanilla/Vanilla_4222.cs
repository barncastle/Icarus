using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Vanilla_4222 : IOffset
    {
        public virtual int Build { get; } = 4222;
        public int WorldEnables { get; } = 0xAAD2A4;
        public int CurWorldFrame { get; } = 0x998108;
        public int CameraOffset { get; } = 0x6558;
        public int CameraFieldOffset { get; } = 8;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternVanilla();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}