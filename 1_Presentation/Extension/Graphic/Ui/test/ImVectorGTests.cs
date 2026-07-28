// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImVectorGTests.cs
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
    /// The im vector tests class
    /// </summary>
    public class ImVectorGTests
    {
        /// <summary>
        /// Tests that im vector constructor sets size
        /// </summary>
        [Fact]
        public void ImVectorConstructor_SetsSize()
        {
            ImVector vector = new ImVector {Size = 5, Capacity = 10, Data = IntPtr.Zero};
            ImVectorG<int> imVectorG = new ImVectorG<int>(vector);
            Assert.Equal(5, imVectorG.Size);
        }

        /// <summary>
        /// Tests that im vector constructor sets capacity
        /// </summary>
        [Fact]
        public void ImVectorConstructor_SetsCapacity()
        {
            ImVector vector = new ImVector {Size = 5, Capacity = 10, Data = IntPtr.Zero};
            ImVectorG<int> imVectorG = new ImVectorG<int>(vector);
            Assert.Equal(10, imVectorG.Capacity);
        }

        /// <summary>
        /// Tests that im vector constructor sets data
        /// </summary>
        [Fact]
        public void ImVectorConstructor_SetsData()
        {
            IntPtr data = new IntPtr(42);
            ImVector vector = new ImVector {Size = 5, Capacity = 10, Data = data};
            ImVectorG<int> imVectorG = new ImVectorG<int>(vector);
            Assert.Equal(data, imVectorG.Data);
        }

        /// <summary>
        /// Tests that direct constructor sets all fields
        /// </summary>
        [Fact]
        public void DirectConstructor_SetsAllFields()
        {
            IntPtr data = new IntPtr(99);
            ImVectorG<int> imVectorG = new ImVectorG<int>(7, 14, data);
            Assert.Equal(7, imVectorG.Size);
            Assert.Equal(14, imVectorG.Capacity);
            Assert.Equal(data, imVectorG.Data);
        }

        /// <summary>
        /// Tests that indexer with int data returns correct value
        /// </summary>
        [Fact]
        public void Indexer_WithIntData_ReturnsCorrectValue()
        {
            int[] data = {10, 20, 30, 40, 50};
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<int>() * data.Length);
            try
            {
                Marshal.Copy(data, 0, ptr, data.Length);
                ImVectorG<int> imVectorG = new ImVectorG<int>(data.Length, data.Length, ptr);
                Assert.Equal(10, imVectorG[0]);
                Assert.Equal(30, imVectorG[2]);
                Assert.Equal(50, imVectorG[4]);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Tests that indexer with byte data returns correct value
        /// </summary>
        [Fact]
        public void Indexer_WithByteData_ReturnsCorrectValue()
        {
            byte[] data = {1, 2, 3, 4};
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<byte>() * data.Length);
            try
            {
                Marshal.Copy(data, 0, ptr, data.Length);
                ImVectorG<byte> imVectorG = new ImVectorG<byte>(data.Length, data.Length, ptr);
                Assert.Equal(1, imVectorG[0]);
                Assert.Equal(3, imVectorG[2]);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Tests that indexer with float data returns correct value
        /// </summary>
        [Fact]
        public void Indexer_WithFloatData_ReturnsCorrectValue()
        {
            float[] data = {1.5f, 2.5f, 3.5f};
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<float>() * data.Length);
            try
            {
                Marshal.Copy(data, 0, ptr, data.Length);
                ImVectorG<float> imVectorG = new ImVectorG<float>(data.Length, data.Length, ptr);
                Assert.Equal(1.5f, imVectorG[0]);
                Assert.Equal(3.5f, imVectorG[2]);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Tests that indexer with null data throws exception
        /// </summary>
        [Fact]
        public void Indexer_WithNullData_ThrowsException()
        {
            ImVectorG<int> imVectorG = new ImVectorG<int>(10, 20, IntPtr.Zero);
            Assert.Throws<ArgumentNullException>(() => imVectorG[0]);
        }
    }
}
