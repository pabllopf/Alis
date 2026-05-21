

#if winx64 || winx86 || winarm64 || winarm || win
using System;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    /// <summary>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct Wndclass
    {
        /// <summary>
        /// </summary>
        public uint style;

        /// <summary>
        /// </summary>
        public IntPtr lpfnWndProc;

        /// <summary>
        /// </summary>
        public int cbClsExtra;

        /// <summary>
        /// </summary>
        public int cbWndExtra;

        /// <summary>
        /// </summary>
        public IntPtr hInstance;

        /// <summary>
        /// </summary>
        public IntPtr hIcon;

        /// <summary>
        /// </summary>
        public IntPtr hCursor;

        /// <summary>
        /// </summary>
        public IntPtr hbrBackground;

        /// <summary>
        /// </summary>
        public string lpszMenuName;

        /// <summary>
        /// </summary>
        public string lpszClassName;
    }
}
#endif