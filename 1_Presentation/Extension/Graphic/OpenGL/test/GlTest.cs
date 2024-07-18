// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlTest.cs
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
using Alis.Extension.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Extension.Graphic.OpenGL.Test
{
    /// <summary>
    ///     The gl test class
    /// </summary>
    public class GlTest
    {
        /// <summary>
        /// Tests that get string returns empty string when string name is invalid
        /// </summary>
        [Fact]
        public void GetString_ReturnsEmptyString_WhenStringNameIsInvalid()
        {
            string result = Gl.GlGetString((StringName) 999); // Assuming 999 is an invalid StringName
            Assert.Equal(string.Empty, result);
        }

        /// <summary>
        /// Tests that gen buffer returns non zero
        /// </summary>
        [Fact]
        public void GenBuffer_ReturnsNonZero()
        {
            uint buffer = Gl.GenBuffer();
            Assert.NotEqual(0u, buffer);
        }

        /// <summary>
        /// Tests that delete buffer does not throw when called with valid buffer
        /// </summary>
        [Fact]
        public void DeleteBuffer_DoesNotThrow_WhenCalledWithValidBuffer()
        {
            uint buffer = Gl.GenBuffer();
            Exception exception = Record.Exception(() => Gl.DeleteBuffer(buffer));
            Assert.Null(exception);
        }

        /// <summary>
        /// Tests that get shader info log returns empty string when shader is invalid
        /// </summary>
        [Fact]
        public void GetShaderInfoLog_ReturnsEmptyString_WhenShaderIsInvalid()
        {
            string log = Gl.GetShaderInfoLog(999); // Assuming 999 is an invalid shader ID
            Assert.Equal(string.Empty, log);
        }

        /// <summary>
        /// Tests that get shader compile status returns false when shader is invalid
        /// </summary>
        [Fact]
        public void GetShaderCompileStatus_ReturnsFalse_WhenShaderIsInvalid()
        {
            bool status = Gl.GetShaderCompileStatus(999); // Assuming 999 is an invalid shader ID
            Assert.False(status);
        }

        /// <summary>
        /// Tests that get program info log returns empty string when program is invalid
        /// </summary>
        [Fact]
        public void GetProgramInfoLog_ReturnsEmptyString_WhenProgramIsInvalid()
        {
            string log = Gl.GetProgramInfoLog(999); // Assuming 999 is an invalid program ID
            Assert.Equal(string.Empty, log);
        }

        /// <summary>
        /// Tests that get program link status returns false when program is invalid
        /// </summary>
        [Fact]
        public void GetProgramLinkStatus_ReturnsFalse_WhenProgramIsInvalid()
        {
            bool status = Gl.GetProgramLinkStatus(999); // Assuming 999 is an invalid program ID
            Assert.False(status);
        }

        /// <summary>
        /// Tests that gen vertex array returns non zero
        /// </summary>
        [Fact]
        public void GenVertexArray_ReturnsNonZero()
        {
            uint vao = Gl.GenVertexArray();
            Assert.NotEqual(0u, vao);
        }

        /// <summary>
        /// Tests that delete vertex array does not throw when called with valid vao
        /// </summary>
        [Fact]
        public void DeleteVertexArray_DoesNotThrow_WhenCalledWithValidVao()
        {
            uint vao = Gl.GenVertexArray();
            Exception exception = Record.Exception(() => Gl.DeleteVertexArray(vao));
            Assert.Null(exception);
        }

        /// <summary>
        /// Tests that gen texture returns non zero
        /// </summary>
        [Fact]
        public void GenTexture_ReturnsNonZero()
        {
            uint texture = Gl.GenTexture();
            Assert.NotEqual(0u, texture);
        }

        /// <summary>
        /// Tests that delete texture does not throw when called with valid texture
        /// </summary>
        [Fact]
        public void DeleteTexture_DoesNotThrow_WhenCalledWithValidTexture()
        {
            uint texture = Gl.GenTexture();
            Exception exception = Record.Exception(() => Gl.DeleteTexture(texture));
            Assert.Null(exception);
        }
    }
}