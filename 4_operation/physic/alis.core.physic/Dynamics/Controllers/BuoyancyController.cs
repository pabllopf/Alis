// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   BuoyancyController.cs
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

using Alis.Aspect.Math;
using Alis.Aspect.Time;

namespace Alis.Core.Physic.Dynamics.Controllers
{
    /// <summary>
    ///     Calculates buoyancy forces for fluids in the form of a half plane.
    /// </summary>
    public class BuoyancyController : Controller
    {
        /// Linear drag co-efficient
        private readonly float angularDrag;

        /// The fluid density
        public readonly float Density;

        /// Linear drag co-efficient
        public readonly float LinearDrag;

        /// The height of the fluid surface along the normal
        public readonly float Offset;

        /// If false, bodies are assumed to be uniformly dense, otherwise use the shapes densities
        public readonly bool UseDensity; //False by default to prevent a gotcha

        /// If true, gravity is taken from the world instead of the gravity parameter.
        public readonly bool UseWorldGravity;

        /// <summary>
        ///     Buoyancy controller
        /// </summary>
        private BuoyancyControllerDef buoyancyControllerDef;

        /// Gravity vector, if the world's gravity is not used
        public Vector2 Gravity;

        /// The outer surface normal
        public Vector2 Normal;

        /// Fluid velocity, for drag calculations
        public Vector2 Velocity;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BuoyancyController" /> class
        /// </summary>
        /// <param name="buoyancyControllerDef">The buoyancy controller def</param>
        public BuoyancyController(BuoyancyControllerDef buoyancyControllerDef)
        {
            this.buoyancyControllerDef = buoyancyControllerDef;
            Normal = buoyancyControllerDef.Normal;
            Offset = buoyancyControllerDef.Offset;
            Density = buoyancyControllerDef.Density;
            Velocity = buoyancyControllerDef.Velocity;
            LinearDrag = buoyancyControllerDef.LinearDrag;
            angularDrag = buoyancyControllerDef.AngularDrag;
            UseDensity = buoyancyControllerDef.UseDensity;
            UseWorldGravity = buoyancyControllerDef.UseWorldGravity;
            Gravity = buoyancyControllerDef.Gravity;
        }

        /// <summary>
        ///     Steps the step
        /// </summary>
        /// <param name="step">The step</param>
        public override void Step(TimeStep step)
        {
            //B2_NOT_USED(step);
            if (BodyList == null)
            {
                return;
            }

            if (UseWorldGravity)
            {
                Gravity = World.Gravity;
            }

            for (ControllerEdge i = BodyList; i != null; i = i.NextBody)
            {
                Body body = i.Body;
                if (body.IsSleeping())
                {
                    //Buoyancy force is just a function of position,
                    //so unlike most forces, it is safe to ignore sleeping bodes
                    continue;
                }

                Vector2 areac = new Vector2(0, 0);
                Vector2 massc = new Vector2(0, 0);
                float area = 0;
                float mass = 0;
                for (Fixture shape = body.GetFixtureList(); shape != null; shape = shape.Next)
                {
                    Vector2 sc;
                    float sarea = shape.ComputeSubmergedArea(Normal, Offset, out sc);
                    area += sarea;
                    areac.X += sarea * sc.X;
                    areac.Y += sarea * sc.Y;
                    float shapeDensity = 0;
                    if (UseDensity)
                    {
                        shapeDensity = shape.Density;
                    }
                    else
                    {
                        shapeDensity = 1;
                    }

                    mass += sarea * shapeDensity;
                    massc.X += sarea * sc.X * shapeDensity;
                    massc.Y += sarea * sc.Y * shapeDensity;
                }

                areac.X /= area;
                areac.Y /= area;
                //Vec2 localCentroid = Math.MulT(body.GetXForm(), areac);
                massc.X /= mass;
                massc.Y /= mass;
                if (area < Settings.FltEpsilon)
                {
                    continue;
                }

                //Buoyancy
                Vector2 buoyancyForce = -Density * area * Gravity;
                body.ApplyForce(buoyancyForce, massc);
                //Linear drag
                Vector2 dragForce = body.GetLinearVelocityFromWorldPoint(areac) - Velocity;
                dragForce *= -LinearDrag * area;
                body.ApplyForce(dragForce, areac);
                //Angular drag
                body.ApplyTorque(-body.GetInertia() / body.GetMass() * area * body.GetAngularVelocity() * angularDrag);
            }
        }
    }
}