// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IInputTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

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
            public string InputMode { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IInput.
        /// </summary>
        private class InputBuilderImpl : IInput<InputBuilder, string>
        {
            private readonly InputBuilder _builder = new InputBuilder();

            public InputBuilder Input(string value)
            {
                _builder.InputMode = value;
                return _builder;
            }
        }
    }
}