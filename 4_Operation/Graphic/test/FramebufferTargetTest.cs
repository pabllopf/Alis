

using System;
using Alis.Core.Graphic.OpenGL;
using Xunit;

namespace Alis.Core.Graphic.Test
{
    /// <summary>
    ///     Tests for the FramebufferTarget enum validating framebuffer target types.
    /// </summary>
    public class FramebufferTargetTest
    {
        /// <summary>
        ///     Tests that Framebuffer target has correct OpenGL value.
        /// </summary>
        [Fact]
        public void Framebuffer_HasCorrectValue_EqualsGlFramebuffer()
        {
            const int expectedValue = 0x8D40;

            Assert.Equal(expectedValue, (int) FramebufferTarget.Framebuffer);
        }

        /// <summary>
        ///     Tests that FramebufferTarget is an enum type.
        /// </summary>
        [Fact]
        public void FramebufferTarget_IsEnum_TypeIsCorrect()
        {
            Type enumType = typeof(FramebufferTarget);

            Assert.True(enumType.IsEnum);
        }

        /// <summary>
        ///     Tests that FramebufferTarget enum is public.
        /// </summary>
        [Fact]
        public void FramebufferTarget_IsPublic_CanBeAccessed()
        {
            Type enumType = typeof(FramebufferTarget);

            Assert.True(enumType.IsPublic);
        }

        /// <summary>
        ///     Tests that FramebufferTarget has exactly one defined value.
        /// </summary>
        [Fact]
        public void FramebufferTarget_HasOneValue_CountIsCorrect()
        {
            Array enumValues = Enum.GetValues(typeof(FramebufferTarget));

            Assert.Single(enumValues);
        }

        /// <summary>
        ///     Tests that FramebufferTarget can be cast to int.
        /// </summary>
        [Fact]
        public void FramebufferTarget_CanCastToInt_ConversionIsValid()
        {
            int value = (int) FramebufferTarget.Framebuffer;

            Assert.IsType<int>(value);
            Assert.Equal(0x8D40, value);
        }

        /// <summary>
        ///     Tests that FramebufferTarget values can be compared.
        /// </summary>
        [Fact]
        public void FramebufferTarget_CanCompareValues_EqualityWorks()
        {
            FramebufferTarget fb1 = FramebufferTarget.Framebuffer;
            FramebufferTarget fb2 = FramebufferTarget.Framebuffer;

            Assert.Equal(fb1, fb2);
        }

        /// <summary>
        ///     Tests that Framebuffer has the correct hexadecimal representation.
        /// </summary>
        [Fact]
        public void Framebuffer_HasCorrectHexValue_HexRepresentationIsAccurate()
        {
            int hexValue = (int) FramebufferTarget.Framebuffer;

            Assert.Equal(36160, hexValue); // 0x8D40 in decimal
        }

        /// <summary>
        ///     Tests that FramebufferTarget enum name is correct.
        /// </summary>
        [Fact]
        public void FramebufferTarget_HasCorrectName_NamingConventionIsMaintained()
        {
            string name = Enum.GetName(typeof(FramebufferTarget), FramebufferTarget.Framebuffer);

            Assert.Equal("Framebuffer", name);
        }
    }
}