// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextureParameterTest.cs
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
    ///     Tests for the TextureParameter enum validating texture parameter values.
    /// </summary>
    public class TextureParameterTest
    {
        [Fact]
        public void Nearest_HasCorrectValue_EqualsExpected() { Assert.Equal(0x2600, (int)TextureParameter.Nearest); }

        [Fact]
        public void Linear_HasCorrectValue_EqualsExpected() { Assert.Equal(0x2601, (int)TextureParameter.Linear); }

        [Fact]
        public void NearestMipMapNearest_HasCorrectValue_EqualsExpected() { Assert.Equal(0x2700, (int)TextureParameter.NearestMipMapNearest); }

        [Fact]
        public void LinearMipMapNearest_HasCorrectValue_EqualsExpected() { Assert.Equal(0x2701, (int)TextureParameter.LinearMipMapNearest); }

        [Fact]
        public void NearestMipMapLinear_HasCorrectValue_EqualsExpected() { Assert.Equal(0x2702, (int)TextureParameter.NearestMipMapLinear); }

        [Fact]
        public void LinearMipMapLinear_HasCorrectValue_EqualsExpected() { Assert.Equal(0x2703, (int)TextureParameter.LinearMipMapLinear); }

        [Fact]
        public void ClampToEdge_HasCorrectValue_EqualsExpected() { Assert.Equal(0x812F, (int)TextureParameter.ClampToEdge); }

        [Fact]
        public void ClampToBorder_HasCorrectValue_EqualsExpected() { Assert.Equal(0x812D, (int)TextureParameter.ClampToBorder); }

        [Fact]
        public void MirrorClampToEdge_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8743, (int)TextureParameter.MirrorClampToEdge); }

        [Fact]
        public void MirroredRepeat_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8370, (int)TextureParameter.MirroredRepeat); }

        [Fact]
        public void Repeat_HasCorrectValue_EqualsExpected() { Assert.Equal(0x2901, (int)TextureParameter.Repeat); }

        [Fact]
        public void Red_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1903, (int)TextureParameter.Red); }

        [Fact]
        public void Green_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1904, (int)TextureParameter.Green); }

        [Fact]
        public void Blue_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1905, (int)TextureParameter.Blue); }

        [Fact]
        public void Alpha_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1906, (int)TextureParameter.Alpha); }

        [Fact]
        public void Zero_HasCorrectValue_EqualsExpected() { Assert.Equal(0, (int)TextureParameter.Zero); }

        [Fact]
        public void One_HasCorrectValue_EqualsExpected() { Assert.Equal(1, (int)TextureParameter.One); }

        [Fact]
        public void CompareRefToTexture_HasCorrectValue_EqualsExpected() { Assert.Equal(0x884E, (int)TextureParameter.CompareRefToTexture); }

        [Fact]
        public void None_HasCorrectValue_EqualsExpected() { Assert.Equal(0, (int)TextureParameter.None); }

        [Fact]
        public void StencilIndex_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1901, (int)TextureParameter.StencilIndex); }

        [Fact]
        public void DepthComponent_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1902, (int)TextureParameter.DepthComponent); }

        [Fact]
        public void MaxAnisotropyExt_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84FE, (int)TextureParameter.MaxAnisotropyExt); }

        [Fact]
        public void TextureParameter_IsEnum_TypeIsCorrect() { Assert.True(typeof(TextureParameter).IsEnum); }

        [Fact]
        public void TextureParameter_IsPublic_CanBeAccessed() { Assert.True(typeof(TextureParameter).IsPublic); }

        [Fact]
        public void TextureParameter_HasMultipleValues_CountIsNotZero()
        {
            Array enumValues = Enum.GetValues(typeof(TextureParameter));
            Assert.NotEmpty(enumValues);
        }

        [Fact]
        public void TextureParameter_CanCastToInt_ConversionIsValid()
        {
            int value = (int)TextureParameter.Nearest;
            Assert.IsType<int>(value);
        }

        [Fact]
        public void TextureParameter_CanCompareValues_EqualityWorks()
        {
            TextureParameter param1 = TextureParameter.Nearest;
            TextureParameter param2 = TextureParameter.Nearest;
            Assert.Equal(param1, param2);
        }

        [Fact]
        public void TextureParameter_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(TextureParameter.Nearest, TextureParameter.Linear);
        }
    }
}
