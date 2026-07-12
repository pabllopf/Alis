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
    public class AudioFormatTest
    {
        /// <summary>
        ///     Tests that constructor creates an empty format instance
        /// </summary>
        [Fact]
        public void Constructor_ShouldCreateEmptyFormat()
        {
            AudioFormat format = new AudioFormat();

            Assert.NotNull(format);
        }

        /// <summary>
        ///     Tests that Filename property can be set and retrieved
        /// </summary>
        [Fact]
        public void Filename_ShouldBeSettable()
        {
            AudioFormat format = new AudioFormat();
            format.Filename = "/path/to/audio.mp3";

            Assert.Equal("/path/to/audio.mp3", format.Filename);
        }

        /// <summary>
        ///     Tests that NbStreams property can be set and retrieved
        /// </summary>
        [Fact]
        public void NbStreams_ShouldBeSettable()
        {
            AudioFormat format = new AudioFormat();
            format.NbStreams = 2;

            Assert.Equal(2, format.NbStreams);
        }

        /// <summary>
        ///     Tests that NbPrograms property can be set and retrieved
        /// </summary>
        [Fact]
        public void NbPrograms_ShouldBeSettable()
        {
            AudioFormat format = new AudioFormat();
            format.NbPrograms = 0;

            Assert.Equal(0, format.NbPrograms);
        }

        /// <summary>
        ///     Tests that FormatName property can be set and retrieved
        /// </summary>
        [Fact]
        public void FormatName_ShouldBeSettable()
        {
            AudioFormat format = new AudioFormat();
            format.FormatName = "mp3";

            Assert.Equal("mp3", format.FormatName);
        }

        /// <summary>
        ///     Tests that FormatLongName property can be set and retrieved
        /// </summary>
        [Fact]
        public void FormatLongName_ShouldBeSettable()
        {
            AudioFormat format = new AudioFormat();
            format.FormatLongName = "MP2/3 (MPEG audio layer 2/3)";

            Assert.Equal("MP2/3 (MPEG audio layer 2/3)", format.FormatLongName);
        }

        /// <summary>
        ///     Tests that StartTime property can be set and retrieved
        /// </summary>
        [Fact]
        public void StartTime_ShouldBeSettable()
        {
            AudioFormat format = new AudioFormat();
            format.StartTime = "0.000000";

            Assert.Equal("0.000000", format.StartTime);
        }

        /// <summary>
        ///     Tests that Duration property can be set and retrieved
        /// </summary>
        [Fact]
        public void Duration_ShouldBeSettable()
        {
            AudioFormat format = new AudioFormat();
            format.Duration = "180.500000";

            Assert.Equal("180.500000", format.Duration);
        }

        /// <summary>
        ///     Tests that Size property can be set and retrieved
        /// </summary>
        [Fact]
        public void Size_ShouldBeSettable()
        {
            AudioFormat format = new AudioFormat();
            format.Size = "4567890";

            Assert.Equal("4567890", format.Size);
        }

        /// <summary>
        ///     Tests that BitRate property can be set and retrieved
        /// </summary>
        [Fact]
        public void BitRate_ShouldBeSettable()
        {
            AudioFormat format = new AudioFormat();
            format.BitRate = "320000";

            Assert.Equal("320000", format.BitRate);
        }

        /// <summary>
        ///     Tests that ProbeScore property can be set and retrieved
        /// </summary>
        [Fact]
        public void ProbeScore_ShouldBeSettable()
        {
            AudioFormat format = new AudioFormat();
            format.ProbeScore = 100;

            Assert.Equal(100, format.ProbeScore);
        }

        /// <summary>
        ///     Tests that all properties can be set together
        /// </summary>
        [Fact]
        public void AllProperties_ShouldBeSettableTogether()
        {
            AudioFormat format = new AudioFormat
            {
                Filename = "/path/to/audio.mp3",
                NbStreams = 2,
                NbPrograms = 0,
                FormatName = "mp3",
                FormatLongName = "MP2/3 (MPEG audio layer 2/3)",
                StartTime = "0.000000",
                Duration = "180.500000",
                Size = "4567890",
                BitRate = "320000",
                ProbeScore = 100
            };

            Assert.Equal("/path/to/audio.mp3", format.Filename);
            Assert.Equal(2, format.NbStreams);
            Assert.Equal(0, format.NbPrograms);
            Assert.Equal("mp3", format.FormatName);
            Assert.Equal("MP2/3 (MPEG audio layer 2/3)", format.FormatLongName);
            Assert.Equal("0.000000", format.StartTime);
            Assert.Equal("180.500000", format.Duration);
            Assert.Equal("4567890", format.Size);
            Assert.Equal("320000", format.BitRate);
            Assert.Equal(100, format.ProbeScore);
        }

        /// <summary>
        ///     Tests that default values are correct
        /// </summary>
        [Fact]
        public void DefaultValues_ShouldBeCorrect()
        {
            AudioFormat format = new AudioFormat();

            Assert.Null(format.Filename);
            Assert.Equal(0, format.NbStreams);
            Assert.Equal(0, format.NbPrograms);
            Assert.Null(format.FormatName);
            Assert.Null(format.FormatLongName);
            Assert.Null(format.StartTime);
            Assert.Null(format.Duration);
            Assert.Null(format.Size);
            Assert.Null(format.BitRate);
            Assert.Equal(0, format.ProbeScore);
        }

        /// <summary>
        ///     Tests that string properties can be null
        /// </summary>
        [Fact]
        public void StringProperties_CanBeNull()
        {
            AudioFormat format = new AudioFormat();

            format.Filename = null;
            format.FormatName = null;
            format.FormatLongName = null;
            format.StartTime = null;
            format.Duration = null;
            format.Size = null;
            format.BitRate = null;

            Assert.Null(format.Filename);
            Assert.Null(format.FormatName);
            Assert.Null(format.FormatLongName);
            Assert.Null(format.StartTime);
            Assert.Null(format.Duration);
            Assert.Null(format.Size);
            Assert.Null(format.BitRate);
        }

        /// <summary>
        ///     Tests that large values are handled correctly
        /// </summary>
        [Fact]
        public void LargeValues_ShouldBeHandledCorrectly()
        {
            AudioFormat format = new AudioFormat
            {
                NbStreams = long.MaxValue,
                NbPrograms = long.MaxValue,
                ProbeScore = long.MaxValue
            };

            Assert.Equal(long.MaxValue, format.NbStreams);
            Assert.Equal(long.MaxValue, format.NbPrograms);
            Assert.Equal(long.MaxValue, format.ProbeScore);
        }

        /// <summary>
        ///     Tests that negative values are handled for numeric properties
        /// </summary>
        [Fact]
        public void NegativeValues_ShouldBeHandledForNumericProperties()
        {
            AudioFormat format = new AudioFormat
            {
                NbStreams = -1,
                NbPrograms = -1,
                ProbeScore = -1
            };

            Assert.Equal(-1, format.NbStreams);
            Assert.Equal(-1, format.NbPrograms);
            Assert.Equal(-1, format.ProbeScore);
        }
    }
}
