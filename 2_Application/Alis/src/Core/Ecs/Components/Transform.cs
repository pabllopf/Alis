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
    public struct Transform : IInitable, IGameObjectComponent
    {
        /// <summary>
        ///     The position
        /// </summary>
        public Vector2F Position;

        /// <summary>
        ///     The rotation
        /// </summary>
        public Complex Rotation;

        /// <summary>
        ///     The scale
        /// </summary>
        public Vector2F Scale;

        /// <summary>
        ///     Inits the self
        /// </summary>
        /// <param name="self">The self</param>
        public void Init(IGameObject self)
        {
        }

        /// <summary>
        ///     Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        public void Update(IGameObject self)
        {
        }


        /// <summary>
        ///     Initialize using a position vector and a Complex rotation.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation</param>
        public Transform(Vector2F position, Complex rotation)
        {
            Rotation = rotation;
            Position = position;
            Scale = Vector2F.One; // Default scale is 1,1
          
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Transform" /> class
        /// </summary>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="scale">The scale</param>
        public Transform(Vector2F position, Complex rotation, Vector2F scale)
        {
            Rotation = rotation;
            Position = position;
            Scale = scale;

        }

        /// <summary>
        ///     Initialize using a position vector and a rotation.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="angle">The rotation angle</param>
        public Transform(Vector2F position, float angle)
            : this(position, Complex.FromAngle(angle))
        {
           
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Transform" /> class
        /// </summary>
        /// <param name="position">The position</param>
        /// <param name="angle">The angle</param>
        /// <param name="scale">The scale</param>
        public Transform(Vector2F position, float angle, Vector2F scale)
            : this(position, Complex.FromAngle(angle), scale)
        {
            
        }
    }
}