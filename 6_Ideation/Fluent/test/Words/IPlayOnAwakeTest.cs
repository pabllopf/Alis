using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    public class IPlayOnAwakeTest
    {
        [Fact]
        public void IPlayOnAwake_CanBeImplemented()
        {
            PlayOnAwakeBuilderImpl builder = new PlayOnAwakeBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IPlayOnAwake<PlayOnAwakeBuilder, bool>>(builder);
        }

        [Fact]
        public void PlayOnAwake_SetsValueCorrectly()
        {
            PlayOnAwakeBuilderImpl builder = new PlayOnAwakeBuilderImpl();
            PlayOnAwakeBuilder result = builder.PlayOnAwake(true);
            Assert.True(result.IsPlayOnAwake);
        }

        [Fact]
        public void PlayOnAwake_ReturnsBuilder()
        {
            PlayOnAwakeBuilderImpl builder = new PlayOnAwakeBuilderImpl();
            PlayOnAwakeBuilder result = builder.PlayOnAwake(false);
            Assert.NotNull(result);
            Assert.IsType<PlayOnAwakeBuilder>(result);
        }

        [Theory, InlineData(true), InlineData(false)]
        public void PlayOnAwake_WithBothValues(bool value)
        {
            PlayOnAwakeBuilderImpl builder = new PlayOnAwakeBuilderImpl();
            PlayOnAwakeBuilder result = builder.PlayOnAwake(value);
            Assert.Equal(value, result.IsPlayOnAwake);
        }

        [Fact]
        public void PlayOnAwake_DefaultIsFalse()
        {
            PlayOnAwakeBuilderImpl builder = new PlayOnAwakeBuilderImpl();
            PlayOnAwakeBuilder result = builder.PlayOnAwake(false);
            Assert.False(result.IsPlayOnAwake);
        }

        internal class PlayOnAwakeBuilder
        {
            public bool IsPlayOnAwake { get; set; }
        }

        internal class PlayOnAwakeBuilderImpl : IPlayOnAwake<PlayOnAwakeBuilder, bool>
        {
            private readonly PlayOnAwakeBuilder _builder = new PlayOnAwakeBuilder();

            public PlayOnAwakeBuilder PlayOnAwake(bool value)
            {
                _builder.IsPlayOnAwake = value;
                return _builder;
            }
        }
    }
}
