// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PointITest.cs
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
    	  
	 public class PointITest 
    {
        /// <summary>
        ///     Tests that constructor initializes properties correctly
        /// </summary>
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            PointI point = new PointI {X = 1, Y = 2};

            Assert.Equal(1, point.X);
            Assert.Equal(2, point.Y);
        }

        /// <summary>
        ///     Tests that properties set values correctly
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [Theory, InlineData(0, 0), InlineData(-1, -1), InlineData(int.MaxValue, int.MaxValue)]
        public void Properties_SetValuesCorrectly(int x, int y)
        {
            PointI point = new PointI {X = x, Y = y};

            Assert.Equal(x, point.X);
            Assert.Equal(y, point.Y);
        }
    }
}