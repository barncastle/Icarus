using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class TBC_5849 : IOffset
    {
        public virtual int Build { get; } = 5849;
        public int WorldEnables { get; } = 0xCCB244;
        public int CurWorldFrame { get; } = 0xB9994C;
        public int CameraOffset { get; } = 0x65C0;
        public int CameraFieldOffset { get; } = 8;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternVanilla();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternTBC();
    }
}