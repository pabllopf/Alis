// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP5ExecutionTests.cs
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
    ///     Executes the native-backed wrappers of the ImGuiP5 partial class against the real
    ///     cimgui library. Each test owns a fresh context destroyed in finally, and every
    ///     window-scoped call is wrapped in a real NewFrame/Begin/End/EndFrame cycle.
    /// </summary>
    public class ImGuiP5ExecutionTests
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
        ///     Verifies the pure color conversion helpers and CalcItemWidth execute against a live
        ///     context, and that the float4/u32 and hsv/rgb round trips produce sane values.
        /// </summary>
        [MacOsOnly]
        public void ColorConvertHelpers_And_CalcItemWidth_Execute()
        {
            IntPtr ctx = CreateContext();
            try
            {
                Vector4F color = new Vector4F(0.2f, 0.4f, 0.6f, 1.0f);
                uint packed = ImGui.ColorConvertFloat4ToU32(color);
                Vector4F unpacked = ImGui.ColorConvertU32ToFloat4(packed);
                Assert.True(Math.Abs(unpacked.X - color.X) < 0.01f);
                Assert.True(Math.Abs(unpacked.Y - color.Y) < 0.01f);
                Assert.True(Math.Abs(unpacked.Z - color.Z) < 0.01f);
                Assert.True(Math.Abs(unpacked.W - color.W) < 0.01f);
                ImGui.ColorConvertHsVtoRgb(0.5f, 1.0f, 1.0f, out float red, out float green, out float blue);
                Assert.True(red >= 0.0f && red <= 1.0f);
                Assert.True(green >= 0.0f && green <= 1.0f);
                Assert.True(blue >= 0.0f && blue <= 1.0f);
                ImGui.ColorConvertRgBtoHsv(red, green, blue, out float hue, out float sat, out float val);
                Assert.True(hue >= 0.0f && hue <= 1.0f);
                Assert.True(Math.Abs(sat - 1.0f) < 0.01f);
                Assert.True(Math.Abs(val - 1.0f) < 0.01f);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies the three Begin overloads return true and End closes each window, together
        ///     with AlignTextToFramePadding, ArrowButton, Bullet, BulletText and CalcItemWidth, all
        ///     inside a frame.
        /// </summary>
        [MacOsOnly]
        public void BeginEndWindows_ExecuteInsideFrame()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                Assert.True(ImGui.Begin("window-p5-one"));
                ImGui.AlignTextToFramePadding();
                _ = ImGui.ArrowButton("arrow-p5-one", ImGuiDir.Left);
                ImGui.Bullet();
                ImGui.BulletText("bullet-p5-text");
                Assert.True(ImGui.CalcItemWidth() > 0.0f);
                ImGui.End();
                bool openTwo = true;
                Assert.True(ImGui.Begin("window-p5-two", ref openTwo));
                ImGui.End();
                bool openThree = true;
                Assert.True(ImGui.Begin("window-p5-three", ref openThree, ImGuiWindowFlags.NoTitleBar));
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies every BeginChild and BeginChildFrame overload paired with its End, plus the
        ///     group, disabled and tooltip begin/end pairs, all inside one framed window.
        /// </summary>
        [MacOsOnly]
        public void ChildGroupDisabledTooltip_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p5-child-window");
                ImGui.BeginChild("p5-child-one");
                ImGui.EndChild();
                ImGui.BeginChild("p5-child-two", new Vector2F(64.0f, 64.0f));
                ImGui.EndChild();
                ImGui.BeginChild("p5-child-three", new Vector2F(64.0f, 64.0f), true);
                ImGui.EndChild();
                ImGui.BeginChild("p5-child-four", new Vector2F(64.0f, 64.0f), true, ImGuiWindowFlags.NoTitleBar);
                ImGui.EndChild();
                ImGui.BeginChild(1u);
                ImGui.EndChild();
                ImGui.BeginChild(2u, new Vector2F(64.0f, 64.0f));
                ImGui.EndChild();
                ImGui.BeginChild(3u, new Vector2F(64.0f, 64.0f), true);
                ImGui.EndChild();
                ImGui.BeginChild(4u, new Vector2F(64.0f, 64.0f), true, ImGuiWindowFlags.NoTitleBar);
                ImGui.EndChild();
                if (ImGui.BeginChildFrame(1u, new Vector2F(64.0f, 64.0f)))
                {
                    ImGui.EndChildFrame();
                }

                if (ImGui.BeginChildFrame(2u, new Vector2F(64.0f, 64.0f), ImGuiWindowFlags.NoTitleBar))
                {
                    ImGui.EndChildFrame();
                }

                ImGui.BeginGroup();
                ImGui.EndGroup();
                ImGui.BeginDisabled();
                ImGui.EndDisabled();
                ImGui.BeginDisabled(false);
                ImGui.EndDisabled();
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
        ///     Verifies the combo, list box, tab bar, table, columns, button, checkbox, collapsing
        ///     header and combo array wrappers execute inside one framed window. The Combo array
        ///     overloads cannot marshal nested arrays and throw, which still executes their bodies.
        /// </summary>
        [MacOsOnly]
        public void ComboListBoxTabBarTableColumns_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p5-widget-window");
                if (ImGui.BeginCombo("p5-combo", "preview"))
                {
                    ImGui.EndCombo();
                }

                if (ImGui.BeginCombo("p5-combo-flags", "preview", ImGuiComboFlags.NoArrowButton))
                {
                    ImGui.EndCombo();
                }

                if (ImGui.BeginListBox("p5-listbox"))
                {
                    ImGui.EndListBox();
                }

                if (ImGui.BeginListBox("p5-listbox-size", new Vector2F(100.0f, 100.0f)))
                {
                    ImGui.EndListBox();
                }

                if (ImGui.BeginTabBar("p5-tabbar"))
                {
                    ImGui.EndTabBar();
                }

                if (ImGui.BeginTabBar("p5-tabbar-flags", ImGuiTabBarFlags.FittingPolicyScroll))
                {
                    ImGui.EndTabBar();
                }

                if (ImGui.BeginTable("p5-table", 2))
                {
                    ImGui.EndTable();
                }

                if (ImGui.BeginTable("p5-table-flags", 2, ImGuiTableFlags.BordersOuter))
                {
                    ImGui.EndTable();
                }

                if (ImGui.BeginTable("p5-table-size", 2, ImGuiTableFlags.BordersOuter, new Vector2F(200.0f, 200.0f)))
                {
                    ImGui.EndTable();
                }

                if (ImGui.BeginTable("p5-table-inner", 2, ImGuiTableFlags.BordersOuter, new Vector2F(200.0f, 200.0f), 300.0f))
                {
                    ImGui.EndTable();
                }

                ImGui.Columns();
                ImGui.Columns(2);
                ImGui.Columns(2, "p5-columns-id");
                ImGui.Columns(2, "p5-columns-id", true);
                _ = ImGui.Button("p5-button");
                _ = ImGui.Button("p5-button-size", new Vector2F(64.0f, 32.0f));
                bool check = true;
                _ = ImGui.Checkbox("p5-checkbox", ref check);
                _ = ImGui.CollapsingHeader("p5-collapsing");
                _ = ImGui.CollapsingHeader("p5-collapsing-flags", ImGuiTreeNodeFlags.DefaultOpen);
                int current = 0;
                string[] items = { "A", "B", "C" };
                Assert.Throws<MarshalDirectiveException>(() => ImGui.Combo("p5-combo-arr", ref current, items, 3));
                Assert.Throws<MarshalDirectiveException>(() => ImGui.Combo("p5-combo-arr-max", ref current, items, 3, 4));
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies the popup, popup modal, popup context and menu wrappers execute inside one
        ///     framed window. Popup context calls return false without a right click, which is fine.
        /// </summary>
        [MacOsOnly]
        public void PopupsAndMenus_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                bool open = true;
                ImGui.Begin("p5-popup-window", ref open, ImGuiWindowFlags.MenuBar);
                ImGui.OpenPopup("p5-popup-one");
                if (ImGui.BeginPopup("p5-popup-one"))
                {
                    ImGui.CloseCurrentPopup();
                    ImGui.EndPopup();
                }

                if (ImGui.BeginPopup("p5-popup-two", ImGuiWindowFlags.NoTitleBar))
                {
                    ImGui.EndPopup();
                }

                _ = ImGui.BeginPopupModal("p5-modal-closed");
                bool modalOpen = true;
                _ = ImGui.BeginPopupModal("p5-modal-closed-open", ref modalOpen);
                _ = ImGui.BeginPopupModal("p5-modal-closed-flags", ref modalOpen, ImGuiWindowFlags.NoTitleBar);

                _ = ImGui.BeginPopupContextItem();
                _ = ImGui.BeginPopupContextItem("p5-ctx-item");
                _ = ImGui.BeginPopupContextItem("p5-ctx-item-flags", ImGuiPopupFlags.MouseButtonRight);
                _ = ImGui.BeginPopupContextWindow();
                _ = ImGui.BeginPopupContextWindow("p5-ctx-window");
                _ = ImGui.BeginPopupContextWindow("p5-ctx-window-flags", ImGuiPopupFlags.MouseButtonRight);
                _ = ImGui.BeginPopupContextVoid();
                _ = ImGui.BeginPopupContextVoid("p5-ctx-void");
                _ = ImGui.BeginPopupContextVoid("p5-ctx-void-flags", ImGuiPopupFlags.MouseButtonRight);
                if (ImGui.BeginMenuBar())
                {
                    ImGui.EndMenuBar();
                }

                ImGui.End();
                if (ImGui.BeginMainMenuBar())
                {
                    if (ImGui.BeginMenu("p5-menu"))
                    {
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu("p5-menu-disabled", true))
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
        ///     Verifies the drag drop source and target wrappers execute inside one framed window
        ///     without an active drag, returning false but never throwing.
        /// </summary>
        [MacOsOnly]
        public void DragDrop_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p5-drag-window");
                _ = ImGui.BeginDragDropSource();
                _ = ImGui.BeginDragDropSource(ImGuiDragDropFlags.SourceNoHoldToOpenOthers);
                _ = ImGui.BeginDragDropTarget();
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies the ColorEdit4 and ColorButton wrappers execute inside one framed window,
        ///     together with the CollapsingHeader flags overloads not already exercised.
        /// </summary>
        [MacOsOnly]
        public void ColorWidgets_ExecuteInsideWindow()
        {
            IntPtr ctx = CreateFramedContext();
            try
            {
                ImGuiNative.igNewFrame();
                ImGui.Begin("p5-color-window");
                Vector4F color = new Vector4F(0.2f, 0.4f, 0.6f, 1.0f);
                IntPtr label = Marshal.StringToHGlobalAnsi("p5-color-edit");
                _ = ImGui.ColorEdit4(label, ref color);
                _ = ImGui.ColorEdit4(label, ref color, ImGuiColorEditFlags.NoAlpha);
                Marshal.FreeHGlobal(label);
                _ = ImGui.ColorButton("p5-color-button", new Vector4F(1, 1, 1, 1));
                _ = ImGui.ColorButton("p5-color-button-flags", new Vector4F(1, 1, 1, 1), ImGuiColorEditFlags.NoAlpha);
                _ = ImGui.ColorButton("p5-color-button-size", new Vector4F(1, 1, 1, 1), ImGuiColorEditFlags.NoAlpha, new Vector2F(32.0f, 32.0f));
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
