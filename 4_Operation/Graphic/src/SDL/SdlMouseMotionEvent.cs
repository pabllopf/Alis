using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl mousemotionevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlMouseMotionEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public SdlEventType type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public uint timestamp;

        /// <summary>
        ///     The window id
        /// </summary>
        public uint windowID;

        /// <summary>
        ///     The which
        /// </summary>
        public uint which;

        /// <summary>
        ///     The state
        /// </summary>
        public byte state; /* bitmask of buttons */

        /// <summary>
        ///     The padding
        /// </summary>
        private byte padding1;

        /// <summary>
        ///     The padding
        /// </summary>
        private byte padding2;

        /// <summary>
        ///     The padding
        /// </summary>
        private byte padding3;

        /// <summary>
        ///     The
        /// </summary>
        public int x;

        /// <summary>
        ///     The
        /// </summary>
        public int y;

        /// <summary>
        ///     The xrel
        /// </summary>
        public int xrel;

        /// <summary>
        ///     The yrel
        /// </summary>
        public int yrel;
    }
}