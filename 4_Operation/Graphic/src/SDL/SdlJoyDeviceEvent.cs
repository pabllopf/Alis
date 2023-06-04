using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl joydeviceevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlJoyDeviceEvent
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
    }
}