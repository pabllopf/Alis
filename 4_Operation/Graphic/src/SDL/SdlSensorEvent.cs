using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl sensorevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlSensorEvent
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
        public int which;

        /// <summary>
        ///     The data
        /// </summary>
        public float[] data;

        /// <summary>
        /// Initializes a new instance of the <see cref="SdlSensorEvent"/> class
        /// </summary>
        public SdlSensorEvent()
        {
            type = SdlEventType.SdlFirstevent;
            timestamp = 0;
            which = 0;
            data = new float[6];
        }
    }
}