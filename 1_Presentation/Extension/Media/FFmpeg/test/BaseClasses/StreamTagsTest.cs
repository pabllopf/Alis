// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StreamTagsTest.cs
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

using Alis.Extension.Media.FFmpeg.BaseClasses;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.BaseClasses
{
    /// <summary>
    ///     The stream tags test class
    /// </summary>
    /// <seealso cref="StreamTags" />
    public class StreamTagsTest
    {
        /// <summary>
        ///     Tests that stream tags default constructor should create instance with empty strings
        /// </summary>
        [Fact]
        public void StreamTags_DefaultConstructor_ShouldCreateInstanceWithEmptyStrings()
        {
            // Arrange & Act
            StreamTags tags = new StreamTags();

            // Assert
            Assert.NotNull(tags);
            Assert.Equal(string.Empty, tags.CreationTime);
            Assert.Equal(string.Empty, tags.Language);
            Assert.Equal(string.Empty, tags.HandlerName);
        }

        /// <summary>
        ///     Tests that stream tags parameterized constructor should create instance with values
        /// </summary>
        [Fact]
        public void StreamTags_ParameterizedConstructor_ShouldCreateInstanceWithValues()
        {
            // Arrange
            string creationTime = "2021-01-01T00:00:00.000000Z";
            string language = "eng";
            string handlerName = "VideoHandler";

            // Act
            StreamTags tags = new StreamTags(creationTime, language, handlerName);

            // Assert
            Assert.Equal(creationTime, tags.CreationTime);
            Assert.Equal(language, tags.Language);
            Assert.Equal(handlerName, tags.HandlerName);
        }

        /// <summary>
        ///     Tests that stream tags creation time property should be settable
        /// </summary>
        [Fact]
        public void StreamTags_CreationTimeProperty_ShouldBeSettable()
        {
            // Arrange
            StreamTags tags = new StreamTags();
            string creationTime = "2021-01-01T00:00:00.000000Z";

            // Act
            tags.CreationTime = creationTime;

            // Assert
            Assert.Equal(creationTime, tags.CreationTime);
        }

        /// <summary>
        ///     Tests that stream tags language property should be settable
        /// </summary>
        [Fact]
        public void StreamTags_LanguageProperty_ShouldBeSettable()
        {
            // Arrange
            StreamTags tags = new StreamTags();
            string language = "eng";

            // Act
            tags.Language = language;

            // Assert
            Assert.Equal(language, tags.Language);
        }

        /// <summary>
        ///     Tests that stream tags handler name property should be settable
        /// </summary>
        [Fact]
        public void StreamTags_HandlerNameProperty_ShouldBeSettable()
        {
            // Arrange
            StreamTags tags = new StreamTags();
            string handlerName = "AudioHandler";

            // Act
            tags.HandlerName = handlerName;

            // Assert
            Assert.Equal(handlerName, tags.HandlerName);
        }

        /// <summary>
        ///     Tests that stream tags should allow null values
        /// </summary>
        [Fact]
        public void StreamTags_ShouldAllowNullValues()
        {
            // Arrange
            StreamTags tags = new StreamTags();

            // Act
            tags.CreationTime = null;
            tags.Language = null;
            tags.HandlerName = null;

            // Assert
            Assert.Null(tags.CreationTime);
            Assert.Null(tags.Language);
            Assert.Null(tags.HandlerName);
        }

        /// <summary>
        ///     Tests that stream tags should support common language codes
        /// </summary>
        [Fact]
        public void StreamTags_ShouldSupportCommonLanguageCodes()
        {
            // Arrange & Act
            StreamTags engTags = new StreamTags {Language = "eng"};
            StreamTags espTags = new StreamTags {Language = "spa"};
            StreamTags freTags = new StreamTags {Language = "fre"};

            // Assert
            Assert.Equal("eng", engTags.Language);
            Assert.Equal("spa", espTags.Language);
            Assert.Equal("fre", freTags.Language);
        }

        /// <summary>
        ///     Tests that stream tags properties should be independent
        /// </summary>
        [Fact]
        public void StreamTags_Properties_ShouldBeIndependent()
        {
            // Arrange
            StreamTags tags = new StreamTags();

            // Act
            tags.CreationTime = "2021-01-01T00:00:00.000000Z";
            tags.Language = "eng";
            tags.HandlerName = "VideoHandler";

            // Assert
            Assert.Equal("2021-01-01T00:00:00.000000Z", tags.CreationTime);
            Assert.Equal("eng", tags.Language);
            Assert.Equal("VideoHandler", tags.HandlerName);
        }

        /// <summary>
        ///     Tests that stream tags should support initializer syntax
        /// </summary>
        [Fact]
        public void StreamTags_ShouldSupportInitializerSyntax()
        {
            // Arrange & Act
            StreamTags tags = new StreamTags
            {
                CreationTime = "2021-01-01T00:00:00.000000Z",
                Language = "eng",
                HandlerName = "AudioHandler"
            };

            // Assert
            Assert.Equal("2021-01-01T00:00:00.000000Z", tags.CreationTime);
            Assert.Equal("eng", tags.Language);
            Assert.Equal("AudioHandler", tags.HandlerName);
        }

        /// <summary>
        ///     Tests that stream tags properties should be mutable
        /// </summary>
        [Fact]
        public void StreamTags_Properties_ShouldBeMutable()
        {
            // Arrange
            StreamTags tags = new StreamTags("2021-01-01", "eng", "VideoHandler");

            // Act
            tags.CreationTime = "2022-01-01";
            tags.Language = "spa";
            tags.HandlerName = "AudioHandler";

            // Assert
            Assert.Equal("2022-01-01", tags.CreationTime);
            Assert.Equal("spa", tags.Language);
            Assert.Equal("AudioHandler", tags.HandlerName);
        }

        /// <summary>
        ///     Tests that stream tags constructor with null parameters should work
        /// </summary>
        [Fact]
        public void StreamTags_ConstructorWithNullParameters_ShouldWork()
        {
            // Arrange & Act
            StreamTags tags = new StreamTags(null, null, null);

            // Assert
            Assert.Null(tags.CreationTime);
            Assert.Null(tags.Language);
            Assert.Null(tags.HandlerName);
        }
    }
}