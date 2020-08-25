using Icarus.Logic.Game.Enums;
using Icarus.Logic.Hooks.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Icarus.Logic.Hooks
{
    public static class KeyBinding
    {
        public const string SettingsFile = "bindings.wtf";

        private static readonly Dictionary<InputMask, Keys> InputToKeys;
        private static readonly Dictionary<Keys, InputMask> KeysToInput;

        static KeyBinding()
        {
            InputToKeys = Default.ToDictionary(x => x.Key, x => x.Value);
            KeysToInput = InputToKeys.ToDictionary(x => x.Value, x => x.Key);
        }

        public static bool TryGet(Keys key, out InputMask inputMask)
        {
            return KeysToInput.TryGetValue(key, out inputMask) && inputMask != InputMask.None;
        }

        public static bool TryGet(InputMask input, out Keys key)
        {
            return InputToKeys.TryGetValue(input, out key) && key != Keys.None;
        }

        public static void BindKey(InputMask input, Keys key)
        {
            if (input == InputMask.None || !Enum.IsDefined(typeof(InputMask), input))
                return;

            if (TryGet(key, out var oInput))
                InputToKeys.Remove(oInput);
            if (TryGet(input, out var oKey))
                KeysToInput.Remove(oKey);

            InputToKeys[input] = key;
            KeysToInput[key] = input;
        }

        public static void Reset()
        {
            foreach (var kvp in Default)
            {
                InputToKeys[kvp.Key] = kvp.Value;
                KeysToInput[kvp.Value] = kvp.Key;
            }
        }

        #region IO

        public static void Save()
        {
            using (var sw = File.CreateText(SettingsFile))
                foreach (var kvp in InputToKeys)
                    sw.WriteLine($"{kvp.Key} {kvp.Value}");
        }

        public static bool Load()
        {
            if (!File.Exists(SettingsFile))
                return false;

            using (var sw = File.OpenText(SettingsFile))
            {
                while (!sw.EndOfStream)
                {
                    var parts = sw.ReadLine().Trim().Split(' ');
                    if (parts.Length < 2)
                        continue;

                    if (Enum.TryParse<InputMask>(parts[0], true, out var inputMask))
                        if (Enum.TryParse<Keys>(parts[1], true, out var key))
                            BindKey(inputMask, key);
                }
            }

            return true;
        }

        #endregion IO

        private static readonly IReadOnlyDictionary<InputMask, Keys> Default = new Dictionary<InputMask, Keys>()
        {
            [InputMask.Forward] = Keys.W,
            [InputMask.Backward] = Keys.S,
            [InputMask.Left] = Keys.A,
            [InputMask.Right] = Keys.D,
            [InputMask.Ascend] = Keys.Space,
            [InputMask.Descend] = Keys.X,
            [InputMask.Fast] = Keys.LShiftKey,
            [InputMask.Slow] = Keys.LControlKey,
            [InputMask.Toggle] = Keys.F1
        };
    }
}