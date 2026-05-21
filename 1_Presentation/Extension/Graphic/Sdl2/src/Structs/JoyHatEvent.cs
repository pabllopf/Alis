

using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl joy hat event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct JoyHatEvent
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
        ///     The hat
        /// </summary>
        public readonly byte hat;

        /// <summary>
        ///     The hat value
        /// </summary>
        public readonly byte hatValue;
    }
}