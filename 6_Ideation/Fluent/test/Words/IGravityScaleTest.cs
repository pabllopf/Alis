// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: IGravityScaleTest.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
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
    ///     Unit tests for the IGravityScale interface.
    ///     Tests the GravityScale method for gravity multiplier assignment.
    /// </summary>
    public class IGravityScaleTest
    {
        /// <summary>
        ///     Helper builder class for gravity scale.
        /// </summary>
        private class GravityScaleBuilder
        {
            public float GravityScaleValue { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IGravityScale.
        /// </summary>
        private class GravityScaleBuilderImpl : IGravityScale<GravityScaleBuilder, float>
        {
            private readonly GravityScaleBuilder _builder = new GravityScaleBuilder();

            public GravityScaleBuilder GravityScale(float value)
            {
                _builder.GravityScaleValue = value;
                return _builder;
            }
        }

        /// <summary>
        ///     Tests that IGravityScale can be implemented.
        /// </summary>
        [Fact]
        public void IGravityScale_CanBeImplemented()
        {
            GravityScaleBuilderImpl builder = new GravityScaleBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IGravityScale<GravityScaleBuilder, float>>(builder);
        }

        /// <summary>
        ///     Tests that GravityScale sets value correctly.
        /// </summary>
        [Fact]
        public void GravityScale_SetsValueCorrectly()
        {
            GravityScaleBuilderImpl builder = new GravityScaleBuilderImpl();
            GravityScaleBuilder result = builder.GravityScale(2f);
            Assert.Equal(2f, result.GravityScaleValue);
        }

        /// <summary>
        ///     Tests that GravityScale returns builder.
        /// </summary>
        [Fact]
        public void GravityScale_ReturnsBuilder()
        {
            GravityScaleBuilderImpl builder = new GravityScaleBuilderImpl();
            GravityScaleBuilder result = builder.GravityScale(0.5f);
            Assert.NotNull(result);
            Assert.IsType<GravityScaleBuilder>(result);
        }

        /// <summary>
        ///     Tests GravityScale with various multipliers.
        /// </summary>
        [Theory]
        [InlineData(0f)]
        [InlineData(0.5f)]
        [InlineData(1f)]
        [InlineData(2f)]
        [InlineData(5f)]
        public void GravityScale_WithVariousMultipliers(float scale)
        {
            GravityScaleBuilderImpl builder = new GravityScaleBuilderImpl();
            GravityScaleBuilder result = builder.GravityScale(scale);
            Assert.Equal(scale, result.GravityScaleValue);
        }
    }
}

