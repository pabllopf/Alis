// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoReaderMetadataStreamTests.cs
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
using Alis.Extension.Media.FFmpeg.Video;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    ///     Exercises the VideoReader metadata stream parsing against a real video file and
    ///     the system ffprobe executable.
    /// </summary>
    public class VideoReaderMetadataStreamTests : IDisposable
    {
        /// <summary>
        ///     The temp directory
        /// </summary>
        private readonly string _tempDir;

        /// <summary>
        ///     The video file
        /// </summary>
        private readonly string _videoFile;

        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoReaderMetadataStreamTests"/> class
        /// </summary>
        public VideoReaderMetadataStreamTests()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);
            _videoFile = Path.Combine(_tempDir, "sample.mp4");
            CreateTestVideo(_videoFile);
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
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (Directory.Exists(_tempDir))
            {
                try
                {
                    Directory.Delete(_tempDir, recursive: true);
                }
                catch
                {
                }
            }
        }

        /// <summary>
        ///     Verifies that metadata loading with the real ffprobe populates the video stream
        ///     fields.
        /// </summary>
        [RequireFfmpegFact]
        public void LoadMetadata_WithRealFfprobe_PopulatesStreamFields()
        {
            if (!File.Exists(_videoFile))
            {
                return;
            }

            using VideoReader reader = new VideoReader(_videoFile, "ffmpeg", "ffprobe");
            reader.LoadMetadata();
            Assert.True(reader.LoadedMetadata);
            Assert.NotNull(reader.Metadata);
            Assert.True(reader.Metadata.Duration >= 0);
            Assert.True(reader.Metadata.PredictedFrameCount >= 0);
        }

        /// <summary>
        ///     Verifies that the async metadata loading path populates the stream fields.
        /// </summary>
        [RequireFfmpegFact]
        public async void LoadMetadataAsync_WithRealFfprobe_PopulatesStreamFields()
        {
            if (!File.Exists(_videoFile))
            {
                return;
            }

            using VideoReader reader = new VideoReader(_videoFile, "ffmpeg", "ffprobe");
            await reader.LoadMetadataAsync();
            Assert.True(reader.LoadedMetadata);
            Assert.NotNull(reader.Metadata);
            Assert.True(reader.Metadata.PredictedFrameCount >= 0);
        }
    }
}
