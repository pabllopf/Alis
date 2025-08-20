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
using Alis.Core.Graphic;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     The gl test class
    /// </summary>
    public class GlTest
    {
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
        ///     Tests that enable vertex attrib array throws argument out of range exception for negative index
        /// </summary>
        [Fact]
        public void EnableVertexAttribArray_ThrowsArgumentOutOfRangeExceptionForNegativeIndex()
        {
            int index = -1;
            Assert.Throws<ArgumentOutOfRangeException>(() => Gl.EnableVertexAttribArray(index));
        }
    }
}