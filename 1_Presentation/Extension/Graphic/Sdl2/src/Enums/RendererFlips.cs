

using System;

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl renderer flip enum
    /// </summary>
    [Flags]
    public enum RendererFlips
    {
        /// <summary>
        ///     The sdl flip none sdl renderer flip
        /// </summary>
        None = 0x00000000,

        /// <summary>
        ///     The sdl flip horizontal sdl renderer flip
        /// </summary>
        FlipHorizontal = 0x00000001,

        /// <summary>
        ///     The sdl flip vertical sdl renderer flip
        /// </summary>
        FlipVertical = 0x00000002
    }
}