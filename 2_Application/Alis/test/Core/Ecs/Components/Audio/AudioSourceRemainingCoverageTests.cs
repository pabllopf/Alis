using Alis.Core.Audio.Interfaces;
using Alis.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Systems.Scope;
using Moq;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Audio
{
    public class AudioSourceRemainingCoverageTests
    {
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

        [Fact]
        public void Stop_WithRealPlayer_ShouldNotThrow()
        {
            Context context = new Context();
            AudioSource source = new AudioSource(context);

            source.Stop();
        }

        [Fact]
        public void Resume_WithRealPlayer_ShouldNotThrow()
        {
            Context context = new Context();
            AudioSource source = new AudioSource(context);

            source.Resume();
        }

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
