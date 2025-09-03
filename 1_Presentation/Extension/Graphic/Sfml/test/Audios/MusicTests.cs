using Xunit;
using Alis.Extension.Graphic.Sfml.Audios;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    /// The music tests class
    /// </summary>
    public class MusicTests
    {
        /// <summary>
        /// Tests that constructor from file throws if file not found
        /// </summary>
        [Fact(Skip = "Cannot test Music without native SFML dependencies and audio files.")]
        public void Constructor_FromFile_ThrowsIfFileNotFound()
        {
            Assert.Throws<Alis.Extension.Graphic.Sfml.Windows.LoadingFailedException>(() => new Music("notfound.ogg"));
        }

        /// <summary>
        /// Tests that to string returns music
        /// </summary>
        [Fact(Skip = "Cannot test Music without native SFML dependencies.")]
        public void ToString_ReturnsMusic()
        {
            Music music = new Music("somefile.ogg");
            Assert.Equal("Music", music.ToString());
        }
    }
}

