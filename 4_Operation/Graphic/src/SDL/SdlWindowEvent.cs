using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl windowevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlWindowEvent
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
        ///     The window event
        /// </summary>
        public SdlWindowEventId windowEvent; // event, lolC#

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

        /// <summary>
        ///     The data
        /// </summary>
        public int data2;
    }
}