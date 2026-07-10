// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolygonModeEnumTest.cs
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
    ///     Tests for the PolygonModeEnum enum validating polygon rasterization modes.
    /// </summary>
    public class PolygonModeEnumTest
    {
        [Fact]
        public void Point_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1B00, (int)PolygonModeEnum.Point); }

        [Fact]
        public void Line_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1B01, (int)PolygonModeEnum.Line); }

        [Fact]
        public void Fill_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1B02, (int)PolygonModeEnum.Fill); }

        [Fact]
        public void PolygonModeEnum_IsEnum_TypeIsCorrect() { Assert.True(typeof(PolygonModeEnum).IsEnum); }

        [Fact]
        public void PolygonModeEnum_IsPublic_CanBeAccessed() { Assert.True(typeof(PolygonModeEnum).IsPublic); }

        [Fact]
        public void PolygonModeEnum_HasThreeValues_CountIsCorrect()
        {
            Array enumValues = Enum.GetValues(typeof(PolygonModeEnum));
            Assert.Equal(3, enumValues.Length);
        }

        [Fact]
        public void PolygonModeEnum_CanCastToInt_ConversionIsValid()
        {
            int value = (int)PolygonModeEnum.Fill;
            Assert.IsType<int>(value);
        }

        [Fact]
        public void PolygonModeEnum_CanCompareValues_EqualityWorks()
        {
            PolygonModeEnum mode1 = PolygonModeEnum.Fill;
            PolygonModeEnum mode2 = PolygonModeEnum.Fill;
            Assert.Equal(mode1, mode2);
        }

        [Fact]
        public void PolygonModeEnum_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(PolygonModeEnum.Point, PolygonModeEnum.Fill);
        }
    }
}
