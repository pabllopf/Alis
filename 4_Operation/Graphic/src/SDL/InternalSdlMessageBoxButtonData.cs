using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The internal sdl messageboxbuttondata
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct InternalSdlMessageBoxButtonData
    {
        /// <summary>
        ///     The flags
        /// </summary>
        public Sdl.SdlMessageBoxButtonFlags flags;

        /// <summary>
        ///     The buttonid
        /// </summary>
        public int buttonid;

        /// <summary>
        ///     The text
        /// </summary>
        public IntPtr text; /* The UTF-8 button text */
    }
}