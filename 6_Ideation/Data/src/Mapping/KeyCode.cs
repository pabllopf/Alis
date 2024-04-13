// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyCode.cs
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

namespace Alis.Core.Aspect.Data.Mapping
{
    /// <summary>
    ///     The sdl keycode enum
    /// </summary>
    public enum KeyCode
    {
        /// <summary>
        ///     The  unknown sdl keycode
        /// </summary>
        Unknown = 0,
        
        /// <summary>
        ///     The  return sdl keycode
        /// </summary>
        Return = '\r',
        
        /// <summary>
        ///     The  escape sdl keycode
        /// </summary>
        Escape = 27, // '\033'
        
        /// <summary>
        ///     The  backspace sdl keycode
        /// </summary>
        Backspace = '\b',
        
        /// <summary>
        ///     The  tab sdl keycode
        /// </summary>
        Tab = '\t',
        
        /// <summary>
        ///     The  space sdl keycode
        /// </summary>
        Space = ' ',
        
        /// <summary>
        ///     The  exclaim sdl keycode
        /// </summary>
        Exclaim = '!',
        
        /// <summary>
        ///     The  quotedbl sdl keycode
        /// </summary>
        Quotedbl = '"',
        
        /// <summary>
        ///     The  hash sdl keycode
        /// </summary>
        Hash = '#',
        
        /// <summary>
        ///     The  percent sdl keycode
        /// </summary>
        Percent = '%',
        
        /// <summary>
        ///     The  dollar sdl keycode
        /// </summary>
        Dollar = '$',
        
        /// <summary>
        ///     The  ampersand sdl keycode
        /// </summary>
        Ampersand = '&',
        
        /// <summary>
        ///     The  quote sdl keycode
        /// </summary>
        Quote = '\'',
        
        /// <summary>
        ///     The  left paren sdl keycode
        /// </summary>
        Leftparen = '(',
        
        /// <summary>
        ///     The  right paren sdl keycode
        /// </summary>
        RightParen = ')',
        
        /// <summary>
        ///     The  asterisk sdl keycode
        /// </summary>
        Asterisk = '*',
        
        /// <summary>
        ///     The  plus sdl keycode
        /// </summary>
        Plus = '+',
        
        /// <summary>
        ///     The  comma sdl keycode
        /// </summary>
        Comma = ',',
        
        /// <summary>
        ///     The  minus sdl keycode
        /// </summary>
        Minus = '-',
        
        /// <summary>
        ///     The  period sdl keycode
        /// </summary>
        Period = '.',
        
        /// <summary>
        ///     The  slash sdl keycode
        /// </summary>
        Slash = '/',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        Num0 = '0',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        Num1 = '1',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        Num2 = '2',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        Num3 = '3',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        Num4 = '4',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        Num5 = '5',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        Num6 = '6',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        Num7 = '7',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        Num8 = '8',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        Num9 = '9',
        
        /// <summary>
        ///     The  colon sdl keycode
        /// </summary>
        Colon = ':',
        
        /// <summary>
        ///     The  semicolon sdl keycode
        /// </summary>
        Semicolon = ';',
        
        /// <summary>
        ///     The  less sdl keycode
        /// </summary>
        Less = '<',
        
        /// <summary>
        ///     The  equals sdl keycode
        /// </summary>
        Equals = '=',
        
        /// <summary>
        ///     The  greater sdl keycode
        /// </summary>
        Greater = '>',
        
        /// <summary>
        ///     The  question sdl keycode
        /// </summary>
        Question = '?',
        
        /// <summary>
        ///     The  at sdl keycode
        /// </summary>
        At = '@',
        
        /*
            Skip uppercase letters
            */
        /// <summary>
        ///     The  leftbracket sdl keycode
        /// </summary>
        Leftbracket = '[',
        
        /// <summary>
        ///     The  backslash sdl keycode
        /// </summary>
        Backslash = '\\',
        
        /// <summary>
        ///     The  rightbracket sdl keycode
        /// </summary>
        Rightbracket = ']',
        
        /// <summary>
        ///     The  caret sdl keycode
        /// </summary>
        Caret = '^',
        
