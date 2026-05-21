

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl display mode
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DisplayMode
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
        ///     The driver data
        /// </summary>
        public IntPtr DriverData { get; set; }
    }
}