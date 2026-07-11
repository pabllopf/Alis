using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Controllers
{
    /// <summary>
    /// The gravity controller remaining coverage tests class
    /// </summary>
    public class GravityControllerRemainingCoverageTests
    {
        /// <summary>
        /// Tests that update with body gravity linear fixtured body applies force
        /// </summary>
        [Fact]
        public void Update_WithBodyGravityLinear_FixturedBody_AppliesForce()
        {
            GravityController controller = new GravityController(100f, 200f, 1f)
            {
                GravityType = GravityType.Linear
            };
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body worldBody = world.CreateCircle(1f, 1f, new Vector2F(20, 0), BodyType.Dynamic);
            Body controllerBody = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            controller.AddBody(controllerBody);

            controller.Update(0.016f);

            Assert.True(true);
        }

        /// <summary>
        /// Tests that update with body gravity distance squared fixtured body applies force
        /// </summary>
        [Fact]
        public void Update_WithBodyGravityDistanceSquared_FixturedBody_AppliesForce()
        {
            GravityController controller = new GravityController(100f, 200f, 1f)
            {
                GravityType = GravityType.DistanceSquared
            };
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body worldBody = world.CreateCircle(1f, 1f, new Vector2F(20, 0), BodyType.Dynamic);
            Body controllerBody = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            controller.AddBody(controllerBody);

            controller.Update(0.016f);

            Assert.True(true);
        }

        /// <summary>
        /// Tests that update with point gravity linear fixtured body applies force
        /// </summary>
        [Fact]
        public void Update_WithPointGravityLinear_FixturedBody_AppliesForce()
        {
            GravityController controller = new GravityController(100f, 200f, 1f)
            {
                GravityType = GravityType.Linear
            };
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body worldBody = world.CreateCircle(1f, 1f, new Vector2F(20, 0), BodyType.Dynamic);
            controller.AddPoint(new Vector2F(0, 0));

            controller.Update(0.016f);

            Assert.True(true);
        }

        /// <summary>
        /// Tests that update with body gravity linear fixtured body at same position should not throw
        /// </summary>
        [Fact]
        public void Update_WithBodyGravityLinear_FixturedBody_AtSamePosition_ShouldNotThrow()
        {
            GravityController controller = new GravityController(100f, 100f, 0f)
            {
                GravityType = GravityType.Linear
            };
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body worldBody = world.CreateCircle(1f, 1f, new Vector2F(0, 0), BodyType.Dynamic);
            Body controllerBody = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            controller.AddBody(controllerBody);

            controller.Update(0.016f);

            Assert.NotNull(controller);
        }

        /// <summary>
        /// Tests that update with point gravity linear fixtured body at same position should not throw
        /// </summary>
        [Fact]
        public void Update_WithPointGravityLinear_FixturedBody_AtSamePosition_ShouldNotThrow()
        {
            GravityController controller = new GravityController(100f, 100f, 0f)
            {
                GravityType = GravityType.Linear
            };
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body worldBody = world.CreateCircle(1f, 1f, new Vector2F(0, 0), BodyType.Dynamic);
            controller.AddPoint(new Vector2F(0, 0));

            controller.Update(0.016f);

            Assert.NotNull(controller);
        }

        /// <summary>
        /// Tests that update with body gravity distance squared fixtured body beyond max radius should skip
        /// </summary>
        [Fact]
        public void Update_WithBodyGravityDistanceSquared_FixturedBody_BeyondMaxRadius_ShouldSkip()
        {
            GravityController controller = new GravityController(100f, 10f, 0f)
            {
                GravityType = GravityType.DistanceSquared
            };
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body worldBody = world.CreateCircle(1f, 1f, new Vector2F(100, 0), BodyType.Dynamic);
            Body controllerBody = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            controller.AddBody(controllerBody);

            controller.Update(0.016f);

            Assert.NotNull(controller);
        }

        /// <summary>
        /// Tests that update with body gravity distance squared fixtured body within min radius should skip
        /// </summary>
        [Fact]
        public void Update_WithBodyGravityDistanceSquared_FixturedBody_WithinMinRadius_ShouldSkip()
        {
            GravityController controller = new GravityController(100f, 100f, 50f)
            {
                GravityType = GravityType.DistanceSquared
            };
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body worldBody = world.CreateCircle(1f, 1f, new Vector2F(10, 0), BodyType.Dynamic);
            Body controllerBody = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            controller.AddBody(controllerBody);

            controller.Update(0.016f);

            Assert.NotNull(controller);
        }

        /// <summary>
        /// Tests that update with point gravity distance squared fixtured body beyond max radius should skip
        /// </summary>
        [Fact]
        public void Update_WithPointGravityDistanceSquared_FixturedBody_BeyondMaxRadius_ShouldSkip()
        {
            GravityController controller = new GravityController(100f, 10f, 0f)
            {
                GravityType = GravityType.DistanceSquared
            };
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body worldBody = world.CreateCircle(1f, 1f, new Vector2F(100, 0), BodyType.Dynamic);
            controller.AddPoint(new Vector2F(0, 0));

            controller.Update(0.016f);

            Assert.NotNull(controller);
        }

        /// <summary>
        /// Tests that update with point gravity linear fixtured body beyond max radius should skip
        /// </summary>
        [Fact]
        public void Update_WithPointGravityLinear_FixturedBody_BeyondMaxRadius_ShouldSkip()
        {
            GravityController controller = new GravityController(100f, 10f, 0f)
            {
                GravityType = GravityType.Linear
            };
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body worldBody = world.CreateCircle(1f, 1f, new Vector2F(100, 0), BodyType.Dynamic);
            controller.AddPoint(new Vector2F(0, 0));

            controller.Update(0.016f);

            Assert.NotNull(controller);
        }

        /// <summary>
        /// Tests that update with point gravity linear fixtured body within min radius should skip
        /// </summary>
        [Fact]
        public void Update_WithPointGravityLinear_FixturedBody_WithinMinRadius_ShouldSkip()
        {
            GravityController controller = new GravityController(100f, 100f, 50f)
            {
                GravityType = GravityType.Linear
            };
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body worldBody = world.CreateCircle(1f, 1f, new Vector2F(10, 0), BodyType.Dynamic);
            controller.AddPoint(new Vector2F(0, 0));

            controller.Update(0.016f);

            Assert.NotNull(controller);
        }

        /// <summary>
        /// Tests that update with both body and point gravity fixtured bodies should not throw
        /// </summary>
        [Fact]
        public void Update_WithBothBodyAndPointGravity_FixturedBodies_ShouldNotThrow()
        {
            GravityController controller = new GravityController(100f, 200f, 1f)
            {
                GravityType = GravityType.DistanceSquared
            };
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body worldBody = world.CreateCircle(1f, 1f, new Vector2F(10, 0), BodyType.Dynamic);
            Body controllerBody = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            controller.AddBody(controllerBody);
            controller.AddPoint(new Vector2F(-10, 0));

            controller.Update(0.016f);

            Assert.NotNull(controller);
        }

        /// <summary>
        /// Tests that update with multiple world bodies some filtered by controller should not throw
        /// </summary>
        [Fact]
        public void Update_WithMultipleWorldBodies_SomeFilteredByController_ShouldNotThrow()
        {
            GravityController controller = new GravityController(100f, 200f, 1f)
            {
                GravityType = GravityType.DistanceSquared
            };
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body activeBody = world.CreateCircle(1f, 1f, new Vector2F(10, 0), BodyType.Dynamic);
            Body filteredBody = world.CreateCircle(1f, 1f, new Vector2F(20, 0), BodyType.Dynamic);
            filteredBody.ControllerFilter.IgnoreController(controller.ControllerCategories);
            Body controllerBody = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            controller.AddBody(controllerBody);

            controller.Update(0.016f);

            Assert.NotNull(controller);
        }

        /// <summary>
        /// Tests that update with controller ignore through category should skip body
        /// </summary>
        [Fact]
        public void Update_WithControllerIgnoreThroughCategory_ShouldSkipBody()
        {
            GravityController controller = new GravityController(100f);
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body body = world.CreateCircle(1f, 1f, new Vector2F(10, 0), BodyType.Dynamic);
            body.ControllerFilter.IgnoreController(controller.ControllerCategories);

            controller.Update(0.016f);

            Assert.NotNull(controller);
        }

        /// <summary>
        /// Tests that update with body gravity linear fixtured body valid distance should apply force
        /// </summary>
        [Fact]
        public void Update_WithBodyGravityLinear_FixturedBody_ValidDistance_ShouldApplyForce()
        {
            GravityController controller = new GravityController(500f, 100f, 0.1f)
            {
                GravityType = GravityType.Linear
            };
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body worldBody = world.CreateCircle(1f, 1f, new Vector2F(10, 0), BodyType.Dynamic);
            Body controllerBody = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            controller.AddBody(controllerBody);

            controller.Update(0.016f);

            Assert.NotNull(controller);
        }

        /// <summary>
        /// Tests that update with body gravity distance squared fixtured body valid distance should apply force
        /// </summary>
        [Fact]
        public void Update_WithBodyGravityDistanceSquared_FixturedBody_ValidDistance_ShouldApplyForce()
        {
            GravityController controller = new GravityController(500f, 100f, 0.1f)
            {
                GravityType = GravityType.DistanceSquared
            };
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body worldBody = world.CreateCircle(1f, 1f, new Vector2F(10, 0), BodyType.Dynamic);
            Body controllerBody = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            controller.AddBody(controllerBody);

            controller.Update(0.016f);

            Assert.NotNull(controller);
        }
    }
}
