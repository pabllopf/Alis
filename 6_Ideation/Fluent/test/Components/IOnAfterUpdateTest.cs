

using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IOnAfterUpdate interface.
    ///     Tests the OnAfterUpdate lifecycle method for post-update logic.
    /// </summary>
    public class IOnAfterUpdateTest
    {
        /// <summary>
        ///     Tests that IOnAfterUpdate can be implemented.
        /// </summary>
        [Fact]
        public void IOnAfterUpdate_CanBeImplemented()
        {
            AfterUpdateHandler handler = new AfterUpdateHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnAfterUpdate>(handler);
        }

        /// <summary>
        ///     Tests that OnAfterUpdate method can be called.
        /// </summary>
        [Fact]
        public void OnAfterUpdate_CanBeCalled()
        {
            AfterUpdateHandler handler = new AfterUpdateHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnAfterUpdate(gameObject);
            Assert.Equal(1, handler.CallCount);
        }

        /// <summary>
        ///     Tests that OnAfterUpdate counts calls.
        /// </summary>
        [Fact]
        public void OnAfterUpdate_CountsCalls()
        {
            AfterUpdateHandler handler = new AfterUpdateHandler();
            MockGameObject gameObject = new MockGameObject();
            for (int i = 0; i < 10; i++)
            {
                handler.OnAfterUpdate(gameObject);
            }

            Assert.Equal(10, handler.CallCount);
        }


        /// <summary>
        ///     Helper implementation for testing IOnAfterUpdate.
        /// </summary>
        private class AfterUpdateHandler : IOnAfterUpdate
        {
            /// <summary>
            ///     Gets or sets the value of the call count
            /// </summary>
            public int CallCount { get; private set; }

            /// <summary>
            ///     Ons the after update using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnAfterUpdate(IGameObject self)
            {
                CallCount++;
            }
        }
    }
}