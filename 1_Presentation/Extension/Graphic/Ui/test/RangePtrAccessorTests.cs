// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RangePtrAccessorTests.cs
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

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Provides unit coverage for the <see cref="RangePtrAccessor{T}" /> struct.
    /// </summary>
    public class RangePtrAccessorTests
    {
        /// <summary>
        ///     Verifies that the default struct has a zero pointer and count.
        /// </summary>
        [Fact]
        public void Default_DataAndCount_AreZero()
        {
            RangePtrAccessor<int> accessor = default;

            Assert.Equal(IntPtr.Zero, accessor.Data);
            Assert.Equal(0, accessor.Count);
        }

        /// <summary>
        ///     Verifies that the constructor stores the data pointer.
        /// </summary>
        [Fact]
        public void Constructor_Data_IsStored()
        {
            IntPtr data = new IntPtr(1234);

            RangePtrAccessor<int> accessor = new RangePtrAccessor<int>(data, 7);

            Assert.Equal(data, accessor.Data);
        }

        /// <summary>
        ///     Verifies that the constructor stores the count.
        /// </summary>
        [Fact]
        public void Constructor_Count_IsStored()
        {
            RangePtrAccessor<int> accessor = new RangePtrAccessor<int>(new IntPtr(99), 12);

            Assert.Equal(12, accessor.Count);
        }

        /// <summary>
        ///     Verifies that the constructor stores both the pointer and the count.
        /// </summary>
        [Fact]
        public void Constructor_DataAndCount_AreStored()
        {
            IntPtr data = new IntPtr(0xDEADBEEF);

            RangePtrAccessor<int> accessor = new RangePtrAccessor<int>(data, 3);

            Assert.Equal(data, accessor.Data);
            Assert.Equal(3, accessor.Count);
        }

        /// <summary>
        ///     Verifies that the indexer reads the correct integer value from native memory.
        /// </summary>
        [Fact]
        public void Indexer_ReadsInt_FromNativeMemory()
        {
            int[] expected = { 10, 20, 30, 40 };
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<int>() * expected.Length);
            try
            {
                Marshal.Copy(expected, 0, ptr, expected.Length);
                RangePtrAccessor<int> accessor = new RangePtrAccessor<int>(ptr, expected.Length);

                Assert.Equal(10, accessor[0]);
                Assert.Equal(20, accessor[1]);
                Assert.Equal(30, accessor[2]);
                Assert.Equal(40, accessor[3]);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Verifies that the indexer reads the correct byte value from native memory.
        /// </summary>
        [Fact]
        public void Indexer_ReadsByte_FromNativeMemory()
        {
            byte[] expected = { 0xAB, 0xCD, 0xEF };
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<byte>() * expected.Length);
            try
            {
                Marshal.Copy(expected, 0, ptr, expected.Length);
                RangePtrAccessor<byte> accessor = new RangePtrAccessor<byte>(ptr, expected.Length);

                Assert.Equal(0xAB, accessor[0]);
                Assert.Equal(0xCD, accessor[1]);
                Assert.Equal(0xEF, accessor[2]);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Verifies that the indexer reads the correct float value from native memory.
        /// </summary>
        [Fact]
        public void Indexer_ReadsFloat_FromNativeMemory()
        {
            float[] expected = { 1.5f, -2.25f, 3.75f };
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<float>() * expected.Length);
            try
            {
                Marshal.Copy(expected, 0, ptr, expected.Length);
                RangePtrAccessor<float> accessor = new RangePtrAccessor<float>(ptr, expected.Length);

                Assert.Equal(1.5f, accessor[0], 5);
                Assert.Equal(-2.25f, accessor[1], 5);
                Assert.Equal(3.75f, accessor[2], 5);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Verifies that the indexer reads the correct element for a non-zero offset.
        /// </summary>
        [Fact]
        public void Indexer_ReadsFromCorrectOffset()
        {
            int[] expected = { 100, 200, 300, 400, 500 };
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<int>() * expected.Length);
            try
            {
                Marshal.Copy(expected, 0, ptr, expected.Length);
                RangePtrAccessor<int> accessor = new RangePtrAccessor<int>(ptr, expected.Length);

                Assert.Equal(300, accessor[2]);
                Assert.Equal(500, accessor[4]);
                Assert.Equal(100, accessor[0]);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Verifies that the indexer reflects writes performed directly on the native buffer.
        /// </summary>
        [Fact]
        public void Indexer_ReflectsNativeWrites()
        {
            int[] initial = { 1, 2, 3 };
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<int>() * initial.Length);
            try
            {
                Marshal.Copy(initial, 0, ptr, initial.Length);
                RangePtrAccessor<int> accessor = new RangePtrAccessor<int>(ptr, initial.Length);

                int[] updated = { 7, 8, 9 };
                Marshal.Copy(updated, 0, ptr, updated.Length);

                Assert.Equal(7, accessor[0]);
                Assert.Equal(8, accessor[1]);
                Assert.Equal(9, accessor[2]);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Verifies that the indexer throws for a negative index.
        /// </summary>
        [Fact]
        public void Indexer_NegativeIndex_Throws()
        {
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<int>() * 4);
            try
            {
                RangePtrAccessor<int> accessor = new RangePtrAccessor<int>(ptr, 4);

                Assert.Throws<CustomIndexOutOfRangeException>(() => accessor[-1]);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Verifies that the indexer throws when the index equals the count.
        /// </summary>
        [Fact]
        public void Indexer_IndexEqualsCount_Throws()
        {
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<int>() * 4);
            try
            {
                RangePtrAccessor<int> accessor = new RangePtrAccessor<int>(ptr, 4);

                Assert.Throws<CustomIndexOutOfRangeException>(() => accessor[4]);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Verifies that the indexer throws when the index is beyond the count.
        /// </summary>
        [Fact]
        public void Indexer_IndexBeyondCount_Throws()
        {
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<int>() * 4);
            try
            {
                RangePtrAccessor<int> accessor = new RangePtrAccessor<int>(ptr, 4);

                Assert.Throws<CustomIndexOutOfRangeException>(() => accessor[10]);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        ///     Verifies that the indexer throws when the count is zero.
        /// </summary>
        [Fact]
        public void Indexer_ZeroCount_Throws()
        {
            RangePtrAccessor<int> accessor = new RangePtrAccessor<int>(IntPtr.Zero, 0);

            Assert.Throws<CustomIndexOutOfRangeException>(() => accessor[0]);
        }
    }
}
