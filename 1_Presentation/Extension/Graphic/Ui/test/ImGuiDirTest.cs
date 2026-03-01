using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImGuiDir"/> enum values.
    /// </summary>
    public class ImGuiDirTest
    {
        /// <summary>
        /// Verifies that direction values are properly defined.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            ImGuiDir dir = ImGuiDir.None;
            Assert.Equal(0, (int)dir);
        }

        /// <summary>
        /// Verifies that different directions have distinct values.
        /// </summary>
        [Fact]
        public void EnumValues_ShouldBeDistinct()
        {
            ImGuiDir left = ImGuiDir.Left;
            ImGuiDir right = ImGuiDir.Right;
            ImGuiDir up = ImGuiDir.Up;
            ImGuiDir down = ImGuiDir.Down;

            Assert.NotEqual((int)left, (int)right);
            Assert.NotEqual((int)up, (int)down);
            Assert.NotEqual((int)left, (int)up);
        }
    }
}

