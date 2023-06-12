using System;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl blendmode enum
    /// </summary>
    [Flags]
    public enum SdlBlendMode
    {
        /// <summary>
        ///     The sdl blendmode none sdl blendmode
        /// </summary>
        SdlBlendmodeNone = 0x00000000,

        /// <summary>
        ///     The sdl blendmode blend sdl blendmode
        /// </summary>
        SdlBlendmodeBlend = 0x00000001,

        /// <summary>
        ///     The sdl blendmode add sdl blendmode
        /// </summary>
        SdlBlendmodeAdd = 0x00000002,

        /// <summary>
        ///     The sdl blendmode mod sdl blendmode
        /// </summary>
        SdlBlendmodeMod = 0x00000004,

        /// <summary>
        ///     The sdl blendmode mul sdl blendmode
        /// </summary>
        SdlBlendmodeMul = 0x00000008, 

        /// <summary>
        ///     The sdl blendmode invalid sdl blendmode
        /// </summary>
        SdlBlendmodeInvalid = 0x7FFFFFFF
    }
}