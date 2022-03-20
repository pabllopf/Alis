// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Shape.cs
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
using Alis.Core.Physics2D.Common;

namespace Alis.Core.Physics2D.Collision.Shapes
{
    /// <summary>
    ///     A shape is used for collision detection. You can create a shape however you like.
    ///     Shapes used for simulation in World are created automatically when a Fixture is created.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// The radius
        /// </summary>
        internal float m_radius;
        /// <summary>
        /// Gets the value of the contact match
        /// </summary>
        internal abstract byte ContactMatch { get; }

        /// <summary>
        /// Clones this instance
        /// </summary>
        /// <returns>The shape</returns>
        public abstract Shape Clone();
        /// <summary>
        /// Gets the child count
        /// </summary>
        /// <returns>The int</returns>
        public abstract int GetChildCount();
        /// <summary>
        /// Describes whether this instance test point
        /// </summary>
        /// <param name="xf">The xf</param>
        /// <param name="p">The </param>
        /// <returns>The bool</returns>
        public abstract bool TestPoint(in Transform xf, in Vector2 p);

        /// <summary>
        /// Describes whether this instance ray cast
        /// </summary>
        /// <param name="output">The output</param>
        /// <param name="input">The input</param>
        /// <param name="transform">The transform</param>
        /// <param name="childIndex">The child index</param>
        /// <returns>The bool</returns>
        public abstract bool RayCast(
            out RayCastOutput output,
            in RayCastInput input,
            in Transform transform,
            int childIndex);

        /// <summary>
        /// Computes the aabb using the specified aabb
        /// </summary>
        /// <param name="aabb">The aabb</param>
        /// <param name="xf">The xf</param>
        /// <param name="childIndex">The child index</param>
        public abstract void ComputeAABB(out AABB aabb, in Transform xf, int childIndex);

        /// <summary>
        /// Computes the mass using the specified mass data
        /// </summary>
        /// <param name="massData">The mass data</param>
        /// <param name="density">The density</param>
        public abstract void ComputeMass(out MassData massData, float density);
    }
}