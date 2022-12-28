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

using System.Numerics;
using Alis.Builder.Core.Component.Render;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.D2.SFML.Graphics;
using Alis.Core.Manager.Graphic;

namespace Alis.Core.Component.Render
{
    /// <summary>
    ///     The camera class
    /// </summary>
    /// <seealso cref="ComponentBase" />
    public class Camera : ComponentBase,
        IBuilder<CameraBuilder>
    {
        /// <summary>
        ///     Gets or sets the value of the view
        /// </summary>
        private View view;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Camera" /> class
        /// </summary>
        public Camera()
        {
        }

        /// <summary>
        ///     Gets or sets the value of the point of view
        /// </summary>
        private Vector2 PointOfView { get; set; }

        /// <summary>
        ///     Gets or sets the value of the resolution
        /// </summary>
        public Vector2 Resolution { get; set; }

        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The camera builder</returns>
        public CameraBuilder Builder() => new CameraBuilder();

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start()
        {
            PointOfView = new Vector2(0.0f, 0.0f);
            Resolution = new Vector2(
                (uint) VideoGame.Setting.Graphic.Window.Resolution.X,
                (uint) VideoGame.Setting.Graphic.Window.Resolution.Y);
            view = new View(new Vector2F(PointOfView.X, PointOfView.Y), new Vector2F(Resolution.X, Resolution.Y));
        }

        /// <summary>
        ///     Befores the update
        /// </summary>
        public override void BeforeUpdate()
        {
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
            view.Center = new Vector2F(GameObject.Transform.Position.X, GameObject.Transform.Position.Y);
            GraphicManager.Current.renderWindow.SetView(view);
        }
    }
}