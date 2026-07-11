// license header
using Alis.Extension.Graphic.Sfml.Systems;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    /// The sound buffer test class
    /// </summary>
    public class SoundBufferTest
    {
        /// <summary>
        /// Tests that sound buffer is assignable from object base
        /// </summary>
        [Fact]
        public void SoundBuffer_IsAssignableFromObjectBase()
        {
            var type = typeof(Alis.Extension.Graphic.Sfml.Audios.SoundBuffer);
            Assert.True(typeof(ObjectBase).IsAssignableFrom(type));
        }

        /// <summary>
        /// Tests that sound buffer class exists
        /// </summary>
        [Fact]
        public void SoundBuffer_Class_Exists()
        {
            var type = typeof(Alis.Extension.Graphic.Sfml.Audios.SoundBuffer);
            Assert.NotNull(type);
        }
    }
}
