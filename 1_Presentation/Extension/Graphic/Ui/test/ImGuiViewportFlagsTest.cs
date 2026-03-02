using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImGuiViewportFlags"/> values.
    /// </summary>
    public class ImGuiViewportFlagsTest
    {
        /// <summary>
        /// Verifies that representative viewport flags are distinct values.
        /// </summary>
        [Fact]
        public void RepresentativeFlags_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImGuiViewportFlags.IsPlatformWindow, (int) ImGuiViewportFlags.IsPlatformMonitor);
            Assert.NotEqual((int) ImGuiViewportFlags.NoInputs, (int) ImGuiViewportFlags.NoRendererClear);
            Assert.NotEqual((int) ImGuiViewportFlags.NoAutoMerge, (int) ImGuiViewportFlags.CanHostOtherWindows);
        }
    }
}

