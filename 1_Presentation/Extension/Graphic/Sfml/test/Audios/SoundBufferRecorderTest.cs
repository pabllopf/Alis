// license header
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    /// The sound buffer recorder test class
    /// </summary>
    public class SoundBufferRecorderTest
    {
        /// <summary>
        /// Tests that sound buffer recorder is assignable from object base
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBufferRecorder_IsAssignableFromObjectBase()
        {
            var type = typeof(Alis.Extension.Graphic.Sfml.Audios.SoundBufferRecorder);
            Assert.True(typeof(ObjectBase).IsAssignableFrom(type));
        }

        /// <summary>
        /// Tests that sound buffer recorder class exists
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBufferRecorder_Class_Exists()
        {
            var type = typeof(Alis.Extension.Graphic.Sfml.Audios.SoundBufferRecorder);
            Assert.NotNull(type);
        }
    }
}
