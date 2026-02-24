// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InputStateEnumTests.cs
// 
//  Author:GitHub Copilot
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

using System;
using Alis.Extension.Graphic.Glfw.Enums;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Enums
{
    /// <summary>
    ///     Tests for InputState enum
    /// </summary>
    public class InputStateEnumTests
    {
        /// <summary>
        /// Tests that input state release is defined
        /// </summary>
        [Fact]
        public void InputState_Release_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(InputState), InputState.Release);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that input state press is defined
        /// </summary>
        [Fact]
        public void InputState_Press_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(InputState), InputState.Press);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that input state repeat is defined
        /// </summary>
        [Fact]
        public void InputState_Repeat_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(InputState), InputState.Repeat);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that input state can be cast to int
        /// </summary>
        [Fact]
        public void InputState_CanBeCastToInt()
        {
            // Arrange
            InputState state = InputState.Press;

            // Act
            int value = (int)state;

            // Assert
            Assert.True(value >= 0);
        }

        /// <summary>
        /// Tests that input state can be cast from int
        /// </summary>
        [Fact]
        public void InputState_CanBeCastFromInt()
        {
            // Arrange
            int value = (int)InputState.Press;

            // Act
            InputState state = (InputState)value;

            // Assert
            Assert.Equal(InputState.Press, state);
        }

        /// <summary>
        /// Tests that input state all states are different
        /// </summary>
        [Fact]
        public void InputState_AllStates_AreDifferent()
        {
            // Assert
            Assert.NotEqual(InputState.Release, InputState.Press);
            Assert.NotEqual(InputState.Release, InputState.Repeat);
            Assert.NotEqual(InputState.Press, InputState.Repeat);
        }
    }
}

