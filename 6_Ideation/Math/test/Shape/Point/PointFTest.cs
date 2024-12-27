// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PointFTest.cs
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
using Alis.Core.Aspect.Math.Shape.Point;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Shape.Point
{
    /// <summary>
    ///     The point test class
    /// </summary>
    	  
	 public class PointFTest 
    {
        /// <summary>
        ///     Tests that constructor initializes properties correctly
        /// </summary>
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            PointF point = new PointF {X = 1.0f, Y = 2.0f};

            Assert.Equal(1.0f, point.X);
            Assert.Equal(2.0f, point.Y);
        }

        /// <summary>
        ///     Tests that properties set values correctly
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [Theory, InlineData(0f, 0f), InlineData(-1f, -1f), InlineData(float.MaxValue, float.MaxValue)]
        public void Properties_SetValuesCorrectly(float x, float y)
        {
            PointF point = new PointF {X = x, Y = y};

            Assert.Equal(x, point.X);
            Assert.Equal(y, point.Y);
        }
    }
}