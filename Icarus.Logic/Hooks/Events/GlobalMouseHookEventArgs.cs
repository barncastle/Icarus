using Icarus.Logic.Hooks.Enums;
using Icarus.Logic.Hooks.Structs;
using System.ComponentModel;

namespace Icarus.Logic.Hooks.Events
{
    public class GlobalMouseHookEventArgs : HandledEventArgs
    {
        public readonly MouseState State;
        public readonly LowLevelMouseInputEvent Data;

        public GlobalMouseHookEventArgs(LowLevelMouseInputEvent mouseData, MouseState mouseState)
        {
            Data = mouseData;
            State = mouseState;
        }
    }
}