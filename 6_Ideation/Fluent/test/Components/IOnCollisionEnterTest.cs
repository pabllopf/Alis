

using System;
using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IOnCollisionEnter interface.
    ///     Tests the OnCollisionEnter lifecycle method for collision detection.
    /// </summary>
    public class IOnCollisionEnterTest
    {
        /// <summary>
        ///     Tests that IOnCollisionEnter can be implemented.
        /// </summary>
        [Fact]
        public void IOnCollisionEnter_CanBeImplemented()
        {
            CollisionEnterHandler handler = new CollisionEnterHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnCollisionEnter>(handler);
        }

        /// <summary>
        ///     Tests that OnCollisionEnter method can be called.
        /// </summary>
        [Fact]
        public void OnCollisionEnter_CanBeCalled()
        {
            CollisionEnterHandler handler = new CollisionEnterHandler();
            MockGameObject self = new MockGameObject();
            MockGameObject collision = new MockGameObject();
            handler.OnCollisionEnter(self, collision);
            Assert.Equal(1, handler.CollisionCount);
        }

        /// <summary>
        ///     Tests that OnCollisionEnter records collider.
        /// </summary>
        [Fact]
        public void OnCollisionEnter_RecordsCollider()
        {
            CollisionEnterHandler handler = new CollisionEnterHandler();
            MockGameObject self = new MockGameObject();
            MockGameObject collision = new MockGameObject();
            handler.OnCollisionEnter(self, collision);
            Assert.Same(collision, handler.LastCollider);
        }

        /// <summary>
        ///     Tests multiple collision events.
        /// </summary>
        [Fact]
        public void OnCollisionEnter_HandlesMultipleCollisions()
        {
            CollisionEnterHandler handler = new CollisionEnterHandler();
            MockGameObject self = new MockGameObject();
            MockGameObject collision1 = new MockGameObject();
            MockGameObject collision2 = new MockGameObject();
            handler.OnCollisionEnter(self, collision1);
            handler.OnCollisionEnter(self, collision2);
            Assert.Equal(2, handler.CollisionCount);
            Assert.Same(collision2, handler.LastCollider);
        }


        /// <summary>
        ///     Helper implementation for testing IOnCollisionEnter.
        /// </summary>
        private class CollisionEnterHandler : IOnCollisionEnter
        {
            /// <summary>
            ///     Gets or sets the value of the collision count
            /// </summary>
            public int CollisionCount { get; private set; }

            /// <summary>
            ///     Gets or sets the value of the last collider
            /// </summary>
            public IGameObject LastCollider { get; private set; }

            /// <summary>
            ///     Ons the collision enter using the specified other
            /// </summary>
            /// <param name="other">The other</param>
            /// <exception cref="NotImplementedException"></exception>
            public void OnCollisionEnter(IGameObject other)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            ///     Ons the collision enter using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            /// <param name="collision">The collision</param>
            public void OnCollisionEnter(IGameObject self, IGameObject collision)
            {
                CollisionCount++;
                LastCollider = collision;
            }
        }
    }
}