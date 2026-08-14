// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioReaderRemainingCoverageTests.cs
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
using System.Diagnostics;
using System.IO;
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.BaseClasses;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Moq;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    /// <summary>
    /// The testable audio reader class
    /// </summary>
    /// <seealso cref="AudioReader"/>
    public class TestableAudioReader : AudioReader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestableAudioReader"/> class
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <param name="ffmpeg">The ffmpeg</param>
        /// <param name="ffprobe">The ffprobe</param>
        public TestableAudioReader(string filename, string ffmpeg = "ffmpeg", string ffprobe = "ffprobe")
            : base(filename, ffmpeg, ffprobe)
        {
        }

        /// <summary>
        /// Sets the data stream using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        public void SetDataStream(Stream stream) => DataStream = stream;

        /// <summary>
        /// Sets the opened for reading using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        public void SetOpenedForReading(bool value) => OpenedForReading = value;
    }

    /// <summary>
    /// The audio reader remaining coverage tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class AudioReaderRemainingCoverageTests : IDisposable
    {
        /// <summary>
        /// The temp file
        /// </summary>
        internal readonly string _tempFile;

        /// <summary>
        /// The real audio wav file
        /// </summary>
        internal readonly string _realAudioFile;

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioReaderRemainingCoverageTests"/> class
        /// </summary>
        public AudioReaderRemainingCoverageTests()
        {
            _tempFile = Path.GetTempFileName();
            _realAudioFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".wav");
            CreateTestWavFile(_realAudioFile);
        }

        /// <summary>
        /// Creates a real WAV test audio file using ffmpeg
        /// </summary>
        private static void CreateTestWavFile(string path)
        {
            using Process process = new Process();
            process.StartInfo.FileName = "ffmpeg";
            process.StartInfo.Arguments = $"-f lavfi -i anullsrc=r=44100:cl=mono -t 0.5 -acodec pcm_s16le -f wav \"{path}\" -y -loglevel quiet";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.WaitForExit(10000);
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (!string.IsNullOrEmpty(_tempFile) && File.Exists(_tempFile))
            {
                File.Delete(_tempFile);
            }
            if (!string.IsNullOrEmpty(_realAudioFile) && File.Exists(_realAudioFile))
            {
                try { File.Delete(_realAudioFile); } catch { }
            }
        }

        /// <summary>
        /// Tests that dispose with data stream set disposes data stream
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WithDataStreamSet_DisposesDataStream()
        {
            TestableAudioReader reader = new TestableAudioReader(_tempFile);
            using MemoryStream stream = new MemoryStream(new byte[] { 1, 2, 3 });
            reader.SetDataStream(stream);

            Assert.True(stream.CanRead);
            reader.Dispose();
            Assert.False(stream.CanRead);
        }

        /// <summary>
        /// Tests that dispose with data stream set multiple calls safe
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WithDataStreamSet_MultipleCalls_Safe()
        {
            TestableAudioReader reader = new TestableAudioReader(_tempFile);
            using MemoryStream stream = new MemoryStream(new byte[] { 1, 2, 3 });
            reader.SetDataStream(stream);

            reader.Dispose();
            reader.Dispose();
            reader.Dispose();
        }

        /// <summary>
        /// Tests that dispose when data stream is null no exception
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WhenDataStreamIsNull_NoException()
        {
            TestableAudioReader reader = new TestableAudioReader(_tempFile);
            Exception ex = Record.Exception(() => reader.Dispose());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that next frame frame when stream has data returns frame and updates offset
        /// </summary>
        [RequireFfmpegFact]
        public void NextFrame_Frame_WhenStreamHasData_ReturnsFrameAndUpdatesOffset()
        {
            TestableAudioReader reader = new TestableAudioReader(_tempFile);
            int channels = 2;
            int sampleCount = 1024;
            int bitDepth = 16;
            int frameSize = sampleCount * channels * (bitDepth / 8);

            byte[] pcmData = new byte[frameSize];
            for (int i = 0; i < pcmData.Length; i++)
                pcmData[i] = (byte)(i % 256);

            reader.SetOpenedForReading(true);
            reader.SetDataStream(new MemoryStream(pcmData));

            long initialOffset = reader.CurrentSampleOffset;
            AudioFrame frame = new AudioFrame(channels, sampleCount, bitDepth);
            AudioFrame result = reader.NextFrame(frame);

            Assert.NotNull(result);
            Assert.Same(frame, result);
            Assert.Equal(sampleCount, frame.LoadedSamples);
            Assert.Equal(sampleCount, reader.CurrentSampleOffset - initialOffset);
        }

        /// <summary>
        /// Tests that next frame frame when stream is empty returns null
        /// </summary>
        [RequireFfmpegFact]
        public void NextFrame_Frame_WhenStreamIsEmpty_ReturnsNull()
        {
            TestableAudioReader reader = new TestableAudioReader(_tempFile);
            reader.SetOpenedForReading(true);
            reader.SetDataStream(new MemoryStream());

            long initialOffset = reader.CurrentSampleOffset;
            AudioFrame frame = new AudioFrame(2, 1024, 16);
            AudioFrame result = reader.NextFrame(frame);

            Assert.Null(result);
            Assert.Equal(0, frame.LoadedSamples);
            Assert.Equal(initialOffset, reader.CurrentSampleOffset);
        }

        /// <summary>
        /// Tests that next frame frame when stream has partial data returns with one sample
        /// </summary>
        [RequireFfmpegFact]
        public void NextFrame_Frame_WhenStreamHasPartialData_ReturnsWithOneSample()
        {
            TestableAudioReader reader = new TestableAudioReader(_tempFile);
            reader.SetOpenedForReading(true);
            reader.SetDataStream(new MemoryStream(new byte[] { 1, 2, 3, 4 }));

            long initialOffset = reader.CurrentSampleOffset;
            AudioFrame frame = new AudioFrame(2, 1024, 16);
            AudioFrame result = reader.NextFrame(frame);

            Assert.NotNull(result);
            Assert.Equal(1, result.LoadedSamples);
            Assert.Equal(1, reader.CurrentSampleOffset - initialOffset);
        }

        /// <summary>
        /// Tests that next frame frame when not opened for reading throws
        /// </summary>
        [RequireFfmpegFact]
        public void NextFrame_Frame_WhenNotOpenedForReading_Throws()
        {
            TestableAudioReader reader = new TestableAudioReader(_tempFile);
            AudioFrame frame = new AudioFrame(2, 1024, 16);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.NextFrame(frame));
            Assert.Contains("load the audio", ex.Message);
        }

        /// <summary>
        /// Tests that copy to when data stream is null throws
        /// </summary>
        [RequireFfmpegFact]
        public void CopyTo_WhenDataStreamIsNull_Throws()
        {
            AudioReader reader = new AudioReader(_tempFile);
            Mock<MediaWriter<AudioFrame>> mockWriter = new Mock<MediaWriter<AudioFrame>>();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.CopyTo(mockWriter.Object));
            Assert.Contains("not opened for reading", ex.Message);
        }

        /// <summary>
        /// Tests that copy to when writer not opened throws
        /// </summary>
        [RequireFfmpegFact]
        public void CopyTo_WhenWriterNotOpened_Throws()
        {
            TestableAudioReader reader = new TestableAudioReader(_tempFile);
            reader.SetDataStream(new MemoryStream(new byte[] { 1, 2, 3 }));

            Mock<MediaWriter<AudioFrame>> mockWriter = new Mock<MediaWriter<AudioFrame>>();
            mockWriter.Setup(w => w.OpenedForWriting).Returns(false);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.CopyTo(mockWriter.Object));
            Assert.Contains("not opened for writing", ex.Message);
        }

        /// <summary>
        /// Tests that LoadMetadataAsync succeeds with a real WAV file using ffprobe.
        /// </summary>
        [RequireFfmpegFact]
        public void LoadMetadataAsync_WithRealAudioFile_Succeeds()
        {
            using AudioReader reader = new AudioReader(_realAudioFile);

            Exception ex = Record.Exception(() => reader.LoadMetadataAsync().Wait(TimeSpan.FromSeconds(30)));

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that LoadMetadataAsync with ignoreStreamErrors=true succeeds with real audio file.
        /// </summary>
        [RequireFfmpegFact]
        public void LoadMetadataAsync_WithIgnoreStreamErrors_AndRealFile_Succeeds()
        {
            using AudioReader reader = new AudioReader(_realAudioFile);

            Exception ex = Record.Exception(() => reader.LoadMetadataAsync(ignoreStreamErrors: true).Wait(TimeSpan.FromSeconds(30)));

            Assert.Null(ex);
            Assert.True(reader.MetadataLoaded);
        }

        /// <summary>
        /// Tests that Load prepares the reader for reading frames after metadata is loaded.
        /// </summary>
        [RequireFfmpegFact]
        public void Load_AfterMetadata_OpensDataStream()
        {
            using AudioReader reader = new AudioReader(_realAudioFile);
            reader.LoadMetadataAsync().Wait(TimeSpan.FromSeconds(30));

            reader.Load(16);

            Assert.True(reader.OpenedForReading);
        }

        /// <summary>
        /// Tests that Load with 24-bit depth works after metadata load.
        /// </summary>
        [RequireFfmpegFact]
        public void Load_WithBitDepth24_Succeeds()
        {
            using AudioReader reader = new AudioReader(_realAudioFile);
            reader.LoadMetadataAsync().Wait(TimeSpan.FromSeconds(30));

            Exception ex = Record.Exception(() => reader.Load(24));

            Assert.Null(ex);
            Assert.True(reader.OpenedForReading);
        }

        /// <summary>
        /// Tests that Load with invalid bit depth (8) throws.
        /// </summary>
        [RequireFfmpegFact]
        public void Load_WithInvalidBitDepth8_Throws()
        {
            using AudioReader reader = new AudioReader(_realAudioFile);
            reader.LoadMetadataAsync().Wait(TimeSpan.FromSeconds(30));

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.Load(8));

            Assert.Contains("bit depths", ex.Message);
        }

        /// <summary>
        /// Tests that Load when already opened throws.
        /// </summary>
        [RequireFfmpegFact]
        public void Load_WhenAlreadyOpened_Throws()
        {
            using AudioReader reader = new AudioReader(_realAudioFile);
            reader.LoadMetadataAsync().Wait(TimeSpan.FromSeconds(30));
            reader.Load(16);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.Load(16));

            Assert.Contains("already loaded", ex.Message);
        }

        /// <summary>
        /// Tests that copy to when both reader and writer ready copies data
        /// </summary>
        [RequireFfmpegFact]
        public void CopyTo_WhenBothReaderAndWriterReady_CopiesData()
        {
            TestableAudioReader reader = new TestableAudioReader(_tempFile);
            byte[] testData = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            reader.SetDataStream(new MemoryStream(testData));

            MemoryStream destStream = new MemoryStream();
            Mock<MediaWriter<AudioFrame>> mockWriter = new Mock<MediaWriter<AudioFrame>>();
            mockWriter.Setup(w => w.OpenedForWriting).Returns(true);
            mockWriter.Setup(w => w.InputDataStream).Returns(destStream);

            reader.CopyTo(mockWriter.Object);

            Assert.Equal(testData, destStream.ToArray());
        }
    }
}
