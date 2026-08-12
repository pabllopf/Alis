// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP3RemainingCoverageTests.cs
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
    /// The ImGuiP3 remaining coverage tests class
    /// </summary>
    public class ImGuiP3RemainingCoverageTests
    {
        /// <summary>
        /// Tests that DragScalarN throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragScalarN_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragScalarN("label", 0, IntPtr.Zero, 0, 0, IntPtr.Zero, IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that DragScalarN throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragScalarN_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragScalarN("label", 0, IntPtr.Zero, 0, 0, IntPtr.Zero, IntPtr.Zero, "label"); });
            }
        }

        /// <summary>
        /// Tests that DragScalarN throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragScalarN_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragScalarN("label", 0, IntPtr.Zero, 0, 0, IntPtr.Zero, IntPtr.Zero, "label", 0); });
            }
        }

        /// <summary>
        /// Tests that Dummy throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Dummy_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.Dummy(default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that End throws when native library is unavailable
        /// </summary>
        [Fact]
        public void End_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.End(); });
            }
        }

        /// <summary>
        /// Tests that EndChild throws when native library is unavailable
        /// </summary>
        [Fact]
        public void EndChild_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.EndChild(); });
            }
        }

        /// <summary>
        /// Tests that EndChildFrame throws when native library is unavailable
        /// </summary>
        [Fact]
        public void EndChildFrame_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.EndChildFrame(); });
            }
        }

        /// <summary>
        /// Tests that EndCombo throws when native library is unavailable
        /// </summary>
        [Fact]
        public void EndCombo_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.EndCombo(); });
            }
        }

        /// <summary>
        /// Tests that EndDisabled throws when native library is unavailable
        /// </summary>
        [Fact]
        public void EndDisabled_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.EndDisabled(); });
            }
        }

        /// <summary>
        /// Tests that EndDragDropSource throws when native library is unavailable
        /// </summary>
        [Fact]
        public void EndDragDropSource_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.EndDragDropSource(); });
            }
        }

        /// <summary>
        /// Tests that EndDragDropTarget throws when native library is unavailable
        /// </summary>
        [Fact]
        public void EndDragDropTarget_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.EndDragDropTarget(); });
            }
        }

        /// <summary>
        /// Tests that EndFrame throws when native library is unavailable
        /// </summary>
        [Fact]
        public void EndFrame_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.EndFrame(); });
            }
        }

        /// <summary>
        /// Tests that EndGroup throws when native library is unavailable
        /// </summary>
        [Fact]
        public void EndGroup_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.EndGroup(); });
            }
        }

        /// <summary>
        /// Tests that EndListBox throws when native library is unavailable
        /// </summary>
        [Fact]
        public void EndListBox_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.EndListBox(); });
            }
        }

        /// <summary>
        /// Tests that EndMainMenuBar throws when native library is unavailable
        /// </summary>
        [Fact]
        public void EndMainMenuBar_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.EndMainMenuBar(); });
            }
        }

        /// <summary>
        /// Tests that EndMenu throws when native library is unavailable
        /// </summary>
        [Fact]
        public void EndMenu_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.EndMenu(); });
            }
        }

        /// <summary>
        /// Tests that EndMenuBar throws when native library is unavailable
        /// </summary>
        [Fact]
        public void EndMenuBar_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.EndMenuBar(); });
            }
        }

        /// <summary>
        /// Tests that EndPopup throws when native library is unavailable
        /// </summary>
        [Fact]
        public void EndPopup_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.EndPopup(); });
            }
        }

        /// <summary>
        /// Tests that EndTabBar throws when native library is unavailable
        /// </summary>
        [Fact]
        public void EndTabBar_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.EndTabBar(); });
            }
        }

        /// <summary>
        /// Tests that EndTabItem throws when native library is unavailable
        /// </summary>
        [Fact]
        public void EndTabItem_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.EndTabItem(); });
            }
        }

        /// <summary>
        /// Tests that EndTable throws when native library is unavailable
        /// </summary>
        [Fact]
        public void EndTable_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.EndTable(); });
            }
        }

        /// <summary>
        /// Tests that EndTooltip throws when native library is unavailable
        /// </summary>
        [Fact]
        public void EndTooltip_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.EndTooltip(); });
            }
        }

        /// <summary>
        /// Tests that FindViewportById throws when native library is unavailable
        /// </summary>
        [Fact]
        public void FindViewportById_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.FindViewportById(0); });
            }
        }

        /// <summary>
        /// Tests that FindViewportByPlatformHandle throws when native library is unavailable
        /// </summary>
        [Fact]
        public void FindViewportByPlatformHandle_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.FindViewportByPlatformHandle(IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that GetAllocatorFunctions throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetAllocatorFunctions_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 IntPtr pAllocFunc = default; IntPtr pFreeFunc = default; IntPtr pUserData = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetAllocatorFunctions(ref pAllocFunc, ref pFreeFunc, ref pUserData); });
            }
        }

        /// <summary>
        /// Tests that GetBackgroundDrawList throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetBackgroundDrawList_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetBackgroundDrawList(); });
            }
        }

        /// <summary>
        /// Tests that GetBackgroundDrawList throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetBackgroundDrawList_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetBackgroundDrawList(default(ImGuiViewportPtr)); });
            }
        }

        /// <summary>
        /// Tests that GetClipboardText throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetClipboardText_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetClipboardText(); });
            }
        }

        /// <summary>
        /// Tests that GetColorU32 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetColorU32_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetColorU32((ImGuiCol)0); });
            }
        }

        /// <summary>
        /// Tests that GetColorU32 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetColorU32_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetColorU32(0, 0); });
            }
        }

        /// <summary>
        /// Tests that GetColorU32 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetColorU32_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetColorU32(default(Vector4F)); });
            }
        }

        /// <summary>
        /// Tests that GetColorU32 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetColorU32_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetColorU32((ImGuiCol)0); });
            }
        }

        /// <summary>
        /// Tests that GetColumnIndex throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetColumnIndex_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetColumnIndex(); });
            }
        }

        /// <summary>
        /// Tests that GetColumnOffset throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetColumnOffset_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetColumnOffset(); });
            }
        }

        /// <summary>
        /// Tests that GetColumnOffset throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetColumnOffset_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetColumnOffset(0); });
            }
        }

        /// <summary>
        /// Tests that GetColumnsCount throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetColumnsCount_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetColumnsCount(); });
            }
        }

        /// <summary>
        /// Tests that GetColumnWidth throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetColumnWidth_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetColumnWidth(); });
            }
        }

        /// <summary>
        /// Tests that GetColumnWidth throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetColumnWidth_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetColumnWidth(0); });
            }
        }

        /// <summary>
        /// Tests that GetContentRegionAvail throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetContentRegionAvail_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetContentRegionAvail(); });
            }
        }

        /// <summary>
        /// Tests that GetContentRegionMax throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetContentRegionMax_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetContentRegionMax(); });
            }
        }

        /// <summary>
        /// Tests that GetCurrentContext throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetCurrentContext_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetCurrentContext(); });
            }
        }

        /// <summary>
        /// Tests that GetCursorPos throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetCursorPos_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetCursorPos(); });
            }
        }

        /// <summary>
        /// Tests that GetCursorPosX throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetCursorPosX_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetCursorPosX(); });
            }
        }

        /// <summary>
        /// Tests that GetCursorPosY throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetCursorPosY_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetCursorPosY(); });
            }
        }

        /// <summary>
        /// Tests that GetCursorScreenPos throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetCursorScreenPos_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetCursorScreenPos(); });
            }
        }

        /// <summary>
        /// Tests that GetCursorStartPos throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetCursorStartPos_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetCursorStartPos(); });
            }
        }

        /// <summary>
        /// Tests that GetDragDropPayload throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetDragDropPayload_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetDragDropPayload(); });
            }
        }

        /// <summary>
        /// Tests that GetDrawData throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetDrawData_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetDrawData(); });
            }
        }

        /// <summary>
        /// Tests that GetDrawListSharedData throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetDrawListSharedData_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetDrawListSharedData(); });
            }
        }

        /// <summary>
        /// Tests that GetFont throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetFont_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetFont(); });
            }
        }

        /// <summary>
        /// Tests that GetFontSize throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetFontSize_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetFontSize(); });
            }
        }

        /// <summary>
        /// Tests that GetFontTexUvWhitePixel throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetFontTexUvWhitePixel_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetFontTexUvWhitePixel(); });
            }
        }

        /// <summary>
        /// Tests that GetForegroundDrawList throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetForegroundDrawList_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetForegroundDrawList(); });
            }
        }

        /// <summary>
        /// Tests that GetForegroundDrawList throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetForegroundDrawList_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetForegroundDrawList(default(ImGuiViewportPtr)); });
            }
        }

        /// <summary>
        /// Tests that GetFrameCount throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetFrameCount_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetFrameCount(); });
            }
        }

        /// <summary>
        /// Tests that GetFrameHeight throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetFrameHeight_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetFrameHeight(); });
            }
        }

        /// <summary>
        /// Tests that GetFrameHeightWithSpacing throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetFrameHeightWithSpacing_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetFrameHeightWithSpacing(); });
            }
        }

        /// <summary>
        /// Tests that GetId throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetId_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetId("label"); });
            }
        }

        /// <summary>
        /// Tests that GetId throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetId_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetId(IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that GetIo throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetIo_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetIo(); });
            }
        }

        /// <summary>
        /// Tests that GetItemRectMax throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetItemRectMax_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetItemRectMax(); });
            }
        }

        /// <summary>
        /// Tests that GetItemRectMin throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetItemRectMin_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetItemRectMin(); });
            }
        }

        /// <summary>
        /// Tests that GetItemRectSize throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetItemRectSize_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetItemRectSize(); });
            }
        }

        /// <summary>
        /// Tests that GetKeyIndex throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetKeyIndex_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetKeyIndex(0); });
            }
        }

        /// <summary>
        /// Tests that GetKeyName throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetKeyName_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetKeyName(0); });
            }
        }

        /// <summary>
        /// Tests that GetKeyPressedAmount throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetKeyPressedAmount_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetKeyPressedAmount(0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that GetMainViewport throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetMainViewport_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetMainViewport(); });
            }
        }

        /// <summary>
        /// Tests that GetMouseClickedCount throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetMouseClickedCount_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetMouseClickedCount(0); });
            }
        }

        /// <summary>
        /// Tests that GetMouseCursor throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetMouseCursor_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetMouseCursor(); });
            }
        }

        /// <summary>
        /// Tests that GetMouseDragDelta throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetMouseDragDelta_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetMouseDragDelta(); });
            }
        }

        /// <summary>
        /// Tests that GetMouseDragDelta throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetMouseDragDelta_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetMouseDragDelta(0); });
            }
        }

        /// <summary>
        /// Tests that GetMouseDragDelta throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetMouseDragDelta_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetMouseDragDelta(0, 0); });
            }
        }

        /// <summary>
        /// Tests that GetMousePos throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetMousePos_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetMousePos(); });
            }
        }

        /// <summary>
        /// Tests that GetMousePosOnOpeningCurrentPopup throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetMousePosOnOpeningCurrentPopup_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetMousePosOnOpeningCurrentPopup(); });
            }
        }

        /// <summary>
        /// Tests that GetPlatformIo throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetPlatformIo_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetPlatformIo(); });
            }
        }

        /// <summary>
        /// Tests that GetScrollMaxX throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetScrollMaxX_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetScrollMaxX(); });
            }
        }

        /// <summary>
        /// Tests that GetScrollMaxY throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetScrollMaxY_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetScrollMaxY(); });
            }
        }

        /// <summary>
        /// Tests that GetScrollX throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetScrollX_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetScrollX(); });
            }
        }

        /// <summary>
        /// Tests that GetScrollY throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetScrollY_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetScrollY(); });
            }
        }

        /// <summary>
        /// Tests that GetStateStorage throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetStateStorage_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetStateStorage(); });
            }
        }

        /// <summary>
        /// Tests that GetStyleColorName throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetStyleColorName_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetStyleColorName(0); });
            }
        }

        /// <summary>
        /// Tests that GetStyleColorVec4 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetStyleColorVec4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetStyleColorVec4(0); });
            }
        }

        /// <summary>
        /// Tests that GetTextLineHeight throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetTextLineHeight_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetTextLineHeight(); });
            }
        }

        /// <summary>
        /// Tests that GetTextLineHeightWithSpacing throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetTextLineHeightWithSpacing_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetTextLineHeightWithSpacing(); });
            }
        }

        /// <summary>
        /// Tests that GetTime throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetTime_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetTime(); });
            }
        }

        /// <summary>
        /// Tests that GetTreeNodeToLabelSpacing throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetTreeNodeToLabelSpacing_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetTreeNodeToLabelSpacing(); });
            }
        }

        /// <summary>
        /// Tests that GetVersion throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetVersion_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetVersion(); });
            }
        }

        /// <summary>
        /// Tests that GetWindowContentRegionMax throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetWindowContentRegionMax_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetWindowContentRegionMax(); });
            }
        }

        /// <summary>
        /// Tests that GetWindowContentRegionMin throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetWindowContentRegionMin_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetWindowContentRegionMin(); });
            }
        }

        /// <summary>
        /// Tests that GetWindowDockId throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetWindowDockId_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetWindowDockId(); });
            }
        }

        /// <summary>
        /// Tests that GetWindowDpiScale throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetWindowDpiScale_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetWindowDpiScale(); });
            }
        }

        /// <summary>
        /// Tests that GetWindowDrawList throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetWindowDrawList_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetWindowDrawList(); });
            }
        }

        /// <summary>
        /// Tests that GetWindowHeight throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetWindowHeight_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetWindowHeight(); });
            }
        }

        /// <summary>
        /// Tests that GetWindowPos throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetWindowPos_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetWindowPos(); });
            }
        }

        /// <summary>
        /// Tests that GetWindowSize throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetWindowSize_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetWindowSize(); });
            }
        }

        /// <summary>
        /// Tests that GetWindowViewport throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetWindowViewport_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetWindowViewport(); });
            }
        }

        /// <summary>
        /// Tests that GetWindowWidth throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetWindowWidth_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.GetWindowWidth(); });
            }
        }

        /// <summary>
        /// Tests that Image throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Image_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.Image(IntPtr.Zero, default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that Image throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Image_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.Image(IntPtr.Zero, default(Vector2F), default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that Image throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Image_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.Image(IntPtr.Zero, default(Vector2F), default(Vector2F), default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that Image throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Image_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.Image(IntPtr.Zero, default(Vector2F), default(Vector2F), default(Vector2F), default(Vector4F)); });
            }
        }

        /// <summary>
        /// Tests that Image throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Image_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.Image(IntPtr.Zero, default(Vector2F), default(Vector2F), default(Vector2F), default(Vector4F), default(Vector4F)); });
            }
        }

        /// <summary>
        /// Tests that ImageButton throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ImageButton_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.ImageButton("label", IntPtr.Zero, default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that ImageButton throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ImageButton_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.ImageButton("label", IntPtr.Zero, default(Vector2F), default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that ImageButton throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ImageButton_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.ImageButton("label", IntPtr.Zero, default(Vector2F), default(Vector2F), default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that ImageButton throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ImageButton_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.ImageButton("label", IntPtr.Zero, default(Vector2F), default(Vector2F), default(Vector2F), default(Vector4F)); });
            }
        }

        /// <summary>
        /// Tests that ImageButton throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ImageButton_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.ImageButton("label", IntPtr.Zero, default(Vector2F), default(Vector2F), default(Vector2F), default(Vector4F), default(Vector4F)); });
            }
        }

        /// <summary>
        /// Tests that Indent throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Indent_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.Indent(); });
            }
        }

        /// <summary>
        /// Tests that Indent throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Indent_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.Indent(0); });
            }
        }

        /// <summary>
        /// Tests that InputDouble throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputDouble_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputDouble("label", ref v); });
            }
        }

        /// <summary>
        /// Tests that InputDouble throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputDouble_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputDouble("label", ref v, 0); });
            }
        }

        /// <summary>
        /// Tests that InputDouble throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputDouble_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputDouble("label", ref v, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that InputDouble throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputDouble_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputDouble("label", ref v, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that InputDouble throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputDouble_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputDouble("label", ref v, 0, 0, "label", 0); });
            }
        }

        /// <summary>
        /// Tests that InputFloat throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputFloat_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputFloat("label", ref v); });
            }
        }

        /// <summary>
        /// Tests that InputFloat throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputFloat_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputFloat("label", ref v, 0); });
            }
        }

        /// <summary>
        /// Tests that InputFloat throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputFloat_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputFloat("label", ref v, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that InputFloat throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputFloat_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputFloat("label", ref v, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that InputFloat throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputFloat_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputFloat("label", ref v, 0, 0, "label", 0); });
            }
        }

        /// <summary>
        /// Tests that InputFloat2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputFloat2_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 Vector2F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputFloat2("label", ref v); });
            }
        }

        /// <summary>
        /// Tests that InputFloat2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputFloat2_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 Vector2F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputFloat2("label", ref v, "label"); });
            }
        }

        /// <summary>
        /// Tests that InputFloat2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputFloat2_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 Vector2F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputFloat2("label", ref v, "label", 0); });
            }
        }

        /// <summary>
        /// Tests that InputFloat3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputFloat3_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 Vector3F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputFloat3("label", ref v); });
            }
        }

        /// <summary>
        /// Tests that InputFloat3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputFloat3_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 Vector3F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputFloat3("label", ref v, "label"); });
            }
        }

        /// <summary>
        /// Tests that InputFloat3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputFloat3_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 Vector3F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputFloat3("label", ref v, "label", 0); });
            }
        }

        /// <summary>
        /// Tests that InputFloat4 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputFloat4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 Vector4F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputFloat4("label", ref v); });
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

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImGuiP3RemainingCoverageTests).Assembly.Location);
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
