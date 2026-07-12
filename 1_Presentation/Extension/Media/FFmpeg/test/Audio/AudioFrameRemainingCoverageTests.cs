// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioFrameRemainingCoverageTests.cs
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

using System;
using System.IO;
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.BaseClasses;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    /// <summary>
    ///     Remaining coverage tests for the <see cref="AudioFrame" /> class using plain facts.
    /// </summary>
    public class AudioFrameRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that the constructor with valid parameters creates an instance with correct default values.
        /// </summary>
        [Fact]
        public void Constructor_WithValidParameters_ShouldCreateInstanceWithCorrectDefaults()
        {
            AudioFrame frame = new AudioFrame(2);

            Assert.NotNull(frame);
            Assert.Equal(2, frame.Channels);
            Assert.Equal(1024, frame.SampleCount);
            Assert.Equal(2, frame.BytesPerSample);
        }

        /// <summary>
        ///     Tests that the constructor with bit depth eight throws invalid operation exception.
        /// </summary>
        [Fact]
        public void Constructor_WithBitDepthEight_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new AudioFrame(2, 1024, 8));
        }

        /// <summary>
        ///     Tests that the constructor with bit depth twelve throws invalid operation exception.
        /// </summary>
        [Fact]
        public void Constructor_WithBitDepthTwelve_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new AudioFrame(2, 1024, 12));
        }

        /// <summary>
        ///     Tests that the constructor with bit depth sixty four throws invalid operation exception.
        /// </summary>
        [Fact]
        public void Constructor_WithBitDepthSixtyFour_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new AudioFrame(2, 1024, 64));
        }

        /// <summary>
        ///     Tests that the constructor with zero channels throws invalid data exception.
        /// </summary>
        [Fact]
        public void Constructor_WithZeroChannels_ShouldThrowInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new AudioFrame(0));
        }

        /// <summary>
        ///     Tests that the constructor with negative channels throws invalid data exception.
        /// </summary>
        [Fact]
        public void Constructor_WithNegativeChannels_ShouldThrowInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new AudioFrame(-1));
        }

        /// <summary>
        ///     Tests that the constructor with zero sample count throws invalid data exception.
        /// </summary>
        [Fact]
        public void Constructor_WithZeroSampleCount_ShouldThrowInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new AudioFrame(2, 0));
        }

        /// <summary>
        ///     Tests that the constructor with negative sample count throws invalid data exception.
        /// </summary>
        [Fact]
        public void Constructor_WithNegativeSampleCount_ShouldThrowInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new AudioFrame(2, -1));
        }

        /// <summary>
        ///     Tests that the constructor with bit depth sixteen sets bytes per sample to two.
        /// </summary>
        [Fact]
        public void Constructor_WithBitDepthSixteen_ShouldSetBytesPerSampleToTwo()
        {
            AudioFrame frame = new AudioFrame(2, 1024, 16);

            Assert.Equal(2, frame.BytesPerSample);
        }

        /// <summary>
        ///     Tests that the constructor with bit depth twenty four sets bytes per sample to three.
        /// </summary>
        [Fact]
        public void Constructor_WithBitDepthTwentyFour_ShouldSetBytesPerSampleToThree()
        {
            AudioFrame frame = new AudioFrame(2, 1024, 24);

            Assert.Equal(3, frame.BytesPerSample);
        }

        /// <summary>
        ///     Tests that the constructor with bit depth thirty two sets bytes per sample to four.
        /// </summary>
        [Fact]
        public void Constructor_WithBitDepthThirtyTwo_ShouldSetBytesPerSampleToFour()
        {
            AudioFrame frame = new AudioFrame(2, 1024, 32);

            Assert.Equal(4, frame.BytesPerSample);
        }

        /// <summary>
        ///     Tests that the raw data is not null after construction.
        /// </summary>
        [Fact]
        public void RawData_AfterConstruction_ShouldNotBeNull()
        {
            AudioFrame frame = new AudioFrame(2);

            Assert.NotNull(frame.RawData);
        }

        /// <summary>
        ///     Tests that the raw data length equals channels times sample count times bytes per sample.
        /// </summary>
        [Fact]
        public void RawData_AfterConstruction_ShouldHaveExpectedLength()
        {
            int channels = 2;
            int sampleCount = 1024;
            int bitDepth = 16;
            int expectedLength = channels * sampleCount * (bitDepth / 8);

            AudioFrame frame = new AudioFrame(channels, sampleCount, bitDepth);

            Assert.Equal(expectedLength, frame.RawData.Length);
        }

        /// <summary>
        ///     Tests that the raw data length is correct for twenty four bit depth.
        /// </summary>
        [Fact]
        public void RawData_WithTwentyFourBitDepth_ShouldHaveExpectedLength()
        {
            int channels = 2;
            int sampleCount = 100;
            int bitDepth = 24;
            int expectedLength = channels * sampleCount * (bitDepth / 8);

            AudioFrame frame = new AudioFrame(channels, sampleCount, bitDepth);

            Assert.Equal(expectedLength, frame.RawData.Length);
        }

        /// <summary>
        ///     Tests that LoadedSamples is zero after construction.
        /// </summary>
        [Fact]
        public void LoadedSamples_AfterConstruction_ShouldBeZero()
        {
            AudioFrame frame = new AudioFrame(2);

            Assert.Equal(0, frame.LoadedSamples);
        }

        /// <summary>
        ///     Tests that Load from an empty stream returns false.
        /// </summary>
        [Fact]
        public void Load_FromEmptyStream_ShouldReturnFalse()
        {
            AudioFrame frame = new AudioFrame(2);
            MemoryStream emptyStream = new MemoryStream();

            bool result = frame.Load(emptyStream);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that Load from a stream with full data returns true and sets LoadedSamples to sample count.
        /// </summary>
        [Fact]
        public void Load_FromFullStream_ShouldReturnTrueAndSetLoadedSamples()
        {
            AudioFrame frame = new AudioFrame(2, 100);
            byte[] testData = new byte[400];
            MemoryStream stream = new MemoryStream(testData);

            bool result = frame.Load(stream);

            Assert.True(result);
            Assert.Equal(100, frame.LoadedSamples);
        }

        /// <summary>
        ///     Tests that Load from a partial stream returns true and sets LoadedSamples to half sample count.
        /// </summary>
        [Fact]
        public void Load_FromPartialStream_ShouldReturnTrueAndSetHalfLoadedSamples()
        {
            AudioFrame frame = new AudioFrame(2, 100);
            byte[] testData = new byte[200];
            MemoryStream stream = new MemoryStream(testData);

            bool result = frame.Load(stream);

            Assert.True(result);
            Assert.Equal(50, frame.LoadedSamples);
        }

        /// <summary>
        ///     Tests that Load updates RawData to a shorter array when partial data is read.
        /// </summary>
        [Fact]
        public void Load_FromPartialStream_ShouldUpdateRawDataToShorterArray()
        {
            AudioFrame frame = new AudioFrame(2, 100);
            int totalRead = 200;
            byte[] testData = new byte[totalRead];
            MemoryStream stream = new MemoryStream(testData);

            frame.Load(stream);

            Assert.Equal(totalRead, frame.RawData.Length);
        }

        /// <summary>
        ///     Tests that Load from a full stream keeps RawData length equal to the buffer size.
        /// </summary>
        [Fact]
        public void Load_FromFullStream_ShouldKeepRawDataLengthEqualToBufferSize()
        {
            AudioFrame frame = new AudioFrame(2, 100);
            byte[] testData = new byte[400];
            MemoryStream stream = new MemoryStream(testData);

            frame.Load(stream);

            Assert.Equal(400, frame.RawData.Length);
        }

        /// <summary>
        ///     Tests that GetSample returns the correct bytes for the first channel of the first sample.
        /// </summary>
        [Fact]
        public void GetSample_ForFirstChannelFirstSample_ShouldReturnExpectedBytes()
        {
            AudioFrame frame = new AudioFrame(2, 10);
            byte[] testData = new byte[40];
            for (int i = 0; i < testData.Length; i++)
            {
                testData[i] = (byte) i;
            }

            MemoryStream stream = new MemoryStream(testData);
            frame.Load(stream);

            byte[] sample = frame.GetSample(0, 0);

            Assert.Equal(2, sample.Length);
            Assert.Equal(0, sample[0]);
            Assert.Equal(1, sample[1]);
        }

        /// <summary>
        ///     Tests that GetSample returns the correct bytes for the second channel of the first sample.
        /// </summary>
        [Fact]
        public void GetSample_ForSecondChannelFirstSample_ShouldReturnExpectedBytes()
        {
            AudioFrame frame = new AudioFrame(2, 10);
            byte[] testData = new byte[40];
            for (int i = 0; i < testData.Length; i++)
            {
                testData[i] = (byte) i;
            }

            MemoryStream stream = new MemoryStream(testData);
            frame.Load(stream);

            byte[] sample = frame.GetSample(0, 1);

            Assert.Equal(2, sample.Length);
            Assert.Equal(2, sample[0]);
            Assert.Equal(3, sample[1]);
        }

        /// <summary>
        ///     Tests that GetSample returns the correct bytes for a non-first sample index.
        /// </summary>
        [Fact]
        public void GetSample_ForSecondSampleFirstChannel_ShouldReturnExpectedBytes()
        {
            AudioFrame frame = new AudioFrame(2, 10);
            byte[] testData = new byte[40];
            for (int i = 0; i < testData.Length; i++)
            {
                testData[i] = (byte) i;
            }

            MemoryStream stream = new MemoryStream(testData);
            frame.Load(stream);

            byte[] sample = frame.GetSample(1, 0);

            Assert.Equal(2, sample.Length);
            Assert.Equal(4, sample[0]);
            Assert.Equal(5, sample[1]);
        }

        /// <summary>
        ///     Tests that GetSample returns a three byte array for twenty four bit depth.
        /// </summary>
        [Fact]
        public void GetSample_WithTwentyFourBitDepth_ShouldReturnThreeBytes()
        {
            AudioFrame frame = new AudioFrame(1, 10, 24);
            byte[] testData = new byte[30];
            for (int i = 0; i < testData.Length; i++)
            {
                testData[i] = (byte) i;
            }

            MemoryStream stream = new MemoryStream(testData);
            frame.Load(stream);

            byte[] sample = frame.GetSample(0, 0);

            Assert.Equal(3, sample.Length);
            Assert.Equal(0, sample[0]);
            Assert.Equal(1, sample[1]);
            Assert.Equal(2, sample[2]);
        }

        /// <summary>
        ///     Tests that Dispose can be called and the frame reference is still not null afterwards.
        /// </summary>
        [Fact]
        public void Dispose_WhenCalled_ShouldLeaveFrameNotNull()
        {
            AudioFrame frame = new AudioFrame(2);

            frame.Dispose();

            Assert.NotNull(frame);
        }

        /// <summary>
        ///     Tests that calling Load after Dispose throws an argument null exception because the frame buffer is null.
        /// </summary>
        [Fact]
        public void Load_AfterDispose_ShouldThrowArgumentNullException()
        {
            AudioFrame frame = new AudioFrame(2, 100);

            frame.Dispose();

            Assert.Throws<ArgumentNullException>(() => frame.Load(new MemoryStream(new byte[10])));
        }

        /// <summary>
        ///     Tests that multiple sequential Load calls on the same frame both return true.
        /// </summary>
        [Fact]
        public void Load_CalledMultipleTimes_ShouldReturnTrueEachTime()
        {
            AudioFrame frame = new AudioFrame(2, 100);
            byte[] testData = new byte[400];

            MemoryStream stream1 = new MemoryStream(testData);
            bool result1 = frame.Load(stream1);

            MemoryStream stream2 = new MemoryStream(testData);
            bool result2 = frame.Load(stream2);

            Assert.True(result1);
            Assert.True(result2);
        }

        /// <summary>
        ///     Tests that the constructor with different sample counts stores the matching sample count.
        /// </summary>
        [Fact]
        public void Constructor_WithDifferentSampleCounts_ShouldStoreMatchingSampleCount()
        {
            AudioFrame frame512 = new AudioFrame(2, 512);
            AudioFrame frame1024 = new AudioFrame(2);
            AudioFrame frame2048 = new AudioFrame(2, 2048);

            Assert.Equal(512, frame512.SampleCount);
            Assert.Equal(1024, frame1024.SampleCount);
            Assert.Equal(2048, frame2048.SampleCount);
        }

        /// <summary>
        ///     Tests that the frame is assignable to IDisposable.
        /// </summary>
        [Fact]
        public void Frame_ShouldBeAssignableToIDisposable()
        {
            AudioFrame frame = new AudioFrame(2);

            Assert.IsAssignableFrom<IDisposable>(frame);
        }

        /// <summary>
        ///     Tests that the frame is assignable to IMediaFrame.
        /// </summary>
        [Fact]
        public void Frame_ShouldBeAssignableToIMediaFrame()
        {
            AudioFrame frame = new AudioFrame(2);

            Assert.IsAssignableFrom<IMediaFrame>(frame);
        }

        /// <summary>
        ///     Tests that the constructor with one channel creates a mono frame.
        /// </summary>
        [Fact]
        public void Constructor_WithOneChannel_ShouldCreateMonoFrame()
        {
            AudioFrame frame = new AudioFrame(1);

            Assert.Equal(1, frame.Channels);
        }

        /// <summary>
        ///     Tests that the constructor with two channels creates a stereo frame.
        /// </summary>
        [Fact]
        public void Constructor_WithTwoChannels_ShouldCreateStereoFrame()
        {
            AudioFrame frame = new AudioFrame(2);

            Assert.Equal(2, frame.Channels);
        }

        /// <summary>
        ///     Tests that the constructor with eight channels creates a multichannel frame.
        /// </summary>
        [Fact]
        public void Constructor_WithEightChannels_ShouldCreateMultiChannelFrame()
        {
            AudioFrame frame = new AudioFrame(8);

            Assert.Equal(8, frame.Channels);
        }

        /// <summary>
        ///     Tests that LoadedSamples reflects the partial amount read after a partial load.
        /// </summary>
        [Fact]
        public void Load_FromQuarterStream_ShouldSetLoadedSamplesToQuarterSampleCount()
        {
            AudioFrame frame = new AudioFrame(2, 100);
            byte[] testData = new byte[100];
            MemoryStream stream = new MemoryStream(testData);

            frame.Load(stream);

            Assert.Equal(25, frame.LoadedSamples);
        }

        /// <summary>
        ///     Tests that RawData contains the expected byte values after loading known data.
        /// </summary>
        [Fact]
        public void Load_WithKnownData_ShouldCopyBytesIntoRawData()
        {
            AudioFrame frame = new AudioFrame(1, 4);
            byte[] testData = new byte[] { 10, 20, 30, 40, 50, 60, 70, 80 };
            MemoryStream stream = new MemoryStream(testData);

            frame.Load(stream);

            Assert.Equal(8, frame.RawData.Length);
            Assert.Equal(10, frame.RawData[0]);
            Assert.Equal(20, frame.RawData[1]);
            Assert.Equal(80, frame.RawData[7]);
        }
    }
}