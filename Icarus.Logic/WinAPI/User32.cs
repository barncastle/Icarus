using System;
using System.Runtime.InteropServices;

namespace Icarus.Logic.WinAPI
{
    internal static class User32
    {
        public const int EVENT_SYSTEM_FOREGROUND = 3;
        public const int WH_KEYBOARD_LL = 13;
        public const int WH_MOUSE_LL = 14;
        public const int WINEVENT_OUTOFCONTEXT = 0;

        private const string DLL_NAME = "user32.dll";

        [DllImport(DLL_NAME, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, int dwThreadId);

        [DllImport(DLL_NAME, SetLastError = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr hHook);

        [DllImport(DLL_NAME, SetLastError = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hHook, int code, IntPtr wParam, IntPtr lParam);

        [DllImport(DLL_NAME, SetLastError = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport(DLL_NAME, SetLastError = true)]
        public static extern IntPtr SetWinEventHook(int eventMin, int eventMax, IntPtr hmodWinEventProc, WinEvent lpfnWinEventProc, int idProcess, int idThread, int dwFlags);

        [DllImport(DLL_NAME, SetLastError = true)]
        public static extern bool UnhookWinEvent(IntPtr hWinEventHook);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void WinEvent(IntPtr hWinEventHook, int eventType, IntPtr hwnd, int idObject, int idChild, int dwEventThread, int dwmsEventTime);
    }
}