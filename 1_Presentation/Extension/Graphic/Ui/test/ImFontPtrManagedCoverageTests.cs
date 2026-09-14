// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontPtrManagedCoverageTests.cs
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
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im font ptr managed coverage tests class
    /// </summary>
    public class ImFontPtrManagedCoverageTests
    {
        /// <summary>
        ///     Tests that native ptr after int ptr constructor returns same pointer
        /// </summary>
        [Fact]
        public void NativePtr_AfterIntPtrConstructor_ReturnsSamePointer()
        {
            IntPtr expected = new IntPtr(0xABCD);
            ImFontPtr ptr = new ImFontPtr(expected);
            Assert.Equal(expected, ptr.NativePtr);
        }

        /// <summary>
        ///     Tests that native ptr after im font constructor returns allocated pointer
        /// </summary>
        [Fact]
        public void NativePtr_AfterImFontConstructor_ReturnsAllocatedPointer()
        {
            ImFontPtr ptr = new ImFontPtr(default(ImFont));
            try
            {
                Assert.NotEqual(IntPtr.Zero, ptr.NativePtr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that constructor with int ptr stores pointer
        /// </summary>
        [Fact]
        public void Constructor_WithIntPtr_StoresPointer()
        {
            IntPtr expected = new IntPtr(1234);
            ImFontPtr ptr = new ImFontPtr(expected);
            Assert.Equal(expected, ptr.NativePtr);
        }

        /// <summary>
        ///     Tests that constructor with im font round trips all properties
        /// </summary>
        [Fact]
        public void Constructor_WithImFont_RoundTripsAllProperties()
        {
            ImVector advanceX = new ImVector(5, 10, new IntPtr(0xDEAD));
            ImVector lookup = new ImVector(8, 16, new IntPtr(0xBEEF));
            ImFont font = new ImFont
            {
                IndexAdvanceX = advanceX,
                FallbackAdvanceX = 2.5f,
                FontSize = 18.0f,
                IndexLookup = lookup,
                ContainerAtlas = new IntPtr(0xCAFE),
                ConfigData = new IntPtr(0x1234),
                ConfigDataCount = 2,
                FallbackChar = 0xFFFD,
                EllipsisChar = 0x2026,
                DotChar = 46,
                DirtyLookupTables = 1,
                Scale = 1.25f,
                Ascent = 0.75f,
                Descent = -0.25f,
                MetricsTotalSurface = 2048
            };

            ImFontPtr ptr = new ImFontPtr(font);
            try
            {
                Assert.Equal(advanceX.Size, ptr.IndexAdvanceX.Size);
                Assert.Equal(advanceX.Capacity, ptr.IndexAdvanceX.Capacity);
                Assert.Equal(advanceX.Data, ptr.IndexAdvanceX.Data);
                Assert.Equal(font.FallbackAdvanceX, ptr.FallbackAdvanceX);
                Assert.Equal(font.FontSize, ptr.FontSize);
                Assert.Equal(lookup.Size, ptr.IndexLookup.Size);
                Assert.Equal(lookup.Capacity, ptr.IndexLookup.Capacity);
                Assert.Equal(lookup.Data, ptr.IndexLookup.Data);
                Assert.Equal(new IntPtr(0xCAFE), ptr.ContainerAtlas.NativePtr);
                Assert.Equal(new IntPtr(0x1234), ptr.ConfigData.NativePtr);
                Assert.Equal(font.ConfigDataCount, ptr.ConfigDataCount);
                Assert.Equal(font.FallbackChar, ptr.FallbackChar);
                Assert.Equal(font.EllipsisChar, ptr.EllipsisChar);
                Assert.Equal(font.DotChar, ptr.DotChar);
                Assert.True(ptr.DirtyLookupTables);
                Assert.Equal(font.Scale, ptr.Scale);
                Assert.Equal(font.Ascent, ptr.Ascent);
                Assert.Equal(font.Descent, ptr.Descent);
                Assert.Equal(font.MetricsTotalSurface, ptr.MetricsTotalSurface);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that implicit operator to int ptr returns native ptr
        /// </summary>
        [Fact]
        public void ImplicitOperator_ToIntPtr_ReturnsNativePtr()
        {
            IntPtr native = new IntPtr(0x7777);
            ImFontPtr ptr = new ImFontPtr(native);
            IntPtr result = ptr;
            Assert.Equal(native, result);
        }

        /// <summary>
        ///     Tests that implicit operator from int ptr returns wrapper
        /// </summary>
        [Fact]
        public void ImplicitOperator_FromIntPtr_ReturnsWrapper()
        {
            IntPtr native = new IntPtr(0x8888);
            ImFontPtr ptr = native;
            Assert.Equal(native, ptr.NativePtr);
        }

        /// <summary>
        ///     Tests that fallback advance x reads correct value
        /// </summary>
        [Fact]
        public void FallbackAdvanceX_ReadsCorrectValue()
        {
            const float expected = 3.14f;
            ImFont font = new ImFont { FallbackAdvanceX = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                Assert.Equal(expected, ptr.FallbackAdvanceX);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that font size reads correct value
        /// </summary>
        [Fact]
        public void FontSize_ReadsCorrectValue()
        {
            const float expected = 24.0f;
            ImFont font = new ImFont { FontSize = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                Assert.Equal(expected, ptr.FontSize);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that index advance x returns wrapped im vector
        /// </summary>
        [Fact]
        public void IndexAdvanceX_ReturnsWrappedImVector()
        {
            ImVector vector = new ImVector(5, 10, new IntPtr(0xDEAD));
            ImFont font = new ImFont { IndexAdvanceX = vector };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                ImVectorG<float> result = ptr.IndexAdvanceX;
                Assert.Equal(vector.Size, result.Size);
                Assert.Equal(vector.Capacity, result.Capacity);
                Assert.Equal(vector.Data, result.Data);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that index lookup returns wrapped im vector
        /// </summary>
        [Fact]
        public void IndexLookup_ReturnsWrappedImVector()
        {
            ImVector vector = new ImVector(8, 16, new IntPtr(0xBEEF));
            ImFont font = new ImFont { IndexLookup = vector };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                ImVectorG<ushort> result = ptr.IndexLookup;
                Assert.Equal(vector.Size, result.Size);
                Assert.Equal(vector.Capacity, result.Capacity);
                Assert.Equal(vector.Data, result.Data);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that container atlas reads correct value
        /// </summary>
        [Fact]
        public void ContainerAtlas_ReadsCorrectValue()
        {
            IntPtr expected = new IntPtr(0xCAFE);
            ImFont font = new ImFont { ContainerAtlas = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                ImFontAtlasPtr result = ptr.ContainerAtlas;
                Assert.Equal(expected, result.NativePtr);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that config data getter reads correct value
        /// </summary>
        [Fact]
        public void ConfigData_Getter_ReadsCorrectValue()
        {
            IntPtr expected = new IntPtr(0x1234);
            ImFont font = new ImFont { ConfigData = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                Assert.Equal(expected, ptr.ConfigData.NativePtr);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that config data setter persists to native structure
        /// </summary>
        [Fact]
        public void ConfigData_Setter_PersistsToNativeStructure()
        {
            ImFont font = new ImFont { ConfigData = IntPtr.Zero };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                ImFontConfigPtr config = new ImFontConfigPtr(new IntPtr(0x5678));
                ptr.ConfigData = config;
                Assert.Equal(new IntPtr(0x5678), ptr.ConfigData.NativePtr);
                ImFont result = Marshal.PtrToStructure<ImFont>(nativePtr);
                Assert.Equal(new IntPtr(0x5678), result.ConfigData);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that config data count reads correct value
        /// </summary>
        [Fact]
        public void ConfigDataCount_ReadsCorrectValue()
        {
            const short expected = 3;
            ImFont font = new ImFont { ConfigDataCount = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                Assert.Equal(expected, ptr.ConfigDataCount);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that fallback char reads correct value
        /// </summary>
        [Fact]
        public void FallbackChar_ReadsCorrectValue()
        {
            const ushort expected = 0xFFFD;
            ImFont font = new ImFont { FallbackChar = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                Assert.Equal(expected, ptr.FallbackChar);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that ellipsis char reads correct value
        /// </summary>
        [Fact]
        public void EllipsisChar_ReadsCorrectValue()
        {
            const ushort expected = 0x2026;
            ImFont font = new ImFont { EllipsisChar = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                Assert.Equal(expected, ptr.EllipsisChar);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that dot char reads correct value
        /// </summary>
        [Fact]
        public void DotChar_ReadsCorrectValue()
        {
            const ushort expected = (ushort)'.';
            ImFont font = new ImFont { DotChar = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                Assert.Equal(expected, ptr.DotChar);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that dirty lookup tables true returns true
        /// </summary>
        [Fact]
        public void DirtyLookupTables_True_ReturnsTrue()
        {
            ImFont font = new ImFont { DirtyLookupTables = 1 };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                Assert.True(ptr.DirtyLookupTables);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that dirty lookup tables false returns false
        /// </summary>
        [Fact]
        public void DirtyLookupTables_False_ReturnsFalse()
        {
            ImFont font = new ImFont { DirtyLookupTables = 0 };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                Assert.False(ptr.DirtyLookupTables);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that scale reads correct value
        /// </summary>
        [Fact]
        public void Scale_ReadsCorrectValue()
        {
            const float expected = 1.5f;
            ImFont font = new ImFont { Scale = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                Assert.Equal(expected, ptr.Scale);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that ascent reads correct value
        /// </summary>
        [Fact]
        public void Ascent_ReadsCorrectValue()
        {
            const float expected = 0.9f;
            ImFont font = new ImFont { Ascent = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                Assert.Equal(expected, ptr.Ascent);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that descent reads correct value
        /// </summary>
        [Fact]
        public void Descent_ReadsCorrectValue()
        {
            const float expected = -0.3f;
            ImFont font = new ImFont { Descent = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                Assert.Equal(expected, ptr.Descent);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that metrics total surface reads correct value
        /// </summary>
        [Fact]
        public void MetricsTotalSurface_ReadsCorrectValue()
        {
            const int expected = 999;
            ImFont font = new ImFont { MetricsTotalSurface = expected };
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                Assert.Equal(expected, ptr.MetricsTotalSurface);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        ///     Tests that im font constructor allocated memory is readable
        /// </summary>
        [Fact]
        public void ImFontConstructor_AllocatedMemory_IsReadable()
        {
            ImFontPtr ptr = new ImFontPtr(default(ImFont));
            try
            {
                _ = ptr.IndexAdvanceX;
                _ = ptr.FallbackAdvanceX;
                _ = ptr.FontSize;
                _ = ptr.IndexLookup;
                _ = ptr.ContainerAtlas;
                _ = ptr.ConfigData;
                _ = ptr.ConfigDataCount;
                _ = ptr.FallbackChar;
                _ = ptr.EllipsisChar;
                _ = ptr.DotChar;
                _ = ptr.DirtyLookupTables;
                _ = ptr.Scale;
                _ = ptr.Ascent;
                _ = ptr.Descent;
                _ = ptr.MetricsTotalSurface;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }
    }
}