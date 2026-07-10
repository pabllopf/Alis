using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    public class ISetAudioClipTest
    {
        [Fact]
        public void ISetAudioClip_CanBeImplemented()
        {
            SetAudioClipBuilderImpl builder = new SetAudioClipBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<ISetAudioClip<SetAudioClipBuilder, string>>(builder);
        }

        [Fact]
        public void SetAudioClip_SetsClipCorrectly()
        {
            SetAudioClipBuilderImpl builder = new SetAudioClipBuilderImpl();
            SetAudioClipBuilder result = builder.SetAudioClip("explosion.wav");
            Assert.Equal("explosion.wav", result.AudioClip);
        }

        [Fact]
        public void SetAudioClip_ReturnsBuilder()
        {
            SetAudioClipBuilderImpl builder = new SetAudioClipBuilderImpl();
            SetAudioClipBuilder result = builder.SetAudioClip("music.ogg");
            Assert.NotNull(result);
            Assert.IsType<SetAudioClipBuilder>(result);
        }

        [Theory, InlineData("hit.wav"), InlineData("ambient.ogg"), InlineData("voice.mp3"), InlineData("footstep.wav")]
        public void SetAudioClip_WithVariousClips(string clip)
        {
            SetAudioClipBuilderImpl builder = new SetAudioClipBuilderImpl();
            SetAudioClipBuilder result = builder.SetAudioClip(clip);
            Assert.Equal(clip, result.AudioClip);
        }

        [Fact]
        public void SetAudioClip_WithNullClip()
        {
            SetAudioClipBuilderImpl builder = new SetAudioClipBuilderImpl();
            SetAudioClipBuilder result = builder.SetAudioClip(null);
            Assert.Null(result.AudioClip);
        }

        internal class SetAudioClipBuilder
        {
            public string AudioClip { get; set; }
        }

        internal class SetAudioClipBuilderImpl : ISetAudioClip<SetAudioClipBuilder, string>
        {
            private readonly SetAudioClipBuilder _builder = new SetAudioClipBuilder();

            public SetAudioClipBuilder SetAudioClip(string value)
            {
                _builder.AudioClip = value;
                return _builder;
            }
        }
    }
}
