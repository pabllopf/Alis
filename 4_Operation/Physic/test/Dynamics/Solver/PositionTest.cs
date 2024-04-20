// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PositionTest.cs
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
using Alis.Core.Physic.Dynamics.Solver;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Solver
{
    /// <summary>
    /// The position test class
    /// </summary>
    public class PositionTest
    {
        /// <summary>
        /// Tests that position constructor test
        /// </summary>
        [Fact]
        public void PositionConstructorTest()
        {
            // Arrange
            Vector2 c = new Vector2(1.0f, 1.0f);
            float a = 0.5f;
            
            // Act
            Position position = new Position(c, a);
            
            // Assert
            Assert.Equal(c, position.C);
            Assert.Equal(a, position.A);
        }
        
        /// <summary>
        /// Tests that position default constructor test
        /// </summary>
        [Fact]
        public void PositionDefaultConstructorTest()
        {
            // Act
            Position position = new Position();
            
            // Assert
            Assert.Equal(Vector2.Zero, position.C);
            Assert.Equal(0.0f, position.A);
        }
        
        /// <summary>
        /// Tests that position c property test
        /// </summary>
        [Fact]
        public void PositionCPropertyTest()
        {
            // Arrange
            Vector2 c = new Vector2(1.0f, 1.0f);
            Position position = new Position(c, 0.5f);
            
            // Act
            Vector2 newC = new Vector2(2.0f, 2.0f);
            position.C = newC;
            
            // Assert
            Assert.Equal(newC, position.C);
        }
        
        /// <summary>
        /// Tests that position a property test
        /// </summary>
        [Fact]
        public void PositionAPropertyTest()
        {
            // Arrange
            float a = 0.5f;
            Position position = new Position(new Vector2(1.0f, 1.0f), a);
            
            // Act
            float newA = 1.0f;
            position.A = newA;
            
            // Assert
            Assert.Equal(newA, position.A);
        }
    }
}