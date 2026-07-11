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
        /// <summary>
        /// Tests that nearest has correct value equals expected
        /// </summary>
        [Fact]
        public void Nearest_HasCorrectValue_EqualsExpected() { Assert.Equal(0x2600, (int)TextureParameter.Nearest); }

        /// <summary>
        /// Tests that linear has correct value equals expected
        /// </summary>
        [Fact]
        public void Linear_HasCorrectValue_EqualsExpected() { Assert.Equal(0x2601, (int)TextureParameter.Linear); }

        /// <summary>
        /// Tests that nearest mip map nearest has correct value equals expected
        /// </summary>
        [Fact]
        public void NearestMipMapNearest_HasCorrectValue_EqualsExpected() { Assert.Equal(0x2700, (int)TextureParameter.NearestMipMapNearest); }

        /// <summary>
        /// Tests that linear mip map nearest has correct value equals expected
        /// </summary>
        [Fact]
        public void LinearMipMapNearest_HasCorrectValue_EqualsExpected() { Assert.Equal(0x2701, (int)TextureParameter.LinearMipMapNearest); }

        /// <summary>
        /// Tests that nearest mip map linear has correct value equals expected
        /// </summary>
        [Fact]
        public void NearestMipMapLinear_HasCorrectValue_EqualsExpected() { Assert.Equal(0x2702, (int)TextureParameter.NearestMipMapLinear); }

        /// <summary>
        /// Tests that linear mip map linear has correct value equals expected
        /// </summary>
        [Fact]
        public void LinearMipMapLinear_HasCorrectValue_EqualsExpected() { Assert.Equal(0x2703, (int)TextureParameter.LinearMipMapLinear); }

        /// <summary>
        /// Tests that clamp to edge has correct value equals expected
        /// </summary>
        [Fact]
        public void ClampToEdge_HasCorrectValue_EqualsExpected() { Assert.Equal(0x812F, (int)TextureParameter.ClampToEdge); }

        /// <summary>
        /// Tests that clamp to border has correct value equals expected
        /// </summary>
        [Fact]
        public void ClampToBorder_HasCorrectValue_EqualsExpected() { Assert.Equal(0x812D, (int)TextureParameter.ClampToBorder); }

        /// <summary>
        /// Tests that mirror clamp to edge has correct value equals expected
        /// </summary>
        [Fact]
        public void MirrorClampToEdge_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8743, (int)TextureParameter.MirrorClampToEdge); }

        /// <summary>
        /// Tests that mirrored repeat has correct value equals expected
        /// </summary>
        [Fact]
        public void MirroredRepeat_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8370, (int)TextureParameter.MirroredRepeat); }

        /// <summary>
        /// Tests that repeat has correct value equals expected
        /// </summary>
        [Fact]
        public void Repeat_HasCorrectValue_EqualsExpected() { Assert.Equal(0x2901, (int)TextureParameter.Repeat); }

        /// <summary>
        /// Tests that red has correct value equals expected
        /// </summary>
        [Fact]
        public void Red_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1903, (int)TextureParameter.Red); }

        /// <summary>
        /// Tests that green has correct value equals expected
        /// </summary>
        [Fact]
        public void Green_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1904, (int)TextureParameter.Green); }

        /// <summary>
        /// Tests that blue has correct value equals expected
        /// </summary>
        [Fact]
        public void Blue_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1905, (int)TextureParameter.Blue); }

        /// <summary>
        /// Tests that alpha has correct value equals expected
        /// </summary>
        [Fact]
        public void Alpha_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1906, (int)TextureParameter.Alpha); }

        /// <summary>
        /// Tests that zero has correct value equals expected
        /// </summary>
        [Fact]
        public void Zero_HasCorrectValue_EqualsExpected() { Assert.Equal(0, (int)TextureParameter.Zero); }

        /// <summary>
        /// Tests that one has correct value equals expected
        /// </summary>
        [Fact]
        public void One_HasCorrectValue_EqualsExpected() { Assert.Equal(1, (int)TextureParameter.One); }

        /// <summary>
        /// Tests that compare ref to texture has correct value equals expected
        /// </summary>
        [Fact]
        public void CompareRefToTexture_HasCorrectValue_EqualsExpected() { Assert.Equal(0x884E, (int)TextureParameter.CompareRefToTexture); }

        /// <summary>
        /// Tests that none has correct value equals expected
        /// </summary>
        [Fact]
        public void None_HasCorrectValue_EqualsExpected() { Assert.Equal(0, (int)TextureParameter.None); }

        /// <summary>
        /// Tests that stencil index has correct value equals expected
        /// </summary>
        [Fact]
        public void StencilIndex_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1901, (int)TextureParameter.StencilIndex); }

        /// <summary>
        /// Tests that depth component has correct value equals expected
        /// </summary>
        [Fact]
        public void DepthComponent_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1902, (int)TextureParameter.DepthComponent); }

        /// <summary>
        /// Tests that max anisotropy ext has correct value equals expected
        /// </summary>
        [Fact]
        public void MaxAnisotropyExt_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84FE, (int)TextureParameter.MaxAnisotropyExt); }

        /// <summary>
        /// Tests that texture parameter is enum type is correct
        /// </summary>
        [Fact]
        public void TextureParameter_IsEnum_TypeIsCorrect() { Assert.True(typeof(TextureParameter).IsEnum); }

        /// <summary>
        /// Tests that texture parameter is public can be accessed
        /// </summary>
        [Fact]
        public void TextureParameter_IsPublic_CanBeAccessed() { Assert.True(typeof(TextureParameter).IsPublic); }

        /// <summary>
        /// Tests that texture parameter has multiple values count is not zero
        /// </summary>
        [Fact]
        public void TextureParameter_HasMultipleValues_CountIsNotZero()
        {
            Array enumValues = Enum.GetValues(typeof(TextureParameter));
            Assert.NotEmpty(enumValues);
        }

        /// <summary>
        /// Tests that texture parameter can cast to int conversion is valid
        /// </summary>
        [Fact]
        public void TextureParameter_CanCastToInt_ConversionIsValid()
        {
            int value = (int)TextureParameter.Nearest;
            Assert.IsType<int>(value);
        }

        /// <summary>
        /// Tests that texture parameter can compare values equality works
        /// </summary>
        [Fact]
        public void TextureParameter_CanCompareValues_EqualityWorks()
        {
            TextureParameter param1 = TextureParameter.Nearest;
            TextureParameter param2 = TextureParameter.Nearest;
            Assert.Equal(param1, param2);
        }

        /// <summary>
        /// Tests that texture parameter different values are not equal
        /// </summary>
        [Fact]
        public void TextureParameter_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(TextureParameter.Nearest, TextureParameter.Linear);
        }
    }
}
