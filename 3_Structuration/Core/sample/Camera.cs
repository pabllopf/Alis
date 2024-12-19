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
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Color = Alis.Core.Aspect.Math.Definition.Color;

namespace Alis.Core.Sample
{
    /// <summary>
    ///     The camera class
    /// </summary>
    public class Camera
    {
        /// <summary>
        ///     The background color
        /// </summary>
        public Color BackgroundColor;

        /// <summary>
        ///     The camera border
        /// </summary>
        public float CameraBorder;

        /// <summary>
        ///     The position
        /// </summary>
        public Vector2F Position;

        /// <summary>
        ///     The resolution
        /// </summary>
        public Vector2F Resolution;

        /// <summary>
        ///     The texture target
        /// </summary>
        public IntPtr TextureTarget;

        /// <summary>
        ///     The viewport
        /// </summary>
        public RectangleI Viewport;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Camera" /> class
        /// </summary>
        /// <param name="renderer">The renderer</param>
        public Camera(IntPtr renderer)
        {
            Position = new Vector2F(0, 0);
            Resolution = new Vector2F(640, 480);
            Viewport = new RectangleI(0, 0, 640, 480);
            BackgroundColor = Color.Black;
            CameraBorder = 1f;
            TextureTarget = IntPtr.Zero;

            int x = (int) Math.Truncate(Position.X);
            int y = (int) Math.Truncate(Position.Y);
            int w = (int) Math.Truncate(Resolution.X);
            int h = (int) Math.Truncate(Resolution.Y);

            Viewport = new RectangleI(x, y, w, h);
            TextureTarget = Sdl.CreateTexture(renderer, Sdl.PixelFormatRgba8888, (int) TextureAccess.SdlTextureAccessTarget, Viewport.W, Viewport.H);
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public void OnUpdate()
        {
            Viewport = new RectangleI((int) (Position.X - Resolution.X / 2), (int) (Position.Y - Resolution.Y / 2), (int) Resolution.X, (int) Resolution.Y);
        }
    }
}