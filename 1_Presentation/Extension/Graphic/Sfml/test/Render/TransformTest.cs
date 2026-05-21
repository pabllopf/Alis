// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TransformTest.cs
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
    ///     Unit tests for the Transform struct.
    /// </summary>
    public class TransformTest
    {
        /// <summary>
        ///     Tests the constructor and field assignment.
        /// </summary>
        [Fact]
        public void Constructor_AssignsFields()
        {
            Transform t = new Transform(1, 2, 3, 4, 5, 6, 7, 8, 9);
            Assert.Equal(1, t.m00);
            Assert.Equal(2, t.m01);
            Assert.Equal(3, t.m02);
            Assert.Equal(4, t.m10);
            Assert.Equal(5, t.m11);
            Assert.Equal(6, t.m12);
            Assert.Equal(7, t.m20);
            Assert.Equal(8, t.m21);
            Assert.Equal(9, t.m22);
        }
    }
}