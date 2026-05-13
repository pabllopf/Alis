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
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Ecs.Components
{
    /// <summary>
    ///     Represents the spatial transform (position, rotation, scale) of an ECS entity.
    /// </summary>
    public struct Transform : IOnStart, IOnExit
    {
        /// <summary>
        ///     The original position for reset purposes.
        /// </summary>
        private readonly Vector2F positionOrigin;

        /// <summary>
        ///     The original rotation for reset purposes.
        /// </summary>
        private readonly float rotationOrigin;

        /// <summary>
        ///     The original scale for reset purposes.
        /// </summary>
        private readonly Vector2F scaleOrigin;

        /// <summary>
        ///     Current position of the entity in world space.
        /// </summary>
        public Vector2F Position;

        /// <summary>
        ///     Current rotation of the entity in radians.
        /// </summary>
        public float Rotation;

        /// <summary>
        ///     Current scale of the entity.
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
        ///     Initializes a new instance of the <see cref="Transform" /> struct.
        /// </summary>
        /// <param name="position">The initial position.</param>
        /// <param name="rotation">The initial rotation in radians.</param>
        public Transform(Vector2F position, float rotation)

        /// <summary>
        ///     Initializes a new instance of the <see cref="Transform" /> struct.
        /// </summary>
        /// <param name="position">The initial position.</param>
        /// <param name="rotation">The initial rotation in radians.</param>
        /// <param name="scale">The initial scale.</param>
        public Transform(Vector2F position, float rotation, Vector2F scale)
        {
            Rotation = rotation;
            Position = position;
            Scale = scale;

            positionOrigin = position;
            rotationOrigin = rotation;
            scaleOrigin = scale;
        }

        /// <summary>
        ///     Ons the start using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnStart(IGameObject self)
        {
        }

        /// <summary>
        ///     Called when the entity is started.
        /// </summary>
        /// <param name="self">The owning game object.</param>
        public void OnStart(IGameObject self)

        /// <summary>
        ///     Called when the entity is destroyed; resets transform to origin values.
        /// </summary>
        /// <param name="self">The owning game object.</param>
        public void OnExit(IGameObject self)
        {
            Position = positionOrigin;
            Rotation = rotationOrigin;
            Scale = scaleOrigin;
        }
    }
}