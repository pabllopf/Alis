// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiInputTextCallbackDataTest.cs
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
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    ///     The im gui input text callback data test class
    /// </summary>
    	  
	 public class ImGuiInputTextCallbackDataTest 
    {
        /// <summary>
        ///     Tests that event flag should be initialized
        /// </summary>
        [Fact]
        public void EventFlag_ShouldBeInitialized()
        {
            ImGuiInputTextCallbackData data = new ImGuiInputTextCallbackData();
            Assert.Equal(default(ImGuiInputTextFlags), data.EventFlag);
        }

        /// <summary>
        ///     Tests that flags should be initialized
        /// </summary>
        [Fact]
        public void Flags_ShouldBeInitialized()
        {
            ImGuiInputTextCallbackData data = new ImGuiInputTextCallbackData();
            Assert.Equal(default(ImGuiInputTextFlags), data.Flags);
        }

        /// <summary>
        ///     Tests that user data should be initialized
        /// </summary>
        [Fact]
        public void UserData_ShouldBeInitialized()
        {
            ImGuiInputTextCallbackData data = new ImGuiInputTextCallbackData();
            Assert.Equal(IntPtr.Zero, data.UserData);
        }

        /// <summary>
        ///     Tests that event char should be initialized
        /// </summary>
        [Fact]
        public void EventChar_ShouldBeInitialized()
        {
            ImGuiInputTextCallbackData data = new ImGuiInputTextCallbackData();
            Assert.Equal((ushort) 0, data.EventChar);
        }

        /// <summary>
        ///     Tests that event key should be initialized
        /// </summary>
        [Fact]
        public void EventKey_ShouldBeInitialized()
        {
            ImGuiInputTextCallbackData data = new ImGuiInputTextCallbackData();
            Assert.Equal(default(ImGuiKey), data.EventKey);
        }

        /// <summary>
        ///     Tests that buf should be initialized
        /// </summary>
        [Fact]
        public void Buf_ShouldBeInitialized()
        {
            ImGuiInputTextCallbackData data = new ImGuiInputTextCallbackData();
            Assert.Equal(IntPtr.Zero, data.Buf);
        }

        /// <summary>
        ///     Tests that buf text len should be initialized
        /// </summary>
        [Fact]
        public void BufTextLen_ShouldBeInitialized()
        {
            ImGuiInputTextCallbackData data = new ImGuiInputTextCallbackData();
            Assert.Equal(0, data.BufTextLen);
        }

        /// <summary>
        ///     Tests that buf size should be initialized
        /// </summary>
        [Fact]
        public void BufSize_ShouldBeInitialized()
        {
            ImGuiInputTextCallbackData data = new ImGuiInputTextCallbackData();
            Assert.Equal(0, data.BufSize);
        }

        /// <summary>
        ///     Tests that buf dirty should be initialized
        /// </summary>
        [Fact]
        public void BufDirty_ShouldBeInitialized()
        {
            ImGuiInputTextCallbackData data = new ImGuiInputTextCallbackData();
            Assert.Equal((byte) 0, data.BufDirty);
        }

        /// <summary>
        ///     Tests that cursor pos should be initialized
        /// </summary>
        [Fact]
        public void CursorPos_ShouldBeInitialized()
        {
            ImGuiInputTextCallbackData data = new ImGuiInputTextCallbackData();
            Assert.Equal(0, data.CursorPos);
        }

        /// <summary>
        ///     Tests that selection start should be initialized
        /// </summary>
        [Fact]
        public void SelectionStart_ShouldBeInitialized()
        {
            ImGuiInputTextCallbackData data = new ImGuiInputTextCallbackData();
            Assert.Equal(0, data.SelectionStart);
        }

        /// <summary>
        ///     Tests that selection end should be initialized
        /// </summary>
        [Fact]
        public void SelectionEnd_ShouldBeInitialized()
        {
            ImGuiInputTextCallbackData data = new ImGuiInputTextCallbackData();
            Assert.Equal(0, data.SelectionEnd);
        }

        /// <summary>
        ///     Tests that event flag set and get returns correct value
        /// </summary>
        [Fact]
        public void EventFlag_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiInputTextCallbackData obj = new ImGuiInputTextCallbackData();
            ImGuiInputTextFlags value = new ImGuiInputTextFlags();
            obj.EventFlag = value;
            Assert.Equal(value, obj.EventFlag);
        }

        /// <summary>
        ///     Tests that flags set and get returns correct value
        /// </summary>
        [Fact]
        public void Flags_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiInputTextCallbackData obj = new ImGuiInputTextCallbackData();
            ImGuiInputTextFlags value = new ImGuiInputTextFlags();
            obj.Flags = value;
            Assert.Equal(value, obj.Flags);
        }

        /// <summary>
        ///     Tests that user data set and get returns correct value
        /// </summary>
        [Fact]
        public void UserData_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiInputTextCallbackData obj = new ImGuiInputTextCallbackData();
            IntPtr value = new IntPtr(123);
            obj.UserData = value;
            Assert.Equal(value, obj.UserData);
        }

        /// <summary>
        ///     Tests that event char set and get returns correct value
        /// </summary>
        [Fact]
        public void EventChar_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiInputTextCallbackData obj = new ImGuiInputTextCallbackData();
            ushort value = 123;
            obj.EventChar = value;
            Assert.Equal(value, obj.EventChar);
        }

        /// <summary>
        ///     Tests that event key set and get returns correct value
        /// </summary>
        [Fact]
        public void EventKey_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiInputTextCallbackData obj = new ImGuiInputTextCallbackData();
            ImGuiKey value = new ImGuiKey();
            obj.EventKey = value;
            Assert.Equal(value, obj.EventKey);
        }

        /// <summary>
        ///     Tests that buf set and get returns correct value
        /// </summary>
        [Fact]
        public void Buf_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiInputTextCallbackData obj = new ImGuiInputTextCallbackData();
            IntPtr value = new IntPtr(123);
            obj.Buf = value;
            Assert.Equal(value, obj.Buf);
        }

        /// <summary>
        ///     Tests that buf text len set and get returns correct value
        /// </summary>
        [Fact]
        public void BufTextLen_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiInputTextCallbackData obj = new ImGuiInputTextCallbackData();
            int value = 123;
            obj.BufTextLen = value;
            Assert.Equal(value, obj.BufTextLen);
        }

        /// <summary>
        ///     Tests that buf size set and get returns correct value
        /// </summary>
        [Fact]
        public void BufSize_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiInputTextCallbackData obj = new ImGuiInputTextCallbackData();
            int value = 123;
            obj.BufSize = value;
            Assert.Equal(value, obj.BufSize);
        }

        /// <summary>
        ///     Tests that buf dirty set and get returns correct value
        /// </summary>
        [Fact]
        public void BufDirty_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiInputTextCallbackData obj = new ImGuiInputTextCallbackData();
            byte value = 1;
            obj.BufDirty = value;
            Assert.Equal(value, obj.BufDirty);
        }

        /// <summary>
        ///     Tests that cursor pos set and get returns correct value
        /// </summary>
        [Fact]
        public void CursorPos_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiInputTextCallbackData obj = new ImGuiInputTextCallbackData();
            int value = 123;
            obj.CursorPos = value;
            Assert.Equal(value, obj.CursorPos);
        }

        /// <summary>
        ///     Tests that selection start set and get returns correct value
        /// </summary>
        [Fact]
        public void SelectionStart_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiInputTextCallbackData obj = new ImGuiInputTextCallbackData();
            int value = 123;
            obj.SelectionStart = value;
            Assert.Equal(value, obj.SelectionStart);
        }

        /// <summary>
        ///     Tests that selection end set and get returns correct value
        /// </summary>
        [Fact]
        public void SelectionEnd_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiInputTextCallbackData obj = new ImGuiInputTextCallbackData();
            int value = 123;
            obj.SelectionEnd = value;
            Assert.Equal(value, obj.SelectionEnd);
        }
    }
}