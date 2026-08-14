// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoReaderLoadCoverageTests.cs
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
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Alis.Extension.Media.FFmpeg.Video;
using Alis.Extension.Media.FFmpeg.Video.Models;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    ///     The video reader load coverage tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class VideoReaderLoadCoverageTests : IDisposable
    {
        /// <summary>
        ///     The temp dir
        /// </summary>
        private readonly string _tempDir;

        /// <summary>
        ///     The real video file
        /// </summary>
        private readonly string _videoFile;

        /// <summary>
        ///     The fake ffprobe path
        /// </summary>
        private readonly string _fakeFfprobePath;

        /// <summary>
        ///     The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoReaderLoadCoverageTests"/> class
        /// </summary>
        public VideoReaderLoadCoverageTests()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);

            _videoFile = Path.Combine(_tempDir, "sample.mp4");
            CreateTestVideo(_videoFile);

            _fakeFfprobePath = Path.Combine(_tempDir, "ffprobe");
            File.WriteAllText(_fakeFfprobePath, "#!/bin/bash\necho '{{{ not valid json'");
            using Process chmod = Process.Start("chmod", $"+x \"{_fakeFfprobePath}\"");
            chmod.WaitForExit();
        }

        /// <summary>
        ///     Creates a real test video file using ffmpeg
        /// </summary>
        /// <param name="path">The path</param>
        private static void CreateTestVideo(string path)
        {
            using Process process = new Process();
            process.StartInfo.FileName = "ffmpeg";
            process.StartInfo.Arguments = $"-f lavfi -i testsrc=duration=1:size=16x16:rate=2 -c:v libx264 -pix_fmt yuv420p \"{path}\" -y -loglevel quiet";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.WaitForExit(30000);
        }

        /// <summary>
        ///     Sets the backing field using the specified obj
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <param name="propName">The prop name</param>
        /// <param name="value">The value</param>
        private static void SetBackingField(object obj, string propName, object value)
        {
            FieldInfo field = obj.GetType().GetField($"<{propName}>k__BackingField",
                BindingFlags.NonPublic | BindingFlags.Instance);
            field.SetValue(obj, value);
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                if (Directory.Exists(_tempDir))
                {
                    try { Directory.Delete(_tempDir, recursive: true); } catch { }
                }
            }
        }

        /// <summary>
        ///     Tests that sync LoadMetadata loads metadata from a real video file
        /// </summary>
        [RequireFfmpegFact]
        public void LoadMetadata_Sync_OnRealVideo_ShouldLoad()
        {
            if (!File.Exists(_videoFile)) return;
            using VideoReader reader = new VideoReader(_videoFile);

            Exception ex = Record.Exception(() => reader.LoadMetadata());

            Assert.Null(ex);
            Assert.True(reader.LoadedMetadata);
        }

        /// <summary>
        ///     Tests that LoadMetadataAsync throws when metadata is already loaded
        /// </summary>
        [RequireFfmpegFact]
        public async System.Threading.Tasks.Task LoadMetadataAsync_Twice_ShouldThrowAlreadyLoaded()
        {
            if (!File.Exists(_videoFile)) return;
            using VideoReader reader = new VideoReader(_videoFile);

            await reader.LoadMetadataAsync().WaitAsync(TimeSpan.FromSeconds(30));

            InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(() => reader.LoadMetadataAsync());
            Assert.Contains("already loaded", ex.Message);
        }

        /// <summary>
        ///     Tests that LoadMetadataAsync throws when ffprobe emits corrupt output
        /// </summary>
        [RequireFfmpegFact]
        public async System.Threading.Tasks.Task LoadMetadataAsync_WithCorruptFfprobe_ShouldThrowInvalidOperation()
        {
            if (!File.Exists(_videoFile)) return;
            using VideoReader reader = new VideoReader(_videoFile, "ffmpeg", _fakeFfprobePath);

            InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(() => reader.LoadMetadataAsync());
            Assert.Contains("Failed to interpret ffprobe video metadata output", ex.Message);
        }

        /// <summary>
        ///     Tests that Load throws when loaded metadata contains zero dimensions
        /// </summary>
        [RequireFfmpegFact]
        public void Load_WithZeroDimensions_ShouldThrowInvalidData()
        {
            if (!File.Exists(_videoFile)) return;
            using VideoReader reader = new VideoReader(_videoFile);

            reader.LoadMetadataAsync().Wait(TimeSpan.FromSeconds(30));

            InvalidDataException ex = Assert.Throws<InvalidDataException>(() => reader.Load());
            Assert.Contains("Loaded metadata contains errors", ex.Message);
        }

        /// <summary>
        ///     Tests that Load opens the data stream when metadata dimensions are set
        /// </summary>
        [RequireFfmpegFact]
        public void Load_AfterReflectiveMetadata_ShouldOpenStream()
        {
            if (!File.Exists(_videoFile)) return;
            using VideoReader reader = new VideoReader(_videoFile);

            SetBackingField(reader, "Metadata", new VideoMetadata { Width = 16, Height = 16 });
            SetBackingField(reader, "LoadedMetadata", true);

            Exception ex = Record.Exception(() => reader.Load());

            Assert.Null(ex);
            Assert.True(reader.OpenedForReading);
        }

        /// <summary>
        ///     Tests that Load with a positive offset opens the data stream
        /// </summary>
        [RequireFfmpegFact]
        public void Load_WithOffset_AfterReflectiveMetadata_ShouldOpenStream()
        {
            if (!File.Exists(_videoFile)) return;
            using VideoReader reader = new VideoReader(_videoFile);

            SetBackingField(reader, "Metadata", new VideoMetadata { Width = 16, Height = 16 });
            SetBackingField(reader, "LoadedMetadata", true);

            Exception ex = Record.Exception(() => reader.Load(0.5));

            Assert.Null(ex);
            Assert.True(reader.OpenedForReading);
        }

        /// <summary>
        ///     Tests that Load throws when the reader is already loaded
        /// </summary>
        [RequireFfmpegFact]
        public void Load_Twice_ShouldThrowAlreadyLoaded()
        {
            if (!File.Exists(_videoFile)) return;
            using VideoReader reader = new VideoReader(_videoFile);

            SetBackingField(reader, "Metadata", new VideoMetadata { Width = 16, Height = 16 });
            SetBackingField(reader, "LoadedMetadata", true);
            reader.Load();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.Load());
            Assert.Contains("already loaded", ex.Message);
        }

        /// <summary>
        ///     Tests that the parameterless NextFrame returns the next real frame
        /// </summary>
        [RequireFfmpegFact]
        public void NextFrame_Parameterless_AfterLoad_ShouldReturnFrame()
        {
            if (!File.Exists(_videoFile)) return;
            using VideoReader reader = new VideoReader(_videoFile);

            SetBackingField(reader, "Metadata", new VideoMetadata { Width = 16, Height = 16 });
            SetBackingField(reader, "LoadedMetadata", true);
            reader.Load();

            VideoFrame frame = reader.NextFrame();

            Assert.NotNull(frame);
            Assert.Equal(1, reader.CurrentFrameOffset);
        }
    }
}
