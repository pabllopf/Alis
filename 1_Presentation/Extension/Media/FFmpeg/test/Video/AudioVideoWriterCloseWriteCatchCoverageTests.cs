// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioVideoWriterCloseWriteCatchCoverageTests.cs
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
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Media.FFmpeg.Encoding.Builders;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    ///     The audio video writer close write catch coverage tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class AudioVideoWriterCloseWriteCatchCoverageTests : IDisposable
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
        ///     Initializes a new instance of the <see cref="AudioVideoWriterCloseWriteCatchCoverageTests"/> class
        /// </summary>
        public AudioVideoWriterCloseWriteCatchCoverageTests()
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
                    try
                    {
                        Directory.Delete(_tempDir, recursive: true);
                    }
                    catch
                    {
                    }
                }
            }
        }

        /// <summary>
        ///     Tests that CloseWrite swallows the error thrown when the FFmpeg process
        ///     handle is disposed while the five second exit wait is in progress. The
        ///     wait still reports that the process is running, the subsequent
        ///     <c>HasExited</c> check throws and is swallowed by the inner catch block,
        ///     and the final <c>WaitForExit()</c> propagates the disposed-handle error.
        /// </summary>
        [RequireFfmpegFact]
        public void CloseWrite_WhenProcessHandleDisposedDuringWait_ThrowsAfterSwallowingKillError()
        {
            string outFile = Path.Combine(_tempDir, Guid.NewGuid().ToString() + ".mp4");
            using AudioVideoWriter writer = new(outFile, 16, 16, 30.0, 2, 44100, 16,
                new H264Encoder().Create(), new AacEncoder().Create(), _fakeFfmpegPath);

            writer.OpenWrite();

            Process ffmpegProcess = writer.CurrentFFmpegProcess;
            int processId = ffmpegProcess.Id;

            try
            {
                Exception closeWriteException = null;
                Task closeTask = Task.Run(() =>
                {
                    try
                    {
                        writer.CloseWrite();
                    }
                    catch (Exception exception)
                    {
                        closeWriteException = exception;
                    }
                });

                Thread.Sleep(1000);
                ffmpegProcess.Close();

                Assert.True(closeTask.Wait(TimeSpan.FromSeconds(20)));
                Assert.IsType<InvalidOperationException>(closeWriteException);
                Assert.False(writer.OpenedForWriting);
            }
            finally
            {
                try
                {
                    using Process killer = Process.Start("/bin/kill", $"-9 {processId}");
                    killer?.WaitForExit();
                }
                catch
                {
                }
            }
        }
    }
}
