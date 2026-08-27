// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontConfigPtrTests.cs
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
    ///     The im font config ptr tests class
    /// </summary>
    public class ImFontConfigPtrTests
    {
        /// <summary>
        ///     Allocates a native block backed by the given config and wraps it in a pointer.
        /// </summary>
        /// <param name="config">The managed config to marshal into the native block</param>
        /// <returns>A pointer wrapping a freshly allocated native config block</returns>
        private static ImFontConfigPtr Wrap(ImFontConfig config)
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            Marshal.StructureToPtr(config, nativePtr, false);
            return new ImFontConfigPtr(nativePtr);
        }

        /// <summary>
        ///     Tests that constructor with int ptr sets native ptr
        /// </summary>
        [RequireCImguiSystemFact]
        public void Constructor_WithIntPtr_SetsNativePtr()
        {
            IntPtr expected = new IntPtr(1234);
            ImFontConfigPtr ptr = new ImFontConfigPtr(expected);
            Assert.Equal(expected, ptr.NativePtr);
        }

        /// <summary>
        ///     Tests that constructor with zero int ptr sets zero native ptr
        /// </summary>
        [RequireCImguiSystemFact]
        public void Constructor_WithZeroIntPtr_SetsZeroNativePtr()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Equal(IntPtr.Zero, ptr.NativePtr);
        }

        /// <summary>
        ///     Tests that constructor with im font config allocates and round trips all fields
        /// </summary>
        [RequireCImguiSystemFact]
        public void Constructor_WithImFontConfig_RoundTripsFields()
        {
            ImFontConfig config = new ImFontConfig
            {
                FontData = new IntPtr(11),
                FontDataSize = 22,
                FontDataOwnedByAtlas = 1,
                FontNo = 3,
                SizePixels = 17.5f,
                OversampleH = 4,
                OversampleV = 5,
                SnapH = 1,
                GlyphExtraSpacing = new Vector2F(1.0f, 2.0f),
                GlyphOffset = new Vector2F(3.0f, 4.0f),
                GlyphRanges = new IntPtr(33),
                GlyphMinAdvanceX = 6.0f,
                GlyphMaxAdvanceX = 64.0f,
                MergeMode = 1,
                FontBuilderFlags = 9u,
                RasterizerMultiply = 1.25f,
                EllipsisChar = 111,
                DstFont = new IntPtr(44)
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
                Assert.Equal(config.GlyphExtraSpacing, ptr.GlyphExtraSpacing);
                Assert.Equal(config.GlyphOffset, ptr.GlyphOffset);
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
        ///     Tests that implicit conversion to int ptr returns native ptr
        /// </summary>
        [RequireCImguiSystemFact]
        public void ImplicitConversion_ToIntPtr_ReturnsNativePtr()
        {
            IntPtr expected = new IntPtr(555);
            ImFontConfigPtr ptr = new ImFontConfigPtr(expected);
            IntPtr result = ptr;
            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Tests that implicit conversion from int ptr returns im font config ptr
        /// </summary>
        [RequireCImguiSystemFact]
        public void ImplicitConversion_FromIntPtr_ReturnsImFontConfigPtr()
        {
            IntPtr nativePtr = new IntPtr(666);
            ImFontConfigPtr ptr = nativePtr;
            Assert.Equal(nativePtr, ptr.NativePtr);
        }

        /// <summary>
        ///     Tests that font data getter reads the native block
        /// </summary>
        [RequireCImguiSystemFact]
        public void FontData_Getter_ReadsNativeBlock()
        {
            ImFontConfigPtr ptr = Wrap(new ImFontConfig { FontData = new IntPtr(777) });
            try
            {
                Assert.Equal(new IntPtr(777), ptr.FontData);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that font data size getter reads the native block
        /// </summary>
        [RequireCImguiSystemFact]
        public void FontDataSize_Getter_ReadsNativeBlock()
        {
            ImFontConfigPtr ptr = Wrap(new ImFontConfig { FontDataSize = 123 });
            try
            {
                Assert.Equal(123, ptr.FontDataSize);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that font data owned by atlas getter returns true for non zero byte
        /// </summary>
        [RequireCImguiSystemFact]
        public void FontDataOwnedByAtlas_Getter_NonZero_ReturnsTrue()
        {
            ImFontConfigPtr ptr = Wrap(new ImFontConfig { FontDataOwnedByAtlas = 1 });
            try
            {
                Assert.True(ptr.FontDataOwnedByAtlas);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that font no getter reads the native block
        /// </summary>
        [RequireCImguiSystemFact]
        public void FontNo_Getter_ReadsNativeBlock()
        {
            ImFontConfigPtr ptr = Wrap(new ImFontConfig { FontNo = 8 });
            try
            {
                Assert.Equal(8, ptr.FontNo);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that size pixels getter reads the native block
        /// </summary>
        [RequireCImguiSystemFact]
        public void SizePixels_Getter_ReadsNativeBlock()
        {
            ImFontConfigPtr ptr = Wrap(new ImFontConfig { SizePixels = 21.0f });
            try
            {
                Assert.Equal(21.0f, ptr.SizePixels);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that oversample h getter reads the native block
        /// </summary>
        [RequireCImguiSystemFact]
        public void OversampleH_Getter_ReadsNativeBlock()
        {
            ImFontConfigPtr ptr = Wrap(new ImFontConfig { OversampleH = 3 });
            try
            {
                Assert.Equal(3, ptr.OversampleH);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that oversample v getter reads the native block
        /// </summary>
        [RequireCImguiSystemFact]
        public void OversampleV_Getter_ReadsNativeBlock()
        {
            ImFontConfigPtr ptr = Wrap(new ImFontConfig { OversampleV = 4 });
            try
            {
                Assert.Equal(4, ptr.OversampleV);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that snap h getter returns true for non zero byte
        /// </summary>
        [RequireCImguiSystemFact]
        public void SnapH_Getter_NonZero_ReturnsTrue()
        {
            ImFontConfigPtr ptr = Wrap(new ImFontConfig { SnapH = 1 });
            try
            {
                Assert.True(ptr.SnapH);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that snap h setter writes back to the native block
        /// </summary>
        [RequireCImguiSystemFact]
        public void SnapH_Setter_WritesToNativeBlock()
        {
            ImFontConfigPtr ptr = Wrap(new ImFontConfig { SnapH = 0 });
            try
            {
                ptr.SnapH = true;
                ImFontConfig result = Marshal.PtrToStructure<ImFontConfig>(ptr.NativePtr);
                Assert.Equal((byte)1, result.SnapH);
                Assert.True(ptr.SnapH);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that glyph extra spacing getter reads the native block
        /// </summary>
        [RequireCImguiSystemFact]
        public void GlyphExtraSpacing_Getter_ReadsNativeBlock()
        {
            ImFontConfigPtr ptr = Wrap(new ImFontConfig { GlyphExtraSpacing = new Vector2F(5.0f, 6.0f) });
            try
            {
                Assert.Equal(new Vector2F(5.0f, 6.0f), ptr.GlyphExtraSpacing);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that glyph offset getter reads the native block
        /// </summary>
        [RequireCImguiSystemFact]
        public void GlyphOffset_Getter_ReadsNativeBlock()
        {
            ImFontConfigPtr ptr = Wrap(new ImFontConfig { GlyphOffset = new Vector2F(7.0f, 8.0f) });
            try
            {
                Assert.Equal(new Vector2F(7.0f, 8.0f), ptr.GlyphOffset);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that glyph ranges setter writes back to the native block
        /// </summary>
        [RequireCImguiSystemFact]
        public void GlyphRanges_Setter_WritesToNativeBlock()
        {
            ImFontConfigPtr ptr = Wrap(new ImFontConfig { GlyphRanges = IntPtr.Zero });
            try
            {
                IntPtr expected = new IntPtr(888);
                ptr.GlyphRanges = expected;
                ImFontConfig result = Marshal.PtrToStructure<ImFontConfig>(ptr.NativePtr);
                Assert.Equal(expected, result.GlyphRanges);
                Assert.Equal(expected, ptr.GlyphRanges);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that glyph min advance x setter writes back to the native block
        /// </summary>
        [RequireCImguiSystemFact]
        public void GlyphMinAdvanceX_Setter_WritesToNativeBlock()
        {
            ImFontConfigPtr ptr = Wrap(new ImFontConfig { GlyphMinAdvanceX = 0.0f });
            try
            {
                ptr.GlyphMinAdvanceX = 9.5f;
                ImFontConfig result = Marshal.PtrToStructure<ImFontConfig>(ptr.NativePtr);
                Assert.Equal(9.5f, result.GlyphMinAdvanceX);
                Assert.Equal(9.5f, ptr.GlyphMinAdvanceX);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that glyph max advance x getter reads the native block
        /// </summary>
        [RequireCImguiSystemFact]
        public void GlyphMaxAdvanceX_Getter_ReadsNativeBlock()
        {
            ImFontConfigPtr ptr = Wrap(new ImFontConfig { GlyphMaxAdvanceX = 48.0f });
            try
            {
                Assert.Equal(48.0f, ptr.GlyphMaxAdvanceX);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that merge mode setter writes back to the native block
        /// </summary>
        [RequireCImguiSystemFact]
        public void MergeMode_Setter_WritesToNativeBlock()
        {
            ImFontConfigPtr ptr = Wrap(new ImFontConfig { MergeMode = 0 });
            try
            {
                ptr.MergeMode = true;
                ImFontConfig result = Marshal.PtrToStructure<ImFontConfig>(ptr.NativePtr);
                Assert.Equal((byte)1, result.MergeMode);
                Assert.True(ptr.MergeMode);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that font builder flags getter reads the native block
        /// </summary>
        [RequireCImguiSystemFact]
        public void FontBuilderFlags_Getter_ReadsNativeBlock()
        {
            ImFontConfigPtr ptr = Wrap(new ImFontConfig { FontBuilderFlags = 31u });
            try
            {
                Assert.Equal(31u, ptr.FontBuilderFlags);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that rasterizer multiply getter reads the native block
        /// </summary>
        [RequireCImguiSystemFact]
        public void RasterizerMultiply_Getter_ReadsNativeBlock()
        {
            ImFontConfigPtr ptr = Wrap(new ImFontConfig { RasterizerMultiply = 2.5f });
            try
            {
                Assert.Equal(2.5f, ptr.RasterizerMultiply);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that ellipsis char getter reads the native block
        /// </summary>
        [RequireCImguiSystemFact]
        public void EllipsisChar_Getter_ReadsNativeBlock()
        {
            ImFontConfigPtr ptr = Wrap(new ImFontConfig { EllipsisChar = 321 });
            try
            {
                Assert.Equal((ushort)321, ptr.EllipsisChar);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that dst font getter reads the native block
        /// </summary>
        [RequireCImguiSystemFact]
        public void DstFont_Getter_ReadsNativeBlock()
        {
            ImFontConfigPtr ptr = Wrap(new ImFontConfig { DstFont = new IntPtr(999) });
            try
            {
                Assert.Equal(new IntPtr(999), ptr.DstFont.NativePtr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that property getters on zero ptr throw null reference exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void Getter_OnZeroPtr_ThrowsNullReferenceException()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() => _ = ptr.FontData);
            Assert.Throws<NullReferenceException>(() => _ = ptr.DstFont);
        }
    }
}
