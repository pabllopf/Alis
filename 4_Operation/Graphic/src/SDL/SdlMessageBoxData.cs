using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl messageboxdata
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlMessageBoxData
    {
        /// <summary>
        ///     The flags
        /// </summary>
        public SdlMessageBoxFlags flags;

        /// <summary>
        ///     The window
        /// </summary>
        public IntPtr window; /* Parent window, can be NULL */

        /// <summary>
        ///     The title
        /// </summary>
        public string title; /* UTF-8 title */

        /// <summary>
        ///     The message
        /// </summary>
        public string message; /* UTF-8 message text */

        /// <summary>
        ///     The numbuttons
        /// </summary>
        public int numbuttons;

        /// <summary>
        ///     The buttons
        /// </summary>
        public SdlMessageBoxButtonData[] buttons;

        /// <summary>
        ///     The color scheme
        /// </summary>
        public SdlMessageBoxColorScheme? colorScheme; /* Can be NULL to use system settings */
    }
}