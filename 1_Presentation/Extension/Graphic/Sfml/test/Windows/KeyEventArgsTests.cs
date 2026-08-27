// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyEventArgsTests.cs
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
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     Tests for KeyEventArgs.
    /// </summary>
    public class KeyEventArgsTests
    {
        /// <summary>
        ///     Tests that constructor sets code from key event
        /// </summary>
        [Fact]
        public void Constructor_SetsCodeFromKeyEvent()
        {
            KeyEvent e = new KeyEvent { Code = Keyboard.Key.Space };

            KeyEventArgs args = new KeyEventArgs(e);

            Assert.Equal(Keyboard.Key.Space, args.Code);
        }

        /// <summary>
        ///     Tests that constructor sets alt from non zero key event value
        /// </summary>
        [Fact]
        public void Constructor_SetsAltFromNonZeroKeyEventValue()
        {
            KeyEvent e = new KeyEvent { Alt = 1 };

            KeyEventArgs args = new KeyEventArgs(e);

            Assert.True(args.Alt);
        }

        /// <summary>
        ///     Tests that constructor sets control from non zero key event value
        /// </summary>
        [Fact]
        public void Constructor_SetsControlFromNonZeroKeyEventValue()
        {
            KeyEvent e = new KeyEvent { Control = 1 };

            KeyEventArgs args = new KeyEventArgs(e);

            Assert.True(args.Control);
        }

        /// <summary>
        ///     Tests that constructor sets shift from non zero key event value
        /// </summary>
        [Fact]
        public void Constructor_SetsShiftFromNonZeroKeyEventValue()
        {
            KeyEvent e = new KeyEvent { Shift = 1 };

            KeyEventArgs args = new KeyEventArgs(e);

            Assert.True(args.Shift);
        }

        /// <summary>
        ///     Tests that constructor sets system from non zero key event value
        /// </summary>
        [Fact]
        public void Constructor_SetsSystemFromNonZeroKeyEventValue()
        {
            KeyEvent e = new KeyEvent { System = 1 };

            KeyEventArgs args = new KeyEventArgs(e);

            Assert.True(args.System);
        }

        /// <summary>
        ///     Tests that constructor sets false modifiers from zero key event values
        /// </summary>
        [Fact]
        public void Constructor_SetsFalseModifiersFromZeroKeyEventValues()
        {
            KeyEvent e = new KeyEvent { Code = Keyboard.Key.A, Alt = 0, Control = 0, Shift = 0, System = 0 };

            KeyEventArgs args = new KeyEventArgs(e);

            Assert.False(args.Alt);
            Assert.False(args.Control);
            Assert.False(args.Shift);
            Assert.False(args.System);
        }

        /// <summary>
        ///     Tests that default key event produces default key event args
        /// </summary>
        [Fact]
        public void DefaultKeyEvent_ProducesDefaultKeyEventArgs()
        {
            KeyEventArgs args = new KeyEventArgs(new KeyEvent());

            Assert.Equal(default, args.Code);
            Assert.False(args.Alt);
            Assert.False(args.Control);
            Assert.False(args.Shift);
            Assert.False(args.System);
        }

        /// <summary>
        ///     Tests that properties get and set values
        /// </summary>
        [Fact]
        public void Properties_GetAndSetValues()
        {
            KeyEventArgs args = new KeyEventArgs(new KeyEvent());

            args.Code = Keyboard.Key.Enter;
            args.Alt = true;
            args.Control = true;
            args.Shift = true;
            args.System = true;

            Assert.Equal(Keyboard.Key.Enter, args.Code);
            Assert.True(args.Alt);
            Assert.True(args.Control);
            Assert.True(args.Shift);
            Assert.True(args.System);
        }

        /// <summary>
        ///     Tests that key event args inherits from event args
        /// </summary>
        [Fact]
        public void KeyEventArgs_InheritsFromEventArgs()
        {
            KeyEventArgs args = new KeyEventArgs(new KeyEvent());

            Assert.IsAssignableFrom<EventArgs>(args);
        }

        /// <summary>
        ///     Tests that to string returns expected format
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            KeyEvent e = new KeyEvent { Code = Keyboard.Key.A, Alt = 1, Control = 0, Shift = 1, System = 0 };
            KeyEventArgs args = new KeyEventArgs(e);

            string str = args.ToString();

            Assert.Contains("[KeyEventArgs]", str);
            Assert.Contains("Code(A)", str);
            Assert.Contains("Alt(True)", str);
            Assert.Contains("Control(False)", str);
            Assert.Contains("Shift(True)", str);
            Assert.Contains("System(False)", str);
        }
    }
}
