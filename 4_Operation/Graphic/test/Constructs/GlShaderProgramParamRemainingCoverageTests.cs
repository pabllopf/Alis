// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlShaderProgramParamRemainingCoverageTests.cs
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
    /// The gl shader program param remaining coverage tests class
    /// </summary>
    public class GlShaderProgramParamRemainingCoverageTests
    {
        /// <summary>
        /// Tests that constructor 3 params sets fields correctly
        /// </summary>
        [Fact]
        public void Constructor_3Params_SetsFieldsCorrectly()
        {
            var param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "testName");

            Assert.Equal(typeof(int), param.Type);
            Assert.Equal(ParamType.Uniform, param.ParamType);
            Assert.Equal("testName", param.Name);
        }

        /// <summary>
        /// Tests that constructor 5 params sets fields correctly
        /// </summary>
        [Fact]
        public void Constructor_5Params_SetsFieldsCorrectly()
        {
            var param = new GlShaderProgramParam(typeof(float), ParamType.Attribute, "attrName", 42u, 7);

            Assert.Equal(typeof(float), param.Type);
            Assert.Equal(ParamType.Attribute, param.ParamType);
            Assert.Equal("attrName", param.Name);
            Assert.Equal(7, param.Location);
        }

        /// <summary>
        /// Tests that constructor 5 params program id defaults to zero
        /// </summary>
        [Fact]
        public void Constructor_5Params_ProgramId_DefaultsToZero()
        {
            var param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "p", 99u, -1);

            Assert.Equal(0u, param.Program);
            Assert.Equal(0u, param.ProgramId);
        }

        /// <summary>
        /// Tests that location get set works
        /// </summary>
        [Fact]
        public void Location_GetSet_Works()
        {
            var param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "n");
            param.Location = 42;
            Assert.Equal(42, param.Location);
            param.Location = -5;
            Assert.Equal(-5, param.Location);
        }

        /// <summary>
        /// Tests that program get set works
        /// </summary>
        [Fact]
        public void Program_GetSet_Works()
        {
            var param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "n");
            param.Program = 123u;
            Assert.Equal(123u, param.Program);
        }

        /// <summary>
        /// Tests that program id get set works
        /// </summary>
        [Fact]
        public void ProgramId_GetSet_Works()
        {
            var param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "n");
            param.ProgramId = 456u;
            Assert.Equal(456u, param.ProgramId);
        }

        /// <summary>
        /// Tests that set value float array invalid length throws argument exception
        /// </summary>
        /// <param name="length">The length</param>
        [Theory]
        [InlineData(0)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        [InlineData(14)]
        [InlineData(15)]
        [InlineData(17)]
        [InlineData(100)]
        public void SetValue_FloatArray_InvalidLength_ThrowsArgumentException(int length)
        {
            var param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "x");
            var array = new float[length];

            var ex = Assert.Throws<ArgumentException>(() => param.SetValue(array));
            Assert.Equal("param", ex.ParamName);
        }

        /// <summary>
        /// Tests that set value float array length zero throws argument exception
        /// </summary>
        [Fact]
        public void SetValue_FloatArray_LengthZero_ThrowsArgumentException()
        {
            var param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "x");
            var array = Array.Empty<float>();

            var ex = Assert.Throws<ArgumentException>(() => param.SetValue(array));
            Assert.Equal("param", ex.ParamName);
        }
    }
}
