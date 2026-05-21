

using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl controller axis event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ControllerAxisEvent
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
        ///     The which SDL_JoystickID
        /// </summary>
        public int which;

        /// <summary>
        ///     The axis
        /// </summary>
        public byte axis;
    }
}