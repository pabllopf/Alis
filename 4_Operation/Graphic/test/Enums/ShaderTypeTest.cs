// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ShaderTypeTest.cs
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

using Xunit;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.Test.Enums
{
    /// <summary>
    /// Tests for the ShaderType enum validating all shader type definitions.
    /// </summary>
    public class ShaderTypeTest
    {
        /// <summary>
        /// Tests that FragmentShader has correct value.
        /// </summary>
        [Fact]
        public void FragmentShader_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8B30, (int)ShaderType.FragmentShader);
        }

        /// <summary>
        /// Tests that VertexShader has correct value.
        /// </summary>
        [Fact]
        public void VertexShader_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8B31, (int)ShaderType.VertexShader);
        }

        /// <summary>
        /// Tests that GeometryShader has correct value.
        /// </summary>
        [Fact]
        public void GeometryShader_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8DD9, (int)ShaderType.GeometryShader);
        }

        /// <summary>
        /// Tests that TessControlShader has correct value.
        /// </summary>
        [Fact]
        public void TessControlShader_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8E88, (int)ShaderType.TessControlShader);
        }

        /// <summary>
        /// Tests that TessEvaluationShader has correct value.
        /// </summary>
        [Fact]
        public void TessEvaluationShader_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x8E87, (int)ShaderType.TessEvaluationShader);
        }

        /// <summary>
        /// Tests that ComputeShader has correct value.
        /// </summary>
        [Fact]
        public void ComputeShader_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x91B9, (int)ShaderType.ComputeShader);
        }

        /// <summary>
        /// Tests that ShaderType is an enum type.
        /// </summary>
        [Fact]
        public void ShaderType_IsEnum_TypeIsCorrect()
        {
            Assert.True(typeof(ShaderType).IsEnum);
        }

        /// <summary>
        /// Tests that ShaderType enum is public.
        /// </summary>
        [Fact]
        public void ShaderType_IsPublic_CanBeAccessed()
        {
            Assert.True(typeof(ShaderType).IsPublic);
        }

        /// <summary>
        /// Tests that ShaderType has six defined values.
        /// </summary>
        [Fact]
        public void ShaderType_HasSixValues_CountIsCorrect()
        {
            var enumValues = System.Enum.GetValues(typeof(ShaderType));
            Assert.Equal(6, enumValues.Length);
        }

        /// <summary>
        /// Tests that all ShaderType values are unique.
        /// </summary>
        [Fact]
        public void AllValues_AreUnique_NoConflicts()
        {
            var values = new[]
            {
                (int)ShaderType.FragmentShader,
                (int)ShaderType.VertexShader,
                (int)ShaderType.GeometryShader,
                (int)ShaderType.TessControlShader,
                (int)ShaderType.TessEvaluationShader,
                (int)ShaderType.ComputeShader
            };

            var uniqueCount = new System.Collections.Generic.HashSet<int>(values).Count;
            Assert.Equal(values.Length, uniqueCount);
        }

        /// <summary>
        /// Tests that ShaderType can be cast to int.
        /// </summary>
        [Fact]
        public void ShaderType_CanCastToInt_ConversionIsValid()
        {
            int value = (int)ShaderType.VertexShader;
            Assert.IsType<int>(value);
        }

        /// <summary>
        /// Tests that ShaderType values can be compared.
        /// </summary>
        [Fact]
        public void ShaderType_CanCompareValues_EqualityWorks()
        {
            var type1 = ShaderType.VertexShader;
            var type2 = ShaderType.VertexShader;
            Assert.Equal(type1, type2);
        }

        /// <summary>
        /// Tests that different ShaderType values are not equal.
        /// </summary>
        [Fact]
        public void ShaderType_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(ShaderType.VertexShader, ShaderType.FragmentShader);
        }

        /// <summary>
        /// Tests that VertexShader and FragmentShader are consecutive values.
        /// </summary>
        [Fact]
        public void VertexShader_AndFragmentShader_AreSequential()
        {
            int fragmentValue = (int)ShaderType.FragmentShader;
            int vertexValue = (int)ShaderType.VertexShader;
            Assert.Equal(vertexValue, fragmentValue + 1);
        }
    }
}

