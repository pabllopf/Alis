// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SolverPositionTest.cs
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
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The solver position test class
    /// </summary>
    public class SolverPositionTest
    {
        /// <summary>
        ///     Tests that default constructor should initialize with default values
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeWithDefaultValues()
        {
            SolverPosition position = new SolverPosition();
            
            Assert.Equal(Vector2F.Zero, position.C);
            Assert.Equal(0.0f, position.A);
        }

        /// <summary>
        ///     Tests that c property should set and get correctly
        /// </summary>
        [Fact]
        public void CProperty_ShouldSetAndGetCorrectly()
        {
            SolverPosition position = new SolverPosition
            {
                C = new Vector2F(5.0f, 10.0f)
            };
            
            Assert.Equal(5.0f, position.C.X);
            Assert.Equal(10.0f, position.C.Y);
        }

        /// <summary>
        ///     Tests that a property should set and get correctly
        /// </summary>
        [Fact]
        public void AProperty_ShouldSetAndGetCorrectly()
        {
            SolverPosition position = new SolverPosition
            {
                A = 1.5707f // ~PI/2
            };
            
            Assert.Equal(1.5707f, position.A);
        }

        /// <summary>
        ///     Tests that solver position should support negative angle
        /// </summary>
        [Fact]
        public void SolverPosition_ShouldSupportNegativeAngle()
        {
            SolverPosition position = new SolverPosition
            {
                A = -3.14159f
            };
            
            Assert.Equal(-3.14159f, position.A);
        }

        /// <summary>
        ///     Tests that solver position should support negative coordinates
        /// </summary>
        [Fact]
        public void SolverPosition_ShouldSupportNegativeCoordinates()
        {
            SolverPosition position = new SolverPosition
            {
                C = new Vector2F(-10.0f, -20.0f)
            };
            
            Assert.Equal(-10.0f, position.C.X);
            Assert.Equal(-20.0f, position.C.Y);
        }

        /// <summary>
        ///     Tests that solver position should be value type
        /// </summary>
        [Fact]
        public void SolverPosition_ShouldBeValueType()
        {
            SolverPosition position1 = new SolverPosition { A = 1.0f };
            SolverPosition position2 = position1;
            
            position2.A = 2.0f;
            
            Assert.NotEqual(position1.A, position2.A);
        }

        /// <summary>
        ///     Tests that solver position should handle zero values
        /// </summary>
        [Fact]
        public void SolverPosition_ShouldHandleZeroValues()
        {
            SolverPosition position = new SolverPosition
            {
                C = Vector2F.Zero,
                A = 0.0f
            };
            
            Assert.Equal(Vector2F.Zero, position.C);
            Assert.Equal(0.0f, position.A);
        }

        /// <summary>
        ///     Tests that solver position should handle large coordinate values
        /// </summary>
        [Fact]
        public void SolverPosition_ShouldHandleLargeCoordinateValues()
        {
            SolverPosition position = new SolverPosition
            {
                C = new Vector2F(1000.0f, 2000.0f),
                A = 10.0f
            };
            
            Assert.Equal(1000.0f, position.C.X);
            Assert.Equal(2000.0f, position.C.Y);
            Assert.Equal(10.0f, position.A);
        }

        /// <summary>
        ///     Tests that solver position should support full rotation range
        /// </summary>
        [Fact]
        public void SolverPosition_ShouldSupportFullRotationRange()
        {
            SolverPosition position = new SolverPosition
            {
                A = 6.28318f // 2*PI
            };
            
            Assert.True(position.A > 0);
        }
    }
}

