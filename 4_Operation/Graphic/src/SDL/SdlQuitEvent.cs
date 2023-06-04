using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl quitevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlQuitEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public SdlEventType type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public uint timestamp;
    }
}