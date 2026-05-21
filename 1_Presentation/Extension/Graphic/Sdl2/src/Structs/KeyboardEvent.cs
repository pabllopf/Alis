

using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl keyboard event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct KeyboardEvent
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
        ///     The state
        /// </summary>
        public readonly byte state;

        /// <summary>
        ///     The repeat
        /// </summary>
        public readonly byte repeat;

        /// <summary>
        ///     The key sym
        /// </summary>
        public KeySym KeySym { get; set; }
    }
}