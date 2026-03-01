using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImGuiCol"/> enum values.
    /// </summary>
    public class ImGuiColTest
    {
        /// <summary>
        /// Verifies that color indices are properly defined.
        /// </summary>
        [Fact]
        public void Text_ShouldBeDefined()
        {
            ImGuiCol color = ImGuiCol.Text;
            Assert.NotEqual(0, (int)color);
        }

        /// <summary>
        /// Verifies that different colors have distinct indices.
        /// </summary>
        [Fact]
        public void EnumValues_ShouldBeDistinct()
        {
            ImGuiCol text = ImGuiCol.Text;
            ImGuiCol bg = ImGuiCol.WindowBg;
            ImGuiCol border = ImGuiCol.Border;

            Assert.NotEqual((int)text, (int)bg);
            Assert.NotEqual((int)bg, (int)border);
            Assert.NotEqual((int)text, (int)border);
        }
    }
}

