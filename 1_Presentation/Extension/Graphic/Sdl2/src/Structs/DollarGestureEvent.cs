

using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl dollar gesture event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DollarGestureEvent
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
        ///     The touch id
        /// </summary>
        public long touchId;

        /// <summary>
        ///     The gesture id
        /// </summary>
        public long gestureId;

        /// <summary>
        ///     The num fingers
        /// </summary>
        public uint numFingers;

        /// <summary>
        ///     The error
        /// </summary>
        public float error;

        /// <summary>
        ///     The
        /// </summary>
        public float x;

        /// <summary>
        ///     The
        /// </summary>
        public float y;
    }
}