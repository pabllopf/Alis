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
        /// <summary>
        /// Tests that texture 0 has correct value equals expected
        /// </summary>
        [Fact]
        public void Texture0_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84C0, (int)TextureUnit.Texture0); }

        /// <summary>
        /// Tests that texture 1 has correct value equals expected
        /// </summary>
        [Fact]
        public void Texture1_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84C1, (int)TextureUnit.Texture1); }

        /// <summary>
        /// Tests that texture 2 has correct value equals expected
        /// </summary>
        [Fact]
        public void Texture2_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84C2, (int)TextureUnit.Texture2); }

        /// <summary>
        /// Tests that texture 3 has correct value equals expected
        /// </summary>
        [Fact]
        public void Texture3_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84C3, (int)TextureUnit.Texture3); }

        /// <summary>
        /// Tests that texture 4 has correct value equals expected
        /// </summary>
        [Fact]
        public void Texture4_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84C4, (int)TextureUnit.Texture4); }

        /// <summary>
        /// Tests that texture 5 has correct value equals expected
        /// </summary>
        [Fact]
        public void Texture5_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84C5, (int)TextureUnit.Texture5); }

        /// <summary>
        /// Tests that texture 6 has correct value equals expected
        /// </summary>
        [Fact]
        public void Texture6_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84C6, (int)TextureUnit.Texture6); }

        /// <summary>
        /// Tests that texture 7 has correct value equals expected
        /// </summary>
        [Fact]
        public void Texture7_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84C7, (int)TextureUnit.Texture7); }

        /// <summary>
        /// Tests that texture 8 has correct value equals expected
        /// </summary>
        [Fact]
        public void Texture8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84C8, (int)TextureUnit.Texture8); }

        /// <summary>
        /// Tests that texture 9 has correct value equals expected
        /// </summary>
        [Fact]
        public void Texture9_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84C9, (int)TextureUnit.Texture9); }

        /// <summary>
        /// Tests that texture 10 has correct value equals expected
        /// </summary>
        [Fact]
        public void Texture10_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84CA, (int)TextureUnit.Texture10); }

        /// <summary>
        /// Tests that texture 11 has correct value equals expected
        /// </summary>
        [Fact]
        public void Texture11_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84CB, (int)TextureUnit.Texture11); }

        /// <summary>
        /// Tests that texture 12 has correct value equals expected
        /// </summary>
        [Fact]
        public void Texture12_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84CC, (int)TextureUnit.Texture12); }

        /// <summary>
        /// Tests that texture 13 has correct value equals expected
        /// </summary>
        [Fact]
        public void Texture13_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84CD, (int)TextureUnit.Texture13); }

        /// <summary>
        /// Tests that texture 14 has correct value equals expected
        /// </summary>
        [Fact]
        public void Texture14_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84CE, (int)TextureUnit.Texture14); }

        /// <summary>
        /// Tests that texture 15 has correct value equals expected
        /// </summary>
        [Fact]
        public void Texture15_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84CF, (int)TextureUnit.Texture15); }

        /// <summary>
        /// Tests that texture unit is enum type is correct
        /// </summary>
        [Fact]
        public void TextureUnit_IsEnum_TypeIsCorrect() { Assert.True(typeof(TextureUnit).IsEnum); }

        /// <summary>
        /// Tests that texture unit is public can be accessed
        /// </summary>
        [Fact]
        public void TextureUnit_IsPublic_CanBeAccessed() { Assert.True(typeof(TextureUnit).IsPublic); }

        /// <summary>
        /// Tests that texture unit has sixteen values count is correct
        /// </summary>
        [Fact]
        public void TextureUnit_HasSixteenValues_CountIsCorrect()
        {
            Array enumValues = Enum.GetValues(typeof(TextureUnit));
            Assert.Equal(16, enumValues.Length);
        }

        /// <summary>
        /// Tests that texture unit can cast to int conversion is valid
        /// </summary>
        [Fact]
        public void TextureUnit_CanCastToInt_ConversionIsValid()
        {
            int value = (int)TextureUnit.Texture0;
            Assert.IsType<int>(value);
        }

        /// <summary>
        /// Tests that texture unit can compare values equality works
        /// </summary>
        [Fact]
        public void TextureUnit_CanCompareValues_EqualityWorks()
        {
            TextureUnit unit1 = TextureUnit.Texture0;
            TextureUnit unit2 = TextureUnit.Texture0;
            Assert.Equal(unit1, unit2);
        }

        /// <summary>
        /// Tests that texture unit different values are not equal
        /// </summary>
        [Fact]
        public void TextureUnit_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(TextureUnit.Texture0, TextureUnit.Texture1);
        }
    }
}
