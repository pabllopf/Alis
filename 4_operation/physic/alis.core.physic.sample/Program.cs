// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Program.cs
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
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            // Define the size of the world. Simulation will still work
            // if bodies reach the end of the world, but it will be slower.
            Aabb worldAabb = new Aabb();
            worldAabb.LowerBound.Set(-100.0f);
            worldAabb.UpperBound.Set(100.0f);

            // Define the gravity vector.
            Vector2 gravity = new Vector2(0.0f, -10.0f);

            // Do we want to let bodies sleep?
            const bool doSleep = true;

            // Construct a world object, which will hold and simulate the rigid bodies.
            World world = new World(worldAabb, gravity, doSleep);
            
            // Define the ground body.
            BodyDef groundBodyDef = new BodyDef();
            groundBodyDef.Position.Set(0.0f, -10.0f);

            // Call the body factory which  creates the ground box shape.
            // The body is also added to the world.
            Body groundBody = new Body(groundBodyDef, world);
            
            // Define the ground box shape.
            PolygonDef groundShapeDef = new PolygonDef();

            // The extents are the half-widths of the box.
            groundShapeDef.SetAsBox(50.0f, 10.0f);

            // Add the ground shape to the ground body.
            groundBody.CreateFixture(groundShapeDef);
            
            world.AddBody(groundBody);

            // Define the dynamic body. We set its position and call the body factory.
            BodyDef bodyDef = new BodyDef();
            bodyDef.Position.Set(0.0f, 4.0f);
            Body body = new Body(bodyDef, world);

            // Define another box shape for our dynamic body.
            PolygonDef shapeDef = new PolygonDef();
            shapeDef.SetAsBox(1.0f, 1.0f);

            // Set the box density to be non-zero, so it will be dynamic.
            shapeDef.Density = 1.0f;

            // Override the default friction.
            shapeDef.Friction = 0.3f;

            // Add the shape to the body.
            body.CreateFixture(shapeDef);

            // Now tell the dynamic body to compute it's mass properties base
            // on its shape.
            body.SetMassFromShapes();
            
            world.AddBody(body);

            // Prepare for simulation. Typically we use a time step of 1/60 of a
            // second (60Hz) and 10 iterations. This provides a high quality simulation
            // in most game scenarios.
            const float timeStep = 1.0f / 60.0f;
            const int velocityIterations = 8;
            const int positionIterations = 1;

            // This is our little game loop.
            for (int i = 0; i < 100; ++i)
            {
                // Instruct the world to perform a single step of simulation. It is
                // generally best to keep the time step and iterations fixed.
                world.Step(timeStep, velocityIterations, positionIterations);

                // Now print the position and angle of the body.
                Vector2 position = body.GetPosition();
                float angle = body.GetAngle();

                Console.WriteLine(
                    "Step: {3} - X: {0}, Y: {1}, Angle: {2}", position.X.ToString(), position.Y.ToString(),
                    angle.ToString(), i.ToString());
            }

            // When the world destructor is called, all bodies and joints are freed. This can
            // create orphaned pointers, so be careful about your world management.

            //Console.ReadLine();
        }
    }
}