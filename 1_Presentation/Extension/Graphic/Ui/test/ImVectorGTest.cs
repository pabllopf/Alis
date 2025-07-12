// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImVectorGTest.cs
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
    ///     The im vector test class
    /// </summary>
    public class ImVectorGTest
    {
        /// <summary>
        ///     Tests that size should be initialized correctly
        /// </summary>
        [Fact]
        public void Size_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImVector vector = new ImVector {Size = 10, Capacity = 20, Data = IntPtr.Zero};
            ImVectorG<int> imVectorG = new ImVectorG<int>(vector);

            // Act
            int size = imVectorG.Size;

            // Assert
            Assert.Equal(10, size);
        }

        /// <summary>
        ///     Tests that capacity should be initialized correctly
        /// </summary>
        [Fact]
        public void Capacity_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImVector vector = new ImVector {Size = 10, Capacity = 20, Data = IntPtr.Zero};
            ImVectorG<int> imVectorG = new ImVectorG<int>(vector);

            // Act
            int capacity = imVectorG.Capacity;

            // Assert
            Assert.Equal(20, capacity);
        }

        /// <summary>
        ///     Tests that data should be initialized correctly
        /// </summary>
        [Fact]
        public void Data_ShouldBeInitializedCorrectly()
        {
            // Arrange
            IntPtr data = new IntPtr(123);
            ImVector vector = new ImVector {Size = 10, Capacity = 20, Data = data};
            ImVectorG<int> imVectorG = new ImVectorG<int>(vector);

            // Act
            IntPtr result = imVectorG.Data;

            // Assert
            Assert.Equal(data, result);
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
            ImVectorG<int> imVectorG = new ImVectorG<int>(data.Length, data.Length, ptr);

            // Act
            int result = imVectorG[2];

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
            ImVectorG<int> imVectorG = new ImVectorG<int>(10, 20, IntPtr.Zero);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => imVectorG[10]);
        }
    }
}