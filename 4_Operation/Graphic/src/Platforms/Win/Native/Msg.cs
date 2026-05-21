

#if winx64 || winx86 || winarm64 || winarm || win
using System;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    /// <summary>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct Msg
    {
        /// <summary>
        ///     The hwnd
        /// </summary>
        public IntPtr hwnd;

        /// <summary>
        ///     The message
        /// </summary>
        public uint message;

        /// <summary>
        ///     The param
        /// </summary>
        public IntPtr wParam;

        /// <summary>
        ///     The param
        /// </summary>
        public IntPtr lParam;

        /// <summary>
        ///     The time
        /// </summary>
        public uint time;

        /// <summary>
        ///     The pt
        /// </summary>
        public int pt_x;

        /// <summary>
        ///     The pt
        /// </summary>
        public int pt_y;
    }
}

#endif