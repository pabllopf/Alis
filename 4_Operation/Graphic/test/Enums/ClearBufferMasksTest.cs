// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ClearBufferMasksTest.cs
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
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Enums
{
    /// <summary>
    ///     Tests for the ClearBufferMasks enum validating clear buffer flags.
    /// </summary>
    public class ClearBufferMasksTest
    {
        /// <summary>
        /// Tests that depth buffer bit has correct value equals expected
        /// </summary>
        [Fact]
        public void DepthBufferBit_HasCorrectValue_EqualsExpected() { Assert.Equal(0x00000100, (int)ClearBufferMasks.DepthBufferBit); }

        /// <summary>
        /// Tests that accum buffer bit has correct value equals expected
        /// </summary>
        [Fact]
        public void AccumBufferBit_HasCorrectValue_EqualsExpected() { Assert.Equal(0x00000200, (int)ClearBufferMasks.AccumBufferBit); }

        /// <summary>
        /// Tests that stencil buffer bit has correct value equals expected
        /// </summary>
        [Fact]
        public void StencilBufferBit_HasCorrectValue_EqualsExpected() { Assert.Equal(0x00000400, (int)ClearBufferMasks.StencilBufferBit); }

        /// <summary>
        /// Tests that color buffer bit has correct value equals expected
        /// </summary>
        [Fact]
        public void ColorBufferBit_HasCorrectValue_EqualsExpected() { Assert.Equal(0x00004000, (int)ClearBufferMasks.ColorBufferBit); }

        /// <summary>
        /// Tests that clear buffer masks is enum type is correct
        /// </summary>
        [Fact]
        public void ClearBufferMasks_IsEnum_TypeIsCorrect() { Assert.True(typeof(ClearBufferMasks).IsEnum); }

        /// <summary>
        /// Tests that clear buffer masks is public can be accessed
        /// </summary>
        [Fact]
        public void ClearBufferMasks_IsPublic_CanBeAccessed() { Assert.True(typeof(ClearBufferMasks).IsPublic); }

        /// <summary>
        /// Tests that clear buffer masks has four values count is correct
        /// </summary>
        [Fact]
        public void ClearBufferMasks_HasFourValues_CountIsCorrect()
        {
            Array enumValues = Enum.GetValues(typeof(ClearBufferMasks));
            Assert.Equal(4, enumValues.Length);
        }

        /// <summary>
        /// Tests that clear buffer masks can cast to int conversion is valid
        /// </summary>
        [Fact]
        public void ClearBufferMasks_CanCastToInt_ConversionIsValid()
        {
            int value = (int)ClearBufferMasks.ColorBufferBit;
            Assert.IsType<int>(value);
        }

        /// <summary>
        /// Tests that clear buffer masks can compare values equality works
        /// </summary>
        [Fact]
        public void ClearBufferMasks_CanCompareValues_EqualityWorks()
        {
            ClearBufferMasks mask1 = ClearBufferMasks.ColorBufferBit;
            ClearBufferMasks mask2 = ClearBufferMasks.ColorBufferBit;
            Assert.Equal(mask1, mask2);
        }

        /// <summary>
        /// Tests that clear buffer masks different values are not equal
        /// </summary>
        [Fact]
        public void ClearBufferMasks_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(ClearBufferMasks.DepthBufferBit, ClearBufferMasks.ColorBufferBit);
        }
    }
}
