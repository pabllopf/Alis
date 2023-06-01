using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl rect
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlRect
    {
        /// <summary>
        ///     The
        /// </summary>
        public int x;

        /// <summary>
        ///     The
        /// </summary>
        public int y;

        /// <summary>
        ///     The
        /// </summary>
        public int w;

        /// <summary>
        ///     The
        /// </summary>
        public int h;
    }
}