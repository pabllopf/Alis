// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontConfigPtrRemainingCoverageTests.cs
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
    /// The im font config ptr remaining coverage tests class
    /// </summary>
    public class ImFontConfigPtrRemainingCoverageTests
    {
        /// <summary>
        /// Tests that implicit conversion to int ptr returns native ptr
        /// </summary>
        [RequireCImguiSystemFact]
        public void ImplicitConversionToIntPtr_ReturnsNativePtr()
        {
            IntPtr nativePtr = new IntPtr(42);
            ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);
            IntPtr result = ptr;
            Assert.Equal(nativePtr, result);
        }

        /// <summary>
        /// Tests that implicit conversion from int ptr returns im font config ptr
        /// </summary>
        [RequireCImguiSystemFact]
        public void ImplicitConversionFromIntPtr_ReturnsImFontConfigPtr()
        {
            IntPtr nativePtr = new IntPtr(99);
            ImFontConfigPtr ptr = nativePtr;
            Assert.Equal(nativePtr, ptr.NativePtr);
        }

        /// <summary>
        /// Tests that snap h setter sets value to true
        /// </summary>
        [RequireCImguiSystemFact]
        public void SnapH_Setter_SetsValueToTrue()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig();
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
        /// Tests that snap h setter sets value to false
        /// </summary>
        [RequireCImguiSystemFact]
        public void SnapH_Setter_SetsValueToFalse()
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
        /// Tests that glyph ranges setter sets value
        /// </summary>
        [RequireCImguiSystemFact]
        public void GlyphRanges_Setter_SetsValue()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig();
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);

                IntPtr expected = new IntPtr(12345);
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
        /// Tests that glyph min advance x setter sets value
        /// </summary>
        [RequireCImguiSystemFact]
        public void GlyphMinAdvanceX_Setter_SetsValue()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig();
                Marshal.StructureToPtr(config, nativePtr, false);
                ImFontConfigPtr ptr = new ImFontConfigPtr(nativePtr);

                ptr.GlyphMinAdvanceX = 3.14f;

                ImFontConfig result = Marshal.PtrToStructure<ImFontConfig>(nativePtr);
                Assert.Equal(3.14f, result.GlyphMinAdvanceX, 5);
                Assert.Equal(3.14f, ptr.GlyphMinAdvanceX, 5);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that merge mode setter sets value to true
        /// </summary>
        [RequireCImguiSystemFact]
        public void MergeMode_Setter_SetsValueToTrue()
        {
            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                ImFontConfig config = new ImFontConfig();
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
        /// Tests that merge mode setter sets value to false
        /// </summary>
        [RequireCImguiSystemFact]
        public void MergeMode_Setter_SetsValueToFalse()
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
        /// Tests that constructor with im font config allocates memory
        /// </summary>
        [RequireCImguiSystemFact]
        public void ConstructorWithImFontConfig_AllocatesMemory()
        {
            ImFontConfig config = new ImFontConfig
            {
                FontData = new IntPtr(55),
                FontDataSize = 100,
                SizePixels = 16.0f,
                OversampleH = 2,
                OversampleV = 3
            };

            ImFontConfigPtr ptr = new ImFontConfigPtr(config);

            Assert.NotEqual(IntPtr.Zero, ptr.NativePtr);
            Assert.Equal(config.FontData, ptr.FontData);
            Assert.Equal(config.FontDataSize, ptr.FontDataSize);
            Assert.Equal(config.SizePixels, ptr.SizePixels);
            Assert.Equal(config.OversampleH, ptr.OversampleH);
            Assert.Equal(config.OversampleV, ptr.OversampleV);

            Marshal.FreeHGlobal(ptr.NativePtr);
        }

        /// <summary>
        /// Tests that constructor with im font config zero pointer throws access violation
        /// </summary>
        [RequireCImguiSystemFact]
        public void ConstructorWithImFontConfig_ZeroPointer_ThrowsAccessViolation()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);

            Assert.Throws<NullReferenceException>(() => _ = ptr.FontData);
        }
    }
}
