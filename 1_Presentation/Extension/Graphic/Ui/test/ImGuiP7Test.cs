// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP7Test.cs
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
using System.Linq;
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Provides API-surface coverage for methods contributed by ImGuiP7 wrappers.
    /// </summary>
    public class ImGuiP7Test
    {
        /// <summary>
        ///     Verifies popup APIs expose expected overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PopupApis_ShouldExposeOverloads()
        {
            MethodInfo[] openPopup = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "OpenPopup").ToArray();
            MethodInfo[] openPopupOnItemClick = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "OpenPopupOnItemClick").ToArray();

            Assert.True(openPopup.Length >= 4);
            Assert.True(openPopupOnItemClick.Length >= 3);
        }

        /// <summary>
        ///     Verifies representative frame navigation methods exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void FrameNavigationMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("NewFrame", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("NextColumn", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies NewLine method exists.
        /// </summary>
        [RequireCImguiSystemFact]
        public void NewLine_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("NewLine", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies MenuItem overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void MenuItem_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "MenuItem").ToArray();
            Assert.True(methods.Length >= 1);
        }

        /// <summary>
        ///     Verifies PlotHistogram overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotHistogram_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "PlotHistogram").ToArray();
            Assert.True(methods.Length >= 7);
        }

        /// <summary>
        ///     Verifies PlotLines overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotLines_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "PlotLines").ToArray();
            Assert.True(methods.Length >= 7);
        }

        /// <summary>
        ///     Verifies Pop* methods exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PopMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("PopAllowKeyboardFocus", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("PopButtonRepeat", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("PopClipRect", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("PopFont", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("PopId", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("PopItemWidth", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("PopTextWrapPos", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies PopStyleColor and PopStyleVar overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PopStyleMethods_ShouldExposeOverloads()
        {
            MethodInfo[] popStyleColor = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "PopStyleColor").ToArray();
            MethodInfo[] popStyleVar = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "PopStyleVar").ToArray();

            Assert.True(popStyleColor.Length >= 2);
            Assert.True(popStyleVar.Length >= 2);
        }

        /// <summary>
        ///     Verifies ProgressBar overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ProgressBar_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "ProgressBar").ToArray();
            Assert.True(methods.Length >= 3);
        }

        /// <summary>
        ///     Verifies Push* methods exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PushMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("PushAllowKeyboardFocus", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("PushButtonRepeat", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("PushClipRect", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("PushFont", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("PushItemWidth", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies PushId overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PushId_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "PushId").ToArray();
            Assert.True(methods.Length >= 3);
        }

        /// <summary>
        ///     Verifies PushStyleColor and PushStyleVar overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PushStyleMethods_ShouldExposeOverloads()
        {
            MethodInfo[] pushStyleColor = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "PushStyleColor").ToArray();
            MethodInfo[] pushStyleVar = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "PushStyleVar").ToArray();

            Assert.True(pushStyleColor.Length >= 2);
            Assert.True(pushStyleVar.Length >= 2);
        }

        /// <summary>
        ///     Verifies PushTextWrapPos overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PushTextWrapPos_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "PushTextWrapPos").ToArray();
            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies RadioButton overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void RadioButton_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "RadioButton").ToArray();
            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies Render methods exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void RenderMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("Render", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies RenderPlatformWindowsDefault overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void RenderPlatformWindowsDefault_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "RenderPlatformWindowsDefault").ToArray();
            Assert.True(methods.Length >= 3);
        }

        /// <summary>
        ///     Verifies ResetMouseDragDelta overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ResetMouseDragDelta_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "ResetMouseDragDelta").ToArray();
            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies SameLine overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SameLine_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SameLine").ToArray();
            Assert.True(methods.Length >= 3);
        }

        /// <summary>
        ///     Verifies SaveIniSettings methods exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SaveIniSettingsMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("SaveIniSettingsToDisk", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies SaveIniSettingsToMemory overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SaveIniSettingsToMemory_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SaveIniSettingsToMemory").ToArray();
            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies Selectable overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Selectable_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "Selectable").ToArray();
            Assert.True(methods.Length >= 7);
        }

        /// <summary>
        ///     Verifies Separator method exists.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Separator_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("Separator", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies SetAllocatorFunctions overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetAllocatorFunctions_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SetAllocatorFunctions").ToArray();
            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies SetClipboardText method exists.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetClipboardText_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("SetClipboardText", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies SetColorEditOptions method exists.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetColorEditOptions_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("SetColorEditOptions", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies SetColumn methods exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetColumnMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("SetColumnOffset", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("SetColumnWidth", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies SetCurrentContext method exists.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetCurrentContext_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("SetCurrentContext", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies SetCursorPos methods exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetCursorPosMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("SetCursorPos", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("SetCursorPosX", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("SetCursorPosY", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("SetCursorScreenPos", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies SetDragDropPayload overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetDragDropPayload_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SetDragDropPayload").ToArray();
            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies SetItem methods exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetItemMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("SetItemAllowOverlap", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("SetItemDefaultFocus", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies SetKeyboardFocusHere overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetKeyboardFocusHere_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SetKeyboardFocusHere").ToArray();
            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies SetMouseCursor method exists.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetMouseCursor_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("SetMouseCursor", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies SetNextFrameWantCapture methods exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNextFrameWantCaptureMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("SetNextFrameWantCaptureKeyboard", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("SetNextFrameWantCaptureMouse", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies SetNextItem overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNextItemMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("SetNextItemWidth", BindingFlags.Public | BindingFlags.Static));
            MethodInfo[] open = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SetNextItemOpen").ToArray();
            Assert.True(open.Length >= 2);
        }

        /// <summary>
        ///     Verifies SetNextWindow methods exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNextWindowMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("SetNextWindowBgAlpha", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("SetNextWindowClass", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("SetNextWindowContentSize", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("SetNextWindowFocus", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("SetNextWindowScroll", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("SetNextWindowViewport", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies SetNextWindowCollapsed and SetNextWindowDockId overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNextWindowCollapsedDock_ShouldExposeOverloads()
        {
            MethodInfo[] collapsed = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SetNextWindowCollapsed").ToArray();
            MethodInfo[] dockId = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SetNextWindowDockId").ToArray();
            MethodInfo[] size = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SetNextWindowSize").ToArray();
            MethodInfo[] constraints = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SetNextWindowSizeConstraints").ToArray();
            MethodInfo[] pos = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SetNextWindowPos").ToArray();

            Assert.True(collapsed.Length >= 2);
            Assert.True(dockId.Length >= 2);
            Assert.True(size.Length >= 2);
            Assert.True(constraints.Length >= 3);
            Assert.True(pos.Length >= 3);
        }

        /// <summary>
        ///     Verifies SetScrollFromPos overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetScrollFromPosMethods_ShouldExposeOverloads()
        {
            MethodInfo[] fromPosX = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SetScrollFromPosX").ToArray();
            MethodInfo[] fromPosY = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SetScrollFromPosY").ToArray();

            Assert.True(fromPosX.Length >= 2);
            Assert.True(fromPosY.Length >= 2);
        }

        /// <summary>
        ///     Verifies SetScrollHere overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetScrollHereMethods_ShouldExposeOverloads()
        {
            MethodInfo[] hereX = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SetScrollHereX").ToArray();
            MethodInfo[] hereY = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SetScrollHereY").ToArray();

            Assert.True(hereX.Length >= 2);
            Assert.True(hereY.Length >= 2);
        }

        /// <summary>
        ///     Verifies SetScrollX and SetScrollY methods exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetScrollXYMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("SetScrollX", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("SetScrollY", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies SetStateStorage method exists.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetStateStorage_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("SetStateStorage", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies SetTabItemClosed method exists.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetTabItemClosed_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("SetTabItemClosed", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies SetTooltip method exists.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetTooltip_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("SetTooltip", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies SetWindow methods exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetWindowMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("SetWindowFontScale", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies SetWindowCollapsed overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetWindowCollapsed_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SetWindowCollapsed").ToArray();
            Assert.True(methods.Length >= 4);
        }

        /// <summary>
        ///     Verifies SetWindowFocus overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetWindowFocus_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SetWindowFocus").ToArray();
            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies SetWindowPos overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetWindowPos_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SetWindowPos").ToArray();
            Assert.True(methods.Length >= 4);
        }

        /// <summary>
        ///     Verifies SetWindowSize overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetWindowSize_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "SetWindowSize").ToArray();
            Assert.True(methods.Length >= 4);
        }

        /// <summary>
        ///     Verifies PlotHistogram ref float overload with null label throws
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotHistogram_RefFloat_WithNullLabel_ShouldThrowArgumentNullException()
        {
            float values = 1;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.PlotHistogram(null, ref values, 1)));
        }

        /// <summary>
        ///     Verifies PlotHistogram ref float overload with offset and null label throws
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotHistogram_RefFloat_WithOffset_WithNullLabel_ShouldThrowArgumentNullException()
        {
            float values = 1;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.PlotHistogram(null, ref values, 1, 0)));
        }

        /// <summary>
        ///     Verifies PlotHistogram ref float overload with overlay and null label throws
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotHistogram_RefFloat_WithOverlay_WithNullLabel_ShouldThrowArgumentNullException()
        {
            float values = 1;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.PlotHistogram(null, ref values, 1, 0, "overlay")));
        }

        /// <summary>
        ///     Verifies PlotHistogram ref float overload with scale min and null label throws
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotHistogram_RefFloat_WithScaleMin_WithNullLabel_ShouldThrowArgumentNullException()
        {
            float values = 1;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.PlotHistogram(null, ref values, 1, 0, "overlay", 0.0f)));
        }

        /// <summary>
        ///     Verifies PlotHistogram ref float overload with scale max and null label throws
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotHistogram_RefFloat_WithScaleMax_WithNullLabel_ShouldThrowArgumentNullException()
        {
            float values = 1;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.PlotHistogram(null, ref values, 1, 0, "overlay", 0.0f, 1.0f)));
        }

        /// <summary>
        ///     Verifies PlotHistogram ref float overload with graph size and null label throws
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotHistogram_RefFloat_WithGraphSize_WithNullLabel_ShouldThrowArgumentNullException()
        {
            float values = 1;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.PlotHistogram(null, ref values, 1, 0, "overlay", 0.0f, 1.0f, new Vector2F())));
        }

        /// <summary>
        ///     Verifies PlotHistogram ref float overload with stride and null label throws
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotHistogram_RefFloat_WithStride_WithNullLabel_ShouldThrowArgumentNullException()
        {
            float values = 1;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.PlotHistogram(null, ref values, 1, 0, "overlay", 0.0f, 1.0f, new Vector2F(), sizeof(float))));
        }

        /// <summary>
        ///     Verifies PlotLines ref float overload with null label throws
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotLines_RefFloat_WithNullLabel_ShouldThrowArgumentNullException()
        {
            float values = 1;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.PlotLines(null, ref values, 1)));
        }

        /// <summary>
        ///     Verifies PlotLines ref float overload with offset and null label throws
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotLines_RefFloat_WithOffset_WithNullLabel_ShouldThrowArgumentNullException()
        {
            float values = 1;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.PlotLines(null, ref values, 1, 0)));
        }

        /// <summary>
        ///     Verifies PlotLines ref float overload with overlay and null label throws
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotLines_RefFloat_WithOverlay_WithNullLabel_ShouldThrowArgumentNullException()
        {
            float values = 1;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.PlotLines(null, ref values, 1, 0, "overlay")));
        }

        /// <summary>
        ///     Verifies PlotLines ref float overload with scale min and null label throws
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotLines_RefFloat_WithScaleMin_WithNullLabel_ShouldThrowArgumentNullException()
        {
            float values = 1;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.PlotLines(null, ref values, 1, 0, "overlay", 0.0f)));
        }

        /// <summary>
        ///     Verifies PlotLines ref float overload with scale max and null label throws
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotLines_RefFloat_WithScaleMax_WithNullLabel_ShouldThrowArgumentNullException()
        {
            float values = 1;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.PlotLines(null, ref values, 1, 0, "overlay", 0.0f, 1.0f)));
        }

        /// <summary>
        ///     Verifies PlotLines ref float overload with graph size and null label throws
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotLines_RefFloat_WithGraphSize_WithNullLabel_ShouldThrowArgumentNullException()
        {
            float values = 1;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.PlotLines(null, ref values, 1, 0, "overlay", 0.0f, 1.0f, new Vector2F())));
        }

        /// <summary>
        ///     Verifies PlotLines ref float overload with stride and null label throws
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotLines_RefFloat_WithStride_WithNullLabel_ShouldThrowArgumentNullException()
        {
            float values = 1;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.PlotLines(null, ref values, 1, 0, "overlay", 0.0f, 1.0f, new Vector2F(), sizeof(float))));
        }

        /// <summary>
        ///     Verifies Selectable ref bool overload with null label throws
        /// </summary>
        [RequireCImguiSystemFact]
        public void Selectable_RefBool_WithNullLabel_ShouldThrowArgumentNullException()
        {
            bool selected = false;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.Selectable(null, ref selected)));
        }

        /// <summary>
        ///     Verifies Selectable ref bool overload with flags and null label throws
        /// </summary>
        [RequireCImguiSystemFact]
        public void Selectable_RefBool_WithFlags_WithNullLabel_ShouldThrowArgumentNullException()
        {
            bool selected = false;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.Selectable(null, ref selected, ImGuiSelectableFlags.None)));
        }

        /// <summary>
        ///     Verifies Selectable ref bool overload with size and null label throws
        /// </summary>
        [RequireCImguiSystemFact]
        public void Selectable_RefBool_WithSize_WithNullLabel_ShouldThrowArgumentNullException()
        {
            bool selected = false;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.Selectable(null, ref selected, ImGuiSelectableFlags.None, new Vector2F())));
        }

        /// <summary>
        ///     Verifies SetDragDropPayload with null type throws
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetDragDropPayload_WithNullType_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.SetDragDropPayload(null, IntPtr.Zero, 0)));
        }

        /// <summary>
        ///     Verifies SetDragDropPayload with condition and null type throws
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetDragDropPayload_WithCondition_WithNullType_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.SetDragDropPayload(null, IntPtr.Zero, 0, ImGuiCond.None)));
        }
    }
}
