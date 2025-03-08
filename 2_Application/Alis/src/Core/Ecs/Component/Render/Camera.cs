// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Camera.cs
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
using Color = Alis.Core.Aspect.Math.Definition.Color;

namespace Alis.Core.Ecs.Component.Render
{
    /// <summary>
    ///     The camera class
    /// </summary>
    /// <seealso cref="AComponent" />
    public class Camera :
        AComponent,
        IHasBuilder<CameraBuilder>
    {
        /// <summary>
        ///     The position
        /// </summary>
        [JsonPropertyName("_Position_")] public Vector2F Position;

        /// <summary>
        ///     The viewport
        /// </summary>
        [JsonPropertyName("_Viewport_")] public RectangleI Viewport;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Camera" /> class
        /// </summary>
#if NET5_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.DynamicDependency(global::System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.PublicConstructors, typeof(Camera))]
#endif
        public Camera()
        {
            Viewport = new RectangleI(0, 0, 1024, 640);
            TextureTarget = IntPtr.Zero;
            Resolution = new Vector2F(800, 600);
            BackgroundColor = Color.Black;
            CameraBorder = 1f;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Camera" /> class
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="name">The name</param>
        /// <param name="tag">The tag</param>
        /// <param name="isEnable">The is enable</param>
        /// <param name="viewport">The viewport</param>
        /// <param name="resolution">The resolution</param>
        /// <param name="backgroundColor">The background color</param>
        /// <param name="cameraBorder">The camera border</param>
        [JsonConstructor]
        public Camera(string id, string name, string tag, bool isEnable, RectangleI viewport, Vector2F resolution, Color backgroundColor, float cameraBorder)
        {
            Id = id;
            Name = name;
            Tag = tag;
            IsEnable = isEnable;
            Viewport = viewport;
            Resolution = resolution;
            BackgroundColor = backgroundColor;
            CameraBorder = cameraBorder;
        }

        /// <summary>
        ///     Gets or sets the value of the texture target
        /// </summary>
        [JsonPropertyName("_TextureTarget_", true, true)]
        public IntPtr TextureTarget { get; set; }

        /// <summary>
        ///     Gets or sets the value of the resolution
        /// </summary>
        [JsonPropertyName("_Resolution_")]
        public Vector2F Resolution { get; set; }

        /// <summary>
        ///     Gets or sets the value of the background color
        /// </summary>
        [JsonPropertyName("_BackgroundColor_")]
        public Color BackgroundColor { get; set; }

        /// <summary>
        ///     Gets or sets the value of the camera border
        /// </summary>
        [JsonPropertyName("_CameraBorder_")]
        public float CameraBorder { get; set; }

        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The camera builder</returns>
        public CameraBuilder Builder() => new CameraBuilder();

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void OnStart()
        {
            Viewport = new RectangleI(0, 0, (int) Resolution.X, (int) Resolution.Y);
            //TextureTarget = Sdl.CreateTexture(Context.GraphicManager.Renderer, Sdl.PixelFormatRgba8888, (int) TextureAccess.SdlTextureAccessTarget, Viewport.W, Viewport.H);

            Context.GraphicManager.Attach(this);
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            if (GameObject == null || Context == null)
            {
            }

            //Viewport = new RectangleI((int) GameObject.Transform.Position.X, (int) GameObject.Transform.Position.Y, Viewport.W, Viewport.H);
        }

        /// <summary>
        ///     Ons the exit
        /// </summary>
        public override void OnExit()
        {
            Context.GraphicManager.UnAttach(this);
        }
    }
}