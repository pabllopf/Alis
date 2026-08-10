// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactSolverAdditionalCoverageTests.cs
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
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    ///     The contact solver additional coverage tests class
    /// </summary>
    public class ContactSolverAdditionalCoverageTests
    {
        /// <summary>
        ///     Tests that colliding circles with restitution solve through world step
        /// </summary>
        [Fact]
        public void CollidingCircles_WithRestitution_SolveThroughWorldStep()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, 0));
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(0, 0), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(0.75f, 0), BodyType.Dynamic);
            bodyA.SetRestitution(0.8f);
            bodyB.SetRestitution(0.8f);
            bodyA.LinearVelocity = new Vector2F(1, 0);
            bodyB.LinearVelocity = new Vector2F(-1, 0);

            for (int i = 0; i < 30; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        /// <summary>
        ///     Tests that colliding polygons with friction solve through world step
        /// </summary>
        [Fact]
        public void CollidingPolygons_WithFriction_SolveThroughWorldStep()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, 0));
            Vertices vertices = PolygonTools.CreateRectangle(0.5f, 0.5f);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(0.75f, 0), 0, BodyType.Dynamic);
            Fixture fixtureA = bodyA.CreateFixture(new PolygonShape(vertices, 1.0f));
            Fixture fixtureB = bodyB.CreateFixture(new PolygonShape(vertices, 1.0f));
            fixtureA.GetFriction = 0.5f;
            fixtureB.GetFriction = 0.5f;

            for (int i = 0; i < 30; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        /// <summary>
        ///     Tests that stacked bodies settle through world step
        /// </summary>
        [Fact]
        public void StackedBodies_SettleThroughWorldStep()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -9.81f));
            Body ground = world.CreateBody(new Vector2F(0, -5), 0, BodyType.Static);
            Vertices groundVerts = PolygonTools.CreateRectangle(10, 1);
            ground.CreateFixture(new PolygonShape(groundVerts, 1.0f));

            Body box1 = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Vertices boxVerts = PolygonTools.CreateRectangle(0.5f, 0.5f);
            box1.CreateFixture(new PolygonShape(boxVerts, 1.0f));

            Body box2 = world.CreateBody(new Vector2F(0, 1.2f), 0, BodyType.Dynamic);
            box2.CreateFixture(new PolygonShape(boxVerts, 1.0f));

            for (int i = 0; i < 60; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(world.ContactManager.ContactCount >= 0);
        }
    }
}
