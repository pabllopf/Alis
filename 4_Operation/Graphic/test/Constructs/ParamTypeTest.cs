// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ParamTypeTest.cs
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
using Alis.Core.Graphic.OpenGL.Constructs;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    /// <summary>
    ///     Tests for the ParamType enum validating shader parameter classification.
    /// </summary>
    public class ParamTypeTest
    {
        /// <summary>
        ///     Tests that Uniform value is defined.
        /// </summary>
        [Fact]
        public void Uniform_IsValid_ValueExists()
        {
            ParamType uniformValue = ParamType.Uniform;

            Assert.Equal(ParamType.Uniform, uniformValue);
        }

        /// <summary>
        ///     Tests that Attribute value is defined.
        /// </summary>
        [Fact]
        public void Attribute_IsValid_ValueExists()
        {
            ParamType attributeValue = ParamType.Attribute;

            Assert.Equal(ParamType.Attribute, attributeValue);
        }

        /// <summary>
        ///     Tests that ParamType is an enum type.
        /// </summary>
        [Fact]
        public void ParamType_IsEnum_TypeIsCorrect()
        {
            Type enumType = typeof(ParamType);

            Assert.True(enumType.IsEnum);
        }

        /// <summary>
        ///     Tests that ParamType enum is public.
        /// </summary>
        [Fact]
        public void ParamType_IsPublic_CanBeAccessed()
        {
            Type enumType = typeof(ParamType);

            Assert.True(enumType.IsPublic);
        }

        /// <summary>
        ///     Tests that ParamType has exactly two defined values.
        /// </summary>
        [Fact]
        public void ParamType_HasTwoValues_CountIsCorrect()
        {
            Array enumValues = Enum.GetValues(typeof(ParamType));

            Assert.Equal(2, enumValues.Length);
        }

        /// <summary>
        ///     Tests that ParamType Uniform and Attribute are unique.
        /// </summary>
        [Fact]
        public void ParamType_ValuesAreUnique_NoConflicts()
        {
            int uniformValue = (int) ParamType.Uniform;
            int attributeValue = (int) ParamType.Attribute;

            Assert.NotEqual(uniformValue, attributeValue);
        }

        /// <summary>
        ///     Tests that ParamType values can be compared.
        /// </summary>
        [Fact]
        public void ParamType_CanCompareValues_EqualityWorks()
        {
            ParamType uniform1 = ParamType.Uniform;
            ParamType uniform2 = ParamType.Uniform;

            Assert.Equal(uniform1, uniform2);
        }

        /// <summary>
        ///     Tests that different ParamType values are not equal.
        /// </summary>
        [Fact]
        public void ParamType_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(ParamType.Uniform, ParamType.Attribute);
        }

        /// <summary>
        ///     Tests that ParamType can be cast to int.
        /// </summary>
        [Fact]
        public void ParamType_CanCastToInt_ConversionIsValid()
        {
            int uniformValue = (int) ParamType.Uniform;
            int attributeValue = (int) ParamType.Attribute;

            Assert.IsType<int>(uniformValue);
            Assert.IsType<int>(attributeValue);
        }

        /// <summary>
        ///     Tests that ParamType Uniform value is first.
        /// </summary>
        [Fact]
        public void ParamType_Uniform_HasZeroValue()
        {
            int uniformValue = (int) ParamType.Uniform;

            Assert.Equal(0, uniformValue);
        }

        /// <summary>
        ///     Tests that ParamType Attribute value is second.
        /// </summary>
        [Fact]
        public void ParamType_Attribute_HasOneValue()
        {
            int attributeValue = (int) ParamType.Attribute;

            Assert.Equal(1, attributeValue);
        }

        /// <summary>
        ///     Tests that ParamType enum names are correct.
        /// </summary>
        [Fact]
        public void ParamType_Names_AreCorrect()
        {
            string uniformName = Enum.GetName(typeof(ParamType), ParamType.Uniform);
            string attributeName = Enum.GetName(typeof(ParamType), ParamType.Attribute);

            Assert.Equal("Uniform", uniformName);
            Assert.Equal("Attribute", attributeName);
        }
    }
}