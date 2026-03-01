// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IRotationTest.cs
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

using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    ///     Unit tests for the IRotation interface.
    ///     Tests the Rotation method for rotation assignment.
    /// </summary>
    public class IRotationTest
    {
        /// <summary>
        ///     Tests that IRotation can be implemented.
        /// </summary>
        [Fact]
        public void IRotation_CanBeImplemented()
        {
            RotationBuilderImpl builder = new RotationBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IRotation<RotationBuilder, float>>(builder);
        }

        /// <summary>
        ///     Tests that Rotation sets value correctly.
        /// </summary>
        [Fact]
        public void Rotation_SetsValueCorrectly()
        {
            RotationBuilderImpl builder = new RotationBuilderImpl();
            RotationBuilder result = builder.Rotation(45f);
            Assert.Equal(45f, result.RotationValue);
        }

        /// <summary>
        ///     Tests that Rotation returns builder.
        /// </summary>
        [Fact]
        public void Rotation_ReturnsBuilder()
        {
            RotationBuilderImpl builder = new RotationBuilderImpl();
            RotationBuilder result = builder.Rotation(90f);
            Assert.NotNull(result);
            Assert.IsType<RotationBuilder>(result);
        }

        /// <summary>
        ///     Tests Rotation with full circle angle.
        /// </summary>
        [Theory, InlineData(0f), InlineData(90f), InlineData(180f), InlineData(270f), InlineData(360f)]
        public void Rotation_WithStandardAngles(float angle)
        {
            RotationBuilderImpl builder = new RotationBuilderImpl();
            RotationBuilder result = builder.Rotation(angle);
            Assert.Equal(angle, result.RotationValue);
        }

        /// <summary>
        ///     Tests Rotation with negative angles.
        /// </summary>
        [Fact]
        public void Rotation_WithNegativeAngle()
        {
            RotationBuilderImpl builder = new RotationBuilderImpl();
            RotationBuilder result = builder.Rotation(-45f);
            Assert.Equal(-45f, result.RotationValue);
        }

        /// <summary>
        ///     Helper builder class for rotation.
        /// </summary>
        private class RotationBuilder
        {
            /// <summary>
            /// Gets or sets the value of the rotation value
            /// </summary>
            public float RotationValue { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IRotation.
        /// </summary>
        private class RotationBuilderImpl : IRotation<RotationBuilder, float>
        {
            /// <summary>
            /// The rotation builder
            /// </summary>
            private readonly RotationBuilder _builder = new RotationBuilder();

            /// <summary>
            /// Rotations the value
            /// </summary>
            /// <param name="value">The value</param>
            /// <returns>The builder</returns>
            public RotationBuilder Rotation(float value)
            {
                _builder.RotationValue = value;
                return _builder;
            }
        }
    }
}