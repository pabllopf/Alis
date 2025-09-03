using Xunit;
using Alis.Extension.Graphic.Sfml.Audios;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    /// The sound buffer tests class
    /// </summary>
    public class SoundBufferTests
    {
        /// <summary>
        /// Tests that constructor from file throws if file not found
        /// </summary>
        [Fact(Skip = "Cannot test SoundBuffer without native SFML dependencies and audio files.")]
        public void Constructor_FromFile_ThrowsIfFileNotFound()
        {
            Assert.Throws<Alis.Extension.Graphic.Sfml.Windows.LoadingFailedException>(() => new SoundBuffer("notfound.wav"));
        }

        /// <summary>
        /// Tests that to string returns sound buffer
        /// </summary>
        [Fact(Skip = "Cannot test SoundBuffer without native SFML dependencies.")]
        public void ToString_ReturnsSoundBuffer()
        {
            SoundBuffer buffer = new SoundBuffer("somefile.wav");
            Assert.Equal("SoundBuffer", buffer.ToString());
        }
    }
}

