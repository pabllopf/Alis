// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PixelFormatTest.cs
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
    /// Tests for the PixelFormat enum validating pixel format specifications.
    /// </summary>
    public class PixelFormatTest
    {
        /// <summary>
        /// Tests that ColorIndex has correct value.
        /// </summary>
        [Fact]
        public void ColorIndex_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x1900, (int)PixelFormat.ColorIndex);
        }

        /// <summary>
        /// Tests that StencilIndex has correct value.
        /// </summary>
        [Fact]
        public void StencilIndex_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x1901, (int)PixelFormat.StencilIndex);
        }

        /// <summary>
        /// Tests that DepthComponent has correct value.
        /// </summary>
        [Fact]
        public void DepthComponent_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x1902, (int)PixelFormat.DepthComponent);
        }

        /// <summary>
        /// Tests that Red has correct value.
        /// </summary>
        [Fact]
        public void Red_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x1903, (int)PixelFormat.Red);
        }

        /// <summary>
        /// Tests that Green has correct value.
        /// </summary>
        [Fact]
        public void Green_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x1904, (int)PixelFormat.Green);
        }

        /// <summary>
        /// Tests that Blue has correct value.
        /// </summary>
        [Fact]
        public void Blue_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x1905, (int)PixelFormat.Blue);
        }

        /// <summary>
        /// Tests that Alpha has correct value.
        /// </summary>
        [Fact]
        public void Alpha_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x1906, (int)PixelFormat.Alpha);
        }

        /// <summary>
        /// Tests that Rgb has correct value.
        /// </summary>
        [Fact]
        public void Rgb_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x1907, (int)PixelFormat.Rgb);
        }

        /// <summary>
        /// Tests that Rgba has correct value.
        /// </summary>
        [Fact]
        public void Rgba_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x1908, (int)PixelFormat.Rgba);
        }

        /// <summary>
        /// Tests that PixelFormat is an enum type.
        /// </summary>
        [Fact]
        public void PixelFormat_IsEnum_TypeIsCorrect()
        {
            Assert.True(typeof(PixelFormat).IsEnum);
        }

        /// <summary>
        /// Tests that PixelFormat enum is public.
        /// </summary>
        [Fact]
        public void PixelFormat_IsPublic_CanBeAccessed()
        {
            Assert.True(typeof(PixelFormat).IsPublic);
        }

        /// <summary>
        /// Tests that PixelFormat has multiple defined values.
        /// </summary>
        [Fact]
        public void PixelFormat_HasMultipleValues_CountIsNotZero()
        {
            Array enumValues = System.Enum.GetValues(typeof(PixelFormat));
            Assert.NotEmpty(enumValues);
        }

        /// <summary>
        /// Tests that PixelFormat can be cast to int.
        /// </summary>
        [Fact]
        public void PixelFormat_CanCastToInt_ConversionIsValid()
        {
            int value = (int)PixelFormat.Rgba;
            Assert.IsType<int>(value);
        }

        /// <summary>
        /// Tests that PixelFormat values can be compared.
        /// </summary>
        [Fact]
        public void PixelFormat_CanCompareValues_EqualityWorks()
        {
            PixelFormat format1 = PixelFormat.Rgba;
            PixelFormat format2 = PixelFormat.Rgba;
            Assert.Equal(format1, format2);
        }

        /// <summary>
        /// Tests that different PixelFormat values are not equal.
        /// </summary>
        [Fact]
        public void PixelFormat_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(PixelFormat.Rgb, PixelFormat.Rgba);
        }

        /// <summary>
        /// Tests that PixelFormat contains common color formats.
        /// </summary>
        [Fact]
        public void PixelFormat_ContainsCommonFormats_AllPresent()
        {
            PixelFormat rgbFormat = PixelFormat.Rgb;
            PixelFormat rgbaFormat = PixelFormat.Rgba;
            PixelFormat redFormat = PixelFormat.Red;

            Assert.NotNull(rgbFormat);
            Assert.NotNull(rgbaFormat);
            Assert.NotNull(redFormat);
        }
    }
}

