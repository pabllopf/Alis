using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl controllerbuttonevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlControllerButtonEvent
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
        ///     The button
        /// </summary>
        public byte button;

        /// <summary>
        ///     The state
        /// </summary>
        public byte state;

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