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

        /// <summary>
        /// Tests that punctuation keys are correct
        /// </summary>
        [Fact]
        public void PunctuationKeys_AreCorrect()
        {
            Assert.Equal(33, (int)KeyCodes.Exclaim);
            Assert.Equal('"', (int)KeyCodes.Quotedbl);
            Assert.Equal('#', (int)KeyCodes.Hash);
            Assert.Equal('$', (int)KeyCodes.Dollar);
            Assert.Equal('%', (int)KeyCodes.Percent);
            Assert.Equal('&', (int)KeyCodes.Ampersand);
            Assert.Equal('\'', (int)KeyCodes.Quote);
            Assert.Equal('(', (int)KeyCodes.Leftparen);
            Assert.Equal(')', (int)KeyCodes.RightParen);
            Assert.Equal('*', (int)KeyCodes.Asterisk);
            Assert.Equal('+', (int)KeyCodes.Plus);
            Assert.Equal(',', (int)KeyCodes.Comma);
            Assert.Equal('-', (int)KeyCodes.Minus);
            Assert.Equal('.', (int)KeyCodes.Period);
            Assert.Equal('/', (int)KeyCodes.Slash);
        }

        /// <summary>
        /// Tests that more punctuation keys are correct
        /// </summary>
        [Fact]
        public void MorePunctuationKeys_AreCorrect()
        {
            Assert.Equal(':', (int)KeyCodes.Colon);
            Assert.Equal(';', (int)KeyCodes.Semicolon);
            Assert.Equal('<', (int)KeyCodes.Less);
            Assert.Equal('=', (int)KeyCodes.Equals);
            Assert.Equal('>', (int)KeyCodes.Greater);
            Assert.Equal('?', (int)KeyCodes.Question);
            Assert.Equal('@', (int)KeyCodes.At);
            Assert.Equal('[', (int)KeyCodes.Leftbracket);
            Assert.Equal('\\', (int)KeyCodes.Backslash);
            Assert.Equal(']', (int)KeyCodes.Rightbracket);
            Assert.Equal('^', (int)KeyCodes.Caret);
            Assert.Equal('_', (int)KeyCodes.Underscore);
            Assert.Equal('`', (int)KeyCodes.Backquote);
        }

        /// <summary>
        /// Tests that remaining number keys are correct
        /// </summary>
        [Fact]
        public void RemainingNumberKeys_AreCorrect()
        {
            Assert.Equal('2', (int)KeyCodes.Num2);
            Assert.Equal('3', (int)KeyCodes.Num3);
            Assert.Equal('4', (int)KeyCodes.Num4);
            Assert.Equal('5', (int)KeyCodes.Num5);
            Assert.Equal('6', (int)KeyCodes.Num6);
            Assert.Equal('7', (int)KeyCodes.Num7);
            Assert.Equal('8', (int)KeyCodes.Num8);
        }

        /// <summary>
        /// Tests that all letter keys are correct
        /// </summary>
        [Fact]
        public void AllLetters_AreCorrect()
        {
            Assert.Equal('c', (int)KeyCodes.C);
            Assert.Equal('d', (int)KeyCodes.D);
            Assert.Equal('e', (int)KeyCodes.E);
            Assert.Equal('f', (int)KeyCodes.F);
            Assert.Equal('g', (int)KeyCodes.G);
            Assert.Equal('h', (int)KeyCodes.H);
            Assert.Equal('i', (int)KeyCodes.I);
            Assert.Equal('j', (int)KeyCodes.J);
            Assert.Equal('k', (int)KeyCodes.K);
            Assert.Equal('l', (int)KeyCodes.L);
            Assert.Equal('m', (int)KeyCodes.M);
            Assert.Equal('n', (int)KeyCodes.N);
            Assert.Equal('o', (int)KeyCodes.O);
            Assert.Equal('p', (int)KeyCodes.P);
            Assert.Equal('q', (int)KeyCodes.Q);
            Assert.Equal('r', (int)KeyCodes.R);
            Assert.Equal('s', (int)KeyCodes.S);
            Assert.Equal('t', (int)KeyCodes.T);
            Assert.Equal('u', (int)KeyCodes.U);
            Assert.Equal('v', (int)KeyCodes.V);
            Assert.Equal('w', (int)KeyCodes.W);
            Assert.Equal('x', (int)KeyCodes.X);
            Assert.Equal('y', (int)KeyCodes.Y);
        }

        /// <summary>
        /// Tests that extended function keys have scancode mask
        /// </summary>
        [Fact]
        public void ExtendedFunctionKeys_HaveScancodeMask()
        {
            int mask = SdlInputConst.KScancodeMask;
            Assert.True(((int)KeyCodes.F2 & mask) != 0);
            Assert.True(((int)KeyCodes.F3 & mask) != 0);
            Assert.True(((int)KeyCodes.F4 & mask) != 0);
            Assert.True(((int)KeyCodes.F5 & mask) != 0);
            Assert.True(((int)KeyCodes.F6 & mask) != 0);
            Assert.True(((int)KeyCodes.F7 & mask) != 0);
            Assert.True(((int)KeyCodes.F8 & mask) != 0);
            Assert.True(((int)KeyCodes.F9 & mask) != 0);
            Assert.True(((int)KeyCodes.F10 & mask) != 0);
            Assert.True(((int)KeyCodes.F11 & mask) != 0);
            Assert.True(((int)KeyCodes.F13 & mask) != 0);
            Assert.True(((int)KeyCodes.F14 & mask) != 0);
            Assert.True(((int)KeyCodes.F15 & mask) != 0);
            Assert.True(((int)KeyCodes.F16 & mask) != 0);
            Assert.True(((int)KeyCodes.F17 & mask) != 0);
            Assert.True(((int)KeyCodes.F18 & mask) != 0);
            Assert.True(((int)KeyCodes.F19 & mask) != 0);
            Assert.True(((int)KeyCodes.F20 & mask) != 0);
            Assert.True(((int)KeyCodes.F21 & mask) != 0);
            Assert.True(((int)KeyCodes.F22 & mask) != 0);
            Assert.True(((int)KeyCodes.F23 & mask) != 0);
        }

        /// <summary>
        /// Tests that screen keys have scancode mask
        /// </summary>
        [Fact]
        public void ScreenKeys_HaveScancodeMask()
        {
            int mask = SdlInputConst.KScancodeMask;
            Assert.True(((int)KeyCodes.Printscreen & mask) != 0);
            Assert.True(((int)KeyCodes.Scrolllock & mask) != 0);
            Assert.True(((int)KeyCodes.Pause & mask) != 0);
            Assert.True(((int)KeyCodes.Numlockclear & mask) != 0);
        }

        /// <summary>
        /// Tests that application and system keys have scancode mask
        /// </summary>
        [Fact]
        public void ApplicationSystemKeys_HaveScancodeMask()
        {
            int mask = SdlInputConst.KScancodeMask;
            Assert.True(((int)KeyCodes.Application & mask) != 0);
            Assert.True(((int)KeyCodes.Power & mask) != 0);
            Assert.True(((int)KeyCodes.Execute & mask) != 0);
            Assert.True(((int)KeyCodes.Help & mask) != 0);
            Assert.True(((int)KeyCodes.Menu & mask) != 0);
            Assert.True(((int)KeyCodes.Select & mask) != 0);
            Assert.True(((int)KeyCodes.Stop & mask) != 0);
            Assert.True(((int)KeyCodes.Again & mask) != 0);
            Assert.True(((int)KeyCodes.Undo & mask) != 0);
            Assert.True(((int)KeyCodes.Cut & mask) != 0);
            Assert.True(((int)KeyCodes.Copy & mask) != 0);
            Assert.True(((int)KeyCodes.Paste & mask) != 0);
            Assert.True(((int)KeyCodes.Find & mask) != 0);
        }

        /// <summary>
        /// Tests that audio volume keys have scancode mask
        /// </summary>
        [Fact]
        public void AudioVolumeKeys_HaveScancodeMask()
        {
            int mask = SdlInputConst.KScancodeMask;
            Assert.True(((int)KeyCodes.Mute & mask) != 0);
            Assert.True(((int)KeyCodes.Volumeup & mask) != 0);
            Assert.True(((int)KeyCodes.Volumedown & mask) != 0);
        }

        /// <summary>
        /// Tests that basic keypad keys have scancode mask
        /// </summary>
        [Fact]
        public void KeypadBasicKeys_HaveScancodeMask()
        {
            int mask = SdlInputConst.KScancodeMask;
            Assert.True(((int)KeyCodes.KpDivide & mask) != 0);
            Assert.True(((int)KeyCodes.KpMultiply & mask) != 0);
            Assert.True(((int)KeyCodes.KpMinus & mask) != 0);
            Assert.True(((int)KeyCodes.KpPlus & mask) != 0);
            Assert.True(((int)KeyCodes.KpEnter & mask) != 0);
            Assert.True(((int)KeyCodes.Kp1 & mask) != 0);
            Assert.True(((int)KeyCodes.Kp2 & mask) != 0);
            Assert.True(((int)KeyCodes.Kp3 & mask) != 0);
            Assert.True(((int)KeyCodes.Kp4 & mask) != 0);
            Assert.True(((int)KeyCodes.Kp5 & mask) != 0);
            Assert.True(((int)KeyCodes.Kp6 & mask) != 0);
            Assert.True(((int)KeyCodes.Kp7 & mask) != 0);
            Assert.True(((int)KeyCodes.Kp8 & mask) != 0);
            Assert.True(((int)KeyCodes.Kp9 & mask) != 0);
            Assert.True(((int)KeyCodes.Kp0 & mask) != 0);
            Assert.True(((int)KeyCodes.KpPeriod & mask) != 0);
            Assert.True(((int)KeyCodes.KpEquals & mask) != 0);
        }

        /// <summary>
        /// Tests that extended keypad keys have scancode mask
        /// </summary>
        [Fact]
        public void ExtendedKeypadKeys_HaveScancodeMask()
        {
            int mask = SdlInputConst.KScancodeMask;
            Assert.True(((int)KeyCodes.KpComma & mask) != 0);
            Assert.True(((int)KeyCodes.KpEqualsas400 & mask) != 0);
            Assert.True(((int)KeyCodes.Kp00 & mask) != 0);
            Assert.True(((int)KeyCodes.Kp000 & mask) != 0);
            Assert.True(((int)KeyCodes.KpLeftparen & mask) != 0);
            Assert.True(((int)KeyCodes.KpRightparen & mask) != 0);
            Assert.True(((int)KeyCodes.KpLeftbrace & mask) != 0);
            Assert.True(((int)KeyCodes.KpRightbrace & mask) != 0);
            Assert.True(((int)KeyCodes.KpTab & mask) != 0);
            Assert.True(((int)KeyCodes.KpBackspace & mask) != 0);
            Assert.True(((int)KeyCodes.KpA & mask) != 0);
            Assert.True(((int)KeyCodes.KpB & mask) != 0);
            Assert.True(((int)KeyCodes.KpC & mask) != 0);
            Assert.True(((int)KeyCodes.KpD & mask) != 0);
            Assert.True(((int)KeyCodes.KpE & mask) != 0);
            Assert.True(((int)KeyCodes.KpF & mask) != 0);
        }

        /// <summary>
        /// Tests that keypad operator keys have scancode mask
        /// </summary>
        [Fact]
        public void KeypadOperatorKeys_HaveScancodeMask()
        {
            int mask = SdlInputConst.KScancodeMask;
            Assert.True(((int)KeyCodes.KpXor & mask) != 0);
            Assert.True(((int)KeyCodes.KpPower & mask) != 0);
            Assert.True(((int)KeyCodes.KpPercent & mask) != 0);
            Assert.True(((int)KeyCodes.KpLess & mask) != 0);
            Assert.True(((int)KeyCodes.KpGreater & mask) != 0);
            Assert.True(((int)KeyCodes.KpAmpersand & mask) != 0);
            Assert.True(((int)KeyCodes.KpDblampersand & mask) != 0);
            Assert.True(((int)KeyCodes.KpVerticalbar & mask) != 0);
            Assert.True(((int)KeyCodes.KpDblverticalbar & mask) != 0);
            Assert.True(((int)KeyCodes.KpColon & mask) != 0);
            Assert.True(((int)KeyCodes.KpHash & mask) != 0);
            Assert.True(((int)KeyCodes.KpSpace & mask) != 0);
            Assert.True(((int)KeyCodes.KpAt & mask) != 0);
            Assert.True(((int)KeyCodes.KpExclam & mask) != 0);
        }

        /// <summary>
        /// Tests that keypad memory keys have scancode mask
        /// </summary>
        [Fact]
        public void KeypadMemoryKeys_HaveScancodeMask()
        {
            int mask = SdlInputConst.KScancodeMask;
            Assert.True(((int)KeyCodes.KpMemstore & mask) != 0);
            Assert.True(((int)KeyCodes.KpMemrecall & mask) != 0);
            Assert.True(((int)KeyCodes.KpMemclear & mask) != 0);
            Assert.True(((int)KeyCodes.KpMemadd & mask) != 0);
            Assert.True(((int)KeyCodes.KpMemsubtract & mask) != 0);
            Assert.True(((int)KeyCodes.KpMemmultiply & mask) != 0);
            Assert.True(((int)KeyCodes.KpMemdivide & mask) != 0);
            Assert.True(((int)KeyCodes.KpPlusminus & mask) != 0);
            Assert.True(((int)KeyCodes.KpClear & mask) != 0);
            Assert.True(((int)KeyCodes.KpClearentry & mask) != 0);
            Assert.True(((int)KeyCodes.KpBinary & mask) != 0);
            Assert.True(((int)KeyCodes.KpOctal & mask) != 0);
            Assert.True(((int)KeyCodes.KpDecimal & mask) != 0);
            Assert.True(((int)KeyCodes.KpHexadecimal & mask) != 0);
        }

        /// <summary>
        /// Tests that legacy keys have scancode mask
        /// </summary>
        [Fact]
        public void LegacyKeys_HaveScancodeMask()
        {
            int mask = SdlInputConst.KScancodeMask;
            Assert.True(((int)KeyCodes.Alterase & mask) != 0);
            Assert.True(((int)KeyCodes.Syzsreq & mask) != 0);
            Assert.True(((int)KeyCodes.Cancel & mask) != 0);
            Assert.True(((int)KeyCodes.Clear & mask) != 0);
            Assert.True(((int)KeyCodes.Prior & mask) != 0);
            Assert.True(((int)KeyCodes.Return2 & mask) != 0);
            Assert.True(((int)KeyCodes.Separator & mask) != 0);
            Assert.True(((int)KeyCodes.Out & mask) != 0);
            Assert.True(((int)KeyCodes.Oper & mask) != 0);
            Assert.True(((int)KeyCodes.Clearagain & mask) != 0);
            Assert.True(((int)KeyCodes.Crsel & mask) != 0);
            Assert.True(((int)KeyCodes.Exsel & mask) != 0);
            Assert.True(((int)KeyCodes.Thousandsseparator & mask) != 0);
            Assert.True(((int)KeyCodes.Decimalseparator & mask) != 0);
            Assert.True(((int)KeyCodes.Currencyunit & mask) != 0);
            Assert.True(((int)KeyCodes.Currencysubunit & mask) != 0);
        }

        /// <summary>
        /// Tests that media keys have scancode mask
        /// </summary>
        [Fact]
        public void MediaKeys_HaveScancodeMask()
        {
            int mask = SdlInputConst.KScancodeMask;
            Assert.True(((int)KeyCodes.Audionext & mask) != 0);
            Assert.True(((int)KeyCodes.Audioprev & mask) != 0);
            Assert.True(((int)KeyCodes.Audiostop & mask) != 0);
            Assert.True(((int)KeyCodes.Audioplay & mask) != 0);
            Assert.True(((int)KeyCodes.Audiomute & mask) != 0);
            Assert.True(((int)KeyCodes.Mediaselect & mask) != 0);
            Assert.True(((int)KeyCodes.Mode & mask) != 0);
            Assert.True(((int)KeyCodes.Audiorewind & mask) != 0);
            Assert.True(((int)KeyCodes.Audiofastforward & mask) != 0);
        }

        /// <summary>
        /// Tests that web and mail keys have scancode mask
        /// </summary>
        [Fact]
        public void WebMailKeys_HaveScancodeMask()
        {
            int mask = SdlInputConst.KScancodeMask;
            Assert.True(((int)KeyCodes.Www & mask) != 0);
            Assert.True(((int)KeyCodes.Mail & mask) != 0);
            Assert.True(((int)KeyCodes.Calculator & mask) != 0);
            Assert.True(((int)KeyCodes.Computer & mask) != 0);
        }

        /// <summary>
        /// Tests that ac keys have scancode mask
        /// </summary>
        [Fact]
        public void AcKeys_HaveScancodeMask()
        {
            int mask = SdlInputConst.KScancodeMask;
            Assert.True(((int)KeyCodes.AcSearch & mask) != 0);
            Assert.True(((int)KeyCodes.AcHome & mask) != 0);
            Assert.True(((int)KeyCodes.AcBack & mask) != 0);
            Assert.True(((int)KeyCodes.AcForward & mask) != 0);
            Assert.True(((int)KeyCodes.AcStop & mask) != 0);
            Assert.True(((int)KeyCodes.AcRefresh & mask) != 0);
            Assert.True(((int)KeyCodes.AcBookmarks & mask) != 0);
        }

        /// <summary>
        /// Tests that hardware keys have scancode mask
        /// </summary>
        [Fact]
        public void HardwareKeys_HaveScancodeMask()
        {
            int mask = SdlInputConst.KScancodeMask;
            Assert.True(((int)KeyCodes.Brightnessdown & mask) != 0);
            Assert.True(((int)KeyCodes.Brightnessup & mask) != 0);
            Assert.True(((int)KeyCodes.Displayswitch & mask) != 0);
            Assert.True(((int)KeyCodes.Kbdillumtoggle & mask) != 0);
            Assert.True(((int)KeyCodes.Kbdillumdown & mask) != 0);
            Assert.True(((int)KeyCodes.Kbdillumup & mask) != 0);
            Assert.True(((int)KeyCodes.Eject & mask) != 0);
            Assert.True(((int)KeyCodes.Sleep & mask) != 0);
            Assert.True(((int)KeyCodes.App1 & mask) != 0);
            Assert.True(((int)KeyCodes.App2 & mask) != 0);
        }
    }
}
