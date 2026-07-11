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
        /// <summary>
        /// Tests that func add has correct value equals expected
        /// </summary>
        [Fact]
        public void FuncAdd_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8006, (int)BlendEquationMode.FuncAdd); }

        /// <summary>
        /// Tests that min has correct value equals expected
        /// </summary>
        [Fact]
        public void Min_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8007, (int)BlendEquationMode.Min); }

        /// <summary>
        /// Tests that max has correct value equals expected
        /// </summary>
        [Fact]
        public void Max_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8008, (int)BlendEquationMode.Max); }

        /// <summary>
        /// Tests that func subtract has correct value equals expected
        /// </summary>
        [Fact]
        public void FuncSubtract_HasCorrectValue_EqualsExpected() { Assert.Equal(0x800A, (int)BlendEquationMode.FuncSubtract); }

        /// <summary>
        /// Tests that func reverse subtract has correct value equals expected
        /// </summary>
        [Fact]
        public void FuncReverseSubtract_HasCorrectValue_EqualsExpected() { Assert.Equal(0x800B, (int)BlendEquationMode.FuncReverseSubtract); }

        /// <summary>
        /// Tests that blend equation mode is enum type is correct
        /// </summary>
        [Fact]
        public void BlendEquationMode_IsEnum_TypeIsCorrect() { Assert.True(typeof(BlendEquationMode).IsEnum); }

        /// <summary>
        /// Tests that blend equation mode is public can be accessed
        /// </summary>
        [Fact]
        public void BlendEquationMode_IsPublic_CanBeAccessed() { Assert.True(typeof(BlendEquationMode).IsPublic); }

        /// <summary>
        /// Tests that blend equation mode has five values count is correct
        /// </summary>
        [Fact]
        public void BlendEquationMode_HasFiveValues_CountIsCorrect()
        {
            Array enumValues = Enum.GetValues(typeof(BlendEquationMode));
            Assert.Equal(5, enumValues.Length);
        }

        /// <summary>
        /// Tests that blend equation mode can cast to int conversion is valid
        /// </summary>
        [Fact]
        public void BlendEquationMode_CanCastToInt_ConversionIsValid()
        {
            int value = (int)BlendEquationMode.FuncAdd;
            Assert.IsType<int>(value);
        }

        /// <summary>
        /// Tests that blend equation mode can compare values equality works
        /// </summary>
        [Fact]
        public void BlendEquationMode_CanCompareValues_EqualityWorks()
        {
            BlendEquationMode mode1 = BlendEquationMode.FuncAdd;
            BlendEquationMode mode2 = BlendEquationMode.FuncAdd;
            Assert.Equal(mode1, mode2);
        }

        /// <summary>
        /// Tests that blend equation mode different values are not equal
        /// </summary>
        [Fact]
        public void BlendEquationMode_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(BlendEquationMode.FuncAdd, BlendEquationMode.FuncSubtract);
        }
    }
}
