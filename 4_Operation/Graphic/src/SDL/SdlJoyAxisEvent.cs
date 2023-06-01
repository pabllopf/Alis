using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl joyaxisevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlJoyAxisEvent
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
        ///     The axis
        /// </summary>
        public byte axis;

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
        ///     The axis value
        /// </summary>
        public short axisValue; /* value, lolC# */

        /// <summary>
        ///     The padding
        /// </summary>
        public ushort padding4;
    }
}