// license header
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    /// The sound recorder test class
    /// </summary>
    public class SoundRecorderTest
    {
        /// <summary>
        /// Tests that sound recorder is assignable from object base
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundRecorder_IsAssignableFromObjectBase()
        {
            var type = typeof(Alis.Extension.Graphic.Sfml.Audios.SoundRecorder);
            Assert.True(typeof(ObjectBase).IsAssignableFrom(type));
        }

        /// <summary>
        /// Tests that sound recorder class exists
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundRecorder_Class_Exists()
        {
            var type = typeof(Alis.Extension.Graphic.Sfml.Audios.SoundRecorder);
            Assert.NotNull(type);
        }
    }
}
