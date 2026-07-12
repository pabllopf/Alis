// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlCoverageRemainingTests.cs
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
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Delegates;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test
{
    /// <summary>
    ///     The gl coverage remaining tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class GlCoverageRemainingTests : IDisposable
    {
        /// <summary>
        ///     The field
        /// </summary>
        private static readonly FieldInfo Field = typeof(Gl).GetField("_getProcAddress", BindingFlags.NonPublic | BindingFlags.Static);

        /// <summary>
        ///     The saved
        /// </summary>
        private readonly object _saved;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GlCoverageRemainingTests"/> class
        /// </summary>
        public GlCoverageRemainingTests() => _saved = Field?.GetValue(null);

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose() => Field?.SetValue(null, _saved);

        /// <summary>
        ///     Inits the zero
        /// </summary>
        private static void InitZero() => Gl.Initialize(_ => IntPtr.Zero);

        /// <summary>
        ///     Tests that all uncovered properties throw external
        /// </summary>
        [Fact]
        public void AllUncoveredProperties_ThrowExternal()
        {
            InitZero();

            Assert.Throws<ExternalException>(() => { _ = Gl.GlViewport; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlClearColor; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlColor4F; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlEnd; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlClear; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlEnable; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlDisable; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlBlendEquation; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlBlendFunc; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlUseProgram; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlCreateShader; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlBegin; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlCompileShader; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlDeleteShader; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlCreateProgram; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlAttachShader; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlLinkProgram; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlGetUniformLocation; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlGetAttribLocation; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlDetachShader; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlDeleteProgram; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlGetActiveAttrib; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlGetActiveUniform; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlUniform1F; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlUniform2F; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlUniform3F; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlUniform4F; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlUniform1I; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlReadPixels; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlGenFramebuffer; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlFramebufferTexture2D; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlUniformMatrix3Fv; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlBindSampler; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlBindVertexArray; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlBindBuffer; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlVertex2F; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlTexCoord2F; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlDisableVertexAttribArray; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlBindFramebuffer; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlBindTexture; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlBufferData; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlScissor; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlDrawElementsBaseVertex; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlPixelStorei; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlTexImage2D; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlTexParameteri; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlDrawArrays; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlDrawElements; });
            Assert.Throws<ExternalException>(() => { _ = Gl.GlPolygonMode; });
        }

        /// <summary>
        ///     Tests that get shader compile status returns true when compile status is one
        /// </summary>
        [Fact]
        public void GetShaderCompileStatus_ReturnsTrue_WhenCompileStatusIsOne()
        {
            GetShaderiv mock = (uint shader, ShaderParameter pname, int[] data) => { data[0] = 1; };
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Gl.Initialize(name => name == "glGetShaderiv" ? fp : IntPtr.Zero);
            Assert.True(Gl.GetShaderCompileStatus(1));
        }

        /// <summary>
        ///     Tests that get shader compile status returns false when compile status is zero
        /// </summary>
        [Fact]
        public void GetShaderCompileStatus_ReturnsFalse_WhenCompileStatusIsZero()
        {
            GetShaderiv mock = (uint shader, ShaderParameter pname, int[] data) => { data[0] = 0; };
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Gl.Initialize(name => name == "glGetShaderiv" ? fp : IntPtr.Zero);
            Assert.False(Gl.GetShaderCompileStatus(1));
        }

        /// <summary>
        ///     Tests that get program link status returns true when link status is one
        /// </summary>
        [Fact]
        public void GetProgramLinkStatus_ReturnsTrue_WhenLinkStatusIsOne()
        {
            GetProgramiv mock = (uint program, ProgramParameter pname, int[] data) => { data[0] = 1; };
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Gl.Initialize(name => name == "glGetProgramiv" ? fp : IntPtr.Zero);
            Assert.True(Gl.GetProgramLinkStatus(1));
        }

        /// <summary>
        ///     Tests that get program link status returns false when link status is zero
        /// </summary>
        [Fact]
        public void GetProgramLinkStatus_ReturnsFalse_WhenLinkStatusIsZero()
        {
            GetProgramiv mock = (uint program, ProgramParameter pname, int[] data) => { data[0] = 0; };
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Gl.Initialize(name => name == "glGetProgramiv" ? fp : IntPtr.Zero);
            Assert.False(Gl.GetProgramLinkStatus(1));
        }

        /// <summary>
        ///     Tests that get shader info log returns empty when info log length is zero
        /// </summary>
        [Fact]
        public void GetShaderInfoLog_ReturnsEmpty_WhenInfoLogLengthIsZero()
        {
            GetShaderiv mock = (uint shader, ShaderParameter pname, int[] data) => { data[0] = 0; };
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Gl.Initialize(name => name == "glGetShaderiv" ? fp : IntPtr.Zero);
            Assert.Equal(string.Empty, Gl.GetShaderInfoLog(1));
        }

        /// <summary>
        ///     Tests that get shader info log returns log when info log length is non zero
        /// </summary>
        [Fact]
        public void GetShaderInfoLog_ReturnsLog_WhenInfoLogLengthIsNonZero()
        {
            GetShaderiv shaderMock = (uint shader, ShaderParameter pname, int[] data) => { data[0] = 5; };
            GetShaderInfoLogDel logMock = (uint shader, int maxLength, int[] length, StringBuilder infoLog) =>
            {
                infoLog.Append("hello");
                length[0] = 5;
            };
            IntPtr fpShader = Marshal.GetFunctionPointerForDelegate(shaderMock);
            IntPtr fpLog = Marshal.GetFunctionPointerForDelegate(logMock);
            Gl.Initialize(name =>
                name == "glGetShaderiv" ? fpShader :
                name == "glGetShaderInfoLog" ? fpLog : IntPtr.Zero);
            Assert.Equal("hello", Gl.GetShaderInfoLog(1));
        }

        /// <summary>
        ///     Tests that get program info log returns empty when info log length is zero
        /// </summary>
        [Fact]
        public void GetProgramInfoLog_ReturnsEmpty_WhenInfoLogLengthIsZero()
        {
            GetProgramiv mock = (uint program, ProgramParameter pname, int[] data) => { data[0] = 0; };
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Gl.Initialize(name => name == "glGetProgramiv" ? fp : IntPtr.Zero);
            Assert.Equal(string.Empty, Gl.GetProgramInfoLog(1));
        }

        /// <summary>
        ///     Tests that get program info log returns log when info log length is non zero
        /// </summary>
        [Fact]
        public void GetProgramInfoLog_ReturnsLog_WhenInfoLogLengthIsNonZero()
        {
            GetProgramiv programMock = (uint program, ProgramParameter pname, int[] data) => { data[0] = 5; };
            GetProgramInfoLogDel logMock = (uint program, int maxLength, int[] length, StringBuilder infoLog) =>
            {
                infoLog.Append("hello");
                length[0] = 5;
            };
            IntPtr fpProgram = Marshal.GetFunctionPointerForDelegate(programMock);
            IntPtr fpLog = Marshal.GetFunctionPointerForDelegate(logMock);
            Gl.Initialize(name =>
                name == "glGetProgramiv" ? fpProgram :
                name == "glGetProgramInfoLog" ? fpLog : IntPtr.Zero);
            Assert.Equal("hello", Gl.GetProgramInfoLog(1));
        }

        /// <summary>
        ///     Tests that gl get string returns string when pointer non null
        /// </summary>
        [Fact]
        public void GlGetString_ReturnsString_WhenPointerNonNull()
        {
            IntPtr ptr = Marshal.AllocHGlobal(6);
            try
            {
                Marshal.WriteByte(ptr, 0, (byte)'H');
                Marshal.WriteByte(ptr, 1, (byte)'e');
                Marshal.WriteByte(ptr, 2, (byte)'l');
                Marshal.WriteByte(ptr, 3, (byte)'l');
                Marshal.WriteByte(ptr, 4, (byte)'o');
                Marshal.WriteByte(ptr, 5, 0);
                GetString mock = (StringName _) => ptr;
                IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
                Gl.Initialize(name => name == "glGetString" ? fp : IntPtr.Zero);
                Assert.Equal("Hello", Gl.GlGetString(StringName.Version));
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
    }
}
