

using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl mouse motion event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MouseMotionEvent
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
        ///     The state
        /// </summary>
        public readonly byte state;

        /// <summary>
        ///     The
        /// </summary>
        public readonly int x;

        /// <summary>
        ///     The
        /// </summary>
        public readonly int y;

        /// <summary>
        ///     The x rel
        /// </summary>
        public readonly int xRel;

        /// <summary>
        ///     The y rel
        /// </summary>
        public readonly int yRel;
    }
}