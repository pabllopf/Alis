// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlKeycode.cs
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

namespace Alis.App.Engine.SDL.Enums
{
    /// <summary>
    ///     The sdl keycode enum
    /// </summary>
    public enum SdlKeycode
    {
        /// <summary>
        ///     The sdlk unknown sdl keycode
        /// </summary>
        SdlkUnknown = 0,

        /// <summary>
        ///     The sdlk return sdl keycode
        /// </summary>
        SdlkReturn = '\r',

        /// <summary>
        ///     The sdlk escape sdl keycode
        /// </summary>
        SdlkEscape = 27, // '\033'

        /// <summary>
        ///     The sdlk backspace sdl keycode
        /// </summary>
        SdlkBackspace = '\b',

        /// <summary>
        ///     The sdlk tab sdl keycode
        /// </summary>
        SdlkTab = '\t',

        /// <summary>
        ///     The sdlk space sdl keycode
        /// </summary>
        SdlkSpace = ' ',

        /// <summary>
        ///     The sdlk exclaim sdl keycode
        /// </summary>
        SdlkExclaim = '!',

        /// <summary>
        ///     The sdlk quotedbl sdl keycode
        /// </summary>
        SdlkQuotedbl = '"',

        /// <summary>
        ///     The sdlk hash sdl keycode
        /// </summary>
        SdlkHash = '#',

        /// <summary>
        ///     The sdlk percent sdl keycode
        /// </summary>
        SdlkPercent = '%',

        /// <summary>
        ///     The sdlk dollar sdl keycode
        /// </summary>
        SdlkDollar = '$',

        /// <summary>
        ///     The sdlk ampersand sdl keycode
        /// </summary>
        SdlkAmpersand = '&',

        /// <summary>
        ///     The sdlk quote sdl keycode
        /// </summary>
        SdlkQuote = '\'',

        /// <summary>
        ///     The sdlk leftparen sdl keycode
        /// </summary>
        SdlkLeftparen = '(',

        /// <summary>
        ///     The sdlk rightparen sdl keycode
        /// </summary>
        SdlkRightparen = ')',

        /// <summary>
        ///     The sdlk asterisk sdl keycode
        /// </summary>
        SdlkAsterisk = '*',

        /// <summary>
        ///     The sdlk plus sdl keycode
        /// </summary>
        SdlkPlus = '+',

        /// <summary>
        ///     The sdlk comma sdl keycode
        /// </summary>
        SdlkComma = ',',

        /// <summary>
        ///     The sdlk minus sdl keycode
        /// </summary>
        SdlkMinus = '-',

        /// <summary>
        ///     The sdlk period sdl keycode
        /// </summary>
        SdlkPeriod = '.',

        /// <summary>
        ///     The sdlk slash sdl keycode
        /// </summary>
        SdlkSlash = '/',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        Sdlk0 = '0',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        Sdlk1 = '1',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        Sdlk2 = '2',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        Sdlk3 = '3',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        Sdlk4 = '4',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        Sdlk5 = '5',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        Sdlk6 = '6',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        Sdlk7 = '7',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        Sdlk8 = '8',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        Sdlk9 = '9',

        /// <summary>
        ///     The sdlk colon sdl keycode
        /// </summary>
        SdlkColon = ':',

        /// <summary>
        ///     The sdlk semicolon sdl keycode
        /// </summary>
        SdlkSemicolon = ';',

        /// <summary>
        ///     The sdlk less sdl keycode
        /// </summary>
        SdlkLess = '<',

        /// <summary>
        ///     The sdlk equals sdl keycode
        /// </summary>
        SdlkEquals = '=',

        /// <summary>
        ///     The sdlk greater sdl keycode
        /// </summary>
        SdlkGreater = '>',

        /// <summary>
        ///     The sdlk question sdl keycode
        /// </summary>
        SdlkQuestion = '?',

        /// <summary>
        ///     The sdlk at sdl keycode
        /// </summary>
        SdlkAt = '@',

        /*
            Skip uppercase letters
            */
        /// <summary>
        ///     The sdlk leftbracket sdl keycode
        /// </summary>
        SdlkLeftbracket = '[',

        /// <summary>
        ///     The sdlk backslash sdl keycode
        /// </summary>
        SdlkBackslash = '\\',

        /// <summary>
        ///     The sdlk rightbracket sdl keycode
        /// </summary>
        SdlkRightbracket = ']',

