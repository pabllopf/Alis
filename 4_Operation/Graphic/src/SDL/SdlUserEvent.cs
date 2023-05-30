using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl userevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlUserEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public uint type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public uint timestamp;

        /// <summary>
        ///     The window id
        /// </summary>
        public uint windowID;

        /// <summary>
        ///     The code
        /// </summary>
        public int code;

        /// <summary>
        ///     The data
        /// </summary>
        public IntPtr data1; /* user-defined */

        /// <summary>
        ///     The data
        /// </summary>
        public IntPtr data2; /* user-defined */
    }
}