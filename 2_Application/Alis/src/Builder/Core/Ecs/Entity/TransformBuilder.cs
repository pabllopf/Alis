// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TransformBuilder.cs
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

using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components;

namespace Alis.Builder.Core.Ecs.Entity
{
    /// <summary>
    ///     The transform builder class
    /// </summary>
    /// <seealso cref="IBuild{Transform}" />
    public class TransformBuilder :
        IBuild<Transform>,
        IPosition2D<TransformBuilder, float>,
        IRotation<TransformBuilder, float>,
        IScale2D<TransformBuilder, float>
    {
        /// <summary>
        ///     The vector
        /// </summary>
        private Vector2F position = new Vector2F(0, 0);

        /// <summary>
        ///     The one
        /// </summary>
        private float rotation;

        /// <summary>
        ///     The vector
        /// </summary>
        private Vector2F scale = new Vector2F(1, 1);

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The transform</returns>
        public Transform Build() => new Transform(position, rotation, scale);

        /// <summary>
        ///     Positions the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The transform builder</returns>
        public TransformBuilder Position(float x, float y)
        {
            position = new Vector2F(x, y);
            return this;
        }

        /// <summary>
        ///     Rotations the angle
        /// </summary>
        /// <param name="angle">The angle</param>
        /// <returns>The transform builder</returns>
        public TransformBuilder Rotation(float angle)
        {
            rotation = angle;
            return this;
        }

        /// <summary>
        ///     Scales the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The transform builder</returns>
        public TransformBuilder Scale(float x, float y)
        {
            scale = new Vector2F(x, y);
            return this;
        }

        /// <summary>
        ///     Positions the vector
        /// </summary>
        /// <param name="vector">The vector</param>
        /// <returns>The transform builder</returns>
        public TransformBuilder Position(Vector2F vector)
        {
            position = vector;
            return this;
        }
    }
}