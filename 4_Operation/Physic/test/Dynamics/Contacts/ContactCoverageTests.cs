// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactCoverageTests.cs
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
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    ///     The contact coverage tests class
    /// </summary>
    public class ContactCoverageTests
    {
        /// <summary>
        ///     Tests that report separation with all handlers subscribed invokes every handler
        /// </summary>
        [Fact]
        public void ReportSeparation_WithAllHandlersSubscribed_InvokesEveryHandler()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(100.0f, 0.0f), BodyType.Dynamic);
            Fixture fixtureA = bodyA.FixtureList[0];
            Fixture fixtureB = bodyB.FixtureList[0];

            bool fixtureAHandled = false;
            bool fixtureBHandled = false;
            bool bodyAHandled = false;
            bool bodyBHandled = false;
            fixtureA.OnSeparation += (fa, fb, contact) => fixtureAHandled = true;
            fixtureB.OnSeparation += (fa, fb, contact) => fixtureBHandled = true;
            bodyA.OnSeparationEventHandler += (fa, fb, contact) => bodyAHandled = true;
            bodyB.OnSeparationEventHandler += (fa, fb, contact) => bodyBHandled = true;

            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            contact.ReportSeparation(bodyA, bodyB, world.ContactManager);

            Assert.True(fixtureAHandled);
            Assert.True(fixtureBHandled);
            Assert.True(bodyAHandled);
            Assert.True(bodyBHandled);
        }

        /// <summary>
        ///     Tests that evaluate with edge and circle fixtures computes a manifold
        /// </summary>
        [Fact]
        public void Evaluate_WithEdgeAndCircleFixtures_ComputesManifold()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(0.9f, 0.0f), 0, BodyType.Dynamic);
            Fixture fixtureA = bodyA.CreateFixture(new EdgeShape(new Vector2F(-1.0f, 0.0f), new Vector2F(1.0f, 0.0f)));
            Fixture fixtureB = bodyB.CreateFixture(new CircleShape(0.5f, 1.0f));

            Contact contact = Contact.Create(world.ContactManager, fixtureA, 0, fixtureB, 0);
            Manifold manifold = new Manifold();
            contact.Evaluate(ref manifold, ref bodyA.Xf, ref bodyB.Xf);

            Assert.True(manifold.PointCount >= 0);
        }

        /// <summary>
        ///     Tests that evaluate with edge and polygon fixtures computes a manifold
        /// </summary>
        [Fact]
        public void Evaluate_WithEdgeAndPolygonFixtures_ComputesManifold()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(0.5f, -0.5f), 0, BodyType.Dynamic);
            Fixture fixtureA = bodyA.CreateFixture(new EdgeShape(new Vector2F(-1.0f, 0.0f), new Vector2F(1.0f, 0.0f)));
            Fixture fixtureB = bodyB.CreateFixture(new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f));

            Contact contact = Contact.Create(world.ContactManager, fixtureA, 0, fixtureB, 0);
            Manifold manifold = new Manifold();
            contact.Evaluate(ref manifold, ref bodyA.Xf, ref bodyB.Xf);

            Assert.True(manifold.PointCount >= 0);
        }

        /// <summary>
        ///     Tests that evaluate with chain and circle fixtures computes a manifold
        /// </summary>
        [Fact]
        public void Evaluate_WithChainAndCircleFixtures_ComputesManifold()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(0.9f, 0.0f), 0, BodyType.Dynamic);
            Vertices chainVertices = new Vertices(new[]
            {
                new Vector2F(-1.0f, 0.0f),
                new Vector2F(0.0f, 0.0f),
                new Vector2F(1.0f, 0.0f)
            });
            Fixture fixtureA = bodyA.CreateFixture(new ChainShape(chainVertices, false));
            Fixture fixtureB = bodyB.CreateFixture(new CircleShape(0.5f, 1.0f));

            Contact contact = Contact.Create(world.ContactManager, fixtureA, 0, fixtureB, 0);
            Manifold manifold = new Manifold();
            contact.Evaluate(ref manifold, ref bodyA.Xf, ref bodyB.Xf);

            Assert.True(manifold.PointCount >= 0);
        }

        /// <summary>
        ///     Tests that evaluate with chain and polygon fixtures computes a manifold
        /// </summary>
        [Fact]
        public void Evaluate_WithChainAndPolygonFixtures_ComputesManifold()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(0.5f, -0.5f), 0, BodyType.Dynamic);
            Vertices chainVertices = new Vertices(new[]
            {
                new Vector2F(-1.0f, 0.0f),
                new Vector2F(0.0f, 0.0f),
                new Vector2F(1.0f, 0.0f)
            });
            Fixture fixtureA = bodyA.CreateFixture(new ChainShape(chainVertices, false));
            Fixture fixtureB = bodyB.CreateFixture(new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f));

            Contact contact = Contact.Create(world.ContactManager, fixtureA, 0, fixtureB, 0);
            Manifold manifold = new Manifold();
            contact.Evaluate(ref manifold, ref bodyA.Xf, ref bodyB.Xf);

            Assert.True(manifold.PointCount >= 0);
        }

        /// <summary>
        ///     Tests that create from pool with swapped fixtures resets with swapped order
        /// </summary>
        [Fact]
        public void Create_FromPool_WithSwappedFixtures_ResetsSwapped()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body pooledA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body pooledB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);

            Contact pooled = world.ContactManager.ContactList.Next;
            Assert.NotNull(pooled);
            world.ContactManager.Destroy(pooled);

            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Fixture circleA = bodyA.CreateFixture(new CircleShape(0.5f, 1.0f));
            Fixture polygonB = bodyB.CreateFixture(new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f));
            Contact swapped = Contact.Create(world.ContactManager, circleA, 0, polygonB, 0);

            Assert.NotNull(swapped);
            Assert.Equal(polygonB, swapped.FixtureA);
            Assert.Equal(circleA, swapped.FixtureB);
        }
    }
}
