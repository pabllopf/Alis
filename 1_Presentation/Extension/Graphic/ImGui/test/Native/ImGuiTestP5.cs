// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTestP5.cs
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

namespace Alis.Extension.Graphic.ImGui.Test.Native
{
    /// <summary>
    ///     The im gui test class
    /// </summary>
    public class ImGuiTestP5
    {
        /// <summary>
        ///     Tests that accept drag drop payload with type throws dll not found exception
        /// </summary>
        [Fact]
        public void AcceptDragDropPayload_WithType_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.AcceptDragDropPayload("type"));
        }

        /// <summary>
        ///     Tests that accept drag drop payload with type and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void AcceptDragDropPayload_WithTypeAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.AcceptDragDropPayload("type", ImGuiDragDropFlags.None));
        }

        /// <summary>
        ///     Tests that align text to frame padding throws dll not found exception
        /// </summary>
        [Fact]
        public void AlignTextToFramePadding_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.AlignTextToFramePadding());
        }

        /// <summary>
        ///     Tests that arrow button throws dll not found exception
        /// </summary>
        [Fact]
        public void ArrowButton_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ArrowButton("strId", ImGuiDir.None));
        }

        /// <summary>
        ///     Tests that begin with name throws dll not found exception
        /// </summary>
        [Fact]
        public void Begin_WithName_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Begin("name"));
        }

        /// <summary>
        ///     Tests that begin with name and ref bool throws dll not found exception
        /// </summary>
        [Fact]
        public void Begin_WithNameAndRefBool_ThrowsDllNotFoundException()
        {
            bool pOpen = true;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Begin("name", ref pOpen));
        }

        /// <summary>
        ///     Tests that begin with name ref bool and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void Begin_WithNameRefBoolAndFlags_ThrowsDllNotFoundException()
        {
            bool pOpen = true;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Begin("name", ref pOpen, ImGuiWindowFlags.None));
        }

        /// <summary>
        ///     Tests that begin child with str id throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginChild_WithStrId_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginChild("strId"));
        }

        /// <summary>
        ///     Tests that begin child with str id and size throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginChild_WithStrIdAndSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginChild("strId", new Vector2F()));
        }

        /// <summary>
        ///     Tests that begin child with str id size and border throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginChild_WithStrIdSizeAndBorder_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginChild("strId", new Vector2F(), true));
        }

        /// <summary>
        ///     Tests that begin child with str id size border and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginChild_WithStrIdSizeBorderAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginChild("strId", new Vector2F(), true, ImGuiWindowFlags.None));
        }

        /// <summary>
        ///     Tests that begin child with id throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginChild_WithId_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginChild(1u));
        }

        /// <summary>
        ///     Tests that begin child with id and size throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginChild_WithIdAndSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginChild(1u, new Vector2F()));
        }

        /// <summary>
        ///     Tests that begin child with id size and border throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginChild_WithIdSizeAndBorder_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginChild(1u, new Vector2F(), true));
        }

        /// <summary>
        ///     Tests that begin child with id size border and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginChild_WithIdSizeBorderAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginChild(1u, new Vector2F(), true, ImGuiWindowFlags.None));
        }

        /// <summary>
        ///     Tests that begin child frame with id and size throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginChildFrame_WithIdAndSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginChildFrame(1u, new Vector2F()));
        }

        /// <summary>
        ///     Tests that begin child frame with id size and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginChildFrame_WithIdSizeAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginChildFrame(1u, new Vector2F(), ImGuiWindowFlags.None));
        }

        /// <summary>
        ///     Tests that begin combo with label and preview value throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginCombo_WithLabelAndPreviewValue_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginCombo("label", "previewValue"));
        }

        /// <summary>
        ///     Tests that begin combo with label preview value and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginCombo_WithLabelPreviewValueAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginCombo("label", "previewValue", ImGuiComboFlags.None));
        }

        /// <summary>
        ///     Tests that begin disabled throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginDisabled_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginDisabled());
        }

        /// <summary>
        ///     Tests that begin disabled with bool throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginDisabled_WithBool_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginDisabled(true));
        }

        /// <summary>
        ///     Tests that begin drag drop source throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginDragDropSource_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginDragDropSource());
        }

        /// <summary>
        ///     Tests that begin drag drop source with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginDragDropSource_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginDragDropSource(ImGuiDragDropFlags.None));
        }

        /// <summary>
        ///     Tests that begin drag drop target throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginDragDropTarget_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginDragDropTarget());
        }

        /// <summary>
        ///     Tests that begin group throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginGroup_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginGroup());
        }

        /// <summary>
        ///     Tests that begin list box with label throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginListBox_WithLabel_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginListBox("label"));
        }

        /// <summary>
        ///     Tests that begin list box with label and size throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginListBox_WithLabelAndSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginListBox("label", new Vector2F()));
        }

        /// <summary>
        ///     Tests that begin main menu bar throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginMainMenuBar_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginMainMenuBar());
        }

        /// <summary>
        ///     Tests that begin menu with label throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginMenu_WithLabel_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginMenu("label"));
        }

        /// <summary>
        ///     Tests that begin menu with label and enabled throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginMenu_WithLabelAndEnabled_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginMenu("label", true));
        }

        /// <summary>
        ///     Tests that begin menu bar throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginMenuBar_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginMenuBar());
        }

        /// <summary>
        ///     Tests that begin popup with str id throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginPopup_WithStrId_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginPopup("strId"));
        }

        /// <summary>
        ///     Tests that begin popup with str id and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginPopup_WithStrIdAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginPopup("strId", ImGuiWindowFlags.None));
        }

        /// <summary>
        ///     Tests that begin popup context item throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginPopupContextItem_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginPopupContextItem());
        }

        /// <summary>
        ///     Tests that begin popup context item with str id throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginPopupContextItem_WithStrId_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginPopupContextItem("strId"));
        }

        /// <summary>
        ///     Tests that begin popup context item with str id and popup flags throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginPopupContextItem_WithStrIdAndPopupFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginPopupContextItem("strId", ImGuiPopupFlags.None));
        }

        /// <summary>
        ///     Tests that begin popup context void throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginPopupContextVoid_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginPopupContextVoid());
        }

        /// <summary>
        ///     Tests that begin popup context void with str id throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginPopupContextVoid_WithStrId_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginPopupContextVoid("strId"));
        }

        /// <summary>
        ///     Tests that begin popup context void with str id and popup flags throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginPopupContextVoid_WithStrIdAndPopupFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginPopupContextVoid("strId", ImGuiPopupFlags.None));
        }

        /// <summary>
        ///     Tests that begin popup context window throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginPopupContextWindow_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginPopupContextWindow());
        }

        /// <summary>
        ///     Tests that begin popup context window with str id throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginPopupContextWindow_WithStrId_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginPopupContextWindow("strId"));
        }

        /// <summary>
        ///     Tests that begin popup context window with str id and popup flags throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginPopupContextWindow_WithStrIdAndPopupFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginPopupContextWindow("strId", ImGuiPopupFlags.None));
        }

        /// <summary>
        ///     Tests that begin popup modal with name throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginPopupModal_WithName_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginPopupModal("name"));
        }

        /// <summary>
        ///     Tests that begin popup modal with name and ref bool throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginPopupModal_WithNameAndRefBool_ThrowsDllNotFoundException()
        {
            bool pOpen = true;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginPopupModal("name", ref pOpen));
        }

        /// <summary>
        ///     Tests that begin popup modal with name ref bool and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginPopupModal_WithNameRefBoolAndFlags_ThrowsDllNotFoundException()
        {
            bool pOpen = true;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginPopupModal("name", ref pOpen, ImGuiWindowFlags.None));
        }

        /// <summary>
        ///     Tests that begin tab bar with str id throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginTabBar_WithStrId_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginTabBar("strId"));
        }

        /// <summary>
        ///     Tests that begin tab bar with str id and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginTabBar_WithStrIdAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginTabBar("strId", ImGuiTabBarFlags.None));
        }

        /// <summary>
        ///     Tests that begin tab item with label throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginTabItem_WithLabel_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginTabItem("label"));
        }

        /// <summary>
        ///     Tests that begin tab item with label and ref bool throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginTabItem_WithLabelAndRefBool_ThrowsDllNotFoundException()
        {
            bool pOpen = true;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginTabItem("label", ref pOpen));
        }

        /// <summary>
        ///     Tests that begin tab item with label ref bool and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginTabItem_WithLabelRefBoolAndFlags_ThrowsDllNotFoundException()
        {
            bool pOpen = true;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginTabItem("label", ref pOpen, ImGuiTabItemFlags.None));
        }

        /// <summary>
        ///     Tests that begin table with str id and column throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginTable_WithStrIdAndColumn_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginTable("strId", 1));
        }

        /// <summary>
        ///     Tests that begin table with str id column and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginTable_WithStrIdColumnAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginTable("strId", 1, ImGuiTableFlags.None));
        }

        /// <summary>
        ///     Tests that begin table with str id column flags and outer size throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginTable_WithStrIdColumnFlagsAndOuterSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginTable("strId", 1, ImGuiTableFlags.None, new Vector2F()));
        }

        /// <summary>
        ///     Tests that begin table with str id column flags outer size and inner width throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginTable_WithStrIdColumnFlagsOuterSizeAndInnerWidth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginTable("strId", 1, ImGuiTableFlags.None, new Vector2F(), 0.0f));
        }

        /// <summary>
        ///     Tests that begin tooltip throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginTooltip_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BeginTooltip());
        }

        /// <summary>
        ///     Tests that bullet throws dll not found exception
        /// </summary>
        [Fact]
        public void Bullet_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Bullet());
        }

        /// <summary>
        ///     Tests that bullet text throws dll not found exception
        /// </summary>
        [Fact]
        public void BulletText_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.BulletText("fmt"));
        }

        /// <summary>
        ///     Tests that button with label throws dll not found exception
        /// </summary>
        [Fact]
        public void Button_WithLabel_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Button("label"));
        }

        /// <summary>
        ///     Tests that button with label and size throws dll not found exception
        /// </summary>
        [Fact]
        public void Button_WithLabelAndSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Button("label", new Vector2F()));
        }

        /// <summary>
        ///     Tests that calc item width throws dll not found exception
        /// </summary>
        [Fact]
        public void CalcItemWidth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.CalcItemWidth());
        }

        /// <summary>
        ///     Tests that checkbox with label and ref bool throws dll not found exception
        /// </summary>
        [Fact]
        public void Checkbox_WithLabelAndRefBool_ThrowsDllNotFoundException()
        {
            bool v = true;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Checkbox("label", ref v));
        }

        /// <summary>
        ///     Tests that checkbox flags with label ref int and flags value throws dll not found exception
        /// </summary>
        [Fact]
        public void CheckboxFlags_WithLabelRefIntAndFlagsValue_ThrowsDllNotFoundException()
        {
            int flags = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.CheckboxFlags("label", ref flags, 1));
        }

        /// <summary>
        ///     Tests that checkbox flags with label ref uint and flags value throws dll not found exception
        /// </summary>
        [Fact]
        public void CheckboxFlags_WithLabelRefUintAndFlagsValue_ThrowsDllNotFoundException()
        {
            uint flags = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.CheckboxFlags("label", ref flags, 1u));
        }

        /// <summary>
        ///     Tests that close current popup throws dll not found exception
        /// </summary>
        [Fact]
        public void CloseCurrentPopup_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.CloseCurrentPopup());
        }

        /// <summary>
        ///     Tests that collapsing header with label throws dll not found exception
        /// </summary>
        [Fact]
        public void CollapsingHeader_WithLabel_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.CollapsingHeader("label"));
        }

        /// <summary>
        ///     Tests that collapsing header with label and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void CollapsingHeader_WithLabelAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.CollapsingHeader("label", ImGuiTreeNodeFlags.None));
        }

        /// <summary>
        ///     Tests that collapsing header with label and ref bool throws dll not found exception
        /// </summary>
        [Fact]
        public void CollapsingHeader_WithLabelAndRefBool_ThrowsDllNotFoundException()
        {
            bool pVisible = true;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.CollapsingHeader("label", ref pVisible));
        }

        /// <summary>
        ///     Tests that collapsing header with label ref bool and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void CollapsingHeader_WithLabelRefBoolAndFlags_ThrowsDllNotFoundException()
        {
            bool pVisible = true;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.CollapsingHeader("label", ref pVisible, ImGuiTreeNodeFlags.None));
        }

        /// <summary>
        ///     Tests that color button with desc id and col throws dll not found exception
        /// </summary>
        [Fact]
        public void ColorButton_WithDescIdAndCol_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ColorButton("descId", new Vector4F()));
        }

        /// <summary>
        ///     Tests that color button with desc id col and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void ColorButton_WithDescIdColAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ColorButton("descId", new Vector4F(), ImGuiColorEditFlags.None));
        }

        /// <summary>
        ///     Tests that color button with desc id col flags and size throws dll not found exception
        /// </summary>
        [Fact]
        public void ColorButton_WithDescIdColFlagsAndSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ColorButton("descId", new Vector4F(), ImGuiColorEditFlags.None, new Vector2F()));
        }

        /// <summary>
        ///     Tests that color convert float 4 to u 32 throws dll not found exception
        /// </summary>
        [Fact]
        public void ColorConvertFloat4ToU32_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ColorConvertFloat4ToU32(new Vector4F()));
        }

        /// <summary>
        ///     Tests that color convert hs vto rgb throws dll not found exception
        /// </summary>
        [Fact]
        public void ColorConvertHsVtoRgb_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ColorConvertHsVtoRgb(0.0f, 0.0f, 0.0f, out float outR, out float outG, out float outB));
        }

        /// <summary>
        ///     Tests that color convert rg bto hsv throws dll not found exception
        /// </summary>
        [Fact]
        public void ColorConvertRgBtoHsv_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ColorConvertRgBtoHsv(0.0f, 0.0f, 0.0f, out float outH, out float outS, out float outV));
        }

        /// <summary>
        ///     Tests that color convert u 32 to float 4 throws dll not found exception
        /// </summary>
        [Fact]
        public void ColorConvertU32ToFloat4_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ColorConvertU32ToFloat4(0u));
        }

        /// <summary>
        ///     Tests that color edit 3 with label and ref vector 3 throws dll not found exception
        /// </summary>
        [Fact]
        public void ColorEdit3_WithLabelAndRefVector3_ThrowsDllNotFoundException()
        {
            Vector3F col = new Vector3F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ColorEdit3("label", ref col));
        }

        /// <summary>
        ///     Tests that color edit 3 with label ref vector 3 and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void ColorEdit3_WithLabelRefVector3AndFlags_ThrowsDllNotFoundException()
        {
            Vector3F col = new Vector3F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ColorEdit3("label", ref col, ImGuiColorEditFlags.None));
        }

        /// <summary>
        ///     Tests that color edit 4 with label and ref vector 4 throws dll not found exception
        /// </summary>
        [Fact]
        public void ColorEdit4_WithLabelAndRefVector4_ThrowsDllNotFoundException()
        {
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ColorEdit4(Marshal.StringToHGlobalAnsi("label"), ref col));
        }

        /// <summary>
        ///     Tests that color edit 4 with label ref vector 4 and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void ColorEdit4_WithLabelRefVector4AndFlags_ThrowsDllNotFoundException()
        {
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ColorEdit4(Marshal.StringToHGlobalAnsi("label"), ref col, ImGuiColorEditFlags.None));
        }

        /// <summary>
        ///     Tests that color picker 3 with label and ref vector 3 throws dll not found exception
        /// </summary>
        [Fact]
        public void ColorPicker3_WithLabelAndRefVector3_ThrowsDllNotFoundException()
        {
            Vector3F col = new Vector3F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ColorPicker3("label", ref col));
        }

        /// <summary>
        ///     Tests that color picker 3 with label ref vector 3 and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void ColorPicker3_WithLabelRefVector3AndFlags_ThrowsDllNotFoundException()
        {
            Vector3F col = new Vector3F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ColorPicker3("label", ref col, ImGuiColorEditFlags.None));
        }

        /// <summary>
        ///     Tests that color picker 4 with label and ref vector 4 throws dll not found exception
        /// </summary>
        [Fact]
        public void ColorPicker4_WithLabelAndRefVector4_ThrowsDllNotFoundException()
        {
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ColorPicker4("label", ref col));
        }

        /// <summary>
        ///     Tests that color picker 4 with label ref vector 4 and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void ColorPicker4_WithLabelRefVector4AndFlags_ThrowsDllNotFoundException()
        {
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ColorPicker4("label", ref col, ImGuiColorEditFlags.None));
        }

        /// <summary>
        ///     Tests that color picker 4 with label ref vector 4 flags and ref col throws dll not found exception
        /// </summary>
        [Fact]
        public void ColorPicker4_WithLabelRefVector4FlagsAndRefCol_ThrowsDllNotFoundException()
        {
            Vector4F col = new Vector4F();
            float refCol = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ColorPicker4("label", ref col, ImGuiColorEditFlags.None, ref refCol));
        }

        /// <summary>
        ///     Tests that columns throws dll not found exception
        /// </summary>
        [Fact]
        public void Columns_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Columns());
        }

        /// <summary>
        ///     Tests that columns with count throws dll not found exception
        /// </summary>
        [Fact]
        public void Columns_WithCount_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Columns(1));
        }

        /// <summary>
        ///     Tests that columns with count and id throws dll not found exception
        /// </summary>
        [Fact]
        public void Columns_WithCountAndId_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Columns(1, "id"));
        }

        /// <summary>
        ///     Tests that columns with count id and border throws dll not found exception
        /// </summary>
        [Fact]
        public void Columns_WithCountIdAndBorder_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Columns(1, "id", true));
        }

        /// <summary>
        ///     Tests that combo throws dll not found exception
        /// </summary>
        [Fact]
        public void Combo_ThrowsDllNotFoundException()
        {
            Assert.Throws<MarshalDirectiveException>(() =>
            {
                int currentItem = int.MinValue;
                return ImGui.Native.ImGui.Combo("label", ref currentItem, new[] {"item1", "item2"}, 2);
            });
        }

        /// <summary>
        ///     Tests that combo with popup max height in items throws dll not found exception
        /// </summary>
        [Fact]
        public void Combo_WithPopupMaxHeightInItems_ThrowsDllNotFoundException()
        {
            Assert.Throws<MarshalDirectiveException>(() =>
            {
                int currentItem = int.MinValue;
                return ImGui.Native.ImGui.Combo("label", ref currentItem, new[] {"item1", "item2"}, 2, 10);
            });
        }
    }
}