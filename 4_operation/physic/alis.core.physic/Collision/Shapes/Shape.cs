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

using System;
using Alis.Aspect.Math;

namespace Alis.Core.Physic.Collision.Shapes
{
    /// <summary>
    ///     A shape is used for collision detection. You can create a shape however you like.
    ///     Shapes used for simulation in World are created automatically when a Fixture is created.
    /// </summary>
    public abstract class Shape : IDisposable
    {
        /// <summary>
        ///     The radius
        /// </summary>
        internal float Radius;

        /// <summary>
        ///     The unknown shape
        /// </summary>
        protected ShapeType Type = ShapeType.UnknownShape;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Shape" /> class
        /// </summary>
        protected Shape()
        {
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public virtual void Dispose()
        {
        }

        /// <summary>
        ///     Test a point for containment in this shape. This only works for convex shapes.
        /// </summary>
        /// <param name="xf">The shape world transform.</param>
        /// <param name="p">A point in world coordinates.</param>
        /// <returns></returns>
        public abstract bool TestPoint(XForm xf, Vector2 p);

        /// <summary>
        ///     Perform a ray cast against this shape.
        /// </summary>
        /// <param name="xf">The shape world transform.</param>
        /// <param name="lambda">
        ///     Returns the hit fraction. You can use this to compute the contact point
        ///     p = (1 - lambda) * segment.P1 + lambda * segment.P2.
        /// </param>
        /// <param name="normal">
        ///     Returns the normal at the contact point. If there is no intersection,
        ///     the normal is not set.
        /// </param>
        /// <param name="segment">Defines the begin and end point of the ray cast.</param>
        /// <param name="maxLambda">A number typically in the range [0,1].</param>
        public abstract SegmentCollide TestSegment(XForm xf, out float lambda, out Vector2 normal, Segment segment,
            float maxLambda);

        /// <summary>
        ///     Given a transform, compute the associated axis aligned bounding box for this shape.
        /// </summary>
        /// <param name="aabb">Returns the axis aligned box.</param>
        /// <param name="xf">The world transform of the shape.</param>
        public abstract void ComputeAabb(out Aabb aabb, XForm xf);

        /// <summary>
        ///     Compute the mass properties of this shape using its dimensions and density.
        ///     The inertia tensor is computed about the local origin, not the centroid.
        /// </summary>
        /// <param name="massData">Returns the mass data for this shape</param>
        /// <param name="density"></param>
        public abstract void ComputeMass(out MassData massData, float density);

        /// <summary>
        ///     Compute the volume and centroid of this shape intersected with a half plane.
        /// </summary>
        /// <param name="normal">Normal the surface normal.</param>
        /// <param name="offset">Offset the surface offset along normal.</param>
        /// <param name="xf">The shape transform.</param>
        /// <param name="c">Returns the centroid.</param>
        /// <returns>The total volume less than offset along normal.</returns>
        public abstract float ComputeSubmergedArea(Vector2 normal, float offset, XForm xf, out Vector2 c);

        /// <summary>
        ///     Compute the sweep radius. This is used for conservative advancement (continuous collision detection).
        /// </summary>
        /// <param name="pivot">Pivot is the pivot point for rotation.</param>
        /// <returns>The distance of the furthest point from the pivot.</returns>
        public abstract float ComputeSweepRadius(Vector2 pivot);

        /// <summary>
        ///     Gets the vertex using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The vec</returns>
        public abstract Vector2 GetVertex(int index);

        /// <summary>
        ///     Gets the support using the specified d
        /// </summary>
        /// <param name="d">The </param>
        /// <returns>The int</returns>
        public abstract int GetSupport(Vector2 d);

        /// <summary>
        ///     Gets the support vertex using the specified d
        /// </summary>
        /// <param name="d">The </param>
        /// <returns>The vec</returns>
        public abstract Vector2 GetSupportVertex(Vector2 d);
    }
}