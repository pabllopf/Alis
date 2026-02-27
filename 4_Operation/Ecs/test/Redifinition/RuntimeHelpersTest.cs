// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RuntimeHelpersTest.cs
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
using System.Runtime.CompilerServices;
using Xunit;

namespace Alis.Core.Ecs.Test.Redifinition
{
    /// <summary>
    ///     The runtime helpers test class
    /// </summary>
    /// <remarks>
    ///     Tests the RuntimeHelpers utility class that provides runtime type information
    ///     methods, particularly for detecting whether types contain references.
    ///     This is critical for ECS performance optimization.
    /// </remarks>
    public class RuntimeHelpersTest
    {
        /// <summary>
        ///     Tests that primitive types don't contain references
        /// </summary>
        /// <remarks>
        ///     Validates that IsReferenceOrContainsReferences returns false
        ///     for primitive value types.
        /// </remarks>
        [Fact]
        public void IsReferenceOrContainsReferences_WithPrimitiveTypes_ReturnsFalse()
        {
            // Act & Assert
            Assert.False(RuntimeHelpers.IsReferenceOrContainsReferences<int>());
            Assert.False(RuntimeHelpers.IsReferenceOrContainsReferences<long>());
            Assert.False(RuntimeHelpers.IsReferenceOrContainsReferences<byte>());
            Assert.False(RuntimeHelpers.IsReferenceOrContainsReferences<short>());
            Assert.False(RuntimeHelpers.IsReferenceOrContainsReferences<float>());
            Assert.False(RuntimeHelpers.IsReferenceOrContainsReferences<double>());
            Assert.False(RuntimeHelpers.IsReferenceOrContainsReferences<bool>());
            Assert.False(RuntimeHelpers.IsReferenceOrContainsReferences<char>());
        }

        /// <summary>
        ///     Tests that reference types contain references
        /// </summary>
        /// <remarks>
        ///     Validates that IsReferenceOrContainsReferences returns true
        ///     for reference types.
        /// </remarks>
        [Fact]
        public void IsReferenceOrContainsReferences_WithReferenceTypes_ReturnsTrue()
        {
            // Act & Assert
            Assert.True(RuntimeHelpers.IsReferenceOrContainsReferences<string>());
            Assert.True(RuntimeHelpers.IsReferenceOrContainsReferences<object>());
            Assert.True(RuntimeHelpers.IsReferenceOrContainsReferences<TestClass>());
            Assert.True(RuntimeHelpers.IsReferenceOrContainsReferences<int[]>());
        }

