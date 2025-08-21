#if WIN
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    internal static class User32
    {
        private const string DllName = "user32.dll";

        [DllImport(DllName, SetLastError = true, EntryPoint = "CreateWindowExW")]
        public static extern IntPtr CreateWindowEx(
            int dwExStyle,
            string lpClassName,
            string lpWindowName,
            int dwStyle,
            int x,
            int y,
            int nWidth,
            int nHeight,
            IntPtr hWndParent,
            IntPtr hMenu,
            IntPtr hInstance,
            IntPtr lpParam);

        [DllImport(DllName, SetLastError = true, EntryPoint = "DestroyWindow")]
        public static extern bool DestroyWindow(IntPtr hWnd);

        [DllImport(DllName, SetLastError = true, EntryPoint = "ShowWindow")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport(DllName, SetLastError = true, EntryPoint = "UpdateWindow")]
        public static extern bool UpdateWindow(IntPtr hWnd);

        [DllImport(DllName, SetLastError = true, EntryPoint = "SetWindowTextW")]
        public static extern bool SetWindowText(IntPtr hWnd, string lpString);

        [DllImport(DllName, SetLastError = true, EntryPoint = "SetWindowPos")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        [DllImport(DllName, SetLastError = true, EntryPoint = "DefWindowProcW")]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport(DllName, SetLastError = true, EntryPoint = "RegisterClassW")]
        public static extern ushort RegisterClass(ref Wndclass lpWndClass);

        [DllImport(DllName, SetLastError = true, EntryPoint = "GetDC")]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport(DllName, SetLastError = true, EntryPoint = "ReleaseDC")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDc);

        [DllImport(DllName, SetLastError = true, EntryPoint = "PeekMessageW")]
        public static extern bool PeekMessage(out Msg lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);

        [DllImport(DllName, SetLastError = true, EntryPoint = "TranslateMessage")]
        public static extern bool TranslateMessage(ref Msg lpMsg);

        [DllImport(DllName, SetLastError = true, EntryPoint = "DispatchMessageW")]
        public static extern IntPtr DispatchMessage(ref Msg lpMsg);

        [DllImport(DllName, SetLastError = true, EntryPoint = "GetMessageW")]
        public static extern int GetMessage(out Msg lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

        [DllImport(DllName, SetLastError = true, EntryPoint = "GetWindowTextW")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport(DllName, SetLastError = true, EntryPoint = "GetWindowRect")]
        public static extern int GetWindowRect(IntPtr hWnd, out Rect lpRect);

        [DllImport(DllName, SetLastError = true, EntryPoint = "IsWindowVisible")]
        public static extern bool IsWindowVisible(IntPtr hWnd);
    }
}
#endif