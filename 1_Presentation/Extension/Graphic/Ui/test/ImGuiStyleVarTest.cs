using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImGuiStyleVar"/> enum values.
    /// </summary>
    public class ImGuiStyleVarTest
    {
        /// <summary>
        /// Verifies that style variable indices are defined.
        /// </summary>
        [Fact]
        public void Alpha_ShouldBeDefined()
        {
            ImGuiStyleVar styleVar = ImGuiStyleVar.Alpha;
            Assert.Equal(0, (int)styleVar);
        }

        /// <summary>
        /// Verifies that different style variables have distinct indices.
        /// </summary>
        [Fact]
        public void EnumValues_ShouldBeDistinct()
        {
            ImGuiStyleVar alpha = ImGuiStyleVar.Alpha;
            ImGuiStyleVar windowPadding = ImGuiStyleVar.WindowPadding;
            ImGuiStyleVar windowRounding = ImGuiStyleVar.WindowRounding;

            Assert.NotEqual((int)alpha, (int)windowPadding);
            Assert.NotEqual((int)windowPadding, (int)windowRounding);
            Assert.NotEqual((int)alpha, (int)windowRounding);
        }
    }
}

