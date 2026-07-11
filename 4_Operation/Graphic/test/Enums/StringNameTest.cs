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
        /// <summary>
        /// Tests that vendor has correct value equals expected
        /// </summary>
        [Fact]
        public void Vendor_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1F00, (int)StringName.Vendor); }

        /// <summary>
        /// Tests that renderer has correct value equals expected
        /// </summary>
        [Fact]
        public void Renderer_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1F01, (int)StringName.Renderer); }

        /// <summary>
        /// Tests that version has correct value equals expected
        /// </summary>
        [Fact]
        public void Version_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1F02, (int)StringName.Version); }

        /// <summary>
        /// Tests that extensions has correct value equals expected
        /// </summary>
        [Fact]
        public void Extensions_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1F03, (int)StringName.Extensions); }

        /// <summary>
        /// Tests that shading language version has correct value equals expected
        /// </summary>
        [Fact]
        public void ShadingLanguageVersion_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B8C, (int)StringName.ShadingLanguageVersion); }

        /// <summary>
        /// Tests that string name is enum type is correct
        /// </summary>
        [Fact]
        public void StringName_IsEnum_TypeIsCorrect() { Assert.True(typeof(StringName).IsEnum); }

        /// <summary>
        /// Tests that string name is public can be accessed
        /// </summary>
        [Fact]
        public void StringName_IsPublic_CanBeAccessed() { Assert.True(typeof(StringName).IsPublic); }

        /// <summary>
        /// Tests that string name has five values count is correct
        /// </summary>
        [Fact]
        public void StringName_HasFiveValues_CountIsCorrect()
        {
            Array enumValues = Enum.GetValues(typeof(StringName));
            Assert.Equal(5, enumValues.Length);
        }

        /// <summary>
        /// Tests that string name can cast to int conversion is valid
        /// </summary>
        [Fact]
        public void StringName_CanCastToInt_ConversionIsValid()
        {
            int value = (int)StringName.Version;
            Assert.IsType<int>(value);
        }

        /// <summary>
        /// Tests that string name can compare values equality works
        /// </summary>
        [Fact]
        public void StringName_CanCompareValues_EqualityWorks()
        {
            StringName name1 = StringName.Version;
            StringName name2 = StringName.Version;
            Assert.Equal(name1, name2);
        }

        /// <summary>
        /// Tests that string name different values are not equal
        /// </summary>
        [Fact]
        public void StringName_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(StringName.Version, StringName.Vendor);
        }
    }
}
