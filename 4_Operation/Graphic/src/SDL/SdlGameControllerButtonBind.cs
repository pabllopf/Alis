using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl gamecontrollerbuttonbind
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlGameControllerButtonBind
    {
        /// <summary>
        ///     The bind type
        /// </summary>
        public SdlGameControllerBindType bindType;

        /// <summary>
        ///     The value
        /// </summary>
        public InternalGameControllerButtonBindUnion value;
    }
}