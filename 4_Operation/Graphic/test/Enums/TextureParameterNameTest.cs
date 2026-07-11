// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextureParameterNameTest.cs
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
    ///     Tests for the TextureParameterName enum validating texture parameter names.
    /// </summary>
    public class TextureParameterNameTest
    {
        /// <summary>
        /// Tests that texture base level has correct value equals expected
        /// </summary>
        [Fact]
        public void TextureBaseLevel_HasCorrectValue_EqualsExpected() { Assert.Equal(0x813C, (int)TextureParameterName.TextureBaseLevel); }

        /// <summary>
        /// Tests that texture border color has correct value equals expected
        /// </summary>
        [Fact]
        public void TextureBorderColor_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1004, (int)TextureParameterName.TextureBorderColor); }

        /// <summary>
        /// Tests that texture compare mode has correct value equals expected
        /// </summary>
        [Fact]
        public void TextureCompareMode_HasCorrectValue_EqualsExpected() { Assert.Equal(0x884C, (int)TextureParameterName.TextureCompareMode); }

        /// <summary>
        /// Tests that texture compare func has correct value equals expected
        /// </summary>
        [Fact]
        public void TextureCompareFunc_HasCorrectValue_EqualsExpected() { Assert.Equal(0x884D, (int)TextureParameterName.TextureCompareFunc); }

        /// <summary>
        /// Tests that texture lod bias has correct value equals expected
        /// </summary>
        [Fact]
        public void TextureLodBias_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8501, (int)TextureParameterName.TextureLodBias); }

        /// <summary>
        /// Tests that texture mag filter has correct value equals expected
        /// </summary>
        [Fact]
        public void TextureMagFilter_HasCorrectValue_EqualsExpected() { Assert.Equal(0x2800, (int)TextureParameterName.TextureMagFilter); }

        /// <summary>
        /// Tests that texture max level has correct value equals expected
        /// </summary>
        [Fact]
        public void TextureMaxLevel_HasCorrectValue_EqualsExpected() { Assert.Equal(0x813D, (int)TextureParameterName.TextureMaxLevel); }

        /// <summary>
        /// Tests that texture max lod has correct value equals expected
        /// </summary>
        [Fact]
        public void TextureMaxLod_HasCorrectValue_EqualsExpected() { Assert.Equal(0x813B, (int)TextureParameterName.TextureMaxLod); }

        /// <summary>
        /// Tests that texture min filter has correct value equals expected
        /// </summary>
        [Fact]
        public void TextureMinFilter_HasCorrectValue_EqualsExpected() { Assert.Equal(0x2801, (int)TextureParameterName.TextureMinFilter); }

        /// <summary>
        /// Tests that texture min lod has correct value equals expected
        /// </summary>
        [Fact]
        public void TextureMinLod_HasCorrectValue_EqualsExpected() { Assert.Equal(0x813A, (int)TextureParameterName.TextureMinLod); }

        /// <summary>
        /// Tests that texture swizzle r has correct value equals expected
        /// </summary>
        [Fact]
        public void TextureSwizzleR_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8E42, (int)TextureParameterName.TextureSwizzleR); }

        /// <summary>
        /// Tests that texture swizzle g has correct value equals expected
        /// </summary>
        [Fact]
        public void TextureSwizzleG_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8E43, (int)TextureParameterName.TextureSwizzleG); }

        /// <summary>
        /// Tests that texture swizzle b has correct value equals expected
        /// </summary>
        [Fact]
        public void TextureSwizzleB_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8E44, (int)TextureParameterName.TextureSwizzleB); }

        /// <summary>
        /// Tests that texture swizzle a has correct value equals expected
        /// </summary>
        [Fact]
        public void TextureSwizzleA_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8E45, (int)TextureParameterName.TextureSwizzleA); }

        /// <summary>
        /// Tests that texture swizzle rgba has correct value equals expected
        /// </summary>
        [Fact]
        public void TextureSwizzleRgba_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8E46, (int)TextureParameterName.TextureSwizzleRgba); }

        /// <summary>
        /// Tests that texture wrap s has correct value equals expected
        /// </summary>
        [Fact]
        public void TextureWrapS_HasCorrectValue_EqualsExpected() { Assert.Equal(0x2802, (int)TextureParameterName.TextureWrapS); }

        /// <summary>
        /// Tests that texture wrap t has correct value equals expected
        /// </summary>
        [Fact]
        public void TextureWrapT_HasCorrectValue_EqualsExpected() { Assert.Equal(0x2803, (int)TextureParameterName.TextureWrapT); }

        /// <summary>
        /// Tests that texture wrap r has correct value equals expected
        /// </summary>
        [Fact]
        public void TextureWrapR_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8072, (int)TextureParameterName.TextureWrapR); }

        /// <summary>
        /// Tests that max anisotropy ext has correct value equals expected
        /// </summary>
        [Fact]
        public void MaxAnisotropyExt_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84FE, (int)TextureParameterName.MaxAnisotropyExt); }

        /// <summary>
        /// Tests that texture parameter name is enum type is correct
        /// </summary>
        [Fact]
        public void TextureParameterName_IsEnum_TypeIsCorrect() { Assert.True(typeof(TextureParameterName).IsEnum); }

        /// <summary>
        /// Tests that texture parameter name is public can be accessed
        /// </summary>
        [Fact]
        public void TextureParameterName_IsPublic_CanBeAccessed() { Assert.True(typeof(TextureParameterName).IsPublic); }

        /// <summary>
        /// Tests that texture parameter name has multiple values count is not zero
        /// </summary>
        [Fact]
        public void TextureParameterName_HasMultipleValues_CountIsNotZero()
        {
            Array enumValues = Enum.GetValues(typeof(TextureParameterName));
            Assert.NotEmpty(enumValues);
        }

        /// <summary>
        /// Tests that texture parameter name can cast to int conversion is valid
        /// </summary>
        [Fact]
        public void TextureParameterName_CanCastToInt_ConversionIsValid()
        {
            int value = (int)TextureParameterName.TextureMagFilter;
            Assert.IsType<int>(value);
        }

        /// <summary>
        /// Tests that texture parameter name can compare values equality works
        /// </summary>
        [Fact]
        public void TextureParameterName_CanCompareValues_EqualityWorks()
        {
            TextureParameterName param1 = TextureParameterName.TextureMagFilter;
            TextureParameterName param2 = TextureParameterName.TextureMagFilter;
            Assert.Equal(param1, param2);
        }

        /// <summary>
        /// Tests that texture parameter name different values are not equal
        /// </summary>
        [Fact]
        public void TextureParameterName_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(TextureParameterName.TextureMagFilter, TextureParameterName.TextureMinFilter);
        }
    }
}
