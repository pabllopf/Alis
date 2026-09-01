// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP5NullLabelCoverageTests.cs
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
    ///     The im gui p5 null label coverage tests class
    /// </summary>
    public class ImGuiP5NullLabelCoverageTests
    {
        /// <summary>
        ///     tests the acceptdragdroppayload_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void AcceptDragDropPayload_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.AcceptDragDropPayload(null)));
        }

        /// <summary>
        ///     tests the acceptdragdroppayload_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void AcceptDragDropPayload_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.AcceptDragDropPayload(null, ImGuiDragDropFlags.None)));
        }

        /// <summary>
        ///     tests the arrowbutton null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ArrowButton_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.ArrowButton(null, ImGuiDir.Left)));
        }

        /// <summary>
        ///     tests the begin_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Begin_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            bool pOpen = true;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.Begin(null)));
        }

        /// <summary>
        ///     tests the begin_popen null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Begin_POpen_NullLabel_ShouldThrowArgumentNullException()
        {
            bool pOpen = true;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.Begin(null, ref pOpen)));
        }

        /// <summary>
        ///     tests the begin_popen_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Begin_POpen_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            bool pOpen = true;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.Begin(null, ref pOpen, ImGuiWindowFlags.None)));
        }

        /// <summary>
        ///     tests the beginchild_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginChild_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginChild((string)null)));
        }

        /// <summary>
        ///     tests the beginchild_size null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginChild_Size_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginChild((string)null, new Vector2F(0, 0))));
        }

        /// <summary>
        ///     tests the beginchild_size_border null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginChild_Size_Border_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginChild((string)null, new Vector2F(0, 0), true)));
        }

        /// <summary>
        ///     tests the beginchild_size_border_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginChild_Size_Border_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginChild((string)null, new Vector2F(0, 0), true, ImGuiWindowFlags.None)));
        }

        /// <summary>
        ///     tests the begincombo_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginCombo_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginCombo(null, "p")));
        }

        /// <summary>
        ///     tests the begincombo_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginCombo_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginCombo(null, "p", ImGuiComboFlags.None)));
        }

        /// <summary>
        ///     tests the beginlistbox_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginListBox_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginListBox(null)));
        }

        /// <summary>
        ///     tests the beginlistbox_size null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginListBox_Size_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginListBox(null, new Vector2F(0, 0))));
        }

        /// <summary>
        ///     tests the beginmenu_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginMenu_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginMenu(null)));
        }

        /// <summary>
        ///     tests the beginmenu_enabled null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginMenu_Enabled_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginMenu(null, true)));
        }

        /// <summary>
        ///     tests the beginpopup_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginPopup_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginPopup((string)null)));
        }

        /// <summary>
        ///     tests the beginpopup_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginPopup_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginPopup((string)null, ImGuiWindowFlags.None)));
        }

        /// <summary>
        ///     tests the beginpopupcontextitem_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginPopupContextItem_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginPopupContextItem((string)null)));
        }

        /// <summary>
        ///     tests the beginpopupcontextitem_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginPopupContextItem_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginPopupContextItem((string)null, ImGuiPopupFlags.None)));
        }

        /// <summary>
        ///     tests the beginpopupcontextvoid_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginPopupContextVoid_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginPopupContextVoid((string)null)));
        }

        /// <summary>
        ///     tests the beginpopupcontextvoid_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginPopupContextVoid_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginPopupContextVoid((string)null, ImGuiPopupFlags.None)));
        }

        /// <summary>
        ///     tests the beginpopupcontextwindow_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginPopupContextWindow_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginPopupContextWindow((string)null)));
        }

        /// <summary>
        ///     tests the beginpopupcontextwindow_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginPopupContextWindow_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginPopupContextWindow((string)null, ImGuiPopupFlags.None)));
        }

        /// <summary>
        ///     tests the beginpopupmodal_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginPopupModal_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginPopupModal(null)));
        }

        /// <summary>
        ///     tests the beginpopupmodal_popen null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginPopupModal_POpen_NullLabel_ShouldThrowArgumentNullException()
        {
            bool pOpen = true;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginPopupModal(null, ref pOpen)));
        }

        /// <summary>
        ///     tests the beginpopupmodal_popen_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginPopupModal_POpen_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            bool pOpen = true;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginPopupModal(null, ref pOpen, ImGuiWindowFlags.None)));
        }

        /// <summary>
        ///     tests the begintabbar_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginTabBar_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginTabBar((string)null)));
        }

        /// <summary>
        ///     tests the begintabbar_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginTabBar_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginTabBar((string)null, ImGuiTabBarFlags.None)));
        }

        /// <summary>
        ///     tests the begintabitem_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginTabItem_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginTabItem(null)));
        }

        /// <summary>
        ///     tests the begintabitem_popen null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginTabItem_POpen_NullLabel_ShouldThrowArgumentNullException()
        {
            bool pOpen = true;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginTabItem(null, ref pOpen)));
        }

        /// <summary>
        ///     tests the begintabitem_popen_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginTabItem_POpen_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            bool pOpen = true;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginTabItem(null, ref pOpen, ImGuiTabItemFlags.None)));
        }

        /// <summary>
        ///     tests the begintable_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginTable_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginTable((string)null, 1)));
        }

        /// <summary>
        ///     tests the begintable_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginTable_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginTable((string)null, 1, ImGuiTableFlags.None)));
        }

        /// <summary>
        ///     tests the begintable_flags_outersize null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginTable_Flags_OuterSize_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginTable((string)null, 1, ImGuiTableFlags.None, new Vector2F(0, 0))));
        }

        /// <summary>
        ///     tests the begintable_flags_outersize_innerwidth null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginTable_Flags_OuterSize_InnerWidth_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BeginTable((string)null, 1, ImGuiTableFlags.None, new Vector2F(0, 0), 0.0f)));
        }

        /// <summary>
        ///     tests the bullettext null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BulletText_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.BulletText((string)null)));
        }

        /// <summary>
        ///     tests the button_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Button_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.Button(null)));
        }

        /// <summary>
        ///     tests the button_size null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Button_Size_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.Button(null, new Vector2F(0, 0))));
        }

        /// <summary>
        ///     tests the checkbox null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Checkbox_NullLabel_ShouldThrowArgumentNullException()
        {
            bool v = false;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.Checkbox(null, ref v)));
        }

        /// <summary>
        ///     tests the checkboxflags_int null label should throw argument null exception
        /// </summary>
        [Fact]
        public void CheckboxFlags_Int_NullLabel_ShouldThrowArgumentNullException()
        {
            int flags = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.CheckboxFlags(null, ref flags, 1)));
        }

        /// <summary>
        ///     tests the checkboxflags_uint null label should throw argument null exception
        /// </summary>
        [Fact]
        public void CheckboxFlags_Uint_NullLabel_ShouldThrowArgumentNullException()
        {
            uint flags = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.CheckboxFlags(null, ref flags, 1)));
        }

        /// <summary>
        ///     tests the collapsingheader_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void CollapsingHeader_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.CollapsingHeader(null)));
        }

        /// <summary>
        ///     tests the collapsingheader_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void CollapsingHeader_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.CollapsingHeader(null, ImGuiTreeNodeFlags.None)));
        }

        /// <summary>
        ///     tests the collapsingheader_pvisible null label should throw argument null exception
        /// </summary>
        [Fact]
        public void CollapsingHeader_PVisible_NullLabel_ShouldThrowArgumentNullException()
        {
            bool pVisible = true;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.CollapsingHeader(null, ref pVisible)));
        }

        /// <summary>
        ///     tests the collapsingheader_pvisible_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void CollapsingHeader_PVisible_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            bool pVisible = true;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.CollapsingHeader(null, ref pVisible, ImGuiTreeNodeFlags.None)));
        }

        /// <summary>
        ///     tests the colorbutton_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ColorButton_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.ColorButton(null, new Vector4F(0, 0, 0, 1))));
        }

        /// <summary>
        ///     tests the colorbutton_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ColorButton_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.ColorButton(null, new Vector4F(0, 0, 0, 1), ImGuiColorEditFlags.None)));
        }

        /// <summary>
        ///     tests the colorbutton_flags_size null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ColorButton_Flags_Size_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.ColorButton(null, new Vector4F(0, 0, 0, 1), ImGuiColorEditFlags.None, new Vector2F(0, 0))));
        }

        /// <summary>
        ///     tests the coloredit3_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ColorEdit3_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector3F col = new Vector3F(0, 0, 0);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.ColorEdit3(null, ref col)));
        }

        /// <summary>
        ///     tests the coloredit3_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ColorEdit3_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector3F col = new Vector3F(0, 0, 0);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.ColorEdit3(null, ref col, ImGuiColorEditFlags.None)));
        }

        /// <summary>
        ///     tests the colorpicker3_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ColorPicker3_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector3F col = new Vector3F(0, 0, 0);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.ColorPicker3(null, ref col)));
        }

        /// <summary>
        ///     tests the colorpicker3_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ColorPicker3_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector3F col = new Vector3F(0, 0, 0);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.ColorPicker3(null, ref col, ImGuiColorEditFlags.None)));
        }

        /// <summary>
        ///     tests the colorpicker4_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ColorPicker4_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector4F col = new Vector4F(0, 0, 0, 1);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.ColorPicker4(null, ref col)));
        }

        /// <summary>
        ///     tests the colorpicker4_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ColorPicker4_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector4F col = new Vector4F(0, 0, 0, 1);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.ColorPicker4(null, ref col, ImGuiColorEditFlags.None)));
        }

        /// <summary>
        ///     tests the colorpicker4_flags_refcol null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ColorPicker4_Flags_RefCol_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector4F col = new Vector4F(0, 0, 0, 1);
            float refCol = 0f;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.ColorPicker4(null, ref col, ImGuiColorEditFlags.None, ref refCol)));
        }

        /// <summary>
        ///     tests the columns_id null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Columns_Id_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.Columns(1, (string)null)));
        }

        /// <summary>
        ///     tests the columns_id_border null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Columns_Id_Border_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.Columns(1, (string)null, true)));
        }

        /// <summary>
        ///     tests the combo_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Combo_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            int currentItem = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.Combo("c", ref currentItem, new string[] { "A", null }, 2)));
        }

        /// <summary>
        ///     tests the combo_height null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Combo_Height_NullLabel_ShouldThrowArgumentNullException()
        {
            int currentItem = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.Combo("c", ref currentItem, new string[] { "A", null }, 2, -1)));
        }

    }
}
