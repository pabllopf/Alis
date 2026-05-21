

using System;
using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IOnCollisionExit interface.
    ///     Tests the OnCollisionExit lifecycle method for collision end detection.
    /// </summary>
    public class IOnCollisionExitTest
    {
        /// <summary>
        ///     Tests that IOnCollisionExit can be implemented.
        /// </summary>
        [Fact]
        public void IOnCollisionExit_CanBeImplemented()
        {
            CollisionExitHandler handler = new CollisionExitHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnCollisionExit>(handler);
        }

        /// <summary>
        ///     Tests that OnCollisionExit method can be called.
        /// </summary>
        [Fact]
        public void OnCollisionExit_CanBeCalled()
        {
            CollisionExitHandler handler = new CollisionExitHandler();
            MockGameObject self = new MockGameObject();
            MockGameObject collision = new MockGameObject();
            handler.OnCollisionExit(self, collision);
            Assert.Equal(1, handler.ExitCount);
        }

        /// <summary>
        ///     Tests that OnCollisionExit counts exits.
        /// </summary>
        [Fact]
        public void OnCollisionExit_CountsExits()
        {
            CollisionExitHandler handler = new CollisionExitHandler();
            MockGameObject self = new MockGameObject();
            MockGameObject collision = new MockGameObject();
            handler.OnCollisionExit(self, collision);
            handler.OnCollisionExit(self, collision);
            Assert.Equal(2, handler.ExitCount);
        }


        /// <summary>
        ///     Helper implementation for testing IOnCollisionExit.
        /// </summary>
        private class CollisionExitHandler : IOnCollisionExit
        {
            /// <summary>
            ///     Gets or sets the value of the exit count
            /// </summary>
            public int ExitCount { get; private set; }

            /// <summary>
            ///     Ons the collision exit using the specified other
            /// </summary>
            /// <param name="other">The other</param>
            /// <exception cref="NotImplementedException"></exception>
            public void OnCollisionExit(IGameObject other)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            ///     Ons the collision exit using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            /// <param name="collision">The collision</param>
            public void OnCollisionExit(IGameObject self, IGameObject collision)
            {
                ExitCount++;
            }
        }
    }
}