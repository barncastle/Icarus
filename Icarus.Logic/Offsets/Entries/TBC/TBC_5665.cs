using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class TBC_5665 : IOffset
    {
        public virtual int Build { get; } = 5665;
        public int WorldEnables { get; } = 0xC9379C;
        public int CurWorldFrame { get; } = 0xB62964;
        public int CameraOffset { get; } = 0x65B8;
        public int CameraFieldOffset { get; } = 8;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternVanilla();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternTBC();
    }
}