        /// <summary>
        ///     The  underscore sdl keycode
        /// </summary>
        Underscore = '_',
        
        /// <summary>
        ///     The  backquote sdl keycode
        /// </summary>
        Backquote = '`',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        A = 'a',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        B = 'b',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        C = 'c',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        D = 'd',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        E = 'e',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        F = 'f',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        G = 'g',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        H = 'h',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        I = 'i',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        J = 'j',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        K = 'k',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        L = 'l',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        M = 'm',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        N = 'n',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        O = 'o',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        P = 'p',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        Q = 'q',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        R = 'r',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        S = 's',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        T = 't',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        U = 'u',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        V = 'v',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        W = 'w',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        X = 'x',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        Y = 'y',
        
        /// <summary>
        ///     The  sdl keycode
        /// </summary>
        Z = 'z',
        
        /// <summary>
        ///     The  capslock sdl keycode
        /// </summary>
        Capslock = SdlScancode.SdlScancodeCapslock | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  f1 sdl keycode
        /// </summary>
        F1 = SdlScancode.SdlScancodeF1 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  f2 sdl keycode
        /// </summary>
        F2 = SdlScancode.SdlScancodeF2 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  f3 sdl keycode
        /// </summary>
        F3 = SdlScancode.SdlScancodeF3 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  f4 sdl keycode
        /// </summary>
        F4 = SdlScancode.SdlScancodeF4 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  f5 sdl keycode
        /// </summary>
        F5 = SdlScancode.SdlScancodeF5 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  f6 sdl keycode
        /// </summary>
        F6 = SdlScancode.SdlScancodeF6 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  f7 sdl keycode
        /// </summary>
        F7 = SdlScancode.SdlScancodeF7 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  f8 sdl keycode
        /// </summary>
        F8 = SdlScancode.SdlScancodeF8 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  f9 sdl keycode
        /// </summary>
        F9 = SdlScancode.SdlScancodeF9 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  f10 sdl keycode
        /// </summary>
        F10 = SdlScancode.SdlScancodeF10 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  f11 sdl keycode
        /// </summary>
        F11 = SdlScancode.SdlScancodeF11 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  f12 sdl keycode
        /// </summary>
        F12 = SdlScancode.SdlScancodeF12 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  printscreen sdl keycode
        /// </summary>
        Printscreen = SdlScancode.SdlScancodePrintscreen | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  scrolllock sdl keycode
        /// </summary>
        Scrolllock = SdlScancode.SdlScancodeScrolllock | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  pause sdl keycode
        /// </summary>
        Pause = SdlScancode.SdlScancodePause | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  insert sdl keycode
        /// </summary>
        Insert = SdlScancode.SdlScancodeInsert | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  home sdl keycode
        /// </summary>
        Home = SdlScancode.SdlScancodeHome | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  pageup sdl keycode
        /// </summary>
        Pageup = SdlScancode.SdlScancodePageup | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  delete sdl keycode
        /// </summary>
        Delete = 127,
        
