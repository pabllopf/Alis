// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Ivec4Test.cs
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

using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Unit tests for the Ivec4 struct.
    /// </summary>
    public class Ivec4Test
    {
        /// <summary>
        ///     Tests the constructor and field assignment.
        /// </summary>
        [Fact]
        public void Constructor_AssignsFields()
        {
            Ivec4 v = new Ivec4(1, 2, 3, 4);
            Assert.Equal(1, v.X);
            Assert.Equal(2, v.Y);
            Assert.Equal(3, v.Z);
            Assert.Equal(4, v.W);
        }

        /// <summary>
        ///     Tests the constructor from Color copies byte components directly.
        /// </summary>
        [Fact]
        public void Constructor_FromColor_CopiesComponents()
        {
            Color color = new Color(10, 20, 30, 40);
            Ivec4 v = new Ivec4(color);
            Assert.Equal(10, v.X);
            Assert.Equal(20, v.Y);
            Assert.Equal(30, v.Z);
            Assert.Equal(40, v.W);
        }
    }
}
