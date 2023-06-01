using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl vertex
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlVertex
    {
        /// <summary>
        ///     The position
        /// </summary>
        public SdlFPoint position;

        /// <summary>
        ///     The color
        /// </summary>
        public SdlColor color;

        /// <summary>
        ///     The tex coord
        /// </summary>
        public SdlFPoint tex_coord;
    }
}