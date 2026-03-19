using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The controller delegate test class
    /// </summary>
    public class ControllerDelegateTest
    {
        /// <summary>
        /// Tests that delegate should be invokable
        /// </summary>
        [Fact]
        public void Delegate_ShouldBeInvokable()
        {
            WorldPhysic capturedWorld = null;
            Controller capturedController = null;
            ControllerDelegate callback = (world, controller) =>
            {
                capturedWorld = world;
                capturedController = controller;
            };

            WorldPhysic sender = new WorldPhysic(Vector2F.Zero);
            GravityController controllerArg = new GravityController(1.0f);

            callback(sender, controllerArg);

            Assert.Equal(sender, capturedWorld);
            Assert.Equal(controllerArg, capturedController);
        }
    }
}

