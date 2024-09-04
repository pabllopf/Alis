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
using Alis.Core.Aspect.Math.Vector;
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

        private RectangleI Rectangle;

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
            Context.GraphicManager.Attach(this);
        }

        /// <summary>
        /// Ons the start
        /// </summary>
        public override void OnStart()
        {
            Sdl.QueryTexture(Image.Texture, out _, out _, out w, out h);
            
            dstRect = new RectangleI( (int)GameObject.Transform.Position.X, (int)GameObject.Transform.Position.Y, w, h);
        }

        public override void OnUpdate()
        {
        }

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public override void OnExit()
        {
           
        }

        public void Render(IntPtr renderer, Vector2 cameraPosition, Vector2 cameraResolution, float pixelsPerMeter)
        {
            Vector2 spritePosition = GameObject.Transform.Position;
            Vector2 spriteSize = Image.Size;

            float spritePosX = spritePosition.X * pixelsPerMeter;
            float spritePosY = spritePosition.Y * pixelsPerMeter;

            int x = (int)(spritePosX - cameraPosition.X * pixelsPerMeter + cameraResolution.X / 2 - spriteSize.X / 2);
            int y = (int)(spritePosY - cameraPosition.Y * pixelsPerMeter + cameraResolution.Y / 2 - spriteSize.Y / 2);

            Rectangle = new RectangleI
            {
                X = x,
                Y = y,
                W = (int)spriteSize.X,
                H = (int)spriteSize.Y
            };

            Sdl.RenderCopyEx(renderer, Image.Texture, IntPtr.Zero, ref Rectangle, 0, IntPtr.Zero, RendererFlips.FlipVertical);
        }
        
        public bool IsVisible(Vector2 cameraPosition, Vector2 cameraResolution, float pixelsPerMeter)
        {
            Vector2 spritePosition = GameObject.Transform.Position;
            Vector2 spriteSize = Image.Size;

            float spritePosX = spritePosition.X * pixelsPerMeter;
            float spritePosY = spritePosition.Y * pixelsPerMeter;

            float cameraLeft = cameraPosition.X * pixelsPerMeter - cameraResolution.X / 2;
            float cameraRight = cameraPosition.X * pixelsPerMeter + cameraResolution.X / 2;
            float cameraTop = cameraPosition.Y * pixelsPerMeter - cameraResolution.Y / 2;
            float cameraBottom = cameraPosition.Y * pixelsPerMeter + cameraResolution.Y / 2;

            float spriteLeft = spritePosX - spriteSize.X / 2;
            float spriteRight = spritePosX + spriteSize.X / 2;
            float spriteTop = spritePosY - spriteSize.Y / 2;
            float spriteBottom = spritePosY + spriteSize.Y / 2;

            return spriteRight > cameraLeft && spriteLeft < cameraRight && spriteBottom > cameraTop && spriteTop < cameraBottom;
        }
    }
}