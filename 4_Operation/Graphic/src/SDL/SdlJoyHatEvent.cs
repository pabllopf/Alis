using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl joyhatevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlJoyHatEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public SdlEventType type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public uint timestamp;

        /// <summary>
        ///     The which
        /// </summary>
        public int which; /* SDL_JoystickID */

        /// <summary>
        ///     The hat
        /// </summary>
        public byte hat; /* index of the hat */

        /// <summary>
        ///     The hat value
        /// </summary>
        public byte hatValue; /* value, lolC# */

        /// <summary>
        ///     The padding
        /// </summary>
        private byte padding1;

        /// <summary>
        ///     The padding
        /// </summary>
        private byte padding2;
    }
}