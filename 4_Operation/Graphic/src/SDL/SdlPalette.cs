using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl palette
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlPalette
    {
        /// <summary>
        ///     The ncolors
        /// </summary>
        public int ncolors;

        /// <summary>
        ///     The colors
        /// </summary>
        public IntPtr colors;

        /// <summary>
        ///     The version
        /// </summary>
        public int version;

        /// <summary>
        ///     The refcount
        /// </summary>
        public int refcount;
    }
}