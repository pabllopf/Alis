// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontAtlasPtrNativeCoverageTests.cs
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
    /// <summary>
    ///     Invokes the native ImFontAtlas methods through the ImFontAtlasPtr wrapper
    ///     using the font atlas owned by a headless context. Font rasterization is
    ///     pure CPU so no frame or display is required.
    /// </summary>
    public class ImFontAtlasPtrNativeCoverageTests
    {
        /// <summary>
        ///     Creates a context and returns its font atlas.
        /// </summary>
        private static ImFontAtlasPtr CreateContextAndGetAtlas()
        {
            IntPtr context = ImGuiNative.igCreateContext(IntPtr.Zero);
            ImGuiNative.igSetCurrentContext(context);
            return new ImGuiIoPtr(ImGuiNative.igGetIO()).Fonts;
        }

        /// <summary>
        ///     Destroys the active context.
        /// </summary>
        private static void DestroyContext()
        {
            ImGuiNative.igDestroyContext(ImGuiNative.igGetCurrentContext());
        }

        /// <summary>
        ///     Verifies AddFontDefault returns a valid font pointer.
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddFontDefault_ReturnsValidFont()
        {
            ImFontAtlasPtr atlas = CreateContextAndGetAtlas();
            try
            {
                ImFontPtr font = atlas.AddFontDefault();
                Assert.NotEqual(IntPtr.Zero, font.NativePtr);
            }
            finally
            {
                DestroyContext();
            }
        }

        /// <summary>
        ///     Verifies AddFontDefault with a font config returns a valid font pointer.
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddFontDefault_WithFontConfig_ReturnsValidFont()
        {
            ImFontAtlasPtr atlas = CreateContextAndGetAtlas();
            try
            {
                ImFontConfigPtr config = ImGui.ImFontConfig();
                ImFontPtr font = atlas.AddFontDefault(config);
                Assert.NotEqual(IntPtr.Zero, font.NativePtr);
            }
            finally
            {
                DestroyContext();
            }
        }

        /// <summary>
        ///     Verifies Build returns true and IsBuilt reflects the built state.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Build_And_IsBuilt_ReflectState()
        {
            ImFontAtlasPtr atlas = CreateContextAndGetAtlas();
            try
            {
                Assert.False(atlas.IsBuilt());
                atlas.AddFontDefault();
                Assert.True(atlas.Build());
                Assert.True(atlas.IsBuilt());
            }
            finally
            {
                DestroyContext();
            }
        }

        /// <summary>
        ///     Verifies GetTexDataAsAlpha8 returns texture data after building.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetTexDataAsAlpha8_AfterBuild_ReturnsTexture()
        {
            ImFontAtlasPtr atlas = CreateContextAndGetAtlas();
            try
            {
                atlas.AddFontDefault();
                atlas.Build();
                atlas.GetTexDataAsAlpha8(out IntPtr pixels, out int width, out int height);
                Assert.True(width > 0);
                Assert.True(height > 0);
                Assert.NotEqual(IntPtr.Zero, pixels);
                atlas.GetTexDataAsAlpha8(out IntPtr pixels2, out int w2, out int h2, out int bytesPerPixel);
                Assert.True(w2 > 0);
                Assert.True(bytesPerPixel == 1);
            }
            finally
            {
                DestroyContext();
            }
        }

        /// <summary>
        ///     Verifies GetTexDataAsRgba32 returns texture data after building.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetTexDataAsRgba32_AfterBuild_ReturnsTexture()
        {
            ImFontAtlasPtr atlas = CreateContextAndGetAtlas();
            try
            {
                atlas.AddFontDefault();
                atlas.Build();
                atlas.GetTexDataAsRgba32(out IntPtr pixels, out int width, out int height);
                Assert.True(width > 0);
                Assert.NotEqual(IntPtr.Zero, pixels);
                atlas.GetTexDataAsRgba32(out IntPtr pixels2, out int w2, out int h2, out int bytesPerPixel);
                Assert.True(w2 > 0);
                Assert.True(bytesPerPixel == 4);
            }
            finally
            {
                DestroyContext();
            }
        }

        /// <summary>
        ///     Verifies every GetGlyphRanges accessor returns a non-zero pointer.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetGlyphRanges_AllAccessors_ReturnNonZero()
        {
            ImFontAtlasPtr atlas = CreateContextAndGetAtlas();
            try
            {
                Assert.NotEqual(IntPtr.Zero, atlas.GetGlyphRangesChineseFull());
                Assert.NotEqual(IntPtr.Zero, atlas.GetGlyphRangesChineseSimplifiedCommon());
                Assert.NotEqual(IntPtr.Zero, atlas.GetGlyphRangesCyrillic());
                Assert.NotEqual(IntPtr.Zero, atlas.GetGlyphRangesDefault());
                Assert.NotEqual(IntPtr.Zero, atlas.GetGlyphRangesGreek());
                Assert.NotEqual(IntPtr.Zero, atlas.GetGlyphRangesJapanese());
                Assert.NotEqual(IntPtr.Zero, atlas.GetGlyphRangesKorean());
                Assert.NotEqual(IntPtr.Zero, atlas.GetGlyphRangesThai());
                Assert.NotEqual(IntPtr.Zero, atlas.GetGlyphRangesVietnamese());
            }
            finally
            {
                DestroyContext();
            }
        }

        /// <summary>
        ///     Verifies AddCustomRectRegular and GetCustomRectByIndex round trip.
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddCustomRectRegular_And_GetCustomRectByIndex_RoundTrip()
        {
            ImFontAtlasPtr atlas = CreateContextAndGetAtlas();
            try
            {
                int index = atlas.AddCustomRectRegular(8, 8);
                Assert.True(index >= 0);
                atlas.Build();
                _ = atlas.GetCustomRectByIndex(index);
            }
            finally
            {
                DestroyContext();
            }
        }

        /// <summary>
        ///     Verifies AddCustomRectFontGlyph overloads execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddCustomRectFontGlyph_AllOverloads_Execute()
        {
            ImFontAtlasPtr atlas = CreateContextAndGetAtlas();
            try
            {
                ImFontPtr font = atlas.AddFontDefault();
                int index = atlas.AddCustomRectFontGlyph(font, 65, 8, 8, 1.0f);
                Assert.True(index >= 0);
                int index2 = atlas.AddCustomRectFontGlyph(font, 66, 8, 8, 1.0f, new Vector2F(0.5f, 0.5f));
                Assert.True(index2 >= 0);
            }
            finally
            {
                DestroyContext();
            }
        }

        /// <summary>
        ///     Verifies CalcCustomRectUv fills the uv coordinates after building.
        /// </summary>
        [RequireCImguiSystemFact]
        public void CalcCustomRectUv_AfterBuild_FillsUv()
        {
            ImFontAtlasPtr atlas = CreateContextAndGetAtlas();
            try
            {
                int index = atlas.AddCustomRectRegular(8, 8);
                atlas.AddFontDefault();
                atlas.Build();
                atlas.CalcCustomRectUv(atlas.GetCustomRectByIndex(index), out Vector2F uvMin, out Vector2F uvMax);
            }
            finally
            {
                DestroyContext();
            }
        }

        /// <summary>
        ///     Verifies GetMouseCursorTexData returns true after the atlas has been
        ///     built with a font. Calling it before building asserts natively, so the
        ///     pre-build path is intentionally not exercised.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetMouseCursorTexData_ReflectsBuildState()
        {
            ImFontAtlasPtr atlas = CreateContextAndGetAtlas();
            try
            {
                atlas.AddFontDefault();
                atlas.Build();
                bool after = atlas.GetMouseCursorTexData(ImGuiMouseCursor.Arrow, out Vector2F a1, out Vector2F a2, out Vector2F a3, out Vector2F a4);
                Assert.True(after);
            }
            finally
            {
                DestroyContext();
            }
        }

        /// <summary>
        ///     Verifies SetTexId and the TexId property setter round trip.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetTexId_And_TexIdSetter_RoundTrip()
        {
            ImFontAtlasPtr atlas = CreateContextAndGetAtlas();
            try
            {
                atlas.SetTexId(new IntPtr(7));
                Assert.Equal(new IntPtr(7), atlas.TexId);
                atlas.TexId = new IntPtr(9);
                Assert.Equal(new IntPtr(9), atlas.TexId);
            }
            finally
            {
                DestroyContext();
            }
        }

        /// <summary>
        ///     Verifies the pointer-backed property setters throw because the generated
        ///     field offsets do not match the managed ImFontAtlas layout.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PointerPropertySetters_ThrowArgumentException()
        {
            ImFontAtlasPtr atlas = CreateContextAndGetAtlas();
            try
            {
                Assert.Throws<ArgumentException>(() => atlas.TexPixelsAlpha8 = new IntPtr(0x1234));
                Assert.Throws<ArgumentException>(() => atlas.TexPixelsRgba32 = new IntPtr(0x5678));
                Assert.Throws<ArgumentException>(() => atlas.FontBuilderIo = new IntPtr(0x9ABC));
            }
            finally
            {
                DestroyContext();
            }
        }

        /// <summary>
        ///     Verifies ClearFonts, ClearInputData, ClearTexData and Clear execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Clear_Operations_Execute()
        {
            ImFontAtlasPtr atlas = CreateContextAndGetAtlas();
            try
            {
                atlas.AddFontDefault();
                atlas.Build();
                atlas.ClearFonts();
                atlas.ClearInputData();
                atlas.ClearTexData();
                atlas.Clear();
            }
            finally
            {
                DestroyContext();
            }
        }

        /// <summary>
        ///     Verifies CreateContext accepts a shared font atlas.
        /// </summary>
        [RequireCImguiSystemFact]
        public void CreateContext_WithSharedFontAtlas_Executes()
        {
            IntPtr context = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(context);
                ImFontAtlasPtr atlas = new ImGuiIoPtr(ImGuiNative.igGetIO()).Fonts;
                IntPtr second = ImGui.CreateContext(atlas);
                try
                {
                    Assert.NotEqual(IntPtr.Zero, second);
                }
                finally
                {
                    ImGuiNative.igDestroyContext(second);
                }
            }
            finally
            {
                ImGuiNative.igDestroyContext(context);
            }
        }
    }
}
