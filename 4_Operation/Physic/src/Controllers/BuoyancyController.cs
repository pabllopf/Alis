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
using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Controllers
{
    /// <summary>
    ///     The buoyancy controller class
    /// </summary>
    /// <seealso cref="Controller" />
    public sealed class BuoyancyController : Controller
    {
        /// <summary>
        ///     The gravity
        /// </summary>
        private readonly Vector2F _gravity;

        /// <summary>
        ///     The body
        /// </summary>
        private readonly ICollection<Body> _uniqueBodies = new List<Body>();

        /// <summary>
        ///     The container
        /// </summary>
        private AABB _container;

        /// <summary>
        ///     The normal
        /// </summary>
        private Vector2F _normal;

        /// <summary>
        ///     The offset
        /// </summary>
        private float _offset;

        /// <summary>
        ///     Controls the rotational drag that the fluid exerts on the bodies within it. Use higher values will simulate thick
        ///     fluid, like honey, lower values to
        ///     simulate water-like fluids.
        /// </summary>
        public float AngularDragCoefficient;

        /// <summary>
        ///     Density of the fluid. Higher values will make things more buoyant, lower values will cause things to sink.
        /// </summary>
        public float Density;

        /// <summary>
        ///     Controls the linear drag that the fluid exerts on the bodies within it.  Use higher values will simulate thick
        ///     fluid, like honey, lower values to
        ///     simulate water-like fluids.
        /// </summary>
        public float LinearDragCoefficient;

        /// <summary>
        ///     Acts like waterflow. Defaults to 0,0.
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
        public BuoyancyController(AABB container, float density, float linearDragCoefficient, float rotationalDragCoefficient, Vector2F gravity)
        {
            Container = container;
            _normal = new Vector2F(0, 1);
            Density = density;
            LinearDragCoefficient = linearDragCoefficient;
            AngularDragCoefficient = rotationalDragCoefficient;
            _gravity = gravity;
        }

        /// <summary>
        ///     Gets or sets the value of the container
        /// </summary>
        public AABB Container
        {
            get => _container;
            set
            {
                _container = value;
                _offset = _container.UpperBound.Y;
            }
        }

        /// <summary>
        ///     Updates the dt
        /// </summary>
        /// <param name="dt">The dt</param>
        public override void Update(float dt)
        {
            _uniqueBodies.Clear();
            World.QueryAABB(fixture =>
            {
                if (fixture.Body.BodyType == BodyType.Static || !fixture.Body.Awake)
                {
                    return true;
                }

                if (!_uniqueBodies.Contains(fixture.Body))
                {
                    _uniqueBodies.Add(fixture.Body);
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
                    if ((fixture.Shape.ShapeType != ShapeType.Polygon) && (fixture.Shape.ShapeType != ShapeType.Circle))
                    {
                        continue;
                    }

                    Shape shape = fixture.Shape;

                    float sarea = shape.ComputeSubmergedArea(ref _normal, _offset, ref body._xf, out Vector2F sc);
                    area += sarea;
                    areac.X += sarea * sc.X;
                    areac.Y += sarea * sc.Y;

                    mass += sarea * shape.Density;
                    massc.X += sarea * sc.X * shape.Density;
                    massc.Y += sarea * sc.Y * shape.Density;
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