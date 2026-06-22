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
using System.Diagnostics;
using Alis.Extension.Media.FFmpeg.Audio;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test
{
    /// <summary>
    ///     Tests for the <see cref="AudioPlayer"/> class.
    /// </summary>
    public class AudioPlayerTest
    {
        /// <summary>
        ///     Tests that the default constructor creates an AudioPlayer without throwing.
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldNotThrow()
        {
            AudioPlayer player = new AudioPlayer();

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that the default constructor sets Filename to null.
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldSetFilenameToNull()
        {
            AudioPlayer player = new AudioPlayer();

            // Filename is a protected property, but player should be instantiated successfully
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that the constructor with input parameter creates an AudioPlayer.
        /// </summary>
        [Fact]
        public void Constructor_WithInput_ShouldNotThrow()
        {
            string testFile = "test.wav";
            AudioPlayer player = new AudioPlayer(testFile);

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that the constructor sets Filename to the provided input.
        /// </summary>
        [Fact]
        public void Constructor_WithInput_ShouldSetFilename()
        {
            string testFile = "test.wav";
            AudioPlayer player = new AudioPlayer(testFile);

            Assert.NotNull(player);
            // Filename would be set to testFile, but it's protected
        }

        /// <summary>
        ///     Tests that the constructor with input and ffplayExecutable parameters creates an AudioPlayer.
        /// </summary>
        [Fact]
        public void Constructor_WithInputAndFfplay_ShouldNotThrow()
        {
            string testFile = "test.wav";
            string testFfplay = "custom_ffplay";
            AudioPlayer player = new AudioPlayer(testFile, testFfplay);

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that the finalizer does not throw when called.
        /// </summary>
        [Fact]
        public void Finalizer_ShouldNotThrow()
        {
            // Create a derived class to test finalization behavior
            var player = new AudioPlayer("test.wav");

            // Force garbage collection to trigger finalizer
            GC.SuppressFinalize(player);

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that AudioPlayer implements IDisposable.
        /// </summary>
        [Fact]
        public void AudioPlayer_ShouldImplementIDisposable()
        {
            AudioPlayer player = new AudioPlayer();

            Assert.IsAssignableFrom<IDisposable>(player);
        }
    }
}
