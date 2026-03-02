using System.Linq;
using System.Reflection;
using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides API-surface coverage for methods contributed by ImGuiP5 wrappers.
    /// </summary>
    public class ImGuiP5Test
    {
        /// <summary>
        /// Verifies begin-family APIs expose overload sets.
        /// </summary>
        [Fact]
        public void BeginFamily_ShouldExposeOverloads()
        {
            MethodInfo[] begin = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "Begin").ToArray();
            MethodInfo[] beginChild = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "BeginChild").ToArray();

            Assert.True(begin.Length >= 3);
            Assert.True(beginChild.Length >= 8);
        }

        /// <summary>
        /// Verifies drag-drop payload acceptance overloads exist.
        /// </summary>
        [Fact]
        public void AcceptDragDropPayload_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "AcceptDragDropPayload").ToArray();

            Assert.True(methods.Length >= 2);
        }
    }
}

