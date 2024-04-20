// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ToiInputTest.cs
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

using Alis.Core.Physic.Collision.Distance;
using Alis.Core.Physic.Collision.TOI;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.TOI
{
    /// <summary>
    /// The toi input test class
    /// </summary>
    public class ToiInputTest
    {
        /// <summary>
        /// Tests that test toi input proxy a property
        /// </summary>
        [Fact]
        public void TestToiInputProxyAProperty()
        {
            // Arrange
            ToiInput toiInput = new ToiInput();
            DistanceProxy expectedValue = new DistanceProxy();
            
            // Act
            toiInput.ProxyA = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, toiInput.ProxyA);
        }
        
        /// <summary>
        /// Tests that test toi input proxy b property
        /// </summary>
        [Fact]
        public void TestToiInputProxyBProperty()
        {
            // Arrange
            ToiInput toiInput = new ToiInput();
            DistanceProxy expectedValue = new DistanceProxy();
            
            // Act
            toiInput.ProxyB = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, toiInput.ProxyB);
        }
        
        /// <summary>
        /// Tests that test toi input sweep a property
        /// </summary>
        [Fact]
        public void TestToiInputSweepAProperty()
        {
            // Arrange
            ToiInput toiInput = new ToiInput();
            Sweep expectedValue = new Sweep();
            
            // Act
            toiInput.SweepA = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, toiInput.SweepA);
        }
        
        /// <summary>
        /// Tests that test toi input sweep b property
        /// </summary>
        [Fact]
        public void TestToiInputSweepBProperty()
        {
            // Arrange
            ToiInput toiInput = new ToiInput();
            Sweep expectedValue = new Sweep();
            
            // Act
            toiInput.SweepB = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, toiInput.SweepB);
        }
        
        /// <summary>
        /// Tests that test toi input max property
        /// </summary>
        [Fact]
        public void TestToiInputMaxProperty()
        {
            // Arrange
            ToiInput toiInput = new ToiInput();
            float expectedValue = 0.5f;
            
            // Act
            toiInput.Max = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, toiInput.Max);
        }
    }
}