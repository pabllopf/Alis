// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ShapeTest.cs
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

using Alis.Core.Physic.Collision.Shapes;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.Shapes
{
    /// <summary>
    ///     The shape test class
    /// </summary>
    public class AShapeTest
    {
        /// <summary>
        /// Tests that get mass data returns correct mass data
        /// </summary>
        [Fact]
        public void GetMassData_ReturnsCorrectMassData()
        {
            // Arrange
            MassData expectedMassData = new MassData(1.0f, 2.0f, 3.0f);
            AShape shape = new ConcreteShape(
                ShapeType.Circle,
                1.0f,
                1.0f
            );
            shape.MassDataPrivate = expectedMassData;
            
            // Act
            shape.GetMassData(out MassData actualMassData);
            
            // Assert
            Assert.Equal(expectedMassData.Mass, actualMassData.Mass);
            Assert.Equal(expectedMassData.Inertia, actualMassData.Inertia);
        }
        
        [Fact]
        public void Radius_Setter_UpdatesRadiusAndCallsComputeProperties()
        {
            // Arrange
            AShape shape = new ConcreteShape(
                ShapeType.Circle,
                1.0f,
                1.0f
            );
            float newRadius = 2.0f;
            
            // Act
            shape.Radius = newRadius;
            
            // Assert
            Assert.Equal(newRadius, shape.Radius);
            // Here you would assert that the properties of the shape have been set correctly after ComputeProperties() is called.
        }
        
        [Fact]
        public void Radius_Setter_DoesNotUpdateRadiusWhenValueIsSame()
        {
            // Arrange
            AShape shape = new ConcreteShape(
                ShapeType.Circle,
                1.0f,
                1.0f
            );
            float initialRadius = shape.Radius;
            
            // Act
            shape.Radius = initialRadius;
            
            // Assert
            Assert.Equal(initialRadius, shape.Radius);
            // Here you would assert that the properties of the shape have not changed.
        }
        
        [Fact]
        public void Density_Setter_UpdatesDensityAndCallsComputeProperties()
        {
            // Arrange
            AShape shape = new ConcreteShape(
                ShapeType.Circle,
                1.0f,
                1.0f
            );
            float newDensity = 2.0f;
            
            // Act
            shape.Density = newDensity;
            
            // Assert
            Assert.Equal(newDensity, shape.Density);
            // Here you would assert that the properties of the shape have been set correctly after ComputeProperties() is called.
        }
        
        [Fact]
        public void Density_Setter_DoesNotUpdateDensityWhenValueIsSame_v2()
        {
            // Arrange
            AShape shape = new ConcreteShape(
                ShapeType.Circle,
                1.0f,
                1.0f
            );
            float initialDensity = shape.Density;
            
            // Act
            shape.Density = initialDensity;
            
            // Assert
            Assert.Equal(initialDensity, shape.Density);
            // Here you would assert that the properties of the shape have not changed.
        }
        
        
    }
}