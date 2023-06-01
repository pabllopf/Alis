using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl displaymode
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlDisplayMode
    {
        /// <summary>
        ///     The format
        /// </summary>
        public uint format;

        /// <summary>
        ///     The
        /// </summary>
        public int w;

        /// <summary>
        ///     The
        /// </summary>
        public int h;

        /// <summary>
        ///     The refresh rate
        /// </summary>
        public int refresh_rate;

        /// <summary>
        ///     The driverdata
        /// </summary>
        public IntPtr driverdata; // void*
    }
}