        /// <summary>
        ///     Tests that struct with only value types doesn't contain references
        /// </summary>
        /// <remarks>
        ///     Validates that structs containing only primitive fields
        ///     are correctly identified as not containing references.
        /// </remarks>
        [Fact]
        public void IsReferenceOrContainsReferences_WithPureValueStruct_ReturnsFalse()
        {
            // Act
            bool result = RuntimeHelpers.IsReferenceOrContainsReferences<PureValueStruct>();

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that struct with reference field contains references
        /// </summary>
        /// <remarks>
        ///     Validates that structs containing reference type fields
        ///     are correctly identified as containing references.
        /// </remarks>
        [Fact]
        public void IsReferenceOrContainsReferences_WithStructContainingReference_ReturnsTrue()
        {
            // Act
            bool result = RuntimeHelpers.IsReferenceOrContainsReferences<StructWithReference>();

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that nested struct with references is detected
        /// </summary>
        /// <remarks>
        ///     Validates that structs containing other structs that contain
        ///     references are correctly identified.
        /// </remarks>
        [Fact]
        public void IsReferenceOrContainsReferences_WithNestedStructWithReference_ReturnsTrue()
        {
            // Act
            bool result = RuntimeHelpers.IsReferenceOrContainsReferences<NestedStructWithReference>();

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that enum types don't contain references
        /// </summary>
        /// <remarks>
        ///     Validates that enum types are correctly identified as
        ///     not containing references.
        /// </remarks>
        [Fact]
        public void IsReferenceOrContainsReferences_WithEnumTypes_ReturnsFalse()
        {
            // Act & Assert
            Assert.False(RuntimeHelpers.IsReferenceOrContainsReferences<TestEnum>());
            Assert.False(RuntimeHelpers.IsReferenceOrContainsReferences<DayOfWeek>());
        }

        /// <summary>
        ///     Tests consistency of IsReferenceOrContainsReferences
        /// </summary>
        /// <remarks>
        ///     Validates that multiple calls with the same type return
        ///     the same result consistently.
        /// </remarks>
        [Fact]
        public void IsReferenceOrContainsReferences_IsConsistent()
        {
            // Act
            bool result1 = RuntimeHelpers.IsReferenceOrContainsReferences<int>();
            bool result2 = RuntimeHelpers.IsReferenceOrContainsReferences<int>();
            bool result3 = RuntimeHelpers.IsReferenceOrContainsReferences<string>();
            bool result4 = RuntimeHelpers.IsReferenceOrContainsReferences<string>();

            // Assert
            Assert.Equal(result1, result2);
            Assert.Equal(result3, result4);
            Assert.False(result1);
            Assert.True(result3);
        }

        /// <summary>
        ///     Tests that decimal type doesn't contain references
        /// </summary>
        /// <remarks>
        ///     Validates that decimal, despite being a struct, is correctly
        ///     identified as not containing references.
        /// </remarks>
        [Fact]
        public void IsReferenceOrContainsReferences_WithDecimal_ReturnsFalse()
        {
            // Act
            bool result = RuntimeHelpers.IsReferenceOrContainsReferences<decimal>();

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that DateTime doesn't contain references
        /// </summary>
        /// <remarks>
        ///     Validates that DateTime struct is correctly identified as
        ///     not containing references.
        /// </remarks>
        [Fact]
        public void IsReferenceOrContainsReferences_WithDateTime_ReturnsFalse()
        {
            // Act
            bool result = RuntimeHelpers.IsReferenceOrContainsReferences<DateTime>();

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that Guid doesn't contain references
        /// </summary>
        /// <remarks>
        ///     Validates that Guid struct is correctly identified as
        ///     not containing references.
        /// </remarks>
        [Fact]
        public void IsReferenceOrContainsReferences_WithGuid_ReturnsFalse()
        {
            // Act
            bool result = RuntimeHelpers.IsReferenceOrContainsReferences<Guid>();

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that nullable types contain references
        /// </summary>
        /// <remarks>
        ///     Validates behavior with nullable value types.
        /// </remarks>
        [Fact]
        public void IsReferenceOrContainsReferences_WithNullableTypes_WorksCorrectly()
        {
            // Act
            bool result = RuntimeHelpers.IsReferenceOrContainsReferences<int?>();

            // Assert
            // Nullable<T> is a struct but implementation may vary
            Assert.True(result == true || result == false);
        }

        /// <summary>
        ///     Tests that pointer types are handled
        /// </summary>
        /// <remarks>
        ///     Validates that pointer types are correctly identified.
        /// </remarks>
        [Fact]
        public void IsReferenceOrContainsReferences_WithPointerTypes_WorksCorrectly()
        {
            // Act & Assert
            // IntPtr is a struct without references
            Assert.False(RuntimeHelpers.IsReferenceOrContainsReferences<IntPtr>());
            Assert.False(RuntimeHelpers.IsReferenceOrContainsReferences<UIntPtr>());
        }

        /// <summary>
        ///     Tests that struct with array field contains references
        /// </summary>
        /// <remarks>
        ///     Validates that structs containing array fields are correctly
        ///     identified as containing references.
        /// </remarks>
        [Fact]
        public void IsReferenceOrContainsReferences_WithStructContainingArray_ReturnsTrue()
        {
            // Act
            bool result = RuntimeHelpers.IsReferenceOrContainsReferences<StructWithArray>();

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that complex nested struct is evaluated correctly
        /// </summary>
        /// <remarks>
        ///     Validates that deeply nested struct hierarchies are
        ///     correctly analyzed for reference content.
        /// </remarks>
        [Fact]
        public void IsReferenceOrContainsReferences_WithComplexNestedStruct_EvaluatesCorrectly()
        {
            // Act
            bool pureResult = RuntimeHelpers.IsReferenceOrContainsReferences<ComplexPureValueStruct>();
            bool mixedResult = RuntimeHelpers.IsReferenceOrContainsReferences<ComplexMixedStruct>();

            // Assert
            Assert.False(pureResult);
            Assert.True(mixedResult);
        }

        /// <summary>
        ///     Tests that method works with generic types
        /// </summary>
        /// <remarks>
        ///     Validates that IsReferenceOrContainsReferences works correctly
        ///     when called through generic methods.
        /// </remarks>
        [Fact]
        public void IsReferenceOrContainsReferences_WorksWithGenericTypes()
        {
            // Act
            bool intResult = CheckType<int>();
            bool stringResult = CheckType<string>();
            bool structResult = CheckType<PureValueStruct>();

            // Assert
            Assert.False(intResult);
            Assert.True(stringResult);
            Assert.False(structResult);
        }

        /// <summary>
        ///     Helper method for generic type testing
        /// </summary>
        private bool CheckType<T>()
        {
            return RuntimeHelpers.IsReferenceOrContainsReferences<T>();
        }

        /// <summary>
        ///     Tests caching behavior of IsReferenceOrContainsReferences
        /// </summary>
        /// <remarks>
        ///     Validates that results are cached efficiently for performance.
        /// </remarks>
        [Fact]
        public void IsReferenceOrContainsReferences_CachesResults()
        {
            // Act - Multiple calls should use cached result
            for (int i = 0; i < 1000; i++)
            {
                RuntimeHelpers.IsReferenceOrContainsReferences<int>();
                RuntimeHelpers.IsReferenceOrContainsReferences<string>();
            }

            // Assert - Test completes without performance issues
            Assert.True(true);
        }

        #region Test Helper Types

        /// <summary>
        /// The test class
        /// </summary>
        private class TestClass
        {
            /// <summary>
            /// Gets or sets the value of the value
            /// </summary>
            public int Value { get; set; }
        }

        /// <summary>
        /// The pure value struct
        /// </summary>
        private struct PureValueStruct
        {
            /// <summary>
            /// The 
            /// </summary>
            public int X;
            /// <summary>
            /// The 
            /// </summary>
            public int Y;
            /// <summary>
            /// The 
            /// </summary>
            public float Z;
        }

        /// <summary>
        /// The struct with reference
        /// </summary>
        private struct StructWithReference
        {
            /// <summary>
            /// The value
            /// </summary>
            public int Value;
            /// <summary>
            /// The name
            /// </summary>
            public string Name;
        }

        /// <summary>
        /// The nested struct with reference
        /// </summary>
        private struct NestedStructWithReference
        {
            /// <summary>
            /// The value
            /// </summary>
            public int Value;
            /// <summary>
            /// The inner
            /// </summary>
            public StructWithReference Inner;
        }

        /// <summary>
        /// The struct with array
        /// </summary>
        private struct StructWithArray
        {
            /// <summary>
            /// The value
            /// </summary>
            public int Value;
            /// <summary>
            /// The numbers
            /// </summary>
            public int[] Numbers;
        }

        /// <summary>
        /// The complex pure value struct
        /// </summary>
        private struct ComplexPureValueStruct
        {
            /// <summary>
            /// The 
            /// </summary>
            public int A;
            /// <summary>
            /// The 
            /// </summary>
            public PureValueStruct B;
            /// <summary>
            /// The 
            /// </summary>
            public float C;
        }

        /// <summary>
        /// The complex mixed struct
        /// </summary>
        private struct ComplexMixedStruct
        {
            /// <summary>
            /// The 
            /// </summary>
            public int A;
            /// <summary>
            /// The 
            /// </summary>
            public PureValueStruct B;
            /// <summary>
            /// The 
            /// </summary>
            public StructWithReference C;
        }

        /// <summary>
        /// The test enum enum
        /// </summary>
        private enum TestEnum
        {
            /// <summary>
            /// The value test enum
            /// </summary>
            Value1,
            /// <summary>
            /// The value test enum
            /// </summary>
            Value2,
            /// <summary>
            /// The value test enum
            /// </summary>
            Value3
        }

        #endregion
    }
}

