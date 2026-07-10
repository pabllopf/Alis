// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BufferUsageHintTest.cs
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
    ///     Tests for the BufferUsageHint enum validating buffer usage hints.
    /// </summary>
    public class BufferUsageHintTest
    {
        [Fact]
        public void StreamDraw_HasCorrectValue_EqualsExpected() { Assert.Equal(0x88E0, (int)BufferUsageHint.StreamDraw); }

        [Fact]
        public void StreamRead_HasCorrectValue_EqualsExpected() { Assert.Equal(0x88E1, (int)BufferUsageHint.StreamRead); }

        [Fact]
        public void StreamCopy_HasCorrectValue_EqualsExpected() { Assert.Equal(0x88E2, (int)BufferUsageHint.StreamCopy); }

        [Fact]
        public void StaticDraw_HasCorrectValue_EqualsExpected() { Assert.Equal(0x88E4, (int)BufferUsageHint.StaticDraw); }

        [Fact]
        public void StaticRead_HasCorrectValue_EqualsExpected() { Assert.Equal(0x88E5, (int)BufferUsageHint.StaticRead); }

        [Fact]
        public void StaticCopy_HasCorrectValue_EqualsExpected() { Assert.Equal(0x88E6, (int)BufferUsageHint.StaticCopy); }

        [Fact]
        public void DynamicDraw_HasCorrectValue_EqualsExpected() { Assert.Equal(0x88E8, (int)BufferUsageHint.DynamicDraw); }

        [Fact]
        public void DynamicRead_HasCorrectValue_EqualsExpected() { Assert.Equal(0x88E9, (int)BufferUsageHint.DynamicRead); }

        [Fact]
        public void DynamicCopy_HasCorrectValue_EqualsExpected() { Assert.Equal(0x88EA, (int)BufferUsageHint.DynamicCopy); }

        [Fact]
        public void BufferUsageHint_IsEnum_TypeIsCorrect() { Assert.True(typeof(BufferUsageHint).IsEnum); }

        [Fact]
        public void BufferUsageHint_IsPublic_CanBeAccessed() { Assert.True(typeof(BufferUsageHint).IsPublic); }

        [Fact]
        public void BufferUsageHint_HasNineValues_CountIsCorrect()
        {
            Array enumValues = Enum.GetValues(typeof(BufferUsageHint));
            Assert.Equal(9, enumValues.Length);
        }

        [Fact]
        public void BufferUsageHint_CanCastToInt_ConversionIsValid()
        {
            int value = (int)BufferUsageHint.StaticDraw;
            Assert.IsType<int>(value);
        }

        [Fact]
        public void BufferUsageHint_CanCompareValues_EqualityWorks()
        {
            BufferUsageHint hint1 = BufferUsageHint.StaticDraw;
            BufferUsageHint hint2 = BufferUsageHint.StaticDraw;
            Assert.Equal(hint1, hint2);
        }

        [Fact]
        public void BufferUsageHint_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(BufferUsageHint.StaticDraw, BufferUsageHint.DynamicDraw);
        }
    }
}
