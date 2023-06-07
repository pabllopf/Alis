using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl syswmevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlSysWmEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public SdlEventType type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public uint timestamp;

        /// <summary>
        ///     The msg
        /// </summary>
        public IntPtr msg; 
    }
}