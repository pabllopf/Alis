// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextureUnitTest.cs
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
    ///     Tests for the TextureUnit enum validating texture unit identifiers.
    /// </summary>
    public class TextureUnitTest
    {
        [Fact]
        public void Texture0_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84C0, (int)TextureUnit.Texture0); }

        [Fact]
        public void Texture1_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84C1, (int)TextureUnit.Texture1); }

        [Fact]
        public void Texture2_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84C2, (int)TextureUnit.Texture2); }

        [Fact]
        public void Texture3_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84C3, (int)TextureUnit.Texture3); }

        [Fact]
        public void Texture4_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84C4, (int)TextureUnit.Texture4); }

        [Fact]
        public void Texture5_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84C5, (int)TextureUnit.Texture5); }

        [Fact]
        public void Texture6_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84C6, (int)TextureUnit.Texture6); }

        [Fact]
        public void Texture7_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84C7, (int)TextureUnit.Texture7); }

        [Fact]
        public void Texture8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84C8, (int)TextureUnit.Texture8); }

        [Fact]
        public void Texture9_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84C9, (int)TextureUnit.Texture9); }

        [Fact]
        public void Texture10_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84CA, (int)TextureUnit.Texture10); }

        [Fact]
        public void Texture11_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84CB, (int)TextureUnit.Texture11); }

        [Fact]
        public void Texture12_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84CC, (int)TextureUnit.Texture12); }

        [Fact]
        public void Texture13_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84CD, (int)TextureUnit.Texture13); }

        [Fact]
        public void Texture14_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84CE, (int)TextureUnit.Texture14); }

        [Fact]
        public void Texture15_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84CF, (int)TextureUnit.Texture15); }

        [Fact]
        public void TextureUnit_IsEnum_TypeIsCorrect() { Assert.True(typeof(TextureUnit).IsEnum); }

        [Fact]
        public void TextureUnit_IsPublic_CanBeAccessed() { Assert.True(typeof(TextureUnit).IsPublic); }

        [Fact]
        public void TextureUnit_HasSixteenValues_CountIsCorrect()
        {
            Array enumValues = Enum.GetValues(typeof(TextureUnit));
            Assert.Equal(16, enumValues.Length);
        }

        [Fact]
        public void TextureUnit_CanCastToInt_ConversionIsValid()
        {
            int value = (int)TextureUnit.Texture0;
            Assert.IsType<int>(value);
        }

        [Fact]
        public void TextureUnit_CanCompareValues_EqualityWorks()
        {
            TextureUnit unit1 = TextureUnit.Texture0;
            TextureUnit unit2 = TextureUnit.Texture0;
            Assert.Equal(unit1, unit2);
        }

        [Fact]
        public void TextureUnit_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(TextureUnit.Texture0, TextureUnit.Texture1);
        }
    }
}
