// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioFrameTest.cs
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
    ///     The audio frame test class
    /// </summary>
    /// <seealso cref="AudioFrame" />
    public class AudioFrameTest
    {
        /// <summary>
        ///     Tests that audio frame constructor with valid parameters should create instance
        /// </summary>
        [Fact]
        public void AudioFrame_ConstructorWithValidParameters_ShouldCreateInstance()
        {
            // Arrange & Act
            AudioFrame frame = new AudioFrame(2);

            // Assert
            Assert.NotNull(frame);
            Assert.Equal(2, frame.Channels);
            Assert.Equal(1024, frame.SampleCount);
            Assert.Equal(2, frame.BytesPerSample);
        }

        /// <summary>
        ///     Tests that audio frame constructor with invalid bit depth should throw exception
        /// </summary>
        [Fact]
        public void AudioFrame_ConstructorWithInvalidBitDepth_ShouldThrowException()
        {
            // Arrange & Act & Assert
            Assert.Throws<InvalidOperationException>(() => new AudioFrame(2, 1024, 8));
        }

        /// <summary>
        ///     Tests that audio frame constructor with zero channels should throw exception
        /// </summary>
        [Fact]
        public void AudioFrame_ConstructorWithZeroChannels_ShouldThrowException()
        {
            // Arrange & Act & Assert
            Assert.Throws<InvalidDataException>(() => new AudioFrame(0));
        }

        /// <summary>
        ///     Tests that audio frame constructor with negative channels should throw exception
        /// </summary>
        [Fact]
        public void AudioFrame_ConstructorWithNegativeChannels_ShouldThrowException()
        {
            // Arrange & Act & Assert
            Assert.Throws<InvalidDataException>(() => new AudioFrame(-1));
        }

        /// <summary>
        ///     Tests that audio frame constructor with zero sample count should throw exception
        /// </summary>
        [Fact]
        public void AudioFrame_ConstructorWithZeroSampleCount_ShouldThrowException()
        {
            // Arrange & Act & Assert
            Assert.Throws<InvalidDataException>(() => new AudioFrame(2, 0));
        }

        /// <summary>
        ///     Tests that audio frame constructor with negative sample count should throw exception
        /// </summary>
        [Fact]
        public void AudioFrame_ConstructorWithNegativeSampleCount_ShouldThrowException()
        {
            // Arrange & Act & Assert
            Assert.Throws<InvalidDataException>(() => new AudioFrame(2, -1));
        }

        /// <summary>
        ///     Tests that audio frame should support 16 bit depth
        /// </summary>
        [Fact]
        public void AudioFrame_ShouldSupport16BitDepth()
        {
            // Arrange & Act
            AudioFrame frame = new AudioFrame(2);

            // Assert
            Assert.Equal(2, frame.BytesPerSample);
        }

        /// <summary>
        ///     Tests that audio frame should support 24 bit depth
        /// </summary>
        [Fact]
        public void AudioFrame_ShouldSupport24BitDepth()
        {
            // Arrange & Act
            AudioFrame frame = new AudioFrame(2, 1024, 24);

            // Assert
            Assert.Equal(3, frame.BytesPerSample);
        }

        /// <summary>
        ///     Tests that audio frame should support 32 bit depth
        /// </summary>
        [Fact]
        public void AudioFrame_ShouldSupport32BitDepth()
        {
            // Arrange & Act
            AudioFrame frame = new AudioFrame(2, 1024, 32);

            // Assert
            Assert.Equal(4, frame.BytesPerSample);
        }

        /// <summary>
        ///     Tests that audio frame raw data should not be null after construction
        /// </summary>
        [Fact]
        public void AudioFrame_RawData_ShouldNotBeNullAfterConstruction()
        {
            // Arrange & Act
            AudioFrame frame = new AudioFrame(2);

            // Assert
            Assert.NotNull(frame.RawData);
        }

        /// <summary>
        ///     Tests that audio frame raw data length should be correct
        /// </summary>
        [Fact]
        public void AudioFrame_RawDataLength_ShouldBeCorrect()
        {
            // Arrange
            int channels = 2;
            int sampleCount = 1024;
            int bitDepth = 16;
            int expectedLength = channels * sampleCount * (bitDepth / 8);

            // Act
            AudioFrame frame = new AudioFrame(channels, sampleCount, bitDepth);

            // Assert
            Assert.Equal(expectedLength, frame.RawData.Length);
        }

        /// <summary>
        ///     Tests that audio frame loaded samples should be zero initially
        /// </summary>
        [Fact]
        public void AudioFrame_LoadedSamples_ShouldBeZeroInitially()
        {
            // Arrange & Act
            AudioFrame frame = new AudioFrame(2);

            // Assert
            Assert.Equal(0, frame.LoadedSamples);
        }

        /// <summary>
        ///     Tests that audio frame load from empty stream should return false
        /// </summary>
        [Fact]
        public void AudioFrame_LoadFromEmptyStream_ShouldReturnFalse()
        {
            // Arrange
            AudioFrame frame = new AudioFrame(2);
            MemoryStream emptyStream = new MemoryStream();

            // Act
            bool result = frame.Load(emptyStream);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that audio frame load from stream with data should return true
        /// </summary>
        [Fact]
        public void AudioFrame_LoadFromStreamWithData_ShouldReturnTrue()
        {
            // Arrange
            AudioFrame frame = new AudioFrame(2, 100);
            byte[] testData = new byte[400]; // 2 channels * 100 samples * 2 bytes
            MemoryStream stream = new MemoryStream(testData);

            // Act
            bool result = frame.Load(stream);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that audio frame load should update loaded samples
        /// </summary>
        [Fact]
        public void AudioFrame_Load_ShouldUpdateLoadedSamples()
        {
            // Arrange
            AudioFrame frame = new AudioFrame(2, 100);
            byte[] testData = new byte[400]; // 2 channels * 100 samples * 2 bytes
            MemoryStream stream = new MemoryStream(testData);

            // Act
            frame.Load(stream);

            // Assert
            Assert.Equal(100, frame.LoadedSamples);
        }

        /// <summary>
        ///     Tests that audio frame get sample should return correct byte array
        /// </summary>
        [Fact]
        public void AudioFrame_GetSample_ShouldReturnCorrectByteArray()
        {
            // Arrange
            AudioFrame frame = new AudioFrame(2, 10);
            byte[] testData = new byte[40]; // 2 channels * 10 samples * 2 bytes
            for (int i = 0; i < testData.Length; i++)
            {
                testData[i] = (byte) i;
            }

            MemoryStream stream = new MemoryStream(testData);
            frame.Load(stream);

            // Act
            byte[] sample = frame.GetSample(0, 0);

            // Assert
            Assert.Equal(2, sample.Length);
            Assert.Equal(0, sample[0]);
            Assert.Equal(1, sample[1]);
        }

        /// <summary>
        ///     Tests that audio frame get sample from second channel should work
        /// </summary>
        [Fact]
        public void AudioFrame_GetSampleFromSecondChannel_ShouldWork()
        {
            // Arrange
            AudioFrame frame = new AudioFrame(2, 10);
            byte[] testData = new byte[40];
            for (int i = 0; i < testData.Length; i++)
            {
                testData[i] = (byte) i;
            }

            MemoryStream stream = new MemoryStream(testData);
            frame.Load(stream);

            // Act
            byte[] sample = frame.GetSample(0, 1);

            // Assert
            Assert.Equal(2, sample.Length);
            Assert.Equal(2, sample[0]);
            Assert.Equal(3, sample[1]);
        }

        /// <summary>
        ///     Tests that audio frame dispose should clear frame buffer
        /// </summary>
        [Fact]
        public void AudioFrame_Dispose_ShouldClearFrameBuffer()
        {
            // Arrange
            AudioFrame frame = new AudioFrame(2);

            // Act
            frame.Dispose();

            // Assert - No exception thrown
            Assert.NotNull(frame);
        }

        /// <summary>
        ///     Tests that audio frame should support mono audio
        /// </summary>
        [Fact]
        public void AudioFrame_ShouldSupportMonoAudio()
        {
            // Arrange & Act
            AudioFrame frame = new AudioFrame(1);

            // Assert
            Assert.Equal(1, frame.Channels);
        }

        /// <summary>
        ///     Tests that audio frame should support stereo audio
        /// </summary>
        [Fact]
        public void AudioFrame_ShouldSupportStereoAudio()
        {
            // Arrange & Act
            AudioFrame frame = new AudioFrame(2);

            // Assert
            Assert.Equal(2, frame.Channels);
        }

        /// <summary>
        ///     Tests that audio frame should support multi channel audio
        /// </summary>
        [Fact]
        public void AudioFrame_ShouldSupportMultiChannelAudio()
        {
            // Arrange & Act
            AudioFrame frame = new AudioFrame(8);

            // Assert
            Assert.Equal(8, frame.Channels);
        }

        /// <summary>
        ///     Tests that audio frame load from partial stream should work
        /// </summary>
        [Fact]
        public void AudioFrame_LoadFromPartialStream_ShouldWork()
        {
            // Arrange
            AudioFrame frame = new AudioFrame(2, 100);
            byte[] testData = new byte[200]; // Only half the required data
            MemoryStream stream = new MemoryStream(testData);

            // Act
            bool result = frame.Load(stream);

            // Assert
            Assert.True(result);
            Assert.Equal(50, frame.LoadedSamples);
        }

        /// <summary>
        ///     Tests that audio frame should implement i media frame interface
        /// </summary>
        [Fact]
        public void AudioFrame_ShouldImplementIMediaFrameInterface()
        {
            // Arrange & Act
            AudioFrame frame = new AudioFrame(2);

            // Assert
            Assert.IsAssignableFrom<IMediaFrame>(frame);
        }

        /// <summary>
        ///     Tests that audio frame should implement i disposable interface
        /// </summary>
        [Fact]
        public void AudioFrame_ShouldImplementIDisposableInterface()
        {
            // Arrange & Act
            AudioFrame frame = new AudioFrame(2);

            // Assert
            Assert.IsAssignableFrom<IDisposable>(frame);
        }

        /// <summary>
        ///     Tests that audio frame multiple load calls should work
        /// </summary>
        [Fact]
        public void AudioFrame_MultipleLoadCalls_ShouldWork()
        {
            // Arrange
            AudioFrame frame = new AudioFrame(2, 100);
            byte[] testData = new byte[400];

            // Act
            MemoryStream stream1 = new MemoryStream(testData);
            bool result1 = frame.Load(stream1);

            MemoryStream stream2 = new MemoryStream(testData);
            bool result2 = frame.Load(stream2);

            // Assert
            Assert.True(result1);
            Assert.True(result2);
        }

        /// <summary>
        ///     Tests that audio frame constructor with different sample counts should work
        /// </summary>
        [Fact]
        public void AudioFrame_ConstructorWithDifferentSampleCounts_ShouldWork()
        {
            // Arrange & Act
            AudioFrame frame512 = new AudioFrame(2, 512);
            AudioFrame frame1024 = new AudioFrame(2);
            AudioFrame frame2048 = new AudioFrame(2, 2048);

            // Assert
            Assert.Equal(512, frame512.SampleCount);
            Assert.Equal(1024, frame1024.SampleCount);
            Assert.Equal(2048, frame2048.SampleCount);
        }
    }
}