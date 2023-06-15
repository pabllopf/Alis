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
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Extensions.Controllers.ControllerBase;

namespace Alis.Core.Physic.Extensions.Controllers.Gravity
{
    /// <summary>
    ///     The gravity controller class
    /// </summary>
    /// <seealso cref="Controller" />
    public class GravityController : Controller
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GravityController" /> class
        /// </summary>
        /// <param name="strength">The strength</param>
        public GravityController(float strength)
            : base(ControllerType.GravityController)
        {
            Strength = strength;
            Radius = float.MaxValue;
            GravityType = GravityType.DistanceSquared;
            Points = new List<Vector2>();
            Bodies = new List<Body>();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GravityController" /> class
        /// </summary>
        /// <param name="strength">The strength</param>
        /// <param name="maxRadius">The max radius</param>
        /// <param name="minRadius">The min radius</param>
        public GravityController(float strength, float maxRadius, float minRadius)
            : base(ControllerType.GravityController)
        {
            MinRadius = minRadius;
            Radius = maxRadius;
            Strength = strength;
            GravityType = GravityType.DistanceSquared;
            Points = new List<Vector2>();
            Bodies = new List<Body>();
        }

        /// <summary>
        ///     Gets or sets the value of the min radius
        /// </summary>
        public float MinRadius { get; set; }

        /// <summary>
        ///     Gets or sets the value of the max radius
        /// </summary>
        public float Radius { get; set; }

        /// <summary>
        ///     Gets or sets the value of the strength
        /// </summary>
        public float Strength { get; set; }

        /// <summary>
        ///     Gets or sets the value of the gravity type
        /// </summary>
        public GravityType GravityType { get; set; }

        /// <summary>
        ///     Gets or sets the value of the bodies
        /// </summary>
        public List<Body> Bodies { get; set; }

        /// <summary>
        ///     Gets or sets the value of the points
        /// </summary>
        public List<Vector2> Points { get; set; }

        /// <summary>
        ///     Updates the dt
        /// </summary>
        /// <param name="dt">The dt</param>
        public override void Update(float dt)
        {
            Vector2 f = Vector2.Zero;

            foreach (Body worldBody in World.Bodies)
            {
                if (!IsActiveOn(worldBody))
                {
                    continue;
                }

                foreach (Body controllerBody in Bodies)
                {
                    if (worldBody == controllerBody || (worldBody.IsStatic && controllerBody.IsStatic) ||
                        !controllerBody.Enabled)
                    {
                        continue;
                    }

                    Vector2 d = controllerBody.Position - worldBody.Position;
                    float r2 = d.LengthSquared();

                    if (r2 <= Constant.Epsilon || r2 > Radius * Radius || r2 < MinRadius * MinRadius)
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

                foreach (Vector2 point in Points)
                {
                    Vector2 d = point - worldBody.Position;
                    float r2 = d.LengthSquared();

                    if (r2 <= Constant.Epsilon || r2 > Radius * Radius || r2 < MinRadius * MinRadius)
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
        ///     Adds the body using the specified body
        /// </summary>
        /// <param name="body">The body</param>
        public void AddBody(Body body)
        {
            Bodies.Add(body);
        }

        /// <summary>
        ///     Adds the point using the specified point
        /// </summary>
        /// <param name="point">The point</param>
        public void AddPoint(Vector2 point)
        {
            Points.Add(point);
        }
    }
}