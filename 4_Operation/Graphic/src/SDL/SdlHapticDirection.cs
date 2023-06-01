using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl hapticdirection
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SdlHapticDirection
    {
        /// <summary>
        ///     The type
        /// </summary>
        public byte type;

        /// <summary>
        ///     The dir
        /// </summary>
        public fixed int dir[3];
    }
}