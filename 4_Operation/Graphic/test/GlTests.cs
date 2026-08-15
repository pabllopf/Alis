// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlTests.cs
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
using System.Text;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Delegates;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test
{
    /// <summary>
    ///     Exercises the Gl command resolution and composite wrapper paths using fake
    ///     function pointers so the managed bodies run without a live OpenGL context.
    /// </summary>
    public class GlTests
    {
        /// <summary>
        ///     The pinned string returned by the fake get string command
        /// </summary>
        private static IntPtr _fakeStringPtr;

        /// <summary>
        ///     The fake string returned by the fake get string command
        /// </summary>
        private static readonly string FakeString = "OpenGL ES 3.0";

        /// <summary>
        ///     The clear fake delegate reference
        /// </summary>
        private static readonly Clear FakeClearDelegate = FakeClear;

        /// <summary>
        ///     The get string fake delegate reference
        /// </summary>
        private static readonly GetString FakeGetStringDelegate = FakeGetString;

        /// <summary>
        ///     The get shader iv fake delegate reference
        /// </summary>
        private static readonly GetShaderiv FakeGetShaderivDelegate = FakeGetShaderiv;

        /// <summary>
        ///     The get program iv fake delegate reference
        /// </summary>
        private static readonly GetProgramiv FakeGetProgramivDelegate = FakeGetProgramiv;

        /// <summary>
        ///     The gen buffers fake delegate reference
        /// </summary>
        private static readonly GenBuffers FakeGenBuffersDelegate = FakeGenBuffers;

        /// <summary>
        ///     The delete buffers fake delegate reference
        /// </summary>
        private static readonly DeleteBuffers FakeDeleteBuffersDelegate = FakeDeleteBuffers;

        /// <summary>
        ///     The get shader info log fake delegate reference
        /// </summary>
        private static readonly GetShaderInfoLogDel FakeGetShaderInfoLogDelegate = FakeGetShaderInfoLog;

        /// <summary>
        ///     The get program info log fake delegate reference
        /// </summary>
        private static readonly GetProgramInfoLogDel FakeGetProgramInfoLogDelegate = FakeGetProgramInfoLog;

        /// <summary>
        ///     The shader source fake delegate reference
        /// </summary>
        private static readonly ShaderSourceDel FakeShaderSourceDelegate = FakeShaderSource;

        /// <summary>
        ///     The uniform matrix 4 fv fake delegate reference
        /// </summary>
        private static readonly UniformMatrix4FvDel FakeUniformMatrix4FvDelegate = FakeUniformMatrix4Fv;

        /// <summary>
        ///     The enable vertex attrib array fake delegate reference
        /// </summary>
        private static readonly EnableVertexAttribArrayDel FakeEnableVertexAttribArrayDelegate = FakeEnableVertexAttribArray;

        /// <summary>
        ///     The vertex attrib pointer fake delegate reference
        /// </summary>
        private static readonly VertexAttribPointerDel FakeVertexAttribPointerDelegate = FakeVertexAttribPointer;

        /// <summary>
        ///     The gen vertex arrays fake delegate reference
        /// </summary>
        private static readonly GenVertexArrays FakeGenVertexArraysDelegate = FakeGenVertexArrays;

        /// <summary>
        ///     The delete vertex arrays fake delegate reference
        /// </summary>
        private static readonly DeleteVertexArrays FakeDeleteVertexArraysDelegate = FakeDeleteVertexArrays;

        /// <summary>
        ///     The gen textures fake delegate reference
        /// </summary>
        private static readonly GenTextures FakeGenTexturesDelegate = FakeGenTextures;

        /// <summary>
        ///     The delete textures fake delegate reference
        /// </summary>
        private static readonly DeleteTextures FakeDeleteTexturesDelegate = FakeDeleteTextures;

        /// <summary>
        ///     The get error fake delegate reference
        /// </summary>
        private static readonly Gl.GetError FakeGetErrorDelegate = FakeGetError;

        /// <summary>
        ///     The line width fake delegate reference
        /// </summary>
        private static readonly Gl.LineWidth FakeLineWidthDelegate = FakeLineWidth;

        /// <summary>
        ///     The active texture fake delegate reference
        /// </summary>
        private static readonly Gl.ActiveTexture FakeActiveTextureDelegate = FakeActiveTexture;

        /// <summary>
        ///     The get integerv fake delegate reference
        /// </summary>
        private static readonly Gl.GetIntegerv FakeGetIntegervDelegate = FakeGetIntegerv;

        /// <summary>
        ///     The uniform matrix 2x3 fake delegate reference
        /// </summary>
        private static readonly Gl.UniformMatrix2x3FvDel FakeUniformMatrix2x3FvDelegate = FakeUniformMatrix2x3Fv;

        /// <summary>
        ///     The fake get active attrib delegate reference
        /// </summary>
        private static readonly GetActiveAttrib FakeGetActiveAttribDelegate = FakeGetActiveAttrib;

        /// <summary>
        ///     The fake get active uniform delegate reference
        /// </summary>
        private static readonly GetActiveUniform FakeGetActiveUniformDelegate = FakeGetActiveUniform;

        /// <summary>
        ///     The fake clear delegate body
        /// </summary>
        /// <param name="mask">The mask</param>
        private static void FakeClear(ClearBufferMasks mask)
        {
        }

        /// <summary>
        ///     The fake get active attrib delegate body
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="index">The index</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="length">The length</param>
        /// <param name="size">The size</param>
        /// <param name="type">The type</param>
        /// <param name="name">The name</param>
        private static void FakeGetActiveAttrib(uint program, uint index, int bufSize, int[] length, int[] size, ActiveAttribType[] type, StringBuilder name)
        {
        }

        /// <summary>
        ///     The fake get active uniform delegate body
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="index">The index</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="length">The length</param>
        /// <param name="size">The size</param>
        /// <param name="type">The type</param>
        /// <param name="name">The name</param>
        private static void FakeGetActiveUniform(uint program, uint index, int bufSize, int[] length, int[] size, ActiveUniformType[] type, StringBuilder name)
        {
        }

        /// <summary>
        ///     The fake get string delegate body
        /// </summary>
        /// <param name="pname">The pname</param>
        /// <returns>The string pointer</returns>
        private static IntPtr FakeGetString(StringName pname) => _fakeStringPtr;

        /// <summary>
        ///     The fake shader info log length returned by the fake get shader iv command
        /// </summary>
        private static int _fakeShaderInfoLogLength;

        /// <summary>
        ///     The fake program info log length returned by the fake get program iv command
        /// </summary>
        private static int _fakeProgramInfoLogLength;

        /// <summary>
        ///     The fake get shader iv delegate body
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="pname">The pname</param>
        /// <param name="paramsOut">The params out</param>
        private static void FakeGetShaderiv(uint shader, ShaderParameter pname, int[] paramsOut)
        {
            if (paramsOut.Length > 0)
            {
                paramsOut[0] = pname == ShaderParameter.InfoLogLength ? _fakeShaderInfoLogLength : 1;
            }
        }

        /// <summary>
        ///     The fake get program iv delegate body
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="pname">The pname</param>
        /// <param name="paramsOut">The params out</param>
        private static void FakeGetProgramiv(uint program, ProgramParameter pname, int[] paramsOut)
        {
            if (paramsOut.Length > 0)
            {
                paramsOut[0] = pname == ProgramParameter.InfoLogLength ? _fakeProgramInfoLogLength : 1;
            }
        }

        /// <summary>
        ///     The fake gen buffers delegate body
        /// </summary>
        /// <param name="n">The n</param>
        /// <param name="buffers">The buffers</param>
        private static void FakeGenBuffers(int n, uint[] buffers)
        {
            if (buffers.Length > 0)
            {
                buffers[0] = 7;
            }
        }

        /// <summary>
        ///     The fake delete buffers delegate body
        /// </summary>
        /// <param name="n">The n</param>
        /// <param name="buffers">The buffers</param>
        private static void FakeDeleteBuffers(int n, uint[] buffers)
        {
        }

        /// <summary>
        ///     The fake get shader info log delegate body
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="length">The length</param>
        /// <param name="infoLog">The info log</param>
        private static void FakeGetShaderInfoLog(uint shader, int maxLength, int[] length, StringBuilder infoLog)
        {
            infoLog?.Append("log");
        }

        /// <summary>
        ///     The fake get program info log delegate body
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="length">The length</param>
        /// <param name="infoLog">The info log</param>
        private static void FakeGetProgramInfoLog(uint program, int maxLength, int[] length, StringBuilder infoLog)
        {
            infoLog?.Append("log");
        }

        /// <summary>
        ///     The fake shader source delegate body
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="count">The count</param>
        /// <param name="strings">The strings</param>
        /// <param name="length">The length</param>
        private static void FakeShaderSource(uint shader, int count, string[] strings, int[] length)
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
        ///     The fake enable vertex attrib array delegate body
        /// </summary>
        /// <param name="index">The index</param>
        private static void FakeEnableVertexAttribArray(uint index)
        {
        }

        /// <summary>
        ///     The fake vertex attrib pointer delegate body
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="size">The size</param>
        /// <param name="type">The type</param>
        /// <param name="normalized">The normalized</param>
        /// <param name="stride">The stride</param>
        /// <param name="pointer">The pointer</param>
        private static void FakeVertexAttribPointer(uint index, int size, VertexAttribPointerType type, bool normalized, int stride, IntPtr pointer)
        {
        }

        /// <summary>
        ///     The fake gen vertex arrays delegate body
        /// </summary>
        /// <param name="n">The n</param>
        /// <param name="arrays">The arrays</param>
        private static void FakeGenVertexArrays(int n, uint[] arrays)
        {
            if (arrays.Length > 0)
            {
                arrays[0] = 9;
            }
        }

        /// <summary>
        ///     The fake delete vertex arrays delegate body
        /// </summary>
        /// <param name="n">The n</param>
        /// <param name="arrays">The arrays</param>
        private static void FakeDeleteVertexArrays(int n, uint[] arrays)
        {
        }

        /// <summary>
        ///     The fake gen textures delegate body
        /// </summary>
        /// <param name="n">The n</param>
        /// <param name="textures">The textures</param>
        private static void FakeGenTextures(int n, uint[] textures)
        {
            if (textures.Length > 0)
            {
                textures[0] = 11;
            }
        }

        /// <summary>
        ///     The fake delete textures delegate body
        /// </summary>
        /// <param name="n">The n</param>
        /// <param name="textures">The textures</param>
        private static void FakeDeleteTextures(int n, uint[] textures)
        {
        }

        /// <summary>
        ///     The fake get error delegate body
        /// </summary>
        /// <returns>The int</returns>
        private static int FakeGetError() => 0;

        /// <summary>
        ///     The fake line width delegate body
        /// </summary>
        /// <param name="width">The width</param>
        private static void FakeLineWidth(float width)
        {
        }

        /// <summary>
        ///     The fake active texture delegate body
        /// </summary>
        /// <param name="texture">The texture</param>
        private static void FakeActiveTexture(TextureUnit texture)
        {
        }

        /// <summary>
        ///     The fake get integerv delegate body
        /// </summary>
        /// <param name="pname">The pname</param>
        /// <param name="data">The data</param>
        private static void FakeGetIntegerv(int pname, int[] data)
        {
        }

        /// <summary>
        ///     The fake uniform matrix 2x3 delegate body
        /// </summary>
        /// <param name="location">The location</param>
        /// <param name="count">The count</param>
        /// <param name="transpose">The transpose</param>
        /// <param name="value">The value</param>
        private static void FakeUniformMatrix2x3Fv(int location, int count, bool transpose, Span<float> value)
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
                case "glGetString": return Marshal.GetFunctionPointerForDelegate(FakeGetStringDelegate);
                case "glGetShaderiv": return Marshal.GetFunctionPointerForDelegate(FakeGetShaderivDelegate);
                case "glGetProgramiv": return Marshal.GetFunctionPointerForDelegate(FakeGetProgramivDelegate);
                case "glGetActiveAttrib": return Marshal.GetFunctionPointerForDelegate(FakeGetActiveAttribDelegate);
                case "glGetActiveUniform": return Marshal.GetFunctionPointerForDelegate(FakeGetActiveUniformDelegate);
                case "glGenBuffers": return Marshal.GetFunctionPointerForDelegate(FakeGenBuffersDelegate);
                case "glDeleteBuffers": return Marshal.GetFunctionPointerForDelegate(FakeDeleteBuffersDelegate);
                case "glGetShaderInfoLog": return Marshal.GetFunctionPointerForDelegate(FakeGetShaderInfoLogDelegate);
                case "glGetProgramInfoLog": return Marshal.GetFunctionPointerForDelegate(FakeGetProgramInfoLogDelegate);
                case "glShaderSource": return Marshal.GetFunctionPointerForDelegate(FakeShaderSourceDelegate);
                case "glUniformMatrix4fv": return Marshal.GetFunctionPointerForDelegate(FakeUniformMatrix4FvDelegate);
                case "glEnableVertexAttribArray": return Marshal.GetFunctionPointerForDelegate(FakeEnableVertexAttribArrayDelegate);
                case "glVertexAttribPointer": return Marshal.GetFunctionPointerForDelegate(FakeVertexAttribPointerDelegate);
                case "glGenVertexArrays": return Marshal.GetFunctionPointerForDelegate(FakeGenVertexArraysDelegate);
                case "glDeleteVertexArrays": return Marshal.GetFunctionPointerForDelegate(FakeDeleteVertexArraysDelegate);
                case "glGenTextures": return Marshal.GetFunctionPointerForDelegate(FakeGenTexturesDelegate);
                case "glDeleteTextures": return Marshal.GetFunctionPointerForDelegate(FakeDeleteTexturesDelegate);
                case "glGetError": return Marshal.GetFunctionPointerForDelegate(FakeGetErrorDelegate);
                case "glLineWidth": return Marshal.GetFunctionPointerForDelegate(FakeLineWidthDelegate);
                case "glActiveTexture": return Marshal.GetFunctionPointerForDelegate(FakeActiveTextureDelegate);
                case "glGetIntegerv": return Marshal.GetFunctionPointerForDelegate(FakeGetIntegervDelegate);
                case "glUniformMatrix2x3fv": return Marshal.GetFunctionPointerForDelegate(FakeUniformMatrix2x3FvDelegate);
                default: return Marshal.GetFunctionPointerForDelegate(FakeClearDelegate);
            }
        }

        /// <summary>
        ///     Verifies that the active attrib and uniform command properties resolve when a
        ///     function pointer is available for them.
        /// </summary>
        [Fact]
        public void ActiveAttribAndUniform_ResolveWithFunctionPointers()
        {
            Gl.Initialize(FakeProcAddress);
            Assert.NotNull(Gl.GlGetActiveAttrib);
            Assert.NotNull(Gl.GlGetActiveUniform);
            Gl.Initialize(null);
        }

        /// <summary>
        ///     Verifies that the string query reads a native string buffer.
        /// </summary>
        [Fact]
        public void GlGetString_WithNativeBuffer_ReturnsString()
        {
            IntPtr buffer = Marshal.StringToHGlobalAnsi(FakeString);
            try
            {
                _fakeStringPtr = buffer;
                Gl.Initialize(FakeProcAddress);
                string result = Gl.GlGetString(StringName.Renderer);
                Assert.Equal(FakeString, result);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
                Gl.Initialize(null);
            }
        }

        /// <summary>
        ///     Verifies that the string query returns empty when the pointer is zero.
        /// </summary>
        [Fact]
        public void GlGetString_WithZeroPointer_ReturnsEmpty()
        {
            _fakeStringPtr = IntPtr.Zero;
            Gl.Initialize(FakeProcAddress);
            Assert.Equal(string.Empty, Gl.GlGetString(StringName.Renderer));
            Gl.Initialize(null);
        }

        /// <summary>
        ///     Verifies that the buffer generation and deletion wrappers execute.
        /// </summary>
        [Fact]
        public void GenAndDeleteBuffer_Execute()
        {
            Gl.Initialize(FakeProcAddress);
            uint buffer = Gl.GenBuffer();
            Assert.Equal(7u, buffer);
            Gl.DeleteBuffer(buffer);
            Gl.Initialize(null);
        }

        /// <summary>
        ///     Verifies that the shader info log query executes with a positive length.
        /// </summary>
        [Fact]
        public void GetShaderInfoLog_WithPositiveLength_ReturnsText()
        {
            _fakeShaderInfoLogLength = 100;
            Gl.Initialize(FakeProcAddress);
            string log = Gl.GetShaderInfoLog(1);
            Assert.Equal("log", log);
            _fakeShaderInfoLogLength = 0;
            Gl.Initialize(null);
        }

        /// <summary>
        ///     Verifies that the shader info log query returns empty for a zero length.
        /// </summary>
        [Fact]
        public void GetShaderInfoLog_WithZeroLength_ReturnsEmpty()
        {
            _fakeShaderInfoLogLength = 0;
            Gl.Initialize(FakeProcAddress);
            Assert.Equal(string.Empty, Gl.GetShaderInfoLog(1));
            Gl.Initialize(null);
        }

        /// <summary>
        ///     Verifies that the program info log query returns empty for a zero length.
        /// </summary>
        [Fact]
        public void GetProgramInfoLog_WithZeroLength_ReturnsEmpty()
        {
            Gl.Initialize(FakeProcAddress);
            Assert.Equal(string.Empty, Gl.GetProgramInfoLog(1));
            Gl.Initialize(null);
        }

        /// <summary>
        ///     Verifies that the matrix 2x3 uniform wrapper executes.
        /// </summary>
        [Fact]
        public void UniformMatrix2X3_Executes()
        {
            Gl.Initialize(FakeProcAddress);
            Gl.GlUniformMatrix2x3(0, false, new float[6]);
            Gl.Initialize(null);
        }

        /// <summary>
        ///     Verifies that the shader source and compile status wrappers execute.
        /// </summary>
        [Fact]
        public void ShaderSource_And_CompileStatus_Execute()
        {
            Gl.Initialize(FakeProcAddress);
            Gl.ShaderSource(1, "void main() {}");
            Assert.True(Gl.GetShaderCompileStatus(1));
            Gl.Initialize(null);
        }

        /// <summary>
        ///     Verifies that the program info log and link status wrappers execute.
        /// </summary>
        [Fact]
        public void ProgramInfoLog_And_LinkStatus_Execute()
        {
            _fakeProgramInfoLogLength = 100;
            Gl.Initialize(FakeProcAddress);
            string log = Gl.GetProgramInfoLog(1);
            Assert.Equal("log", log);
            Assert.True(Gl.GetProgramLinkStatus(1));
            _fakeProgramInfoLogLength = 0;
            Gl.Initialize(null);
        }

        /// <summary>
        ///     Verifies that the uniform matrix and shader state wrappers execute.
        /// </summary>
        [Fact]
        public void CompositeStateWrappers_Execute()
        {
            Gl.Initialize(FakeProcAddress);
            Gl.UniformMatrix4Fv(0, new Matrix4X4());
            Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, IntPtr.Zero);
            Gl.EnableVertexAttribArray(0);
            Gl.GlGetShader(1, ShaderParameter.CompileStatus, out int status);
            Assert.Equal(1, status);
            Gl.GlGetProgram(1, ProgramParameter.LinkStatus, out int link);
            Assert.Equal(1, link);
            Gl.GlGetIntegerv(0, new int[4]);
            Gl.Initialize(null);
        }

        /// <summary>
        ///     Verifies that the vertex array and texture wrappers execute.
        /// </summary>
        [Fact]
        public void VertexArray_And_Texture_Wrappers_Execute()
        {
            Gl.Initialize(FakeProcAddress);
            uint vao = Gl.GenVertexArray();
            Assert.Equal(9u, vao);
            Gl.DeleteVertexArray(vao);
            uint texture = Gl.GenTexture();
            Assert.Equal(11u, texture);
            Gl.DeleteTexture(texture);
            Gl.Initialize(null);
        }

        /// <summary>
        ///     Verifies that the direct state wrappers execute.
        /// </summary>
        [Fact]
        public void DirectStateWrappers_Execute()
        {
            Gl.Initialize(FakeProcAddress);
            Assert.Equal(0, Gl.GlGetError());
            Gl.GlLineWidth(1.0f);
            Gl.GlActiveTexture(TextureUnit.Texture0);
            Gl.Initialize(null);
        }
    }
}
