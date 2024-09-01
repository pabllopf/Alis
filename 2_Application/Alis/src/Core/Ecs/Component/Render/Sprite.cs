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
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;

namespace Alis.Core.Ecs.Component.Render
{
    /// <summary>
    ///     The sprite class
    /// </summary>
    /// <seealso cref="AComponent" />
    /// <seealso cref="IBuilder{SpriteBuilder}" />
    public class Sprite :
        AComponent,
        IBuilder<SpriteBuilder>
    {
        /// <summary>
        /// The dst rect
        /// </summary>
        private RectangleI dstRect;

        /// <summary>
        /// The 
        /// </summary>
        private int w;

        /// <summary>
        /// The 
        /// </summary>
        private int h;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Sprite" /> class
        /// </summary>
        public Sprite()
        {
            Image = new Image();
            Depth = 0;
            Flips = RendererFlips.None;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Sprite" /> class
        /// </summary>
        /// <param name="image">The image</param>
        public Sprite(Image image)
        {
            Image = image;
            Depth = 0;
            Flips = RendererFlips.None;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Sprite" /> class
        /// </summary>
        /// <param name="image">The image</param>
        /// <param name="depth">The depth</param>
        /// <param name="flips">The flips</param>
        [JsonConstructor]
        public Sprite(Image image, int depth, RendererFlips flips)
        {
            Image = image;
            Depth = depth;
            Flips = flips;
        }

        /// <summary>
        ///     The image
        /// </summary>
        [JsonPropertyName("_Image_")]
        public Image Image { get; set; }

        /// <summary>
        ///     The level
        /// </summary>
        [JsonPropertyName("_Depth_")]
        public int Depth { get; set; }

        /// <summary>
        ///     Gets or sets the value of the flip
        /// </summary>
        [JsonPropertyName("_Flips_")]
        public RendererFlips Flips { get; set; }

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
            Image.Load();
        }

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public override void OnAwake()
        {
            Context?.GraphicManager.Attach(this);
        }

        /// <summary>
        /// Ons the start
        /// </summary>
        public override void OnStart()
        {
            Sdl.QueryTexture(Image.Texture, out _, out _, out w, out h);


            dstRect = new RectangleI(
                (int) (GameObject.Transform.Position.X - w * GameObject.Transform.Scale.X / 2),
                (int) (GameObject.Transform.Position.Y - h * GameObject.Transform.Scale.Y / 2),
                (int) (w * GameObject.Transform.Scale.X),
                (int) (h * GameObject.Transform.Scale.Y));
        }

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public override void OnExit()
        {
            Context?.GraphicManager.UnAttach(this);
        }

        private const float PIXELS_PER_METER = 32.0f;

        /// <summary>
        /// Renders the sprite
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="camera">The camera</param>
        public void Render(IntPtr renderer, Camera camera)
        {
            if (Context is null)
            {
                return;
            }

            // Calculate camera's viewport in world coordinates
            float halfViewportWidth = camera.Viewport.W / 2;
            float halfViewportHeight = camera.Viewport.H / 2;
            float cameraLeft = camera.Viewport.X - halfViewportWidth;
            float cameraTop = camera.Viewport.Y - halfViewportHeight;

            // Adjust sprite's position based on the camera's position and viewport
            dstRect.X = (int)((GameObject.Transform.Position.X - w * GameObject.Transform.Scale.X / 2 - cameraLeft) * PIXELS_PER_METER);
            dstRect.Y = (int)((GameObject.Transform.Position.Y - h * GameObject.Transform.Scale.Y / 2 - cameraTop) * PIXELS_PER_METER);
            dstRect.W = (int)(w * GameObject.Transform.Scale.X * PIXELS_PER_METER);
            dstRect.H = (int)(h * GameObject.Transform.Scale.Y * PIXELS_PER_METER);

            Sdl.RenderCopyEx(renderer, Image.Texture, IntPtr.Zero, ref dstRect, GameObject.Transform.Rotation.Angle, IntPtr.Zero, Flips);
        }

        /// <summary>
        ///     Renders the renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        public void Render(IntPtr renderer)
        {
            if (Context is null)
            {
                return;
            }

            dstRect.X = (int) (GameObject.Transform.Position.X - w * GameObject.Transform.Scale.X / 2);
            dstRect.Y = (int) (GameObject.Transform.Position.Y - h * GameObject.Transform.Scale.Y / 2);
            dstRect.W = (int) (w * GameObject.Transform.Scale.X);
            dstRect.H = (int) (h * GameObject.Transform.Scale.Y);

            Sdl.RenderCopyEx(renderer, Image.Texture, IntPtr.Zero, ref dstRect, GameObject.Transform.Rotation.Angle, IntPtr.Zero, Flips);
        }

        /// <summary>
        /// Describes whether this instance is visible
        /// </summary>
        /// <param name="camera">The camera</param>
        /// <returns>The bool</returns>
        public bool IsVisible(Camera camera)
        {
            // Precompute values
            float posX = GameObject.Transform.Position.X;
            float posY = GameObject.Transform.Position.Y;
            float scaleX = GameObject.Transform.Scale.X;
            float scaleY = GameObject.Transform.Scale.Y;
            float halfWidth = w * scaleX / 2;
            float halfHeight = h * scaleY / 2;

            // Sprite's bounding box
            float spriteLeft = posX - halfWidth;
            float spriteRight = posX + halfWidth;
            float spriteTop = posY - halfHeight;
            float spriteBottom = posY + halfHeight;

            // Camera's viewport
            float halfViewportWidth = camera.Viewport.W / 2;
            float halfViewportHeight = camera.Viewport.H / 2;
            float cameraLeft = camera.Viewport.X - halfViewportWidth;
            float cameraRight = camera.Viewport.X + halfViewportWidth;
            float cameraTop = camera.Viewport.Y - halfViewportHeight;
            float cameraBottom = camera.Viewport.Y + halfViewportHeight;

            // Check visibility
            return spriteRight > cameraLeft &&
                   spriteLeft < cameraRight &&
                   spriteBottom > cameraTop &&
                   spriteTop < cameraBottom;
        }
    }
}