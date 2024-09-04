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
    }
}