// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DistanceInputTest.cs
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

using Alis.Core.Aspect.Math;
using Alis.Core.Physic.Collision.Distance;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.Distance
{
    /// <summary>
    /// The distance input test class
    /// </summary>
    public class DistanceInputTest
    {
        /// <summary>
        /// Tests that proxy a property test
        /// </summary>
        [Fact]
        public void ProxyAPropertyTest()
        {
            // Arrange
            DistanceInput distanceInput = new DistanceInput();
            DistanceProxy proxyA = new DistanceProxy();
            
            // Act
            distanceInput.ProxyA = proxyA;
            
            // Assert
            Assert.Equal(proxyA, distanceInput.ProxyA);
        }
        
        /// <summary>
        /// Tests that proxy b property test
        /// </summary>
        [Fact]
        public void ProxyBPropertyTest()
        {
            // Arrange
            DistanceInput distanceInput = new DistanceInput();
            DistanceProxy proxyB = new DistanceProxy();
            
            // Act
            distanceInput.ProxyB = proxyB;
            
            // Assert
            Assert.Equal(proxyB, distanceInput.ProxyB);
        }
        
        /// <summary>
        /// Tests that transform a property test
        /// </summary>
        [Fact]
        public void TransformAPropertyTest()
        {
            // Arrange
            DistanceInput distanceInput = new DistanceInput();
            Transform transformA = new Transform();
            
            // Act
            distanceInput.TransformA = transformA;
            
            // Assert
            Assert.Equal(transformA, distanceInput.TransformA);
        }
        
        /// <summary>
        /// Tests that transform b property test
        /// </summary>
        [Fact]
        public void TransformBPropertyTest()
        {
            // Arrange
            DistanceInput distanceInput = new DistanceInput();
            Transform transformB = new Transform();
            
            // Act
            distanceInput.TransformB = transformB;
            
            // Assert
            Assert.Equal(transformB, distanceInput.TransformB);
        }
        
        /// <summary>
        /// Tests that use radii property test
        /// </summary>
        [Fact]
        public void UseRadiiPropertyTest()
        {
            // Arrange
            DistanceInput distanceInput = new DistanceInput();
            bool useRadii = true;
            
            // Act
            distanceInput.UseRadii = useRadii;
            
            // Assert
            Assert.Equal(useRadii, distanceInput.UseRadii);
        }
    }
}