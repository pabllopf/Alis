// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyEventArgsRemainingCoverageTests.cs
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

using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     The key event args remaining coverage tests class
    /// </summary>
    public class KeyEventArgsRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that constructor assigns code and modifiers
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_AssignsCodeAndModifiers()
        {
            KeyEvent keyEvent = new KeyEvent
            {
                Code = Keyboard.Key.A,
                Alt = 1,
                Control = 1,
                Shift = 1,
                System = 1
            };

            KeyEventArgs args = new KeyEventArgs(keyEvent);

            Assert.Equal(Keyboard.Key.A, args.Code);
            Assert.True(args.Alt);
            Assert.True(args.Control);
            Assert.True(args.Shift);
            Assert.True(args.System);
        }

        /// <summary>
        ///     Tests that constructor with zero modifiers sets false flags
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_WithZeroModifiers_SetsFalseFlags()
        {
            KeyEvent keyEvent = new KeyEvent
            {
                Code = Keyboard.Key.B
            };

            KeyEventArgs args = new KeyEventArgs(keyEvent);

            Assert.Equal(Keyboard.Key.B, args.Code);
            Assert.False(args.Alt);
            Assert.False(args.Control);
            Assert.False(args.Shift);
            Assert.False(args.System);
        }

        /// <summary>
        ///     Tests that properties get and set values
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Properties_GetAndSetValues()
        {
            KeyEventArgs args = new KeyEventArgs(new KeyEvent());

            args.Alt = true;
            args.Control = true;
            args.Shift = true;
            args.System = true;
            args.Code = Keyboard.Key.C;

            Assert.True(args.Alt);
            Assert.True(args.Control);
            Assert.True(args.Shift);
            Assert.True(args.System);
            Assert.Equal(Keyboard.Key.C, args.Code);
        }

        /// <summary>
        ///     Tests that to string returns expected format
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void ToString_ReturnsExpectedFormat()
        {
            KeyEvent keyEvent = new KeyEvent
            {
                Code = Keyboard.Key.Unknown
            };
            KeyEventArgs args = new KeyEventArgs(keyEvent);

            string str = args.ToString();

            Assert.Contains("[KeyEventArgs]", str);
            Assert.Contains("Code(Unknown)", str);
            Assert.Contains("Alt(False)", str);
            Assert.Contains("Control(False)", str);
            Assert.Contains("Shift(False)", str);
            Assert.Contains("System(False)", str);
        }
    }
}
