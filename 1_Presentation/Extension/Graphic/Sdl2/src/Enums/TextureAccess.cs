

using System;

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl texture access enum
    /// </summary>
    [Flags]
    public enum TextureAccess
    {
        /// <summary>
        ///     The sdl texture access static sdl texture access
        /// </summary>
        None = 0,

        /// <summary>
        ///     The sdl texture access streaming sdl texture access
        /// </summary>
        SdlTextureAccessStreaming = 1,

        /// <summary>
        ///     The sdl texture access target sdl texture access
        /// </summary>
        SdlTextureAccessTarget = 2
    }
}