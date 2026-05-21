

using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl touch finger event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TouchFingerEvent
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
        ///     The finger id
        /// </summary>
        public long fingerId;

        /// <summary>
        ///     The
        /// </summary>
        public float x;

        /// <summary>
        ///     The
        /// </summary>
        public float y;

        /// <summary>
        ///     The dx
        /// </summary>
        public float dx;

        /// <summary>
        ///     The dy
        /// </summary>
        public float dy;

        /// <summary>
        ///     The pressure
        /// </summary>
        public float pressure;

        /// <summary>
        ///     The window id
        /// </summary>
        public uint windowID;
    }
}