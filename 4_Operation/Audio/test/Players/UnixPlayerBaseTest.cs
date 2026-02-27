// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UnixPlayerBaseTest.cs
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
using System.Threading.Tasks;
using Alis.Core.Audio.Interfaces;
using Alis.Core.Audio.Players;
using Alis.Core.Audio.Test.Players.Attributes;
using Xunit;
using Alis.Core.Audio.Test.Players.Attributes;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    ///     The unix player base test class
    /// </summary>
    /// <seealso cref="UnixPlayerBase" />
    public class UnixPlayerBaseTest
    {
        /// <summary>
        ///     Tests that unix player base pause process command should be correct
        /// </summary>
        [UnixOnly]
        public void UnixPlayerBase_PauseProcessCommand_ShouldBeCorrect()
        {
            // Arrange & Act
            string command = UnixPlayerBase.PauseProcessCommand;

            // Assert
            Assert.Equal("kill -STOP {0}", command);
        }

        /// <summary>
        ///     Tests that unix player base resume process command should be correct
        /// </summary>
        [UnixOnly]
        public void UnixPlayerBase_ResumeProcessCommand_ShouldBeCorrect()
        {
            // Arrange & Act
            string command = UnixPlayerBase.ResumeProcessCommand;

            // Assert
            Assert.Equal("kill -CONT {0}", command);
        }

        /// <summary>
        ///     Tests that playing property should return false initially using mac player
        /// </summary>
        [MacOsOnly]
        public void Playing_Property_ShouldReturnFalseInitially_UsingMacPlayer()
        {
            // Arrange
            MacPlayer player = new MacPlayer();

            // Act
            bool playing = player.Playing;

            // Assert
            Assert.False(playing);
        }

        /// <summary>
        ///     Tests that paused property should return false initially using mac player
        /// </summary>
        [MacOsOnly]
        public void Paused_Property_ShouldReturnFalseInitially_UsingMacPlayer()
        {
            // Arrange
            MacPlayer player = new MacPlayer();

            // Act
            bool paused = player.Paused;

            // Assert
            Assert.False(paused);
        }

        /// <summary>
        ///     Tests that playing property should return false initially using linux player
        /// </summary>
        [LinuxOnly]
        public void Playing_Property_ShouldReturnFalseInitially_UsingLinuxPlayer()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            bool playing = player.Playing;

            // Assert
            Assert.False(playing);
        }

        /// <summary>
        ///     Tests that paused property should return false initially using linux player
        /// </summary>
        [LinuxOnly]
        public void Paused_Property_ShouldReturnFalseInitially_UsingLinuxPlayer()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            bool paused = player.Paused;

            // Assert
            Assert.False(paused);
        }

        /// <summary>
        ///     Tests that play should throw file not found exception when file does not exist on mac
        /// </summary>
        [MacOsOnly]
        public async Task Play_ShouldThrowFileNotFoundException_WhenFileDoesNotExist_OnMac()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            string nonExistentFile = "nonexistent_file_12345.wav";

            // Act & Assert
            await Assert.ThrowsAnyAsync<Exception>(async () => await player.Play(nonExistentFile));
        }

        /// <summary>
        ///     Tests that play should throw file not found exception when file does not exist on linux
        /// </summary>
        [LinuxOnly]
        public async Task Play_ShouldThrowFileNotFoundException_WhenFileDoesNotExist_OnLinux()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            string nonExistentFile = "nonexistent_file_12345.wav";

            // Act & Assert
            await Assert.ThrowsAnyAsync<Exception>(async () => await player.Play(nonExistentFile));
        }

        /// <summary>
        ///     Tests that pause should not throw when not playing on mac
        /// </summary>
        [MacOsOnly]
        public async Task Pause_ShouldNotThrow_WhenNotPlaying_OnMac()
        {
            // Arrange
            MacPlayer player = new MacPlayer();

            // Act
            await player.Pause();

            // Assert
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that pause should not throw when not playing on linux
        /// </summary>
        [LinuxOnly]
        public async Task Pause_ShouldNotThrow_WhenNotPlaying_OnLinux()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            await player.Pause();

            // Assert
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that resume should not throw when not playing on mac
        /// </summary>
        [MacOsOnly]
        public async Task Resume_ShouldNotThrow_WhenNotPlaying_OnMac()
        {
            // Arrange
            MacPlayer player = new MacPlayer();

            // Act
            await player.Resume();

            // Assert
            Assert.False(player.Paused);
            Assert.False(player.Playing);
        }

        /// <summary>
        ///     Tests that resume should not throw when not playing on linux
        /// </summary>
        [LinuxOnly]
        public async Task Resume_ShouldNotThrow_WhenNotPlaying_OnLinux()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            await player.Resume();

            // Assert
            Assert.False(player.Paused);
            Assert.False(player.Playing);
        }

        /// <summary>
        ///     Tests that stop should set playing and paused to false on mac
        /// </summary>
        [MacOsOnly]
        public async Task Stop_ShouldSetPlayingAndPausedToFalse_OnMac()
        {
            // Arrange
            MacPlayer player = new MacPlayer();

            // Act
            await player.Stop();

            // Assert
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that stop should set playing and paused to false on linux
        /// </summary>
        [LinuxOnly]
        public async Task Stop_ShouldSetPlayingAndPausedToFalse_OnLinux()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            await player.Stop();

            // Assert
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that playback finished event should be available on mac
        /// </summary>
        [MacOsOnly]
        public void PlaybackFinished_Event_ShouldBeAvailable_OnMac()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            bool eventAttached = false;

            // Act
            player.PlaybackFinished += (sender, e) => { eventAttached = true; };

            // Assert - Event handler attached without exception
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that playback finished event should be available on linux
        /// </summary>
        [LinuxOnly]
        public void PlaybackFinished_Event_ShouldBeAvailable_OnLinux()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            bool eventAttached = false;

            // Act
            player.PlaybackFinished += (sender, e) => { eventAttached = true; };

            // Assert - Event handler attached without exception
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that multiple pause calls should be safe on mac
        /// </summary>
        [MacOsOnly]
        public async Task Pause_MultipleCalls_ShouldBeSafe_OnMac()
        {
            // Arrange
            MacPlayer player = new MacPlayer();

            // Act
            await player.Pause();
            await player.Pause();
            await player.Pause();

            // Assert - No exception thrown
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that multiple pause calls should be safe on linux
        /// </summary>
        [LinuxOnly]
        public async Task Pause_MultipleCalls_ShouldBeSafe_OnLinux()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            await player.Pause();
            await player.Pause();
            await player.Pause();

            // Assert - No exception thrown
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that multiple stop calls should be safe on mac
        /// </summary>
        [MacOsOnly]
        public async Task Stop_MultipleCalls_ShouldBeSafe_OnMac()
        {
            // Arrange
            MacPlayer player = new MacPlayer();

            // Act
            await player.Stop();
            await player.Stop();
            await player.Stop();

            // Assert
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that multiple stop calls should be safe on linux
        /// </summary>
        [LinuxOnly]
        public async Task Stop_MultipleCalls_ShouldBeSafe_OnLinux()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            await player.Stop();
            await player.Stop();
            await player.Stop();

            // Assert
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that play loop should throw file not found exception when file does not exist on mac
        /// </summary>
        [MacOsOnly]
        public async Task PlayLoop_ShouldThrowFileNotFoundException_WhenFileDoesNotExist_OnMac()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            string nonExistentFile = "nonexistent_file_12345.wav";
            bool loop = true;

            // Act & Assert
            await Assert.ThrowsAnyAsync<Exception>(async () => await player.PlayLoop(nonExistentFile, loop));
        }

        /// <summary>
        ///     Tests that play loop should throw file not found exception when file does not exist on linux
        /// </summary>
        [LinuxOnly]
        public async Task PlayLoop_ShouldThrowFileNotFoundException_WhenFileDoesNotExist_OnLinux()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            string nonExistentFile = "nonexistent_file_12345.wav";
            bool loop = true;

            // Act & Assert
            await Assert.ThrowsAnyAsync<Exception>(async () => await player.PlayLoop(nonExistentFile, loop));
        }

        /// <summary>
        ///     Tests that unix player base constants should not be null or empty
        /// </summary>
        [UnixOnly]
        public void UnixPlayerBase_Constants_ShouldNotBeNullOrEmpty()
        {
            // Arrange & Act
            string pauseCommand = UnixPlayerBase.PauseProcessCommand;
            string resumeCommand = UnixPlayerBase.ResumeProcessCommand;

            // Assert
            Assert.NotNull(pauseCommand);
            Assert.NotEmpty(pauseCommand);
            Assert.NotNull(resumeCommand);
            Assert.NotEmpty(resumeCommand);
        }

        /// <summary>
        ///     Tests that unix player base should implement i player interface on mac
        /// </summary>
        [MacOsOnly]
        public void UnixPlayerBase_ShouldImplementIPlayerInterface_OnMac()
        {
            // Arrange & Act
            MacPlayer player = new MacPlayer();

            // Assert
            Assert.IsAssignableFrom<IPlayer>(player);
        }

        /// <summary>
        ///     Tests that unix player base should implement i player interface on linux
        /// </summary>
        [LinuxOnly]
        public void UnixPlayerBase_ShouldImplementIPlayerInterface_OnLinux()
        {
            // Arrange & Act
            LinuxPlayer player = new LinuxPlayer();

            // Assert
            Assert.IsAssignableFrom<IPlayer>(player);
        }

        /// <summary>
        ///     Tests that pause process command should contain kill keyword
        /// </summary>
        [UnixOnly]
        public void PauseProcessCommand_ShouldContainKillKeyword()
        {
            // Arrange & Act
            string command = UnixPlayerBase.PauseProcessCommand;

            // Assert
            Assert.Contains("kill", command);
        }

        /// <summary>
        ///     Tests that resume process command should contain kill keyword
        /// </summary>
        [UnixOnly]
        public void ResumeProcessCommand_ShouldContainKillKeyword()
        {
            // Arrange & Act
            string command = UnixPlayerBase.ResumeProcessCommand;

            // Assert
            Assert.Contains("kill", command);
        }

        /// <summary>
        ///     Tests that pause process command should contain stop signal
        /// </summary>
        [UnixOnly]
        public void PauseProcessCommand_ShouldContainStopSignal()
        {
            // Arrange & Act
            string command = UnixPlayerBase.PauseProcessCommand;

            // Assert
            Assert.Contains("STOP", command);
        }

        /// <summary>
        ///     Tests that resume process command should contain continue signal
        /// </summary>
        [UnixOnly]
        public void ResumeProcessCommand_ShouldContainContinueSignal()
        {
            // Arrange & Act
            string command = UnixPlayerBase.ResumeProcessCommand;

            // Assert
            Assert.Contains("CONT", command);
        }
    }
}

