// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoPlayerTest.cs
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
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    ///     The video player test class
    /// </summary>
    /// <seealso cref="VideoPlayer" />
    public class VideoPlayerTest
    {
        /// <summary>
        ///     Tests that video player constructor should create instance
        /// </summary>
        [Fact]
        public void VideoPlayer_Constructor_ShouldCreateInstance()
        {
            VideoPlayer player = new VideoPlayer();

            Assert.NotNull(player);
        }


        /// <summary>
        ///     Tests that video player should be disposable
        /// </summary>
        [Fact]
        public void VideoPlayer_ShouldBeDisposable()
        {
            VideoPlayer player = new VideoPlayer();

            Assert.IsAssignableFrom<IDisposable>(player);
        }


        /// <summary>
        ///     Tests that video player should be disposable multiple times
        /// </summary>
        [Fact]
        public void VideoPlayer_ShouldBeDisposableMultipleTimes()
        {
            VideoPlayer player = new VideoPlayer();

            player.Dispose();
            player.Dispose();
            player.Dispose();
        }

        [Fact]
        public void VideoPlayer_Play_ShouldThrowWhenNoFilename()
        {
            VideoPlayer player = new VideoPlayer();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.Play());

            Assert.Contains("No filename was specified", ex.Message);
        }

        [Fact]
        public void VideoPlayer_CloseWrite_ShouldThrowWhenNotOpened()
        {
            VideoPlayer player = new VideoPlayer();

            Assert.Throws<InvalidOperationException>(() => player.CloseWrite());
        }

        [Fact]
        public void VideoPlayer_Constructor_ShouldSetFilename()
        {
            VideoPlayer player = new VideoPlayer("test.mp4");

            Assert.Equal("test.mp4", player.Filename);
        }

        [Fact]
        public void VideoPlayer_Constructor_ShouldDefaultFilenameToNull()
        {
            VideoPlayer player = new VideoPlayer();

            Assert.Null(player.Filename);
        }
    }
}