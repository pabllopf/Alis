// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: IVolumeTest.cs
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
    ///     Unit tests for the IVolume interface.
    ///     Tests the Volume method for volume control.
    /// </summary>
    public class IVolumeTest
    {
        /// <summary>
        ///     Helper builder class for volume.
        /// </summary>
        private class VolumeBuilder
        {
            public float VolumeLevel { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IVolume.
        /// </summary>
        private class VolumeBuilderImpl : IVolume<VolumeBuilder, float>
        {
            private readonly VolumeBuilder _builder = new VolumeBuilder();

            public VolumeBuilder Volume(float value)
            {
                _builder.VolumeLevel = value;
                return _builder;
            }
        }

        /// <summary>
        ///     Tests that IVolume can be implemented.
        /// </summary>
        [Fact]
        public void IVolume_CanBeImplemented()
        {
            VolumeBuilderImpl builder = new VolumeBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IVolume<VolumeBuilder, float>>(builder);
        }

        /// <summary>
        ///     Tests that Volume sets level correctly.
        /// </summary>
        [Fact]
        public void Volume_SetsLevelCorrectly()
        {
            VolumeBuilderImpl builder = new VolumeBuilderImpl();
            VolumeBuilder result = builder.Volume(0.5f);
            Assert.Equal(0.5f, result.VolumeLevel);
        }

        /// <summary>
        ///     Tests that Volume returns builder.
        /// </summary>
        [Fact]
        public void Volume_ReturnsBuilder()
        {
            VolumeBuilderImpl builder = new VolumeBuilderImpl();
            VolumeBuilder result = builder.Volume(0.8f);
            Assert.NotNull(result);
            Assert.IsType<VolumeBuilder>(result);
        }

        /// <summary>
        ///     Tests Volume with valid range (0 to 1).
        /// </summary>
        [Theory]
        [InlineData(0f)]
        [InlineData(0.25f)]
        [InlineData(0.5f)]
        [InlineData(0.75f)]
        [InlineData(1f)]
        public void Volume_WithValidRange(float level)
        {
            VolumeBuilderImpl builder = new VolumeBuilderImpl();
            VolumeBuilder result = builder.Volume(level);
            Assert.Equal(level, result.VolumeLevel);
        }

        /// <summary>
        ///     Tests Volume with extreme values.
        /// </summary>
        [Fact]
        public void Volume_WithExtremeValues()
        {
            VolumeBuilderImpl builder = new VolumeBuilderImpl();
            VolumeBuilder resultMin = builder.Volume(0f);
            Assert.Equal(0f, resultMin.VolumeLevel);
            VolumeBuilder resultMax = builder.Volume(1f);
            Assert.Equal(1f, resultMax.VolumeLevel);
        }
    }
}

