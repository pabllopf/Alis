// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MediaTypeTest.cs
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

using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test
{
    /// <summary>
    ///     The media type test class
    /// </summary>
    /// <seealso cref="MediaType" />
    public class MediaTypeTest
    {
        /// <summary>
        ///     Tests that media type video should have correct value
        /// </summary>
        [Fact]
        public void MediaType_Video_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            MediaType mediaType = MediaType.Video;

            // Assert
            Assert.Equal(0, (int)mediaType);
        }

        /// <summary>
        ///     Tests that media type audio should have correct value
        /// </summary>
        [Fact]
        public void MediaType_Audio_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            MediaType mediaType = MediaType.Audio;

            // Assert
            Assert.Equal(1, (int)mediaType);
        }

        /// <summary>
        ///     Tests that media type subtitle should have correct value
        /// </summary>
        [Fact]
        public void MediaType_Subtitle_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            MediaType mediaType = MediaType.Subtitle;

            // Assert
            Assert.Equal(2, (int)mediaType);
        }

        /// <summary>
        ///     Tests that media type enum should have three values
        /// </summary>
        [Fact]
        public void MediaType_Enum_ShouldHaveThreeValues()
        {
            // Arrange & Act
            MediaType[] values = (MediaType[])System.Enum.GetValues(typeof(MediaType));

            // Assert
            Assert.Equal(3, values.Length);
        }

        /// <summary>
        ///     Tests that media type enum should contain video audio and subtitle
        /// </summary>
        [Fact]
        public void MediaType_Enum_ShouldContainVideoAudioAndSubtitle()
        {
            // Arrange & Act
            bool hasVideo = System.Enum.IsDefined(typeof(MediaType), MediaType.Video);
            bool hasAudio = System.Enum.IsDefined(typeof(MediaType), MediaType.Audio);
            bool hasSubtitle = System.Enum.IsDefined(typeof(MediaType), MediaType.Subtitle);

            // Assert
            Assert.True(hasVideo);
            Assert.True(hasAudio);
            Assert.True(hasSubtitle);
        }

        /// <summary>
        ///     Tests that media type should be convertible to string
        /// </summary>
        [Fact]
        public void MediaType_ShouldBeConvertibleToString()
        {
            // Arrange
            MediaType video = MediaType.Video;
            MediaType audio = MediaType.Audio;
            MediaType subtitle = MediaType.Subtitle;

            // Act
            string videoStr = video.ToString();
            string audioStr = audio.ToString();
            string subtitleStr = subtitle.ToString();

            // Assert
            Assert.Equal("Video", videoStr);
            Assert.Equal("Audio", audioStr);
            Assert.Equal("Subtitle", subtitleStr);
        }

        /// <summary>
        ///     Tests that media type should be parseable from string
        /// </summary>
        [Fact]
        public void MediaType_ShouldBeParseableFromString()
        {
            // Arrange & Act
            MediaType video = (MediaType)System.Enum.Parse(typeof(MediaType), "Video");
            MediaType audio = (MediaType)System.Enum.Parse(typeof(MediaType), "Audio");
            MediaType subtitle = (MediaType)System.Enum.Parse(typeof(MediaType), "Subtitle");

            // Assert
            Assert.Equal(MediaType.Video, video);
            Assert.Equal(MediaType.Audio, audio);
            Assert.Equal(MediaType.Subtitle, subtitle);
        }

        /// <summary>
        ///     Tests that media type should support equality comparison
        /// </summary>
        [Fact]
        public void MediaType_ShouldSupportEqualityComparison()
        {
            // Arrange
            MediaType video1 = MediaType.Video;
            MediaType video2 = MediaType.Video;
            MediaType audio = MediaType.Audio;

            // Act & Assert
            Assert.Equal(video1, video2);
            Assert.NotEqual(video1, audio);
        }

        /// <summary>
        ///     Tests that media type should be usable in switch statement
        /// </summary>
        [Fact]
        public void MediaType_ShouldBeUsableInSwitchStatement()
        {
            // Arrange
            MediaType mediaType = MediaType.Audio;
            string result = string.Empty;

            // Act
            switch (mediaType)
            {
                case MediaType.Video:
                    result = "Video";
                    break;
                case MediaType.Audio:
                    result = "Audio";
                    break;
                case MediaType.Subtitle:
                    result = "Subtitle";
                    break;
            }

            // Assert
            Assert.Equal("Audio", result);
        }

        /// <summary>
        ///     Tests that media type should have unique values
        /// </summary>
        [Fact]
        public void MediaType_ShouldHaveUniqueValues()
        {
            // Arrange
            int videoValue = (int)MediaType.Video;
            int audioValue = (int)MediaType.Audio;
            int subtitleValue = (int)MediaType.Subtitle;

            // Act & Assert
            Assert.NotEqual(videoValue, audioValue);
            Assert.NotEqual(audioValue, subtitleValue);
            Assert.NotEqual(videoValue, subtitleValue);
        }

        /// <summary>
        ///     Tests that media type should be castable to int
        /// </summary>
        [Fact]
        public void MediaType_ShouldBeCastableToInt()
        {
            // Arrange
            MediaType mediaType = MediaType.Video;

            // Act
            int value = (int)mediaType;

            // Assert
            Assert.Equal(0, value);
        }

        /// <summary>
        ///     Tests that media type should be castable from int
        /// </summary>
        [Fact]
        public void MediaType_ShouldBeCastableFromInt()
        {
            // Arrange
            int value = 1;

            // Act
            MediaType mediaType = (MediaType)value;

            // Assert
            Assert.Equal(MediaType.Audio, mediaType);
        }
    }
}

