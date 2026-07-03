// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP6Test.cs
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
    ///     Provides API-surface coverage for methods contributed by ImGuiP6 wrappers.
    /// </summary>
    public class ImGuiP6Test
    {
        /// <summary>
        ///     Verifies input APIs expose expected overload families.
        /// </summary>
        [Fact]
        public void InputFamilies_ShouldExposeOverloads()
        {
            MethodInfo[] inputFloat4 = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "InputFloat4").ToArray();
            MethodInfo[] inputInt = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "InputInt").ToArray();
            MethodInfo[] inputInt2 = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "InputInt2").ToArray();
            MethodInfo[] inputInt3 = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "InputInt3").ToArray();
            MethodInfo[] inputInt4 = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "InputInt4").ToArray();
            MethodInfo[] inputScalar = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "InputScalar").ToArray();
            MethodInfo[] inputScalarN = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "InputScalarN").ToArray();

            Assert.True(inputFloat4.Length >= 2);
            Assert.True(inputInt.Length >= 4);
            Assert.True(inputInt2.Length >= 2);
            Assert.True(inputInt3.Length >= 2);
            Assert.True(inputInt4.Length >= 2);
            Assert.True(inputScalar.Length >= 5);
            Assert.True(inputScalarN.Length >= 5);
        }

        /// <summary>
        ///     Verifies InvisibleButton exposes expected overloads.
        /// </summary>
        [Fact]
        public void InvisibleButton_ShouldExist()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "InvisibleButton").ToArray();
            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies IsAnyItem query methods exist.
        /// </summary>
        [Fact]
        public void IsAnyItem_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("IsAnyItemActive"));
            Assert.NotNull(typeof(ImGui).GetMethod("IsAnyItemFocused"));
            Assert.NotNull(typeof(ImGui).GetMethod("IsAnyItemHovered"));
            Assert.NotNull(typeof(ImGui).GetMethod("IsAnyMouseDown"));
        }

        /// <summary>
        ///     Verifies IsItem query methods expose expected overloads.
        /// </summary>
        [Fact]
        public void IsItemMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("IsItemActivated"));
            Assert.NotNull(typeof(ImGui).GetMethod("IsItemActive"));

            MethodInfo[] isItemClicked = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "IsItemClicked").ToArray();
            Assert.True(isItemClicked.Length >= 2);

            Assert.NotNull(typeof(ImGui).GetMethod("IsItemDeactivated"));
            Assert.NotNull(typeof(ImGui).GetMethod("IsItemDeactivatedAfterEdit"));
            Assert.NotNull(typeof(ImGui).GetMethod("IsItemEdited"));
            Assert.NotNull(typeof(ImGui).GetMethod("IsItemFocused"));

            MethodInfo[] isItemHovered = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "IsItemHovered").ToArray();
            Assert.True(isItemHovered.Length >= 2);

            Assert.NotNull(typeof(ImGui).GetMethod("IsItemToggledOpen"));
            Assert.NotNull(typeof(ImGui).GetMethod("IsItemVisible"));
        }

        /// <summary>
        ///     Verifies IsKey methods expose expected overloads.
        /// </summary>
        [Fact]
        public void IsKeyMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("IsKeyDown"));

            MethodInfo[] isKeyPressed = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "IsKeyPressed").ToArray();
            Assert.True(isKeyPressed.Length >= 2);

            Assert.NotNull(typeof(ImGui).GetMethod("IsKeyReleased"));
        }

        /// <summary>
        ///     Verifies IsMouse methods expose expected overloads.
        /// </summary>
        [Fact]
        public void IsMouseMethods_ShouldExist()
        {
            MethodInfo[] isMouseClicked = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "IsMouseClicked").ToArray();
            Assert.True(isMouseClicked.Length >= 2);

            Assert.NotNull(typeof(ImGui).GetMethod("IsMouseDoubleClicked"));
            Assert.NotNull(typeof(ImGui).GetMethod("IsMouseDown"));

            MethodInfo[] isMouseDragging = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "IsMouseDragging").ToArray();
            Assert.True(isMouseDragging.Length >= 2);

            MethodInfo[] isMouseHoveringRect = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "IsMouseHoveringRect").ToArray();
            Assert.True(isMouseHoveringRect.Length >= 2);

            MethodInfo[] isMousePosValid = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "IsMousePosValid").ToArray();
            Assert.True(isMousePosValid.Length >= 2);

            Assert.NotNull(typeof(ImGui).GetMethod("IsMouseReleased"));
        }

        /// <summary>
        ///     Verifies IsPopupOpen and IsRectVisible expose expected overloads.
        /// </summary>
        [Fact]
        public void IsPopupOpen_AndIsRectVisible_ShouldExist()
        {
            MethodInfo[] isPopupOpen = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "IsPopupOpen").ToArray();
            Assert.True(isPopupOpen.Length >= 2);

            MethodInfo[] isRectVisible = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "IsRectVisible").ToArray();
            Assert.True(isRectVisible.Length >= 2);
        }

        /// <summary>
        ///     Verifies IsWindow state methods expose expected overloads.
        /// </summary>
        [Fact]
        public void IsWindowMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("IsWindowAppearing"));
            Assert.NotNull(typeof(ImGui).GetMethod("IsWindowCollapsed"));
            Assert.NotNull(typeof(ImGui).GetMethod("IsWindowDocked"));

            MethodInfo[] isWindowFocused = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "IsWindowFocused").ToArray();
            Assert.True(isWindowFocused.Length >= 2);

            MethodInfo[] isWindowHovered = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "IsWindowHovered").ToArray();
            Assert.True(isWindowHovered.Length >= 2);
        }

        /// <summary>
        ///     Verifies LabelText and ListBox exist.
        /// </summary>
        [Fact]
        public void LabelText_AndListBox_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("LabelText"));

            MethodInfo[] listBox = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "ListBox").ToArray();
            Assert.True(listBox.Length >= 2);
        }

        /// <summary>
        ///     Verifies LoadIniSettings methods exist.
        /// </summary>
        [Fact]
        public void LoadIniSettings_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("LoadIniSettingsFromDisk"));

            MethodInfo[] loadIniSettingsFromMemory = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "LoadIniSettingsFromMemory").ToArray();
            Assert.True(loadIniSettingsFromMemory.Length >= 2);
        }

        /// <summary>
        ///     Verifies Log methods expose expected overloads.
        /// </summary>
        [Fact]
        public void LogMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("LogButtons"));
            Assert.NotNull(typeof(ImGui).GetMethod("LogFinish"));
            Assert.NotNull(typeof(ImGui).GetMethod("LogText"));

            MethodInfo[] logToClipboard = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "LogToClipboard").ToArray();
            Assert.True(logToClipboard.Length >= 2);

            MethodInfo[] logToFile = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "LogToFile").ToArray();
            Assert.True(logToFile.Length >= 3);

            MethodInfo[] logToTty = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "LogToTty").ToArray();
            Assert.True(logToTty.Length >= 2);
        }

        /// <summary>
        ///     Verifies MemAlloc and MemFree exist.
        /// </summary>
        [Fact]
        public void MemAlloc_AndMemFree_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("MemAlloc"));
            Assert.NotNull(typeof(ImGui).GetMethod("MemFree"));
        }

        /// <summary>
        ///     Verifies MenuItem exposes expected overloads.
        /// </summary>
        [Fact]
        public void MenuItem_ShouldExist()
        {
            MethodInfo[] menuItem = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "MenuItem").ToArray();
            Assert.True(menuItem.Length >= 5);
        }
    }
}
