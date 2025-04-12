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
using Alis.Builder.Core.Ecs.Entity;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Comps;

namespace Alis.Core.Ecs.Components.Render
{
    public struct Camera(Vector2F position, Vector2F resolution) : ICamera
    {
        /// <summary>
        ///     The position
        /// </summary>
        public Vector2F Position { get; set; } = position;

        /// <summary>
        ///     Gets or sets the value of the resolution
        /// </summary>
        public Vector2F Resolution { get; set; } = resolution;

        /// <summary>
        ///     Inits the self
        /// </summary>
        /// <param name="self">The self</param>
        public void Init(GameObject self)
        {
            Console.WriteLine($"Camera {self.EntityID} created");
        }

        /// <summary>
        ///     Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        public void Update(GameObject self)
        {
            Console.WriteLine($"Camera {self.EntityID} updated");
        }

        public CameraBuilder CreateBuilder() => new CameraBuilder();
        public Camera Build() => new Camera(Position, Resolution);

        public void Configure(Action<Camera> configure)
        {
            configure(this);
        }
    }
}