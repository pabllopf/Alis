// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VertexAttribPointerTypeTest.cs
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
    ///     Tests for the VertexAttribPointerType enum validating vertex attribute pointer types.
    /// </summary>
    public class VertexAttribPointerTypeTest
    {
        /// <summary>
        /// Tests that byte has correct value equals expected
        /// </summary>
        [Fact]
        public void Byte_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1400, (int)VertexAttribPointerType.Byte); }

        /// <summary>
        /// Tests that unsigned byte has correct value equals expected
        /// </summary>
        [Fact]
        public void UnsignedByte_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1401, (int)VertexAttribPointerType.UnsignedByte); }

        /// <summary>
        /// Tests that short has correct value equals expected
        /// </summary>
        [Fact]
        public void Short_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1402, (int)VertexAttribPointerType.Short); }

        /// <summary>
        /// Tests that unsigned short has correct value equals expected
        /// </summary>
        [Fact]
        public void UnsignedShort_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1403, (int)VertexAttribPointerType.UnsignedShort); }

        /// <summary>
        /// Tests that int has correct value equals expected
        /// </summary>
        [Fact]
        public void Int_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1404, (int)VertexAttribPointerType.Int); }

        /// <summary>
        /// Tests that unsigned int has correct value equals expected
        /// </summary>
        [Fact]
        public void UnsignedInt_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1405, (int)VertexAttribPointerType.UnsignedInt); }

        /// <summary>
        /// Tests that float has correct value equals expected
        /// </summary>
        [Fact]
        public void Float_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1406, (int)VertexAttribPointerType.Float); }

        /// <summary>
        /// Tests that double has correct value equals expected
        /// </summary>
        [Fact]
        public void Double_HasCorrectValue_EqualsExpected() { Assert.Equal(0x140A, (int)VertexAttribPointerType.Double); }

        /// <summary>
        /// Tests that half float has correct value equals expected
        /// </summary>
        [Fact]
        public void HalfFloat_HasCorrectValue_EqualsExpected() { Assert.Equal(0x140B, (int)VertexAttribPointerType.HalfFloat); }

        /// <summary>
        /// Tests that unsigned u int 2101010 reversed has correct value equals expected
        /// </summary>
        [Fact]
        public void UnsignedUInt2101010Reversed_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8368, (int)VertexAttribPointerType.UnsignedUInt2101010Reversed); }

        /// <summary>
        /// Tests that unsigned int 2101010 reversed has correct value equals expected
        /// </summary>
        [Fact]
        public void UnsignedInt2101010Reversed_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D9F, (int)VertexAttribPointerType.UnsignedInt2101010Reversed); }

        /// <summary>
        /// Tests that unsigned u int 101111 reversed has correct value equals expected
        /// </summary>
        [Fact]
        public void UnsignedUInt101111Reversed_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C3B, (int)VertexAttribPointerType.UnsignedUInt101111Reversed); }

        /// <summary>
        /// Tests that vertex attrib pointer type is enum type is correct
        /// </summary>
        [Fact]
        public void VertexAttribPointerType_IsEnum_TypeIsCorrect() { Assert.True(typeof(VertexAttribPointerType).IsEnum); }

        /// <summary>
        /// Tests that vertex attrib pointer type is public can be accessed
        /// </summary>
        [Fact]
        public void VertexAttribPointerType_IsPublic_CanBeAccessed() { Assert.True(typeof(VertexAttribPointerType).IsPublic); }

        /// <summary>
        /// Tests that vertex attrib pointer type has multiple values count is not zero
        /// </summary>
        [Fact]
        public void VertexAttribPointerType_HasMultipleValues_CountIsNotZero()
        {
            Array enumValues = Enum.GetValues(typeof(VertexAttribPointerType));
            Assert.NotEmpty(enumValues);
        }

        /// <summary>
        /// Tests that vertex attrib pointer type can cast to int conversion is valid
        /// </summary>
        [Fact]
        public void VertexAttribPointerType_CanCastToInt_ConversionIsValid()
        {
            int value = (int)VertexAttribPointerType.Float;
            Assert.IsType<int>(value);
        }

        /// <summary>
        /// Tests that vertex attrib pointer type can compare values equality works
        /// </summary>
        [Fact]
        public void VertexAttribPointerType_CanCompareValues_EqualityWorks()
        {
            VertexAttribPointerType type1 = VertexAttribPointerType.Float;
            VertexAttribPointerType type2 = VertexAttribPointerType.Float;
            Assert.Equal(type1, type2);
        }

        /// <summary>
        /// Tests that vertex attrib pointer type different values are not equal
        /// </summary>
        [Fact]
        public void VertexAttribPointerType_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(VertexAttribPointerType.Float, VertexAttribPointerType.Int);
        }
    }
}
