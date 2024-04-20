// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RectangleTest.cs
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

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Figure;
using Xunit;

namespace Alis.Core.Physic.Test.Figure
{
    /// <summary>
    /// The rectangle test class
    /// </summary>
    public class RectangleTest
    {
        /// <summary>
        /// Tests that constructor test
        /// </summary>
        [Fact]
        public void ConstructorTest()
        {
            // Arrange
            float width = 2.0f;
            float height = 3.0f;
            Vector2 position = new Vector2(1, 1);
            Vector2 linearVelocity = new Vector2(0, 0);
            BodyType bodyType = BodyType.Static;
            float angle = 0;
            float angularVelocity = 0;
            float linearDamping = 0;
            float angularDamping = 0;
            bool allowSleep = true;
            bool awake = true;
            bool fixedRotation = false;
            bool isBullet = false;
            bool enabled = true;
            float gravityScale = 1;
            
            // Act
            Rectangle rectangle = new Rectangle(width, height, position, linearVelocity, bodyType, angle, angularVelocity, linearDamping, angularDamping, allowSleep, awake, fixedRotation, isBullet, enabled, gravityScale);
            
            // Assert
            Assert.Equal(position, rectangle.Position);
            Assert.Equal(linearVelocity, rectangle.LinearVelocity);
            Assert.Equal(bodyType, rectangle.BodyType);
            Assert.Equal(angularVelocity, rectangle.AngularVelocity);
            Assert.Equal(linearDamping, rectangle.LinearDamping);
            Assert.Equal(angularDamping, rectangle.AngularDamping);
            Assert.Equal(awake, rectangle.Awake);
            Assert.Equal(fixedRotation, rectangle.FixedRotation);
            Assert.Equal(isBullet, rectangle.IsBullet);
            Assert.Equal(enabled, rectangle.Enabled);
            Assert.Equal(gravityScale, rectangle.GravityScale);
        }
        
        /// <summary>
        /// Tests that constructor throws exception when width is zero or negative
        /// </summary>
        [Fact]
        public void ConstructorThrowsExceptionWhenWidthIsZeroOrNegative()
        {
            // Arrange
            float width = 0;
            float height = 1;
            Vector2 position = new Vector2(1, 1);
            Vector2 linearVelocity = new Vector2(0, 0);
            
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Rectangle(width, height, position, linearVelocity));
        }
        
        /// <summary>
        /// Tests that constructor throws exception when height is zero or negative
        /// </summary>
        [Fact]
        public void ConstructorThrowsExceptionWhenHeightIsZeroOrNegative()
        {
            // Arrange
            float width = 1;
            float height = 0;
            Vector2 position = new Vector2(1, 1);
            Vector2 linearVelocity = new Vector2(0, 0);
            
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Rectangle(width, height, position, linearVelocity));
        }
    }
}