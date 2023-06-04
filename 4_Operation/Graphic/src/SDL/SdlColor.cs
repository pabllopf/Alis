using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl color
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlColor
    {
        /// <summary>
        ///     The
        /// </summary>
        public byte r;

        /// <summary>
        ///     The
        /// </summary>
        public byte g;

        /// <summary>
        ///     The
        /// </summary>
        public byte b;

        /// <summary>
        ///     The
        /// </summary>
        public byte a;
    }
}