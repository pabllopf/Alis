using System.Linq;
using System.Reflection;
using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides API-surface coverage for methods contributed by ImGuiP2 wrappers.
    /// </summary>
    public class ImGuiP2Test
    {
        /// <summary>
        /// Verifies that DragInt family exposes a broad overload set.
        /// </summary>
        [Fact]
        public void DragIntFamily_ShouldExposeManyOverloads()
        {
            MethodInfo[] dragInt = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "DragInt").ToArray();
            MethodInfo[] dragInt2 = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "DragInt2").ToArray();
            MethodInfo[] dragInt3 = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "DragInt3").ToArray();

            Assert.True(dragInt.Length >= 6);
            Assert.True(dragInt2.Length >= 6);
            Assert.True(dragInt3.Length >= 6);
        }
    }
}

