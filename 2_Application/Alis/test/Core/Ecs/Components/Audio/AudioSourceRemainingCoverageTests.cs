using Alis.Core.Audio.Interfaces;
using Alis.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Systems.Scope;
using Moq;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Audio
{
    /// <summary>
    /// The audio source remaining coverage tests class
    /// </summary>
    public class AudioSourceRemainingCoverageTests
    {
        /// <summary>
        /// Tests that is playing when player is playing should return true
        /// </summary>
        [Fact]
        public void IsPlaying_WhenPlayerIsPlaying_ShouldReturnTrue()
        {
            Mock<IPlayer> mock = new Mock<IPlayer>();
            mock.Setup(p => p.Playing).Returns(true);

            Context context = new Context();
            AudioSource source = new AudioSource(context);
            source.PlayerForTest = mock.Object;

            bool result = source.IsPlaying;

            Assert.True(result);
        }

        /// <summary>
        /// Tests that is playing when player is not playing should return false
        /// </summary>
        [Fact]
        public void IsPlaying_WhenPlayerIsNotPlaying_ShouldReturnFalse()
        {
            Mock<IPlayer> mock = new Mock<IPlayer>();
            mock.Setup(p => p.Playing).Returns(false);

            Context context = new Context();
            AudioSource source = new AudioSource(context);
            source.PlayerForTest = mock.Object;

            bool result = source.IsPlaying;

            Assert.False(result);
        }

        /// <summary>
        /// Tests that play with empty full path and non empty name should use name file with mock
        /// </summary>
        [Fact]
        public void Play_WithEmptyFullPathAndNonEmptyName_ShouldUseNameFileWithMock()
        {
            Mock<IPlayer> mock = new Mock<IPlayer>();
            mock.Setup(p => p.Play(It.IsAny<string>())).Returns(System.Threading.Tasks.Task.CompletedTask);

            Context context = new Context();
            AudioSource source = new AudioSource(context);
            source.PlayerForTest = mock.Object;
            source.NameFile = "test.wav";

            source.Play();

            mock.Verify(p => p.Play("test.wav"), Times.Once);
        }

        /// <summary>
        /// Tests that stop with real player should not throw
        /// </summary>
        [Fact]
        public void Stop_WithRealPlayer_ShouldNotThrow()
        {
            Context context = new Context();
            AudioSource source = new AudioSource(context);

            source.Stop();
        }

        /// <summary>
        /// Tests that resume with real player should not throw
        /// </summary>
        [Fact]
        public void Resume_WithRealPlayer_ShouldNotThrow()
        {
            Context context = new Context();
            AudioSource source = new AudioSource(context);

            source.Resume();
        }

        /// <summary>
        /// Tests that play on awake with real player should not throw
        /// </summary>
        [Fact]
        public void PlayOnAwake_WithRealPlayer_ShouldNotThrow()
        {
            Context context = new Context();
            AudioSource source = new AudioSource(context);
            source.PlayOnAwake = true;
            source.NameFile = "test.wav";

            source.OnStart(null!);
        }
    }
}
