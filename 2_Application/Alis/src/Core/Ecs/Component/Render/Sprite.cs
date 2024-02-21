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
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;

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
        ///     Initializes a new instance of the <see cref="Sprite" /> class
        /// </summary>
        public Sprite()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Sprite" /> class
        /// </summary>
        /// <param name="texturePath">The texture path</param>
        public Sprite(string texturePath) => TexturePath = texturePath;

        /// <summary>
        ///     The level
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        ///     Gets or sets the value of the flip
        /// </summary>
        public RendererFlip Flip { get; set; }

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
        }

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public override void OnAwake()
        {
            VideoGame.Instance.GraphicManager.Attach(this);
        }

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public override void OnExit()
        {
            VideoGame.Instance.GraphicManager.UnAttach(this);
        }

        /// <summary>
        ///     Renders the renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="camera"></param>
        public void Render(IntPtr renderer, Camera camera)
        {
            Sdl.QueryTexture(Image.Texture, out _, out _, out int w, out int h);

            RectangleI dstRect = new RectangleI(
                (int) (GameObject.Transform.Position.X - w * GameObject.Transform.Scale.X / 2 - (camera.Viewport.x - camera.Viewport.w / 2) + Camera.CameraBorder),
                (int) (GameObject.Transform.Position.Y - h * GameObject.Transform.Scale.Y / 2 - (camera.Viewport.y - camera.Viewport.h / 2) + Camera.CameraBorder),
                (int) (w * GameObject.Transform.Scale.X),
                (int) (h * GameObject.Transform.Scale.Y));

            Sdl.RenderCopyEx(renderer, Image.Texture, IntPtr.Zero, ref dstRect, GameObject.Transform.Rotation.Angle, IntPtr.Zero, Flip);
        }

        /// <summary>
        ///     Renders the renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        public void Render(IntPtr renderer)
        {
            Sdl.QueryTexture(Image.Texture, out _, out _, out int w, out int h);

            RectangleI dstRect = new RectangleI(
                (int) (GameObject.Transform.Position.X - w * GameObject.Transform.Scale.X / 2),
                (int) (GameObject.Transform.Position.Y - h * GameObject.Transform.Scale.Y / 2),
                (int) (w * GameObject.Transform.Scale.X),
                (int) (h * GameObject.Transform.Scale.Y));

            Sdl.RenderCopyEx(renderer, Image.Texture, IntPtr.Zero, ref dstRect, GameObject.Transform.Rotation.Angle, IntPtr.Zero, Flip);
        }
    }
}