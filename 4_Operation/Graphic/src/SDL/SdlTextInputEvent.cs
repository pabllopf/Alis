using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl textinputevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlTextInputEvent
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
        ///     The sdl textinputevent text size
        /// </summary>
        public byte[] text;

        /// <summary>
        /// Initializes a new instance of the <see cref="SdlTextInputEvent"/> class
        /// </summary>
        public SdlTextInputEvent()
        {
            type = SdlEventType.SdlFirstevent;
            timestamp = 0;
            windowID = 0;
            text = new byte[Sdl.SdlTextinputeventTextSize];
        }
    }
}