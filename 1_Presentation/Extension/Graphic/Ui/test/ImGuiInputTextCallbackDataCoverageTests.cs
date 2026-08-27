// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiInputTextCallbackDataCoverageTests.cs
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
using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Tests for the <see cref="ImGuiInputTextCallbackData" /> struct.
    /// </summary>
    public class ImGuiInputTextCallbackDataCoverageTests
    {
        /// <summary>
        ///     Verifies that default values are zero.
        /// </summary>
        [Fact]
        public void Default_ValuesAreZero()
        {
            ImGuiInputTextCallbackData data = default;

            Assert.Equal(default(ImGuiInputTextFlags), data.EventFlag);
            Assert.Equal(default(ImGuiInputTextFlags), data.Flags);
            Assert.Equal(IntPtr.Zero, data.UserData);
            Assert.Equal(0, data.EventChar);
            Assert.Equal(default(ImGuiKey), data.EventKey);
            Assert.Equal(IntPtr.Zero, data.Buf);
            Assert.Equal(0, data.BufTextLen);
            Assert.Equal(0, data.BufSize);
            Assert.Equal(0, data.BufDirty);
            Assert.Equal(0, data.CursorPos);
            Assert.Equal(0, data.SelectionStart);
            Assert.Equal(0, data.SelectionEnd);
        }

        /// <summary>
        ///     Verifies that all properties round-trip.
        /// </summary>
        [Fact]
        public void AllProperties_RoundTrip()
        {
            ImGuiInputTextCallbackData data = new ImGuiInputTextCallbackData();

            data.EventFlag = (ImGuiInputTextFlags)3;
            data.Flags = (ImGuiInputTextFlags)7;
            data.UserData = new IntPtr(100);
            data.EventChar = 65;
            data.EventKey = (ImGuiKey)9;
            data.Buf = new IntPtr(200);
            data.BufTextLen = 12;
            data.BufSize = 64;
            data.BufDirty = 1;
            data.CursorPos = 5;
            data.SelectionStart = 2;
            data.SelectionEnd = 8;

            Assert.Equal((ImGuiInputTextFlags)3, data.EventFlag);
            Assert.Equal((ImGuiInputTextFlags)7, data.Flags);
            Assert.Equal(new IntPtr(100), data.UserData);
            Assert.Equal(65, data.EventChar);
            Assert.Equal((ImGuiKey)9, data.EventKey);
            Assert.Equal(new IntPtr(200), data.Buf);
            Assert.Equal(12, data.BufTextLen);
            Assert.Equal(64, data.BufSize);
            Assert.Equal(1, data.BufDirty);
            Assert.Equal(5, data.CursorPos);
            Assert.Equal(2, data.SelectionStart);
            Assert.Equal(8, data.SelectionEnd);
        }
    }
}
