// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoWriterKillPathCoverageTests.cs
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
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    ///     The video writer kill path coverage tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class VideoWriterKillPathCoverageTests : IDisposable
    {
        /// <summary>
        ///     The temp dir
        /// </summary>
        private readonly string _tempDir;

        /// <summary>
        ///     The fake ffmpeg path
        /// </summary>
        private readonly string _fakeFfmpegPath;

        /// <summary>
        ///     The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoWriterKillPathCoverageTests"/> class
        /// </summary>
        public VideoWriterKillPathCoverageTests()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);

            _fakeFfmpegPath = Path.Combine(_tempDir, "ffmpeg");
            File.WriteAllText(_fakeFfmpegPath, "#!/bin/bash\nexec sleep 10");
            using Process chmod = Process.Start("chmod", $"+x \"{_fakeFfmpegPath}\"");
            chmod.WaitForExit();
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
        ///     Sets the backing field using the specified obj
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <param name="propName">The prop name</param>
        /// <param name="value">The value</param>
        private static void SetBackingField(object obj, string propName, object value)
        {
            Type type = obj.GetType();
            while (type != null)
            {
                FieldInfo field = type.GetField($"<{propName}>k__BackingField",
                    BindingFlags.NonPublic | BindingFlags.Instance);
                if (field != null)
                {
                    field.SetValue(obj, value);
                    return;
                }

                type = type.BaseType;
            }
        }

        /// <summary>
        ///     Tests that OpenWrite throws when the writer is already opened
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_AlreadyOpened_ShouldThrowInvalidOperation()
        {
            using VideoWriter writer = new VideoWriter("out.mp4", 16, 16, 30.0, null, _fakeFfmpegPath);

            SetBackingField(writer, "OpenedForWriting", true);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => writer.OpenWrite());
            Assert.Contains("already opened for writing", ex.Message);
        }

        /// <summary>
        ///     Tests that CloseWrite kills a still running ffmpeg process
        /// </summary>
        [RequireFfmpegFact]
        public void CloseWrite_WithRunningFfmpeg_ShouldKillProcess()
        {
            string outFile = Path.Combine(_tempDir, Guid.NewGuid().ToString() + ".mp4");
            using VideoWriter writer = new VideoWriter(outFile, 16, 16, 30.0, null, _fakeFfmpegPath);

            Exception ex = Record.Exception(() => writer.OpenWrite());

            Assert.Null(ex);
            Assert.True(writer.OpenedForWriting);
            Process process = writer.CurrentFFmpegProcess;
            Assert.NotNull(process);
            Assert.False(process.HasExited);

            Exception closeEx = Record.Exception(() => writer.CloseWrite());

            Assert.Null(closeEx);
            process.WaitForExit(5000);
            Assert.True(process.HasExited);
            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        ///     Tests that CloseWrite in stream mode kills a still running ffmpeg process
        /// </summary>
        [RequireFfmpegFact]
        public void CloseWrite_StreamMode_WithRunningFfmpeg_ShouldKillProcess()
        {
            using MemoryStream dest = new MemoryStream();
            using VideoWriter writer = new VideoWriter(dest, 16, 16, 30.0, null, _fakeFfmpegPath);

            Exception ex = Record.Exception(() => writer.OpenWrite());

            Assert.Null(ex);
            Assert.True(writer.OpenedForWriting);
            Process process = writer.CurrentFFmpegProcess;
            Assert.NotNull(process);
            Assert.False(process.HasExited);

            Exception closeEx = Record.Exception(() => writer.CloseWrite());

            Assert.Null(closeEx);
            process.WaitForExit(5000);
            Assert.True(process.HasExited);
            Assert.False(writer.OpenedForWriting);
        }
    }
}
