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

using System;
using System.Numerics;
using Alis.Core.Entities;
using Alis.Core.Managers;
using SFML.Graphics;
using SFML.System;
using Transform = Alis.Core.Entities.Transform;

namespace Alis.Core.Components
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
        public string texturePath;

        /// <summary>
        /// Gets the value of the level
        /// </summary>
        public int Level => level;

        /// <summary>
        ///     The transform
        /// </summary>
        private Transform transform;

        /// <summary>
        /// The level
        /// </summary>
        private readonly int level;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Sprite" /> class
        /// </summary>
        public Sprite()
        {
            texturePath = "";
            transform = new Transform();
            sprite = new SFML.Graphics.Sprite();
            RenderManager.Attach(this);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Sprite" /> class
        /// </summary>
        /// <param name="texturePath">The texture path</param>
        public Sprite(string texturePath)
        {
            this.texturePath = texturePath;

            transform = new Transform();

            sprite = new SFML.Graphics.Sprite(new Texture(texturePath));
            Size = new Vector2(sprite.TextureRect.Width, sprite.TextureRect.Height);
            Console.WriteLine(@$"witdh ={Size.X} | height={Size.Y}");
            RenderManager.Attach(this);
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Sprite"/> class
        /// </summary>
        /// <param name="texturePath">The texture path</param>
        /// <param name="level">The level</param>
        public Sprite(string texturePath, int level)
        {
            this.texturePath = texturePath;
            this.level = level;

            transform = new Transform();

            sprite = new SFML.Graphics.Sprite(new Texture(texturePath));
            Size = new Vector2(sprite.TextureRect.Width, sprite.TextureRect.Height);
            Console.WriteLine(@$"witdh ={Size.X} | height={Size.Y}");
            RenderManager.Attach(this);
        }

        /// <summary>
        ///     Gets the value of the drawable
        /// </summary>
        public Drawable Drawable => sprite;


        /// <summary>
        ///     Gets or sets the value of the size
        /// </summary>
        public Vector2 Size { get; set; }

        /// <summary>
        ///     Gets or sets the value of the texture
        /// </summary>
        public Texture Texture
        {
            get => sprite.Texture;
            set => sprite.Texture = value;
        }

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

        public override void Stop()
        {
            
        }

        public override void Exit()
        {
            RenderManager.UnAttach(this);
        }
    }
}