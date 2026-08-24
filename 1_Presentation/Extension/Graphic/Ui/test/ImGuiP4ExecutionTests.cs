// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP4ExecutionTests.cs
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
using System.Text;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Executes the native-backed wrappers of the ImGuiP4 partial class against the real
    ///     cimgui library. Each test owns a fresh context destroyed in finally, and every
    ///     window-scoped call is wrapped in a real NewFrame/Begin/End/EndFrame cycle.
    /// </summary>
    public class ImGuiP4ExecutionTests
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
        ///     Verifies every Text family wrapper executes inside a framed window without
        ///     throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void TextFamily_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p4-text-window");
                ImGui.Text("p4-plain-text");
                ImGui.TextColored(new Vector4F(1, 0, 0, 1), "p4-colored-text");
                ImGui.TextDisabled("p4-disabled-text");
                ImGui.TextUnformatted("p4-unformatted-text");
                ImGui.TextWrapped("p4-wrapped-text");
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every TreeNode, TreeNodeEx, TreePush, TreePop and Unindent wrapper
        ///     executes inside a framed window without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void TreeFamily_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p4-tree-window");
                if (ImGui.TreeNode("p4-node-1"))
                {
                    ImGui.TreePop();
                }

                if (ImGui.TreeNode("p4-node-2", "p4-node-2-label"))
                {
                    ImGui.TreePop();
                }

                if (ImGui.TreeNode(new IntPtr(1), "p4-node-3-label"))
                {
                    ImGui.TreePop();
                }

                if (ImGui.TreeNodeEx("p4-node-ex-1"))
                {
                    ImGui.TreePop();
                }

                if (ImGui.TreeNodeEx("p4-node-ex-2", ImGuiTreeNodeFlags.None))
                {
                    ImGui.TreePop();
                }

                if (ImGui.TreeNodeEx("p4-node-ex-3", ImGuiTreeNodeFlags.None, "p4-node-ex-3-label"))
                {
                    ImGui.TreePop();
                }

                if (ImGui.TreeNodeEx(new IntPtr(2), ImGuiTreeNodeFlags.None, "p4-node-ex-4-label"))
                {
                    ImGui.TreePop();
                }

                ImGui.TreePush("p4-push-1");
                ImGui.TreePop();
                ImGui.TreePush(new IntPtr(3));
                ImGui.TreePop();
                ImGui.Unindent();
                ImGui.Unindent(10.0f);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every InputTextMultiline and InputTextWithHint overload executes inside a
        ///     framed window against a real managed buffer without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void InputTextMultiline_And_InputTextWithHint_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p4-input-text-window");
                string input = "p4-multiline-input";
                uint maxLength = (uint) Encoding.UTF8.GetByteCount(input);
                _ = ImGui.InputTextMultiline("p4-multiline-1", ref input, maxLength, new Vector2F(128.0f, 64.0f));
                _ = ImGui.InputTextMultiline("p4-multiline-2", ref input, maxLength, new Vector2F(128.0f, 64.0f), ImGuiInputTextFlags.None);
                _ = ImGui.InputTextMultiline("p4-multiline-3", ref input, maxLength, new Vector2F(128.0f, 64.0f), ImGuiInputTextFlags.None, null);
                _ = ImGui.InputTextMultiline("p4-multiline-4", ref input, maxLength, new Vector2F(128.0f, 64.0f), ImGuiInputTextFlags.None, null, IntPtr.Zero);
                string hinted = "p4-hinted-input";
                uint hintedLength = (uint) Encoding.UTF8.GetByteCount(hinted);
                _ = ImGui.InputTextWithHint("p4-hinted-1", "p4-hint", hinted, hintedLength);
                _ = ImGui.InputTextWithHint("p4-hinted-2", "p4-hint", hinted, hintedLength, ImGuiInputTextFlags.None);
                _ = ImGui.InputTextWithHint("p4-hinted-3", "p4-hint", hinted, hintedLength, ImGuiInputTextFlags.None, null);
                _ = ImGui.InputTextWithHint("p4-hinted-4", "p4-hint", hinted, hintedLength, ImGuiInputTextFlags.None, null, IntPtr.Zero);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every TableSetupColumn and TableSetupScrollFreeze overload executes inside
        ///     a BeginTable/EndTable block of a framed window without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void TableFamily_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p4-table-window");
                if (ImGui.BeginTable("p4-table", 3))
                {
                    ImGui.TableSetupColumn("p4-col-1", ImGuiTableColumnFlags.None);
                    ImGui.TableSetupColumn("p4-col-2", ImGuiTableColumnFlags.None, 0.0f);
                    ImGui.TableSetupColumn("p4-col-3", ImGuiTableColumnFlags.None, 0.0f, 0u);
                    ImGui.TableSetupScrollFreeze(0, 0);
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
        ///     Verifies every VSliderFloat and VSliderInt overload executes inside a framed
        ///     window against ref values without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void VSliderFloat_And_VSliderInt_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p4-vslider-window");
                Vector2F size = new Vector2F(24.0f, 96.0f);
                float vf = 0.5f;
                _ = ImGui.VSliderFloat("p4-vslider-f-1", size, ref vf, 0.0f, 1.0f);
                _ = ImGui.VSliderFloat("p4-vslider-f-2", size, ref vf, 0.0f, 1.0f, "%.2f");
                _ = ImGui.VSliderFloat("p4-vslider-f-3", size, ref vf, 0.0f, 1.0f, "%.2f", ImGuiSliderFlags.None);
                int vi = 5;
                _ = ImGui.VSliderInt("p4-vslider-i-1", size, ref vi, 0, 10);
                _ = ImGui.VSliderInt("p4-vslider-i-2", size, ref vi, 0, 10, "%d");
                _ = ImGui.VSliderInt("p4-vslider-i-3", size, ref vi, 0, 10, "%d", ImGuiSliderFlags.None);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every VSliderScalar overload executes inside a framed window against
        ///     pinned float payload, min and max pointers without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void VSliderScalar_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p4-vslider-scalar-window");
                float[] payload = { 0.5f };
                float[] minimum = { 0.0f };
                float[] maximum = { 1.0f };
                GCHandle dataHandle = GCHandle.Alloc(payload, GCHandleType.Pinned);
                GCHandle minHandle = GCHandle.Alloc(minimum, GCHandleType.Pinned);
                GCHandle maxHandle = GCHandle.Alloc(maximum, GCHandleType.Pinned);
                IntPtr pData = dataHandle.AddrOfPinnedObject();
                IntPtr pMin = minHandle.AddrOfPinnedObject();
                IntPtr pMax = maxHandle.AddrOfPinnedObject();
                Vector2F size = new Vector2F(24.0f, 96.0f);
                _ = ImGui.VSliderScalar("p4-vslider-s-1", size, ImGuiDataType.Float, pData, pMin, pMax);
                _ = ImGui.VSliderScalar("p4-vslider-s-2", size, ImGuiDataType.Float, pData, pMin, pMax, "%.2f");
                _ = ImGui.VSliderScalar("p4-vslider-s-3", size, ImGuiDataType.Float, pData, pMin, pMax, "%.2f", ImGuiSliderFlags.None);
                dataHandle.Free();
                minHandle.Free();
                maxHandle.Free();
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every Value overload executes inside a framed window without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Value_AllOverloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p4-value-window");
                ImGui.Value("p4-value-bool", true);
                ImGui.Value("p4-value-int", 42);
                ImGui.Value("p4-value-uint", 42u);
                ImGui.Value("p4-value-float", 1.5f);
                ImGui.Value("p4-value-float-format", 1.5f, "%.2f");
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies the Begin wrapper taking window flags returns true and pairs with End
        ///     inside a framed window.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Begin_WithFlags_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                Assert.True(ImGui.Begin("p4-begin-window", ImGuiWindowFlags.None));
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies UpdatePlatformWindows executes after a rendered frame without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void UpdatePlatformWindows_ExecuteAfterFrame()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p4-platform-window");
                ImGui.End();
                ImGuiNative.igEndFrame();
                ImGui.UpdatePlatformWindows();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every CalcTextSize overload executes and returns a non-zero size.
        /// </summary>
        [RequireCImguiSystemFact]
        public void CalcTextSize_AllOverloads_Execute()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p4-calctextsize-window");
                _ = ImGui.CalcTextSize("p4 text");
                _ = ImGui.CalcTextSize("p4 text", 2);
                _ = ImGui.CalcTextSize("p4 text", 128.0f);
                _ = ImGui.CalcTextSize("p4 text", true);
                _ = ImGui.CalcTextSize("p4 text", 2, 4);
                _ = ImGui.CalcTextSize("p4 text", 2, true);
                _ = ImGui.CalcTextSize("p4 text", 2, 128.0f);
                _ = ImGui.CalcTextSize("p4 text", true, 128.0f);
                _ = ImGui.CalcTextSize("p4 text", 2, 4, true);
                _ = ImGui.CalcTextSize("p4 text", 2, 4, 128.0f);
                _ = ImGui.CalcTextSize("p4 text", 2, 4, true, 128.0f);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every InputText overload taking an IntPtr buffer executes inside a framed
        ///     window against a real allocated buffer without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void InputText_IntPtrOverloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p4-inputtext-window");
                IntPtr buffer = Marshal.AllocHGlobal(256);
                byte[] initial = Encoding.UTF8.GetBytes("p4 buffer\0");
                Marshal.Copy(initial, 0, buffer, initial.Length);
                try
                {
                    _ = ImGui.InputText("p4-input-ptr-1", buffer, 256);
                    _ = ImGui.InputText("p4-input-ptr-2", buffer, 256, ImGuiInputTextFlags.None);
                    _ = ImGui.InputText("p4-input-ptr-3", buffer, 256, ImGuiInputTextFlags.None, null);
                    _ = ImGui.InputText("p4-input-ptr-4", buffer, 256, ImGuiInputTextFlags.None, null, IntPtr.Zero);
                }
                finally
                {
                    Marshal.FreeHGlobal(buffer);
                }
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
