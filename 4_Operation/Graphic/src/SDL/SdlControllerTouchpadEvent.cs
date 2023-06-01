using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl controllertouchpadevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlControllerTouchpadEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public uint type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public uint timestamp;

        /// <summary>
        ///     The which
        /// </summary>
        public int which; /* SDL_JoystickID */

        /// <summary>
        ///     The touchpad
        /// </summary>
        public int touchpad;

        /// <summary>
        ///     The finger
        /// </summary>
        public int finger;

        /// <summary>
        ///     The
        /// </summary>
        public float x;

        /// <summary>
        ///     The
        /// </summary>
        public float y;

        /// <summary>
        ///     The pressure
        /// </summary>
        public float pressure;
    }
}