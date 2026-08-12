// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// The ImFontAtlasPtr remaining coverage tests class
    /// </summary>
    public class ImFontAtlasPtrRemainingCoverageTests
    {
        /// <summary>
        /// Tests that AddCustomRectFontGlyph throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddCustomRectFontGlyph_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddCustomRectFontGlyph(default(ImFontPtr), default(ushort), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddCustomRectFontGlyph throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddCustomRectFontGlyph_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddCustomRectFontGlyph(default(ImFontPtr), default(ushort), 0, 0, 0, default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that AddCustomRectRegular throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddCustomRectRegular_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddCustomRectRegular(0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddFont throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddFont_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddFont(default(ImFontConfigPtr)); });
            }
        }

        /// <summary>
        /// Tests that AddFontDefault throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddFontDefault_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddFontDefault(); });
            }
        }

        /// <summary>
        /// Tests that AddFontDefault throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddFontDefault_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddFontDefault(default(ImFontConfigPtr)); });
            }
        }

        /// <summary>
        /// Tests that AddFontFromFileTtf throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddFontFromFileTtf_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddFontFromFileTtf("label", 0); });
            }
        }

        /// <summary>
        /// Tests that AddFontFromFileTtf throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddFontFromFileTtf_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddFontFromFileTtf("label", 0, default(ImFontConfigPtr)); });
            }
        }

        /// <summary>
        /// Tests that AddFontFromFileTtf throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddFontFromFileTtf_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddFontFromFileTtf("label", 0, default(ImFontConfigPtr), IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that AddFontFromMemoryCompressedBase85Ttf throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddFontFromMemoryCompressedBase85Ttf_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddFontFromMemoryCompressedBase85Ttf("label", 0); });
            }
        }

        /// <summary>
        /// Tests that AddFontFromMemoryCompressedBase85Ttf throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddFontFromMemoryCompressedBase85Ttf_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddFontFromMemoryCompressedBase85Ttf("label", 0, default(ImFontConfigPtr)); });
            }
        }

        /// <summary>
        /// Tests that AddFontFromMemoryCompressedBase85Ttf throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddFontFromMemoryCompressedBase85Ttf_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddFontFromMemoryCompressedBase85Ttf("label", 0, default(ImFontConfigPtr), IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that AddFontFromMemoryCompressedTtf throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddFontFromMemoryCompressedTtf_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddFontFromMemoryCompressedTtf(IntPtr.Zero, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddFontFromMemoryCompressedTtf throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddFontFromMemoryCompressedTtf_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddFontFromMemoryCompressedTtf(IntPtr.Zero, 0, 0, default(ImFontConfigPtr)); });
            }
        }

        /// <summary>
        /// Tests that AddFontFromMemoryCompressedTtf throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddFontFromMemoryCompressedTtf_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddFontFromMemoryCompressedTtf(IntPtr.Zero, 0, 0, default(ImFontConfigPtr), IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that AddFontFromMemoryTtf throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddFontFromMemoryTtf_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddFontFromMemoryTtf(IntPtr.Zero, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddFontFromMemoryTtf throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddFontFromMemoryTtf_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddFontFromMemoryTtf(IntPtr.Zero, 0, 0, default(ImFontConfigPtr)); });
            }
        }

        /// <summary>
        /// Tests that AddFontFromMemoryTtf throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddFontFromMemoryTtf_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddFontFromMemoryTtf(IntPtr.Zero, 0, 0, default(ImFontConfigPtr), IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that Build throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Build_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.Build(); });
            }
        }

        /// <summary>
        /// Tests that CalcCustomRectUv throws when native library is unavailable
        /// </summary>
        [Fact]
        public void CalcCustomRectUv_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); Vector2F outUvMin = default; Vector2F outUvMax = default;
                Assert.Throws<DllNotFoundException>(() => { instance.CalcCustomRectUv(default(ImFontAtlasCustomRect), out outUvMin, out outUvMax); });
            }
        }

        /// <summary>
        /// Tests that Clear throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Clear_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.Clear(); });
            }
        }

        /// <summary>
        /// Tests that ClearFonts throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ClearFonts_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.ClearFonts(); });
            }
        }

        /// <summary>
        /// Tests that ClearInputData throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ClearInputData_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.ClearInputData(); });
            }
        }

        /// <summary>
        /// Tests that ClearTexData throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ClearTexData_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.ClearTexData(); });
            }
        }

        /// <summary>
        /// Tests that GetCustomRectByIndex throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetCustomRectByIndex_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.GetCustomRectByIndex(0); });
            }
        }

        /// <summary>
        /// Tests that GetGlyphRangesChineseFull throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetGlyphRangesChineseFull_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.GetGlyphRangesChineseFull(); });
            }
        }

        /// <summary>
        /// Tests that GetGlyphRangesChineseSimplifiedCommon throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetGlyphRangesChineseSimplifiedCommon_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.GetGlyphRangesChineseSimplifiedCommon(); });
            }
        }

        /// <summary>
        /// Tests that GetGlyphRangesCyrillic throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetGlyphRangesCyrillic_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.GetGlyphRangesCyrillic(); });
            }
        }

        /// <summary>
        /// Tests that GetGlyphRangesDefault throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetGlyphRangesDefault_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.GetGlyphRangesDefault(); });
            }
        }

        /// <summary>
        /// Tests that GetGlyphRangesGreek throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetGlyphRangesGreek_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.GetGlyphRangesGreek(); });
            }
        }

        /// <summary>
        /// Tests that GetGlyphRangesJapanese throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetGlyphRangesJapanese_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.GetGlyphRangesJapanese(); });
            }
        }

        /// <summary>
        /// Tests that GetGlyphRangesKorean throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetGlyphRangesKorean_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.GetGlyphRangesKorean(); });
            }
        }

        /// <summary>
        /// Tests that GetGlyphRangesThai throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetGlyphRangesThai_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.GetGlyphRangesThai(); });
            }
        }

        /// <summary>
        /// Tests that GetGlyphRangesVietnamese throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetGlyphRangesVietnamese_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.GetGlyphRangesVietnamese(); });
            }
        }

        /// <summary>
        /// Tests that GetMouseCursorTexData throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetMouseCursorTexData_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); Vector2F outOffset = default; Vector2F outSize = default; Vector2F outUvBorder = default; Vector2F outUvFill = default;
                Assert.Throws<DllNotFoundException>(() => { instance.GetMouseCursorTexData(0, out outOffset, out outSize, out outUvBorder, out outUvFill); });
            }
        }

        /// <summary>
        /// Tests that GetTexDataAsAlpha8 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetTexDataAsAlpha8_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); byte[] outPixels = default; int outWidth = default; int outHeight = default;
                Assert.Throws<DllNotFoundException>(() => { instance.GetTexDataAsAlpha8(out outPixels, out outWidth, out outHeight); });
            }
        }

        /// <summary>
        /// Tests that GetTexDataAsAlpha8 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetTexDataAsAlpha8_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); byte[] outPixels = default; int outWidth = default; int outHeight = default; int outBytesPerPixel = default;
                Assert.Throws<DllNotFoundException>(() => { instance.GetTexDataAsAlpha8(out outPixels, out outWidth, out outHeight, out outBytesPerPixel); });
            }
        }

        /// <summary>
        /// Tests that GetTexDataAsAlpha8 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetTexDataAsAlpha8_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); IntPtr outPixels = default; int outWidth = default; int outHeight = default;
                Assert.Throws<DllNotFoundException>(() => { instance.GetTexDataAsAlpha8(out outPixels, out outWidth, out outHeight); });
            }
        }

        /// <summary>
        /// Tests that GetTexDataAsAlpha8 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetTexDataAsAlpha8_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); IntPtr outPixels = default; int outWidth = default; int outHeight = default; int outBytesPerPixel = default;
                Assert.Throws<DllNotFoundException>(() => { instance.GetTexDataAsAlpha8(out outPixels, out outWidth, out outHeight, out outBytesPerPixel); });
            }
        }

        /// <summary>
        /// Tests that GetTexDataAsRgba32 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetTexDataAsRgba32_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); byte[] outPixels = default; int outWidth = default; int outHeight = default; int outBytesPerPixel = default;
                Assert.Throws<DllNotFoundException>(() => { instance.GetTexDataAsRgba32(out outPixels, out outWidth, out outHeight, out outBytesPerPixel); });
            }
        }

        /// <summary>
        /// Tests that GetTexDataAsRgba32 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetTexDataAsRgba32_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); IntPtr outPixels = default; int outWidth = default; int outHeight = default;
                Assert.Throws<DllNotFoundException>(() => { instance.GetTexDataAsRgba32(out outPixels, out outWidth, out outHeight); });
            }
        }

        /// <summary>
        /// Tests that GetTexDataAsRgba32 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetTexDataAsRgba32_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); IntPtr outPixels = default; int outWidth = default; int outHeight = default; int outBytesPerPixel = default;
                Assert.Throws<DllNotFoundException>(() => { instance.GetTexDataAsRgba32(out outPixels, out outWidth, out outHeight, out outBytesPerPixel); });
            }
        }

        /// <summary>
        /// Tests that IsBuilt throws when native library is unavailable
        /// </summary>
        [Fact]
        public void IsBuilt_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.IsBuilt(); });
            }
        }

        /// <summary>
        /// Tests that SetTexId throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetTexId_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImFontAtlasPtr instance = new ImFontAtlasPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.SetTexId(IntPtr.Zero); });
            }
        }
        /// <summary>
        /// Determines whether the cimgui native library can be loaded
        /// </summary>
        /// <returns>True if the library can be loaded</returns>
        private static bool CanLoadCImguiLibrary()
        {
            if (NativeLibrary.TryLoad("cimgui", out _))
            {
                return true;
            }

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImFontAtlasPtrRemainingCoverageTests).Assembly.Location);
            if (assemblyDir == null)
            {
                return false;
            }

            string[] candidates = new[]
            {
                System.IO.Path.Combine(assemblyDir, "cimgui"),
                System.IO.Path.Combine(assemblyDir, "libcimgui"),
                System.IO.Path.Combine(assemblyDir, "libcimgui.dylib")
            };

            foreach (string candidate in candidates)
            {
                if (System.IO.File.Exists(candidate) && NativeLibrary.TryLoad(candidate, out _))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
