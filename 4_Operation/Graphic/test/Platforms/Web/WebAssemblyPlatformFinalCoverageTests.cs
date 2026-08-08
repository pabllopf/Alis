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
using Alis.Core.Graphic.Test.Attributes;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    /// The web assembly platform final coverage tests class
    /// </summary>
    public class WebAssemblyPlatformFinalCoverageTests
    {
        /// <summary>
        /// Tests that convert key code alphabet b maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetB_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 66, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.B));
        }

        /// <summary>
        /// Tests that convert key code alphabet c maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetC_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 67, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.C));
        }

        /// <summary>
        /// Tests that convert key code alphabet d maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetD_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 68, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.D));
        }

        /// <summary>
        /// Tests that convert key code alphabet e maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetE_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 69, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.E));
        }

        /// <summary>
        /// Tests that convert key code alphabet f maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetF_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 70, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F));
        }

        /// <summary>
        /// Tests that convert key code alphabet g maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetG_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 71, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.G));
        }

        /// <summary>
        /// Tests that convert key code alphabet h maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetH_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 72, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.H));
        }

        /// <summary>
        /// Tests that convert key code alphabet i maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetI_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 73, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.I));
        }

        /// <summary>
        /// Tests that convert key code alphabet j maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetJ_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 74, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.J));
        }

        /// <summary>
        /// Tests that convert key code alphabet k maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetK_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 75, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.K));
        }

        /// <summary>
        /// Tests that convert key code alphabet l maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetL_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 76, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.L));
        }

        /// <summary>
        /// Tests that convert key code alphabet m maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetM_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 77, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.M));
        }

        /// <summary>
        /// Tests that convert key code alphabet n maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetN_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 78, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.N));
        }

        /// <summary>
        /// Tests that convert key code alphabet o maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetO_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 79, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.O));
        }

        /// <summary>
        /// Tests that convert key code alphabet p maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetP_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 80, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.P));
        }

        /// <summary>
        /// Tests that convert key code alphabet q maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetQ_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 81, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Q));
        }

        /// <summary>
        /// Tests that convert key code alphabet r maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetR_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 82, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.R));
        }

        /// <summary>
        /// Tests that convert key code alphabet s maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetS_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 83, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.S));
        }

        /// <summary>
        /// Tests that convert key code alphabet t maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetT_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 84, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.T));
        }

        /// <summary>
        /// Tests that convert key code alphabet u maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetU_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 85, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.U));
        }

        /// <summary>
        /// Tests that convert key code alphabet v maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetV_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 86, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.V));
        }

        /// <summary>
        /// Tests that convert key code alphabet w maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetW_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 87, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.W));
        }

        /// <summary>
        /// Tests that convert key code alphabet x maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetX_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 88, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.X));
        }

        /// <summary>
        /// Tests that convert key code alphabet y maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_AlphabetY_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 89, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.Y));
        }

        /// <summary>
        /// Tests that convert key code number 1 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_Number1_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 49, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.D1));
        }

        /// <summary>
        /// Tests that convert key code number 2 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_Number2_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 50, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.D2));
        }

        /// <summary>
        /// Tests that convert key code number 3 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_Number3_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 51, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.D3));
        }

        /// <summary>
        /// Tests that convert key code number 4 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_Number4_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 52, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.D4));
        }

        /// <summary>
        /// Tests that convert key code number 5 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_Number5_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 53, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.D5));
        }

        /// <summary>
        /// Tests that convert key code number 6 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_Number6_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 54, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.D6));
        }

        /// <summary>
        /// Tests that convert key code number 7 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_Number7_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 55, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.D7));
        }

        /// <summary>
        /// Tests that convert key code number 8 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_Number8_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 56, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.D8));
        }

        /// <summary>
        /// Tests that convert key code function key f 2 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_FunctionKeyF2_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 113, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F2));
        }

        /// <summary>
        /// Tests that convert key code function key f 3 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_FunctionKeyF3_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 114, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F3));
        }

        /// <summary>
        /// Tests that convert key code function key f 4 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_FunctionKeyF4_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 115, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F4));
        }

        /// <summary>
        /// Tests that convert key code function key f 5 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_FunctionKeyF5_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 116, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F5));
        }

        /// <summary>
        /// Tests that convert key code function key f 6 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_FunctionKeyF6_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 117, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F6));
        }

        /// <summary>
        /// Tests that convert key code function key f 7 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_FunctionKeyF7_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 118, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F7));
        }

        /// <summary>
        /// Tests that convert key code function key f 8 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_FunctionKeyF8_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 119, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F8));
        }

        /// <summary>
        /// Tests that convert key code function key f 9 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_FunctionKeyF9_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 120, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F9));
        }

        /// <summary>
        /// Tests that convert key code function key f 10 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_FunctionKeyF10_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 121, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F10));
        }

        /// <summary>
        /// Tests that convert key code function key f 11 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_FunctionKeyF11_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 122, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.F11));
        }

        /// <summary>
        /// Tests that convert key code numpad 1 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_Numpad1_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 97, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NumPad1));
        }

        /// <summary>
        /// Tests that convert key code numpad 2 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_Numpad2_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 98, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NumPad2));
        }

        /// <summary>
        /// Tests that convert key code numpad 3 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_Numpad3_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 99, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NumPad3));
        }

        /// <summary>
        /// Tests that convert key code numpad 4 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_Numpad4_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 100, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NumPad4));
        }

        /// <summary>
        /// Tests that convert key code numpad 5 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_Numpad5_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 101, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NumPad5));
        }

        /// <summary>
        /// Tests that convert key code numpad 6 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_Numpad6_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 102, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NumPad6));
        }

        /// <summary>
        /// Tests that convert key code numpad 7 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_Numpad7_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 103, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NumPad7));
        }

        /// <summary>
        /// Tests that convert key code numpad 8 maps correctly
        /// </summary>
        [WebOnly]
        public void ConvertKeyCode_Numpad8_MapsCorrectly()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 104, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NumPad8));
        }

        /// <summary>
        /// Tests that on mouse down valid button sets button
        /// </summary>
        [WebOnly]
        public void OnMouseDown_ValidButton_SetsButton()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseDown", 0, 10, 20, 100, 200);
            platform.GetMouseState(out int x, out int y, out bool[] buttons);
            Assert.True(buttons[0]);
            Assert.Equal(100, x);
            Assert.Equal(200, y);
        }

        /// <summary>
        /// Tests that on mouse down valid button 4 sets button
        /// </summary>
        [WebOnly]
        public void OnMouseDown_ValidButton4_SetsButton()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseDown", 4, 10, 20, 100, 200);
            platform.GetMouseState(out int x, out int y, out bool[] buttons);
            Assert.True(buttons[4]);
        }

        /// <summary>
        /// Tests that on mouse up valid button clears button
        /// </summary>
        [WebOnly]
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

        /// <summary>
        /// Tests that on mouse up valid button 4 clears button
        /// </summary>
        [WebOnly]
        public void OnMouseUp_ValidButton4_ClearsButton()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseDown", 4, 0, 0, 0, 0);
            InvokePrivate(platform, "OnMouseUp", 4, 0, 0, 0, 0);
            platform.GetMouseState(out _, out _, out bool[] buttons);
            Assert.False(buttons[4]);
        }

        /// <summary>
        /// Tests that on mouse down valid buttons all set correctly
        /// </summary>
        [WebOnly]
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

        /// <summary>
        /// Tests that on mouse up valid buttons all cleared correctly
        /// </summary>
        [WebOnly]
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

        /// <summary>
        /// Tests that gamepad state left stick x default is zero
        /// </summary>
        [WebOnly]
        public void GamepadState_LeftStickX_DefaultIsZero()
        {
            GamepadState state = new GamepadState();
            Assert.Equal(0.0f, state.LeftStickX, 5);
        }

        /// <summary>
        /// Tests that gamepad state left stick x can set
        /// </summary>
        [WebOnly]
        public void GamepadState_LeftStickX_CanSet()
        {
            GamepadState state = new GamepadState();
            state.LeftStickX = 0.5f;
            Assert.Equal(0.5f, state.LeftStickX, 5);
        }

        /// <summary>
        /// Tests that gamepad state left stick y default is zero
        /// </summary>
        [WebOnly]
        public void GamepadState_LeftStickY_DefaultIsZero()
        {
            GamepadState state = new GamepadState();
            Assert.Equal(0.0f, state.LeftStickY, 5);
        }

        /// <summary>
        /// Tests that gamepad state left stick y can set
        /// </summary>
        [WebOnly]
        public void GamepadState_LeftStickY_CanSet()
        {
            GamepadState state = new GamepadState();
            state.LeftStickY = 0.5f;
            Assert.Equal(0.5f, state.LeftStickY, 5);
        }

        /// <summary>
        /// Tests that gamepad state right stick x default is zero
        /// </summary>
        [WebOnly]
        public void GamepadState_RightStickX_DefaultIsZero()
        {
            GamepadState state = new GamepadState();
            Assert.Equal(0.0f, state.RightStickX, 5);
        }

        /// <summary>
        /// Tests that gamepad state right stick x can set
        /// </summary>
        [WebOnly]
        public void GamepadState_RightStickX_CanSet()
        {
            GamepadState state = new GamepadState();
            state.RightStickX = 0.5f;
            Assert.Equal(0.5f, state.RightStickX, 5);
        }

        /// <summary>
        /// Tests that gamepad state right stick y default is zero
        /// </summary>
        [WebOnly]
        public void GamepadState_RightStickY_DefaultIsZero()
        {
            GamepadState state = new GamepadState();
            Assert.Equal(0.0f, state.RightStickY, 5);
        }

        /// <summary>
        /// Tests that gamepad state right stick y can set
        /// </summary>
        [WebOnly]
        public void GamepadState_RightStickY_CanSet()
        {
            GamepadState state = new GamepadState();
            state.RightStickY = 0.5f;
            Assert.Equal(0.5f, state.RightStickY, 5);
        }

        /// <summary>
        /// Tests that gamepad state left trigger default is zero
        /// </summary>
        [WebOnly]
        public void GamepadState_LeftTrigger_DefaultIsZero()
        {
            GamepadState state = new GamepadState();
            Assert.Equal(0.0f, state.LeftTrigger, 5);
        }

        /// <summary>
        /// Tests that gamepad state left trigger can set
        /// </summary>
        [WebOnly]
        public void GamepadState_LeftTrigger_CanSet()
        {
            GamepadState state = new GamepadState();
            state.LeftTrigger = 0.5f;
            Assert.Equal(0.5f, state.LeftTrigger, 5);
        }

        /// <summary>
        /// Tests that gamepad state right trigger default is zero
        /// </summary>
        [WebOnly]
        public void GamepadState_RightTrigger_DefaultIsZero()
        {
            GamepadState state = new GamepadState();
            Assert.Equal(0.0f, state.RightTrigger, 5);
        }

        /// <summary>
        /// Tests that gamepad state right trigger can set
        /// </summary>
        [WebOnly]
        public void GamepadState_RightTrigger_CanSet()
        {
            GamepadState state = new GamepadState();
            state.RightTrigger = 0.5f;
            Assert.Equal(0.5f, state.RightTrigger, 5);
        }

        /// <summary>
        /// Tests that on gamepad connect new index creates state
        /// </summary>
        [WebOnly]
        public void OnGamepadConnect_NewIndex_CreatesState()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 5);
            Assert.True(platform.TryGetGamepadState(5, out GamepadState state));
            Assert.True(state.Connected);
        }

        /// <summary>
        /// Tests that on gamepad disconnect existing index sets disconnected
        /// </summary>
        [WebOnly]
        public void OnGamepadDisconnect_ExistingIndex_SetsDisconnected()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadDisconnect", 0);
            Assert.True(platform.TryGetGamepadState(0, out GamepadState state));
            Assert.False(state.Connected);
        }

        /// <summary>
        /// Tests that initialize short overload returns false when egl fails
        /// </summary>
        [WebOnly]
        public void Initialize_ShortOverload_ReturnsFalse_WhenEglFails()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            bool result = platform.Initialize(800, 600, "Test");
            Assert.False(result);
        }

        /// <summary>
        /// Invokes the private using the specified instance
        /// </summary>
        /// <param name="instance">The instance</param>
        /// <param name="methodName">The method name</param>
        /// <param name="arguments">The arguments</param>
        private static void InvokePrivate(object instance, string methodName, params object[] arguments)
        {
            MethodInfo method = instance.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);
            method.Invoke(instance, arguments);
        }
    }
}
