using Xunit;
using Alis.Extension.Graphic.Sfml.Audios;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    /// The sound tests class
    /// </summary>
    public class SoundTests
    {
        /// <summary>
        /// Tests that constructor default does not throw
        /// </summary>
        [Fact(Skip = "Cannot test Sound without native SFML dependencies.")]
        public void Constructor_Default_DoesNotThrow()
        {
            Sound sound = new Sound();
            Assert.NotNull(sound);
        }

        /// <summary>
        /// Tests that to string returns sound
        /// </summary>
        [Fact(Skip = "Cannot test Sound without native SFML dependencies.")]
        public void ToString_ReturnsSound()
        {
            Sound sound = new Sound();
            Assert.Equal("Sound", sound.ToString());
        }
    }
}

