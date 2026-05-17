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
        // GamepadState
        // =====================================================================

        [Fact]
        public void GamepadState_DefaultValues_AreCorrect()
        {
            var state = new GamepadState();
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
            var state = new GamepadState();
            foreach (bool button in state.Buttons)
            {
                Assert.False(button);
            }
        }

        [Fact]
        public void GamepadState_GetButton_ValidIndex_ReturnsCorrectValue()
        {
            var state = new GamepadState();
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
            var state = new GamepadState();
            Assert.False(state.GetButton(index));
        }

        [Fact]
        public void GamepadState_ButtonA_ReturnsButtons0()
        {
            var state = new GamepadState();
            state.Buttons[0] = true;
            Assert.True(state.ButtonA);
        }

        [Fact]
        public void GamepadState_ButtonB_ReturnsButtons1()
        {
            var state = new GamepadState();
            state.Buttons[1] = true;
            Assert.True(state.ButtonB);
        }

        [Fact]
        public void GamepadState_ButtonX_ReturnsButtons2()
        {
            var state = new GamepadState();
            state.Buttons[2] = true;
            Assert.True(state.ButtonX);
        }

        [Fact]
        public void GamepadState_ButtonY_ReturnsButtons3()
        {
            var state = new GamepadState();
            state.Buttons[3] = true;
            Assert.True(state.ButtonY);
        }

        [Fact]
        public void GamepadState_ButtonLb_ReturnsButtons4()
        {
            var state = new GamepadState();
            state.Buttons[4] = true;
            Assert.True(state.ButtonLb);
        }

        [Fact]
        public void GamepadState_ButtonRb_ReturnsButtons5()
        {
            var state = new GamepadState();
            state.Buttons[5] = true;
            Assert.True(state.ButtonRb);
        }

        [Fact]
        public void GamepadState_ButtonLeftStickClick_ReturnsButtons10()
        {
            var state = new GamepadState();
            state.Buttons[10] = true;
            Assert.True(state.ButtonLeftStickClick);
        }

        [Fact]
        public void GamepadState_ButtonRightStickClick_ReturnsButtons11()
        {
            var state = new GamepadState();
            state.Buttons[11] = true;
            Assert.True(state.ButtonRightStickClick);
        }

        [Fact]
        public void GamepadState_ButtonStart_ReturnsButtons9()
        {
            var state = new GamepadState();
            state.Buttons[9] = true;
            Assert.True(state.ButtonStart);
        }

        [Fact]
        public void GamepadState_ButtonBack_ReturnsButtons8()
        {
            var state = new GamepadState();
            state.Buttons[8] = true;
            Assert.True(state.ButtonBack);
        }

        [Fact]
        public void GamepadState_ButtonGuide_ReturnsButtons12()
        {
            var state = new GamepadState();
            state.Buttons[12] = true;
            Assert.True(state.ButtonGuide);
        }

        [Fact]
        public void GamepadState_SetConnected_Works()
        {
            var state = new GamepadState { Connected = true };
            Assert.True(state.Connected);
        }

        [Fact]
        public void GamepadState_SetAnalogSticks_Works()
        {
            var state = new GamepadState
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
            var state = new GamepadState
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
            var state = new GamepadState();
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
            var state = new GamepadState();
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
            var state = new GamepadState();
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
        // GamepadInputState
        // =====================================================================

        [Fact]
        public void GamepadInputState_Default_NullStates()
        {
            var state = new GamepadInputState();
            Assert.Null(state.CurrentState);
            Assert.Null(state.PreviousState);
        }

        [Fact]
        public void GamepadInputState_Update_ShiftsCurrentToPrevious()
        {
            var state = new GamepadInputState();
            var newState = new GamepadState { Connected = true, LeftStickX = 0.5f };
            state.Update(newState);
            Assert.Equal(newState, state.CurrentState);
            Assert.Null(state.PreviousState);
        }

        [Fact]
        public void GamepadInputState_UpdateTwice_PreservesPrevious()
        {
            var state = new GamepadInputState();
            var first = new GamepadState { Connected = true, LeftStickX = 0.3f };
            var second = new GamepadState { Connected = true, LeftStickX = 0.7f };
            state.Update(first);
            state.Update(second);
            Assert.Equal(second, state.CurrentState);
            Assert.Equal(first, state.PreviousState);
        }

        [Fact]
        public void GamepadInputState_SetProperties_Works()
        {
            var state = new GamepadInputState
            {
                CurrentState = new GamepadState { Connected = true },
                PreviousState = new GamepadState { Connected = false }
            };
            Assert.True(state.CurrentState.Connected);
            Assert.False(state.PreviousState.Connected);
        }
    }
}
