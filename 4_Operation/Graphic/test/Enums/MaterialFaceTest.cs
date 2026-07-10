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
        [Fact]
        public void Front_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0404, (int)MaterialFace.Front); }

        [Fact]
        public void Back_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0405, (int)MaterialFace.Back); }

        [Fact]
        public void FrontAndBack_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0408, (int)MaterialFace.FrontAndBack); }

        [Fact]
        public void MaterialFace_IsEnum_TypeIsCorrect() { Assert.True(typeof(MaterialFace).IsEnum); }

        [Fact]
        public void MaterialFace_IsPublic_CanBeAccessed() { Assert.True(typeof(MaterialFace).IsPublic); }

        [Fact]
        public void MaterialFace_HasThreeValues_CountIsCorrect()
        {
            Array enumValues = Enum.GetValues(typeof(MaterialFace));
            Assert.Equal(3, enumValues.Length);
        }

        [Fact]
        public void MaterialFace_CanCastToInt_ConversionIsValid()
        {
            int value = (int)MaterialFace.Front;
            Assert.IsType<int>(value);
        }

        [Fact]
        public void MaterialFace_CanCompareValues_EqualityWorks()
        {
            MaterialFace face1 = MaterialFace.Front;
            MaterialFace face2 = MaterialFace.Front;
            Assert.Equal(face1, face2);
        }

        [Fact]
        public void MaterialFace_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(MaterialFace.Front, MaterialFace.Back);
        }
    }
}
