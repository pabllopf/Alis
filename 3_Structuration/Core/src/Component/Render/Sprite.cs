// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sprite.cs
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
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.SFML;
using Alis.Core.Builder.Component.Render;
using Alis.Core.Graphic.D2.SFML.Graphics;
using Alis.Core.Manager;

namespace Alis.Core.Component.Render
{
    /// <summary>
    /// The sprite class
    /// </summary>
    /// <seealso cref="ComponentBase"/>
    public class Sprite : ComponentBase, IBuilder<SpriteBuilder>
    {
        /// <summary>
        ///     The level
        /// </summary>
        public int Depth { get; set; } = 0;

        /// <summary>
        ///     The sprite
        /// </summary>
        public Alis.Core.Graphic.D2.SFML.Graphics.Sprite sprite;

        /// <summary>
        ///     The texture path
        /// </summary>
        public string texturePath;
        
        /// <summary>
        /// The image
        /// </summary>
        public Image Image;

        /// <summary>
        /// The size
        /// </summary>
        private Vector2F size;

        /// <summary>
        /// Inits this instance
        /// </summary>
        public override void Init()
        {
            sprite = new Graphic.D2.SFML.Graphics.Sprite(new Texture(texturePath));
            size = new Vector2F(sprite.TextureRect.Width, sprite.TextureRect.Height);
            Logger.Log($"Sprite::init::render::{texturePath}");
        }

        /// <summary>
        /// Awakes this instance
        /// </summary>
        public override void Awake()
        {
            GraphicManager.Attach(this);
        }
        
        /// <summary>
        ///     Starts this instance
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override void Start()
        {
            sprite.Position = new Vector2F(
                (GameObject.Transform.Position.X) - (size.X / 2),
                (GameObject.Transform.Position.Y) - (size.Y / 2));
            sprite.Rotation = GameObject.Transform.Rotation;
            sprite.Scale = new Vector2F(GameObject.Transform.Scale.X, GameObject.Transform.Scale.Y);
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override void Update()
        {
            sprite.Position =  new Vector2F(
                (GameObject.Transform.Position.X) - (size.X / 2),
                (GameObject.Transform.Position.Y) - (size.Y / 2));
            sprite.Rotation = GameObject.Transform.Rotation;
            sprite.Scale = new Vector2F(GameObject.Transform.Scale.X, GameObject.Transform.Scale.Y);
        }

        /// <summary>
        /// Exits this instance
        /// </summary>
        public override void Exit()
        {
            GraphicManager.UnAttach(this);
        }

        /// <summary>
        /// Builders this instance
        /// </summary>
        /// <returns>The sprite builder</returns>
        public new SpriteBuilder Builder() => new SpriteBuilder();
    }
}