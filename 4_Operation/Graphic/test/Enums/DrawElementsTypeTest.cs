

using System;
using System.Collections.Generic;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Enums
{
    /// <summary>
    ///     Tests for the DrawElementsType enum validating index element data types.
    /// </summary>
    public class DrawElementsTypeTest
    {
        /// <summary>
        ///     Tests that UnsignedByte has correct value.
        /// </summary>
        [Fact]
        public void UnsignedByte_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x1401, (int) DrawElementsType.UnsignedByte);
        }

        /// <summary>
        ///     Tests that UnsignedShort has correct value.
        /// </summary>
        [Fact]
        public void UnsignedShort_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x1403, (int) DrawElementsType.UnsignedShort);
        }

        /// <summary>
        ///     Tests that UnsignedInt has correct value.
        /// </summary>
        [Fact]
        public void UnsignedInt_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x1405, (int) DrawElementsType.UnsignedInt);
        }

        /// <summary>
        ///     Tests that DrawElementsType is an enum type.
        /// </summary>
        [Fact]
        public void DrawElementsType_IsEnum_TypeIsCorrect()
        {
            Assert.True(typeof(DrawElementsType).IsEnum);
        }

        /// <summary>
        ///     Tests that DrawElementsType enum is public.
        /// </summary>
        [Fact]
        public void DrawElementsType_IsPublic_CanBeAccessed()
        {
            Assert.True(typeof(DrawElementsType).IsPublic);
        }

        /// <summary>
        ///     Tests that DrawElementsType has three defined values.
        /// </summary>
        [Fact]
        public void DrawElementsType_HasThreeValues_CountIsCorrect()
        {
            Array enumValues = Enum.GetValues(typeof(DrawElementsType));
            Assert.Equal(3, enumValues.Length);
        }

        /// <summary>
        ///     Tests that all DrawElementsType values are unique.
        /// </summary>
        [Fact]
        public void AllValues_AreUnique_NoConflicts()
        {
            int[] values = new[]
            {
                (int) DrawElementsType.UnsignedByte,
                (int) DrawElementsType.UnsignedShort,
                (int) DrawElementsType.UnsignedInt
            };

            int uniqueCount = new HashSet<int>(values).Count;
            Assert.Equal(values.Length, uniqueCount);
        }

        /// <summary>
        ///     Tests that DrawElementsType can be cast to int.
        /// </summary>
        [Fact]
        public void DrawElementsType_CanCastToInt_ConversionIsValid()
        {
            int value = (int) DrawElementsType.UnsignedInt;
            Assert.IsType<int>(value);
        }

        /// <summary>
        ///     Tests that DrawElementsType values can be compared.
        /// </summary>
        [Fact]
        public void DrawElementsType_CanCompareValues_EqualityWorks()
        {
            DrawElementsType type1 = DrawElementsType.UnsignedInt;
            DrawElementsType type2 = DrawElementsType.UnsignedInt;
            Assert.Equal(type1, type2);
        }

        /// <summary>
        ///     Tests that different DrawElementsType values are not equal.
        /// </summary>
        [Fact]
        public void DrawElementsType_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(DrawElementsType.UnsignedByte, DrawElementsType.UnsignedInt);
        }

        /// <summary>
        ///     Tests that UnsignedByte is the smallest data type.
        /// </summary>
        [Fact]
        public void UnsignedByte_HasSmallestValue_ComparisonIsCorrect()
        {
            int byteValue = (int) DrawElementsType.UnsignedByte;
            int shortValue = (int) DrawElementsType.UnsignedShort;
            int intValue = (int) DrawElementsType.UnsignedInt;

            Assert.True(byteValue < shortValue);
            Assert.True(shortValue < intValue);
        }
    }
}