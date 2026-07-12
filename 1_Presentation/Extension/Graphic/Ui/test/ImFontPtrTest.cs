// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontPtrTest.cs
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
    ///     Provides unit coverage for managed behavior exposed by <see cref="ImFontPtr" />.
    /// </summary>
    public class ImFontPtrTest
    {
        /// <summary>
        ///     Verifies that the constructor from a native pointer preserves its value.
        /// </summary>
        [Fact]
        public void Constructor_WithIntPtr_ShouldPreserveNativePointer()
        {
            IntPtr native = new IntPtr(1234);
            ImFontPtr ptr = new ImFontPtr(native);

            Assert.Equal(native, ptr.NativePtr);
        }

        /// <summary>
        ///     Verifies that the constructor from <see cref="ImFont" /> allocates an unmanaged block.
        /// </summary>
        [Fact]
        public void Constructor_WithImFont_ShouldAllocateNativePointer()
        {
            ImFont font = new ImFont
            {
                FallbackAdvanceX = 4.25f,
                FontSize = 16.0f,
                ConfigData = IntPtr.Zero,
                DirtyLookupTables = 1,
                Scale = 2.0f,
                Ascent = 3.0f,
                Descent = -1.0f,
                MetricsTotalSurface = 512
            };

            ImFontPtr ptr = new ImFontPtr(font);
            try
            {
                Assert.NotEqual(IntPtr.Zero, ptr.NativePtr);
                Assert.Equal(4.25f, ptr.FallbackAdvanceX);
                Assert.Equal(16.0f, ptr.FontSize);
                Assert.True(ptr.DirtyLookupTables);
                Assert.Equal(2.0f, ptr.Scale);
                Assert.Equal(512, ptr.MetricsTotalSurface);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Verifies that setting <see cref="ImFontPtr.ConfigData" /> updates the underlying structure.
        /// </summary>
        [Fact]
        public void ConfigData_Setter_ShouldPersistInNativeStructure()
        {
            ImFont font = new ImFont
            {
                ConfigData = IntPtr.Zero
            };

            ImFontPtr ptr = new ImFontPtr(font);
            try
            {
                ImFontConfigPtr config = new ImFontConfigPtr(new IntPtr(987));
                ptr.ConfigData = config;

                Assert.Equal(config.NativePtr, ptr.ConfigData.NativePtr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }
    }
}