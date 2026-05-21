// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GamepadStateTest.cs
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

using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Tests for GamepadState and GamepadInputState.
    /// </summary>
    public class GamepadStateTest
    {
        // =====================================================================

        [Fact]
        public void GamepadState_DefaultValues_AreCorrect()
        {
            GamepadState state = new GamepadState();
            Assert.False(state.Connected);
            Assert.Equal(0.0f, state.LeftStickX);
            Assert.Equal(0.0f, state.LeftStickY);
            Assert.Equal(0.0f, state.RightStickX);
            Assert.Equal(0.0f, state.RightStickY);
            Assert.Equal(0.0f, state.LeftTrigger);
            Assert.Equal(0.0f, state.RightTrigger);
            Assert.NotNull(state.Buttons);
            Assert.Equal(13, state.Buttons.Length);
        }

        [Fact]
        public void GamepadState_ButtonsArray_AllFalseByDefault()
        {
            GamepadState state = new GamepadState();
            foreach (bool button in state.Buttons)
            {
                Assert.False(button);
            }
        }

        [Fact]
        public void GamepadState_GetButton_ValidIndex_ReturnsCorrectValue()
        {
            GamepadState state = new GamepadState();
            state.Buttons[0] = true;
            Assert.True(state.GetButton(0));
            Assert.False(state.GetButton(1));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(13)]
        [InlineData(100)]
        public void GamepadState_GetButton_InvalidIndex_ReturnsFalse(int index)
        {
            GamepadState state = new GamepadState();
            Assert.False(state.GetButton(index));
        }

        [Fact]
        public void GamepadState_ButtonA_ReturnsButtons0()
        {
            GamepadState state = new GamepadState();
            state.Buttons[0] = true;
            Assert.True(state.ButtonA);
        }

        [Fact]
        public void GamepadState_ButtonB_ReturnsButtons1()
        {
            GamepadState state = new GamepadState();
            state.Buttons[1] = true;
            Assert.True(state.ButtonB);
        }

        [Fact]
        public void GamepadState_ButtonX_ReturnsButtons2()
        {
            GamepadState state = new GamepadState();
            state.Buttons[2] = true;
            Assert.True(state.ButtonX);
        }

        [Fact]
        public void GamepadState_ButtonY_ReturnsButtons3()
        {
            GamepadState state = new GamepadState();
            state.Buttons[3] = true;
            Assert.True(state.ButtonY);
        }

        [Fact]
        public void GamepadState_ButtonLb_ReturnsButtons4()
        {
            GamepadState state = new GamepadState();
            state.Buttons[4] = true;
            Assert.True(state.ButtonLb);
        }

        [Fact]
        public void GamepadState_ButtonRb_ReturnsButtons5()
        {
            GamepadState state = new GamepadState();
            state.Buttons[5] = true;
            Assert.True(state.ButtonRb);
        }

        [Fact]
        public void GamepadState_ButtonLeftStickClick_ReturnsButtons10()
        {
            GamepadState state = new GamepadState();
            state.Buttons[10] = true;
            Assert.True(state.ButtonLeftStickClick);
        }

        [Fact]
        public void GamepadState_ButtonRightStickClick_ReturnsButtons11()
        {
            GamepadState state = new GamepadState();
            state.Buttons[11] = true;
            Assert.True(state.ButtonRightStickClick);
        }

        [Fact]
        public void GamepadState_ButtonStart_ReturnsButtons9()
        {
            GamepadState state = new GamepadState();
            state.Buttons[9] = true;
            Assert.True(state.ButtonStart);
        }

        [Fact]
        public void GamepadState_ButtonBack_ReturnsButtons8()
        {
            GamepadState state = new GamepadState();
            state.Buttons[8] = true;
            Assert.True(state.ButtonBack);
        }

        [Fact]
        public void GamepadState_ButtonGuide_ReturnsButtons12()
        {
            GamepadState state = new GamepadState();
            state.Buttons[12] = true;
            Assert.True(state.ButtonGuide);
        }

        [Fact]
        public void GamepadState_SetConnected_Works()
        {
            GamepadState state = new GamepadState { Connected = true };
            Assert.True(state.Connected);
        }

        [Fact]
        public void GamepadState_SetAnalogSticks_Works()
        {
            GamepadState state = new GamepadState
            {
                LeftStickX = 0.5f,
                LeftStickY = -0.3f,
                RightStickX = 0.8f,
                RightStickY = -0.1f
            };
            Assert.Equal(0.5f, state.LeftStickX);
            Assert.Equal(-0.3f, state.LeftStickY);
            Assert.Equal(0.8f, state.RightStickX);
            Assert.Equal(-0.1f, state.RightStickY);
        }

        [Fact]
        public void GamepadState_SetTriggers_Works()
        {
            GamepadState state = new GamepadState
            {
                LeftTrigger = 0.7f,
                RightTrigger = 0.9f
            };
            Assert.Equal(0.7f, state.LeftTrigger);
            Assert.Equal(0.9f, state.RightTrigger);
        }

        [Fact]
        public void GamepadState_SetAllButtons_True()
        {
            GamepadState state = new GamepadState();
            for (int i = 0; i < state.Buttons.Length; i++)
            {
                state.Buttons[i] = true;
            }
            for (int i = 0; i < state.Buttons.Length; i++)
            {
                Assert.True(state.GetButton(i));
            }
        }

        [Fact]
        public void GamepadState_SetAllButtons_False()
        {
            GamepadState state = new GamepadState();
            for (int i = 0; i < state.Buttons.Length; i++)
            {
                state.Buttons[i] = false;
            }
            for (int i = 0; i < state.Buttons.Length; i++)
            {
                Assert.False(state.GetButton(i));
            }
        }

        [Fact]
        public void GamepadState_AllButtonProperties_CorrectIndices()
        {
            GamepadState state = new GamepadState();
            state.Buttons[0] = true; Assert.True(state.ButtonA); state.Buttons[0] = false;
            state.Buttons[1] = true; Assert.True(state.ButtonB); state.Buttons[1] = false;
            state.Buttons[2] = true; Assert.True(state.ButtonX); state.Buttons[2] = false;
            state.Buttons[3] = true; Assert.True(state.ButtonY); state.Buttons[3] = false;
            state.Buttons[4] = true; Assert.True(state.ButtonLb); state.Buttons[4] = false;
            state.Buttons[5] = true; Assert.True(state.ButtonRb); state.Buttons[5] = false;
            state.Buttons[8] = true; Assert.True(state.ButtonBack); state.Buttons[8] = false;
            state.Buttons[9] = true; Assert.True(state.ButtonStart); state.Buttons[9] = false;
            state.Buttons[10] = true; Assert.True(state.ButtonLeftStickClick); state.Buttons[10] = false;
            state.Buttons[11] = true; Assert.True(state.ButtonRightStickClick); state.Buttons[11] = false;
            state.Buttons[12] = true; Assert.True(state.ButtonGuide); state.Buttons[12] = false;
        }

        // =====================================================================

        [Fact]
        public void GamepadInputState_Default_NullStates()
        {
            GamepadInputState state = new GamepadInputState();
            Assert.Null(state.CurrentState);
            Assert.Null(state.PreviousState);
        }

        [Fact]
        public void GamepadInputState_Update_ShiftsCurrentToPrevious()
        {
            GamepadInputState state = new GamepadInputState();
            GamepadState newState = new GamepadState { Connected = true, LeftStickX = 0.5f };
            state.Update(newState);
            Assert.Equal(newState, state.CurrentState);
            Assert.Null(state.PreviousState);
        }

        [Fact]
        public void GamepadInputState_UpdateTwice_PreservesPrevious()
        {
            GamepadInputState state = new GamepadInputState();
            GamepadState first = new GamepadState { Connected = true, LeftStickX = 0.3f };
            GamepadState second = new GamepadState { Connected = true, LeftStickX = 0.7f };
            state.Update(first);
            state.Update(second);
            Assert.Equal(second, state.CurrentState);
            Assert.Equal(first, state.PreviousState);
        }

        [Fact]
        public void GamepadInputState_SetProperties_Works()
        {
            GamepadInputState state = new GamepadInputState
            {
                CurrentState = new GamepadState { Connected = true },
                PreviousState = new GamepadState { Connected = false }
            };
            Assert.True(state.CurrentState.Connected);
            Assert.False(state.PreviousState.Connected);
        }
    }
}
