

using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl haptic direction
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct HapticDirection
    {
        /// <summary>
        ///     The type
        /// </summary>
        public readonly byte type;

        /// <summary>
        ///     The dir
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 3)]
        public readonly int[] dir;
    }
}