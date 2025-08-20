// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CircleITest.cs
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


using Alis.Core.Aspect.Math.Shape.Circle;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Shape.Circle
{
    /// <summary>
    ///     The circle test class
    /// </summary>
    public class CircleITest
    {
        /// <summary>
        ///     Tests that constructor initializes properties correctly
        /// </summary>
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            CircleI circle = new CircleI {X = 1, Y = 2, R = 3};

            Assert.Equal(1, circle.X);
            Assert.Equal(2, circle.Y);
            Assert.Equal(3, circle.R);
        }

        /// <summary>
        ///     Tests that properties set values correctly
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="r">The </param>
        [Theory, InlineData(0, 0, 0), InlineData(-1, -1, 1), InlineData(int.MaxValue, int.MaxValue, int.MaxValue)]
        public void Properties_SetValuesCorrectly(int x, int y, int r)
        {
            CircleI circle = new CircleI {X = x, Y = y, R = r};

            Assert.Equal(x, circle.X);
            Assert.Equal(y, circle.Y);
            Assert.Equal(r, circle.R);
        }
    }
}