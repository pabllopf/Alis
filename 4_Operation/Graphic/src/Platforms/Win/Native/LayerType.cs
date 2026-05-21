

#if winx64 || winx86 || winarm64 || winarm || win
using System;
using System.Diagnostics.CodeAnalysis;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    /// <summary>
    ///     Layer type for OpenGL context.
    /// </summary>
    [Flags]
    public enum LayerType : byte
    {
        /// <summary>
        /// </summary>
        MainPlane = 0
    }
}

#endif