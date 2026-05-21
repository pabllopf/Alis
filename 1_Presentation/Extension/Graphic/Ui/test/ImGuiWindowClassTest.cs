

using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui window class test class
    /// </summary>
    public class ImGuiWindowClassTest
    {
        /// <summary>
        ///     Tests that im gui window class should initialize with default values
        /// </summary>
        [Fact]
        public void ImGuiWindowClass_ShouldInitializeWithDefaultValues()
        {
            ImGuiWindowClass windowClass = new ImGuiWindowClass();

            Assert.Equal(0u, windowClass.ClassId);
            Assert.Equal(0u, windowClass.ParentViewportId);
            Assert.Equal(ImGuiViewportFlags.None, windowClass.ViewportFlagsOverrideSet);
            Assert.Equal(ImGuiViewportFlags.None, windowClass.ViewportFlagsOverrideClear);
            Assert.Equal(ImGuiTabItemFlags.None, windowClass.TabItemFlagsOverrideSet);
            Assert.Equal(ImGuiDockNodeFlags.None, windowClass.DockNodeFlagsOverrideSet);
            Assert.Equal(0, windowClass.DockingAlwaysTabBar);
            Assert.Equal(0, windowClass.DockingAllowUnclassed);
        }

        /// <summary>
        ///     Tests that im gui window class should set and get properties
        /// </summary>
        [Fact]
        public void ImGuiWindowClass_ShouldSetAndGetProperties()
        {
            ImGuiWindowClass windowClass = new ImGuiWindowClass
            {
                ClassId = 1,
                ParentViewportId = 2,
                ViewportFlagsOverrideSet = ImGuiViewportFlags.NoDecoration,
                ViewportFlagsOverrideClear = ImGuiViewportFlags.NoTaskBarIcon,
                TabItemFlagsOverrideSet = ImGuiTabItemFlags.SetSelected,
                DockNodeFlagsOverrideSet = ImGuiDockNodeFlags.NoDockingInCentralNode,
                DockingAlwaysTabBar = 1,
                DockingAllowUnclassed = 1
            };

            Assert.Equal(1u, windowClass.ClassId);
            Assert.Equal(2u, windowClass.ParentViewportId);
            Assert.Equal(ImGuiViewportFlags.NoDecoration, windowClass.ViewportFlagsOverrideSet);
            Assert.Equal(ImGuiViewportFlags.NoTaskBarIcon, windowClass.ViewportFlagsOverrideClear);
            Assert.Equal(ImGuiTabItemFlags.SetSelected, windowClass.TabItemFlagsOverrideSet);
            Assert.Equal(ImGuiDockNodeFlags.NoDockingInCentralNode, windowClass.DockNodeFlagsOverrideSet);
            Assert.Equal(1, windowClass.DockingAlwaysTabBar);
            Assert.Equal(1, windowClass.DockingAllowUnclassed);
        }
    }
}