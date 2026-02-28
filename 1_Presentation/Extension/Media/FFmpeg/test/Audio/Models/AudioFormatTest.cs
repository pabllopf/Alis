// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioFormatTest.cs
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
    ///     The audio format test class
    /// </summary>
    /// <seealso cref="AudioFormat" />
    public class AudioFormatTest
    {
        /// <summary>
        ///     Tests that audio format constructor should create instance
        /// </summary>
        [Fact]
        public void AudioFormat_Constructor_ShouldCreateInstance()
        {
            // Arrange & Act
            AudioFormat format = new AudioFormat();

            // Assert
            Assert.NotNull(format);
        }

        /// <summary>
        ///     Tests that audio format filename property should be settable
        /// </summary>
        [Fact]
        public void AudioFormat_FilenameProperty_ShouldBeSettable()
        {
            // Arrange
            AudioFormat format = new AudioFormat();
            string filename = "audio.mp3";

            // Act
            format.Filename = filename;

            // Assert
            Assert.Equal(filename, format.Filename);
        }

        /// <summary>
        ///     Tests that audio format nb streams property should be settable
        /// </summary>
        [Fact]
        public void AudioFormat_NbStreamsProperty_ShouldBeSettable()
        {
            // Arrange
            AudioFormat format = new AudioFormat();
            long nbStreams = 1;

            // Act
            format.NbStreams = nbStreams;

            // Assert
            Assert.Equal(nbStreams, format.NbStreams);
        }

        /// <summary>
        ///     Tests that audio format nb programs property should be settable
        /// </summary>
        [Fact]
        public void AudioFormat_NbProgramsProperty_ShouldBeSettable()
        {
            // Arrange
            AudioFormat format = new AudioFormat();
            long nbPrograms = 0;

            // Act
            format.NbPrograms = nbPrograms;

            // Assert
            Assert.Equal(nbPrograms, format.NbPrograms);
        }

        /// <summary>
        ///     Tests that audio format format name property should be settable
        /// </summary>
        [Fact]
        public void AudioFormat_FormatNameProperty_ShouldBeSettable()
        {
            // Arrange
            AudioFormat format = new AudioFormat();
            string formatName = "mp3";

            // Act
            format.FormatName = formatName;

            // Assert
            Assert.Equal(formatName, format.FormatName);
        }

        /// <summary>
        ///     Tests that audio format format long name property should be settable
        /// </summary>
        [Fact]
        public void AudioFormat_FormatLongNameProperty_ShouldBeSettable()
        {
            // Arrange
            AudioFormat format = new AudioFormat();
            string formatLongName = "MP2/3 (MPEG audio layer 2/3)";

            // Act
            format.FormatLongName = formatLongName;

            // Assert
            Assert.Equal(formatLongName, format.FormatLongName);
        }

        /// <summary>
        ///     Tests that audio format start time property should be settable
        /// </summary>
        [Fact]
        public void AudioFormat_StartTimeProperty_ShouldBeSettable()
        {
            // Arrange
            AudioFormat format = new AudioFormat();
            string startTime = "0.000000";

            // Act
            format.StartTime = startTime;

            // Assert
            Assert.Equal(startTime, format.StartTime);
        }

        /// <summary>
        ///     Tests that audio format duration property should be settable
        /// </summary>
        [Fact]
        public void AudioFormat_DurationProperty_ShouldBeSettable()
        {
            // Arrange
            AudioFormat format = new AudioFormat();
            string duration = "180.000000";

            // Act
            format.Duration = duration;

            // Assert
            Assert.Equal(duration, format.Duration);
        }

        /// <summary>
        ///     Tests that audio format size property should be settable
        /// </summary>
        [Fact]
        public void AudioFormat_SizeProperty_ShouldBeSettable()
        {
            // Arrange
            AudioFormat format = new AudioFormat();
            string size = "5000000";

            // Act
            format.Size = size;

            // Assert
            Assert.Equal(size, format.Size);
        }

        /// <summary>
        ///     Tests that audio format bit rate property should be settable
        /// </summary>
        [Fact]
        public void AudioFormat_BitRateProperty_ShouldBeSettable()
        {
            // Arrange
            AudioFormat format = new AudioFormat();
            string bitRate = "320000";

            // Act
            format.BitRate = bitRate;

            // Assert
            Assert.Equal(bitRate, format.BitRate);
        }

        /// <summary>
        ///     Tests that audio format probe score property should be settable
        /// </summary>
        [Fact]
        public void AudioFormat_ProbeScoreProperty_ShouldBeSettable()
        {
            // Arrange
            AudioFormat format = new AudioFormat();
            long probeScore = 100;

            // Act
            format.ProbeScore = probeScore;

            // Assert
            Assert.Equal(probeScore, format.ProbeScore);
        }

        /// <summary>
        ///     Tests that audio format should support null values
        /// </summary>
        [Fact]
        public void AudioFormat_ShouldSupportNullValues()
        {
            // Arrange
            AudioFormat format = new AudioFormat();

            // Act
            format.Filename = null;
            format.FormatName = null;
            format.FormatLongName = null;
            format.StartTime = null;
            format.Duration = null;
            format.Size = null;
            format.BitRate = null;

            // Assert
            Assert.Null(format.Filename);
            Assert.Null(format.FormatName);
            Assert.Null(format.FormatLongName);
        }

        /// <summary>
        ///     Tests that audio format should support initializer syntax
        /// </summary>
        [Fact]
        public void AudioFormat_ShouldSupportInitializerSyntax()
        {
            // Arrange & Act
            AudioFormat format = new AudioFormat
            {
                Filename = "audio.mp3",
                FormatName = "mp3",
                Duration = "180.000000",
                BitRate = "320000"
            };

            // Assert
            Assert.Equal("audio.mp3", format.Filename);
            Assert.Equal("mp3", format.FormatName);
            Assert.Equal("180.000000", format.Duration);
            Assert.Equal("320000", format.BitRate);
        }

        /// <summary>
        ///     Tests that audio format properties should be mutable
        /// </summary>
        [Fact]
        public void AudioFormat_Properties_ShouldBeMutable()
        {
            // Arrange
            AudioFormat format = new AudioFormat
            {
                Filename = "audio1.mp3",
                FormatName = "mp3"
            };

            // Act
            format.Filename = "audio2.wav";
            format.FormatName = "wav";

            // Assert
            Assert.Equal("audio2.wav", format.Filename);
            Assert.Equal("wav", format.FormatName);
        }

        /// <summary>
        ///     Tests that audio format should support common audio formats
        /// </summary>
        [Fact]
        public void AudioFormat_ShouldSupportCommonAudioFormats()
        {
            // Arrange & Act
            AudioFormat mp3Format = new AudioFormat {FormatName = "mp3"};
            AudioFormat wavFormat = new AudioFormat {FormatName = "wav"};
            AudioFormat oggFormat = new AudioFormat {FormatName = "ogg"};
            AudioFormat flacFormat = new AudioFormat {FormatName = "flac"};

            // Assert
            Assert.Equal("mp3", mp3Format.FormatName);
            Assert.Equal("wav", wavFormat.FormatName);
            Assert.Equal("ogg", oggFormat.FormatName);
            Assert.Equal("flac", flacFormat.FormatName);
        }

        /// <summary>
        ///     Tests that audio format nb streams should support multiple streams
        /// </summary>
        [Fact]
        public void AudioFormat_NbStreams_ShouldSupportMultipleStreams()
        {
            // Arrange & Act
            AudioFormat singleStream = new AudioFormat {NbStreams = 1};
            AudioFormat multipleStreams = new AudioFormat {NbStreams = 3};

            // Assert
            Assert.Equal(1, singleStream.NbStreams);
            Assert.Equal(3, multipleStreams.NbStreams);
        }

        /// <summary>
        ///     Tests that audio format probe score should support valid range
        /// </summary>
        [Fact]
        public void AudioFormat_ProbeScore_ShouldSupportValidRange()
        {
            // Arrange & Act
            AudioFormat lowScore = new AudioFormat {ProbeScore = 0};
            AudioFormat mediumScore = new AudioFormat {ProbeScore = 50};
            AudioFormat highScore = new AudioFormat {ProbeScore = 100};

            // Assert
            Assert.Equal(0, lowScore.ProbeScore);
            Assert.Equal(50, mediumScore.ProbeScore);
            Assert.Equal(100, highScore.ProbeScore);
        }
    }
}