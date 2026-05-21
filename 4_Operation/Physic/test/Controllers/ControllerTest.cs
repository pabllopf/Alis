

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common.Logic;
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Controllers
{
    /// <summary>
    ///     The controller test class
    /// </summary>
    public class ControllerTest
    {
        /// <summary>
        ///     Tests that controller should initialize with enabled true
        /// </summary>
        [Fact]
        public void Controller_ShouldInitializeWithEnabledTrue()
        {
            TestController controller = new TestController();

            Assert.True(controller.Enabled);
        }

        /// <summary>
        ///     Tests that controller should have controller category
        /// </summary>
        [Fact]
        public void Controller_ShouldHaveControllerCategory()
        {
            TestController controller = new TestController();

            Assert.Equal(ControllerCategory.Cat01, controller.ControllerCategory);
        }

        /// <summary>
        ///     Tests that enabled property should set and get correctly
        /// </summary>
        [Fact]
        public void EnabledProperty_ShouldSetAndGetCorrectly()
        {
            TestController controller = new TestController();

            controller.Enabled = false;

            Assert.False(controller.Enabled);
        }

        /// <summary>
        ///     Tests that world physic property should set correctly
        /// </summary>
        [Fact]
        public void WorldPhysicProperty_ShouldSetCorrectly()
        {
            TestController controller = new TestController();
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));

            controller.WorldPhysic = world;

            Assert.NotNull(controller.WorldPhysic);
            Assert.Equal(world, controller.WorldPhysic);
        }

        /// <summary>
        ///     Tests that update should be callable
        /// </summary>
        [Fact]
        public void Update_ShouldBeCallable()
        {
            TestController controller = new TestController();

            controller.Update(0.016f);

            Assert.True(controller.UpdateCalled);
        }

        /// <summary>
        ///     Tests that is active on should return false when controller ignored
        /// </summary>
        [Fact]
        public void IsActiveOn_ShouldReturnFalse_WhenControllerIgnored()
        {
            TestController controller = new TestController();
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            body.ControllerFilter.IgnoreController(controller.ControllerCategory);

            bool isActive = controller.IsActiveOn(body);

            Assert.False(isActive);
        }

        /// <summary>
        ///     Tests that controller should inherit from filter data
        /// </summary>
        [Fact]
        public void Controller_ShouldInheritFromFilterData()
        {
            TestController controller = new TestController();

            Assert.IsAssignableFrom<FilterData>(controller);
        }

        /// <summary>
        ///     Tests that controller should be abstract class
        /// </summary>
        [Fact]
        public void Controller_ShouldBeAbstractClass()
        {
            Type type = typeof(Controller);

            Assert.True(type.IsAbstract);
        }

        /// <summary>
        ///     The test controller class
        /// </summary>
        /// <seealso cref="Controller" />
        private class TestController : Controller
        {
            /// <summary>
            ///     The update called
            /// </summary>
            public bool UpdateCalled { get; private set; }

            /// <summary>
            ///     Updates the dt
            /// </summary>
            /// <param name="dt">The dt</param>
            public override void Update(float dt)
            {
                UpdateCalled = true;
            }
        }
    }
}