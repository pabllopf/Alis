// license header
using Alis.Extension.Graphic.Sfml.Systems;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    public class SoundBufferTest
    {
        [Fact]
        public void SoundBuffer_IsAssignableFromObjectBase()
        {
            var type = typeof(Alis.Extension.Graphic.Sfml.Audios.SoundBuffer);
            Assert.True(typeof(ObjectBase).IsAssignableFrom(type));
        }

        [Fact]
        public void SoundBuffer_Class_Exists()
        {
            var type = typeof(Alis.Extension.Graphic.Sfml.Audios.SoundBuffer);
            Assert.NotNull(type);
        }
    }
}
