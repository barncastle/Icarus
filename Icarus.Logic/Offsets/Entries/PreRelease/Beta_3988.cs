using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets.Entries
{
    internal class Beta_3988 : IOffset
    {
        public virtual int Build { get; } = 3988;
        public int WorldEnables { get; } = 0xA78B1C;
        public int CurWorldFrame { get; } = 0x987704;
        public int CameraOffset { get; } = 0x64E0;
        public int CameraFieldOffset { get; } = 8;
        public Pattern CalcThirdPerson { get; } = Common.GetCalcThirdPersonPatternVanilla();
        public Pattern SetFarclipPattern { get; } = Common.GetSetFarclipPatternAlpha();
    }
}