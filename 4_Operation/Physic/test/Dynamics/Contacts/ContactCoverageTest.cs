// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactCoverageTest.cs
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
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    ///     The contact coverage test class
    /// </summary>
    public class ContactCoverageTest
    {
        /// <summary>
        ///     Tests that two overlapping rectangles collide and use the Polygon contact type.
        ///     This exercises the ContactType.Polygon branch in Contact.Evaluate.
        /// </summary>
        [Fact]
        public void RectangleAndRectangle_Overlap_CreatesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.5f, 0.0f), 0.0f, BodyType.Dynamic);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        ///     Tests that an edge and a circle overlapping create a contact.
        ///     This exercises the ContactType.EdgeAndCircle branch in Contact.Evaluate.
        /// </summary>
        [Fact]
        public void EdgeAndCircle_Overlap_CreatesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateEdge(new Vector2F(-5.0f, 0.0f), new Vector2F(5.0f, 0.0f));
            world.CreateCircle(3.0f, 1.0f, new Vector2F(0.0f, -2.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        ///     Tests that an edge and a rectangle overlapping create a contact.
        ///     This exercises the ContactType.EdgeAndPolygon branch in Contact.Evaluate.
        /// </summary>
        [Fact]
        public void EdgeAndPolygon_Overlap_CreatesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateEdge(new Vector2F(-5.0f, 0.0f), new Vector2F(5.0f, 0.0f));
            world.CreateRectangle(4.0f, 4.0f, 1.0f, new Vector2F(0.0f, -1.5f), 0.0f, BodyType.Dynamic);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        ///     Tests that a chain shape and a circle overlapping create a contact.
        ///     This exercises the ContactType.ChainAndCircle branch in Contact.Evaluate.
        /// </summary>
        [Fact]
        public void ChainAndCircle_Overlap_CreatesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Vertices vertices = new Vertices
            {
                new Vector2F(-5.0f, 0.0f),
                new Vector2F(0.0f, 5.0f),
                new Vector2F(5.0f, 0.0f)
            };
            world.CreateChainShape(vertices, new Vector2F(0.0f, 0.0f));
            world.CreateCircle(3.0f, 1.0f, new Vector2F(0.0f, -2.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        ///     Tests that a chain shape and a rectangle overlapping create a contact.
        ///     This exercises the ContactType.ChainAndPolygon branch in Contact.Evaluate.
        /// </summary>
        [Fact]
        public void ChainAndPolygon_Overlap_CreatesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Vertices vertices = new Vertices
            {
                new Vector2F(-5.0f, 0.0f),
                new Vector2F(0.0f, 5.0f),
                new Vector2F(5.0f, 0.0f)
            };
            world.CreateChainShape(vertices, new Vector2F(0.0f, 0.0f));
            world.CreateRectangle(4.0f, 4.0f, 1.0f, new Vector2F(0.0f, -1.5f), 0.0f, BodyType.Dynamic);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        ///     Tests that a sensor fixture does not generate a manifold but still detects overlap.
        ///     This exercises the ProcessSensorContact branch in Contact.Update.
        /// </summary>
        [Fact]
        public void SensorFixture_DetectsOverlap_NoManifold()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bool sensorFired = false;
            world.ContactManager.BeginContact = contact =>
            {
                sensorFired = contact.FixtureA.GetIsSensor || contact.FixtureB.GetIsSensor;
                return true;
            };

            bodyA.FixtureList[0].GetIsSensor = true;

            world.Step(1.0f / 60.0f);

            Assert.True(sensorFired);
            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        ///     Tests that Fixture.OnCollision fires when contact is created.
        ///     This exercises InvokeHandlers in ReportCollision.
        /// </summary>
        [Fact]
        public void FixtureOnCollision_Fires_WhenContactCreated()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bool collisionFired = false;
            bodyA.FixtureList[0].OnCollision = (_, _, _) =>
            {
                collisionFired = true;
                return true;
            };

            world.Step(1.0f / 60.0f);

            Assert.True(collisionFired);
            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        ///     Tests that Fixture.OnCollision returning false disables the contact.
        ///     This exercises the enabled=false path in ReportCollision.
        /// </summary>
        [Fact]
        public void FixtureOnCollision_ReturnsFalse_DisabledContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bool collisionFired = false;
            bodyA.FixtureList[0].OnCollision = (_, _, _) =>
            {
                collisionFired = true;
                return false;
            };

            world.Step(1.0f / 60.0f);

            Assert.True(collisionFired);
        }

        /// <summary>
        ///     Tests that Body.OnCollision fires when contact is created.
        ///     This exercises the body callback path in ReportCollision.
        /// </summary>
        [Fact]
        public void BodyOnCollision_Fires_WhenContactCreated()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bool collisionFired = false;
            bodyA.OnCollision += (_, _, _) =>
            {
                collisionFired = true;
                return true;
            };

            world.Step(1.0f / 60.0f);

            Assert.True(collisionFired);
        }

        /// <summary>
        ///     Tests that BeginContact delegate fires when contact is created.
        ///     This exercises the BeginContact path in ReportCollision.
        /// </summary>
        [Fact]
        public void BeginContact_Fires_WhenContactCreated()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bool beginContactFired = false;
            world.ContactManager.BeginContact = contact =>
            {
                beginContactFired = true;
                return true;
            };

            world.Step(1.0f / 60.0f);

            Assert.True(beginContactFired);
        }

        /// <summary>
        ///     Tests that EndContact delegate fires when bodies separate.
        ///     This exercises the EndContact path in ReportSeparation.
        /// </summary>
        [Fact]
        public void EndContact_Fires_WhenBodiesSeparate()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bool endContactFired = false;
            world.ContactManager.EndContact = contact =>
            {
                endContactFired = true;
            };

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            bodyA.SetTransform(new Vector2F(1000.0f, 1000.0f), 0.0f);
            bodyB.SetTransform(new Vector2F(2000.0f, 2000.0f), 0.0f);

            world.Step(1.0f / 60.0f);

            Assert.True(endContactFired);
        }

        /// <summary>
        ///     Tests that PreSolve delegate fires when contact persists.
        ///     This exercises the ProcessPreSolve path in Contact.Update.
        /// </summary>
        [Fact]
        public void PreSolve_Fires_WhenContactPersists()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bool preSolveFired = false;
            void OnPreSolve(Contact contact, ref Manifold oldManifold) => preSolveFired = true;
            world.ContactManager.PreSolve = OnPreSolve;

            world.Step(1.0f / 60.0f);

            Assert.True(preSolveFired);
        }

        /// <summary>
        ///     Tests that a persistent contact across multiple steps exercises warm starting.
        ///     This exercises the old manifold id matching loop in ProcessNonSensorContact.
        /// </summary>
        [Fact]
        public void PersistentContact_AcrossSteps_WarmsStarting()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            for (int i = 0; i < 5; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        ///     Tests that Body.OnSeparation fires when bodies separate.
        ///     This exercises the body OnSeparation path in ReportSeparation.
        /// </summary>
        [Fact]
        public void BodyOnSeparation_Fires_WhenBodiesSeparate()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bool sepFired = false;
            bodyA.OnSeparation += (_, _, _) => sepFired = true;

            world.Step(1.0f / 60.0f);

            bodyA.SetTransform(new Vector2F(1000.0f, 1000.0f), 0.0f);
            bodyB.SetTransform(new Vector2F(2000.0f, 2000.0f), 0.0f);

            world.Step(1.0f / 60.0f);

            Assert.True(sepFired);
        }

        /// <summary>
        ///     Tests that Fixture.OnSeparation fires when bodies separate.
        ///     This exercises the fixture OnSeparation path in ReportSeparation.
        /// </summary>
        [Fact]
        public void FixtureOnSeparation_Fires_WhenBodiesSeparate()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bool sepFired = false;
            world.ContactManager.BeginContact = contact =>
            {
                contact.FixtureA.OnSeparation = (_, _, _) => sepFired = true;
                return true;
            };

            world.Step(1.0f / 60.0f);

            bodyA.SetTransform(new Vector2F(1000.0f, 1000.0f), 0.0f);
            bodyB.SetTransform(new Vector2F(2000.0f, 2000.0f), 0.0f);

            world.Step(1.0f / 60.0f);

            Assert.True(sepFired);
        }
    }
}
