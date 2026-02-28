// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PixelTypeTest.cs
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
    /// Tests for the PixelType enum validating pixel data type definitions.
    /// </summary>
    public class PixelTypeTest
    {
        /// <summary>
        /// Tests that Byte has correct value.
        /// </summary>
        [Fact]
        public void Byte_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x1400, (int)PixelType.Byte);
        }

        /// <summary>
        /// Tests that UnsignedByte has correct value.
        /// </summary>
        [Fact]
        public void UnsignedByte_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x1401, (int)PixelType.UnsignedByte);
        }

        /// <summary>
        /// Tests that Short has correct value.
        /// </summary>
        [Fact]
        public void Short_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x1402, (int)PixelType.Short);
        }

        /// <summary>
        /// Tests that UnsignedShort has correct value.
        /// </summary>
        [Fact]
        public void UnsignedShort_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x1403, (int)PixelType.UnsignedShort);
        }

        /// <summary>
        /// Tests that Int has correct value.
        /// </summary>
        [Fact]
        public void Int_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x1404, (int)PixelType.Int);
        }

        /// <summary>
        /// Tests that UnsignedInt has correct value.
        /// </summary>
        [Fact]
        public void UnsignedInt_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x1405, (int)PixelType.UnsignedInt);
        }

        /// <summary>
        /// Tests that Float has correct value.
        /// </summary>
        [Fact]
        public void Float_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x1406, (int)PixelType.Float);
        }

        /// <summary>
        /// Tests that HalfFloat has correct value.
        /// </summary>
        [Fact]
        public void HalfFloat_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x140B, (int)PixelType.HalfFloat);
        }

        /// <summary>
        /// Tests that Bitmap has correct value.
        /// </summary>
        [Fact]
        public void Bitmap_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x1A00, (int)PixelType.Bitmap);
        }

        /// <summary>
        /// Tests that PixelType is an enum type.
        /// </summary>
        [Fact]
        public void PixelType_IsEnum_TypeIsCorrect()
        {
            Assert.True(typeof(PixelType).IsEnum);
        }

        /// <summary>
        /// Tests that PixelType enum is public.
        /// </summary>
        [Fact]
        public void PixelType_IsPublic_CanBeAccessed()
        {
            Assert.True(typeof(PixelType).IsPublic);
        }

        /// <summary>
        /// Tests that PixelType has multiple defined values.
        /// </summary>
        [Fact]
        public void PixelType_HasMultipleValues_CountIsNotZero()
        {
            Array enumValues = System.Enum.GetValues(typeof(PixelType));
            Assert.NotEmpty(enumValues);
        }

        /// <summary>
        /// Tests that PixelType can be cast to int.
        /// </summary>
        [Fact]
        public void PixelType_CanCastToInt_ConversionIsValid()
        {
            int value = (int)PixelType.UnsignedByte;
            Assert.IsType<int>(value);
        }

        /// <summary>
        /// Tests that PixelType values can be compared.
        /// </summary>
        [Fact]
        public void PixelType_CanCompareValues_EqualityWorks()
        {
            PixelType type1 = PixelType.Float;
            PixelType type2 = PixelType.Float;
            Assert.Equal(type1, type2);
        }

        /// <summary>
        /// Tests that different PixelType values are not equal.
        /// </summary>
        [Fact]
        public void PixelType_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(PixelType.UnsignedByte, PixelType.Float);
        }

        /// <summary>
        /// Tests that PixelType contains common data types.
        /// </summary>
        [Fact]
        public void PixelType_ContainsCommonTypes_AllPresent()
        {
            PixelType byteType = PixelType.Byte;
            PixelType unsignedByteType = PixelType.UnsignedByte;
            PixelType floatType = PixelType.Float;

            Assert.NotNull(byteType);
            Assert.NotNull(unsignedByteType);
            Assert.NotNull(floatType);
        }
    }
}

