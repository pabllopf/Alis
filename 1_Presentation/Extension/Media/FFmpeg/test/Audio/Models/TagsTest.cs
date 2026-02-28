// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TagsTest.cs
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

using Alis.Extension.Media.FFmpeg.Audio.Models;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio.Models
{
    /// <summary>
    ///     The tags test class
    /// </summary>
    /// <seealso cref="Tags" />
    public class TagsTest
    {
        /// <summary>
        ///     Tests that tags constructor should create instance
        /// </summary>
        [Fact]
        public void Tags_Constructor_ShouldCreateInstance()
        {
            // Arrange & Act
            Tags tags = new Tags();

            // Assert
            Assert.NotNull(tags);
        }

        /// <summary>
        ///     Tests that tags encoder property should be settable
        /// </summary>
        [Fact]
        public void Tags_EncoderProperty_ShouldBeSettable()
        {
            // Arrange
            Tags tags = new Tags();
            string encoder = "Lavf58.29.100";

            // Act
            tags.Encoder = encoder;

            // Assert
            Assert.Equal(encoder, tags.Encoder);
        }

        /// <summary>
        ///     Tests that tags encoder property should accept null
        /// </summary>
        [Fact]
        public void Tags_EncoderProperty_ShouldAcceptNull()
        {
            // Arrange
            Tags tags = new Tags();

            // Act
            tags.Encoder = null;

            // Assert
            Assert.Null(tags.Encoder);
        }

        /// <summary>
        ///     Tests that tags encoder property should accept empty string
        /// </summary>
        [Fact]
        public void Tags_EncoderProperty_ShouldAcceptEmptyString()
        {
            // Arrange
            Tags tags = new Tags();

            // Act
            tags.Encoder = string.Empty;

            // Assert
            Assert.Equal(string.Empty, tags.Encoder);
        }

        /// <summary>
        ///     Tests that tags should support initializer syntax
        /// </summary>
        [Fact]
        public void Tags_ShouldSupportInitializerSyntax()
        {
            // Arrange & Act
            Tags tags = new Tags
            {
                Encoder = "Lavf58.29.100"
            };

            // Assert
            Assert.Equal("Lavf58.29.100", tags.Encoder);
        }

        /// <summary>
        ///     Tests that tags encoder property should be mutable
        /// </summary>
        [Fact]
        public void Tags_EncoderProperty_ShouldBeMutable()
        {
            // Arrange
            Tags tags = new Tags {Encoder = "Lavf58.29.100"};

            // Act
            tags.Encoder = "Lavf59.27.100";

            // Assert
            Assert.Equal("Lavf59.27.100", tags.Encoder);
        }

        /// <summary>
        ///     Tests that tags should support common encoder strings
        /// </summary>
        [Fact]
        public void Tags_ShouldSupportCommonEncoderStrings()
        {
            // Arrange & Act
            Tags lavfTags = new Tags {Encoder = "Lavf58.29.100"};
            Tags ffmpegTags = new Tags {Encoder = "FFmpeg"};
            Tags customTags = new Tags {Encoder = "Custom Encoder 1.0"};

            // Assert
            Assert.Equal("Lavf58.29.100", lavfTags.Encoder);
            Assert.Equal("FFmpeg", ffmpegTags.Encoder);
            Assert.Equal("Custom Encoder 1.0", customTags.Encoder);
        }
    }
}