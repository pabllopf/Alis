

using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im draw flags test class
    /// </summary>
    public class ImDrawFlagsTest
    {
        /// <summary>
        ///     Tests that none should have correct value
        /// </summary>
        [Fact]
        public void None_ShouldHaveCorrectValue()
        {
            ImDrawFlags flag = ImDrawFlags.None;

            Assert.Equal(0, (int) flag);
        }

        /// <summary>
        ///     Tests that closed should have correct value
        /// </summary>
        [Fact]
        public void Closed_ShouldHaveCorrectValue()
        {
            ImDrawFlags flag = ImDrawFlags.Closed;

            Assert.Equal(1, (int) flag);
        }

        /// <summary>
        ///     Tests that round corners top left should have correct value
        /// </summary>
        [Fact]
        public void RoundCornersTopLeft_ShouldHaveCorrectValue()
        {
            ImDrawFlags flag = ImDrawFlags.RoundCornersTopLeft;

            Assert.Equal(16, (int) flag);
        }

        /// <summary>
        ///     Tests that round corners top right should have correct value
        /// </summary>
        [Fact]
        public void RoundCornersTopRight_ShouldHaveCorrectValue()
        {
            ImDrawFlags flag = ImDrawFlags.RoundCornersTopRight;

            Assert.Equal(32, (int) flag);
        }

        /// <summary>
        ///     Tests that round corners bottom left should have correct value
        /// </summary>
        [Fact]
        public void RoundCornersBottomLeft_ShouldHaveCorrectValue()
        {
            ImDrawFlags flag = ImDrawFlags.RoundCornersBottomLeft;

            Assert.Equal(64, (int) flag);
        }

        /// <summary>
        ///     Tests that round corners bottom right should have correct value
        /// </summary>
        [Fact]
        public void RoundCornersBottomRight_ShouldHaveCorrectValue()
        {
            ImDrawFlags flag = ImDrawFlags.RoundCornersBottomRight;

            Assert.Equal(128, (int) flag);
        }

        /// <summary>
        ///     Tests that round corners none should have correct value
        /// </summary>
        [Fact]
        public void RoundCornersNone_ShouldHaveCorrectValue()
        {
            ImDrawFlags flag = ImDrawFlags.RoundCornersNone;

            Assert.Equal(256, (int) flag);
        }

        /// <summary>
        ///     Tests that round corners top should have correct value
        /// </summary>
        [Fact]
        public void RoundCornersTop_ShouldHaveCorrectValue()
        {
            ImDrawFlags flag = ImDrawFlags.RoundCornersTop;

            Assert.Equal(48, (int) flag);
        }

        /// <summary>
        ///     Tests that round corners bottom should have correct value
        /// </summary>
        [Fact]
        public void RoundCornersBottom_ShouldHaveCorrectValue()
        {
            ImDrawFlags flag = ImDrawFlags.RoundCornersBottom;

            Assert.Equal(192, (int) flag);
        }

        /// <summary>
        ///     Tests that round corners left should have correct value
        /// </summary>
        [Fact]
        public void RoundCornersLeft_ShouldHaveCorrectValue()
        {
            ImDrawFlags flag = ImDrawFlags.RoundCornersLeft;

            Assert.Equal(80, (int) flag);
        }

        /// <summary>
        ///     Tests that round corners right should have correct value
        /// </summary>
        [Fact]
        public void RoundCornersRight_ShouldHaveCorrectValue()
        {
            ImDrawFlags flag = ImDrawFlags.RoundCornersRight;

            Assert.Equal(160, (int) flag);
        }

        /// <summary>
        ///     Tests that round corners all should have correct value
        /// </summary>
        [Fact]
        public void RoundCornersAll_ShouldHaveCorrectValue()
        {
            ImDrawFlags flag = ImDrawFlags.RoundCornersAll;

            Assert.Equal(240, (int) flag);
        }

        /// <summary>
        ///     Tests that round corners default should have correct value
        /// </summary>
        [Fact]
        public void RoundCornersDefault_ShouldHaveCorrectValue()
        {
            ImDrawFlags flag = ImDrawFlags.RoundCornersDefault;

            Assert.Equal(240, (int) flag);
        }

        /// <summary>
        ///     Tests that round corners mask should have correct value
        /// </summary>
        [Fact]
        public void RoundCornersMask_ShouldHaveCorrectValue()
        {
            ImDrawFlags flag = ImDrawFlags.RoundCornersMask;

            Assert.Equal(496, (int) flag);
        }
    }
}