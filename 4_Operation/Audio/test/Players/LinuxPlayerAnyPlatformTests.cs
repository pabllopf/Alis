using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    public class LinuxPlayerAnyPlatformTests
    {
        [Fact]
        public void GetBashCommand_WithWav_ReturnsMpg123()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("mpg123 -q", player.GetBashCommand("test.wav"));
        }

        [Fact]
        public void GetBashCommand_WithUpperCaseWav_ReturnsMpg123()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("mpg123 -q", player.GetBashCommand("test.WAV"));
        }

        [Fact]
        public void GetBashCommand_WithMixedCaseWav_ReturnsMpg123()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("mpg123 -q", player.GetBashCommand("test.WaV"));
        }

        [Fact]
        public void GetBashCommand_WithMp3_ReturnsAplay()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("aplay -q", player.GetBashCommand("test.mp3"));
        }

        [Fact]
        public void GetBashCommand_WithOgg_ReturnsAplay()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("aplay -q", player.GetBashCommand("test.ogg"));
        }

        [Fact]
        public void GetBashCommand_WithFlac_ReturnsAplay()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("aplay -q", player.GetBashCommand("test.flac"));
        }

        [Fact]
        public void GetBashCommand_WithNoExtension_ReturnsAplay()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("aplay -q", player.GetBashCommand("testfile"));
        }

        [Fact]
        public void GetBashCommand_WithEmptyString_ReturnsAplay()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("aplay -q", player.GetBashCommand(string.Empty));
        }

        [Fact]
        public void GetBashCommand_WithDotWavInMiddle_ReturnsAplay()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("aplay -q", player.GetBashCommand("test.wav.mp3"));
        }

        [Fact]
        public void GetBashCommand_WithSpacesInPath_ReturnsMpg123()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("mpg123 -q", player.GetBashCommand("/path/to/my file.wav"));
        }

        [Fact]
        public void GetBashCommand_WithLongPath_ReturnsMpg123()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("mpg123 -q", player.GetBashCommand("/very/long/path/to/file.wav"));
        }

        [Fact]
        public void GetBashCommand_WithRelativePath_ReturnsMpg123()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("mpg123 -q", player.GetBashCommand("./relative/path/file.wav"));
        }

        [Fact]
        public void GetBashCommand_WithSpecialCharacters_ReturnsMpg123()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("mpg123 -q", player.GetBashCommand("test@#$.wav"));
        }

        [Fact]
        public void GetBashCommand_WithMultipleDots_ReturnsMpg123()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("mpg123 -q", player.GetBashCommand("file.name.with.dots.wav"));
        }

        [Fact]
        public void GetBashCommand_WithNull_ThrowsException()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.ThrowsAny<System.Exception>(() => player.GetBashCommand(null));
        }

        [Fact]
        public void GetBashCommand_CaseInsensitiveCheck_AllReturnMpg123()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("mpg123 -q", player.GetBashCommand("test.wav"));
            Assert.Equal("mpg123 -q", player.GetBashCommand("test.WAV"));
            Assert.Equal("mpg123 -q", player.GetBashCommand("test.WaV"));
            Assert.Equal("mpg123 -q", player.GetBashCommand("test.wAv"));
        }

        [Fact]
        public void Constructor_ShouldInitializeProperly()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.NotNull(player);
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }
    }
}
