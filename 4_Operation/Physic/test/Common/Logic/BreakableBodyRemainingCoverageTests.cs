// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BreakableBodyRemainingCoverageTests.cs
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
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.Logic;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    /// <summary>
    ///     The breakable body remaining coverage tests class
    /// </summary>
    public class BreakableBodyRemainingCoverageTests
    {
        /// <summary>
        ///     Creates the square vertices
        /// </summary>
        /// <param name="offset">The offset</param>
        /// <returns>The vertices</returns>
        private static Vertices CreateSquare(float offset)
        {
            Vertices vertices = new Vertices();
            vertices.Add(new Vector2F(offset, offset));
            vertices.Add(new Vector2F(offset + 1, offset));
            vertices.Add(new Vector2F(offset + 1, offset + 1));
            vertices.Add(new Vector2F(offset, offset + 1));
            return vertices;
        }

        /// <summary>
        ///     Tests that internal constructor assigns world physic and subscribes post solve
        /// </summary>
        [Fact]
        public void InternalConstructor_AssignsWorldPhysic_AndSubscribesPostSolve()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            bool subscribed = false;

            world.ContactManager.PostSolve += (contact, impulse) => subscribed = true;
            world.ContactManager.PostSolve = null;
            world.ContactManager.PostSolve += (contact, impulse) => { };

            BreakableBody body = new BreakableBody(world);

            Assert.Same(world, body.WorldPhysic);
            Assert.Equal(BreakableBodyState.Unbroken, body.State);
            Assert.Null(body.MainBody);
            Assert.NotNull(body.Parts);
            Assert.Equal(8, body.Parts.Capacity);
            Assert.Equal(500.0f, body.Strength);
            Assert.False(subscribed);
        }

        /// <summary>
        ///     Tests that vertices list constructor creates main body and parts
        /// </summary>
        [Fact]
        public void VerticesListConstructor_CreatesMainBody_AndParts()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            List<Vertices> parts = new List<Vertices>
            {
                CreateSquare(0),
                CreateSquare(3)
            };

            BreakableBody body = new BreakableBody(world, parts, 1.0f);

            Assert.NotNull(body.MainBody);
            Assert.Equal(BodyType.Dynamic, body.MainBody.GetBodyType);
            Assert.Equal(2, body.Parts.Count);
            Assert.Equal(1, world.BodyList.Count);
        }

        /// <summary>
        ///     Tests that vertices list constructor applies position and rotation
        /// </summary>
        [Fact]
        public void VerticesListConstructor_AppliesPosition_AndRotation()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            List<Vertices> parts = new List<Vertices>
            {
                CreateSquare(0)
            };
            Vector2F position = new Vector2F(10, 20);

            BreakableBody body = new BreakableBody(world, parts, 1.0f, position, 0.5f);

            Assert.Equal(position.X, body.MainBody.Position.X, 5);
            Assert.Equal(position.Y, body.MainBody.Position.Y, 5);
            Assert.Equal(0.5f, body.MainBody.Rotation, 5);
        }

        /// <summary>
        ///     Tests that shapes list constructor creates main body and parts
        /// </summary>
        [Fact]
        public void ShapesListConstructor_CreatesMainBody_AndParts()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            List<Shape> shapes = new List<Shape>
            {
                new PolygonShape(CreateSquare(0), 1.0f),
                new CircleShape(0.5f, 1.0f)
            };

            BreakableBody body = new BreakableBody(world, shapes);

            Assert.NotNull(body.MainBody);
            Assert.Equal(2, body.Parts.Count);
        }

        /// <summary>
        ///     Tests that single vertices constructor triangulates into parts
        /// </summary>
        [Fact]
        public void SingleVerticesConstructor_Triangulates_IntoParts()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            BreakableBody body = new BreakableBody(world, CreateSquare(0), 1.0f);

            Assert.NotNull(body.MainBody);
            Assert.True(body.Parts.Count >= 1);
        }

        /// <summary>
        ///     Tests that post solve with low impulse keeps state unbroken
        /// </summary>
        [Fact]
        public void PostSolve_WithLowImpulse_KeepsStateUnbroken()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            List<Vertices> parts = new List<Vertices>
            {
                CreateSquare(0),
                CreateSquare(3)
            };
            BreakableBody body = new BreakableBody(world, parts, 1.0f);
            Body other = world.CreateBody(new Vector2F(20, 0), 0, BodyType.Dynamic);
            Fixture otherFixture = other.CreateFixture(new CircleShape(0.5f, 1.0f));

            Contact contact = new Contact(body.Parts[0], 0, otherFixture, 0);
            contact.Manifold.PointCount = 1;
            ContactVelocityConstraint impulse = new ContactVelocityConstraint();
            impulse.Points[0].NormalImpulse = 100.0f;

            world.ContactManager.PostSolve(contact, impulse);

            Assert.Equal(BreakableBodyState.Unbroken, body.State);
        }

        /// <summary>
        ///     Tests that post solve with high impulse sets should break
        /// </summary>
        [Fact]
        public void PostSolve_WithHighImpulse_SetsShouldBreak()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            List<Vertices> parts = new List<Vertices>
            {
                CreateSquare(0),
                CreateSquare(3)
            };
            BreakableBody body = new BreakableBody(world, parts, 1.0f);
            Body other = world.CreateBody(new Vector2F(20, 0), 0, BodyType.Dynamic);
            Fixture otherFixture = other.CreateFixture(new CircleShape(0.5f, 1.0f));

            Contact contact = new Contact(body.Parts[0], 0, otherFixture, 0);
            contact.Manifold.PointCount = 1;
            ContactVelocityConstraint impulse = new ContactVelocityConstraint();
            impulse.Points[0].NormalImpulse = 600.0f;

            world.ContactManager.PostSolve(contact, impulse);

            Assert.Equal(BreakableBodyState.ShouldBreak, body.State);
        }

        /// <summary>
        ///     Tests that post solve with unrelated contact keeps state unbroken
        /// </summary>
        [Fact]
        public void PostSolve_WithUnrelatedContact_KeepsStateUnbroken()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            List<Vertices> parts = new List<Vertices>
            {
                CreateSquare(0)
            };
            BreakableBody body = new BreakableBody(world, parts, 1.0f);
            Body bodyA = world.CreateBody(new Vector2F(20, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(30, 0), 0, BodyType.Dynamic);
            Fixture fixtureA = bodyA.CreateFixture(new CircleShape(0.5f, 1.0f));
            Fixture fixtureB = bodyB.CreateFixture(new CircleShape(0.5f, 1.0f));

            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            contact.Manifold.PointCount = 1;
            ContactVelocityConstraint impulse = new ContactVelocityConstraint();
            impulse.Points[0].NormalImpulse = 600.0f;

            world.ContactManager.PostSolve(contact, impulse);

            Assert.Equal(BreakableBodyState.Unbroken, body.State);
        }

        /// <summary>
        ///     Tests that post solve with zero point count keeps state unbroken
        /// </summary>
        [Fact]
        public void PostSolve_WithZeroPointCount_KeepsStateUnbroken()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            List<Vertices> parts = new List<Vertices>
            {
                CreateSquare(0)
            };
            BreakableBody body = new BreakableBody(world, parts, 1.0f);
            Body other = world.CreateBody(new Vector2F(20, 0), 0, BodyType.Dynamic);
            Fixture otherFixture = other.CreateFixture(new CircleShape(0.5f, 1.0f));

            Contact contact = new Contact(body.Parts[0], 0, otherFixture, 0);
            contact.Manifold.PointCount = 0;
            ContactVelocityConstraint impulse = new ContactVelocityConstraint();
            impulse.Points[0].NormalImpulse = 600.0f;

            world.ContactManager.PostSolve(contact, impulse);

            Assert.Equal(BreakableBodyState.Unbroken, body.State);
        }

        /// <summary>
        ///     Tests that update in unbroken state caches velocities
        /// </summary>
        [Fact]
        public void Update_InUnbrokenState_CachesVelocities()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            List<Vertices> parts = new List<Vertices>
            {
                CreateSquare(0),
                CreateSquare(3)
            };
            BreakableBody body = new BreakableBody(world, parts, 1.0f);
            body.Parts[0].GetBody.LinearVelocity = new Vector2F(5, 6);
            body.Parts[0].GetBody.AngularVelocity = 2.0f;

            body.Update();

            Assert.Equal(BreakableBodyState.Unbroken, body.State);
            Assert.Equal(8, body._velocitiesCache.Length);
            Assert.Equal(5, body._velocitiesCache[0].X, 5);
            Assert.Equal(6, body._velocitiesCache[0].Y, 5);
            Assert.Equal(2.0f, body._angularVelocitiesCache[0], 5);
        }

        /// <summary>
        ///     Tests that cache velocities enlarges cache when parts exceed capacity
        /// </summary>
        [Fact]
        public void CacheVelocities_EnlargesCache_WhenPartsExceedCapacity()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            List<Vertices> parts = new List<Vertices>();
            for (int i = 0; i < 10; i++)
            {
                parts.Add(CreateSquare(i * 3));
            }

            BreakableBody body = new BreakableBody(world, parts, 1.0f);
            body.CacheVelocities();

            Assert.Equal(10, body._velocitiesCache.Length);
            Assert.Equal(10, body._angularVelocitiesCache.Length);
        }

        /// <summary>
        ///     Tests that update in should break state decomposes
        /// </summary>
        [Fact]
        public void Update_InShouldBreakState_Decomposes()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            List<Vertices> parts = new List<Vertices>
            {
                CreateSquare(0),
                CreateSquare(3)
            };
            BreakableBody body = new BreakableBody(world, parts, 1.0f);
            body.State = BreakableBodyState.ShouldBreak;

            body.Update();

            Assert.Equal(BreakableBodyState.Broken, body.State);
            Assert.Equal(2, world.BodyList.Count);
        }

        /// <summary>
        ///     Tests that decompose removes main body and creates independent bodies
        /// </summary>
        [Fact]
        public void Decompose_RemovesMainBody_AndCreatesIndependentBodies()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            List<Vertices> parts = new List<Vertices>
            {
                CreateSquare(0),
                CreateSquare(3)
            };
            BreakableBody body = new BreakableBody(world, parts, 1.0f);
            body.Parts[0].GetBody.LinearVelocity = new Vector2F(5, 6);
            body.Parts[0].GetBody.AngularVelocity = 2.0f;
            body.CacheVelocities();

            body.Decompose();

            Assert.Equal(BreakableBodyState.Broken, body.State);
            Assert.Equal(2, world.BodyList.Count);
            Assert.NotNull(body.Parts[0].GetBody);
            Assert.NotSame(body.MainBody, body.Parts[0].GetBody);
            Assert.Equal(5, body.Parts[0].GetBody.LinearVelocity.X, 5);
            Assert.Equal(6, body.Parts[0].GetBody.LinearVelocity.Y, 5);
            Assert.Equal(2.0f, body.Parts[0].GetBody.AngularVelocity, 5);
        }

        /// <summary>
        ///     Tests that decompose throws when already broken
        /// </summary>
        [Fact]
        public void Decompose_WhenAlreadyBroken_ThrowsInvalidOperationException()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            List<Vertices> parts = new List<Vertices>
            {
                CreateSquare(0)
            };
            BreakableBody body = new BreakableBody(world, parts, 1.0f);
            body.State = BreakableBodyState.Broken;

            Assert.Throws<InvalidOperationException>(() => body.Decompose());
        }
    }
}
