// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyEventTest.cs
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

using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     Tests for KeyEvent and KeyEventArgs.
    /// </summary>
    public class KeyEventTest
    {
        /// <summary>
        /// Tests that key event default has zero values
        /// </summary>
        [Fact]
        public void KeyEvent_Default_HasZeroValues()
        {
            KeyEvent e = new KeyEvent();
            Assert.Equal(Keyboard.Key.A, e.Code);
            Assert.Equal(0, e.Alt);
            Assert.Equal(0, e.Control);
            Assert.Equal(0, e.Shift);
            Assert.Equal(0, e.System);
        }

        /// <summary>
        /// Tests that key event args constructor sets properties
        /// </summary>
        [Fact]
        public void KeyEventArgs_Constructor_SetsProperties()
        {
            KeyEvent e = new KeyEvent { Code = Keyboard.Key.Space, Alt = 1, Control = 0, Shift = 1, System = 0 };
            KeyEventArgs args = new KeyEventArgs(e);
            Assert.Equal(Keyboard.Key.Space, args.Code);
            Assert.True(args.Alt);
            Assert.False(args.Control);
            Assert.True(args.Shift);
            Assert.False(args.System);
        }

        /// <summary>
        /// Tests that key event args to string includes property names
        /// </summary>
        [Fact]
        public void KeyEventArgs_ToString_IncludesPropertyNames()
        {
            KeyEvent e = new KeyEvent { Code = Keyboard.Key.Enter };
            KeyEventArgs args = new KeyEventArgs(e);
            string str = args.ToString();
            Assert.Contains("Code", str);
            Assert.Contains("Alt", str);
            Assert.Contains("Control", str);
        }
    }
}
