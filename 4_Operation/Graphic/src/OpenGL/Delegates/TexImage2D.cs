// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TexImage2D.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  --------------------------------------------------------------------------

using System;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.OpenGL.Delegates
{
    /// <summary>
    /// Represents the unmanaged function pointer for the OpenGL glTexImage2D command.
    /// Specifies a two-dimensional texture image.
    /// </summary>
    /// <param name="target">The texture target (e.g., Texture2D).</param>
    /// <param name="level">The level-of-detail number (0 is the base image).</param>
    /// <param name="internalformat">The number of color components in the texture.</param>
    /// <param name="width">The width of the texture image.</param>
    /// <param name="height">The height of the texture image.</param>
    /// <param name="border">The width of the border (must be 0).</param>
    /// <param name="format">The format of the pixel data.</param>
    /// <param name="type">The data type of the pixel data.</param>
    /// <param name="pixels">A pointer to the image data in memory.</param>
    public delegate void TexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, IntPtr pixels);
}
