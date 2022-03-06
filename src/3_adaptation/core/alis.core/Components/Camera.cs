// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Camera.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Numerics;
using Alis.Core.Entities;
using Alis.Core.Managers;
using SFML.Graphics;
using SFML.System;

namespace Alis.Core.Components
{
    /// <summary>
    ///     The camera class
    /// </summary>
    /// <seealso cref="Component" />
    public class Camera : Component
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Camera" /> class
        /// </summary>
        public Camera()
        {
            PointOfView = new Vector2(0.0f, 0.0f);
            Resolution = new Vector2(640, 480);
            View = new View(new Vector2f(PointOfView.X, PointOfView.Y), new Vector2f(Resolution.X, Resolution.Y));
        }

        /// <summary>
        ///     Gets or sets the value of the point of view
        /// </summary>
        private Vector2 PointOfView { get; }

        /// <summary>
        ///     Gets or sets the value of the resolution
        /// </summary>
        public Vector2 Resolution { get; set; }

        /// <summary>
        ///     Gets or sets the value of the view
        /// </summary>
        private View View { get; }

        /// <summary>
        ///     Gets the value of the instance
        /// </summary>
        public static Camera Instance { get; } = new Camera();

        /// <summary>
        ///     Creates the instance
        /// </summary>
        /// <returns>The camera</returns>
        public static Camera CreateInstance() => Instance;

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start() => RenderManager.SetView(View);

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update() =>
            View.Center = new Vector2f(GameObject.Transform.Position.X, GameObject.Transform.Position.Y);
    }
}