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
using Xunit;

namespace Alis.Core.Ecs.Test.Redifinition
{
    /// <summary>
    ///     The memory helpers test class
    /// </summary>
    /// <remarks>
    ///     Tests the MemoryHelpers utility class that provides memory management
    ///     operations including power-of-2 rounding, array resizing, and other
    ///     low-level operations critical for ECS performance.
    /// </remarks>
    public class MemoryHelpersTest
    {
        /// <summary>
        ///     Tests that RoundDownToPowerOfTwo correctly rounds down to power of 2
        /// </summary>
        /// <remarks>
        ///     Validates that values are correctly rounded down to the nearest
        ///     power of 2 value.
        /// </remarks>
        [Fact]
        public void RoundDownToPowerOfTwo_WithVariousValues_RoundsCorrectly()
        {
            Assert.Equal(1u, MemoryHelpers.RoundDownToPowerOfTwo(1));
        }

        /// <summary>
        ///     Tests that RoundUpToNextMultipleOf16 rounds up correctly
        /// </summary>
        /// <remarks>
        ///     Validates that values are correctly rounded up to the next
        ///     multiple of 16 for memory alignment purposes.
        /// </remarks>
        [Fact]
        public void RoundUpToNextMultipleOf16_WithVariousValues_RoundsCorrectly()
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
        ///     Tests that RoundDownToNextMultipleOf16 rounds down correctly
        /// </summary>
        /// <remarks>
        ///     Validates that values are correctly rounded down to the previous
        ///     multiple of 16 for memory alignment purposes.
        /// </remarks>
        [Fact]
        public void RoundDownToNextMultipleOf16_WithVariousValues_RoundsCorrectly()
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
        ///     Tests that BoolToByte converts correctly
        /// </summary>
        /// <remarks>
        ///     Validates that boolean values are correctly converted to byte
        ///     representation for low-level operations.
        /// </remarks>
        [Fact]
        public void BoolToByte_WithTrueAndFalse_ConvertsCorrectly()
        {
            byte trueResult = MemoryHelpers.BoolToByte(true);
            byte falseResult = MemoryHelpers.BoolToByte(false);

            Assert.Equal(1, trueResult);
            Assert.Equal(0, falseResult);
        }

        /// <summary>
        ///     Tests that RoundUpToNextMultipleOf16 is idempotent for multiples
        /// </summary>
        /// <remarks>
        ///     Validates that values already at multiples of 16 remain unchanged
        ///     when rounded up.
        /// </remarks>
        [Fact]
        public void RoundUpToNextMultipleOf16_WithMultiples_IsIdempotent()
        {
            int[] multiples = {0, 16, 32, 48, 64, 128, 256, 512};

            foreach (int value in multiples)
            {
                int result = MemoryHelpers.RoundUpToNextMultipleOf16(value);
                Assert.Equal(value, result);
            }
        }

        /// <summary>
        ///     Tests that RoundDownToNextMultipleOf16 is idempotent for multiples
        /// </summary>
        /// <remarks>
        ///     Validates that values already at multiples of 16 remain unchanged
        ///     when rounded down.
        /// </remarks>
        [Fact]
        public void RoundDownToNextMultipleOf16_WithMultiples_IsIdempotent()
        {
            int[] multiples = {0, 16, 32, 48, 64, 128, 256, 512};

            foreach (int value in multiples)
            {
                int result = MemoryHelpers.RoundDownToNextMultipleOf16(value);
                Assert.Equal(value, result);
            }
        }

        /// <summary>
        ///     Tests that rounding functions are consistent
        /// </summary>
        /// <remarks>
        ///     Validates that RoundUp and RoundDown produce results that
        ///     are consistent with each other (RoundDown <= value <= RoundUp).
        /// </remarks>
        [Fact]
        public void RoundingFunctions_AreConsistent()
        {
            for (int i = 0; i < 100; i++)
            {
                int roundedDown = MemoryHelpers.RoundDownToNextMultipleOf16(i);
                int roundedUp = MemoryHelpers.RoundUpToNextMultipleOf16(i);

                Assert.True(roundedDown <= i);
                Assert.True(roundedUp >= i);
                Assert.True(roundedDown % 16 == 0);
                Assert.True(roundedUp % 16 == 0 || roundedUp == 0);
            }
        }

