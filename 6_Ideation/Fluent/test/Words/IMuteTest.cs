using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    public class IMuteTest
    {
        [Fact]
        public void IMute_CanBeImplemented()
        {
            MuteBuilderImpl builder = new MuteBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IMute<MuteBuilder, bool>>(builder);
        }

        [Fact]
        public void Mute_SetsValueCorrectly()
        {
            MuteBuilderImpl builder = new MuteBuilderImpl();
            MuteBuilder result = builder.Mute(true);
            Assert.True(result.IsMuted);
        }

        [Fact]
        public void Mute_ReturnsBuilder()
        {
            MuteBuilderImpl builder = new MuteBuilderImpl();
            MuteBuilder result = builder.Mute(false);
            Assert.NotNull(result);
            Assert.IsType<MuteBuilder>(result);
        }

        [Theory, InlineData(true), InlineData(false)]
        public void Mute_WithBothValues(bool value)
        {
            MuteBuilderImpl builder = new MuteBuilderImpl();
            MuteBuilder result = builder.Mute(value);
            Assert.Equal(value, result.IsMuted);
        }

        [Fact]
        public void Mute_ToggleBetweenStates()
        {
            MuteBuilderImpl builder = new MuteBuilderImpl();
            MuteBuilder result1 = builder.Mute(true);
            Assert.True(result1.IsMuted);
            MuteBuilder result2 = builder.Mute(false);
            Assert.False(result2.IsMuted);
        }

        internal class MuteBuilder
        {
            public bool IsMuted { get; set; }
        }

        internal class MuteBuilderImpl : IMute<MuteBuilder, bool>
        {
            private readonly MuteBuilder _builder = new MuteBuilder();

            public MuteBuilder Mute(bool value)
            {
                _builder.IsMuted = value;
                return _builder;
            }
        }
    }
}
