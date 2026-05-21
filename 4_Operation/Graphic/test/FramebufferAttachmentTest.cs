

using System;
using Alis.Core.Graphic.OpenGL;
using Xunit;

namespace Alis.Core.Graphic.Test
{
    /// <summary>
    ///     Tests for the FramebufferAttachment enum validating framebuffer attachment types.
    /// </summary>
    public class FramebufferAttachmentTest
    {
        /// <summary>
        ///     Tests that ColorAttachment0 has correct value.
        /// </summary>
        [Fact]
        public void ColorAttachment0_HasCorrectValue_EqualsExpected()
        {
            const int expectedValue = 0x8CE0;

            Assert.Equal(expectedValue, (int) FramebufferAttachment.ColorAttachment0);
        }

        /// <summary>
        ///     Tests that FramebufferAttachment is an enum type.
        /// </summary>
        [Fact]
        public void FramebufferAttachment_IsEnum_TypeIsCorrect()
        {
            Type enumType = typeof(FramebufferAttachment);

            Assert.True(enumType.IsEnum);
        }

        /// <summary>
        ///     Tests that FramebufferAttachment enum is public.
        /// </summary>
        [Fact]
        public void FramebufferAttachment_IsPublic_CanBeAccessed()
        {
            Type enumType = typeof(FramebufferAttachment);

            Assert.True(enumType.IsPublic);
        }

        /// <summary>
        ///     Tests that FramebufferAttachment has at least one defined value.
        /// </summary>
        [Fact]
        public void FramebufferAttachment_HasValues_CountIsNotZero()
        {
            Array enumValues = Enum.GetValues(typeof(FramebufferAttachment));

            Assert.NotEmpty(enumValues);
        }

        /// <summary>
        ///     Tests that FramebufferAttachment can be cast to int.
        /// </summary>
        [Fact]
        public void FramebufferAttachment_CanCastToInt_ConversionIsValid()
        {
            int value = (int) FramebufferAttachment.ColorAttachment0;

            Assert.IsType<int>(value);
            Assert.Equal(0x8CE0, value);
        }

        /// <summary>
        ///     Tests that FramebufferAttachment values can be compared.
        /// </summary>
        [Fact]
        public void FramebufferAttachment_CanCompareValues_EqualityWorks()
        {
            FramebufferAttachment attach1 = FramebufferAttachment.ColorAttachment0;
            FramebufferAttachment attach2 = FramebufferAttachment.ColorAttachment0;

            Assert.Equal(attach1, attach2);
        }

        /// <summary>
        ///     Tests that FramebufferAttachment enum name is correct.
        /// </summary>
        [Fact]
        public void FramebufferAttachment_HasCorrectName_NamingConventionIsMaintained()
        {
            string name = Enum.GetName(typeof(FramebufferAttachment), FramebufferAttachment.ColorAttachment0);

            Assert.Equal("ColorAttachment0", name);
        }

        /// <summary>
        ///     Tests that ColorAttachment0 has the correct decimal value.
        /// </summary>
        [Fact]
        public void ColorAttachment0_HasCorrectDecimalValue_HexConversionIsAccurate()
        {
            int decimalValue = (int) FramebufferAttachment.ColorAttachment0;

            Assert.Equal(36064, decimalValue); // 0x8CE0 in decimal
        }
    }
}