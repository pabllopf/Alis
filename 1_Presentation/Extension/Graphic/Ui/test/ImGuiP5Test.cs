// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP5Test.cs
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
    ///     Provides API-surface coverage for methods contributed by ImGuiP5 wrappers.
    /// </summary>
    public class ImGuiP5Test
    {
        /// <summary>
        ///     Verifies begin-family APIs expose overload sets.
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
        ///     Verifies drag-drop payload acceptance overloads exist.
        /// </summary>
        [Fact]
        public void AcceptDragDropPayload_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "AcceptDragDropPayload").ToArray();

            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies BeginChildFrame overloads exist.
        /// </summary>
        [Fact]
        public void BeginChildFrame_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "BeginChildFrame").ToArray();

            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies BeginCombo overloads exist.
        /// </summary>
        [Fact]
        public void BeginCombo_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "BeginCombo").ToArray();

            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies BeginDisabled overloads exist.
        /// </summary>
        [Fact]
        public void BeginDisabled_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "BeginDisabled").ToArray();

            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies drag-drop source and target methods exist.
        /// </summary>
        [Fact]
        public void BeginDragDrop_ShouldExposeOverloads()
        {
            MethodInfo[] sourceMethods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "BeginDragDropSource").ToArray();

            Assert.True(sourceMethods.Length >= 2);
            Assert.NotNull(typeof(ImGui).GetMethod("BeginDragDropTarget"));
        }

        /// <summary>
        ///     Verifies BeginListBox overloads exist.
        /// </summary>
        [Fact]
        public void BeginListBox_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "BeginListBox").ToArray();

            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies BeginMenu overloads exist.
        /// </summary>
        [Fact]
        public void BeginMenu_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "BeginMenu").ToArray();

            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies popup-family APIs expose expected overloads.
        /// </summary>
        [Fact]
        public void BeginPopup_ShouldExposeOverloads()
        {
            MethodInfo[] popup = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "BeginPopup").ToArray();
            MethodInfo[] ctxItem = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "BeginPopupContextItem").ToArray();
            MethodInfo[] ctxVoid = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "BeginPopupContextVoid").ToArray();
            MethodInfo[] ctxWindow = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "BeginPopupContextWindow").ToArray();
            MethodInfo[] modal = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "BeginPopupModal").ToArray();

            Assert.True(popup.Length >= 2);
            Assert.True(ctxItem.Length >= 3);
            Assert.True(ctxVoid.Length >= 3);
            Assert.True(ctxWindow.Length >= 3);
            Assert.True(modal.Length >= 3);
            Assert.NotNull(typeof(ImGui).GetMethod("CloseCurrentPopup"));
        }

        /// <summary>
        ///     Verifies BeginTabBar overloads exist.
        /// </summary>
        [Fact]
        public void BeginTabBar_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "BeginTabBar").ToArray();

            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies BeginTabItem overloads exist.
        /// </summary>
        [Fact]
        public void BeginTabItem_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "BeginTabItem").ToArray();

            Assert.True(methods.Length >= 3);
        }

        /// <summary>
        ///     Verifies BeginTable overloads exist.
        /// </summary>
        [Fact]
        public void BeginTable_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "BeginTable").ToArray();

            Assert.True(methods.Length >= 4);
        }

        /// <summary>
        ///     Verifies Button overloads exist.
        /// </summary>
        [Fact]
        public void Button_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "Button").ToArray();

            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies Checkbox and CheckboxFlags overloads exist.
        /// </summary>
        [Fact]
        public void Checkbox_ShouldExposeOverloads()
        {
            MethodInfo[] flagsMethods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "CheckboxFlags").ToArray();

            Assert.NotNull(typeof(ImGui).GetMethod("Checkbox"));
            Assert.True(flagsMethods.Length >= 2);
        }

        /// <summary>
        ///     Verifies CollapsingHeader overloads exist.
        /// </summary>
        [Fact]
        public void CollapsingHeader_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "CollapsingHeader").ToArray();

            Assert.True(methods.Length >= 4);
        }

        /// <summary>
        ///     Verifies ColorButton overloads exist.
        /// </summary>
        [Fact]
        public void ColorButton_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "ColorButton").ToArray();

            Assert.True(methods.Length >= 3);
        }

        /// <summary>
        ///     Verifies color-conversion utility methods exist.
        /// </summary>
        [Fact]
        public void ColorConvert_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("ColorConvertFloat4ToU32"));
            Assert.NotNull(typeof(ImGui).GetMethod("ColorConvertHsVtoRgb"));
            Assert.NotNull(typeof(ImGui).GetMethod("ColorConvertRgBtoHsv"));
            Assert.NotNull(typeof(ImGui).GetMethod("ColorConvertU32ToFloat4"));
        }

        /// <summary>
        ///     Verifies ColorEdit3 overloads exist.
        /// </summary>
        [Fact]
        public void ColorEdit3_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "ColorEdit3").ToArray();

            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies ColorEdit4 overloads exist.
        /// </summary>
        [Fact]
        public void ColorEdit4_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "ColorEdit4").ToArray();

            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies ColorPicker3 overloads exist.
        /// </summary>
        [Fact]
        public void ColorPicker3_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "ColorPicker3").ToArray();

            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies ColorPicker4 overloads exist.
        /// </summary>
        [Fact]
        public void ColorPicker4_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "ColorPicker4").ToArray();

            Assert.True(methods.Length >= 3);
        }

        /// <summary>
        ///     Verifies Columns overloads exist.
        /// </summary>
        [Fact]
        public void Columns_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "Columns").ToArray();

            Assert.True(methods.Length >= 4);
        }

        /// <summary>
        ///     Verifies Combo overloads exist.
        /// </summary>
        [Fact]
        public void Combo_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "Combo").ToArray();

            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies basic singleton utility methods exist.
        /// </summary>
        [Fact]
        public void BasicSingletons_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("AlignTextToFramePadding"));
            Assert.NotNull(typeof(ImGui).GetMethod("ArrowButton"));
            Assert.NotNull(typeof(ImGui).GetMethod("BeginGroup"));
            Assert.NotNull(typeof(ImGui).GetMethod("BeginMainMenuBar"));
            Assert.NotNull(typeof(ImGui).GetMethod("BeginMenuBar"));
            Assert.NotNull(typeof(ImGui).GetMethod("BeginTooltip"));
            Assert.NotNull(typeof(ImGui).GetMethod("Bullet"));
            Assert.NotNull(typeof(ImGui).GetMethod("BulletText"));
            Assert.NotNull(typeof(ImGui).GetMethod("CalcItemWidth"));
        }
    }
}
