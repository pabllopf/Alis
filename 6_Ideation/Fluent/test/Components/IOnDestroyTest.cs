

using System;
using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IOnDestroy interface.
    ///     Tests the OnDestroy lifecycle method for cleanup.
    /// </summary>
    public class IOnDestroyTest
    {
        /// <summary>
        ///     Tests that IOnDestroy can be implemented.
        /// </summary>
        [Fact]
        public void IOnDestroy_CanBeImplemented()
        {
            DestroyHandler handler = new DestroyHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnDestroy>(handler);
        }

        /// <summary>
        ///     Tests that OnDestroy method can be called.
        /// </summary>
        [Fact]
        public void OnDestroy_CanBeCalled()
        {
            DestroyHandler handler = new DestroyHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnDestroy(gameObject);
            Assert.True(handler.WasDestroyCalled);
        }

        /// <summary>
        ///     Tests that OnDestroy records call count.
        /// </summary>
        [Fact]
        public void OnDestroy_RecordsCallCount()
        {
            DestroyHandler handler = new DestroyHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnDestroy(gameObject);
            Assert.Equal(1, handler.DestroyCount);
        }

        /// <summary>
        ///     Tests that OnDestroy can be called multiple times.
        /// </summary>
        [Fact]
        public void OnDestroy_CanBeCalledMultipleTimes()
        {
            DestroyHandler handler = new DestroyHandler();
            MockGameObject gameObject = new MockGameObject();
            for (int i = 0; i < 5; i++)
            {
                handler.OnDestroy(gameObject);
            }

            Assert.Equal(5, handler.DestroyCount);
        }


        /// <summary>
        ///     Helper implementation for testing IOnDestroy.
        /// </summary>
        private class DestroyHandler : IOnDestroy
        {
            /// <summary>
            ///     Gets or sets the value of the was destroy called
            /// </summary>
            public bool WasDestroyCalled { get; private set; }

            /// <summary>
            ///     Gets or sets the value of the destroy count
            /// </summary>
            public int DestroyCount { get; private set; }

            /// <summary>
            ///     Ons the destroy
            /// </summary>
            /// <exception cref="NotImplementedException"></exception>
            public void OnDestroy()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            ///     Ons the destroy using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnDestroy(IGameObject self)
            {
                WasDestroyCalled = true;
                DestroyCount++;
            }
        }
    }
}