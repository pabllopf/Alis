using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    /// The set audio clip test class
    /// </summary>
    public class ISetAudioClipTest
    {
        /// <summary>
        /// Tests that i set audio clip can be implemented
        /// </summary>
        [Fact]
        public void ISetAudioClip_CanBeImplemented()
        {
            SetAudioClipBuilderImpl builder = new SetAudioClipBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<ISetAudioClip<SetAudioClipBuilder, string>>(builder);
        }

        /// <summary>
        /// Tests that set audio clip sets clip correctly
        /// </summary>
        [Fact]
        public void SetAudioClip_SetsClipCorrectly()
        {
            SetAudioClipBuilderImpl builder = new SetAudioClipBuilderImpl();
            SetAudioClipBuilder result = builder.SetAudioClip("explosion.wav");
            Assert.Equal("explosion.wav", result.AudioClip);
        }

        /// <summary>
        /// Tests that set audio clip returns builder
        /// </summary>
        [Fact]
        public void SetAudioClip_ReturnsBuilder()
        {
            SetAudioClipBuilderImpl builder = new SetAudioClipBuilderImpl();
            SetAudioClipBuilder result = builder.SetAudioClip("music.ogg");
            Assert.NotNull(result);
            Assert.IsType<SetAudioClipBuilder>(result);
        }

        /// <summary>
        /// Tests that set audio clip with various clips
        /// </summary>
        /// <param name="clip">The clip</param>
        [Theory, InlineData("hit.wav"), InlineData("ambient.ogg"), InlineData("voice.mp3"), InlineData("footstep.wav")]
        public void SetAudioClip_WithVariousClips(string clip)
        {
            SetAudioClipBuilderImpl builder = new SetAudioClipBuilderImpl();
            SetAudioClipBuilder result = builder.SetAudioClip(clip);
            Assert.Equal(clip, result.AudioClip);
        }

        /// <summary>
        /// Tests that set audio clip with null clip
        /// </summary>
        [Fact]
        public void SetAudioClip_WithNullClip()
        {
            SetAudioClipBuilderImpl builder = new SetAudioClipBuilderImpl();
            SetAudioClipBuilder result = builder.SetAudioClip(null);
            Assert.Null(result.AudioClip);
        }

        /// <summary>
        /// The set audio clip builder class
        /// </summary>
        internal class SetAudioClipBuilder
        {
            /// <summary>
            /// Gets or sets the value of the audio clip
            /// </summary>
            public string AudioClip { get; set; }
        }

        /// <summary>
        /// The set audio clip builder impl class
        /// </summary>
        /// <seealso cref="ISetAudioClip{SetAudioClipBuilder, string}"/>
        internal class SetAudioClipBuilderImpl : ISetAudioClip<SetAudioClipBuilder, string>
        {
            /// <summary>
            /// The set audio clip builder
            /// </summary>
            private readonly SetAudioClipBuilder _builder = new SetAudioClipBuilder();

            /// <summary>
            /// Sets the audio clip using the specified value
            /// </summary>
            /// <param name="value">The value</param>
            /// <returns>The builder</returns>
            public SetAudioClipBuilder SetAudioClip(string value)
            {
                _builder.AudioClip = value;
                return _builder;
            }
        }
    }
}
