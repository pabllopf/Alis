using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl displayevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlDisplayEvent
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
        ///     The display
        /// </summary>
        public uint display;

        /// <summary>
        ///     The display event
        /// </summary>
        public SdlDisplayEventId displayEvent;

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
        ///     The data
        /// </summary>
        public int data1;
    }
}