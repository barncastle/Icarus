using Icarus.Logic.Game;
using System;
using System.IO;

namespace Icarus.Logic.Patterns
{
    internal sealed class Pattern
    {
        public byte[] Source { get; }
        public byte[] Patch { get; }
        public long Offset { get; private set; } = -1;
        public bool HasPatch => Pattern2.Length > 0;

        private const short Wildcard = -1;
        private readonly short[] Pattern1;
        private readonly short[] Pattern2;

        public Pattern(short[] original, short[] modified = null)
        {
            Pattern1 = original ?? throw new ArgumentNullException(nameof(original));
            Pattern2 = modified ?? new short[0];

            Source = new byte[Pattern1.Length];
            Patch = new byte[Pattern2.Length];
        }

        public bool Resolve(ProcessManager manager)
        {
            // scan memory for either pattern
            if (!HasWildcard())
            {
                IndexOfAny(manager);
                ResolvePatterns();
            }
            // scan memory for source and replace wildcard bytes
            else if ((Offset = manager.IndexOf(Pattern1, manager.BaseAddress)) > -1)
            {
                ResolvePatterns(manager.Read<byte>(Offset, Pattern1.Length));
            }
            // scan exe for source and replace wildcard bytes
            else if (Resolve(manager.ProcessPath))
            {
                Offset += manager.BaseAddress; // rebase
            }

            return Offset > -1;
        }

        public bool Resolve(string filepath)
        {
            if (File.Exists(filepath))
                using (var fs = File.OpenRead(filepath))
                    return Resolve(fs);

            return false;
        }

        public bool Resolve(Stream stream)
        {
            if ((Offset = stream.IndexOf(Pattern1)) > -1)
            {
                byte[] buffer = new byte[Pattern1.Length];
                stream.Position = Offset;
                stream.Read(buffer, 0, buffer.Length);
                ResolvePatterns(buffer);
            }

            return Offset > -1;
        }

        public Pattern Clone() => new Pattern(Pattern1, Pattern2);

        private void IndexOfAny(ProcessManager manager)
        {
            if ((Offset = manager.IndexOf(Pattern1, manager.BaseAddress)) == -1)
                Offset = manager.IndexOf(Pattern2, manager.BaseAddress);
        }

        private bool HasWildcard()
        {
            if (Array.IndexOf(Pattern1, Wildcard) > -1 || Array.IndexOf(Pattern2, Wildcard) > -1)
                return true;

            return false;
        }

        private void ResolvePatterns(byte[] source = null)
        {
            for (int i = 0; i < Pattern1.Length; i++)
                Source[i] = Pattern1[i] == Wildcard ? source[i] : (byte)Pattern1[i];
            for (int i = 0; i < Pattern2.Length; i++)
                Patch[i] = Pattern2[i] == Wildcard ? source[i] : (byte)Pattern2[i];
        }
    }
}