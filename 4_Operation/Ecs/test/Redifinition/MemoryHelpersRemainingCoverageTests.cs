// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MemoryHelpersRemainingCoverageTests.cs
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
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Redifinition;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Redifinition
{
    /// <summary>
    ///     Remaining coverage tests for <see cref="MemoryHelpers" />.
    /// </summary>
    public class MemoryHelpersRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.RoundDownToPowerOfTwo" /> returns 1 for input 0.
        /// </summary>
        [Fact]
        public void RoundDownToPowerOfTwo_Zero_ReturnsOne()
        {
            UInt32 result = MemoryHelpers.RoundDownToPowerOfTwo(0u);

            Assert.Equal(1u, result);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.RoundDownToPowerOfTwo" /> returns 64 for input 100.
        /// </summary>
        [Fact]
        public void RoundDownToPowerOfTwo_100_Returns64()
        {
            UInt32 result = MemoryHelpers.RoundDownToPowerOfTwo(100u);

            Assert.Equal(64u, result);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.RoundUpToNextMultipleOf16" /> returns 112 for input 100.
        /// </summary>
        [Fact]
        public void RoundUpToNextMultipleOf16_100_Returns112()
        {
            Int32 result = MemoryHelpers.RoundUpToNextMultipleOf16(100);

            Assert.Equal(112, result);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.RoundDownToNextMultipleOf16" /> returns 96 for input 100.
        /// </summary>
        [Fact]
        public void RoundDownToNextMultipleOf16_100_Returns96()
        {
            Int32 result = MemoryHelpers.RoundDownToNextMultipleOf16(100);

            Assert.Equal(96, result);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.BoolToByte" /> returns the expected byte values.
        /// </summary>
        [Fact]
        public void BoolToByte_ReturnsExplicitByte()
        {
            Byte trueByte = MemoryHelpers.BoolToByte(true);
            Byte falseByte = MemoryHelpers.BoolToByte(false);

            Assert.Equal((Byte)1, trueByte);
            Assert.Equal((Byte)0, falseByte);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.GetOrAddNew" /> works with value type <see cref="Int32" />.
        /// </summary>
        [Fact]
        public void GetOrAddNew_WithIntValueType_ReturnsDefault()
        {
            Dictionary<String, Int32> dict = new Dictionary<String, Int32>();

            Int32 val1 = dict.GetOrAddNew("a");
            Int32 val2 = dict.GetOrAddNew("a");

            Assert.Equal(0, val1);
            Assert.Equal(0, val2);
            Assert.Single(dict);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.GetOrAddNew" /> throws <see cref="ArgumentNullException" /> for null key.
        /// </summary>
        [Fact]
        public void GetOrAddNew_NullKey_ThrowsArgumentNullException()
        {
            Dictionary<String, Object> dict = new Dictionary<String, Object>();

            Assert.Throws<ArgumentNullException>(() => dict.GetOrAddNew(null));
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.GetValueOrResize" /> resizes when index equals array length.
        /// </summary>
        [Fact]
        public void GetValueOrResize_AtCapacityBoundary_Resizes()
        {
            Int32[] arr = [10, 20, 30];

            ref Int32 val = ref MemoryHelpers.GetValueOrResize(ref arr, 3);

            Assert.True(arr.Length >= 4);
            val = 40;
            Assert.Equal(40, arr[3]);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.GetValueOrResize" /> works with reference type arrays.
        /// </summary>
        [Fact]
        public void GetValueOrResize_WithStringArray_Works()
        {
            String[] arr = ["a", "b", "c"];

            ref String val = ref MemoryHelpers.GetValueOrResize(ref arr, 1);

            Assert.Equal("b", val);
            val = "x";
            Assert.Equal("x", arr[1]);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.Poison" /> does not throw for a default <see cref="Int32" />.
        /// </summary>
        [Fact]
        public void Poison_DefaultInt_DoesNotThrow()
        {
            Int32 v = default;

            MemoryHelpers.Poison(ref v);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.Poison" /> does not throw for <see cref="Int64" />.
        /// </summary>
        [Fact]
        public void Poison_LongValueType_DoesNotThrow()
        {
            Int64 v = 42;

            MemoryHelpers.Poison(ref v);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.Poison" /> does not throw for <see cref="Double" />.
        /// </summary>
        [Fact]
        public void Poison_DoubleValueType_DoesNotThrow()
        {
            Double v = 3.14;

            MemoryHelpers.Poison(ref v);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.Poison" /> throws <see cref="NotSupportedException" /> for a null string
        ///     reference.
        /// </summary>
        [Fact]
        public void Poison_NullString_ThrowsNotSupportedException()
        {
            String s = null;

            Assert.Throws<NotSupportedException>(() => MemoryHelpers.Poison(ref s));
        }

        /// <summary>
        ///     Verifies that <see cref="Unsafe.SizeOf" /> returns 2 for <see cref="MemoryHelpers.Block2" />.
        /// </summary>
        [Fact]
        public void Block2_UnsafeSizeOf_Returns2()
        {
            Int32 size = Unsafe.SizeOf<MemoryHelpers.Block2>();

            Assert.Equal(2, size);
        }

        /// <summary>
        ///     Verifies that <see cref="Unsafe.SizeOf" /> returns 4 for <see cref="MemoryHelpers.Block4" />.
        /// </summary>
        [Fact]
        public void Block4_UnsafeSizeOf_Returns4()
        {
            Int32 size = Unsafe.SizeOf<MemoryHelpers.Block4>();

            Assert.Equal(4, size);
        }

        /// <summary>
        ///     Verifies that <see cref="Unsafe.SizeOf" /> returns 8 for <see cref="MemoryHelpers.Block8" />.
        /// </summary>
        [Fact]
        public void Block8_UnsafeSizeOf_Returns8()
        {
            Int32 size = Unsafe.SizeOf<MemoryHelpers.Block8>();

            Assert.Equal(8, size);
        }

        /// <summary>
        ///     Verifies that <see cref="Unsafe.SizeOf" /> returns 16 for <see cref="MemoryHelpers.Block16" />.
        /// </summary>
        [Fact]
        public void Block16_UnsafeSizeOf_Returns16()
        {
            Int32 size = Unsafe.SizeOf<MemoryHelpers.Block16>();

            Assert.Equal(16, size);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.SharedTempComponentHandleBuffer" /> is initialized lazily with at least 8
        ///     elements.
        /// </summary>
        [Fact]
        public void SharedTempComponentHandleBuffer_LengthAtLeast8()
        {
            ComponentHandle[] buffer = MemoryHelpers.SharedTempComponentHandleBuffer;

            Assert.NotNull(buffer);
            Assert.True(buffer.Length >= 8);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.SharedTempComponentStorageBuffer" /> is initialized lazily with at least 8
        ///     elements.
        /// </summary>
        [Fact]
        public void SharedTempComponentStorageBuffer_LengthAtLeast8()
        {
            ComponentStorageBase[] buffer = MemoryHelpers.SharedTempComponentStorageBuffer;

            Assert.NotNull(buffer);
            Assert.True(buffer.Length >= 8);
        }
    }
}
