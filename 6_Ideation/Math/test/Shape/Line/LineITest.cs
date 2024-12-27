// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LineITest.cs
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
using Alis.Core.Aspect.Math.Shape.Line;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Shape.Line
{
    /// <summary>
    ///     The line test class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
	 public class LineITest 
    {
        /// <summary>
        ///     Tests that constructor initializes properties correctly
        /// </summary>
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            LineI line = new LineI {X1 = 1, Y1 = 2, X2 = 3, Y2 = 4};

            Assert.Equal(1, line.X1);
            Assert.Equal(2, line.Y1);
            Assert.Equal(3, line.X2);
            Assert.Equal(4, line.Y2);
        }

        /// <summary>
        ///     Tests that properties set values correctly
        /// </summary>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        [Theory, InlineData(0, 0, 0, 0), InlineData(-1, -2, -3, -4), InlineData(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue)]
        public void Properties_SetValuesCorrectly(int x1, int y1, int x2, int y2)
        {
            LineI line = new LineI {X1 = x1, Y1 = y1, X2 = x2, Y2 = y2};

            Assert.Equal(x1, line.X1);
            Assert.Equal(y1, line.Y1);
            Assert.Equal(x2, line.X2);
            Assert.Equal(y2, line.Y2);
        }
    }
}