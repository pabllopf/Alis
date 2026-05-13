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

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Core.Ecs.Components.Render
{
    /// <summary>
    ///     Represents a rendering camera with position and resolution.
    /// </summary>
    public struct Camera(Context context, Vector2F position, Vector2F resolution) : ICamera
    {
        /// <summary>
        ///     The original position for reset purposes.
        /// </summary>
        private readonly Vector2F positionOriginal = position;

        /// <summary>
        ///     The original resolution for reset purposes.
        /// </summary>
        private readonly Vector2F resolutionOriginal = resolution;

        /// <summary>
        ///     Current camera position in world space.
        /// </summary>
        public Vector2F Position { get; set; } = position;

        /// <summary>
        ///     Gets or sets the camera's rendering resolution.
        /// </summary>
        public Vector2F Resolution { get; set; } = resolution;

        /// <summary>
        ///     Inits the self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnStart(IGameObject self)
        {
            Logger.Info($"[{nameof(Camera)}] Initialized with position: ({Position.X},{Position.Y}) and resolution: ({Resolution.X},{Resolution.Y})");
        }

        /// <summary>
        ///     Ons the exit using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnExit(IGameObject self)
        {
            Position = new Vector2F(positionOriginal.X, positionOriginal.Y);
            Resolution = new Vector2F(resolutionOriginal.X, resolutionOriginal.Y);
            Logger.Info($"[{nameof(Camera)}] Reset position: ({Position.X},{Position.Y}) and resolution: ({Resolution.X},{Resolution.Y})");
        }

        /// <summary>
        ///     Called when the entity is started. Logs initialization details.
        /// </summary>
        /// <param name="self">The owning game object.</param>
        public void OnStart(IGameObject self)

        /// <summary>
        ///     Called when the entity is destroyed; resets camera to original position and resolution.
        /// </summary>
        /// <param name="self">The owning game object.</param>
        public void OnExit(IGameObject self)

        /// <summary>
        ///     Gets or sets the execution context.
        /// </summary>
        public Context Context { get; set; } = context;
    }
}