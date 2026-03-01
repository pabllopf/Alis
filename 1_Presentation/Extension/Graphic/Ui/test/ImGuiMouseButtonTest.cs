using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImGuiMouseButton"/> enum values.
    /// </summary>
    public class ImGuiMouseButtonTest
    {
        /// <summary>
        /// Verifies that mouse button values are defined.
        /// </summary>
        [Fact]
        public void Left_ShouldBeZero()
        {
            ImGuiMouseButton button = ImGuiMouseButton.Left;
            Assert.Equal(0, (int)button);
        }

        /// <summary>
        /// Verifies that different mouse buttons have distinct values.
        /// </summary>
        [Fact]
        public void EnumValues_ShouldBeDistinct()
        {
            ImGuiMouseButton left = ImGuiMouseButton.Left;
            ImGuiMouseButton right = ImGuiMouseButton.Right;
            ImGuiMouseButton middle = ImGuiMouseButton.Middle;

            Assert.NotEqual((int)left, (int)right);
            Assert.NotEqual((int)right, (int)middle);
            Assert.NotEqual((int)left, (int)middle);
        }
    }
}

