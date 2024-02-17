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
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Color = Alis.Core.Aspect.Math.Definition.Color;

namespace Alis.Core.Ecs.Component.Render
{
    /// <summary>
    ///     The camera class
    /// </summary>
    /// <seealso cref="Component" />
    public class Camera : Component,
        IBuilder<CameraBuilder>
    {
        /// <summary>
        ///     The viewport
        /// </summary>
        public RectangleI viewport;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Camera" /> class
        /// </summary>
        public Camera()
        {
        }

        /// <summary>
        ///     Gets or sets the value of the texture target
        /// </summary>
        public IntPtr TextureTarget { get; set; }

        /// <summary>
        ///     Gets or sets the value of the resolution
        /// </summary>
        public Vector2 Resolution { get; set; } = new Vector2(800, 600);

        /// <summary>
        ///     Gets or sets the value of the background color
        /// </summary>
        public Color BackgroundColor { get; set; } = Color.Black;

        /// <summary>
        ///     Gets or sets the value of the camera border
        /// </summary>
        public static float CameraBorder { get; set; } = 1f;

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
            viewport = new RectangleI((int) GameObject.Transform.Position.X, (int) GameObject.Transform.Position.Y, (int) Resolution.X, (int) Resolution.Y);
            TextureTarget = Sdl.CreateTexture(VideoGame.Instance.GraphicManager.Renderer, Sdl.PixelFormatRgba8888, (int) TextureAccess.SdlTextureAccessTarget, viewport.w, viewport.h);
            VideoGame.Instance.GraphicManager.Attach(this);
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            viewport.x = (int) GameObject.Transform.Position.X;
            viewport.y = (int) GameObject.Transform.Position.Y;
        }

        /// <summary>
        ///     Ons the exit
        /// </summary>
        public override void OnExit()
        {
            VideoGame.Instance.GraphicManager.UnAttach(this);
        }
    }
}