// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontGlyphRangesBuilderExecutionTests.cs
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
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Executes the native-backed wrappers of the <see cref="ImFontGlyphRangesBuilder" /> struct against the
    ///     real cimgui library. Each test owns a fresh context destroyed in finally, and every native image copy
    ///     has its GImGui context slot synchronized so the allocator used by the builder is reachable.
    /// </summary>
    public class ImFontGlyphRangesBuilderExecutionTests
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
        ///     Closes a dynamic library handle
        /// </summary>
        /// <param name="handle">The library handle</param>
        /// <returns>The result</returns>
        [DllImport("libSystem.dylib", EntryPoint = "dlclose")]
        private static extern int DlClose(IntPtr handle);

        /// <summary>
        ///     Resolves the address of an exported symbol inside a loaded library
        /// </summary>
        /// <param name="handle">The library handle</param>
        /// <param name="symbol">The symbol name</param>
        /// <returns>The symbol address</returns>
        [DllImport("libSystem.dylib", EntryPoint = "dlsym")]
        private static extern IntPtr Dlsym(IntPtr handle, string symbol);

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
        ///     Synchronizes the ImGui context pointer of every loaded cimgui image so that the allocator used
        ///     by the font glyph ranges builder is visible to all the image copies. The GImGui slot is resolved
        ///     through the exported symbol of each image instead of a hardcoded offset, which varies between
        ///     the x64 and arm64 slices of the native library.
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

                        if (slot != IntPtr.Zero)
                        {
                            Marshal.WriteIntPtr(slot, imgui);
                        }

                        DlClose(handle);
                    }
                }
            }
        }

        /// <summary>
        ///     Verifies that Clear initializes the used chars vector with a zeroed, allocated backing buffer.
        /// </summary>
        [MacOsOnly]
        public void Clear_Then_UsedCharsVector_IsAllocatedAndZeroed()
        {
            IntPtr ctx = CreateContext();
            try
            {
                ImFontGlyphRangesBuilder builder = new ImFontGlyphRangesBuilder();
                builder.Clear();
                Assert.Equal(2048, builder.UsedChars.Size);
                Assert.True(builder.UsedChars.Capacity >= builder.UsedChars.Size);
                Assert.NotEqual(IntPtr.Zero, builder.UsedChars.Data);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies that AddChar sets the bit of the given character so GetBit reports it as used.
        /// </summary>
        [MacOsOnly]
        public void AddChar_Then_GetBit_ReturnsTrue()
        {
            IntPtr ctx = CreateContext();
            try
            {
                ImFontGlyphRangesBuilder builder = new ImFontGlyphRangesBuilder();
                builder.Clear();
                builder.AddChar('A');
                Assert.True(builder.GetBit((uint) 'A'));
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies that SetBit marks the requested bit so GetBit reports it as set.
        /// </summary>
        [MacOsOnly]
        public void SetBit_Then_GetBit_ReturnsTrue()
        {
            IntPtr ctx = CreateContext();
            try
            {
                ImFontGlyphRangesBuilder builder = new ImFontGlyphRangesBuilder();
                builder.Clear();
                builder.SetBit(300u);
                Assert.True(builder.GetBit(300u));
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies that GetBit returns false for a character never added to the builder.
        /// </summary>
        [MacOsOnly]
        public void GetBit_ForUnsetChar_ReturnsFalse()
        {
            IntPtr ctx = CreateContext();
            try
            {
                ImFontGlyphRangesBuilder builder = new ImFontGlyphRangesBuilder();
                builder.Clear();
                builder.AddChar('A');
                Assert.False(builder.GetBit((uint) 'B'));
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies that a second Clear wipes every previously set bit while keeping the vector usable.
        /// </summary>
        [MacOsOnly]
        public void Clear_Then_PreviouslySetBits_AreReset()
        {
            IntPtr ctx = CreateContext();
            try
            {
                ImFontGlyphRangesBuilder builder = new ImFontGlyphRangesBuilder();
                builder.Clear();
                builder.AddChar('A');
                builder.SetBit(300u);
                builder.Clear();
                Assert.False(builder.GetBit((uint) 'A'));
                Assert.False(builder.GetBit(300u));
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies that the UsedChars property can be assigned and read back on a live builder.
        /// </summary>
        [MacOsOnly]
        public void UsedChars_Setter_RoundTripsValue()
        {
            IntPtr ctx = CreateContext();
            try
            {
                ImFontGlyphRangesBuilder builder = new ImFontGlyphRangesBuilder();
                ImVector usedChars = new ImVector(2, 4, IntPtr.Zero);
                builder.UsedChars = usedChars;
                Assert.Equal(2, builder.UsedChars.Size);
                Assert.Equal(4, builder.UsedChars.Capacity);
                Assert.Equal(IntPtr.Zero, builder.UsedChars.Data);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }
    }
}
