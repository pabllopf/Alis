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
        [Fact]
        public void DiagnosticWindowApis_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] showDemoWindow = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "ShowDemoWindow").ToArray();
            MethodInfo[] showMetricsWindow = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "ShowMetricsWindow").ToArray();

            Assert.True(showDemoWindow.Length >= 2);
            Assert.True(showMetricsWindow.Length >= 2);
        }

        /// <summary>
        ///     Verifies slider-angle API keeps multiple overloads.
        /// </summary>
        [Fact]
        public void SliderAngle_ShouldExposeMultipleOverloads()
        {
            MethodInfo[] sliderAngle = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SliderAngle").ToArray();

            Assert.True(sliderAngle.Length >= 3);
        }
    }
}