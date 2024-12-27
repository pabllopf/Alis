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
using System.Diagnostics.CodeAnalysis;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Extension.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Extension.Graphic.OpenGL.Test
{
    /// <summary>
    ///     The gl test class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
	 public class GlTest 
    {
        /// <summary>
        ///     Tests that get program link status returns true when linked
        /// </summary>
        [Fact]
        public void GetProgramLinkStatus_ReturnsTrueWhenLinked()
        {
            uint program = 1;
            Assert.Throws<TypeInitializationException>(() => Gl.GetProgramLinkStatus(program));
        }

        /// <summary>
        ///     Tests that get program link status returns false when not linked
        /// </summary>
        [Fact]
        public void GetProgramLinkStatus_ReturnsFalseWhenNotLinked()
        {
            uint program = 0;
            Assert.Throws<TypeInitializationException>(() => Gl.GetProgramLinkStatus(program));
        }

        /// <summary>
        ///     Tests that uniform matrix 4 fv calls gl uniform matrix 4 fv
        /// </summary>
        [Fact]
        public void UniformMatrix4Fv_CallsGlUniformMatrix4Fv()
        {
            int location = 1;
            Matrix4X4 matrix = new Matrix4X4();
            Assert.Throws<TypeInitializationException>(() => Gl.UniformMatrix4Fv(location, matrix));
        }

        /// <summary>
        ///     Tests that vertex attrib pointer throws argument out of range exception for negative index
        /// </summary>
        [Fact]
        public void VertexAttribPointer_ThrowsArgumentOutOfRangeExceptionForNegativeIndex()
        {
            int index = -1;
            Assert.Throws<ArgumentOutOfRangeException>(() => Gl.VertexAttribPointer(index, 3, VertexAttribPointerType.Float, false, 0, IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that vertex attrib pointer calls gl vertex attrib pointer
        /// </summary>
        [Fact]
        public void VertexAttribPointer_CallsGlVertexAttribPointer()
        {
            int index = 1;
            Assert.Throws<TypeInitializationException>(() => Gl.VertexAttribPointer(index, 3, VertexAttribPointerType.Float, false, 0, IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that enable vertex attrib array throws argument out of range exception for negative index
        /// </summary>
        [Fact]
        public void EnableVertexAttribArray_ThrowsArgumentOutOfRangeExceptionForNegativeIndex()
        {
            int index = -1;
            Assert.Throws<ArgumentOutOfRangeException>(() => Gl.EnableVertexAttribArray(index));
        }

        /// <summary>
        ///     Tests that enable vertex attrib array calls gl enable vertex attrib array
        /// </summary>
        [Fact]
        public void EnableVertexAttribArray_CallsGlEnableVertexAttribArray()
        {
            int index = 1;
            Assert.Throws<TypeInitializationException>(() => Gl.EnableVertexAttribArray(index));
        }

        /// <summary>
        ///     Tests that gen vertex array calls gl gen vertex arrays
        /// </summary>
        [Fact]
        public void GenVertexArray_CallsGlGenVertexArrays()
        {
            Assert.Throws<TypeInitializationException>(() => Gl.GenVertexArray());
        }

        /// <summary>
        ///     Tests that delete vertex array calls gl delete vertex arrays
        /// </summary>
        [Fact]
        public void DeleteVertexArray_CallsGlDeleteVertexArrays()
        {
            uint vao = 1;
            Assert.Throws<TypeInitializationException>(() => Gl.DeleteVertexArray(vao));
        }

        /// <summary>
        ///     Tests that gen texture calls gl gen textures
        /// </summary>
        [Fact]
        public void GenTexture_CallsGlGenTextures()
        {
            Assert.Throws<TypeInitializationException>(() => Gl.GenTexture());
        }

        /// <summary>
        ///     Tests that delete texture calls gl delete textures
        /// </summary>
        [Fact]
        public void DeleteTexture_CallsGlDeleteTextures()
        {
            uint texture = 1;
            Assert.Throws<TypeInitializationException>(() => Gl.DeleteTexture(texture));
        }
    }
}