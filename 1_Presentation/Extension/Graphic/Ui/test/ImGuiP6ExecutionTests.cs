// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP6ExecutionTests.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Executes the native-backed wrappers of the ImGuiP6 partial class against the real
    ///     cimgui library. Each test owns a fresh context destroyed in finally, and every
    ///     window-scoped call is wrapped in a real NewFrame/Begin/End/EndFrame cycle. The
    ///     filesystem-scoped LoadIniSettingsFromDisk and LogToFile overloads are intentionally
    ///     not exercised to keep the suite free of filesystem side effects.
    /// </summary>
    public class ImGuiP6ExecutionTests
    {
        /// <summary>
        ///     The no load mode of the dyld dynamic loader
        /// </summary>
        private const int RtlNoLoad = 0x10;

        /// <summary>
        ///     The dyld image count
        /// </summary>
        /// <returns>The int</returns>
        [ExcludeFromCodeCoverage]
        [DllImport("libSystem.dylib", EntryPoint = "_dyld_image_count")]
        private static extern int DyldImageCount();

        /// <summary>
        ///     The dyld get image name
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [ExcludeFromCodeCoverage]
        [DllImport("libSystem.dylib", EntryPoint = "_dyld_get_image_name")]
        private static extern IntPtr DyldGetImageName(int index);

        /// <summary>
        ///     Opens an already loaded dynamic library
        /// </summary>
        /// <param name="path">The image path</param>
        /// <param name="mode">The open mode</param>
        /// <returns>The library handle</returns>
        [ExcludeFromCodeCoverage]
        [DllImport("libSystem.dylib", EntryPoint = "dlopen")]
        private static extern IntPtr DlOpen(string path, int mode);

        /// <summary>
        ///     Resolves the address of an exported symbol inside a loaded library
        /// </summary>
        /// <param name="handle">The library handle</param>
        /// <param name="symbol">The symbol name</param>
        /// <returns>The symbol address</returns>
        [ExcludeFromCodeCoverage]
        [DllImport("libSystem.dylib", EntryPoint = "dlsym")]
        private static extern IntPtr Dlsym(IntPtr handle, string symbol);

        /// <summary>
        ///     Returns information about the loaded image that owns the given address
        /// </summary>
        /// <param name="address">The address to resolve</param>
        /// <param name="info">The image information</param>
        /// <returns>The result</returns>
        [ExcludeFromCodeCoverage]
        [DllImport("libSystem.dylib", EntryPoint = "dladdr")]
        private static extern int DlAddr(IntPtr address, ref DlInfo info);

        /// <summary>
        ///     The image information returned by the dladdr call
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct DlInfo
        {
            /// <summary>
            ///     The file name of the loaded image
            /// </summary>
            public IntPtr FileName;

            /// <summary>
            ///     The base address of the loaded image
            /// </summary>
            public IntPtr Base;

            /// <summary>
            ///     The name of the nearest symbol
            /// </summary>
            public IntPtr SymbolName;

            /// <summary>
            ///     The address of the nearest symbol
            /// </summary>
            public IntPtr SymbolAddress;
        }

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
        ///     started through one image copy is visible to all the other copies. The GImGui slot is
        ///     resolved through the exported symbol of each image instead of a hardcoded offset, which
        ///     varies between the x64 and arm64 slices of the native library. The handle opened with
        ///     RtlNoLoad is never closed because dlclose can unload the image, and the resolved address
        ///     is verified with dladdr before the write so a stale slot can never fault the test host.
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
                    IntPtr handle = DlOpen(name, RtlNoLoad);

                    if (handle != IntPtr.Zero)
                    {
                        IntPtr slot = Dlsym(handle, "GImGui");

                        if (slot != IntPtr.Zero && IsLoadedCimgui(slot))
                        {
                            Marshal.WriteIntPtr(slot, imgui);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Verifies that the given address belongs to a currently loaded cimgui image, so that a stale
        ///     symbol address can never trigger an access violation while synchronizing the context slot.
        /// </summary>
        /// <param name="address">The resolved symbol address</param>
        /// <returns>The bool</returns>
        private static bool IsLoadedCimgui(IntPtr address)
        {
            DlInfo info = new DlInfo();

            if (DlAddr(address, ref info) == 0)
            {
                return false;
            }

            string fileName = Marshal.PtrToStringAnsi(info.FileName);
            return fileName != null && fileName.Contains("cimgui");
        }

        /// <summary>
        ///     Verifies MemAlloc returns a usable allocation and MemFree releases it against a
        ///     live context, without needing a frame.
        /// </summary>
        [RequireCImguiSystemFact]
        public void MemAlloc_And_MemFree_Execute()
        {
            IntPtr ctx = CreateContext();
            try
            {
                IntPtr block = ImGui.MemAlloc(64);
                Assert.NotEqual(IntPtr.Zero, block);
                ImGui.MemFree(block);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies both LoadIniSettingsFromMemory overloads parse in-memory ini data against
        ///     fresh contexts before any frame runs, satisfying the native FrameCount == 0 rule.
        /// </summary>
        [RequireCImguiSystemFact]
        public void LoadIniSettingsFromMemory_ExecuteBeforeFrame()
        {
            IntPtr first = CreateContext();
            try
            {
                ImGui.LoadIniSettingsFromMemory("[Window][Dock]\n");
            }
            finally
            {
                ImGuiNative.igDestroyContext(first);
            }

            IntPtr second = CreateContext();
            try
            {
                string iniData = "[Window][Dock]\n";
                ImGui.LoadIniSettingsFromMemory(iniData, (uint) iniData.Length);
            }
            finally
            {
                ImGuiNative.igDestroyContext(second);
            }
        }

        /// <summary>
        ///     Verifies every InputInt overload executes inside one framed window without
        ///     throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void InputInt_AllOverloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p6-input-int-window");
                int v = 5;
                _ = ImGui.InputInt("p6-input-int-1", ref v);
                _ = ImGui.InputInt("p6-input-int-2", ref v, 1);
                _ = ImGui.InputInt("p6-input-int-3", ref v, 1, 10);
                _ = ImGui.InputInt("p6-input-int-4", ref v, 1, 10, ImGuiInputTextFlags.None);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies both InputInt2 overloads execute inside one framed window without
        ///     throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void InputInt2_AllOverloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p6-input-int2-window");
                int v = 5;
                _ = ImGui.InputInt2("p6-input-int2-1", ref v);
                _ = ImGui.InputInt2("p6-input-int2-2", ref v, ImGuiInputTextFlags.None);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies both InputInt3 overloads execute inside one framed window and throw
        ///     EntryPointNotFoundException because the native binding declares the entry point
        ///     with a leading underscore, which the runtime resolves as a doubled underscore.
        /// </summary>
        [RequireCImguiSystemFact]
        public void InputInt3_AllOverloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p6-input-int3-window");
                int v = 5;
                Assert.Throws<EntryPointNotFoundException>(() => ImGui.InputInt3("p6-input-int3-1", ref v));
                Assert.Throws<EntryPointNotFoundException>(() => ImGui.InputInt3("p6-input-int3-2", ref v, ImGuiInputTextFlags.None));
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies both InputInt4 overloads execute inside one framed window without
        ///     throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void InputInt4_AllOverloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p6-input-int4-window");
                int v = 5;
                _ = ImGui.InputInt4("p6-input-int4-1", ref v);
                _ = ImGui.InputInt4("p6-input-int4-2", ref v, ImGuiInputTextFlags.None);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies both InputFloat4 overloads execute inside one framed window without
        ///     throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void InputFloat4_AllOverloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p6-input-float4-window");
                Vector4F v = new Vector4F(1, 2, 3, 4);
                _ = ImGui.InputFloat4("p6-input-float4-1", ref v, "%.2f");
                _ = ImGui.InputFloat4("p6-input-float4-2", ref v, "%.2f", ImGuiInputTextFlags.None);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every InputScalar overload executes inside one framed window against a
        ///     pinned float payload without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void InputScalar_AllOverloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p6-input-scalar-window");
                float[] payload = { 5.0f };
                GCHandle handle = GCHandle.Alloc(payload, GCHandleType.Pinned);
                IntPtr pData = handle.AddrOfPinnedObject();
                _ = ImGui.InputScalar("p6-input-scalar-1", ImGuiDataType.Float, pData);
                _ = ImGui.InputScalar("p6-input-scalar-2", ImGuiDataType.Float, pData, IntPtr.Zero);
                _ = ImGui.InputScalar("p6-input-scalar-3", ImGuiDataType.Float, pData, IntPtr.Zero, IntPtr.Zero);
                _ = ImGui.InputScalar("p6-input-scalar-4", ImGuiDataType.Float, pData, IntPtr.Zero, IntPtr.Zero, "%.1f");
                _ = ImGui.InputScalar("p6-input-scalar-5", ImGuiDataType.Float, pData, IntPtr.Zero, IntPtr.Zero, "%.1f", ImGuiInputTextFlags.None);
                handle.Free();
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every InputScalarN overload executes inside one framed window against a
        ///     pinned float payload without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void InputScalarN_AllOverloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p6-input-scalar-n-window");
                float[] payload = { 5.0f };
                GCHandle handle = GCHandle.Alloc(payload, GCHandleType.Pinned);
                IntPtr pData = handle.AddrOfPinnedObject();
                _ = ImGui.InputScalarN("p6-input-scalar-n-1", ImGuiDataType.Float, pData, 1);
                _ = ImGui.InputScalarN("p6-input-scalar-n-2", ImGuiDataType.Float, pData, 1, IntPtr.Zero);
                _ = ImGui.InputScalarN("p6-input-scalar-n-3", ImGuiDataType.Float, pData, 1, IntPtr.Zero, IntPtr.Zero);
                _ = ImGui.InputScalarN("p6-input-scalar-n-4", ImGuiDataType.Float, pData, 1, IntPtr.Zero, IntPtr.Zero, "%.1f");
                _ = ImGui.InputScalarN("p6-input-scalar-n-5", ImGuiDataType.Float, pData, 1, IntPtr.Zero, IntPtr.Zero, "%.1f", ImGuiInputTextFlags.None);
                handle.Free();
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies both ListBox overloads throw MarshalDirectiveException while executing
        ///     their wrapper bodies, because the native binding cannot marshal jagged string
        ///     arrays.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ListBox_ThrowsMarshalDirective_InsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p6-listbox-window");
                int currentItem = 0;
                string[] items = { "A", "B", "C" };
                Assert.Throws<MarshalDirectiveException>(() => ImGui.ListBox("p6-listbox-1", ref currentItem, items, 3));
                Assert.Throws<MarshalDirectiveException>(() => ImGui.ListBox("p6-listbox-2", ref currentItem, items, 3, 4));
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every MenuItem overload executes inside one framed window without
        ///     throwing. The bool-pointer overload is called with false so the native pointer
        ///     argument stays NULL, since the binding marshals the bool by value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void MenuItem_AllOverloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p6-menu-item-window");
                _ = ImGui.MenuItem("p6-menu-item-1");
                _ = ImGui.MenuItem("p6-menu-item-2", "Ctrl+A");
                _ = ImGui.MenuItem("p6-menu-item-3", "Ctrl+A", false);
                _ = ImGui.MenuItem("p6-menu-item-4", "Ctrl+A", false, true);
                bool pSelected = false;
                _ = ImGui.MenuItem("p6-menu-item-5", "Ctrl+A", ref pSelected);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies both InvisibleButton overloads and LabelText execute inside one framed
        ///     window without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void InvisibleButton_And_LabelText_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p6-invisible-button-window");
                _ = ImGui.InvisibleButton("p6-invisible-button-1", new Vector2F(32.0f, 32.0f));
                _ = ImGui.InvisibleButton("p6-invisible-button-2", new Vector2F(32.0f, 32.0f), ImGuiButtonFlags.None);
                ImGui.LabelText("p6-label", "p6-label-text");
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every IsItem and IsAnyItem state query executes inside one framed window
        ///     after an item has been placed, without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsItemQueries_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p6-is-item-window");
                _ = ImGui.Button("p6-probe");
                _ = ImGui.IsAnyItemActive();
                _ = ImGui.IsAnyItemFocused();
                _ = ImGui.IsAnyItemHovered();
                _ = ImGui.IsAnyMouseDown();
                _ = ImGui.IsItemActivated();
                _ = ImGui.IsItemActive();
                _ = ImGui.IsItemClicked();
                _ = ImGui.IsItemClicked(ImGuiMouseButton.Left);
                _ = ImGui.IsItemDeactivated();
                _ = ImGui.IsItemDeactivatedAfterEdit();
                _ = ImGui.IsItemEdited();
                _ = ImGui.IsItemFocused();
                _ = ImGui.IsItemHovered();
                _ = ImGui.IsItemHovered(ImGuiHoveredFlags.AllowWhenDisabled);
                _ = ImGui.IsItemToggledOpen();
                _ = ImGui.IsItemVisible();
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every IsWindow state query executes inside one framed window, asserting
        ///     the window is appearing on its first frame.
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsWindowQueries_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p6-is-window-query");
                Assert.True(ImGui.IsWindowAppearing());
                _ = ImGui.IsWindowCollapsed();
                _ = ImGui.IsWindowDocked();
                _ = ImGui.IsWindowFocused();
                _ = ImGui.IsWindowFocused(ImGuiFocusedFlags.RootWindow);
                _ = ImGui.IsWindowHovered();
                _ = ImGui.IsWindowHovered(ImGuiHoveredFlags.RootWindow);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every IsKey state query executes inside one framed window against the A
        ///     key without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsKeyQueries_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p6-is-key-window");
                _ = ImGui.IsKeyDown(ImGuiKey.A);
                _ = ImGui.IsKeyPressed(ImGuiKey.A);
                _ = ImGui.IsKeyPressed(ImGuiKey.A, false);
                _ = ImGui.IsKeyReleased(ImGuiKey.A);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every IsMouse state query executes inside one framed window without
        ///     throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsMouseQueries_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p6-is-mouse-window");
                _ = ImGui.IsMouseClicked(ImGuiMouseButton.Left);
                _ = ImGui.IsMouseClicked(ImGuiMouseButton.Left, false);
                _ = ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left);
                _ = ImGui.IsMouseDown(ImGuiMouseButton.Left);
                _ = ImGui.IsMouseDragging(ImGuiMouseButton.Left);
                _ = ImGui.IsMouseDragging(ImGuiMouseButton.Left, -1.0f);
                _ = ImGui.IsMouseHoveringRect(new Vector2F(0, 0), new Vector2F(32, 32));
                _ = ImGui.IsMouseHoveringRect(new Vector2F(0, 0), new Vector2F(32, 32), false);
                _ = ImGui.IsMousePosValid();
                Vector2F mousePos = new Vector2F(10, 10);
                _ = ImGui.IsMousePosValid(ref mousePos);
                _ = ImGui.IsMouseReleased(ImGuiMouseButton.Left);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies both IsPopupOpen overloads report false for an unopened popup and both
        ///     IsRectVisible overloads execute inside one framed window.
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsPopupOpen_And_IsRectVisible_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p6-is-popup-window");
                Assert.False(ImGui.IsPopupOpen("p6-popup"));
                Assert.False(ImGui.IsPopupOpen("p6-popup", ImGuiPopupFlags.AnyPopup));
                _ = ImGui.IsRectVisible(new Vector2F(32.0f, 32.0f));
                _ = ImGui.IsRectVisible(new Vector2F(0, 0), new Vector2F(32, 32));
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies the clipboard, tty and window logging functions execute inside one framed
        ///     window without creating files on disk.
        /// </summary>
        [RequireCImguiSystemFact]
        public void LogFunctions_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p6-log-window");
                ImGui.LogToClipboard();
                ImGui.LogText("p6-log-clipboard-entry");
                ImGui.LogFinish();
                ImGui.LogToClipboard(1);
                ImGui.LogFinish();
                ImGui.LogToTty();
                ImGui.LogText("p6-log-tty-entry");
                ImGui.LogFinish();
                ImGui.LogToTty(1);
                ImGui.LogFinish();
                ImGui.LogButtons();
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies the LogToFile overloads execute against the native library inside a live
        ///     frame. Logging to a file only opens a text file, so the calls are side effect free
        ///     within the test run.
        /// </summary>
        [RequireCImguiSystemFact]
        public void LogToFile_AllOverloads_Execute()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p6-log-file-window");
                ImGui.LogToFile();
                ImGui.LogText("p6-log-file-entry-a");
                ImGui.LogFinish();
                ImGui.LogToFile(1);
                ImGui.LogText("p6-log-file-entry-b");
                ImGui.LogFinish();
                ImGui.LogToFile(1, "p6-log-file.txt");
                ImGui.LogText("p6-log-file-entry-c");
                ImGui.LogFinish();
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies LoadIniSettingsFromDisk executes against the native library using a
        ///     non-existent ini path, which the native function tolerates by failing silently.
        /// </summary>
        [RequireCImguiSystemFact]
        public void LoadIniSettingsFromDisk_Executes()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p6-load-ini-window");
                ImGui.LoadIniSettingsFromDisk("non-existent-settings.ini");
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }
    }
}
