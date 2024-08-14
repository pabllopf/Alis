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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    /// The im font config ptr test class
    /// </summary>
    public class ImFontConfigPtrTest
    {
        /// <summary>
        /// Tests that native ptr should be initialized
        /// </summary>
        [Fact]
        public void NativePtr_ShouldBeInitialized()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Equal(IntPtr.Zero, ptr.NativePtr);
        }
        
        /// <summary>
        /// Tests that font data should be initialized
        /// </summary>
        [Fact]
        public void FontData_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.FontData, ptr.FontData);
        }
        
        /// <summary>
        /// Tests that font data size should be initialized
        /// </summary>
        [Fact]
        public void FontDataSize_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.FontDataSize, ptr.FontDataSize);
        }
        
        /// <summary>
        /// Tests that font data owned by atlas should be initialized
        /// </summary>
        [Fact]
        public void FontDataOwnedByAtlas_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.FontDataOwnedByAtlas != 0, ptr.FontDataOwnedByAtlas);
        }
        
        /// <summary>
        /// Tests that font no should be initialized
        /// </summary>
        [Fact]
        public void FontNo_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.FontNo, ptr.FontNo);
        }
        
        /// <summary>
        /// Tests that size pixels should be initialized
        /// </summary>
        [Fact]
        public void SizePixels_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.SizePixels, ptr.SizePixels);
        }
        
        /// <summary>
        /// Tests that oversample h should be initialized
        /// </summary>
        [Fact]
        public void OversampleH_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.OversampleH, ptr.OversampleH);
        }
        
        /// <summary>
        /// Tests that oversample v should be initialized
        /// </summary>
        [Fact]
        public void OversampleV_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.OversampleV, ptr.OversampleV);
        }
        
        /// <summary>
        /// Tests that snap h should be initialized
        /// </summary>
        [Fact]
        public void SnapH_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.SnapH != 0, ptr.SnapH);
        }
        
        /// <summary>
        /// Tests that glyph extra spacing should be initialized
        /// </summary>
        [Fact]
        public void GlyphExtraSpacing_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.GlyphExtraSpacing, ptr.GlyphExtraSpacing);
        }
        
        /// <summary>
        /// Tests that glyph offset should be initialized
        /// </summary>
        [Fact]
        public void GlyphOffset_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.GlyphOffset, ptr.GlyphOffset);
        }
        
        /// <summary>
        /// Tests that glyph ranges should be initialized
        /// </summary>
        [Fact]
        public void GlyphRanges_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.GlyphRanges, ptr.GlyphRanges);
        }
        
        /// <summary>
        /// Tests that glyph min advance x should be initialized
        /// </summary>
        [Fact]
        public void GlyphMinAdvanceX_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.GlyphMinAdvanceX, ptr.GlyphMinAdvanceX);
        }
        
        /// <summary>
        /// Tests that glyph max advance x should be initialized
        /// </summary>
        [Fact]
        public void GlyphMaxAdvanceX_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.GlyphMaxAdvanceX, ptr.GlyphMaxAdvanceX);
        }
        
        /// <summary>
        /// Tests that merge mode should be initialized
        /// </summary>
        [Fact]
        public void MergeMode_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.MergeMode != 0, ptr.MergeMode);
        }
        
        /// <summary>
        /// Tests that font builder flags should be initialized
        /// </summary>
        [Fact]
        public void FontBuilderFlags_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.FontBuilderFlags, ptr.FontBuilderFlags);
        }
        
        /// <summary>
        /// Tests that rasterizer multiply should be initialized
        /// </summary>
        [Fact]
        public void RasterizerMultiply_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.RasterizerMultiply, ptr.RasterizerMultiply);
        }
        
        /// <summary>
        /// Tests that ellipsis char should be initialized
        /// </summary>
        [Fact]
        public void EllipsisChar_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.EllipsisChar, ptr.EllipsisChar);
        }
        
        /// <summary>
        /// Tests that dst font should be initialized
        /// </summary>
        [Fact]
        public void DstFont_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.DstFont, ptr.DstFont.NativePtr);
        }
        
        /// <summary>
        /// Tests that test constructor with native ptr
        /// </summary>
        [Fact]
        public void Test_Constructor_WithNativePtr()
        {
            ImFontPtr result = new ImFontPtr(IntPtr.Zero);
            Assert.Equal(IntPtr.Zero, result.NativePtr);
        }
        
        /// <summary>
        /// Tests that test add glyph v 1
        /// </summary>
        [Fact]
        public void Test_AddGlyph_v1()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ptr.AddGlyph(new ImFontConfigPtr(IntPtr.Zero), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        }
        
        /// <summary>
        /// Tests that test add remap char v 1
        /// </summary>
        [Fact]
        public void Test_AddRemapChar_v1()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ptr.AddRemapChar(0, 0));
        }
        
        /// <summary>
        /// Tests that test add remap char v 2
        /// </summary>
        [Fact]
        public void Test_AddRemapChar_v2()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ptr.AddRemapChar(0, 0, true));
        }
        
        /// <summary>
        /// Tests that test build lookup table
        /// </summary>
        [Fact]
        public void Test_BuildLookupTable()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ptr.BuildLookupTable());
        }
        
        /// <summary>
        /// Tests that test clear output data
        /// </summary>
        [Fact]
        public void Test_ClearOutputData()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ptr.ClearOutputData());
        }
        
        /// <summary>
        /// Tests that test find glyph
        /// </summary>
        [Fact]
        public void Test_FindGlyph()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ptr.FindGlyph(0));
        }
        
        /// <summary>
        /// Tests that test find glyph no fallback
        /// </summary>
        [Fact]
        public void Test_FindGlyphNoFallback()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ptr.FindGlyphNoFallback(0));
        }
        
        /// <summary>
        /// Tests that test get char advance
        /// </summary>
        [Fact]
        public void Test_GetCharAdvance()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ptr.GetCharAdvance(0));
        }
        
        /// <summary>
        /// Tests that test get debug name
        /// </summary>
        [Fact]
        public void Test_GetDebugName()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<MarshalDirectiveException>(() => ptr.GetDebugName());
        }
        
        /// <summary>
        /// Tests that test grow index
        /// </summary>
        [Fact]
        public void Test_GrowIndex()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ptr.GrowIndex(0));
        }
        
        /// <summary>
        /// Tests that test is loaded
        /// </summary>
        [Fact]
        public void Test_IsLoaded()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ptr.IsLoaded());
        }
        
        /// <summary>
        /// Tests that test render char
        /// </summary>
        [Fact]
        public void Test_RenderChar()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ptr.RenderChar(new ImDrawListPtr(IntPtr.Zero), 0, new Vector2(), 0, 0));
        }
        
        /// <summary>
        /// Tests that test set glyph visible
        /// </summary>
        [Fact]
        public void Test_SetGlyphVisible()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ptr.SetGlyphVisible(0, true));
        }
    }
}