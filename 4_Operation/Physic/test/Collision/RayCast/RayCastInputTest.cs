// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RayCastInputTest.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.RayCast;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.RayCast
{
    /// <summary>
    ///     The ray cast input test class
    /// </summary>
    public class RayCastInputTest
    {
        /// <summary>
        ///     Tests that test fraction
        /// </summary>
        [Fact]
        public void Test_Fraction()
        {
            // Arrange
            RayCastInput rayCastInput = new RayCastInput();
            float expected = 0.5f;

            // Act
            rayCastInput.Fraction = expected;

            // Assert
            Assert.Equal(expected, rayCastInput.Fraction);
        }

        /// <summary>
        ///     Tests that test point 1
        /// </summary>
        [Fact]
        public void Test_Point1()
        {
            // Arrange
            RayCastInput rayCastInput = new RayCastInput();
            Vector2 expected = new Vector2(1, 1);

            // Act
            rayCastInput.Point1 = expected;

            // Assert
            Assert.Equal(expected, rayCastInput.Point1);
        }

        /// <summary>
        ///     Tests that test point 2
        /// </summary>
        [Fact]
        public void Test_Point2()
        {
            // Arrange
            RayCastInput rayCastInput = new RayCastInput();
            Vector2 expected = new Vector2(2, 2);

            // Act
            rayCastInput.Point2 = expected;

            // Assert
            Assert.Equal(expected, rayCastInput.Point2);
        }
    }
}