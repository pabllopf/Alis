// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP6RemainingCoverageTests.cs
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

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// The ImGuiP6 remaining coverage tests class
    /// </summary>
    public class ImGuiP6RemainingCoverageTests
    {
        /// <summary>
        /// Tests that InputFloat4_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputFloat4_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector4F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputFloat4("label", ref v, "label"); });
            }
        }

        /// <summary>
        /// Tests that InputFloat4_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputFloat4_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector4F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputFloat4("label", ref v, "label", default); });
            }
        }

        /// <summary>
        /// Tests that InputInt_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputInt_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputInt("label", ref v); });
            }
        }

        /// <summary>
        /// Tests that InputInt_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputInt_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputInt("label", ref v, 0); });
            }
        }

        /// <summary>
        /// Tests that InputInt_3 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputInt_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputInt("label", ref v, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that InputInt_4 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputInt_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputInt("label", ref v, 0, 0, default); });
            }
        }

        /// <summary>
        /// Tests that InputInt2_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputInt2_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputInt2("label", ref v); });
            }
        }

        /// <summary>
        /// Tests that InputInt2_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputInt2_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputInt2("label", ref v, default); });
            }
        }

        /// <summary>
        /// Tests that InputInt3_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputInt3_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputInt3("label", ref v); });
            }
        }

        /// <summary>
        /// Tests that InputInt3_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputInt3_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputInt3("label", ref v, default); });
            }
        }

        /// <summary>
        /// Tests that InputInt4_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputInt4_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputInt4("label", ref v); });
            }
        }

        /// <summary>
        /// Tests that InputInt4_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputInt4_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputInt4("label", ref v, default); });
            }
        }

        /// <summary>
        /// Tests that InputScalar_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputScalar_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputScalar("label", default, IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that InputScalar_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputScalar_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputScalar("label", default, IntPtr.Zero, IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that InputScalar_3 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputScalar_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputScalar("label", default, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that InputScalar_4 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputScalar_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputScalar("label", default, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, "label"); });
            }
        }

        /// <summary>
        /// Tests that InputScalar_5 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputScalar_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputScalar("label", default, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, "label", default); });
            }
        }

        /// <summary>
        /// Tests that InputScalarN_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputScalarN_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputScalarN("label", default, IntPtr.Zero, 0); });
            }
        }

        /// <summary>
        /// Tests that InputScalarN_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputScalarN_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputScalarN("label", default, IntPtr.Zero, 0, IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that InputScalarN_3 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputScalarN_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputScalarN("label", default, IntPtr.Zero, 0, IntPtr.Zero, IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that InputScalarN_4 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputScalarN_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputScalarN("label", default, IntPtr.Zero, 0, IntPtr.Zero, IntPtr.Zero, "label"); });
            }
        }

        /// <summary>
        /// Tests that InputScalarN_5 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputScalarN_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputScalarN("label", default, IntPtr.Zero, 0, IntPtr.Zero, IntPtr.Zero, "label", default); });
            }
        }

        /// <summary>
        /// Tests that InvisibleButton_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void InvisibleButton_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.InvisibleButton("label", default); });
            }
        }

        /// <summary>
        /// Tests that InvisibleButton_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void InvisibleButton_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.InvisibleButton("label", default, default); });
            }
        }

        /// <summary>
        /// Tests that IsAnyItemActive throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsAnyItemActive_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsAnyItemActive(); });
            }
        }

        /// <summary>
        /// Tests that IsAnyItemFocused throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsAnyItemFocused_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsAnyItemFocused(); });
            }
        }

        /// <summary>
        /// Tests that IsAnyItemHovered throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsAnyItemHovered_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsAnyItemHovered(); });
            }
        }

        /// <summary>
        /// Tests that IsAnyMouseDown throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsAnyMouseDown_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsAnyMouseDown(); });
            }
        }

        /// <summary>
        /// Tests that IsItemActivated throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsItemActivated_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsItemActivated(); });
            }
        }

        /// <summary>
        /// Tests that IsItemActive throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsItemActive_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsItemActive(); });
            }
        }

        /// <summary>
        /// Tests that IsItemClicked_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsItemClicked_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsItemClicked(); });
            }
        }

        /// <summary>
        /// Tests that IsItemClicked_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsItemClicked_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsItemClicked(default); });
            }
        }

        /// <summary>
        /// Tests that IsItemDeactivated throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsItemDeactivated_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsItemDeactivated(); });
            }
        }

        /// <summary>
        /// Tests that IsItemDeactivatedAfterEdit throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsItemDeactivatedAfterEdit_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsItemDeactivatedAfterEdit(); });
            }
        }

        /// <summary>
        /// Tests that IsItemEdited throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsItemEdited_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsItemEdited(); });
            }
        }

        /// <summary>
        /// Tests that IsItemFocused throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsItemFocused_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsItemFocused(); });
            }
        }

        /// <summary>
        /// Tests that IsItemHovered_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsItemHovered_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsItemHovered(); });
            }
        }

        /// <summary>
        /// Tests that IsItemHovered_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsItemHovered_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsItemHovered(default); });
            }
        }

        /// <summary>
        /// Tests that IsItemToggledOpen throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsItemToggledOpen_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsItemToggledOpen(); });
            }
        }

        /// <summary>
        /// Tests that IsItemVisible throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsItemVisible_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsItemVisible(); });
            }
        }

        /// <summary>
        /// Tests that IsKeyDown throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsKeyDown_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsKeyDown(default); });
            }
        }

        /// <summary>
        /// Tests that IsKeyPressed_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsKeyPressed_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsKeyPressed(default); });
            }
        }

        /// <summary>
        /// Tests that IsKeyPressed_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsKeyPressed_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsKeyPressed(default, false); });
            }
        }

        /// <summary>
        /// Tests that IsKeyReleased throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsKeyReleased_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsKeyReleased(default); });
            }
        }

        /// <summary>
        /// Tests that IsMouseClicked_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsMouseClicked_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsMouseClicked(default); });
            }
        }

        /// <summary>
        /// Tests that IsMouseClicked_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsMouseClicked_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsMouseClicked(default, false); });
            }
        }

        /// <summary>
        /// Tests that IsMouseDoubleClicked throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsMouseDoubleClicked_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsMouseDoubleClicked(default); });
            }
        }

        /// <summary>
        /// Tests that IsMouseDown throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsMouseDown_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsMouseDown(default); });
            }
        }

        /// <summary>
        /// Tests that IsMouseDragging_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsMouseDragging_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsMouseDragging(default); });
            }
        }

        /// <summary>
        /// Tests that IsMouseDragging_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsMouseDragging_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsMouseDragging(default, 0); });
            }
        }

        /// <summary>
        /// Tests that IsMouseHoveringRect_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsMouseHoveringRect_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsMouseHoveringRect(default, default); });
            }
        }

        /// <summary>
        /// Tests that IsMouseHoveringRect_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsMouseHoveringRect_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsMouseHoveringRect(default, default, false); });
            }
        }

        /// <summary>
        /// Tests that IsMousePosValid_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsMousePosValid_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsMousePosValid(); });
            }
        }

        /// <summary>
        /// Tests that IsMousePosValid_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsMousePosValid_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector2F mousePos = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsMousePosValid(ref mousePos); });
            }
        }

        /// <summary>
        /// Tests that IsMouseReleased throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsMouseReleased_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsMouseReleased(default); });
            }
        }

        /// <summary>
        /// Tests that IsPopupOpen_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsPopupOpen_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsPopupOpen("label"); });
            }
        }

        /// <summary>
        /// Tests that IsPopupOpen_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsPopupOpen_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsPopupOpen("label", default); });
            }
        }

        /// <summary>
        /// Tests that IsRectVisible_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsRectVisible_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsRectVisible(default); });
            }
        }

        /// <summary>
        /// Tests that IsRectVisible_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsRectVisible_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsRectVisible(default, default); });
            }
        }

        /// <summary>
        /// Tests that IsWindowAppearing throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsWindowAppearing_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsWindowAppearing(); });
            }
        }

        /// <summary>
        /// Tests that IsWindowCollapsed throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsWindowCollapsed_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsWindowCollapsed(); });
            }
        }

        /// <summary>
        /// Tests that IsWindowDocked throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsWindowDocked_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsWindowDocked(); });
            }
        }

        /// <summary>
        /// Tests that IsWindowFocused_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsWindowFocused_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsWindowFocused(); });
            }
        }

        /// <summary>
        /// Tests that IsWindowFocused_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsWindowFocused_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsWindowFocused(default); });
            }
        }

        /// <summary>
        /// Tests that IsWindowHovered_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsWindowHovered_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsWindowHovered(); });
            }
        }

        /// <summary>
        /// Tests that IsWindowHovered_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsWindowHovered_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.IsWindowHovered(default); });
            }
        }

        /// <summary>
        /// Tests that LabelText throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void LabelText_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.LabelText("label", "label"); });
            }
        }

        /// <summary>
        /// Tests that ListBox_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void ListBox_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int currentItem = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.ListBox("label", ref currentItem, default, 0); });
            }
        }

        /// <summary>
        /// Tests that ListBox_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void ListBox_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int currentItem = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.ListBox("label", ref currentItem, default, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that LoadIniSettingsFromDisk throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void LoadIniSettingsFromDisk_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.LoadIniSettingsFromDisk("label"); });
            }
        }

        /// <summary>
        /// Tests that LoadIniSettingsFromMemory_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void LoadIniSettingsFromMemory_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.LoadIniSettingsFromMemory("label"); });
            }
        }

        /// <summary>
        /// Tests that LoadIniSettingsFromMemory_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void LoadIniSettingsFromMemory_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.LoadIniSettingsFromMemory("label", 0); });
            }
        }

        /// <summary>
        /// Tests that LogButtons throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void LogButtons_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.LogButtons(); });
            }
        }

        /// <summary>
        /// Tests that LogFinish throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void LogFinish_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.LogFinish(); });
            }
        }

        /// <summary>
        /// Tests that LogText throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void LogText_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.LogText("label"); });
            }
        }

        /// <summary>
        /// Tests that LogToClipboard_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void LogToClipboard_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.LogToClipboard(); });
            }
        }

        /// <summary>
        /// Tests that LogToClipboard_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void LogToClipboard_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.LogToClipboard(0); });
            }
        }

        /// <summary>
        /// Tests that LogToFile_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void LogToFile_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.LogToFile(); });
            }
        }

        /// <summary>
        /// Tests that LogToFile_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void LogToFile_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.LogToFile(0); });
            }
        }

        /// <summary>
        /// Tests that LogToFile_3 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void LogToFile_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.LogToFile(0, "label"); });
            }
        }

        /// <summary>
        /// Tests that LogToTty_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void LogToTty_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.LogToTty(); });
            }
        }

        /// <summary>
        /// Tests that LogToTty_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void LogToTty_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.LogToTty(0); });
            }
        }

        /// <summary>
        /// Tests that MemAlloc throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void MemAlloc_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.MemAlloc(0); });
            }
        }

        /// <summary>
        /// Tests that MemFree throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void MemFree_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.MemFree(IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that MenuItem_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void MenuItem_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.MenuItem("label"); });
            }
        }

        /// <summary>
        /// Tests that MenuItem_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void MenuItem_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.MenuItem("label", "label"); });
            }
        }

        /// <summary>
        /// Tests that MenuItem_3 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void MenuItem_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.MenuItem("label", "label", false); });
            }
        }

        /// <summary>
        /// Tests that MenuItem_4 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void MenuItem_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.MenuItem("label", "label", false, false); });
            }
        }

        /// <summary>
        /// Tests that MenuItem_5 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void MenuItem_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                bool pSelected = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.MenuItem("label", "label", ref pSelected); });
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

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImGuiP6RemainingCoverageTests).Assembly.Location);
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
