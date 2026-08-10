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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.OpenGL.Constructs;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    /// <summary>
    ///     The gl shader program param remaining coverage tests class
    /// </summary>
    public class GlShaderProgramParamRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that constructor assigns fields
        /// </summary>
        [Fact]
        public void Constructor_AssignsFields()
        {
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "uColor");

            Assert.Equal("uColor", param.Name);
            Assert.Equal(ParamType.Uniform, param.ParamType);
            Assert.Equal(typeof(float), param.Type);
        }

        /// <summary>
        ///     Tests that full constructor assigns program and location
        /// </summary>
        [Fact]
        public void FullConstructor_AssignsProgramAndLocation()
        {
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(float), ParamType.Attribute, "aPos", 42, 7);

            Assert.Equal("aPos", param.Name);
            Assert.Equal(ParamType.Attribute, param.ParamType);
            Assert.Equal(typeof(float), param.Type);
        }

        /// <summary>
        ///     Tests that properties round trip
        /// </summary>
        [Fact]
        public void Properties_RoundTrip()
        {
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "uValue");

            param.Location = 5;
            param.Program = 9;
            param.ProgramId = 11;

            Assert.Equal(5, param.Location);
            Assert.Equal(9u, param.Program);
            Assert.Equal(11u, param.ProgramId);
        }

        /// <summary>
        ///     Tests that ensure type with matching type passes
        /// </summary>
        [Fact]
        public void EnsureType_WithMatchingType_Passes()
        {
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "uColor");

            param.EnsureType<float>();
        }
    }
}
