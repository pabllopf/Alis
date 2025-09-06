using Xunit;
using Alis.Extension.Graphic.Sfml.Render;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The drawable tests class
    /// </summary>
    public class IDrawableTests
    {
        /// <summary>
        /// The dummy drawable class
        /// </summary>
        /// <seealso cref="IDrawable"/>
        private class DummyDrawable : IDrawable
        {
            /// <summary>
            /// Gets or sets the value of the was drawn
            /// </summary>
            public bool WasDrawn { get; private set; }
            /// <summary>
            /// Draws the target
            /// </summary>
            /// <param name="target">The target</param>
            /// <param name="states">The states</param>
            public void Draw(IRenderTarget target, RenderStates states)
            {
                WasDrawn = true;
            }
        }

        /// <summary>
        /// Tests that draw can be called
        /// </summary>
        [Fact]
        public void Draw_CanBeCalled()
        {
            DummyDrawable drawable = new DummyDrawable();
            drawable.Draw(null, default);
            Assert.True(drawable.WasDrawn);
        }
    }
}

