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
        public int[] dir;

        /// <summary>
        /// Initializes a new instance of the <see cref="SdlHapticDirection"/> class
        /// </summary>
        public SdlHapticDirection()
        {
            type = 0;
            dir = new int[3];
        }
    }
}