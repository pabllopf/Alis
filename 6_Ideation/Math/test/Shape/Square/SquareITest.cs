// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SquareITest.cs
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
using Alis.Core.Aspect.Math.Shape.Square;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Shape.Square
{
    /// <summary>
    ///     The square test class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
	 public class SquareITest 
    {
        /// <summary>
        ///     Tests that constructor initializes properties correctly
        /// </summary>
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            SquareI square = new SquareI {X = 1, Y = 2, W = 3};

            Assert.Equal(1, square.X);
            Assert.Equal(2, square.Y);
            Assert.Equal(3, square.W);
        }

        /// <summary>
        ///     Tests that properties set values correctly
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="w">The </param>
        [Theory, InlineData(0, 0, 0), InlineData(-1, -1, -1), InlineData(int.MaxValue, int.MaxValue, int.MaxValue)]
        public void Properties_SetValuesCorrectly(int x, int y, int w)
        {
            SquareI square = new SquareI {X = x, Y = y, W = w};

            Assert.Equal(x, square.X);
            Assert.Equal(y, square.Y);
            Assert.Equal(w, square.W);
        }
    }
}