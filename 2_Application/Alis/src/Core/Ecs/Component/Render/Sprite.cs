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
using System.Diagnostics.CodeAnalysis;
using Alis.Builder.Core.Ecs.Component.Render;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;

namespace Alis.Core.Ecs.Component.Render
{
    public class Sprite : 
        AComponent, 
        IBuilder<SpriteBuilder>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Sprite" /> class
        /// </summary>
        public Sprite()
        {
            Image = null;
            TexturePath = string.Empty;
            Depth = 0;
            Flips = RendererFlips.None;
        }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="Sprite" /> class
        /// </summary>
        /// <param name="texturePath">The texture path</param>
        public Sprite(string texturePath) => TexturePath = texturePath;
        
        [JsonConstructor]
        public Sprite(Image image, string texturePath, int depth, RendererFlips flips)
        {
            Image = image;
            TexturePath = texturePath;
            Depth = depth;
            Flips = flips;
        }
        
        /// <summary>
        ///     The image
        /// </summary>
        [JsonPropertyName("_Image_")]
        public Image Image  { get; set; }
        
        /// <summary>
        ///     The texture path
        /// </summary>
        [JsonPropertyName("_TexturePath_")]
        public string TexturePath { get; set; }
        
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
        [ExcludeFromCodeCoverage]
        public override void OnInit()
        {
            if (Context is null)
            {
                return;
            }
            
            if (!string.IsNullOrEmpty(TexturePath))
            {
                Image = new Image(TexturePath);
                Logger.Info($"Load sprite od '{TexturePath}'");
            }
        }
        
        /// <summary>
        ///     Awakes this instance
        /// </summary>
        [ExcludeFromCodeCoverage]
        public override void OnAwake()
        {
            Context?.GraphicManager.Attach(this);
        }
        
        /// <summary>
        ///     Exits this instance
        /// </summary>
        [ExcludeFromCodeCoverage]
        public override void OnExit()
        {
            Context?.GraphicManager.UnAttach(this);
        }
        
        /// <summary>
        ///     Renders the renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="camera"></param>
        [ExcludeFromCodeCoverage]
        public void Render(IntPtr renderer, Camera camera)
        {
            if (Context is null)
            {
                return;
            }
            
            Sdl.QueryTexture(Image.Texture, out _, out _, out int w, out int h);
            
            RectangleI dstRect = new RectangleI(
                (int) (GameObject.Transform.Position.X - w * GameObject.Transform.Scale.X / 2 - (camera.Viewport.X - camera.Viewport.W / 2) + camera.CameraBorder),
                (int) (GameObject.Transform.Position.Y - h * GameObject.Transform.Scale.Y / 2 - (camera.Viewport.Y - camera.Viewport.H / 2) + camera.CameraBorder),
                (int) (w * GameObject.Transform.Scale.X),
                (int) (h * GameObject.Transform.Scale.Y));
            
            Sdl.RenderCopyEx(renderer, Image.Texture, IntPtr.Zero, ref dstRect, GameObject.Transform.Rotation.Angle, IntPtr.Zero, Flips);
        }
        
        /// <summary>
        ///     Renders the renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        [ExcludeFromCodeCoverage]
        public void Render(IntPtr renderer)
        {
            if (Context is null)
            {
                return;
            }
            
            Sdl.QueryTexture(Image.Texture, out _, out _, out int w, out int h);
            
            RectangleI dstRect = new RectangleI(
                (int) (GameObject.Transform.Position.X - w * GameObject.Transform.Scale.X / 2),
                (int) (GameObject.Transform.Position.Y - h * GameObject.Transform.Scale.Y / 2),
                (int) (w * GameObject.Transform.Scale.X),
                (int) (h * GameObject.Transform.Scale.Y));
            
            Sdl.RenderCopyEx(renderer, Image.Texture, IntPtr.Zero, ref dstRect, GameObject.Transform.Rotation.Angle, IntPtr.Zero, Flips);
        }
    }
}