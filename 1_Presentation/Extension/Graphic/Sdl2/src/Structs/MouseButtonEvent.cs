

using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl mouse button event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MouseButtonEvent
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
        ///     The button
        /// </summary>
        public readonly byte button;

        /// <summary>
        ///     The state
        /// </summary>
        public readonly byte state;

        /// <summary>
        ///     The clicks
        /// </summary>
        public readonly byte clicks;

        /// <summary>
        ///     The
        /// </summary>
        public readonly int x;

        /// <summary>
        ///     The
        /// </summary>
        public readonly int y;
    }
}