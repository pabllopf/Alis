// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP3RemainingCoverageExecutionTests.cs
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
    ///     Executes the remaining native-backed wrappers of the ImGuiP3 partial class against the
    ///     real cimgui library. Each test owns a fresh context destroyed in finally, and every
    ///     window-scoped call is wrapped in a real NewFrame/Begin/End/EndFrame cycle.
    /// </summary>
    public class ImGuiP3RemainingCoverageExecutionTests
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
        ///     Computes the native ImGui id hash of a string using the cimgui helper.
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="dataSize">The data size</param>
        /// <param name="seed">The seed</param>
        /// <returns>The uint</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl, EntryPoint = "igImHashStr")]
        private static extern uint NativeImHashStr(byte[] data, UIntPtr dataSize, uint seed);

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
        ///     Verifies the EndCombo wrapper executes when the combo popup is forced open through a
        ///     prior-frame OpenPopup call inside a framed window.
        /// </summary>
        [MacOsOnly]
        public void EndCombo_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                uint widgetId = 0;
                uint popupId = 0;
                ImGuiNative.igNewFrame();
                ImGui.Begin("p3-combo-window");
                widgetId = ImGuiNative.igGetID_Str(Encoding.UTF8.GetBytes("p3-combo"));
                popupId = NativeImHashStr(Encoding.UTF8.GetBytes("##ComboPopup"), UIntPtr.Zero, widgetId);
                ImGui.OpenPopup(popupId);
                if (ImGui.BeginCombo("p3-combo", "preview"))
                {
                    ImGui.EndCombo();
                }

                ImGui.End();
                ImGuiNative.igEndFrame();

                ImGuiNative.igNewFrame();
                ImGui.Begin("p3-combo-window");
                if (ImGui.BeginCombo("p3-combo", "preview"))
                {
                    ImGui.EndCombo();
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
        ///     Verifies the EndMenu wrapper executes when the menu popup is forced open through a
        ///     prior-frame OpenPopup call inside a framed menu bar window.
        /// </summary>
        [MacOsOnly]
        public void EndMenu_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                bool open = true;
                ImGuiNative.igNewFrame();
                ImGui.Begin("p3-menu-window", ref open, ImGuiWindowFlags.MenuBar);
                if (ImGui.BeginMenuBar())
                {
                    ImGui.OpenPopup("p3-menu");
                    if (ImGui.BeginMenu("p3-menu"))
                    {
                        ImGui.EndMenu();
                    }

                    ImGui.EndMenuBar();
                }

                ImGui.End();
                ImGuiNative.igEndFrame();

                ImGuiNative.igNewFrame();
                ImGui.Begin("p3-menu-window", ref open, ImGuiWindowFlags.MenuBar);
                if (ImGui.BeginMenuBar())
                {
                    if (ImGui.BeginMenu("p3-menu"))
                    {
                        ImGui.EndMenu();
                    }

                    ImGui.EndMenuBar();
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
        ///     Verifies the column query wrappers execute inside a framed window.
        /// </summary>
        [MacOsOnly]
        public void ColumnQueries_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p3-column-window");
                _ = ImGui.GetColumnIndex();
                _ = ImGui.GetColumnOffset();
                _ = ImGui.GetColumnOffset(0);
                _ = ImGui.GetColumnsCount();
                _ = ImGui.GetColumnWidth();
                _ = ImGui.GetColumnWidth(0);
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
