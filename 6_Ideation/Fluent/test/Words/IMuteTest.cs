using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    /// The mute test class
    /// </summary>
    public class IMuteTest
    {
        /// <summary>
        /// Tests that i mute can be implemented
        /// </summary>
        [Fact]
        public void IMute_CanBeImplemented()
        {
            MuteBuilderImpl builder = new MuteBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IMute<MuteBuilder, bool>>(builder);
        }

        /// <summary>
        /// Tests that mute sets value correctly
        /// </summary>
        [Fact]
        public void Mute_SetsValueCorrectly()
        {
            MuteBuilderImpl builder = new MuteBuilderImpl();
            MuteBuilder result = builder.Mute(true);
            Assert.True(result.IsMuted);
        }

        /// <summary>
        /// Tests that mute returns builder
        /// </summary>
        [Fact]
        public void Mute_ReturnsBuilder()
        {
            MuteBuilderImpl builder = new MuteBuilderImpl();
            MuteBuilder result = builder.Mute(false);
            Assert.NotNull(result);
            Assert.IsType<MuteBuilder>(result);
        }

        /// <summary>
        /// Tests that mute with both values
        /// </summary>
        /// <param name="value">The value</param>
        [Theory, InlineData(true), InlineData(false)]
        public void Mute_WithBothValues(bool value)
        {
            MuteBuilderImpl builder = new MuteBuilderImpl();
            MuteBuilder result = builder.Mute(value);
            Assert.Equal(value, result.IsMuted);
        }

        /// <summary>
        /// Tests that mute toggle between states
        /// </summary>
        [Fact]
        public void Mute_ToggleBetweenStates()
        {
            MuteBuilderImpl builder = new MuteBuilderImpl();
            MuteBuilder result1 = builder.Mute(true);
            Assert.True(result1.IsMuted);
            MuteBuilder result2 = builder.Mute(false);
            Assert.False(result2.IsMuted);
        }

        /// <summary>
        /// The mute builder class
        /// </summary>
        internal class MuteBuilder
        {
            /// <summary>
            /// Gets or sets the value of the is muted
            /// </summary>
            public bool IsMuted { get; set; }
        }

        /// <summary>
        /// The mute builder impl class
        /// </summary>
        /// <seealso cref="IMute{MuteBuilder, bool}"/>
        internal class MuteBuilderImpl : IMute<MuteBuilder, bool>
        {
            /// <summary>
            /// The mute builder
            /// </summary>
            internal readonly MuteBuilder _builder = new MuteBuilder();

            /// <summary>
            /// Mutes the value
            /// </summary>
            /// <param name="value">The value</param>
            /// <returns>The builder</returns>
            public MuteBuilder Mute(bool value)
            {
                _builder.IsMuted = value;
                return _builder;
            }
        }
    }
}
