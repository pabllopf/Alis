

using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl mouse wheel event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MouseWheelEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public readonly EventType type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public readonly uint timestamp;

        /// <summary>
        ///     The window id
        /// </summary>
        public readonly uint windowID;

        /// <summary>
        ///     The which
        /// </summary>
        public readonly uint which;

        /// <summary>
        ///     The
        /// </summary>
        public readonly int x;

        /// <summary>
        ///     The
        /// </summary>
        public readonly int y;

        /// <summary>
        ///     The direction
        /// </summary>
        public readonly uint direction;

        /// <summary>
        ///     The precise
        /// </summary>
        public readonly float preciseX;

        /// <summary>
        ///     The precise
        /// </summary>
        public readonly float preciseY;
    }
}