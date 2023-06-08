using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl textinputevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SdlTextInputEvent
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
        public fixed byte text[Sdl.SdlTextinputeventTextSize];
    }
}