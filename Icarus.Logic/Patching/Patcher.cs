using Icarus.Logic.Game;
using Icarus.Logic.Offsets;
using Icarus.Logic.Patching.Enums;
using Icarus.Logic.Patterns;
using System;
using System.IO;

namespace Icarus.Logic.Patching
{
    internal static class Patcher
    {
        private const string FileNameSuffix = "_modified";

        public static bool Patch(ProcessManager process)
        {
            // try to load the offsets for this build
            if (!OffsetStore.TryGetOffset(process.Build, out var offsets))
                return false;

            // check executable exists
            if (!File.Exists(process.ProcessPath))
                return false;

            var patches = (PatchType[])Enum.GetValues(typeof(PatchType));

            foreach (var patch in patches)
                if (!Patch(process.ProcessPath, patch, offsets))
                    return false;

            return true;
        }

        private static bool Patch(string filepath, PatchType type, IOffset offsets)
        {
            switch (type)
            {
                case PatchType.Farclip:
                    return ApplyPatch(filepath, offsets.SetFarclipPattern.Clone());

                default:
                    return false;
            }
        }

        private static bool ApplyPatch(string filepath, Pattern pattern)
        {
            using (var source = File.OpenRead(filepath))
            {
                // scan for the pattern
                if (pattern.Resolve(source))
                {
                    using (var fs = new FileStream(GetModifiedFilename(filepath), FileMode.OpenOrCreate))
                    {
                        // clone the original file
                        if (fs.Length == 0)
                        {
                            source.Position = 0;
                            source.CopyTo(fs);
                        }

                        // apply patch bytes
                        fs.Position = pattern.Offset;
                        fs.Write(pattern.Patch, 0, pattern.Patch.Length);

                        return true;
                    }
                }
            }

            return false;
        }

        private static string GetModifiedFilename(string filepath)
        {
            return filepath.Insert(filepath.Length - Path.GetExtension(filepath).Length, FileNameSuffix);
        }
    }
}