

using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im draw vert test class
    /// </summary>
    public class ImDrawVertTest
    {
        /// <summary>
        ///     Tests that pos should be initialized correctly
        /// </summary>
        [Fact]
        public void Pos_ShouldBeInitializedCorrectly()
        {
            ImDrawVert vert = new ImDrawVert {Pos = new Vector2F(1, 2)};

            Vector2F result = vert.Pos;

            Assert.Equal(new Vector2F(1, 2), result);
        }

        /// <summary>
        ///     Tests that uv should be initialized correctly
        /// </summary>
        [Fact]
        public void Uv_ShouldBeInitializedCorrectly()
        {
            ImDrawVert vert = new ImDrawVert {Uv = new Vector2F(3, 4)};

            Vector2F result = vert.Uv;

            Assert.Equal(new Vector2F(3, 4), result);
        }

        /// <summary>
        ///     Tests that col should be initialized correctly
        /// </summary>
        [Fact]
        public void Col_ShouldBeInitializedCorrectly()
        {
            ImDrawVert vert = new ImDrawVert {Col = 0xFFFFFFFF};

            uint result = vert.Col;

            Assert.Equal(0xFFFFFFFF, result);
        }
    }
}