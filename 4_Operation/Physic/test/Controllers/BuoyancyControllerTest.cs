

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Controllers
{
    /// <summary>
    ///     The buoyancy controller test class
    /// </summary>
    public class BuoyancyControllerTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with valid parameters
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithValidParameters()
        {
            Aabb container = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            float density = 1.0f;
            float linearDrag = 2.0f;
            float angularDrag = 1.0f;
            Vector2F gravity = new Vector2F(0, -10);

            BuoyancyController controller = new BuoyancyController(container, density, linearDrag, angularDrag, gravity);

            Assert.NotNull(controller);
            Assert.Equal(density, controller.Density);
            Assert.Equal(linearDrag, controller.LinearDragCoefficient);
            Assert.Equal(angularDrag, controller.AngularDragCoefficient);
        }

        /// <summary>
        ///     Tests that container property should set and get correctly
        /// </summary>
        [Fact]
        public void ContainerProperty_ShouldSetAndGetCorrectly()
        {
            Aabb container = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            BuoyancyController controller = new BuoyancyController(container, 1.0f, 1.0f, 1.0f, new Vector2F(0, -10));

            Aabb newContainer = new Aabb(new Vector2F(-5, -5), new Vector2F(15, 15));
            controller.Container = newContainer;

            Assert.Equal(newContainer.LowerBound, controller.Container.LowerBound);
            Assert.Equal(newContainer.UpperBound, controller.Container.UpperBound);
        }

        /// <summary>
        ///     Tests that velocity property should set and get correctly
        /// </summary>
        [Fact]
        public void VelocityProperty_ShouldSetAndGetCorrectly()
        {
            Aabb container = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            BuoyancyController controller = new BuoyancyController(container, 1.0f, 1.0f, 1.0f, new Vector2F(0, -10));

            controller.Velocity = new Vector2F(5, 0);

            Assert.Equal(new Vector2F(5, 0), controller.Velocity);
        }

        /// <summary>
        ///     Tests that update should execute without errors
        /// </summary>
        [Fact]
        public void Update_ShouldExecuteWithoutErrors()
        {
            Aabb container = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            BuoyancyController controller = new BuoyancyController(container, 1.0f, 1.0f, 1.0f, new Vector2F(0, -10));
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            controller.WorldPhysic = world;

            controller.Update(0.016f);

            Assert.True(true); // No exception thrown
        }

        /// <summary>
        ///     Tests that buoyancy controller should handle zero density
        /// </summary>
        [Fact]
        public void BuoyancyController_ShouldHandleZeroDensity()
        {
            Aabb container = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            BuoyancyController controller = new BuoyancyController(container, 0.0f, 1.0f, 1.0f, new Vector2F(0, -10));

            Assert.Equal(0.0f, controller.Density);
        }

        /// <summary>
        ///     Tests that buoyancy controller should handle negative drag coefficients
        /// </summary>
        [Fact]
        public void BuoyancyController_ShouldHandleNegativeDragCoefficients()
        {
            Aabb container = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            BuoyancyController controller = new BuoyancyController(container, 1.0f, -1.0f, -1.0f, new Vector2F(0, -10));

            Assert.Equal(-1.0f, controller.LinearDragCoefficient);
            Assert.Equal(-1.0f, controller.AngularDragCoefficient);
        }

        /// <summary>
        ///     Tests that buoyancy controller should support high density values
        /// </summary>
        [Fact]
        public void BuoyancyController_ShouldSupportHighDensityValues()
        {
            Aabb container = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            BuoyancyController controller = new BuoyancyController(container, 1000.0f, 1.0f, 1.0f, new Vector2F(0, -10));

            Assert.Equal(1000.0f, controller.Density);
        }

        /// <summary>
        ///     Tests that update should handle empty world
        /// </summary>
        [Fact]
        public void Update_ShouldHandleEmptyWorld()
        {
            Aabb container = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            BuoyancyController controller = new BuoyancyController(container, 1.0f, 1.0f, 1.0f, new Vector2F(0, -10));
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            controller.WorldPhysic = world;

            controller.Update(0.016f);

            Assert.True(true); // No exception thrown
        }

        /// <summary>
        ///     Tests that buoyancy controller should inherit from controller
        /// </summary>
        [Fact]
        public void BuoyancyController_ShouldInheritFromController()
        {
            Aabb container = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            BuoyancyController controller = new BuoyancyController(container, 1.0f, 1.0f, 1.0f, new Vector2F(0, -10));

            Assert.IsAssignableFrom<Controller>(controller);
        }
    }
}