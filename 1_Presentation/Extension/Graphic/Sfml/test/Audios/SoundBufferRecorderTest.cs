// license header
using Alis.Extension.Graphic.Sfml.Systems;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    public class SoundBufferRecorderTest
    {
        [Fact]
        public void SoundBufferRecorder_IsAssignableFromObjectBase()
        {
            var type = typeof(Alis.Extension.Graphic.Sfml.Audios.SoundBufferRecorder);
            Assert.True(typeof(ObjectBase).IsAssignableFrom(type));
        }

        [Fact]
        public void SoundBufferRecorder_Class_Exists()
        {
            var type = typeof(Alis.Extension.Graphic.Sfml.Audios.SoundBufferRecorder);
            Assert.NotNull(type);
        }
    }
}
