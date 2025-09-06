// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTestP6.cs
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

using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Native
{
    /// <summary>
    ///     The im gui test class
    /// </summary>
    public class ImGuiTestP6
    {
        /// <summary>
        ///     Tests that log to clipboard throws dll not found exception 6
        /// </summary>
        [Fact]
        public void LogToClipboard_ThrowsDllNotFoundException_6()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.LogToClipboard(-1));
        }

        /// <summary>
        ///     Tests that log to file throws dll not found exception 4
        /// </summary>
        [Fact]
        public void LogToFile_ThrowsDllNotFoundException_4()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.LogToFile(-1));
        }

        /// <summary>
        ///     Tests that log to file with filename throws dll not found exception
        /// </summary>
        [Fact]
        public void LogToFile_WithFilename_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.LogToFile(-1, "test.log"));
        }

        /// <summary>
        ///     Tests that log to tty throws dll not found exception
        /// </summary>
        [Fact]
        public void LogToTty_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.LogToTty(-1));
        }

        /// <summary>
        ///     Tests that mem alloc throws dll not found exception
        /// </summary>
        [Fact]
        public void MemAlloc_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.MemAlloc(1024));
        }

        /// <summary>
        ///     Tests that mem free throws dll not found exception
        /// </summary>
        [Fact]
        public void MemFree_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.MemFree(IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that menu item throws dll not found exception
        /// </summary>
        [Fact]
        public void MenuItem_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.MenuItem("File"));
        }

        /// <summary>
        ///     Tests that menu item with shortcut throws dll not found exception
        /// </summary>
        [Fact]
        public void MenuItem_WithShortcut_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.MenuItem("File", "Ctrl+F"));
        }

        /// <summary>
        ///     Tests that menu item with selected throws dll not found exception
        /// </summary>
        [Fact]
        public void MenuItem_WithSelected_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.MenuItem("File", "Ctrl+F", true));
        }

        /// <summary>
        ///     Tests that menu item with selected and enabled throws dll not found exception
        /// </summary>
        [Fact]
        public void MenuItem_WithSelectedAndEnabled_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.MenuItem("File", "Ctrl+F", true, true));
        }

        /// <summary>
        ///     Tests that menu item with ref selected throws dll not found exception
        /// </summary>
        [Fact]
        public void MenuItem_WithRefSelected_ThrowsDllNotFoundException()
        {
            bool selected = false;
            Assert.Throws<DllNotFoundException>(() => ImGui.MenuItem("File", "Ctrl+F", ref selected));
        }

        /// <summary>
        ///     Tests that input float 4 throws dll not found exception
        /// </summary>
        [Fact]
        public void InputFloat4_ThrowsDllNotFoundException()
        {
            Vector4F v = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImGui.InputFloat4("Label", ref v, "%.3f"));
        }

        /// <summary>
        ///     Tests that input float 4 with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void InputFloat4_WithFlags_ThrowsDllNotFoundException()
        {
            Vector4F v = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImGui.InputFloat4("Label", ref v, "%.3f", ImGuiInputTextFlags.None));
        }

        /// <summary>
        ///     Tests that input int throws dll not found exception
        /// </summary>
        [Fact]
        public void InputInt_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.InputInt("Label", ref v));
        }

        /// <summary>
        ///     Tests that input int with step throws dll not found exception
        /// </summary>
        [Fact]
        public void InputInt_WithStep_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.InputInt("Label", ref v, 1));
        }

        /// <summary>
        ///     Tests that input int with step and step fast throws dll not found exception
        /// </summary>
        [Fact]
        public void InputInt_WithStepAndStepFast_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.InputInt("Label", ref v, 1, 100));
        }

        /// <summary>
        ///     Tests that input int with step step fast and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void InputInt_WithStepStepFastAndFlags_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.InputInt("Label", ref v, 1, 100, ImGuiInputTextFlags.None));
        }

        /// <summary>
        ///     Tests that input int 2 throws dll not found exception
        /// </summary>
        [Fact]
        public void InputInt2_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.InputInt2("Label", ref v));
        }

        /// <summary>
        ///     Tests that input int 2 with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void InputInt2_WithFlags_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.InputInt2("Label", ref v, ImGuiInputTextFlags.None));
        }

        /// <summary>
        ///     Tests that input int 3 throws dll not found exception
        /// </summary>
        [Fact]
        public void InputInt3_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.InputInt3("Label", ref v));
        }

        /// <summary>
        ///     Tests that input int 3 with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void InputInt3_WithFlags_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.InputInt3("Label", ref v, ImGuiInputTextFlags.None));
        }

        /// <summary>
        ///     Tests that input int 4 throws dll not found exception
        /// </summary>
        [Fact]
        public void InputInt4_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.InputInt4("Label", ref v));
        }

        /// <summary>
        ///     Tests that input int 4 with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void InputInt4_WithFlags_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.InputInt4("Label", ref v, ImGuiInputTextFlags.None));
        }

        /// <summary>
        ///     Tests that input scalar throws dll not found exception
        /// </summary>
        [Fact]
        public void InputScalar_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.InputScalar("Label", ImGuiDataType.S32, IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that input scalar with step throws dll not found exception
        /// </summary>
        [Fact]
        public void InputScalar_WithStep_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.InputScalar("Label", ImGuiDataType.S32, IntPtr.Zero, IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that input scalar with step and step fast throws dll not found exception
        /// </summary>
        [Fact]
        public void InputScalar_WithStepAndStepFast_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.InputScalar("Label", ImGuiDataType.S32, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that input scalar with step step fast and format throws dll not found exception
        /// </summary>
        [Fact]
        public void InputScalar_WithStepStepFastAndFormat_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.InputScalar("Label", ImGuiDataType.S32, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, "%.3f"));
        }

        /// <summary>
        ///     Tests that input scalar with step step fast format and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void InputScalar_WithStepStepFastFormatAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.InputScalar("Label", ImGuiDataType.S32, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, "%.3f", ImGuiInputTextFlags.None));
        }

        /// <summary>
        ///     Tests that input scalar n throws dll not found exception
        /// </summary>
        [Fact]
        public void InputScalarN_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.InputScalarN("Label", ImGuiDataType.S32, IntPtr.Zero, 4));
        }

        /// <summary>
        ///     Tests that input scalar n with step throws dll not found exception
        /// </summary>
        [Fact]
        public void InputScalarN_WithStep_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.InputScalarN("Label", ImGuiDataType.S32, IntPtr.Zero, 4, IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that input scalar n with step and step fast throws dll not found exception
        /// </summary>
        [Fact]
        public void InputScalarN_WithStepAndStepFast_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.InputScalarN("Label", ImGuiDataType.S32, IntPtr.Zero, 4, IntPtr.Zero, IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that input scalar n with step step fast and format throws dll not found exception
        /// </summary>
        [Fact]
        public void InputScalarN_WithStepStepFastAndFormat_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.InputScalarN("Label", ImGuiDataType.S32, IntPtr.Zero, 4, IntPtr.Zero, IntPtr.Zero, "%.3f"));
        }

        /// <summary>
        ///     Tests that input scalar n with step step fast format and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void InputScalarN_WithStepStepFastFormatAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.InputScalarN("Label", ImGuiDataType.S32, IntPtr.Zero, 4, IntPtr.Zero, IntPtr.Zero, "%.3f", ImGuiInputTextFlags.None));
        }

        /// <summary>
        ///     Tests that invisible button throws dll not found exception
        /// </summary>
        [Fact]
        public void InvisibleButton_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.InvisibleButton("Button", new Vector2F(100, 50)));
        }

        /// <summary>
        ///     Tests that invisible button with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void InvisibleButton_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.InvisibleButton("Button", new Vector2F(100, 50), ImGuiButtonFlags.None));
        }

        /// <summary>
        ///     Tests that is any item active throws dll not found exception
        /// </summary>
        [Fact]
        public void IsAnyItemActive_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsAnyItemActive());
        }

        /// <summary>
        ///     Tests that is any item focused throws dll not found exception
        /// </summary>
        [Fact]
        public void IsAnyItemFocused_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsAnyItemFocused());
        }

        /// <summary>
        ///     Tests that is any item hovered throws dll not found exception
        /// </summary>
        [Fact]
        public void IsAnyItemHovered_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsAnyItemHovered());
        }

        /// <summary>
        ///     Tests that is any mouse down throws dll not found exception
        /// </summary>
        [Fact]
        public void IsAnyMouseDown_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsAnyMouseDown());
        }

        /// <summary>
        ///     Tests that is item activated throws dll not found exception
        /// </summary>
        [Fact]
        public void IsItemActivated_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsItemActivated());
        }

        /// <summary>
        ///     Tests that is item active throws dll not found exception
        /// </summary>
        [Fact]
        public void IsItemActive_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsItemActive());
        }

        /// <summary>
        ///     Tests that is item clicked throws dll not found exception
        /// </summary>
        [Fact]
        public void IsItemClicked_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsItemClicked());
        }

        /// <summary>
        ///     Tests that is item clicked with mouse button throws dll not found exception
        /// </summary>
        [Fact]
        public void IsItemClicked_WithMouseButton_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsItemClicked(ImGuiMouseButton.Left));
        }

        /// <summary>
        ///     Tests that is item deactivated throws dll not found exception
        /// </summary>
        [Fact]
        public void IsItemDeactivated_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsItemDeactivated());
        }

        /// <summary>
        ///     Tests that is item deactivated after edit throws dll not found exception
        /// </summary>
        [Fact]
        public void IsItemDeactivatedAfterEdit_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsItemDeactivatedAfterEdit());
        }

        /// <summary>
        ///     Tests that is item edited throws dll not found exception
        /// </summary>
        [Fact]
        public void IsItemEdited_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsItemEdited());
        }

        /// <summary>
        ///     Tests that is item focused throws dll not found exception
        /// </summary>
        [Fact]
        public void IsItemFocused_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsItemFocused());
        }

        /// <summary>
        ///     Tests that is item hovered throws dll not found exception
        /// </summary>
        [Fact]
        public void IsItemHovered_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsItemHovered());
        }

        /// <summary>
        ///     Tests that is item hovered with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void IsItemHovered_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsItemHovered(ImGuiHoveredFlags.None));
        }

        /// <summary>
        ///     Tests that is item toggled open throws dll not found exception
        /// </summary>
        [Fact]
        public void IsItemToggledOpen_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsItemToggledOpen());
        }

        /// <summary>
        ///     Tests that is item visible throws dll not found exception
        /// </summary>
        [Fact]
        public void IsItemVisible_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsItemVisible());
        }

        /// <summary>
        ///     Tests that is key down throws dll not found exception
        /// </summary>
        [Fact]
        public void IsKeyDown_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsKeyDown(ImGuiKey.A));
        }

        /// <summary>
        ///     Tests that is key pressed throws dll not found exception
        /// </summary>
        [Fact]
        public void IsKeyPressed_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsKeyPressed(ImGuiKey.A));
        }

        /// <summary>
        ///     Tests that is key pressed with repeat throws dll not found exception
        /// </summary>
        [Fact]
        public void IsKeyPressed_WithRepeat_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsKeyPressed(ImGuiKey.A, true));
        }

        /// <summary>
        ///     Tests that is key released throws dll not found exception
        /// </summary>
        [Fact]
        public void IsKeyReleased_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsKeyReleased(ImGuiKey.A));
        }

        /// <summary>
        ///     Tests that is mouse clicked throws dll not found exception
        /// </summary>
        [Fact]
        public void IsMouseClicked_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsMouseClicked(ImGuiMouseButton.Left));
        }

        /// <summary>
        ///     Tests that is mouse clicked with repeat throws dll not found exception
        /// </summary>
        [Fact]
        public void IsMouseClicked_WithRepeat_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsMouseClicked(ImGuiMouseButton.Left, true));
        }

        /// <summary>
        ///     Tests that is mouse double clicked throws dll not found exception
        /// </summary>
        [Fact]
        public void IsMouseDoubleClicked_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left));
        }

        /// <summary>
        ///     Tests that is mouse down throws dll not found exception
        /// </summary>
        [Fact]
        public void IsMouseDown_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsMouseDown(ImGuiMouseButton.Left));
        }

        /// <summary>
        ///     Tests that is mouse dragging throws dll not found exception
        /// </summary>
        [Fact]
        public void IsMouseDragging_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsMouseDragging(ImGuiMouseButton.Left));
        }

        /// <summary>
        ///     Tests that is mouse dragging with lock threshold throws dll not found exception
        /// </summary>
        [Fact]
        public void IsMouseDragging_WithLockThreshold_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsMouseDragging(ImGuiMouseButton.Left, 0.5f));
        }

        /// <summary>
        ///     Tests that is mouse hovering rect throws dll not found exception
        /// </summary>
        [Fact]
        public void IsMouseHoveringRect_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsMouseHoveringRect(new Vector2F(0, 0), new Vector2F(100, 100)));
        }

        /// <summary>
        ///     Tests that is mouse hovering rect with clip throws dll not found exception
        /// </summary>
        [Fact]
        public void IsMouseHoveringRect_WithClip_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsMouseHoveringRect(new Vector2F(0, 0), new Vector2F(100, 100), true));
        }

        /// <summary>
        ///     Tests that is mouse pos valid throws dll not found exception
        /// </summary>
        [Fact]
        public void IsMousePosValid_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsMousePosValid());
        }

        /// <summary>
        ///     Tests that is mouse pos valid with mouse pos throws dll not found exception
        /// </summary>
        [Fact]
        public void IsMousePosValid_WithMousePos_ThrowsDllNotFoundException()
        {
            Vector2F mousePos = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImGui.IsMousePosValid(ref mousePos));
        }

        /// <summary>
        ///     Tests that is mouse released throws dll not found exception
        /// </summary>
        [Fact]
        public void IsMouseReleased_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsMouseReleased(ImGuiMouseButton.Left));
        }

        /// <summary>
        ///     Tests that is popup open throws dll not found exception
        /// </summary>
        [Fact]
        public void IsPopupOpen_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsPopupOpen("Popup"));
        }

        /// <summary>
        ///     Tests that is popup open with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void IsPopupOpen_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsPopupOpen("Popup", ImGuiPopupFlags.None));
        }

        /// <summary>
        ///     Tests that is rect visible throws dll not found exception
        /// </summary>
        [Fact]
        public void IsRectVisible_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsRectVisible(new Vector2F(100, 100)));
        }

        /// <summary>
        ///     Tests that is rect visible with rect min and rect max throws dll not found exception
        /// </summary>
        [Fact]
        public void IsRectVisible_WithRectMinAndRectMax_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsRectVisible(new Vector2F(0, 0), new Vector2F(100, 100)));
        }

        /// <summary>
        ///     Tests that is window appearing throws dll not found exception
        /// </summary>
        [Fact]
        public void IsWindowAppearing_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsWindowAppearing());
        }

        /// <summary>
        ///     Tests that is window collapsed throws dll not found exception
        /// </summary>
        [Fact]
        public void IsWindowCollapsed_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsWindowCollapsed());
        }

        /// <summary>
        ///     Tests that is window docked throws dll not found exception
        /// </summary>
        [Fact]
        public void IsWindowDocked_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsWindowDocked());
        }

        /// <summary>
        ///     Tests that is window focused throws dll not found exception
        /// </summary>
        [Fact]
        public void IsWindowFocused_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsWindowFocused());
        }

        /// <summary>
        ///     Tests that is window focused with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void IsWindowFocused_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsWindowFocused(ImGuiFocusedFlags.None));
        }

        /// <summary>
        ///     Tests that is window hovered throws dll not found exception
        /// </summary>
        [Fact]
        public void IsWindowHovered_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsWindowHovered());
        }

        /// <summary>
        ///     Tests that is window hovered with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void IsWindowHovered_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.IsWindowHovered(ImGuiHoveredFlags.None));
        }

        /// <summary>
        ///     Tests that label text throws dll not found exception
        /// </summary>
        [Fact]
        public void LabelText_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.LabelText("Label", "Text"));
        }

        /// <summary>
        ///     Tests that list box throws dll not found exception
        /// </summary>
        [Fact]
        public void ListBox_ThrowsDllNotFoundException()
        {
            int currentItem = 0;
            string[] items = {"Item1", "Item2"};
            Assert.Throws<MarshalDirectiveException>(() => ImGui.ListBox("Label", ref currentItem, items, items.Length));
        }

        /// <summary>
        ///     Tests that list box with height in items throws dll not found exception
        /// </summary>
        [Fact]
        public void ListBox_WithHeightInItems_ThrowsDllNotFoundException()
        {
            int currentItem = 0;
            string[] items = {"Item1", "Item2"};
            Assert.Throws<MarshalDirectiveException>(() => ImGui.ListBox("Label", ref currentItem, items, items.Length, 5));
        }

        /// <summary>
        ///     Tests that load ini settings from disk throws dll not found exception
        /// </summary>
        [Fact]
        public void LoadIniSettingsFromDisk_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.LoadIniSettingsFromDisk("settings.ini"));
        }

        /// <summary>
        ///     Tests that load ini settings from memory throws dll not found exception
        /// </summary>
        [Fact]
        public void LoadIniSettingsFromMemory_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.LoadIniSettingsFromMemory("iniData"));
        }

        /// <summary>
        ///     Tests that load ini settings from memory with ini size throws dll not found exception
        /// </summary>
        [Fact]
        public void LoadIniSettingsFromMemory_WithIniSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.LoadIniSettingsFromMemory("iniData", 1024));
        }

        /// <summary>
        ///     Tests that log buttons throws dll not found exception
        /// </summary>
        [Fact]
        public void LogButtons_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.LogButtons());
        }

        /// <summary>
        ///     Tests that log finish throws dll not found exception
        /// </summary>
        [Fact]
        public void LogFinish_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.LogFinish());
        }

        /// <summary>
        ///     Tests that log text throws dll not found exception
        /// </summary>
        [Fact]
        public void LogText_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.LogText("Log message"));
        }

        /// <summary>
        ///     Tests that log to clipboard throws dll not found exception
        /// </summary>
        [Fact]
        public void LogToClipboard_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.LogToClipboard());
        }

        /// <summary>
        ///     Tests that log to clipboard with auto open depth throws dll not found exception
        /// </summary>
        [Fact]
        public void LogToClipboard_WithAutoOpenDepth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.LogToClipboard(-1));
        }

        /// <summary>
        ///     Tests that log to file throws dll not found exception
        /// </summary>
        [Fact]
        public void LogToFile_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.LogToFile());
        }

        /// <summary>
        ///     Tests that log to file with auto open depth throws dll not found exception
        /// </summary>
        [Fact]
        public void LogToFile_WithAutoOpenDepth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.LogToFile(-1));
        }

        /// <summary>
        ///     Tests that log to file with auto open depth and filename throws dll not found exception
        /// </summary>
        [Fact]
        public void LogToFile_WithAutoOpenDepthAndFilename_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.LogToFile(-1, "log.txt"));
        }

        /// <summary>
        ///     Tests that log to tty throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void LogToTty_ThrowsDllNotFoundException_V3()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.LogToTty());
        }

        /// <summary>
        ///     Tests that log to tty with auto open depth throws dll not found exception
        /// </summary>
        [Fact]
        public void LogToTty_WithAutoOpenDepth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.LogToTty(-1));
        }
    }
}