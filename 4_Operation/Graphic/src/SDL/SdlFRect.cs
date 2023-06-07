using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl frect
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlFRect
    {
        /// <summary>
        ///     The
        /// </summary>
        public float x;

        /// <summary>
        ///     The
        /// </summary>
        public float y;

        /// <summary>
        ///     The
        /// </summary>
        public float w;

        /// <summary>
        ///     The
        /// </summary>
        public float h;
    }
}