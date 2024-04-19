// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ShapeCastInputTest.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.Distance;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.Distance
{
    /// <summary>
    /// The shape cast input test class
    /// </summary>
    public class ShapeCastInputTest
    {
        /// <summary>
        /// Tests that proxy a property test
        /// </summary>
        [Fact]
        public void ProxyAPropertyTest()
        {
            // Arrange
            ShapeCastInput shapeCastInput = new ShapeCastInput();
            DistanceProxy proxyA = new DistanceProxy();
            
            // Act
            shapeCastInput.ProxyA = proxyA;
            
            // Assert
            Assert.Equal(proxyA, shapeCastInput.ProxyA);
        }
        
        /// <summary>
        /// Tests that proxy b property test
        /// </summary>
        [Fact]
        public void ProxyBPropertyTest()
        {
            // Arrange
            ShapeCastInput shapeCastInput = new ShapeCastInput();
            DistanceProxy proxyB = new DistanceProxy();
            
            // Act
            shapeCastInput.ProxyB = proxyB;
            
            // Assert
            Assert.Equal(proxyB, shapeCastInput.ProxyB);
        }
        
        /// <summary>
        /// Tests that transform a property test
        /// </summary>
        [Fact]
        public void TransformAPropertyTest()
        {
            // Arrange
            ShapeCastInput shapeCastInput = new ShapeCastInput();
            Transform transformA = new Transform();
            
            // Act
            shapeCastInput.TransformA = transformA;
            
            // Assert
            Assert.Equal(transformA, shapeCastInput.TransformA);
        }
        
        /// <summary>
        /// Tests that transform b property test
        /// </summary>
        [Fact]
        public void TransformBPropertyTest()
        {
            // Arrange
            ShapeCastInput shapeCastInput = new ShapeCastInput();
            Transform transformB = new Transform();
            
            // Act
            shapeCastInput.TransformB = transformB;
            
            // Assert
            Assert.Equal(transformB, shapeCastInput.TransformB);
        }
        
        /// <summary>
        /// Tests that translation b property test
        /// </summary>
        [Fact]
        public void TranslationBPropertyTest()
        {
            // Arrange
            ShapeCastInput shapeCastInput = new ShapeCastInput();
            Vector2 translationB = new Vector2(1, 1);
            
            // Act
            shapeCastInput.TranslationB = translationB;
            
            // Assert
            Assert.Equal(translationB, shapeCastInput.TranslationB);
        }
    }
}