// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FFMpegWrapperFormatsCoverageTest.cs
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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test
{
    /// <summary>
    ///     The f f mpeg wrapper formats coverage test class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class FFMpegWrapperFormatsCoverageTest : IDisposable
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
        ///     Initializes a new instance of the <see cref="FFMpegWrapperFormatsCoverageTest"/> class
        /// </summary>
        public FFMpegWrapperFormatsCoverageTest()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);

            _fakeFfmpegPath = Path.Combine(_tempDir, "ffmpeg");
            File.WriteAllText(_fakeFfmpegPath,
                "#!/bin/bash\n" +
                "printf ' D  mp3 MP3 (MPEG audio layer 3)\\n" +
                "DE  mp4 MP4 (MPEG-4 Part 14)\\n" +
                " E  mkv Matroska container\\n'");
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
        ///     Tests that GetFormats parses a clean format list without duplicate keys
        /// </summary>
        [RequireFfmpegFact]
        public void GetFormats_WithCleanFakeFfmpeg_ShouldReturnDictionary()
        {
            Dictionary<string, (string Description, MuxingSupport Support)> formats = FfMpegWrapper.GetFormats(_fakeFfmpegPath);

            Assert.NotNull(formats);
            Assert.Equal(3, formats.Count);
            Assert.Equal(MuxingSupport.Demux, formats["mp3"].Support);
            Assert.Equal(MuxingSupport.MuxDemux, formats["mp4"].Support);
            Assert.Equal(MuxingSupport.Mux, formats["mkv"].Support);
            Assert.Contains("MPEG audio layer 3", formats["mp3"].Description);
        }
    }
}
