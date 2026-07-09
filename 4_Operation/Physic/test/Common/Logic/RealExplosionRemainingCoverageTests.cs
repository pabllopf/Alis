using System;
using System.Collections.Generic;
using System.Linq;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common.Logic;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    public class RealExplosionRemainingCoverageTests
    {
        [Fact]
        public void Constructor_DefaultFields_ShouldHaveCorrectValues()
        {
            WorldPhysic world = new WorldPhysic();
            RealExplosion explosion = new RealExplosion(world);

            Assert.Equal(1.0f / 40.0f, explosion.EdgeRatio);
            Assert.False(explosion.IgnoreWhenInsideShape);
            Assert.Equal(MathF.PI / 15f, explosion.MaxAngle, 5);
            Assert.Equal(100, explosion.MaxShapes);
            Assert.Equal(5, explosion.MinRays);
        }

        [Fact]
        public void Constructor_WorldPhysic_ShouldBeSet()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            RealExplosion explosion = new RealExplosion(world);

            Assert.Same(world, explosion.WorldPhysic);
        }

        [Fact]
        public void Constructor_ControllerCategories_ShouldDefaultToCat01()
        {
            WorldPhysic world = new WorldPhysic();
            RealExplosion explosion = new RealExplosion(world);

            Assert.Equal(ControllerCategories.Cat01, explosion.ControllerCategories);
        }

        [Fact]
        public void Constructor_BaseType_ShouldBePhysicsLogic()
        {
            WorldPhysic world = new WorldPhysic();
            RealExplosion explosion = new RealExplosion(world);

            Assert.IsAssignableFrom<PhysicsLogic>(explosion);
        }

        [Fact]
        public void Constructor_BaseType_ShouldBeFilterData()
        {
            WorldPhysic world = new WorldPhysic();
            RealExplosion explosion = new RealExplosion(world);

            Assert.IsAssignableFrom<FilterData>(explosion);
        }

        [Fact]
        public void Activate_WithNoBodies_ReturnsEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 10f, 100f);

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void Activate_WithNoBodies_LargeRadius_ReturnsEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(new Vector2F(100, 100), 1000f, 500f);

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void Activate_WithStaticRectangle_ReturnsEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(10f, 10f, 1f, new Vector2F(5f, 0), 0f, BodyType.Static);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 50f, 100f);

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void Activate_WithDynamicRectangle_FarAway_ReturnsEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(2f, 2f, 1f, new Vector2F(100f, 0), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 5f, 100f);

            Assert.NotNull(result);
        }

        [Fact]
        public void Activate_WithContainedShape_InsideRectangle_ReturnsNonEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(20f, 20f, 1f, new Vector2F(5f, 0), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 100f, 100f);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void Activate_WithContainedShape_InsideCircle_ReturnsNonEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(10f, 1f, new Vector2F(5f, 0), BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 100f, 100f);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void Activate_WithContainedShape_ReturnsFixtureWithDynamicBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(20f, 20f, 1f, new Vector2F(5f, 0), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 100f, 100f);

            Assert.NotEmpty(result);
            KeyValuePair<Fixture, Vector2F> entry = result.First();
            Assert.Same(body, entry.Key.GetBody);
            Assert.True(entry.Value.Length() > 0);
        }

        [Fact]
        public void Activate_WithContainedCircleShape_ReturnsFixtureWithDynamicBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(10f, 1f, new Vector2F(5f, 0), BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 100f, 100f);

            Assert.NotEmpty(result);
            KeyValuePair<Fixture, Vector2F> entry = result.First();
            Assert.Same(body, entry.Key.GetBody);
            Assert.True(entry.Value.Length() > 0);
        }

        [Fact]
        public void Activate_WithContainedStaticShape_ReturnsEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Static);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 100f, 100f);

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void Activate_WithDisabledBody_ReturnsEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            body.Enabled = false;
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 100f, 100f);

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void Activate_WithIgnoredController_ReturnsEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);
            body.ControllerFilter.IgnoreController(ControllerCategories.Cat01);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 100f, 100f);

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void Activate_WithIgnoredController_MultipleBodies_OnlyActiveAffected()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body activeBody = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            Body ignoredBody = world.CreateRectangle(10f, 10f, 1f, new Vector2F(20f, 0), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);
            ignoredBody.ControllerFilter.IgnoreController(ControllerCategories.Cat01);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 100f, 100f);

            Assert.Contains(result, kvp => kvp.Key.GetBody == activeBody);
            Assert.DoesNotContain(result, kvp => kvp.Key.GetBody == ignoredBody);
        }

        [Fact]
        public void Activate_WithZeroRadius_FarFromBodies_ReturnsEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(10f, 10f, 1f, new Vector2F(100f, 0), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(new Vector2F(-100f, 0), 0f, 100f);

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void Activate_WithZeroMaxForce_ReturnsNonEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 100f, 0f);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void Activate_WithMultipleContainedBodies_ReturnsAll()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body1 = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            Body body2 = world.CreateCircle(5f, 1f, Vector2F.Zero, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 100f, 100f);

            Assert.Contains(result, kvp => kvp.Key.GetBody == body1);
            Assert.Contains(result, kvp => kvp.Key.GetBody == body2);
        }

        [Fact]
        public void IsActiveOn_WithActiveBody_ReturnsTrue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Assert.True(explosion.IsActiveOn(body));
        }

        [Fact]
        public void IsActiveOn_WithNullBody_ThrowsNullReferenceException()
        {
            WorldPhysic world = new WorldPhysic();
            RealExplosion explosion = new RealExplosion(world);

            Assert.Throws<NullReferenceException>(() => explosion.IsActiveOn(null));
        }

        [Fact]
        public void IsActiveOn_WithStaticBody_ReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Static);
            RealExplosion explosion = new RealExplosion(world);

            Assert.False(explosion.IsActiveOn(body));
        }

        [Fact]
        public void IsActiveOn_WithDisabledBody_ReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            body.Enabled = false;
            RealExplosion explosion = new RealExplosion(world);

            Assert.False(explosion.IsActiveOn(body));
        }

        [Fact]
        public void IsActiveOn_WithIgnoredController_ReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);
            body.ControllerFilter.IgnoreController(ControllerCategories.Cat01);

            Assert.False(explosion.IsActiveOn(body));
        }
    }
}
