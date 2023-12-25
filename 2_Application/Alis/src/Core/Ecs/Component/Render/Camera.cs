// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Camera.cs
// 
//  Author: Pablo Perdomo Falcón
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

using Alis.Builder.Core.Ecs.Component.Render;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;

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
        ///     Initializes a new instance of the <see cref="Camera" /> class
        /// </summary>
        public Camera()
        {
            Logger.Trace();
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
        public override void OnStart()
        {
            PointOfView = new Vector2(0.0f, 0.0f);
            //Resolution = new Vector2(
            //   (uint) VideoGame.GraphicManager.Setting.Window.X,
            //   (uint) VideoGame.GraphicManager.Setting.Window.Y);
            // view = new View(new Vector2(PointOfView.X, PointOfView.Y), new Vector2(Resolution.X, Resolution.Y));
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void OnUpdate()
        {
            /*
            view.Center = new Vector2(GameObject.Transform.Position.X, GameObject.Transform.Position.Y);
            GraphicManager.SetView(view);*/
        }
    }
}