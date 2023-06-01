using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl joyballevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlJoyBallEvent
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
        ///     The ball
        /// </summary>
        public byte ball;

        /// <summary>
        ///     The padding
        /// </summary>
        private byte padding1;

        /// <summary>
        ///     The padding
        /// </summary>
        private byte padding2;

        /// <summary>
        ///     The padding
        /// </summary>
        private byte padding3;

        /// <summary>
        ///     The xrel
        /// </summary>
        public short xrel;

        /// <summary>
        ///     The yrel
        /// </summary>
        public short yrel;
    }
}