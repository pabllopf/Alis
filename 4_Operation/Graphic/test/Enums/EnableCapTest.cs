// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EnableCapTest.cs
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
    /// Tests for the EnableCap enum validating all OpenGL capability flags.
    /// </summary>
    public class EnableCapTest
    {
        /// <summary>
        /// Tests that LineSmooth has correct value.
        /// </summary>
        [Fact]
        public void LineSmooth_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0B20, (int)EnableCap.LineSmooth);
        }

        /// <summary>
        /// Tests that PolygonSmooth has correct value.
        /// </summary>
        [Fact]
        public void PolygonSmooth_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0B41, (int)EnableCap.PolygonSmooth);
        }

        /// <summary>
        /// Tests that CullFace has correct value.
        /// </summary>
        [Fact]
        public void CullFace_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0B44, (int)EnableCap.CullFace);
        }

        /// <summary>
        /// Tests that DepthTest has correct value.
        /// </summary>
        [Fact]
        public void DepthTest_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0B71, (int)EnableCap.DepthTest);
        }

        /// <summary>
        /// Tests that StencilTest has correct value.
        /// </summary>
        [Fact]
        public void StencilTest_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0B90, (int)EnableCap.StencilTest);
        }

        /// <summary>
        /// Tests that Dither has correct value.
        /// </summary>
        [Fact]
        public void Dither_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0BD0, (int)EnableCap.Dither);
        }

        /// <summary>
        /// Tests that Blend has correct value.
        /// </summary>
        [Fact]
        public void Blend_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0BE2, (int)EnableCap.Blend);
        }

        /// <summary>
        /// Tests that IndexLogicOp has correct value.
        /// </summary>
        [Fact]
        public void IndexLogicOp_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0BF1, (int)EnableCap.IndexLogicOp);
        }

        /// <summary>
        /// Tests that ColorLogicOp has correct value.
        /// </summary>
        [Fact]
        public void ColorLogicOp_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0BF2, (int)EnableCap.ColorLogicOp);
        }

        /// <summary>
        /// Tests that ScissorTest has correct value.
        /// </summary>
        [Fact]
        public void ScissorTest_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0C11, (int)EnableCap.ScissorTest);
        }

        /// <summary>
        /// Tests that EnableCap is an enum type.
        /// </summary>
        [Fact]
        public void EnableCap_IsEnum_TypeIsCorrect()
        {
            Assert.True(typeof(EnableCap).IsEnum);
        }

        /// <summary>
        /// Tests that EnableCap enum is public.
        /// </summary>
        [Fact]
        public void EnableCap_IsPublic_CanBeAccessed()
        {
            Assert.True(typeof(EnableCap).IsPublic);
        }

        /// <summary>
        /// Tests that EnableCap has multiple defined values.
        /// </summary>
        [Fact]
        public void EnableCap_HasMultipleValues_CountIsNotZero()
        {
            Array enumValues = System.Enum.GetValues(typeof(EnableCap));
            Assert.NotEmpty(enumValues);
            Assert.True(enumValues.Length > 10);
        }

        /// <summary>
        /// Tests that EnableCap can be cast to int.
        /// </summary>
        [Fact]
        public void EnableCap_CanCastToInt_ConversionIsValid()
        {
            int value = (int)EnableCap.Blend;
            Assert.IsType<int>(value);
        }

        /// <summary>
        /// Tests that EnableCap values can be compared.
        /// </summary>
        [Fact]
        public void EnableCap_CanCompareValues_EqualityWorks()
        {
            EnableCap cap1 = EnableCap.Blend;
            EnableCap cap2 = EnableCap.Blend;
            Assert.Equal(cap1, cap2);
        }

        /// <summary>
        /// Tests that different EnableCap values are not equal.
        /// </summary>
        [Fact]
        public void EnableCap_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(EnableCap.Blend, EnableCap.DepthTest);
        }

        /// <summary>
        /// Tests that EnableCap contains common capabilities.
        /// </summary>
        [Fact]
        public void EnableCap_ContainsCommonCapabilities_AllPresent()
        {
            // Verify that common capabilities are present
            EnableCap blendCap = EnableCap.Blend;
            EnableCap depthTestCap = EnableCap.DepthTest;
            EnableCap scissorTestCap = EnableCap.ScissorTest;
            EnableCap cullFaceCap = EnableCap.CullFace;

            Assert.NotNull(blendCap);
            Assert.NotNull(depthTestCap);
            Assert.NotNull(scissorTestCap);
            Assert.NotNull(cullFaceCap);
        }
    }
}

