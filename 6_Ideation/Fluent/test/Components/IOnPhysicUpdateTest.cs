

using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IOnPhysicUpdate interface.
    ///     Tests the OnPhysicUpdate lifecycle method for physics simulation.
    /// </summary>
    public class IOnPhysicUpdateTest
    {
        /// <summary>
        ///     Tests that IOnPhysicUpdate can be implemented.
        /// </summary>
        [Fact]
        public void IOnPhysicUpdate_CanBeImplemented()
        {
            PhysicUpdateHandler handler = new PhysicUpdateHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnPhysicUpdate>(handler);
        }

        /// <summary>
        ///     Tests that OnPhysicUpdate method can be called.
        /// </summary>
        [Fact]
        public void OnPhysicUpdate_CanBeCalled()
        {
            PhysicUpdateHandler handler = new PhysicUpdateHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnPhysicUpdate(gameObject);
            Assert.Equal(1, handler.UpdateCount);
        }

        /// <summary>
        ///     Tests that OnPhysicUpdate counts physics steps.
        /// </summary>
        [Fact]
        public void OnPhysicUpdate_CountsPhysicsSteps()
        {
            PhysicUpdateHandler handler = new PhysicUpdateHandler();
            MockGameObject gameObject = new MockGameObject();
            for (int i = 0; i < 50; i++)
            {
                handler.OnPhysicUpdate(gameObject);
            }

            Assert.Equal(50, handler.UpdateCount);
        }


        /// <summary>
        ///     Helper implementation for testing IOnPhysicUpdate.
        /// </summary>
        private class PhysicUpdateHandler : IOnPhysicUpdate
        {
            /// <summary>
            ///     Gets or sets the value of the update count
            /// </summary>
            public int UpdateCount { get; private set; }

            /// <summary>
            ///     Ons the physic update using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnPhysicUpdate(IGameObject self)
            {
                UpdateCount++;
            }
        }
    }
}