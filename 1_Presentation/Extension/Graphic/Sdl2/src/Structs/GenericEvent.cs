

using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl generic event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GenericEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public EventType type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public uint timestamp;
    }
}