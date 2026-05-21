

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl user event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct UserEvent
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
        public IntPtr Data1 { get; set; }

        /// <summary>
        ///     The data
        /// </summary>
        public IntPtr Data2 { get; set; }
    }
}