namespace Icarus.Logic.Hooks.Enums
{
    public enum MouseState
    {
        LeftButtonDown = 0x200,
        LeftButtonUp = 0x201,
        RightButtonDown = 0x203,
        RightButtonUp = 0x204,

        All = LeftButtonDown | LeftButtonUp | RightButtonDown | RightButtonUp
    }
}