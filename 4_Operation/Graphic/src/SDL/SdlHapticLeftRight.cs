using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl hapticleftright
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlHapticLeftRight
    {
        // Header
        /// <summary>
        ///     The type
        /// </summary>
        public ushort type;

        // Replay
        /// <summary>
        ///     The length
        /// </summary>
        public uint length;

        // Rumble
        /// <summary>
        ///     The large magnitude
        /// </summary>
        public ushort large_magnitude;

        /// <summary>
        ///     The small magnitude
        /// </summary>
        public ushort small_magnitude;
    }
}