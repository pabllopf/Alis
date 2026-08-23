// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP2ExecutionTests.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Executes the native-backed drag wrappers of the ImGuiP2 partial class against the real
    ///     cimgui library. Each test owns a fresh context destroyed in finally, and every
    ///     window-scoped call is wrapped in a real NewFrame/Begin/End/EndFrame cycle.
    /// </summary>
    public class ImGuiP2ExecutionTests
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
        ///     Verifies every DragInt overload executes inside a framed window without throwing.
        /// </summary>
        [MacOsOnly]
        public void DragInt_Overloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("drag-int-window");
                int v = 5;
                _ = ImGui.DragInt("drag-int-1", ref v, 1.0f);
                _ = ImGui.DragInt("drag-int-2", ref v, 1.0f, 0);
                _ = ImGui.DragInt("drag-int-3", ref v, 1.0f, 0, 100);
                _ = ImGui.DragInt("drag-int-4", ref v, 1.0f, 0, 100, "%d");
                _ = ImGui.DragInt("drag-int-5", ref v, 1.0f, 0, 100, "%d", ImGuiSliderFlags.AlwaysClamp);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every DragInt2 overload executes inside a framed window without throwing.
        /// </summary>
        [MacOsOnly]
        public void DragInt2_Overloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("drag-int2-window");
                int[] values = { 1, 2 };
                _ = ImGui.DragInt2("drag-int2-1", ref values[0]);
                _ = ImGui.DragInt2("drag-int2-2", ref values[0], 1.0f);
                _ = ImGui.DragInt2("drag-int2-3", ref values[0], 1.0f, 0);
                _ = ImGui.DragInt2("drag-int2-4", ref values[0], 1.0f, 0, 100);
                _ = ImGui.DragInt2("drag-int2-5", ref values[0], 1.0f, 0, 100, "%d");
                _ = ImGui.DragInt2("drag-int2-6", ref values[0], 1.0f, 0, 100, "%d", ImGuiSliderFlags.AlwaysClamp);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every DragInt3 overload executes inside a framed window without throwing.
        /// </summary>
        [MacOsOnly]
        public void DragInt3_Overloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("drag-int3-window");
                int[] values = { 1, 2, 3 };
                _ = ImGui.DragInt3("drag-int3-1", ref values[0]);
                _ = ImGui.DragInt3("drag-int3-2", ref values[0], 1.0f);
                _ = ImGui.DragInt3("drag-int3-3", ref values[0], 1.0f, 0);
                _ = ImGui.DragInt3("drag-int3-4", ref values[0], 1.0f, 0, 100);
                _ = ImGui.DragInt3("drag-int3-5", ref values[0], 1.0f, 0, 100, "%d");
                _ = ImGui.DragInt3("drag-int3-6", ref values[0], 1.0f, 0, 100, "%d", ImGuiSliderFlags.AlwaysClamp);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every DragInt4 overload executes inside a framed window without throwing.
        /// </summary>
        [MacOsOnly]
        public void DragInt4_Overloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("drag-int4-window");
                int[] values = { 1, 2, 3, 4 };
                _ = ImGui.DragInt4("drag-int4-1", ref values[0]);
                _ = ImGui.DragInt4("drag-int4-2", ref values[0], 1.0f);
                _ = ImGui.DragInt4("drag-int4-3", ref values[0], 1.0f, 0);
                _ = ImGui.DragInt4("drag-int4-4", ref values[0], 1.0f, 0, 100);
                _ = ImGui.DragInt4("drag-int4-5", ref values[0], 1.0f, 0, 100, "%d");
                _ = ImGui.DragInt4("drag-int4-6", ref values[0], 1.0f, 0, 100, "%d", ImGuiSliderFlags.AlwaysClamp);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every DragIntRange2 overload executes inside a framed window without throwing.
        /// </summary>
        [MacOsOnly]
        public void DragIntRange2_Overloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("drag-int-range2-window");
                int currentMin = 10;
                int currentMax = 50;
                _ = ImGui.DragIntRange2("drag-range2-1", ref currentMin, ref currentMax);
                _ = ImGui.DragIntRange2("drag-range2-2", ref currentMin, ref currentMax, 1.0f);
                _ = ImGui.DragIntRange2("drag-range2-3", ref currentMin, ref currentMax, 1.0f, 0);
                _ = ImGui.DragIntRange2("drag-range2-4", ref currentMin, ref currentMax, 1.0f, 0, 100);
                _ = ImGui.DragIntRange2("drag-range2-5", ref currentMin, ref currentMax, 1.0f, 0, 100, "%d");
                _ = ImGui.DragIntRange2("drag-range2-6", ref currentMin, ref currentMax, 1.0f, 0, 100, "%d", "%d");
                _ = ImGui.DragIntRange2("drag-range2-7", ref currentMin, ref currentMax, 1.0f, 0, 100, "%d", "%d", ImGuiSliderFlags.AlwaysClamp);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every DragScalar overload executes inside a framed window against a pinned
        ///     int payload, using pinned bounds where the signature provides them.
        /// </summary>
        [MacOsOnly]
        public void DragScalar_Overloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("drag-scalar-window");
                int[] payload = { 25 };
                int[] minimum = { 0 };
                int[] maximum = { 100 };
                GCHandle dataHandle = GCHandle.Alloc(payload, GCHandleType.Pinned);
                GCHandle minHandle = GCHandle.Alloc(minimum, GCHandleType.Pinned);
                GCHandle maxHandle = GCHandle.Alloc(maximum, GCHandleType.Pinned);
                IntPtr pData = dataHandle.AddrOfPinnedObject();
                IntPtr pMin = minHandle.AddrOfPinnedObject();
                IntPtr pMax = maxHandle.AddrOfPinnedObject();
                _ = ImGui.DragScalar("drag-scalar-1", ImGuiDataType.S32, pData);
                _ = ImGui.DragScalar("drag-scalar-2", ImGuiDataType.S32, pData, 1.0f);
                _ = ImGui.DragScalar("drag-scalar-3", ImGuiDataType.S32, pData, 1.0f, IntPtr.Zero);
                _ = ImGui.DragScalar("drag-scalar-4", ImGuiDataType.S32, pData, 1.0f, pMin, pMax);
                _ = ImGui.DragScalar("drag-scalar-5", ImGuiDataType.S32, pData, 1.0f, pMin, pMax, "%d");
                _ = ImGui.DragScalar("drag-scalar-6", ImGuiDataType.S32, pData, 1.0f, pMin, pMax, "%d", ImGuiSliderFlags.AlwaysClamp);
                maxHandle.Free();
                minHandle.Free();
                dataHandle.Free();
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every DragScalarN overload executes inside a framed window against a pinned
        ///     int array, using pinned bounds where the signature provides them.
        /// </summary>
        [MacOsOnly]
        public void DragScalarN_Overloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("drag-scalar-n-window");
                int[] payload = { 25, 50 };
                int[] minimum = { 0 };
                GCHandle dataHandle = GCHandle.Alloc(payload, GCHandleType.Pinned);
                GCHandle minHandle = GCHandle.Alloc(minimum, GCHandleType.Pinned);
                IntPtr pData = dataHandle.AddrOfPinnedObject();
                IntPtr pMin = minHandle.AddrOfPinnedObject();
                _ = ImGui.DragScalarN("drag-scalar-n-1", ImGuiDataType.S32, pData, 2);
                _ = ImGui.DragScalarN("drag-scalar-n-2", ImGuiDataType.S32, pData, 2, 1.0f);
                _ = ImGui.DragScalarN("drag-scalar-n-3", ImGuiDataType.S32, pData, 2, 1.0f, pMin);
                minHandle.Free();
                dataHandle.Free();
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
