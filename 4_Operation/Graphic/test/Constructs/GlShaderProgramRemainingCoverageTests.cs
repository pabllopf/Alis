// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlShaderProgramRemainingCoverageTests.cs
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
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    /// <summary>
    ///     The gl shader program remaining coverage tests class
    /// </summary>
    public class GlShaderProgramRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that two shader constructor throws when gl not initialized
        /// </summary>
        [Fact]
        public void TwoShaderConstructor_ThrowsWhenGlNotInitialized()
        {
            Gl.Initialize(null);

            Assert.Throws<InvalidOperationException>(() => new GlShaderProgram(CreateFakeShader(1u), CreateFakeShader(2u)));
        }

        /// <summary>
        ///     Tests that source constructor throws when gl not initialized
        /// </summary>
        [Fact]
        public void SourceConstructor_ThrowsWhenGlNotInitialized()
        {
            Gl.Initialize(null);

            Assert.Throws<InvalidOperationException>(() => new GlShaderProgram("void main() {}", "void main() {}"));
        }

        /// <summary>
        ///     Tests that indexer returns registered param
        /// </summary>
        [Fact]
        public void Indexer_ReturnsRegisteredParam()
        {
            GlShaderProgram program = CreateFakeProgram(1u);
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "uColor");
            Dictionary<string, GlShaderProgramParam> dict = new Dictionary<string, GlShaderProgramParam>();
            dict.Add("uColor", param);
            SetShaderParams(program, dict);

            Assert.Same(param, program["uColor"]);
        }

        /// <summary>
        ///     Tests that indexer returns null for unknown name
        /// </summary>
        [Fact]
        public void Indexer_ReturnsNullForUnknownName()
        {
            GlShaderProgram program = CreateFakeProgram(1u);
            Dictionary<string, GlShaderProgramParam> dict = new Dictionary<string, GlShaderProgramParam>();
            SetShaderParams(program, dict);

            Assert.Null(program["uUnknown"]);
        }

        /// <summary>
        ///     Tests that program log throws when gl not initialized
        /// </summary>
        [Fact]
        public void ProgramLog_ThrowsWhenGlNotInitialized()
        {
            Gl.Initialize(null);
            GlShaderProgram program = CreateFakeProgram(1u);

            Assert.Throws<InvalidOperationException>(() => program.ProgramLog);
        }

        /// <summary>
        ///     Tests that dispose with program id throws when gl not initialized
        /// </summary>
        [Fact]
        public void Dispose_WithProgramId_ThrowsWhenGlNotInitialized()
        {
            Gl.Initialize(null);
            GlShaderProgram program = CreateFakeProgram(1u);

            Assert.Throws<InvalidOperationException>(() => program.Dispose());
        }

        /// <summary>
        ///     Tests that dispose with zero program id does not throw
        /// </summary>
        [Fact]
        public void Dispose_WithZeroProgramId_DoesNotThrow()
        {
            Gl.Initialize(null);
            GlShaderProgram program = CreateFakeProgram(0u);

            program.Dispose();
        }

        /// <summary>
        ///     Tests that finalizer does not throw when gl not initialized
        /// </summary>
        [Fact]
        public void Finalizer_DoesNotThrowWhenGlNotInitialized()
        {
            Gl.Initialize(null);

            CreateFinalizableProgram();

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        /// <summary>
        ///     Tests that get params throws when gl not initialized
        /// </summary>
        [Fact]
        public void GetParams_ThrowsWhenGlNotInitialized()
        {
            Gl.Initialize(null);
            GlShaderProgram program = CreateFakeProgram(1u);

            Assert.Throws<InvalidOperationException>(() => program.GetParams());
        }

        /// <summary>
        ///     Tests that use throws when gl not initialized
        /// </summary>
        [Fact]
        public void Use_ThrowsWhenGlNotInitialized()
        {
            Gl.Initialize(null);
            GlShaderProgram program = CreateFakeProgram(1u);

            Assert.Throws<InvalidOperationException>(() => program.Use());
        }

        /// <summary>
        ///     Tests that get uniform location throws when gl not initialized
        /// </summary>
        [Fact]
        public void GetUniformLocation_ThrowsWhenGlNotInitialized()
        {
            Gl.Initialize(null);
            GlShaderProgram program = CreateFakeProgram(1u);

            Assert.Throws<InvalidOperationException>(() => program.GetUniformLocation("uColor"));
        }

        /// <summary>
        ///     Tests that get attribute location throws when gl not initialized
        /// </summary>
        [Fact]
        public void GetAttributeLocation_ThrowsWhenGlNotInitialized()
        {
            Gl.Initialize(null);
            GlShaderProgram program = CreateFakeProgram(1u);

            Assert.Throws<InvalidOperationException>(() => program.GetAttributeLocation("aPos"));
        }

        /// <summary>
        ///     Tests that type from attribute type unknown value returns object
        /// </summary>
        [Fact]
        public void TypeFromAttributeType_UnknownValue_ReturnsObject()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromAttributeType", BindingFlags.NonPublic | BindingFlags.Static);

            Assert.Equal(typeof(object), method.Invoke(null, new object[] { (ActiveAttribType)999 }));
        }

        /// <summary>
        ///     Tests that type from uniform type unknown value returns object
        /// </summary>
        [Fact]
        public void TypeFromUniformType_UnknownValue_ReturnsObject()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromUniformType", BindingFlags.NonPublic | BindingFlags.Static);

            Assert.Equal(typeof(object), method.Invoke(null, new object[] { (ActiveUniformType)999 }));
        }

        /// <summary>
        ///     Creates the fake shader using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The gl shader</returns>
        private static GlShader CreateFakeShader(uint id)
        {
            GlShader shader = (GlShader)RuntimeHelpers.GetUninitializedObject(typeof(GlShader));
            typeof(GlShader).GetProperty("ShaderId").GetSetMethod(true).Invoke(shader, new object[] { id });
            return shader;
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

        /// <summary>
        ///     Creates the finalizable program
        /// </summary>
        private static void CreateFinalizableProgram()
        {
            GlShaderProgram program = CreateFakeProgram(1u);
        }

        /// <summary>
        ///     Sets the shader params using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="dict">The dict</param>
        private static void SetShaderParams(GlShaderProgram program, Dictionary<string, GlShaderProgramParam> dict)
        {
            typeof(GlShaderProgram).GetField("shaderParams", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(program, dict);
        }
    }
}
