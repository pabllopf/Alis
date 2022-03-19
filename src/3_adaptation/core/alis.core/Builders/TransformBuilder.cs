// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   TransformBuilder.cs
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
using Alis.FluentApi;
using Alis.FluentApi.Words;

namespace Alis.Core.Builders
{
    /// <summary>
    /// The transform builder class
    /// </summary>
    /// <seealso cref="IBuild{Transform}"/>
    /// <seealso cref="IPosition{TransformBuilder, float, float, float}"/>
    /// <seealso cref="IScale{TransformBuilder, float, float, float}"/>
    /// <seealso cref="IRotation{TransformBuilder, float}"/>
    /// <seealso cref="IRotation{TransformBuilder, Vector3}"/>
    public class TransformBuilder :
        IBuild<Transform>,
        IPosition<TransformBuilder, float, float, float>,
        IScale<TransformBuilder, float, float, float>,
        IRotation<TransformBuilder, float>,
        IRotation<TransformBuilder, Vector3>
    {
        /// <summary>
        /// The transform
        /// </summary>
        private Transform transform;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TransformBuilder"/> class
        /// </summary>
        public TransformBuilder() => transform = new Transform();

        /// <summary>
        /// Builds this instance
        /// </summary>
        /// <returns>The transform</returns>
        public Transform Build() => transform;
        
        /// <summary>
        /// Rotations the angle
        /// </summary>
        /// <param name="angle">The angle</param>
        /// <returns>The transform builder</returns>
        public TransformBuilder Rotation(Vector3 angle)
        {
            transform.Rotation = angle;
            return this;
        }

        /// <summary>
        /// Rotations the angle
        /// </summary>
        /// <param name="angle">The angle</param>
        /// <returns>The transform builder</returns>
        public TransformBuilder Rotation(float angle)
        {
            transform.SetRotation(angle);
            return this;
        }

        /// <summary>
        /// Positions the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="z">The </param>
        /// <returns>The transform builder</returns>
        public TransformBuilder Position(float x, float y, float z)
        {
            transform.Position = new Vector3(x, y, z);
            return this;
        }

        /// <summary>
        /// Scales the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="z">The </param>
        /// <returns>The transform builder</returns>
        public TransformBuilder Scale(float x, float y, float z)
        {
            transform.Scale = new Vector3(x, y, z);
            return this;
        }
    }
}