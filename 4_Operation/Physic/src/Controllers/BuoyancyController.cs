// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BuoyancyController.cs
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

using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Controllers
{
    /// <summary>
    ///     Simulates buoyancy forces on rigid bodies within a fluid region.
    /// </summary>
    /// <remarks>
    ///     <para>This controller applies buoyancy forces, linear drag, and angular drag to bodies
    ///     that overlap with the specified container AABB.</para>
    ///     <para>Buoyancy is calculated using Archimedes' principle: the upward buoyant force equals
    ///     the weight of the fluid displaced by the submerged portion of the body.</para>
    ///     <para>The controller computes the submerged area of each body's fixtures using the
    ///     shape's <see cref="Shape.ComputeSubmergedArea"/> method, which determines how much of
    ///     the shape lies below the fluid surface defined by the container's upper bound.</para>
    ///     <para>Drag forces are applied to simulate fluid resistance. Linear drag acts against
    ///     the body's linear velocity relative to the fluid, while angular drag resists rotation.</para>
    ///     <example>
    ///     <code>
    ///     // Create a buoyancy controller for a water surface
    ///     var waterArea = new Aabb(new Vector2F(-50, 0), new Vector2F(50, 20));
    ///     var buoyancy = new BuoyancyController(
    ///         container: waterArea,
    ///         density: 1.0f,           // Water density
    ///         linearDragCoefficient: 0.05f,
    ///         rotationalDragCoefficient: 0.1f,
    ///         gravity: new Vector2F(0, -9.81f)
    ///     );
    ///     
    ///     // Add current effect (water flow)
    ///     buoyancy.Velocity = new Vector2F(1, 0);
    ///     
    ///     // Add controller to world
    ///     world.AddController(buoyancy);
    ///     </code>
    ///     </example>
    /// </remarks>
    /// <seealso cref="Controller" />
    public sealed class BuoyancyController : Controller
    {
        /// <summary>
        ///     The gravity vector defining the direction and magnitude of gravitational force.
        /// </summary>
        private readonly Vector2F _gravity;

        /// <summary>
        ///     Collection of unique bodies currently within the fluid region that are eligible for buoyancy calculations.
        /// </summary>
        private readonly ICollection<Body> _uniqueBodies = new List<Body>();

        /// <summary>
        ///     Controls the rotational drag that the fluid exerts on bodies within it.
        ///     Higher values simulate thicker fluids (e.g., honey), while lower values simulate water-like fluids.
        /// </summary>
        public readonly float AngularDragCoefficient;

        /// <summary>
        ///     Density of the fluid. Higher values increase buoyancy, causing objects to float more readily.
        ///     Lower values reduce buoyant force, causing objects to sink.
        /// </summary>
        public readonly float Density;

        /// <summary>
        ///     Controls the linear drag that the fluid exerts on bodies within it.
        ///     Higher values simulate thicker fluids (e.g., honey), while lower values simulate water-like fluids.
        /// </summary>
        public readonly float LinearDragCoefficient;

        /// <summary>
        ///     The AABB defining the fluid region. Updated via the <see cref="Container"/> property.
        /// </summary>
        private Aabb _container;

        /// <summary>
        ///     The surface normal vector of the fluid, pointing upward. Defaults to (0, 1).
        /// </summary>
        private Vector2F _normal;

        /// <summary>
        ///     The Y-coordinate offset representing the fluid surface level, derived from <see cref="Container"/>.UpperBound.Y.
        /// </summary>
        private float _offset;

        /// <summary>
        ///     Simulates water current or flow velocity. Defaults to (0, 0).
        /// </summary>
        public Vector2F Velocity;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BuoyancyController" /> class.
        /// </summary>
        /// <param name="container">Only bodies inside this AABB will be influenced by the controller</param>
        /// <param name="density">Density of the fluid</param>
        /// <param name="linearDragCoefficient">Linear drag coefficient of the fluid</param>
        /// <param name="rotationalDragCoefficient">Rotational drag coefficient of the fluid</param>
        /// <param name="gravity">The direction gravity acts. Buoyancy force will act in opposite direction of gravity.</param>
        public BuoyancyController(Aabb container, float density, float linearDragCoefficient, float rotationalDragCoefficient, Vector2F gravity)
        {
            Container = container;
            _normal = new Vector2F(0, 1);
            Density = density;
            LinearDragCoefficient = linearDragCoefficient;
            AngularDragCoefficient = rotationalDragCoefficient;
            _gravity = gravity;
        }

        /// <summary>
        ///     Gets or sets the AABB defining the fluid region.
        /// </summary>
        /// <remarks>
        ///     The upper bound of this AABB represents the fluid surface level.
        ///     Bodies with fixtures below this Y coordinate are considered submerged.
        ///     Only bodies intersecting this AABB will be affected by buoyancy forces.
        /// </remarks>
        public Aabb Container
        {
            get => _container;
            set
            {
                _container = value;
                _offset = _container.UpperBound.Y;
            }
        }

        /// <summary>
        ///     Applies buoyancy forces to all bodies within the fluid region.
        /// </summary>
        /// <param name="dt">Time step delta in seconds. Used to scale velocity clamping calculations.</param>
        /// <remarks>
        ///     <para>This method is called automatically by the physics world during simulation.
        ///     It performs the following steps:</para>
        ///     <list type="number">
        ///         <item>Queries all fixtures intersecting the container AABB</item>
        ///         <item>Filters to unique bodies (skipping static and sleeping bodies)</item>
        ///         <item>For each body, iterates through polygon and circle fixtures</item>
        ///         <item>Computes submerged area and centroid for each fixture</item>
        ///         <item>Applies buoyancy force: <c>F = -density * area * gravity</c></item>
        ///         <item>Applies linear drag based on velocity difference from fluid</item>
        ///         <item>Applies angular drag proportional to angular velocity</item>
        ///     </list>
        /// </remarks>
        public override void Update(float dt)
        {
            _uniqueBodies.Clear();
            WorldPhysic.QueryAabb(fixture =>
            {
                if (fixture.GetBody.GetBodyType == BodyType.Static || !fixture.GetBody.Awake)
                {
                    return true;
                }

                if (!_uniqueBodies.Contains(fixture.GetBody))
                {
                    _uniqueBodies.Add(fixture.GetBody);
                }

                return true;
            }, ref _container);

            if (_uniqueBodies.Count == 0)
            {
                return;
            }

            foreach (Body body in _uniqueBodies)
            {
                Vector2F areac = Vector2F.Zero;
                Vector2F massc = Vector2F.Zero;
                float area = 0;
                float mass = 0;

                foreach (Fixture fixture in body.FixtureList)
                {
                    if ((fixture.GetShape.ShapeType != ShapeType.Polygon) && (fixture.GetShape.ShapeType != ShapeType.Circle))
                    {
                        continue;
                    }

                    Shape shape = fixture.GetShape;

                    float sarea = shape.ComputeSubmergedArea(ref _normal, _offset, ref body.Xf, out Vector2F sc);
                    area += sarea;
                    areac.X += sarea * sc.X;
                    areac.Y += sarea * sc.Y;

                    mass += sarea * shape.GetDensity;
                    massc.X += sarea * sc.X * shape.GetDensity;
                    massc.Y += sarea * sc.Y * shape.GetDensity;
                }

                areac.X /= area;
                areac.Y /= area;
                massc.X /= mass;
                massc.Y /= mass;

                if (area < SettingEnv.Epsilon)
                {
                    continue;
                }

                //Buoyancy
                Vector2F buoyancyForce = -Density * area * _gravity;
                body.ApplyForce(buoyancyForce, massc);

                //Linear drag
                Vector2F dragVelocity = body.GetLinearVelocityFromWorldPoint(areac) - Velocity;
                Vector2F dragForce = dragVelocity * (-LinearDragCoefficient * area);
                body.ApplyForce(dragForce, areac);

                //Angular drag
                body.ApplyTorque(-body.Inertia / body.Mass * area * body.AngularVelocity * AngularDragCoefficient);
            }
        }
    }
}