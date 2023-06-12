using System;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl texturemodulate enum
    /// </summary>
    [Flags]
    public enum SdlTextureModulate
    {
        /// <summary>
        ///     The sdl texturemodulate none sdl texturemodulate
        /// </summary>
        SdlTexturemodulateNone = 0x00000000,

        /// <summary>
        ///     The sdl texturemodulate horizontal sdl texturemodulate
        /// </summary>
        SdlTexturemodulateHorizontal = 0x00000001,

        /// <summary>
        ///     The sdl texturemodulate vertical sdl texturemodulate
        /// </summary>
        SdlTexturemodulateVertical = 0x00000002
    }
}