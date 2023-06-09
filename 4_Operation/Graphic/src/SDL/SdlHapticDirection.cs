using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl hapticdirection
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlHapticDirection
    {
        /// <summary>
        ///     The type
        /// </summary>
        public byte type;

        /// <summary>
        ///     The dir
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 3)]
        public int[] dir;
    }
}