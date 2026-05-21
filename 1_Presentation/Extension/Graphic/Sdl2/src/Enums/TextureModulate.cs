

using System;

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl texture modulate enum
    /// </summary>
    [Flags]
    public enum TextureModulate
    {
        /// <summary>
        ///     The sdl texture modulate none sdl texture modulate
        /// </summary>
        None = 0x00000000,

        /// <summary>
        ///     The sdl texture modulate horizontal sdl texture modulate
        /// </summary>
        SdlTextureModulateHorizontal = 0x00000001,

        /// <summary>
        ///     The sdl texture modulate vertical sdl texture modulate
        /// </summary>
        SdlTextureModulateVertical = 0x00000002
    }
}