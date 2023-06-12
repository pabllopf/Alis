using System;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl rendererflip enum
    /// </summary>
    [Flags]
    public enum SdlRendererFlip
    {
        /// <summary>
        ///     The sdl flip none sdl rendererflip
        /// </summary>
        SdlFlipNone = 0x00000000,

        /// <summary>
        ///     The sdl flip horizontal sdl rendererflip
        /// </summary>
        SdlFlipHorizontal = 0x00000001,

        /// <summary>
        ///     The sdl flip vertical sdl rendererflip
        /// </summary>
        SdlFlipVertical = 0x00000002
    }
}