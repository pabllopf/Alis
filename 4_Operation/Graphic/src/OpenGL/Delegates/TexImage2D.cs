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
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.OpenGL.Delegates
{
    /// <summary>
    ///     Specifies a two-dimensional texture image, defining the texels in the image data
    /// </summary>
    /// <param name="target">Specifies the target texture type</param>
    /// <param name="level">Specifies the level-of-detail number</param>
    /// <param name="internalFormat">Specifies the number of color components in the texture</param>
    /// <param name="width">Specifies the width of the texture image</param>
    /// <param name="height">Specifies the height of the texture image</param>
    /// <param name="border">Specifies the width of the border (must be 0 or 1)</param>
    /// <param name="format">Specifies the format of the pixel data</param>
    /// <param name="type">Specifies the data type of the pixel data</param>
    /// <param name="data">Specifies a pointer to the image data</param>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void TexImage2D(TextureTarget target, int level, PixelInternalFormat internalFormat, int width, int height, int border, PixelFormat format, PixelType type, IntPtr data);
}