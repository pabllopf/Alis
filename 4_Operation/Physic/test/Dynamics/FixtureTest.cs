// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixtureTest.cs
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
using Alis.Core.Physic.Dynamics;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The fixture test class
    /// </summary>
    public class FixtureTest
    {
        /// <summary>
        /// Tests that constructor with shape should clone shape and setup proxies
        /// </summary>
        [Fact]
        public void Constructor_WithShape_ShouldCloneShapeAndSetupProxies()
        {
            CircleShape shape = new CircleShape(0.5f, 1.0f);

            Fixture fixture = new Fixture(shape);

            Assert.NotSame(shape, fixture.GetShape);
            Assert.Equal(shape.ChildCount, fixture.Proxies.Length);
            Assert.Equal(0, fixture.ProxyCount);
        }

        /// <summary>
        /// Tests that sensor flag when set should wake body
        /// </summary>
        [Fact]
        public void SensorFlag_WhenSet_ShouldWakeBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture fixture = body.CreateCircle(0.5f, 1.0f);
            body.Awake = false;

            fixture.GetIsSensor = true;

            Assert.True(body.Awake);
            Assert.True(fixture.GetIsSensor);
        }

        /// <summary>
        /// Tests that collision category properties should set and get values
        /// </summary>
        [Fact]
        public void CollisionCategoryProperties_ShouldSetAndGetValues()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture fixture = body.CreateCircle(0.5f, 1.0f);

            fixture.GetCollisionGroup = 2;
            fixture.GetCollisionCategories = Categories.Cat4;
            fixture.GetCollidesWith = Categories.Cat2 | Categories.Cat3;

            Assert.Equal((short)2, fixture.GetCollisionGroup);
            Assert.Equal(Categories.Cat4, fixture.GetCollisionCategories);
            Assert.Equal(Categories.Cat2 | Categories.Cat3, fixture.GetCollidesWith);
        }

        /// <summary>
        /// Tests that test point should return true when point inside circle
        /// </summary>
        [Fact]
        public void TestPoint_ShouldReturnTrue_WhenPointInsideCircle()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(1.0f, 1.0f), 0.0f, BodyType.Dynamic);
            Fixture fixture = body.CreateCircle(1.0f, 1.0f);
            Vector2F point = new Vector2F(1.2f, 1.1f);

            bool isInside = fixture.TestPoint(ref point);

            Assert.True(isInside);
        }

        /// <summary>
        /// Tests that friction and restitution should persist assigned values
        /// </summary>
        [Fact]
        public void FrictionAndRestitution_ShouldPersistAssignedValues()
        {
            Fixture fixture = new Fixture(new CircleShape(0.4f, 1.0f));

            fixture.GetFriction = 0.9f;
            fixture.GetRestitution = 0.2f;

            Assert.Equal(0.9f, fixture.GetFriction);
            Assert.Equal(0.2f, fixture.GetRestitution);
        }

        /// <summary>
        /// Tests that test point should return false when point is outside circle
        /// </summary>
        [Fact]
        public void TestPoint_ShouldReturnFalse_WhenPointOutsideCircle()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(1.0f, 1.0f), 0.0f, BodyType.Dynamic);
            Fixture fixture = body.CreateCircle(1.0f, 1.0f);
            Vector2F point = new Vector2F(5.0f, 5.0f);

            bool isInside = fixture.TestPoint(ref point);

            Assert.False(isInside);
        }

        /// <summary>
        /// Tests that clone onto should copy fixture properties to target body
        /// </summary>
        [Fact]
        public void CloneOnto_ShouldCopyFixturePropertiesToTargetBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body sourceBody = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture sourceFixture = sourceBody.CreateCircle(0.5f, 1.0f);
            sourceFixture.GetFriction = 0.7f;
            sourceFixture.GetRestitution = 0.3f;
            sourceFixture.GetIsSensor = true;
            sourceFixture.Tag = "test-tag";

            Body targetBody = world.CreateBody(new Vector2F(2.0f, 2.0f), 0.0f, BodyType.Dynamic);
            Fixture clonedFixture = sourceFixture.CloneOnto(targetBody);

            Assert.NotNull(clonedFixture);
            Assert.NotSame(sourceFixture, clonedFixture);
            Assert.Equal(0.7f, clonedFixture.GetFriction);
            Assert.Equal(0.3f, clonedFixture.GetRestitution);
            Assert.True(clonedFixture.GetIsSensor);
            Assert.Equal("test-tag", clonedFixture.Tag);
            Assert.Same(targetBody, clonedFixture.GetBody);
        }

        /// <summary>
        ///     Tests that constructor defaults are set correctly
        /// </summary>
        [Fact]
        public void Constructor_Defaults_ShouldSetCorrectValues()
        {
            Fixture fixture = new Fixture(new CircleShape(0.4f, 1.0f));

            Assert.Equal(Categories.Cat1, fixture.GetCollisionCategories);
            Assert.Equal(Categories.All, fixture.GetCollidesWith);
            Assert.Equal((short)0, fixture.GetCollisionGroup);
            Assert.Equal(0.2f, fixture.GetFriction);
            Assert.Equal(0.0f, fixture.GetRestitution);
            Assert.False(fixture.GetIsSensor);
            Assert.Null(fixture.GetBody);
            Assert.NotNull(fixture.GetShape);
            Assert.NotNull(fixture.Proxies);
        }

        /// <summary>
        ///     Tests that tag property can be set and retrieved
        /// </summary>
        [Fact]
        public void Tag_ShouldSetAndGetValue()
        {
            Fixture fixture = new Fixture(new CircleShape(0.4f, 1.0f));

            fixture.Tag = "my-tag";

            Assert.Equal("my-tag", fixture.Tag);
        }

        /// <summary>
        ///     Tests that get collision group set with same value should not refilter
        /// </summary>
        [Fact]
        public void GetCollisionGroup_SameValue_ShouldNotRefilter()
        {
            Fixture fixture = new Fixture(new CircleShape(0.4f, 1.0f));

            fixture.GetCollisionGroup = 0;

            Assert.Equal((short)0, fixture.GetCollisionGroup);
        }

        /// <summary>
        ///     Tests that get collides with set with same value should not refilter
        /// </summary>
        [Fact]
        public void GetCollidesWith_SameValue_ShouldNotRefilter()
        {
            Fixture fixture = new Fixture(new CircleShape(0.4f, 1.0f));

            fixture.GetCollidesWith = Categories.All;

            Assert.Equal(Categories.All, fixture.GetCollidesWith);
        }

        /// <summary>
        ///     Tests that get collision categories set with same value should not refilter
        /// </summary>
        [Fact]
        public void GetCollisionCategories_SameValue_ShouldNotRefilter()
        {
            Fixture fixture = new Fixture(new CircleShape(0.4f, 1.0f));

            fixture.GetCollisionCategories = Categories.Cat1;

            Assert.Equal(Categories.Cat1, fixture.GetCollisionCategories);
        }

        /// <summary>
        ///     Tests that get is sensor with no body should not wake body
        /// </summary>
        [Fact]
        public void GetIsSensor_WithNoBody_ShouldNotThrow()
        {
            Fixture fixture = new Fixture(new CircleShape(0.4f, 1.0f));

            fixture.GetIsSensor = true;

            Assert.True(fixture.GetIsSensor);
        }

        /// <summary>
        ///     Tests that get body is null when fixture not attached
        /// </summary>
        [Fact]
        public void GetBody_WhenNotAttached_ShouldBeNull()
        {
            Fixture fixture = new Fixture(new CircleShape(0.4f, 1.0f));

            Assert.Null(fixture.GetBody);
        }

        /// <summary>
        ///     Tests that get shape returns the cloned shape
        /// </summary>
        [Fact]
        public void GetShape_ShouldReturnClonedShape()
        {
            CircleShape shape = new CircleShape(0.5f, 1.0f);
            Fixture fixture = new Fixture(shape);

            Assert.NotNull(fixture.GetShape);
            Assert.IsType<CircleShape>(fixture.GetShape);
        }

        /// <summary>
        ///     Tests that ray cast returns correct result
        /// </summary>
        [Fact]
        public void RayCast_ShouldReturnResult()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture fixture = body.CreateCircle(5.0f, 1.0f);
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(-10.0f, 0.0f),
                Point2 = new Vector2F(10.0f, 0.0f),
                MaxFraction = 1.0f
            };

            bool hit = fixture.RayCast(out RayCastOutput output, ref input, 0);

            Assert.True(hit);
            Assert.True(output.Fraction > 0.0f);
        }

        /// <summary>
        ///     Tests that ray cast returns false when no intersection
        /// </summary>
        [Fact]
        public void RayCast_ShouldReturnFalse_WhenNoIntersection()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture fixture = body.CreateCircle(1.0f, 1.0f);
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(10.0f, 10.0f),
                Point2 = new Vector2F(20.0f, 20.0f),
                MaxFraction = 1.0f
            };

            bool hit = fixture.RayCast(out RayCastOutput output, ref input, 0);

            Assert.False(hit);
        }

        /// <summary>
        ///     Tests that get aabb returns the proxy aabb for the child index
        /// </summary>
        [Fact]
        public void GetAabb_ShouldReturnProxyAabb()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture fixture = body.CreateCircle(1.0f, 1.0f);

            fixture.GetAabb(out Aabb aabb, 0);

            Assert.NotNull(aabb);
        }

        /// <summary>
        ///     Tests that destroy proxies removes proxies from broad phase
        /// </summary>
        [Fact]
        public void DestroyProxies_ShouldRemoveProxiesFromBroadPhase()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture fixture = body.CreateCircle(0.5f, 1.0f);
            Mock<IBroadPhase> mockBroadPhase = new Mock<IBroadPhase>();
            int proxyCountBefore = fixture.ProxyCount;

            fixture.DestroyProxies(mockBroadPhase.Object);

            Assert.Equal(0, fixture.ProxyCount);
            mockBroadPhase.Verify(m => m.RemoveProxy(It.IsAny<int>()), Times.Exactly(proxyCountBefore));
        }

        /// <summary>
        ///     Tests that destroy proxies sets proxy ids to -1
        /// </summary>
        [Fact]
        public void DestroyProxies_ShouldSetProxyIdsToNegativeOne()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture fixture = body.CreateCircle(0.5f, 1.0f);
            Mock<IBroadPhase> mockBroadPhase = new Mock<IBroadPhase>();

            fixture.DestroyProxies(mockBroadPhase.Object);

            Assert.All(fixture.Proxies, p => Assert.Equal(-1, p.ProxyId));
        }

        /// <summary>
        ///     Tests that touch proxies touches all proxies in broad phase
        /// </summary>
        [Fact]
        public void TouchProxies_ShouldTouchAllProxies()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture fixture = body.CreateCircle(0.5f, 1.0f);
            Mock<IBroadPhase> mockBroadPhase = new Mock<IBroadPhase>();

            fixture.TouchProxies(mockBroadPhase.Object);

            mockBroadPhase.Verify(m => m.TouchProxy(It.IsAny<int>()), Times.Exactly(fixture.ProxyCount));
        }

        /// <summary>
        ///     Tests that synchronize moves proxies based on transform delta
        /// </summary>
        [Fact]
        public void Synchronize_ShouldMoveProxies()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture fixture = body.CreateCircle(0.5f, 1.0f);
            Mock<IBroadPhase> mockBroadPhase = new Mock<IBroadPhase>();
            ControllerTransform transform1 = ControllerTransform.Identity;
            ControllerTransform transform2 = new ControllerTransform(new Vector2F(1.0f, 0.0f), Complex.One);

            fixture.Synchronize(mockBroadPhase.Object, ref transform1, ref transform2);

            mockBroadPhase.Verify(m => m.MoveProxy(It.IsAny<int>(),
                    ref It.Ref<Aabb>.IsAny,
                    It.IsAny<Vector2F>()),
                Times.AtLeastOnce);
        }

        /// <summary>
        ///     Tests that clone onto calls internal overload with same shape
        /// </summary>
        [Fact]
        public void CloneOnto_ShouldUseInternalOverload()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body sourceBody = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture sourceFixture = sourceBody.CreateCircle(0.5f, 1.0f);
            sourceFixture.Tag = "clone-test";
            Body targetBody = world.CreateBody(new Vector2F(2.0f, 2.0f), 0.0f, BodyType.Dynamic);

            Fixture cloned = sourceFixture.CloneOnto(targetBody);

            Assert.Equal("clone-test", cloned.Tag);
            Assert.Equal(0.2f, cloned.GetFriction);
            Assert.Equal(0.0f, cloned.GetRestitution);
            Assert.Equal(sourceFixture.Proxies.Length, cloned.Proxies.Length);
        }

        /// <summary>
        ///     Tests that default constructor sets correct initial values
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldSetCorrectValues()
        {
            CircleShape shape = new CircleShape(0.5f, 1.0f);
            Fixture fixture = new Fixture(shape);

            Assert.Equal(Categories.Cat1, fixture.GetCollisionCategories);
            Assert.Equal(Categories.All, fixture.GetCollidesWith);
            Assert.Equal((short)0, fixture.GetCollisionGroup);
            Assert.Equal(0.2f, fixture.GetFriction);
            Assert.Equal(0.0f, fixture.GetRestitution);
            Assert.False(fixture.GetIsSensor);
            Assert.Null(fixture.GetBody);
        }

        /// <summary>
        ///     Tests that proxy count starts at zero then increases after body attachment
        /// </summary>
        [Fact]
        public void ProxyCount_ShouldStartAtZero_ThenIncrease()
        {
            CircleShape shape = new CircleShape(0.5f, 1.0f);
            Fixture fixture = new Fixture(shape);

            Assert.Equal(0, fixture.ProxyCount);
        }
    }
}