        /// <summary>
        ///     Tests MaxComponentCount constant value
        /// </summary>
        /// <remarks>
        ///     Validates that the MaxComponentCount constant is set to the expected value
        ///     which is critical for ECS memory allocation.
        /// </remarks>
        [Fact]
        public void MaxComponentCount_HasExpectedValue()
        {
            Assert.Equal(127, MemoryHelpers.MaxComponentCount);
        }

        /// <summary>
        ///     Tests that RoundDownToPowerOfTwo handles large values
        /// </summary>
        /// <remarks>
        ///     Validates that large values are correctly rounded down to
        ///     the nearest power of 2 without overflow.
        /// </remarks>
        [Fact]
        public void RoundDownToPowerOfTwo_WithLargeValues_HandlesCorrectly()
        {
            Assert.Equal(1073741824u, MemoryHelpers.RoundDownToPowerOfTwo(1073741824)); // 2^30
            Assert.Equal(1073741824u, MemoryHelpers.RoundDownToPowerOfTwo(2000000000));
        }

        /// <summary>
        ///     Tests rounding with boundary values around multiples of 16
        /// </summary>
        /// <remarks>
        ///     Validates correct behavior for values immediately before and
        ///     after multiples of 16.
        /// </remarks>
        [Fact]
        public void RoundingFunctions_WithBoundaryValues_WorkCorrectly()
        {
            Assert.Equal(0, MemoryHelpers.RoundDownToNextMultipleOf16(15));
            Assert.Equal(16, MemoryHelpers.RoundUpToNextMultipleOf16(15));

            Assert.Equal(16, MemoryHelpers.RoundDownToNextMultipleOf16(16));
            Assert.Equal(16, MemoryHelpers.RoundUpToNextMultipleOf16(16));

            Assert.Equal(16, MemoryHelpers.RoundDownToNextMultipleOf16(17));
            Assert.Equal(32, MemoryHelpers.RoundUpToNextMultipleOf16(17));
        }

        /// <summary>
        ///     Tests that BoolToByte is consistent
        /// </summary>
        /// <remarks>
        ///     Validates that multiple calls with the same boolean value
        ///     produce the same byte result.
        /// </remarks>
        [Fact]
        public void BoolToByte_IsConsistent()
        {
            byte true1 = MemoryHelpers.BoolToByte(true);
            byte true2 = MemoryHelpers.BoolToByte(true);
            byte false1 = MemoryHelpers.BoolToByte(false);
            byte false2 = MemoryHelpers.BoolToByte(false);

            Assert.Equal(true1, true2);
            Assert.Equal(false1, false2);
            Assert.NotEqual(true1, false1);
        }

        /// <summary>
        ///     Tests Block2 struct size
        /// </summary>
        /// <remarks>
        ///     Validates that Block2 has the correct size for memory alignment.
        /// </remarks>
        [Fact]
        public void Block2_HasCorrectSize()
        {
            int size = Marshal.SizeOf<MemoryHelpers.Block2>();

            Assert.Equal(2, size);
        }

        /// <summary>
        ///     Tests Block4 struct size
        /// </summary>
        /// <remarks>
        ///     Validates that Block4 has the correct size for memory alignment.
        /// </remarks>
        [Fact]
        public void Block4_HasCorrectSize()
        {
            int size = Marshal.SizeOf<MemoryHelpers.Block4>();

            Assert.Equal(4, size);
        }

        /// <summary>
        ///     Tests Block8 struct size
        /// </summary>
        /// <remarks>
        ///     Validates that Block8 has the correct size for memory alignment.
        /// </remarks>
        [Fact]
        public void Block8_HasCorrectSize()
        {
            int size = Marshal.SizeOf<MemoryHelpers.Block8>();

            Assert.Equal(8, size);
        }

        /// <summary>
        ///     Tests Block16 struct size
        /// </summary>
        /// <remarks>
        ///     Validates that Block16 has the correct size for memory alignment.
        /// </remarks>
        [Fact]
        public void Block16_HasCorrectSize()
        {
            int size = Marshal.SizeOf<MemoryHelpers.Block16>();

            Assert.Equal(16, size);
        }

