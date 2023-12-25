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
using Alis.Builder.Core.Ecs.Component.Render;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs.System.Manager.Graphic;

namespace Alis.Core.Ecs.Component.Render
{
    /// <summary>
    ///     The sprite class
    /// </summary>
    /// <seealso cref="Component" />
    public class Sprite : Component, IBuilder<SpriteBuilder>
    {
        /// <summary>
        ///     The image
        /// </summary>
        public Image Image;
        
        /// <summary>
        ///     The texture path
        /// </summary>
        public string TexturePath;

        /// <summary>
        ///     The level
        /// </summary>
        public int Depth { get; set; } = 0;

        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The sprite builder</returns>
        public SpriteBuilder Builder() => new SpriteBuilder();

        /// <summary>
        ///     Inits this instance
        /// </summary>
        public override void OnInit()
        {
            if (!string.IsNullOrEmpty(TexturePath))
            {
                Image = new Image(TexturePath);
                Console.WriteLine($"Load sprite od '{TexturePath}'");
            }
            
            
            /*
            SpriteSfml = new Graphic.SFML.Graphics.Sprite(new Texture(TexturePath));
            size = new Vector2(SpriteSfml.TextureRect.Width, SpriteSfml.TextureRect.Height);
            Logger.Log($"Load sprite od '{TexturePath}'");*/
        }

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public override void OnAwake()
        {
            GraphicManager.Attach(this);
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override void OnStart()
        {
            /*
            SpriteSfml.Position = new Vector2(
                GameObject.Transform.Position.X - size.X * GameObject.Transform.Scale.X / 2,
                GameObject.Transform.Position.Y - size.Y * GameObject.Transform.Scale.Y / 2
            );
            SpriteSfml.Rotation = GameObject.Transform.Rotation;
            SpriteSfml.Scale = new Vector2(GameObject.Transform.Scale.X, GameObject.Transform.Scale.Y);*/
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override void OnUpdate()
        {
            /*
            SpriteSfml.Position = new Vector2(
                GameObject.Transform.Position.X - size.X * GameObject.Transform.Scale.X / 2,
                GameObject.Transform.Position.Y - size.Y * GameObject.Transform.Scale.Y / 2
            );
            SpriteSfml.Rotation = GameObject.Transform.Rotation;
            SpriteSfml.Scale = new Vector2(GameObject.Transform.Scale.X, GameObject.Transform.Scale.Y);*/
        }

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public override void OnExit()
        {
            GraphicManager.UnAttach(this);
        }

        public Sprite()
        {
            
        } 
        
        public Sprite(string texturePath)
        {
            TexturePath = texturePath;
        }
    }
}