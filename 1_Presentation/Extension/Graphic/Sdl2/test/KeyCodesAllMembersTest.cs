// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyCodesAllMembersTest.cs
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
using Alis.Extension.Graphic.Sdl2.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Asserts the exact value of every KeyCodes enum member
    /// </summary>
    public class KeyCodesAllMembersTest
    {
        /// <summary>
        /// Tests that all key codes members have their expected values
        /// </summary>
        [RequireSdl2ImageFact]
        public void AllKeyCodesMembers_HaveExpectedValues()
        {
            Assert.Equal(0, (int) KeyCodes.Unknown);
            Assert.Equal(13, (int) KeyCodes.Return);
            Assert.Equal(27, (int) KeyCodes.Escape);
            Assert.Equal(8, (int) KeyCodes.Backspace);
            Assert.Equal(9, (int) KeyCodes.Tab);
            Assert.Equal(32, (int) KeyCodes.Space);
            Assert.Equal(33, (int) KeyCodes.Exclaim);
            Assert.Equal((int) '"', (int) KeyCodes.Quotedbl);
            Assert.Equal((int) '#', (int) KeyCodes.Hash);
            Assert.Equal((int) '%', (int) KeyCodes.Percent);
            Assert.Equal((int) '$', (int) KeyCodes.Dollar);
            Assert.Equal((int) '&', (int) KeyCodes.Ampersand);
            Assert.Equal((int) '\'', (int) KeyCodes.Quote);
            Assert.Equal((int) '(', (int) KeyCodes.Leftparen);
            Assert.Equal((int) ')', (int) KeyCodes.RightParen);
            Assert.Equal((int) '*', (int) KeyCodes.Asterisk);
            Assert.Equal((int) '+', (int) KeyCodes.Plus);
            Assert.Equal((int) ',', (int) KeyCodes.Comma);
            Assert.Equal((int) '-', (int) KeyCodes.Minus);
            Assert.Equal((int) '.', (int) KeyCodes.Period);
            Assert.Equal((int) '/', (int) KeyCodes.Slash);
            Assert.Equal((int) '0', (int) KeyCodes.Num0);
            Assert.Equal((int) '1', (int) KeyCodes.Num1);
            Assert.Equal((int) '2', (int) KeyCodes.Num2);
            Assert.Equal((int) '3', (int) KeyCodes.Num3);
            Assert.Equal((int) '4', (int) KeyCodes.Num4);
            Assert.Equal((int) '5', (int) KeyCodes.Num5);
            Assert.Equal((int) '6', (int) KeyCodes.Num6);
            Assert.Equal((int) '7', (int) KeyCodes.Num7);
            Assert.Equal((int) '8', (int) KeyCodes.Num8);
            Assert.Equal((int) '9', (int) KeyCodes.Num9);
            Assert.Equal((int) ':', (int) KeyCodes.Colon);
            Assert.Equal((int) ';', (int) KeyCodes.Semicolon);
            Assert.Equal((int) '<', (int) KeyCodes.Less);
            Assert.Equal((int) '=', (int) KeyCodes.Equals);
            Assert.Equal((int) '>', (int) KeyCodes.Greater);
            Assert.Equal((int) '?', (int) KeyCodes.Question);
            Assert.Equal((int) '@', (int) KeyCodes.At);
            Assert.Equal((int) '[', (int) KeyCodes.Leftbracket);
            Assert.Equal((int) '\\', (int) KeyCodes.Backslash);
            Assert.Equal((int) ']', (int) KeyCodes.Rightbracket);
            Assert.Equal((int) '^', (int) KeyCodes.Caret);
            Assert.Equal((int) '_', (int) KeyCodes.Underscore);
            Assert.Equal((int) '`', (int) KeyCodes.Backquote);
            Assert.Equal((int) 'a', (int) KeyCodes.A);
            Assert.Equal((int) 'b', (int) KeyCodes.B);
            Assert.Equal((int) 'c', (int) KeyCodes.C);
            Assert.Equal((int) 'd', (int) KeyCodes.D);
            Assert.Equal((int) 'e', (int) KeyCodes.E);
            Assert.Equal((int) 'f', (int) KeyCodes.F);
            Assert.Equal((int) 'g', (int) KeyCodes.G);
            Assert.Equal((int) 'h', (int) KeyCodes.H);
            Assert.Equal((int) 'i', (int) KeyCodes.I);
            Assert.Equal((int) 'j', (int) KeyCodes.J);
            Assert.Equal((int) 'k', (int) KeyCodes.K);
            Assert.Equal((int) 'l', (int) KeyCodes.L);
            Assert.Equal((int) 'm', (int) KeyCodes.M);
            Assert.Equal((int) 'n', (int) KeyCodes.N);
            Assert.Equal((int) 'o', (int) KeyCodes.O);
            Assert.Equal((int) 'p', (int) KeyCodes.P);
            Assert.Equal((int) 'q', (int) KeyCodes.Q);
            Assert.Equal((int) 'r', (int) KeyCodes.R);
            Assert.Equal((int) 's', (int) KeyCodes.S);
            Assert.Equal((int) 't', (int) KeyCodes.T);
            Assert.Equal((int) 'u', (int) KeyCodes.U);
            Assert.Equal((int) 'v', (int) KeyCodes.V);
            Assert.Equal((int) 'w', (int) KeyCodes.W);
            Assert.Equal((int) 'x', (int) KeyCodes.X);
            Assert.Equal((int) 'y', (int) KeyCodes.Y);
            Assert.Equal((int) 'z', (int) KeyCodes.Z);
            Assert.Equal((int) SdlScancode.SdlScancodeCapslock | SdlInputConst.KScancodeMask, (int) KeyCodes.Capslock);
            Assert.Equal((int) SdlScancode.SdlScancodeF1 | SdlInputConst.KScancodeMask, (int) KeyCodes.F1);
            Assert.Equal((int) SdlScancode.SdlScancodeF2 | SdlInputConst.KScancodeMask, (int) KeyCodes.F2);
            Assert.Equal((int) SdlScancode.SdlScancodeF3 | SdlInputConst.KScancodeMask, (int) KeyCodes.F3);
            Assert.Equal((int) SdlScancode.SdlScancodeF4 | SdlInputConst.KScancodeMask, (int) KeyCodes.F4);
            Assert.Equal((int) SdlScancode.SdlScancodeF5 | SdlInputConst.KScancodeMask, (int) KeyCodes.F5);
            Assert.Equal((int) SdlScancode.SdlScancodeF6 | SdlInputConst.KScancodeMask, (int) KeyCodes.F6);
            Assert.Equal((int) SdlScancode.SdlScancodeF7 | SdlInputConst.KScancodeMask, (int) KeyCodes.F7);
            Assert.Equal((int) SdlScancode.SdlScancodeF8 | SdlInputConst.KScancodeMask, (int) KeyCodes.F8);
            Assert.Equal((int) SdlScancode.SdlScancodeF9 | SdlInputConst.KScancodeMask, (int) KeyCodes.F9);
            Assert.Equal((int) SdlScancode.SdlScancodeF10 | SdlInputConst.KScancodeMask, (int) KeyCodes.F10);
            Assert.Equal((int) SdlScancode.SdlScancodeF11 | SdlInputConst.KScancodeMask, (int) KeyCodes.F11);
            Assert.Equal((int) SdlScancode.SdlScancodeF12 | SdlInputConst.KScancodeMask, (int) KeyCodes.F12);
            Assert.Equal((int) SdlScancode.SdlScancodePrintscreen | SdlInputConst.KScancodeMask, (int) KeyCodes.Printscreen);
            Assert.Equal((int) SdlScancode.SdlScancodeScrolllock | SdlInputConst.KScancodeMask, (int) KeyCodes.Scrolllock);
            Assert.Equal((int) SdlScancode.SdlScancodePause | SdlInputConst.KScancodeMask, (int) KeyCodes.Pause);
            Assert.Equal((int) SdlScancode.SdlScancodeInsert | SdlInputConst.KScancodeMask, (int) KeyCodes.Insert);
            Assert.Equal((int) SdlScancode.SdlScancodeHome | SdlInputConst.KScancodeMask, (int) KeyCodes.Home);
            Assert.Equal((int) SdlScancode.SdlScancodePageup | SdlInputConst.KScancodeMask, (int) KeyCodes.Pageup);
            Assert.Equal(127, (int) KeyCodes.Delete);
            Assert.Equal((int) SdlScancode.SdlScancodeEnd | SdlInputConst.KScancodeMask, (int) KeyCodes.End);
            Assert.Equal((int) SdlScancode.SdlScancodePagedown | SdlInputConst.KScancodeMask, (int) KeyCodes.Pagedown);
            Assert.Equal((int) SdlScancode.SdlScancodeRight | SdlInputConst.KScancodeMask, (int) KeyCodes.Right);
            Assert.Equal((int) SdlScancode.SdlScancodeLeft | SdlInputConst.KScancodeMask, (int) KeyCodes.Left);
            Assert.Equal((int) SdlScancode.SdlScancodeDown | SdlInputConst.KScancodeMask, (int) KeyCodes.Down);
            Assert.Equal((int) SdlScancode.SdlScancodeUp | SdlInputConst.KScancodeMask, (int) KeyCodes.Up);
            Assert.Equal((int) SdlScancode.SdlScancodeNumlockclear | SdlInputConst.KScancodeMask, (int) KeyCodes.Numlockclear);
            Assert.Equal((int) SdlScancode.SdlScancodeKpDivide | SdlInputConst.KScancodeMask, (int) KeyCodes.KpDivide);
            Assert.Equal((int) SdlScancode.SdlScancodeKpMultiply | SdlInputConst.KScancodeMask, (int) KeyCodes.KpMultiply);
            Assert.Equal((int) SdlScancode.SdlScancodeKpMinus | SdlInputConst.KScancodeMask, (int) KeyCodes.KpMinus);
            Assert.Equal((int) SdlScancode.SdlScancodeKpPlus | SdlInputConst.KScancodeMask, (int) KeyCodes.KpPlus);
            Assert.Equal((int) SdlScancode.SdlScancodeKpEnter | SdlInputConst.KScancodeMask, (int) KeyCodes.KpEnter);
            Assert.Equal((int) SdlScancode.SdlScancodeKp1 | SdlInputConst.KScancodeMask, (int) KeyCodes.Kp1);
            Assert.Equal((int) SdlScancode.SdlScancodeKp2 | SdlInputConst.KScancodeMask, (int) KeyCodes.Kp2);
            Assert.Equal((int) SdlScancode.SdlScancodeKp3 | SdlInputConst.KScancodeMask, (int) KeyCodes.Kp3);
            Assert.Equal((int) SdlScancode.SdlScancodeKp4 | SdlInputConst.KScancodeMask, (int) KeyCodes.Kp4);
            Assert.Equal((int) SdlScancode.SdlScancodeKp5 | SdlInputConst.KScancodeMask, (int) KeyCodes.Kp5);
            Assert.Equal((int) SdlScancode.SdlScancodeKp6 | SdlInputConst.KScancodeMask, (int) KeyCodes.Kp6);
            Assert.Equal((int) SdlScancode.SdlScancodeKp7 | SdlInputConst.KScancodeMask, (int) KeyCodes.Kp7);
            Assert.Equal((int) SdlScancode.SdlScancodeKp8 | SdlInputConst.KScancodeMask, (int) KeyCodes.Kp8);
            Assert.Equal((int) SdlScancode.SdlScancodeKp9 | SdlInputConst.KScancodeMask, (int) KeyCodes.Kp9);
            Assert.Equal((int) SdlScancode.SdlScancodeKp0 | SdlInputConst.KScancodeMask, (int) KeyCodes.Kp0);
            Assert.Equal((int) SdlScancode.SdlScancodeKpPeriod | SdlInputConst.KScancodeMask, (int) KeyCodes.KpPeriod);
            Assert.Equal((int) SdlScancode.SdlScancodeApplication | SdlInputConst.KScancodeMask, (int) KeyCodes.Application);
            Assert.Equal((int) SdlScancode.SdlScancodePower | SdlInputConst.KScancodeMask, (int) KeyCodes.Power);
            Assert.Equal((int) SdlScancode.SdlScancodeKpEquals | SdlInputConst.KScancodeMask, (int) KeyCodes.KpEquals);
            Assert.Equal((int) SdlScancode.SdlScancodeF13 | SdlInputConst.KScancodeMask, (int) KeyCodes.F13);
            Assert.Equal((int) SdlScancode.SdlScancodeF14 | SdlInputConst.KScancodeMask, (int) KeyCodes.F14);
            Assert.Equal((int) SdlScancode.SdlScancodeF15 | SdlInputConst.KScancodeMask, (int) KeyCodes.F15);
            Assert.Equal((int) SdlScancode.SdlScancodeF16 | SdlInputConst.KScancodeMask, (int) KeyCodes.F16);
            Assert.Equal((int) SdlScancode.SdlScancodeF17 | SdlInputConst.KScancodeMask, (int) KeyCodes.F17);
            Assert.Equal((int) SdlScancode.SdlScancodeF18 | SdlInputConst.KScancodeMask, (int) KeyCodes.F18);
            Assert.Equal((int) SdlScancode.SdlScancodeF19 | SdlInputConst.KScancodeMask, (int) KeyCodes.F19);
            Assert.Equal((int) SdlScancode.SdlScancodeF20 | SdlInputConst.KScancodeMask, (int) KeyCodes.F20);
            Assert.Equal((int) SdlScancode.SdlScancodeF21 | SdlInputConst.KScancodeMask, (int) KeyCodes.F21);
            Assert.Equal((int) SdlScancode.SdlScancodeF22 | SdlInputConst.KScancodeMask, (int) KeyCodes.F22);
            Assert.Equal((int) SdlScancode.SdlScancodeF23 | SdlInputConst.KScancodeMask, (int) KeyCodes.F23);
            Assert.Equal((int) SdlScancode.SdlScancodeF24 | SdlInputConst.KScancodeMask, (int) KeyCodes.F24);
            Assert.Equal((int) SdlScancode.SdlScancodeExecute | SdlInputConst.KScancodeMask, (int) KeyCodes.Execute);
            Assert.Equal((int) SdlScancode.SdlScancodeHelp | SdlInputConst.KScancodeMask, (int) KeyCodes.Help);
            Assert.Equal((int) SdlScancode.SdlScancodeMenu | SdlInputConst.KScancodeMask, (int) KeyCodes.Menu);
            Assert.Equal((int) SdlScancode.SdlScancodeSelect | SdlInputConst.KScancodeMask, (int) KeyCodes.Select);
            Assert.Equal((int) SdlScancode.SdlScancodeStop | SdlInputConst.KScancodeMask, (int) KeyCodes.Stop);
            Assert.Equal((int) SdlScancode.SdlScancodeAgain | SdlInputConst.KScancodeMask, (int) KeyCodes.Again);
            Assert.Equal((int) SdlScancode.SdlScancodeUndo | SdlInputConst.KScancodeMask, (int) KeyCodes.Undo);
            Assert.Equal((int) SdlScancode.SdlScancodeCut | SdlInputConst.KScancodeMask, (int) KeyCodes.Cut);
            Assert.Equal((int) SdlScancode.SdlScancodeCopy | SdlInputConst.KScancodeMask, (int) KeyCodes.Copy);
            Assert.Equal((int) SdlScancode.SdlScancodePaste | SdlInputConst.KScancodeMask, (int) KeyCodes.Paste);
            Assert.Equal((int) SdlScancode.SdlScancodeFind | SdlInputConst.KScancodeMask, (int) KeyCodes.Find);
            Assert.Equal((int) SdlScancode.SdlScancodeMute | SdlInputConst.KScancodeMask, (int) KeyCodes.Mute);
            Assert.Equal((int) SdlScancode.SdlScancodeVolumeup | SdlInputConst.KScancodeMask, (int) KeyCodes.Volumeup);
            Assert.Equal((int) SdlScancode.SdlScancodeVolumedown | SdlInputConst.KScancodeMask, (int) KeyCodes.Volumedown);
            Assert.Equal((int) SdlScancode.SdlScancodeKpComma | SdlInputConst.KScancodeMask, (int) KeyCodes.KpComma);
            Assert.Equal((int) SdlScancode.SdlScancodeAlterase | SdlInputConst.KScancodeMask, (int) KeyCodes.Alterase);
            Assert.Equal((int) SdlScancode.SdlScancodeSysreq | SdlInputConst.KScancodeMask, (int) KeyCodes.Syzsreq);
            Assert.Equal((int) SdlScancode.SdlScancodeCancel | SdlInputConst.KScancodeMask, (int) KeyCodes.Cancel);
            Assert.Equal((int) SdlScancode.SdlScancodeClear | SdlInputConst.KScancodeMask, (int) KeyCodes.Clear);
            Assert.Equal((int) SdlScancode.SdlScancodePrior | SdlInputConst.KScancodeMask, (int) KeyCodes.Prior);
            Assert.Equal((int) SdlScancode.SdlScancodeReturn2 | SdlInputConst.KScancodeMask, (int) KeyCodes.Return2);
            Assert.Equal((int) SdlScancode.SdlScancodeSeparator | SdlInputConst.KScancodeMask, (int) KeyCodes.Separator);
            Assert.Equal((int) SdlScancode.SdlScancodeOut | SdlInputConst.KScancodeMask, (int) KeyCodes.Out);
            Assert.Equal((int) SdlScancode.SdlScancodeOper | SdlInputConst.KScancodeMask, (int) KeyCodes.Oper);
            Assert.Equal((int) SdlScancode.SdlScancodeClearagain | SdlInputConst.KScancodeMask, (int) KeyCodes.Clearagain);
            Assert.Equal((int) SdlScancode.SdlScancodeCrsel | SdlInputConst.KScancodeMask, (int) KeyCodes.Crsel);
            Assert.Equal((int) SdlScancode.SdlScancodeExsel | SdlInputConst.KScancodeMask, (int) KeyCodes.Exsel);
            Assert.Equal((int) SdlScancode.SdlScancodeKp00 | SdlInputConst.KScancodeMask, (int) KeyCodes.Kp00);
            Assert.Equal((int) SdlScancode.SdlScancodeKp000 | SdlInputConst.KScancodeMask, (int) KeyCodes.Kp000);
            Assert.Equal((int) SdlScancode.SdlScancodeCurrencyunit | SdlInputConst.KScancodeMask, (int) KeyCodes.Currencyunit);
            Assert.Equal((int) SdlScancode.SdlScancodeKpLeftparen | SdlInputConst.KScancodeMask, (int) KeyCodes.KpLeftparen);
            Assert.Equal((int) SdlScancode.SdlScancodeKpRightparen | SdlInputConst.KScancodeMask, (int) KeyCodes.KpRightparen);
            Assert.Equal((int) SdlScancode.SdlScancodeKpLeftbrace | SdlInputConst.KScancodeMask, (int) KeyCodes.KpLeftbrace);
            Assert.Equal((int) SdlScancode.SdlScancodeKpRightbrace | SdlInputConst.KScancodeMask, (int) KeyCodes.KpRightbrace);
            Assert.Equal((int) SdlScancode.SdlScancodeKpTab | SdlInputConst.KScancodeMask, (int) KeyCodes.KpTab);
            Assert.Equal((int) SdlScancode.SdlScancodeKpBackspace | SdlInputConst.KScancodeMask, (int) KeyCodes.KpBackspace);
            Assert.Equal((int) SdlScancode.SdlScancodeKpA | SdlInputConst.KScancodeMask, (int) KeyCodes.KpA);
            Assert.Equal((int) SdlScancode.SdlScancodeKpB | SdlInputConst.KScancodeMask, (int) KeyCodes.KpB);
            Assert.Equal((int) SdlScancode.SdlScancodeKpC | SdlInputConst.KScancodeMask, (int) KeyCodes.KpC);
            Assert.Equal((int) SdlScancode.SdlScancodeKpD | SdlInputConst.KScancodeMask, (int) KeyCodes.KpD);
            Assert.Equal((int) SdlScancode.SdlScancodeKpE | SdlInputConst.KScancodeMask, (int) KeyCodes.KpE);
            Assert.Equal((int) SdlScancode.SdlScancodeKpF | SdlInputConst.KScancodeMask, (int) KeyCodes.KpF);
            Assert.Equal((int) SdlScancode.SdlScancodeKpXor | SdlInputConst.KScancodeMask, (int) KeyCodes.KpXor);
            Assert.Equal((int) SdlScancode.SdlScancodeKpPower | SdlInputConst.KScancodeMask, (int) KeyCodes.KpPower);
            Assert.Equal((int) SdlScancode.SdlScancodeKpPercent | SdlInputConst.KScancodeMask, (int) KeyCodes.KpPercent);
            Assert.Equal((int) SdlScancode.SdlScancodeKpLess | SdlInputConst.KScancodeMask, (int) KeyCodes.KpLess);
            Assert.Equal((int) SdlScancode.SdlScancodeKpGreater | SdlInputConst.KScancodeMask, (int) KeyCodes.KpGreater);
            Assert.Equal((int) SdlScancode.SdlScancodeKpAmpersand | SdlInputConst.KScancodeMask, (int) KeyCodes.KpAmpersand);
            Assert.Equal((int) SdlScancode.SdlScancodeKpColon | SdlInputConst.KScancodeMask, (int) KeyCodes.KpColon);
            Assert.Equal((int) SdlScancode.SdlScancodeKpHash | SdlInputConst.KScancodeMask, (int) KeyCodes.KpHash);
            Assert.Equal((int) SdlScancode.SdlScancodeKpSpace | SdlInputConst.KScancodeMask, (int) KeyCodes.KpSpace);
            Assert.Equal((int) SdlScancode.SdlScancodeKpAt | SdlInputConst.KScancodeMask, (int) KeyCodes.KpAt);
            Assert.Equal((int) SdlScancode.SdlScancodeKpExclam | SdlInputConst.KScancodeMask, (int) KeyCodes.KpExclam);
            Assert.Equal((int) SdlScancode.SdlScancodeKpMemstore | SdlInputConst.KScancodeMask, (int) KeyCodes.KpMemstore);
            Assert.Equal((int) SdlScancode.SdlScancodeKpMemrecall | SdlInputConst.KScancodeMask, (int) KeyCodes.KpMemrecall);
            Assert.Equal((int) SdlScancode.SdlScancodeKpMemclear | SdlInputConst.KScancodeMask, (int) KeyCodes.KpMemclear);
            Assert.Equal((int) SdlScancode.SdlScancodeKpMemadd | SdlInputConst.KScancodeMask, (int) KeyCodes.KpMemadd);
            Assert.Equal((int) SdlScancode.SdlScancodeKpMemdivide | SdlInputConst.KScancodeMask, (int) KeyCodes.KpMemdivide);
            Assert.Equal((int) SdlScancode.SdlScancodeKpPlusminus | SdlInputConst.KScancodeMask, (int) KeyCodes.KpPlusminus);
            Assert.Equal((int) SdlScancode.SdlScancodeKpClear | SdlInputConst.KScancodeMask, (int) KeyCodes.KpClear);
            Assert.Equal((int) SdlScancode.SdlScancodeKpClearentry | SdlInputConst.KScancodeMask, (int) KeyCodes.KpClearentry);
            Assert.Equal((int) SdlScancode.SdlScancodeKpBinary | SdlInputConst.KScancodeMask, (int) KeyCodes.KpBinary);
            Assert.Equal((int) SdlScancode.SdlScancodeKpOctal | SdlInputConst.KScancodeMask, (int) KeyCodes.KpOctal);
            Assert.Equal((int) SdlScancode.SdlScancodeKpDecimal | SdlInputConst.KScancodeMask, (int) KeyCodes.KpDecimal);
            Assert.Equal((int) SdlScancode.SdlScancodeLctrl | SdlInputConst.KScancodeMask, (int) KeyCodes.Lctrl);
            Assert.Equal((int) SdlScancode.SdlScancodeLshift | SdlInputConst.KScancodeMask, (int) KeyCodes.Lshift);
            Assert.Equal((int) SdlScancode.SdlScancodeLalt | SdlInputConst.KScancodeMask, (int) KeyCodes.Lalt);
            Assert.Equal((int) SdlScancode.SdlScancodeLgui | SdlInputConst.KScancodeMask, (int) KeyCodes.Lgui);
            Assert.Equal((int) SdlScancode.SdlScancodeRctrl | SdlInputConst.KScancodeMask, (int) KeyCodes.Rctrl);
            Assert.Equal((int) SdlScancode.SdlScancodeRshift | SdlInputConst.KScancodeMask, (int) KeyCodes.Rshift);
            Assert.Equal((int) SdlScancode.SdlScancodeRalt | SdlInputConst.KScancodeMask, (int) KeyCodes.Ralt);
            Assert.Equal((int) SdlScancode.SdlScancodeRgui | SdlInputConst.KScancodeMask, (int) KeyCodes.Rgui);
            Assert.Equal((int) SdlScancode.SdlScancodeMode | SdlInputConst.KScancodeMask, (int) KeyCodes.Mode);
            Assert.Equal((int) SdlScancode.SdlScancodeAudionext | SdlInputConst.KScancodeMask, (int) KeyCodes.Audionext);
            Assert.Equal((int) SdlScancode.SdlScancodeAudioprev | SdlInputConst.KScancodeMask, (int) KeyCodes.Audioprev);
            Assert.Equal((int) SdlScancode.SdlScancodeAudiostop | SdlInputConst.KScancodeMask, (int) KeyCodes.Audiostop);
            Assert.Equal((int) SdlScancode.SdlScancodeAudioplay | SdlInputConst.KScancodeMask, (int) KeyCodes.Audioplay);
            Assert.Equal((int) SdlScancode.SdlScancodeAudiomute | SdlInputConst.KScancodeMask, (int) KeyCodes.Audiomute);
            Assert.Equal((int) SdlScancode.SdlScancodeMediaselect | SdlInputConst.KScancodeMask, (int) KeyCodes.Mediaselect);
            Assert.Equal((int) SdlScancode.SdlScancodeWww | SdlInputConst.KScancodeMask, (int) KeyCodes.Www);
            Assert.Equal((int) SdlScancode.SdlScancodeMail | SdlInputConst.KScancodeMask, (int) KeyCodes.Mail);
            Assert.Equal((int) SdlScancode.SdlScancodeCalculator | SdlInputConst.KScancodeMask, (int) KeyCodes.Calculator);
            Assert.Equal((int) SdlScancode.SdlScancodeComputer | SdlInputConst.KScancodeMask, (int) KeyCodes.Computer);
            Assert.Equal((int) SdlScancode.SdlScancodeAcSearch | SdlInputConst.KScancodeMask, (int) KeyCodes.AcSearch);
            Assert.Equal((int) SdlScancode.SdlScancodeAcHome | SdlInputConst.KScancodeMask, (int) KeyCodes.AcHome);
            Assert.Equal((int) SdlScancode.SdlScancodeAcBack | SdlInputConst.KScancodeMask, (int) KeyCodes.AcBack);
            Assert.Equal((int) SdlScancode.SdlScancodeAcForward | SdlInputConst.KScancodeMask, (int) KeyCodes.AcForward);
            Assert.Equal((int) SdlScancode.SdlScancodeAcStop | SdlInputConst.KScancodeMask, (int) KeyCodes.AcStop);
            Assert.Equal((int) SdlScancode.SdlScancodeAcRefresh | SdlInputConst.KScancodeMask, (int) KeyCodes.AcRefresh);
            Assert.Equal((int) SdlScancode.SdlScancodeAcBookmarks | SdlInputConst.KScancodeMask, (int) KeyCodes.AcBookmarks);
            Assert.Equal((int) SdlScancode.SdlScancodeBrightnessup | SdlInputConst.KScancodeMask, (int) KeyCodes.Brightnessup);
            Assert.Equal((int) SdlScancode.SdlScancodeDisplayswitch | SdlInputConst.KScancodeMask, (int) KeyCodes.Displayswitch);
            Assert.Equal((int) SdlScancode.SdlScancodeKbdillumdown | SdlInputConst.KScancodeMask, (int) KeyCodes.Kbdillumdown);
            Assert.Equal((int) SdlScancode.SdlScancodeKbdillumup | SdlInputConst.KScancodeMask, (int) KeyCodes.Kbdillumup);
            Assert.Equal((int) SdlScancode.SdlScancodeEject | SdlInputConst.KScancodeMask, (int) KeyCodes.Eject);
            Assert.Equal((int) SdlScancode.SdlScancodeSleep | SdlInputConst.KScancodeMask, (int) KeyCodes.Sleep);
            Assert.Equal((int) SdlScancode.SdlScancodeApp1 | SdlInputConst.KScancodeMask, (int) KeyCodes.App1);
            Assert.Equal((int) SdlScancode.SdlScancodeApp2 | SdlInputConst.KScancodeMask, (int) KeyCodes.App2);
            Assert.Equal((int) SdlScancode.SdlScancodeAudiorewind | SdlInputConst.KScancodeMask, (int) KeyCodes.Audiorewind);
            Assert.Equal((int) SdlScancode.SdlScancodeAudiofastforward | SdlInputConst.KScancodeMask, (int) KeyCodes.Audiofastforward);
        }
    }
}
