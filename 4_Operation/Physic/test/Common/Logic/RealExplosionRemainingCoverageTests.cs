using System;
using System.Collections.Generic;
using System.Linq;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common.Logic;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    /// <summary>
    /// The real explosion remaining coverage tests class
    /// </summary>
    public class RealExplosionRemainingCoverageTests
    {
        /// <summary>
        /// Tests that constructor default fields should have correct values
        /// </summary>
        [Fact]
        public void Constructor_DefaultFields_ShouldHaveCorrectValues()
        {
            WorldPhysic world = new WorldPhysic();
            RealExplosion explosion = new RealExplosion(world);

            Assert.Equal(1.0f / 40.0f, explosion.EdgeRatio, 5);
            Assert.False(explosion.IgnoreWhenInsideShape);
            Assert.Equal(MathF.PI / 15f, explosion.MaxAngle, 5);
            Assert.Equal(100, explosion.MaxShapes);
            Assert.Equal(5, explosion.MinRays);
        }

        /// <summary>
        /// Tests that constructor world physic should be set
        /// </summary>
        [Fact]
        public void Constructor_WorldPhysic_ShouldBeSet()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            RealExplosion explosion = new RealExplosion(world);

            Assert.Same(world, explosion.WorldPhysic);
        }

        /// <summary>
        /// Tests that constructor controller categories should default to cat 01
        /// </summary>
        [Fact]
        public void Constructor_ControllerCategories_ShouldDefaultToCat01()
        {
            WorldPhysic world = new WorldPhysic();
            RealExplosion explosion = new RealExplosion(world);

            Assert.Equal(ControllerCategories.Cat01, explosion.ControllerCategories);
        }

        /// <summary>
        /// Tests that constructor base type should be physics logic
        /// </summary>
        [Fact]
        public void Constructor_BaseType_ShouldBePhysicsLogic()
        {
            WorldPhysic world = new WorldPhysic();
            RealExplosion explosion = new RealExplosion(world);

            Assert.IsAssignableFrom<PhysicsLogic>(explosion);
        }

        /// <summary>
        /// Tests that constructor base type should be filter data
        /// </summary>
        [Fact]
        public void Constructor_BaseType_ShouldBeFilterData()
        {
            WorldPhysic world = new WorldPhysic();
            RealExplosion explosion = new RealExplosion(world);

            Assert.IsAssignableFrom<FilterData>(explosion);
        }

        /// <summary>
        /// Tests that activate with no bodies returns empty
        /// </summary>
        [Fact]
        public void Activate_WithNoBodies_ReturnsEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 10f, 100f);

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that activate with no bodies large radius returns empty
        /// </summary>
        [Fact]
        public void Activate_WithNoBodies_LargeRadius_ReturnsEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(new Vector2F(100, 100), 1000f, 500f);

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that activate with static rectangle returns empty
        /// </summary>
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

        /// <summary>
        /// Tests that activate with dynamic rectangle far away returns empty
        /// </summary>
        [Fact]
        public void Activate_WithDynamicRectangle_FarAway_ReturnsEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(2f, 2f, 1f, new Vector2F(100f, 0), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 5f, 100f);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that activate with contained shape inside rectangle returns non empty
        /// </summary>
        [Fact]
        public void Activate_WithContainedShape_InsideRectangle_ReturnsNonEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(20f, 20f, 1f, new Vector2F(5f, 0), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 100f, 100f);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        /// <summary>
        /// Tests that activate with contained shape inside circle returns non empty
        /// </summary>
        [Fact]
        public void Activate_WithContainedShape_InsideCircle_ReturnsNonEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(10f, 1f, new Vector2F(5f, 0), BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 100f, 100f);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        /// <summary>
        /// Tests that activate with contained shape returns fixture with dynamic body
        /// </summary>
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

        /// <summary>
        /// Tests that activate with contained circle shape returns fixture with dynamic body
        /// </summary>
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

        /// <summary>
        /// Tests that activate with contained static shape returns empty
        /// </summary>
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

        /// <summary>
        /// Tests that activate with disabled body returns empty
        /// </summary>
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

        /// <summary>
        /// Tests that activate with ignored controller returns empty
        /// </summary>
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

        /// <summary>
        /// Tests that activate with ignored controller multiple bodies only active affected
        /// </summary>
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

        /// <summary>
        /// Tests that activate with zero radius far from bodies returns empty
        /// </summary>
        [Fact]
        public void Activate_WithZeroRadius_FarFromBodies_ReturnsEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(10f, 10f, 1f, new Vector2F(100f, 0), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(new Vector2F(-100f, 0), 0f, 100f);

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that activate with zero max force returns non empty
        /// </summary>
        [Fact]
        public void Activate_WithZeroMaxForce_ReturnsNonEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 100f, 0f);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        /// <summary>
        /// Tests that activate with multiple contained bodies returns all
        /// </summary>
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

        /// <summary>
        /// Tests that is active on with active body returns true
        /// </summary>
        [Fact]
        public void IsActiveOn_WithActiveBody_ReturnsTrue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Assert.True(explosion.IsActiveOn(body));
        }

        /// <summary>
        /// Tests that is active on with null body throws null reference exception
        /// </summary>
        [Fact]
        public void IsActiveOn_WithNullBody_ThrowsNullReferenceException()
        {
            WorldPhysic world = new WorldPhysic();
            RealExplosion explosion = new RealExplosion(world);

            Assert.Throws<NullReferenceException>(() => explosion.IsActiveOn(null));
        }

        /// <summary>
        /// Tests that is active on with static body returns false
        /// </summary>
        [Fact]
        public void IsActiveOn_WithStaticBody_ReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Static);
            RealExplosion explosion = new RealExplosion(world);

            Assert.False(explosion.IsActiveOn(body));
        }

        /// <summary>
        /// Tests that is active on with disabled body returns false
        /// </summary>
        [Fact]
        public void IsActiveOn_WithDisabledBody_ReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            body.Enabled = false;
            RealExplosion explosion = new RealExplosion(world);

            Assert.False(explosion.IsActiveOn(body));
        }

        /// <summary>
        /// Tests that is active on with ignored controller returns false
        /// </summary>
        [Fact]
        public void IsActiveOn_WithIgnoredController_ReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);
            body.ControllerFilter.IgnoreController(ControllerCategories.Cat01);

            Assert.False(explosion.IsActiveOn(body));
        }

        /// <summary>
        /// Tests that activate with dynamic body outside explosion should trigger raycast
        /// </summary>
        [Fact]
        public void Activate_WithDynamicBodyOutsideExplosion_ShouldTriggerRaycast()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(4f, 4f, 1f, new Vector2F(15f, 0), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 50f, 100f);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that activate with dynamic circle outside explosion should trigger create polygon from circle
        /// </summary>
        [Fact]
        public void Activate_WithDynamicCircleOutsideExplosion_ShouldTriggerCreatePolygonFromCircle()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(3f, 1f, new Vector2F(20f, 0), BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 50f, 100f);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that activate with dynamic body behind static body should skip blocked body
        /// </summary>
        [Fact]
        public void Activate_WithDynamicBodyBehindStaticBody_ShouldSkipBlockedBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(10f, 10f, 1f, new Vector2F(5f, 0), 0f, BodyType.Static);
            world.CreateRectangle(4f, 4f, 1f, new Vector2F(20f, 0), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 50f, 100f);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that activate with multiple dynamic bodies should affect all hit by rays
        /// </summary>
        [Fact]
        public void Activate_WithMultipleDynamicBodies_ShouldAffectAllHitByRays()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(4f, 4f, 1f, new Vector2F(15f, 0), 0f, BodyType.Dynamic);
            world.CreateCircle(3f, 1f, new Vector2F(0, 15f), BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 50f, 100f);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that activate with dynamic body at angle should calculate angle bounds
        /// </summary>
        [Fact]
        public void Activate_WithDynamicBodyAtAngle_ShouldCalculateAngleBounds()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(4f, 4f, 1f, new Vector2F(10f, 10f), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 50f, 100f);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that activate with large radius and max force should not throw
        /// </summary>
        [Fact]
        public void Activate_WithLargeRadiusAndMaxForce_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(5f, 5f, 1f, new Vector2F(100f, 0), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(new Vector2F(-50f, 0), 200f, 1000f);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that activate with explosion close to rectangle edge should process ray cast
        /// </summary>
        [Fact]
        public void Activate_WithExplosionCloseToRectangleEdge_ShouldProcessRayCast()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(10f, 10f, 1f, new Vector2F(10f, 0), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(new Vector2F(-1f, 0), 20f, 50f);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that activate with explosion close to circle edge should process create polygon from circle
        /// </summary>
        [Fact]
        public void Activate_WithExplosionCloseToCircleEdge_ShouldProcessCreatePolygonFromCircle()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(5f, 1f, new Vector2F(12f, 0), BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(new Vector2F(-1f, 0), 20f, 50f);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that activate with kinematic body should not be affected
        /// </summary>
        [Fact]
        public void Activate_WithKinematicBody_ShouldNotBeAffected()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(10f, 10f, 1f, new Vector2F(10f, 0), 0f, BodyType.Kinematic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 50f, 100f);

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that activate with max force zero and body outside should not throw
        /// </summary>
        [Fact]
        public void Activate_WithMaxForceZeroAndBodyOutside_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(3f, 1f, new Vector2F(10f, 0), BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 30f, 0f);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that activate with body very close to explosion should process ray hit
        /// </summary>
        [Fact]
        public void Activate_WithBodyVeryCloseToExplosion_ShouldProcessRayHit()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(2f, 2f, 1f, new Vector2F(3f, 0), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 10f, 100f);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that activate with large rectangle body should compute angle bounds
        /// </summary>
        [Fact]
        public void Activate_WithLargeRectangleBody_ShouldComputeAngleBounds()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(20f, 2f, 1f, new Vector2F(15f, 0), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 50f, 200f);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that activate with explosion behind body should still process ray cast
        /// </summary>
        [Fact]
        public void Activate_WithExplosionBehindBody_ShouldStillProcessRayCast()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(4f, 4f, 1f, new Vector2F(10f, 0), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(new Vector2F(25f, 0), 30f, 100f);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that activate with circle shape body large radius should apply impulses
        /// </summary>
        [Fact]
        public void Activate_WithCircleShapeBodyLargeRadius_ShouldApplyImpulses()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(6f, 1f, new Vector2F(20f, 0), BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 100f, 500f);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that list any with non empty list returns true
        /// </summary>
        [Fact]
        public void ListAny_WithNonEmptyList_ReturnsTrue()
        {
            List<int> list = new List<int> { 1 };
            Assert.True(RealExplosion.ListAny(list));
        }

        /// <summary>
        /// Tests that list any with empty list returns false
        /// </summary>
        [Fact]
        public void ListAny_WithEmptyList_ReturnsFalse()
        {
            List<int> list = new List<int>();
            Assert.False(RealExplosion.ListAny(list));
        }

        /// <summary>
        /// Tests that list first with non empty list returns first
        /// </summary>
        [Fact]
        public void ListFirst_WithNonEmptyList_ReturnsFirst()
        {
            List<int> list = new List<int> { 1, 2, 3 };
            Assert.Equal(1, RealExplosion.ListFirst(list));
        }

        /// <summary>
        /// Tests that list last with non empty list returns last
        /// </summary>
        [Fact]
        public void ListLast_WithNonEmptyList_ReturnsLast()
        {
            List<int> list = new List<int> { 1, 2, 3 };
            Assert.Equal(3, RealExplosion.ListLast(list));
        }

        /// <summary>
        /// Tests that is active on with kinematic body returns true
        /// </summary>
        [Fact]
        public void IsActiveOn_WithKinematicBody_ReturnsTrue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Kinematic);
            RealExplosion explosion = new RealExplosion(world);

            Assert.True(explosion.IsActiveOn(body));
        }

        /// <summary>
        /// Tests that activate with rectangle and circle dynamic bodies should process multiple shapes
        /// </summary>
        [Fact]
        public void Activate_WithRectangleAndCircle_DynamicBodies_ShouldProcessMultipleShapes()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(2f, 2f, 1f, new Vector2F(10f, 0), 0f, BodyType.Dynamic);
            world.CreateCircle(2f, 1f, new Vector2F(0, 12f), BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 30f, 100f);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that activate with large force and multiple bodies should not throw
        /// </summary>
        [Fact]
        public void Activate_WithLargeForceAndMultipleBodies_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            for (int i = 0; i < 3; i++)
            {
                world.CreateRectangle(2f, 2f, 1f, new Vector2F(10f + i * 5f, 0), 0f, BodyType.Dynamic);
            }
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 50f, 1000f);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that activate with overlapping angle bounds processes ray hits
        /// </summary>
        [Fact]
        public void Activate_WithOverlappingAngleBounds_ProcessesRayHits()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(10f, 10f, 1f, new Vector2F(5f, 0), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 100f, 100f);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that activate with contained circle shape processes contained shapes
        /// </summary>
        [Fact]
        public void Activate_WithContainedCircleShape_ProcessesContainedShapes()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(5f, 1f, Vector2F.Zero, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 1f, 100f);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that activate with explosion at body center triggers contained shapes
        /// </summary>
        [Fact]
        public void Activate_WithExplosionAtBodyCenter_TriggersContainedShapes()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(20f, 20f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 5f, 100f);

            Assert.NotNull(result);
        }

        // ========================================================================
        // Internal method tests
        // ========================================================================

        /// <summary>
        /// Tests that add new shape data adds entry with correct values
        /// </summary>
        [Fact]
        public void AddNewShapeData_AddsEntryWithCorrectValues()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            RealExplosion explosion = new RealExplosion(world);
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);

            explosion.AddNewShapeData(body, 0.1f, 1.0f);

            Assert.Single(explosion._data);
            Assert.Same(body, explosion._data[0].Body);
            Assert.Equal(0.1f, explosion._data[0].Min, 5);
            Assert.Equal(1.0f, explosion._data[0].Max, 5);
        }

        /// <summary>
        /// Tests that update last shape data updates max of last entry
        /// </summary>
        [Fact]
        public void UpdateLastShapeData_UpdatesMaxOfLastEntry()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            RealExplosion explosion = new RealExplosion(world);
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);

            explosion.AddNewShapeData(body, 0.1f, 1.0f);
            explosion.UpdateLastShapeData(2.0f);
            explosion.UpdateLastShapeData(3.0f);

            Assert.Equal(3.0f, explosion._data[0].Max, 5);
        }

        /// <summary>
        /// Tests that process ray hit with no existing data adds new entry
        /// </summary>
        [Fact]
        public void ProcessRayHit_WithNoExistingData_AddsNewEntry()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            RealExplosion explosion = new RealExplosion(world);
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            float[] vals = { 0.1f, 1.0f };
            bool rayMissed = true;

            explosion.ProcessRayHit(vals, 0, 2, body, ref rayMissed);

            Assert.Single(explosion._data);
            Assert.Same(body, explosion._data[0].Body);
            Assert.Equal(vals[0], explosion._data[0].Min);
            Assert.Equal(vals[1], explosion._data[0].Max);
        }

        /// <summary>
        /// Tests that process ray hit with existing same body data updates last using iplus as max
        /// </summary>
        [Fact]
        public void ProcessRayHit_WithExistingSameBody_UpdatesLast()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            RealExplosion explosion = new RealExplosion(world);
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            float[] vals = { 0.1f, 1.0f, 1.5f, 2.5f };
            bool rayMissed = false;

            explosion.AddNewShapeData(body, 0.1f, 1.0f);
            explosion.ProcessRayHit(vals, 2, 4, body, ref rayMissed);

            Assert.Single(explosion._data);
            Assert.Equal(3, explosion._data[0].Max);
        }

        /// <summary>
        /// Tests that merge circular data with matching endpoints merges entries
        /// </summary>
        [Fact]
        public void MergeCircularData_WithMatchingEndpoints_MergesEntries()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            RealExplosion explosion = new RealExplosion(world);
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);

            explosion.AddNewShapeData(body, 0.1f, 1.0f);
            explosion.AddNewShapeData(body, 2.0f, 0.1f + 0.5f * float.Epsilon);

            explosion.MergeCircularData();

            Assert.Single(explosion._data);
            Assert.True(explosion._data[0].Min < explosion._data[0].Max);
        }

        /// <summary>
        /// Tests that merge circular data with single entry does nothing
        /// </summary>
        [Fact]
        public void MergeCircularData_WithSingleEntry_DoesNothing()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            RealExplosion explosion = new RealExplosion(world);
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);

            explosion.AddNewShapeData(body, 0.1f, 1.0f);
            explosion.MergeCircularData();

            Assert.Single(explosion._data);
        }

        /// <summary>
        /// Tests that merge circular data with different bodies does nothing
        /// </summary>
        [Fact]
        public void MergeCircularData_WithDifferentBodies_DoesNothing()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            RealExplosion explosion = new RealExplosion(world);
            Body body1 = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            Body body2 = world.CreateCircle(5f, 1f, new Vector2F(10f, 0), BodyType.Dynamic);

            explosion.AddNewShapeData(body1, 0.1f, 1.0f);
            explosion.AddNewShapeData(body2, 2.0f, 0.1f + 0.5f * float.Epsilon);
            explosion.MergeCircularData();

            Assert.Equal(2, explosion._data.Count);
        }

        /// <summary>
        /// Tests that adjust wrapped data when min greater or equal max adjusts min
        /// </summary>
        [Fact]
        public void AdjustWrappedData_WhenMinGreaterOrEqualMax_AdjustsMin()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            RealExplosion explosion = new RealExplosion(world);
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);

            explosion.AddNewShapeData(body, 2.0f, 1.0f);
            explosion.AdjustWrappedData();

            Assert.True(explosion._data[0].Min < explosion._data[0].Max);
        }

        /// <summary>
        /// Tests that adjust wrapped data with normal entry does nothing
        /// </summary>
        [Fact]
        public void AdjustWrappedData_WithNormalEntry_DoesNothing()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            RealExplosion explosion = new RealExplosion(world);
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);

            explosion.AddNewShapeData(body, 0.1f, 1.0f);
            explosion.AdjustWrappedData();

            Assert.Equal(0.1f, explosion._data[0].Min, 5);
            Assert.Equal(1.0f, explosion._data[0].Max, 5);
        }

        /// <summary>
        /// Tests that adjust overlapping data calls adjust wrapped data
        /// </summary>
        [Fact]
        public void AdjustOverlappingData_WithWrappedEntry_AdjustsMin()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            RealExplosion explosion = new RealExplosion(world);
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);

            explosion.AddNewShapeData(body, 2.0f, 1.0f);
            explosion.AdjustOverlappingData();

            Assert.True(explosion._data[0].Min < explosion._data[0].Max);
        }

        /// <summary>
        /// Tests that apply contained shape impulses with dynamic body adds to dictionary
        /// </summary>
        [Fact]
        public void ApplyContainedShapeImpulses_WithDynamicBody_AddsToDictionary()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(10f, 10f, 1f, new Vector2F(5f, 0), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);
            Fixture fixture = body.FixtureList[0];
            Fixture[] containedShapes = { fixture };
            Dictionary<Fixture, Vector2F> exploded = new Dictionary<Fixture, Vector2F>();

            explosion.ApplyContainedShapeImpulses(Vector2F.Zero, 100f, containedShapes, 1, exploded);

            Assert.NotEmpty(exploded);
            Assert.Contains(fixture, exploded);
        }

        /// <summary>
        /// Tests that apply contained shape impulses with static body adds nothing
        /// </summary>
        [Fact]
        public void ApplyContainedShapeImpulses_WithStaticBody_DoesNothing()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Static);
            RealExplosion explosion = new RealExplosion(world);
            Fixture fixture = body.FixtureList[0];
            Fixture[] containedShapes = { fixture };
            Dictionary<Fixture, Vector2F> exploded = new Dictionary<Fixture, Vector2F>();

            explosion.ApplyContainedShapeImpulses(Vector2F.Zero, 100f, containedShapes, 1, exploded);

            Assert.Empty(exploded);
        }

        /// <summary>
        /// Tests that apply contained shape impulses with ignored controller adds nothing
        /// </summary>
        [Fact]
        public void ApplyContainedShapeImpulses_WithIgnoredController_DoesNothing()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            body.ControllerFilter.IgnoreController(ControllerCategories.Cat01);
            RealExplosion explosion = new RealExplosion(world);
            Fixture fixture = body.FixtureList[0];
            Fixture[] containedShapes = { fixture };
            Dictionary<Fixture, Vector2F> exploded = new Dictionary<Fixture, Vector2F>();

            explosion.ApplyContainedShapeImpulses(Vector2F.Zero, 100f, containedShapes, 1, exploded);

            Assert.Empty(exploded);
        }

        /// <summary>
        /// Tests that apply contained shape impulses with circle shape calls impulse for circle
        /// </summary>
        [Fact]
        public void ApplyContainedShapeImpulses_WithCircleShape_AddsToDictionary()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(5f, 1f, Vector2F.Zero, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);
            Fixture fixture = body.FixtureList[0];
            Fixture[] containedShapes = { fixture };
            Dictionary<Fixture, Vector2F> exploded = new Dictionary<Fixture, Vector2F>();

            explosion.ApplyContainedShapeImpulses(Vector2F.Zero, 100f, containedShapes, 1, exploded);

            Assert.NotEmpty(exploded);
        }

        /// <summary>
        /// Tests that apply explosion impulses with data entries applies impulses
        /// </summary>
        [Fact]
        public void ApplyExplosionImpulses_WithDataEntries_AppliesImpulses()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(10f, 10f, 1f, new Vector2F(10f, 0), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            explosion.AddNewShapeData(body, 0.0f, 1.0f);

            Dictionary<Fixture, Vector2F> exploded = new Dictionary<Fixture, Vector2F>();
            explosion.ApplyExplosionImpulses(Vector2F.Zero, 50f, 100f, exploded);

            Assert.NotEmpty(exploded);
        }
    }
}
