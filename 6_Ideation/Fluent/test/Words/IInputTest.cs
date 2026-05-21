

using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    ///     Unit tests for the IInput interface.
    ///     Tests the Input method for input configuration.
    /// </summary>
    public class IInputTest
    {
        /// <summary>
        ///     Tests that IInput can be implemented.
        /// </summary>
        [Fact]
        public void IInput_CanBeImplemented()
        {
            InputBuilderImpl builder = new InputBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IInput<InputBuilder, string>>(builder);
        }

        /// <summary>
        ///     Tests that Input sets mode correctly.
        /// </summary>
        [Fact]
        public void Input_SetsModeCorrectly()
        {
            InputBuilderImpl builder = new InputBuilderImpl();
            InputBuilder result = builder.Input("Keyboard");
            Assert.Equal("Keyboard", result.InputMode);
        }

        /// <summary>
        ///     Tests that Input returns builder.
        /// </summary>
        [Fact]
        public void Input_ReturnsBuilder()
        {
            InputBuilderImpl builder = new InputBuilderImpl();
            InputBuilder result = builder.Input("Gamepad");
            Assert.NotNull(result);
            Assert.IsType<InputBuilder>(result);
        }

        /// <summary>
        ///     Tests Input with various modes.
        /// </summary>
        [Theory, InlineData("Keyboard"), InlineData("Mouse"), InlineData("Gamepad"), InlineData("Touch")]
        public void Input_WithVariousModes(string mode)
        {
            InputBuilderImpl builder = new InputBuilderImpl();
            InputBuilder result = builder.Input(mode);
            Assert.Equal(mode, result.InputMode);
        }

        /// <summary>
        ///     Helper builder class for input.
        /// </summary>
        private class InputBuilder
        {
            /// <summary>
            ///     Gets or sets the value of the input mode
            /// </summary>
            public string InputMode { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IInput.
        /// </summary>
        private class InputBuilderImpl : IInput<InputBuilder, string>
        {
            /// <summary>
            ///     The input builder
            /// </summary>
            private readonly InputBuilder _builder = new InputBuilder();

            /// <summary>
            ///     Inputs the value
            /// </summary>
            /// <param name="value">The value</param>
            /// <returns>The builder</returns>
            public InputBuilder Input(string value)
            {
                _builder.InputMode = value;
                return _builder;
            }
        }
    }
}