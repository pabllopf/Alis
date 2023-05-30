using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl dropevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlDropEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public SdlEventType type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public uint timestamp;

        /* char* filename, to be freed.
             * Access the variable EXACTLY ONCE like this:
             * string s = SDL.UTF8_ToManaged(evt.drop.file, true);
             */
        /// <summary>
        ///     The file
        /// </summary>
        public IntPtr file;

        /// <summary>
        ///     The window id
        /// </summary>
        public uint windowID;
    }
}