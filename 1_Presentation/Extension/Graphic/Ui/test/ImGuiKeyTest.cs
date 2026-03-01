using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImGuiKey"/> enum values.
    /// </summary>
    public class ImGuiKeyTest
    {
        /// <summary>
        /// Verifies that keyboard key values are properly defined.
        /// </summary>
        [Fact]
        public void Tab_ShouldBeDefined()
        {
            ImGuiKey key = ImGuiKey.Tab;
            Assert.NotEqual(0, (int)key);
        }

        /// <summary>
        /// Verifies that different keys have distinct values.
        /// </summary>
        [Fact]
        public void EnumValues_ShouldBeDistinct()
        {
            ImGuiKey tab = ImGuiKey.Tab;
            ImGuiKey enter = ImGuiKey.Enter;
            ImGuiKey escape = ImGuiKey.Escape;

            Assert.NotEqual((int)tab, (int)enter);
            Assert.NotEqual((int)enter, (int)escape);
            Assert.NotEqual((int)tab, (int)escape);
        }
    }
}

