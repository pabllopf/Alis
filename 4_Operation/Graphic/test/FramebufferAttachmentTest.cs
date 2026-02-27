// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FramebufferAttachmentTest.cs
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

using Xunit;
using Alis.Core.Graphic.OpenGL;

namespace Alis.Core.Graphic.Test
{
    /// <summary>
    /// Tests for the FramebufferAttachment enum validating framebuffer attachment types.
    /// </summary>
    public class FramebufferAttachmentTest
    {
        /// <summary>
        /// Tests that ColorAttachment0 has correct value.
        /// </summary>
        [Fact]
        public void ColorAttachment0_HasCorrectValue_EqualsExpected()
        {
            // Arrange & Act
            const int expectedValue = 0x8CE0;

            // Assert
            Assert.Equal(expectedValue, (int)FramebufferAttachment.ColorAttachment0);
        }

        /// <summary>
        /// Tests that FramebufferAttachment is an enum type.
        /// </summary>
        [Fact]
        public void FramebufferAttachment_IsEnum_TypeIsCorrect()
        {
            // Arrange & Act
            var enumType = typeof(FramebufferAttachment);

            // Assert
            Assert.True(enumType.IsEnum);
        }

        /// <summary>
        /// Tests that FramebufferAttachment enum is public.
        /// </summary>
        [Fact]
        public void FramebufferAttachment_IsPublic_CanBeAccessed()
        {
            // Arrange & Act
            var enumType = typeof(FramebufferAttachment);

            // Assert
            Assert.True(enumType.IsPublic);
        }

        /// <summary>
        /// Tests that FramebufferAttachment has at least one defined value.
        /// </summary>
        [Fact]
        public void FramebufferAttachment_HasValues_CountIsNotZero()
        {
            // Arrange
            var enumValues = System.Enum.GetValues(typeof(FramebufferAttachment));

            // Act & Assert
            Assert.NotEmpty(enumValues);
        }

        /// <summary>
        /// Tests that FramebufferAttachment can be cast to int.
        /// </summary>
        [Fact]
        public void FramebufferAttachment_CanCastToInt_ConversionIsValid()
        {
            // Arrange & Act
            int value = (int)FramebufferAttachment.ColorAttachment0;

            // Assert
            Assert.IsType<int>(value);
            Assert.Equal(0x8CE0, value);
        }

        /// <summary>
        /// Tests that FramebufferAttachment values can be compared.
        /// </summary>
        [Fact]
        public void FramebufferAttachment_CanCompareValues_EqualityWorks()
        {
            // Arrange & Act
            var attach1 = FramebufferAttachment.ColorAttachment0;
            var attach2 = FramebufferAttachment.ColorAttachment0;

            // Assert
            Assert.Equal(attach1, attach2);
        }

        /// <summary>
        /// Tests that FramebufferAttachment enum name is correct.
        /// </summary>
        [Fact]
        public void FramebufferAttachment_HasCorrectName_NamingConventionIsMaintained()
        {
            // Arrange & Act
            var name = System.Enum.GetName(typeof(FramebufferAttachment), FramebufferAttachment.ColorAttachment0);

            // Assert
            Assert.Equal("ColorAttachment0", name);
        }

        /// <summary>
        /// Tests that ColorAttachment0 has the correct decimal value.
        /// </summary>
        [Fact]
        public void ColorAttachment0_HasCorrectDecimalValue_HexConversionIsAccurate()
        {
            // Arrange & Act
            int decimalValue = (int)FramebufferAttachment.ColorAttachment0;

            // Assert
            Assert.Equal(36064, decimalValue); // 0x8CE0 in decimal
        }
    }
}

