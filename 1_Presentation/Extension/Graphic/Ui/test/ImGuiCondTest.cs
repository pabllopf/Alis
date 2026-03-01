using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImGuiCond"/> enum values.
    /// </summary>
    public class ImGuiCondTest
    {
        /// <summary>
        /// Verifies that condition values are defined.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            ImGuiCond cond = ImGuiCond.None;
            Assert.Equal(0, (int)cond);
        }

        /// <summary>
        /// Verifies that different conditions have distinct values.
        /// </summary>
        [Fact]
        public void EnumValues_ShouldBeDistinct()
        {
            ImGuiCond always = ImGuiCond.Always;
            ImGuiCond once = ImGuiCond.Once;
            ImGuiCond firstUseEver = ImGuiCond.FirstUseEver;

            Assert.NotEqual((int)always, (int)once);
            Assert.NotEqual((int)once, (int)firstUseEver);
            Assert.NotEqual((int)always, (int)firstUseEver);
        }
    }
}

