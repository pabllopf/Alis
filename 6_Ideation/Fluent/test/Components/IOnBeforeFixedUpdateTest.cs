

using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IOnBeforeFixedUpdate lifecycle contract.
    /// </summary>
    public class IOnBeforeFixedUpdateTest
    {
        /// <summary>
        ///     Tests that IOnBeforeFixedUpdate can be implemented.
        /// </summary>
        [Fact]
        public void IOnBeforeFixedUpdate_CanBeImplemented()
        {
            BeforeFixedUpdateHandler handler = new BeforeFixedUpdateHandler();

            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnBeforeFixedUpdate>(handler);
        }

        /// <summary>
        ///     Tests that OnBeforeFixedUpdate can be called multiple times.
        /// </summary>
        [Fact]
        public void OnBeforeFixedUpdate_CountsCalls()
        {
            BeforeFixedUpdateHandler handler = new BeforeFixedUpdateHandler();
            MockGameObject gameObject = new MockGameObject();

            handler.OnBeforeFixedUpdate(gameObject);
            handler.OnBeforeFixedUpdate(gameObject);
            handler.OnBeforeFixedUpdate(gameObject);

            Assert.Equal(3, handler.CallCount);
        }

        /// <summary>
        ///     Test implementation for IOnBeforeFixedUpdate.
        /// </summary>
        private sealed class BeforeFixedUpdateHandler : IOnBeforeFixedUpdate
        {
            /// <summary>
            ///     Gets the number of times this lifecycle hook was called.
            /// </summary>
            public int CallCount { get; private set; }

            /// <summary>
            ///     Invokes pre-fixed-update behavior.
            /// </summary>
            /// <param name="self">The owning game object.</param>
            public void OnBeforeFixedUpdate(IGameObject self)
            {
                CallCount++;
            }
        }
    }
}
