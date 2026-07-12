// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyCodesTest.cs
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

using Alis.Extension.Graphic.Sdl2.Mapping;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The key codes test class
    /// </summary>
    public class KeyCodesTest
    {
        /// <summary>
        /// Tests that unknown is zero
        /// </summary>
        [Fact]
        public void Unknown_IsZero()
        {
            Assert.Equal(0, (int)KeyCodes.Unknown);
        }

        /// <summary>
        /// Tests that return is correct
        /// </summary>
        [Fact]
        public void Return_IsCorrect()
        {
            Assert.Equal(13, (int)KeyCodes.Return);
        }

        /// <summary>
        /// Tests that escape is correct
        /// </summary>
        [Fact]
        public void Escape_IsCorrect()
        {
            Assert.Equal(27, (int)KeyCodes.Escape);
        }

        /// <summary>
        /// Tests that backspace is correct
        /// </summary>
        [Fact]
        public void Backspace_IsCorrect()
        {
            Assert.Equal(8, (int)KeyCodes.Backspace);
        }

        /// <summary>
        /// Tests that tab is correct
        /// </summary>
        [Fact]
        public void Tab_IsCorrect()
        {
            Assert.Equal(9, (int)KeyCodes.Tab);
        }

        /// <summary>
        /// Tests that space is correct
        /// </summary>
        [Fact]
        public void Space_IsCorrect()
        {
            Assert.Equal(32, (int)KeyCodes.Space);
        }

        /// <summary>
        /// Tests that delete is correct
        /// </summary>
        [Fact]
        public void Delete_IsCorrect()
        {
            Assert.Equal(127, (int)KeyCodes.Delete);
        }

        /// <summary>
        /// Tests that letter keys are correct
        /// </summary>
        [Fact]
        public void LetterKeys_AreCorrect()
        {
            Assert.Equal('a', (int)KeyCodes.A);
            Assert.Equal('b', (int)KeyCodes.B);
            Assert.Equal('z', (int)KeyCodes.Z);
        }

        /// <summary>
        /// Tests that number keys are correct
        /// </summary>
        [Fact]
        public void NumberKeys_AreCorrect()
        {
            Assert.Equal('0', (int)KeyCodes.Num0);
            Assert.Equal('1', (int)KeyCodes.Num1);
            Assert.Equal('9', (int)KeyCodes.Num9);
        }

        /// <summary>
        /// Tests that function keys have scancode mask
        /// </summary>
        [Fact]
        public void FunctionKeys_HaveScancodeMask()
        {
            int mask = SdlInputConst.KScancodeMask;
            Assert.True(((int)KeyCodes.F1 & mask) != 0);
            Assert.True(((int)KeyCodes.F12 & mask) != 0);
            Assert.True(((int)KeyCodes.F24 & mask) != 0);
        }

        /// <summary>
        /// Tests that modifier keys have scancode mask
        /// </summary>
        [Fact]
        public void ModifierKeys_HaveScancodeMask()
        {
            int mask = SdlInputConst.KScancodeMask;
            Assert.True(((int)KeyCodes.Lctrl & mask) != 0);
            Assert.True(((int)KeyCodes.Rctrl & mask) != 0);
            Assert.True(((int)KeyCodes.Lshift & mask) != 0);
            Assert.True(((int)KeyCodes.Rshift & mask) != 0);
            Assert.True(((int)KeyCodes.Lalt & mask) != 0);
            Assert.True(((int)KeyCodes.Ralt & mask) != 0);
            Assert.True(((int)KeyCodes.Lgui & mask) != 0);
            Assert.True(((int)KeyCodes.Rgui & mask) != 0);
        }

        /// <summary>
        /// Tests that arrow keys have scancode mask
        /// </summary>
        [Fact]
        public void ArrowKeys_HaveScancodeMask()
        {
            int mask = SdlInputConst.KScancodeMask;
            Assert.True(((int)KeyCodes.Up & mask) != 0);
            Assert.True(((int)KeyCodes.Down & mask) != 0);
            Assert.True(((int)KeyCodes.Left & mask) != 0);
            Assert.True(((int)KeyCodes.Right & mask) != 0);
        }

        /// <summary>
        /// Tests that capslock has scancode mask
        /// </summary>
        [Fact]
        public void Capslock_HasScancodeMask()
        {
            int mask = SdlInputConst.KScancodeMask;
            Assert.True(((int)KeyCodes.Capslock & mask) != 0);
        }

        /// <summary>
        /// Tests that navigation keys have scancode mask
        /// </summary>
        [Fact]
        public void NavigationKeys_HaveScancodeMask()
        {
            int mask = SdlInputConst.KScancodeMask;
            Assert.True(((int)KeyCodes.Home & mask) != 0);
            Assert.True(((int)KeyCodes.End & mask) != 0);
            Assert.True(((int)KeyCodes.Insert & mask) != 0);
            Assert.True(((int)KeyCodes.Pageup & mask) != 0);
            Assert.True(((int)KeyCodes.Pagedown & mask) != 0);
        }
    }
}
