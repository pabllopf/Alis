// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ShaderParameterTest.cs
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
    ///     Tests for the ShaderParameter enum validating shader query parameters.
    /// </summary>
    public class ShaderParameterTest
    {
        [Fact]
        public void ShaderType_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B4F, (int)ShaderParameter.ShaderType); }

        [Fact]
        public void DeleteStatus_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B80, (int)ShaderParameter.DeleteStatus); }

        [Fact]
        public void CompileStatus_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B81, (int)ShaderParameter.CompileStatus); }

        [Fact]
        public void InfoLogLength_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B84, (int)ShaderParameter.InfoLogLength); }

        [Fact]
        public void ShaderSourceLength_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B88, (int)ShaderParameter.ShaderSourceLength); }

        [Fact]
        public void ShaderParameter_IsEnum_TypeIsCorrect() { Assert.True(typeof(ShaderParameter).IsEnum); }

        [Fact]
        public void ShaderParameter_IsPublic_CanBeAccessed() { Assert.True(typeof(ShaderParameter).IsPublic); }

        [Fact]
        public void ShaderParameter_HasFiveValues_CountIsCorrect()
        {
            Array enumValues = Enum.GetValues(typeof(ShaderParameter));
            Assert.Equal(5, enumValues.Length);
        }

        [Fact]
        public void ShaderParameter_CanCastToInt_ConversionIsValid()
        {
            int value = (int)ShaderParameter.ShaderType;
            Assert.IsType<int>(value);
        }

        [Fact]
        public void ShaderParameter_CanCompareValues_EqualityWorks()
        {
            ShaderParameter param1 = ShaderParameter.ShaderType;
            ShaderParameter param2 = ShaderParameter.ShaderType;
            Assert.Equal(param1, param2);
        }

        [Fact]
        public void ShaderParameter_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(ShaderParameter.ShaderType, ShaderParameter.CompileStatus);
        }
    }
}
