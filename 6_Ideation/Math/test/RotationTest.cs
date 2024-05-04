// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RotationTest.cs
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
using Xunit;

namespace Alis.Core.Aspect.Math.Test
{
    /// <summary>
    ///     The rotation test class
    /// </summary>
    public class RotationTest
    {
        /// <summary>
        ///     Tests that constructor should set angle and calculate sine and cosine
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetAngleAndCalculateSineAndCosine()
        {
            // Arrange
            float angle = 45;
            
            // Act
            Rotation rotation = new Rotation(angle);
            
            // Assert
            Assert.Equal(angle, rotation.Angle);
            Assert.Equal((float) System.Math.Sin(angle), rotation.Sine);
            Assert.Equal((float) System.Math.Cos(angle), rotation.Cosine);
        }
        
        /// <summary>
        ///     Tests that set should set angle and calculate sine and cosine
        /// </summary>
        [Fact]
        public void Set_ShouldSetAngleAndCalculateSineAndCosine()
        {
            // Arrange
            Rotation rotation = new Rotation();
            float angle = 45;
            
            // Act
            rotation.Set(angle);
            
            // Assert
            Assert.Equal(angle, rotation.Angle);
            Assert.Equal((float) System.Math.Sin(angle), rotation.Sine);
            Assert.Equal((float) System.Math.Cos(angle), rotation.Cosine);
        }
        
        /// <summary>
        ///     Tests that set identity should set to identity
        /// </summary>
        [Fact]
        public void SetIdentity_ShouldSetToIdentity()
        {
            // Arrange
            Rotation rotation = new Rotation(45);
            
            // Act
            rotation.SetIdentity();
            
            // Assert
            Assert.Equal(0, rotation.Sine);
            Assert.Equal(1, rotation.Cosine);
        }
        
        /// <summary>
        ///     Tests that get angle should return angle in radians
        /// </summary>
        [Fact]
        public void GetAngle_ShouldReturnAngleInRadians()
        {
            // Arrange
            float angle = 45;
            Rotation rotation = new Rotation(angle);
            
            // Act
            float result = rotation.GetAngle();
            
            // Assert
            Assert.Equal((float) System.Math.Atan2(rotation.Sine, rotation.Cosine), result);
        }
        
        /// <summary>
        ///     Tests that get x axis should return x axis
        /// </summary>
        [Fact]
        public void GetXAxis_ShouldReturnXAxis()
        {
            // Arrange
            float angle = 45;
            Rotation rotation = new Rotation(angle);
            
            // Act
            Vector2 result = rotation.GetXAxis();
            
            // Assert
            Assert.Equal(new Vector2(rotation.Cosine, rotation.Sine), result);
        }
        
        /// <summary>
        ///     Tests that get y axis should return y axis
        /// </summary>
        [Fact]
        public void GetYAxis_ShouldReturnYAxis()
        {
            // Arrange
            float angle = 45;
            Rotation rotation = new Rotation(angle);
            
            // Act
            Vector2 result = rotation.GetYAxis();
            
            // Assert
            Assert.Equal(new Vector2(-rotation.Sine, rotation.Cosine), result);
        }
        
        /// <summary>
        ///     Tests that set should calculate correctly when angle is zero
        /// </summary>
        [Fact]
        public void Set_ShouldCalculateCorrectly_WhenAngleIsZero()
        {
            // Arrange
            float angle = 0;
            
            // Act
            Rotation rotation = new Rotation();
            rotation.Set(angle);
            
            // Assert
            Assert.Equal(0, rotation.Sine);
            Assert.Equal(1, rotation.Cosine);
        }
        
        /// <summary>
        ///     Tests that set should calculate correctly when angle is not zero
        /// </summary>
        [Fact]
        public void Set_ShouldCalculateCorrectly_WhenAngleIsNotZero()
        {
            // Arrange
            float angle = CustomMathF.Pi / 2; // 90 degrees
            
            // Act
            Rotation rotation = new Rotation();
            rotation.Set(angle);
            
            // Assert
            Assert.Equal(1, rotation.Sine, 5);
            Assert.Equal(0, rotation.Cosine, 5);
        }
    }
}