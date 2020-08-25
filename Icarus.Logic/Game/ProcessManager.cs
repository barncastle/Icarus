using Icarus.Logic.Patching;
using Icarus.Logic.Patterns;
using Icarus.Logic.WinAPI;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Icarus.Logic.Game
{
    public class ProcessManager : IDisposable
    {
        internal event EventHandler ProcessAttached;

        internal event EventHandler ProcessDetached;

        public Process Process { get; private set; }
        public long BaseAddress { get; private set; }
        public int Build { get; private set; }
        public string ProcessPath { get; private set; }

        internal IntPtr Handle { get; private set; } = IntPtr.Zero;
        internal IntPtr WindowHandle => !HasExited() ? Process.MainWindowHandle : IntPtr.Zero;

        public bool Attach(Process process)
        {
            Detach();

            Process = process;
            Process.EnableRaisingEvents = true;
            Process.Exited += ProcessDetached;
            BaseAddress = Process.MainModule.BaseAddress.ToInt64();

            if ((Handle = Kernel32.OpenProcess(Kernel32.PROCESS_ALL_ACCESS, false, Process.Id)) != IntPtr.Zero)
            {
                GetClientBuild();

                ProcessAttached?.Invoke(this, EventArgs.Empty);
                return true;
            }

            return false;
        }

        public void Detach()
        {
            if (Process != null)
            {
                if (Handle != IntPtr.Zero && !Kernel32.CloseHandle(Handle))
                    throw new Win32Exception(Marshal.GetLastWin32Error());

                Process.Exited -= ProcessDetached;
                Process.Dispose();
                Process = null;

                BaseAddress = Build = 0;
                Handle = IntPtr.Zero;
                ProcessDetached?.Invoke(this, EventArgs.Empty);
            }
        }

        public bool HasExited()
        {
            if (Process != null)
            {
                Process.Refresh();
                return Process.HasExited;
            }

            return true;
        }

        #region Client

        private string GetProcessPath()
        {
            if (Process != null)
            {
                var buffer = new StringBuilder(0x104);
                int bufferSize = buffer.Capacity + 1;

                if (Kernel32.QueryFullProcessImageName(Process.Handle, 0, buffer, ref bufferSize))
                    return ProcessPath = buffer.ToString();
            }

            return ProcessPath = "";
        }

        private int GetClientBuild()
        {
            // read executable version
            var filePath = GetProcessPath();
            if (File.Exists(filePath))
            {
                var version = FileVersionInfo.GetVersionInfo(filePath);
                if (version.FilePrivatePart != 0)
                    return Build = version.FilePrivatePart;
            }

            // read pattern from memory
            var buildPattern = Common.GetBuildPattern();
            if (buildPattern.Resolve(this))
            {
                long offset = buildPattern.Offset + buildPattern.Source.Length;
                string buildstr = Read(offset, 0x10, ')');

                if (int.TryParse(buildstr, out int build))
                    return Build = build;
            }

            return Build = 0;
        }

        /// <summary>
        /// Generates a new client executable with the in-memory patches concreted
        /// </summary>
        /// <returns></returns>
        public bool PatchClient() => Patcher.Patch(this);

        #endregion Client

        #region Memory

        public bool Read(long offset, byte[] buffer)
        {
            int read = 0;
            if (!Kernel32.ReadProcessMemory(Handle, (IntPtr)offset, buffer, buffer.Length, ref read))
                throw new Win32Exception(Marshal.GetLastWin32Error());
            return read == buffer.Length;
        }

        public T Read<T>(long offset) where T : unmanaged
        {
            byte[] buffer = new byte[Unsafe.SizeOf<T>()];
            Read(offset, buffer);
            return Unsafe.ReadUnaligned<T>(ref buffer[0]);
        }

        public unsafe T[] Read<T>(long offset, int count) where T : unmanaged
        {
            byte[] buffer = new byte[Unsafe.SizeOf<T>() * count];
            Read(offset, buffer);

            T[] result = new T[count];
            Unsafe.CopyBlockUnaligned(Unsafe.AsPointer(ref result[0]), Unsafe.AsPointer(ref buffer[0]), (uint)buffer.Length);
            return result;
        }

        public string Read(long offset, int length, char? delim = null)
        {
            byte[] buffer = new byte[length];
            Read(offset, buffer);
            string value = Encoding.UTF8.GetString(buffer);

            return delim.HasValue ? value.Split(delim.Value)[0] : value;
        }

        public long ReadPointer(params long[] offsets)
        {
            if (offsets == null || offsets.Length == 0)
                return 0;

            uint pointer = Read<uint>(offsets[0]);
            for (int i = 1; i < offsets.Length && pointer > 0; i++)
                pointer = Read<uint>(pointer + offsets[i]);

            return pointer;
        }

        public bool Write(long offset, byte[] buffer)
        {
            int written = 0;
            if (!Kernel32.WriteProcessMemory(Handle, (IntPtr)offset, buffer, buffer.Length, ref written))
                throw new Win32Exception(Marshal.GetLastWin32Error());
            return written == buffer.Length;
        }

        public bool Write<T>(long offset, T value) where T : unmanaged
        {
            byte[] buffer = new byte[Unsafe.SizeOf<T>()];
            Unsafe.WriteUnaligned(ref buffer[0], value);
            return Write(offset, buffer);
        }

        public unsafe bool Write<T>(long offset, T[] value) where T : unmanaged
        {
            if (!(value is byte[] buffer))
            {
                buffer = new byte[value.Length * Unsafe.SizeOf<T>()];
                Unsafe.CopyBlockUnaligned(Unsafe.AsPointer(ref buffer[0]), Unsafe.AsPointer(ref value[0]), (uint)buffer.Length);
            }

            return Write(offset, buffer);
        }

        public bool Write(long offset, string value, char? delim = null)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(value + delim);
            return Write(offset, buffer);
        }

        #endregion Memory

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                Detach();
                Process?.Dispose();
            }
        }

        ~ProcessManager() => Dispose(false);
    }
}