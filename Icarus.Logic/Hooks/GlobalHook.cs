using Icarus.Logic.Hooks.Enums;
using Icarus.Logic.Hooks.Events;
using Icarus.Logic.Hooks.Structs;
using Icarus.Logic.WinAPI;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Icarus.Logic.Hooks
{
    public class GlobalHook : IDisposable
    {
        public event EventHandler<GlobalKeyboardHookEventArgs> KeyboardPressed;

        public event EventHandler<GlobalMouseHookEventArgs> MousePressed;

        public event EventHandler<IntPtr> WindowChanged;

        public bool IsKeyboardHooked => KeyboardHookHandle != IntPtr.Zero;
        public bool IsMouseHooked => MouseHookHandle != IntPtr.Zero;
        public bool IsWindowHooked => WindowHookHandle != IntPtr.Zero;

        private readonly IntPtr User32Handle;

        private IntPtr KeyboardHookHandle;
        private IntPtr MouseHookHandle;
        private IntPtr WindowHookHandle;
        private User32.HookProc KeyboardHookAction;
        private User32.HookProc MouseHookAction;
        private User32.WinEvent WindowHookAction;

        public GlobalHook()
        {
            KeyboardHookAction = LowLevelKeyboardAction;
            MouseHookAction = LowLevelMouseAction;
            WindowHookAction = WindowChangedAction;

            KeyboardHookHandle = IntPtr.Zero;
            MouseHookHandle = IntPtr.Zero;
            WindowHookHandle = IntPtr.Zero;

            // load User32
            if ((User32Handle = Kernel32.LoadLibrary("User32")) == IntPtr.Zero)
                throw new Win32Exception(Marshal.GetLastWin32Error());

            KeyBinding.Load();
        }

        ~GlobalHook() => Dispose(false);

        public void HookKeyboard()
        {
            KeyboardHookHandle = User32.SetWindowsHookEx(User32.WH_KEYBOARD_LL, KeyboardHookAction, User32Handle, 0);
            if (KeyboardHookHandle == IntPtr.Zero)
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        public void HookMouse()
        {
            MouseHookHandle = User32.SetWindowsHookEx(User32.WH_MOUSE_LL, MouseHookAction, User32Handle, 0);
            if (MouseHookHandle == IntPtr.Zero)
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        public void HookWindowChange()
        {
            WindowHookHandle = User32.SetWinEventHook(User32.EVENT_SYSTEM_FOREGROUND, User32.EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, WindowHookAction, 0, 0, User32.WINEVENT_OUTOFCONTEXT);
            if (WindowHookHandle == IntPtr.Zero)
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        public bool IsActiveWindow(IntPtr windowHandle) => User32.GetForegroundWindow() == windowHandle;

        private unsafe IntPtr LowLevelKeyboardAction(int nCode, IntPtr wParam, IntPtr lParam)
        {
            var wparamTyped = (KeyboardState)wParam.ToInt32();

            if ((KeyboardState.All & wparamTyped) == wparamTyped)
            {
                var p = Unsafe.Read<LowLevelKeyboardInputEvent>(lParam.ToPointer());

                if (KeyBinding.TryGet(p.VirtualCode, out _))
                {
                    var args = new GlobalKeyboardHookEventArgs(p, wparamTyped);
                    KeyboardPressed?.Invoke(this, args);

                    if (args.Handled)
                        return (IntPtr)1;
                }
            }

            return User32.CallNextHookEx(KeyboardHookHandle, nCode, wParam, lParam);
        }

        private unsafe IntPtr LowLevelMouseAction(int nCode, IntPtr wParam, IntPtr lParam)
        {
            var state = (MouseState)(wParam.ToInt32() - 1); // fix for MouseMove 0x200 mask

            if ((MouseState.All & state) == state)
            {
                var p = Unsafe.Read<LowLevelMouseInputEvent>(lParam.ToPointer());

                var args = new GlobalMouseHookEventArgs(p, state);
                MousePressed?.Invoke(this, args);

                if (args.Handled)
                    return (IntPtr)1;
            }

            return User32.CallNextHookEx(MouseHookHandle, nCode, wParam, lParam);
        }

        private void WindowChangedAction(IntPtr hWinEventHook, int eventType, IntPtr hwnd, int idObject, int idChild, int dwEventThread, int dwmsEventTime)
        {
            WindowChanged?.Invoke(this, hwnd);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                KeyboardHookAction -= LowLevelKeyboardAction;
                MouseHookAction -= LowLevelMouseAction;
                WindowHookAction -= WindowChangedAction;

                if (KeyboardHookHandle != IntPtr.Zero && !User32.UnhookWindowsHookEx(KeyboardHookHandle))
                    throw new Win32Exception(Marshal.GetLastWin32Error());

                if (MouseHookHandle != IntPtr.Zero && !User32.UnhookWindowsHookEx(MouseHookHandle))
                    throw new Win32Exception(Marshal.GetLastWin32Error());

                if (WindowHookHandle != IntPtr.Zero && !User32.UnhookWinEvent(WindowHookHandle))
                    throw new Win32Exception(Marshal.GetLastWin32Error());

                if (User32Handle != IntPtr.Zero && !Kernel32.FreeLibrary(User32Handle))
                    throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }
    }
}