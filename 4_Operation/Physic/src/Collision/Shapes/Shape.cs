// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Shape.cs
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

using System;
using System.Diagnostics;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.RayCast;
using Alis.Core.Physic.Shared;

namespace Alis.Core.Physic.Collision.Shapes
{
    /// <summary>
    ///     A shape is used for collision detection. You can create a shape however you like. Shapes used for simulation
    ///     in World are created automatically when a Fixture is created. Shapes may encapsulate a one or more child shapes.
    ///     A shape is 2D geometrical object, such as a circle or polygon.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        ///     The density
        /// </summary>
        internal float DensityPrivate;
        
        /// <summary>
        ///     The mass data
        /// </summary>
        internal MassData MassDataPrivate;
        
        /// <summary>
        ///     The radius
        /// </summary>
        internal float RadiusPrivate;
        
        /// <summary>
        ///     The shape type
        /// </summary>
        internal ShapeType ShapeTypePrivate;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="Shape" /> class
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="radius">The radius</param>
        /// <param name="density">The density</param>
        internal Shape(ShapeType type, float radius = 0, float density = 0)
        {
            Debug.Assert(radius >= 0);
            Debug.Assert(density >= 0);
            
            ShapeTypePrivate = type;
            RadiusPrivate = radius;
            DensityPrivate = density;
            MassDataPrivate = new MassData();
        }
        
        /// <summary>Get the type of this shape.</summary>
        /// <value>The type of the shape.</value>
        public ShapeType ShapeType => ShapeTypePrivate;
        
        /// <summary>Get the number of child primitives.</summary>
        public abstract int ChildCount { get; }
        
        /// <summary>Radius of the Shape Changing the radius causes a recalculation of shape properties.</summary>
        public float Radius
        {
            get => RadiusPrivate;
            set
            {
                Debug.Assert(value >= 0);
                
                if (Math.Abs(RadiusPrivate - value) > 0.01F)
                {
                    RadiusPrivate = value;
                    ComputeProperties();
                }
            }
        }
        
        //Velcro: Moved density to the base shape. Simplifies a lot of code everywhere else
        /// <summary>Gets or sets the density. Changing the density causes a recalculation of shape properties.</summary>
        /// <value>The density.</value>
        public float Density
        {
            get => DensityPrivate;
            set
            {
                Debug.Assert(value >= 0);
                
                if (Math.Abs(DensityPrivate - value) > 0.01F)
                {
                    DensityPrivate = value;
                    ComputeProperties();
                }
            }
        }
        
        /// <summary>
        ///     Contains the properties of the shape such as:
        ///     - Area of the shape
        ///     - Centroid
        ///     - Inertia
        ///     - Mass
        /// </summary>
        public void GetMassData(out MassData massData)
        {
            massData = MassDataPrivate;
        }
        
        /// <summary>Clone the concrete shape</summary>
        /// <returns>A clone of the shape</returns>
        public abstract Shape Clone();
        
        /// <summary>Test a point for containment in this shape. Note: This only works for convex shapes.</summary>
        /// <param name="transform">The shape world transform.</param>
        /// <param name="point">A point in world coordinates.</param>
        /// <returns>True if the point is inside the shape</returns>
        public abstract bool TestPoint(ref Transform transform, ref Vector2 point);
        
        /// <summary>Cast a ray against a child shape.</summary>
        /// <param name="input">The ray-cast input parameters.</param>
        /// <param name="transform">The transform to be applied to the shape.</param>
        /// <param name="childIndex">The child shape index.</param>
        /// <param name="output">The ray-cast results.</param>
        /// <returns>True if the ray-cast hits the shape</returns>
        public abstract bool RayCast(ref RayCastInput input, ref Transform transform, int childIndex,
            out RayCastOutput output);
        
        /// <summary>Given a transform, compute the associated axis aligned bounding box for a child shape.</summary>
        /// <param name="transform">The world transform of the shape.</param>
        /// <param name="childIndex">The child shape index.</param>
        /// <param name="aabb">The AABB results.</param>
        public abstract void ComputeAabb(ref Transform transform, int childIndex, out Aabb aabb);
        
        /// <summary>
        ///     Compute the mass properties of this shape using its dimensions and density. The inertia tensor is computed
        ///     about the local origin, not the centroid.
        /// </summary>
        protected abstract void ComputeProperties();
    }
}