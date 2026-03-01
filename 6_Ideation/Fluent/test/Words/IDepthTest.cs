// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IDepthTest.cs
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
    ///     Unit tests for the IDepth interface.
    ///     Tests the Depth method for rendering depth/z-order assignment.
    /// </summary>
    public class IDepthTest
    {
        /// <summary>
        ///     Tests that IDepth can be implemented.
        /// </summary>
        [Fact]
        public void IDepth_CanBeImplemented()
        {
            DepthBuilderImpl builder = new DepthBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IDepth<DepthBuilder, int>>(builder);
        }

        /// <summary>
        ///     Tests that Depth sets value correctly.
        /// </summary>
        [Fact]
        public void Depth_SetsValueCorrectly()
        {
            DepthBuilderImpl builder = new DepthBuilderImpl();
            DepthBuilder result = builder.Depth(10);
            Assert.Equal(10, result.DepthValue);
        }

        /// <summary>
        ///     Tests that Depth returns builder.
        /// </summary>
        [Fact]
        public void Depth_ReturnsBuilder()
        {
            DepthBuilderImpl builder = new DepthBuilderImpl();
            DepthBuilder result = builder.Depth(5);
            Assert.NotNull(result);
            Assert.IsType<DepthBuilder>(result);
        }

        /// <summary>
        ///     Tests Depth with various values.
        /// </summary>
        [Theory, InlineData(0), InlineData(1), InlineData(100), InlineData(-10)]
        public void Depth_WithVariousValues(int depth)
        {
            DepthBuilderImpl builder = new DepthBuilderImpl();
            DepthBuilder result = builder.Depth(depth);
            Assert.Equal(depth, result.DepthValue);
        }

        /// <summary>
        ///     Helper builder class for depth.
        /// </summary>
        private class DepthBuilder
        {
            /// <summary>
            /// Gets or sets the value of the depth value
            /// </summary>
            public int DepthValue { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IDepth.
        /// </summary>
        private class DepthBuilderImpl : IDepth<DepthBuilder, int>
        {
            /// <summary>
            /// The depth builder
            /// </summary>
            private readonly DepthBuilder _builder = new DepthBuilder();

            /// <summary>
            /// Depths the value
            /// </summary>
            /// <param name="value">The value</param>
            /// <returns>The builder</returns>
            public DepthBuilder Depth(int value)
            {
                _builder.DepthValue = value;
                return _builder;
            }
        }
    }
}