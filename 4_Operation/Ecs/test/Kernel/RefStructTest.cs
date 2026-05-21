

using System;
using Alis.Core.Ecs.Kernel;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     The ref struct test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="Ref{T}" /> ref struct which provides a wrapper
    ///     over references to values for safe component access.
    /// </remarks>
    public class RefStructTest
    {
        /// <summary>
        ///     Tests that ref can be created from array
        /// </summary>
        /// <remarks>
        ///     Verifies that Ref can be instantiated from an array.
        /// </remarks>
        [Fact]
        public void Ref_CanBeCreatedFromArray()
        {
            int[] arr = {1, 2, 3, 4, 5};

            Ref<int> refValue = new Ref<int>(arr, 0);

            Assert.Equal(1, refValue.Value);
        }

        /// <summary>
        ///     Tests that ref can access different indices
        /// </summary>
        /// <remarks>
        ///     Validates that Ref correctly accesses different array indices.
        /// </remarks>
        [Fact]
        public void Ref_CanAccessDifferentIndices()
        {
            int[] arr = {10, 20, 30, 40, 50};

            Ref<int> ref0 = new Ref<int>(arr, 0);
            Ref<int> ref2 = new Ref<int>(arr, 2);
            Ref<int> ref4 = new Ref<int>(arr, 4);

            Assert.Equal(10, ref0.Value);
            Assert.Equal(30, ref2.Value);
            Assert.Equal(50, ref4.Value);
        }

        /// <summary>
        ///     Tests that ref can modify value
        /// </summary>
        /// <remarks>
        ///     Validates that Ref allows modifying the referenced value.
        /// </remarks>
        [Fact]
        public void Ref_CanModifyValue()
        {
            int[] arr = {1, 2, 3};
            Ref<int> refValue = new Ref<int>(arr, 1);

            refValue.Value = 999;

            Assert.Equal(999, arr[1]);
        }

        /// <summary>
        ///     Tests that ref implicit conversion to value
        /// </summary>
        /// <remarks>
        ///     Tests implicit conversion from Ref to T.
        /// </remarks>
        [Fact]
        public void Ref_ImplicitConversionToValue()
        {
            int[] arr = {42};
            Ref<int> refValue = new Ref<int>(arr, 0);

            int value = refValue;

            Assert.Equal(42, value);
        }

        /// <summary>
        ///     Tests that ref to string returns value string representation
        /// </summary>
        /// <remarks>
        ///     Validates that ToString() returns the string representation of the value.
        /// </remarks>
        [Fact]
        public void Ref_ToStringReturnsValueStringRepresentation()
        {
            int[] arr = {123};
            Ref<int> refValue = new Ref<int>(arr, 0);

            string result = refValue.ToString();

            Assert.Equal("123", result);
        }

        /// <summary>
        ///     Tests that ref with string type
        /// </summary>
        /// <remarks>
        ///     Tests Ref with reference type (string).
        /// </remarks>
        [Fact]
        public void Ref_WithStringType()
        {
            string[] arr = {"hello", "world"};
            Ref<string> refValue = new Ref<string>(arr, 0);

            Assert.Equal("hello", refValue.Value);
        }

        /// <summary>
        ///     Tests that ref can be created from span
        /// </summary>
        /// <remarks>
        ///     Verifies that Ref can be created from a Span.
        /// </remarks>
        [Fact]
        public void Ref_CanBeCreatedFromSpan()
        {
            int[] arr = {1, 2, 3, 4, 5};
            Span<int> span = arr.AsSpan();

            Ref<int> refValue = new Ref<int>(span, 2);

            Assert.Equal(3, refValue.Value);
        }

        /// <summary>
        ///     Tests that ref with null value
        /// </summary>
        /// <remarks>
        ///     Tests Ref with null string value.
        /// </remarks>
        [Fact]
        public void Ref_WithNullValue()
        {
            string[] arr = {null, "test"};
            Ref<string> refValue = new Ref<string>(arr, 0);

            Assert.Null(refValue.Value);
        }

        /// <summary>
        ///     Tests that ref multiple modifications
        /// </summary>
        /// <remarks>
        ///     Validates multiple modifications through the same Ref.
        /// </remarks>
        [Fact]
        public void Ref_MultipleModifications()
        {
            int[] arr = {0};
            Ref<int> refValue = new Ref<int>(arr, 0);

            refValue.Value = 10;
            refValue.Value = 20;
            refValue.Value = 30;

            Assert.Equal(30, arr[0]);
        }
    }
}