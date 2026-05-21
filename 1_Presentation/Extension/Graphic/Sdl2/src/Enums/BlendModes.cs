

using System;

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl blend mode enum
    /// </summary>
    [Flags]
    public enum BlendModes
    {
        /// <summary>
        ///     The sdl blend factor none sdl blend factor
        /// </summary>
        None = 0x00000000,

        /// <summary>
        ///     The sdl blend factor blend sdl blend factor
        /// </summary>
        BlendModeBlend = 0x00000001,

        /// <summary>
        ///     The sdl blend factor add sdl blend factor
        /// </summary>
        BlendModeAdd = 0x00000002,

        /// <summary>
        ///     The sdl blend factor mod sdl blend factor
        /// </summary>
        BlendModeMod = 0x00000004,

        /// <summary>
        ///     The sdl blend factor mul sdl blend factor
        /// </summary>
        BlendModeMul = 0x00000008,

        /// <summary>
        ///     The sdl blend factor invalid sdl blend factor
        /// </summary>
        BlendModeInvalid = 0x7FFFFFFF,

        /// <summary>
        ///     The blend all blend mode
        /// </summary>
        BlendAll = BlendModeBlend | BlendModeAdd | BlendModeMod | BlendModeMul | BlendModeInvalid
    }
}