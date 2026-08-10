using System;
using System.Threading.Tasks;
using Alis.Core.Audio.Players;
using Alis.Core.Audio.Test.Players.Attributes;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    /// The mac player and linux exception tests class
    /// </summary>
    public class MacPlayerAndLinuxExceptionTests
    {
        /// <summary>
        /// Tests that mac player set volume with value 101 should throw argument out of range exception
        /// </summary>
        [Fact]
        public async Task MacPlayer_SetVolume_WithValue101_ShouldThrowArgumentOutOfRangeException()
        {
            MacPlayer player = new MacPlayer();
            ArgumentOutOfRangeException ex = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => player.SetVolume(101));
            Assert.Equal("percent", ex.ParamName);
        }

        /// <summary>
        /// Tests that mac player set volume with value 150 should throw argument out of range exception
        /// </summary>
        [Fact]
        public async Task MacPlayer_SetVolume_WithValue150_ShouldThrowArgumentOutOfRangeException()
        {
            MacPlayer player = new MacPlayer();
            ArgumentOutOfRangeException ex = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => player.SetVolume(150));
            Assert.Contains("100", ex.Message);
        }

        /// <summary>
        /// Tests that mac player set volume with value 255 should throw argument out of range exception
        /// </summary>
        [Fact]
        public async Task MacPlayer_SetVolume_WithValue255_ShouldThrowArgumentOutOfRangeException()
        {
            MacPlayer player = new MacPlayer();
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => player.SetVolume(255));
        }

        /// <summary>
        /// Tests that mac player set volume with value 0 should work
        /// </summary>
        [UnixOnly]
        public async Task MacPlayer_SetVolume_WithValue0_ShouldWork()
        {
            MacPlayer player = new MacPlayer();
            await player.SetVolume(0);
            Assert.NotNull(player);
        }

        /// <summary>
        /// Tests that mac player set volume with value 50 should work
        /// </summary>
        [UnixOnly]
        public async Task MacPlayer_SetVolume_WithValue50_ShouldWork()
        {
            MacPlayer player = new MacPlayer();
            await player.SetVolume(50);
            Assert.NotNull(player);
        }

        /// <summary>
        /// Tests that mac player set volume with value 100 should work
        /// </summary>
        [UnixOnly]
        public async Task MacPlayer_SetVolume_WithValue100_ShouldWork()
        {
            MacPlayer player = new MacPlayer();
            await player.SetVolume(100);
            Assert.NotNull(player);
        }

        /// <summary>
        /// Tests that mac player get bash command should return afplay
        /// </summary>
        [Fact]
        public void MacPlayer_GetBashCommand_ShouldReturnAfplay()
        {
            MacPlayer player = new MacPlayer();
            Assert.Equal("afplay", player.GetBashCommand("test.wav"));
            Assert.Equal("afplay", player.GetBashCommand("test.mp3"));
            Assert.Equal("afplay", player.GetBashCommand("test.ogg"));
            Assert.Equal("afplay", player.GetBashCommand("test.flac"));
            Assert.Equal("afplay", player.GetBashCommand("test.m4a"));
            Assert.Equal("afplay", player.GetBashCommand("test.aiff"));
            Assert.Equal("afplay", player.GetBashCommand("test.aac"));
            Assert.Equal("afplay", player.GetBashCommand("testfile"));
            Assert.Equal("afplay", player.GetBashCommand(string.Empty));
            Assert.Equal("afplay", player.GetBashCommand(null));
        }

        /// <summary>
        /// Tests that mac player constructor should initialize correctly
        /// </summary>
        [Fact]
        public void MacPlayer_Constructor_ShouldInitializeCorrectly()
        {
            MacPlayer player = new MacPlayer();
            Assert.NotNull(player);
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        /// Tests that linux player set volume with value 101 should throw argument out of range exception
        /// </summary>
        [Fact]
        public async Task LinuxPlayer_SetVolume_WithValue101_ShouldThrowArgumentOutOfRangeException()
        {
            LinuxPlayer player = new LinuxPlayer();
            ArgumentOutOfRangeException ex = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => player.SetVolume(101));
            Assert.Equal("percent", ex.ParamName);
        }

        /// <summary>
        /// Tests that linux player set volume with value 150 should throw argument out of range exception
        /// </summary>
        [Fact]
        public async Task LinuxPlayer_SetVolume_WithValue150_ShouldThrowArgumentOutOfRangeException()
        {
            LinuxPlayer player = new LinuxPlayer();
            ArgumentOutOfRangeException ex = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => player.SetVolume(150));
            Assert.Contains("100", ex.Message);
        }

        /// <summary>
        /// Tests that linux player set volume with value 255 should throw argument out of range exception
        /// </summary>
        [Fact]
        public async Task LinuxPlayer_SetVolume_WithValue255_ShouldThrowArgumentOutOfRangeException()
        {
            LinuxPlayer player = new LinuxPlayer();
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => player.SetVolume(255));
        }

        /// <summary>
        /// Tests that linux player set volume with value 0 should work
        /// </summary>
        [UnixOnly]
        public async Task LinuxPlayer_SetVolume_WithValue0_ShouldWork()
        {
            LinuxPlayer player = new LinuxPlayer();
            await player.SetVolume(0);
            Assert.NotNull(player);
        }

        /// <summary>
        /// Tests that linux player set volume with value 50 should work
        /// </summary>
        [UnixOnly]
        public async Task LinuxPlayer_SetVolume_WithValue50_ShouldWork()
        {
            LinuxPlayer player = new LinuxPlayer();
            await player.SetVolume(50);
            Assert.NotNull(player);
        }

        /// <summary>
        /// Tests that linux player set volume with value 100 should work
        /// </summary>
        [UnixOnly]
        public async Task LinuxPlayer_SetVolume_WithValue100_ShouldWork()
        {
            LinuxPlayer player = new LinuxPlayer();
            await player.SetVolume(100);
            Assert.NotNull(player);
        }

        /// <summary>
        /// Tests that linux player set volume boundary values should work
        /// </summary>
        [UnixOnly]
        public async Task LinuxPlayer_SetVolume_BoundaryValues_ShouldWork()
        {
            LinuxPlayer player = new LinuxPlayer();
            await player.SetVolume(0);
            await player.SetVolume(1);
            await player.SetVolume(99);
            await player.SetVolume(100);
        }

        /// <summary>
        /// Tests that linux player set volume multiple times should work
        /// </summary>
        [UnixOnly]
        public async Task LinuxPlayer_SetVolume_MultipleTimes_ShouldWork()
        {
            LinuxPlayer player = new LinuxPlayer();
            await player.SetVolume(0);
            await player.SetVolume(25);
            await player.SetVolume(50);
            await player.SetVolume(75);
            await player.SetVolume(100);
            await player.SetVolume(50);
            await player.SetVolume(0);
        }
    }
}
