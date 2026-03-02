using System.Linq;
using System.Reflection;
using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides API-surface coverage for methods contributed by ImGuiP3 wrappers.
    /// </summary>
    public class ImGuiP3Test
    {
        /// <summary>
        /// Verifies representative End* methods are exposed as void static methods.
        /// </summary>
        [Fact]
        public void EndMethods_ShouldBeAvailable()
        {
            string[] names = { "End", "EndChild", "EndCombo", "EndFrame", "EndMenu", "EndPopup" };

            foreach (string name in names)
            {
                MethodInfo method = typeof(ImGui).GetMethod(name, BindingFlags.Public | BindingFlags.Static);
                Assert.NotNull(method);
                Assert.Equal(typeof(void), method.ReturnType);
            }
        }

        /// <summary>
        /// Verifies DragScalarN overloads exist.
        /// </summary>
        [Fact]
        public void DragScalarN_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "DragScalarN").ToArray();

            Assert.True(methods.Length >= 3);
        }
    }
}

