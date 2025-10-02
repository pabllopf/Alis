// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Transform.cs
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
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Ecs.Components
{
    /// <summary>
    ///     The transform
    /// </summary>
    public struct Transform : IOnStart, IOnExit
    {
        private readonly Vector2F positionOrigin;
        private readonly float rotationOrigin;
        private readonly Vector2F scaleOrigin;
        
        /// <summary>
        ///     The position
        /// </summary>
        public Vector2F Position;

        /// <summary>
        ///     The rotation
        /// </summary>
        public float Rotation;

        /// <summary>
        ///     The scale
        /// </summary>
        public Vector2F Scale;
        
        /// <summary>
        ///     Initialize using a position vector and a Complex rotation.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation</param>
        public Transform(Vector2F position, float rotation)
        {
            Rotation = rotation;
            Position = position;
            Scale = Vector2F.One; 
            
            positionOrigin = position;
            rotationOrigin = rotation;
            scaleOrigin = Vector2F.One;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Transform" /> class
        /// </summary>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="scale">The scale</param>
        public Transform(Vector2F position, float rotation, Vector2F scale)
        {
            Rotation = rotation;
            Position = position;
            Scale = scale;
            
            positionOrigin = position;
            rotationOrigin = rotation;
            scaleOrigin = scale;
        }
        
        public void OnStart(IGameObject self)
        {
            Logger.Info($"[{GetType()}] Initialized Transform of GameObject '{self.Get<Info>().Name}' with Position: {Position}, Rotation: {Rotation}, Scale: {Scale}");
        }

        public void OnExit(IGameObject self)
        {
            Position = positionOrigin;
            Rotation = rotationOrigin;
            Scale = scaleOrigin;
            Logger.Info($"[{GetType()}] Reset Transform of GameObject '{self.Get<Info>().Name}' to Position: {Position} , Rotation: {Rotation}, Scale: {Scale}");
        }
    }
}