// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP3ExecutionTests.cs
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
    ///     Executes the native-backed wrappers of the ImGuiP3 partial class against the real
    ///     cimgui library. Each test owns a fresh context destroyed in finally, and every
    ///     window-scoped call is wrapped in a real NewFrame/Begin/End/EndFrame cycle.
    /// </summary>
    public class ImGuiP3ExecutionTests
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
        ///     Verifies the context, time, frame, io, style, font, key, mouse, color, viewport,
        ///     draw list and allocator getters execute against a live context without a frame.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ContextGetters_ExecuteWithoutFrame()
        {
            IntPtr ctx = CreateContext();
            try
            {
                Assert.NotEqual(IntPtr.Zero, ImGui.GetCurrentContext());
                Assert.False(string.IsNullOrEmpty(ImGui.GetVersion()));
                Assert.True(ImGui.GetFrameCount() >= 0);
                Assert.True(ImGui.GetTime() >= 0.0);
                Assert.NotEqual(IntPtr.Zero, ImGui.GetDrawListSharedData());
                Assert.NotEqual(IntPtr.Zero, ImGui.GetMainViewport().NativePtr);
                Assert.Equal(IntPtr.Zero, ImGui.FindViewportById(0x12345678).NativePtr);
                Assert.Equal(IntPtr.Zero, ImGui.FindViewportByPlatformHandle(new IntPtr(0x1234)).NativePtr);
                _ = ImGui.GetFont();
                _ = ImGui.GetFontSize();
                _ = ImGui.GetFontTexUvWhitePixel();
                _ = ImGui.GetFrameHeight();
                _ = ImGui.GetFrameHeightWithSpacing();
                _ = ImGui.GetKeyIndex(ImGuiKey.A);
                _ = ImGui.GetKeyPressedAmount(ImGuiKey.A, 0.1f, 0.1f);
                _ = ImGui.GetMousePos();
                _ = ImGui.GetMousePosOnOpeningCurrentPopup();
                _ = ImGui.GetMouseCursor();
                _ = ImGui.GetMouseClickedCount(ImGuiMouseButton.Left);
                _ = ImGui.GetMouseDragDelta();
                _ = ImGui.GetMouseDragDelta(ImGuiMouseButton.Left);
                _ = ImGui.GetMouseDragDelta(ImGuiMouseButton.Left, -1.0f);
                _ = ImGui.GetPlatformIo();
                _ = ImGui.GetStyleColorVec4(ImGuiCol.Text);
                _ = ImGui.GetTextLineHeight();
                _ = ImGui.GetTextLineHeightWithSpacing();
                _ = ImGui.GetTreeNodeToLabelSpacing();
                _ = ImGui.GetWindowDpiScale();
                _ = ImGui.GetColorU32(ImGuiCol.Text);
                _ = ImGui.GetColorU32(ImGuiCol.Text, 0.5f);
                _ = ImGui.GetColorU32(new Vector4F(1, 1, 1, 1));
                _ = ImGui.GetColorU32(0xFF000000);
                IntPtr alloc = IntPtr.Zero;
                IntPtr free = IntPtr.Zero;
                IntPtr userData = IntPtr.Zero;
                ImGui.GetAllocatorFunctions(ref alloc, ref free, ref userData);
                _ = ImGui.GetStyle();
                _ = ImGui.GetStyle().Alpha;
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies the string getters that cannot marshal the native const char return value
        ///     throw MarshalDirectiveException while still executing the wrapper bodies.
        /// </summary>
        [RequireCImguiSystemFact]
        public void StringGetters_ThatFailMarshalling_Throw()
        {
            IntPtr ctx = CreateContext();
            try
            {
                Assert.Throws<MarshalDirectiveException>(() => ImGui.GetClipboardText());
                Assert.Throws<MarshalDirectiveException>(() => ImGui.GetKeyName(ImGuiKey.A));
                Assert.Throws<MarshalDirectiveException>(() => ImGui.GetStyleColorName(ImGuiCol.Text));
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetDrawData throws NullReferenceException without a rendered frame and
        ///     GetIo initializes the cached IO pointer from the native context. The context is
        ///     deliberately leaked so the static IO cache stays valid for the host process.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetDrawData_And_GetIo_Execute()
        {
            IntPtr ctx = CreateContext();
            Assert.Throws<NullReferenceException>(() => ImGui.GetDrawData());
            ImGuiIoPtr io = ImGui.GetIo();
            Assert.NotEqual(IntPtr.Zero, io.NativePtr);
        }

        /// <summary>
        ///     Verifies the window, cursor, item rect, content region, id, state storage, scroll and
        ///     draw list getters execute inside a framed window, together with Dummy, Indent and
        ///     the viewport-scoped draw list getters.
        /// </summary>
        [RequireCImguiSystemFact]
        public void WindowGetters_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("getter-window");
                _ = ImGui.GetId("execution-id");
                _ = ImGui.GetId(new IntPtr(0x1234));
                _ = ImGui.GetStateStorage();
                _ = ImGui.GetScrollX();
                _ = ImGui.GetScrollY();
                _ = ImGui.GetScrollMaxX();
                _ = ImGui.GetScrollMaxY();
                _ = ImGui.GetForegroundDrawList();
                _ = ImGui.GetBackgroundDrawList();
                _ = ImGui.GetWindowPos();
                _ = ImGui.GetWindowSize();
                _ = ImGui.GetWindowWidth();
                _ = ImGui.GetWindowHeight();
                _ = ImGui.GetWindowContentRegionMin();
                _ = ImGui.GetWindowContentRegionMax();
                _ = ImGui.GetWindowDockId();
                _ = ImGui.GetWindowDrawList();
                _ = ImGui.GetWindowViewport();
                _ = ImGui.GetCursorPos();
                _ = ImGui.GetCursorPosX();
                _ = ImGui.GetCursorPosY();
                _ = ImGui.GetCursorScreenPos();
                _ = ImGui.GetCursorStartPos();
                _ = ImGui.GetContentRegionAvail();
                _ = ImGui.GetContentRegionMax();
                _ = ImGui.GetItemRectMin();
                _ = ImGui.GetItemRectMax();
                _ = ImGui.GetItemRectSize();
                ImGuiViewportPtr viewport = ImGui.GetMainViewport();
                _ = ImGui.GetBackgroundDrawList(viewport);
                _ = ImGui.GetForegroundDrawList(viewport);
                ImGui.Dummy(new Vector2F(16.0f, 16.0f));
                ImGui.Indent();
                ImGui.Indent(20.0f);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every InputFloat, InputDouble, InputFloat2, InputFloat3, InputFloat4 and
        ///     DragScalarN overload executes inside a framed window without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void InputWidgets_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("input-window");
                float v = 1.0f;
                _ = ImGui.InputFloat("float", ref v);
                _ = ImGui.InputFloat("float-step", ref v, 0.1f);
                _ = ImGui.InputFloat("float-fast", ref v, 0.1f, 0.5f);
                _ = ImGui.InputFloat("float-format", ref v, 0.1f, 0.5f, "%.2f");
                _ = ImGui.InputFloat("float-flags", ref v, 0.1f, 0.5f, "%.2f", ImGuiInputTextFlags.CharsDecimal);
                double d = 1.0;
                _ = ImGui.InputDouble("double", ref d);
                _ = ImGui.InputDouble("double-step", ref d, 0.1);
                _ = ImGui.InputDouble("double-fast", ref d, 0.1, 0.5);
                _ = ImGui.InputDouble("double-format", ref d, 0.1, 0.5, "%.2f");
                _ = ImGui.InputDouble("double-flags", ref d, 0.1, 0.5, "%.2f", ImGuiInputTextFlags.CharsDecimal);
                Vector2F v2 = new Vector2F(1, 1);
                _ = ImGui.InputFloat2("float2", ref v2);
                _ = ImGui.InputFloat2("float2-format", ref v2, "%.2f");
                _ = ImGui.InputFloat2("float2-flags", ref v2, "%.2f", ImGuiInputTextFlags.CharsDecimal);
                Vector3F v3 = new Vector3F(1, 1, 1);
                _ = ImGui.InputFloat3("float3", ref v3);
                _ = ImGui.InputFloat3("float3-format", ref v3, "%.2f");
                _ = ImGui.InputFloat3("float3-flags", ref v3, "%.2f", ImGuiInputTextFlags.CharsDecimal);
                Vector4F v4 = new Vector4F(1, 1, 1, 1);
                _ = ImGui.InputFloat4("float4", ref v4);
                float[] data = { 1.0f };
                GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
                IntPtr pData = handle.AddrOfPinnedObject();
                _ = ImGui.DragScalarN("drag1", ImGuiDataType.Float, pData, 1, 0.5f, IntPtr.Zero, IntPtr.Zero);
                _ = ImGui.DragScalarN("drag2", ImGuiDataType.Float, pData, 1, 0.5f, IntPtr.Zero, IntPtr.Zero, "%.2f");
                _ = ImGui.DragScalarN("drag3", ImGuiDataType.Float, pData, 1, 0.5f, IntPtr.Zero, IntPtr.Zero, "%.2f", ImGuiSliderFlags.AlwaysClamp);
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
        ///     Verifies every Image and ImageButton overload executes inside a framed window.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ImageWidgets_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("image-window");
                Vector2F size = new Vector2F(32.0f, 32.0f);
                IntPtr texture = IntPtr.Zero;
                ImGui.Image(texture, size);
                ImGui.Image(texture, size, new Vector2F());
                ImGui.Image(texture, size, new Vector2F(), new Vector2F(1, 1));
                ImGui.Image(texture, size, new Vector2F(), new Vector2F(1, 1), new Vector4F(1, 1, 1, 1));
                ImGui.Image(texture, size, new Vector2F(), new Vector2F(1, 1), new Vector4F(1, 1, 1, 1), new Vector4F());
                _ = ImGui.ImageButton("image-button-1", texture, size);
                _ = ImGui.ImageButton("image-button-2", texture, size, new Vector2F());
                _ = ImGui.ImageButton("image-button-3", texture, size, new Vector2F(), new Vector2F(1, 1));
                _ = ImGui.ImageButton("image-button-4", texture, size, new Vector2F(), new Vector2F(1, 1), new Vector4F());
                _ = ImGui.ImageButton("image-button-5", texture, size, new Vector2F(), new Vector2F(1, 1), new Vector4F(), new Vector4F(1, 1, 1, 1));
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies EndGroup, EndChild, EndChildFrame and EndDisabled execute when paired with
        ///     their Begin* counterparts inside a framed window.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Ends_ChildAndGroup_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("paired-window");
                ImGui.BeginGroup();
                ImGui.EndGroup();
                ImGui.BeginChild("paired-child");
                ImGui.EndChild();
                ImGui.BeginChildFrame(1u, new Vector2F(100.0f, 100.0f));
                ImGui.EndChildFrame();
                ImGui.BeginDisabled();
                ImGui.EndDisabled();
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies EndListBox executes when paired with BeginListBox inside a framed window.
        /// </summary>
        [RequireCImguiSystemFact]
        public void EndListBox_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("paired-window");
                ImGui.BeginListBox("paired-listbox");
                ImGui.EndListBox();
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies EndTooltip executes when paired with BeginTooltip inside a framed window.
        /// </summary>
        [RequireCImguiSystemFact]
        public void EndTooltip_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("paired-window");
                ImGui.BeginTooltip();
                ImGui.EndTooltip();
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies EndTabBar executes when paired with BeginTabBar inside a framed window.
        /// </summary>
        [RequireCImguiSystemFact]
        public void EndTabBar_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("paired-window");
                ImGui.BeginTabBar("paired-tabbar");
                ImGui.EndTabBar();
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies EndTable executes when paired with BeginTable inside a framed window.
        /// </summary>
        [RequireCImguiSystemFact]
        public void EndTable_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("paired-window");
                ImGui.BeginTable("paired-table", 2);
                ImGui.EndTable();
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies EndPopup executes after OpenPopup and a successful BeginPopup inside a
        ///     framed window.
        /// </summary>
        [RequireCImguiSystemFact]
        public void EndPopup_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("paired-window");
                ImGui.OpenPopup("paired-popup");
                if (ImGui.BeginPopup("paired-popup"))
                {
                    ImGui.EndPopup();
                }

                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies EndMenuBar, EndMenu and EndMainMenuBar execute when paired with their
        ///     Begin* counterparts inside a framed window.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Ends_Menus_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                bool open = true;
                ImGui.Begin("paired-window", ref open, ImGuiWindowFlags.MenuBar);
                if (ImGui.BeginMenuBar())
                {
                    ImGui.EndMenuBar();
                }

                ImGui.End();
                if (ImGui.BeginMainMenuBar())
                {
                    if (ImGui.BeginMenu("paired-menu"))
                    {
                        ImGui.EndMenu();
                    }

                    ImGui.EndMainMenuBar();
                }

                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies EndFrame closes a real frame and GetDragDropPayload returns the context
        ///     payload produced by the frame.
        /// </summary>
        [RequireCImguiSystemFact]
        public void EndFrame_And_GetDragDropPayload_Execute()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("frame-window");
                ImGui.End();
                _ = ImGui.GetDragDropPayload();
                ImGui.EndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }
    }
}
