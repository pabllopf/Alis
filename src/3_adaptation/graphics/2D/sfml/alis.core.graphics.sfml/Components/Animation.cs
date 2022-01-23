// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Animation.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace Alis.Core.Sfml.Components
{
    /// <summary>
    ///     The animation class
    /// </summary>
    public class Animation
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Animation" /> class
        /// </summary>
        public Animation() => Textures = new List<Texture>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="Animation" /> class
        /// </summary>
        /// <param name="textures">The textures</param>
        public Animation(List<Texture> textures) => Textures = textures;

        /// <summary>
        ///     Gets or sets the value of the index
        /// </summary>
        private int Index { get; set; }

        /// <summary>
        ///     Gets or sets the value of the speed
        /// </summary>
        public double Speed { get; set; } = 1.0f;

        /// <summary>
        ///     Gets or sets the value of the textures
        /// </summary>
        private List<Texture> Textures { get; }

        /// <summary>
        ///     Describes whether this instance has next
        /// </summary>
        /// <returns>The bool</returns>
        public bool HasNext() => Textures.Count > 0;

        /// <summary>
        ///     Nexts the texture
        /// </summary>
        /// <exception cref="InvalidCastException"></exception>
        /// <returns>The texture</returns>
        public Texture NextTexture()
        {
            Texture result = Textures[Index];

            if (Index < Textures.Count - 1)
            {
                Index += 1;
            }

            if (Index == Textures.Count - 1)
            {
                Index = 0;
            }

            return result;
        }

        /// <summary>
        ///     Textures this instance
        /// </summary>
        /// <returns>The texture</returns>
        public Texture Texture() => Textures[Index];
    }
}