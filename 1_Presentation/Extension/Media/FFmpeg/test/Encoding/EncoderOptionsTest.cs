// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EncoderOptionsTest.cs
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
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Encoding
{
    /// <summary>
    ///     The encoder options test class
    /// </summary>
    /// <seealso cref="EncoderOptions" />
    public class EncoderOptionsTest
    {
        /// <summary>
        ///     Tests that encoder options constructor should create instance
        /// </summary>
        [Fact]
        public void EncoderOptions_Constructor_ShouldCreateInstance()
        {
            // Arrange & Act
            EncoderOptions options = new EncoderOptions();

            // Assert
            Assert.NotNull(options);
        }

        /// <summary>
        ///     Tests that encoder options format property should be settable
        /// </summary>
        [Fact]
        public void EncoderOptions_FormatProperty_ShouldBeSettable()
        {
            // Arrange
            EncoderOptions options = new EncoderOptions();
            string format = "mp4";

            // Act
            options.Format = format;

            // Assert
            Assert.Equal(format, options.Format);
        }

        /// <summary>
        ///     Tests that encoder options encoder name property should be settable
        /// </summary>
        [Fact]
        public void EncoderOptions_EncoderNameProperty_ShouldBeSettable()
        {
            // Arrange
            EncoderOptions options = new EncoderOptions();
            string encoderName = "libx264";

            // Act
            options.EncoderName = encoderName;

            // Assert
            Assert.Equal(encoderName, options.EncoderName);
        }

        /// <summary>
        ///     Tests that encoder options encoder arguments property should be settable
        /// </summary>
        [Fact]
        public void EncoderOptions_EncoderArgumentsProperty_ShouldBeSettable()
        {
            // Arrange
            EncoderOptions options = new EncoderOptions();
            string arguments = "-crf 22 -preset medium";

            // Act
            options.EncoderArguments = arguments;

            // Assert
            Assert.Equal(arguments, options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that encoder options should allow null format
        /// </summary>
        [Fact]
        public void EncoderOptions_ShouldAllowNullFormat()
        {
            // Arrange
            EncoderOptions options = new EncoderOptions();

            // Act
            options.Format = null;

            // Assert
            Assert.Null(options.Format);
        }

        /// <summary>
        ///     Tests that encoder options should allow null encoder name
        /// </summary>
        [Fact]
        public void EncoderOptions_ShouldAllowNullEncoderName()
        {
            // Arrange
            EncoderOptions options = new EncoderOptions();

            // Act
            options.EncoderName = null;

            // Assert
            Assert.Null(options.EncoderName);
        }

        /// <summary>
        ///     Tests that encoder options should allow null encoder arguments
        /// </summary>
        [Fact]
        public void EncoderOptions_ShouldAllowNullEncoderArguments()
        {
            // Arrange
            EncoderOptions options = new EncoderOptions();

            // Act
            options.EncoderArguments = null;

            // Assert
            Assert.Null(options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that encoder options should allow empty strings
        /// </summary>
        [Fact]
        public void EncoderOptions_ShouldAllowEmptyStrings()
        {
            // Arrange
            EncoderOptions options = new EncoderOptions();

            // Act
            options.Format = string.Empty;
            options.EncoderName = string.Empty;
            options.EncoderArguments = string.Empty;

            // Assert
            Assert.Equal(string.Empty, options.Format);
            Assert.Equal(string.Empty, options.EncoderName);
            Assert.Equal(string.Empty, options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that encoder options all properties should be independent
        /// </summary>
        [Fact]
        public void EncoderOptions_AllProperties_ShouldBeIndependent()
        {
            // Arrange
            EncoderOptions options = new EncoderOptions();

            // Act
            options.Format = "mp4";
            options.EncoderName = "libx264";
            options.EncoderArguments = "-crf 22";

            // Assert
            Assert.Equal("mp4", options.Format);
            Assert.Equal("libx264", options.EncoderName);
            Assert.Equal("-crf 22", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that encoder options should support common video formats
        /// </summary>
        [Fact]
        public void EncoderOptions_ShouldSupportCommonVideoFormats()
        {
            // Arrange
            EncoderOptions mp4Options = new EncoderOptions { Format = "mp4" };
            EncoderOptions webmOptions = new EncoderOptions { Format = "webm" };
            EncoderOptions mkvOptions = new EncoderOptions { Format = "mkv" };

            // Act & Assert
            Assert.Equal("mp4", mp4Options.Format);
            Assert.Equal("webm", webmOptions.Format);
            Assert.Equal("mkv", mkvOptions.Format);
        }

        /// <summary>
        ///     Tests that encoder options should support common audio formats
        /// </summary>
        [Fact]
        public void EncoderOptions_ShouldSupportCommonAudioFormats()
        {
            // Arrange
            EncoderOptions mp3Options = new EncoderOptions { Format = "mp3" };
            EncoderOptions oggOptions = new EncoderOptions { Format = "ogg" };
            EncoderOptions m4aOptions = new EncoderOptions { Format = "m4a" };

            // Act & Assert
            Assert.Equal("mp3", mp3Options.Format);
            Assert.Equal("ogg", oggOptions.Format);
            Assert.Equal("m4a", m4aOptions.Format);
        }

        /// <summary>
        ///     Tests that encoder options should support common video encoders
        /// </summary>
        [Fact]
        public void EncoderOptions_ShouldSupportCommonVideoEncoders()
        {
            // Arrange
            EncoderOptions h264Options = new EncoderOptions { EncoderName = "libx264" };
            EncoderOptions h265Options = new EncoderOptions { EncoderName = "libx265" };
            EncoderOptions vp9Options = new EncoderOptions { EncoderName = "libvpx-vp9" };

            // Act & Assert
            Assert.Equal("libx264", h264Options.EncoderName);
            Assert.Equal("libx265", h265Options.EncoderName);
            Assert.Equal("libvpx-vp9", vp9Options.EncoderName);
        }

        /// <summary>
        ///     Tests that encoder options should support common audio encoders
        /// </summary>
        [Fact]
        public void EncoderOptions_ShouldSupportCommonAudioEncoders()
        {
            // Arrange
            EncoderOptions mp3Options = new EncoderOptions { EncoderName = "libmp3lame" };
            EncoderOptions aacOptions = new EncoderOptions { EncoderName = "aac" };
            EncoderOptions vorbisOptions = new EncoderOptions { EncoderName = "libvorbis" };

            // Act & Assert
            Assert.Equal("libmp3lame", mp3Options.EncoderName);
            Assert.Equal("aac", aacOptions.EncoderName);
            Assert.Equal("libvorbis", vorbisOptions.EncoderName);
        }

        /// <summary>
        ///     Tests that encoder options should allow complex encoder arguments
        /// </summary>
        [Fact]
        public void EncoderOptions_ShouldAllowComplexEncoderArguments()
        {
            // Arrange
            EncoderOptions options = new EncoderOptions();
            string complexArgs = "-crf 22 -preset medium -tune film -profile:v high";

            // Act
            options.EncoderArguments = complexArgs;

            // Assert
            Assert.Equal(complexArgs, options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that encoder options properties should be mutable
        /// </summary>
        [Fact]
        public void EncoderOptions_Properties_ShouldBeMutable()
        {
            // Arrange
            EncoderOptions options = new EncoderOptions
            {
                Format = "mp4",
                EncoderName = "libx264",
                EncoderArguments = "-crf 22"
            };

            // Act
            options.Format = "webm";
            options.EncoderName = "libvpx-vp9";
            options.EncoderArguments = "-crf 31";

            // Assert
            Assert.Equal("webm", options.Format);
            Assert.Equal("libvpx-vp9", options.EncoderName);
            Assert.Equal("-crf 31", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that encoder options should support initializer syntax
        /// </summary>
        [Fact]
        public void EncoderOptions_ShouldSupportInitializerSyntax()
        {
            // Arrange & Act
            EncoderOptions options = new EncoderOptions
            {
                Format = "mp4",
                EncoderName = "libx264",
                EncoderArguments = "-crf 22 -preset medium"
            };

            // Assert
            Assert.Equal("mp4", options.Format);
            Assert.Equal("libx264", options.EncoderName);
            Assert.Equal("-crf 22 -preset medium", options.EncoderArguments);
        }
    }
}

