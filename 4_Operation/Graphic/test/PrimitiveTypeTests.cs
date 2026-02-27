// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PrimitiveTypeTests.cs
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

using Alis.Core.Graphic.OpenGL;
using Xunit;

namespace Alis.Core.Graphic.Test
{
    /// <summary>
    ///     The primitive type tests class
    /// </summary>
    public class PrimitiveTypeTests
    {
        /// <summary>
        ///     Tests that points has value 0x 0000
        /// </summary>
        [Fact]
        public void Points_HasValue0x0000()
        {
            Assert.Equal(0x0000, (int) PrimitiveType.Points);
        }
        
        /// <summary>
        ///     Tests that lines has value 0x 0001
        /// </summary>
        [Fact]
        public void Lines_HasValue0x0001()
        {
            Assert.Equal(0x0001, (int) PrimitiveType.Lines);
        }

        /// <summary>
        ///     Tests that line loop has value 0x 0002
        /// </summary>
        [Fact]
        public void LineLoop_HasValue0x0002()
        {
            Assert.Equal(0x0002, (int) PrimitiveType.LineLoop);
        }

        /// <summary>
        ///     Tests that line strip has value 0x 0003
        /// </summary>
        [Fact]
        public void LineStrip_HasValue0x0003()
        {
            Assert.Equal(0x0003, (int) PrimitiveType.LineStrip);
        }

        /// <summary>
        ///     Tests that triangles has value 0x 0004
        /// </summary>
        [Fact]
        public void Triangles_HasValue0x0004()
        {
            Assert.Equal(0x0004, (int) PrimitiveType.Triangles);
        }

        /// <summary>
        ///     Tests that triangle strip has value 0x 0005
        /// </summary>
        [Fact]
        public void TriangleStrip_HasValue0x0005()
        {
            Assert.Equal(0x0005, (int) PrimitiveType.TriangleStrip);
        }

        /// <summary>
        ///     Tests that triangle fan has value 0x 0006
        /// </summary>
        [Fact]
        public void TriangleFan_HasValue0x0006()
        {
            Assert.Equal(0x0006, (int) PrimitiveType.TriangleFan);
        }
    }
}