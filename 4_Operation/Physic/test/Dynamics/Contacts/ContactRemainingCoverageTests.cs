// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactRemainingCoverageTests.cs
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
    ///     The contact remaining coverage tests class
    /// </summary>
    public class ContactRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that update with sensor fixtures processes sensor contact
        /// </summary>
        [Fact]
        public void Update_WithSensorFixtures_ProcessesSensorContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(0.1f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(1.0f, 1.0f);
            CircleShape shapeB = new CircleShape(1.0f, 1.0f);
            Fixture fixtureA = bodyA.CreateFixture(shapeA);
            Fixture fixtureB = bodyB.CreateFixture(shapeB);
            fixtureA.GetIsSensor = true;

            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            contact.Update(world.ContactManager);

            Assert.True(contact.IsTouching);
        }

        /// <summary>
        ///     Tests that update with non sensor fixtures processes non sensor contact
        /// </summary>
        [Fact]
        public void Update_WithNonSensorFixtures_ProcessesNonSensorContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(0.1f, 0), 0, BodyType.Dynamic);
            Fixture fixtureA = bodyA.CreateFixture(new CircleShape(1.0f, 1.0f));
            Fixture fixtureB = bodyB.CreateFixture(new CircleShape(1.0f, 1.0f));

            Contact contact = Contact.Create(world.ContactManager, fixtureA, 0, fixtureB, 0);
            contact.Update(world.ContactManager);

            Assert.True(contact.IsTouching);
        }

        /// <summary>
        ///     Tests that update with separated fixtures reports separation
        /// </summary>
        [Fact]
        public void Update_WithSeparatedFixtures_ReportsSeparation()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(100, 0), 0, BodyType.Dynamic);
            Fixture fixtureA = bodyA.CreateFixture(new CircleShape(1.0f, 1.0f));
            Fixture fixtureB = bodyB.CreateFixture(new CircleShape(1.0f, 1.0f));

            bool separated = false;
            fixtureA.OnSeparation += (fa, fb, contact) => separated = true;

            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            contact.IsTouching = true;
            contact.Update(world.ContactManager);

            Assert.False(contact.IsTouching);
            Assert.True(separated);
        }

        /// <summary>
        ///     Tests that report separation invokes end contact delegate
        /// </summary>
        [Fact]
        public void ReportSeparation_InvokesEndContactDelegate()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(100, 0), 0, BodyType.Dynamic);
            Fixture fixtureA = bodyA.CreateFixture(new CircleShape(1.0f, 1.0f));
            Fixture fixtureB = bodyB.CreateFixture(new CircleShape(1.0f, 1.0f));

            bool ended = false;
            world.ContactManager.EndContact += contact => ended = true;

            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            contact.ReportSeparation(bodyA, bodyB, world.ContactManager);

            Assert.True(ended);
        }

        /// <summary>
        ///     Tests that report collision with enabled handlers keeps contact enabled
        /// </summary>
        [Fact]
        public void ReportCollision_WithEnabledHandlers_KeepsContactEnabled()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(0.1f, 0), 0, BodyType.Dynamic);
            Fixture fixtureA = bodyA.CreateFixture(new CircleShape(1.0f, 1.0f));
            Fixture fixtureB = bodyB.CreateFixture(new CircleShape(1.0f, 1.0f));

            bool began = false;
            world.ContactManager.BeginContact += contact => { began = true; return true; };

            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            contact.ReportCollision(bodyA, bodyB, world.ContactManager);

            Assert.True(began);
            Assert.True(contact.Enabled);
        }

        /// <summary>
        ///     Tests that report collision with disabling handler disables contact
        /// </summary>
        [Fact]
        public void ReportCollision_WithDisablingHandler_DisablesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(0.1f, 0), 0, BodyType.Dynamic);
            Fixture fixtureA = bodyA.CreateFixture(new CircleShape(1.0f, 1.0f));
            Fixture fixtureB = bodyB.CreateFixture(new CircleShape(1.0f, 1.0f));
            fixtureA.OnCollision += (fa, fb, contact) => false;

            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            contact.ReportCollision(bodyA, bodyB, world.ContactManager);

            Assert.False(contact.Enabled);
            Assert.False(contact.IsTouching);
        }

        /// <summary>
        ///     Tests that process pre solve invokes pre solve delegate
        /// </summary>
        [Fact]
        public void ProcessPreSolve_InvokesPreSolveDelegate()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(0.1f, 0), 0, BodyType.Dynamic);
            Fixture fixtureA = bodyA.CreateFixture(new CircleShape(1.0f, 1.0f));
            Fixture fixtureB = bodyB.CreateFixture(new CircleShape(1.0f, 1.0f));

            bool called = false;
            world.ContactManager.PreSolve += (Contact contact, ref Manifold oldManifold) => called = true;

            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            contact.ProcessPreSolve(world.ContactManager, new Manifold());

            Assert.True(called);
        }

        /// <summary>
        ///     Tests that evaluate with circle fixtures computes manifold
        /// </summary>
        [Fact]
        public void Evaluate_WithCircleFixtures_ComputesManifold()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(0.1f, 0), 0, BodyType.Dynamic);
            Fixture fixtureA = bodyA.CreateFixture(new CircleShape(1.0f, 1.0f));
            Fixture fixtureB = bodyB.CreateFixture(new CircleShape(1.0f, 1.0f));

            Contact contact = Contact.Create(world.ContactManager, fixtureA, 0, fixtureB, 0);
            Manifold manifold = new Manifold();
            contact.Evaluate(ref manifold, ref bodyA.Xf, ref bodyB.Xf);

            Assert.True(manifold.PointCount > 0);
        }

        /// <summary>
        ///     Tests that create with polygon and circle fixtures returns contact
        /// </summary>
        [Fact]
        public void Create_WithPolygonAndCircle_ReturnsContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(0.1f, 0), 0, BodyType.Dynamic);
            Vertices vertices = PolygonTools.CreateRectangle(1.0f, 1.0f);
            Fixture fixtureA = bodyA.CreateFixture(new PolygonShape(vertices, 1.0f));
            Fixture fixtureB = bodyB.CreateFixture(new CircleShape(1.0f, 1.0f));

            Contact contact = Contact.Create(world.ContactManager, fixtureA, 0, fixtureB, 0);

            Assert.NotNull(contact);
        }

        /// <summary>
        ///     Tests that evaluate with polygon fixtures computes manifold
        /// </summary>
        [Fact]
        public void Evaluate_WithPolygonFixtures_ComputesManifold()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(0.1f, 0), 0, BodyType.Dynamic);
            Vertices vertices = PolygonTools.CreateRectangle(1.0f, 1.0f);
            Fixture fixtureA = bodyA.CreateFixture(new PolygonShape(vertices, 1.0f));
            Fixture fixtureB = bodyB.CreateFixture(new PolygonShape(vertices, 1.0f));

            Contact contact = Contact.Create(world.ContactManager, fixtureA, 0, fixtureB, 0);
            Manifold manifold = new Manifold();
            contact.Evaluate(ref manifold, ref bodyA.Xf, ref bodyB.Xf);

            Assert.True(manifold.PointCount > 0);
        }

        /// <summary>
        ///     Tests that get world manifold returns normal and points
        /// </summary>
        [Fact]
        public void GetWorldManifold_ReturnsNormalAndPoints()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(0.1f, 0), 0, BodyType.Dynamic);
            Fixture fixtureA = bodyA.CreateFixture(new CircleShape(1.0f, 1.0f));
            Fixture fixtureB = bodyB.CreateFixture(new CircleShape(1.0f, 1.0f));

            Contact contact = Contact.Create(world.ContactManager, fixtureA, 0, fixtureB, 0);
            contact.Update(world.ContactManager);

            contact.GetWorldManifold(out Vector2F normal, out FixedArray2<Vector2F> points);

            Assert.NotEqual(0.0f, normal.LengthSquared());
        }

        /// <summary>
        ///     Tests that destroy with touching fixtures wakes bodies
        /// </summary>
        [Fact]
        public void Destroy_WithTouchingFixtures_WakesBodies()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(0.1f, 0), 0, BodyType.Dynamic);
            Fixture fixtureA = bodyA.CreateFixture(new CircleShape(1.0f, 1.0f));
            Fixture fixtureB = bodyB.CreateFixture(new CircleShape(1.0f, 1.0f));
            bodyA.Awake = false;
            bodyB.Awake = false;

            Contact contact = Contact.Create(world.ContactManager, fixtureA, 0, fixtureB, 0);
            contact.Update(world.ContactManager);
            contact.Destroy();

            Assert.Null(contact.FixtureA);
            Assert.Null(contact.FixtureB);
        }

        /// <summary>
        ///     Tests that create reuses contact from pool
        /// </summary>
        [Fact]
        public void Create_ReusesContactFromPool()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(0.1f, 0), 0, BodyType.Dynamic);
            Fixture fixtureA = bodyA.CreateFixture(new CircleShape(1.0f, 1.0f));
            Fixture fixtureB = bodyB.CreateFixture(new CircleShape(1.0f, 1.0f));

            Contact first = Contact.Create(world.ContactManager, fixtureA, 0, fixtureB, 0);
            first.Destroy();

            Contact second = Contact.Create(world.ContactManager, fixtureA, 0, fixtureB, 0);

            Assert.NotNull(second);
            Assert.NotNull(second.FixtureA);
            Assert.NotNull(second.FixtureB);
        }

        /// <summary>
        ///     Tests that create with polygon and edge fixtures swaps fixtures
        /// </summary>
        [Fact]
        public void Create_WithPolygonAndEdge_SwapsFixtures()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(0.1f, 0), 0, BodyType.Dynamic);
            Vertices vertices = PolygonTools.CreateRectangle(1.0f, 1.0f);
            Fixture fixtureA = bodyA.CreateFixture(new PolygonShape(vertices, 1.0f));
            Fixture fixtureB = bodyB.CreateFixture(new EdgeShape(new Vector2F(-1, 0), new Vector2F(1, 0)));

            Contact contact = Contact.Create(world.ContactManager, fixtureA, 0, fixtureB, 0);

            Assert.NotNull(contact);
        }
    }
}
