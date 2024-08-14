// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VelocityTest.cs
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
    ///     The velocity test class
    /// </summary>
    public class VelocityTest
    {
        /// <summary>
        ///     Tests that velocity constructor test
        /// </summary>
        [Fact]
        public void VelocityConstructorTest()
        {
            // Arrange
            Vector2 v = new Vector2(1.0f, 1.0f);
            float w = 0.5f;
            
            // Act
            Velocity velocity = new Velocity(v, w);
            
            // Assert
            Assert.Equal(v, velocity.V);
            Assert.Equal(w, velocity.W);
        }
        
        /// <summary>
        ///     Tests that velocity v property test
        /// </summary>
        [Fact]
        public void VelocityVPropertyTest()
        {
            // Arrange
            Vector2 v = new Vector2(1.0f, 1.0f);
            Velocity velocity = new Velocity(v, 0.5f);
            
            // Act
            Vector2 newV = new Vector2(2.0f, 2.0f);
            velocity.V = newV;
            
            // Assert
            Assert.Equal(newV, velocity.V);
        }
        
        /// <summary>
        ///     Tests that velocity w property test
        /// </summary>
        [Fact]
        public void VelocityWPropertyTest()
        {
            // Arrange
            float w = 0.5f;
            Velocity velocity = new Velocity(new Vector2(1.0f, 1.0f), w);
            
            // Act
            float newW = 1.0f;
            velocity.W = newW;
            
            // Assert
            Assert.Equal(newW, velocity.W);
        }
    }
}