// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ISpeedTest.cs
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
    ///     Unit tests for the ISpeed interface.
    ///     Tests the Speed method for velocity/speed assignment.
    /// </summary>
    public class ISpeedTest
    {
        /// <summary>
        ///     Tests that ISpeed can be implemented.
        /// </summary>
        [Fact]
        public void ISpeed_CanBeImplemented()
        {
            SpeedBuilderImpl builder = new SpeedBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<ISpeed<SpeedBuilder, float>>(builder);
        }

        /// <summary>
        ///     Tests that Speed sets value correctly.
        /// </summary>
        [Fact]
        public void Speed_SetsValueCorrectly()
        {
            SpeedBuilderImpl builder = new SpeedBuilderImpl();
            SpeedBuilder result = builder.Speed(5.5f);
            Assert.Equal(5.5f, result.SpeedValue);
        }

        /// <summary>
        ///     Tests that Speed returns builder.
        /// </summary>
        [Fact]
        public void Speed_ReturnsBuilder()
        {
            SpeedBuilderImpl builder = new SpeedBuilderImpl();
            SpeedBuilder result = builder.Speed(10f);
            Assert.NotNull(result);
            Assert.IsType<SpeedBuilder>(result);
        }

        /// <summary>
        ///     Tests Speed with realistic velocity values.
        /// </summary>
        [Theory, InlineData(0f), InlineData(5f), InlineData(10f), InlineData(30f)]
        public void Speed_WithRealisticValues(float speed)
        {
            SpeedBuilderImpl builder = new SpeedBuilderImpl();
            SpeedBuilder result = builder.Speed(speed);
            Assert.Equal(speed, result.SpeedValue);
        }

        /// <summary>
        ///     Helper builder class for speed.
        /// </summary>
        private class SpeedBuilder
        {
            /// <summary>
            /// Gets or sets the value of the speed value
            /// </summary>
            public float SpeedValue { get; set; }
        }

        /// <summary>
        ///     Helper implementation of ISpeed.
        /// </summary>
        private class SpeedBuilderImpl : ISpeed<SpeedBuilder, float>
        {
            /// <summary>
            /// The speed builder
            /// </summary>
            private readonly SpeedBuilder _builder = new SpeedBuilder();

            /// <summary>
            /// Speeds the value
            /// </summary>
            /// <param name="value">The value</param>
            /// <returns>The builder</returns>
            public SpeedBuilder Speed(float value)
            {
                _builder.SpeedValue = value;
                return _builder;
            }
        }
    }
}