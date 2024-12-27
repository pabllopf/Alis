// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RectangleFTest.cs
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

using System.Diagnostics.CodeAnalysis;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Shape.Rectangle
{
    /// <summary>
    ///     The rectangle test class
    /// </summary>
    	  
	 public class RectangleFTest 
    {
        /// <summary>
        ///     Tests the rectangle f constructor
        /// </summary>
        [Fact]
        public void TestRectangleF_Constructor()
        {
            float x = 1.0f;
            float y = 2.0f;
            float w = 3.0f;
            float h = 4.0f;

            RectangleF rectangle = new RectangleF(x, y, w, h);

            Assert.Equal(x, rectangle.X);
            Assert.Equal(y, rectangle.Y);
            Assert.Equal(w, rectangle.W);
            Assert.Equal(h, rectangle.H);
        }

        /// <summary>
        ///     Tests that test rectangle f constructor v 2
        /// </summary>
        [Fact]
        public void TestRectangleF_Constructor_V2()
        {
            float x = 1.0f;
            float y = 2.0f;
            float w = 3.0f;
            float h = 4.0f;

            RectangleF rectangle = new RectangleF(x, y, w, h);

            Assert.Equal(x, rectangle.X);
            Assert.Equal(y, rectangle.Y);
            Assert.Equal(w, rectangle.W);
            Assert.Equal(h, rectangle.H);
        }
    }
}