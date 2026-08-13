// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP1ExecutionTests.cs
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
    ///     Executes the native-backed wrappers of the ImGuiP1 partial class against the real
    ///     cimgui library. Each test owns a fresh context destroyed in finally, and every
    ///     window-scoped call is wrapped in a real NewFrame/Begin/End/EndFrame cycle.
    /// </summary>
    public class ImGuiP1ExecutionTests
    {
        /// <summary>
        ///     The image offset of the native GImGui context slot
        /// </summary>
        private const int GImGuiSlot = 0x4597e0;

        /// <summary>
        ///     The native value of ImGuiConfigFlags_DockingEnable in cimgui 1.89.2
        /// </summary>
        private const int DockingEnableFlag = 0x200;

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
        ///     Creates a raw ImGui context and binds it as the current context.
        /// </summary>
        /// <returns>The created context pointer</returns>
        private static IntPtr CreateContext()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            ImGuiNative.igSetCurrentContext(ctx);
            SyncContextSlots(ctx);
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
        ///     Enables the native docking flag on the io config flags of the current context so
        ///     that igDockSpace and igDockSpaceOverViewport can run without triggering asserts.
        /// </summary>
        private static void EnableDocking()
        {
            IntPtr ioPtr = ImGuiNative.igGetIO();
            int config = Marshal.ReadInt32(ioPtr, 0);
            Marshal.WriteInt32(ioPtr, 0, config | DockingEnableFlag);
        }

        /// <summary>
        ///     Verifies both CreateContext overloads execute against the native library: the
        ///     plain one and the one sharing the font atlas of an existing context.
        /// </summary>
        [MacOsOnly]
        public void CreateContext_Overloads_Execute()
        {
            IntPtr ctx = ImGui.CreateContext();
            try
            {
                Assert.NotEqual(IntPtr.Zero, ctx);
                ImGuiNative.igSetCurrentContext(ctx);
                SyncContextSlots(ctx);
                IntPtr ioPtr = ImGuiNative.igGetIO();
                IntPtr fontsPtr = Marshal.ReadIntPtr(ioPtr, 80);
                ImFontAtlasPtr atlas = new ImFontAtlasPtr(fontsPtr);
                IntPtr shared = ImGui.CreateContext(atlas);
                try
                {
                    Assert.NotEqual(IntPtr.Zero, shared);
                }
                finally
                {
                    ImGuiNative.igDestroyContext(shared);
                }
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies DebugCheckVersionAndDataLayout executes against the native library with
        ///     the version reported by the library itself and plausible structure sizes.
        /// </summary>
        [MacOsOnly]
        public void DebugCheckVersionAndDataLayout_Execute()
        {
            IntPtr ctx = CreateContext();
            try
            {
                _ = ImGui.DebugCheckVersionAndDataLayout("1.89.2\0", 14320u, 1080u, 8u, 16u, 20u, 2u);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies DebugTextEncoding executes inside a framed window.
        /// </summary>
        [MacOsOnly]
        public void DebugTextEncoding_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("debug-window");
                ImGui.DebugTextEncoding("Héllo✓ 中文");
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every DockSpace overload executes inside a framed window with docking
        ///     enabled, using zero-initialized window classes.
        /// </summary>
        [MacOsOnly]
        public void DockSpace_AllOverloads_ExecuteInsideFrame()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                EnableDocking();
                ImGuiNative.igNewFrame();
                ImGui.Begin("dock-window");
                _ = ImGui.DockSpace(1u);
                _ = ImGui.DockSpace(2u, new Vector2F(64.0f, 64.0f));
                _ = ImGui.DockSpace(3u, new Vector2F(), ImGuiDockNodeFlags.NoDockingInCentralNode);
                _ = ImGui.DockSpace(4u, new Vector2F(), ImGuiDockNodeFlags.None, new ImGuiWindowClass());
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every DockSpaceOverViewport overload executes inside a framed window with
        ///     docking enabled, using the main viewport and zero-initialized window classes.
        /// </summary>
        [MacOsOnly]
        public void DockSpaceOverViewport_AllOverloads_ExecuteInsideFrame()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                EnableDocking();
                ImGuiNative.igNewFrame();
                ImGui.Begin("dock-viewport-window");
                ImGuiViewportPtr viewport = ImGui.GetMainViewport();
                _ = ImGui.DockSpaceOverViewport();
                _ = ImGui.DockSpaceOverViewport(viewport);
                _ = ImGui.DockSpaceOverViewport(viewport, ImGuiDockNodeFlags.NoDockingInCentralNode);
                _ = ImGui.DockSpaceOverViewport(viewport, ImGuiDockNodeFlags.None, new ImGuiWindowClass());
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every DragFloat overload executes inside a framed window with real
        ///     values, speed, bounds, format and flags.
        /// </summary>
        [MacOsOnly]
        public void DragFloat_AllOverloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("drag-window");
                float v = 1.0f;
                _ = ImGui.DragFloat("drag", ref v);
                _ = ImGui.DragFloat("drag-speed", ref v, 0.1f);
                _ = ImGui.DragFloat("drag-min", ref v, 0.1f, 0.0f);
                _ = ImGui.DragFloat("drag-range", ref v, 0.1f, 0.0f, 100.0f);
                _ = ImGui.DragFloat("drag-format", ref v, 0.1f, 0.0f, 100.0f, "%.2f");
                _ = ImGui.DragFloat("drag-flags", ref v, 0.1f, 0.0f, 100.0f, "%.2f", ImGuiSliderFlags.AlwaysClamp);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every DragFloat2 overload executes inside a framed window with real
        ///     values, speed, bounds, format and flags.
        /// </summary>
        [MacOsOnly]
        public void DragFloat2_AllOverloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("drag2-window");
                Vector2F v = new Vector2F(1, 1);
                _ = ImGui.DragFloat2("drag2", ref v);
                _ = ImGui.DragFloat2("drag2-speed", ref v, 0.1f);
                _ = ImGui.DragFloat2("drag2-min", ref v, 0.1f, 0.0f);
                _ = ImGui.DragFloat2("drag2-range", ref v, 0.1f, 0.0f, 100.0f);
                _ = ImGui.DragFloat2("drag2-format", ref v, 0.1f, 0.0f, 100.0f, "%.2f");
                _ = ImGui.DragFloat2("drag2-flags", ref v, 0.1f, 0.0f, 100.0f, "%.2f", ImGuiSliderFlags.AlwaysClamp);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every DragFloat3 overload executes inside a framed window with real
        ///     values, speed, bounds, format and flags.
        /// </summary>
        [MacOsOnly]
        public void DragFloat3_AllOverloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("drag3-window");
                Vector3F v = new Vector3F(1, 1, 1);
                _ = ImGui.DragFloat3("drag3", ref v);
                _ = ImGui.DragFloat3("drag3-speed", ref v, 0.1f);
                _ = ImGui.DragFloat3("drag3-min", ref v, 0.1f, 0.0f);
                _ = ImGui.DragFloat3("drag3-range", ref v, 0.1f, 0.0f, 100.0f);
                _ = ImGui.DragFloat3("drag3-format", ref v, 0.1f, 0.0f, 100.0f, "%.2f");
                _ = ImGui.DragFloat3("drag3-flags", ref v, 0.1f, 0.0f, 100.0f, "%.2f", ImGuiSliderFlags.AlwaysClamp);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every DragFloatRange2 overload executes inside a framed window with real
        ///     values, speed, bounds, formats and flags.
        /// </summary>
        [MacOsOnly]
        public void DragFloatRange2_AllOverloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("drag-range-window");
                float min = 1.0f;
                float max = 2.0f;
                _ = ImGui.DragFloatRange2("range", ref min, ref max);
                _ = ImGui.DragFloatRange2("range-speed", ref min, ref max, 0.1f);
                _ = ImGui.DragFloatRange2("range-min", ref min, ref max, 0.1f, 0.0f);
                _ = ImGui.DragFloatRange2("range-max", ref min, ref max, 0.1f, 0.0f, 100.0f);
                _ = ImGui.DragFloatRange2("range-format", ref min, ref max, 0.1f, 0.0f, 100.0f, "%.2f");
                _ = ImGui.DragFloatRange2("range-format2", ref min, ref max, 0.1f, 0.0f, 100.0f, "%.2f", "%.1f");
                _ = ImGui.DragFloatRange2("range-flags", ref min, ref max, 0.1f, 0.0f, 100.0f, "%.2f", "%.1f", ImGuiSliderFlags.AlwaysClamp);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies the DragInt overload executes inside a framed window with a real value.
        /// </summary>
        [MacOsOnly]
        public void DragInt_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("drag-int-window");
                int v = 5;
                _ = ImGui.DragInt("drag-int", ref v);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every Combo overload executes inside a framed window with a zero
        ///     separated item list and a valid current item index.
        /// </summary>
        [MacOsOnly]
        public void Combo_AllOverloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("combo-window");
                int current = 0;
                _ = ImGui.Combo("combo", ref current, "One\0Two\0Three\0\0");
                _ = ImGui.Combo("combo-height", ref current, "One\0Two\0Three\0\0", 3);
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
