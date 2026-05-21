

using System;
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl drop event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DropEvent
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
        ///     The file
        /// </summary>
        public IntPtr File { get; set; }

        /// <summary>
        ///     The window id
        /// </summary>
        public readonly uint windowID;
    }
}