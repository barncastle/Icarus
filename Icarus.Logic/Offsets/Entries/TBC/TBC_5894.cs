using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class TBC_5894 : IOffset
    {
        public virtual int Build { get; } = 5894;
        public virtual int WorldEnables { get; } = 0xCCD2B4;
        public int CurWorldFrame { get; } = 0xB9B94C;
        public int CameraOffset { get; } = 0x65C8;
        public int CameraFieldOffset { get; } = 8;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternVanilla();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternTBC();
    }
}