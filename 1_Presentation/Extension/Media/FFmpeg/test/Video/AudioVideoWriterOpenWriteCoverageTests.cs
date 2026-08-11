// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioVideoWriterOpenWriteCoverageTests.cs
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
using Alis.Extension.Media.FFmpeg.Encoding.Builders;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    ///     The audio video writer open write coverage tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class AudioVideoWriterOpenWriteCoverageTests : IDisposable
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
        ///     Initializes a new instance of the <see cref="AudioVideoWriterOpenWriteCoverageTests"/> class
        /// </summary>
        public AudioVideoWriterOpenWriteCoverageTests()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);

            _fakeFfmpegPath = Path.Combine(_tempDir, "ffmpeg");
            File.WriteAllText(_fakeFfmpegPath,
                "#!/bin/bash\n" +
                "port=$(printf '%s\\n' \"$@\" | sed -n 's/.*tcp:\\/\\/127\\.0\\.0\\.1:\\([0-9]*\\).*/\\1/p')\n" +
                "if [ -n \"$port\" ]; then\n" +
                "  exec 3<>/dev/tcp/127.0.0.1/$port\n" +
                "fi\n" +
                "exec sleep 30");
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
        ///     Tests that OpenWrite in file mode opens the writer and CloseWrite terminates ffmpeg
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_FileMode_ShouldOpenAndClose()
        {
            string outFile = Path.Combine(_tempDir, Guid.NewGuid().ToString() + ".mp4");
            File.WriteAllBytes(outFile, new byte[] { 1, 2, 3 });
            using AudioVideoWriter writer = new AudioVideoWriter(outFile, 16, 16, 30.0, 2, 44100, 16,
                new H264Encoder().Create(), new AacEncoder().Create(), _fakeFfmpegPath);

            Exception ex = Record.Exception(() => writer.OpenWrite());

            Assert.Null(ex);
            Assert.True(writer.OpenedForWriting);
            Assert.NotNull(writer.CurrentFFmpegProcess);
            Assert.NotNull(writer.InputDataStreamVideo);
            Assert.NotNull(writer.InputDataStreamAudio);

            Exception closeEx = Record.Exception(() => writer.CloseWrite());

            Assert.Null(closeEx);
            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        ///     Tests that OpenWrite in stream mode opens the writer and CloseWrite disposes the output stream
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_StreamMode_ShouldOpenAndClose()
        {
            using MemoryStream dest = new MemoryStream();
            using AudioVideoWriter writer = new AudioVideoWriter(dest, 16, 16, 30.0, 2, 44100, 16,
                new H264Encoder().Create(), new AacEncoder().Create(), _fakeFfmpegPath);

            Exception ex = Record.Exception(() => writer.OpenWrite());

            Assert.Null(ex);
            Assert.True(writer.OpenedForWriting);
            Assert.NotNull(writer.CurrentFFmpegProcess);
            Assert.NotNull(writer.InputDataStreamVideo);
            Assert.NotNull(writer.OutputDataStream);

            Exception closeEx = Record.Exception(() => writer.CloseWrite());

            Assert.Null(closeEx);
            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        ///     Tests that OpenWrite throws when the writer is already opened
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_AlreadyOpened_ShouldThrowInvalidOperation()
        {
            using AudioVideoWriter writer = new AudioVideoWriter("out.mp4", 16, 16, 30.0, 2, 44100, 16, null, null, _fakeFfmpegPath);

            FieldInfo openedField = typeof(AudioVideoWriter).GetField("<OpenedForWriting>k__BackingField",
                BindingFlags.NonPublic | BindingFlags.Instance);
            openedField.SetValue(writer, true);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => writer.OpenWrite());
            Assert.Contains("already opened for writing", ex.Message);
        }
    }
}
