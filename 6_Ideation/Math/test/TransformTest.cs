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

using System.Runtime.Serialization;
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

        /// <summary>
        /// Tests that set identity sets position to zero and rotation to identity
        /// </summary>
        [Fact]
        public void SetIdentity_SetsPositionToZeroAndRotationToIdentity()
        {
            Transform transform = new Transform(new Vector2(1, 2), new Rotation(45), new Vector2(3, 4));
            transform.SetIdentity();

            Assert.Equal(Vector2.Zero, transform.Position);
            Assert.Equal(45, transform.Rotation.Angle);
        }

        /// <summary>
        /// Tests that set sets position and angle correctly
        /// </summary>
        [Fact]
        public void Set_SetsPositionAndAngleCorrectly()
        {
            Transform transform = new Transform();
            Vector2 newPosition = new Vector2(5, 6);
            float newAngle = 30;

            transform.Set(newPosition, newAngle);

            Assert.Equal(newPosition, transform.Position);
            Assert.Equal(newAngle, transform.Rotation.Angle);
        }

        /// <summary>
        /// Tests that get object data serializes properties correctly
        /// </summary>
        [Fact]
        public void GetObjectData_SerializesPropertiesCorrectly()
        {
            Transform transform = new Transform(new Vector2(1, 2), new Rotation(45), new Vector2(3, 4));
            SerializationInfo info = new SerializationInfo(typeof(Transform), new FormatterConverter());
            StreamingContext context = new StreamingContext();

            transform.GetObjectData(info, context);

            Assert.Equal(new Vector2(1, 2), (Vector2) info.GetValue("position", typeof(Vector2)));
            Assert.Equal(new Vector2(3, 4), (Vector2) info.GetValue("scale", typeof(Vector2)));
            Assert.Equal(new Rotation(45), (Rotation) info.GetValue("rotation", typeof(Rotation)));
        }
    }
}