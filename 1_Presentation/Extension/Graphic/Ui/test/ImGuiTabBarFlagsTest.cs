using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImGuiTabBarFlags"/> values.
    /// </summary>
    public class ImGuiTabBarFlagsTest
    {
        /// <summary>
        /// Verifies that fitting policy aliases are coherent.
        /// </summary>
        [Fact]
        public void FittingPolicyAliases_ShouldBeCoherent()
        {
            ImGuiTabBarFlags expectedMask = ImGuiTabBarFlags.FittingPolicyResizeDown | ImGuiTabBarFlags.FittingPolicyScroll;

            Assert.Equal(expectedMask, ImGuiTabBarFlags.FittingPolicyMask);
            Assert.Equal(ImGuiTabBarFlags.FittingPolicyResizeDown, ImGuiTabBarFlags.FittingPolicyDefault);
        }
    }
}

