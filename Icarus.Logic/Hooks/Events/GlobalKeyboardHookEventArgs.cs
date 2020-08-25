using Icarus.Logic.Hooks.Enums;
using Icarus.Logic.Hooks.Structs;
using System.ComponentModel;

namespace Icarus.Logic.Hooks.Events
{
    public class GlobalKeyboardHookEventArgs : HandledEventArgs
    {
        public readonly KeyboardState State;
        public readonly LowLevelKeyboardInputEvent Data;

        public GlobalKeyboardHookEventArgs(LowLevelKeyboardInputEvent keyboardData, KeyboardState keyboardState)
        {
            Data = keyboardData;
            State = keyboardState;
        }
    }
}