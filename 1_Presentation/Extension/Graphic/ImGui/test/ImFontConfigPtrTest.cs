// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontConfigPtrTest.cs
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
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    ///     The im font config ptr test class
    /// </summary>
    	  
	 public class ImFontConfigPtrTest 
    {
        /// <summary>
        ///     Tests that native ptr should be initialized
        /// </summary>
        [Fact]
        public void NativePtr_ShouldBeInitialized()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Equal(IntPtr.Zero, ptr.NativePtr);
        }

        /// <summary>
        ///     Tests that font data should be initialized
        /// </summary>
        [Fact]
        public void FontData_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.FontData, ptr.FontData);
        }

        /// <summary>
        ///     Tests that font data size should be initialized
        /// </summary>
        [Fact]
        public void FontDataSize_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.FontDataSize, ptr.FontDataSize);
        }

        /// <summary>
        ///     Tests that font data owned by atlas should be initialized
        /// </summary>
        [Fact]
        public void FontDataOwnedByAtlas_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.FontDataOwnedByAtlas != 0, ptr.FontDataOwnedByAtlas);
        }

        /// <summary>
        ///     Tests that font no should be initialized
        /// </summary>
        [Fact]
        public void FontNo_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.FontNo, ptr.FontNo);
        }

        /// <summary>
        ///     Tests that size pixels should be initialized
        /// </summary>
        [Fact]
        public void SizePixels_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.SizePixels, ptr.SizePixels);
        }

        /// <summary>
        ///     Tests that oversample h should be initialized
        /// </summary>
        [Fact]
        public void OversampleH_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.OversampleH, ptr.OversampleH);
        }

        /// <summary>
        ///     Tests that oversample v should be initialized
        /// </summary>
        [Fact]
        public void OversampleV_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.OversampleV, ptr.OversampleV);
        }

        /// <summary>
        ///     Tests that snap h should be initialized
        /// </summary>
        [Fact]
        public void SnapH_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.SnapH != 0, ptr.SnapH);
        }

        /// <summary>
        ///     Tests that glyph extra spacing should be initialized
        /// </summary>
        [Fact]
        public void GlyphExtraSpacing_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.GlyphExtraSpacing, ptr.GlyphExtraSpacing);
        }

        /// <summary>
        ///     Tests that glyph offset should be initialized
        /// </summary>
        [Fact]
        public void GlyphOffset_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.GlyphOffset, ptr.GlyphOffset);
        }

        /// <summary>
        ///     Tests that glyph ranges should be initialized
        /// </summary>
        [Fact]
        public void GlyphRanges_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.GlyphRanges, ptr.GlyphRanges);
        }

        /// <summary>
        ///     Tests that glyph min advance x should be initialized
        /// </summary>
        [Fact]
        public void GlyphMinAdvanceX_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.GlyphMinAdvanceX, ptr.GlyphMinAdvanceX);
        }

        /// <summary>
        ///     Tests that glyph max advance x should be initialized
        /// </summary>
        [Fact]
        public void GlyphMaxAdvanceX_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.GlyphMaxAdvanceX, ptr.GlyphMaxAdvanceX);
        }

        /// <summary>
        ///     Tests that merge mode should be initialized
        /// </summary>
        [Fact]
        public void MergeMode_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.MergeMode != 0, ptr.MergeMode);
        }

        /// <summary>
        ///     Tests that font builder flags should be initialized
        /// </summary>
        [Fact]
        public void FontBuilderFlags_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.FontBuilderFlags, ptr.FontBuilderFlags);
        }

        /// <summary>
        ///     Tests that rasterizer multiply should be initialized
        /// </summary>
        [Fact]
        public void RasterizerMultiply_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.RasterizerMultiply, ptr.RasterizerMultiply);
        }

        /// <summary>
        ///     Tests that ellipsis char should be initialized
        /// </summary>
        [Fact]
        public void EllipsisChar_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.EllipsisChar, ptr.EllipsisChar);
        }

        /// <summary>
        ///     Tests that dst font should be initialized
        /// </summary>
        [Fact]
        public void DstFont_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.DstFont, ptr.DstFont.NativePtr);
        }

        /// <summary>
        ///     Tests that test constructor with native ptr
        /// </summary>
        [Fact]
        public void Test_Constructor_WithNativePtr()
        {
            ImFontPtr result = new ImFontPtr(IntPtr.Zero);
            Assert.Equal(IntPtr.Zero, result.NativePtr);
        }

        /// <summary>
        ///     Tests that test add glyph v 1
        /// </summary>
        [Fact]
        public void Test_AddGlyph_v1()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ptr.AddGlyph(new ImFontConfigPtr(IntPtr.Zero), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        }

        /// <summary>
        ///     Tests that test add remap char v 1
        /// </summary>
        [Fact]
        public void Test_AddRemapChar_v1()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ptr.AddRemapChar(0, 0));
        }

        /// <summary>
        ///     Tests that test add remap char v 1
        /// </summary>
        [Fact]
        public void Test_AddRemapChar_v3()
        {
            ImFontPtr ptr = new ImFontPtr(new ImFont());
            Assert.Throws<DllNotFoundException>(() => ptr.AddRemapChar(0, 0));
        }

        /// <summary>
        ///     Tests that test add remap char v 2
        /// </summary>
        [Fact]
        public void Test_AddRemapChar_v2()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ptr.AddRemapChar(0, 0, true));
        }

        /// <summary>
        ///     Tests that test build lookup table
        /// </summary>
        [Fact]
        public void Test_BuildLookupTable()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ptr.BuildLookupTable());
        }

        /// <summary>
        ///     Tests that test clear output data
        /// </summary>
        [Fact]
        public void Test_ClearOutputData()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ptr.ClearOutputData());
        }

        /// <summary>
        ///     Tests that test find glyph
        /// </summary>
        [Fact]
        public void Test_FindGlyph()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ptr.FindGlyph(0));
        }

        /// <summary>
        ///     Tests that test find glyph no fallback
        /// </summary>
        [Fact]
        public void Test_FindGlyphNoFallback()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ptr.FindGlyphNoFallback(0));
        }

        /// <summary>
        ///     Tests that test get char advance
        /// </summary>
        [Fact]
        public void Test_GetCharAdvance()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ptr.GetCharAdvance(0));
        }

        /// <summary>
        ///     Tests that test get debug name
        /// </summary>
        [Fact]
        public void Test_GetDebugName()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<MarshalDirectiveException>(() => ptr.GetDebugName());
        }

        /// <summary>
        ///     Tests that test grow index
        /// </summary>
        [Fact]
        public void Test_GrowIndex()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ptr.GrowIndex(0));
        }

        /// <summary>
        ///     Tests that test is loaded
        /// </summary>
        [Fact]
        public void Test_IsLoaded()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ptr.IsLoaded());
        }

        /// <summary>
        ///     Tests that test render char
        /// </summary>
        [Fact]
        public void Test_RenderChar()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ptr.RenderChar(new ImDrawListPtr(IntPtr.Zero), 0, new Vector2F(), 0, 0));
        }

        /// <summary>
        ///     Tests that test set glyph visible
        /// </summary>
        [Fact]
        public void Test_SetGlyphVisible()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ptr.SetGlyphVisible(0, true));
        }

        /// <summary>
        ///     Tests that implicit conversion to int ptr returns native ptr
        /// </summary>
        [Fact]
        public void ImplicitConversionToIntPtr_ReturnsNativePtr()
        {
            IntPtr nativePtr = new IntPtr(123);
            ImFontPtr fontPtr = new ImFontPtr(nativePtr);
            IntPtr result = fontPtr;
            Assert.Equal(nativePtr, result);
        }

        /// <summary>
        ///     Tests that implicit conversion from int ptr returns im font ptr
        /// </summary>
        [Fact]
        public void ImplicitConversionFromIntPtr_ReturnsImFontPtr()
        {
            IntPtr nativePtr = new IntPtr(123);
            ImFontPtr fontPtr = nativePtr;
            Assert.Equal(nativePtr, fontPtr.NativePtr);
        }


        /// <summary>
        ///     Tests that fallback advance x returns correct value
        /// </summary>
        [Fact]
        public void FallbackAdvanceX_ReturnsCorrectValue()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            ImFont font = new ImFont {FallbackAdvanceX = 1.23f};
            Marshal.StructureToPtr(font, nativePtr, false);
            ImFontPtr fontPtr = new ImFontPtr(nativePtr);
            Assert.Equal(1.23f, fontPtr.FallbackAdvanceX);
            Marshal.FreeHGlobal(nativePtr);
        }

        /// <summary>
        ///     Tests that font size returns correct value
        /// </summary>
        [Fact]
        public void FontSize_ReturnsCorrectValue()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            ImFont font = new ImFont {FontSize = 12.34f};
            Marshal.StructureToPtr(font, nativePtr, false);
            ImFontPtr fontPtr = new ImFontPtr(nativePtr);
            Assert.Equal(12.34f, fontPtr.FontSize);
            Marshal.FreeHGlobal(nativePtr);
        }

        /// <summary>
        ///     Tests that container atlas returns correct value
        /// </summary>
        [Fact]
        public void ContainerAtlas_ReturnsCorrectValue()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            ImFont font = new ImFont {ContainerAtlas = new IntPtr(101112)};
            Marshal.StructureToPtr(font, nativePtr, false);
            ImFontPtr fontPtr = new ImFontPtr(nativePtr);
            Assert.Equal(new IntPtr(101112), fontPtr.ContainerAtlas.NativePtr);
            Marshal.FreeHGlobal(nativePtr);
        }

        /// <summary>
        ///     Tests that config data get and set returns correct value
        /// </summary>
        [Fact]
        public void ConfigData_GetAndSet_ReturnsCorrectValue()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            ImFont font = new ImFont {ConfigData = new IntPtr(131415)};
            Marshal.StructureToPtr(font, nativePtr, false);
            ImFontPtr fontPtr = new ImFontPtr(nativePtr);
            Assert.Equal(new IntPtr(131415), fontPtr.ConfigData.NativePtr);

            ImFontConfigPtr newConfigData = new IntPtr(161718);
            fontPtr.ConfigData = newConfigData;
            Assert.Equal(new IntPtr(161718), fontPtr.ConfigData.NativePtr);
            Marshal.FreeHGlobal(nativePtr);
        }

        /// <summary>
        ///     Tests that config data count returns correct value
        /// </summary>
        [Fact]
        public void ConfigDataCount_ReturnsCorrectValue()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            ImFont font = new ImFont {ConfigDataCount = 5};
            Marshal.StructureToPtr(font, nativePtr, false);
            ImFontPtr fontPtr = new ImFontPtr(nativePtr);
            Assert.Equal(5, fontPtr.ConfigDataCount);
            Marshal.FreeHGlobal(nativePtr);
        }

        /// <summary>
        ///     Tests that fallback char returns correct value
        /// </summary>
        [Fact]
        public void FallbackChar_ReturnsCorrectValue()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            ImFont font = new ImFont {FallbackChar = 1234};
            Marshal.StructureToPtr(font, nativePtr, false);
            ImFontPtr fontPtr = new ImFontPtr(nativePtr);
            Assert.Equal(1234, fontPtr.FallbackChar);
            Marshal.FreeHGlobal(nativePtr);
        }

        /// <summary>
        ///     Tests that ellipsis char returns correct value
        /// </summary>
        [Fact]
        public void EllipsisChar_ReturnsCorrectValue()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            ImFont font = new ImFont {EllipsisChar = 5678};
            Marshal.StructureToPtr(font, nativePtr, false);
            ImFontPtr fontPtr = new ImFontPtr(nativePtr);
            Assert.Equal(5678, fontPtr.EllipsisChar);
            Marshal.FreeHGlobal(nativePtr);
        }

        /// <summary>
        ///     Tests that dot char returns correct value
        /// </summary>
        [Fact]
        public void DotChar_ReturnsCorrectValue()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            ImFont font = new ImFont {DotChar = unchecked((ushort) 91011)};
            Marshal.StructureToPtr(font, nativePtr, false);
            ImFontPtr fontPtr = new ImFontPtr(nativePtr);
            Assert.Equal(25475, fontPtr.DotChar);
            Marshal.FreeHGlobal(nativePtr);
        }

        /// <summary>
        ///     Tests that dirty lookup tables returns correct value
        /// </summary>
        [Fact]
        public void DirtyLookupTables_ReturnsCorrectValue()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            ImFont font = new ImFont {DirtyLookupTables = 1};
            Marshal.StructureToPtr(font, nativePtr, false);
            ImFontPtr fontPtr = new ImFontPtr(nativePtr);
            Assert.True(fontPtr.DirtyLookupTables);
            Marshal.FreeHGlobal(nativePtr);
        }

        /// <summary>
        ///     Tests that scale returns correct value
        /// </summary>
        [Fact]
        public void Scale_ReturnsCorrectValue()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            ImFont font = new ImFont {Scale = 2.34f};
            Marshal.StructureToPtr(font, nativePtr, false);
            ImFontPtr fontPtr = new ImFontPtr(nativePtr);
            Assert.Equal(2.34f, fontPtr.Scale);
            Marshal.FreeHGlobal(nativePtr);
        }

        /// <summary>
        ///     Tests that ascent returns correct value
        /// </summary>
        [Fact]
        public void Ascent_ReturnsCorrectValue()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            ImFont font = new ImFont {Ascent = 3.45f};
            Marshal.StructureToPtr(font, nativePtr, false);
            ImFontPtr fontPtr = new ImFontPtr(nativePtr);
            Assert.Equal(3.45f, fontPtr.Ascent);
            Marshal.FreeHGlobal(nativePtr);
        }

        /// <summary>
        ///     Tests that descent returns correct value
        /// </summary>
        [Fact]
        public void Descent_ReturnsCorrectValue()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            ImFont font = new ImFont {Descent = 4.56f};
            Marshal.StructureToPtr(font, nativePtr, false);
            ImFontPtr fontPtr = new ImFontPtr(nativePtr);
            Assert.Equal(4.56f, fontPtr.Descent);
            Marshal.FreeHGlobal(nativePtr);
        }

        /// <summary>
        ///     Tests that metrics total surface returns correct value
        /// </summary>
        [Fact]
        public void MetricsTotalSurface_ReturnsCorrectValue()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            ImFont font = new ImFont {MetricsTotalSurface = 7890};
            Marshal.StructureToPtr(font, nativePtr, false);
            ImFontPtr fontPtr = new ImFontPtr(nativePtr);
            Assert.Equal(7890, fontPtr.MetricsTotalSurface);
            Marshal.FreeHGlobal(nativePtr);
        }

        /// <summary>
        ///     Tests that index advance x throws dll not found exception
        /// </summary>
        [Fact]
        public void IndexAdvanceX_ThrowsDllNotFoundException()
        {
            ImFontPtr fontPtr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                ImVectorG<float> _ = fontPtr.IndexAdvanceX;
            });
        }

        /// <summary>
        ///     Tests that fallback advance x throws dll not found exception
        /// </summary>
        [Fact]
        public void FallbackAdvanceX_ThrowsDllNotFoundException()
        {
            ImFontPtr fontPtr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                float _ = fontPtr.FallbackAdvanceX;
            });
        }

        /// <summary>
        ///     Tests that font size throws dll not found exception
        /// </summary>
        [Fact]
        public void FontSize_ThrowsDllNotFoundException()
        {
            ImFontPtr fontPtr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                float _ = fontPtr.FontSize;
            });
        }

        /// <summary>
        ///     Tests that index lookup throws dll not found exception
        /// </summary>
        [Fact]
        public void IndexLookup_ThrowsDllNotFoundException()
        {
            ImFontPtr fontPtr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                ImVectorG<ushort> _ = fontPtr.IndexLookup;
            });
        }

        /// <summary>
        ///     Tests that container atlas throws dll not found exception
        /// </summary>
        [Fact]
        public void ContainerAtlas_ThrowsDllNotFoundException()
        {
            ImFontPtr fontPtr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                ImFontAtlasPtr _ = fontPtr.ContainerAtlas;
            });
        }

        /// <summary>
        ///     Tests that config data throws dll not found exception
        /// </summary>
        [Fact]
        public void ConfigData_ThrowsDllNotFoundException()
        {
            ImFontPtr fontPtr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                ImFontConfigPtr _ = fontPtr.ConfigData;
            });
        }

        /// <summary>
        ///     Tests that config data count throws dll not found exception
        /// </summary>
        [Fact]
        public void ConfigDataCount_ThrowsDllNotFoundException()
        {
            ImFontPtr fontPtr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                short _ = fontPtr.ConfigDataCount;
            });
        }

        /// <summary>
        ///     Tests that fallback char throws dll not found exception
        /// </summary>
        [Fact]
        public void FallbackChar_ThrowsDllNotFoundException()
        {
            ImFontPtr fontPtr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                ushort _ = fontPtr.FallbackChar;
            });
        }

        /// <summary>
        ///     Tests that ellipsis char throws dll not found exception
        /// </summary>
        [Fact]
        public void EllipsisChar_ThrowsDllNotFoundException()
        {
            ImFontPtr fontPtr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                ushort _ = fontPtr.EllipsisChar;
            });
        }

        /// <summary>
        ///     Tests that dot char throws dll not found exception
        /// </summary>
        [Fact]
        public void DotChar_ThrowsDllNotFoundException()
        {
            ImFontPtr fontPtr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                ushort _ = fontPtr.DotChar;
            });
        }

        /// <summary>
        ///     Tests that dirty lookup tables throws dll not found exception
        /// </summary>
        [Fact]
        public void DirtyLookupTables_ThrowsDllNotFoundException()
        {
            ImFontPtr fontPtr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                bool _ = fontPtr.DirtyLookupTables;
            });
        }

        /// <summary>
        ///     Tests that scale throws dll not found exception
        /// </summary>
        [Fact]
        public void Scale_ThrowsDllNotFoundException()
        {
            ImFontPtr fontPtr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                float _ = fontPtr.Scale;
            });
        }

        /// <summary>
        ///     Tests that ascent throws dll not found exception
        /// </summary>
        [Fact]
        public void Ascent_ThrowsDllNotFoundException()
        {
            ImFontPtr fontPtr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                float _ = fontPtr.Ascent;
            });
        }

        /// <summary>
        ///     Tests that descent throws dll not found exception
        /// </summary>
        [Fact]
        public void Descent_ThrowsDllNotFoundException()
        {
            ImFontPtr fontPtr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                float _ = fontPtr.Descent;
            });
        }

        /// <summary>
        ///     Tests that metrics total surface throws dll not found exception
        /// </summary>
        [Fact]
        public void MetricsTotalSurface_ThrowsDllNotFoundException()
        {
            ImFontPtr fontPtr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() =>
            {
                int _ = fontPtr.MetricsTotalSurface;
            });
        }
    }
}