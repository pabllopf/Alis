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
        /// <summary>
        /// Tests that shader type has correct value equals expected
        /// </summary>
        [Fact]
        public void ShaderType_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B4F, (int)ShaderParameter.ShaderType); }

        /// <summary>
        /// Tests that delete status has correct value equals expected
        /// </summary>
        [Fact]
        public void DeleteStatus_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B80, (int)ShaderParameter.DeleteStatus); }

        /// <summary>
        /// Tests that compile status has correct value equals expected
        /// </summary>
        [Fact]
        public void CompileStatus_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B81, (int)ShaderParameter.CompileStatus); }

        /// <summary>
        /// Tests that info log length has correct value equals expected
        /// </summary>
        [Fact]
        public void InfoLogLength_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B84, (int)ShaderParameter.InfoLogLength); }

        /// <summary>
        /// Tests that shader source length has correct value equals expected
        /// </summary>
        [Fact]
        public void ShaderSourceLength_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B88, (int)ShaderParameter.ShaderSourceLength); }

        /// <summary>
        /// Tests that shader parameter is enum type is correct
        /// </summary>
        [Fact]
        public void ShaderParameter_IsEnum_TypeIsCorrect() { Assert.True(typeof(ShaderParameter).IsEnum); }

        /// <summary>
        /// Tests that shader parameter is public can be accessed
        /// </summary>
        [Fact]
        public void ShaderParameter_IsPublic_CanBeAccessed() { Assert.True(typeof(ShaderParameter).IsPublic); }

        /// <summary>
        /// Tests that shader parameter has five values count is correct
        /// </summary>
        [Fact]
        public void ShaderParameter_HasFiveValues_CountIsCorrect()
        {
            Array enumValues = Enum.GetValues(typeof(ShaderParameter));
            Assert.Equal(5, enumValues.Length);
        }

        /// <summary>
        /// Tests that shader parameter can cast to int conversion is valid
        /// </summary>
        [Fact]
        public void ShaderParameter_CanCastToInt_ConversionIsValid()
        {
            int value = (int)ShaderParameter.ShaderType;
            Assert.IsType<int>(value);
        }

        /// <summary>
        /// Tests that shader parameter can compare values equality works
        /// </summary>
        [Fact]
        public void ShaderParameter_CanCompareValues_EqualityWorks()
        {
            ShaderParameter param1 = ShaderParameter.ShaderType;
            ShaderParameter param2 = ShaderParameter.ShaderType;
            Assert.Equal(param1, param2);
        }

        /// <summary>
        /// Tests that shader parameter different values are not equal
        /// </summary>
        [Fact]
        public void ShaderParameter_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(ShaderParameter.ShaderType, ShaderParameter.CompileStatus);
        }
    }
}
