// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ILinearVelocityTest.cs
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
    ///     Unit tests for the ILinearVelocity interface.
    ///     Tests the LinearVelocity method for velocity assignment.
    /// </summary>
    public class ILinearVelocityTest
    {
        /// <summary>
        ///     Tests that ILinearVelocity can be implemented.
        /// </summary>
        [Fact]
        public void ILinearVelocity_CanBeImplemented()
        {
            LinearVelocityBuilderImpl builder = new LinearVelocityBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<ILinearVelocity<VelocityBuilder, float>>(builder);
        }

        /// <summary>
        ///     Tests that LinearVelocity sets values correctly.
        /// </summary>
        [Fact]
        public void LinearVelocity_SetsValuesCorrectly()
        {
            LinearVelocityBuilderImpl builder = new LinearVelocityBuilderImpl();
            VelocityBuilder result = builder.LinearVelocity(5f, 10f);
            Assert.Equal(5f, result.VelocityX);
            Assert.Equal(10f, result.VelocityY);
        }

        /// <summary>
        ///     Tests that LinearVelocity returns builder.
        /// </summary>
        [Fact]
        public void LinearVelocity_ReturnsBuilder()
        {
            LinearVelocityBuilderImpl builder = new LinearVelocityBuilderImpl();
            VelocityBuilder result = builder.LinearVelocity(2f, 3f);
            Assert.NotNull(result);
            Assert.IsType<VelocityBuilder>(result);
        }

        /// <summary>
        ///     Tests LinearVelocity with various values.
        /// </summary>
        [Theory, InlineData(0f, 0f), InlineData(5f, 5f), InlineData(-10f, 10f), InlineData(20f, -20f)]
        public void LinearVelocity_WithVariousValues(float x, float y)
        {
            LinearVelocityBuilderImpl builder = new LinearVelocityBuilderImpl();
            VelocityBuilder result = builder.LinearVelocity(x, y);
            Assert.Equal(x, result.VelocityX);
            Assert.Equal(y, result.VelocityY);
        }

        /// <summary>
        ///     Helper builder class for velocity.
        /// </summary>
        private class VelocityBuilder
        {
            public float VelocityX { get; set; }
            public float VelocityY { get; set; }
        }

        /// <summary>
        ///     Helper implementation of ILinearVelocity.
        /// </summary>
        private class LinearVelocityBuilderImpl : ILinearVelocity<VelocityBuilder, float>
        {
            private readonly VelocityBuilder _builder = new VelocityBuilder();

            public VelocityBuilder LinearVelocity(float x, float y)
            {
                _builder.VelocityX = x;
                _builder.VelocityY = y;
                return _builder;
            }
        }
    }
}