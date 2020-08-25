using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Vanilla_5302 : IOffset
    {
        public virtual int Build { get; } = 5302;
        public int WorldEnables { get; } = 0xC213E4;
        public int CurWorldFrame { get; } = 0xB10CA4;
        public int CameraOffset { get; } = 0x65C0;
        public int CameraFieldOffset { get; } = 8;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternVanilla();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}