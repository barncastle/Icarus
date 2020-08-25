using Icarus.Logic.Game;
using System.IO;

namespace Icarus.Logic.Patterns
{
    internal static class PatternExtensions
    {
        private const int BufferSize = 0x10000;

        public static long IndexOf(this byte[] haystack, short[] pattern, int startOffset = 0)
        {
            if (pattern == null)
                return -1;

            int pLen = pattern.Length, tLen = haystack.Length - pLen + 1;
            if (pLen == 0 || tLen <= 0)
                return -1;

            int j;
            for (int i = startOffset; i < tLen; i++)
            {
                for (j = 0; j < pLen; j++)
                    if (pattern[j] != -1 && haystack[i + j] != (byte)pattern[j])
                        break;

                if (j == pLen)
                    return startOffset + i;
            }

            return -1;
        }

        public static long IndexOf(this ProcessManager manager, short[] pattern, long offset = 0)
        {
            if (pattern == null || pattern.Length == 0 || pattern.Length > BufferSize)
                return -1;

            manager.Process.Refresh();
            var length = manager.Process.MainModule.ModuleMemorySize;
            var buffer = new byte[BufferSize];
            var increment = buffer.Length - pattern.Length + 1;

            while (offset < length)
            {
                if (!manager.Read(offset, buffer))
                    break;

                var index = buffer.IndexOf(pattern);
                if (index > -1)
                    return offset + index;

                offset += increment;
            }

            return -1;
        }

        public static long IndexOf(this Stream stream, short[] pattern, long offset = 0)
        {
            if (pattern == null || pattern.Length == 0 || pattern.Length > BufferSize)
                return -1;

            var length = stream.Length;
            var buffer = new byte[BufferSize];
            var increment = buffer.Length - pattern.Length + 1;

            while (offset < length)
            {
                stream.Position = offset;

                if (stream.Read(buffer, 0, buffer.Length) == 0)
                    break;

                var index = buffer.IndexOf(pattern);
                if (index > -1)
                    return offset + index;

                offset += increment;
            }

            return -1;
        }
    }
}