// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BlendEquationModeTest.cs
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
    ///     Tests for the BlendEquationMode enum validating blend equation modes.
    /// </summary>
    public class BlendEquationModeTest
    {
        [Fact]
        public void FuncAdd_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8006, (int)BlendEquationMode.FuncAdd); }

        [Fact]
        public void Min_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8007, (int)BlendEquationMode.Min); }

        [Fact]
        public void Max_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8008, (int)BlendEquationMode.Max); }

        [Fact]
        public void FuncSubtract_HasCorrectValue_EqualsExpected() { Assert.Equal(0x800A, (int)BlendEquationMode.FuncSubtract); }

        [Fact]
        public void FuncReverseSubtract_HasCorrectValue_EqualsExpected() { Assert.Equal(0x800B, (int)BlendEquationMode.FuncReverseSubtract); }

        [Fact]
        public void BlendEquationMode_IsEnum_TypeIsCorrect() { Assert.True(typeof(BlendEquationMode).IsEnum); }

        [Fact]
        public void BlendEquationMode_IsPublic_CanBeAccessed() { Assert.True(typeof(BlendEquationMode).IsPublic); }

        [Fact]
        public void BlendEquationMode_HasFiveValues_CountIsCorrect()
        {
            Array enumValues = Enum.GetValues(typeof(BlendEquationMode));
            Assert.Equal(5, enumValues.Length);
        }

        [Fact]
        public void BlendEquationMode_CanCastToInt_ConversionIsValid()
        {
            int value = (int)BlendEquationMode.FuncAdd;
            Assert.IsType<int>(value);
        }

        [Fact]
        public void BlendEquationMode_CanCompareValues_EqualityWorks()
        {
            BlendEquationMode mode1 = BlendEquationMode.FuncAdd;
            BlendEquationMode mode2 = BlendEquationMode.FuncAdd;
            Assert.Equal(mode1, mode2);
        }

        [Fact]
        public void BlendEquationMode_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(BlendEquationMode.FuncAdd, BlendEquationMode.FuncSubtract);
        }
    }
}
