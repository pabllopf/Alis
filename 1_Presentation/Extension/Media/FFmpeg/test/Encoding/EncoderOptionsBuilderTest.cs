// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EncoderOptionsBuilderTest.cs
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

using Alis.Extension.Media.FFmpeg.Encoding;
using Alis.Extension.Media.FFmpeg.Encoding.Builders;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Encoding
{
    /// <summary>
    ///     The encoder options builder test class
    /// </summary>
    /// <seealso cref="EncoderOptionsBuilder" />
    public class EncoderOptionsBuilderTest
    {
        /// <summary>
        ///     Tests that encoder options builder format property should be settable
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_FormatProperty_ShouldBeSettable()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();
            string format = "mkv";

            // Act
            encoder.Format = format;

            // Assert
            Assert.Equal(format, encoder.Format);
        }

        /// <summary>
        ///     Tests that encoder options builder name property should be readable
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_NameProperty_ShouldBeReadable()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();

            // Act
            string name = encoder.Name;

            // Assert
            Assert.NotNull(name);
            Assert.NotEmpty(name);
        }

        /// <summary>
        ///     Tests that encoder options builder create method should return options
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_CreateMethod_ShouldReturnOptions()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.NotNull(options);
            Assert.IsAssignableFrom<EncoderOptions>(options);
        }

        /// <summary>
        ///     Tests that encoder options builder create should include format
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_Create_ShouldIncludeFormat()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();
            encoder.Format = "mp4";

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.Equal("mp4", options.Format);
        }

        /// <summary>
        ///     Tests that encoder options builder create should include encoder name
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_Create_ShouldIncludeEncoderName()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.Equal("libx264", options.EncoderName);
        }

        /// <summary>
        ///     Tests that encoder options builder create should include encoder arguments
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_Create_ShouldIncludeEncoderArguments()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.NotNull(options.EncoderArguments);
            Assert.NotEmpty(options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that different encoder builders should have different names
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_DifferentEncoders_ShouldHaveDifferentNames()
        {
            // Arrange
            H264Encoder h264 = new H264Encoder();
            Mp3Encoder mp3 = new Mp3Encoder();
            Vp9Encoder vp9 = new Vp9Encoder();

            // Act
            string h264Name = h264.Name;
            string mp3Name = mp3.Name;
            string vp9Name = vp9.Name;

            // Assert
            Assert.NotEqual(h264Name, mp3Name);
            Assert.NotEqual(mp3Name, vp9Name);
            Assert.NotEqual(h264Name, vp9Name);
        }

        /// <summary>
        ///     Tests that different encoder builders should have different formats
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_DifferentEncoders_ShouldHaveDifferentDefaultFormats()
        {
            // Arrange
            H264Encoder h264 = new H264Encoder();
            Mp3Encoder mp3 = new Mp3Encoder();
            Vp9Encoder vp9 = new Vp9Encoder();

            // Act
            string h264Format = h264.Format;
            string mp3Format = mp3.Format;
            string vp9Format = vp9.Format;

            // Assert
            Assert.Equal("mp4", h264Format);
            Assert.Equal("mp3", mp3Format);
            Assert.Equal("webm", vp9Format);
        }

        /// <summary>
        ///     Tests that encoder options builder should create valid encoder options
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_ShouldCreateValidEncoderOptions()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.NotNull(options.Format);
            Assert.NotNull(options.EncoderName);
            Assert.NotNull(options.EncoderArguments);
            Assert.NotEmpty(options.Format);
            Assert.NotEmpty(options.EncoderName);
            Assert.NotEmpty(options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that encoder options builder format should be mutable before create
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_FormatShouldBeMutableBeforeCreate()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();
            string originalFormat = encoder.Format;

            // Act
            encoder.Format = "mkv";
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.NotEqual(originalFormat, "mkv");
            Assert.Equal("mkv", options.Format);
        }

        /// <summary>
        ///     Tests that encoder options builder should support multiple calls to create
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_ShouldSupportMultipleCallsToCreate()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();

            // Act
            EncoderOptions options1 = encoder.Create();
            EncoderOptions options2 = encoder.Create();
            EncoderOptions options3 = encoder.Create();

            // Assert
            Assert.NotNull(options1);
            Assert.NotNull(options2);
            Assert.NotNull(options3);
        }

        /// <summary>
        ///     Tests that encoder options builder mp 3 encoder should create mp 3 options
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_Mp3Encoder_ShouldCreateMp3Options()
        {
            // Arrange
            Mp3Encoder encoder = new Mp3Encoder();

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.Equal("mp3", options.Format);
            Assert.Equal("libmp3lame", options.EncoderName);
        }

        /// <summary>
        ///     Tests that encoder options builder vp 9 encoder should create vp 9 options
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_Vp9Encoder_ShouldCreateVp9Options()
        {
            // Arrange
            Vp9Encoder encoder = new Vp9Encoder();

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.Equal("webm", options.Format);
            Assert.Equal("libvpx-vp9", options.EncoderName);
        }
    }
}