// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MaterialFaceTest.cs
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
    ///     Tests for the MaterialFace enum validating material face types.
    /// </summary>
    public class MaterialFaceTest
    {
        /// <summary>
        /// Tests that front has correct value equals expected
        /// </summary>
        [Fact]
        public void Front_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0404, (int)MaterialFace.Front); }

        /// <summary>
        /// Tests that back has correct value equals expected
        /// </summary>
        [Fact]
        public void Back_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0405, (int)MaterialFace.Back); }

        /// <summary>
        /// Tests that front and back has correct value equals expected
        /// </summary>
        [Fact]
        public void FrontAndBack_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0408, (int)MaterialFace.FrontAndBack); }

        /// <summary>
        /// Tests that material face is enum type is correct
        /// </summary>
        [Fact]
        public void MaterialFace_IsEnum_TypeIsCorrect() { Assert.True(typeof(MaterialFace).IsEnum); }

        /// <summary>
        /// Tests that material face is public can be accessed
        /// </summary>
        [Fact]
        public void MaterialFace_IsPublic_CanBeAccessed() { Assert.True(typeof(MaterialFace).IsPublic); }

        /// <summary>
        /// Tests that material face has three values count is correct
        /// </summary>
        [Fact]
        public void MaterialFace_HasThreeValues_CountIsCorrect()
        {
            Array enumValues = Enum.GetValues(typeof(MaterialFace));
            Assert.Equal(3, enumValues.Length);
        }

        /// <summary>
        /// Tests that material face can cast to int conversion is valid
        /// </summary>
        [Fact]
        public void MaterialFace_CanCastToInt_ConversionIsValid()
        {
            int value = (int)MaterialFace.Front;
            Assert.IsType<int>(value);
        }

        /// <summary>
        /// Tests that material face can compare values equality works
        /// </summary>
        [Fact]
        public void MaterialFace_CanCompareValues_EqualityWorks()
        {
            MaterialFace face1 = MaterialFace.Front;
            MaterialFace face2 = MaterialFace.Front;
            Assert.Equal(face1, face2);
        }

        /// <summary>
        /// Tests that material face different values are not equal
        /// </summary>
        [Fact]
        public void MaterialFace_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(MaterialFace.Front, MaterialFace.Back);
        }
    }
}
