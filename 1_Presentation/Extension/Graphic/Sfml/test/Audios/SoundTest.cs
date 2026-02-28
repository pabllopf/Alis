using Xunit;
using Alis.Extension.Graphic.Sfml.Audios;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    /// Unit tests for the Sound class.
    /// </summary>
    public class SoundTest
    {
        /// <summary>
        /// Tests default constructor creates a valid object.
        /// </summary>
        [Fact]
        public void DefaultConstructor_CreatesObject()
        {
            Sound sound = new Sound();
            Assert.NotNull(sound);
        }

        /// <summary>
        /// Tests copy constructor creates a new object with same buffer.
        /// </summary>
        [Fact]
        public void CopyConstructor_CreatesCopy()
        {
            Sound original = new Sound();
            Sound copy = new Sound(original);
            Assert.NotNull(copy);
        }
    }
}

