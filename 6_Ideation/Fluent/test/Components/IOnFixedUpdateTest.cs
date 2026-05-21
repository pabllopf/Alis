

using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IOnFixedUpdate interface.
    ///     Tests the OnFixedUpdate lifecycle method for physics updates.
    /// </summary>
    public class IOnFixedUpdateTest
    {
        /// <summary>
        ///     Tests that IOnFixedUpdate can be implemented.
        /// </summary>
        [Fact]
        public void IOnFixedUpdate_CanBeImplemented()
        {
            FixedUpdateHandler handler = new FixedUpdateHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnFixedUpdate>(handler);
        }

        /// <summary>
        ///     Tests that OnFixedUpdate method can be called.
        /// </summary>
        [Fact]
        public void OnFixedUpdate_CanBeCalled()
        {
            FixedUpdateHandler handler = new FixedUpdateHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnFixedUpdate(gameObject);
            Assert.Equal(1, handler.CallCount);
        }

        /// <summary>
        ///     Tests that OnFixedUpdate counts physics frames correctly.
        /// </summary>
        [Fact]
        public void OnFixedUpdate_CountsPhysicsFrames()
        {
            FixedUpdateHandler handler = new FixedUpdateHandler();
            MockGameObject gameObject = new MockGameObject();
            for (int i = 0; i < 60; i++)
            {
                handler.OnFixedUpdate(gameObject);
            }

            Assert.Equal(60, handler.CallCount);
        }


        /// <summary>
        ///     Helper implementation for testing IOnFixedUpdate.
        /// </summary>
        private class FixedUpdateHandler : IOnFixedUpdate
        {
            /// <summary>
            ///     Gets or sets the value of the call count
            /// </summary>
            public int CallCount { get; private set; }

            /// <summary>
            ///     Ons the fixed update using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnFixedUpdate(IGameObject self)
            {
                CallCount++;
            }
        }
    }
}