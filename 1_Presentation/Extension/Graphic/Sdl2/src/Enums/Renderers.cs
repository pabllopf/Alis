

using System;

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl renderer flags enum
    /// </summary>
    [Flags]
    public enum Renderers : uint
    {
        /// <summary>
        ///     The none renderer
        /// </summary>
        None = 0x00000000,

        /// <summary>
        ///     The sdl renderer software sdl renderer flags
        /// </summary>
        SdlRendererSoftware = 0x00000001,

        /// <summary>
        ///     The sdl renderer accelerated sdl renderer flags
        /// </summary>
        SdlRendererAccelerated = 0x00000002,

        /// <summary>
        ///     The sdl renderer present vsync sdl renderer flags
        /// </summary>
        SdlRendererPresentVSync = 0x00000004,

        /// <summary>
        ///     The sdl renderer target texture sdl renderer flags
        /// </summary>
        SdlRendererTargetTexture = 0x00000008
    }
}