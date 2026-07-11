// license header
using Alis.Extension.Graphic.Sfml.Systems;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    public class SoundStreamTest
    {
        [Fact]
        public void SoundStream_IsAssignableFromObjectBase()
        {
            var type = typeof(Alis.Extension.Graphic.Sfml.Audios.SoundStream);
            Assert.True(typeof(ObjectBase).IsAssignableFrom(type));
        }

        [Fact]
        public void SoundStream_Class_Exists()
        {
            var type = typeof(Alis.Extension.Graphic.Sfml.Audios.SoundStream);
            Assert.NotNull(type);
        }
    }
}
