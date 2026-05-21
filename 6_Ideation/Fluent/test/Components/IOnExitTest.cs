

using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IOnExit interface.
    ///     Tests the OnExit lifecycle method for cleanup on scene exit.
    /// </summary>
    public class IOnExitTest
    {
        /// <summary>
        ///     Tests that IOnExit can be implemented.
        /// </summary>
        [Fact]
        public void IOnExit_CanBeImplemented()
        {
            ExitHandler handler = new ExitHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnExit>(handler);
        }

        /// <summary>
        ///     Tests that OnExit method can be called.
        /// </summary>
        [Fact]
        public void OnExit_CanBeCalled()
        {
            ExitHandler handler = new ExitHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnExit(gameObject);
            Assert.True(handler.WasExitCalled);
        }

        /// <summary>
        ///     Tests that OnExit counts invocations.
        /// </summary>
        [Fact]
        public void OnExit_CountsInvocations()
        {
            ExitHandler handler = new ExitHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnExit(gameObject);
            Assert.Equal(1, handler.ExitCount);
            handler.OnExit(gameObject);
            Assert.Equal(2, handler.ExitCount);
        }


        /// <summary>
        ///     Helper implementation for testing IOnExit.
        /// </summary>
        private class ExitHandler : IOnExit
        {
            /// <summary>
            ///     Gets or sets the value of the was exit called
            /// </summary>
            public bool WasExitCalled { get; private set; }

            /// <summary>
            ///     Gets or sets the value of the exit count
            /// </summary>
            public int ExitCount { get; private set; }

            /// <summary>
            ///     Ons the exit using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnExit(IGameObject self)
            {
                WasExitCalled = true;
                ExitCount++;
            }
        }
    }
}