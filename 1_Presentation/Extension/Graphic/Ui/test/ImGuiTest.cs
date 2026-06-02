// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTest.cs
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
    ///     Provides API-surface coverage for methods in the <see cref="ImGui" /> partial class.
    /// </summary>
    public class ImGuiTest
    {
        /// <summary>
        ///     Verifies that SliderFloat4 has the expected overload.
        /// </summary>
        [Fact]
        public void SliderFloat4_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SliderFloat4").ToArray();
            Assert.Single(methods);
        }

        /// <summary>
        ///     Verifies that SliderInt has the expected overloads.
        /// </summary>
        [Fact]
        public void SliderInt_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SliderInt").ToArray();
            Assert.Equal(3, methods.Length);
            Assert.Contains(methods, m => m.GetParameters().Length == 4);
            Assert.Contains(methods, m => m.GetParameters().Length == 5);
            Assert.Contains(methods, m => m.GetParameters().Length == 6);
        }

        /// <summary>
        ///     Verifies that SliderInt2 has the expected overloads.
        /// </summary>
        [Fact]
        public void SliderInt2_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SliderInt2").ToArray();
            Assert.Equal(3, methods.Length);
        }

        /// <summary>
        ///     Verifies that SliderInt3 has the expected overloads.
        /// </summary>
        [Fact]
        public void SliderInt3_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SliderInt3").ToArray();
            Assert.Equal(3, methods.Length);
        }

        /// <summary>
        ///     Verifies that SliderInt4 has the expected overloads.
        /// </summary>
        [Fact]
        public void SliderInt4_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SliderInt4").ToArray();
            Assert.Equal(3, methods.Length);
        }

        /// <summary>
        ///     Verifies that SliderScalar has the expected overloads.
        /// </summary>
        [Fact]
        public void SliderScalar_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SliderScalar").ToArray();
            Assert.Equal(3, methods.Length);
        }

        /// <summary>
        ///     Verifies that SliderScalarN has the expected overloads.
        /// </summary>
        [Fact]
        public void SliderScalarN_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SliderScalarN").ToArray();
            Assert.Equal(3, methods.Length);
        }

        /// <summary>
        ///     Verifies that style helper methods are exposed.
        /// </summary>
        [Fact]
        public void StyleMethods_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] styleColorsClassic = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "StyleColorsClassic").ToArray();
            MethodInfo[] styleColorsDark = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "StyleColorsDark").ToArray();
            MethodInfo[] styleColorsLight = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "StyleColorsLight").ToArray();

            Assert.Equal(2, styleColorsClassic.Length);
            Assert.Equal(2, styleColorsDark.Length);
            Assert.Equal(2, styleColorsLight.Length);
        }

        /// <summary>
        ///     Verifies that Table API methods are exposed.
        /// </summary>
        [Fact]
        public void TableApi_ShouldExposeExpectedMethods()
        {
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "TableGetColumnCount"));
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "TableGetColumnFlags"));
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "TableGetColumnIndex"));
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "TableGetColumnName"));
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "TableGetRowIndex"));
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "TableGetSortSpecs"));
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "TableHeader"));
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "TableHeadersRow"));
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "TableNextColumn"));
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "TableNextRow"));
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "TableSetBgColor"));
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "TableSetColumnEnabled"));
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "TableSetColumnIndex"));
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "TableSetupColumn"));
        }

        /// <summary>
        ///     Verifies that DockBuilder API methods are exposed.
        /// </summary>
        [Fact]
        public void DockBuilderApi_ShouldExposeExpectedMethods()
        {
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "DockBuilderRemoveNode"));
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "DockBuilderAddNode"));
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "DockBuilderSetNodeSize"));
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "DockBuilderSplitNode"));
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "DockBuilderDockWindow"));
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "DockBuilderFinish"));
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "DockBuilderSetNodeFlags"));
        }

        /// <summary>
        ///     Verifies that utility methods are exposed.
        /// </summary>
        [Fact]
        public void UtilityMethods_ShouldBeExposed()
        {
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "SmallButton"));
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "Spacing"));
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "TabItemButton"));
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "MenuItem"));
            Assert.True(typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Any(m => m.Name == "ImFontConfig"));
        }
    }
}
