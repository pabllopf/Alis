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
            // Arrange & Act
            VideoPlayer player = new VideoPlayer();

            // Assert
            Assert.NotNull(player);
        }


        /// <summary>
        ///     Tests that video player should be disposable
        /// </summary>
        [Fact]
        public void VideoPlayer_ShouldBeDisposable()
        {
            // Arrange & Act
            VideoPlayer player = new VideoPlayer();

            // Assert
            Assert.IsAssignableFrom<IDisposable>(player);
        }


        /// <summary>
        ///     Tests that video player should be disposable multiple times
        /// </summary>
        [Fact]
        public void VideoPlayer_ShouldBeDisposableMultipleTimes()
        {
            // Arrange
            VideoPlayer player = new VideoPlayer();

            // Act & Assert - No exceptions should be thrown
            player.Dispose();
            player.Dispose();
            player.Dispose();
        }
    }
}