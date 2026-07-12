// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioFormatRemainingCoverageTests.cs
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
    ///     The audio format remaining coverage tests class
    /// </summary>
    public class AudioFormatRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that the constructor creates a non-null instance
        /// </summary>
        [Fact]
        public void Constructor_CreatesNonNullInstance()
        {
            AudioFormat audioFormat = new AudioFormat();

            Assert.NotNull(audioFormat);
        }

        /// <summary>
        ///     Verifies that the Filename property round-trips the value test.mp3
        /// </summary>
        [Fact]
        public void Filename_RoundTrip()
        {
            AudioFormat audioFormat = new AudioFormat();
            audioFormat.Filename = "test.mp3";

            Assert.Equal("test.mp3", audioFormat.Filename);
        }

        /// <summary>
        ///     Verifies that the NbStreams property round-trips the value 2
        /// </summary>
        [Fact]
        public void NbStreams_RoundTrip()
        {
            AudioFormat audioFormat = new AudioFormat();
            audioFormat.NbStreams = 2L;

            Assert.Equal(2L, audioFormat.NbStreams);
        }

        /// <summary>
        ///     Verifies that the NbPrograms property round-trips the value 0
        /// </summary>
        [Fact]
        public void NbPrograms_RoundTrip()
        {
            AudioFormat audioFormat = new AudioFormat();
            audioFormat.NbPrograms = 0L;

            Assert.Equal(0L, audioFormat.NbPrograms);
        }

        /// <summary>
        ///     Verifies that the FormatName property round-trips the value mp3
        /// </summary>
        [Fact]
        public void FormatName_RoundTrip()
        {
            AudioFormat audioFormat = new AudioFormat();
            audioFormat.FormatName = "mp3";

            Assert.Equal("mp3", audioFormat.FormatName);
        }

        /// <summary>
        ///     Verifies that the FormatLongName property round-trips its value
        /// </summary>
        [Fact]
        public void FormatLongName_RoundTrip()
        {
            AudioFormat audioFormat = new AudioFormat();
            audioFormat.FormatLongName = "MP2/3 (MPEG audio layer 2/3)";

            Assert.Equal("MP2/3 (MPEG audio layer 2/3)", audioFormat.FormatLongName);
        }

        /// <summary>
        ///     Verifies that the StartTime property round-trips the value 0.000000
        /// </summary>
        [Fact]
        public void StartTime_RoundTrip()
        {
            AudioFormat audioFormat = new AudioFormat();
            audioFormat.StartTime = "0.000000";

            Assert.Equal("0.000000", audioFormat.StartTime);
        }

        /// <summary>
        ///     Verifies that the Duration property round-trips the value 180.500000
        /// </summary>
        [Fact]
        public void Duration_RoundTrip()
        {
            AudioFormat audioFormat = new AudioFormat();
            audioFormat.Duration = "180.500000";

            Assert.Equal("180.500000", audioFormat.Duration);
        }

        /// <summary>
        ///     Verifies that the Size property round-trips the value 4567890
        /// </summary>
        [Fact]
        public void Size_RoundTrip()
        {
            AudioFormat audioFormat = new AudioFormat();
            audioFormat.Size = "4567890";

            Assert.Equal("4567890", audioFormat.Size);
        }

        /// <summary>
        ///     Verifies that the BitRate property round-trips the value 320000
        /// </summary>
        [Fact]
        public void BitRate_RoundTrip()
        {
            AudioFormat audioFormat = new AudioFormat();
            audioFormat.BitRate = "320000";

            Assert.Equal("320000", audioFormat.BitRate);
        }

        /// <summary>
        ///     Verifies that the ProbeScore property round-trips the value 100
        /// </summary>
        [Fact]
        public void ProbeScore_RoundTrip()
        {
            AudioFormat audioFormat = new AudioFormat();
            audioFormat.ProbeScore = 100L;

            Assert.Equal(100L, audioFormat.ProbeScore);
        }

        /// <summary>
        ///     Verifies that all properties set together round-trip their values
        /// </summary>
        [Fact]
        public void AllProperties_SetTogether_RoundTrip()
        {
            AudioFormat audioFormat = new AudioFormat
            {
                Filename = "all.mp4",
                NbStreams = 5L,
                NbPrograms = 1L,
                FormatName = "mov,mp4,m4a,3gp,3g2,mj2",
                FormatLongName = "QuickTime / MOV",
                StartTime = "0.100000",
                Duration = "360.250000",
                Size = "9876543",
                BitRate = "2500000",
                ProbeScore = 51L,
            };

            Assert.Equal("all.mp4", audioFormat.Filename);
            Assert.Equal(5L, audioFormat.NbStreams);
            Assert.Equal(1L, audioFormat.NbPrograms);
            Assert.Equal("mov,mp4,m4a,3gp,3g2,mj2", audioFormat.FormatName);
            Assert.Equal("QuickTime / MOV", audioFormat.FormatLongName);
            Assert.Equal("0.100000", audioFormat.StartTime);
            Assert.Equal("360.250000", audioFormat.Duration);
            Assert.Equal("9876543", audioFormat.Size);
            Assert.Equal("2500000", audioFormat.BitRate);
            Assert.Equal(51L, audioFormat.ProbeScore);
        }

        /// <summary>
        ///     Verifies that the default values are nulls for strings and zero for longs
        /// </summary>
        [Fact]
        public void DefaultValues_AreDefaults()
        {
            AudioFormat audioFormat = new AudioFormat();

            Assert.Null(audioFormat.Filename);
            Assert.Null(audioFormat.FormatName);
            Assert.Null(audioFormat.FormatLongName);
            Assert.Null(audioFormat.StartTime);
            Assert.Null(audioFormat.Duration);
            Assert.Null(audioFormat.Size);
            Assert.Null(audioFormat.BitRate);
            Assert.Equal(0L, audioFormat.NbStreams);
            Assert.Equal(0L, audioFormat.NbPrograms);
            Assert.Equal(0L, audioFormat.ProbeScore);
        }

        /// <summary>
        ///     Verifies that large values are handled correctly for numeric properties
        /// </summary>
        [Fact]
        public void LargeValues_HandledCorrectly()
        {
            AudioFormat audioFormat = new AudioFormat();
            audioFormat.NbStreams = long.MaxValue;
            audioFormat.NbPrograms = long.MaxValue;
            audioFormat.ProbeScore = long.MaxValue;

            Assert.Equal(long.MaxValue, audioFormat.NbStreams);
            Assert.Equal(long.MaxValue, audioFormat.NbPrograms);
            Assert.Equal(long.MaxValue, audioFormat.ProbeScore);
        }

        /// <summary>
        ///     Verifies that negative values are handled for numeric properties
        /// </summary>
        [Fact]
        public void NegativeValues_HandledForNumericProperties()
        {
            AudioFormat audioFormat = new AudioFormat();
            audioFormat.NbStreams = -1L;
            audioFormat.NbPrograms = -1L;
            audioFormat.ProbeScore = -1L;

            Assert.Equal(-1L, audioFormat.NbStreams);
            Assert.Equal(-1L, audioFormat.NbPrograms);
            Assert.Equal(-1L, audioFormat.ProbeScore);
        }
    }
}