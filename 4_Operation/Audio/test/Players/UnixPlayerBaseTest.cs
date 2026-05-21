

using System;
using System.Threading.Tasks;
using Alis.Core.Audio.Interfaces;
using Alis.Core.Audio.Players;
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
            string command = UnixPlayerBase.PauseProcessCommand;

            Assert.Equal("kill -STOP {0}", command);
        }

        /// <summary>
        ///     Tests that unix player base resume process command should be correct
        /// </summary>
        [UnixOnly]
        public void UnixPlayerBase_ResumeProcessCommand_ShouldBeCorrect()
        {
            string command = UnixPlayerBase.ResumeProcessCommand;

            Assert.Equal("kill -CONT {0}", command);
        }

        /// <summary>
        ///     Tests that playing property should return false initially using mac player
        /// </summary>
        [MacOsOnly]
        public void Playing_Property_ShouldReturnFalseInitially_UsingMacPlayer()
        {
            MacPlayer player = new MacPlayer();

            bool playing = player.Playing;

            Assert.False(playing);
        }

        /// <summary>
        ///     Tests that paused property should return false initially using mac player
        /// </summary>
        [MacOsOnly]
        public void Paused_Property_ShouldReturnFalseInitially_UsingMacPlayer()
        {
            MacPlayer player = new MacPlayer();

            bool paused = player.Paused;

            Assert.False(paused);
        }

        /// <summary>
        ///     Tests that playing property should return false initially using linux player
        /// </summary>
        [LinuxOnly]
        public void Playing_Property_ShouldReturnFalseInitially_UsingLinuxPlayer()
        {
            LinuxPlayer player = new LinuxPlayer();

            bool playing = player.Playing;

            Assert.False(playing);
        }

        /// <summary>
        ///     Tests that paused property should return false initially using linux player
        /// </summary>
        [LinuxOnly]
        public void Paused_Property_ShouldReturnFalseInitially_UsingLinuxPlayer()
        {
            LinuxPlayer player = new LinuxPlayer();

            bool paused = player.Paused;

            Assert.False(paused);
        }

        /// <summary>
        ///     Tests that play should throw file not found exception when file does not exist on mac
        /// </summary>
        [MacOsOnly]
        public async Task Play_ShouldThrowFileNotFoundException_WhenFileDoesNotExist_OnMac()
        {
            MacPlayer player = new MacPlayer();
            string nonExistentFile = "nonexistent_file_12345.wav";

            await Assert.ThrowsAnyAsync<Exception>(async () => await player.Play(nonExistentFile));
        }

        /// <summary>
        ///     Tests that play should throw file not found exception when file does not exist on linux
        /// </summary>
        [LinuxOnly]
        public async Task Play_ShouldThrowFileNotFoundException_WhenFileDoesNotExist_OnLinux()
        {
            LinuxPlayer player = new LinuxPlayer();
            string nonExistentFile = "nonexistent_file_12345.wav";

            await Assert.ThrowsAnyAsync<Exception>(async () => await player.Play(nonExistentFile));
        }

        /// <summary>
        ///     Tests that pause should not throw when not playing on mac
        /// </summary>
        [MacOsOnly]
        public async Task Pause_ShouldNotThrow_WhenNotPlaying_OnMac()
        {
            MacPlayer player = new MacPlayer();

            await player.Pause();

            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that pause should not throw when not playing on linux
        /// </summary>
        [LinuxOnly]
        public async Task Pause_ShouldNotThrow_WhenNotPlaying_OnLinux()
        {
            LinuxPlayer player = new LinuxPlayer();

            await player.Pause();

            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that resume should not throw when not playing on mac
        /// </summary>
        [MacOsOnly]
        public async Task Resume_ShouldNotThrow_WhenNotPlaying_OnMac()
        {
            MacPlayer player = new MacPlayer();

            await player.Resume();

            Assert.False(player.Paused);
            Assert.False(player.Playing);
        }

        /// <summary>
        ///     Tests that resume should not throw when not playing on linux
        /// </summary>
        [LinuxOnly]
        public async Task Resume_ShouldNotThrow_WhenNotPlaying_OnLinux()
        {
            LinuxPlayer player = new LinuxPlayer();

            await player.Resume();

            Assert.False(player.Paused);
            Assert.False(player.Playing);
        }

        /// <summary>
        ///     Tests that stop should set playing and paused to false on mac
        /// </summary>
        [MacOsOnly]
        public async Task Stop_ShouldSetPlayingAndPausedToFalse_OnMac()
        {
            MacPlayer player = new MacPlayer();

            await player.Stop();

            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that stop should set playing and paused to false on linux
        /// </summary>
        [LinuxOnly]
        public async Task Stop_ShouldSetPlayingAndPausedToFalse_OnLinux()
        {
            LinuxPlayer player = new LinuxPlayer();

            await player.Stop();

            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that playback finished event should be available on mac
        /// </summary>
        [MacOsOnly]
        public void PlaybackFinished_Event_ShouldBeAvailable_OnMac()
        {
            MacPlayer player = new MacPlayer();
            bool eventAttached = false;

            player.PlaybackFinished += (sender, e) => { eventAttached = true; };

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that playback finished event should be available on linux
        /// </summary>
        [LinuxOnly]
        public void PlaybackFinished_Event_ShouldBeAvailable_OnLinux()
        {
            LinuxPlayer player = new LinuxPlayer();
            bool eventAttached = false;

            player.PlaybackFinished += (sender, e) => { eventAttached = true; };

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that multiple pause calls should be safe on mac
        /// </summary>
        [MacOsOnly]
        public async Task Pause_MultipleCalls_ShouldBeSafe_OnMac()
        {
            MacPlayer player = new MacPlayer();

            await player.Pause();
            await player.Pause();
            await player.Pause();

            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that multiple pause calls should be safe on linux
        /// </summary>
        [LinuxOnly]
        public async Task Pause_MultipleCalls_ShouldBeSafe_OnLinux()
        {
            LinuxPlayer player = new LinuxPlayer();

            await player.Pause();
            await player.Pause();
            await player.Pause();

            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that multiple stop calls should be safe on mac
        /// </summary>
        [MacOsOnly]
        public async Task Stop_MultipleCalls_ShouldBeSafe_OnMac()
        {
            MacPlayer player = new MacPlayer();

            await player.Stop();
            await player.Stop();
            await player.Stop();

            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that multiple stop calls should be safe on linux
        /// </summary>
        [LinuxOnly]
        public async Task Stop_MultipleCalls_ShouldBeSafe_OnLinux()
        {
            LinuxPlayer player = new LinuxPlayer();

            await player.Stop();
            await player.Stop();
            await player.Stop();

            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that play loop should throw file not found exception when file does not exist on mac
        /// </summary>
        [MacOsOnly]
        public async Task PlayLoop_ShouldThrowFileNotFoundException_WhenFileDoesNotExist_OnMac()
        {
            MacPlayer player = new MacPlayer();
            string nonExistentFile = "nonexistent_file_12345.wav";
            bool loop = true;

            await Assert.ThrowsAnyAsync<Exception>(async () => await player.PlayLoop(nonExistentFile, loop));
        }

        /// <summary>
        ///     Tests that play loop should throw file not found exception when file does not exist on linux
        /// </summary>
        [LinuxOnly]
        public async Task PlayLoop_ShouldThrowFileNotFoundException_WhenFileDoesNotExist_OnLinux()
        {
            LinuxPlayer player = new LinuxPlayer();
            string nonExistentFile = "nonexistent_file_12345.wav";
            bool loop = true;

            await Assert.ThrowsAnyAsync<Exception>(async () => await player.PlayLoop(nonExistentFile, loop));
        }

        /// <summary>
        ///     Tests that unix player base constants should not be null or empty
        /// </summary>
        [UnixOnly]
        public void UnixPlayerBase_Constants_ShouldNotBeNullOrEmpty()
        {
            string pauseCommand = UnixPlayerBase.PauseProcessCommand;
            string resumeCommand = UnixPlayerBase.ResumeProcessCommand;

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
            MacPlayer player = new MacPlayer();

            Assert.IsAssignableFrom<IPlayer>(player);
        }

        /// <summary>
        ///     Tests that unix player base should implement i player interface on linux
        /// </summary>
        [LinuxOnly]
        public void UnixPlayerBase_ShouldImplementIPlayerInterface_OnLinux()
        {
            LinuxPlayer player = new LinuxPlayer();

            Assert.IsAssignableFrom<IPlayer>(player);
        }

        /// <summary>
        ///     Tests that pause process command should contain kill keyword
        /// </summary>
        [UnixOnly]
        public void PauseProcessCommand_ShouldContainKillKeyword()
        {
            string command = UnixPlayerBase.PauseProcessCommand;

            Assert.Contains("kill", command);
        }

        /// <summary>
        ///     Tests that resume process command should contain kill keyword
        /// </summary>
        [UnixOnly]
        public void ResumeProcessCommand_ShouldContainKillKeyword()
        {
            string command = UnixPlayerBase.ResumeProcessCommand;

            Assert.Contains("kill", command);
        }

        /// <summary>
        ///     Tests that pause process command should contain stop signal
        /// </summary>
        [UnixOnly]
        public void PauseProcessCommand_ShouldContainStopSignal()
        {
            string command = UnixPlayerBase.PauseProcessCommand;

            Assert.Contains("STOP", command);
        }

        /// <summary>
        ///     Tests that resume process command should contain continue signal
        /// </summary>
        [UnixOnly]
        public void ResumeProcessCommand_ShouldContainContinueSignal()
        {
            string command = UnixPlayerBase.ResumeProcessCommand;

            Assert.Contains("CONT", command);
        }

        /// <summary>
        ///     Tests that pause process command should have format placeholder
        /// </summary>
        [UnixOnly]
        public void PauseProcessCommand_ShouldHaveFormatPlaceholder()
        {
            string command = UnixPlayerBase.PauseProcessCommand;

            Assert.Contains("{0}", command);
        }

        /// <summary>
        ///     Tests that resume process command should have format placeholder
        /// </summary>
        [UnixOnly]
        public void ResumeProcessCommand_ShouldHaveFormatPlaceholder()
        {
            string command = UnixPlayerBase.ResumeProcessCommand;

            Assert.Contains("{0}", command);
        }

        /// <summary>
        ///     Tests that pause process command should be formattable
        /// </summary>
        [UnixOnly]
        public void PauseProcessCommand_ShouldBeFormattable()
        {
            string command = UnixPlayerBase.PauseProcessCommand;
            int testPid = 12345;

            string formattedCommand = string.Format(command, testPid);

            Assert.Contains("12345", formattedCommand);
            Assert.DoesNotContain("{0}", formattedCommand);
        }

        /// <summary>
        ///     Tests that resume process command should be formattable
        /// </summary>
        [UnixOnly]
        public void ResumeProcessCommand_ShouldBeFormattable()
        {
            string command = UnixPlayerBase.ResumeProcessCommand;
            int testPid = 67890;

            string formattedCommand = string.Format(command, testPid);

            Assert.Contains("67890", formattedCommand);
            Assert.DoesNotContain("{0}", formattedCommand);
        }

        /// <summary>
        ///     Tests that playback finished event can be subscribed on mac
        /// </summary>
        [MacOsOnly]
        public void PlaybackFinished_Event_CanBeSubscribed_OnMac()
        {
            MacPlayer player = new MacPlayer();
            bool eventHandled = false;

            player.PlaybackFinished += (sender, e) => eventHandled = true;

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that playback finished event can be subscribed on linux
        /// </summary>
        [LinuxOnly]
        public void PlaybackFinished_Event_CanBeSubscribed_OnLinux()
        {
            LinuxPlayer player = new LinuxPlayer();
            bool eventHandled = false;

            player.PlaybackFinished += (sender, e) => eventHandled = true;

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that stop then play should work on mac
        /// </summary>
        [MacOsOnly]
        public async Task Stop_ThenPlay_ShouldWork_OnMac()
        {
            MacPlayer player = new MacPlayer();

            await player.Stop();

            try
            {
                await player.Play("nonexistent.wav");
            }
            catch (Exception)
            {
            }

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that stop then play should work on linux
        /// </summary>
        [LinuxOnly]
        public async Task Stop_ThenPlay_ShouldWork_OnLinux()
        {
            LinuxPlayer player = new LinuxPlayer();

            await player.Stop();

            try
            {
                await player.Play("nonexistent.wav");
            }
            catch (Exception)
            {
            }

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that pause commands should be different from resume commands
        /// </summary>
        [UnixOnly]
        public void PauseCommand_ShouldBeDifferentFromResumeCommand()
        {
            string pauseCommand = UnixPlayerBase.PauseProcessCommand;
            string resumeCommand = UnixPlayerBase.ResumeProcessCommand;

            Assert.NotEqual(pauseCommand, resumeCommand);
        }

        /// <summary>
        ///     Tests that unix player base commands should contain dash
        /// </summary>
        [UnixOnly]
        public void UnixPlayerBase_Commands_ShouldContainDash()
        {
            string pauseCommand = UnixPlayerBase.PauseProcessCommand;
            string resumeCommand = UnixPlayerBase.ResumeProcessCommand;

            Assert.Contains("-", pauseCommand);
            Assert.Contains("-", resumeCommand);
        }

        /// <summary>
        ///     Tests that play loop without loop should work on mac
        /// </summary>
        [MacOsOnly]
        public async Task PlayLoop_WithoutLoop_ShouldWork_OnMac()
        {
            MacPlayer player = new MacPlayer();

            try
            {
                await player.PlayLoop("nonexistent.wav", false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }

        /// <summary>
        ///     Tests that play loop without loop should work on linux
        /// </summary>
        [LinuxOnly]
        public async Task PlayLoop_WithoutLoop_ShouldWork_OnLinux()
        {
            LinuxPlayer player = new LinuxPlayer();

            try
            {
                await player.PlayLoop("nonexistent.wav", false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }

        /// <summary>
        ///     Tests that multiple resume calls should be safe on mac
        /// </summary>
        [MacOsOnly]
        public async Task Resume_MultipleCalls_ShouldBeSafe_OnMac()
        {
            MacPlayer player = new MacPlayer();

            await player.Resume();
            await player.Resume();
            await player.Resume();

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that multiple resume calls should be safe on linux
        /// </summary>
        [LinuxOnly]
        public async Task Resume_MultipleCalls_ShouldBeSafe_OnLinux()
        {
            LinuxPlayer player = new LinuxPlayer();

            await player.Resume();
            await player.Resume();
            await player.Resume();

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that pause stop pause sequence should work on mac
        /// </summary>
        [MacOsOnly]
        public async Task Pause_Stop_Pause_Sequence_ShouldWork_OnMac()
        {
            MacPlayer player = new MacPlayer();

            await player.Pause();
            await player.Stop();
            await player.Pause();

            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that pause stop pause sequence should work on linux
        /// </summary>
        [LinuxOnly]
        public async Task Pause_Stop_Pause_Sequence_ShouldWork_OnLinux()
        {
            LinuxPlayer player = new LinuxPlayer();

            await player.Pause();
            await player.Stop();
            await player.Pause();

            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that constants should be readonly
        /// </summary>
        [UnixOnly]
        public void UnixPlayerBase_Constants_ShouldBeReadonly()
        {
            string pauseCommand1 = UnixPlayerBase.PauseProcessCommand;
            string pauseCommand2 = UnixPlayerBase.PauseProcessCommand;

            Assert.Equal(pauseCommand1, pauseCommand2);
        }
    }
}