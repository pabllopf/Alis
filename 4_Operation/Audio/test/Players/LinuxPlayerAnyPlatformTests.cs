using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    /// The linux player any platform tests class
    /// </summary>
    public class LinuxPlayerAnyPlatformTests
    {
        /// <summary>
        /// Tests that get bash command with wav returns mpg 123
        /// </summary>
        [Fact]
        public void GetBashCommand_WithWav_ReturnsMpg123()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("mpg123 -q", player.GetBashCommand("test.wav"));
        }

        /// <summary>
        /// Tests that get bash command with upper case wav returns mpg 123
        /// </summary>
        [Fact]
        public void GetBashCommand_WithUpperCaseWav_ReturnsMpg123()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("mpg123 -q", player.GetBashCommand("test.WAV"));
        }

        /// <summary>
        /// Tests that get bash command with mixed case wav returns mpg 123
        /// </summary>
        [Fact]
        public void GetBashCommand_WithMixedCaseWav_ReturnsMpg123()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("mpg123 -q", player.GetBashCommand("test.WaV"));
        }

        /// <summary>
        /// Tests that get bash command with mp 3 returns aplay
        /// </summary>
        [Fact]
        public void GetBashCommand_WithMp3_ReturnsAplay()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("aplay -q", player.GetBashCommand("test.mp3"));
        }

        /// <summary>
        /// Tests that get bash command with ogg returns aplay
        /// </summary>
        [Fact]
        public void GetBashCommand_WithOgg_ReturnsAplay()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("aplay -q", player.GetBashCommand("test.ogg"));
        }

        /// <summary>
        /// Tests that get bash command with flac returns aplay
        /// </summary>
        [Fact]
        public void GetBashCommand_WithFlac_ReturnsAplay()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("aplay -q", player.GetBashCommand("test.flac"));
        }

        /// <summary>
        /// Tests that get bash command with no extension returns aplay
        /// </summary>
        [Fact]
        public void GetBashCommand_WithNoExtension_ReturnsAplay()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("aplay -q", player.GetBashCommand("testfile"));
        }

        /// <summary>
        /// Tests that get bash command with empty string returns aplay
        /// </summary>
        [Fact]
        public void GetBashCommand_WithEmptyString_ReturnsAplay()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("aplay -q", player.GetBashCommand(string.Empty));
        }

        /// <summary>
        /// Tests that get bash command with dot wav in middle returns aplay
        /// </summary>
        [Fact]
        public void GetBashCommand_WithDotWavInMiddle_ReturnsAplay()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("aplay -q", player.GetBashCommand("test.wav.mp3"));
        }

        /// <summary>
        /// Tests that get bash command with spaces in path returns mpg 123
        /// </summary>
        [Fact]
        public void GetBashCommand_WithSpacesInPath_ReturnsMpg123()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("mpg123 -q", player.GetBashCommand("/path/to/my file.wav"));
        }

        /// <summary>
        /// Tests that get bash command with long path returns mpg 123
        /// </summary>
        [Fact]
        public void GetBashCommand_WithLongPath_ReturnsMpg123()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("mpg123 -q", player.GetBashCommand("/very/long/path/to/file.wav"));
        }

        /// <summary>
        /// Tests that get bash command with relative path returns mpg 123
        /// </summary>
        [Fact]
        public void GetBashCommand_WithRelativePath_ReturnsMpg123()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("mpg123 -q", player.GetBashCommand("./relative/path/file.wav"));
        }

        /// <summary>
        /// Tests that get bash command with special characters returns mpg 123
        /// </summary>
        [Fact]
        public void GetBashCommand_WithSpecialCharacters_ReturnsMpg123()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("mpg123 -q", player.GetBashCommand("test@#$.wav"));
        }

        /// <summary>
        /// Tests that get bash command with multiple dots returns mpg 123
        /// </summary>
        [Fact]
        public void GetBashCommand_WithMultipleDots_ReturnsMpg123()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("mpg123 -q", player.GetBashCommand("file.name.with.dots.wav"));
        }

        /// <summary>
        /// Tests that get bash command with null throws exception
        /// </summary>
        [Fact]
        public void GetBashCommand_WithNull_ThrowsException()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.ThrowsAny<System.Exception>(() => player.GetBashCommand(null));
        }

        /// <summary>
        /// Tests that get bash command case insensitive check all return mpg 123
        /// </summary>
        [Fact]
        public void GetBashCommand_CaseInsensitiveCheck_AllReturnMpg123()
        {
            LinuxPlayer player = new LinuxPlayer();
            Assert.Equal("mpg123 -q", player.GetBashCommand("test.wav"));
            Assert.Equal("mpg123 -q", player.GetBashCommand("test.WAV"));
            Assert.Equal("mpg123 -q", player.GetBashCommand("test.WaV"));
            Assert.Equal("mpg123 -q", player.GetBashCommand("test.wAv"));
        }

        /// <summary>
        /// Tests that constructor should initialize properly
        /// </summary>
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
