// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoReaderTest.cs
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
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    ///     The video reader test class
    /// </summary>
    /// <seealso cref="VideoReader" />
    public class VideoReaderTest
    {
        [Fact]
        public void VideoReader_Constructor_ShouldThrowWhenFileMissing()
        {
            string missing = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".mp4");

            Assert.Throws<FileNotFoundException>(() => new VideoReader(missing));
        }

        [Fact]
        public void VideoReader_Load_ShouldThrowWhenMetadataNotLoaded()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".mp4");
            File.WriteAllBytes(path, new byte[] {1});

            try
            {
                VideoReader reader = new VideoReader(path);

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.Load());

                Assert.Contains("load the video metadata", ex.Message);
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void VideoReader_NextFrame_ShouldThrowWhenNotOpened()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".mp4");
            File.WriteAllBytes(path, new byte[] {1});

            try
            {
                VideoReader reader = new VideoReader(path);

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.NextFrame());

                Assert.Contains("load the video first", ex.Message);
            }
            finally
            {
                File.Delete(path);
            }
        }
    }
}
