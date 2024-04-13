// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SpriteBuilder.cs
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

using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Component.Render;

namespace Alis.Builder.Core.Ecs.Component.Render
{
    /// <summary>
    ///     The sprite builder class
    /// </summary>
    /// <seealso cref="IBuild{Sprite}" />
    public class SpriteBuilder :
        IBuild<Sprite>,
        IDepth<SpriteBuilder, int>,
        ISetTexture<SpriteBuilder, string>
    {
        /// <summary>
        ///     The sprite
        /// </summary>
        private readonly Sprite sprite = new Sprite();
        
        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The sprite</returns>
        public Sprite Build() => sprite;
        
        /// <summary>
        ///     Depths the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The sprite builder</returns>
        public SpriteBuilder Depth(int value)
        {
            sprite.Depth = value;
            return this;
        }
        
        /// <summary>
        ///     Textures the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The sprite builder</returns>
        public SpriteBuilder SetTexture(string value)
        {
            sprite.TexturePath = value;
            return this;
        }
    }
}