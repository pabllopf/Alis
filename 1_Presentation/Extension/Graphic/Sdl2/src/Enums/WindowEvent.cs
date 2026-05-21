

using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl window event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct WindowEvent
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
        ///     The window event
        /// </summary>
        public readonly WindowEventId windowEvent;

        /// <summary>
        ///     The padding
        /// </summary>
        private readonly byte padding1;

        /// <summary>
        ///     The padding
        /// </summary>
        private readonly byte padding2;

        /// <summary>
        ///     The padding
        /// </summary>
        private readonly byte padding3;

        /// <summary>
        ///     The data
        /// </summary>
        public readonly int data1;

        /// <summary>
        ///     The data
        /// </summary>
        public readonly int data2;
    }
}