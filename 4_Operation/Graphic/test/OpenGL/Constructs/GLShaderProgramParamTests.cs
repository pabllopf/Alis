// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GLShaderProgramParamTests.cs
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
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Delegates;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.OpenGL.Constructs
{
    /// <summary>
    /// The gl shader program param tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class GlShaderProgramParamTests : IDisposable
    {
        /// <summary>
        /// The static
        /// </summary>
        private static readonly FieldInfo Field = typeof(Gl).GetField("_getProcAddress", BindingFlags.NonPublic | BindingFlags.Static);

        /// <summary>
        /// The saved
        /// </summary>
        private readonly object _saved;

        /// <summary>
        /// The program id
        /// </summary>
        private uint _programId;

        /// <summary>
        /// The vertex shader id
        /// </summary>
        private uint _vertexShaderId;

        /// <summary>
        /// The fragment shader id
        /// </summary>
        private uint _fragmentShaderId;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlShaderProgramParamTests"/> class
        /// </summary>
        public GlShaderProgramParamTests() => _saved = Field?.GetValue(null);

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => Field?.SetValue(null, _saved);

        /// <summary>
        /// Inits the shader program
        /// </summary>
        private void InitShaderProgram()
        {
            _programId = 42;
            _vertexShaderId = 10;
            _fragmentShaderId = 20;

            CreateProgram createProgram = () => _programId;
            CreateShader createShader = (ShaderType type) => type == ShaderType.VertexShader ? _vertexShaderId : _fragmentShaderId;
            ShaderSourceDel shaderSource = (uint shader, int count, string[] src, int[] len) => { };
            CompileShader compileShader = (uint shader) => { };
            GetShaderiv getShaderiv = (uint shader, ShaderParameter pname, int[] p) =>
            {
                if (pname == ShaderParameter.CompileStatus)
                {
                    p[0] = 1;
                }
                else if (pname == ShaderParameter.InfoLogLength)
                {
                    p[0] = 0;
                }
            };
            GetShaderInfoLogDel getShaderInfoLog = (uint shader, int maxLen, int[] len, StringBuilder sb) => { };
            AttachShader attachShader = (uint program, uint shader) => { };
            LinkProgram linkProgram = (uint program) => { };

            GetProgramiv getProgramiv = (uint program, ProgramParameter pname, int[] p) =>
            {
                if (pname == ProgramParameter.LinkStatus)
                {
                    p[0] = 1;
                }
                else if (pname == ProgramParameter.InfoLogLength)
                {
                    p[0] = 0;
                }
                else if (pname == ProgramParameter.ActiveAttributes)
                {
                    p[0] = 0;
                }
                else if (pname == ProgramParameter.ActiveUniforms)
                {
                    p[0] = 0;
                }
            };

            GetProgramInfoLogDel getProgramInfoLog = (uint program, int maxLen, int[] len, StringBuilder sb) => { };
            UseProgram useProgram = (uint program) => { };
            DetachShader detachShader = (uint program, uint shader) => { };
            DeleteProgram deleteProgram = (uint program) => { };
            DeleteShader deleteShader = (uint shader) => { };

            GetUniformLocation getUniformLocation = (uint program, string name) => 5;
            GetAttribLocation getAttribLocation = (uint program, string name) => 10;

            IntPtr createProgramFp = Marshal.GetFunctionPointerForDelegate(createProgram);
            IntPtr createShaderFp = Marshal.GetFunctionPointerForDelegate(createShader);
            IntPtr shaderSourceFp = Marshal.GetFunctionPointerForDelegate(shaderSource);
            IntPtr compileShaderFp = Marshal.GetFunctionPointerForDelegate(compileShader);
            IntPtr getShaderivFp = Marshal.GetFunctionPointerForDelegate(getShaderiv);
            IntPtr getShaderInfoLogFp = Marshal.GetFunctionPointerForDelegate(getShaderInfoLog);
            IntPtr attachShaderFp = Marshal.GetFunctionPointerForDelegate(attachShader);
            IntPtr linkProgramFp = Marshal.GetFunctionPointerForDelegate(linkProgram);
            IntPtr getProgramivFp = Marshal.GetFunctionPointerForDelegate(getProgramiv);
            IntPtr getProgramInfoLogFp = Marshal.GetFunctionPointerForDelegate(getProgramInfoLog);
            IntPtr useProgramFp = Marshal.GetFunctionPointerForDelegate(useProgram);
            IntPtr detachShaderFp = Marshal.GetFunctionPointerForDelegate(detachShader);
            IntPtr deleteProgramFp = Marshal.GetFunctionPointerForDelegate(deleteProgram);
            IntPtr deleteShaderFp = Marshal.GetFunctionPointerForDelegate(deleteShader);
            IntPtr getUniformLocationFp = Marshal.GetFunctionPointerForDelegate(getUniformLocation);
            IntPtr getAttribLocationFp = Marshal.GetFunctionPointerForDelegate(getAttribLocation);

            Gl.Initialize(name => name switch
            {
                "glCreateProgram" => createProgramFp,
                "glCreateShader" => createShaderFp,
                "glShaderSource" => shaderSourceFp,
                "glCompileShader" => compileShaderFp,
                "glGetShaderiv" => getShaderivFp,
                "glGetShaderInfoLog" => getShaderInfoLogFp,
                "glAttachShader" => attachShaderFp,
                "glLinkProgram" => linkProgramFp,
                "glGetProgramiv" => getProgramivFp,
                "glGetProgramInfoLog" => getProgramInfoLogFp,
                "glUseProgram" => useProgramFp,
                "glDetachShader" => detachShaderFp,
                "glDeleteProgram" => deleteProgramFp,
                "glDeleteShader" => deleteShaderFp,
                "glGetUniformLocation" => getUniformLocationFp,
                "glGetAttribLocation" => getAttribLocationFp,
                _ => IntPtr.Zero
            });
        }

        /// <summary>
        /// Inits the uniforms
        /// </summary>
        private void InitUniforms()
        {
            Uniform1I uniform1i = (int location, int v0) => { };
            Uniform1F uniform1f = (int location, float v0) => { };
            Uniform2F uniform2f = (int location, float v0, float v1) => { };
            Uniform3F uniform3f = (int location, float v0, float v1, float v2) => { };
            Uniform4F uniform4f = (int location, float v0, float v1, float v2, float v3) => { };
            UniformMatrix4FvDel uniformMatrix4fv = (int location, int count, bool transpose, float[] value) => { };
            UniformMatrix3FvDel uniformMatrix3fv = (int location, int count, bool transpose, float[] value) => { };

            IntPtr uniform1iFp = Marshal.GetFunctionPointerForDelegate(uniform1i);
            IntPtr uniform1fFp = Marshal.GetFunctionPointerForDelegate(uniform1f);
            IntPtr uniform2fFp = Marshal.GetFunctionPointerForDelegate(uniform2f);
            IntPtr uniform3fFp = Marshal.GetFunctionPointerForDelegate(uniform3f);
            IntPtr uniform4fFp = Marshal.GetFunctionPointerForDelegate(uniform4f);
            IntPtr uniformMatrix4fvFp = Marshal.GetFunctionPointerForDelegate(uniformMatrix4fv);
            IntPtr uniformMatrix3fvFp = Marshal.GetFunctionPointerForDelegate(uniformMatrix3fv);

            Gl.Initialize(name => name switch
            {
                "glUniform1i" => uniform1iFp,
                "glUniform1f" => uniform1fFp,
                "glUniform2f" => uniform2fFp,
                "glUniform3f" => uniform3fFp,
                "glUniform4f" => uniform4fFp,
                "glUniformMatrix4fv" => uniformMatrix4fvFp,
                "glUniformMatrix3fv" => uniformMatrix3fvFp,
                _ => IntPtr.Zero
            });
        }

        /// <summary>
        /// Creates the valid program
        /// </summary>
        /// <returns>The gl shader program</returns>
        private GlShaderProgram CreateValidProgram()
        {
            GlShader vs = new GlShader("vs", ShaderType.VertexShader);
            GlShader fs = new GlShader("fs", ShaderType.FragmentShader);
            return new GlShaderProgram(vs, fs);
        }

        /// <summary>
        /// Tests that get location when program id is zero and uniform sets location from program
        /// </summary>
        [Fact]
        public void GetLocation_WhenProgramIdIsZeroAndUniform_SetsLocationFromProgram()
        {
            InitShaderProgram();
            GlShaderProgram program = CreateValidProgram();

            GlShaderProgramParam param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "testUniform", 0u, 0);
            param.Location = 0;
            param.ProgramId = 0;

            param.GetLocation(program);

            Assert.Equal(program.ProgramId, param.ProgramId);
            Assert.Equal(5, param.Location);
        }

        /// <summary>
        /// Tests that get location when program id is zero and attribute sets location from program
        /// </summary>
        [Fact]
        public void GetLocation_WhenProgramIdIsZeroAndAttribute_SetsLocationFromProgram()
        {
            InitShaderProgram();
            GlShaderProgram program = CreateValidProgram();

            GlShaderProgramParam param = new GlShaderProgramParam(typeof(Vector3F), ParamType.Attribute, "testAttrib", 0u, 0);
            param.Location = 0;
            param.ProgramId = 0;

            param.GetLocation(program);

            Assert.Equal(program.ProgramId, param.ProgramId);
            Assert.Equal(10, param.Location);
        }

        /// <summary>
        /// Tests that get location when program id is non zero does not change location
        /// </summary>
        [Fact]
        public void GetLocation_WhenProgramIdIsNonZero_DoesNotChangeLocation()
        {
            InitShaderProgram();
            GlShaderProgram program = CreateValidProgram();

            GlShaderProgramParam param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "test", 0u, 99);
            param.ProgramId = 42;

            param.GetLocation(program);

            Assert.Equal(42u, param.ProgramId);
            Assert.Equal(99, param.Location);
        }

        /// <summary>
        /// Tests that get location when program id is non zero does not change program id
        /// </summary>
        [Fact]
        public void GetLocation_WhenProgramIdIsNonZero_DoesNotChangeProgramId()
        {
            InitShaderProgram();
            GlShaderProgram program = CreateValidProgram();

            GlShaderProgramParam param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "test", 0u, 0);
            param.ProgramId = 100;

            param.GetLocation(program);

            Assert.Equal(100u, param.ProgramId);
            Assert.Equal(0, param.Location);
        }

        /// <summary>
        /// Tests that set value float array length 9 calls uniform matrix 3 fv
        /// </summary>
        [Fact]
        public void SetValue_FloatArray_Length9_CallsUniformMatrix3Fv()
        {
            InitUniforms();

            GlShaderProgramParam param = new GlShaderProgramParam(typeof(Exception), ParamType.Uniform, "m3");
            param.Location = 3;
            float[] values = new float[9];

            param.SetValue(values);
        }

        /// <summary>
        /// Tests that get location calls use on program
        /// </summary>
        [Fact]
        public void GetLocation_CallsUseOnProgram()
        {
            InitShaderProgram();
            GlShaderProgram program = CreateValidProgram();

            GlShaderProgramParam param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "test");
            param.ProgramId = 0;
            param.Location = 0;

            param.GetLocation(program);

            Assert.NotEqual(0u, param.ProgramId);
        }

        /// <summary>
        /// Tests that get location with uniform type queries uniform location
        /// </summary>
        [Fact]
        public void GetLocation_WithUniformType_QueriesUniformLocation()
        {
            InitShaderProgram();
            GlShaderProgram program = CreateValidProgram();

            GlShaderProgramParam param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "myUniform");
            param.ProgramId = 0;

            param.GetLocation(program);

            Assert.Equal(5, param.Location);
        }

        /// <summary>
        /// Tests that get location with attribute type queries attribute location
        /// </summary>
        [Fact]
        public void GetLocation_WithAttributeType_QueriesAttributeLocation()
        {
            InitShaderProgram();
            GlShaderProgram program = CreateValidProgram();

            GlShaderProgramParam param = new GlShaderProgramParam(typeof(Vector3F), ParamType.Attribute, "myAttrib");
            param.ProgramId = 0;

            param.GetLocation(program);

            Assert.Equal(10, param.Location);
        }

        /// <summary>
        /// Tests that set value bool calls gl uniform 1 i
        /// </summary>
        [Fact]
        public void SetValue_Bool_CallsGlUniform1I()
        {
            InitUniforms();
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(bool), ParamType.Uniform, "b");
            param.Location = 1;
            param.SetValue(true);
            param.SetValue(false);
        }

        /// <summary>
        /// Tests that set value int calls gl uniform 1 i
        /// </summary>
        [Fact]
        public void SetValue_Int_CallsGlUniform1I()
        {
            InitUniforms();
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "i");
            param.Location = 2;
            param.SetValue(42);
        }

        /// <summary>
        /// Tests that set value float calls gl uniform 1 f
        /// </summary>
        [Fact]
        public void SetValue_Float_CallsGlUniform1F()
        {
            InitUniforms();
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "f");
            param.Location = 3;
            param.SetValue(3.14f);
        }

        /// <summary>
        /// Tests that set value vector 2 f calls gl uniform 2 f
        /// </summary>
        [Fact]
        public void SetValue_Vector2F_CallsGlUniform2F()
        {
            InitUniforms();
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(Vector2F), ParamType.Uniform, "v2");
            param.Location = 4;
            param.SetValue(new Vector2F(1f, 2f));
        }

        /// <summary>
        /// Tests that set value vector 3 f calls gl uniform 3 f
        /// </summary>
        [Fact]
        public void SetValue_Vector3F_CallsGlUniform3F()
        {
            InitUniforms();
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(Vector3F), ParamType.Uniform, "v3");
            param.Location = 5;
            param.SetValue(new Vector3F(1f, 2f, 3f));
        }

        /// <summary>
        /// Tests that set value vector 4 f calls gl uniform 4 f
        /// </summary>
        [Fact]
        public void SetValue_Vector4F_CallsGlUniform4F()
        {
            InitUniforms();
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(Vector4F), ParamType.Uniform, "v4");
            param.Location = 6;
            param.SetValue(new Vector4F(1f, 2f, 3f, 4f));
        }

        /// <summary>
        /// Tests that set value matrix 4 x 4 calls uniform matrix 4 fv
        /// </summary>
        [Fact]
        public void SetValue_Matrix4X4_CallsUniformMatrix4Fv()
        {
            InitUniforms();
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(Matrix4X4), ParamType.Uniform, "m4");
            param.Location = 7;
            param.SetValue(new Matrix4X4());
        }

        /// <summary>
        /// Tests that set value float array length 16 calls gl uniform matrix 4 fv
        /// </summary>
        [Fact]
        public void SetValue_FloatArray_Length16_CallsGlUniformMatrix4Fv()
        {
            InitUniforms();
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(Matrix4X4), ParamType.Uniform, "m16");
            param.Location = 8;
            param.SetValue(new float[16]);
        }

        /// <summary>
        /// Tests that set value float array length 4 calls gl uniform 4 f
        /// </summary>
        [Fact]
        public void SetValue_FloatArray_Length4_CallsGlUniform4F()
        {
            InitUniforms();
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(Vector4F), ParamType.Uniform, "v4arr");
            param.Location = 9;
            param.SetValue(new float[4]);
        }

        /// <summary>
        /// Tests that set value float array length 3 calls gl uniform 3 f
        /// </summary>
        [Fact]
        public void SetValue_FloatArray_Length3_CallsGlUniform3F()
        {
            InitUniforms();
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(Vector3F), ParamType.Uniform, "v3arr");
            param.Location = 10;
            param.SetValue(new float[3]);
        }

        /// <summary>
        /// Tests that set value float array length 2 calls gl uniform 2 f
        /// </summary>
        [Fact]
        public void SetValue_FloatArray_Length2_CallsGlUniform2F()
        {
            InitUniforms();
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(Vector2F), ParamType.Uniform, "v2arr");
            param.Location = 11;
            param.SetValue(new float[2]);
        }

        /// <summary>
        /// Tests that set value float array length 1 calls gl uniform 1 f
        /// </summary>
        [Fact]
        public void SetValue_FloatArray_Length1_CallsGlUniform1F()
        {
            InitUniforms();
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "farr");
            param.Location = 12;
            param.SetValue(new float[1]);
        }

        /// <summary>
        /// Tests that set value float array invalid length throws argument exception
        /// </summary>
        [Fact]
        public void SetValue_FloatArray_InvalidLength_ThrowsArgumentException()
        {
            InitUniforms();
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "x");
            param.Location = 0;
            ArgumentException ex = Assert.Throws<ArgumentException>(() => param.SetValue(new float[0]));
            Assert.Equal("param", ex.ParamName);
        }
    }
}