        /// <summary>
        ///     The sdlk caret sdl keycode
        /// </summary>
        SdlkCaret = '^',

        /// <summary>
        ///     The sdlk underscore sdl keycode
        /// </summary>
        SdlkUnderscore = '_',

        /// <summary>
        ///     The sdlk backquote sdl keycode
        /// </summary>
        SdlkBackquote = '`',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkA = 'a',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkB = 'b',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkC = 'c',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkD = 'd',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkE = 'e',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkF = 'f',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkG = 'g',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkH = 'h',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkI = 'i',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkJ = 'j',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkK = 'k',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkL = 'l',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkM = 'm',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkN = 'n',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkO = 'o',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkP = 'p',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkQ = 'q',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkR = 'r',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkS = 's',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkT = 't',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkU = 'u',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkV = 'v',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkW = 'w',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkX = 'x',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkY = 'y',

        /// <summary>
        ///     The sdlk sdl keycode
        /// </summary>
        SdlkZ = 'z',

        /// <summary>
        ///     The sdlk capslock sdl keycode
        /// </summary>
        SdlkCapslock = SdlScancode.SdlScancodeCapslock | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk f1 sdl keycode
        /// </summary>
        SdlkF1 = SdlScancode.SdlScancodeF1 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk f2 sdl keycode
        /// </summary>
        SdlkF2 = SdlScancode.SdlScancodeF2 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk f3 sdl keycode
        /// </summary>
        SdlkF3 = SdlScancode.SdlScancodeF3 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk f4 sdl keycode
        /// </summary>
        SdlkF4 = SdlScancode.SdlScancodeF4 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk f5 sdl keycode
        /// </summary>
        SdlkF5 = SdlScancode.SdlScancodeF5 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk f6 sdl keycode
        /// </summary>
        SdlkF6 = SdlScancode.SdlScancodeF6 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk f7 sdl keycode
        /// </summary>
        SdlkF7 = SdlScancode.SdlScancodeF7 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk f8 sdl keycode
        /// </summary>
        SdlkF8 = SdlScancode.SdlScancodeF8 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk f9 sdl keycode
        /// </summary>
        SdlkF9 = SdlScancode.SdlScancodeF9 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk f10 sdl keycode
        /// </summary>
        SdlkF10 = SdlScancode.SdlScancodeF10 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk f11 sdl keycode
        /// </summary>
        SdlkF11 = SdlScancode.SdlScancodeF11 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk f12 sdl keycode
        /// </summary>
        SdlkF12 = SdlScancode.SdlScancodeF12 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk printscreen sdl keycode
        /// </summary>
        SdlkPrintscreen = SdlScancode.SdlScancodePrintscreen | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk scrolllock sdl keycode
        /// </summary>
        SdlkScrolllock = SdlScancode.SdlScancodeScrolllock | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk pause sdl keycode
        /// </summary>
        SdlkPause = SdlScancode.SdlScancodePause | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk insert sdl keycode
        /// </summary>
        SdlkInsert = SdlScancode.SdlScancodeInsert | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk home sdl keycode
        /// </summary>
        SdlkHome = SdlScancode.SdlScancodeHome | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk pageup sdl keycode
        /// </summary>
        SdlkPageup = SdlScancode.SdlScancodePageup | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk delete sdl keycode
        /// </summary>
        SdlkDelete = 127,

