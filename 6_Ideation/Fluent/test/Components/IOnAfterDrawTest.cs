

using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IOnAfterDraw interface.
    ///     Tests the OnAfterDraw lifecycle method for post-render cleanup.
    /// </summary>
    public class IOnAfterDrawTest
    {
        /// <summary>
        ///     Tests that IOnAfterDraw can be implemented.
        /// </summary>
        [Fact]
        public void IOnAfterDraw_CanBeImplemented()
        {
            AfterDrawHandler handler = new AfterDrawHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnAfterDraw>(handler);
        }

        /// <summary>
        ///     Tests that OnAfterDraw method can be called.
        /// </summary>
        [Fact]
        public void OnAfterDraw_CanBeCalled()
        {
            AfterDrawHandler handler = new AfterDrawHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnAfterDraw(gameObject);
            Assert.Equal(1, handler.CallCount);
        }

        /// <summary>
        ///     Tests that OnAfterDraw counts frames.
        /// </summary>
        [Fact]
        public void OnAfterDraw_CountsFrames()
        {
            AfterDrawHandler handler = new AfterDrawHandler();
            MockGameObject gameObject = new MockGameObject();
            for (int i = 0; i < 120; i++)
            {
                handler.OnAfterDraw(gameObject);
            }

            Assert.Equal(120, handler.CallCount);
        }


        /// <summary>
        ///     Helper implementation for testing IOnAfterDraw.
        /// </summary>
        private class AfterDrawHandler : IOnAfterDraw
        {
            /// <summary>
            ///     Gets or sets the value of the call count
            /// </summary>
            public int CallCount { get; private set; }

            /// <summary>
            ///     Ons the after draw using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnAfterDraw(IGameObject self)
            {
                CallCount++;
            }
        }
    }
}