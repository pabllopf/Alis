// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SquareFTest.cs
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

using Alis.Core.Aspect.Math.Shape.Square;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Shape.Square
{
    /// <summary>
    ///     The square test class
    /// </summary>
    public class SquareFTest
    {
        /// <summary>
        ///     Tests that constructor initializes properties correctly
        /// </summary>
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            SquareF square = new SquareF {X = 1.0f, Y = 2.0f, W = 3.0f};

            Assert.Equal(1.0f, square.X);
            Assert.Equal(2.0f, square.Y);
            Assert.Equal(3.0f, square.W);
        }

        /// <summary>
        ///     Tests that properties set values correctly
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="w">The </param>
        [Theory, InlineData(0f, 0f, 0f), InlineData(-1f, -1f, -1f), InlineData(float.MaxValue, float.MaxValue, float.MaxValue)]
        public void Properties_SetValuesCorrectly(float x, float y, float w)
        {
            SquareF square = new SquareF {X = x, Y = y, W = w};

            Assert.Equal(x, square.X);
            Assert.Equal(y, square.Y);
            Assert.Equal(w, square.W);
        }
    }
}