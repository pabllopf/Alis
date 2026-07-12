// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InputStateEnumTests.cs
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
        ///     Tests that input state release is defined
        /// </summary>
        [Fact]
        public void InputState_Release_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(InputState), InputState.Release);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that input state press is defined
        /// </summary>
        [Fact]
        public void InputState_Press_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(InputState), InputState.Press);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that input state repeat is defined
        /// </summary>
        [Fact]
        public void InputState_Repeat_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(InputState), InputState.Repeat);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that input state can be cast to int
        /// </summary>
        [Fact]
        public void InputState_CanBeCastToInt()
        {
            InputState state = InputState.Press;

            int value = (int) state;

            Assert.True(value >= 0);
        }

        /// <summary>
        ///     Tests that input state can be cast from int
        /// </summary>
        [Fact]
        public void InputState_CanBeCastFromInt()
        {
            int value = (int) InputState.Press;

            InputState state = (InputState) value;

            Assert.Equal(InputState.Press, state);
        }

        /// <summary>
        ///     Tests that input state all states are different
        /// </summary>
        [Fact]
        public void InputState_AllStates_AreDifferent()
        {
            Assert.NotEqual(InputState.Release, InputState.Press);
            Assert.NotEqual(InputState.Release, InputState.Repeat);
            Assert.NotEqual(InputState.Press, InputState.Repeat);
        }
    }
}