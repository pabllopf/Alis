

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Controllers
{
    /// <summary>
    ///     The velocity limit controller test class
    /// </summary>
    public class VelocityLimitControllerTest
    {
        /// <summary>
        ///     Tests that default constructor should initialize with default limits
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeWithDefaultLimits()
        {
            VelocityLimitController controller = new VelocityLimitController();

            Assert.True(controller.MaxLinearVelocity > 0);
            Assert.True(controller.MaxAngularVelocity > 0);
            Assert.True(controller.LimitLinearVelocity);
            Assert.True(controller.LimitAngularVelocity);
        }

        /// <summary>
        ///     Tests that constructor with parameters should initialize correctly
        /// </summary>
        [Fact]
        public void ConstructorWithParameters_ShouldInitializeCorrectly()
        {
            float maxLinear = 50.0f;
            float maxAngular = 10.0f;

            VelocityLimitController controller = new VelocityLimitController(maxLinear, maxAngular);

            Assert.Equal(maxLinear, controller.MaxLinearVelocity);
            Assert.Equal(maxAngular, controller.MaxAngularVelocity);
        }

        /// <summary>
        ///     Tests that constructor with zero linear velocity should disable linear limit
        /// </summary>
        [Fact]
        public void ConstructorWithZeroLinearVelocity_ShouldDisableLinearLimit()
        {
            VelocityLimitController controller = new VelocityLimitController(0.0f, 10.0f);

            Assert.False(controller.LimitLinearVelocity);
        }

        /// <summary>
        ///     Tests that constructor with zero angular velocity should disable angular limit
        /// </summary>
        [Fact]
        public void ConstructorWithZeroAngularVelocity_ShouldDisableAngularLimit()
        {
            VelocityLimitController controller = new VelocityLimitController(50.0f, 0.0f);

            Assert.False(controller.LimitAngularVelocity);
        }

        /// <summary>
        ///     Tests that constructor with max float values should disable limits
        /// </summary>
        [Fact]
        public void ConstructorWithMaxFloatValues_ShouldDisableLimits()
        {
            VelocityLimitController controller = new VelocityLimitController(float.MaxValue, float.MaxValue);

            Assert.False(controller.LimitLinearVelocity);
            Assert.False(controller.LimitAngularVelocity);
        }

        /// <summary>
        ///     Tests that max linear velocity property should set and get correctly
        /// </summary>
        [Fact]
        public void MaxLinearVelocityProperty_ShouldSetAndGetCorrectly()
        {
            VelocityLimitController controller = new VelocityLimitController();

            controller.MaxLinearVelocity = 100.0f;

            Assert.Equal(100.0f, controller.MaxLinearVelocity);
        }

        /// <summary>
        ///     Tests that max angular velocity property should set and get correctly
        /// </summary>
        [Fact]
        public void MaxAngularVelocityProperty_ShouldSetAndGetCorrectly()
        {
            VelocityLimitController controller = new VelocityLimitController();

            controller.MaxAngularVelocity = 20.0f;

            Assert.Equal(20.0f, controller.MaxAngularVelocity);
        }

        /// <summary>
        ///     Tests that update should execute without errors
        /// </summary>
        [Fact]
        public void Update_ShouldExecuteWithoutErrors()
        {
            VelocityLimitController controller = new VelocityLimitController();
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            controller.WorldPhysic = world;

            controller.Update(0.016f);

            Assert.True(true); // No exception thrown
        }

        /// <summary>
        ///     Tests that velocity limit controller should inherit from controller
        /// </summary>
        [Fact]
        public void VelocityLimitController_ShouldInheritFromController()
        {
            VelocityLimitController controller = new VelocityLimitController();

            Assert.IsAssignableFrom<Controller>(controller);
        }

        /// <summary>
        ///     Tests that velocity limit controller should handle negative velocities
        /// </summary>
        [Fact]
        public void VelocityLimitController_ShouldHandleNegativeVelocities()
        {
            VelocityLimitController controller = new VelocityLimitController(-50.0f, -10.0f);

            Assert.Equal(-50.0f, controller.MaxLinearVelocity);
            Assert.Equal(-10.0f, controller.MaxAngularVelocity);
        }
    }
}