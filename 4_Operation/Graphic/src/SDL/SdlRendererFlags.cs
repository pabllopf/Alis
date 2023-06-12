using System;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl rendererflags enum
    /// </summary>
    [Flags]
    public enum SdlRendererFlags : uint
    {
        /// <summary>
        ///     The sdl renderer software sdl rendererflags
        /// </summary>
        SdlRendererSoftware = 0x00000001,

        /// <summary>
        ///     The sdl renderer accelerated sdl rendererflags
        /// </summary>
        SdlRendererAccelerated = 0x00000002,

        /// <summary>
        ///     The sdl renderer presentvsync sdl rendererflags
        /// </summary>
        SdlRendererPresentvsync = 0x00000004,

        /// <summary>
        ///     The sdl renderer targettexture sdl rendererflags
        /// </summary>
        SdlRendererTargettexture = 0x00000008
    }
}