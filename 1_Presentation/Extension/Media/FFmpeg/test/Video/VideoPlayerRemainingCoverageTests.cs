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
using System.Reflection;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    ///     Remaining coverage tests for <see cref="VideoPlayer" /> targeting
    ///     the still-uncovered code paths: PlayInBackground pre-conditions,
    ///     constructor field initialization, and Dispose branches.
    /// </summary>
    public class VideoPlayerRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that <see cref="VideoPlayer.PlayInBackground" /> throws
        ///     <see cref="InvalidOperationException" /> when <see cref="VideoPlayer.Filename" />
        ///     is null.
        /// </summary>
        [Fact]
        public void PlayInBackground_NullFilename_ThrowsInvalidOperationException()
        {
            VideoPlayer player = new VideoPlayer();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.PlayInBackground());

            Assert.Contains("No filename was specified", ex.Message);
        }

        /// <summary>
        ///     Tests that <see cref="VideoPlayer.PlayInBackground" /> throws
        ///     <see cref="InvalidOperationException" /> when <see cref="VideoPlayer.Filename" />
        ///     is empty.
        /// </summary>
        [Fact]
        public void PlayInBackground_EmptyFilename_ThrowsInvalidOperationException()
        {
            VideoPlayer player = new VideoPlayer(string.Empty);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.PlayInBackground());

            Assert.Contains("No filename was specified", ex.Message);
        }

        /// <summary>
        ///     Tests that the constructor with a custom ffplay executable name
        ///     stores the value in the private <c>ffplay</c> field.
        /// </summary>
        [Fact]
        public void Constructor_CustomFfplayExecutable_SetsField()
        {
            const string customExecutable = "myffplay";
            VideoPlayer player = new VideoPlayer("test.mp4", customExecutable);

            FieldInfo ffplayField = typeof(VideoPlayer).GetField("ffplay",
                BindingFlags.NonPublic | BindingFlags.Instance);

            string actual = (string)ffplayField.GetValue(player);

            Assert.Equal(customExecutable, actual);
        }

        /// <summary>
        ///     Tests that <see cref="VideoPlayer.PlayInBackground" /> does not throw
        ///     any pre-condition exception (i.e. <see cref="InvalidOperationException" />)
        ///     when <see cref="VideoPlayer.Filename" /> is set and <c>OpenedForWriting</c> is false.
        ///     NOTE: This test may fail if the ffplay executable is not installed on the
        ///     test system, because <see cref="FfMpegWrapper.OpenOutput" /> attempts to
        ///     start ffplay as an external process.
        /// </summary>
        [Fact]
        public void PlayInBackground_WithFilename_DoesNotThrowPreconditionException()
        {
            VideoPlayer player = new VideoPlayer("test.mp4");

            InvalidOperationException ex = Record.Exception(() => player.PlayInBackground()) as InvalidOperationException;

            Assert.Null(ex);
        }
    }
}
