// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontPtrTests.cs
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
    /// The im font ptr tests class
    /// </summary>
    public class ImFontPtrTests
    {
        /// <summary>
        /// Natives the ptr from int ptr constructor returns same pointer
        /// </summary>
        [RequireCImguiSystemFact]
        public void NativePtr_FromIntPtrConstructor_ReturnsSamePointer()
        {
            IntPtr expected = new IntPtr(0xABCD);
            ImFontPtr ptr = new ImFontPtr(expected);
            Assert.Equal(expected, ptr.NativePtr);
        }

        /// <summary>
        /// Natives the ptr from im font constructor returns non zero
        /// </summary>
        [RequireCImguiSystemFact]
        public void NativePtr_FromImFontConstructor_ReturnsNonZero()
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
        /// Fallbacks the advance x reads correct value
        /// </summary>
        [RequireCImguiSystemFact]
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
        /// Fonts the size reads correct value
        /// </summary>
        [RequireCImguiSystemFact]
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
        /// Configs the data count reads correct value
        /// </summary>
        [RequireCImguiSystemFact]
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
        /// Fallbacks the char reads correct value
        /// </summary>
        [RequireCImguiSystemFact]
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
        /// Ellipsises the char reads correct value
        /// </summary>
        [RequireCImguiSystemFact]
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
        /// Dots the char reads correct value
        /// </summary>
        [RequireCImguiSystemFact]
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
        /// Dirties the lookup tables true returns true
        /// </summary>
        [RequireCImguiSystemFact]
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
        /// Dirties the lookup tables false returns false
        /// </summary>
        [RequireCImguiSystemFact]
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
        /// Scales the reads correct value
        /// </summary>
        [RequireCImguiSystemFact]
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
        /// Ascents the reads correct value
        /// </summary>
        [RequireCImguiSystemFact]
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
        /// Descents the reads correct value
        /// </summary>
        [RequireCImguiSystemFact]
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
        /// Metricses the total surface reads correct value
        /// </summary>
        [RequireCImguiSystemFact]
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
        /// Indexes the advance x reads correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void IndexAdvanceX_ReadsCorrectValue()
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
        /// Indexes the lookup reads correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void IndexLookup_ReadsCorrectValue()
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
        /// Containers the atlas reads correct value
        /// </summary>
        [RequireCImguiSystemFact]
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
        /// Configs the data getter reads correct value
        /// </summary>
        [RequireCImguiSystemFact]
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
        /// Configs the data setter persists to native structure
        /// </summary>
        [RequireCImguiSystemFact]
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
                ImFont result = Marshal.PtrToStructure<ImFont>(nativePtr);
                Assert.Equal(new IntPtr(0x5678), result.ConfigData);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Implicits the conversion to int ptr returns native ptr
        /// </summary>
        [RequireCImguiSystemFact]
        public void ImplicitConversion_ToIntPtr_ReturnsNativePtr()
        {
            IntPtr native = new IntPtr(0x7777);
            ImFontPtr ptr = new ImFontPtr(native);
            IntPtr result = ptr;
            Assert.Equal(native, result);
        }

        /// <summary>
        /// Implicits the conversion from int ptr creates im font ptr
        /// </summary>
        [RequireCImguiSystemFact]
        public void ImplicitConversion_FromIntPtr_CreatesImFontPtr()
        {
            IntPtr native = new IntPtr(0x8888);
            ImFontPtr ptr = native;
            Assert.Equal(native, ptr.NativePtr);
        }

        /// <summary>
        /// Constructors the with im font roundtrips all properties
        /// </summary>
        [RequireCImguiSystemFact]
        public void Constructor_WithImFont_RoundtripsAllProperties()
        {
            ImFont font = new ImFont
            {
                FallbackAdvanceX = 2.5f,
                FontSize = 18.0f,
                Scale = 1.25f,
                Ascent = 0.75f,
                Descent = -0.25f,
                MetricsTotalSurface = 2048,
                ConfigDataCount = 2,
                FallbackChar = 0xFFFD,
                EllipsisChar = 0x2026,
                DotChar = 46,
                DirtyLookupTables = 1
            };

            ImFontPtr ptr = new ImFontPtr(font);
            try
            {
                Assert.Equal(font.FallbackAdvanceX, ptr.FallbackAdvanceX);
                Assert.Equal(font.FontSize, ptr.FontSize);
                Assert.Equal(font.Scale, ptr.Scale);
                Assert.Equal(font.Ascent, ptr.Ascent);
                Assert.Equal(font.Descent, ptr.Descent);
                Assert.Equal(font.MetricsTotalSurface, ptr.MetricsTotalSurface);
                Assert.Equal(font.ConfigDataCount, ptr.ConfigDataCount);
                Assert.Equal(font.FallbackChar, ptr.FallbackChar);
                Assert.Equal(font.EllipsisChar, ptr.EllipsisChar);
                Assert.Equal(font.DotChar, ptr.DotChar);
                Assert.True(ptr.DirtyLookupTables);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        /// Zeroes the native ptr accessing properties throws null reference
        /// </summary>
        [RequireCImguiSystemFact]
        public void ZeroNativePtr_AccessingProperties_ThrowsNullReference()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            Assert.Throws<NullReferenceException>(() => _ = ptr.FallbackAdvanceX);
        }

        /// <summary>
        /// Ims the font constructor allocated memory is readable
        /// </summary>
        [RequireCImguiSystemFact]
        public void ImFontConstructor_AllocatedMemory_IsReadable()
        {
            ImFontPtr ptr = new ImFontPtr(default(ImFont));
            try
            {
                _ = ptr.FallbackAdvanceX;
                _ = ptr.FontSize;
                _ = ptr.Scale;
                _ = ptr.Ascent;
                _ = ptr.Descent;
                _ = ptr.MetricsTotalSurface;
                _ = ptr.ConfigDataCount;
                _ = ptr.FallbackChar;
                _ = ptr.EllipsisChar;
                _ = ptr.DotChar;
                _ = ptr.DirtyLookupTables;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        /// Multiples the ptrs independent memory do not interfere
        /// </summary>
        [RequireCImguiSystemFact]
        public void MultiplePtrs_IndependentMemory_DoNotInterfere()
        {
            ImFont font1 = new ImFont { FallbackAdvanceX = 1.0f, FontSize = 10.0f };
            ImFont font2 = new ImFont { FallbackAdvanceX = 2.0f, FontSize = 20.0f };

            ImFontPtr ptr1 = new ImFontPtr(font1);
            ImFontPtr ptr2 = new ImFontPtr(font2);
            try
            {
                Assert.Equal(1.0f, ptr1.FallbackAdvanceX);
                Assert.Equal(10.0f, ptr1.FontSize);
                Assert.Equal(2.0f, ptr2.FallbackAdvanceX);
                Assert.Equal(20.0f, ptr2.FontSize);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr1.NativePtr);
                Marshal.FreeHGlobal(ptr2.NativePtr);
            }
        }

        /// <summary>
        /// Configs the data setter multiple writes last value persists
        /// </summary>
        [RequireCImguiSystemFact]
        public void ConfigData_Setter_MultipleWrites_LastValuePersists()
        {
            ImFontPtr ptr = new ImFontPtr(default(ImFont));
            try
            {
                ImFontConfigPtr config1 = new ImFontConfigPtr(new IntPtr(0x1111));
                ImFontConfigPtr config2 = new ImFontConfigPtr(new IntPtr(0x2222));
                ptr.ConfigData = config1;
                ptr.ConfigData = config2;
                Assert.Equal(new IntPtr(0x2222), ptr.ConfigData.NativePtr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        /// Natives the ptr zero value implicit conversion preserves zero
        /// </summary>
        [RequireCImguiSystemFact]
        public void NativePtr_ZeroValue_ImplicitConversionPreservesZero()
        {
            ImFontPtr ptr = new ImFontPtr(IntPtr.Zero);
            IntPtr result = ptr;
            Assert.Equal(IntPtr.Zero, result);
        }
    }
}
