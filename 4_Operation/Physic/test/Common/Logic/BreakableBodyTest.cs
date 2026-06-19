// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BreakableBodyTest.cs
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
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.Logic;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics.Contacts;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    /// <summary>
    /// The breakable body test class
    /// </summary>
    public class BreakableBodyTest
    {
        /// <summary>
        /// Tests that breakable body type should be accessible
        /// </summary>
        [Fact]
        public void BreakableBody_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(BreakableBody));
        }

        /// <summary>
        /// Tests that parts list should be initialized with capacity 8
        /// </summary>
        [Fact]
        public void BreakableBody_PartsShouldBeInitializedWithDefaultCapacity()
        {
            Mock<WorldPhysic> mockWorld = new Mock<WorldPhysic>();

            BreakableBody breakableBody = CreateBreakableBody(mockWorld.Object);

            Assert.Equal(8, breakableBody.Parts.Capacity);
            Assert.Empty(breakableBody.Parts);
        }

        /// <summary>
        /// Tests that strength should have default value of 500.0f
        /// </summary>
        [Fact]
        public void BreakableBody_StrengthShouldHaveDefault500()
        {
            Mock<WorldPhysic> mockWorld = new Mock<WorldPhysic>();

            BreakableBody breakableBody = CreateBreakableBody(mockWorld.Object);

            Assert.Equal(500.0f, breakableBody.Strength);
        }

        /// <summary>
        /// Tests that world property should return the provided world
        /// </summary>
        [Fact]
        public void BreakableBody_WorldPropertyShouldReturnProvidedWorld()
        {
            WorldPhysic world = new Mock<WorldPhysic>().Object;

            BreakableBody breakableBody = CreateBreakableBody(world);

            Assert.Same(world, breakableBody.WorldPhysic);
        }

        /// <summary>
        /// Tests that main body property should be set from constructor
        /// </summary>
        [Fact]
        public void BreakableBody_MainBodyPropertyShouldBeSetFromConstructor()
        {
            Mock<WorldPhysic> mockWorld = new Mock<WorldPhysic>();
            Mock<Body> mockBody = new Mock<Body>();

            mockWorld.Setup(w => w.CreateBody(It.IsAny<Vector2F>(), It.IsAny<float>(), It.IsAny<BodyType>()))
                .Returns(mockBody.Object);

            List<Alis.Core.Physic.Common.Vertices> vertices = new List<Alis.Core.Physic.Common.Vertices>
            {
                new Alis.Core.Physic.Common.Vertices(new[]
                {
                    new Vector2F(0f, 0f),
                    new Vector2F(1f, 0f),
                    new Vector2F(1f, 1f),
                    new Vector2F(0f, 1f)
                })
            };

            BreakableBody breakableBody = new BreakableBody(mockWorld.Object, vertices, 1.0f);

            Assert.NotNull(breakableBody.MainBody);
        }

        /// <summary>
        /// Tests that state should default to Unbroken
        /// </summary>
        [Fact]
        public void BreakableBody_StateShouldDefaultToUnbroken()
        {
            Mock<WorldPhysic> mockWorld = new Mock<WorldPhysic>();

            BreakableBody breakableBody = CreateBreakableBody(mockWorld.Object);

            Assert.Equal(BreakableBodyState.Unbroken, breakableBody.State);
        }

        /// <summary>
        /// Tests that state property can be set to ShouldBreak
        /// </summary>
        [Fact]
        public void BreakableBody_StateShouldBeSettableToShouldBreak()
        {
            Mock<WorldPhysic> mockWorld = new Mock<WorldPhysic>();

            BreakableBody breakableBody = CreateBreakableBody(mockWorld.Object);

            breakableBody.State = BreakableBodyState.ShouldBreak;

            Assert.Equal(BreakableBodyState.ShouldBreak, breakableBody.State);
        }

        /// <summary>
        /// Tests that state property can be set to Broken
        /// </summary>
        [Fact]
        public void BreakableBody_StateShouldBeSettableToBroken()
        {
            Mock<WorldPhysic> mockWorld = new Mock<WorldPhysic>();

            BreakableBody breakableBody = CreateBreakableBody(mockWorld.Object);

            breakableBody.State = BreakableBodyState.Broken;

            Assert.Equal(BreakableBodyState.Broken, breakableBody.State);
        }

        /// <summary>
        /// Tests that Update in Unbroken state executes CacheVelocities without error
        /// </summary>
        [Fact]
        public void BreakableBody_Update_WhenUnbroken_ShouldExecuteCacheVelocities()
        {
            Mock<WorldPhysic> mockWorld = new Mock<WorldPhysic>();

            BreakableBody breakableBody = CreateBreakableBody(mockWorld.Object);

            breakableBody.Update();
        }

        /// <summary>
        /// Tests that BreakableBody can be created with a single Vertices
        /// </summary>
        [Fact]
        public void BreakableBody_ShouldCreateFromSingleVertices()
        {
            Mock<WorldPhysic> mockWorld = new Mock<WorldPhysic>();
            Mock<Body> mockBody = new Mock<Body>();

            mockWorld.Setup(w => w.CreateBody(It.IsAny<Vector2F>(), It.IsAny<float>(), It.IsAny<BodyType>()))
                .Returns(mockBody.Object);

            Alis.Core.Physic.Common.Vertices vertices = new Alis.Core.Physic.Common.Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(1f, 1f)
            });

            BreakableBody breakableBody = new BreakableBody(mockWorld.Object, vertices, 1.0f);

            Assert.NotNull(breakableBody.MainBody);
            Assert.Equal(1, breakableBody.Parts.Count);
        }

        /// <summary>
        /// Creates the breakable body using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <returns>The breakable body</returns>
        private static BreakableBody CreateBreakableBody(WorldPhysic world)
        {
            ConstructorInfo ctor = typeof(BreakableBody).GetConstructor(
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
                null,
                new[] { typeof(WorldPhysic) },
                null);

            return (BreakableBody)ctor.Invoke(new[] { world });
        }

        /// <summary>
        /// Tests that post solve with high impulse sets state to should break
        /// </summary>
        [Fact]
        public void PostSolve_WhenHighImpulseExceedsStrength_SetsStateToShouldBreak()
        {
            Mock<WorldPhysic> mockWorld = new Mock<WorldPhysic>();
            BreakableBody breakableBody = CreateBreakableBody(mockWorld.Object);

            Fixture fixture = new Fixture(new CircleShape(0.5f, 1.0f));
            breakableBody.Parts.Add(fixture);

            Fixture otherFixture = new Fixture(new CircleShape(0.5f, 1.0f));
            Contact contact = new Contact(fixture, 0, otherFixture, 0);
            contact.Manifold.PointCount = 1;

            ContactVelocityConstraint constraint = new ContactVelocityConstraint();
            constraint.PointCount = 1;
            constraint.Points[0].NormalImpulse = 600.0f;

            breakableBody.PostSolve(contact, constraint);

            Assert.Equal(BreakableBodyState.ShouldBreak, breakableBody.State);
        }

        /// <summary>
        /// Tests that post solve with low impulse does not change state
        /// </summary>
        [Fact]
        public void PostSolve_WhenLowImpulseBelowStrength_DoesNotChangeState()
        {
            Mock<WorldPhysic> mockWorld = new Mock<WorldPhysic>();
            BreakableBody breakableBody = CreateBreakableBody(mockWorld.Object);

            Fixture fixture = new Fixture(new CircleShape(0.5f, 1.0f));
            breakableBody.Parts.Add(fixture);

            Fixture otherFixture = new Fixture(new CircleShape(0.5f, 1.0f));
            Contact contact = new Contact(fixture, 0, otherFixture, 0);
            contact.Manifold.PointCount = 1;

            ContactVelocityConstraint constraint = new ContactVelocityConstraint();
            constraint.PointCount = 1;
            constraint.Points[0].NormalImpulse = 100.0f;

            breakableBody.PostSolve(contact, constraint);

            Assert.Equal(BreakableBodyState.Unbroken, breakableBody.State);
        }

        /// <summary>
        /// Tests that post solve when already broken does not change state
        /// </summary>
        [Fact]
        public void PostSolve_WhenStateIsBroken_DoesNotChangeState()
        {
            Mock<WorldPhysic> mockWorld = new Mock<WorldPhysic>();
            BreakableBody breakableBody = CreateBreakableBody(mockWorld.Object);
            breakableBody.State = BreakableBodyState.Broken;

            Fixture fixture = new Fixture(new CircleShape(0.5f, 1.0f));
            Fixture otherFixture = new Fixture(new CircleShape(0.5f, 1.0f));
            Contact contact = new Contact(fixture, 0, otherFixture, 0);
            contact.Manifold.PointCount = 1;

            ContactVelocityConstraint constraint = new ContactVelocityConstraint();
            constraint.PointCount = 1;
            constraint.Points[0].NormalImpulse = 600.0f;

            breakableBody.PostSolve(contact, constraint);

            Assert.Equal(BreakableBodyState.Broken, breakableBody.State);
        }

        /// <summary>
        /// Tests that post solve with non matching fixture does not change state
        /// </summary>
        [Fact]
        public void PostSolve_WhenFixtureNotInParts_DoesNotChangeState()
        {
            Mock<WorldPhysic> mockWorld = new Mock<WorldPhysic>();
            BreakableBody breakableBody = CreateBreakableBody(mockWorld.Object);

            Fixture unrelatedFixture = new Fixture(new CircleShape(0.5f, 1.0f));
            Fixture otherFixture = new Fixture(new CircleShape(0.5f, 1.0f));
            Contact contact = new Contact(unrelatedFixture, 0, otherFixture, 0);
            contact.Manifold.PointCount = 1;

            ContactVelocityConstraint constraint = new ContactVelocityConstraint();
            constraint.PointCount = 1;
            constraint.Points[0].NormalImpulse = 600.0f;

            breakableBody.PostSolve(contact, constraint);

            Assert.Equal(BreakableBodyState.Unbroken, breakableBody.State);
        }

        /// <summary>
        /// Tests that cache velocities caches linear and angular velocities
        /// </summary>
        [Fact]
        public void CacheVelocities_CachesLinearAndAngularVelocities()
        {
            Mock<WorldPhysic> mockWorld = new Mock<WorldPhysic>();
            BreakableBody breakableBody = CreateBreakableBody(mockWorld.Object);

            Body body = new Body();
            body.GetBodyType = BodyType.Dynamic;
            body.LinearVelocity = new Vector2F(3.0f, 4.0f);
            body.AngularVelocity = 2.0f;

            Fixture fixture = new Fixture(new PolygonShape(new Alis.Core.Physic.Common.Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(1f, 1f)
            }), 1.0f));
            fixture.GetBody = body;
            breakableBody.Parts.Add(fixture);

            breakableBody.CacheVelocities();

            float[] angularCache = (float[])typeof(BreakableBody)
                .GetField("_angularVelocitiesCache", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(breakableBody);
            Vector2F[] velocityCache = (Vector2F[])typeof(BreakableBody)
                .GetField("_velocitiesCache", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(breakableBody);

            Assert.Equal(2.0f, angularCache[0]);
            Assert.Equal(3.0f, velocityCache[0].X);
            Assert.Equal(4.0f, velocityCache[0].Y);
        }

        /// <summary>
        /// Tests that cache velocities resizes cache when parts exceed cache length
        /// </summary>
        [Fact]
        public void CacheVelocities_WhenPartsExceedCacheLength_ResizesCache()
        {
            Mock<WorldPhysic> mockWorld = new Mock<WorldPhysic>();
            BreakableBody breakableBody = CreateBreakableBody(mockWorld.Object);

            Body body = new Body();
            body.GetBodyType = BodyType.Dynamic;
            body.LinearVelocity = new Vector2F(1.0f, 2.0f);
            body.AngularVelocity = 3.0f;

            for (int i = 0; i < 10; i++)
            {
                Fixture fixture = new Fixture(new PolygonShape(new Alis.Core.Physic.Common.Vertices(new[]
                {
                    new Vector2F(0f, 0f),
                    new Vector2F(1f, 0f),
                    new Vector2F(1f, 1f)
                }), 1.0f));
                fixture.GetBody = body;
                breakableBody.Parts.Add(fixture);
            }

            breakableBody.CacheVelocities();

            float[] angularCache = (float[])typeof(BreakableBody)
                .GetField("_angularVelocitiesCache", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(breakableBody);
            Vector2F[] velocityCache = (Vector2F[])typeof(BreakableBody)
                .GetField("_velocitiesCache", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(breakableBody);

            Assert.Equal(10, angularCache.Length);
            Assert.Equal(10, velocityCache.Length);
        }

        /// <summary>
        /// Tests that update when should break transitions to broken
        /// </summary>
        [Fact]
        public void Update_WhenShouldBreak_TransitionsToBroken()
        {
            Mock<WorldPhysic> mockWorld = new Mock<WorldPhysic>();
            Mock<Body> mockMainBody = new Mock<Body>();

            mockWorld.Setup(w => w.CreateBody(It.IsAny<Vector2F>(), It.IsAny<float>(), It.IsAny<BodyType>()))
                .Returns(mockMainBody.Object);

            Fixture fixture = new Fixture(new CircleShape(0.5f, 1.0f));
            mockMainBody.Setup(b => b.CreateFixture(It.IsAny<Shape>())).Returns(fixture);

            List<Alis.Core.Physic.Common.Vertices> vertices = new List<Alis.Core.Physic.Common.Vertices>
            {
                new Alis.Core.Physic.Common.Vertices(new[]
                {
                    new Vector2F(0f, 0f),
                    new Vector2F(1f, 0f),
                    new Vector2F(1f, 1f),
                    new Vector2F(0f, 1f)
                })
            };

            BreakableBody breakableBody = new BreakableBody(mockWorld.Object, vertices, 1.0f);
            breakableBody.State = BreakableBodyState.ShouldBreak;

            mockWorld.Setup(w => w.Remove(mockMainBody.Object));

            breakableBody.Update();

            Assert.Equal(BreakableBodyState.Broken, breakableBody.State);
        }

        /// <summary>
        /// Tests that constructor with shapes creates main body
        /// </summary>
        [Fact]
        public void Constructor_WithShapes_CreatesMainBody()
        {
            Mock<WorldPhysic> mockWorld = new Mock<WorldPhysic>();
            Mock<Body> mockBody = new Mock<Body>();

            mockWorld.Setup(w => w.CreateBody(It.IsAny<Vector2F>(), It.IsAny<float>(), It.IsAny<BodyType>()))
                .Returns(mockBody.Object);

            Shape shape = new CircleShape(0.5f, 1.0f);
            Fixture fixture = new Fixture(shape.Clone());
            mockBody.Setup(b => b.CreateFixture(It.IsAny<Shape>())).Returns(fixture);

            List<Shape> shapes = new List<Shape> { shape };

            BreakableBody breakableBody = new BreakableBody(mockWorld.Object, shapes);

            Assert.NotNull(breakableBody.MainBody);
            Assert.Single(breakableBody.Parts);
        }
    }
}