        /// <summary>
        ///     The  end sdl keycode
        /// </summary>
        End = SdlScancode.SdlScancodeEnd | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  pagedown sdl keycode
        /// </summary>
        Pagedown = SdlScancode.SdlScancodePagedown | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  right sdl keycode
        /// </summary>
        Right = SdlScancode.SdlScancodeRight | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  left sdl keycode
        /// </summary>
        Left = SdlScancode.SdlScancodeLeft | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  down sdl keycode
        /// </summary>
        Down = SdlScancode.SdlScancodeDown | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  up sdl keycode
        /// </summary>
        Up = SdlScancode.SdlScancodeUp | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  numlockclear sdl keycode
        /// </summary>
        Numlockclear = SdlScancode.SdlScancodeNumlockclear | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp divide sdl keycode
        /// </summary>
        KpDivide = SdlScancode.SdlScancodeKpDivide | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp multiply sdl keycode
        /// </summary>
        KpMultiply = SdlScancode.SdlScancodeKpMultiply | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp minus sdl keycode
        /// </summary>
        KpMinus = SdlScancode.SdlScancodeKpMinus | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp plus sdl keycode
        /// </summary>
        KpPlus = SdlScancode.SdlScancodeKpPlus | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp enter sdl keycode
        /// </summary>
        KpEnter = SdlScancode.SdlScancodeKpEnter | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp sdl keycode
        /// </summary>
        Kp1 = SdlScancode.SdlScancodeKp1 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp sdl keycode
        /// </summary>
        Kp2 = SdlScancode.SdlScancodeKp2 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp sdl keycode
        /// </summary>
        Kp3 = SdlScancode.SdlScancodeKp3 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp sdl keycode
        /// </summary>
        Kp4 = SdlScancode.SdlScancodeKp4 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp sdl keycode
        /// </summary>
        Kp5 = SdlScancode.SdlScancodeKp5 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp sdl keycode
        /// </summary>
        Kp6 = SdlScancode.SdlScancodeKp6 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp sdl keycode
        /// </summary>
        Kp7 = SdlScancode.SdlScancodeKp7 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp sdl keycode
        /// </summary>
        Kp8 = SdlScancode.SdlScancodeKp8 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp sdl keycode
        /// </summary>
        Kp9 = SdlScancode.SdlScancodeKp9 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp sdl keycode
        /// </summary>
        Kp0 = SdlScancode.SdlScancodeKp0 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp period sdl keycode
        /// </summary>
        KpPeriod = SdlScancode.SdlScancodeKpPeriod | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  application sdl keycode
        /// </summary>
        Application = SdlScancode.SdlScancodeApplication | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  power sdl keycode
        /// </summary>
        Power = SdlScancode.SdlScancodePower | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp equals sdl keycode
        /// </summary>
        KpEquals = SdlScancode.SdlScancodeKpEquals | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  f13 sdl keycode
        /// </summary>
        F13 = SdlScancode.SdlScancodeF13 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  f14 sdl keycode
        /// </summary>
        F14 = SdlScancode.SdlScancodeF14 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  f15 sdl keycode
        /// </summary>
        F15 = SdlScancode.SdlScancodeF15 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  f16 sdl keycode
        /// </summary>
        F16 = SdlScancode.SdlScancodeF16 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  f17 sdl keycode
        /// </summary>
        F17 = SdlScancode.SdlScancodeF17 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  f18 sdl keycode
        /// </summary>
        F18 = SdlScancode.SdlScancodeF18 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  f19 sdl keycode
        /// </summary>
        F19 = SdlScancode.SdlScancodeF19 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  f20 sdl keycode
        /// </summary>
        F20 = SdlScancode.SdlScancodeF20 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  f21 sdl keycode
        /// </summary>
        F21 = SdlScancode.SdlScancodeF21 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  f22 sdl keycode
        /// </summary>
        F22 = SdlScancode.SdlScancodeF22 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  f23 sdl keycode
        /// </summary>
        F23 = SdlScancode.SdlScancodeF23 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  f24 sdl keycode
        /// </summary>
        F24 = SdlScancode.SdlScancodeF24 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  execute sdl keycode
        /// </summary>
        Execute = SdlScancode.SdlScancodeExecute | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  help sdl keycode
        /// </summary>
        Help = SdlScancode.SdlScancodeHelp | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  menu sdl keycode
        /// </summary>
        Menu = SdlScancode.SdlScancodeMenu | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  select sdl keycode
        /// </summary>
        Select = SdlScancode.SdlScancodeSelect | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  stop sdl keycode
        /// </summary>
        Stop = SdlScancode.SdlScancodeStop | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  again sdl keycode
        /// </summary>
        Again = SdlScancode.SdlScancodeAgain | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  undo sdl keycode
        /// </summary>
        Undo = SdlScancode.SdlScancodeUndo | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  cut sdl keycode
        /// </summary>
        Cut = SdlScancode.SdlScancodeCut | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  copy sdl keycode
        /// </summary>
        Copy = SdlScancode.SdlScancodeCopy | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  paste sdl keycode
        /// </summary>
        Paste = SdlScancode.SdlScancodePaste | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  find sdl keycode
        /// </summary>
        Find = SdlScancode.SdlScancodeFind | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  mute sdl keycode
        /// </summary>
        Mute = SdlScancode.SdlScancodeMute | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  volumeup sdl keycode
        /// </summary>
        Volumeup = SdlScancode.SdlScancodeVolumeup | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  volumedown sdl keycode
        /// </summary>
        Volumedown = SdlScancode.SdlScancodeVolumedown | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp comma sdl keycode
        /// </summary>
        KpComma = SdlScancode.SdlScancodeKpComma | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp equalsas400 sdl keycode
        /// </summary>
        KpEqualsas400 =
            SdlScancode.SdlScancodeKpEqualsas400 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  alterase sdl keycode
        /// </summary>
        Alterase = SdlScancode.SdlScancodeAlterase | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  sysreq sdl keycode
        /// </summary>
        Sysreq = SdlScancode.SdlScancodeSysreq | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  cancel sdl keycode
        /// </summary>
        Cancel = SdlScancode.SdlScancodeCancel | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  clear sdl keycode
        /// </summary>
        Clear = SdlScancode.SdlScancodeClear | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  prior sdl keycode
        /// </summary>
        Prior = SdlScancode.SdlScancodePrior | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  return2 sdl keycode
        /// </summary>
        Return2 = SdlScancode.SdlScancodeReturn2 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  separator sdl keycode
        /// </summary>
        Separator = SdlScancode.SdlScancodeSeparator | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  out sdl keycode
        /// </summary>
        Out = SdlScancode.SdlScancodeOut | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  oper sdl keycode
        /// </summary>
        Oper = SdlScancode.SdlScancodeOper | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  clearagain sdl keycode
        /// </summary>
        Clearagain = SdlScancode.SdlScancodeClearagain | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  crsel sdl keycode
        /// </summary>
        Crsel = SdlScancode.SdlScancodeCrsel | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  exsel sdl keycode
        /// </summary>
        Exsel = SdlScancode.SdlScancodeExsel | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp 00 sdl keycode
        /// </summary>
        Kp00 = SdlScancode.SdlScancodeKp00 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp 000 sdl keycode
        /// </summary>
        Kp000 = SdlScancode.SdlScancodeKp000 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  thousandsseparator sdl keycode
        /// </summary>
        Thousandsseparator =
            SdlScancode.SdlScancodeThousandsseparator | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  decimalseparator sdl keycode
        /// </summary>
        Decimalseparator =
            SdlScancode.SdlScancodeDecimalseparator | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  currencyunit sdl keycode
        /// </summary>
        Currencyunit = SdlScancode.SdlScancodeCurrencyunit | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  currencysubunit sdl keycode
        /// </summary>
        Currencysubunit =
            SdlScancode.SdlScancodeCurrencysubunit | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp leftparen sdl keycode
        /// </summary>
        KpLeftparen = SdlScancode.SdlScancodeKpLeftparen | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp rightparen sdl keycode
        /// </summary>
        KpRightparen = SdlScancode.SdlScancodeKpRightparen | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp leftbrace sdl keycode
        /// </summary>
        KpLeftbrace = SdlScancode.SdlScancodeKpLeftbrace | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp rightbrace sdl keycode
        /// </summary>
        KpRightbrace = SdlScancode.SdlScancodeKpRightbrace | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp tab sdl keycode
        /// </summary>
        KpTab = SdlScancode.SdlScancodeKpTab | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp backspace sdl keycode
        /// </summary>
        KpBackspace = SdlScancode.SdlScancodeKpBackspace | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp sdl keycode
        /// </summary>
        KpA = SdlScancode.SdlScancodeKpA | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp sdl keycode
        /// </summary>
        KpB = SdlScancode.SdlScancodeKpB | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp sdl keycode
        /// </summary>
        KpC = SdlScancode.SdlScancodeKpC | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp sdl keycode
        /// </summary>
        KpD = SdlScancode.SdlScancodeKpD | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp sdl keycode
        /// </summary>
        KpE = SdlScancode.SdlScancodeKpE | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp sdl keycode
        /// </summary>
        KpF = SdlScancode.SdlScancodeKpF | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp xor sdl keycode
        /// </summary>
        KpXor = SdlScancode.SdlScancodeKpXor | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp power sdl keycode
        /// </summary>
        KpPower = SdlScancode.SdlScancodeKpPower | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp percent sdl keycode
        /// </summary>
        KpPercent = SdlScancode.SdlScancodeKpPercent | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp less sdl keycode
        /// </summary>
        KpLess = SdlScancode.SdlScancodeKpLess | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp greater sdl keycode
        /// </summary>
        KpGreater = SdlScancode.SdlScancodeKpGreater | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp ampersand sdl keycode
        /// </summary>
        KpAmpersand = SdlScancode.SdlScancodeKpAmpersand | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp dblampersand sdl keycode
        /// </summary>
        KpDblampersand =
            SdlScancode.SdlScancodeKpDblampersand | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp verticalbar sdl keycode
        /// </summary>
        KpVerticalbar =
            SdlScancode.SdlScancodeKpVerticalbar | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp dblverticalbar sdl keycode
        /// </summary>
        KpDblverticalbar =
            SdlScancode.SdlScancodeKpDblverticalbar | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp colon sdl keycode
        /// </summary>
        KpColon = SdlScancode.SdlScancodeKpColon | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp hash sdl keycode
        /// </summary>
        KpHash = SdlScancode.SdlScancodeKpHash | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp space sdl keycode
        /// </summary>
        KpSpace = SdlScancode.SdlScancodeKpSpace | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp at sdl keycode
        /// </summary>
        KpAt = SdlScancode.SdlScancodeKpAt | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp exclam sdl keycode
        /// </summary>
        KpExclam = SdlScancode.SdlScancodeKpExclam | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp memstore sdl keycode
        /// </summary>
        KpMemstore = SdlScancode.SdlScancodeKpMemstore | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp memrecall sdl keycode
        /// </summary>
        KpMemrecall = SdlScancode.SdlScancodeKpMemrecall | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp memclear sdl keycode
        /// </summary>
        KpMemclear = SdlScancode.SdlScancodeKpMemclear | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp memadd sdl keycode
        /// </summary>
        KpMemadd = SdlScancode.SdlScancodeKpMemadd | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp memsubtract sdl keycode
        /// </summary>
        KpMemsubtract =
            SdlScancode.SdlScancodeKpMemsubtract | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp memmultiply sdl keycode
        /// </summary>
        KpMemmultiply =
            SdlScancode.SdlScancodeKpMemmultiply | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp memdivide sdl keycode
        /// </summary>
        KpMemdivide = SdlScancode.SdlScancodeKpMemdivide | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp plusminus sdl keycode
        /// </summary>
        KpPlusminus = SdlScancode.SdlScancodeKpPlusminus | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp clear sdl keycode
        /// </summary>
        KpClear = SdlScancode.SdlScancodeKpClear | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp clearentry sdl keycode
        /// </summary>
        KpClearentry = SdlScancode.SdlScancodeKpClearentry | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp binary sdl keycode
        /// </summary>
        KpBinary = SdlScancode.SdlScancodeKpBinary | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp octal sdl keycode
        /// </summary>
        KpOctal = SdlScancode.SdlScancodeKpOctal | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp decimal sdl keycode
        /// </summary>
        KpDecimal = SdlScancode.SdlScancodeKpDecimal | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kp hexadecimal sdl keycode
        /// </summary>
        KpHexadecimal =
            SdlScancode.SdlScancodeKpHexadecimal | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  lctrl sdl keycode
        /// </summary>
        Lctrl = SdlScancode.SdlScancodeLctrl | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  lshift sdl keycode
        /// </summary>
        Lshift = SdlScancode.SdlScancodeLshift | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  lalt sdl keycode
        /// </summary>
        Lalt = SdlScancode.SdlScancodeLalt | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  lgui sdl keycode
        /// </summary>
        Lgui = SdlScancode.SdlScancodeLgui | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  rctrl sdl keycode
        /// </summary>
        Rctrl = SdlScancode.SdlScancodeRctrl | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  rshift sdl keycode
        /// </summary>
        Rshift = SdlScancode.SdlScancodeRshift | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  ralt sdl keycode
        /// </summary>
        Ralt = SdlScancode.SdlScancodeRalt | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  rgui sdl keycode
        /// </summary>
        Rgui = SdlScancode.SdlScancodeRgui | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  mode sdl keycode
        /// </summary>
        Mode = SdlScancode.SdlScancodeMode | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  audionext sdl keycode
        /// </summary>
        Audionext = SdlScancode.SdlScancodeAudionext | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  audioprev sdl keycode
        /// </summary>
        Audioprev = SdlScancode.SdlScancodeAudioprev | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  audiostop sdl keycode
        /// </summary>
        Audiostop = SdlScancode.SdlScancodeAudiostop | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  audioplay sdl keycode
        /// </summary>
        Audioplay = SdlScancode.SdlScancodeAudioplay | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  audiomute sdl keycode
        /// </summary>
        Audiomute = SdlScancode.SdlScancodeAudiomute | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  mediaselect sdl keycode
        /// </summary>
        Mediaselect = SdlScancode.SdlScancodeMediaselect | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  www sdl keycode
        /// </summary>
        Www = SdlScancode.SdlScancodeWww | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  mail sdl keycode
        /// </summary>
        Mail = SdlScancode.SdlScancodeMail | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  calculator sdl keycode
        /// </summary>
        Calculator = SdlScancode.SdlScancodeCalculator | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  computer sdl keycode
        /// </summary>
        Computer = SdlScancode.SdlScancodeComputer | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  ac search sdl keycode
        /// </summary>
        AcSearch = SdlScancode.SdlScancodeAcSearch | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  ac home sdl keycode
        /// </summary>
        AcHome = SdlScancode.SdlScancodeAcHome | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  ac back sdl keycode
        /// </summary>
        AcBack = SdlScancode.SdlScancodeAcBack | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  ac forward sdl keycode
        /// </summary>
        AcForward = SdlScancode.SdlScancodeAcForward | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  ac stop sdl keycode
        /// </summary>
        AcStop = SdlScancode.SdlScancodeAcStop | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  ac refresh sdl keycode
        /// </summary>
        AcRefresh = SdlScancode.SdlScancodeAcRefresh | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  ac bookmarks sdl keycode
        /// </summary>
        AcBookmarks = SdlScancode.SdlScancodeAcBookmarks | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  brightnessdown sdl keycode
        /// </summary>
        Brightnessdown =
            SdlScancode.SdlScancodeBrightnessdown | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  brightnessup sdl keycode
        /// </summary>
        Brightnessup = SdlScancode.SdlScancodeBrightnessup | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  displayswitch sdl keycode
        /// </summary>
        Displayswitch = SdlScancode.SdlScancodeDisplayswitch | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kbdillumtoggle sdl keycode
        /// </summary>
        Kbdillumtoggle =
            SdlScancode.SdlScancodeKbdillumtoggle | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kbdillumdown sdl keycode
        /// </summary>
        Kbdillumdown = SdlScancode.SdlScancodeKbdillumdown | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  kbdillumup sdl keycode
        /// </summary>
        Kbdillumup = SdlScancode.SdlScancodeKbdillumup | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  eject sdl keycode
        /// </summary>
        Eject = SdlScancode.SdlScancodeEject | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  sleep sdl keycode
        /// </summary>
        Sleep = SdlScancode.SdlScancodeSleep | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  app1 sdl keycode
        /// </summary>
        App1 = SdlScancode.SdlScancodeApp1 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  app2 sdl keycode
        /// </summary>
        App2 = SdlScancode.SdlScancodeApp2 | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  audiorewind sdl keycode
        /// </summary>
        Audiorewind = SdlScancode.SdlScancodeAudiorewind | SdlInputConst.KScancodeMask,
        
        /// <summary>
        ///     The  audiofastforward sdl keycode
        /// </summary>
        Audiofastforward = SdlScancode.SdlScancodeAudiofastforward | SdlInputConst.KScancodeMask
    }
}