        /// <summary>
        ///     The sdlk end sdl keycode
        /// </summary>
        SdlkEnd = SdlScancode.SdlScancodeEnd | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk pagedown sdl keycode
        /// </summary>
        SdlkPagedown = SdlScancode.SdlScancodePagedown | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk right sdl keycode
        /// </summary>
        SdlkRight = SdlScancode.SdlScancodeRight | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk left sdl keycode
        /// </summary>
        SdlkLeft = SdlScancode.SdlScancodeLeft | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk down sdl keycode
        /// </summary>
        SdlkDown = SdlScancode.SdlScancodeDown | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk up sdl keycode
        /// </summary>
        SdlkUp = SdlScancode.SdlScancodeUp | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk numlockclear sdl keycode
        /// </summary>
        SdlkNumlockclear = SdlScancode.SdlScancodeNumlockclear | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp divide sdl keycode
        /// </summary>
        SdlkKpDivide = SdlScancode.SdlScancodeKpDivide | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp multiply sdl keycode
        /// </summary>
        SdlkKpMultiply = SdlScancode.SdlScancodeKpMultiply | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp minus sdl keycode
        /// </summary>
        SdlkKpMinus = SdlScancode.SdlScancodeKpMinus | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp plus sdl keycode
        /// </summary>
        SdlkKpPlus = SdlScancode.SdlScancodeKpPlus | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp enter sdl keycode
        /// </summary>
        SdlkKpEnter = SdlScancode.SdlScancodeKpEnter | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp sdl keycode
        /// </summary>
        SdlkKp1 = SdlScancode.SdlScancodeKp1 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp sdl keycode
        /// </summary>
        SdlkKp2 = SdlScancode.SdlScancodeKp2 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp sdl keycode
        /// </summary>
        SdlkKp3 = SdlScancode.SdlScancodeKp3 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp sdl keycode
        /// </summary>
        SdlkKp4 = SdlScancode.SdlScancodeKp4 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp sdl keycode
        /// </summary>
        SdlkKp5 = SdlScancode.SdlScancodeKp5 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp sdl keycode
        /// </summary>
        SdlkKp6 = SdlScancode.SdlScancodeKp6 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp sdl keycode
        /// </summary>
        SdlkKp7 = SdlScancode.SdlScancodeKp7 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp sdl keycode
        /// </summary>
        SdlkKp8 = SdlScancode.SdlScancodeKp8 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp sdl keycode
        /// </summary>
        SdlkKp9 = SdlScancode.SdlScancodeKp9 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp sdl keycode
        /// </summary>
        SdlkKp0 = SdlScancode.SdlScancodeKp0 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp period sdl keycode
        /// </summary>
        SdlkKpPeriod = SdlScancode.SdlScancodeKpPeriod | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk application sdl keycode
        /// </summary>
        SdlkApplication = SdlScancode.SdlScancodeApplication | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk power sdl keycode
        /// </summary>
        SdlkPower = SdlScancode.SdlScancodePower | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp equals sdl keycode
        /// </summary>
        SdlkKpEquals = SdlScancode.SdlScancodeKpEquals | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk f13 sdl keycode
        /// </summary>
        SdlkF13 = SdlScancode.SdlScancodeF13 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk f14 sdl keycode
        /// </summary>
        SdlkF14 = SdlScancode.SdlScancodeF14 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk f15 sdl keycode
        /// </summary>
        SdlkF15 = SdlScancode.SdlScancodeF15 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk f16 sdl keycode
        /// </summary>
        SdlkF16 = SdlScancode.SdlScancodeF16 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk f17 sdl keycode
        /// </summary>
        SdlkF17 = SdlScancode.SdlScancodeF17 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk f18 sdl keycode
        /// </summary>
        SdlkF18 = SdlScancode.SdlScancodeF18 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk f19 sdl keycode
        /// </summary>
        SdlkF19 = SdlScancode.SdlScancodeF19 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk f20 sdl keycode
        /// </summary>
        SdlkF20 = SdlScancode.SdlScancodeF20 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk f21 sdl keycode
        /// </summary>
        SdlkF21 = SdlScancode.SdlScancodeF21 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk f22 sdl keycode
        /// </summary>
        SdlkF22 = SdlScancode.SdlScancodeF22 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk f23 sdl keycode
        /// </summary>
        SdlkF23 = SdlScancode.SdlScancodeF23 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk f24 sdl keycode
        /// </summary>
        SdlkF24 = SdlScancode.SdlScancodeF24 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk execute sdl keycode
        /// </summary>
        SdlkExecute = SdlScancode.SdlScancodeExecute | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk help sdl keycode
        /// </summary>
        SdlkHelp = SdlScancode.SdlScancodeHelp | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk menu sdl keycode
        /// </summary>
        SdlkMenu = SdlScancode.SdlScancodeMenu | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk select sdl keycode
        /// </summary>
        SdlkSelect = SdlScancode.SdlScancodeSelect | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk stop sdl keycode
        /// </summary>
        SdlkStop = SdlScancode.SdlScancodeStop | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk again sdl keycode
        /// </summary>
        SdlkAgain = SdlScancode.SdlScancodeAgain | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk undo sdl keycode
        /// </summary>
        SdlkUndo = SdlScancode.SdlScancodeUndo | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk cut sdl keycode
        /// </summary>
        SdlkCut = SdlScancode.SdlScancodeCut | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk copy sdl keycode
        /// </summary>
        SdlkCopy = SdlScancode.SdlScancodeCopy | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk paste sdl keycode
        /// </summary>
        SdlkPaste = SdlScancode.SdlScancodePaste | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk find sdl keycode
        /// </summary>
        SdlkFind = SdlScancode.SdlScancodeFind | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk mute sdl keycode
        /// </summary>
        SdlkMute = SdlScancode.SdlScancodeMute | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk volumeup sdl keycode
        /// </summary>
        SdlkVolumeup = SdlScancode.SdlScancodeVolumeup | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk volumedown sdl keycode
        /// </summary>
        SdlkVolumedown = SdlScancode.SdlScancodeVolumedown | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp comma sdl keycode
        /// </summary>
        SdlkKpComma = SdlScancode.SdlScancodeKpComma | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp equalsas400 sdl keycode
        /// </summary>
        SdlkKpEqualsas400 =
            SdlScancode.SdlScancodeKpEqualsas400 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk alterase sdl keycode
        /// </summary>
        SdlkAlterase = SdlScancode.SdlScancodeAlterase | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk sysreq sdl keycode
        /// </summary>
        SdlkSysreq = SdlScancode.SdlScancodeSysreq | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk cancel sdl keycode
        /// </summary>
        SdlkCancel = SdlScancode.SdlScancodeCancel | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk clear sdl keycode
        /// </summary>
        SdlkClear = SdlScancode.SdlScancodeClear | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk prior sdl keycode
        /// </summary>
        SdlkPrior = SdlScancode.SdlScancodePrior | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk return2 sdl keycode
        /// </summary>
        SdlkReturn2 = SdlScancode.SdlScancodeReturn2 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk separator sdl keycode
        /// </summary>
        SdlkSeparator = SdlScancode.SdlScancodeSeparator | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk out sdl keycode
        /// </summary>
        SdlkOut = SdlScancode.SdlScancodeOut | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk oper sdl keycode
        /// </summary>
        SdlkOper = SdlScancode.SdlScancodeOper | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk clearagain sdl keycode
        /// </summary>
        SdlkClearagain = SdlScancode.SdlScancodeClearagain | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk crsel sdl keycode
        /// </summary>
        SdlkCrsel = SdlScancode.SdlScancodeCrsel | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk exsel sdl keycode
        /// </summary>
        SdlkExsel = SdlScancode.SdlScancodeExsel | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp 00 sdl keycode
        /// </summary>
        SdlkKp00 = SdlScancode.SdlScancodeKp00 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp 000 sdl keycode
        /// </summary>
        SdlkKp000 = SdlScancode.SdlScancodeKp000 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk thousandsseparator sdl keycode
        /// </summary>
        SdlkThousandsseparator =
            SdlScancode.SdlScancodeThousandsseparator | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk decimalseparator sdl keycode
        /// </summary>
        SdlkDecimalseparator =
            SdlScancode.SdlScancodeDecimalseparator | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk currencyunit sdl keycode
        /// </summary>
        SdlkCurrencyunit = SdlScancode.SdlScancodeCurrencyunit | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk currencysubunit sdl keycode
        /// </summary>
        SdlkCurrencysubunit =
            SdlScancode.SdlScancodeCurrencysubunit | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp leftparen sdl keycode
        /// </summary>
        SdlkKpLeftparen = SdlScancode.SdlScancodeKpLeftparen | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp rightparen sdl keycode
        /// </summary>
        SdlkKpRightparen = SdlScancode.SdlScancodeKpRightparen | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp leftbrace sdl keycode
        /// </summary>
        SdlkKpLeftbrace = SdlScancode.SdlScancodeKpLeftbrace | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp rightbrace sdl keycode
        /// </summary>
        SdlkKpRightbrace = SdlScancode.SdlScancodeKpRightbrace | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp tab sdl keycode
        /// </summary>
        SdlkKpTab = SdlScancode.SdlScancodeKpTab | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp backspace sdl keycode
        /// </summary>
        SdlkKpBackspace = SdlScancode.SdlScancodeKpBackspace | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp sdl keycode
        /// </summary>
        SdlkKpA = SdlScancode.SdlScancodeKpA | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp sdl keycode
        /// </summary>
        SdlkKpB = SdlScancode.SdlScancodeKpB | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp sdl keycode
        /// </summary>
        SdlkKpC = SdlScancode.SdlScancodeKpC | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp sdl keycode
        /// </summary>
        SdlkKpD = SdlScancode.SdlScancodeKpD | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp sdl keycode
        /// </summary>
        SdlkKpE = SdlScancode.SdlScancodeKpE | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp sdl keycode
        /// </summary>
        SdlkKpF = SdlScancode.SdlScancodeKpF | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp xor sdl keycode
        /// </summary>
        SdlkKpXor = SdlScancode.SdlScancodeKpXor | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp power sdl keycode
        /// </summary>
        SdlkKpPower = SdlScancode.SdlScancodeKpPower | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp percent sdl keycode
        /// </summary>
        SdlkKpPercent = SdlScancode.SdlScancodeKpPercent | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp less sdl keycode
        /// </summary>
        SdlkKpLess = SdlScancode.SdlScancodeKpLess | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp greater sdl keycode
        /// </summary>
        SdlkKpGreater = SdlScancode.SdlScancodeKpGreater | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp ampersand sdl keycode
        /// </summary>
        SdlkKpAmpersand = SdlScancode.SdlScancodeKpAmpersand | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp dblampersand sdl keycode
        /// </summary>
        SdlkKpDblampersand =
            SdlScancode.SdlScancodeKpDblampersand | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp verticalbar sdl keycode
        /// </summary>
        SdlkKpVerticalbar =
            SdlScancode.SdlScancodeKpVerticalbar | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp dblverticalbar sdl keycode
        /// </summary>
        SdlkKpDblverticalbar =
            SdlScancode.SdlScancodeKpDblverticalbar | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp colon sdl keycode
        /// </summary>
        SdlkKpColon = SdlScancode.SdlScancodeKpColon | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp hash sdl keycode
        /// </summary>
        SdlkKpHash = SdlScancode.SdlScancodeKpHash | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp space sdl keycode
        /// </summary>
        SdlkKpSpace = SdlScancode.SdlScancodeKpSpace | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp at sdl keycode
        /// </summary>
        SdlkKpAt = SdlScancode.SdlScancodeKpAt | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp exclam sdl keycode
        /// </summary>
        SdlkKpExclam = SdlScancode.SdlScancodeKpExclam | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp memstore sdl keycode
        /// </summary>
        SdlkKpMemstore = SdlScancode.SdlScancodeKpMemstore | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp memrecall sdl keycode
        /// </summary>
        SdlkKpMemrecall = SdlScancode.SdlScancodeKpMemrecall | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp memclear sdl keycode
        /// </summary>
        SdlkKpMemclear = SdlScancode.SdlScancodeKpMemclear | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp memadd sdl keycode
        /// </summary>
        SdlkKpMemadd = SdlScancode.SdlScancodeKpMemadd | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp memsubtract sdl keycode
        /// </summary>
        SdlkKpMemsubtract =
            SdlScancode.SdlScancodeKpMemsubtract | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp memmultiply sdl keycode
        /// </summary>
        SdlkKpMemmultiply =
            SdlScancode.SdlScancodeKpMemmultiply | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp memdivide sdl keycode
        /// </summary>
        SdlkKpMemdivide = SdlScancode.SdlScancodeKpMemdivide | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp plusminus sdl keycode
        /// </summary>
        SdlkKpPlusminus = SdlScancode.SdlScancodeKpPlusminus | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp clear sdl keycode
        /// </summary>
        SdlkKpClear = SdlScancode.SdlScancodeKpClear | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp clearentry sdl keycode
        /// </summary>
        SdlkKpClearentry = SdlScancode.SdlScancodeKpClearentry | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp binary sdl keycode
        /// </summary>
        SdlkKpBinary = SdlScancode.SdlScancodeKpBinary | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp octal sdl keycode
        /// </summary>
        SdlkKpOctal = SdlScancode.SdlScancodeKpOctal | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp decimal sdl keycode
        /// </summary>
        SdlkKpDecimal = SdlScancode.SdlScancodeKpDecimal | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kp hexadecimal sdl keycode
        /// </summary>
        SdlkKpHexadecimal =
            SdlScancode.SdlScancodeKpHexadecimal | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk lctrl sdl keycode
        /// </summary>
        SdlkLctrl = SdlScancode.SdlScancodeLctrl | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk lshift sdl keycode
        /// </summary>
        SdlkLshift = SdlScancode.SdlScancodeLshift | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk lalt sdl keycode
        /// </summary>
        SdlkLalt = SdlScancode.SdlScancodeLalt | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk lgui sdl keycode
        /// </summary>
        SdlkLgui = SdlScancode.SdlScancodeLgui | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk rctrl sdl keycode
        /// </summary>
        SdlkRctrl = SdlScancode.SdlScancodeRctrl | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk rshift sdl keycode
        /// </summary>
        SdlkRshift = SdlScancode.SdlScancodeRshift | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk ralt sdl keycode
        /// </summary>
        SdlkRalt = SdlScancode.SdlScancodeRalt | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk rgui sdl keycode
        /// </summary>
        SdlkRgui = SdlScancode.SdlScancodeRgui | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk mode sdl keycode
        /// </summary>
        SdlkMode = SdlScancode.SdlScancodeMode | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk audionext sdl keycode
        /// </summary>
        SdlkAudionext = SdlScancode.SdlScancodeAudionext | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk audioprev sdl keycode
        /// </summary>
        SdlkAudioprev = SdlScancode.SdlScancodeAudioprev | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk audiostop sdl keycode
        /// </summary>
        SdlkAudiostop = SdlScancode.SdlScancodeAudiostop | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk audioplay sdl keycode
        /// </summary>
        SdlkAudioplay = SdlScancode.SdlScancodeAudioplay | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk audiomute sdl keycode
        /// </summary>
        SdlkAudiomute = SdlScancode.SdlScancodeAudiomute | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk mediaselect sdl keycode
        /// </summary>
        SdlkMediaselect = SdlScancode.SdlScancodeMediaselect | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk www sdl keycode
        /// </summary>
        SdlkWww = SdlScancode.SdlScancodeWww | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk mail sdl keycode
        /// </summary>
        SdlkMail = SdlScancode.SdlScancodeMail | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk calculator sdl keycode
        /// </summary>
        SdlkCalculator = SdlScancode.SdlScancodeCalculator | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk computer sdl keycode
        /// </summary>
        SdlkComputer = SdlScancode.SdlScancodeComputer | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk ac search sdl keycode
        /// </summary>
        SdlkAcSearch = SdlScancode.SdlScancodeAcSearch | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk ac home sdl keycode
        /// </summary>
        SdlkAcHome = SdlScancode.SdlScancodeAcHome | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk ac back sdl keycode
        /// </summary>
        SdlkAcBack = SdlScancode.SdlScancodeAcBack | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk ac forward sdl keycode
        /// </summary>
        SdlkAcForward = SdlScancode.SdlScancodeAcForward | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk ac stop sdl keycode
        /// </summary>
        SdlkAcStop = SdlScancode.SdlScancodeAcStop | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk ac refresh sdl keycode
        /// </summary>
        SdlkAcRefresh = SdlScancode.SdlScancodeAcRefresh | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk ac bookmarks sdl keycode
        /// </summary>
        SdlkAcBookmarks = SdlScancode.SdlScancodeAcBookmarks | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk brightnessdown sdl keycode
        /// </summary>
        SdlkBrightnessdown =
            SdlScancode.SdlScancodeBrightnessdown | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk brightnessup sdl keycode
        /// </summary>
        SdlkBrightnessup = SdlScancode.SdlScancodeBrightnessup | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk displayswitch sdl keycode
        /// </summary>
        SdlkDisplayswitch = SdlScancode.SdlScancodeDisplayswitch | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kbdillumtoggle sdl keycode
        /// </summary>
        SdlkKbdillumtoggle =
            SdlScancode.SdlScancodeKbdillumtoggle | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kbdillumdown sdl keycode
        /// </summary>
        SdlkKbdillumdown = SdlScancode.SdlScancodeKbdillumdown | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk kbdillumup sdl keycode
        /// </summary>
        SdlkKbdillumup = SdlScancode.SdlScancodeKbdillumup | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk eject sdl keycode
        /// </summary>
        SdlkEject = SdlScancode.SdlScancodeEject | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk sleep sdl keycode
        /// </summary>
        SdlkSleep = SdlScancode.SdlScancodeSleep | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk app1 sdl keycode
        /// </summary>
        SdlkApp1 = SdlScancode.SdlScancodeApp1 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk app2 sdl keycode
        /// </summary>
        SdlkApp2 = SdlScancode.SdlScancodeApp2 | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk audiorewind sdl keycode
        /// </summary>
        SdlkAudiorewind = SdlScancode.SdlScancodeAudiorewind | Sdl.KScancodeMask,

        /// <summary>
        ///     The sdlk audiofastforward sdl keycode
        /// </summary>
        SdlkAudiofastforward = SdlScancode.SdlScancodeAudiofastforward | Sdl.KScancodeMask
    }
}