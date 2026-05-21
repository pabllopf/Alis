

using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IOnStart interface.
    ///     Tests the OnStart lifecycle method invocation.
    /// </summary>
    public class IOnStartTest
    {
        /// <summary>
        ///     Tests that IOnStart can be implemented.
        /// </summary>
        [Fact]
        public void IOnStart_CanBeImplemented()
        {
            StartHandler handler = new StartHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnStart>(handler);
        }

        /// <summary>
        ///     Tests that OnStart method can be called.
        /// </summary>
        [Fact]
        public void OnStart_CanBeCalled()
        {
            StartHandler handler = new StartHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnStart(gameObject);
            Assert.True(handler.WasStartCalled);
        }

        /// <summary>
        ///     Tests that OnStart increments call count correctly.
        /// </summary>
        [Fact]
        public void OnStart_IncrementCallCount()
        {
            StartHandler handler = new StartHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnStart(gameObject);
            Assert.Equal(1, handler.CallCount);
            handler.OnStart(gameObject);
            Assert.Equal(2, handler.CallCount);
        }

        /// <summary>
        ///     Tests that OnStart ignores null game object gracefully.
        /// </summary>
        [Fact]
        public void OnStart_CanBeCalledWithGameObject()
        {
            StartHandler handler = new StartHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnStart(gameObject);
            Assert.True(handler.WasStartCalled);
        }


        /// <summary>
        ///     Helper implementation for testing IOnStart.
        /// </summary>
        private class StartHandler : IOnStart
        {
            /// <summary>
            ///     Gets or sets the value of the was start called
            /// </summary>
            public bool WasStartCalled { get; private set; }

            /// <summary>
            ///     Gets or sets the value of the call count
            /// </summary>
            public int CallCount { get; private set; }

            /// <summary>
            ///     Ons the start using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnStart(IGameObject self)
            {
                WasStartCalled = true;
                CallCount++;
            }
        }
    }
}