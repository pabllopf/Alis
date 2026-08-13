// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP8ExecutionTests.cs
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
    ///     Executes the native-backed wrappers of the ImGuiP8 partial class against the real
    ///     cimgui library. Each test owns a fresh context destroyed in finally, and every
    ///     window-scoped call is wrapped in a real NewFrame/Begin/End/EndFrame cycle.
    /// </summary>
    public class ImGuiP8ExecutionTests
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
        ///     Verifies every Show window wrapper without a pOpen argument and every Show window
        ///     wrapper with a ref bool pOpen argument executes inside a framed host window.
        /// </summary>
        [MacOsOnly]
        public void ShowWindows_AllOverloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("show-window");
                bool open = true;
                ImGui.ShowAboutWindow();
                ImGui.ShowAboutWindow(ref open);
                ImGui.ShowDebugLogWindow();
                ImGui.ShowDebugLogWindow(ref open);
                ImGui.ShowMetricsWindow();
                ImGui.ShowMetricsWindow(ref open);
                ImGui.ShowStackToolWindow();
                ImGui.ShowStackToolWindow(ref open);
                ImGui.ShowUserGuide();
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies the ShowDemoWindow wrappers execute inside a framed host window and the
        ///     ref bool argument round-trips through the native pointer.
        /// </summary>
        [MacOsOnly]
        public void ShowDemoWindow_AllOverloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("demo-window");
                ImGui.ShowDemoWindow();
                bool open = true;
                ImGui.ShowDemoWindow(ref open);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies ShowStyleEditor with and without a style argument and the ShowStyleSelector
        ///     and ShowFontSelector label wrappers execute inside a framed host window.
        /// </summary>
        [MacOsOnly]
        public void StyleAndFontSelectors_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("style-window");
                ImGui.ShowStyleEditor();
                ImGui.ShowStyleEditor(new ImGuiStyle());
                _ = ImGui.ShowStyleSelector("Style Selector");
                ImGui.ShowFontSelector("Font Selector");
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every SliderAngle overload executes inside a framed host window with the
        ///     value passed by reference and the returned bool discarded.
        /// </summary>
        [MacOsOnly]
        public void SliderAngle_AllOverloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("slider-angle-window");
                float value = 45.0f;
                _ = ImGui.SliderAngle("angle", ref value);
                _ = ImGui.SliderAngle("angle-min", ref value, 0.0f);
                _ = ImGui.SliderAngle("angle-range", ref value, 0.0f, 180.0f);
                _ = ImGui.SliderAngle("angle-format", ref value, 0.0f, 180.0f, "%.2f rad");
                _ = ImGui.SliderAngle("angle-flags", ref value, 0.0f, 180.0f, "%.2f rad", ImGuiSliderFlags.AlwaysClamp);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every SliderFloat overload executes inside a framed host window with the
        ///     value passed by reference and the returned bool discarded.
        /// </summary>
        [MacOsOnly]
        public void SliderFloat_AllOverloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("slider-float-window");
                float value = 0.5f;
                _ = ImGui.SliderFloat("float", ref value, 0.0f, 1.0f);
                _ = ImGui.SliderFloat("float-format", ref value, 0.0f, 1.0f, "%.2f");
                _ = ImGui.SliderFloat("float-flags", ref value, 0.0f, 1.0f, "%.2f", ImGuiSliderFlags.AlwaysClamp);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every SliderFloat2 overload executes inside a framed host window with the
        ///     value passed by reference and the returned bool discarded.
        /// </summary>
        [MacOsOnly]
        public void SliderFloat2_AllOverloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("slider-float2-window");
                Vector2F value = new Vector2F(0.5f, 0.5f);
                _ = ImGui.SliderFloat2("float2", ref value, 0.0f, 1.0f);
                _ = ImGui.SliderFloat2("float2-format", ref value, 0.0f, 1.0f, "%.2f");
                _ = ImGui.SliderFloat2("float2-flags", ref value, 0.0f, 1.0f, "%.2f", ImGuiSliderFlags.AlwaysClamp);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every SliderFloat3 overload executes inside a framed host window with the
        ///     value passed by reference and the returned bool discarded.
        /// </summary>
        [MacOsOnly]
        public void SliderFloat3_AllOverloads_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("slider-float3-window");
                Vector3F value = new Vector3F(0.5f, 0.5f, 0.5f);
                _ = ImGui.SliderFloat3("float3", ref value, 0.0f, 1.0f);
                _ = ImGui.SliderFloat3("float3-format", ref value, 0.0f, 1.0f, "%.2f");
                _ = ImGui.SliderFloat3("float3-flags", ref value, 0.0f, 1.0f, "%.2f", ImGuiSliderFlags.AlwaysClamp);
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
