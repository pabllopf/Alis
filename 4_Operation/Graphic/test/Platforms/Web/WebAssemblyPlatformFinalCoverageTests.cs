// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyPlatformFinalCoverageTests.cs
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
using System.Reflection;
using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    public class WebAssemblyPlatformFinalCoverageTests
    {
        [Fact]
        public void ConvertKeyCode_AlphabetB_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 66, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.B));
        }

        [Fact]
        public void ConvertKeyCode_AlphabetC_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 67, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.C));
        }

        [Fact]
        public void ConvertKeyCode_AlphabetD_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 68, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.D));
        }

        [Fact]
        public void ConvertKeyCode_AlphabetE_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 69, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.E));
        }

        [Fact]
        public void ConvertKeyCode_AlphabetF_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 70, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F));
        }

        [Fact]
        public void ConvertKeyCode_AlphabetG_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 71, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.G));
        }

        [Fact]
        public void ConvertKeyCode_AlphabetH_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 72, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.H));
        }

        [Fact]
        public void ConvertKeyCode_AlphabetI_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 73, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.I));
        }

        [Fact]
        public void ConvertKeyCode_AlphabetJ_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 74, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.J));
        }

        [Fact]
        public void ConvertKeyCode_AlphabetK_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 75, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.K));
        }

        [Fact]
        public void ConvertKeyCode_AlphabetL_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 76, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.L));
        }

        [Fact]
        public void ConvertKeyCode_AlphabetM_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 77, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.M));
        }

        [Fact]
        public void ConvertKeyCode_AlphabetN_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 78, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.N));
        }

        [Fact]
        public void ConvertKeyCode_AlphabetO_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 79, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.O));
        }

        [Fact]
        public void ConvertKeyCode_AlphabetP_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 80, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.P));
        }

        [Fact]
        public void ConvertKeyCode_AlphabetQ_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 81, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Q));
        }

        [Fact]
        public void ConvertKeyCode_AlphabetR_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 82, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.R));
        }

        [Fact]
        public void ConvertKeyCode_AlphabetS_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 83, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.S));
        }

        [Fact]
        public void ConvertKeyCode_AlphabetT_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 84, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.T));
        }

        [Fact]
        public void ConvertKeyCode_AlphabetU_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 85, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.U));
        }

        [Fact]
        public void ConvertKeyCode_AlphabetV_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 86, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.V));
        }

        [Fact]
        public void ConvertKeyCode_AlphabetW_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 87, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.W));
        }

        [Fact]
        public void ConvertKeyCode_AlphabetX_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 88, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.X));
        }

        [Fact]
        public void ConvertKeyCode_AlphabetY_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 89, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Y));
        }

        [Fact]
        public void ConvertKeyCode_Number1_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 49, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.D1));
        }

        [Fact]
        public void ConvertKeyCode_Number2_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 50, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.D2));
        }

        [Fact]
        public void ConvertKeyCode_Number3_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 51, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.D3));
        }

        [Fact]
        public void ConvertKeyCode_Number4_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 52, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.D4));
        }

        [Fact]
        public void ConvertKeyCode_Number5_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 53, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.D5));
        }

        [Fact]
        public void ConvertKeyCode_Number6_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 54, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.D6));
        }

        [Fact]
        public void ConvertKeyCode_Number7_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 55, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.D7));
        }

        [Fact]
        public void ConvertKeyCode_Number8_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 56, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.D8));
        }

        [Fact]
        public void ConvertKeyCode_FunctionKeyF2_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 113, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F2));
        }

        [Fact]
        public void ConvertKeyCode_FunctionKeyF3_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 114, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F3));
        }

        [Fact]
        public void ConvertKeyCode_FunctionKeyF4_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 115, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F4));
        }

        [Fact]
        public void ConvertKeyCode_FunctionKeyF5_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 116, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F5));
        }

        [Fact]
        public void ConvertKeyCode_FunctionKeyF6_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 117, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F6));
        }

        [Fact]
        public void ConvertKeyCode_FunctionKeyF7_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 118, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F7));
        }

        [Fact]
        public void ConvertKeyCode_FunctionKeyF8_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 119, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F8));
        }

        [Fact]
        public void ConvertKeyCode_FunctionKeyF9_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 120, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F9));
        }

        [Fact]
        public void ConvertKeyCode_FunctionKeyF10_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 121, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F10));
        }

        [Fact]
        public void ConvertKeyCode_FunctionKeyF11_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 122, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F11));
        }

        [Fact]
        public void ConvertKeyCode_Numpad1_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 97, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NumPad1));
        }

        [Fact]
        public void ConvertKeyCode_Numpad2_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 98, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NumPad2));
        }

        [Fact]
        public void ConvertKeyCode_Numpad3_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 99, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NumPad3));
        }

        [Fact]
        public void ConvertKeyCode_Numpad4_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 100, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NumPad4));
        }

        [Fact]
        public void ConvertKeyCode_Numpad5_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 101, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NumPad5));
        }

        [Fact]
        public void ConvertKeyCode_Numpad6_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 102, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NumPad6));
        }

        [Fact]
        public void ConvertKeyCode_Numpad7_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 103, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NumPad7));
        }

        [Fact]
        public void ConvertKeyCode_Numpad8_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 104, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NumPad8));
        }

        [Fact]
        public void OnMouseDown_ValidButton_SetsButton()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseDown", 0, 10, 20, 100, 200);
            platform.GetMouseState(out int x, out int y, out bool[] buttons);
            Assert.True(buttons[0]);
            Assert.Equal(100, x);
            Assert.Equal(200, y);
        }

        [Fact]
        public void OnMouseDown_ValidButton4_SetsButton()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseDown", 4, 10, 20, 100, 200);
            platform.GetMouseState(out int x, out int y, out bool[] buttons);
            Assert.True(buttons[4]);
        }

        [Fact]
        public void OnMouseUp_ValidButton_ClearsButton()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseDown", 0, 0, 0, 0, 0);
            platform.GetMouseState(out _, out _, out bool[] before);
            Assert.True(before[0]);
            InvokePrivate(platform, "OnMouseUp", 0, 0, 0, 0, 0);
            platform.GetMouseState(out _, out _, out bool[] after);
            Assert.False(after[0]);
        }

        [Fact]
        public void OnMouseUp_ValidButton4_ClearsButton()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseDown", 4, 0, 0, 0, 0);
            InvokePrivate(platform, "OnMouseUp", 4, 0, 0, 0, 0);
            platform.GetMouseState(out _, out _, out bool[] buttons);
            Assert.False(buttons[4]);
        }

        [Fact]
        public void OnMouseDown_ValidButtons_AllSetCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            for (int i = 0; i < 5; i++)
            {
                InvokePrivate(platform, "OnMouseDown", i, 0, 0, 0, 0);
            }
            platform.GetMouseState(out _, out _, out bool[] buttons);
            for (int i = 0; i < 5; i++)
            {
                Assert.True(buttons[i]);
            }
        }

        [Fact]
        public void OnMouseUp_ValidButtons_AllClearedCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            for (int i = 0; i < 5; i++)
            {
                InvokePrivate(platform, "OnMouseDown", i, 0, 0, 0, 0);
            }
            for (int i = 0; i < 5; i++)
            {
                InvokePrivate(platform, "OnMouseUp", i, 0, 0, 0, 0);
            }
            platform.GetMouseState(out _, out _, out bool[] buttons);
            for (int i = 0; i < 5; i++)
            {
                Assert.False(buttons[i]);
            }
        }

        [Fact]
        public void GamepadState_LeftStickX_DefaultIsZero()
        {
            GamepadState state = new GamepadState();
            Assert.Equal(0.0f, state.LeftStickX);
        }

        [Fact]
        public void GamepadState_LeftStickX_CanSet()
        {
            GamepadState state = new GamepadState();
            state.LeftStickX = 0.5f;
            Assert.Equal(0.5f, state.LeftStickX);
        }

        [Fact]
        public void GamepadState_LeftStickY_DefaultIsZero()
        {
            GamepadState state = new GamepadState();
            Assert.Equal(0.0f, state.LeftStickY);
        }

        [Fact]
        public void GamepadState_LeftStickY_CanSet()
        {
            GamepadState state = new GamepadState();
            state.LeftStickY = 0.5f;
            Assert.Equal(0.5f, state.LeftStickY);
        }

        [Fact]
        public void GamepadState_RightStickX_DefaultIsZero()
        {
            GamepadState state = new GamepadState();
            Assert.Equal(0.0f, state.RightStickX);
        }

        [Fact]
        public void GamepadState_RightStickX_CanSet()
        {
            GamepadState state = new GamepadState();
            state.RightStickX = 0.5f;
            Assert.Equal(0.5f, state.RightStickX);
        }

        [Fact]
        public void GamepadState_RightStickY_DefaultIsZero()
        {
            GamepadState state = new GamepadState();
            Assert.Equal(0.0f, state.RightStickY);
        }

        [Fact]
        public void GamepadState_RightStickY_CanSet()
        {
            GamepadState state = new GamepadState();
            state.RightStickY = 0.5f;
            Assert.Equal(0.5f, state.RightStickY);
        }

        [Fact]
        public void GamepadState_LeftTrigger_DefaultIsZero()
        {
            GamepadState state = new GamepadState();
            Assert.Equal(0.0f, state.LeftTrigger);
        }

        [Fact]
        public void GamepadState_LeftTrigger_CanSet()
        {
            GamepadState state = new GamepadState();
            state.LeftTrigger = 0.5f;
            Assert.Equal(0.5f, state.LeftTrigger);
        }

        [Fact]
        public void GamepadState_RightTrigger_DefaultIsZero()
        {
            GamepadState state = new GamepadState();
            Assert.Equal(0.0f, state.RightTrigger);
        }

        [Fact]
        public void GamepadState_RightTrigger_CanSet()
        {
            GamepadState state = new GamepadState();
            state.RightTrigger = 0.5f;
            Assert.Equal(0.5f, state.RightTrigger);
        }

        [Fact]
        public void OnGamepadConnect_NewIndex_CreatesState()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 5);
            Assert.True(platform.TryGetGamepadState(5, out GamepadState state));
            Assert.True(state.Connected);
        }

        [Fact]
        public void OnGamepadDisconnect_ExistingIndex_SetsDisconnected()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadDisconnect", 0);
            Assert.True(platform.TryGetGamepadState(0, out GamepadState state));
            Assert.False(state.Connected);
        }

        [Fact]
        public void Initialize_ShortOverload_ReturnsFalse_WhenEglFails()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            bool result = platform.Initialize(800, 600, "Test");
            Assert.False(result);
        }

        private static void InvokePrivate(object instance, string methodName, params object[] arguments)
        {
            MethodInfo method = instance.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);
            method.Invoke(instance, arguments);
        }
    }
}