        /// <summary>
        ///     Tests GetOrAddNew with new key
        /// </summary>
        /// <remarks>
        ///     Validates that GetOrAddNew creates and adds a new value
        ///     when the key doesn't exist in the dictionary.
        /// </remarks>
        [Fact]
        public void GetOrAddNew_WithNewKey_CreatesNewValue()
        {
            Dictionary<int, TestClass> dict = new Dictionary<int, TestClass>();

            TestClass value = dict.GetOrAddNew(1);

            Assert.NotNull(value);
            Assert.True(dict.ContainsKey(1));
            Assert.Same(value, dict[1]);
        }

        /// <summary>
        ///     Tests GetOrAddNew with existing key
        /// </summary>
        /// <remarks>
        ///     Validates that GetOrAddNew returns the existing value
        ///     when the key already exists in the dictionary.
        /// </remarks>
        [Fact]
        public void GetOrAddNew_WithExistingKey_ReturnsExistingValue()
        {
            Dictionary<int, TestClass> dict = new Dictionary<int, TestClass>();
            TestClass original = new TestClass();
            dict[1] = original;

            TestClass retrieved = dict.GetOrAddNew(1);

            Assert.Same(original, retrieved);
        }

        /// <summary>
        ///     Tests GetOrAddNew with multiple keys
        /// </summary>
        /// <remarks>
        ///     Validates that GetOrAddNew works correctly when used
        ///     with multiple different keys in succession.
        /// </remarks>
        [Fact]
        public void GetOrAddNew_WithMultipleKeys_WorksCorrectly()
        {
            Dictionary<string, TestClass> dict = new Dictionary<string, TestClass>();

            TestClass value1 = dict.GetOrAddNew("key1");
            TestClass value2 = dict.GetOrAddNew("key2");
            TestClass value3 = dict.GetOrAddNew("key3");
            TestClass value1Again = dict.GetOrAddNew("key1");

            Assert.NotNull(value1);
            Assert.NotNull(value2);
            Assert.NotNull(value3);
            Assert.Same(value1, value1Again);
            Assert.NotSame(value1, value2);
            Assert.NotSame(value2, value3);
            Assert.Equal(3, dict.Count);
        }

        /// <summary>
        ///     Tests RoundUpToNextMultipleOf16 with negative values
        /// </summary>
        /// <remarks>
        ///     Validates behavior with negative input values.
        /// </remarks>
        [Fact]
        public void RoundUpToNextMultipleOf16_WithNegativeValues_HandlesCorrectly()
        {
            int result = MemoryHelpers.RoundUpToNextMultipleOf16(-5);

            Assert.True(result % 16 == 0 || result == 0);
        }

        /// <summary>
        ///     Tests RoundDownToNextMultipleOf16 with negative values
        /// </summary>
        /// <remarks>
        ///     Validates behavior with negative input values for rounding down.
        /// </remarks>
        [Fact]
        public void RoundDownToNextMultipleOf16_WithNegativeValues_HandlesCorrectly()
        {
            int result = MemoryHelpers.RoundDownToNextMultipleOf16(-5);

            Assert.True(result % 16 == 0);
        }

        /// <summary>
        ///     Tests that both rounding functions handle zero correctly
        /// </summary>
        /// <remarks>
        ///     Validates special case handling for zero as input to
        ///     both rounding up and rounding down functions.
        /// </remarks>
        [Fact]
        public void RoundingFunctions_WithZero_HandleCorrectly()
        {
            int roundUp = MemoryHelpers.RoundUpToNextMultipleOf16(0);
            int roundDown = MemoryHelpers.RoundDownToNextMultipleOf16(0);

            Assert.Equal(0, roundUp);
            Assert.Equal(0, roundDown);
        }

        /// <summary>
        ///     Tests rounding consistency for range of values
        /// </summary>
        /// <remarks>
        ///     Validates that for any value, roundDown <= value <= roundUp
        ///     and the difference is at most 16.
        /// </remarks>
        [Fact]
        public void RoundingFunctions_MaintainConsistency()
        {
            for (int i = 1; i <= 1000; i++)
            {
                int roundedUp = MemoryHelpers.RoundUpToNextMultipleOf16(i);
                int roundedDown = MemoryHelpers.RoundDownToNextMultipleOf16(i);

                Assert.True(roundedDown <= i);
                Assert.True(roundedUp >= i);
                Assert.True(roundedUp - roundedDown <= 16);
            }
        }

