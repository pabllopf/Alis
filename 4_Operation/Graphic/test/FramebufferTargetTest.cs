// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FramebufferTargetTest.cs
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
using Xunit;
using Alis.Core.Graphic.OpenGL;

namespace Alis.Core.Graphic.Test
{
    /// <summary>
    /// Tests for the FramebufferTarget enum validating framebuffer target types.
    /// </summary>
    public class FramebufferTargetTest
    {
        /// <summary>
        /// Tests that Framebuffer target has correct OpenGL value.
        /// </summary>
        [Fact]
        public void Framebuffer_HasCorrectValue_EqualsGlFramebuffer()
        {
            // Arrange & Act
            const int expectedValue = 0x8D40;

            // Assert
            Assert.Equal(expectedValue, (int)FramebufferTarget.Framebuffer);
        }

        /// <summary>
        /// Tests that FramebufferTarget is an enum type.
        /// </summary>
        [Fact]
        public void FramebufferTarget_IsEnum_TypeIsCorrect()
        {
            // Arrange & Act
            Type enumType = typeof(FramebufferTarget);

            // Assert
            Assert.True(enumType.IsEnum);
        }

        /// <summary>
        /// Tests that FramebufferTarget enum is public.
        /// </summary>
        [Fact]
        public void FramebufferTarget_IsPublic_CanBeAccessed()
        {
            // Arrange & Act
            Type enumType = typeof(FramebufferTarget);

            // Assert
            Assert.True(enumType.IsPublic);
        }

        /// <summary>
        /// Tests that FramebufferTarget has exactly one defined value.
        /// </summary>
        [Fact]
        public void FramebufferTarget_HasOneValue_CountIsCorrect()
        {
            // Arrange
            Array enumValues = System.Enum.GetValues(typeof(FramebufferTarget));

            // Act & Assert
            Assert.Single(enumValues);
        }

        /// <summary>
        /// Tests that FramebufferTarget can be cast to int.
        /// </summary>
        [Fact]
        public void FramebufferTarget_CanCastToInt_ConversionIsValid()
        {
            // Arrange & Act
            int value = (int)FramebufferTarget.Framebuffer;

            // Assert
            Assert.IsType<int>(value);
            Assert.Equal(0x8D40, value);
        }

        /// <summary>
        /// Tests that FramebufferTarget values can be compared.
        /// </summary>
        [Fact]
        public void FramebufferTarget_CanCompareValues_EqualityWorks()
        {
            // Arrange & Act
            FramebufferTarget fb1 = FramebufferTarget.Framebuffer;
            FramebufferTarget fb2 = FramebufferTarget.Framebuffer;

            // Assert
            Assert.Equal(fb1, fb2);
        }

        /// <summary>
        /// Tests that Framebuffer has the correct hexadecimal representation.
        /// </summary>
        [Fact]
        public void Framebuffer_HasCorrectHexValue_HexRepresentationIsAccurate()
        {
            // Arrange & Act
            int hexValue = (int)FramebufferTarget.Framebuffer;

            // Assert
            Assert.Equal(36160, hexValue); // 0x8D40 in decimal
        }

        /// <summary>
        /// Tests that FramebufferTarget enum name is correct.
        /// </summary>
        [Fact]
        public void FramebufferTarget_HasCorrectName_NamingConventionIsMaintained()
        {
            // Arrange & Act
            string name = System.Enum.GetName(typeof(FramebufferTarget), FramebufferTarget.Framebuffer);

            // Assert
            Assert.Equal("Framebuffer", name);
        }
    }
}

