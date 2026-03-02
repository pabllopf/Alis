using System;
using System.Linq;
using System.Reflection;
using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides API-surface coverage for methods contributed by ImGuiP1 wrappers.
    /// </summary>
    public class ImGuiP1Test
    {
        /// <summary>
        /// Verifies that docking and context API overloads are available on ImGui.
        /// </summary>
        [Fact]
        public void DockingAndContextApi_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] createContext = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "CreateContext").ToArray();
            MethodInfo[] dockSpace = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "DockSpace").ToArray();
            MethodInfo[] dockSpaceOverViewport = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "DockSpaceOverViewport").ToArray();

            Assert.True(createContext.Length >= 2);
            Assert.True(dockSpace.Length >= 4);
            Assert.True(dockSpaceOverViewport.Length >= 4);
        }

        /// <summary>
        /// Verifies that Combo overload family exists.
        /// </summary>
        [Fact]
        public void Combo_ShouldExposeMultipleOverloads()
        {
            MethodInfo[] combo = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "Combo").ToArray();

            Assert.True(combo.Length >= 2);
            Assert.Contains(combo, method => method.GetParameters().Length == 3);
            Assert.Contains(combo, method => method.GetParameters().Length == 4);
        }
    }
}