        /// <summary>
        ///     Tests RoundDownToPowerOfTwo with sequential values
        /// </summary>
        /// <remarks>
        ///     Validates that RoundDownToPowerOfTwo produces monotonically
        ///     non-decreasing results for increasing inputs.
        /// </remarks>
        [Fact]
        public void RoundDownToPowerOfTwo_WithSequentialValues_IsMonotonic()
        {
            uint previousResult = 0;

            for (uint i = 1; i <= 256; i++)
            {
                uint result = MemoryHelpers.RoundDownToPowerOfTwo(i);
                Assert.True(result >= previousResult);

                Assert.True((result & (result - 1)) == 0 || result == 0);

                previousResult = result;
            }
        }

        /// <summary>
        ///     Tests GetOrAddNew thread safety with single thread
        /// </summary>
        /// <remarks>
        ///     Validates that GetOrAddNew works correctly in a single-threaded
        ///     scenario with rapid successive calls.
        /// </remarks>
        [Fact]
        public void GetOrAddNew_WithRapidCalls_WorksCorrectly()
        {
            Dictionary<int, TestClass> dict = new Dictionary<int, TestClass>();

            for (int i = 0; i < 100; i++)
            {
                TestClass value = dict.GetOrAddNew(i % 10);
                Assert.NotNull(value);
            }

            Assert.Equal(10, dict.Count);
        }

        /// <summary>
        ///     Tests MaxComponentCount is within valid range
        /// </summary>
        /// <remarks>
        ///     Validates that MaxComponentCount is a reasonable value
        ///     for ECS component limits.
        /// </remarks>
        [Fact]
        public void MaxComponentCount_IsWithinValidRange()
        {
            Assert.True(MemoryHelpers.MaxComponentCount > 0);
            Assert.True(MemoryHelpers.MaxComponentCount < 256);
            Assert.Equal(127, MemoryHelpers.MaxComponentCount);
        }

        /// <summary>
        ///     Tests that ReadOnlySpanToImmutableArray converts a span to an immutable array
        /// </summary>
        [Fact]
        public void ReadOnlySpanToImmutableArray_WithComponents_CreatesArray()
        {
            ComponentId[] ids = [Component<Position>.Id, Component<Velocity>.Id];
            FastImmutableArray<ComponentId> result = MemoryHelpers.ReadOnlySpanToImmutableArray<ComponentId>(ids);

            Assert.Equal(2, result.Length);
            Assert.Equal(Component<Position>.Id, result[0]);
            Assert.Equal(Component<Velocity>.Id, result[1]);
        }

        /// <summary>
        ///     Tests that Concat adds a new type to an empty array
        /// </summary>
        [Fact]
        public void Concat_SingleType_ToEmptyArray_AddsType()
        {
            FastImmutableArray<ComponentId> empty = FastImmutableArray<ComponentId>.Empty;

            FastImmutableArray<ComponentId> result = MemoryHelpers.Concat(empty, Component<Position>.Id);

            Assert.Equal(1, result.Length);
            Assert.Equal(Component<Position>.Id, result[0]);
        }

        /// <summary>
        ///     Tests that Concat throws when adding a duplicate type
        /// </summary>
        [Fact]
        public void Concat_SingleType_Duplicate_ThrowsInvalidOperation()
        {
            FastImmutableArray<ComponentId> start = MemoryHelpers.ReadOnlySpanToImmutableArray<ComponentId>([Component<Position>.Id]);

            Assert.Throws<InvalidOperationException>(new Action(() => MemoryHelpers.Concat(start, Component<Position>.Id)));
        }

        /// <summary>
        ///     Tests that Concat adds a span of new types to an existing array
        /// </summary>
        [Fact]
        public void Concat_Span_ToExistingArray_AddsTypes()
        {
            FastImmutableArray<ComponentId> start = MemoryHelpers.ReadOnlySpanToImmutableArray<ComponentId>([Component<Position>.Id]);

            FastImmutableArray<ComponentId> result = MemoryHelpers.Concat(start, new[] { Component<Velocity>.Id, Component<Health>.Id });

            Assert.Equal(3, result.Length);
            Assert.Equal(Component<Position>.Id, result[0]);
            Assert.Equal(Component<Velocity>.Id, result[1]);
            Assert.Equal(Component<Health>.Id, result[2]);
        }

