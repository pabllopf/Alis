

using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IOnAwake interface.
    ///     Tests the OnAwake lifecycle method invocation.
    /// </summary>
    public class IOnAwakeTest
    {
        /// <summary>
        ///     Tests that IOnAwake can be implemented.
        /// </summary>
        [Fact]
        public void IOnAwake_CanBeImplemented()
        {
            AwakeHandler handler = new AwakeHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnAwake>(handler);
        }

        /// <summary>
        ///     Tests that OnAwake method can be called.
        /// </summary>
        [Fact]
        public void OnAwake_CanBeCalled()
        {
            AwakeHandler handler = new AwakeHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnAwake(gameObject);
            Assert.True(handler.WasAwakeCalled);
        }

        /// <summary>
        ///     Tests that OnAwake receives correct game object parameter.
        /// </summary>
        [Fact]
        public void OnAwake_ReceivesCorrectGameObject()
        {
            AwakeHandler handler = new AwakeHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnAwake(gameObject);
            Assert.Same(gameObject, handler.LastGameObject);
        }

        /// <summary>
        ///     Tests that OnAwake can be called multiple times.
        /// </summary>
        [Fact]
        public void OnAwake_CanBeCalledMultipleTimes()
        {
            AwakeHandler handler = new AwakeHandler();
            MockGameObject gameObject1 = new MockGameObject();
            MockGameObject gameObject2 = new MockGameObject();
            handler.OnAwake(gameObject1);
            handler.OnAwake(gameObject2);
            Assert.True(handler.WasAwakeCalled);
            Assert.Same(gameObject2, handler.LastGameObject);
        }


        /// <summary>
        ///     Helper implementation for testing IOnAwake.
        /// </summary>
        private class AwakeHandler : IOnAwake
        {
            /// <summary>
            ///     Gets or sets the value of the was awake called
            /// </summary>
            public bool WasAwakeCalled { get; private set; }

            /// <summary>
            ///     Gets or sets the value of the last game object
            /// </summary>
            public IGameObject LastGameObject { get; private set; }

            /// <summary>
            ///     Ons the awake using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnAwake(IGameObject self)
            {
                WasAwakeCalled = true;
                LastGameObject = self;
            }
        }
    }
}