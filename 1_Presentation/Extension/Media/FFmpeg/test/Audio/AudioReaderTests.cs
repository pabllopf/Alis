// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioReaderTests.cs
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
using System.Reflection;
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.Audio.Models;
using Alis.Extension.Media.FFmpeg.BaseClasses;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Moq;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    public class AudioReaderTests
    {
        [Fact]
        public void Constructor_WithNonExistentFile_ThrowsFileNotFoundException()
        {
            FileNotFoundException ex = Assert.Throws<FileNotFoundException>(() => new AudioReader("/nonexistent/file.mp3"));
            Assert.Contains("not found", ex.Message);
        }

        [Fact]
        public void Constructor_WithExistingFile_CreatesInstance()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                using AudioReader reader = new AudioReader(tempFile);
                Assert.NotNull(reader);
                Assert.Equal(tempFile, reader.Filename);
                Assert.Equal(0, reader.CurrentSampleOffset);
                Assert.False(reader.MetadataLoaded);
                Assert.Null(reader.Metadata);
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        [Fact]
        public void Constructor_WithCustomExecutables_CreatesInstance()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                using AudioReader reader = new AudioReader(tempFile, "custom-ffmpeg", "custom-ffprobe");
                Assert.NotNull(reader);
                Assert.Equal(tempFile, reader.Filename);
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        [Fact]
        public void CurrentSampleOffset_Default_IsZero()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                using AudioReader reader = new AudioReader(tempFile);
                Assert.Equal(0, reader.CurrentSampleOffset);
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        [Fact]
        public void MetadataLoaded_Default_IsFalse()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                using AudioReader reader = new AudioReader(tempFile);
                Assert.False(reader.MetadataLoaded);
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        [Fact]
        public void Metadata_Default_IsNull()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                using AudioReader reader = new AudioReader(tempFile);
                Assert.Null(reader.Metadata);
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        [Fact]
        public void Dispose_MultipleCalls_DoesNotThrow()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                AudioReader reader = new AudioReader(tempFile);
                reader.Dispose();
                reader.Dispose();
                reader.Dispose();
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        [Fact]
        public void Dispose_WithDataStream_DisposesStream()
        {
            TestableAudioReader reader = new TestableAudioReader(Path.GetTempFileName());
            using MemoryStream stream = new MemoryStream(new byte[] { 1, 2, 3 });
            reader.SetDataStream(stream);

            Assert.True(stream.CanRead);
            reader.Dispose();
            Assert.False(stream.CanRead);
        }

        [Fact]
        public void Dispose_WithNullDataStream_DoesNotThrow()
        {
            TestableAudioReader reader = new TestableAudioReader(Path.GetTempFileName());
            Exception ex = Record.Exception(() => reader.Dispose());
            Assert.Null(ex);
        }

        [Fact]
        public void Dispose_WithDisposingTrue_DisposesStream()
        {
            TestableAudioReader reader = new TestableAudioReader(Path.GetTempFileName());
            MemoryStream stream = new MemoryStream(new byte[] { 1, 2, 3 });
            reader.SetDataStream(stream);

            MethodInfo disposeMethod = typeof(AudioReader).GetMethod("Dispose",
                BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(bool) }, null);
            disposeMethod.Invoke(reader, new object[] { true });

            Assert.False(stream.CanRead);
        }

        [Fact]
        public void Dispose_WithDisposingFalse_DoesNotReleaseStream()
        {
            TestableAudioReader reader = new TestableAudioReader(Path.GetTempFileName());
            MemoryStream stream = new MemoryStream(new byte[] { 1, 2, 3 });
            reader.SetDataStream(stream);

            MethodInfo disposeMethod = typeof(AudioReader).GetMethod("Dispose",
                BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(bool) }, null);
            disposeMethod.Invoke(reader, new object[] { false });

            Assert.True(stream.CanRead);
        }

        [Fact]
        public void ResolveBitDepth_WhenAlreadySet_DoesNotChange()
        {
            AudioMetadata metadata = new AudioMetadata { BitDepth = 32, SampleFormat = "s16" };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(32, metadata.BitDepth);
        }

        [Fact]
        public void ResolveBitDepth_WithNullSampleFormat_DoesNotChange()
        {
            AudioMetadata metadata = new AudioMetadata { BitDepth = 0, SampleFormat = null };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(0, metadata.BitDepth);
        }

        [Fact]
        public void ResolveBitDepth_WithEmptySampleFormat_DoesNotChange()
        {
            AudioMetadata metadata = new AudioMetadata { BitDepth = 0, SampleFormat = string.Empty };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(0, metadata.BitDepth);
        }

        [Fact]
        public void ResolveBitDepth_WithUnknownFormat_DoesNotChange()
        {
            AudioMetadata metadata = new AudioMetadata { BitDepth = 0, SampleFormat = "unknown_format" };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(0, metadata.BitDepth);
        }

        [Fact]
        public void ResolveBitDepth_With64Format_Sets64()
        {
            AudioMetadata metadata = new AudioMetadata { BitDepth = 0, SampleFormat = "s64le" };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(64, metadata.BitDepth);
        }

        [Fact]
        public void ResolveBitDepth_With32Format_Sets32()
        {
            AudioMetadata metadata = new AudioMetadata { BitDepth = 0, SampleFormat = "fltp32" };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(32, metadata.BitDepth);
        }

        [Fact]
        public void ResolveBitDepth_With24Format_Sets24()
        {
            AudioMetadata metadata = new AudioMetadata { BitDepth = 0, SampleFormat = "s24le" };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(24, metadata.BitDepth);
        }

        [Fact]
        public void ResolveBitDepth_With16Format_Sets16()
        {
            AudioMetadata metadata = new AudioMetadata { BitDepth = 0, SampleFormat = "s16le" };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(16, metadata.BitDepth);
        }

        [Fact]
        public void ResolveBitDepth_With8Format_Sets8()
        {
            AudioMetadata metadata = new AudioMetadata { BitDepth = 0, SampleFormat = "u8" };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(8, metadata.BitDepth);
        }

        [Fact]
        public void ResolveBitDepth_WithMultipleIndicators_MatchesFirstInOrder()
        {
            AudioMetadata metadata = new AudioMetadata { BitDepth = 0, SampleFormat = "s16s32" };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(32, metadata.BitDepth);
        }

        [Fact]
        public void ResolveBitDepth_With64InMiddle_Sets64()
        {
            AudioMetadata metadata = new AudioMetadata { BitDepth = 0, SampleFormat = "double64le" };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(64, metadata.BitDepth);
        }

        [Fact]
        public void ResolveBitDepth_With32InMiddle_Sets32()
        {
            AudioMetadata metadata = new AudioMetadata { BitDepth = 0, SampleFormat = "float32be" };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(32, metadata.BitDepth);
        }

        [Fact]
        public void ResolveBitDepth_WithExistingBitDepthAndNullFormat_KeepsExisting()
        {
            AudioMetadata metadata = new AudioMetadata { BitDepth = 24, SampleFormat = null };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(24, metadata.BitDepth);
        }

        [Fact]
        public void LoadMetadata_WhenAlreadyLoaded_ThrowsInvalidOperationException()
        {
            TestableAudioReader reader = new TestableAudioReader(Path.GetTempFileName());
            PropertyInfo prop = typeof(AudioReader).GetProperty("MetadataLoaded", BindingFlags.Public | BindingFlags.Instance);
            prop.SetValue(reader, true);

            AggregateException ex = Assert.Throws<AggregateException>(() => reader.LoadMetadata());

            Assert.Contains("already loaded", ex.InnerException.Message);
        }

        [Fact]
        public async System.Threading.Tasks.Task LoadMetadataAsync_WhenAlreadyLoaded_ThrowsInvalidOperationException()
        {
            TestableAudioReader reader = new TestableAudioReader(Path.GetTempFileName());
            PropertyInfo prop = typeof(AudioReader).GetProperty("MetadataLoaded", BindingFlags.Public | BindingFlags.Instance);
            prop.SetValue(reader, true);

            InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(() => reader.LoadMetadataAsync());

            Assert.Contains("already loaded", ex.Message);
        }

        [Fact]
        public void Load_WithInvalidBitDepth8_ThrowsInvalidOperationException()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                using AudioReader reader = new AudioReader(tempFile);
                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.Load(8));
                Assert.Contains("bit depths", ex.Message);
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        [Fact]
        public void Load_WithInvalidBitDepth64_ThrowsInvalidOperationException()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                using AudioReader reader = new AudioReader(tempFile);
                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.Load(64));
                Assert.Contains("bit depths", ex.Message);
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        [Fact]
        public void Load_WithInvalidBitDepth20_ThrowsInvalidOperationException()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                using AudioReader reader = new AudioReader(tempFile);
                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.Load(20));
                Assert.Contains("bit depths", ex.Message);
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        [Fact]
        public void Load_WhenAlreadyOpened_ThrowsInvalidOperationException()
        {
            TestableAudioReader reader = new TestableAudioReader(Path.GetTempFileName());
            reader.SetOpenedForReading(true);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.Load(16));

            Assert.Contains("already loaded", ex.Message);
        }

        [Fact]
        public void Load_WhenMetadataNotLoaded_ThrowsInvalidOperationException()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                using AudioReader reader = new AudioReader(tempFile);
                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.Load(16));
                Assert.Contains("metadata", ex.Message);
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        [Fact]
        public void NextFrame_WithoutLoading_ThrowsNullReferenceException()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                using AudioReader reader = new AudioReader(tempFile);
                Assert.Throws<NullReferenceException>(() => reader.NextFrame());
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        [Fact]
        public void NextFrame_WithSamples_WithoutLoading_ThrowsNullReferenceException()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                using AudioReader reader = new AudioReader(tempFile);
                Assert.Throws<NullReferenceException>(() => reader.NextFrame(1024));
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        [Fact]
        public void NextFrame_WithBuffer_WhenNotOpened_ThrowsInvalidOperationException()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                using AudioReader reader = new AudioReader(tempFile);
                AudioFrame frame = new AudioFrame(2, 1024, 16);
                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.NextFrame(frame));
                Assert.Contains("load the audio", ex.Message);
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        [Fact]
        public void NextFrame_Frame_WhenStreamHasData_ReturnsFrameAndUpdatesOffset()
        {
            TestableAudioReader reader = new TestableAudioReader(Path.GetTempFileName());
            int channels = 2;
            int sampleCount = 1024;
            int bitDepth = 16;
            int frameSize = sampleCount * channels * (bitDepth / 8);

            byte[] pcmData = new byte[frameSize];
            for (int i = 0; i < pcmData.Length; i++)
            {
                pcmData[i] = (byte)(i % 256);
            }

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

        [Fact]
        public void NextFrame_Frame_WhenStreamIsEmpty_ReturnsNull()
        {
            TestableAudioReader reader = new TestableAudioReader(Path.GetTempFileName());
            reader.SetOpenedForReading(true);
            reader.SetDataStream(new MemoryStream());

            long initialOffset = reader.CurrentSampleOffset;
            AudioFrame frame = new AudioFrame(2, 1024, 16);
            AudioFrame result = reader.NextFrame(frame);

            Assert.Null(result);
            Assert.Equal(0, frame.LoadedSamples);
            Assert.Equal(initialOffset, reader.CurrentSampleOffset);
        }

        [Fact]
        public void NextFrame_Frame_WhenStreamHasPartialData_ReturnsFrame()
        {
            TestableAudioReader reader = new TestableAudioReader(Path.GetTempFileName());
            reader.SetOpenedForReading(true);
            reader.SetDataStream(new MemoryStream(new byte[] { 1, 2, 3, 4 }));

            long initialOffset = reader.CurrentSampleOffset;
            AudioFrame frame = new AudioFrame(2, 1024, 16);
            AudioFrame result = reader.NextFrame(frame);

            Assert.NotNull(result);
            Assert.Equal(1, result.LoadedSamples);
            Assert.Equal(1, reader.CurrentSampleOffset - initialOffset);
        }

        [Fact]
        public void NextFrame_Parameterless_DelegatesToIntOverload()
        {
            TestableAudioReader reader = new TestableAudioReader(Path.GetTempFileName());
            reader.SetOpenedForReading(true);
            reader.SetDataStream(new MemoryStream(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 }));
            PropertyInfo metadataProp = typeof(AudioReader).GetProperty("Metadata", BindingFlags.Public | BindingFlags.Instance);
            metadataProp.SetValue(reader, new AudioMetadata { Channels = 2 });

            AudioFrame result = reader.NextFrame();

            Assert.NotNull(result);
            Assert.True(result.LoadedSamples > 0);
        }

        [Fact]
        public void Load_WithBitDepth16_AndValidMetadata_OpensReader()
        {
            string ffmpegScript = CreateExecutableScript("#!/bin/sh\nexit 0\n");
            TestableAudioReader reader = new TestableAudioReader(Path.GetTempFileName(), ffmpegScript);
            PropertyInfo metadataLoaded = typeof(AudioReader).GetProperty("MetadataLoaded", BindingFlags.Public | BindingFlags.Instance);
            metadataLoaded.SetValue(reader, true);
            PropertyInfo metadata = typeof(AudioReader).GetProperty("Metadata", BindingFlags.Public | BindingFlags.Instance);
            metadata.SetValue(reader, new AudioMetadata { Channels = 2 });

            try
            {
                reader.Load(16);
                Assert.True(reader.OpenedForReading);
                Assert.NotNull(reader.DataStream);
            }
            finally
            {
                if (File.Exists(ffmpegScript))
                {
                    File.Delete(ffmpegScript);
                }
            }
        }

        [Fact]
        public void Load_WithBitDepth24_AndValidMetadata_OpensReader()
        {
            string ffmpegScript = CreateExecutableScript("#!/bin/sh\nexit 0\n");
            TestableAudioReader reader = new TestableAudioReader(Path.GetTempFileName(), ffmpegScript);
            PropertyInfo metadataLoaded = typeof(AudioReader).GetProperty("MetadataLoaded", BindingFlags.Public | BindingFlags.Instance);
            metadataLoaded.SetValue(reader, true);
            PropertyInfo metadata = typeof(AudioReader).GetProperty("Metadata", BindingFlags.Public | BindingFlags.Instance);
            metadata.SetValue(reader, new AudioMetadata { Channels = 2 });

            try
            {
                reader.Load(24);
                Assert.True(reader.OpenedForReading);
                Assert.NotNull(reader.DataStream);
            }
            finally
            {
                if (File.Exists(ffmpegScript))
                {
                    File.Delete(ffmpegScript);
                }
            }
        }

        [Fact]
        public void Load_WithBitDepth32_AndValidMetadata_OpensReader()
        {
            string ffmpegScript = CreateExecutableScript("#!/bin/sh\nexit 0\n");
            TestableAudioReader reader = new TestableAudioReader(Path.GetTempFileName(), ffmpegScript);
            PropertyInfo metadataLoaded = typeof(AudioReader).GetProperty("MetadataLoaded", BindingFlags.Public | BindingFlags.Instance);
            metadataLoaded.SetValue(reader, true);
            PropertyInfo metadata = typeof(AudioReader).GetProperty("Metadata", BindingFlags.Public | BindingFlags.Instance);
            metadata.SetValue(reader, new AudioMetadata { Channels = 2 });

            try
            {
                reader.Load(32);
                Assert.True(reader.OpenedForReading);
                Assert.NotNull(reader.DataStream);
            }
            finally
            {
                if (File.Exists(ffmpegScript))
                {
                    File.Delete(ffmpegScript);
                }
            }
        }

        [RequireFfmpegFact]
        public void LoadMetadata_WithRealWavFile_Succeeds()
        {
            string realWav = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".wav");
            try
            {
                using Process process = new Process();
                process.StartInfo.FileName = "ffmpeg";
                process.StartInfo.Arguments = $"-f lavfi -i anullsrc=r=44100:cl=mono -t 0.5 -acodec pcm_s16le -f wav \"{realWav}\" -y -loglevel quiet";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.WaitForExit(10000);

                if (!File.Exists(realWav))
                {
                    return;
                }

                using AudioReader reader = new AudioReader(realWav);
                reader.LoadMetadata();

                Assert.True(reader.MetadataLoaded);
                Assert.NotNull(reader.Metadata);
            }
            finally
            {
                if (File.Exists(realWav))
                {
                    try { File.Delete(realWav); }
                    catch { }
                }
            }
        }

        [RequireFfmpegFact]
        public void LoadMetadataAsync_WithRealWavFile_Succeeds()
        {
            string realWav = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".wav");
            try
            {
                using Process process = new Process();
                process.StartInfo.FileName = "ffmpeg";
                process.StartInfo.Arguments = $"-f lavfi -i anullsrc=r=44100:cl=mono -t 0.5 -acodec pcm_s16le -f wav \"{realWav}\" -y -loglevel quiet";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.WaitForExit(10000);

                if (!File.Exists(realWav))
                {
                    return;
                }

                using AudioReader reader = new AudioReader(realWav);
                Exception ex = Record.Exception(() => reader.LoadMetadataAsync().Wait());

                Assert.Null(ex);
                Assert.True(reader.MetadataLoaded);
                Assert.NotNull(reader.Metadata);
            }
            finally
            {
                if (File.Exists(realWav))
                {
                    try { File.Delete(realWav); }
                    catch { }
                }
            }
        }

        [RequireFfmpegFact]
        public void LoadMetadataAsync_WithRealWavFileAndIgnoreStreamErrors_Succeeds()
        {
            string realWav = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".wav");
            try
            {
                using Process process = new Process();
                process.StartInfo.FileName = "ffmpeg";
                process.StartInfo.Arguments = $"-f lavfi -i anullsrc=r=44100:cl=mono -t 0.5 -acodec pcm_s16le -f wav \"{realWav}\" -y -loglevel quiet";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.WaitForExit(10000);

                if (!File.Exists(realWav))
                {
                    return;
                }

                using AudioReader reader = new AudioReader(realWav);
                Exception ex = Record.Exception(() => reader.LoadMetadataAsync(ignoreStreamErrors: true).Wait());

                Assert.Null(ex);
                Assert.True(reader.MetadataLoaded);
            }
            finally
            {
                if (File.Exists(realWav))
                {
                    try { File.Delete(realWav); }
                    catch { }
                }
            }
        }

        [RequireFfmpegFact]
        public void LoadMetadataAsync_WithRealWavFile_PopulatesMetadata()
        {
            string realWav = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".wav");
            try
            {
                using Process process = new Process();
                process.StartInfo.FileName = "ffmpeg";
                process.StartInfo.Arguments = $"-f lavfi -i anullsrc=r=44100:cl=mono -t 0.5 -acodec pcm_s16le -f wav \"{realWav}\" -y -loglevel quiet";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.WaitForExit(10000);

                if (!File.Exists(realWav))
                {
                    return;
                }

                using AudioReader reader = new AudioReader(realWav);
                reader.LoadMetadataAsync().Wait();

                Assert.True(reader.MetadataLoaded);
                Assert.NotNull(reader.Metadata);
            }
            finally
            {
                if (File.Exists(realWav))
                {
                    try { File.Delete(realWav); }
                    catch { }
                }
            }
        }

        [RequireFfmpegFact]
        public void LoadAsync_AfterMetadataLoad_WithRealWavFile_OpensDataStream()
        {
            string realWav = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".wav");
            try
            {
                using Process process = new Process();
                process.StartInfo.FileName = "ffmpeg";
                process.StartInfo.Arguments = $"-f lavfi -i anullsrc=r=44100:cl=mono -t 0.5 -acodec pcm_s16le -f wav \"{realWav}\" -y -loglevel quiet";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.WaitForExit(10000);

                if (!File.Exists(realWav))
                {
                    return;
                }

                using AudioReader reader = new AudioReader(realWav);
                reader.LoadMetadataAsync().Wait();
                reader.Load(16);

                Assert.True(reader.OpenedForReading);
                Assert.NotNull(reader.DataStream);
            }
            finally
            {
                if (File.Exists(realWav))
                {
                    try { File.Delete(realWav); }
                    catch { }
                }
            }
        }

        [Fact]
        public void CopyTo_WhenDataStreamIsNull_ThrowsInvalidOperationException()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                using AudioReader reader = new AudioReader(tempFile);
                Mock<MediaWriter<AudioFrame>> mockWriter = new Mock<MediaWriter<AudioFrame>>();

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.CopyTo(mockWriter.Object));

                Assert.Contains("not opened for reading", ex.Message);
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        [Fact]
        public void CopyTo_WhenWriterNotOpened_ThrowsInvalidOperationException()
        {
            TestableAudioReader reader = new TestableAudioReader(Path.GetTempFileName());
            reader.SetDataStream(new MemoryStream(new byte[] { 1, 2, 3 }));

            Mock<MediaWriter<AudioFrame>> mockWriter = new Mock<MediaWriter<AudioFrame>>();
            mockWriter.Setup(w => w.OpenedForWriting).Returns(false);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.CopyTo(mockWriter.Object));

            Assert.Contains("not opened for writing", ex.Message);
        }

        [Fact]
        public void CopyTo_WhenBothReaderAndWriterReady_CopiesData()
        {
            TestableAudioReader reader = new TestableAudioReader(Path.GetTempFileName());
            byte[] testData = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            reader.SetDataStream(new MemoryStream(testData));

            MemoryStream destStream = new MemoryStream();
            Mock<MediaWriter<AudioFrame>> mockWriter = new Mock<MediaWriter<AudioFrame>>();
            mockWriter.Setup(w => w.OpenedForWriting).Returns(true);
            mockWriter.Setup(w => w.InputDataStream).Returns(destStream);

            reader.CopyTo(mockWriter.Object);

            Assert.Equal(testData, destStream.ToArray());
        }

        private static string CreateExecutableScript(string contents)
        {
            string scriptPath = Path.GetTempFileName();
            File.WriteAllText(scriptPath, contents);
            File.SetUnixFileMode(
                scriptPath,
                UnixFileMode.UserRead |
                UnixFileMode.UserWrite |
                UnixFileMode.UserExecute |
                UnixFileMode.GroupRead |
                UnixFileMode.GroupExecute |
                UnixFileMode.OtherRead |
                UnixFileMode.OtherExecute);
            return scriptPath;
        }
    }
}
