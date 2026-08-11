// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlShaderProgramParamFinalCoverageTests.cs
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
using System.Runtime.CompilerServices;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Constructs;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    /// <summary>
    ///     The gl shader program param final coverage tests class
    /// </summary>
    public class GlShaderProgramParamFinalCoverageTests
    {
        /// <summary>
        ///     Tests that get location throws when gl not initialized
        /// </summary>
        [Fact]
        public void GetLocation_ThrowsWhenGlNotInitialized()
        {
            Gl.Initialize(null);
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "uColor");
            GlShaderProgram program = CreateFakeProgram(1u);

            Assert.Throws<InvalidOperationException>(() => param.GetLocation(program));
        }

        /// <summary>
        ///     Tests that set value float array length nine throws when gl not initialized
        /// </summary>
        [Fact]
        public void SetValue_FloatArray_LengthNine_ThrowsWhenGlNotInitialized()
        {
            Gl.Initialize(null);
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(Exception), ParamType.Uniform, "m3");

            Assert.Throws<InvalidOperationException>(() => param.SetValue(new float[9]));
        }

        /// <summary>
        ///     Creates the fake program using the specified program id
        /// </summary>
        /// <param name="programId">The program id</param>
        /// <returns>The gl shader program</returns>
        private static GlShaderProgram CreateFakeProgram(uint programId)
        {
            GlShaderProgram program = (GlShaderProgram)RuntimeHelpers.GetUninitializedObject(typeof(GlShaderProgram));
            program.ProgramId = programId;
            return program;
        }
    }
}
