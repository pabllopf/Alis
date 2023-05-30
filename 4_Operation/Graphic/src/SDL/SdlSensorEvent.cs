using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl sensorevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SdlSensorEvent
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
        public fixed float data[6];
    }
}