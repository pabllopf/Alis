// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IAngularVelocityTest.cs
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
    ///     Unit tests for the IAngularVelocity interface.
    ///     Tests the AngularVelocity method for rotation speed assignment.
    /// </summary>
    public class IAngularVelocityTest
    {
        /// <summary>
        ///     Tests that IAngularVelocity can be implemented.
        /// </summary>
        [Fact]
        public void IAngularVelocity_CanBeImplemented()
        {
            AngularVelocityBuilderImpl builder = new AngularVelocityBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IAngularVelocity<AngularVelocityBuilder, float>>(builder);
        }

        /// <summary>
        ///     Tests that AngularVelocity sets value correctly.
        /// </summary>
        [Fact]
        public void AngularVelocity_SetsValueCorrectly()
        {
            AngularVelocityBuilderImpl builder = new AngularVelocityBuilderImpl();
            AngularVelocityBuilder result = builder.AngularVelocity(45f);
            Assert.Equal(45f, result.AngularVelocityValue);
        }

        /// <summary>
        ///     Tests that AngularVelocity returns builder.
        /// </summary>
        [Fact]
        public void AngularVelocity_ReturnsBuilder()
        {
            AngularVelocityBuilderImpl builder = new AngularVelocityBuilderImpl();
            AngularVelocityBuilder result = builder.AngularVelocity(90f);
            Assert.NotNull(result);
            Assert.IsType<AngularVelocityBuilder>(result);
        }

        /// <summary>
        ///     Tests AngularVelocity with various rotation speeds.
        /// </summary>
        [Theory, InlineData(0f), InlineData(45f), InlineData(90f), InlineData(180f), InlineData(360f)]
        public void AngularVelocity_WithVariousRotationSpeeds(float velocity)
        {
            AngularVelocityBuilderImpl builder = new AngularVelocityBuilderImpl();
            AngularVelocityBuilder result = builder.AngularVelocity(velocity);
            Assert.Equal(velocity, result.AngularVelocityValue);
        }

        /// <summary>
        ///     Helper builder class for angular velocity.
        /// </summary>
        private class AngularVelocityBuilder
        {
            public float AngularVelocityValue { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IAngularVelocity.
        /// </summary>
        private class AngularVelocityBuilderImpl : IAngularVelocity<AngularVelocityBuilder, float>
        {
            private readonly AngularVelocityBuilder _builder = new AngularVelocityBuilder();

            public AngularVelocityBuilder AngularVelocity(float value)
            {
                _builder.AngularVelocityValue = value;
                return _builder;
            }
        }
    }
}