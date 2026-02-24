// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:User32.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

#if winx64 || winx86 || winarm64 || winarm || win
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    /// <summary>
    /// </summary>
    internal static class User32
    {
        /// <summary>
        /// </summary>
        private const string DllName = "user32.dll";

        /// <summary>
        /// </summary>
        /// <param name="dwExStyle"></param>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <param name="dwStyle"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="nWidth"></param>
        /// <param name="nHeight"></param>
        /// <param name="hWndParent"></param>
        /// <param name="hMenu"></param>
        /// <param name="hInstance"></param>
        /// <param name="lpParam"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "CreateWindowExW")]
        [ExcludeFromCodeCoverage]
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

        /// <summary>
        ///     SetWindowTextA (ANSI version)
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpString"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "SetWindowTextA")]
        [ExcludeFromCodeCoverage]
        public static extern bool SetWindowTextA(IntPtr hWnd, string lpString);

        /// <summary>
        ///     CreateWindowExA (ANSI version)
        /// </summary>
        [DllImport(DllName, SetLastError = true, EntryPoint = "CreateWindowExA")]
        [ExcludeFromCodeCoverage]
        public static extern IntPtr CreateWindowExA(
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

        /// <summary>
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "DestroyWindow")]
        [ExcludeFromCodeCoverage]
        public static extern bool DestroyWindow(IntPtr hWnd);

        /// <summary>
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "ShowWindow")]
        [ExcludeFromCodeCoverage]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        /// <summary>
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "UpdateWindow")]
        [ExcludeFromCodeCoverage]
        public static extern bool UpdateWindow(IntPtr hWnd);

        /// <summary>
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpString"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "SetWindowTextW")]
        [ExcludeFromCodeCoverage]
        public static extern bool SetWindowText(IntPtr hWnd, string lpString);

        /// <summary>
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="hWndInsertAfter"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <param name="uFlags"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "SetWindowPos")]
        [ExcludeFromCodeCoverage]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        /// <summary>
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "DefWindowProcW")]
        [ExcludeFromCodeCoverage]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// </summary>
        /// <param name="lpWndClass"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "RegisterClassW")]
        [ExcludeFromCodeCoverage]
        public static extern ushort RegisterClass(ref Wndclass lpWndClass);

        /// <summary>
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "GetDC")]
        [ExcludeFromCodeCoverage]
        public static extern IntPtr GetDC(IntPtr hWnd);

        /// <summary>
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="hDc"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "ReleaseDC")]
        [ExcludeFromCodeCoverage]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDc);

        /// <summary>
        /// </summary>
        /// <param name="lpMsg"></param>
        /// <param name="hWnd"></param>
        /// <param name="wMsgFilterMin"></param>
        /// <param name="wMsgFilterMax"></param>
        /// <param name="wRemoveMsg"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "PeekMessageW")]
        [ExcludeFromCodeCoverage]
        public static extern bool PeekMessage(out Msg lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);

        /// <summary>
        /// </summary>
        /// <param name="lpMsg"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "TranslateMessage")]
        [ExcludeFromCodeCoverage]
        public static extern bool TranslateMessage(ref Msg lpMsg);

        /// <summary>
        /// </summary>
        /// <param name="lpMsg"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "DispatchMessageW")]
        [ExcludeFromCodeCoverage]
        public static extern IntPtr DispatchMessage(ref Msg lpMsg);

        /// <summary>
        /// </summary>
        /// <param name="lpMsg"></param>
        /// <param name="hWnd"></param>
        /// <param name="wMsgFilterMin"></param>
        /// <param name="wMsgFilterMax"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "GetMessageW")]
        [ExcludeFromCodeCoverage]
        public static extern int GetMessage(out Msg lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

        /// <summary>
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpString"></param>
        /// <param name="nMaxCount"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "GetWindowTextW")]
        [ExcludeFromCodeCoverage]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        /// <summary>
        ///     /
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpRect"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "GetWindowRect")]
        [ExcludeFromCodeCoverage]
        public static extern int GetWindowRect(IntPtr hWnd, out Rect lpRect);

        /// <summary>
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "IsWindowVisible")]
        [ExcludeFromCodeCoverage]
        public static extern bool IsWindowVisible(IntPtr hWnd);
    }
}

#endif