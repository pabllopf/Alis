// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RangePtrAccessorTest.cs
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
using Alis.Core.Aspect.Math.Matrix;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    ///     The range ptr accessor test class
    /// </summary>
    public class RangePtrAccessorTest
    {
        /// <summary>
        ///     Tests that data should be initialized correctly
        /// </summary>
        [Fact]
        public void Data_ShouldBeInitializedCorrectly()
        {
            // Arrange
            IntPtr data = new IntPtr(123);
            RangePtrAccessor<int> accessor = new RangePtrAccessor<int>(data, 10);

            // Act
            IntPtr result = accessor.Data;

            // Assert
            Assert.Equal(data, result);
        }

        /// <summary>
        ///     Tests that count should be initialized correctly
        /// </summary>
        [Fact]
        public void Count_ShouldBeInitializedCorrectly()
        {
            // Arrange
            RangePtrAccessor<int> accessor = new RangePtrAccessor<int>(new IntPtr(123), 10);

            // Act
            int result = accessor.Count;

            // Assert
            Assert.Equal(10, result);
        }

        /// <summary>
        ///     Tests that indexer should return correct value
        /// </summary>
        [Fact]
        public void Indexer_ShouldReturnCorrectValue()
        {
            // Arrange
            int[] data = {1, 2, 3, 4, 5};
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<int>() * data.Length);
            Marshal.Copy(data, 0, ptr, data.Length);
            RangePtrAccessor<int> accessor = new RangePtrAccessor<int>(ptr, data.Length);

            // Act
            int result = accessor[2];

            // Assert
            Assert.Equal(3, result);

            // Cleanup
            Marshal.FreeHGlobal(ptr);
        }

        /// <summary>
        ///     Tests that indexer should throw index out of range exception
        /// </summary>
        [Fact]
        public void Indexer_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            RangePtrAccessor<int> accessor = new RangePtrAccessor<int>(new IntPtr(123), 10);

            // Act & Assert
            Assert.Throws<CustomIndexOutOfRangeException>(() => accessor[10]);
        }
    }
}