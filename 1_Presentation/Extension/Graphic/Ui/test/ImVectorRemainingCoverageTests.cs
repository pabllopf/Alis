// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImVectorRemainingCoverageTests.cs
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
    ///     The im vector remaining coverage tests class
    /// </summary>
    public class ImVectorRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that default size should be zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void DefaultSize_ShouldBeZero()
        {
            ImVector vector = default;
            Assert.Equal(0, vector.Size);
        }

        /// <summary>
        ///     Tests that default capacity should be zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void DefaultCapacity_ShouldBeZero()
        {
            ImVector vector = default;
            Assert.Equal(0, vector.Capacity);
        }

        /// <summary>
        ///     Tests that default data should be zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void DefaultData_ShouldBeZero()
        {
            ImVector vector = default;
            Assert.Equal(IntPtr.Zero, vector.Data);
        }

        /// <summary>
        ///     Tests that constructor should set properties
        /// </summary>
         [RequireCImguiSystemFact]
        public void Constructor_ShouldSetProperties()
        {
            IntPtr data = new IntPtr(42);
            ImVector vector = new ImVector(5, 10, data);
            Assert.Equal(5, vector.Size);
            Assert.Equal(10, vector.Capacity);
            Assert.Equal(data, vector.Data);
        }

        /// <summary>
        ///     Tests that properties should be mutable
        /// </summary>
         [RequireCImguiSystemFact]
        public void Properties_ShouldBeMutable()
        {
            ImVector vector = default;
            vector.Size = 7;
            vector.Capacity = 14;
            IntPtr data = new IntPtr(99);
            vector.Data = data;
            Assert.Equal(7, vector.Size);
            Assert.Equal(14, vector.Capacity);
            Assert.Equal(data, vector.Data);
        }
        /// <summary>
        ///     Tests that ref method should read int from allocated memory
        /// </summary>
         [RequireCImguiSystemFact]
        public void Ref_ShouldReadInt()
        {
            IntPtr data = Marshal.AllocHGlobal(sizeof(int));
            Marshal.WriteInt32(data, 42);
            ImVector vector = new ImVector(1, 1, data);
            Assert.Equal(42, vector.Ref<int>(0));
            Marshal.FreeHGlobal(data);
        }

        /// <summary>
        ///     Tests that ref should read int at non zero index
        /// </summary>
         [RequireCImguiSystemFact]
        public void Ref_ShouldReadIntAtIndex()
        {
            IntPtr data = Marshal.AllocHGlobal(sizeof(int) * 3);
            for (int i = 0; i < 3; i++)
                Marshal.WriteInt32(data + i * sizeof(int), (i + 1) * 10);
            ImVector vector = new ImVector(3, 3, data);
            Assert.Equal(10, vector.Ref<int>(0));
            Assert.Equal(20, vector.Ref<int>(1));
            Assert.Equal(30, vector.Ref<int>(2));
            Marshal.FreeHGlobal(data);
        }

        /// <summary>
        ///     Tests that ref should read byte
        /// </summary>
         [RequireCImguiSystemFact]
        public void Ref_ShouldReadByte()
        {
            IntPtr data = Marshal.AllocHGlobal(sizeof(byte));
            Marshal.WriteByte(data, 7);
            ImVector vector = new ImVector(1, 1, data);
            Assert.Equal((byte)7, vector.Ref<byte>(0));
            Marshal.FreeHGlobal(data);
        }

        /// <summary>
        ///     Tests that address should return data pointer at index zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void Address_ShouldReturnDataPointer()
        {
            IntPtr data = new IntPtr(123);
            ImVector vector = new ImVector(1, 1, data);
            Assert.Equal(data, vector.Address<int>(0));
        }

        /// <summary>
        ///     Tests that address should return advanced pointer at non zero index
        /// </summary>
         [RequireCImguiSystemFact]
        public void Address_ShouldReturnAdvancedPointer()
        {
            IntPtr data = new IntPtr(100);
            ImVector vector = new ImVector(2, 2, data);
            Assert.Equal(data + sizeof(int), vector.Address<int>(1));
        }

        /// <summary>
        ///     Tests that address with byte type should advance by byte size
        /// </summary>
         [RequireCImguiSystemFact]
        public void Address_WithByteType_ShouldAdvanceByByteSize()
        {
            IntPtr data = new IntPtr(100);
            ImVector vector = new ImVector(2, 2, data);
            Assert.Equal(data + sizeof(byte), vector.Address<byte>(1));
        }
    }
}
