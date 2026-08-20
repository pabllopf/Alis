// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP5RemainingCoverageTests.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// The ImGuiP5 remaining coverage tests class
    /// </summary>
    public class ImGuiP5RemainingCoverageTests
    {
        /// <summary>
        /// Tests that AcceptDragDropPayload throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void AcceptDragDropPayload_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.AcceptDragDropPayload("label"); });
            }
        }

        /// <summary>
        /// Tests that AcceptDragDropPayload throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void AcceptDragDropPayload_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.AcceptDragDropPayload("label", 0); });
            }
        }

        /// <summary>
        /// Tests that AlignTextToFramePadding throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void AlignTextToFramePadding_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.AlignTextToFramePadding(); });
            }
        }

        /// <summary>
        /// Tests that ArrowButton throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void ArrowButton_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.ArrowButton("label", 0); });
            }
        }

        /// <summary>
        /// Tests that Begin throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void Begin_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.Begin("label"); });
            }
        }

        /// <summary>
        /// Tests that Begin throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void Begin_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 bool pOpen = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.Begin("label", ref pOpen); });
            }
        }

        /// <summary>
        /// Tests that Begin throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void Begin_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 bool pOpen = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.Begin("label", ref pOpen, 0); });
            }
        }

        /// <summary>
        /// Tests that BeginChild throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginChild_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginChild("label"); });
            }
        }

        /// <summary>
        /// Tests that BeginChild throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginChild_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginChild("label", default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that BeginChild throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginChild_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginChild("label", default(Vector2F), false); });
            }
        }

        /// <summary>
        /// Tests that BeginChild throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginChild_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginChild("label", default(Vector2F), false, 0); });
            }
        }

        /// <summary>
        /// Tests that BeginChild throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginChild_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginChild(0); });
            }
        }

        /// <summary>
        /// Tests that BeginChild throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginChild_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginChild(0, default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that BeginChild throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginChild_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginChild(0, default(Vector2F), false); });
            }
        }

        /// <summary>
        /// Tests that BeginChild throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginChild_8_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginChild(0, default(Vector2F), false, 0); });
            }
        }

        /// <summary>
        /// Tests that BeginChildFrame throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginChildFrame_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginChildFrame(0, default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that BeginChildFrame throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginChildFrame_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginChildFrame(0, default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that BeginCombo throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginCombo_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginCombo("label", "label"); });
            }
        }

        /// <summary>
        /// Tests that BeginCombo throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginCombo_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginCombo("label", "label", 0); });
            }
        }

        /// <summary>
        /// Tests that BeginDisabled throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginDisabled_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginDisabled(); });
            }
        }

        /// <summary>
        /// Tests that BeginDisabled throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginDisabled_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginDisabled(false); });
            }
        }

        /// <summary>
        /// Tests that BeginDragDropSource throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginDragDropSource_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginDragDropSource(); });
            }
        }

        /// <summary>
        /// Tests that BeginDragDropSource throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginDragDropSource_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginDragDropSource(0); });
            }
        }

        /// <summary>
        /// Tests that BeginDragDropTarget throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginDragDropTarget_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginDragDropTarget(); });
            }
        }

        /// <summary>
        /// Tests that BeginGroup throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginGroup_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginGroup(); });
            }
        }

        /// <summary>
        /// Tests that BeginListBox throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginListBox_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginListBox("label"); });
            }
        }

        /// <summary>
        /// Tests that BeginListBox throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginListBox_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginListBox("label", default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that BeginMainMenuBar throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginMainMenuBar_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginMainMenuBar(); });
            }
        }

        /// <summary>
        /// Tests that BeginMenu throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginMenu_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginMenu("label"); });
            }
        }

        /// <summary>
        /// Tests that BeginMenu throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginMenu_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginMenu("label", false); });
            }
        }

        /// <summary>
        /// Tests that BeginMenuBar throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginMenuBar_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginMenuBar(); });
            }
        }

        /// <summary>
        /// Tests that BeginPopup throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginPopup_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginPopup("label"); });
            }
        }

        /// <summary>
        /// Tests that BeginPopup throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginPopup_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginPopup("label", 0); });
            }
        }

        /// <summary>
        /// Tests that BeginPopupContextItem throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginPopupContextItem_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginPopupContextItem(); });
            }
        }

        /// <summary>
        /// Tests that BeginPopupContextItem throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginPopupContextItem_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginPopupContextItem("label"); });
            }
        }

        /// <summary>
        /// Tests that BeginPopupContextItem throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginPopupContextItem_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginPopupContextItem("label", 0); });
            }
        }

        /// <summary>
        /// Tests that BeginPopupContextVoid throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginPopupContextVoid_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginPopupContextVoid(); });
            }
        }

        /// <summary>
        /// Tests that BeginPopupContextVoid throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginPopupContextVoid_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginPopupContextVoid("label"); });
            }
        }

        /// <summary>
        /// Tests that BeginPopupContextVoid throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginPopupContextVoid_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginPopupContextVoid("label", 0); });
            }
        }

        /// <summary>
        /// Tests that BeginPopupContextWindow throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginPopupContextWindow_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginPopupContextWindow(); });
            }
        }

        /// <summary>
        /// Tests that BeginPopupContextWindow throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginPopupContextWindow_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginPopupContextWindow("label"); });
            }
        }

        /// <summary>
        /// Tests that BeginPopupContextWindow throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginPopupContextWindow_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginPopupContextWindow("label", 0); });
            }
        }

        /// <summary>
        /// Tests that BeginPopupModal throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginPopupModal_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginPopupModal("label"); });
            }
        }

        /// <summary>
        /// Tests that BeginPopupModal throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginPopupModal_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 bool pOpen = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginPopupModal("label", ref pOpen); });
            }
        }

        /// <summary>
        /// Tests that BeginPopupModal throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginPopupModal_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 bool pOpen = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginPopupModal("label", ref pOpen, 0); });
            }
        }

        /// <summary>
        /// Tests that BeginTabBar throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginTabBar_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginTabBar("label"); });
            }
        }

        /// <summary>
        /// Tests that BeginTabBar throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginTabBar_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginTabBar("label", 0); });
            }
        }

        /// <summary>
        /// Tests that BeginTabItem throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginTabItem_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginTabItem("label"); });
            }
        }

        /// <summary>
        /// Tests that BeginTabItem throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginTabItem_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 bool pOpen = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginTabItem("label", ref pOpen); });
            }
        }

        /// <summary>
        /// Tests that BeginTabItem throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginTabItem_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 bool pOpen = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginTabItem("label", ref pOpen, 0); });
            }
        }

        /// <summary>
        /// Tests that BeginTable throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginTable_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginTable("label", 0); });
            }
        }

        /// <summary>
        /// Tests that BeginTable throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginTable_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginTable("label", 0, 0); });
            }
        }

        /// <summary>
        /// Tests that BeginTable throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginTable_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginTable("label", 0, 0, default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that BeginTable throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginTable_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginTable("label", 0, 0, default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that BeginTooltip throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginTooltip_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BeginTooltip(); });
            }
        }

        /// <summary>
        /// Tests that Bullet throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void Bullet_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.Bullet(); });
            }
        }

        /// <summary>
        /// Tests that BulletText throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BulletText_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.BulletText("label"); });
            }
        }

        /// <summary>
        /// Tests that Button throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void Button_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.Button("label"); });
            }
        }

        /// <summary>
        /// Tests that Button throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void Button_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.Button("label", default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that CalcItemWidth throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void CalcItemWidth_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.CalcItemWidth(); });
            }
        }

        /// <summary>
        /// Tests that Checkbox throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void Checkbox_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 bool v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.Checkbox("label", ref v); });
            }
        }

        /// <summary>
        /// Tests that CheckboxFlags throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void CheckboxFlags_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int flags = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.CheckboxFlags("label", ref flags, 0); });
            }
        }

        /// <summary>
        /// Tests that CheckboxFlags throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void CheckboxFlags_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint flags = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.CheckboxFlags("label", ref flags, 0); });
            }
        }

        /// <summary>
        /// Tests that CloseCurrentPopup throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void CloseCurrentPopup_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.CloseCurrentPopup(); });
            }
        }

        /// <summary>
        /// Tests that CollapsingHeader throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void CollapsingHeader_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.CollapsingHeader("label"); });
            }
        }

        /// <summary>
        /// Tests that CollapsingHeader throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void CollapsingHeader_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.CollapsingHeader("label", 0); });
            }
        }

        /// <summary>
        /// Tests that CollapsingHeader throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void CollapsingHeader_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 bool pVisible = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.CollapsingHeader("label", ref pVisible); });
            }
        }

        /// <summary>
        /// Tests that CollapsingHeader throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void CollapsingHeader_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 bool pVisible = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.CollapsingHeader("label", ref pVisible, 0); });
            }
        }

        /// <summary>
        /// Tests that ColorButton throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void ColorButton_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.ColorButton("label", default(Vector4F)); });
            }
        }

        /// <summary>
        /// Tests that ColorButton throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void ColorButton_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.ColorButton("label", default(Vector4F), 0); });
            }
        }

        /// <summary>
        /// Tests that ColorButton throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void ColorButton_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.ColorButton("label", default(Vector4F), 0, default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that ColorConvertFloat4ToU32 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void ColorConvertFloat4ToU32_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.ColorConvertFloat4ToU32(default(Vector4F)); });
            }
        }

        /// <summary>
        /// Tests that ColorConvertHsVtoRgb throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void ColorConvertHsVtoRgb_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float outR = default; float outG = default; float outB = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.ColorConvertHsVtoRgb(0, 0, 0, out outR, out outG, out outB); });
            }
        }

        /// <summary>
        /// Tests that ColorConvertRgBtoHsv throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void ColorConvertRgBtoHsv_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float outH = default; float outS = default; float outV = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.ColorConvertRgBtoHsv(0, 0, 0, out outH, out outS, out outV); });
            }
        }

        /// <summary>
        /// Tests that ColorConvertU32ToFloat4 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void ColorConvertU32ToFloat4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.ColorConvertU32ToFloat4(0); });
            }
        }

        /// <summary>
        /// Tests that ColorEdit3 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void ColorEdit3_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 Vector3F col = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.ColorEdit3("label", ref col); });
            }
        }

        /// <summary>
        /// Tests that ColorEdit3 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void ColorEdit3_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 Vector3F col = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.ColorEdit3("label", ref col, 0); });
            }
        }

        /// <summary>
        /// Tests that ColorEdit4 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void ColorEdit4_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 Vector4F col = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.ColorEdit4(IntPtr.Zero, ref col); });
            }
        }

        /// <summary>
        /// Tests that ColorEdit4 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void ColorEdit4_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 Vector4F col = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.ColorEdit4(IntPtr.Zero, ref col, 0); });
            }
        }

        /// <summary>
        /// Tests that ColorPicker3 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void ColorPicker3_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 Vector3F col = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.ColorPicker3("label", ref col); });
            }
        }

        /// <summary>
        /// Tests that ColorPicker3 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void ColorPicker3_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 Vector3F col = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.ColorPicker3("label", ref col, 0); });
            }
        }

        /// <summary>
        /// Tests that ColorPicker4 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void ColorPicker4_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 Vector4F col = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.ColorPicker4("label", ref col); });
            }
        }

        /// <summary>
        /// Tests that ColorPicker4 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void ColorPicker4_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 Vector4F col = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.ColorPicker4("label", ref col, 0); });
            }
        }

        /// <summary>
        /// Tests that ColorPicker4 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void ColorPicker4_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 Vector4F col = default; float refCol = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.ColorPicker4("label", ref col, 0, ref refCol); });
            }
        }

        /// <summary>
        /// Tests that Columns throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void Columns_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.Columns(); });
            }
        }

        /// <summary>
        /// Tests that Columns throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void Columns_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.Columns(0); });
            }
        }

        /// <summary>
        /// Tests that Columns throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void Columns_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.Columns(0, "label"); });
            }
        }

        /// <summary>
        /// Tests that Columns throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void Columns_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.Columns(0, "label", false); });
            }
        }

        /// <summary>
        /// Tests that Combo throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void Combo_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int currentItem = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.Combo("label", ref currentItem, default(string[]), 0); });
            }
        }

        /// <summary>
        /// Tests that Combo throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void Combo_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int currentItem = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.Combo("label", ref currentItem, default(string[]), 0, 0); });
            }
        }
        /// <summary>
        /// Determines whether the cimgui native library can be loaded
        /// </summary>
        /// <returns>True if the library can be loaded</returns>
        private static bool CanLoadCImguiLibrary()
        {
            if (NativeLibrary.TryLoad("cimgui", out _))
            {
                return true;
            }

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImGuiP5RemainingCoverageTests).Assembly.Location);
            if (assemblyDir == null)
            {
                return false;
            }

            string[] candidates = new[]
            {
                System.IO.Path.Combine(assemblyDir, "cimgui"),
                System.IO.Path.Combine(assemblyDir, "libcimgui"),
                System.IO.Path.Combine(assemblyDir, "libcimgui.dylib")
            };

            foreach (string candidate in candidates)
            {
                if (System.IO.File.Exists(candidate) && NativeLibrary.TryLoad(candidate, out _))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
