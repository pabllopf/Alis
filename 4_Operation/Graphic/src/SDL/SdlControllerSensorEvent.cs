using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl controllersensorevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlControllerSensorEvent
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
        ///     The sensor
        /// </summary>
        public int sensor;

        /// <summary>
        ///     The data
        /// </summary>
        public float data1;

        /// <summary>
        ///     The data
        /// </summary>
        public float data2;

        /// <summary>
        ///     The data
        /// </summary>
        public float data3;
    }
}