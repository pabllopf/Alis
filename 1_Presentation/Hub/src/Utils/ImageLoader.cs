// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImageLoader.cs
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
using System.IO;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Memory.Exceptions;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Structs;
using Alis.Extension.Graphic.OpenGL;
using Alis.Extension.Graphic.OpenGL.Enums;
using Alis.Extension.Graphic.Sdl2Image;
using PixelFormat = Alis.Extension.Graphic.OpenGL.Enums.PixelFormat;

namespace Alis.App.Hub.Utils
{
    /// <summary>
    ///     The image loader class
    /// </summary>
    public static class ImageLoader
    {
        /// <summary>
        ///     Loads the texture from file using the specified file path
        /// </summary>
        /// <param name="filePath">The file path</param>
        /// <exception cref="Exception">Failed to load image: {Sdl.GetError()}</exception>
        /// <exception cref="FileNotFoundException">File not found: {filePath}</exception>
        /// <returns>The int ptr</returns>
        public static IntPtr LoadTextureFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File not found: {filePath}");
            }

            // Load image using SDL_image
            IntPtr surface = SdlImage.LoadImg(filePath);
            if (surface == IntPtr.Zero)
            {
                throw new GeneralAlisException($"Failed to load image: {Sdl.GetError()}");
            }

            // Get image dimensions
            Surface sdlSurface = Marshal.PtrToStructure<Surface>(surface);
            int width = sdlSurface.w;
            int height = sdlSurface.h;

            // Generate OpenGL texture
            uint textureId = Gl.GenTexture();
            Gl.GlBindTexture(TextureTarget.Texture2D, textureId);
            Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, width, height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, sdlSurface.Pixels);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, TextureParameter.ClampToEdge);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, TextureParameter.ClampToEdge);
            Gl.GlBindTexture(TextureTarget.Texture2D, 0);

            return (IntPtr) textureId;
        }
    }
}