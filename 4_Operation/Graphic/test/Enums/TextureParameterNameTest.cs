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
        [Fact]
        public void TextureBaseLevel_HasCorrectValue_EqualsExpected() { Assert.Equal(0x813C, (int)TextureParameterName.TextureBaseLevel); }

        [Fact]
        public void TextureBorderColor_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1004, (int)TextureParameterName.TextureBorderColor); }

        [Fact]
        public void TextureCompareMode_HasCorrectValue_EqualsExpected() { Assert.Equal(0x884C, (int)TextureParameterName.TextureCompareMode); }

        [Fact]
        public void TextureCompareFunc_HasCorrectValue_EqualsExpected() { Assert.Equal(0x884D, (int)TextureParameterName.TextureCompareFunc); }

        [Fact]
        public void TextureLodBias_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8501, (int)TextureParameterName.TextureLodBias); }

        [Fact]
        public void TextureMagFilter_HasCorrectValue_EqualsExpected() { Assert.Equal(0x2800, (int)TextureParameterName.TextureMagFilter); }

        [Fact]
        public void TextureMaxLevel_HasCorrectValue_EqualsExpected() { Assert.Equal(0x813D, (int)TextureParameterName.TextureMaxLevel); }

        [Fact]
        public void TextureMaxLod_HasCorrectValue_EqualsExpected() { Assert.Equal(0x813B, (int)TextureParameterName.TextureMaxLod); }

        [Fact]
        public void TextureMinFilter_HasCorrectValue_EqualsExpected() { Assert.Equal(0x2801, (int)TextureParameterName.TextureMinFilter); }

        [Fact]
        public void TextureMinLod_HasCorrectValue_EqualsExpected() { Assert.Equal(0x813A, (int)TextureParameterName.TextureMinLod); }

        [Fact]
        public void TextureSwizzleR_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8E42, (int)TextureParameterName.TextureSwizzleR); }

        [Fact]
        public void TextureSwizzleG_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8E43, (int)TextureParameterName.TextureSwizzleG); }

        [Fact]
        public void TextureSwizzleB_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8E44, (int)TextureParameterName.TextureSwizzleB); }

        [Fact]
        public void TextureSwizzleA_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8E45, (int)TextureParameterName.TextureSwizzleA); }

        [Fact]
        public void TextureSwizzleRgba_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8E46, (int)TextureParameterName.TextureSwizzleRgba); }

        [Fact]
        public void TextureWrapS_HasCorrectValue_EqualsExpected() { Assert.Equal(0x2802, (int)TextureParameterName.TextureWrapS); }

        [Fact]
        public void TextureWrapT_HasCorrectValue_EqualsExpected() { Assert.Equal(0x2803, (int)TextureParameterName.TextureWrapT); }

        [Fact]
        public void TextureWrapR_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8072, (int)TextureParameterName.TextureWrapR); }

        [Fact]
        public void MaxAnisotropyExt_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84FE, (int)TextureParameterName.MaxAnisotropyExt); }

        [Fact]
        public void TextureParameterName_IsEnum_TypeIsCorrect() { Assert.True(typeof(TextureParameterName).IsEnum); }

        [Fact]
        public void TextureParameterName_IsPublic_CanBeAccessed() { Assert.True(typeof(TextureParameterName).IsPublic); }

        [Fact]
        public void TextureParameterName_HasMultipleValues_CountIsNotZero()
        {
            Array enumValues = Enum.GetValues(typeof(TextureParameterName));
            Assert.NotEmpty(enumValues);
        }

        [Fact]
        public void TextureParameterName_CanCastToInt_ConversionIsValid()
        {
            int value = (int)TextureParameterName.TextureMagFilter;
            Assert.IsType<int>(value);
        }

        [Fact]
        public void TextureParameterName_CanCompareValues_EqualityWorks()
        {
            TextureParameterName param1 = TextureParameterName.TextureMagFilter;
            TextureParameterName param2 = TextureParameterName.TextureMagFilter;
            Assert.Equal(param1, param2);
        }

        [Fact]
        public void TextureParameterName_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(TextureParameterName.TextureMagFilter, TextureParameterName.TextureMinFilter);
        }
    }
}
