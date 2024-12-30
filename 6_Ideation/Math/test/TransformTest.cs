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

using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Core.Aspect.Math.Test
{
    /// <summary>
    ///     The transform test class
    /// </summary>
    public class TransformTest
    {
        /// <summary>
        ///     Tests that set should set position and angle
        /// </summary>
        [Fact]
        public void Set_ShouldSetPositionAndAngle()
        {
            // Arrange
            Transform transform = new Transform();
            Vector2F position = new Vector2F(1, 1);
            float angle = 45;

            // Act
            transform.Set(position, angle);

            // Assert
            Assert.Equal(position, transform.Position);
            Assert.Equal(angle, transform.Rotation);
        }

        /// <summary>
        ///     Tests that constructor should set position rotation and scale
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetPositionRotationAndScale()
        {
            // Arrange
            Vector2F position = new Vector2F(1, 1);
            float rotation = 45;
            Vector2F scale = new Vector2F(2, 2);

            // Act
            Transform transform = new Transform(position, rotation, scale);

            // Assert
            Assert.Equal(position, transform.Position);
            Assert.Equal(rotation, transform.Rotation);
            Assert.Equal(scale, transform.Scale);
        }

        /// <summary>
        ///     Tests that set sets position and angle correctly
        /// </summary>
        [Fact]
        public void Set_SetsPositionAndAngleCorrectly()
        {
            Transform transform = new Transform();
            Vector2F newPosition = new Vector2F(5, 6);
            float newAngle = 30;

            transform.Set(newPosition, newAngle);

            Assert.Equal(newPosition, transform.Position);
            Assert.Equal(newAngle, transform.Rotation);
        }
    }
}