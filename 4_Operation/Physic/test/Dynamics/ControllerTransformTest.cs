// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ControllerTransformTest.cs
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
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The controller transform test class
    /// </summary>
    public class ControllerTransformTest
    {
        /// <summary>
        ///     Tests that constructor with position and rotation should initialize correctly
        /// </summary>
        [Fact]
        public void Constructor_WithPositionAndRotation_ShouldInitializeCorrectly()
        {
            Vector2F position = new Vector2F(1.0f, 2.0f);
            Complex rotation = Complex.One;

            ControllerTransform transform = new ControllerTransform(position, rotation);

            Assert.Equal(position, transform.Position);
            Assert.Equal(rotation, transform.Rotation);
            Assert.Equal(Vector2F.One, transform.Scale);
        }

        /// <summary>
        ///     Tests that constructor with position rotation and scale should initialize correctly
        /// </summary>
        [Fact]
        public void Constructor_WithPositionRotationAndScale_ShouldInitializeCorrectly()
        {
            Vector2F position = new Vector2F(1.0f, 2.0f);
            Complex rotation = Complex.One;
            Vector2F scale = new Vector2F(2.0f, 2.0f);

            ControllerTransform transform = new ControllerTransform(position, rotation, scale);

            Assert.Equal(position, transform.Position);
            Assert.Equal(rotation, transform.Rotation);
            Assert.Equal(scale, transform.Scale);
        }

        /// <summary>
        ///     Tests that constructor with position and angle should initialize correctly
        /// </summary>
        [Fact]
        public void Constructor_WithPositionAndAngle_ShouldInitializeCorrectly()
        {
            Vector2F position = new Vector2F(1.0f, 2.0f);
            float angle = 0.5f;

            ControllerTransform transform = new ControllerTransform(position, angle);

            Assert.Equal(position, transform.Position);
            Assert.NotEqual(Complex.One, transform.Rotation);
        }

        /// <summary>
        ///     Tests that identity should return default transform
        /// </summary>
        [Fact]
        public void Identity_ShouldReturnDefaultTransform()
        {
            ControllerTransform identity = ControllerTransform.Identity;

            Assert.Equal(Vector2F.Zero, identity.Position);
            Assert.Equal(Complex.One, identity.Rotation);
        }

        /// <summary>
        ///     Tests that position should set and get correctly
        /// </summary>
        [Fact]
        public void Position_ShouldSetAndGetCorrectly()
        {
            ControllerTransform transform = new ControllerTransform();
            Vector2F position = new Vector2F(5.0f, 10.0f);

            transform.Position = position;

            Assert.Equal(position, transform.Position);
        }

        /// <summary>
        ///     Tests that rotation should set and get correctly
        /// </summary>
        [Fact]
        public void Rotation_ShouldSetAndGetCorrectly()
        {
            ControllerTransform transform = new ControllerTransform();
            Complex rotation = new Complex(0.5f, 0.5f);

            transform.Rotation = rotation;

            Assert.Equal(rotation, transform.Rotation);
        }

        /// <summary>
        ///     Tests that scale should set and get correctly
        /// </summary>
        [Fact]
        public void Scale_ShouldSetAndGetCorrectly()
        {
            ControllerTransform transform = new ControllerTransform();
            Vector2F scale = new Vector2F(2.0f, 3.0f);

            transform.Scale = scale;

            Assert.Equal(scale, transform.Scale);
        }

        /// <summary>
        ///     Tests that transform with zero position should work
        /// </summary>
        [Fact]
        public void Transform_WithZeroPosition_ShouldWork()
        {
            ControllerTransform transform = new ControllerTransform(Vector2F.Zero, Complex.One);

            Assert.Equal(Vector2F.Zero, transform.Position);
        }

        /// <summary>
        ///     Tests that transform with negative scale should work
        /// </summary>
        [Fact]
        public void Transform_WithNegativeScale_ShouldWork()
        {
            Vector2F scale = new Vector2F(-1.0f, -1.0f);
            ControllerTransform transform = new ControllerTransform(Vector2F.Zero, Complex.One, scale);

            Assert.Equal(scale, transform.Scale);
        }

        /// <summary>
        ///     Tests that multiply vector by identity transform should return same vector
        /// </summary>
        [Fact]
        public void Multiply_VectorByIdentity_ShouldReturnSameVector()
        {
            Vector2F vector = new Vector2F(3.0f, 4.0f);
            ControllerTransform transform = ControllerTransform.Identity;

            Vector2F result = ControllerTransform.Multiply(vector, ref transform);

            Assert.Equal(vector, result);
        }

        /// <summary>
        ///     Tests that multiply vector by transform with position should translate
        /// </summary>
        [Fact]
        public void Multiply_VectorByTransform_ShouldTranslate()
        {
            Vector2F vector = new Vector2F(1.0f, 2.0f);
            Vector2F position = new Vector2F(5.0f, 10.0f);
            ControllerTransform transform = new ControllerTransform(position, 0.0f);

            Vector2F result = ControllerTransform.Multiply(vector, ref transform);

            Assert.Equal(new Vector2F(6.0f, 12.0f), result);
        }

        /// <summary>
        ///     Tests that multiply vector by transform with rotation should rotate
        /// </summary>
        [Fact]
        public void Multiply_VectorByTransform_ShouldRotate()
        {
            Vector2F vector = new Vector2F(1.0f, 0.0f);
            ControllerTransform transform = new ControllerTransform(Vector2F.Zero, 90.0f);

            Vector2F result = ControllerTransform.Multiply(vector, ref transform);

            Assert.True(System.Math.Abs(result.X) < 0.01f);
            Assert.True(System.Math.Abs(result.Y - 1.0f) < 0.01f);
        }

        /// <summary>
        ///     Tests that divide vector by identity transform should return same vector
        /// </summary>
        [Fact]
        public void Divide_VectorByIdentity_ShouldReturnSameVector()
        {
            Vector2F vector = new Vector2F(3.0f, 4.0f);
            ControllerTransform transform = ControllerTransform.Identity;

            Vector2F result = ControllerTransform.Divide(vector, ref transform);

            Assert.Equal(vector, result);
        }

        /// <summary>
        ///     Tests that divide vector by transform with position should translate back
        /// </summary>
        [Fact]
        public void Divide_VectorByTransform_ShouldTranslateBack()
        {
            Vector2F vector = new Vector2F(6.0f, 12.0f);
            Vector2F position = new Vector2F(5.0f, 10.0f);
            ControllerTransform transform = new ControllerTransform(position, 0.0f);

            Vector2F result = ControllerTransform.Divide(vector, ref transform);

            Assert.Equal(new Vector2F(1.0f, 2.0f), result);
        }

        /// <summary>
        ///     Tests that divide vector with out parameter should work correctly
        /// </summary>
        [Fact]
        public void Divide_VectorWithOutParameter_ShouldWork()
        {
            Vector2F vector = new Vector2F(6.0f, 12.0f);
            Vector2F position = new Vector2F(5.0f, 10.0f);
            ControllerTransform transform = new ControllerTransform(position, 0.0f);

            ControllerTransform.Divide(vector, ref transform, out Vector2F result);

            Assert.Equal(new Vector2F(1.0f, 2.0f), result);
        }

        /// <summary>
        ///     Tests that multiply transform by identity should return same transform
        /// </summary>
        [Fact]
        public void Multiply_TransformByIdentity_ShouldReturnSameTransform()
        {
            ControllerTransform left = new ControllerTransform(new Vector2F(2.0f, 3.0f), 0.5f);
            ControllerTransform right = ControllerTransform.Identity;

            ControllerTransform result = ControllerTransform.Multiply(ref left, ref right);

            Assert.Equal(left.Position, result.Position);
            Assert.Equal(left.Rotation, result.Rotation);
        }

        /// <summary>
        ///     Tests that multiply two transforms should compose
        /// </summary>
        [Fact]
        public void Multiply_TwoTransforms_ShouldCompose()
        {
            ControllerTransform left = new ControllerTransform(new Vector2F(1.0f, 0.0f), 0.0f);
            ControllerTransform right = new ControllerTransform(new Vector2F(2.0f, 3.0f), 0.0f);

            ControllerTransform result = ControllerTransform.Multiply(ref left, ref right);

            Assert.Equal(new Vector2F(3.0f, 3.0f), result.Position);
        }

        /// <summary>
        ///     Tests that divide transform by itself should return identity
        /// </summary>
        [Fact]
        public void Divide_TransformByItself_ShouldReturnIdentity()
        {
            ControllerTransform transform = new ControllerTransform(new Vector2F(2.0f, 3.0f), 0.5f);

            ControllerTransform result = ControllerTransform.Divide(ref transform, ref transform);

            Assert.True(System.Math.Abs(result.Position.X) < 0.001f);
            Assert.True(System.Math.Abs(result.Position.Y) < 0.001f);
        }

        /// <summary>
        ///     Tests that divide transform with out parameter should work
        /// </summary>
        [Fact]
        public void Divide_TransformWithOutParameter_ShouldWork()
        {
            ControllerTransform left = new ControllerTransform(new Vector2F(5.0f, 6.0f), 0.5f);
            ControllerTransform right = new ControllerTransform(new Vector2F(2.0f, 3.0f), 0.25f);

            ControllerTransform.Divide(ref left, ref right, out ControllerTransform result);

            Assert.NotNull(result.Position);
            Assert.NotNull(result.Rotation);
        }

        /// <summary>
        ///     Tests that multiply transform by complex one should return same transform
        /// </summary>
        [Fact]
        public void Multiply_TransformByComplexOne_ShouldReturnSameTransform()
        {
            ControllerTransform transform = new ControllerTransform(new Vector2F(2.0f, 3.0f), 0.5f);

            ControllerTransform.Multiply(ref transform, Complex.One, out ControllerTransform result);

            Assert.Equal(transform.Position, result.Position);
            Assert.Equal(transform.Rotation, result.Rotation);
        }

        /// <summary>
        ///     Tests that divide transform by complex one should return same transform
        /// </summary>
        [Fact]
        public void Divide_TransformByComplexOne_ShouldReturnSameTransform()
        {
            ControllerTransform transform = new ControllerTransform(new Vector2F(2.0f, 3.0f), 0.5f);

            ControllerTransform.Divide(ref transform, Complex.One, out ControllerTransform result);

            Assert.Equal(transform.Position, result.Position);
            Assert.Equal(transform.Rotation, result.Rotation);
        }

        /// <summary>
        ///     Tests that constructor with position angle and scale should initialize correctly
        /// </summary>
        [Fact]
        public void Constructor_WithPositionAngleAndScale_ShouldInitializeCorrectly()
        {
            Vector2F position = new Vector2F(1.0f, 2.0f);
            float angle = 0.5f;
            Vector2F scale = new Vector2F(3.0f, 4.0f);

            ControllerTransform transform = new ControllerTransform(position, angle, scale);

            Assert.Equal(position, transform.Position);
            Assert.Equal(scale, transform.Scale);
        }

        /// <summary>
        ///     Tests that multiply ref vector by identity should return same vector
        /// </summary>
        [Fact]
        public void Multiply_RefVectorByIdentity_ShouldReturnSameVector()
        {
            Vector2F vector = new Vector2F(3.0f, 4.0f);
            ControllerTransform transform = ControllerTransform.Identity;

            Vector2F result = ControllerTransform.Multiply(ref vector, ref transform);

            Assert.Equal(vector, result);
        }

        /// <summary>
        ///     Tests that divide ref vector by identity should return same vector
        /// </summary>
        [Fact]
        public void Divide_RefVectorByIdentity_ShouldReturnSameVector()
        {
            Vector2F vector = new Vector2F(3.0f, 4.0f);
            ControllerTransform transform = ControllerTransform.Identity;

            Vector2F result = ControllerTransform.Divide(ref vector, ref transform);

            Assert.Equal(vector, result);
        }
    }
}