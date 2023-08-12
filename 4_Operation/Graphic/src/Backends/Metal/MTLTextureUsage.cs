using System;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl texture usage enum
    /// </summary>
    [Flags]
    public enum MTLTextureUsage
    {
        /// <summary>
        /// The unknown mtl texture usage
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// The shader read mtl texture usage
        /// </summary>
        ShaderRead = 1 << 0,
        /// <summary>
        /// The shader write mtl texture usage
        /// </summary>
        ShaderWrite = 1 << 1,
        /// <summary>
        /// The render target mtl texture usage
        /// </summary>
        RenderTarget = 1 << 2,
        /// <summary>
        /// The pixel format view mtl texture usage
        /// </summary>
        PixelFormatView = 0x10,
    }
}