

using System;
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl text editing event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct TextEditingEvent
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
        ///     The window id
        /// </summary>
        public readonly uint windowID;

        /// <summary>
        ///     The sdl text editing event text size
        /// </summary>
        private readonly IntPtr textPtr;

        /// <summary>
        ///     The start
        /// </summary>
        public readonly int start;

        /// <summary>
        ///     The length
        /// </summary>
        public readonly int length;

        /// <summary>
        ///     Gets the value of the text
        /// </summary>
        public string Text => Marshal.PtrToStringAnsi(textPtr);
    }
}