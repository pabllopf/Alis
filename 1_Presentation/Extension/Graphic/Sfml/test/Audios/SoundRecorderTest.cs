// license header
using Alis.Extension.Graphic.Sfml.Systems;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    public class SoundRecorderTest
    {
        [Fact]
        public void SoundRecorder_IsAssignableFromObjectBase()
        {
            var type = typeof(Alis.Extension.Graphic.Sfml.Audios.SoundRecorder);
            Assert.True(typeof(ObjectBase).IsAssignableFrom(type));
        }

        [Fact]
        public void SoundRecorder_Class_Exists()
        {
            var type = typeof(Alis.Extension.Graphic.Sfml.Audios.SoundRecorder);
            Assert.NotNull(type);
        }
    }
}
