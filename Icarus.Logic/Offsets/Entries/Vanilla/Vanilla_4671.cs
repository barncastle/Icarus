using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Vanilla_4671 : IOffset
    {
        public virtual int Build { get; } = 4671;
        public int WorldEnables { get; } = 0xA61D84;
        public int CurWorldFrame { get; } = 0x95519C;
        public int CameraOffset { get; } = 0x6550;
        public int CameraFieldOffset { get; } = 8;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternVanilla();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}