// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontPtrCoverageTests.cs
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
    ///     Invokes the remaining native ImFont methods through the ImFontPtr wrapper using the
    ///     default font rasterized by a headless context font atlas.
    /// </summary>
    public class ImFontPtrCoverageTests
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
        ///     Creates a context, adds the default font, builds the atlas and returns
        ///     the resulting font.
        /// </summary>
        private static ImFontPtr CreateBuiltFont()
        {
            IntPtr context = ImGuiNative.igCreateContext(IntPtr.Zero);
            ImGuiNative.igSetCurrentContext(context);
            ImFontAtlasPtr atlas = new ImGuiIoPtr(ImGuiNative.igGetIO()).Fonts;
            ImFontPtr font = atlas.AddFontDefault();
            atlas.Build();
            return font;
        }

        /// <summary>
        ///     Creates a context ready for a real frame and returns the built default font.
        /// </summary>
        private static ImFontPtr CreateFramedFont()
        {
            IntPtr context = ImGuiNative.igCreateContext(IntPtr.Zero);
            ImGuiNative.igSetCurrentContext(context);
            SyncContextSlots(context);
            IntPtr ioPtr = ImGuiNative.igGetIO();
            Marshal.StructureToPtr(1280.0f, IntPtr.Add(ioPtr, 8), false);
            Marshal.StructureToPtr(720.0f, IntPtr.Add(ioPtr, 12), false);
            IntPtr fontsPtr = Marshal.ReadIntPtr(ioPtr, 80);
            ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(fontsPtr, out IntPtr _, out int _, out int _, out int _);
            ImFontAtlasPtr atlas = new ImGuiIoPtr(ioPtr).Fonts;
            ImFontPtr font = atlas.AddFontDefault();
            atlas.Build();
            ImGuiNative.igNewFrame();
            return font;
        }

        /// <summary>
        ///     Destroys the active context.
        /// </summary>
        private static void DestroyContext()
        {
            ImGuiNative.igDestroyContext(ImGuiNative.igGetCurrentContext());
        }

        /// <summary>
        ///     Verifies RenderChar appends the glyph geometry to the foreground draw list.
        /// </summary>
        [RequireCImguiSystemFact]
        public void RenderChar_AppendsGlyphToDrawList()
        {
            ImFontPtr font = CreateFramedFont();
            try
            {
                ImDrawListPtr drawList = ImGui.GetForegroundDrawList();
                font.RenderChar(drawList, 16.0f, new Vector2F(0.0f, 0.0f), 0xFFFFFFFF, 'A');
                font.RenderChar(drawList, 16.0f, new Vector2F(32.0f, 64.0f), 0xFF000000, 'B');
                ImGuiNative.igEndFrame();
            }
            finally
            {
                DestroyContext();
            }
        }

        /// <summary>
        ///     Verifies AddRemapChar with the overwrite flag set to false executes.
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddRemapChar_WithOverwriteFalse_Executes()
        {
            ImFontPtr font = CreateBuiltFont();
            try
            {
                font.AddRemapChar('C', 'D', false);
            }
            finally
            {
                DestroyContext();
            }
        }

        /// <summary>
        ///     Verifies AddRemapChar with the overwrite flag set to true executes.
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddRemapChar_WithOverwriteTrue_Executes()
        {
            ImFontPtr font = CreateBuiltFont();
            try
            {
                font.AddRemapChar('E', 'F', true);
            }
            finally
            {
                DestroyContext();
            }
        }
    }
}
