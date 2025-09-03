using Xunit;
using Alis.Extension.Graphic.Sfml.Audios;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    /// The sound buffer recorder tests class
    /// </summary>
    public class SoundBufferRecorderTests
    {
        /// <summary>
        /// Tests that constructor default does not throw
        /// </summary>
        [Fact(Skip = "Cannot test SoundBufferRecorder without native SFML dependencies.")]
        public void Constructor_Default_DoesNotThrow()
        {
            SoundBufferRecorder recorder = new SoundBufferRecorder();
            Assert.NotNull(recorder);
        }

        /// <summary>
        /// Tests that to string returns sound buffer recorder
        /// </summary>
        [Fact(Skip = "Cannot test SoundBufferRecorder without native SFML dependencies.")]
        public void ToString_ReturnsSoundBufferRecorder()
        {
            SoundBufferRecorder recorder = new SoundBufferRecorder();
            Assert.Equal("SoundBufferRecorder", recorder.ToString());
        }
    }
}

