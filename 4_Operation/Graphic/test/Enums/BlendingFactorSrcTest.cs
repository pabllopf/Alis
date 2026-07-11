// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BlendingFactorSrcTest.cs
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
    ///     Tests for the BlendingFactorSrc enum validating source blending factor types.
    /// </summary>
    public class BlendingFactorSrcTest
    {
        /// <summary>
        /// Tests that zero has correct value equals expected
        /// </summary>
        [Fact]
        public void Zero_HasCorrectValue_EqualsExpected() { Assert.Equal(0, (int)BlendingFactorSrc.Zero); }

        /// <summary>
        /// Tests that one has correct value equals expected
        /// </summary>
        [Fact]
        public void One_HasCorrectValue_EqualsExpected() { Assert.Equal(1, (int)BlendingFactorSrc.One); }

        /// <summary>
        /// Tests that src alpha has correct value equals expected
        /// </summary>
        [Fact]
        public void SrcAlpha_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0302, (int)BlendingFactorSrc.SrcAlpha); }

        /// <summary>
        /// Tests that one minus src alpha has correct value equals expected
        /// </summary>
        [Fact]
        public void OneMinusSrcAlpha_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0303, (int)BlendingFactorSrc.OneMinusSrcAlpha); }

        /// <summary>
        /// Tests that dst alpha has correct value equals expected
        /// </summary>
        [Fact]
        public void DstAlpha_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0304, (int)BlendingFactorSrc.DstAlpha); }

        /// <summary>
        /// Tests that one minus dst alpha has correct value equals expected
        /// </summary>
        [Fact]
        public void OneMinusDstAlpha_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0305, (int)BlendingFactorSrc.OneMinusDstAlpha); }

        /// <summary>
        /// Tests that dst color has correct value equals expected
        /// </summary>
        [Fact]
        public void DstColor_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0306, (int)BlendingFactorSrc.DstColor); }

        /// <summary>
        /// Tests that one minus dst color has correct value equals expected
        /// </summary>
        [Fact]
        public void OneMinusDstColor_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0307, (int)BlendingFactorSrc.OneMinusDstColor); }

        /// <summary>
        /// Tests that src alpha saturate has correct value equals expected
        /// </summary>
        [Fact]
        public void SrcAlphaSaturate_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0308, (int)BlendingFactorSrc.SrcAlphaSaturate); }

        /// <summary>
        /// Tests that constant color has correct value equals expected
        /// </summary>
        [Fact]
        public void ConstantColor_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8001, (int)BlendingFactorSrc.ConstantColor); }

        /// <summary>
        /// Tests that constant color ext has correct value equals expected
        /// </summary>
        [Fact]
        public void ConstantColorExt_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8001, (int)BlendingFactorSrc.ConstantColorExt); }

        /// <summary>
        /// Tests that one minus constant color has correct value equals expected
        /// </summary>
        [Fact]
        public void OneMinusConstantColor_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8002, (int)BlendingFactorSrc.OneMinusConstantColor); }

        /// <summary>
        /// Tests that one minus constant color ext has correct value equals expected
        /// </summary>
        [Fact]
        public void OneMinusConstantColorExt_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8002, (int)BlendingFactorSrc.OneMinusConstantColorExt); }

        /// <summary>
        /// Tests that constant alpha has correct value equals expected
        /// </summary>
        [Fact]
        public void ConstantAlpha_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8003, (int)BlendingFactorSrc.ConstantAlpha); }

        /// <summary>
        /// Tests that constant alpha ext has correct value equals expected
        /// </summary>
        [Fact]
        public void ConstantAlphaExt_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8003, (int)BlendingFactorSrc.ConstantAlphaExt); }

        /// <summary>
        /// Tests that one minus constant alpha has correct value equals expected
        /// </summary>
        [Fact]
        public void OneMinusConstantAlpha_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8004, (int)BlendingFactorSrc.OneMinusConstantAlpha); }

        /// <summary>
        /// Tests that one minus constant alpha ext has correct value equals expected
        /// </summary>
        [Fact]
        public void OneMinusConstantAlphaExt_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8004, (int)BlendingFactorSrc.OneMinusConstantAlphaExt); }

        /// <summary>
        /// Tests that blending factor src is enum type is correct
        /// </summary>
        [Fact]
        public void BlendingFactorSrc_IsEnum_TypeIsCorrect() { Assert.True(typeof(BlendingFactorSrc).IsEnum); }

        /// <summary>
        /// Tests that blending factor src is public can be accessed
        /// </summary>
        [Fact]
        public void BlendingFactorSrc_IsPublic_CanBeAccessed() { Assert.True(typeof(BlendingFactorSrc).IsPublic); }

        /// <summary>
        /// Tests that blending factor src has multiple values count is not zero
        /// </summary>
        [Fact]
        public void BlendingFactorSrc_HasMultipleValues_CountIsNotZero()
        {
            Array enumValues = Enum.GetValues(typeof(BlendingFactorSrc));
            Assert.NotEmpty(enumValues);
        }

        /// <summary>
        /// Tests that blending factor src can cast to int conversion is valid
        /// </summary>
        [Fact]
        public void BlendingFactorSrc_CanCastToInt_ConversionIsValid()
        {
            int value = (int)BlendingFactorSrc.SrcAlpha;
            Assert.IsType<int>(value);
        }

        /// <summary>
        /// Tests that blending factor src can compare values equality works
        /// </summary>
        [Fact]
        public void BlendingFactorSrc_CanCompareValues_EqualityWorks()
        {
            BlendingFactorSrc factor1 = BlendingFactorSrc.SrcAlpha;
            BlendingFactorSrc factor2 = BlendingFactorSrc.SrcAlpha;
            Assert.Equal(factor1, factor2);
        }

        /// <summary>
        /// Tests that blending factor src different values are not equal
        /// </summary>
        [Fact]
        public void BlendingFactorSrc_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(BlendingFactorSrc.SrcAlpha, BlendingFactorSrc.DstAlpha);
        }

        /// <summary>
        /// Tests that constant color ext is alias equals constant color
        /// </summary>
        [Fact]
        public void ConstantColorExt_IsAlias_EqualsConstantColor()
        {
            Assert.Equal((int)BlendingFactorSrc.ConstantColor, (int)BlendingFactorSrc.ConstantColorExt);
        }

        /// <summary>
        /// Tests that one minus constant color ext is alias equals one minus constant color
        /// </summary>
        [Fact]
        public void OneMinusConstantColorExt_IsAlias_EqualsOneMinusConstantColor()
        {
            Assert.Equal((int)BlendingFactorSrc.OneMinusConstantColor, (int)BlendingFactorSrc.OneMinusConstantColorExt);
        }

        /// <summary>
        /// Tests that constant alpha ext is alias equals constant alpha
        /// </summary>
        [Fact]
        public void ConstantAlphaExt_IsAlias_EqualsConstantAlpha()
        {
            Assert.Equal((int)BlendingFactorSrc.ConstantAlpha, (int)BlendingFactorSrc.ConstantAlphaExt);
        }

        /// <summary>
        /// Tests that one minus constant alpha ext is alias equals one minus constant alpha
        /// </summary>
        [Fact]
        public void OneMinusConstantAlphaExt_IsAlias_EqualsOneMinusConstantAlpha()
        {
            Assert.Equal((int)BlendingFactorSrc.OneMinusConstantAlpha, (int)BlendingFactorSrc.OneMinusConstantAlphaExt);
        }
    }
}
