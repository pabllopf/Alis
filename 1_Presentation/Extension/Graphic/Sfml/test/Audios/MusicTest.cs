// license header
using Alis.Extension.Graphic.Sfml.Systems;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    public class MusicTest
    {
        [Fact]
        public void Music_IsAssignableFromObjectBase()
        {
            var musicType = typeof(Alis.Extension.Graphic.Sfml.Audios.Music);
            Assert.True(typeof(ObjectBase).IsAssignableFrom(musicType));
        }

        [Fact]
        public void Music_Class_Exists()
        {
            var musicType = typeof(Alis.Extension.Graphic.Sfml.Audios.Music);
            Assert.NotNull(musicType);
        }

        [Fact]
        public void Music_ImplementsIDisposable()
        {
            var musicType = typeof(Alis.Extension.Graphic.Sfml.Audios.Music);
            Assert.True(typeof(System.IDisposable).IsAssignableFrom(musicType));
        }
    }
}
