using System.Linq;
using System.Reflection;
using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides API-surface coverage for methods contributed by ImGuiP7 wrappers.
    /// </summary>
    public class ImGuiP7Test
    {
        /// <summary>
        /// Verifies popup APIs expose expected overloads.
        /// </summary>
        [Fact]
        public void PopupApis_ShouldExposeOverloads()
        {
            MethodInfo[] openPopup = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "OpenPopup").ToArray();
            MethodInfo[] openPopupOnItemClick = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "OpenPopupOnItemClick").ToArray();

            Assert.True(openPopup.Length >= 4);
            Assert.True(openPopupOnItemClick.Length >= 3);
        }

        /// <summary>
        /// Verifies representative frame navigation methods exist.
        /// </summary>
        [Fact]
        public void FrameNavigationMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("NewFrame", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("NextColumn", BindingFlags.Public | BindingFlags.Static));
        }
    }
}

