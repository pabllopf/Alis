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
        [Fact]
        public void Byte_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1400, (int)VertexAttribPointerType.Byte); }

        [Fact]
        public void UnsignedByte_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1401, (int)VertexAttribPointerType.UnsignedByte); }

        [Fact]
        public void Short_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1402, (int)VertexAttribPointerType.Short); }

        [Fact]
        public void UnsignedShort_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1403, (int)VertexAttribPointerType.UnsignedShort); }

        [Fact]
        public void Int_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1404, (int)VertexAttribPointerType.Int); }

        [Fact]
        public void UnsignedInt_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1405, (int)VertexAttribPointerType.UnsignedInt); }

        [Fact]
        public void Float_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1406, (int)VertexAttribPointerType.Float); }

        [Fact]
        public void Double_HasCorrectValue_EqualsExpected() { Assert.Equal(0x140A, (int)VertexAttribPointerType.Double); }

        [Fact]
        public void HalfFloat_HasCorrectValue_EqualsExpected() { Assert.Equal(0x140B, (int)VertexAttribPointerType.HalfFloat); }

        [Fact]
        public void UnsignedUInt2101010Reversed_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8368, (int)VertexAttribPointerType.UnsignedUInt2101010Reversed); }

        [Fact]
        public void UnsignedInt2101010Reversed_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D9F, (int)VertexAttribPointerType.UnsignedInt2101010Reversed); }

        [Fact]
        public void UnsignedUInt101111Reversed_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C3B, (int)VertexAttribPointerType.UnsignedUInt101111Reversed); }

        [Fact]
        public void VertexAttribPointerType_IsEnum_TypeIsCorrect() { Assert.True(typeof(VertexAttribPointerType).IsEnum); }

        [Fact]
        public void VertexAttribPointerType_IsPublic_CanBeAccessed() { Assert.True(typeof(VertexAttribPointerType).IsPublic); }

        [Fact]
        public void VertexAttribPointerType_HasMultipleValues_CountIsNotZero()
        {
            Array enumValues = Enum.GetValues(typeof(VertexAttribPointerType));
            Assert.NotEmpty(enumValues);
        }

        [Fact]
        public void VertexAttribPointerType_CanCastToInt_ConversionIsValid()
        {
            int value = (int)VertexAttribPointerType.Float;
            Assert.IsType<int>(value);
        }

        [Fact]
        public void VertexAttribPointerType_CanCompareValues_EqualityWorks()
        {
            VertexAttribPointerType type1 = VertexAttribPointerType.Float;
            VertexAttribPointerType type2 = VertexAttribPointerType.Float;
            Assert.Equal(type1, type2);
        }

        [Fact]
        public void VertexAttribPointerType_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(VertexAttribPointerType.Float, VertexAttribPointerType.Int);
        }
    }
}
