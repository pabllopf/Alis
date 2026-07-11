// license header
using Alis.Extension.Graphic.Sfml.Systems;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    /// The music test class
    /// </summary>
    public class MusicTest
    {
        /// <summary>
        /// Tests that music is assignable from object base
        /// </summary>
        [Fact]
        public void Music_IsAssignableFromObjectBase()
        {
            var musicType = typeof(Alis.Extension.Graphic.Sfml.Audios.Music);
            Assert.True(typeof(ObjectBase).IsAssignableFrom(musicType));
        }

        /// <summary>
        /// Tests that music class exists
        /// </summary>
        [Fact]
        public void Music_Class_Exists()
        {
            var musicType = typeof(Alis.Extension.Graphic.Sfml.Audios.Music);
            Assert.NotNull(musicType);
        }

        /// <summary>
        /// Tests that music implements i disposable
        /// </summary>
        [Fact]
        public void Music_ImplementsIDisposable()
        {
            var musicType = typeof(Alis.Extension.Graphic.Sfml.Audios.Music);
            Assert.True(typeof(System.IDisposable).IsAssignableFrom(musicType));
        }
    }
}
