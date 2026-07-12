// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiCsTest.cs
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
    ///     Provides API-surface coverage for methods contributed by the main ImGui.cs wrappers.
    /// </summary>
    public class ImGuiCsTest
    {
        /// <summary>
        ///     Verifies SliderFloat4 overload exists.
        /// </summary>
        [Fact]
        public void SliderFloat4_ShouldExist()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SliderFloat4").ToArray();
            Assert.True(methods.Length >= 1);
        }

        /// <summary>
        ///     Verifies SliderInt overloads exist.
        /// </summary>
        [Fact]
        public void SliderInt_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SliderInt").ToArray();
            Assert.True(methods.Length >= 3);
        }

        /// <summary>
        ///     Verifies SliderInt2 overloads exist.
        /// </summary>
        [Fact]
        public void SliderInt2_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SliderInt2").ToArray();
            Assert.True(methods.Length >= 3);
        }

        /// <summary>
        ///     Verifies SliderInt3 overloads exist.
        /// </summary>
        [Fact]
        public void SliderInt3_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SliderInt3").ToArray();
            Assert.True(methods.Length >= 3);
        }

        /// <summary>
        ///     Verifies SliderInt4 overloads exist.
        /// </summary>
        [Fact]
        public void SliderInt4_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SliderInt4").ToArray();
            Assert.True(methods.Length >= 3);
        }

        /// <summary>
        ///     Verifies SliderScalar overloads exist.
        /// </summary>
        [Fact]
        public void SliderScalar_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SliderScalar").ToArray();
            Assert.True(methods.Length >= 3);
        }

        /// <summary>
        ///     Verifies SliderScalarN overloads exist.
        /// </summary>
        [Fact]
        public void SliderScalarN_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SliderScalarN").ToArray();
            Assert.True(methods.Length >= 3);
        }

        /// <summary>
        ///     Verifies SmallButton method exists.
        /// </summary>
        [Fact]
        public void SmallButton_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("SmallButton", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies Spacing method exists.
        /// </summary>
        [Fact]
        public void Spacing_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("Spacing", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies StyleColorsClassic overloads exist.
        /// </summary>
        [Fact]
        public void StyleColorsClassic_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "StyleColorsClassic").ToArray();
            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies StyleColorsDark overloads exist.
        /// </summary>
        [Fact]
        public void StyleColorsDark_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "StyleColorsDark").ToArray();
            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies StyleColorsLight overloads exist.
        /// </summary>
        [Fact]
        public void StyleColorsLight_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "StyleColorsLight").ToArray();
            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies TabItemButton overloads exist.
        /// </summary>
        [Fact]
        public void TabItemButton_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "TabItemButton").ToArray();
            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies TableGetColumnCount method exists.
        /// </summary>
        [Fact]
        public void TableGetColumnCount_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("TableGetColumnCount", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies TableGetColumnFlags overloads exist.
        /// </summary>
        [Fact]
        public void TableGetColumnFlags_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "TableGetColumnFlags").ToArray();
            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies TableGetColumnIndex method exists.
        /// </summary>
        [Fact]
        public void TableGetColumnIndex_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("TableGetColumnIndex", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies TableGetColumnName overloads exist.
        /// </summary>
        [Fact]
        public void TableGetColumnName_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "TableGetColumnName").ToArray();
            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies TableGetRowIndex method exists.
        /// </summary>
        [Fact]
        public void TableGetRowIndex_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("TableGetRowIndex", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies TableGetSortSpecs method exists.
        /// </summary>
        [Fact]
        public void TableGetSortSpecs_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("TableGetSortSpecs", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies TableHeader method exists.
        /// </summary>
        [Fact]
        public void TableHeader_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("TableHeader", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies TableHeadersRow method exists.
        /// </summary>
        [Fact]
        public void TableHeadersRow_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("TableHeadersRow", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies TableNextColumn method exists.
        /// </summary>
        [Fact]
        public void TableNextColumn_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("TableNextColumn", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies TableNextRow overloads exist.
        /// </summary>
        [Fact]
        public void TableNextRow_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "TableNextRow").ToArray();
            Assert.True(methods.Length >= 3);
        }

        /// <summary>
        ///     Verifies TableSetBgColor overloads exist.
        /// </summary>
        [Fact]
        public void TableSetBgColor_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "TableSetBgColor").ToArray();
            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies TableSetColumnEnabled method exists.
        /// </summary>
        [Fact]
        public void TableSetColumnEnabled_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("TableSetColumnEnabled", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies TableSetColumnIndex method exists.
        /// </summary>
        [Fact]
        public void TableSetColumnIndex_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("TableSetColumnIndex", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies ImFontConfig method exists.
        /// </summary>
        [Fact]
        public void ImFontConfig_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("ImFontConfig", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies DockBuilderRemoveNode method exists.
        /// </summary>
        [Fact]
        public void DockBuilderRemoveNode_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("DockBuilderRemoveNode", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies DockBuilderAddNode method exists.
        /// </summary>
        [Fact]
        public void DockBuilderAddNode_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("DockBuilderAddNode", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies DockBuilderSetNodeSize method exists.
        /// </summary>
        [Fact]
        public void DockBuilderSetNodeSize_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("DockBuilderSetNodeSize", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies DockBuilderSplitNode method exists.
        /// </summary>
        [Fact]
        public void DockBuilderSplitNode_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("DockBuilderSplitNode", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies DockBuilderDockWindow method exists.
        /// </summary>
        [Fact]
        public void DockBuilderDockWindow_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("DockBuilderDockWindow", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies DockBuilderFinish method exists.
        /// </summary>
        [Fact]
        public void DockBuilderFinish_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("DockBuilderFinish", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies DockBuilderSetNodeFlags method exists.
        /// </summary>
        [Fact]
        public void DockBuilderSetNodeFlags_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("DockBuilderSetNodeFlags", BindingFlags.Public | BindingFlags.Static));
        }
    }
}
