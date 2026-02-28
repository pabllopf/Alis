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
            // Arrange & Act
            AudioPlayer player = new AudioPlayer();

            // Assert
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that audio player should be disposable
        /// </summary>
        [Fact]
        public void AudioPlayer_ShouldBeDisposable()
        {
            // Arrange & Act
            AudioPlayer player = new AudioPlayer();

            // Assert
            Assert.IsAssignableFrom<IDisposable>(player);
        }

        /// <summary>
        ///     Tests that audio player should be disposabl multiple times
        /// </summary>
        [Fact]
        public void AudioPlayer_ShouldBeDisposableMultipleTimes()
        {
            // Arrange
            AudioPlayer player = new AudioPlayer();

            // Act & Assert - No exceptions should be thrown
            player.Dispose();
            player.Dispose();
            player.Dispose();
        }
    }
}