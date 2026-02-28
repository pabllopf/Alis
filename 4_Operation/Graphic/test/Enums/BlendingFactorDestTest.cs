// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BlendingFactorDestTest.cs
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
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.Test.Enums
{
    /// <summary>
    /// Tests for the BlendingFactorDest enum validating destination blending factor types.
    /// </summary>
    public class BlendingFactorDestTest
    {
        /// <summary>
        /// Tests that Zero has correct value.
        /// </summary>
        [Fact]
        public void Zero_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0, (int)BlendingFactorDest.Zero);
        }

        /// <summary>
        /// Tests that SrcColor has correct value.
        /// </summary>
        [Fact]
        public void SrcColor_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0300, (int)BlendingFactorDest.SrcColor);
        }

        /// <summary>
        /// Tests that OneMinusSrcColor has correct value.
        /// </summary>
        [Fact]
        public void OneMinusSrcColor_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0301, (int)BlendingFactorDest.OneMinusSrcColor);
        }

        /// <summary>
        /// Tests that SrcAlpha has correct value.
        /// </summary>
        [Fact]
        public void SrcAlpha_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0302, (int)BlendingFactorDest.SrcAlpha);
        }

        /// <summary>
        /// Tests that OneMinusSrcAlpha has correct value.
        /// </summary>
        [Fact]
        public void OneMinusSrcAlpha_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0303, (int)BlendingFactorDest.OneMinusSrcAlpha);
        }

        /// <summary>
        /// Tests that DstAlpha has correct value.
        /// </summary>
        [Fact]
        public void DstAlpha_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0304, (int)BlendingFactorDest.DstAlpha);
        }

        /// <summary>
        /// Tests that OneMinusDstAlpha has correct value.
        /// </summary>
        [Fact]
        public void OneMinusDstAlpha_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0305, (int)BlendingFactorDest.OneMinusDstAlpha);
        }

        /// <summary>
        /// Tests that DstColor has correct value.
        /// </summary>
        [Fact]
        public void DstColor_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0306, (int)BlendingFactorDest.DstColor);
        }

        /// <summary>
        /// Tests that OneMinusDstColor has correct value.
        /// </summary>
        [Fact]
        public void OneMinusDstColor_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0307, (int)BlendingFactorDest.OneMinusDstColor);
        }

        /// <summary>
        /// Tests that ConstantColor has correct value.
        /// </summary>
        [Fact]
        public void ConstantColor_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8001, (int)BlendingFactorDest.ConstantColor);
        }

        /// <summary>
        /// Tests that OneMinusConstantColor has correct value.
        /// </summary>
        [Fact]
        public void OneMinusConstantColor_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8002, (int)BlendingFactorDest.OneMinusConstantColor);
        }

        /// <summary>
        /// Tests that BlendingFactorDest is an enum type.
        /// </summary>
        [Fact]
        public void BlendingFactorDest_IsEnum_TypeIsCorrect()
        {
            Assert.True(typeof(BlendingFactorDest).IsEnum);
        }

        /// <summary>
        /// Tests that BlendingFactorDest enum is public.
        /// </summary>
        [Fact]
        public void BlendingFactorDest_IsPublic_CanBeAccessed()
        {
            Assert.True(typeof(BlendingFactorDest).IsPublic);
        }

        /// <summary>
        /// Tests that BlendingFactorDest has expected number of values.
        /// </summary>
        [Fact]
        public void BlendingFactorDest_HasMultipleValues_CountIsCorrect()
        {
            Array enumValues = System.Enum.GetValues(typeof(BlendingFactorDest));
            Assert.NotEmpty(enumValues);
        }

        /// <summary>
        /// Tests that BlendingFactorDest can be cast to int.
        /// </summary>
        [Fact]
        public void BlendingFactorDest_CanCastToInt_ConversionIsValid()
        {
            int value = (int)BlendingFactorDest.SrcAlpha;
            Assert.IsType<int>(value);
        }

        /// <summary>
        /// Tests that BlendingFactorDest values can be compared.
        /// </summary>
        [Fact]
        public void BlendingFactorDest_CanCompareValues_EqualityWorks()
        {
            BlendingFactorDest factor1 = BlendingFactorDest.SrcAlpha;
            BlendingFactorDest factor2 = BlendingFactorDest.SrcAlpha;
            Assert.Equal(factor1, factor2);
        }

        /// <summary>
        /// Tests that different BlendingFactorDest values are not equal.
        /// </summary>
        [Fact]
        public void BlendingFactorDest_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(BlendingFactorDest.SrcAlpha, BlendingFactorDest.DstAlpha);
        }

        /// <summary>
        /// Tests that ConstantColorExt alias is equivalent to ConstantColor.
        /// </summary>
        [Fact]
        public void ConstantColorExt_IsAlias_EqualsConstantColor()
        {
            Assert.Equal((int)BlendingFactorDest.ConstantColor, (int)BlendingFactorDest.ConstantColorExt);
        }

        /// <summary>
        /// Tests that OneMinusConstantColorExt alias is equivalent to OneMinusConstantColor.
        /// </summary>
        [Fact]
        public void OneMinusConstantColorExt_IsAlias_EqualsOneMinusConstantColor()
        {
            Assert.Equal((int)BlendingFactorDest.OneMinusConstantColor, (int)BlendingFactorDest.OneMinusConstantColorExt);
        }
    }
}

