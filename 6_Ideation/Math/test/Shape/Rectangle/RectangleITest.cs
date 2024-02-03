// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RectangleITest.cs
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

using Alis.Core.Aspect.Math.Shape.Rectangle;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Shape.Rectangle
{
    /// <summary>
    /// The rectangle test class
    /// </summary>
    public class RectangleITest
    {
        /// <summary>
        /// Tests that test rectangle i constructor
        /// </summary>
        [Fact]
        public void TestRectangleI_Constructor()
        {
            int x = 1;
            int y = 2;
            int w = 3;
            int h = 4;

            RectangleI rectangle = new RectangleI(x, y, w, h);

            Assert.Equal(x, rectangle.x);
            Assert.Equal(y, rectangle.y);
            Assert.Equal(w, rectangle.w);
            Assert.Equal(h, rectangle.h);
        }
    }
}