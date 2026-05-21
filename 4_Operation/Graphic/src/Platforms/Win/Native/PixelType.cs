

#if winx64 || winx86 || winarm64 || winarm || win
using System;
using System.Diagnostics.CodeAnalysis;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    /// <summary>
    ///     Pixel type for OpenGL context.
    /// </summary>
    [Flags]
    public enum PixelType : byte
    {
        /// <summary>
        /// </summary>
        RGBA = 0
    }
}

#endif