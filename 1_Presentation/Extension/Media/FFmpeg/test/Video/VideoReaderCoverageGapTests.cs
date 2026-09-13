// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoReaderCoverageGapTests.cs
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
using System.Threading.Tasks;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    ///     The video reader coverage gap tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class VideoReaderCoverageGapTests : IDisposable
    {
        /// <summary>
        ///     The temp dir
        /// </summary>
        private readonly string _tempDir;

        /// <summary>
        ///     The fake media file
        /// </summary>
        private readonly string _mediaFile;

        /// <summary>
        ///     The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoReaderCoverageGapTests"/> class
        /// </summary>
        public VideoReaderCoverageGapTests()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);
            _mediaFile = Path.Combine(_tempDir, "sample.mp4");
            File.WriteAllText(_mediaFile, string.Empty);
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                try { Directory.Delete(_tempDir, recursive: true); } catch { }
            }
        }

        /// <summary>
        ///     Creates a fake ffprobe script that prints the given fixed json content
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="json">The json</param>
        private string CreateFakeFfprobe(string name, string json)
        {
            string payloadPath = Path.Combine(_tempDir, name + ".json");
            File.WriteAllText(payloadPath, json);
            string scriptPath = Path.Combine(_tempDir, name);
            File.WriteAllText(scriptPath, "#!/bin/bash\ncat \"" + payloadPath + "\"\n");
            using System.Diagnostics.Process chmod = System.Diagnostics.Process.Start("chmod", $"+x \"{scriptPath}\"");
            chmod.WaitForExit();
            return scriptPath;
        }

        /// <summary>
        ///     Creates a reader using the given fake ffprobe interpreter
        /// </summary>
        /// <param name="ffprobePath">The ffprobe path</param>
        private VideoReader CreateReader(string ffprobePath) => new VideoReader(_mediaFile, "ffmpeg", ffprobePath);

        /// <summary>
        ///     Creates a reader whose fake ffprobe emits a fixed valid metadata payload
        /// </summary>
        private VideoReader CreateValidedReader()
        {
            string ffprobe = CreateFakeFfprobe("staticoutput",
                "{\"streams\":[{\"codec_type\":\"video\",\"width\":64,\"height\":32,\"pix_fmt\":\"yuv420p\",\"bit_rate\":\"1000\",\"bits_per_raw_sample\":\"8\",\"duration\":\"10.5\",\"sample_aspect_ratio\":\"1:1\"}],\"format\":{\"duration\":\"10.5\",\"format_name\":\"mov\"}}");
            return CreateReader(ffprobe);
        }

        /// <summary>
        ///     Tests that constructor with missing file should throw file not found
        /// </summary>
        [Fact]
        public void Constructor_WithMissingFile_ShouldThrowFileNotFound()
        {
            string missingPath = Path.Combine(_tempDir, "missing.mp4");
            Assert.Throws<FileNotFoundException>(() => new VideoReader(missingPath));
        }

        /// <summary>
        ///     Tests that constructor should set filename
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetFilename()
        {
            using VideoReader reader = new VideoReader(_mediaFile);
            Assert.Equal(_mediaFile, reader.Filename);
        }

        /// <summary>
        ///     Tests that properties should have default values
        /// </summary>
        [Fact]
        public void Properties_ShouldHaveDefaultValues()
        {
            using VideoReader reader = new VideoReader(_mediaFile);
            Assert.Equal(0L, reader.CurrentFrameOffset);
            Assert.False(reader.LoadedMetadata);
            Assert.Null(reader.Metadata);
            Assert.False(reader.OpenedForReading);
        }

        /// <summary>
        ///     Tests that dispose should dispose data stream
        /// </summary>
        [Fact]
        public void Dispose_ShouldDisposeDataStream()
        {
            GapTestableVideoReader reader = new GapTestableVideoReader(_mediaFile);
            MemoryStream dataStream = new MemoryStream(new byte[10]);
            reader.SetDataStream(dataStream);
            Assert.True(dataStream.CanRead);
            reader.Dispose();
            Assert.False(dataStream.CanRead);
        }

        /// <summary>
        ///     Tests that dispose multiple times should not throw
        /// </summary>
        [Fact]
        public void Dispose_MultipleTimes_ShouldNotThrow()
        {
            VideoReader reader = new VideoReader(_mediaFile);
            reader.Dispose();
            reader.Dispose();
        }

        /// <summary>
        ///     Tests that load when already opened should throw
        /// </summary>
        [Fact]
        public void Load_WhenAlreadyOpened_ShouldThrow()
        {
            GapTestableVideoReader reader = new GapTestableVideoReader(_mediaFile);
            try
            {
                reader.SetOpenedForReading(true);
                Assert.Throws<InvalidOperationException>(() => reader.Load());
            }
            finally
            {
                reader.Dispose();
            }
        }

        /// <summary>
        ///     Tests that next frame without load should throw
        /// </summary>
        [Fact]
        public void NextFrame_WithoutLoad_ShouldThrow()
        {
            GapTestableVideoReader reader = new GapTestableVideoReader(_mediaFile);
            try
            {
                using VideoFrame frame = new VideoFrame(2, 2);
                Assert.Throws<InvalidOperationException>(() => reader.NextFrame(frame));
            }
            finally
            {
                reader.Dispose();
            }
        }

        /// <summary>
        ///     Tests that load without metadata should throw invalid operation
        /// </summary>
        [Fact]
        public void Load_WithoutMetadata_ShouldThrowInvalidOperation()
        {
            using VideoReader reader = new VideoReader(_mediaFile);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.Load());
            Assert.Contains("Please load the video metadata first", ex.Message);
        }

        /// <summary>
        ///     Tests that load metadata async with corrupt output should throw invalid operation
        /// </summary>
        [MacOsOnly]
        public async Task LoadMetadataAsync_WithCorruptOutput_ShouldThrowInvalidOperation()
        {
            string ffprobe = CreateFakeFfprobe("corrupt", "{{{not a json");
            using VideoReader reader = CreateReader(ffprobe);
            InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(() => reader.LoadMetadataAsync());
            Assert.Contains("Failed to interpret ffprobe video metadata output", ex.Message);
        }

        /// <summary>
        ///     Tests that load metadata async should mark metadata as loaded
        /// </summary>
        [MacOsOnly]
        public async Task LoadMetadataAsync_ShouldMarkMetadataLoaded()
        {
            using VideoReader reader = CreateValidedReader();
            await reader.LoadMetadataAsync().WaitAsync(TimeSpan.FromSeconds(30));
            Assert.True(reader.LoadedMetadata);
            Assert.NotNull(reader.Metadata);
            Assert.Equal("mov", reader.Metadata.Format.FormatName);
            Assert.Empty(reader.Metadata.Streams);
        }

        /// <summary>
        ///     Tests that second metadata load should throw already loaded
        /// </summary>
        [MacOsOnly]
        public void LoadMetadata_SecondLoad_ShouldThrowAlreadyLoaded()
        {
            using VideoReader reader = CreateValidedReader();
            reader.LoadMetadata();
            AggregateException ex = Assert.Throws<AggregateException>(() => reader.LoadMetadata());
            Assert.Contains("already loaded", ex.InnerException.Message);
        }

        /// <summary>
        ///     Tests that load after metadata without stream dimensions should throw invalid data
        /// </summary>
        [MacOsOnly]
        public void Load_AfterMetadata_ShouldThrowInvalidData()
        {
            using VideoReader reader = CreateValidedReader();
            reader.LoadMetadata();
            InvalidDataException ex = Assert.Throws<InvalidDataException>(() => reader.Load(1.5));
            Assert.Contains("Loaded metadata contains errors", ex.Message);
        }
    }
    /// <summary>
    ///     The gap testable video reader class
    /// </summary>
    /// <seealso cref="VideoReader"/>
    public class GapTestableVideoReader : VideoReader
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GapTestableVideoReader"/> class
        /// </summary>
        /// <param name="filename">The filename</param>
        public GapTestableVideoReader(string filename)
            : base(filename) { }

        /// <summary>
        ///     Sets the opened for reading using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        public void SetOpenedForReading(bool value) => OpenedForReading = value;

        /// <summary>
        ///     Sets the data stream using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        public void SetDataStream(Stream stream) => DataStream = stream;
    }
}