        /// <summary>
        ///     Tests that Concat throws when a span contains a duplicate type
        /// </summary>
        [Fact]
        public void Concat_Span_Duplicate_ThrowsInvalidOperation()
        {
            FastImmutableArray<ComponentId> start = MemoryHelpers.ReadOnlySpanToImmutableArray<ComponentId>([Component<Position>.Id, Component<Velocity>.Id]);

            Assert.Throws<InvalidOperationException>(new Action(() => MemoryHelpers.Concat(start, new[] { Component<Velocity>.Id })));
        }

        /// <summary>
        ///     Tests that Remove removes an existing type
        /// </summary>
        [Fact]
        public void Remove_SingleType_Existing_RemovesType()
        {
            FastImmutableArray<ComponentId> types = MemoryHelpers.ReadOnlySpanToImmutableArray<ComponentId>([Component<Position>.Id, Component<Velocity>.Id]);

            FastImmutableArray<ComponentId> result = MemoryHelpers.Remove(types, Component<Position>.Id);

            Assert.Equal(1, result.Length);
            Assert.Equal(Component<Velocity>.Id, result[0]);
        }

        /// <summary>
        ///     Tests that Remove throws when type is not found
        /// </summary>
        [Fact]
        public void Remove_SingleType_NotFound_ThrowsComponentNotFoundException()
        {
            FastImmutableArray<ComponentId> types = MemoryHelpers.ReadOnlySpanToImmutableArray<ComponentId>([Component<Position>.Id]);

            Assert.Throws<ComponentNotFoundException>(new Action(() => MemoryHelpers.Remove(types, Component<Velocity>.Id)));
        }

        /// <summary>
        ///     Tests that Remove removes a span of types from an array
        /// </summary>
        [Fact]
        public void Remove_Span_Existing_RemovesTypes()
        {
            FastImmutableArray<ComponentId> types = MemoryHelpers.ReadOnlySpanToImmutableArray<ComponentId>([Component<Position>.Id, Component<Velocity>.Id, Component<Health>.Id]);

            FastImmutableArray<ComponentId> result = MemoryHelpers.Remove(types, new[] { Component<Position>.Id, Component<Health>.Id });

            Assert.Equal(1, result.Length);
            Assert.Equal(Component<Velocity>.Id, result[0]);
        }

        /// <summary>
        ///     Tests that Remove throws when a span contains a type not found
        /// </summary>
        [Fact]
        public void Remove_Span_NotFound_ThrowsComponentNotFoundException()
        {
            FastImmutableArray<ComponentId> types = MemoryHelpers.ReadOnlySpanToImmutableArray<ComponentId>([Component<Position>.Id]);

            Assert.Throws<ComponentNotFoundException>(new Action(() => MemoryHelpers.Remove(types, new[] { Component<Velocity>.Id })));
        }

        /// <summary>
        ///     Tests that GetValueOrResize returns ref to existing element
        /// </summary>
        [Fact]
        public void GetValueOrResize_WithValidIndex_ReturnsRef()
        {
            int[] arr = [10, 20, 30];

            ref int val = ref MemoryHelpers.GetValueOrResize(ref arr, 1);

            Assert.Equal(20, val);
            val = 25;
            Assert.Equal(25, arr[1]);
        }

        /// <summary>
        ///     Tests that GetValueOrResize resizes and returns ref for out-of-range index
        /// </summary>
        [Fact]
        public void GetValueOrResize_WithOutOfRangeIndex_ResizesAndReturnsRef()
        {
            int[] arr = [10, 20, 30];

            ref int val = ref MemoryHelpers.GetValueOrResize(ref arr, 5);

            Assert.True(arr.Length >= 6);
            val = 50;
            Assert.Equal(50, arr[5]);
        }

        /// <summary>
        ///     Tests that Poison does not throw for value types
        /// </summary>
        [Fact]
        public void Poison_ValueType_DoesNotThrow()
        {
            int value = 42;

            MemoryHelpers.Poison(ref value);

            Assert.Equal(42, value);
        }

        /// <summary>
        ///     Tests that Poison throws for reference types
        /// </summary>
        [Fact]
        public void Poison_ReferenceType_ThrowsNotSupported()
        {
            string item = "test";

            Assert.Throws<NotSupportedException>(new Action(() => MemoryHelpers.Poison(ref item)));
        }

        /// <summary>
        ///     Helper test class for GetOrAddNew tests
        /// </summary>
        private class TestClass
        {
            /// <summary>
        ///     Gets or sets the value of the value
        /// </summary>
            public int Value { get; set; }
        }
    }
}