// license header
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    /// The sound stream test class
    /// </summary>
    public class SoundStreamTest
    {
        /// <summary>
        /// Tests that sound stream is assignable from object base
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundStream_IsAssignableFromObjectBase()
        {
            var type = typeof(Alis.Extension.Graphic.Sfml.Audios.SoundStream);
            Assert.True(typeof(ObjectBase).IsAssignableFrom(type));
        }

        /// <summary>
        /// Tests that sound stream class exists
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundStream_Class_Exists()
        {
            var type = typeof(Alis.Extension.Graphic.Sfml.Audios.SoundStream);
            Assert.NotNull(type);
        }
    }
}
