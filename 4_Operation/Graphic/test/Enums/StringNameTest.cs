// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StringNameTest.cs
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
    ///     Tests for the StringName enum validating OpenGL string names.
    /// </summary>
    public class StringNameTest
    {
        [Fact]
        public void Vendor_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1F00, (int)StringName.Vendor); }

        [Fact]
        public void Renderer_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1F01, (int)StringName.Renderer); }

        [Fact]
        public void Version_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1F02, (int)StringName.Version); }

        [Fact]
        public void Extensions_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1F03, (int)StringName.Extensions); }

        [Fact]
        public void ShadingLanguageVersion_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B8C, (int)StringName.ShadingLanguageVersion); }

        [Fact]
        public void StringName_IsEnum_TypeIsCorrect() { Assert.True(typeof(StringName).IsEnum); }

        [Fact]
        public void StringName_IsPublic_CanBeAccessed() { Assert.True(typeof(StringName).IsPublic); }

        [Fact]
        public void StringName_HasFiveValues_CountIsCorrect()
        {
            Array enumValues = Enum.GetValues(typeof(StringName));
            Assert.Equal(5, enumValues.Length);
        }

        [Fact]
        public void StringName_CanCastToInt_ConversionIsValid()
        {
            int value = (int)StringName.Version;
            Assert.IsType<int>(value);
        }

        [Fact]
        public void StringName_CanCompareValues_EqualityWorks()
        {
            StringName name1 = StringName.Version;
            StringName name2 = StringName.Version;
            Assert.Equal(name1, name2);
        }

        [Fact]
        public void StringName_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(StringName.Version, StringName.Vendor);
        }
    }
}
