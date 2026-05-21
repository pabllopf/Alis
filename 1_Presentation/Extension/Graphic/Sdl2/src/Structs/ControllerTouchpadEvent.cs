

using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl controller touch pad event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ControllerTouchpadEvent
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
        ///     The which SDL_JoystickID
        /// </summary>
        public int which;

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