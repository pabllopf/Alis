// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GamePadStateTests.cs
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
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Structs
{
    /// <summary>
    /// The game pad state tests class
    /// </summary>
    public class GamePadStateTests
    {
        /// <summary>
        /// Tests that game pad state struct size is correct
        /// </summary>
        [Fact]
        public void GamePadState_StructSize_IsCorrect()
        {
            int size = Marshal.SizeOf<GamePadState>();

            Assert.Equal(39, size);
        }

        /// <summary>
        /// Tests that game pad state get button state returns press when button is pressed
        /// </summary>
        [Fact]
        public void GamePadState_GetButtonState_ReturnsPress_WhenButtonIsPressed()
        {
            GamePadState state = default;
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<GamePadState>());

            try
            {
                nint basePtr = ptr;

                for (int i = 0; i < 15; i++)
                {
                    Marshal.WriteByte(ptr, i, (byte)(i == (int)GamePadButton.A ? (byte)InputState.Press : (byte)InputState.Release));
                }

                state = Marshal.PtrToStructure<GamePadState>(ptr);

                InputState result = state.GetButtonState(GamePadButton.A);

                Assert.Equal(InputState.Press, result);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Tests that game pad state get button state returns release when button is not pressed
        /// </summary>
        [Fact]
        public void GamePadState_GetButtonState_ReturnsRelease_WhenButtonIsNotPressed()
        {
            GamePadState state = default;
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<GamePadState>());

            try
            {
                for (int i = 0; i < 15; i++)
                {
                    Marshal.WriteByte(ptr, i, (byte)InputState.Release);
                }

                state = Marshal.PtrToStructure<GamePadState>(ptr);

                InputState result = state.GetButtonState(GamePadButton.A);

                Assert.Equal(InputState.Release, result);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Tests that game pad state get button state returns repeat when button is repeated
        /// </summary>
        [Fact]
        public void GamePadState_GetButtonState_ReturnsRepeat_WhenButtonIsRepeated()
        {
            GamePadState state = default;
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<GamePadState>());

            try
            {
                for (int i = 0; i < 15; i++)
                {
                    Marshal.WriteByte(ptr, i, (byte)(i == (int)GamePadButton.B ? (byte)InputState.Repeat : (byte)InputState.Release));
                }

                state = Marshal.PtrToStructure<GamePadState>(ptr);

                InputState result = state.GetButtonState(GamePadButton.B);

                Assert.Equal(InputState.Repeat, result);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Tests that game pad state get button state returns correct state for dpad up
        /// </summary>
        [Fact]
        public void GamePadState_GetButtonState_ReturnsCorrectState_ForDpadUp()
        {
            GamePadState state = default;
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<GamePadState>());

            try
            {
                for (int i = 0; i < 15; i++)
                {
                    Marshal.WriteByte(ptr, i, (byte)(i == (int)GamePadButton.DpadUp ? (byte)InputState.Press : (byte)InputState.Release));
                }

                state = Marshal.PtrToStructure<GamePadState>(ptr);

                InputState result = state.GetButtonState(GamePadButton.DpadUp);

                Assert.Equal(InputState.Press, result);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Tests that game pad state get axis returns correct value for left x
        /// </summary>
        [Fact]
        public void GamePadState_GetAxis_ReturnsCorrectValue_ForLeftX()
        {
            GamePadState state = default;
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<GamePadState>());

            try
            {
                IntPtr axesStart = ptr + 15;

                Marshal.WriteByte(ptr, (int)GamePadButton.DpadLeft, (byte)InputState.Release);

                Marshal.Copy(new float[] { 0.5f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f }, 0, axesStart, 6);

                state = Marshal.PtrToStructure<GamePadState>(ptr);

                float result = state.GetAxis(GamePadAxis.LeftX);

                Assert.Equal(0.5f, result, 5);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Tests that game pad state get axis returns correct value for left y
        /// </summary>
        [Fact]
        public void GamePadState_GetAxis_ReturnsCorrectValue_ForLeftY()
        {
            GamePadState state = default;
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<GamePadState>());

            try
            {
                IntPtr axesStart = ptr + 15;

                Marshal.Copy(new float[] { 0.0f, -0.75f, 0.0f, 0.0f, 0.0f, 0.0f }, 0, axesStart, 6);

                state = Marshal.PtrToStructure<GamePadState>(ptr);

                float result = state.GetAxis(GamePadAxis.LeftY);

                Assert.Equal(-0.75f, result, 5);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Tests that game pad state get axis returns correct value for right x
        /// </summary>
        [Fact]
        public void GamePadState_GetAxis_ReturnsCorrectValue_ForRightX()
        {
            GamePadState state = default;
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<GamePadState>());

            try
            {
                IntPtr axesStart = ptr + 15;

                Marshal.Copy(new float[] { 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 0.0f }, 0, axesStart, 6);

                state = Marshal.PtrToStructure<GamePadState>(ptr);

                float result = state.GetAxis(GamePadAxis.RightX);

                Assert.Equal(1.0f, result, 5);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Tests that game pad state get axis returns correct value for right y
        /// </summary>
        [Fact]
        public void GamePadState_GetAxis_ReturnsCorrectValue_ForRightY()
        {
            GamePadState state = default;
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<GamePadState>());

            try
            {
                IntPtr axesStart = ptr + 15;

                Marshal.Copy(new float[] { 0.0f, 0.0f, 0.0f, 0.33f, 0.0f, 0.0f }, 0, axesStart, 6);

                state = Marshal.PtrToStructure<GamePadState>(ptr);

                float result = state.GetAxis(GamePadAxis.RightY);

                Assert.Equal(0.33f, result, 5);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Tests that game pad state get axis returns correct value for left trigger
        /// </summary>
        [Fact]
        public void GamePadState_GetAxis_ReturnsCorrectValue_ForLeftTrigger()
        {
            GamePadState state = default;
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<GamePadState>());

            try
            {
                IntPtr axesStart = ptr + 15;

                Marshal.Copy(new float[] { 0.0f, 0.0f, 0.0f, 0.0f, -1.0f, 0.0f }, 0, axesStart, 6);

                state = Marshal.PtrToStructure<GamePadState>(ptr);

                float result = state.GetAxis(GamePadAxis.LeftTrigger);

                Assert.Equal(-1.0f, result, 5);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Tests that game pad state get axis returns correct value for right trigger
        /// </summary>
        [Fact]
        public void GamePadState_GetAxis_ReturnsCorrectValue_ForRightTrigger()
        {
            GamePadState state = default;
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<GamePadState>());

            try
            {
                IntPtr axesStart = ptr + 15;

                Marshal.Copy(new float[] { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, -0.5f }, 0, axesStart, 6);

                state = Marshal.PtrToStructure<GamePadState>(ptr);

                float result = state.GetAxis(GamePadAxis.RightTrigger);

                Assert.Equal(-0.5f, result, 5);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Tests that game pad state can be allocated in unmanaged memory and all fields round trip
        /// </summary>
        [Fact]
        public void GamePadState_CanBeAllocatedInUnmanagedMemory_AndAllFieldsRoundTrip()
        {
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<GamePadState>());

            try
            {
                IntPtr axesStart = ptr + 15;

                Marshal.WriteByte(ptr, (int)GamePadButton.A, (byte)InputState.Press);
                Marshal.WriteByte(ptr, (int)GamePadButton.B, (byte)InputState.Release);
                Marshal.WriteByte(ptr, (int)GamePadButton.X, (byte)InputState.Press);
                Marshal.WriteByte(ptr, (int)GamePadButton.Y, (byte)InputState.Release);

                Marshal.Copy(new float[] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f }, 0, axesStart, 6);

                GamePadState state = Marshal.PtrToStructure<GamePadState>(ptr);

                Assert.Equal(InputState.Press, state.GetButtonState(GamePadButton.A));
                Assert.Equal(InputState.Release, state.GetButtonState(GamePadButton.B));
                Assert.Equal(InputState.Press, state.GetButtonState(GamePadButton.X));
                Assert.Equal(InputState.Release, state.GetButtonState(GamePadButton.Y));

                Assert.Equal(0.1f, state.GetAxis(GamePadAxis.LeftX));
                Assert.Equal(0.2f, state.GetAxis(GamePadAxis.LeftY));
                Assert.Equal(0.3f, state.GetAxis(GamePadAxis.RightX));
                Assert.Equal(0.4f, state.GetAxis(GamePadAxis.RightY));
                Assert.Equal(0.5f, state.GetAxis(GamePadAxis.LeftTrigger));
                Assert.Equal(0.6f, state.GetAxis(GamePadAxis.RightTrigger));
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
    }
}
