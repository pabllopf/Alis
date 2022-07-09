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

using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Controllers
{
    /// <summary>
    ///     Calculates buoyancy forces for fluids in the form of a half plane.
    /// </summary>
    public class BuoyancyController : Controller
    {
        /// Linear drag co-efficient
        public float AngularDrag;

        /// The fluid density
        public float Density;

        /// Gravity vector, if the world's gravity is not used
        public Vec2 Gravity;

        /// Linear drag co-efficient
        public float LinearDrag;

        /// The outer surface normal
        public Vec2 Normal;

        /// The height of the fluid surface along the normal
        public float Offset;

        /// If false, bodies are assumed to be uniformly dense, otherwise use the shapes densities
        public bool UseDensity; //False by default to prevent a gotcha

        /// If true, gravity is taken from the world instead of the gravity parameter.
        public bool UseWorldGravity;

        /// Fluid velocity, for drag calculations
        public Vec2 Velocity;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BuoyancyController" /> class
        /// </summary>
        /// <param name="buoyancyControllerDef">The buoyancy controller def</param>
        public BuoyancyController(BuoyancyControllerDef buoyancyControllerDef)
        {
            Normal = buoyancyControllerDef.Normal;
            Offset = buoyancyControllerDef.Offset;
            Density = buoyancyControllerDef.Density;
            Velocity = buoyancyControllerDef.Velocity;
            LinearDrag = buoyancyControllerDef.LinearDrag;
            AngularDrag = buoyancyControllerDef.AngularDrag;
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
                return;

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

                Vec2 areac = new Vec2(0, 0);
                Vec2 massc = new Vec2(0, 0);
                float area = 0;
                float mass = 0;
                for (Fixture shape = body.GetFixtureList(); shape != null; shape = shape.Next)
                {
                    Vec2 sc;
                    float sarea = shape.ComputeSubmergedArea(Normal, Offset, out sc);
                    area += sarea;
                    areac.X += sarea * sc.X;
                    areac.Y += sarea * sc.Y;
                    float shapeDensity = 0;
                    if (UseDensity)
                    {
                        //TODO: Expose density publicly
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
                    continue;
                //Buoyancy
                Vec2 buoyancyForce = -Density * area * Gravity;
                body.ApplyForce(buoyancyForce, massc);
                //Linear drag
                Vec2 dragForce = body.GetLinearVelocityFromWorldPoint(areac) - Velocity;
                dragForce *= -LinearDrag * area;
                body.ApplyForce(dragForce, areac);
                //Angular drag
                //TODO: Something that makes more physical sense?
                body.ApplyTorque(-body.GetInertia() / body.GetMass() * area * body.GetAngularVelocity() * AngularDrag);
            }
        }

        /// <summary>
        ///     Draws the debug draw
        /// </summary>
        /// <param name="debugDraw">The debug draw</param>
        public override void Draw(DebugDraw debugDraw)
        {
            float r = 1000;
            Vec2 p1 = Offset * Normal + Vec2.Cross(Normal, r);
            Vec2 p2 = Offset * Normal - Vec2.Cross(Normal, r);

            Color color = new Color(0, 0, 0.8f);

            debugDraw.DrawSegment(p1, p2, color);
        }
    }
}