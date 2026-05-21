

using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl joy button event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct JoyButtonEvent
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
        ///     The which
        /// </summary>
        public readonly int which;

        /// <summary>
        ///     The button
        /// </summary>
        public readonly byte button;

        /// <summary>
        ///     The state
        /// </summary>
        public readonly byte state;
    }
}