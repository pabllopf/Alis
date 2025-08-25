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


using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Collision.Shapes
{
    /// <summary>
    ///     A shape is used for collision detection. You can create a shape however you like.
    ///     Shapes used for simulation in World are created automatically when a Fixture
    ///     is created. Shapes may encapsulate a one or more child shapes.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        ///     The 2radius
        /// </summary>
        internal float _2radius;

        /// <summary>
        ///     The density
        /// </summary>
        internal float Density;

        /// <summary>
        ///     Contains the properties of the shape such as:
        ///     - Area of the shape
        ///     - Centroid
        ///     - Inertia
        ///     - Mass
        /// </summary>
        public MassData MassData;

        /// <summary>
        ///     The radius
        /// </summary>
        internal float Radius;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Shape" /> class
        /// </summary>
        /// <param name="density">The density</param>
        protected Shape(float density)
        {
            Density = density;
            ShapeType = ShapeType.Unknown;
        }

        /// <summary>
        ///     Get the type of this shape.
        /// </summary>
        /// <value>The type of the shape.</value>
        public ShapeType ShapeType { get; internal set; }

        /// <summary>
        ///     Get the number of child primitives.
        /// </summary>
        /// <value></value>
        public abstract int ChildCount { get; }

        /// <summary>
        ///     Gets or sets the density.
        ///     Changing the density causes a recalculation of shape properties.
        /// </summary>
        /// <value>The density.</value>
        public float GetDensity
        {
            get => Density;
            set
            {
                Density = value;
                ComputeProperties();
            }
        }

        /// <summary>
        ///     Radius of the Shape
        ///     Changing the radius causes a recalculation of shape properties.
        /// </summary>
        public float GetRadius
        {
            get => Radius;
            set
            {
                Radius = value;
                _2radius = Radius * Radius;

                ComputeProperties();
            }
        }

        /// <summary>
        ///     Clone the concrete shape
        /// </summary>
        /// <returns>A clone of the shape</returns>
        public abstract Shape Clone();

        /// <summary>
        ///     Test a point for containment in this shape.
        ///     Note: This only works for convex shapes.
        /// </summary>
        /// <param name="controllerTransform">The shape world transform.</param>
        /// <param name="point">A point in world coordinates.</param>
        /// <returns>True if the point is inside the shape</returns>
        public abstract bool TestPoint(ref ControllerTransform controllerTransform, ref Vector2F point);

        /// <summary>
        ///     Cast a ray against a child shape.
        /// </summary>
        /// <param name="output">The ray-cast results.</param>
        /// <param name="input">The ray-cast input parameters.</param>
        /// <param name="controllerTransform">The transform to be applied to the shape.</param>
        /// <param name="childIndex">The child shape index.</param>
        /// <returns>True if the ray-cast hits the shape</returns>
        public abstract bool RayCast(out RayCastOutput output, ref RayCastInput input, ref ControllerTransform controllerTransform, int childIndex);

        /// <summary>
        ///     Given a transform, compute the associated axis aligned bounding box for a child shape.
        /// </summary>
        /// <param name="aabb">The aabb results.</param>
        /// <param name="controllerTransform">The world transform of the shape.</param>
        /// <param name="childIndex">The child shape index.</param>
        public abstract void ComputeAabb(out Aabb aabb, ref ControllerTransform controllerTransform, int childIndex);

        /// <summary>
        ///     Compute the mass properties of this shape using its dimensions and density.
        ///     The inertia tensor is computed about the local origin, not the centroid.
        /// </summary>
        protected abstract void ComputeProperties();

        /// <summary>
        ///     Used for the buoyancy controller
        /// </summary>
        public abstract float ComputeSubmergedArea(ref Vector2F normal, float offset, ref ControllerTransform xf, out Vector2F sc);
    }
}