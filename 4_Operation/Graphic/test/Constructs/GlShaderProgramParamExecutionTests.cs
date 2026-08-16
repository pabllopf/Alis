// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlShaderProgramParamExecutionTests.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Delegates;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    /// <summary>
    ///     Executes the native-backed <see cref="GlShaderProgramParam" /> members against fake
    ///     OpenGL function pointers installed via <see cref="Gl.Initialize" /> so that the
    ///     managed bodies of the wrappers are exercised for line coverage.
    /// </summary>
    public class GlShaderProgramParamExecutionTests
    {
        /// <summary>
        ///     Tests that get location resolves a uniform location when the program id is zero.
        /// </summary>
        [Fact]
        public void GetLocation_WithUniformAndZeroProgramId_ResolvesUniformLocation()
        {
            Gl.Initialize(FakeProcAddress);
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "uColor");
            GlShaderProgram program = CreateProgram(7u);

            param.GetLocation(program);

            Assert.Equal(7u, param.ProgramId);
            Assert.Equal(5, param.Location);
        }

        /// <summary>
        ///     Tests that get location resolves an attribute location when the program id is zero.
        /// </summary>
        [Fact]
        public void GetLocation_WithAttributeAndZeroProgramId_ResolvesAttributeLocation()
        {
            Gl.Initialize(FakeProcAddress);
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(float), ParamType.Attribute, "aPosition");
            GlShaderProgram program = CreateProgram(8u);

            param.GetLocation(program);

            Assert.Equal(8u, param.ProgramId);
            Assert.Equal(9, param.Location);
        }

        /// <summary>
        ///     Tests that get location skips resolution when the program id is already set.
        /// </summary>
        [Fact]
        public void GetLocation_WithExistingProgramId_DoesNotResolve()
        {
            Gl.Initialize(FakeProcAddress);
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "uColor", 7u, 3);
            param.ProgramId = 7u;

            param.GetLocation(CreateProgram(8u));

            Assert.Equal(7u, param.ProgramId);
            Assert.Equal(3, param.Location);
        }

        /// <summary>
        ///     Tests that the scalar and vector set value overloads execute.
        /// </summary>
        [Fact]
        public void SetValue_ScalarAndVectorOverloads_Execute()
        {
            Gl.Initialize(FakeProcAddress);
            GlShaderProgramParam boolParam = new GlShaderProgramParam(typeof(bool), ParamType.Uniform, "uBool", 1u, 2);

            boolParam.SetValue(true);
            boolParam.SetValue(false);

            GlShaderProgramParam intParam = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "uInt", 1u, 2);

            intParam.SetValue(7);

            GlShaderProgramParam floatParam = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "uFloat", 1u, 2);

            floatParam.SetValue(1.5f);

            GlShaderProgramParam vector2Param = new GlShaderProgramParam(typeof(Vector2F), ParamType.Uniform, "uVec2", 1u, 2);

            vector2Param.SetValue(new Vector2F(1.0f, 2.0f));

            GlShaderProgramParam vector3Param = new GlShaderProgramParam(typeof(Vector3F), ParamType.Uniform, "uVec3", 1u, 2);

            vector3Param.SetValue(new Vector3F(1.0f, 2.0f, 3.0f));

            GlShaderProgramParam vector4Param = new GlShaderProgramParam(typeof(Vector4F), ParamType.Uniform, "uVec4", 1u, 2);

            vector4Param.SetValue(new Vector4F(1.0f, 2.0f, 3.0f, 4.0f));
        }

        /// <summary>
        ///     Tests that the matrix set value overload executes.
        /// </summary>
        [Fact]
        public void SetValue_Matrix_Executes()
        {
            Gl.Initialize(FakeProcAddress);
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(Matrix4X4), ParamType.Uniform, "uMatrix", 1u, 2);

            param.SetValue(new Matrix4X4());
        }

        /// <summary>
        ///     Tests that every array length branch of set value executes.
        /// </summary>
        [Fact]
        public void SetValue_FloatArray_AllLengthBranches_Execute()
        {
            Gl.Initialize(FakeProcAddress);
            SetValueArray(16, typeof(Matrix4X4));
            SetValueArray(9, typeof(Exception));
            SetValueArray(4, typeof(Vector4F));
            SetValueArray(3, typeof(Vector3F));
            SetValueArray(2, typeof(Vector2F));
            SetValueArray(1, typeof(float));
        }

        /// <summary>
        ///     Tests that set value with an unexpected array length throws argument exception.
        /// </summary>
        [Fact]
        public void SetValue_FloatArray_WithUnexpectedLength_ThrowsArgumentException()
        {
            Gl.Initialize(FakeProcAddress);
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "uValue", 1u, 2);

            Assert.Throws<ArgumentException>(() => param.SetValue(new float[5]));
            Assert.Throws<ArgumentException>(() => param.SetValue(new float[0]));
        }

        /// <summary>
        ///     Sets the value array with the specified length and type
        /// </summary>
        /// <param name="length">The length</param>
        /// <param name="type">The type</param>
        private static void SetValueArray(int length, Type type)
        {
            GlShaderProgramParam param = new GlShaderProgramParam(type, ParamType.Uniform, "uArray", 1u, 2);
            param.SetValue(new float[length]);
        }

        /// <summary>
        ///     Creates a shader program with the specified program id without invoking the
        ///     shader-compiling constructor
        /// </summary>
        /// <param name="programId">The program id</param>
        /// <returns>The gl shader program</returns>
        private static GlShaderProgram CreateProgram(uint programId)
        {
            GlShaderProgram program = (GlShaderProgram)System.Runtime.CompilerServices.RuntimeHelpers.GetUninitializedObject(typeof(GlShaderProgram));
            program.ProgramId = programId;
            return program;
        }

        /// <summary>
        ///     The fake use program delegate body
        /// </summary>
        /// <param name="program">The program</param>
        private static void FakeUseProgram(uint program)
        {
        }

        /// <summary>
        ///     The fake get uniform location delegate body
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="name">The name</param>
        /// <returns>The int</returns>
        private static int FakeGetUniformLocation(uint program, string name)
        {
            return 5;
        }

        /// <summary>
        ///     The fake get attrib location delegate body
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="name">The name</param>
        /// <returns>The int</returns>
        private static int FakeGetAttribLocation(uint program, string name)
        {
            return 9;
        }

        /// <summary>
        ///     The fake uniform 1 i delegate body
        /// </summary>
        /// <param name="location">The location</param>
        /// <param name="v0">The v0</param>
        private static void FakeUniform1I(int location, int v0)
        {
        }

        /// <summary>
        ///     The fake uniform 1 f delegate body
        /// </summary>
        /// <param name="location">The location</param>
        /// <param name="v0">The v0</param>
        private static void FakeUniform1F(int location, float v0)
        {
        }

        /// <summary>
        ///     The fake uniform 2 f delegate body
        /// </summary>
        /// <param name="location">The location</param>
        /// <param name="v0">The v0</param>
        /// <param name="v1">The v1</param>
        private static void FakeUniform2F(int location, float v0, float v1)
        {
        }

        /// <summary>
        ///     The fake uniform 3 f delegate body
        /// </summary>
        /// <param name="location">The location</param>
        /// <param name="v0">The v0</param>
        /// <param name="v1">The v1</param>
        /// <param name="v2">The v2</param>
        private static void FakeUniform3F(int location, float v0, float v1, float v2)
        {
        }

        /// <summary>
        ///     The fake uniform 4 f delegate body
        /// </summary>
        /// <param name="location">The location</param>
        /// <param name="v0">The v0</param>
        /// <param name="v1">The v1</param>
        /// <param name="v2">The v2</param>
        /// <param name="v3">The v3</param>
        private static void FakeUniform4F(int location, float v0, float v1, float v2, float v3)
        {
        }

        /// <summary>
        ///     The fake uniform matrix 3 fv delegate body
        /// </summary>
        /// <param name="location">The location</param>
        /// <param name="count">The count</param>
        /// <param name="transpose">The transpose</param>
        /// <param name="value">The value</param>
        private static void FakeUniformMatrix3Fv(int location, int count, bool transpose, float[] value)
        {
        }

        /// <summary>
        ///     The fake uniform matrix 4 fv delegate body
        /// </summary>
        /// <param name="location">The location</param>
        /// <param name="count">The count</param>
        /// <param name="transpose">The transpose</param>
        /// <param name="value">The value</param>
        private static void FakeUniformMatrix4Fv(int location, int count, bool transpose, float[] value)
        {
        }

        /// <summary>
        ///     The fake proc address resolver
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The function pointer</returns>
        private static IntPtr FakeProcAddress(string name)
        {
            switch (name)
            {
                case "glUseProgram": return Marshal.GetFunctionPointerForDelegate(new UseProgram(FakeUseProgram));
                case "glGetUniformLocation": return Marshal.GetFunctionPointerForDelegate(new GetUniformLocation(FakeGetUniformLocation));
                case "glGetAttribLocation": return Marshal.GetFunctionPointerForDelegate(new GetAttribLocation(FakeGetAttribLocation));
                case "glUniform1i": return Marshal.GetFunctionPointerForDelegate(new Uniform1I(FakeUniform1I));
                case "glUniform1f": return Marshal.GetFunctionPointerForDelegate(new Uniform1F(FakeUniform1F));
                case "glUniform2f": return Marshal.GetFunctionPointerForDelegate(new Uniform2F(FakeUniform2F));
                case "glUniform3f": return Marshal.GetFunctionPointerForDelegate(new Uniform3F(FakeUniform3F));
                case "glUniform4f": return Marshal.GetFunctionPointerForDelegate(new Uniform4F(FakeUniform4F));
                case "glUniformMatrix3fv": return Marshal.GetFunctionPointerForDelegate(new UniformMatrix3FvDel(FakeUniformMatrix3Fv));
                case "glUniformMatrix4fv": return Marshal.GetFunctionPointerForDelegate(new UniformMatrix4FvDel(FakeUniformMatrix4Fv));
                default: return IntPtr.Zero;
            }
        }
    }
}
