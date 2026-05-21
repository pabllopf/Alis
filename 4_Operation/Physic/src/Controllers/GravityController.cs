// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GravityController.cs
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
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Controllers
{
    /// <summary>
    ///     A physics controller that applies gravitational forces between bodies and/or points.
    /// </summary>
    /// <remarks>
    ///     This controller simulates gravitational attraction using either Newton's law of
    ///     universal gravitation (distance-squared) or linear falloff. It can apply gravity
    ///     between specific bodies (body-to-body gravity) or between bodies and fixed points
    ///     (like planets or gravity wells).
    ///     
    ///     The controller supports distance-based falloff with configurable minimum and maximum
    ///     radius limits, allowing you to create localized gravity fields or global gravity systems.
    /// </remarks>
    /// <example>
    ///     <code>
    ///     // Create global gravity (like planetary gravity)
    ///     var gravity = new GravityController(100f);
    ///     gravity.AddPoint(new Vector2F(0, 0)); // Sun position
    ///     
    ///     // Add to world
    ///     world.AddController(gravity);
    ///     
    ///     // Or create body-to-body gravity (like star system)
    ///     var mutualGravity = new GravityController(500f, 1000f, 10f);
    ///     mutualGravity.AddBody(sun);
    ///     mutualGravity.AddBody(planet);
    ///     </code>
    /// </example>
    /// <seealso cref="Controller"/>
    public class GravityController : Controller
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GravityController"/> class
        ///     with default radius settings (unlimited range).
        /// </summary>
        /// <param name="strength">
        ///     The gravitational strength coefficient. Higher values produce stronger attraction.
        ///     This is typically G * m1 * m2 where G is the gravitational constant.
        /// </param>
        /// <remarks>
        ///     This constructor creates a gravity controller with no distance limits,
        ///     affecting all specified bodies or points regardless of distance.
        /// </remarks>
        public GravityController(float strength)
        {
            Strength = strength;
            MaxRadius = float.MaxValue;
            GravityType = GravityType.DistanceSquared;
            Points = new List<Vector2F>();
            Bodies = new List<Body>();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GravityController"/> class
        ///     with specified distance limits.
        /// </summary>
        /// <param name="strength">
        ///     The gravitational strength coefficient. Higher values produce stronger attraction.
        /// </param>
        /// <param name="maxRadius">
        ///     The maximum distance at which gravity is applied. Bodies beyond this distance
        ///     will not be affected.
        /// </param>
        /// <param name="minRadius">
        ///     The minimum distance at which gravity is applied. Bodies within this distance
        ///     will not be affected (prevents singularity when bodies overlap).
        /// </param>
        /// <remarks>
        ///     Using distance limits helps prevent numerical instability when bodies get
        ///     very close together and avoids computing gravity for distant objects.
        /// </remarks>
        public GravityController(float strength, float maxRadius, float minRadius)
        {
            MinRadius = minRadius;
            MaxRadius = maxRadius;
            Strength = strength;
            GravityType = GravityType.DistanceSquared;
            Points = new List<Vector2F>();
            Bodies = new List<Body>();
        }

        /// <summary>
        ///     Gets or sets the minimum distance at which gravity is applied.
        /// </summary>
        /// <value>
        ///     A <see cref="float"/> representing the minimum radius in world units.
        /// </value>
        /// <remarks>
        ///     Bodies closer than this distance will not experience gravitational attraction.
        ///     This prevents infinite forces when bodies overlap or get extremely close.
        /// </remarks>
        public float MinRadius { get; set; }

        /// <summary>
        ///     Gets or sets the maximum distance at which gravity is applied.
        /// </summary>
        /// <value>
        ///     A <see cref="float"/> representing the maximum radius in world units.
        /// </value>
        /// <remarks>
        ///     Bodies farther than this distance will not experience gravitational attraction.
        ///     Use this to limit the effective range of the gravity field.
        /// </remarks>
        public float MaxRadius { get; set; }

        /// <summary>
        ///     Gets or sets the gravitational strength coefficient.
        /// </summary>
        /// <value>
        ///     A <see cref="float"/> representing the strength of the gravitational force.
        /// </value>
        /// <remarks>
        ///     Higher values produce stronger gravitational attraction. The actual force
        ///     calculation depends on the <see cref="GravityType"/> setting.
        /// </remarks>
        public float Strength { get; set; }

        /// <summary>
        ///     Gets or sets the gravity calculation method.
        /// </summary>
        /// <value>
        ///     A <see cref="GravityType"/> specifying how force falls off with distance.
        /// </value>
        /// <remarks>
        ///     <see cref="GravityType.DistanceSquared"/> uses Newtonian gravity (1/r^2) while
        ///     <see cref="GravityType.Linear"/> uses linear falloff (1/r).
        /// </remarks>
        public GravityType GravityType { get; set; }

        /// <summary>
        ///     Gets or sets the list of bodies that exert gravitational attraction.
        /// </summary>
        /// <value>
        ///     A <see cref="List{Body}"/> containing the source bodies for gravity.
        /// </value>
        /// <remarks>
        ///     When bodies are added to this list, they will attract other bodies in the world.
        ///     The force is proportional to the product of the masses (F = G * m1 * m2 / r^2).
        /// </remarks>
        public List<Body> Bodies { get; set; }

        /// <summary>
        ///     Gets or sets the list of fixed points that exert gravitational attraction.
        /// </summary>
        /// <value>
        ///     A <see cref="List{Vector2F}"/> containing the positions of gravity sources.
        /// </value>
        /// <remarks>
        ///     Fixed points act as gravity wells that attract bodies with force proportional
        ///     to the body's mass (F = G * m / r^2), regardless of the source's mass.
        /// </remarks>
        public List<Vector2F> Points { get; set; }

        /// <summary>
        ///     Updates the simulation by applying gravitational forces to all affected bodies.
        /// </summary>
        /// <param name="dt">
        ///     The delta time (in seconds) since the last simulation step.
        ///     Not used directly in gravity calculations (gravity is instantaneous force).
        /// </param>
        public override void Update(float dt)
        {
            Vector2F f = Vector2F.Zero;

            foreach (Body worldBody in WorldPhysic.BodyList)
            {
                if (!IsActiveOn(worldBody))
                {
                    continue;
                }

                foreach (Body controllerBody in Bodies)
                {
                    if (worldBody == controllerBody || ((worldBody.GetBodyType == BodyType.Static) && (controllerBody.GetBodyType == BodyType.Static)) || !controllerBody.Enabled)
                    {
                        continue;
                    }

                    Vector2F d = controllerBody.Position - worldBody.Position;
                    float r2 = d.LengthSquared();

                    if (r2 <= SettingEnv.Epsilon || r2 > MaxRadius * MaxRadius || r2 < MinRadius * MinRadius)
                    {
                        continue;
                    }

                    switch (GravityType)
                    {
                        case GravityType.DistanceSquared:
                            f = Strength / r2 * worldBody.Mass * controllerBody.Mass * d;
                            break;
                        case GravityType.Linear:
                            f = Strength / (float) Math.Sqrt(r2) * worldBody.Mass * controllerBody.Mass * d;
                            break;
                    }

                    worldBody.ApplyForce(ref f);
                }

                foreach (Vector2F point in Points)
                {
                    Vector2F d = point - worldBody.Position;
                    float r2 = d.LengthSquared();

                    if (r2 <= SettingEnv.Epsilon || r2 > MaxRadius * MaxRadius || r2 < MinRadius * MinRadius)
                    {
                        continue;
                    }

                    switch (GravityType)
                    {
                        case GravityType.DistanceSquared:
                            f = Strength / r2 * worldBody.Mass * d;
                            break;
                        case GravityType.Linear:
                            f = Strength / (float) Math.Sqrt(r2) * worldBody.Mass * d;
                            break;
                    }

                    worldBody.ApplyForce(ref f);
                }
            }
        }

        /// <summary>
        ///     Adds a body to the gravity controller as a source of gravitational attraction.
        /// </summary>
        /// <param name="body">The body to add as a gravity source.</param>
        /// <remarks>
        ///     The added body will attract other bodies in the simulation based on their masses.
        ///     Static bodies can be added but will only affect other non-static bodies.
        /// </remarks>
        public void AddBody(Body body)
        {
            Bodies.Add(body);
        }

        /// <summary>
        ///     Adds a fixed point to the gravity controller as a gravity well source.
        /// </summary>
        /// <param name="point">The world position of the gravity point.</param>
        /// <remarks>
        ///     Fixed points act as stationary gravity sources that attract bodies with
        ///     force proportional to the body's mass. Unlike bodies, points don't have
        ///     mass themselves - they serve as infinite mass gravity wells.
        /// </remarks>
        public void AddPoint(Vector2F point)
        {
            Points.Add(point);
        }
    }
}