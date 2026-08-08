// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiInputTextCallbackDataRemainingCoverageTests.cs
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
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui input text callback data remaining coverage tests class
    /// </summary>
    public class ImGuiInputTextCallbackDataRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that default values are zero
        /// </summary>
        [Fact]
        public void Default_ValuesAreZero()
        {
            ImGuiInputTextCallbackData data = default;
            Assert.Equal(ImGuiInputTextFlags.None, data.EventFlag);
            Assert.Equal(ImGuiInputTextFlags.None, data.Flags);
            Assert.Equal(IntPtr.Zero, data.UserData);
            Assert.Equal((ushort)0, data.EventChar);
            Assert.Equal(ImGuiKey.None, data.EventKey);
            Assert.Equal(IntPtr.Zero, data.Buf);
            Assert.Equal(0, data.BufTextLen);
            Assert.Equal(0, data.BufSize);
            Assert.Equal((byte)0, data.BufDirty);
            Assert.Equal(0, data.CursorPos);
            Assert.Equal(0, data.SelectionStart);
            Assert.Equal(0, data.SelectionEnd);
        }

        /// <summary>
        ///     Tests that input text flags round trip
        /// </summary>
        [Fact]
        public void InputTextFlags_RoundTrip()
        {
            ImGuiInputTextCallbackData data = default;
            data.EventFlag = ImGuiInputTextFlags.CharsDecimal;
            data.Flags = ImGuiInputTextFlags.CharsHexadecimal;
            Assert.Equal(ImGuiInputTextFlags.CharsDecimal, data.EventFlag);
            Assert.Equal(ImGuiInputTextFlags.CharsHexadecimal, data.Flags);
        }

        /// <summary>
        ///     Tests that key round trip
        /// </summary>
        [Fact]
        public void Key_RoundTrip()
        {
            ImGuiInputTextCallbackData data = default;
            data.EventKey = ImGuiKey.Tab;
            Assert.Equal(ImGuiKey.Tab, data.EventKey);
        }

        /// <summary>
        ///     Tests that int ptr fields round trip
        /// </summary>
        [Fact]
        public void IntPtrFields_RoundTrip()
        {
            ImGuiInputTextCallbackData data = default;
            data.UserData = new IntPtr(123);
            data.Buf = new IntPtr(456);
            Assert.Equal(new IntPtr(123), data.UserData);
            Assert.Equal(new IntPtr(456), data.Buf);
        }

        /// <summary>
        ///     Tests that int fields and event char round trip
        /// </summary>
        [Fact]
        public void IntFieldsAndEventChar_RoundTrip()
        {
            ImGuiInputTextCallbackData data = default;
            data.BufTextLen = 10;
            data.BufSize = 20;
            data.CursorPos = 30;
            data.SelectionStart = 40;
            data.SelectionEnd = 50;
            data.EventChar = (ushort)'A';
            Assert.Equal(10, data.BufTextLen);
            Assert.Equal(20, data.BufSize);
            Assert.Equal(30, data.CursorPos);
            Assert.Equal(40, data.SelectionStart);
            Assert.Equal(50, data.SelectionEnd);
            Assert.Equal((ushort)'A', data.EventChar);
        }

        /// <summary>
        ///     Tests that buf dirty round trip
        /// </summary>
        [Fact]
        public void BufDirty_RoundTrip()
        {
            ImGuiInputTextCallbackData data = default;
            data.BufDirty = 1;
            Assert.Equal((byte)1, data.BufDirty);
        }
    }
}
