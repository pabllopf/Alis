// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Sprite.cs
// 
//  Author: Pablo Perdomo Falcón
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
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Graphic.Sdl2;

namespace Alis.Core.Graphic
{
    /// <summary>
    ///     The sprite class
    /// </summary>
    public class Sprite
    {
        /// <summary>
        ///     The texture
        /// </summary>
        private readonly Texture texture;

        /// <summary>
        ///     The depth
        /// </summary>
        private Depth depth;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Sprite" /> class
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="depth">The depth</param>
        public Sprite(Texture texture, Depth depth)
        {
            this.texture = texture;
            this.depth = depth;
        }

        /// <summary>
        ///     Draws the renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        public void Draw(IntPtr renderer)
        {
            Sdl.RenderCopy(renderer, texture.GetNativePointer(), IntPtr.Zero, ref texture.Figure);
        }
    }
}