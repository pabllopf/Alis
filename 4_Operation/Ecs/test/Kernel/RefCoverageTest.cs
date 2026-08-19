// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RefCoverageTest.cs
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
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Updating;
using Alis.Core.Ecs.Updating.Runners;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    /// The ref coverage test class
    /// </summary>
    public class RefCoverageTest
    {
        /// <summary>
        /// Tests that to string non null value returns value string
        /// </summary>
        [Fact]
        public void ToString_NonNullValue_ReturnsValueString()
        {
            int[] arr = { 42 };
            Ref<int> refValue = new Ref<int>(arr, 0);

            string result = refValue.ToString();

            Assert.Equal("42", result);
        }

        /// <summary>
        /// Tests that to string null value returns null
        /// </summary>
        [Fact]
        public void ToString_NullValue_ReturnsNull()
        {
            string[] arr = { null };
            Ref<string> refValue = new Ref<string>(arr, 0);

            string result = refValue.ToString();

            Assert.Null(result);
        }

        /// <summary>
        /// Tests that to string reference type returns value string
        /// </summary>
        [Fact]
        public void ToString_ReferenceType_ReturnsValueString()
        {
            string[] arr = { "hello" };
            Ref<string> refValue = new Ref<string>(arr, 0);

            string result = refValue.ToString();

            Assert.Equal("hello", result);
        }

        /// <summary>
        /// Tests that ref created from span access value
        /// </summary>
        [Fact]
        public void Ref_CreatedFromSpan_AccessValue()
        {
            int[] arr = { 10, 20, 30 };
            Span<int> span = arr.AsSpan();
            Ref<int> refValue = new Ref<int>(span, 1);

            Assert.Equal(20, refValue.Value);
        }

        /// <summary>
        /// Tests that ref created from span modify value
        /// </summary>
        [Fact]
        public void Ref_CreatedFromSpan_ModifyValue()
        {
            int[] arr = { 1, 2, 3 };
            Span<int> span = arr.AsSpan();
            Ref<int> refValue = new Ref<int>(span, 2);

            refValue.Value = 999;

            Assert.Equal(999, arr[2]);
        }

        /// <summary>
        /// Tests that ref created from component storage access value
        /// </summary>
        [Fact]
        public void Ref_CreatedFromComponentStorage_AccessValue()
        {
            using (ComponentStorage<TestStruct> storage = new Update<TestStruct>(8))
            {
                storage[0] = new TestStruct {X = 42, Y = 84};

                Ref<TestStruct> refValue = new Ref<TestStruct>(storage, 0);

                Assert.Equal(42, refValue.Value.X);
                Assert.Equal(84, refValue.Value.Y);
            }
        }

        /// <summary>
        /// Tests that ref created from component storage modify value
        /// </summary>
        [Fact]
        public void Ref_CreatedFromComponentStorage_ModifyValue()
        {
            using (ComponentStorage<TestStruct> storage = new Update<TestStruct>(8))
            {
                storage[0] = new TestStruct {X = 10, Y = 20};

                Ref<TestStruct> refValue = new Ref<TestStruct>(storage, 0);
                refValue.Value = new TestStruct {X = 100, Y = 200};

                Assert.Equal(100, storage[0].X);
                Assert.Equal(200, storage[0].Y);
            }
        }

        /// <summary>
        /// Tests that implicit operator converts ref to value
        /// </summary>
        [Fact]
        public void ImplicitOperator_ConvertsRefToValue()
        {
            int[] arr = { 77 };
            Ref<int> refValue = new Ref<int>(arr, 0);

            int value = refValue;

            Assert.Equal(77, value);
        }

        /// <summary>
        /// Tests that implicit operator with struct type converts correctly
        /// </summary>
        [Fact]
        public void ImplicitOperator_WithStructType_ConvertsCorrectly()
        {
            TestStruct[] arr = { new TestStruct { X = 5, Y = 10 } };
            Ref<TestStruct> refValue = new Ref<TestStruct>(arr, 0);

            TestStruct value = refValue;

            Assert.Equal(5, value.X);
            Assert.Equal(10, value.Y);
        }
    }
}
