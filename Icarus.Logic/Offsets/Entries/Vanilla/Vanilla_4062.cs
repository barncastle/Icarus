using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Vanilla_4062 : IOffset
    {
        public virtual int Build { get; } = 4062;
        public int WorldEnables { get; } = 0xA9F284;
        public int CurWorldFrame { get; } = 0x98A200;
        public int CameraOffset { get; } = 0x6518;
        public int CameraFieldOffset { get; } = 8;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternVanilla();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}