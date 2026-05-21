

using System;
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl sys wm event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SysWmEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public readonly EventType type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public readonly uint timestamp;

        /// <summary>
        ///     The msg
        /// </summary>
        public IntPtr Msg { get; set; }
    }
}