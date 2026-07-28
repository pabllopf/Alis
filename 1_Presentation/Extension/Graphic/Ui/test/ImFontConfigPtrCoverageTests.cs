// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontConfigPtrCoverageTests.cs
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
    /// The im font config ptr coverage tests class
    /// </summary>
    public class ImFontConfigPtrCoverageTests
    {
        /// <summary>
        /// Tests that constructor with int ptr sets native ptr
        /// </summary>
        [Fact]
        public void Constructor_WithIntPtr_SetsNativePtr()
        {
            IntPtr expected = new IntPtr(42);
            ImFontConfigPtr ptr = new ImFontConfigPtr(expected);
            Assert.Equal(expected, ptr.NativePtr);
        }

        /// <summary>
        /// Tests that constructor with int ptr zero sets native ptr
        /// </summary>
        [Fact]
        public void Constructor_WithIntPtr_Zero_SetsNativePtr()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Equal(IntPtr.Zero, ptr.NativePtr);
        }

        /// <summary>
        /// Tests that constructor with im font config allocates and copies
        /// </summary>
        [Fact]
        public void Constructor_WithImFontConfig_AllocatesAndCopies()
        {
            ImFontConfig config = new ImFontConfig
            {
                FontData = new IntPtr(100),
                FontDataSize = 200,
                FontDataOwnedByAtlas = 1,
                FontNo = 1,
                SizePixels = 16.0f,
                OversampleH = 3,
                OversampleV = 2,
                SnapH = 1,
                GlyphRanges = new IntPtr(300),
                GlyphMinAdvanceX = 4.0f,
                GlyphMaxAdvanceX = 32.0f,
                MergeMode = 1,
                FontBuilderFlags = 5u,
                RasterizerMultiply = 1.5f,
                EllipsisChar = 123,
                DstFont = new IntPtr(400)
            };

            ImFontConfigPtr ptr = new ImFontConfigPtr(config);

            try
            {
                Assert.NotEqual(IntPtr.Zero, ptr.NativePtr);
                Assert.Equal(config.FontData, ptr.FontData);
                Assert.Equal(config.FontDataSize, ptr.FontDataSize);
                Assert.True(ptr.FontDataOwnedByAtlas);
                Assert.Equal(config.FontNo, ptr.FontNo);
                Assert.Equal(config.SizePixels, ptr.SizePixels);
                Assert.Equal(config.OversampleH, ptr.OversampleH);
                Assert.Equal(config.OversampleV, ptr.OversampleV);
                Assert.True(ptr.SnapH);
                Assert.Equal(config.GlyphRanges, ptr.GlyphRanges);
                Assert.Equal(config.GlyphMinAdvanceX, ptr.GlyphMinAdvanceX);
                Assert.Equal(config.GlyphMaxAdvanceX, ptr.GlyphMaxAdvanceX);
                Assert.True(ptr.MergeMode);
                Assert.Equal(config.FontBuilderFlags, ptr.FontBuilderFlags);
                Assert.Equal(config.RasterizerMultiply, ptr.RasterizerMultiply);
                Assert.Equal(config.EllipsisChar, ptr.EllipsisChar);
                Assert.Equal(config.DstFont, ptr.DstFont.NativePtr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        /// Tests that constructor with im font config zero fields returns defaults
        /// </summary>
        [Fact]
        public void Constructor_WithImFontConfig_ZeroFields_ReturnsDefaults()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);

            try
            {
                Assert.NotEqual(IntPtr.Zero, ptr.NativePtr);
                Assert.Equal(IntPtr.Zero, ptr.FontData);
                Assert.Equal(0, ptr.FontDataSize);
                Assert.False(ptr.FontDataOwnedByAtlas);
                Assert.Equal(0, ptr.FontNo);
                Assert.Equal(0.0f, ptr.SizePixels);
                Assert.Equal(0, ptr.OversampleH);
                Assert.Equal(0, ptr.OversampleV);
                Assert.False(ptr.SnapH);
                Assert.Equal(IntPtr.Zero, ptr.GlyphRanges);
                Assert.Equal(0.0f, ptr.GlyphMinAdvanceX);
                Assert.Equal(0.0f, ptr.GlyphMaxAdvanceX);
                Assert.False(ptr.MergeMode);
                Assert.Equal(0u, ptr.FontBuilderFlags);
                Assert.Equal(0.0f, ptr.RasterizerMultiply);
                Assert.Equal((ushort)0, ptr.EllipsisChar);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        /// Tests that implicit conversion to int ptr returns native ptr
        /// </summary>
        [Fact]
        public void ImplicitConversion_ToIntPtr_ReturnsNativePtr()
        {
            IntPtr expected = new IntPtr(77);
            ImFontConfigPtr ptr = new ImFontConfigPtr(expected);
            IntPtr result = ptr;
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that implicit conversion from int ptr returns im font config ptr
        /// </summary>
        [Fact]
        public void ImplicitConversion_FromIntPtr_ReturnsImFontConfigPtr()
        {
            IntPtr nativePtr = new IntPtr(88);
            ImFontConfigPtr ptr = nativePtr;
            Assert.Equal(nativePtr, ptr.NativePtr);
        }

        /// <summary>
        /// Tests that font data getter returns expected
        /// </summary>
        [Fact]
        public void FontData_Getter_ReturnsExpected()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { FontData = new IntPtr(999) };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                Assert.Equal(new IntPtr(999), ptr.FontData);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that font data size getter returns expected
        /// </summary>
        [Fact]
        public void FontDataSize_Getter_ReturnsExpected()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { FontDataSize = 1234 };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                Assert.Equal(1234, ptr.FontDataSize);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that font data owned by atlas getter true returns true
        /// </summary>
        [Fact]
        public void FontDataOwnedByAtlas_Getter_True_ReturnsTrue()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { FontDataOwnedByAtlas = 1 };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                Assert.True(ptr.FontDataOwnedByAtlas);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that font data owned by atlas getter false returns false
        /// </summary>
        [Fact]
        public void FontDataOwnedByAtlas_Getter_False_ReturnsFalse()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { FontDataOwnedByAtlas = 0 };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                Assert.False(ptr.FontDataOwnedByAtlas);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that font no getter returns expected
        /// </summary>
        [Fact]
        public void FontNo_Getter_ReturnsExpected()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { FontNo = 7 };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                Assert.Equal(7, ptr.FontNo);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that size pixels getter returns expected
        /// </summary>
        [Fact]
        public void SizePixels_Getter_ReturnsExpected()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { SizePixels = 24.0f };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                Assert.Equal(24.0f, ptr.SizePixels);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that oversample h getter returns expected
        /// </summary>
        [Fact]
        public void OversampleH_Getter_ReturnsExpected()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { OversampleH = 4 };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                Assert.Equal(4, ptr.OversampleH);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that oversample v getter returns expected
        /// </summary>
        [Fact]
        public void OversampleV_Getter_ReturnsExpected()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { OversampleV = 5 };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                Assert.Equal(5, ptr.OversampleV);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that snap h getter when snap h is non zero returns true
        /// </summary>
        [Fact]
        public void SnapH_Getter_WhenSnapHIsNonZero_ReturnsTrue()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { SnapH = 1 };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                Assert.True(ptr.SnapH);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that snap h getter when snap h is zero returns false
        /// </summary>
        [Fact]
        public void SnapH_Getter_WhenSnapHIsZero_ReturnsFalse()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { SnapH = 0 };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                Assert.False(ptr.SnapH);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that snap h setter sets snap h to true
        /// </summary>
        [Fact]
        public void SnapH_Setter_SetsSnapHToTrue()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { SnapH = 0 };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                ptr.SnapH = true;
                ImFontConfig result = Marshal.PtrToStructure<ImFontConfig>(nativePtr);
                Assert.Equal((byte)1, result.SnapH);
                Assert.True(ptr.SnapH);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that snap h setter sets snap h to false
        /// </summary>
        [Fact]
        public void SnapH_Setter_SetsSnapHToFalse()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { SnapH = 1 };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                ptr.SnapH = false;
                ImFontConfig result = Marshal.PtrToStructure<ImFontConfig>(nativePtr);
                Assert.Equal((byte)0, result.SnapH);
                Assert.False(ptr.SnapH);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that glyph extra spacing getter returns expected
        /// </summary>
        [Fact]
        public void GlyphExtraSpacing_Getter_ReturnsExpected()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig();
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                Assert.Equal(default(Vector2F), ptr.GlyphExtraSpacing);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that glyph offset getter returns expected
        /// </summary>
        [Fact]
        public void GlyphOffset_Getter_ReturnsExpected()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig();
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                Assert.Equal(default(Vector2F), ptr.GlyphOffset);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that glyph ranges getter returns expected
        /// </summary>
        [Fact]
        public void GlyphRanges_Getter_ReturnsExpected()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { GlyphRanges = new IntPtr(500) };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                Assert.Equal(new IntPtr(500), ptr.GlyphRanges);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that glyph ranges setter sets value
        /// </summary>
        [Fact]
        public void GlyphRanges_Setter_SetsValue()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { GlyphRanges = IntPtr.Zero };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                IntPtr expected = new IntPtr(600);
                ptr.GlyphRanges = expected;
                ImFontConfig result = Marshal.PtrToStructure<ImFontConfig>(nativePtr);
                Assert.Equal(expected, result.GlyphRanges);
                Assert.Equal(expected, ptr.GlyphRanges);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that glyph min advance x getter returns expected
        /// </summary>
        [Fact]
        public void GlyphMinAdvanceX_Getter_ReturnsExpected()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { GlyphMinAdvanceX = 2.5f };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                Assert.Equal(2.5f, ptr.GlyphMinAdvanceX);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that glyph min advance x setter sets value
        /// </summary>
        [Fact]
        public void GlyphMinAdvanceX_Setter_SetsValue()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { GlyphMinAdvanceX = 0.0f };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                ptr.GlyphMinAdvanceX = 7.5f;
                ImFontConfig result = Marshal.PtrToStructure<ImFontConfig>(nativePtr);
                Assert.Equal(7.5f, result.GlyphMinAdvanceX);
                Assert.Equal(7.5f, ptr.GlyphMinAdvanceX);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that glyph max advance x getter returns expected
        /// </summary>
        [Fact]
        public void GlyphMaxAdvanceX_Getter_ReturnsExpected()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { GlyphMaxAdvanceX = 64.0f };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                Assert.Equal(64.0f, ptr.GlyphMaxAdvanceX);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that merge mode getter when merge mode is non zero returns true
        /// </summary>
        [Fact]
        public void MergeMode_Getter_WhenMergeModeIsNonZero_ReturnsTrue()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { MergeMode = 1 };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                Assert.True(ptr.MergeMode);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that merge mode getter when merge mode is zero returns false
        /// </summary>
        [Fact]
        public void MergeMode_Getter_WhenMergeModeIsZero_ReturnsFalse()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { MergeMode = 0 };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                Assert.False(ptr.MergeMode);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that merge mode setter sets merge mode to true
        /// </summary>
        [Fact]
        public void MergeMode_Setter_SetsMergeModeToTrue()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { MergeMode = 0 };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                ptr.MergeMode = true;
                ImFontConfig result = Marshal.PtrToStructure<ImFontConfig>(nativePtr);
                Assert.Equal((byte)1, result.MergeMode);
                Assert.True(ptr.MergeMode);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that merge mode setter sets merge mode to false
        /// </summary>
        [Fact]
        public void MergeMode_Setter_SetsMergeModeToFalse()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { MergeMode = 1 };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                ptr.MergeMode = false;
                ImFontConfig result = Marshal.PtrToStructure<ImFontConfig>(nativePtr);
                Assert.Equal((byte)0, result.MergeMode);
                Assert.False(ptr.MergeMode);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that font builder flags getter returns expected
        /// </summary>
        [Fact]
        public void FontBuilderFlags_Getter_ReturnsExpected()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { FontBuilderFlags = 42u };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                Assert.Equal(42u, ptr.FontBuilderFlags);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that rasterizer multiply getter returns expected
        /// </summary>
        [Fact]
        public void RasterizerMultiply_Getter_ReturnsExpected()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { RasterizerMultiply = 2.0f };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                Assert.Equal(2.0f, ptr.RasterizerMultiply);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that ellipsis char getter returns expected
        /// </summary>
        [Fact]
        public void EllipsisChar_Getter_ReturnsExpected()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { EllipsisChar = 999 };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                Assert.Equal((ushort)999, ptr.EllipsisChar);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that dst font getter returns expected
        /// </summary>
        [Fact]
        public void DstFont_Getter_ReturnsExpected()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig { DstFont = new IntPtr(123456) };
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
                Assert.Equal(new IntPtr(123456), ptr.DstFont.NativePtr);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that native ptr getter returns value passed to constructor
        /// </summary>
        [Fact]
        public void NativePtr_Getter_ReturnsValuePassedToConstructor()
        {
            IntPtr expected = new IntPtr(0xDEAD);
            ImFontConfigPtr ptr = new ImFontConfigPtr(expected);
            Assert.Equal(expected, ptr.NativePtr);
        }

        /// <summary>
        /// Tests that font data getter on zero ptr throws null reference exception
        /// </summary>
        [Fact]
        public void FontData_Getter_OnZeroPtr_ThrowsNullReferenceException()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() => _ = ptr.FontData);
        }

        /// <summary>
        /// Tests that font data size getter on zero ptr throws null reference exception
        /// </summary>
        [Fact]
        public void FontDataSize_Getter_OnZeroPtr_ThrowsNullReferenceException()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() => _ = ptr.FontDataSize);
        }

        /// <summary>
        /// Tests that font data owned by atlas getter on zero ptr throws null reference exception
        /// </summary>
        [Fact]
        public void FontDataOwnedByAtlas_Getter_OnZeroPtr_ThrowsNullReferenceException()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() => _ = ptr.FontDataOwnedByAtlas);
        }

        /// <summary>
        /// Tests that font no getter on zero ptr throws null reference exception
        /// </summary>
        [Fact]
        public void FontNo_Getter_OnZeroPtr_ThrowsNullReferenceException()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() => _ = ptr.FontNo);
        }

        /// <summary>
        /// Tests that size pixels getter on zero ptr throws null reference exception
        /// </summary>
        [Fact]
        public void SizePixels_Getter_OnZeroPtr_ThrowsNullReferenceException()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() => _ = ptr.SizePixels);
        }

        /// <summary>
        /// Tests that oversample h getter on zero ptr throws null reference exception
        /// </summary>
        [Fact]
        public void OversampleH_Getter_OnZeroPtr_ThrowsNullReferenceException()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() => _ = ptr.OversampleH);
        }

        /// <summary>
        /// Tests that oversample v getter on zero ptr throws null reference exception
        /// </summary>
        [Fact]
        public void OversampleV_Getter_OnZeroPtr_ThrowsNullReferenceException()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() => _ = ptr.OversampleV);
        }

        /// <summary>
        /// Tests that snap h getter on zero ptr throws null reference exception
        /// </summary>
        [Fact]
        public void SnapH_Getter_OnZeroPtr_ThrowsNullReferenceException()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() => _ = ptr.SnapH);
        }

        /// <summary>
        /// Tests that glyph extra spacing getter on zero ptr throws null reference exception
        /// </summary>
        [Fact]
        public void GlyphExtraSpacing_Getter_OnZeroPtr_ThrowsNullReferenceException()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() => _ = ptr.GlyphExtraSpacing);
        }

        /// <summary>
        /// Tests that glyph offset getter on zero ptr throws null reference exception
        /// </summary>
        [Fact]
        public void GlyphOffset_Getter_OnZeroPtr_ThrowsNullReferenceException()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() => _ = ptr.GlyphOffset);
        }

        /// <summary>
        /// Tests that glyph ranges getter on zero ptr throws null reference exception
        /// </summary>
        [Fact]
        public void GlyphRanges_Getter_OnZeroPtr_ThrowsNullReferenceException()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() => _ = ptr.GlyphRanges);
        }

        /// <summary>
        /// Tests that glyph min advance x getter on zero ptr throws null reference exception
        /// </summary>
        [Fact]
        public void GlyphMinAdvanceX_Getter_OnZeroPtr_ThrowsNullReferenceException()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() => _ = ptr.GlyphMinAdvanceX);
        }

        /// <summary>
        /// Tests that glyph max advance x getter on zero ptr throws null reference exception
        /// </summary>
        [Fact]
        public void GlyphMaxAdvanceX_Getter_OnZeroPtr_ThrowsNullReferenceException()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() => _ = ptr.GlyphMaxAdvanceX);
        }

        /// <summary>
        /// Tests that merge mode getter on zero ptr throws null reference exception
        /// </summary>
        [Fact]
        public void MergeMode_Getter_OnZeroPtr_ThrowsNullReferenceException()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() => _ = ptr.MergeMode);
        }

        /// <summary>
        /// Tests that font builder flags getter on zero ptr throws null reference exception
        /// </summary>
        [Fact]
        public void FontBuilderFlags_Getter_OnZeroPtr_ThrowsNullReferenceException()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() => _ = ptr.FontBuilderFlags);
        }

        /// <summary>
        /// Tests that rasterizer multiply getter on zero ptr throws null reference exception
        /// </summary>
        [Fact]
        public void RasterizerMultiply_Getter_OnZeroPtr_ThrowsNullReferenceException()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() => _ = ptr.RasterizerMultiply);
        }

        /// <summary>
        /// Tests that ellipsis char getter on zero ptr throws null reference exception
        /// </summary>
        [Fact]
        public void EllipsisChar_Getter_OnZeroPtr_ThrowsNullReferenceException()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() => _ = ptr.EllipsisChar);
        }

        /// <summary>
        /// Tests that dst font getter on zero ptr throws null reference exception
        /// </summary>
        [Fact]
        public void DstFont_Getter_OnZeroPtr_ThrowsNullReferenceException()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() => _ = ptr.DstFont);
        }
    }
}
