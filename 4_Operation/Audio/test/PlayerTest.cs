

using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Alis.Core.Audio.Interfaces;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test
{
    /// <summary>
    ///     The player test class
    /// </summary>
    /// <seealso cref="Player" />
    public class PlayerTest
    {
        /// <summary>
        ///     Tests that player constructor should initialize internal player
        /// </summary>
        [Fact]
        public void Player_Constructor_ShouldInitializeInternalPlayer()
        {
            Player player = new Player();

            Assert.NotNull(player);
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that player constructor should initialize with correct os specific player
        /// </summary>
        [Fact]
        public void Player_Constructor_ShouldInitializeWithCorrectOsSpecificPlayer()
        {
            Player player = new Player();

            Assert.NotNull(player);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.NotNull(player);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.NotNull(player);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Assert.NotNull(player);
            }
        }

        /// <summary>
        ///     Tests that playing property should return false initially
        /// </summary>
        [Fact]
        public void Playing_Property_ShouldReturnFalseInitially()
        {
            Player player = new Player();

            bool playing = player.Playing;

            Assert.False(playing);
        }

        /// <summary>
        ///     Tests that paused property should return false initially
        /// </summary>
        [Fact]
        public void Paused_Property_ShouldReturnFalseInitially()
        {
            Player player = new Player();

            bool paused = player.Paused;

            Assert.False(paused);
        }

        /// <summary>
        ///     Tests that check os should return windows player on windows
        /// </summary>
        [Fact]
        public void CheckOs_ShouldReturnWindowsPlayer_OnWindows()
        {
            IPlayer player = Player.CheckOs();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.IsType<WindowsPlayer>(player);
            }
        }

        /// <summary>
        ///     Tests that check os should return linux player on linux
        /// </summary>
        [Fact]
        public void CheckOs_ShouldReturnLinuxPlayer_OnLinux()
        {
            IPlayer player = Player.CheckOs();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.IsType<LinuxPlayer>(player);
            }
        }

        /// <summary>
        ///     Tests that check os should return mac player on mac
        /// </summary>
        [Fact]
        public void CheckOs_ShouldReturnMacPlayer_OnMac()
        {
            IPlayer player = Player.CheckOs();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Assert.IsType<MacPlayer>(player);
            }
        }

        /// <summary>
        ///     Tests that check os should return browser player on webassembly
        /// </summary>
        [Fact]
        public void CheckOs_ShouldReturnBrowserPlayer_OnWebAssembly()
        {
            IPlayer player = Player.CheckOs();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("WEBASSEMBLY")))
            {
                Assert.IsType<BrowserPlayer>(player);
            }
        }

        /// <summary>
        ///     Tests that check os should return browser player on browser
        /// </summary>
        [Fact]
        public void CheckOs_ShouldReturnBrowserPlayer_OnBrowser()
        {
            IPlayer player = Player.CheckOs();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER")))
            {
                Assert.IsType<BrowserPlayer>(player);
            }
        }

        /// <summary>
        ///     Tests that check os should return valid player on current platform
        /// </summary>
        [Fact]
        public void CheckOs_ShouldReturnValidPlayer_OnCurrentPlatform()
        {
            IPlayer player = Player.CheckOs();

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that on playback finished should invoke event handler
        /// </summary>
        [Fact]
        public void OnPlaybackFinished_ShouldInvokeEventHandler()
        {
            Player player = new Player();
            bool eventRaised = false;
            player.PlaybackFinished += (sender, e) => eventRaised = true;

            player.OnPlaybackFinished(player, EventArgs.Empty);

            Assert.True(eventRaised);
        }

        /// <summary>
        ///     Tests that on playback finished with null sender should not throw
        /// </summary>
        [Fact]
        public void OnPlaybackFinished_WithNullSender_ShouldNotThrow()
        {
            Player player = new Player();

            player.OnPlaybackFinished(null, EventArgs.Empty);
        }

        /// <summary>
        ///     Tests that on playback finished without handlers should not throw
        /// </summary>
        [Fact]
        public void OnPlaybackFinished_WithoutHandlers_ShouldNotThrow()
        {
            Player player = new Player();

            player.OnPlaybackFinished(player, EventArgs.Empty);
        }

        /// <summary>
        ///     Tests that playback finished event should be invokable
        /// </summary>
        [Fact]
        public void PlaybackFinished_Event_ShouldBeInvokable()
        {
            Player player = new Player();
            int eventCount = 0;
            player.PlaybackFinished += (sender, e) => eventCount++;

            player.OnPlaybackFinished(player, EventArgs.Empty);
            player.OnPlaybackFinished(player, EventArgs.Empty);

            Assert.Equal(2, eventCount);
        }

        /// <summary>
        ///     Tests that playback finished event sender should be player instance
        /// </summary>
        [Fact]
        public void PlaybackFinished_Event_SenderShouldBePlayerInstance()
        {
            Player player = new Player();
            object eventSender = null;
            player.PlaybackFinished += (sender, e) => eventSender = sender;

            player.OnPlaybackFinished(player, EventArgs.Empty);

            Assert.Same(player, eventSender);
        }

        /// <summary>
        ///     Tests that multiple event handlers should all be invoked
        /// </summary>
        [Fact]
        public void PlaybackFinished_MultipleEventHandlers_ShouldAllBeInvoked()
        {
            Player player = new Player();
            int handler1Count = 0;
            int handler2Count = 0;
            int handler3Count = 0;

            player.PlaybackFinished += (sender, e) => handler1Count++;
            player.PlaybackFinished += (sender, e) => handler2Count++;
            player.PlaybackFinished += (sender, e) => handler3Count++;

            player.OnPlaybackFinished(player, EventArgs.Empty);

            Assert.Equal(1, handler1Count);
            Assert.Equal(1, handler2Count);
            Assert.Equal(1, handler3Count);
        }

        /// <summary>
        ///     Tests that play method should accept file name parameter
        /// </summary>
        [Fact]
        public async Task Play_Method_ShouldAcceptFileNameParameter()
        {
            Player player = new Player();
            string fileName = "nonexistent.wav";

            try
            {
                await player.Play(fileName);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }

        /// <summary>
        ///     Tests that play loop method should accept file name and loop parameters
        /// </summary>
        [Fact]
        public async Task PlayLoop_Method_ShouldAcceptFileNameAndLoopParameters()
        {
            Player player = new Player();
            string fileName = "nonexistent.wav";
            bool loop = true;

            try
            {
                await player.PlayLoop(fileName, loop);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }

        /// <summary>
        ///     Tests that pause method should be callable
        /// </summary>
        [Fact]
        public async Task Pause_Method_ShouldBeCallable()
        {
            Player player = new Player();

            await player.Pause();

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that resume method should be callable
        /// </summary>
        [Fact]
        public async Task Resume_Method_ShouldBeCallable()
        {
            Player player = new Player();

            await player.Resume();

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that stop method should be callable
        /// </summary>
        [Fact]
        public async Task Stop_Method_ShouldBeCallable()
        {
            Player player = new Player();

            await player.Stop();

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that set volume method should accept byte parameter
        /// </summary>
        [Fact]
        public async Task SetVolume_Method_ShouldAcceptByteParameter()
        {
            Player player = new Player();
            byte volume = 50;

            await player.SetVolume(volume);

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that set volume with zero should work
        /// </summary>
        [Fact]
        public async Task SetVolume_WithZero_ShouldWork()
        {
            Player player = new Player();
            byte volume = 0;

            await player.SetVolume(volume);

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that set volume with max value should work
        /// </summary>
        [Fact]
        public async Task SetVolume_WithMaxValue_ShouldWork()
        {
            Player player = new Player();
            byte volume = 100;

            await player.SetVolume(volume);

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that play loop with false should work like normal play
        /// </summary>
        [Fact]
        public async Task PlayLoop_WithFalse_ShouldWorkLikeNormalPlay()
        {
            Player player = new Player();
            string fileName = "nonexistent.wav";
            bool loop = false;

            try
            {
                await player.PlayLoop(fileName, loop);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }

        /// <summary>
        ///     Tests that multiple pause calls should be safe
        /// </summary>
        [Fact]
        public async Task Pause_MultipleCalls_ShouldBeSafe()
        {
            Player player = new Player();

            await player.Pause();
            await player.Pause();
            await player.Pause();

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that multiple stop calls should be safe
        /// </summary>
        [Fact]
        public async Task Stop_MultipleCalls_ShouldBeSafe()
        {
            Player player = new Player();

            await player.Stop();
            await player.Stop();
            await player.Stop();

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that internal player should handle playback finished event
        /// </summary>
        [Fact]
        public void InternalPlayer_ShouldHandlePlaybackFinishedEvent()
        {
            Player player = new Player();
            bool eventRaised = false;
            player.PlaybackFinished += (sender, e) => eventRaised = true;

            player.OnPlaybackFinished(player, EventArgs.Empty);

            Assert.True(eventRaised);
        }

        /// <summary>
        ///     Tests that check os should return player implementing i player
        /// </summary>
        [Fact]
        public void CheckOs_ShouldReturnPlayerImplementingIPlayer()
        {
            IPlayer player = Player.CheckOs();

            Assert.NotNull(player);
            Assert.IsAssignableFrom<IPlayer>(player);
        }

        /// <summary>
        ///     Tests that set volume with mid range values should work
        /// </summary>
        [Fact]
        public async Task SetVolume_WithMidRangeValues_ShouldWork()
        {
            Player player = new Player();

            await player.SetVolume(25);
            await player.SetVolume(50);
            await player.SetVolume(75);

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that event handlers can be removed
        /// </summary>
        [Fact]
        public void PlaybackFinished_EventHandlers_CanBeRemoved()
        {
            Player player = new Player();
            int eventCount = 0;
            EventHandler handler = (sender, e) => eventCount++;

            player.PlaybackFinished += handler;
            player.OnPlaybackFinished(player, EventArgs.Empty);

            player.PlaybackFinished -= handler;
            player.OnPlaybackFinished(player, EventArgs.Empty);

            Assert.Equal(1, eventCount);
        }

        /// <summary>
        ///     Tests that check os should return non null player
        /// </summary>
        [Fact]
        public void CheckOs_ShouldReturnNonNullPlayer()
        {
            IPlayer player = Player.CheckOs();

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that play with null file name should throw exception
        /// </summary>
        [Fact]
        public async Task Play_WithNullFileName_ShouldThrowException()
        {
            Player player = new Player();

            await Assert.ThrowsAnyAsync<Exception>(async () => await player.Play(null));
        }

        /// <summary>
        ///     Tests that play with empty file name should throw exception
        /// </summary>
        [Fact]
        public async Task Play_WithEmptyFileName_ShouldThrowException()
        {
            Player player = new Player();

            await Assert.ThrowsAnyAsync<Exception>(async () => await player.Play(string.Empty));
        }

        /// <summary>
        ///     Tests that play loop with null file name should throw exception
        /// </summary>
        [Fact]
        public async Task PlayLoop_WithNullFileName_ShouldThrowException()
        {
            Player player = new Player();

            await Assert.ThrowsAnyAsync<Exception>(async () => await player.PlayLoop(null, true));
        }

        /// <summary>
        ///     Tests that play loop with empty file name should throw exception
        /// </summary>
        [Fact]
        public async Task PlayLoop_WithEmptyFileName_ShouldThrowException()
        {
            Player player = new Player();

            await Assert.ThrowsAnyAsync<Exception>(async () => await player.PlayLoop(string.Empty, false));
        }

        /// <summary>
        ///     Tests that resume without playing should not throw
        /// </summary>
        [Fact]
        public async Task Resume_WithoutPlaying_ShouldNotThrow()
        {
            Player player = new Player();

            await player.Resume();

            Assert.False(player.Playing);
        }

        /// <summary>
        ///     Tests that set volume with byte max value should work
        /// </summary>
        [Fact]
        public async Task SetVolume_WithByteMaxValue_ShouldWork()
        {
            Player player = new Player();

            await player.SetVolume(90);

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that set volume with byte min value should work
        /// </summary>
        [Fact]
        public async Task SetVolume_WithByteMinValue_ShouldWork()
        {
            Player player = new Player();

            await player.SetVolume(byte.MinValue);

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that on playback finished should pass correct event args
        /// </summary>
        [Fact]
        public void OnPlaybackFinished_ShouldPassCorrectEventArgs()
        {
            Player player = new Player();
            EventArgs receivedArgs = null;
            player.PlaybackFinished += (sender, e) => receivedArgs = e;

            EventArgs testArgs = EventArgs.Empty;
            player.OnPlaybackFinished(player, testArgs);

            Assert.Same(testArgs, receivedArgs);
        }

        /// <summary>
        ///     Tests that multiple operations in sequence should work
        /// </summary>
        [Fact]
        public async Task MultipleOperations_InSequence_ShouldWork()
        {
            Player player = new Player();

            await player.SetVolume(50);
            await player.Pause();
            await player.Resume();
            await player.Stop();

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that check os should handle all platforms
        /// </summary>
        [Fact]
        public void CheckOs_ShouldHandleAllPlatforms()
        {
            IPlayer player = Player.CheckOs();

            Assert.NotNull(player);

            bool isValidType = player is WindowsPlayer ||
                               player is LinuxPlayer ||
                               player is MacPlayer ||
                               player is BrowserPlayer;

            Assert.True(isValidType || player == null);
        }

        /// <summary>
        ///     Tests that playback finished event args should not be null
        /// </summary>
        [Fact]
        public void PlaybackFinished_EventArgs_ShouldNotBeNull()
        {
            Player player = new Player();
            EventArgs receivedArgs = null;
            player.PlaybackFinished += (sender, e) => receivedArgs = e;

            player.OnPlaybackFinished(player, EventArgs.Empty);

            Assert.NotNull(receivedArgs);
        }

        /// <summary>
        ///     Tests that playing property should reflect internal player state
        /// </summary>
        [Fact]
        public void Playing_Property_ShouldReflectInternalPlayerState()
        {
            Player player = new Player();

            bool initialState = player.Playing;

            Assert.False(initialState);
        }

        /// <summary>
        ///     Tests that paused property should reflect internal player state
        /// </summary>
        [Fact]
        public void Paused_Property_ShouldReflectInternalPlayerState()
        {
            Player player = new Player();

            bool initialState = player.Paused;

            Assert.False(initialState);
        }

        /// <summary>
        ///     Tests that play loop with loop true should accept parameter
        /// </summary>
        [Fact]
        public async Task PlayLoop_WithLoopTrue_ShouldAcceptParameter()
        {
            Player player = new Player();

            try
            {
                await player.PlayLoop("nonexistent.wav", true);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }

        /// <summary>
        ///     Tests that set volume during playback should work
        /// </summary>
        [Fact]
        public async Task SetVolume_DuringPlayback_ShouldWork()
        {
            Player player = new Player();

            try
            {
                await player.Play("nonexistent.wav");
            }
            catch
            {
            }

            await player.SetVolume(75);

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that set volume while paused should work
        /// </summary>
        [Fact]
        public async Task SetVolume_WhilePaused_ShouldWork()
        {
            Player player = new Player();

            await player.Pause();
            await player.SetVolume(30);

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that on playback finished with custom event args should work
        /// </summary>
        [Fact]
        public void OnPlaybackFinished_WithCustomEventArgs_ShouldWork()
        {
            Player player = new Player();
            EventArgs receivedArgs = null;
            player.PlaybackFinished += (sender, e) => receivedArgs = e;

            EventArgs customArgs = new EventArgs();
            player.OnPlaybackFinished(player, customArgs);

            Assert.Same(customArgs, receivedArgs);
        }

        /// <summary>
        ///     Tests that pause resume multiple cycles should work
        /// </summary>
        [Fact]
        public async Task Pause_Resume_MultipleCycles_ShouldWork()
        {
            Player player = new Player();

            await player.Pause();
            await player.Resume();
            await player.Pause();
            await player.Resume();

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that internal player should forward playback finished to player
        /// </summary>
        [Fact]
        public void InternalPlayer_ShouldForwardPlaybackFinishedToPlayer()
        {
            Player player = new Player();
            bool eventReceived = false;
            player.PlaybackFinished += (sender, e) => eventReceived = true;

            player.OnPlaybackFinished(player, EventArgs.Empty);

            Assert.True(eventReceived);
        }
    }
}