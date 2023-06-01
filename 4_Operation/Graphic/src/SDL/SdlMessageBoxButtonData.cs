using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl messageboxbuttondata
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlMessageBoxButtonData
    {
        /// <summary>
        ///     The flags
        /// </summary>
        public SdlMessageBoxButtonFlags flags;

        /// <summary>
        ///     The buttonid
        /// </summary>
        public int buttonid;

        /// <summary>
        ///     The text
        /// </summary>
        public string text; /* The UTF-8 button text */
    }
}