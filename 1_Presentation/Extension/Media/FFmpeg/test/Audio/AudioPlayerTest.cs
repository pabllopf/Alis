// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioPlayerTest.cs
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
using Alis.Extension.Media.FFmpeg.Audio;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    /// <summary>
    ///     The audio player test class
    /// </summary>
    /// <seealso cref="AudioPlayer" />
    public class AudioPlayerTest
    {
        /// <summary>
        ///     Tests that audio player constructor should create instance
        /// </summary>
        [Fact]
        public void AudioPlayer_Constructor_ShouldCreateInstance()
        {
            AudioPlayer player = new AudioPlayer();

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that audio player should be disposable
        /// </summary>
        [Fact]
        public void AudioPlayer_ShouldBeDisposable()
        {
            AudioPlayer player = new AudioPlayer();

            Assert.IsAssignableFrom<IDisposable>(player);
        }

        /// <summary>
        ///     Tests that audio player should be disposabl multiple times
        /// </summary>
        [Fact]
        public void AudioPlayer_ShouldBeDisposableMultipleTimes()
        {
            AudioPlayer player = new AudioPlayer();

            player.Dispose();
            player.Dispose();
            player.Dispose();
        }

        /// <summary>
        /// Tests that audio player play should throw when no filename
        /// </summary>
        [Fact]
        public void AudioPlayer_Play_ShouldThrowWhenNoFilename()
        {
            AudioPlayer player = new AudioPlayer();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.Play());

            Assert.Contains("No filename was specified", ex.Message);
        }

        /// <summary>
        /// Tests that audio player close write should throw when not opened
        /// </summary>
        [Fact]
        public void AudioPlayer_CloseWrite_ShouldThrowWhenNotOpened()
        {
            AudioPlayer player = new AudioPlayer();

            Assert.Throws<InvalidOperationException>(() => player.CloseWrite());
        }

        /// <summary>
        /// Tests that audio player constructor should set filename
        /// </summary>
        [Fact]
        public void AudioPlayer_Constructor_ShouldSetFilename()
        {
            AudioPlayer player = new AudioPlayer("test.mp3");

            Assert.Equal("test.mp3", player.Filename);
        }

        /// <summary>
        /// Tests that audio player constructor should default filename to null
        /// </summary>
        [Fact]
        public void AudioPlayer_Constructor_ShouldDefaultFilenameToNull()
        {
            AudioPlayer player = new AudioPlayer();

            Assert.Null(player.Filename);
        }

        /// <summary>
        /// Tests that audio player open write should throw on invalid bit depth
        /// </summary>
        [Fact]
        public void AudioPlayer_OpenWrite_ShouldThrowOnInvalidBitDepth()
        {
            AudioPlayer player = new AudioPlayer();

            Assert.Throws<InvalidOperationException>(() => player.OpenWrite(44100, 2, 8));
        }

        /// <summary>
        ///     Tests that WriteFrame throws when not opened for writing
        /// </summary>
        [Fact]
        public void AudioPlayer_WriteFrame_WhenNotOpened_ShouldThrowInvalidOperationException()
        {
            AudioPlayer player = new AudioPlayer("test.mp3");
            AudioFrame frame = new AudioFrame(2, 1024, 16);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.WriteFrame(frame));

            Assert.Contains("prepared for writing", ex.Message);
        }

    }
}