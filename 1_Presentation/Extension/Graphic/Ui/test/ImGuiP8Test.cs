// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP8Test.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Linq;
using System.Reflection;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Provides API-surface coverage for methods contributed by ImGuiP8 wrappers.
    /// </summary>
    public class ImGuiP8Test
    {
        /// <summary>
        ///     Verifies diagnostic window APIs expose bool-ref and parameterless overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DiagnosticWindowApis_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] showDemoWindow = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "ShowDemoWindow").ToArray();
            MethodInfo[] showMetricsWindow = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "ShowMetricsWindow").ToArray();

            Assert.True(showDemoWindow.Length >= 2);
            Assert.True(showMetricsWindow.Length >= 2);
        }

        /// <summary>
        ///     Verifies ShowAboutWindow overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ShowAboutWindow_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "ShowAboutWindow").ToArray();
            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies ShowDebugLogWindow overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ShowDebugLogWindow_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "ShowDebugLogWindow").ToArray();
            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies ShowStyleEditor overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ShowStyleEditor_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "ShowStyleEditor").ToArray();
            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies ShowFontSelector method exists.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ShowFontSelector_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("ShowFontSelector", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies ShowStackToolWindow overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ShowStackToolWindow_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "ShowStackToolWindow").ToArray();
            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies ShowStyleSelector method exists.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ShowStyleSelector_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("ShowStyleSelector", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies ShowUserGuide method exists.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ShowUserGuide_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("ShowUserGuide", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies slider-angle API keeps multiple overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SliderAngle_ShouldExposeMultipleOverloads()
        {
            MethodInfo[] sliderAngle = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SliderAngle").ToArray();

            Assert.True(sliderAngle.Length >= 5);
        }

        /// <summary>
        ///     Verifies SliderFloat overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SliderFloat_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SliderFloat").ToArray();
            Assert.True(methods.Length >= 3);
        }

        /// <summary>
        ///     Verifies SliderFloat2 overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SliderFloat2_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SliderFloat2").ToArray();
            Assert.True(methods.Length >= 3);
        }

        /// <summary>
        ///     Verifies SliderFloat3 overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SliderFloat3_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SliderFloat3").ToArray();
            Assert.True(methods.Length >= 3);
        }

        /// <summary>
        ///     Verifies SliderFloat4 overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SliderFloat4_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SliderFloat4").ToArray();
            Assert.True(methods.Length >= 2);
        }
    }
}