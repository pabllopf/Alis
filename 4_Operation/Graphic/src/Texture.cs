// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Texture.cs
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
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Graphic.SDL;

namespace Alis.Core.Graphic
{
    /// <summary>
    /// The texture class
    /// </summary>
    /// <seealso cref="IDrawable"/>
    public class Texture : IDrawable
    {
        /// <summary>
        /// The native pointer
        /// </summary>
        private IntPtr nativePointer;
        
        /// <summary>
        /// The renderer
        /// </summary>
        private readonly IntPtr renderer;
        
        /// <summary>
        /// The image
        /// </summary>
        private readonly Image image;

        /// <summary>
        /// The figure
        /// </summary>
        public RectangleI Figure;

        /// <summary>
        /// Initializes a new instance of the <see cref="Texture"/> class
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="image">The image</param>
        /// <param name="figure">The figure</param>
        public Texture(IntPtr renderer, Image image, RectangleI figure)
        {
            this.renderer = renderer;
            this.image = image;
            this.Figure = figure;
        }

        /// <summary>
        /// Loads this instance
        /// </summary>
        private void Load()
        {
            if (nativePointer != IntPtr.Zero)
            {
                return;
            }
            
            nativePointer = Sdl.CreateTextureFromSurface(renderer, image.GetNativePointer());
        }
        
        /// <summary>
        /// Gets the native pointer
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetNativePointer()
        {
            Load();
            return nativePointer;
        }
    }
}