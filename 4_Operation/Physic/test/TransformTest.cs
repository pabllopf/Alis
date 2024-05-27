// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TransformTest.cs
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
using Xunit;

namespace Alis.Core.Physic.Test
{
    /// <summary>
    ///     The transform test class
    /// </summary>
    public class TransformTest
    {
        /// <summary>
        ///     Tests that set identity should set to identity
        /// </summary>
        [Fact]
        public void SetIdentity_ShouldSetToIdentity()
        {
            // Arrange
            Transform transform = new Transform(new Vector2(0, 0), new Rotation(45), new Vector2(1, 1));
            
            // Act
            transform.SetIdentity();
            
            // Assert
            Assert.Equal(Vector2.Zero, transform.Position);
            Assert.Equal(45, transform.Rotation.Angle);
            Assert.Equal(Vector2.One, transform.Scale);
        }
        
        /// <summary>
        ///     Tests that set should set position and angle
        /// </summary>
        [Fact]
        public void Set_ShouldSetPositionAndAngle()
        {
            // Arrange
            Transform transform = new Transform();
            Vector2 position = new Vector2(1, 1);
            float angle = 45;
            
            // Act
            transform.Set(position, angle);
            
            // Assert
            Assert.Equal(position, transform.Position);
            Assert.Equal(angle, transform.Rotation.Angle);
        }
        
        /// <summary>
        ///     Tests that constructor should set position rotation and scale
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetPositionRotationAndScale()
        {
            // Arrange
            Vector2 position = new Vector2(1, 1);
            Rotation rotation = new Rotation(45);
            Vector2 scale = new Vector2(2, 2);
            
            // Act
            Transform transform = new Transform(position, rotation, scale);
            
            // Assert
            Assert.Equal(position, transform.Position);
            Assert.Equal(rotation.Angle, transform.Rotation.Angle);
            Assert.Equal(scale, transform.Scale);
        }
    }
}