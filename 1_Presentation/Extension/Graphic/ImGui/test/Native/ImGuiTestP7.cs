// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTestP7.cs
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
using System.Text;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test.Native
{
    /// <summary>
    /// The im gui test class
    /// </summary>
    public partial class ImGuiTest
    {
        /// <summary>
        /// Tests that pop id throws dll not found exception
        /// </summary>
        [Fact]
        public void PopId_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igPopID());
        }
        
        /// <summary>
        /// Tests that pop item width throws dll not found exception
        /// </summary>
        [Fact]
        public void PopItemWidth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igPopItemWidth());
        }
        
        /// <summary>
        /// Tests that pop style color throws dll not found exception
        /// </summary>
        [Fact]
        public void PopStyleColor_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igPopStyleColor(1));
        }
        
        /// <summary>
        /// Tests that pop style color with count throws dll not found exception
        /// </summary>
        [Fact]
        public void PopStyleColor_WithCount_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igPopStyleColor(2));
        }
        
        /// <summary>
        /// Tests that pop style var throws dll not found exception
        /// </summary>
        [Fact]
        public void PopStyleVar_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igPopStyleVar(1));
        }
        
        /// <summary>
        /// Tests that pop style var with count throws dll not found exception
        /// </summary>
        [Fact]
        public void PopStyleVar_WithCount_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igPopStyleVar(2));
        }
        
        /// <summary>
        /// Tests that pop text wrap pos throws dll not found exception
        /// </summary>
        [Fact]
        public void PopTextWrapPos_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igPopTextWrapPos());
        }
        
        /// <summary>
        /// Tests that progress bar throws dll not found exception
        /// </summary>
        [Fact]
        public void ProgressBar_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igProgressBar(0.5f, new Vector2(-float.MinValue, 0.0f), null));
        }
        
        /// <summary>
        /// Tests that progress bar with size arg throws dll not found exception
        /// </summary>
        [Fact]
        public void ProgressBar_WithSizeArg_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igProgressBar(0.5f, new Vector2(100, 50), null));
        }
        
        /// <summary>
        /// Tests that progress bar with size arg and overlay throws dll not found exception
        /// </summary>
        [Fact]
        public void v3_ProgressBar_WithSizeArgAndOverlay_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igProgressBar(0.5f, new Vector2(100, 50), Encoding.UTF8.GetBytes("Overlay")));
        }
        
        /// <summary>
        /// Tests that push allow keyboard focus throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_v2_PushAllowKeyboardFocus_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igPushAllowKeyboardFocus(1));
        }
        
        /// <summary>
        /// Tests that push button repeat throws dll not found exception
        /// </summary>
        [Fact]
        public void v3_PushButtonRepeat_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igPushButtonRepeat(1));
        }
        
        /// <summary>
        /// Tests that push clip rect throws dll not found exception
        /// </summary>
        [Fact]
        public void v3_PushClipRect_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igPushClipRect(new Vector2(0, 0), new Vector2(100, 100), 1));
        }
        
        /// <summary>
        /// Tests that push font throws dll not found exception
        /// </summary>
        [Fact]
        public void v3_PushFont_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igPushFont(IntPtr.Zero));
        }
        
        /// <summary>
        /// Tests that push id with string throws dll not found exception
        /// </summary>
        [Fact]
        public void v3_PushId_WithString_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igPushID_Str(Encoding.UTF8.GetBytes("test")));
        }
        
        /// <summary>
        /// Tests that push id with pointer throws dll not found exception
        /// </summary>
        [Fact]
        public void PushId_WithPointer_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igPushID_Ptr(IntPtr.Zero));
        }
        
        /// <summary>
        /// Tests that push id with int throws dll not found exception
        /// </summary>
        [Fact]
        public void v3_PushId_WithInt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igPushID_Int(1));
        }
        
        /// <summary>
        /// Tests that push item width throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PushItemWidth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igPushItemWidth(100.0f));
        }
        
        /// <summary>
        /// Tests that push style color with u 32 throws dll not found exception
        /// </summary>
        [Fact]
        public void PushStyleColor_WithU32_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igPushStyleColor_U32(ImGuiCol.Text, 0xFFFFFFFF));
        }
        
        /// <summary>
        /// Tests that push style color with vec 4 throws dll not found exception
        /// </summary>
        [Fact]
        public void PushStyleColor_WithVec4_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igPushStyleColor_Vec4(ImGuiCol.Text, new Vector4(1, 1, 1, 1)));
        }
        
        /// <summary>
        /// Tests that push style var with float throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PushStyleVar_WithFloat_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igPushStyleVar_Float(ImGuiStyleVar.Alpha, 1.0f));
        }
        
        /// <summary>
        /// Tests that push style var with vec 2 throws dll not found exception
        /// </summary>
        [Fact]
        public void PushStyleVar_WithVec2_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igPushStyleVar_Vec2(ImGuiStyleVar.WindowPadding, new Vector2(1, 1)));
        }
        
        /// <summary>
        /// Tests that push text wrap pos throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PushTextWrapPos_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igPushTextWrapPos(0.0f));
        }
        
        /// <summary>
        /// Tests that push text wrap pos with wrap local pos x throws dll not found exception
        /// </summary>
        [Fact]
        public void PushTextWrapPos_WithWrapLocalPosX_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igPushTextWrapPos(100.0f));
        }
        
        /// <summary>
        /// Tests that radio button with bool throws dll not found exception
        /// </summary>
        [Fact]
        public void RadioButton_WithBool_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igRadioButton_Bool(Encoding.UTF8.GetBytes("Radio"), true));
        }
        
        /// <summary>
        /// Tests that radio button with int ptr throws dll not found exception
        /// </summary>
        [Fact]
        public void RadioButton_WithIntPtr_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igRadioButton_IntPtr(Encoding.UTF8.GetBytes("Radio"), ref v, 1));
        }
        
        /// <summary>
        /// Tests that render throws dll not found exception
        /// </summary>
        [Fact]
        public void Render_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igRender());
        }
        
        /// <summary>
        /// Tests that render platform windows default throws dll not found exception
        /// </summary>
        [Fact]
        public void RenderPlatformWindowsDefault_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igRenderPlatformWindowsDefault(IntPtr.Zero, IntPtr.Zero));
        }
        
        /// <summary>
        /// Tests that render platform windows default with platform render arg throws dll not found exception
        /// </summary>
        [Fact]
        public void RenderPlatformWindowsDefault_WithPlatformRenderArg_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igRenderPlatformWindowsDefault(IntPtr.Zero, IntPtr.Zero));
        }
        
        /// <summary>
        /// Tests that render platform windows default with platform render arg and renderer render arg throws dll not found exception
        /// </summary>
        [Fact]
        public void RenderPlatformWindowsDefault_WithPlatformRenderArgAndRendererRenderArg_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igRenderPlatformWindowsDefault(IntPtr.Zero, IntPtr.Zero));
        }
        
        /// <summary>
        /// Tests that reset mouse drag delta throws dll not found exception
        /// </summary>
        [Fact]
        public void ResetMouseDragDelta_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igResetMouseDragDelta(0));
        }
        
        /// <summary>
        /// Tests that reset mouse drag delta with button throws dll not found exception
        /// </summary>
        [Fact]
        public void ResetMouseDragDelta_WithButton_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igResetMouseDragDelta(ImGuiMouseButton.Count));
        }
        
        /// <summary>
        /// Tests that same line throws dll not found exception
        /// </summary>
        [Fact]
        public void SameLine_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSameLine(0.0f, -1.0f));
        }
        
        /// <summary>
        /// Tests that same line with offset from start x throws dll not found exception
        /// </summary>
        [Fact]
        public void SameLine_WithOffsetFromStartX_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSameLine(100.0f, -1.0f));
        }
        
        /// <summary>
        /// Tests that same line with offset from start x and spacing throws dll not found exception
        /// </summary>
        [Fact]
        public void SameLine_WithOffsetFromStartXAndSpacing_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSameLine(100.0f, 10.0f));
        }
        
        /// <summary>
        /// Tests that save ini settings to disk throws dll not found exception
        /// </summary>
        [Fact]
        public void SaveIniSettingsToDisk_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSaveIniSettingsToDisk(Encoding.UTF8.GetBytes("test.ini")));
        }
        
        /// <summary>
        /// Tests that save ini settings to memory throws dll not found exception
        /// </summary>
        [Fact]
        public void SaveIniSettingsToMemory_ThrowsDllNotFoundException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImGuiNative.igSaveIniSettingsToMemory(out _));
        }
        
        /// <summary>
        /// Tests that selectable throws dll not found exception
        /// </summary>
        [Fact]
        public void Selectable_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSelectable_Bool(Encoding.UTF8.GetBytes("Selectable"), false, 0, new Vector2()));
        }
        
        /// <summary>
        /// Tests that selectable with selected throws dll not found exception
        /// </summary>
        [Fact]
        public void Selectable_WithSelected_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSelectable_Bool(Encoding.UTF8.GetBytes("Selectable"), true, 0, new Vector2()));
        }
        
        /// <summary>
        /// Tests that selectable with selected and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void Selectable_WithSelectedAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSelectable_Bool(Encoding.UTF8.GetBytes("Selectable"), true, ImGuiSelectableFlags.DontClosePopups, new Vector2()));
        }
        
        /// <summary>
        /// Tests that selectable with selected flags and size throws dll not found exception
        /// </summary>
        [Fact]
        public void Selectable_WithSelectedFlagsAndSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSelectable_Bool(Encoding.UTF8.GetBytes("Selectable"), true, ImGuiSelectableFlags.DontClosePopups, new Vector2(100, 50)));
        }
        
        /// <summary>
        /// Tests that selectable with ref bool throws dll not found exception
        /// </summary>
        [Fact]
        public void Selectable_WithRefBool_ThrowsDllNotFoundException()
        {
            bool selected = false;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSelectable_BoolPtr(Encoding.UTF8.GetBytes("Selectable"), selected, 0, new Vector2()));
        }
        
        /// <summary>
        /// Tests that selectable with ref bool and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void Selectable_WithRefBoolAndFlags_ThrowsDllNotFoundException()
        {
            bool selected = false;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSelectable_BoolPtr(Encoding.UTF8.GetBytes("Selectable"), selected, ImGuiSelectableFlags.DontClosePopups, new Vector2()));
        }
        
        /// <summary>
        /// Tests that selectable with ref bool flags and size throws dll not found exception
        /// </summary>
        [Fact]
        public void Selectable_WithRefBoolFlagsAndSize_ThrowsDllNotFoundException()
        {
            bool selected = false;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSelectable_BoolPtr(Encoding.UTF8.GetBytes("Selectable"), selected, ImGuiSelectableFlags.DontClosePopups, new Vector2(100, 50)));
        }
        
        /// <summary>
        /// Tests that separator throws dll not found exception
        /// </summary>
        [Fact]
        public void Separator_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSeparator());
        }
        
        /// <summary>
        /// Tests that set allocator functions throws dll not found exception
        /// </summary>
        [Fact]
        public void SetAllocatorFunctions_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetAllocatorFunctions(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
        }
        
        /// <summary>
        /// Tests that set clipboard text throws dll not found exception
        /// </summary>
        [Fact]
        public void SetClipboardText_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetClipboardText(Encoding.UTF8.GetBytes("Clipboard text")));
        }
        
        /// <summary>
        /// Tests that set color edit options throws dll not found exception
        /// </summary>
        [Fact]
        public void SetColorEditOptions_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetColorEditOptions(ImGuiColorEditFlags.NoAlpha));
        }
        
        /// <summary>
        /// Tests that set column offset throws dll not found exception
        /// </summary>
        [Fact]
        public void SetColumnOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetColumnOffset(0, 100.0f));
        }
        
        /// <summary>
        /// Tests that set column width throws dll not found exception
        /// </summary>
        [Fact]
        public void SetColumnWidth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetColumnWidth(0, 100.0f));
        }
        
        /// <summary>
        /// Tests that set current context throws dll not found exception
        /// </summary>
        [Fact]
        public void SetCurrentContext_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetCurrentContext(IntPtr.Zero));
        }
        
        /// <summary>
        /// Tests that set cursor pos throws dll not found exception
        /// </summary>
        [Fact]
        public void SetCursorPos_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetCursorPos(new Vector2(100, 100)));
        }
        
        /// <summary>
        /// Tests that set cursor pos x throws dll not found exception
        /// </summary>
        [Fact]
        public void SetCursorPosX_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetCursorPosX(100.0f));
        }
        
        /// <summary>
        /// Tests that set cursor pos y throws dll not found exception
        /// </summary>
        [Fact]
        public void SetCursorPosY_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetCursorPosY(100.0f));
        }
        
        /// <summary>
        /// Tests that set cursor screen pos throws dll not found exception
        /// </summary>
        [Fact]
        public void SetCursorScreenPos_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetCursorScreenPos(new Vector2(100, 100)));
        }
        
        /// <summary>
        /// Tests that set drag drop payload throws dll not found exception
        /// </summary>
        [Fact]
        public void SetDragDropPayload_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetDragDropPayload(Encoding.UTF8.GetBytes("Payload"), IntPtr.Zero, 0, ImGuiCond.None));
        }
        
        /// <summary>
        /// Tests that set drag drop payload with cond throws dll not found exception
        /// </summary>
        [Fact]
        public void SetDragDropPayload_WithCond_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetDragDropPayload(Encoding.UTF8.GetBytes("Payload"), IntPtr.Zero, 0, ImGuiCond.Always));
        }
        
        /// <summary>
        /// Tests that set item allow overlap throws dll not found exception
        /// </summary>
        [Fact]
        public void SetItemAllowOverlap_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetItemAllowOverlap());
        }
        
        /// <summary>
        /// Tests that set item default focus throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetItemDefaultFocus_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetItemDefaultFocus());
        }
        
        /// <summary>
        /// Tests that set keyboard focus here throws dll not found exception
        /// </summary>
        [Fact]
        public void SetKeyboardFocusHere_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetKeyboardFocusHere(0));
        }
        
        /// <summary>
        /// Tests that set keyboard focus here with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetKeyboardFocusHere_WithOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetKeyboardFocusHere(1));
        }
        
        /// <summary>
        /// Tests that set mouse cursor throws dll not found exception
        /// </summary>
        [Fact]
        public void SetMouseCursor_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetMouseCursor(ImGuiMouseCursor.Arrow));
        }
        
        /// <summary>
        /// Tests that set next frame want capture keyboard throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNextFrameWantCaptureKeyboard_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetNextFrameWantCaptureKeyboard(1));
        }
        
        /// <summary>
        /// Tests that set next frame want capture mouse throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNextFrameWantCaptureMouse_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetNextFrameWantCaptureMouse(1));
        }
        
        /// <summary>
        /// Tests that set next item open throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNextItemOpen_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetNextItemOpen(1, ImGuiCond.None));
        }
        
        /// <summary>
        /// Tests that set next item open with cond throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNextItemOpen_WithCond_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetNextItemOpen(1, ImGuiCond.Always));
        }
        
        /// <summary>
        /// Tests that set next item width throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNextItemWidth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetNextItemWidth(100.0f));
        }
        
        /// <summary>
        /// Tests that set next window bg alpha throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNextWindowBgAlpha_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetNextWindowBgAlpha(0.5f));
        }
        
        /// <summary>
        /// Tests that set next window class throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNextWindowClass_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetNextWindowClass(new ImGuiWindowClass()));
        }
        
        /// <summary>
        /// Tests that set next window collapsed throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNextWindowCollapsed_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetNextWindowCollapsed(1, ImGuiCond.None));
        }
        
        /// <summary>
        /// Tests that set next window collapsed with cond throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNextWindowCollapsed_WithCond_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetNextWindowCollapsed(1, ImGuiCond.Always));
        }
        
        /// <summary>
        /// Tests that set next window content size throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNextWindowContentSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetNextWindowContentSize(new Vector2(100, 100)));
        }
        
        /// <summary>
        /// Tests that set next window dock id throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNextWindowDockId_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetNextWindowDockID(1, ImGuiCond.None));
        }
        
        /// <summary>
        /// Tests that set next window dock id with cond throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNextWindowDockId_WithCond_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetNextWindowDockID(1, ImGuiCond.Always));
        }
        
        /// <summary>
        /// Tests that set next window focus throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNextWindowFocus_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetNextWindowFocus());
        }
        
        /// <summary>
        /// Tests that set next window pos throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNextWindowPos_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetNextWindowPos(new Vector2(100, 100), ImGuiCond.None, new Vector2()));
        }
        
        /// <summary>
        /// Tests that set next window pos with cond throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetNextWindowPos_WithCond_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetNextWindowPos(new Vector2(100, 100), ImGuiCond.Always, new Vector2()));
        }
        
        /// <summary>
        /// Tests that set next window pos with cond and pivot throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNextWindowPos_WithCondAndPivot_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetNextWindowPos(new Vector2(100, 100), ImGuiCond.Always, new Vector2(0.5f, 0.5f)));
        }
        
        /// <summary>
        /// Tests that set next window scroll throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNextWindowScroll_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetNextWindowScroll(new Vector2(100, 100)));
        }
        
        /// <summary>
        /// Tests that set next window size throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNextWindowSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetNextWindowSize(new Vector2(100, 100), ImGuiCond.None));
        }
        
        /// <summary>
        /// Tests that set next window size with cond throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNextWindowSize_WithCond_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetNextWindowSize(new Vector2(100, 100), ImGuiCond.Always));
        }
        
        /// <summary>
        /// Tests that set next window size constraints throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNextWindowSizeConstraints_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetNextWindowSizeConstraints(new Vector2(100, 100), new Vector2(200, 200), null, IntPtr.Zero));
        }
        
        /// <summary>
        /// Tests that set next window size constraints with callback throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNextWindowSizeConstraints_WithCallback_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetNextWindowSizeConstraints(new Vector2(100, 100), new Vector2(200, 200), (out ImGuiSizeCallbackData data) =>
            {
                data = default;
                Callback(data);
            }, IntPtr.Zero));
        }
        
        /// <summary>
        /// Callbacks the data
        /// </summary>
        /// <param name="data">The data</param>
        private void Callback(ImGuiSizeCallbackData data)
        {
        }
        
        /// <summary>
        /// Tests that set next window size constraints with callback and data throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNextWindowSizeConstraints_WithCallbackAndData_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igSetNextWindowSizeConstraints(new Vector2(100, 100), new Vector2(200, 200), (out ImGuiSizeCallbackData data) =>
            {
                data = default;
                CustomCallback(data);
            }, new IntPtr(1)));
        }
        
        /// <summary>
        /// Customs the callback using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        private void CustomCallback(ImGuiSizeCallbackData data)
        {
        }
        
        /// <summary>
        /// Tests that v 2 pop id throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PopId_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.PopId());
        }
        
        /// <summary>
        /// Tests that v 2 pop item width throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PopItemWidth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.PopItemWidth());
        }
        
        /// <summary>
        /// Tests that v 2 pop style color throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PopStyleColor_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.PopStyleColor());
        }
        
        /// <summary>
        /// Tests that v 2 pop style color with count throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PopStyleColor_WithCount_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.PopStyleColor(1));
        }
        
        /// <summary>
        /// Tests that v 2 pop style var throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PopStyleVar_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.PopStyleVar());
        }
        
        /// <summary>
        /// Tests that v 2 pop style var with count throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PopStyleVar_WithCount_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.PopStyleVar(1));
        }
        
        /// <summary>
        /// Tests that v 2 pop text wrap pos throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PopTextWrapPos_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.PopTextWrapPos());
        }
        
        /// <summary>
        /// Tests that v 2 progress bar throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_ProgressBar_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ProgressBar(0.5f));
        }
        
        /// <summary>
        /// Tests that v 2 progress bar with size arg throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_ProgressBar_WithSizeArg_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ProgressBar(0.5f, new Vector2(100, 20)));
        }
        
        /// <summary>
        /// Tests that v 2 progress bar with size arg and overlay throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_ProgressBar_WithSizeArgAndOverlay_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ProgressBar(0.5f, new Vector2(100, 20), "Overlay"));
        }
        
        /// <summary>
        /// Tests that v 2 push allow keyboard focus throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PushAllowKeyboardFocus_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.PushAllowKeyboardFocus(true));
        }
        
        /// <summary>
        /// Tests that v 2 push button repeat throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PushButtonRepeat_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.PushButtonRepeat(true));
        }
        
        /// <summary>
        /// Tests that v 2 push clip rect throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PushClipRect_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.PushClipRect(new Vector2(0, 0), new Vector2(100, 100), true));
        }
        
        /// <summary>
        /// Tests that v 2 push font throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PushFont_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.PushFont(new ImFontPtr(IntPtr.Zero)));
        }
        
        /// <summary>
        /// Tests that v 2 push id with string throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PushId_WithString_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.PushId("test"));
        }
        
        /// <summary>
        /// Tests that push id with int ptr throws dll not found exception
        /// </summary>
        [Fact]
        public void PushId_WithIntPtr_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.PushId(IntPtr.Zero));
        }
        
        /// <summary>
        /// Tests that v 2 push id with int throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PushId_WithInt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.PushId(1));
        }
        
        /// <summary>
        /// Tests that v 3 push item width throws dll not found exception
        /// </summary>
        [Fact]
        public void v3_PushItemWidth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.PushItemWidth(100.0f));
        }
        
        /// <summary>
        /// Tests that push style color with u int throws dll not found exception
        /// </summary>
        [Fact]
        public void PushStyleColor_WithUInt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.PushStyleColor(ImGuiCol.Text, 0xFFFFFFFF));
        }
        
        /// <summary>
        /// Tests that push style color with vector 4 throws dll not found exception
        /// </summary>
        [Fact]
        public void PushStyleColor_WithVector4_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.PushStyleColor(ImGuiCol.Text, new Vector4(1, 1, 1, 1)));
        }
        
        /// <summary>
        /// Tests that v 3 push style var with float throws dll not found exception
        /// </summary>
        [Fact]
        public void v3_PushStyleVar_WithFloat_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.PushStyleVar(ImGuiStyleVar.Alpha, 1.0f));
        }
        
        /// <summary>
        /// Tests that push style var with vector 2 throws dll not found exception
        /// </summary>
        [Fact]
        public void PushStyleVar_WithVector2_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new Vector2(1, 1)));
        }
        
        /// <summary>
        /// Tests that push text wrap pos throws dll not found exception
        /// </summary>
        [Fact]
        public void PushTextWrapPos_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.PushTextWrapPos());
        }
        
        /// <summary>
        /// Tests that push text wrap pos with float throws dll not found exception
        /// </summary>
        [Fact]
        public void PushTextWrapPos_WithFloat_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.PushTextWrapPos(100.0f));
        }
        
        /// <summary>
        /// Tests that v 2 radio button with bool throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_RadioButton_WithBool_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.RadioButton("label", true));
        }
        
        /// <summary>
        /// Tests that v 2 radio button with int ptr throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_RadioButton_WithIntPtr_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.RadioButton("label", ref v, 1));
        }
        
        /// <summary>
        /// Tests that v 2 render throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_Render_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Render());
        }
        
        /// <summary>
        /// Tests that v 2 render platform windows default throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_RenderPlatformWindowsDefault_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.RenderPlatformWindowsDefault());
        }
        
        /// <summary>
        /// Tests that v 2 render platform windows default with platform render arg throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_RenderPlatformWindowsDefault_WithPlatformRenderArg_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.RenderPlatformWindowsDefault(IntPtr.Zero));
        }
        
        /// <summary>
        /// Tests that v 2 render platform windows default with platform render arg and renderer render arg throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_RenderPlatformWindowsDefault_WithPlatformRenderArgAndRendererRenderArg_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.RenderPlatformWindowsDefault(IntPtr.Zero, IntPtr.Zero));
        }
        
        /// <summary>
        /// Tests that v 2 reset mouse drag delta throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_ResetMouseDragDelta_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ResetMouseDragDelta());
        }
        
        /// <summary>
        /// Tests that v 2 reset mouse drag delta with button throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_ResetMouseDragDelta_WithButton_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ResetMouseDragDelta(ImGuiMouseButton.Left));
        }
        
        /// <summary>
        /// Tests that v 2 same line throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SameLine_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SameLine());
        }
        
        /// <summary>
        /// Tests that v 2 same line with offset from start x throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SameLine_WithOffsetFromStartX_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SameLine(100.0f));
        }
        
        /// <summary>
        /// Tests that v 2 same line with offset from start x and spacing throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SameLine_WithOffsetFromStartXAndSpacing_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SameLine(100.0f, 10.0f));
        }
        
        /// <summary>
        /// Tests that v 2 save ini settings to disk throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SaveIniSettingsToDisk_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SaveIniSettingsToDisk("test.ini"));
        }
        
        /// <summary>
        /// Tests that v 2 save ini settings to memory throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SaveIniSettingsToMemory_ThrowsDllNotFoundException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImGui.Native.ImGui.SaveIniSettingsToMemory());
        }
        
        /// <summary>
        /// Tests that save ini settings to memory with out ini size throws dll not found exception
        /// </summary>
        [Fact]
        public void SaveIniSettingsToMemory_WithOutIniSize_ThrowsDllNotFoundException()
        {
            uint size;
            Assert.Throws<MarshalDirectiveException>(() => ImGui.Native.ImGui.SaveIniSettingsToMemory(out size));
        }
        
        /// <summary>
        /// Tests that v 2 selectable throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_Selectable_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Selectable("label"));
        }
        
        /// <summary>
        /// Tests that v 2 selectable with selected throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_Selectable_WithSelected_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Selectable("label", true));
        }
        
        /// <summary>
        /// Tests that v 2 selectable with selected and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_Selectable_WithSelectedAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Selectable("label", true, ImGuiSelectableFlags.None));
        }
        
        /// <summary>
        /// Tests that v 2 selectable with selected flags and size throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_Selectable_WithSelectedFlagsAndSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Selectable("label", true, ImGuiSelectableFlags.None, new Vector2(100, 20)));
        }
        
        /// <summary>
        /// Tests that selectable with ref selected throws dll not found exception
        /// </summary>
        [Fact]
        public void Selectable_WithRefSelected_ThrowsDllNotFoundException()
        {
            bool selected = true;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Selectable("label", ref selected));
        }
        
        /// <summary>
        /// Tests that selectable with ref selected and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void Selectable_WithRefSelectedAndFlags_ThrowsDllNotFoundException()
        {
            bool selected = true;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Selectable("label", ref selected, ImGuiSelectableFlags.None));
        }
        
        /// <summary>
        /// Tests that selectable with ref selected flags and size throws dll not found exception
        /// </summary>
        [Fact]
        public void Selectable_WithRefSelectedFlagsAndSize_ThrowsDllNotFoundException()
        {
            bool selected = true;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Selectable("label", ref selected, ImGuiSelectableFlags.None, new Vector2(100, 20)));
        }
        
        /// <summary>
        /// Tests that v 2 separator throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_Separator_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Separator());
        }
        
        /// <summary>
        /// Tests that v 2 set allocator functions throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetAllocatorFunctions_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetAllocatorFunctions(IntPtr.Zero, IntPtr.Zero));
        }
        
        /// <summary>
        /// Tests that set allocator functions with user data throws dll not found exception
        /// </summary>
        [Fact]
        public void SetAllocatorFunctions_WithUserData_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetAllocatorFunctions(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
        }
        
        /// <summary>
        /// Tests that v 2 set clipboard text throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetClipboardText_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetClipboardText("text"));
        }
        
        /// <summary>
        /// Tests that v 2 set color edit options throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetColorEditOptions_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetColorEditOptions(ImGuiColorEditFlags.None));
        }
        
        /// <summary>
        /// Tests that v 2 set column offset throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetColumnOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetColumnOffset(0, 100.0f));
        }
        
        /// <summary>
        /// Tests that v 2 set column width throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetColumnWidth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetColumnWidth(0, 100.0f));
        }
        
        /// <summary>
        /// Tests that v 2 set current context throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetCurrentContext_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetCurrentContext(IntPtr.Zero));
        }
        
        /// <summary>
        /// Tests that v 2 set cursor pos throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetCursorPos_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetCursorPos(new Vector2(100, 100)));
        }
        
        /// <summary>
        /// Tests that v 2 set cursor pos x throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetCursorPosX_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetCursorPosX(100.0f));
        }
        
        /// <summary>
        /// Tests that v 2 set cursor pos y throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetCursorPosY_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetCursorPosY(100.0f));
        }
        
        /// <summary>
        /// Tests that v 2 set cursor screen pos throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetCursorScreenPos_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetCursorScreenPos(new Vector2(100, 100)));
        }
        
        /// <summary>
        /// Tests that v 2 set drag drop payload throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetDragDropPayload_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetDragDropPayload("type", IntPtr.Zero, 0));
        }
        
        /// <summary>
        /// Tests that v 2 set drag drop payload with cond throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetDragDropPayload_WithCond_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetDragDropPayload("type", IntPtr.Zero, 0, ImGuiCond.None));
        }
        
        /// <summary>
        /// Tests that v 2 set item allow overlap throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetItemAllowOverlap_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetItemAllowOverlap());
        }
        
        /// <summary>
        /// Tests that set item default focus throws dll not found exception
        /// </summary>
        [Fact]
        public void SetItemDefaultFocus_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetItemDefaultFocus());
        }
        
        /// <summary>
        /// Tests that v 2 set keyboard focus here throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetKeyboardFocusHere_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetKeyboardFocusHere());
        }
        
        /// <summary>
        /// Tests that set keyboard focus here with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void SetKeyboardFocusHere_WithOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetKeyboardFocusHere(0));
        }
        
        /// <summary>
        /// Tests that v 2 set mouse cursor throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetMouseCursor_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetMouseCursor(ImGuiMouseCursor.Arrow));
        }
        
        /// <summary>
        /// Tests that v 2 set next frame want capture keyboard throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetNextFrameWantCaptureKeyboard_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetNextFrameWantCaptureKeyboard(true));
        }
        
        /// <summary>
        /// Tests that v 2 set next frame want capture mouse throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetNextFrameWantCaptureMouse_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetNextFrameWantCaptureMouse(true));
        }
        
        /// <summary>
        /// Tests that v 2 set next item open throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetNextItemOpen_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetNextItemOpen(true));
        }
        
        /// <summary>
        /// Tests that v 2 set next item open with cond throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetNextItemOpen_WithCond_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetNextItemOpen(true, ImGuiCond.None));
        }
        
        /// <summary>
        /// Tests that v 2 set next item width throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetNextItemWidth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetNextItemWidth(100.0f));
        }
        
        /// <summary>
        /// Tests that v 2 set next window bg alpha throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetNextWindowBgAlpha_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetNextWindowBgAlpha(1.0f));
        }
        
        /// <summary>
        /// Tests that v 2 set next window class throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetNextWindowClass_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetNextWindowClass(new ImGuiWindowClass()));
        }
        
        /// <summary>
        /// Tests that v 2 set next window collapsed throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetNextWindowCollapsed_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetNextWindowCollapsed(true));
        }
        
        /// <summary>
        /// Tests that v 2 set next window collapsed with cond throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetNextWindowCollapsed_WithCond_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetNextWindowCollapsed(true, ImGuiCond.None));
        }
        
        /// <summary>
        /// Tests that v 2 set next window content size throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetNextWindowContentSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetNextWindowContentSize(new Vector2(100, 100)));
        }
        
        /// <summary>
        /// Tests that v 2 set next window dock id throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetNextWindowDockId_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetNextWindowDockId(1));
        }
        
        /// <summary>
        /// Tests that v 2 set next window dock id with cond throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetNextWindowDockId_WithCond_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetNextWindowDockId(1, ImGuiCond.None));
        }
        
        /// <summary>
        /// Tests that v 2 set next window focus throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetNextWindowFocus_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetNextWindowFocus());
        }
        
        /// <summary>
        /// Tests that v 2 set next window pos throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetNextWindowPos_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetNextWindowPos(new Vector2(100, 100)));
        }
        
        /// <summary>
        /// Tests that set next window pos with cond throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNextWindowPos_WithCond_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetNextWindowPos(new Vector2(100, 100), ImGuiCond.None));
        }
        
        /// <summary>
        /// Tests that v 2 set next window pos with cond and pivot throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetNextWindowPos_WithCondAndPivot_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetNextWindowPos(new Vector2(100, 100), ImGuiCond.None, new Vector2(0.5f, 0.5f)));
        }
        
        /// <summary>
        /// Tests that v 2 set next window scroll throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetNextWindowScroll_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetNextWindowScroll(new Vector2(100, 100)));
        }
        
        /// <summary>
        /// Tests that v 2 set next window size throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetNextWindowSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetNextWindowSize(new Vector2(100, 100)));
        }
        
        /// <summary>
        /// Tests that v 2 set next window size with cond throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetNextWindowSize_WithCond_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetNextWindowSize(new Vector2(100, 100), ImGuiCond.None));
        }
        
        /// <summary>
        /// Tests that v 2 set next window size constraints throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetNextWindowSizeConstraints_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetNextWindowSizeConstraints(new Vector2(100, 100), new Vector2(200, 200)));
        }
        
        /// <summary>
        /// Tests that v 2 set next window size constraints with callback throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetNextWindowSizeConstraints_WithCallback_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetNextWindowSizeConstraints(new Vector2(100, 100), new Vector2(200, 200), null));
        }
        
        /// <summary>
        /// Tests that v 2 set next window size constraints with callback and data throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_SetNextWindowSizeConstraints_WithCallbackAndData_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetNextWindowSizeConstraints(new Vector2(100, 100), new Vector2(200, 200), null, IntPtr.Zero));
        }
        
        /// <summary>
        /// Tests that set next window viewport throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNextWindowViewport_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetNextWindowViewport(1));
        }
        
        /// <summary>
        /// Tests that set scroll from pos x throws dll not found exception
        /// </summary>
        [Fact]
        public void SetScrollFromPosX_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetScrollFromPosX(100.0f));
        }
        
        /// <summary>
        /// Tests that set scroll from pos x with center x ratio throws dll not found exception
        /// </summary>
        [Fact]
        public void SetScrollFromPosX_WithCenterXRatio_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetScrollFromPosX(100.0f, 0.5f));
        }
        
        /// <summary>
        /// Tests that set scroll from pos y throws dll not found exception
        /// </summary>
        [Fact]
        public void SetScrollFromPosY_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetScrollFromPosY(100.0f));
        }
        
        /// <summary>
        /// Tests that set scroll from pos y with center y ratio throws dll not found exception
        /// </summary>
        [Fact]
        public void SetScrollFromPosY_WithCenterYRatio_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetScrollFromPosY(100.0f, 0.5f));
        }
        
        /// <summary>
        /// Tests that set scroll here x throws dll not found exception
        /// </summary>
        [Fact]
        public void SetScrollHereX_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetScrollHereX());
        }
        
        /// <summary>
        /// Tests that set scroll here x with center x ratio throws dll not found exception
        /// </summary>
        [Fact]
        public void SetScrollHereX_WithCenterXRatio_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetScrollHereX(0.5f));
        }
        
        /// <summary>
        /// Tests that set scroll here y throws dll not found exception
        /// </summary>
        [Fact]
        public void SetScrollHereY_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetScrollHereY());
        }
        
        /// <summary>
        /// Tests that set scroll here y with center y ratio throws dll not found exception
        /// </summary>
        [Fact]
        public void SetScrollHereY_WithCenterYRatio_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetScrollHereY(0.5f));
        }
        
        /// <summary>
        /// Tests that set scroll x throws dll not found exception
        /// </summary>
        [Fact]
        public void SetScrollX_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetScrollX(100.0f));
        }
        
        /// <summary>
        /// Tests that set scroll y throws dll not found exception
        /// </summary>
        [Fact]
        public void SetScrollY_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SetScrollY(100.0f));
        }
    }
}