

using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl display event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DisplayEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public EventType type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public uint timestamp;

        /// <summary>
        ///     The display
        /// </summary>
        public uint display;

        /// <summary>
        ///     The display event
        /// </summary>
        public DisplayEventId displayEvent;
    }
}