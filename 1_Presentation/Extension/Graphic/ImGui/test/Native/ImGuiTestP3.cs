// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTestP3.cs
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
    public class ImGuiTestP3
    {
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

        /// <summary>
        ///     Tests that end tab item throws dll not found exception
        /// </summary>
        [Fact]
        public void EndTabItem_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.EndTabItem());
        }

        /// <summary>
        ///     Tests that end table throws dll not found exception
        /// </summary>
        [Fact]
        public void EndTable_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.EndTable());
        }

        /// <summary>
        ///     Tests that end tooltip throws dll not found exception
        /// </summary>
        [Fact]
        public void EndTooltip_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.EndTooltip());
        }

        /// <summary>
        ///     Tests that find viewport by id throws dll not found exception
        /// </summary>
        [Fact]
        public void FindViewportById_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.FindViewportById(1));
        }

        /// <summary>
        ///     Tests that find viewport by platform handle throws dll not found exception
        /// </summary>
        [Fact]
        public void FindViewportByPlatformHandle_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.FindViewportByPlatformHandle(IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that get allocator functions throws dll not found exception
        /// </summary>
        [Fact]
        public void GetAllocatorFunctions_ThrowsDllNotFoundException()
        {
            IntPtr pAllocFunc = IntPtr.Zero;
            IntPtr pFreeFunc = IntPtr.Zero;
            IntPtr pUserData = IntPtr.Zero;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetAllocatorFunctions(ref pAllocFunc, ref pFreeFunc, ref pUserData));
        }

        /// <summary>
        ///     Tests that get background draw list throws dll not found exception
        /// </summary>
        [Fact]
        public void GetBackgroundDrawList_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetBackgroundDrawList());
        }

        /// <summary>
        ///     Tests that get background draw list with viewport throws dll not found exception
        /// </summary>
        [Fact]
        public void GetBackgroundDrawList_WithViewport_ThrowsDllNotFoundException()
        {
            ImGuiViewportPtr viewport = new ImGuiViewportPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetBackgroundDrawList(viewport));
        }

        /// <summary>
        ///     Tests that get clipboard text throws dll not found exception
        /// </summary>
        [Fact]
        public void GetClipboardText_ThrowsDllNotFoundException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImGui.Native.ImGui.GetClipboardText());
        }

        /// <summary>
        ///     Tests that get color u 32 by idx throws dll not found exception
        /// </summary>
        [Fact]
        public void GetColorU32_ByIdx_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetColorU32(ImGuiCol.Text));
        }

        /// <summary>
        ///     Tests that get color u 32 by idx and alpha mul throws dll not found exception
        /// </summary>
        [Fact]
        public void GetColorU32_ByIdxAndAlphaMul_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetColorU32(ImGuiCol.Text, 1.0f));
        }

        /// <summary>
        ///     Tests that get color u 32 by vec 4 throws dll not found exception
        /// </summary>
        [Fact]
        public void GetColorU32_ByVec4_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetColorU32(new Vector4F(1, 1, 1, 1)));
        }

        /// <summary>
        ///     Tests that get color u 32 by uint throws dll not found exception
        /// </summary>
        [Fact]
        public void GetColorU32_ByUint_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetColorU32(0xFFFFFFFF));
        }

        /// <summary>
        ///     Tests that get column index throws dll not found exception
        /// </summary>
        [Fact]
        public void GetColumnIndex_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetColumnIndex());
        }

        /// <summary>
        ///     Tests that get column offset throws dll not found exception
        /// </summary>
        [Fact]
        public void GetColumnOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetColumnOffset());
        }

        /// <summary>
        ///     Tests that get column offset with index throws dll not found exception
        /// </summary>
        [Fact]
        public void GetColumnOffset_WithIndex_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetColumnOffset(0));
        }

        /// <summary>
        ///     Tests that get columns count throws dll not found exception
        /// </summary>
        [Fact]
        public void GetColumnsCount_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetColumnsCount());
        }

        /// <summary>
        ///     Tests that get column width throws dll not found exception
        /// </summary>
        [Fact]
        public void GetColumnWidth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetColumnWidth());
        }

        /// <summary>
        ///     Tests that get column width with index throws dll not found exception
        /// </summary>
        [Fact]
        public void GetColumnWidth_WithIndex_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetColumnWidth(0));
        }

        /// <summary>
        ///     Tests that get content region avail throws dll not found exception
        /// </summary>
        [Fact]
        public void GetContentRegionAvail_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetContentRegionAvail());
        }

        /// <summary>
        ///     Tests that get content region max throws dll not found exception
        /// </summary>
        [Fact]
        public void GetContentRegionMax_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetContentRegionMax());
        }

        /// <summary>
        ///     Tests that get current context throws dll not found exception
        /// </summary>
        [Fact]
        public void GetCurrentContext_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetCurrentContext());
        }

        /// <summary>
        ///     Tests that get cursor pos throws dll not found exception
        /// </summary>
        [Fact]
        public void GetCursorPos_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetCursorPos());
        }

        /// <summary>
        ///     Tests that get cursor pos x throws dll not found exception
        /// </summary>
        [Fact]
        public void GetCursorPosX_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetCursorPosX());
        }

        /// <summary>
        ///     Tests that get cursor pos y throws dll not found exception
        /// </summary>
        [Fact]
        public void GetCursorPosY_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetCursorPosY());
        }

        /// <summary>
        ///     Tests that get cursor screen pos throws dll not found exception
        /// </summary>
        [Fact]
        public void GetCursorScreenPos_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetCursorScreenPos());
        }

        /// <summary>
        ///     Tests that get cursor start pos throws dll not found exception
        /// </summary>
        [Fact]
        public void GetCursorStartPos_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetCursorStartPos());
        }

        /// <summary>
        ///     Tests that get drag drop payload throws dll not found exception
        /// </summary>
        [Fact]
        public void GetDragDropPayload_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetDragDropPayload());
        }

        /// <summary>
        ///     Tests that get draw data throws dll not found exception
        /// </summary>
        [Fact]
        public void GetDrawData_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetDrawData());
        }

        /// <summary>
        ///     Tests that get draw list shared data throws dll not found exception
        /// </summary>
        [Fact]
        public void GetDrawListSharedData_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetDrawListSharedData());
        }

        /// <summary>
        ///     Tests that get font throws dll not found exception
        /// </summary>
        [Fact]
        public void GetFont_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetFont());
        }

        /// <summary>
        ///     Tests that get font size throws dll not found exception
        /// </summary>
        [Fact]
        public void GetFontSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetFontSize());
        }

        /// <summary>
        ///     Tests that get font tex uv white pixel throws dll not found exception
        /// </summary>
        [Fact]
        public void GetFontTexUvWhitePixel_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetFontTexUvWhitePixel());
        }

        /// <summary>
        ///     Tests that get foreground draw list throws dll not found exception
        /// </summary>
        [Fact]
        public void GetForegroundDrawList_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetForegroundDrawList());
        }

        /// <summary>
        ///     Tests that get foreground draw list with viewport throws dll not found exception
        /// </summary>
        [Fact]
        public void GetForegroundDrawList_WithViewport_ThrowsDllNotFoundException()
        {
            ImGuiViewportPtr viewport = new ImGuiViewportPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetForegroundDrawList(viewport));
        }

        /// <summary>
        ///     Tests that get frame count throws dll not found exception
        /// </summary>
        [Fact]
        public void GetFrameCount_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetFrameCount());
        }

        /// <summary>
        ///     Tests that get frame height throws dll not found exception
        /// </summary>
        [Fact]
        public void GetFrameHeight_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetFrameHeight());
        }

        /// <summary>
        ///     Tests that get frame height with spacing throws dll not found exception
        /// </summary>
        [Fact]
        public void GetFrameHeightWithSpacing_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetFrameHeightWithSpacing());
        }

        /// <summary>
        ///     Tests that get id by string throws dll not found exception
        /// </summary>
        [Fact]
        public void GetId_ByString_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetId("test"));
        }

        /// <summary>
        ///     Tests that get id by int ptr throws dll not found exception
        /// </summary>
        [Fact]
        public void GetId_ByIntPtr_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetId(IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that get io throws dll not found exception
        /// </summary>
        [Fact]
        public void GetIo_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetIo());
        }

        /// <summary>
        ///     Tests that get item rect max throws dll not found exception
        /// </summary>
        [Fact]
        public void GetItemRectMax_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetItemRectMax());
        }

        /// <summary>
        ///     Tests that get item rect min throws dll not found exception
        /// </summary>
        [Fact]
        public void GetItemRectMin_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetItemRectMin());
        }

        /// <summary>
        ///     Tests that get item rect size throws dll not found exception
        /// </summary>
        [Fact]
        public void GetItemRectSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetItemRectSize());
        }

        /// <summary>
        ///     Tests that get key index throws dll not found exception
        /// </summary>
        [Fact]
        public void GetKeyIndex_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetKeyIndex(ImGuiKey.Tab));
        }

        /// <summary>
        ///     Tests that get key name throws dll not found exception
        /// </summary>
        [Fact]
        public void GetKeyName_ThrowsDllNotFoundException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImGui.Native.ImGui.GetKeyName(ImGuiKey.Tab));
        }

        /// <summary>
        ///     Tests that get key pressed amount throws dll not found exception
        /// </summary>
        [Fact]
        public void GetKeyPressedAmount_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetKeyPressedAmount(ImGuiKey.Tab, 0.0f, 0.0f));
        }

        /// <summary>
        ///     Tests that get main viewport throws dll not found exception
        /// </summary>
        [Fact]
        public void GetMainViewport_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetMainViewport());
        }

        /// <summary>
        ///     Tests that get mouse clicked count throws dll not found exception
        /// </summary>
        [Fact]
        public void GetMouseClickedCount_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetMouseClickedCount(ImGuiMouseButton.Left));
        }

        /// <summary>
        ///     Tests that get mouse cursor throws dll not found exception
        /// </summary>
        [Fact]
        public void GetMouseCursor_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetMouseCursor());
        }

        /// <summary>
        ///     Tests that get mouse drag delta throws dll not found exception
        /// </summary>
        [Fact]
        public void GetMouseDragDelta_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetMouseDragDelta());
        }

        /// <summary>
        ///     Tests that get mouse drag delta with button throws dll not found exception
        /// </summary>
        [Fact]
        public void GetMouseDragDelta_WithButton_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetMouseDragDelta(ImGuiMouseButton.Left));
        }

        /// <summary>
        ///     Tests that get mouse drag delta with button and lock threshold throws dll not found exception
        /// </summary>
        [Fact]
        public void GetMouseDragDelta_WithButtonAndLockThreshold_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetMouseDragDelta(ImGuiMouseButton.Left, 0.0f));
        }

        /// <summary>
        ///     Tests that get mouse pos throws dll not found exception
        /// </summary>
        [Fact]
        public void GetMousePos_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetMousePos());
        }

        /// <summary>
        ///     Tests that get mouse pos on opening current popup throws dll not found exception
        /// </summary>
        [Fact]
        public void GetMousePosOnOpeningCurrentPopup_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetMousePosOnOpeningCurrentPopup());
        }

        /// <summary>
        ///     Tests that get platform io throws dll not found exception
        /// </summary>
        [Fact]
        public void GetPlatformIo_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetPlatformIo());
        }

        /// <summary>
        ///     Tests that get scroll max x throws dll not found exception
        /// </summary>
        [Fact]
        public void GetScrollMaxX_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetScrollMaxX());
        }

        /// <summary>
        ///     Tests that get scroll max y throws dll not found exception
        /// </summary>
        [Fact]
        public void GetScrollMaxY_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetScrollMaxY());
        }

        /// <summary>
        ///     Tests that get scroll x throws dll not found exception
        /// </summary>
        [Fact]
        public void GetScrollX_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetScrollX());
        }

        /// <summary>
        ///     Tests that get scroll y throws dll not found exception
        /// </summary>
        [Fact]
        public void GetScrollY_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetScrollY());
        }

        /// <summary>
        ///     Tests that get state storage throws dll not found exception
        /// </summary>
        [Fact]
        public void GetStateStorage_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetStateStorage());
        }

        /// <summary>
        ///     Tests that get style throws dll not found exception
        /// </summary>
        [Fact]
        public void GetStyle_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetStyle());
        }

        /// <summary>
        ///     Tests that get style color name throws dll not found exception
        /// </summary>
        [Fact]
        public void GetStyleColorName_ThrowsDllNotFoundException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImGui.Native.ImGui.GetStyleColorName(ImGuiCol.Text));
        }

        /// <summary>
        ///     Tests that get style color vec 4 throws dll not found exception
        /// </summary>
        [Fact]
        public void GetStyleColorVec4_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetStyleColorVec4(ImGuiCol.Text));
        }

        /// <summary>
        ///     Tests that get text line height throws dll not found exception
        /// </summary>
        [Fact]
        public void GetTextLineHeight_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetTextLineHeight());
        }

        /// <summary>
        ///     Tests that get text line height with spacing throws dll not found exception
        /// </summary>
        [Fact]
        public void GetTextLineHeightWithSpacing_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetTextLineHeightWithSpacing());
        }

        /// <summary>
        ///     Tests that get time throws dll not found exception
        /// </summary>
        [Fact]
        public void GetTime_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetTime());
        }

        /// <summary>
        ///     Tests that get tree node to label spacing throws dll not found exception
        /// </summary>
        [Fact]
        public void GetTreeNodeToLabelSpacing_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetTreeNodeToLabelSpacing());
        }

        /// <summary>
        ///     Tests that get version throws dll not found exception
        /// </summary>
        [Fact]
        public void GetVersion_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetVersion());
        }

        /// <summary>
        ///     Tests that get window content region max throws dll not found exception
        /// </summary>
        [Fact]
        public void GetWindowContentRegionMax_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetWindowContentRegionMax());
        }

        /// <summary>
        ///     Tests that get window content region min throws dll not found exception
        /// </summary>
        [Fact]
        public void GetWindowContentRegionMin_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetWindowContentRegionMin());
        }

        /// <summary>
        ///     Tests that get window dock id throws dll not found exception
        /// </summary>
        [Fact]
        public void GetWindowDockId_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetWindowDockId());
        }

        /// <summary>
        ///     Tests that get window dpi scale throws dll not found exception
        /// </summary>
        [Fact]
        public void GetWindowDpiScale_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetWindowDpiScale());
        }

        /// <summary>
        ///     Tests that get window draw list throws dll not found exception
        /// </summary>
        [Fact]
        public void GetWindowDrawList_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetWindowDrawList());
        }

        /// <summary>
        ///     Tests that get window height throws dll not found exception
        /// </summary>
        [Fact]
        public void GetWindowHeight_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetWindowHeight());
        }

        /// <summary>
        ///     Tests that get window pos throws dll not found exception
        /// </summary>
        [Fact]
        public void GetWindowPos_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetWindowPos());
        }

        /// <summary>
        ///     Tests that get window size throws dll not found exception
        /// </summary>
        [Fact]
        public void GetWindowSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetWindowSize());
        }

        /// <summary>
        ///     Tests that get window viewport throws dll not found exception
        /// </summary>
        [Fact]
        public void GetWindowViewport_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetWindowViewport());
        }

        /// <summary>
        ///     Tests that get window width throws dll not found exception
        /// </summary>
        [Fact]
        public void GetWindowWidth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetWindowWidth());
        }

        /// <summary>
        ///     Tests that image throws dll not found exception
        /// </summary>
        [Fact]
        public void Image_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Image(IntPtr.Zero, new Vector2F(1, 1)));
        }

        /// <summary>
        ///     Tests that image with uv 0 throws dll not found exception
        /// </summary>
        [Fact]
        public void Image_WithUv0_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Image(IntPtr.Zero, new Vector2F(1, 1), new Vector2F(0, 0)));
        }

        /// <summary>
        ///     Tests that image with uv 0 and uv 1 throws dll not found exception
        /// </summary>
        [Fact]
        public void Image_WithUv0AndUv1_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Image(IntPtr.Zero, new Vector2F(1, 1), new Vector2F(0, 0), new Vector2F(1, 1)));
        }

        /// <summary>
        ///     Tests that image with uv 0 uv 1 and tint col throws dll not found exception
        /// </summary>
        [Fact]
        public void Image_WithUv0Uv1AndTintCol_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Image(IntPtr.Zero, new Vector2F(1, 1), new Vector2F(0, 0), new Vector2F(1, 1), new Vector4F(1, 1, 1, 1)));
        }

        /// <summary>
        ///     Tests that image with uv 0 uv 1 tint col and border col throws dll not found exception
        /// </summary>
        [Fact]
        public void Image_WithUv0Uv1TintColAndBorderCol_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Image(IntPtr.Zero, new Vector2F(1, 1), new Vector2F(0, 0), new Vector2F(1, 1), new Vector4F(1, 1, 1, 1), new Vector4F(0, 0, 0, 0)));
        }

        /// <summary>
        ///     Tests that image button throws dll not found exception
        /// </summary>
        [Fact]
        public void ImageButton_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ImageButton("test", IntPtr.Zero, new Vector2F(1, 1)));
        }

        /// <summary>
        ///     Tests that image button with uv 0 throws dll not found exception
        /// </summary>
        [Fact]
        public void ImageButton_WithUv0_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ImageButton("test", IntPtr.Zero, new Vector2F(1, 1), new Vector2F(0, 0)));
        }

        /// <summary>
        ///     Tests that image button with uv 0 and uv 1 throws dll not found exception
        /// </summary>
        [Fact]
        public void ImageButton_WithUv0AndUv1_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ImageButton("test", IntPtr.Zero, new Vector2F(1, 1), new Vector2F(0, 0), new Vector2F(1, 1)));
        }

        /// <summary>
        ///     Tests that image button with uv 0 uv 1 and bg col throws dll not found exception
        /// </summary>
        [Fact]
        public void ImageButton_WithUv0Uv1AndBgCol_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ImageButton("test", IntPtr.Zero, new Vector2F(1, 1), new Vector2F(0, 0), new Vector2F(1, 1), new Vector4F(0, 0, 0, 0)));
        }

        /// <summary>
        ///     Tests that image button with uv 0 uv 1 bg col and tint col throws dll not found exception
        /// </summary>
        [Fact]
        public void ImageButton_WithUv0Uv1BgColAndTintCol_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ImageButton("test", IntPtr.Zero, new Vector2F(1, 1), new Vector2F(0, 0), new Vector2F(1, 1), new Vector4F(0, 0, 0, 0), new Vector4F(1, 1, 1, 1)));
        }

        /// <summary>
        ///     Tests that indent throws dll not found exception
        /// </summary>
        [Fact]
        public void Indent_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Indent());
        }

        /// <summary>
        ///     Tests that indent with indent w throws dll not found exception
        /// </summary>
        [Fact]
        public void Indent_WithIndentW_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Indent(1.0f));
        }

        /// <summary>
        ///     Tests that input double throws dll not found exception
        /// </summary>
        [Fact]
        public void InputDouble_ThrowsDllNotFoundException()
        {
            double v = 0.0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.InputDouble("test", ref v));
        }

        /// <summary>
        ///     Tests that input double with step throws dll not found exception
        /// </summary>
        [Fact]
        public void InputDouble_WithStep_ThrowsDllNotFoundException()
        {
            double v = 0.0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.InputDouble("test", ref v, 1.0));
        }

        /// <summary>
        ///     Tests that input double throws dll not found exception v 5
        /// </summary>
        [Fact]
        public void InputDouble_ThrowsDllNotFoundException_v5()
        {
            double v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.InputDouble("label", ref v, 1.0, 1.0));
        }

        /// <summary>
        ///     Tests that input double with format throws dll not found exception
        /// </summary>
        [Fact]
        public void InputDouble_WithFormat_ThrowsDllNotFoundException()
        {
            double v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.InputDouble("label", ref v, 1.0, 1.0, "%f"));
        }

        /// <summary>
        ///     Tests that input double with format and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void InputDouble_WithFormatAndFlags_ThrowsDllNotFoundException()
        {
            double v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.InputDouble("label", ref v, 1.0, 1.0, "%f", ImGuiInputTextFlags.None));
        }

        /// <summary>
        ///     Tests that input float throws dll not found exception
        /// </summary>
        [Fact]
        public void InputFloat_ThrowsDllNotFoundException()
        {
            float v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.InputFloat("label", ref v));
        }

        /// <summary>
        ///     Tests that input float with step throws dll not found exception
        /// </summary>
        [Fact]
        public void InputFloat_WithStep_ThrowsDllNotFoundException()
        {
            float v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.InputFloat("label", ref v, 1.0f));
        }

        /// <summary>
        ///     Tests that input float with step and step fast throws dll not found exception
        /// </summary>
        [Fact]
        public void InputFloat_WithStepAndStepFast_ThrowsDllNotFoundException()
        {
            float v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.InputFloat("label", ref v, 1.0f, 1.0f));
        }

        /// <summary>
        ///     Tests that input float with format throws dll not found exception
        /// </summary>
        [Fact]
        public void InputFloat_WithFormat_ThrowsDllNotFoundException()
        {
            float v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.InputFloat("label", ref v, 1.0f, 1.0f, "%f"));
        }

        /// <summary>
        ///     Tests that input float with format and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void InputFloat_WithFormatAndFlags_ThrowsDllNotFoundException()
        {
            float v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.InputFloat("label", ref v, 1.0f, 1.0f, "%f", ImGuiInputTextFlags.None));
        }

        /// <summary>
        ///     Tests that input float 2 throws dll not found exception
        /// </summary>
        [Fact]
        public void InputFloat2_ThrowsDllNotFoundException()
        {
            Vector2F v = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.InputFloat2("label", ref v));
        }

        /// <summary>
        ///     Tests that input float 2 with format throws dll not found exception
        /// </summary>
        [Fact]
        public void InputFloat2_WithFormat_ThrowsDllNotFoundException()
        {
            Vector2F v = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.InputFloat2("label", ref v, "%f"));
        }

        /// <summary>
        ///     Tests that input float 2 with format and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void InputFloat2_WithFormatAndFlags_ThrowsDllNotFoundException()
        {
            Vector2F v = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.InputFloat2("label", ref v, "%f", ImGuiInputTextFlags.None));
        }

        /// <summary>
        ///     Tests that input float 3 throws dll not found exception
        /// </summary>
        [Fact]
        public void InputFloat3_ThrowsDllNotFoundException()
        {
            Vector3F v = new Vector3F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.InputFloat3("label", ref v));
        }

        /// <summary>
        ///     Tests that input float 3 with format throws dll not found exception
        /// </summary>
        [Fact]
        public void InputFloat3_WithFormat_ThrowsDllNotFoundException()
        {
            Vector3F v = new Vector3F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.InputFloat3("label", ref v, "%f"));
        }

        /// <summary>
        ///     Tests that input float 3 with format and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void InputFloat3_WithFormatAndFlags_ThrowsDllNotFoundException()
        {
            Vector3F v = new Vector3F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.InputFloat3("label", ref v, "%f", ImGuiInputTextFlags.None));
        }

        /// <summary>
        ///     Tests that input float 4 throws dll not found exception
        /// </summary>
        [Fact]
        public void InputFloat4_ThrowsDllNotFoundException()
        {
            Vector4F v = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.InputFloat4("label", ref v));
        }

        /// <summary>
        ///     Tests that drag scalar n throws dll not found exception
        /// </summary>
        [Fact]
        public void DragScalarN_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragScalarN("label", ImGuiDataType.Float, IntPtr.Zero, 1, 1.0f, IntPtr.Zero, IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that drag scalar n with format throws dll not found exception
        /// </summary>
        [Fact]
        public void DragScalarN_WithFormat_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragScalarN("label", ImGuiDataType.Float, IntPtr.Zero, 1, 1.0f, IntPtr.Zero, IntPtr.Zero, "format"));
        }

        /// <summary>
        ///     Tests that drag scalar n with format and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void DragScalarN_WithFormatAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragScalarN("label", ImGuiDataType.Float, IntPtr.Zero, 1, 1.0f, IntPtr.Zero, IntPtr.Zero, "format", ImGuiSliderFlags.None));
        }

        /// <summary>
        ///     Tests that dummy throws dll not found exception
        /// </summary>
        [Fact]
        public void Dummy_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Dummy(new Vector2F(1.0f, 1.0f)));
        }

        /// <summary>
        ///     Tests that end throws dll not found exception
        /// </summary>
        [Fact]
        public void End_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.End());
        }

        /// <summary>
        ///     Tests that end child throws dll not found exception
        /// </summary>
        [Fact]
        public void EndChild_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.EndChild());
        }

        /// <summary>
        ///     Tests that end child frame throws dll not found exception
        /// </summary>
        [Fact]
        public void EndChildFrame_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.EndChildFrame());
        }

        /// <summary>
        ///     Tests that end combo throws dll not found exception
        /// </summary>
        [Fact]
        public void EndCombo_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.EndCombo());
        }

        /// <summary>
        ///     Tests that end disabled throws dll not found exception
        /// </summary>
        [Fact]
        public void EndDisabled_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.EndDisabled());
        }

        /// <summary>
        ///     Tests that end drag drop source throws dll not found exception
        /// </summary>
        [Fact]
        public void EndDragDropSource_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.EndDragDropSource());
        }

        /// <summary>
        ///     Tests that end drag drop target throws dll not found exception
        /// </summary>
        [Fact]
        public void EndDragDropTarget_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.EndDragDropTarget());
        }

        /// <summary>
        ///     Tests that end frame throws dll not found exception
        /// </summary>
        [Fact]
        public void EndFrame_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.EndFrame());
        }

        /// <summary>
        ///     Tests that end group throws dll not found exception
        /// </summary>
        [Fact]
        public void EndGroup_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.EndGroup());
        }

        /// <summary>
        ///     Tests that end list box throws dll not found exception
        /// </summary>
        [Fact]
        public void EndListBox_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.EndListBox());
        }

        /// <summary>
        ///     Tests that end main menu bar throws dll not found exception
        /// </summary>
        [Fact]
        public void EndMainMenuBar_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.EndMainMenuBar());
        }

        /// <summary>
        ///     Tests that end menu throws dll not found exception
        /// </summary>
        [Fact]
        public void EndMenu_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.EndMenu());
        }

        /// <summary>
        ///     Tests that end menu bar throws dll not found exception
        /// </summary>
        [Fact]
        public void EndMenuBar_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.EndMenuBar());
        }

        /// <summary>
        ///     Tests that end popup throws dll not found exception
        /// </summary>
        [Fact]
        public void EndPopup_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.EndPopup());
        }

        /// <summary>
        ///     Tests that end tab bar throws dll not found exception
        /// </summary>
        [Fact]
        public void EndTabBar_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.EndTabBar());
        }

        /// <summary>
        ///     Tests that drag int throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt("label", ref v, 1.0f));
        }

        /// <summary>
        ///     Tests that drag int with min throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt_WithMin_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt("label", ref v, 1.0f, 0));
        }

        /// <summary>
        ///     Tests that drag int with min max throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt_WithMinMax_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt("label", ref v, 1.0f, 0, 100));
        }

        /// <summary>
        ///     Tests that drag int with min max format throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt_WithMinMaxFormat_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt("label", ref v, 1.0f, 0, 100, "%d"));
        }

        /// <summary>
        ///     Tests that drag int with min max format flags throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt_WithMinMaxFormatFlags_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt("label", ref v, 1.0f, 0, 100, "%d", ImGuiSliderFlags.None));
        }

        /// <summary>
        ///     Tests that drag int 2 throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt2_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt2("label", ref v));
        }

        /// <summary>
        ///     Tests that drag int 2 with speed throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt2_WithSpeed_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt2("label", ref v, 1.0f));
        }

        /// <summary>
        ///     Tests that drag int 2 with speed min throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt2_WithSpeedMin_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt2("label", ref v, 1.0f, 0));
        }

        /// <summary>
        ///     Tests that drag int 2 with speed min max throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt2_WithSpeedMinMax_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt2("label", ref v, 1.0f, 0, 100));
        }

        /// <summary>
        ///     Tests that drag int 2 with speed min max format throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt2_WithSpeedMinMaxFormat_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt2("label", ref v, 1.0f, 0, 100, "%d"));
        }

        /// <summary>
        ///     Tests that drag int 2 with speed min max format flags throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt2_WithSpeedMinMaxFormatFlags_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt2("label", ref v, 1.0f, 0, 100, "%d", ImGuiSliderFlags.None));
        }

        /// <summary>
        ///     Tests that drag int 3 throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt3_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt3("label", ref v));
        }

        /// <summary>
        ///     Tests that drag int 3 with speed throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt3_WithSpeed_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt3("label", ref v, 1.0f));
        }

        /// <summary>
        ///     Tests that drag int 3 with speed min throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt3_WithSpeedMin_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt3("label", ref v, 1.0f, 0));
        }

        /// <summary>
        ///     Tests that drag int 3 with speed min max throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt3_WithSpeedMinMax_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt3("label", ref v, 1.0f, 0, 100));
        }

        /// <summary>
        ///     Tests that drag int 3 with speed min max format throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt3_WithSpeedMinMaxFormat_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt3("label", ref v, 1.0f, 0, 100, "%d"));
        }

        /// <summary>
        ///     Tests that drag int 3 with speed min max format flags throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt3_WithSpeedMinMaxFormatFlags_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt3("label", ref v, 1.0f, 0, 100, "%d", ImGuiSliderFlags.None));
        }

        /// <summary>
        ///     Tests that drag int 4 throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt4_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt4("label", ref v));
        }

        /// <summary>
        ///     Tests that drag int 4 with speed throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt4_WithSpeed_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt4("label", ref v, 1.0f));
        }

        /// <summary>
        ///     Tests that drag int 4 with speed min throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt4_WithSpeedMin_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt4("label", ref v, 1.0f, 0));
        }

        /// <summary>
        ///     Tests that drag int 4 with speed min max throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt4_WithSpeedMinMax_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt4("label", ref v, 1.0f, 0, 100));
        }

        /// <summary>
        ///     Tests that drag int 4 with speed min max format throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt4_WithSpeedMinMaxFormat_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt4("label", ref v, 1.0f, 0, 100, "%d"));
        }

        /// <summary>
        ///     Tests that drag int 4 with speed min max format flags throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt4_WithSpeedMinMaxFormatFlags_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt4("label", ref v, 1.0f, 0, 100, "%d", ImGuiSliderFlags.None));
        }

        /// <summary>
        ///     Tests that drag int range 2 throws dll not found exception
        /// </summary>
        [Fact]
        public void DragIntRange2_ThrowsDllNotFoundException()
        {
            int vMin = 0, vMax = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragIntRange2("label", ref vMin, ref vMax));
        }

        /// <summary>
        ///     Tests that drag int range 2 with speed throws dll not found exception
        /// </summary>
        [Fact]
        public void DragIntRange2_WithSpeed_ThrowsDllNotFoundException()
        {
            int vMin = 0, vMax = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragIntRange2("label", ref vMin, ref vMax, 1.0f));
        }

        /// <summary>
        ///     Tests that drag int range 2 with speed min throws dll not found exception
        /// </summary>
        [Fact]
        public void DragIntRange2_WithSpeedMin_ThrowsDllNotFoundException()
        {
            int vMin = 0, vMax = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragIntRange2("label", ref vMin, ref vMax, 1.0f, 0));
        }

        /// <summary>
        ///     Tests that drag int range 2 with speed min max throws dll not found exception
        /// </summary>
        [Fact]
        public void DragIntRange2_WithSpeedMinMax_ThrowsDllNotFoundException()
        {
            int vMin = 0, vMax = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragIntRange2("label", ref vMin, ref vMax, 1.0f, 0, 100));
        }

        /// <summary>
        ///     Tests that drag int range 2 with speed min max format throws dll not found exception
        /// </summary>
        [Fact]
        public void DragIntRange2_WithSpeedMinMaxFormat_ThrowsDllNotFoundException()
        {
            int vMin = 0, vMax = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragIntRange2("label", ref vMin, ref vMax, 1.0f, 0, 100, "%d"));
        }

        /// <summary>
        ///     Tests that drag int range 2 with all params throws dll not found exception
        /// </summary>
        [Fact]
        public void DragIntRange2_WithAllParams_ThrowsDllNotFoundException()
        {
            int vMin = 0, vMax = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragIntRange2("label", ref vMin, ref vMax, 1.0f, 0, 100, "%d", "%d", ImGuiSliderFlags.None));
        }
    }
}