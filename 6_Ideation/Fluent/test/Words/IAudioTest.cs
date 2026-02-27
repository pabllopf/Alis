// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: IAudioTest.cs
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
    ///     Unit tests for the IAudio interface.
    ///     Tests the Audio method for audio configuration.
    /// </summary>
    public class IAudioTest
    {
        /// <summary>
        ///     Helper builder class for audio.
        /// </summary>
        private class AudioBuilder
        {
            public string AudioConfig { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IAudio.
        /// </summary>
        private class AudioBuilderImpl : IAudio<AudioBuilder, string>
        {
            private readonly AudioBuilder _builder = new AudioBuilder();

            public AudioBuilder Audio(string value)
            {
                _builder.AudioConfig = value;
                return _builder;
            }
        }

        /// <summary>
        ///     Tests that IAudio can be implemented.
        /// </summary>
        [Fact]
        public void IAudio_CanBeImplemented()
        {
            AudioBuilderImpl builder = new AudioBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IAudio<AudioBuilder, string>>(builder);
        }

        /// <summary>
        ///     Tests that Audio sets configuration correctly.
        /// </summary>
        [Fact]
        public void Audio_SetsConfigurationCorrectly()
        {
            AudioBuilderImpl builder = new AudioBuilderImpl();
            AudioBuilder result = builder.Audio("Stereo");
            Assert.Equal("Stereo", result.AudioConfig);
        }

        /// <summary>
        ///     Tests that Audio returns builder.
        /// </summary>
        [Fact]
        public void Audio_ReturnsBuilder()
        {
            AudioBuilderImpl builder = new AudioBuilderImpl();
            AudioBuilder result = builder.Audio("Mono");
            Assert.NotNull(result);
            Assert.IsType<AudioBuilder>(result);
        }

        /// <summary>
        ///     Tests Audio with various configurations.
        /// </summary>
        [Theory]
        [InlineData("Mono")]
        [InlineData("Stereo")]
        [InlineData("Surround")]
        [InlineData("Spatial")]
        public void Audio_WithVariousConfigurations(string config)
        {
            AudioBuilderImpl builder = new AudioBuilderImpl();
            AudioBuilder result = builder.Audio(config);
            Assert.Equal(config, result.AudioConfig);
        }
    }
}

