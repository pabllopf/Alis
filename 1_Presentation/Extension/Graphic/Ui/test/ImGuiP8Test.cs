using System.Linq;
using System.Reflection;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides API-surface coverage for methods contributed by ImGuiP8 wrappers.
    /// </summary>
    public class ImGuiP8Test
    {
        /// <summary>
        /// Verifies diagnostic window APIs expose bool-ref and parameterless overloads.
        /// </summary>
        [Fact]
        public void DiagnosticWindowApis_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] showDemoWindow = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "ShowDemoWindow").ToArray();
            MethodInfo[] showMetricsWindow = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "ShowMetricsWindow").ToArray();

            Assert.True(showDemoWindow.Length >= 2);
            Assert.True(showMetricsWindow.Length >= 2);
        }

        /// <summary>
        /// Verifies slider-angle API keeps multiple overloads.
        /// </summary>
        [Fact]
        public void SliderAngle_ShouldExposeMultipleOverloads()
        {
            MethodInfo[] sliderAngle = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SliderAngle").ToArray();

            Assert.True(sliderAngle.Length >= 3);
        }
    }
}
