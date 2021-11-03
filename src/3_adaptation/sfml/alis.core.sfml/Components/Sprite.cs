// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Sprite.cs
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

#region

using System;
using Alis.Core.Entities;
using Alis.Core.Sfml.Managers;
using SFML.Graphics;
using SFML.System;
using Transform = Alis.Core.Entities.Transform;

#endregion

namespace Alis.Core.Sfml.Components
{
    /// <summary>
    ///     The sprite class
    /// </summary>
    /// <seealso cref="Component" />
    public class Sprite : Component
    {
        /// <summary>
        ///     The sprite
        /// </summary>
        private readonly SFML.Graphics.Sprite sprite;

        /// <summary>
        ///     The texture path
        /// </summary>
        private readonly string texturePath;

        /// <summary>
        ///     The transform
        /// </summary>
        private Transform transform;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Sprite" /> class
        /// </summary>
        /// <param name="texturePath">The texture path</param>
        public Sprite(string texturePath)
        {
            this.texturePath = texturePath;

            transform = new Transform();

            sprite = new SFML.Graphics.Sprite(new Texture(texturePath));
            RenderManager.Attach(this);
        }

        /// <summary>
        ///     Gets the value of the drawable
        /// </summary>
        public Drawable Drawable => sprite;

        /// <summary>
        ///     Gets or sets the value of the depth
        /// </summary>
        public int Depth { get; set; } = 0;

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start()
        {
            transform = GameObject.Transform;
            Console.WriteLine(texturePath);
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
            sprite.Position = new Vector2f(transform.Position.X, transform.Position.Y);
            sprite.Rotation = transform.Rotation.Y;
            sprite.Scale = new Vector2f(transform.Scale.X, transform.Scale.Y);
        }
    }
}