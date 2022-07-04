// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   CircleShape.cs
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
using Alis.Core.Physic.D2.Collision.RayCast;
using Alis.Core.Physic.D2.Shared;
using Alis.Core.Physic.D2.Utilities;

namespace Alis.Core.Physic.D2.Collision.Shapes
{
    /// <summary>A circle shape.</summary>
    public class CircleShape : Shape
    {
        /// <summary>
        ///     The position
        /// </summary>
        internal Vector2 Positionprivate;

        /// <summary>Create a new circle with the desired radius and density.</summary>
        /// <param name="radius">The radius of the circle.</param>
        /// <param name="density">The density of the circle.</param>
        /// <param name="position">Position of the shape</param>
        public CircleShape(float radius, float density, Vector2 position = default(Vector2)) : base(ShapeType.Circle,
            radius, density)
        {
            Positionprivate = position;
            ComputeProperties();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CircleShape" /> class
        /// </summary>
        /// <param name="density">The density</param>
        public CircleShape(float density) : base(ShapeType.Circle, 0, density)
        {
            ComputeProperties();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CircleShape" /> class
        /// </summary>
        private CircleShape() : base(ShapeType.Circle)
        {
        }

        /// <summary>
        ///     Gets the value of the child count
        /// </summary>
        public override int ChildCount
        {
            get { return 1; }
        }

        /// <summary>Get or set the position of the circle</summary>
        public Vector2 Position
        {
            get { return Positionprivate; }
            set
            {
                if (Positionprivate != value)
                {
                    Positionprivate = value;
                    ComputeInertia();
                }
            }
        }

        /// <summary>
        ///     Describes whether this instance test point
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <param name="point">The point</param>
        /// <returns>The bool</returns>
        public override bool TestPoint(ref Transform transform, ref Vector2 point)
        {
            return TestPointHelper.TestPointCircle(ref Positionprivate, RadiusPrivate, ref point, ref transform);
        }

        /// <summary>
        ///     Describes whether this instance ray cast
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="transform">The transform</param>
        /// <param name="childIndex">The child index</param>
        /// <param name="output">The output</param>
        /// <returns>The bool</returns>
        public override bool RayCast(ref RayCastInput input, ref Transform transform, int childIndex,
            out RayCastOutput output)
        {
            return RayCastHelper.RayCastCircle(ref Positionprivate, RadiusPrivate, ref input, ref transform,
                out output);
        }

        /// <summary>
        ///     Computes the aabb using the specified transform
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <param name="childIndex">The child index</param>
        /// <param name="aabb">The aabb</param>
        public override void ComputeAabb(ref Transform transform, int childIndex, out Aabb aabb)
        {
            AabbHelper.ComputeCircleAabb(ref Positionprivate, RadiusPrivate, ref transform, out aabb);
        }

        /// <summary>
        ///     Computes the properties
        /// </summary>
        protected sealed override void ComputeProperties()
        {
            ComputeMass();
            ComputeInertia();
        }

        /// <summary>
        ///     Computes the mass
        /// </summary>
        private void ComputeMass()
        {
            //Velcro: We calculate area for later consumption
            float area = MathConstants.Pi * RadiusPrivate * RadiusPrivate;
            MassDataPrivate.Area = area;
            MassDataPrivate.Mass = DensityPrivate * area;
        }

        /// <summary>
        ///     Computes the inertia
        /// </summary>
        private void ComputeInertia()
        {
            MassDataPrivate.Centroid = Positionprivate;

            // inertia about the local origin
            MassDataPrivate.Inertia = MassDataPrivate.Mass *
                                      (0.5f * RadiusPrivate * RadiusPrivate +
                                       Vector2.Dot(Positionprivate, Positionprivate));
        }

        /// <summary>
        ///     Clones this instance
        /// </summary>
        /// <returns>The clone</returns>
        public override Shape Clone()
        {
            CircleShape clone = new CircleShape
            {
                ShapeTypePrivate = ShapeTypePrivate,
                RadiusPrivate = RadiusPrivate,
                DensityPrivate = DensityPrivate,
                Positionprivate = Positionprivate,
                MassDataPrivate = MassDataPrivate
            };
            return clone;
        }
    }
}