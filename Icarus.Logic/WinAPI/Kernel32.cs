using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Icarus.Logic.WinAPI
{
    internal static class Kernel32
    {
        public const int PROCESS_ALL_ACCESS = 0x1F0FFF;

        private const string DLL_NAME = "kernel32.dll";

        [DllImport(DLL_NAME, SetLastError = true)]
        public static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport(DLL_NAME, SetLastError = true)]
        public static extern bool FreeLibrary(IntPtr hModule);

        [DllImport(DLL_NAME, SetLastError = true)]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);

        [DllImport(DLL_NAME, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hProcess);

        [DllImport(DLL_NAME, SetLastError = true)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, ref int lpNumberOfBytesRead);

        [DllImport(DLL_NAME, SetLastError = true)]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

        [DllImport(DLL_NAME, SetLastError = true)]
        public static extern bool QueryFullProcessImageName(IntPtr hProcess, uint dwFlags, StringBuilder lpExeName, ref int lpdwSize);
    }
}