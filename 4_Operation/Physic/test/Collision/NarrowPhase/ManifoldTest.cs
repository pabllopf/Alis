// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ManifoldTest.cs
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

using Alis.Core.Aspect.Math.Optimization;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.NarrowPhase;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.NarrowPhase
{
    /// <summary>
    ///     The manifold test class
    /// </summary>
    public class ManifoldTest
    {
        /// <summary>
        ///     Tests that test local normal property
        /// </summary>
        [Fact]
        public void Test_LocalNormalProperty()
        {
            // Arrange
            Manifold manifold = new Manifold();
            Vector2 expectedValue = new Vector2(1, 1);
            
            // Act
            manifold.LocalNormal = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, manifold.LocalNormal);
        }
        
        /// <summary>
        ///     Tests that test local point property
        /// </summary>
        [Fact]
        public void Test_LocalPointProperty()
        {
            // Arrange
            Manifold manifold = new Manifold();
            Vector2 expectedValue = new Vector2(1, 1);
            
            // Act
            manifold.LocalPoint = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, manifold.LocalPoint);
        }
        
        /// <summary>
        ///     Tests that test point count property
        /// </summary>
        [Fact]
        public void Test_PointCountProperty()
        {
            // Arrange
            Manifold manifold = new Manifold();
            int expectedValue = 2;
            
            // Act
            manifold.PointCount = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, manifold.PointCount);
        }
        
        /// <summary>
        ///     Tests that test points property
        /// </summary>
        [Fact]
        public void Test_PointsProperty()
        {
            // Arrange
            Manifold manifold = new Manifold();
            FixedArray2<ManifoldPoint> expectedValue = new FixedArray2<ManifoldPoint>();
            
            // Act
            manifold.Points = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, manifold.Points);
        }
        
        /// <summary>
        ///     Tests that test type property
        /// </summary>
        [Fact]
        public void Test_TypeProperty()
        {
            // Arrange
            Manifold manifold = new Manifold();
            ManifoldType expectedValue = ManifoldType.FaceA; // Assuming ManifoldType is an enum and FaceA is one of its values
            
            // Act
            manifold.Type = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, manifold.Type);
        }
    }
}