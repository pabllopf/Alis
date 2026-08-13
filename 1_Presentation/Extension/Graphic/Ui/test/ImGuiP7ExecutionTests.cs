// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP7ExecutionTests.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Executes the native-backed wrappers of the ImGuiP7 partial class against the real
    ///     cimgui library. Each test owns a fresh context destroyed in finally, and every
    ///     window-scoped call is wrapped in a real NewFrame/Begin/End/EndFrame cycle.
    /// </summary>
    public class ImGuiP7ExecutionTests
    {
        /// <summary>
        ///     The image offset of the native GImGui context slot
        /// </summary>
        private const int GImGuiSlot = 0x4597e0;

        /// <summary>
        ///     The dyld image count
        /// </summary>
        /// <returns>The int</returns>
        [DllImport("libSystem.dylib", EntryPoint = "_dyld_image_count")]
        private static extern int DyldImageCount();

        /// <summary>
        ///     The dyld get image name
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport("libSystem.dylib", EntryPoint = "_dyld_get_image_name")]
        private static extern IntPtr DyldGetImageName(int index);

        /// <summary>
        ///     The dyld get image header
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport("libSystem.dylib", EntryPoint = "_dyld_get_image_header")]
        private static extern IntPtr DyldGetImageHeader(int index);

        /// <summary>
        ///     Begins a legacy column group so that the column setters execute against a live
        ///     column layout instead of aborting on the native IM_ASSERT.
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginColumns")]
        private static extern void BeginColumnsNative(byte[] strId, int count, int flags);

        /// <summary>
        ///     Ends a legacy column group.
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndColumns")]
        private static extern void EndColumnsNative();

        /// <summary>
        ///     Creates a raw ImGui context and binds it as the current context.
        /// </summary>
        /// <returns>The created context pointer</returns>
        private static IntPtr CreateContext()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            ImGuiNative.igSetCurrentContext(ctx);
            return ctx;
        }

        /// <summary>
        ///     Creates an ImGui context ready for a real frame: the native context slot of every
        ///     loaded cimgui image is synchronized, a display size is written into the io struct
        ///     and the font atlas is built so that igNewFrame can run without aborting.
        /// </summary>
        /// <returns>The created context pointer</returns>
        private static IntPtr CreateFramedContext()
        {
            IntPtr ctx = CreateContext();
            SyncContextSlots(ctx);
            IntPtr ioPtr = ImGuiNative.igGetIO();
            Marshal.StructureToPtr(1280.0f, IntPtr.Add(ioPtr, 8), false);
            Marshal.StructureToPtr(720.0f, IntPtr.Add(ioPtr, 12), false);
            IntPtr fontsPtr = Marshal.ReadIntPtr(ioPtr, 80);
            ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(fontsPtr, out IntPtr _, out int _, out int _, out int _);
            return ctx;
        }

        /// <summary>
        ///     Synchronizes the ImGui context pointer of every loaded cimgui image so that a frame
        ///     started through one image copy is visible to all the other copies.
        /// </summary>
        /// <param name="imgui">The imgui context</param>
        private static void SyncContextSlots(IntPtr imgui)
        {
            int count = DyldImageCount();

            for (int i = 0; i < count; i++)
            {
                string name = Marshal.PtrToStringAnsi(DyldGetImageName(i));

                if (name != null && name.Contains("cimgui"))
                {
                    IntPtr imageBase = DyldGetImageHeader(i);
                    Marshal.WriteInt64(imageBase + GImGuiSlot, imgui.ToInt64());
                }
            }
        }

        /// <summary>
        ///     Verifies the PushStyleColor, PushStyleVar and PushTextWrapPos wrappers paired with
        ///     their Pop counterparts execute inside a framed window.
        /// </summary>
        [MacOsOnly]
        public void PushAndPopStyle_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGui.NewFrame();
                ImGui.Begin("p7-style-window");
                ImGui.PushStyleColor(ImGuiCol.Text, 0xFF112233u);
                ImGui.PopStyleColor();
                ImGui.PushStyleColor(ImGuiCol.Text, new Vector4F(1, 0, 0, 1));
                ImGui.PushStyleColor(ImGuiCol.TextDisabled, new Vector4F(0, 1, 0, 1));
                ImGui.PopStyleColor(2);
                ImGui.PushStyleVar(ImGuiStyleVar.Alpha, 0.5f);
                ImGui.PopStyleVar();
                ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new Vector2F(8, 8));
                ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 4.0f);
                ImGui.PopStyleVar(2);
                ImGui.PushTextWrapPos();
                ImGui.PopTextWrapPos();
                ImGui.PushTextWrapPos(100.0f);
                ImGui.PopTextWrapPos();
                ImGui.End();
                ImGui.EndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies the PushItemWidth, PushAllowKeyboardFocus, PushButtonRepeat, PushClipRect
        ///     and the three PushId overloads paired with their Pop counterparts execute inside a
        ///     framed window.
        /// </summary>
        [MacOsOnly]
        public void PushAndPopItemState_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGui.NewFrame();
                ImGui.Begin("p7-item-window");
                ImGui.PushItemWidth(150.0f);
                ImGui.PopItemWidth();
                ImGui.PushAllowKeyboardFocus(true);
                ImGui.PopAllowKeyboardFocus();
                ImGui.PushButtonRepeat(true);
                ImGui.PopButtonRepeat();
                ImGui.PushClipRect(new Vector2F(0, 0), new Vector2F(200, 200), true);
                ImGui.PopClipRect();
                ImGui.PushId("p7-string-id");
                ImGui.PopId();
                ImGui.PushId(new IntPtr(0x1234));
                ImGui.PopId();
                ImGui.PushId(42);
                ImGui.PopId();
                ImGui.End();
                ImGui.EndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies PushFont executes with the font resolved from the live context and pairs
        ///     with PopFont inside a framed window.
        /// </summary>
        [MacOsOnly]
        public void PushFont_And_PopFont_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGui.NewFrame();
                ImGui.Begin("p7-font-window");
                ImFontPtr font = ImGui.GetFont();
                ImGui.PushFont(font);
                ImGui.PopFont();
                ImGui.End();
                ImGui.EndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every SetNextWindow* wrapper executes before a window begins, followed by a
        ///     real Begin/End/EndFrame cycle that consumes the stacked next-window data.
        /// </summary>
        [MacOsOnly]
        public void SetNextWindowState_BeforeBegin_Execute()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGui.NewFrame();
                ImGui.SetNextFrameWantCaptureKeyboard(true);
                ImGui.SetNextFrameWantCaptureMouse(true);
                ImGui.SetNextWindowPos(new Vector2F(10, 10));
                ImGui.SetNextWindowPos(new Vector2F(10, 10), ImGuiCond.Always);
                ImGui.SetNextWindowPos(new Vector2F(10, 10), ImGuiCond.Always, new Vector2F(0.5f, 0.5f));
                ImGui.SetNextWindowSize(new Vector2F(300, 200));
                ImGui.SetNextWindowSize(new Vector2F(300, 200), ImGuiCond.Always);
                ImGui.SetNextWindowContentSize(new Vector2F(200, 100));
                ImGui.SetNextWindowCollapsed(false);
                ImGui.SetNextWindowCollapsed(false, ImGuiCond.Always);
                ImGui.SetNextWindowFocus();
                ImGui.SetNextWindowBgAlpha(0.5f);
                ImGui.SetNextWindowDockId(0u);
                ImGui.SetNextWindowDockId(0u, ImGuiCond.Always);
                ImGui.SetNextWindowSizeConstraints(new Vector2F(100, 50), new Vector2F(400, 300));
                ImGui.SetNextWindowSizeConstraints(new Vector2F(100, 50), new Vector2F(400, 300), null);
                ImGui.SetNextWindowSizeConstraints(new Vector2F(100, 50), new Vector2F(400, 300), null, IntPtr.Zero);
                ImGui.SetNextWindowScroll(new Vector2F(0, 0));
                ImGui.SetNextWindowClass(new ImGuiWindowClass());
                ImGui.SetNextWindowViewport(0u);
                ImGui.Begin("p7-setnext-window");
                ImGui.End();
                ImGui.EndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every item wrapper of the partial executes inside a framed window: SameLine,
        ///     NewLine, Separator, Selectable, ProgressBar, RadioButton, MenuItem and the SetItem,
        ///     SetCursor, SetScroll and SetTooltip family.
        /// </summary>
        [MacOsOnly]
        public void Items_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGui.NewFrame();
                ImGui.Begin("p7-items-window");
                ImGui.SameLine();
                ImGui.SameLine(10.0f);
                ImGui.SameLine(10.0f, 2.0f);
                ImGui.NewLine();
                ImGui.Separator();
                _ = ImGui.Selectable("p7-selectable-1");
                _ = ImGui.Selectable("p7-selectable-2", true);
                _ = ImGui.Selectable("p7-selectable-3", true, ImGuiSelectableFlags.None);
                _ = ImGui.Selectable("p7-selectable-4", true, ImGuiSelectableFlags.None, new Vector2F(100, 20));
                ImGui.ProgressBar(0.5f);
                ImGui.ProgressBar(0.5f, new Vector2F(100, 10));
                ImGui.ProgressBar(0.5f, new Vector2F(100, 10), "p7-overlay");
                _ = ImGui.RadioButton("p7-radio-1", true);
                int radioValue = 0;
                _ = ImGui.RadioButton("p7-radio-2", ref radioValue, 1);
                bool menuSelected = false;
                _ = ImGui.MenuItem("p7-menu-item", "Ctrl+S", ref menuSelected, true);
                ImGui.SetTooltip("p7-tooltip");
                ImGui.SetTabItemClosed("p7-tab");
                ImGui.SetItemAllowOverlap();
                ImGui.SetItemDefaultFocus();
                ImGui.SetKeyboardFocusHere();
                ImGui.SetKeyboardFocusHere(-1);
                ImGui.SetNextItemOpen(true);
                ImGui.SetNextItemOpen(true, ImGuiCond.Always);
                ImGui.SetNextItemWidth(120.0f);
                ImGui.SetCursorPos(new Vector2F(5, 5));
                ImGui.SetCursorPosX(5.0f);
                ImGui.SetCursorPosY(5.0f);
                ImGui.SetCursorScreenPos(new Vector2F(5, 5));
                ImGui.SetClipboardText("p7-clipboard");
                ImGui.SetScrollX(0.0f);
                ImGui.SetScrollY(0.0f);
                ImGui.SetScrollFromPosX(0.0f);
                ImGui.SetScrollFromPosX(0.0f, 0.5f);
                ImGui.SetScrollFromPosY(0.0f);
                ImGui.SetScrollFromPosY(0.0f, 0.5f);
                ImGui.SetScrollHereX();
                ImGui.SetScrollHereX(0.5f);
                ImGui.SetScrollHereY();
                ImGui.SetScrollHereY(0.5f);
                ImGui.End();
                ImGui.EndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every SetWindow* wrapper executes against the active window inside a framed
        ///     window, including the named overloads that resolve the window by name.
        /// </summary>
        [MacOsOnly]
        public void WindowSetters_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGui.NewFrame();
                ImGui.Begin("p7-setter-window");
                ImGui.SetWindowPos(new Vector2F(10, 10));
                ImGui.SetWindowPos(new Vector2F(10, 10), ImGuiCond.Always);
                ImGui.SetWindowPos("p7-setter-window", new Vector2F(10, 10));
                ImGui.SetWindowPos("p7-setter-window", new Vector2F(10, 10), ImGuiCond.Always);
                ImGui.SetWindowSize(new Vector2F(300, 200));
                ImGui.SetWindowSize(new Vector2F(300, 200), ImGuiCond.Always);
                ImGui.SetWindowSize("p7-setter-window", new Vector2F(300, 200));
                ImGui.SetWindowSize("p7-setter-window", new Vector2F(300, 200), ImGuiCond.Always);
                ImGui.SetWindowCollapsed(false);
                ImGui.SetWindowCollapsed(false, ImGuiCond.Always);
                ImGui.SetWindowCollapsed("p7-setter-window", false);
                ImGui.SetWindowCollapsed("p7-setter-window", false, ImGuiCond.Always);
                ImGui.SetWindowFocus();
                ImGui.SetWindowFocus("p7-setter-window");
                ImGui.SetWindowFontScale(1.0f);
                ImGui.End();
                ImGui.EndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every OpenPopup and OpenPopupOnItemClick overload executes inside a framed
        ///     window, together with NextColumn.
        /// </summary>
        [MacOsOnly]
        public void OpenPopup_And_OpenPopupOnItemClick_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGui.NewFrame();
                ImGui.Begin("p7-popup-window");
                ImGui.OpenPopup("p7-popup");
                ImGui.OpenPopup("p7-popup", ImGuiPopupFlags.MouseButtonRight);
                ImGui.OpenPopup(0x12345678u);
                ImGui.OpenPopup(0x12345678u, ImGuiPopupFlags.MouseButtonRight);
                ImGui.OpenPopupOnItemClick();
                ImGui.OpenPopupOnItemClick("p7-item");
                ImGui.OpenPopupOnItemClick("p7-item", ImGuiPopupFlags.MouseButtonRight);
                ImGui.NextColumn();
                ImGui.End();
                ImGui.EndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies SetColumnOffset, SetColumnWidth and NextColumn execute inside a real legacy
        ///     column group opened with the native igBeginColumns entry point.
        /// </summary>
        [MacOsOnly]
        public void Columns_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGui.NewFrame();
                ImGui.Begin("p7-columns-window");
                BeginColumnsNative(Encoding.UTF8.GetBytes("p7-columns"), 2, 0);
                ImGui.SetColumnOffset(0, 10.0f);
                ImGui.SetColumnWidth(0, 50.0f);
                ImGui.NextColumn();
                EndColumnsNative();
                ImGui.End();
                ImGui.EndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies Render, every RenderPlatformWindowsDefault overload, ResetMouseDragDelta,
        ///     SetMouseCursor, SetColorEditOptions and the ini helpers execute against a framed
        ///     context. The memory helpers throw MarshalDirectiveException because the native
        ///     const char return value cannot be marshalled to a byte array.
        /// </summary>
        [MacOsOnly]
        public void Render_And_Misc_Execute()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGui.NewFrame();
                ImGui.Begin("p7-render-window");
                ImGui.End();
                ImGui.Render();
                ImGui.RenderPlatformWindowsDefault();
                ImGui.RenderPlatformWindowsDefault(IntPtr.Zero);
                ImGui.RenderPlatformWindowsDefault(IntPtr.Zero, IntPtr.Zero);
                ImGui.ResetMouseDragDelta();
                ImGui.ResetMouseDragDelta(ImGuiMouseButton.Left);
                ImGui.SetMouseCursor(ImGuiMouseCursor.Arrow);
                ImGui.SetColorEditOptions((ImGuiColorEditFlags) 0);
                ImGui.SaveIniSettingsToDisk("p7.ini");
                Assert.Throws<MarshalDirectiveException>(() => ImGui.SaveIniSettingsToMemory());
                Assert.Throws<MarshalDirectiveException>(() => ImGui.SaveIniSettingsToMemory(out _));
                ImGui.EndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies SetStateStorage and SetCurrentContext execute against a live context.
        /// </summary>
        [MacOsOnly]
        public void StateStorage_And_CurrentContext_Execute()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGui.NewFrame();
                ImGui.Begin("p7-storage-window");
                ImGui.SetStateStorage(new ImGuiStorage());
                ImGui.End();
                ImGui.EndFrame();
                ImGui.SetCurrentContext(ctx);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

    }
}
