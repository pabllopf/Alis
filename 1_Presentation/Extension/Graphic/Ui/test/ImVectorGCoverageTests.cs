// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImVectorGCoverageTests.cs
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
    ///     The im vector g coverage tests class
    /// </summary>
    public class ImVectorGCoverageTests
    {
        /// <summary>
        ///     Tests that default size should be zero
        /// </summary>
        [Fact]
        public void Default_Size_ShouldBeZero()
        {
            ImVectorG<int> vector = default;
            Assert.Equal(0, vector.Size);
        }

        /// <summary>
        ///     Tests that default capacity should be zero
        /// </summary>
        [Fact]
        public void Default_Capacity_ShouldBeZero()
        {
            ImVectorG<int> vector = default;
            Assert.Equal(0, vector.Capacity);
        }

        /// <summary>
        ///     Tests that default data should be zero
        /// </summary>
        [Fact]
        public void Default_Data_ShouldBeZero()
        {
            ImVectorG<int> vector = default;
            Assert.Equal(IntPtr.Zero, vector.Data);
        }

        /// <summary>
        ///     Tests that constructor from im vector should copy size
        /// </summary>
        [Fact]
        public void Constructor_FromImVector_ShouldCopySize()
        {
            ImVector source = new ImVector {Size = 3, Capacity = 6, Data = IntPtr.Zero};
            ImVectorG<int> vector = new ImVectorG<int>(source);
            Assert.Equal(3, vector.Size);
        }

        /// <summary>
        ///     Tests that constructor from im vector should copy capacity
        /// </summary>
        [Fact]
        public void Constructor_FromImVector_ShouldCopyCapacity()
        {
            ImVector source = new ImVector {Size = 3, Capacity = 6, Data = IntPtr.Zero};
            ImVectorG<int> vector = new ImVectorG<int>(source);
            Assert.Equal(6, vector.Capacity);
        }

        /// <summary>
        ///     Tests that constructor from im vector should copy data
        /// </summary>
        [Fact]
        public void Constructor_FromImVector_ShouldCopyData()
        {
            IntPtr data = new IntPtr(42);
            ImVector source = new ImVector {Size = 3, Capacity = 6, Data = data};
            ImVectorG<int> vector = new ImVectorG<int>(source);
            Assert.Equal(data, vector.Data);
        }

        /// <summary>
        ///     Tests that direct constructor should set all fields
        /// </summary>
        [Fact]
        public void DirectConstructor_ShouldSetAllFields()
        {
            IntPtr data = new IntPtr(99);
            ImVectorG<int> vector = new ImVectorG<int>(7, 14, data);
            Assert.Equal(7, vector.Size);
            Assert.Equal(14, vector.Capacity);
            Assert.Equal(data, vector.Data);
        }

        /// <summary>
        ///     Tests that indexer with int data should return values
        /// </summary>
        [Fact]
        public void Indexer_WithIntData_ShouldReturnValues()
        {
            int[] data = {10, 20, 30, 40, 50};
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<int>() * data.Length);
            try
            {
                Marshal.Copy(data, 0, ptr, data.Length);
                ImVectorG<int> vector = new ImVectorG<int>(data.Length, data.Length, ptr);
                Assert.Equal(10, vector[0]);
                Assert.Equal(30, vector[2]);
                Assert.Equal(50, vector[4]);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Tests that indexer with byte data should return values
        /// </summary>
        [Fact]
        public void Indexer_WithByteData_ShouldReturnValues()
        {
            byte[] data = {1, 2, 3, 4};
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<byte>() * data.Length);
            try
            {
                Marshal.Copy(data, 0, ptr, data.Length);
                ImVectorG<byte> vector = new ImVectorG<byte>(data.Length, data.Length, ptr);
                Assert.Equal(1, vector[0]);
                Assert.Equal(3, vector[2]);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Tests that indexer with float data should return values
        /// </summary>
        [Fact]
        public void Indexer_WithFloatData_ShouldReturnValues()
        {
            float[] data = {1.5f, 2.5f, 3.5f};
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<float>() * data.Length);
            try
            {
                Marshal.Copy(data, 0, ptr, data.Length);
                ImVectorG<float> vector = new ImVectorG<float>(data.Length, data.Length, ptr);
                Assert.Equal(1.5f, vector[0], 5);
                Assert.Equal(3.5f, vector[2], 5);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
    }
}
