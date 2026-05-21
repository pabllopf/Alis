

using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IOnDraw interface.
    ///     Tests the OnDraw lifecycle method for rendering.
    /// </summary>
    public class IOnDrawTest
    {
        /// <summary>
        ///     Tests that IOnDraw can be implemented.
        /// </summary>
        [Fact]
        public void IOnDraw_CanBeImplemented()
        {
            DrawHandler handler = new DrawHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnDraw>(handler);
        }

        /// <summary>
        ///     Tests that OnDraw method can be called.
        /// </summary>
        [Fact]
        public void OnDraw_CanBeCalled()
        {
            DrawHandler handler = new DrawHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnDraw(gameObject);
            Assert.Equal(1, handler.DrawCallCount);
        }

        /// <summary>
        ///     Tests that OnDraw counts rendering frames.
        /// </summary>
        [Fact]
        public void OnDraw_CountsRenderingFrames()
        {
            DrawHandler handler = new DrawHandler();
            MockGameObject gameObject = new MockGameObject();
            for (int i = 0; i < 120; i++)
            {
                handler.OnDraw(gameObject);
            }

            Assert.Equal(120, handler.DrawCallCount);
        }


        /// <summary>
        ///     Helper implementation for testing IOnDraw.
        /// </summary>
        private class DrawHandler : IOnDraw
        {
            /// <summary>
            ///     Gets or sets the value of the draw call count
            /// </summary>
            public int DrawCallCount { get; private set; }

            /// <summary>
            ///     Ons the draw using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnDraw(IGameObject self)
            {
                DrawCallCount++;
            }
        }
    }
}