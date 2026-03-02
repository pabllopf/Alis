using System.Linq;
using System.Reflection;
using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides API-surface coverage for methods contributed by ImGuiP6 wrappers.
    /// </summary>
    public class ImGuiP6Test
    {
        /// <summary>
        /// Verifies input APIs expose expected overload families.
        /// </summary>
        [Fact]
        public void InputFamilies_ShouldExposeOverloads()
        {
            MethodInfo[] inputInt = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "InputInt").ToArray();
            MethodInfo[] inputInt2 = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "InputInt2").ToArray();
            MethodInfo[] inputScalar = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "InputScalar").ToArray();

            Assert.False(inputInt.Length >= 5);
            Assert.True(inputInt2.Length >= 2);
            Assert.True(inputScalar.Length >= 3);
        }
    }
}

