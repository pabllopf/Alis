

using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl multi gesture event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MultiGestureEvent
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
        ///     The touch id
        /// </summary>
        public readonly long touchId;

        /// <summary>
        ///     The theta
        /// </summary>
        public readonly float dTheta;

        /// <summary>
        ///     The dist
        /// </summary>
        public readonly float dDist;

        /// <summary>
        ///     The
        /// </summary>
        public readonly float x;

        /// <summary>
        ///     The
        /// </summary>
        public readonly float y;

        /// <summary>
        ///     The num fingers
        /// </summary>
        public readonly ushort numFingers;

        /// <summary>
        ///     The padding
        /// </summary>
        public readonly ushort padding;
    }
}