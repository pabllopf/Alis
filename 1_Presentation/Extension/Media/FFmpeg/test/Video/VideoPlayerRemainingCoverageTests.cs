// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoPlayerRemainingCoverageTests.cs
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
    /// The video player remaining coverage tests class
    /// </summary>
    public class VideoPlayerRemainingCoverageTests
    {
        /// <summary>
        /// Tests that play in background null filename throws invalid operation exception
        /// </summary>
        [Fact]
        public void PlayInBackground_NullFilename_ThrowsInvalidOperationException()
        {
            VideoPlayer player = new VideoPlayer();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.PlayInBackground());

            Assert.Contains("No filename was specified", ex.Message);
        }

        /// <summary>
        /// Tests that play in background empty filename throws invalid operation exception
        /// </summary>
        [Fact]
        public void PlayInBackground_EmptyFilename_ThrowsInvalidOperationException()
        {
            VideoPlayer player = new VideoPlayer(string.Empty);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.PlayInBackground());

            Assert.Contains("No filename was specified", ex.Message);
        }

        /// <summary>
        /// Tests that play in background with filename does not throw precondition exception
        /// </summary>
        [Fact]
        public void PlayInBackground_WithFilename_DoesNotThrowPreconditionException()
        {
            VideoPlayer player = new VideoPlayer("test.mp4");

            Exception ex = Record.Exception(() => player.PlayInBackground());

            Assert.IsNotType<InvalidOperationException>(ex);
        }

        /// <summary>
        /// Tests that constructor with ffplay executable does not throw
        /// </summary>
        [Fact]
        public void Constructor_WithFfplayExecutable_DoesNotThrow()
        {
            VideoPlayer player = new VideoPlayer("test.mp4", "myffplay");

            Assert.NotNull(player);
        }
    }
}
