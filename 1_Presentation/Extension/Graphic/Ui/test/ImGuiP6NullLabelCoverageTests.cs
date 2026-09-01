// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP6NullLabelCoverageTests.cs
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
using Alis.Core.Aspect.Math.Vector;
using Xunit;
using Alis.Extension.Graphic.Ui;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui p6 null label coverage tests class
    /// </summary>
    public class ImGuiP6NullLabelCoverageTests
    {
        /// <summary>
        ///     tests the inputfloat4_format null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputFloat4_Format_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector4F v = new Vector4F(0, 0, 0, 1);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputFloat4(null, ref v, "%.1f")));
        }

        /// <summary>
        ///     tests the inputfloat4_format_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputFloat4_Format_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector4F v = new Vector4F(0, 0, 0, 1);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputFloat4(null, ref v, "%.1f", ImGuiInputTextFlags.None)));
        }

        /// <summary>
        ///     tests the inputint_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputInt_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputInt(null, ref v)));
        }

        /// <summary>
        ///     tests the inputint_step null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputInt_Step_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputInt(null, ref v, 1)));
        }

        /// <summary>
        ///     tests the inputint_step_stepfast null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputInt_Step_StepFast_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputInt(null, ref v, 1, 10)));
        }

        /// <summary>
        ///     tests the inputint_step_stepfast_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputInt_Step_StepFast_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputInt(null, ref v, 1, 10, ImGuiInputTextFlags.None)));
        }

        /// <summary>
        ///     tests the inputint2_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputInt2_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputInt2(null, ref v)));
        }

        /// <summary>
        ///     tests the inputint2_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputInt2_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputInt2(null, ref v, ImGuiInputTextFlags.None)));
        }

        /// <summary>
        ///     tests the inputint3_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputInt3_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputInt3(null, ref v)));
        }

        /// <summary>
        ///     tests the inputint3_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputInt3_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputInt3(null, ref v, ImGuiInputTextFlags.None)));
        }

        /// <summary>
        ///     tests the inputint4_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputInt4_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputInt4(null, ref v)));
        }

        /// <summary>
        ///     tests the inputint4_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputInt4_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputInt4(null, ref v, ImGuiInputTextFlags.None)));
        }

        /// <summary>
        ///     tests the inputscalar_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputScalar_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputScalar(null, (ImGuiDataType)0, IntPtr.Zero)));
        }

        /// <summary>
        ///     tests the inputscalar_pstep null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputScalar_PStep_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputScalar(null, (ImGuiDataType)0, IntPtr.Zero, IntPtr.Zero)));
        }

        /// <summary>
        ///     tests the inputscalar_pstep_pstepfast null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputScalar_PStep_PStepFast_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputScalar(null, (ImGuiDataType)0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero)));
        }

        /// <summary>
        ///     tests the inputscalar_pstep_pstepfast_format null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputScalar_PStep_PStepFast_Format_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputScalar(null, (ImGuiDataType)0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, "%.1f")));
        }

        /// <summary>
        ///     tests the inputscalar_pstep_pstepfast_format_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputScalar_PStep_PStepFast_Format_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputScalar(null, (ImGuiDataType)0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, "%.1f", ImGuiInputTextFlags.None)));
        }

        /// <summary>
        ///     tests the inputscalarn_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputScalarN_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputScalarN(null, (ImGuiDataType)0, IntPtr.Zero, 1)));
        }

        /// <summary>
        ///     tests the inputscalarn_pstep null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputScalarN_PStep_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputScalarN(null, (ImGuiDataType)0, IntPtr.Zero, 1, IntPtr.Zero)));
        }

        /// <summary>
        ///     tests the inputscalarn_pstep_pstepfast null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputScalarN_PStep_PStepFast_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputScalarN(null, (ImGuiDataType)0, IntPtr.Zero, 1, IntPtr.Zero, IntPtr.Zero)));
        }

        /// <summary>
        ///     tests the inputscalarn_pstep_pstepfast_format null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputScalarN_PStep_PStepFast_Format_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputScalarN(null, (ImGuiDataType)0, IntPtr.Zero, 1, IntPtr.Zero, IntPtr.Zero, "%.1f")));
        }

        /// <summary>
        ///     tests the inputscalarn_pstep_pstepfast_format_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputScalarN_PStep_PStepFast_Format_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputScalarN(null, (ImGuiDataType)0, IntPtr.Zero, 1, IntPtr.Zero, IntPtr.Zero, "%.1f", ImGuiInputTextFlags.None)));
        }

        /// <summary>
        ///     tests the invisiblebutton_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InvisibleButton_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InvisibleButton(null, new Vector2F(0, 0))));
        }

        /// <summary>
        ///     tests the invisiblebutton_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InvisibleButton_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InvisibleButton(null, new Vector2F(0, 0), ImGuiButtonFlags.None)));
        }

        /// <summary>
        ///     tests the ispopupopen_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void IsPopupOpen_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.IsPopupOpen((string)null)));
        }

        /// <summary>
        ///     tests the ispopupopen_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void IsPopupOpen_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.IsPopupOpen((string)null, ImGuiPopupFlags.None)));
        }

        /// <summary>
        ///     tests the labeltext null label should throw argument null exception
        /// </summary>
        [Fact]
        public void LabelText_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.LabelText(null, "f")));
        }

        /// <summary>
        ///     tests the listbox_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ListBox_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            int currentItem = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.ListBox("l", ref currentItem, new string[] { "A", null }, 2)));
        }

        /// <summary>
        ///     tests the listbox_height null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ListBox_Height_NullLabel_ShouldThrowArgumentNullException()
        {
            int currentItem = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.ListBox("l", ref currentItem, new string[] { "A", null }, 2, -1)));
        }

        /// <summary>
        ///     tests the loadinisettingsfromdisk null label should throw argument null exception
        /// </summary>
        [Fact]
        public void LoadIniSettingsFromDisk_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.LoadIniSettingsFromDisk((string)null)));
        }

        /// <summary>
        ///     tests the loadinisettingsfrommemory_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void LoadIniSettingsFromMemory_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.LoadIniSettingsFromMemory((string)null)));
        }

        /// <summary>
        ///     tests the loadinisettingsfrommemory_size null label should throw argument null exception
        /// </summary>
        [Fact]
        public void LoadIniSettingsFromMemory_Size_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.LoadIniSettingsFromMemory((string)null, 0)));
        }

        /// <summary>
        ///     tests the logtext null label should throw argument null exception
        /// </summary>
        [Fact]
        public void LogText_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.LogText((string)null)));
        }

        /// <summary>
        ///     tests the logtofile null label should throw argument null exception
        /// </summary>
        [Fact]
        public void LogToFile_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.LogToFile(0, (string)null)));
        }

        /// <summary>
        ///     tests the menuitem_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void MenuItem_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.MenuItem(null)));
        }

        /// <summary>
        ///     tests the menuitem_shortcut null label should throw argument null exception
        /// </summary>
        [Fact]
        public void MenuItem_Shortcut_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.MenuItem(null, "s")));
        }

        /// <summary>
        ///     tests the menuitem_shortcut_selected null label should throw argument null exception
        /// </summary>
        [Fact]
        public void MenuItem_Shortcut_Selected_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.MenuItem(null, "s", true)));
        }

        /// <summary>
        ///     tests the menuitem_shortcut_selected_enabled null label should throw argument null exception
        /// </summary>
        [Fact]
        public void MenuItem_Shortcut_Selected_Enabled_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.MenuItem(null, "s", true, true)));
        }

        /// <summary>
        ///     tests the menuitem_shortcut_refselected null label should throw argument null exception
        /// </summary>
        [Fact]
        public void MenuItem_Shortcut_RefSelected_NullLabel_ShouldThrowArgumentNullException()
        {
            bool pSelected = false;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.MenuItem(null, "s", ref pSelected)));
        }

    }
}
