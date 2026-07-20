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
using System.Text;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Redifinition;
using Alis.Core.Ecs.Test.Models;
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

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.ReadOnlySpanToImmutableArray" /> works with <see cref="Int32" /> type.
        /// </summary>
        [Fact]
        public void ReadOnlySpanToImmutableArray_IntType()
        {
            ReadOnlySpan<Int32> span = new Int32[] { 10, 20, 30 };

            FastImmutableArray<Int32> result = MemoryHelpers.ReadOnlySpanToImmutableArray(span);

            Assert.Equal(3, result.Length);
            Assert.Equal(10, result[0]);
            Assert.Equal(20, result[1]);
            Assert.Equal(30, result[2]);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.ReadOnlySpanToImmutableArray" /> works with <see cref="String" /> type.
        /// </summary>
        [Fact]
        public void ReadOnlySpanToImmutableArray_StringType()
        {
            ReadOnlySpan<String> span = new String[] { "a", "b", "c" };

            FastImmutableArray<String> result = MemoryHelpers.ReadOnlySpanToImmutableArray(span);

            Assert.Equal(3, result.Length);
            Assert.Equal("a", result[0]);
            Assert.Equal("b", result[1]);
            Assert.Equal("c", result[2]);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.ReadOnlySpanToImmutableArray" /> works with a single element.
        /// </summary>
        [Fact]
        public void ReadOnlySpanToImmutableArray_SingleElement()
        {
            ReadOnlySpan<Int32> span = new Int32[] { 42 };

            FastImmutableArray<Int32> result = MemoryHelpers.ReadOnlySpanToImmutableArray(span);

            Assert.Equal(1, result.Length);
            Assert.Equal(42, result[0]);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.Poison" /> throws for <see cref="ComplexType" /> (struct with references).
        /// </summary>
        [Fact]
        public void Poison_ComplexTypeStructWithReferences_Throws()
        {
            ComplexType ct = default;

            Assert.Throws<NotSupportedException>(() => MemoryHelpers.Poison(ref ct));
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.Poison" /> throws for <see cref="Int32" /> array (reference type).
        /// </summary>
        [Fact]
        public void Poison_IntArrayReferenceType_Throws()
        {
            Int32[] arr = [1, 2, 3];

            Assert.Throws<NotSupportedException>(() => MemoryHelpers.Poison(ref arr));
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.Poison" /> does not throw for <see cref="UInt32" /> value type.
        /// </summary>
        [Fact]
        public void Poison_UintValueType_DoesNotThrow()
        {
            UInt32 v = 42u;

            MemoryHelpers.Poison(ref v);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.RoundDownToPowerOfTwo" /> handles maximum uint value.
        /// </summary>
        [Fact]
        public void RoundDownToPowerOfTwo_MaxValue_ReturnsPowerOfTwo()
        {
            UInt32 result = MemoryHelpers.RoundDownToPowerOfTwo(UInt32.MaxValue);

            Assert.Equal(2147483648u, result);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.RoundDownToPowerOfTwo" /> handles value 2.
        /// </summary>
        [Fact]
        public void RoundDownToPowerOfTwo_Two_ReturnsTwo()
        {
            UInt32 result = MemoryHelpers.RoundDownToPowerOfTwo(2u);

            Assert.Equal(2u, result);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.RoundDownToPowerOfTwo" /> handles value 3.
        /// </summary>
        [Fact]
        public void RoundDownToPowerOfTwo_Three_ReturnsTwo()
        {
            UInt32 result = MemoryHelpers.RoundDownToPowerOfTwo(3u);

            Assert.Equal(2u, result);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.Remove{T}(FastImmutableArray{T}, T)" /> works with single element array.
        /// </summary>
        [Fact]
        public void Remove_SingleType_FromSingleElementArray_ReturnsEmpty()
        {
            ReadOnlySpan<ComponentId> ids = new ComponentId[] { Component<Position>.Id };
            FastImmutableArray<ComponentId> types = MemoryHelpers.ReadOnlySpanToImmutableArray(ids);

            FastImmutableArray<ComponentId> result = MemoryHelpers.Remove(types, Component<Position>.Id);

            Assert.Equal(0, result.Length);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.Remove{T}(FastImmutableArray{T}, ReadOnlySpan{T})" /> removes multiple items in sequence.
        /// </summary>
        [Fact]
        public void Remove_Span_MultipleItems_Sequential()
        {
            ReadOnlySpan<ComponentId> ids = new ComponentId[] { Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id };
            FastImmutableArray<ComponentId> types = MemoryHelpers.ReadOnlySpanToImmutableArray(ids);

            FastImmutableArray<ComponentId> result = MemoryHelpers.Remove(types, new ComponentId[] { Component<Position>.Id, Component<Velocity>.Id }.AsSpan());

            Assert.Equal(1, result.Length);
            Assert.Equal(Component<Health>.Id, result[0]);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.Remove{T}(FastImmutableArray{T}, ReadOnlySpan{T})" /> with empty span returns unchanged array.
        /// </summary>
        [Fact]
        public void Remove_Span_Empty_ReturnsOriginal()
        {
            ReadOnlySpan<ComponentId> ids = new ComponentId[] { Component<Position>.Id, Component<Velocity>.Id };
            FastImmutableArray<ComponentId> types = MemoryHelpers.ReadOnlySpanToImmutableArray(ids);

            FastImmutableArray<ComponentId> result = MemoryHelpers.Remove(types, ReadOnlySpan<ComponentId>.Empty);

            Assert.Equal(2, result.Length);
            Assert.Equal(Component<Position>.Id, result[0]);
            Assert.Equal(Component<Velocity>.Id, result[1]);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.Concat{T}(FastImmutableArray{T}, T)" /> works with empty types array.
        /// </summary>
        [Fact]
        public void Concat_Single_ToEmpty_Once()
        {
            FastImmutableArray<ComponentId> result = MemoryHelpers.Concat(FastImmutableArray<ComponentId>.Empty, Component<Position>.Id);

            Assert.Equal(1, result.Length);
            Assert.Equal(Component<Position>.Id, result[0]);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.GetValueOrResize{T}" /> works with struct arrays.
        /// </summary>
        [Fact]
        public void GetValueOrResize_StructTypeArray()
        {
            Position[] arr = [new Position { X = 1, Y = 2 }];

            ref Position val = ref MemoryHelpers.GetValueOrResize(ref arr, 0);

            Assert.Equal(1f, val.X);
            Assert.Equal(2f, val.Y);
            val.X = 10;
            Assert.Equal(10f, arr[0].X);
        }

        /// <summary>
        ///     Verifies that <see cref="MemoryHelpers.GetValueOrResize{T}" /> resizes with struct type.
        /// </summary>
        [Fact]
        public void GetValueOrResize_StructType_OutOfRange()
        {
            Position[] arr = [new Position { X = 1, Y = 2 }];

            ref Position val = ref MemoryHelpers.GetValueOrResize(ref arr, 5);

            Assert.True(arr.Length >= 6);
            val.X = 100;
            Assert.Equal(100f, arr[5].X);
        }

        /// <summary>
        ///     Verifies <see cref="MemoryHelpers.MemoryHelpersT_Pool" /> works with various types.
        /// </summary>
        [Fact]
        public void MemoryHelpersT_Pool_WithStringAndIntArray()
        {
            Assert.NotNull(MemoryHelpers<String>.Pool);
            Assert.NotNull(MemoryHelpers<Int32[]>.Pool);
            Assert.NotNull(MemoryHelpers<Position>.Pool);
        }

        /// <summary>
        ///     Verifies <see cref="MemoryHelpers.GetOrAddNew{TKey, TValue}" /> with reference type key and value.
        /// </summary>
        [Fact]
        public void GetOrAddNew_WithReferenceType_Works()
        {
            Dictionary<String, StringBuilder> dict = new Dictionary<String, StringBuilder>();

            StringBuilder sb = dict.GetOrAddNew("key");

            Assert.NotNull(sb);
            Assert.Single(dict);
            Assert.Same(sb, dict["key"]);
        }

        /// <summary>
        ///     Verifies <see cref="MemoryHelpers.Concat{T}(FastImmutableArray{T}, T)" /> with array that already contains type.
        /// </summary>
        [Fact]
        public void Concat_Single_Duplicate_InMultiElementArray_Throws()
        {
            ReadOnlySpan<ComponentId> ids = new ComponentId[] { Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id };
            FastImmutableArray<ComponentId> types = MemoryHelpers.ReadOnlySpanToImmutableArray(ids);

            Assert.Throws<InvalidOperationException>(() => MemoryHelpers.Concat(types, Component<Position>.Id));
        }

        /// <summary>
        ///     Verifies <see cref="MemoryHelpers.RoundUpToNextMultipleOf16" /> with negative values.
        /// </summary>
        [Fact]
        public void RoundUpToNextMultipleOf16_NegativeValue()
        {
            Int32 result = MemoryHelpers.RoundUpToNextMultipleOf16(-1);

            Assert.Equal(0, result);
        }

        /// <summary>
        ///     Verifies <see cref="MemoryHelpers.RoundDownToNextMultipleOf16" /> with negative values.
        /// </summary>
        [Fact]
        public void RoundDownToNextMultipleOf16_NegativeValue()
        {
            Int32 result = MemoryHelpers.RoundDownToNextMultipleOf16(-1);

            Assert.Equal(-16, result);
        }
    }
}
