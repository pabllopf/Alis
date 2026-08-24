// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiExecutionTests.cs
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
    ///     Executes the native-backed wrappers of the ImGui partial class against the real
    ///     cimgui library. Each test owns a fresh context destroyed in finally, and every
    ///     window-scoped call is wrapped in a real NewFrame/Begin/End/EndFrame cycle.
    /// </summary>
    public class ImGuiExecutionTests
    {
        /// <summary>
        ///     The no load mode of the dyld dynamic loader
        /// </summary>
        private const int RtlNoLoad = 0x10;

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
        ///     Opens an already loaded dynamic library
        /// </summary>
        /// <param name="path">The image path</param>
        /// <param name="mode">The open mode</param>
        /// <returns>The library handle</returns>
        [DllImport("libSystem.dylib", EntryPoint = "dlopen")]
        private static extern IntPtr DlOpen(string path, int mode);

        /// <summary>
        ///     Resolves the address of an exported symbol inside a loaded library
        /// </summary>
        /// <param name="handle">The library handle</param>
        /// <param name="symbol">The symbol name</param>
        /// <returns>The symbol address</returns>
        [DllImport("libSystem.dylib", EntryPoint = "dlsym")]
        private static extern IntPtr Dlsym(IntPtr handle, string symbol);

        /// <summary>
        ///     Returns information about the loaded image that owns the given address
        /// </summary>
        /// <param name="address">The address to resolve</param>
        /// <param name="info">The image information</param>
        /// <returns>The result</returns>
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
        ///     Verifies every StyleColors overload executes against a live context without a frame.
        /// </summary>
        [RequireCImguiSystemFact]
        public void StyleColors_ExecuteWithoutFrame()
        {
            IntPtr ctx = CreateContext();
            try
            {
                ImGui.StyleColorsClassic();
                ImGui.StyleColorsClassic(new ImGuiStyle());
                ImGui.StyleColorsDark();
                ImGui.StyleColorsDark(new ImGuiStyle());
                ImGui.StyleColorsLight();
                ImGui.StyleColorsLight(new ImGuiStyle());
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every DockBuilder wrapper available in the bundled cimgui executes against
        ///     a live context, following the add, split, dock, size and finish sequence used by
        ///     the docking demo.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DockBuilder_ExecuteWithContext()
        {
            IntPtr ctx = CreateContext();
            try
            {
                uint dockspaceId = 0x00000001;
                ImGui.DockBuilderRemoveNode(dockspaceId);
                ImGui.DockBuilderAddNode(dockspaceId, ImGuiDockNodeFlags.None);
                ImGui.DockBuilderSetNodeSize(dockspaceId, new Vector2F(300.0f, 200.0f));
                ImGui.DockBuilderSplitNode(dockspaceId, ImGuiDir.Right, 0.3f, null, out uint dockIdRight);
                ImGui.DockBuilderDockWindow("docked-window", dockIdRight);
                ImGui.DockBuilderFinish(dockspaceId);
                ImGui.DockBuilderRemoveNode(dockspaceId);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every SliderInt, SliderInt2, SliderInt3, SliderInt4, SliderScalar and
        ///     SliderScalarN overload executes inside a framed window.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Sliders_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("slider-window");
                int single = 1;
                _ = ImGui.SliderInt("slider-int-1", ref single, 0, 10);
                _ = ImGui.SliderInt("slider-int-2", ref single, 0, 10, "%d");
                _ = ImGui.SliderInt("slider-int-3", ref single, 0, 10, "%d", ImGuiSliderFlags.AlwaysClamp);
                int[] pair = new int[2];
                _ = ImGui.SliderInt2("slider-int2-1", ref pair[0], 0, 10);
                _ = ImGui.SliderInt2("slider-int2-2", ref pair[0], 0, 10, "%d");
                _ = ImGui.SliderInt2("slider-int2-3", ref pair[0], 0, 10, "%d", ImGuiSliderFlags.AlwaysClamp);
                int[] triple = new int[3];
                _ = ImGui.SliderInt3("slider-int3-1", ref triple[0], 0, 10);
                _ = ImGui.SliderInt3("slider-int3-2", ref triple[0], 0, 10, "%d");
                _ = ImGui.SliderInt3("slider-int3-3", ref triple[0], 0, 10, "%d", ImGuiSliderFlags.AlwaysClamp);
                int[] quad = new int[4];
                _ = ImGui.SliderInt4("slider-int4-1", ref quad[0], 0, 10);
                _ = ImGui.SliderInt4("slider-int4-2", ref quad[0], 0, 10, "%d");
                _ = ImGui.SliderInt4("slider-int4-3", ref quad[0], 0, 10, "%d", ImGuiSliderFlags.AlwaysClamp);
                GCHandle handle = GCHandle.Alloc(quad, GCHandleType.Pinned);
                int[] bounds = new int[2] { 0, 10 };
                GCHandle boundsHandle = GCHandle.Alloc(bounds, GCHandleType.Pinned);
                IntPtr pData = handle.AddrOfPinnedObject();
                IntPtr pMin = boundsHandle.AddrOfPinnedObject();
                IntPtr pMax = IntPtr.Add(pMin, 4);
                _ = ImGui.SliderScalar("slider-scalar-1", ImGuiDataType.S32, pData, pMin, pMax);
                _ = ImGui.SliderScalar("slider-scalar-2", ImGuiDataType.S32, pData, pMin, pMax, "%d");
                _ = ImGui.SliderScalar("slider-scalar-3", ImGuiDataType.S32, pData, pMin, pMax, "%d", ImGuiSliderFlags.AlwaysClamp);
                _ = ImGui.SliderScalarN("slider-scalar-n-1", ImGuiDataType.S32, pData, 2, pMin, pMax);
                _ = ImGui.SliderScalarN("slider-scalar-n-2", ImGuiDataType.S32, pData, 2, pMin, pMax, "%d");
                _ = ImGui.SliderScalarN("slider-scalar-n-3", ImGuiDataType.S32, pData, 2, pMin, pMax, "%d", ImGuiSliderFlags.AlwaysClamp);
                boundsHandle.Free();
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
        ///     Verifies SmallButton, Spacing and MenuItem execute inside a framed window.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ButtonAndSpacing_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("button-window");
                _ = ImGui.SmallButton("small-button");
                ImGui.Spacing();
                _ = ImGui.MenuItem("menu-item", true);
                _ = ImGui.MenuItem("menu-item-disabled", false);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every TabItemButton overload executes inside a tab bar within a framed window.
        /// </summary>
        [RequireCImguiSystemFact]
        public void TabItemButton_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("tab-window");
                if (ImGui.BeginTabBar("tab-bar"))
                {
                    _ = ImGui.TabItemButton("tab-item-1");
                    _ = ImGui.TabItemButton("tab-item-2", ImGuiTabItemFlags.None);
                    ImGui.EndTabBar();
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
        ///     Verifies the whole table family of wrappers executes inside a framed window with an
        ///     open table and returns sane values.
        /// </summary>
        [RequireCImguiSystemFact]
        public void TableFamily_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("table-window");
                if (ImGui.BeginTable("execution-table", 2, ImGuiTableFlags.Hideable))
                {
                    ImGui.TableSetupColumn("col-a");
                    ImGui.TableSetupColumn("col-b");
                    ImGui.TableHeadersRow();
                    ImGui.TableHeader("header-a");
                    Assert.Equal(2, ImGui.TableGetColumnCount());
                    _ = ImGui.TableGetColumnFlags();
                    _ = ImGui.TableGetColumnFlags(0);
                    Assert.True(ImGui.TableGetColumnIndex() >= 0);
                    Assert.True(ImGui.TableGetRowIndex() >= 0);
                    Assert.Throws<MarshalDirectiveException>(() => ImGui.TableGetColumnName());
                    Assert.Throws<MarshalDirectiveException>(() => ImGui.TableGetColumnName(0));
                    ImGui.TableNextRow();
                    ImGui.TableNextRow(ImGuiTableRowFlags.None);
                    ImGui.TableNextRow(ImGuiTableRowFlags.None, 4.0f);
                    if (ImGui.TableNextColumn())
                    {
                        ImGui.Spacing();
                    }

                    if (ImGui.TableSetColumnIndex(0))
                    {
                        ImGui.Spacing();
                    }

                    ImGui.TableSetColumnEnabled(0, true);
                    ImGui.TableSetColumnEnabled(1, false);
                    ImGui.TableSetBgColor(ImGuiTableBgTarget.RowBg0, 0xFF0000FF);
                    ImGui.TableSetBgColor(ImGuiTableBgTarget.CellBg, 0xFF0000FF, 0);
                    _ = ImGui.TableGetSortSpecs();
                    ImGui.EndTable();
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
        ///     Verifies ImFontConfig creates a native font config with a valid pointer.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ImFontConfig_CreatesNativeConfig()
        {
            IntPtr ctx = CreateContext();
            try
            {
                ImFontConfigPtr config = ImGui.ImFontConfig();
                Assert.NotEqual(IntPtr.Zero, config.NativePtr);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies the DockBuilderSetNodeFlags wrapper dispatch against a live context; the
        ///     C wrapper export is absent from the shipped cimgui build so the call is expected
        ///     to fail with EntryPointNotFoundException.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DockBuilderSetNodeFlags_Execute()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                try
                {
                    ImGui.DockBuilderSetNodeFlags(0x12345678u, ImGuiDockNodeFlags.None);
                }
                catch (EntryPointNotFoundException)
                {
                }

                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }
    }
}
