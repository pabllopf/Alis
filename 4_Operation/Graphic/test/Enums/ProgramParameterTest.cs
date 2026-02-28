// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProgramParameterTest.cs
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
using Xunit;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.Test.Enums
{
    /// <summary>
    /// Tests for the ProgramParameter enum validating shader program query parameters.
    /// </summary>
    public class ProgramParameterTest
    {
        /// <summary>
        /// Tests that DeleteStatus has correct value.
        /// </summary>
        [Fact]
        public void DeleteStatus_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8B80, (int)ProgramParameter.DeleteStatus);
        }

        /// <summary>
        /// Tests that LinkStatus has correct value.
        /// </summary>
        [Fact]
        public void LinkStatus_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8B82, (int)ProgramParameter.LinkStatus);
        }

        /// <summary>
        /// Tests that ValidateStatus has correct value.
        /// </summary>
        [Fact]
        public void ValidateStatus_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8B83, (int)ProgramParameter.ValidateStatus);
        }

        /// <summary>
        /// Tests that InfoLogLength has correct value.
        /// </summary>
        [Fact]
        public void InfoLogLength_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8B84, (int)ProgramParameter.InfoLogLength);
        }

        /// <summary>
        /// Tests that AttachedShaders has correct value.
        /// </summary>
        [Fact]
        public void AttachedShaders_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8B85, (int)ProgramParameter.AttachedShaders);
        }

        /// <summary>
        /// Tests that ActiveUniforms has correct value.
        /// </summary>
        [Fact]
        public void ActiveUniforms_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8B86, (int)ProgramParameter.ActiveUniforms);
        }

        /// <summary>
        /// Tests that ActiveUniformMaxLength has correct value.
        /// </summary>
        [Fact]
        public void ActiveUniformMaxLength_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8B87, (int)ProgramParameter.ActiveUniformMaxLength);
        }

        /// <summary>
        /// Tests that ActiveAttributes has correct value.
        /// </summary>
        [Fact]
        public void ActiveAttributes_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8B89, (int)ProgramParameter.ActiveAttributes);
        }

        /// <summary>
        /// Tests that ActiveAttributeMaxLength has correct value.
        /// </summary>
        [Fact]
        public void ActiveAttributeMaxLength_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8B8A, (int)ProgramParameter.ActiveAttributeMaxLength);
        }

        /// <summary>
        /// Tests that ProgramParameter is an enum type.
        /// </summary>
        [Fact]
        public void ProgramParameter_IsEnum_TypeIsCorrect()
        {
            Assert.True(typeof(ProgramParameter).IsEnum);
        }

        /// <summary>
        /// Tests that ProgramParameter enum is public.
        /// </summary>
        [Fact]
        public void ProgramParameter_IsPublic_CanBeAccessed()
        {
            Assert.True(typeof(ProgramParameter).IsPublic);
        }

        /// <summary>
        /// Tests that ProgramParameter has multiple defined values.
        /// </summary>
        [Fact]
        public void ProgramParameter_HasMultipleValues_CountIsNotZero()
        {
            Array enumValues = System.Enum.GetValues(typeof(ProgramParameter));
            Assert.NotEmpty(enumValues);
        }

        /// <summary>
        /// Tests that ProgramParameter can be cast to int.
        /// </summary>
        [Fact]
        public void ProgramParameter_CanCastToInt_ConversionIsValid()
        {
            int value = (int)ProgramParameter.LinkStatus;
            Assert.IsType<int>(value);
        }

        /// <summary>
        /// Tests that ProgramParameter values can be compared.
        /// </summary>
        [Fact]
        public void ProgramParameter_CanCompareValues_EqualityWorks()
        {
            ProgramParameter param1 = ProgramParameter.LinkStatus;
            ProgramParameter param2 = ProgramParameter.LinkStatus;
            Assert.Equal(param1, param2);
        }

        /// <summary>
        /// Tests that different ProgramParameter values are not equal.
        /// </summary>
        [Fact]
        public void ProgramParameter_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(ProgramParameter.LinkStatus, ProgramParameter.ValidateStatus);
        }

        /// <summary>
        /// Tests that ProgramParameter contains common query parameters.
        /// </summary>
        [Fact]
        public void ProgramParameter_ContainsCommonParameters_AllPresent()
        {
            ProgramParameter linkStatus = ProgramParameter.LinkStatus;
            ProgramParameter infoLogLength = ProgramParameter.InfoLogLength;
            ProgramParameter activeUniforms = ProgramParameter.ActiveUniforms;

            Assert.NotNull(linkStatus);
            Assert.NotNull(infoLogLength);
            Assert.NotNull(activeUniforms);
        }
    }
}

