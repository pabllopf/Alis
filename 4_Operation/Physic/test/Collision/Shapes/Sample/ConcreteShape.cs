// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConcreteShape.cs
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

using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.RayCast;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Shared;

namespace Alis.Core.Physic.Test.Collision.Shapes
{
    /// <summary>
    /// The concrete shape class
    /// </summary>
    /// <seealso cref="AShape"/>
    public class ConcreteShape : AShape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConcreteShape"/> class
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="radius">The radius</param>
        /// <param name="density">The density</param>
        public ConcreteShape(ShapeType type, float radius = 0, float density = 0) : base(type, radius, density)
        {
        }
        
        /// <summary>
        /// Gets the value of the child count
        /// </summary>
        public override int ChildCount { get; }
        /// <summary>
        /// Clones this instance
        /// </summary>
        /// <returns>The shape</returns>
        public override AShape Clone() => throw new System.NotImplementedException();
        
        /// <summary>
        /// Describes whether this instance test point
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <param name="point">The point</param>
        /// <returns>The bool</returns>
        public override bool TestPoint(ref Transform transform, ref Vector2 point) => throw new System.NotImplementedException();
        
        /// <summary>
        /// Describes whether this instance ray cast
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="transform">The transform</param>
        /// <param name="childIndex">The child index</param>
        /// <param name="output">The output</param>
        /// <returns>The bool</returns>
        public override bool RayCast(ref RayCastInput input, ref Transform transform, int childIndex, out RayCastOutput output) => throw new System.NotImplementedException();
        
        /// <summary>
        /// Computes the aabb using the specified transform
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <param name="childIndex">The child index</param>
        /// <param name="aabb">The aabb</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void ComputeAabb(ref Transform transform, int childIndex, out Aabb aabb)
        {
            throw new System.NotImplementedException();
        }
    }
}