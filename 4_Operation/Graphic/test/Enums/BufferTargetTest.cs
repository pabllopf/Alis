

using System;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Enums
{
    /// <summary>
    ///     Tests for the BufferTarget enum validating buffer binding target types.
    /// </summary>
    public class BufferTargetTest
    {
        /// <summary>
        ///     Tests that ArrayBuffer has correct value.
        /// </summary>
        [Fact]
        public void ArrayBuffer_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8892, (int) BufferTarget.ArrayBuffer);
        }

        /// <summary>
        ///     Tests that ElementArrayBuffer has correct value.
        /// </summary>
        [Fact]
        public void ElementArrayBuffer_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8893, (int) BufferTarget.ElementArrayBuffer);
        }

        /// <summary>
        ///     Tests that PackBuffer has correct value.
        /// </summary>
        [Fact]
        public void PackBuffer_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x88EB, (int) BufferTarget.PackBuffer);
        }

        /// <summary>
        ///     Tests that UnpackBuffer has correct value.
        /// </summary>
        [Fact]
        public void UnpackBuffer_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x88EC, (int) BufferTarget.UnpackBuffer);
        }

        /// <summary>
        ///     Tests that UniformBuffer has correct value.
        /// </summary>
        [Fact]
        public void UniformBuffer_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8A11, (int) BufferTarget.UniformBuffer);
        }

        /// <summary>
        ///     Tests that TextureBuffer has correct value.
        /// </summary>
        [Fact]
        public void TextureBuffer_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8C2A, (int) BufferTarget.TextureBuffer);
        }

        /// <summary>
        ///     Tests that TransformFeedbackBuffer has correct value.
        /// </summary>
        [Fact]
        public void TransformFeedbackBuffer_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8C8E, (int) BufferTarget.TransformFeedbackBuffer);
        }

        /// <summary>
        ///     Tests that CopyReadBuffer has correct value.
        /// </summary>
        [Fact]
        public void CopyReadBuffer_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8F36, (int) BufferTarget.CopyReadBuffer);
        }

        /// <summary>
        ///     Tests that CopyWriteBuffer has correct value.
        /// </summary>
        [Fact]
        public void CopyWriteBuffer_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8F37, (int) BufferTarget.CopyWriteBuffer);
        }

        /// <summary>
        ///     Tests that DrawIndirectBuffer has correct value.
        /// </summary>
        [Fact]
        public void DrawIndirectBuffer_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8F3F, (int) BufferTarget.DrawIndirectBuffer);
        }

        /// <summary>
        ///     Tests that BufferTarget is an enum type.
        /// </summary>
        [Fact]
        public void BufferTarget_IsEnum_TypeIsCorrect()
        {
            Assert.True(typeof(BufferTarget).IsEnum);
        }

        /// <summary>
        ///     Tests that BufferTarget enum is public.
        /// </summary>
        [Fact]
        public void BufferTarget_IsPublic_CanBeAccessed()
        {
            Assert.True(typeof(BufferTarget).IsPublic);
        }

        /// <summary>
        ///     Tests that BufferTarget has multiple defined values.
        /// </summary>
        [Fact]
        public void BufferTarget_HasMultipleValues_CountIsNotZero()
        {
            Array enumValues = Enum.GetValues(typeof(BufferTarget));
            Assert.NotEmpty(enumValues);
            Assert.True(enumValues.Length > 5);
        }

        /// <summary>
        ///     Tests that BufferTarget can be cast to int.
        /// </summary>
        [Fact]
        public void BufferTarget_CanCastToInt_ConversionIsValid()
        {
            int value = (int) BufferTarget.ArrayBuffer;
            Assert.IsType<int>(value);
        }

        /// <summary>
        ///     Tests that BufferTarget values can be compared.
        /// </summary>
        [Fact]
        public void BufferTarget_CanCompareValues_EqualityWorks()
        {
            BufferTarget target1 = BufferTarget.ArrayBuffer;
            BufferTarget target2 = BufferTarget.ArrayBuffer;
            Assert.Equal(target1, target2);
        }

        /// <summary>
        ///     Tests that different BufferTarget values are not equal.
        /// </summary>
        [Fact]
        public void BufferTarget_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(BufferTarget.ArrayBuffer, BufferTarget.ElementArrayBuffer);
        }

        /// <summary>
        ///     Tests that BufferTarget contains common buffer targets.
        /// </summary>
        [Fact]
        public void BufferTarget_ContainsCommonTargets_AllPresent()
        {
            BufferTarget arrayBuffer = BufferTarget.ArrayBuffer;
            BufferTarget elementArrayBuffer = BufferTarget.ElementArrayBuffer;
            BufferTarget uniformBuffer = BufferTarget.UniformBuffer;

            Assert.NotNull(arrayBuffer);
            Assert.NotNull(elementArrayBuffer);
            Assert.NotNull(uniformBuffer);
        }
    }
}