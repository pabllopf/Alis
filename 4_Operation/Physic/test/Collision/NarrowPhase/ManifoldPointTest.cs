// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ManifoldPointTest.cs
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
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Collision.NarrowPhase;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.NarrowPhase
{
    /// <summary>
    /// The manifold point test class
    /// </summary>
    public class ManifoldPointTest
    {
        /// <summary>
        /// Tests that test local point property
        /// </summary>
        [Fact]
        public void Test_LocalPointProperty()
        {
            // Arrange
            ManifoldPoint manifoldPoint = new ManifoldPoint();
            Vector2 expectedValue = new Vector2(1, 1);
            
            // Act
            manifoldPoint.LocalPoint = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, manifoldPoint.LocalPoint);
        }
        
        /// <summary>
        /// Tests that test normal impulse property
        /// </summary>
        [Fact]
        public void Test_NormalImpulseProperty()
        {
            // Arrange
            ManifoldPoint manifoldPoint = new ManifoldPoint();
            float expectedValue = 1.5f;
            
            // Act
            manifoldPoint.NormalImpulse = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, manifoldPoint.NormalImpulse);
        }
        
        /// <summary>
        /// Tests that test tangent impulse property
        /// </summary>
        [Fact]
        public void Test_TangentImpulseProperty()
        {
            // Arrange
            ManifoldPoint manifoldPoint = new ManifoldPoint();
            float expectedValue = 1.5f;
            
            // Act
            manifoldPoint.TangentImpulse = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, manifoldPoint.TangentImpulse);
        }
        
        /// <summary>
        /// Tests that test id property
        /// </summary>
        [Fact]
        public void Test_IdProperty()
        {
            // Arrange
            ManifoldPoint manifoldPoint = new ManifoldPoint();
            ContactId expectedValue = new ContactId();
            
            // Act
            manifoldPoint.Id = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, manifoldPoint.Id);
        }
    }
}