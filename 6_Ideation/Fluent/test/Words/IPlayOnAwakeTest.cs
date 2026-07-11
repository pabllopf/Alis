using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    /// The play on awake test class
    /// </summary>
    public class IPlayOnAwakeTest
    {
        /// <summary>
        /// Tests that i play on awake can be implemented
        /// </summary>
        [Fact]
        public void IPlayOnAwake_CanBeImplemented()
        {
            PlayOnAwakeBuilderImpl builder = new PlayOnAwakeBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IPlayOnAwake<PlayOnAwakeBuilder, bool>>(builder);
        }

        /// <summary>
        /// Tests that play on awake sets value correctly
        /// </summary>
        [Fact]
        public void PlayOnAwake_SetsValueCorrectly()
        {
            PlayOnAwakeBuilderImpl builder = new PlayOnAwakeBuilderImpl();
            PlayOnAwakeBuilder result = builder.PlayOnAwake(true);
            Assert.True(result.IsPlayOnAwake);
        }

        /// <summary>
        /// Tests that play on awake returns builder
        /// </summary>
        [Fact]
        public void PlayOnAwake_ReturnsBuilder()
        {
            PlayOnAwakeBuilderImpl builder = new PlayOnAwakeBuilderImpl();
            PlayOnAwakeBuilder result = builder.PlayOnAwake(false);
            Assert.NotNull(result);
            Assert.IsType<PlayOnAwakeBuilder>(result);
        }

        /// <summary>
        /// Tests that play on awake with both values
        /// </summary>
        /// <param name="value">The value</param>
        [Theory, InlineData(true), InlineData(false)]
        public void PlayOnAwake_WithBothValues(bool value)
        {
            PlayOnAwakeBuilderImpl builder = new PlayOnAwakeBuilderImpl();
            PlayOnAwakeBuilder result = builder.PlayOnAwake(value);
            Assert.Equal(value, result.IsPlayOnAwake);
        }

        /// <summary>
        /// Tests that play on awake default is false
        /// </summary>
        [Fact]
        public void PlayOnAwake_DefaultIsFalse()
        {
            PlayOnAwakeBuilderImpl builder = new PlayOnAwakeBuilderImpl();
            PlayOnAwakeBuilder result = builder.PlayOnAwake(false);
            Assert.False(result.IsPlayOnAwake);
        }

        /// <summary>
        /// The play on awake builder class
        /// </summary>
        internal class PlayOnAwakeBuilder
        {
            /// <summary>
            /// Gets or sets the value of the is play on awake
            /// </summary>
            public bool IsPlayOnAwake { get; set; }
        }

        /// <summary>
        /// The play on awake builder impl class
        /// </summary>
        /// <seealso cref="IPlayOnAwake{PlayOnAwakeBuilder, bool}"/>
        internal class PlayOnAwakeBuilderImpl : IPlayOnAwake<PlayOnAwakeBuilder, bool>
        {
            /// <summary>
            /// The play on awake builder
            /// </summary>
            private readonly PlayOnAwakeBuilder _builder = new PlayOnAwakeBuilder();

            /// <summary>
            /// Plays the on awake using the specified value
            /// </summary>
            /// <param name="value">The value</param>
            /// <returns>The builder</returns>
            public PlayOnAwakeBuilder PlayOnAwake(bool value)
            {
                _builder.IsPlayOnAwake = value;
                return _builder;
            }
        }
    }
}
