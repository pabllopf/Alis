// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MemoryHelpersTest.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Redifinition;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Redifinition
{
    /// <summary>
    /// The memory helpers test class
    /// </summary>
    public class MemoryHelpersTest
    {
        /// <summary>
        /// Tests that max component count is 127
        /// </summary>
        [Fact]
        public void MaxComponentCount_Is127() => Assert.Equal(127, MemoryHelpers.MaxComponentCount);

        /// <summary>
        /// Tests that shared temp component handle buffer initialized on get
        /// </summary>
        [Fact]
        public void SharedTempComponentHandleBuffer_InitializedOnGet()
        {
            ComponentHandle[] buffer = MemoryHelpers.SharedTempComponentHandleBuffer;
            Assert.NotNull(buffer);
            Assert.Equal(8, buffer.Length);
        }

        /// <summary>
        /// Tests that shared temp component storage buffer initialized on get
        /// </summary>
        [Fact]
        public void SharedTempComponentStorageBuffer_InitializedOnGet()
        {
            ComponentStorageBase[] buffer = MemoryHelpers.SharedTempComponentStorageBuffer;
            Assert.NotNull(buffer);
            Assert.Equal(8, buffer.Length);
        }

        /// <summary>
        /// Tests that round down to power of two values
        /// </summary>
        [Fact]
        public void RoundDownToPowerOfTwo_Values()
        {
            Assert.Equal(1u, MemoryHelpers.RoundDownToPowerOfTwo(1));
            Assert.Equal(2u, MemoryHelpers.RoundDownToPowerOfTwo(2));
            Assert.Equal(2u, MemoryHelpers.RoundDownToPowerOfTwo(3));
            Assert.Equal(4u, MemoryHelpers.RoundDownToPowerOfTwo(4));
            Assert.Equal(4u, MemoryHelpers.RoundDownToPowerOfTwo(7));
            Assert.Equal(8u, MemoryHelpers.RoundDownToPowerOfTwo(8));
            Assert.Equal(8u, MemoryHelpers.RoundDownToPowerOfTwo(15));
            Assert.Equal(16u, MemoryHelpers.RoundDownToPowerOfTwo(16));
            Assert.Equal(1073741824u, MemoryHelpers.RoundDownToPowerOfTwo(1073741824));
            Assert.Equal(1073741824u, MemoryHelpers.RoundDownToPowerOfTwo(2000000000u));
        }

        /// <summary>
        /// Tests that round down to power of two monotonic
        /// </summary>
        [Fact]
        public void RoundDownToPowerOfTwo_Monotonic()
        {
            uint prev = 0;
            for (uint i = 1; i <= 256; i++)
            {
                uint result = MemoryHelpers.RoundDownToPowerOfTwo(i);
                Assert.True(result >= prev);
                Assert.True((result & (result - 1)) == 0 || result == 0);
                prev = result;
            }
        }

        /// <summary>
        /// Tests that round up to next multiple of 16 values
        /// </summary>
        [Fact]
        public void RoundUpToNextMultipleOf16_Values()
        {
            Assert.Equal(0, MemoryHelpers.RoundUpToNextMultipleOf16(0));
            Assert.Equal(16, MemoryHelpers.RoundUpToNextMultipleOf16(1));
            Assert.Equal(16, MemoryHelpers.RoundUpToNextMultipleOf16(15));
            Assert.Equal(16, MemoryHelpers.RoundUpToNextMultipleOf16(16));
            Assert.Equal(32, MemoryHelpers.RoundUpToNextMultipleOf16(17));
            Assert.Equal(32, MemoryHelpers.RoundUpToNextMultipleOf16(31));
            Assert.Equal(32, MemoryHelpers.RoundUpToNextMultipleOf16(32));
            Assert.Equal(48, MemoryHelpers.RoundUpToNextMultipleOf16(33));
        }

        /// <summary>
        /// Tests that round up to next multiple of 16 idempotent
        /// </summary>
        [Fact]
        public void RoundUpToNextMultipleOf16_Idempotent()
        {
            foreach (int v in new[] { 0, 16, 32, 48, 64, 128, 256, 512 })
            {
                Assert.Equal(v, MemoryHelpers.RoundUpToNextMultipleOf16(v));
            }
        }

        /// <summary>
        /// Tests that round down to next multiple of 16 values
        /// </summary>
        [Fact]
        public void RoundDownToNextMultipleOf16_Values()
        {
            Assert.Equal(0, MemoryHelpers.RoundDownToNextMultipleOf16(0));
            Assert.Equal(0, MemoryHelpers.RoundDownToNextMultipleOf16(1));
            Assert.Equal(0, MemoryHelpers.RoundDownToNextMultipleOf16(15));
            Assert.Equal(16, MemoryHelpers.RoundDownToNextMultipleOf16(16));
            Assert.Equal(16, MemoryHelpers.RoundDownToNextMultipleOf16(17));
            Assert.Equal(16, MemoryHelpers.RoundDownToNextMultipleOf16(31));
            Assert.Equal(32, MemoryHelpers.RoundDownToNextMultipleOf16(32));
            Assert.Equal(32, MemoryHelpers.RoundDownToNextMultipleOf16(47));
        }

        /// <summary>
        /// Tests that round down to next multiple of 16 idempotent
        /// </summary>
        [Fact]
        public void RoundDownToNextMultipleOf16_Idempotent()
        {
            foreach (int v in new[] { 0, 16, 32, 48, 64, 128, 256, 512 })
            {
                Assert.Equal(v, MemoryHelpers.RoundDownToNextMultipleOf16(v));
            }
        }

        /// <summary>
        /// Tests that rounding consistent
        /// </summary>
        [Fact]
        public void Rounding_Consistent()
        {
            for (int i = 1; i <= 1000; i++)
            {
                int down = MemoryHelpers.RoundDownToNextMultipleOf16(i);
                int up = MemoryHelpers.RoundUpToNextMultipleOf16(i);
                Assert.True(down <= i);
                Assert.True(up >= i);
                Assert.True(up - down <= 16);
            }
        }

        /// <summary>
        /// Tests that rounding boundary
        /// </summary>
        [Fact]
        public void Rounding_Boundary()
        {
            Assert.Equal(0, MemoryHelpers.RoundDownToNextMultipleOf16(15));
            Assert.Equal(16, MemoryHelpers.RoundUpToNextMultipleOf16(15));
            Assert.Equal(16, MemoryHelpers.RoundDownToNextMultipleOf16(16));
            Assert.Equal(16, MemoryHelpers.RoundUpToNextMultipleOf16(16));
            Assert.Equal(16, MemoryHelpers.RoundDownToNextMultipleOf16(17));
            Assert.Equal(32, MemoryHelpers.RoundUpToNextMultipleOf16(17));
        }

        /// <summary>
        /// Tests that bool to byte converts
        /// </summary>
        [Fact]
        public void BoolToByte_Converts()
        {
            Assert.Equal(1, MemoryHelpers.BoolToByte(true));
            Assert.Equal(0, MemoryHelpers.BoolToByte(false));
        }

        /// <summary>
        /// Tests that bool to byte consistent
        /// </summary>
        [Fact]
        public void BoolToByte_Consistent()
        {
            Assert.Equal(MemoryHelpers.BoolToByte(true), MemoryHelpers.BoolToByte(true));
            Assert.Equal(MemoryHelpers.BoolToByte(false), MemoryHelpers.BoolToByte(false));
            Assert.NotEqual(MemoryHelpers.BoolToByte(true), MemoryHelpers.BoolToByte(false));
        }

        /// <summary>
        /// Tests that read only span to immutable array creates
        /// </summary>
        [Fact]
        public void ReadOnlySpanToImmutableArray_Creates()
        {
            ReadOnlySpan<ComponentId> ids = new ComponentId[] { Component<Position>.Id, Component<Velocity>.Id };
            FastImmutableArray<ComponentId> result = MemoryHelpers.ReadOnlySpanToImmutableArray(ids);
            Assert.Equal(2, result.Length);
            Assert.Equal(Component<Position>.Id, result[0]);
            Assert.Equal(Component<Velocity>.Id, result[1]);
        }

        /// <summary>
        /// Tests that read only span to immutable array empty
        /// </summary>
        [Fact]
        public void ReadOnlySpanToImmutableArray_Empty()
        {
            FastImmutableArray<ComponentId> result = MemoryHelpers.ReadOnlySpanToImmutableArray(ReadOnlySpan<ComponentId>.Empty);
            Assert.Equal(0, result.Length);
        }

        /// <summary>
        /// Tests that concat single to empty
        /// </summary>
        [Fact]
        public void Concat_Single_ToEmpty()
        {
            FastImmutableArray<ComponentId> result = MemoryHelpers.Concat(FastImmutableArray<ComponentId>.Empty, Component<Position>.Id);
            Assert.Equal(1, result.Length);
            Assert.Equal(Component<Position>.Id, result[0]);
        }

        /// <summary>
        /// Tests that concat single to existing
        /// </summary>
        [Fact]
        public void Concat_Single_ToExisting()
        {
            ReadOnlySpan<ComponentId> pos = new ComponentId[] { Component<Position>.Id };
            FastImmutableArray<ComponentId> start = MemoryHelpers.ReadOnlySpanToImmutableArray(pos);
            FastImmutableArray<ComponentId> result = MemoryHelpers.Concat(start, Component<Velocity>.Id);
            Assert.Equal(2, result.Length);
            Assert.Equal(Component<Position>.Id, result[0]);
            Assert.Equal(Component<Velocity>.Id, result[1]);
        }

        /// <summary>
        /// Tests that concat single duplicate throws
        /// </summary>
        [Fact]
        public void Concat_Single_Duplicate_Throws()
        {
            ReadOnlySpan<ComponentId> pos = new ComponentId[] { Component<Position>.Id };
            FastImmutableArray<ComponentId> start = MemoryHelpers.ReadOnlySpanToImmutableArray(pos);
            Assert.Throws<InvalidOperationException>(() => MemoryHelpers.Concat(start, Component<Position>.Id));
        }

        /// <summary>
        /// Tests that concat span to empty
        /// </summary>
        [Fact]
        public void Concat_Span_ToEmpty()
        {
            FastImmutableArray<ComponentId> result = MemoryHelpers.Concat(FastImmutableArray<ComponentId>.Empty, new ComponentId[] { Component<Position>.Id, Component<Velocity>.Id }.AsSpan());
            Assert.Equal(2, result.Length);
            Assert.Equal(Component<Position>.Id, result[0]);
            Assert.Equal(Component<Velocity>.Id, result[1]);
        }

        /// <summary>
        /// Tests that concat span to existing
        /// </summary>
        [Fact]
        public void Concat_Span_ToExisting()
        {
            ReadOnlySpan<ComponentId> pos = new ComponentId[] { Component<Position>.Id };
            FastImmutableArray<ComponentId> start = MemoryHelpers.ReadOnlySpanToImmutableArray(pos);
            FastImmutableArray<ComponentId> result = MemoryHelpers.Concat(start, new ComponentId[] { Component<Velocity>.Id, Component<Health>.Id }.AsSpan());
            Assert.Equal(3, result.Length);
            Assert.Equal(Component<Position>.Id, result[0]);
            Assert.Equal(Component<Velocity>.Id, result[1]);
            Assert.Equal(Component<Health>.Id, result[2]);
        }

        /// <summary>
        /// Tests that concat span duplicate throws
        /// </summary>
        [Fact]
        public void Concat_Span_Duplicate_Throws()
        {
            ReadOnlySpan<ComponentId> ids = new ComponentId[] { Component<Position>.Id, Component<Velocity>.Id };
            FastImmutableArray<ComponentId> start = MemoryHelpers.ReadOnlySpanToImmutableArray(ids);
            Assert.Throws<InvalidOperationException>(() => MemoryHelpers.Concat(start, new ComponentId[] { Component<Velocity>.Id }.AsSpan()));
        }

        /// <summary>
        /// Tests that remove single type
        /// </summary>
        [Fact]
        public void Remove_SingleType()
        {
            ReadOnlySpan<ComponentId> ids = new ComponentId[] { Component<Position>.Id, Component<Velocity>.Id };
            FastImmutableArray<ComponentId> types = MemoryHelpers.ReadOnlySpanToImmutableArray(ids);
            FastImmutableArray<ComponentId> result = MemoryHelpers.Remove(types, Component<Position>.Id);
            Assert.Equal(1, result.Length);
            Assert.Equal(Component<Velocity>.Id, result[0]);
        }

        /// <summary>
        /// Tests that remove single type not found throws
        /// </summary>
        [Fact]
        public void Remove_SingleType_NotFound_Throws()
        {
            ReadOnlySpan<ComponentId> pos = new ComponentId[] { Component<Position>.Id };
            FastImmutableArray<ComponentId> types = MemoryHelpers.ReadOnlySpanToImmutableArray(pos);
            Assert.Throws<ComponentNotFoundException>(() => MemoryHelpers.Remove(types, Component<Velocity>.Id));
        }

        /// <summary>
        /// Tests that remove span
        /// </summary>
        [Fact]
        public void Remove_Span()
        {
            ReadOnlySpan<ComponentId> ids = new ComponentId[] { Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id };
            FastImmutableArray<ComponentId> types = MemoryHelpers.ReadOnlySpanToImmutableArray(ids);
            FastImmutableArray<ComponentId> result = MemoryHelpers.Remove(types, new ComponentId[] { Component<Position>.Id, Component<Health>.Id }.AsSpan());
            Assert.Equal(1, result.Length);
            Assert.Equal(Component<Velocity>.Id, result[0]);
        }

        /// <summary>
        /// Tests that remove span not found throws
        /// </summary>
        [Fact]
        public void Remove_Span_NotFound_Throws()
        {
            ReadOnlySpan<ComponentId> pos = new ComponentId[] { Component<Position>.Id };
            FastImmutableArray<ComponentId> types = MemoryHelpers.ReadOnlySpanToImmutableArray(pos);
            Assert.Throws<ComponentNotFoundException>(() => MemoryHelpers.Remove(types, new ComponentId[] { Component<Velocity>.Id }.AsSpan()));
        }

        /// <summary>
        /// Tests that remove span all empty
        /// </summary>
        [Fact]
        public void Remove_Span_All_Empty()
        {
            ReadOnlySpan<ComponentId> pos = new ComponentId[] { Component<Position>.Id };
            FastImmutableArray<ComponentId> types = MemoryHelpers.ReadOnlySpanToImmutableArray(pos);
            FastImmutableArray<ComponentId> result = MemoryHelpers.Remove(types, new ComponentId[] { Component<Position>.Id }.AsSpan());
            Assert.Equal(0, result.Length);
        }

        /// <summary>
        /// Tests that remove single last element
        /// </summary>
        [Fact]
        public void Remove_Single_Last_Element()
        {
            ReadOnlySpan<ComponentId> ids = new ComponentId[] { Component<Position>.Id, Component<Velocity>.Id };
            FastImmutableArray<ComponentId> types = MemoryHelpers.ReadOnlySpanToImmutableArray(ids);
            FastImmutableArray<ComponentId> result = MemoryHelpers.Remove(types, Component<Velocity>.Id);
            Assert.Equal(1, result.Length);
            Assert.Equal(Component<Position>.Id, result[0]);
        }

        /// <summary>
        /// Tests that get or add new new key
        /// </summary>
        [Fact]
        public void GetOrAddNew_NewKey()
        {
            Dictionary<int, TestHelper> dict = new Dictionary<int, TestHelper>();
            TestHelper value = dict.GetOrAddNew(1);
            Assert.NotNull(value);
            Assert.True(dict.ContainsKey(1));
            Assert.Same(value, dict[1]);
        }

        /// <summary>
        /// Tests that get or add new existing key
        /// </summary>
        [Fact]
        public void GetOrAddNew_ExistingKey()
        {
            Dictionary<int, TestHelper> dict = new Dictionary<int, TestHelper>();
            TestHelper original = new TestHelper();
            dict[1] = original;
            TestHelper retrieved = dict.GetOrAddNew(1);
            Assert.Same(original, retrieved);
        }

        /// <summary>
        /// Tests that get or add new multiple keys
        /// </summary>
        [Fact]
        public void GetOrAddNew_MultipleKeys()
        {
            Dictionary<string, TestHelper> dict = new Dictionary<string, TestHelper>();
            TestHelper a = dict.GetOrAddNew("a");
            TestHelper b = dict.GetOrAddNew("b");
            TestHelper a2 = dict.GetOrAddNew("a");
            Assert.Same(a, a2);
            Assert.NotSame(a, b);
            Assert.Equal(2, dict.Count);
        }

        /// <summary>
        /// Tests that get value or resize valid index
        /// </summary>
        [Fact]
        public void GetValueOrResize_ValidIndex()
        {
            int[] arr = [10, 20, 30];
            ref int val = ref MemoryHelpers.GetValueOrResize(ref arr, 1);
            Assert.Equal(20, val);
            val = 25;
            Assert.Equal(25, arr[1]);
        }

        /// <summary>
        /// Tests that get value or resize first index
        /// </summary>
        [Fact]
        public void GetValueOrResize_FirstIndex()
        {
            int[] arr = [10, 20, 30];
            ref int val = ref MemoryHelpers.GetValueOrResize(ref arr, 0);
            Assert.Equal(10, val);
            val = 99;
            Assert.Equal(99, arr[0]);
        }

        /// <summary>
        /// Tests that get value or resize last index
        /// </summary>
        [Fact]
        public void GetValueOrResize_LastIndex()
        {
            int[] arr = [10, 20, 30];
            ref int val = ref MemoryHelpers.GetValueOrResize(ref arr, 2);
            Assert.Equal(30, val);
        }

        /// <summary>
        /// Tests that get value or resize out of range
        /// </summary>
        [Fact]
        public void GetValueOrResize_OutOfRange()
        {
            int[] arr = [10, 20, 30];
            ref int val = ref MemoryHelpers.GetValueOrResize(ref arr, 5);
            Assert.True(arr.Length >= 6);
            val = 50;
            Assert.Equal(50, arr[5]);
        }

        /// <summary>
        /// Tests that get value or resize out of range large
        /// </summary>
        [Fact]
        public void GetValueOrResize_OutOfRange_Large()
        {
            int[] arr = [10];
            ref int val = ref MemoryHelpers.GetValueOrResize(ref arr, 100);
            Assert.True(arr.Length > 100);
            val = 999;
            Assert.Equal(999, arr[100]);
        }

        /// <summary>
        /// Tests that get value or resize empty array
        /// </summary>
        [Fact]
        public void GetValueOrResize_EmptyArray()
        {
            int[] arr = [];
            ref int val = ref MemoryHelpers.GetValueOrResize(ref arr, 0);
            Assert.True(arr.Length >= 1);
            val = 42;
            Assert.Equal(42, arr[0]);
        }

        /// <summary>
        /// Tests that poison value type does not throw
        /// </summary>
        [Fact]
        public void Poison_ValueType_DoesNotThrow()
        {
            int v = 42;
            MemoryHelpers.Poison(ref v);
            Assert.Equal(42, v);
        }

        /// <summary>
        /// Tests that poison struct type does not throw
        /// </summary>
        [Fact]
        public void Poison_StructType_DoesNotThrow()
        {
            Position p = default;
            MemoryHelpers.Poison(ref p);
        }

        /// <summary>
        /// Tests that poison reference type throws
        /// </summary>
        [Fact]
        public void Poison_ReferenceType_Throws()
        {
            string s = "test";
            Assert.Throws<NotSupportedException>(() => MemoryHelpers.Poison(ref s));
        }

        /// <summary>
        /// Tests that block 2 size
        /// </summary>
        [Fact]
        public void Block2_Size() => Assert.Equal(2, Marshal.SizeOf<MemoryHelpers.Block2>());

        /// <summary>
        /// Tests that block 4 size
        /// </summary>
        [Fact]
        public void Block4_Size() => Assert.Equal(4, Marshal.SizeOf<MemoryHelpers.Block4>());

        /// <summary>
        /// Tests that block 8 size
        /// </summary>
        [Fact]
        public void Block8_Size() => Assert.Equal(8, Marshal.SizeOf<MemoryHelpers.Block8>());

        /// <summary>
        /// Tests that block 16 size
        /// </summary>
        [Fact]
        public void Block16_Size() => Assert.Equal(16, Marshal.SizeOf<MemoryHelpers.Block16>());

        /// <summary>
        /// Tests that memory helpers t pool not null
        /// </summary>
        [Fact]
        public void MemoryHelpersT_Pool_NotNull()
        {
            Assert.NotNull(MemoryHelpers<int>.Pool);
            Assert.NotNull(MemoryHelpers<double>.Pool);
            Assert.NotNull(MemoryHelpers<object>.Pool);
        }

        /// <summary>
        /// The test helper class
        /// </summary>
        internal class TestHelper
        {
            /// <summary>
            /// Gets or sets the value of the value
            /// </summary>
            public int Value { get; set; }
        }
    }
}
