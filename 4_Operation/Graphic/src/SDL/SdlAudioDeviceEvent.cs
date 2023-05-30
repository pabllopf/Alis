using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl audiodeviceevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlAudioDeviceEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public uint type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public uint timestamp;

        /// <summary>
        ///     The which
        /// </summary>
        public uint which;

        /// <summary>
        ///     The iscapture
        /// </summary>
        public byte iscapture;

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
    }
}