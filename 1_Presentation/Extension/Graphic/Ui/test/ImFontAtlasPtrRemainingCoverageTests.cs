// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontAtlasPtrRemainingCoverageTests.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    public class ImFontAtlasPtrRemainingCoverageTests
    {
        [Fact]
        public void Constructor_FromImFontAtlas_ShouldAllocateNonZeroPtr()
        {
            ImFontAtlas source = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            Assert.NotEqual(IntPtr.Zero, ptr.NativePtr);
        }

        [Fact]
        public void Flags_WhenConstructedFromImFontAtlas_ShouldMatchSource()
        {
            ImFontAtlas source = new ImFontAtlas { Flags = ImFontAtlasFlags.NoPowerOfTwoHeight };
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            Assert.Equal(source.Flags, ptr.Flags);
        }

        [Fact]
        public void TexId_WhenConstructedFromImFontAtlas_ShouldMatchSource()
        {
            IntPtr expected = new IntPtr(12345);
            ImFontAtlas source = new ImFontAtlas { TexId = expected };
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            Assert.Equal(expected, ptr.TexId);
        }

        [Fact]
        public void TexId_Set_ShouldUpdateValue()
        {
            ImFontAtlas source = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            IntPtr expected = new IntPtr(9999);
            ptr.TexId = expected;
            Assert.Equal(expected, ptr.TexId);
        }

        [Fact]
        public void TexDesiredWidth_WhenConstructedFromImFontAtlas_ShouldMatchSource()
        {
            ImFontAtlas source = new ImFontAtlas { TexDesiredWidth = 512 };
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            Assert.Equal(512, ptr.TexDesiredWidth);
        }

        [Fact]
        public void TexGlyphPadding_WhenConstructedFromImFontAtlas_ShouldMatchSource()
        {
            ImFontAtlas source = new ImFontAtlas { TexGlyphPadding = 3 };
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            Assert.Equal(3, ptr.TexGlyphPadding);
        }

        [Fact]
        public void Locked_WhenConstructedFromImFontAtlas_ShouldMatchSource()
        {
            ImFontAtlas source = new ImFontAtlas { Locked = 1 };
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            Assert.True(ptr.Locked);
        }

        [Fact]
        public void Locked_WhenConstructedFromImFontAtlasWithZero_ShouldBeFalse()
        {
            ImFontAtlas source = new ImFontAtlas { Locked = 0 };
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            Assert.False(ptr.Locked);
        }

        [Fact]
        public void TexReady_WhenConstructedFromImFontAtlas_ShouldMatchSource()
        {
            ImFontAtlas source = new ImFontAtlas { TexReady = 1 };
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            Assert.True(ptr.TexReady);
        }

        [Fact]
        public void TexReady_WhenConstructedFromImFontAtlasWithZero_ShouldBeFalse()
        {
            ImFontAtlas source = new ImFontAtlas { TexReady = 0 };
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            Assert.False(ptr.TexReady);
        }

        [Fact]
        public void TexPixelsUseColors_WhenConstructedFromImFontAtlas_ShouldMatchSource()
        {
            ImFontAtlas source = new ImFontAtlas { TexPixelsUseColors = 1 };
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            Assert.True(ptr.TexPixelsUseColors);
        }

        [Fact]
        public void TexPixelsUseColors_WhenConstructedFromImFontAtlasWithZero_ShouldBeFalse()
        {
            ImFontAtlas source = new ImFontAtlas { TexPixelsUseColors = 0 };
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            Assert.False(ptr.TexPixelsUseColors);
        }

        [Fact]
        public void TexPixelsAlpha8_WhenConstructedFromImFontAtlas_ShouldMatchSource()
        {
            IntPtr expected = new IntPtr(7777);
            ImFontAtlas source = new ImFontAtlas { TexPixelsAlpha8 = expected };
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            Assert.Equal(expected, ptr.TexPixelsAlpha8);
        }

        [Fact]
        public void TexPixelsRgba32_WhenConstructedFromImFontAtlas_ShouldMatchSource()
        {
            IntPtr expected = new IntPtr(8888);
            ImFontAtlas source = new ImFontAtlas { TexPixelsRgba32 = expected };
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            Assert.Equal(expected, ptr.TexPixelsRgba32);
        }

        [Fact]
        public void TexWidth_WhenConstructedFromImFontAtlas_ShouldMatchSource()
        {
            ImFontAtlas source = new ImFontAtlas { TexWidth = 1024 };
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            Assert.Equal(1024, ptr.TexWidth);
        }

        [Fact]
        public void TexHeight_WhenConstructedFromImFontAtlas_ShouldMatchSource()
        {
            ImFontAtlas source = new ImFontAtlas { TexHeight = 768 };
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            Assert.Equal(768, ptr.TexHeight);
        }

        [Fact]
        public void TexUvScale_WhenConstructedFromImFontAtlas_ShouldMatchSource()
        {
            Vector2F expected = new Vector2F(0.5f, 0.25f);
            ImFontAtlas source = new ImFontAtlas { TexUvScale = expected };
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            Assert.Equal(expected, ptr.TexUvScale);
        }

        [Fact]
        public void TexUvWhitePixel_WhenConstructedFromImFontAtlas_ShouldMatchSource()
        {
            Vector2F expected = new Vector2F(0.75f, 0.125f);
            ImFontAtlas source = new ImFontAtlas { TexUvWhitePixel = expected };
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            Assert.Equal(expected, ptr.TexUvWhitePixel);
        }

        [Fact]
        public void Fonts_WhenConstructedFromImFontAtlas_ShouldReturnWrapper()
        {
            ImFontAtlas source = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            ImVectorG<ImFontPtr> fonts = ptr.Fonts;
            Assert.Equal(source.Fonts.Size, fonts.Size);
            Assert.Equal(source.Fonts.Capacity, fonts.Capacity);
            Assert.Equal(source.Fonts.Data, fonts.Data);
        }

        [Fact]
        public void CustomRects_WhenConstructedFromImFontAtlas_ShouldReturnWrapper()
        {
            ImFontAtlas source = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            ImVectorG<ImFontAtlasCustomRect> rects = ptr.CustomRects;
            Assert.Equal(source.CustomRects.Size, rects.Size);
            Assert.Equal(source.CustomRects.Capacity, rects.Capacity);
            Assert.Equal(source.CustomRects.Data, rects.Data);
        }

        [Fact]
        public void ConfigData_WhenConstructedFromImFontAtlas_ShouldReturnWrapper()
        {
            ImFontAtlas source = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            ImVectorG<ImFontConfigPtr> configs = ptr.ConfigData;
            Assert.Equal(source.ConfigData.Size, configs.Size);
            Assert.Equal(source.ConfigData.Capacity, configs.Capacity);
            Assert.Equal(source.ConfigData.Data, configs.Data);
        }

        [Fact]
        public void FontBuilderIo_WhenConstructedFromImFontAtlas_ShouldMatchSource()
        {
            IntPtr expected = new IntPtr(5555);
            ImFontAtlas source = new ImFontAtlas { FontBuilderIo = expected };
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            Assert.Equal(expected, ptr.FontBuilderIo);
        }

        [Fact]
        public void FontBuilderFlags_WhenConstructedFromImFontAtlas_ShouldMatchSource()
        {
            ImFontAtlas source = new ImFontAtlas { FontBuilderFlags = 7u };
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            Assert.Equal(7u, ptr.FontBuilderFlags);
        }

        [Fact]
        public void PackIdMouseCursors_WhenConstructedFromImFontAtlas_ShouldMatchSource()
        {
            ImFontAtlas source = new ImFontAtlas { PackIdMouseCursors = 42 };
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            Assert.Equal(42, ptr.PackIdMouseCursors);
        }

        [Fact]
        public void PackIdLines_WhenConstructedFromImFontAtlas_ShouldMatchSource()
        {
            ImFontAtlas source = new ImFontAtlas { PackIdLines = 99 };
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            Assert.Equal(99, ptr.PackIdLines);
        }

        [Fact]
        public void MultiplePropertyRoundTrip_ShouldMaintainValues()
        {
            ImFontAtlas source = new ImFontAtlas
            {
                TexDesiredWidth = 256,
                TexGlyphPadding = 2,
                TexWidth = 512,
                TexHeight = 512,
                FontBuilderFlags = 3u,
                PackIdMouseCursors = 10,
                PackIdLines = 20
            };
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(source);
            Assert.Equal(256, ptr.TexDesiredWidth);
            Assert.Equal(2, ptr.TexGlyphPadding);
            Assert.Equal(512, ptr.TexWidth);
            Assert.Equal(512, ptr.TexHeight);
            Assert.Equal(3u, ptr.FontBuilderFlags);
            Assert.Equal(10, ptr.PackIdMouseCursors);
            Assert.Equal(20, ptr.PackIdLines);
        }

        [Fact]
        public void DefaultConstructed_ShouldHaveZeroNativePtr()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr();
            Assert.Equal(IntPtr.Zero, ptr.NativePtr);
        }

        [Fact]
        public void ImplicitConversion_FromIntPtr_ShouldWrapPtr()
        {
            IntPtr expected = new IntPtr(123);
            ImFontAtlasPtr ptr = expected;
            Assert.Equal(expected, ptr.NativePtr);
        }

        [Fact]
        public void ImplicitConversion_ToIntPtr_ShouldReturnNativePtr()
        {
            IntPtr expected = new IntPtr(456);
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(expected);
            IntPtr actual = ptr;
            Assert.Equal(expected, actual);
        }

        [RequireCImguiSystemFact]
        public void AddCustomRectFontGlyph_WithoutOffset_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontPtr font = new ImFontPtr();
            int result = atlas.AddCustomRectFontGlyph(font, 65, 32, 32, 10.0f);
            _ = result;
        }

        [RequireCImguiSystemFact]
        public void AddCustomRectFontGlyph_WithOffset_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontPtr font = new ImFontPtr();
            Vector2F offset = new Vector2F(1.0f, 2.0f);
            int result = atlas.AddCustomRectFontGlyph(font, 65, 32, 32, 10.0f, offset);
            _ = result;
        }

        [RequireCImguiSystemFact]
        public void AddCustomRectRegular_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            int result = atlas.AddCustomRectRegular(64, 64);
            _ = result;
        }

        [RequireCImguiSystemFact]
        public void AddFont_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontConfigPtr cfg = new ImFontConfigPtr();
            ImFontPtr ret = atlas.AddFont(cfg);
            _ = ret;
        }

        [RequireCImguiSystemFact]
        public void AddFontDefault_WithoutParams_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontPtr ret = atlas.AddFontDefault();
            _ = ret;
        }

        [RequireCImguiSystemFact]
        public void AddFontDefault_WithFontCfg_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontConfigPtr cfg = new ImFontConfigPtr();
            ImFontPtr ret = atlas.AddFontDefault(cfg);
            _ = ret;
        }

        [RequireCImguiSystemFact]
        public void AddFontFromFileTtf_WithoutExtra_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontPtr ret = atlas.AddFontFromFileTtf("test.ttf", 16.0f);
            _ = ret;
        }

        [RequireCImguiSystemFact]
        public void AddFontFromFileTtf_WithFontCfg_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontConfigPtr cfg = new ImFontConfigPtr();
            ImFontPtr ret = atlas.AddFontFromFileTtf("test.ttf", 16.0f, cfg);
            _ = ret;
        }

        [RequireCImguiSystemFact]
        public void AddFontFromFileTtf_WithFontCfgAndGlyphRanges_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontConfigPtr cfg = new ImFontConfigPtr();
            ImFontPtr ret = atlas.AddFontFromFileTtf("test.ttf", 16.0f, cfg, new IntPtr());
            _ = ret;
        }

        [RequireCImguiSystemFact]
        public void AddFontFromMemoryCompressedBase85Ttf_WithoutExtra_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontPtr ret = atlas.AddFontFromMemoryCompressedBase85Ttf("data", 16.0f);
            _ = ret;
        }

        [RequireCImguiSystemFact]
        public void AddFontFromMemoryCompressedBase85Ttf_WithFontCfg_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontConfigPtr cfg = new ImFontConfigPtr();
            ImFontPtr ret = atlas.AddFontFromMemoryCompressedBase85Ttf("data", 16.0f, cfg);
            _ = ret;
        }

        [RequireCImguiSystemFact]
        public void AddFontFromMemoryCompressedBase85Ttf_WithFontCfgAndGlyphRanges_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontConfigPtr cfg = new ImFontConfigPtr();
            ImFontPtr ret = atlas.AddFontFromMemoryCompressedBase85Ttf("data", 16.0f, cfg, new IntPtr());
            _ = ret;
        }

        [RequireCImguiSystemFact]
        public void AddFontFromMemoryCompressedTtf_WithoutExtra_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontPtr ret = atlas.AddFontFromMemoryCompressedTtf(new IntPtr(), 100, 16.0f);
            _ = ret;
        }

        [RequireCImguiSystemFact]
        public void AddFontFromMemoryCompressedTtf_WithFontCfg_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontConfigPtr cfg = new ImFontConfigPtr();
            ImFontPtr ret = atlas.AddFontFromMemoryCompressedTtf(new IntPtr(), 100, 16.0f, cfg);
            _ = ret;
        }

        [RequireCImguiSystemFact]
        public void AddFontFromMemoryCompressedTtf_WithFontCfgAndGlyphRanges_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontConfigPtr cfg = new ImFontConfigPtr();
            ImFontPtr ret = atlas.AddFontFromMemoryCompressedTtf(new IntPtr(), 100, 16.0f, cfg, new IntPtr());
            _ = ret;
        }

        [RequireCImguiSystemFact]
        public void AddFontFromMemoryTtf_WithoutExtra_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontPtr ret = atlas.AddFontFromMemoryTtf(new IntPtr(), 100, 16.0f);
            _ = ret;
        }

        [RequireCImguiSystemFact]
        public void AddFontFromMemoryTtf_WithFontCfg_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontConfigPtr cfg = new ImFontConfigPtr();
            ImFontPtr ret = atlas.AddFontFromMemoryTtf(new IntPtr(), 100, 16.0f, cfg);
            _ = ret;
        }

        [RequireCImguiSystemFact]
        public void AddFontFromMemoryTtf_WithFontCfgAndGlyphRanges_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontConfigPtr cfg = new ImFontConfigPtr();
            ImFontPtr ret = atlas.AddFontFromMemoryTtf(new IntPtr(), 100, 16.0f, cfg, new IntPtr());
            _ = ret;
        }

        [RequireCImguiSystemFact]
        public void Build_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            bool result = atlas.Build();
            _ = result;
        }

        [RequireCImguiSystemFact]
        public void CalcCustomRectUv_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontAtlasCustomRect rect = new ImFontAtlasCustomRect();
            atlas.CalcCustomRectUv(rect, out Vector2F min, out Vector2F max);
            _ = min;
            _ = max;
        }

        [RequireCImguiSystemFact]
        public void Clear_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            atlas.Clear();
        }

        [RequireCImguiSystemFact]
        public void ClearFonts_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            atlas.ClearFonts();
        }

        [RequireCImguiSystemFact]
        public void ClearInputData_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            atlas.ClearInputData();
        }

        [RequireCImguiSystemFact]
        public void ClearTexData_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            atlas.ClearTexData();
        }

        [RequireCImguiSystemFact]
        public void GetCustomRectByIndex_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontAtlasCustomRect result = atlas.GetCustomRectByIndex(0);
            _ = result;
        }

        [RequireCImguiSystemFact]
        public void GetGlyphRangesChineseFull_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            IntPtr result = atlas.GetGlyphRangesChineseFull();
            _ = result;
        }

        [RequireCImguiSystemFact]
        public void GetGlyphRangesChineseSimplifiedCommon_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            IntPtr result = atlas.GetGlyphRangesChineseSimplifiedCommon();
            _ = result;
        }

        [RequireCImguiSystemFact]
        public void GetGlyphRangesCyrillic_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            IntPtr result = atlas.GetGlyphRangesCyrillic();
            _ = result;
        }

        [RequireCImguiSystemFact]
        public void GetGlyphRangesDefault_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            IntPtr result = atlas.GetGlyphRangesDefault();
            _ = result;
        }

        [RequireCImguiSystemFact]
        public void GetGlyphRangesGreek_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            IntPtr result = atlas.GetGlyphRangesGreek();
            _ = result;
        }

        [RequireCImguiSystemFact]
        public void GetGlyphRangesJapanese_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            IntPtr result = atlas.GetGlyphRangesJapanese();
            _ = result;
        }

        [RequireCImguiSystemFact]
        public void GetGlyphRangesKorean_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            IntPtr result = atlas.GetGlyphRangesKorean();
            _ = result;
        }

        [RequireCImguiSystemFact]
        public void GetGlyphRangesThai_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            IntPtr result = atlas.GetGlyphRangesThai();
            _ = result;
        }

        [RequireCImguiSystemFact]
        public void GetGlyphRangesVietnamese_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            IntPtr result = atlas.GetGlyphRangesVietnamese();
            _ = result;
        }

        [RequireCImguiSystemFact]
        public void GetMouseCursorTexData_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            bool result = atlas.GetMouseCursorTexData(ImGuiMouseCursor.Arrow, out Vector2F offset, out Vector2F size, out Vector2F border, out Vector2F fill);
            _ = result;
            _ = offset;
            _ = size;
            _ = border;
            _ = fill;
        }

        [RequireCImguiSystemFact]
        public void GetTexDataAsAlpha8_WithByteArray_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            atlas.GetTexDataAsAlpha8(out byte[] pixels, out int w, out int h);
            _ = pixels;
            _ = w;
            _ = h;
        }

        [RequireCImguiSystemFact]
        public void GetTexDataAsAlpha8_WithByteArrayAndBpp_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            atlas.GetTexDataAsAlpha8(out byte[] pixels, out int w, out int h, out int bpp);
            _ = pixels;
            _ = w;
            _ = h;
            _ = bpp;
        }

        [RequireCImguiSystemFact]
        public void GetTexDataAsAlpha8_WithIntPtr_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            atlas.GetTexDataAsAlpha8(out IntPtr pixels, out int w, out int h);
            _ = pixels;
            _ = w;
            _ = h;
        }

        [RequireCImguiSystemFact]
        public void GetTexDataAsAlpha8_WithIntPtrAndBpp_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            atlas.GetTexDataAsAlpha8(out IntPtr pixels, out int w, out int h, out int bpp);
            _ = pixels;
            _ = w;
            _ = h;
            _ = bpp;
        }

        [RequireCImguiSystemFact]
        public void GetTexDataAsRgba32_WithByteArrayAndBpp_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            atlas.GetTexDataAsRgba32(out byte[] pixels, out int w, out int h, out int bpp);
            _ = pixels;
            _ = w;
            _ = h;
            _ = bpp;
        }

        [RequireCImguiSystemFact]
        public void GetTexDataAsRgba32_WithIntPtr_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            atlas.GetTexDataAsRgba32(out IntPtr pixels, out int w, out int h);
            _ = pixels;
            _ = w;
            _ = h;
        }

        [RequireCImguiSystemFact]
        public void GetTexDataAsRgba32_WithIntPtrAndBpp_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            atlas.GetTexDataAsRgba32(out IntPtr pixels, out int w, out int h, out int bpp);
            _ = pixels;
            _ = w;
            _ = h;
            _ = bpp;
        }

        [RequireCImguiSystemFact]
        public void IsBuilt_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            bool result = atlas.IsBuilt();
            _ = result;
        }

        [RequireCImguiSystemFact]
        public void SetTexId_ShouldCallNative()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            atlas.SetTexId(new IntPtr(999));
        }
    }
}
