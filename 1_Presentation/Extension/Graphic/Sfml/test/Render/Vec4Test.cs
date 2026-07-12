// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vec4Test.cs
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
    ///     Unit tests for the Vec4 struct.
    /// </summary>
    public class Vec4Test
    {
        /// <summary>
        ///     Tests the constructor and field assignment.
        /// </summary>
        [Fact]
        public void Constructor_AssignsFields()
        {
            Vec4 v = new Vec4(1.0f, 2.0f, 3.0f, 4.0f);
            Assert.Equal(1.0f, v.X);
            Assert.Equal(2.0f, v.Y);
            Assert.Equal(3.0f, v.Z);
            Assert.Equal(4.0f, v.W);
        }

        /// <summary>
        ///     Tests the constructor from Color normalizes byte values to 0..1 range.
        /// </summary>
        [Fact]
        public void Constructor_FromColor_NormalizesComponents()
        {
            Color color = new Color(128, 64, 32, 255);
            Vec4 v = new Vec4(color);
            Assert.Equal(128.0f / 255.0f, v.X);
            Assert.Equal(64.0f / 255.0f, v.Y);
            Assert.Equal(32.0f / 255.0f, v.Z);
            Assert.Equal(255.0f / 255.0f, v.W);
        }
    }
}
