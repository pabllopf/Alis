

using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl controller sensor event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ControllerSensorEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public readonly uint type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public readonly uint timestamp;

        /// <summary>
        ///     The which SDL_JoystickID
        /// </summary>
        public readonly int which;

        /// <summary>
        ///     The sensor
        /// </summary>
        public readonly int sensor;

        /// <summary>
        ///     The data
        /// </summary>
        public readonly float data1;

        /// <summary>
        ///     The data
        /// </summary>
        public readonly float data2;

        /// <summary>
        ///     The data
        /// </summary>
        public readonly float data3;
    }
}