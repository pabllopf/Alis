

using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl game controller button bind
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GameControllerButtonBind
    {
        /// <summary>
        ///     The bind type
        /// </summary>
        public GameControllerBindType bindType;


        /// <summary>
        ///     The value
        /// </summary>
        public InternalGameControllerButtonBindUnion value;
    }
}