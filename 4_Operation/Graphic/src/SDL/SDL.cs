// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SDL.cs
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

#region Using Statements

using System;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Base.Dll;
using Alis.Core.Graphic.Properties;

#endregion

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl class
    /// </summary>
    public static class Sdl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sdl"/> class
        /// </summary>
        static Sdl()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                switch (RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.Arm64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2.dylib", NativeGraphic.osx_arm64_sdl2);
                        break;
                    case Architecture.X64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2.dylib", NativeGraphic.osx_x64_sdl2);
                        break;
                }
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                switch (RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.Arm64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2.dll", NativeGraphic.win_arm64_sdl2);
                        break;
                    case Architecture.X86:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2.dll", NativeGraphic.win_x86_sdl2);
                        break;
                    case Architecture.X64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2.dll", NativeGraphic.win_x64_sdl2);
                        break;
                }
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                switch (RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.Arm64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2.so", NativeGraphic.linux_arm64_sdl2);
                        break;
                    case Architecture.X64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2.so", NativeGraphic.linux_x64_sdl2);
                        break;
                }
            }
        }

        #region SDL_scancode.h

        /* Scancodes based off USB keyboard page (0x07) */
        /// <summary>
        ///     The sdl scancode enum
        /// </summary>
        public enum SdlScancode
        {
            /// <summary>
            ///     The sdl scancode unknown sdl scancode
            /// </summary>
            SdlScancodeUnknown = 0,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeA = 4,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeB = 5,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeC = 6,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeD = 7,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeE = 8,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeF = 9,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeG = 10,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeH = 11,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeI = 12,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeJ = 13,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeK = 14,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeL = 15,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeM = 16,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeN = 17,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeO = 18,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeP = 19,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeQ = 20,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeR = 21,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeS = 22,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeT = 23,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeU = 24,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeV = 25,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeW = 26,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeX = 27,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeY = 28,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancodeZ = 29,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancode1 = 30,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancode2 = 31,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancode3 = 32,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancode4 = 33,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancode5 = 34,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancode6 = 35,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancode7 = 36,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancode8 = 37,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancode9 = 38,

            /// <summary>
            ///     The sdl scancode sdl scancode
            /// </summary>
            SdlScancode0 = 39,

            /// <summary>
            ///     The sdl scancode return sdl scancode
            /// </summary>
            SdlScancodeReturn = 40,

            /// <summary>
            ///     The sdl scancode escape sdl scancode
            /// </summary>
            SdlScancodeEscape = 41,

            /// <summary>
            ///     The sdl scancode backspace sdl scancode
            /// </summary>
            SdlScancodeBackspace = 42,

            /// <summary>
            ///     The sdl scancode tab sdl scancode
            /// </summary>
            SdlScancodeTab = 43,

            /// <summary>
            ///     The sdl scancode space sdl scancode
            /// </summary>
            SdlScancodeSpace = 44,

            /// <summary>
            ///     The sdl scancode minus sdl scancode
            /// </summary>
            SdlScancodeMinus = 45,

            /// <summary>
            ///     The sdl scancode equals sdl scancode
            /// </summary>
            SdlScancodeEquals = 46,

            /// <summary>
            ///     The sdl scancode leftbracket sdl scancode
            /// </summary>
            SdlScancodeLeftbracket = 47,

            /// <summary>
            ///     The sdl scancode rightbracket sdl scancode
            /// </summary>
            SdlScancodeRightbracket = 48,

            /// <summary>
            ///     The sdl scancode backslash sdl scancode
            /// </summary>
            SdlScancodeBackslash = 49,

            /// <summary>
            ///     The sdl scancode nonushash sdl scancode
            /// </summary>
            SdlScancodeNonushash = 50,

            /// <summary>
            ///     The sdl scancode semicolon sdl scancode
            /// </summary>
            SdlScancodeSemicolon = 51,

            /// <summary>
            ///     The sdl scancode apostrophe sdl scancode
            /// </summary>
            SdlScancodeApostrophe = 52,

            /// <summary>
            ///     The sdl scancode grave sdl scancode
            /// </summary>
            SdlScancodeGrave = 53,

            /// <summary>
            ///     The sdl scancode comma sdl scancode
            /// </summary>
            SdlScancodeComma = 54,

            /// <summary>
            ///     The sdl scancode period sdl scancode
            /// </summary>
            SdlScancodePeriod = 55,

            /// <summary>
            ///     The sdl scancode slash sdl scancode
            /// </summary>
            SdlScancodeSlash = 56,

            /// <summary>
            ///     The sdl scancode capslock sdl scancode
            /// </summary>
            SdlScancodeCapslock = 57,

            /// <summary>
            ///     The sdl scancode f1 sdl scancode
            /// </summary>
            SdlScancodeF1 = 58,

            /// <summary>
            ///     The sdl scancode f2 sdl scancode
            /// </summary>
            SdlScancodeF2 = 59,

            /// <summary>
            ///     The sdl scancode f3 sdl scancode
            /// </summary>
            SdlScancodeF3 = 60,

            /// <summary>
            ///     The sdl scancode f4 sdl scancode
            /// </summary>
            SdlScancodeF4 = 61,

            /// <summary>
            ///     The sdl scancode f5 sdl scancode
            /// </summary>
            SdlScancodeF5 = 62,

            /// <summary>
            ///     The sdl scancode f6 sdl scancode
            /// </summary>
            SdlScancodeF6 = 63,

            /// <summary>
            ///     The sdl scancode f7 sdl scancode
            /// </summary>
            SdlScancodeF7 = 64,

            /// <summary>
            ///     The sdl scancode f8 sdl scancode
            /// </summary>
            SdlScancodeF8 = 65,

            /// <summary>
            ///     The sdl scancode f9 sdl scancode
            /// </summary>
            SdlScancodeF9 = 66,

            /// <summary>
            ///     The sdl scancode f10 sdl scancode
            /// </summary>
            SdlScancodeF10 = 67,

            /// <summary>
            ///     The sdl scancode f11 sdl scancode
            /// </summary>
            SdlScancodeF11 = 68,

            /// <summary>
            ///     The sdl scancode f12 sdl scancode
            /// </summary>
            SdlScancodeF12 = 69,

            /// <summary>
            ///     The sdl scancode printscreen sdl scancode
            /// </summary>
            SdlScancodePrintscreen = 70,

            /// <summary>
            ///     The sdl scancode scrolllock sdl scancode
            /// </summary>
            SdlScancodeScrolllock = 71,

            /// <summary>
            ///     The sdl scancode pause sdl scancode
            /// </summary>
            SdlScancodePause = 72,

            /// <summary>
            ///     The sdl scancode insert sdl scancode
            /// </summary>
            SdlScancodeInsert = 73,

            /// <summary>
            ///     The sdl scancode home sdl scancode
            /// </summary>
            SdlScancodeHome = 74,

            /// <summary>
            ///     The sdl scancode pageup sdl scancode
            /// </summary>
            SdlScancodePageup = 75,

            /// <summary>
            ///     The sdl scancode delete sdl scancode
            /// </summary>
            SdlScancodeDelete = 76,

            /// <summary>
            ///     The sdl scancode end sdl scancode
            /// </summary>
            SdlScancodeEnd = 77,

            /// <summary>
            ///     The sdl scancode pagedown sdl scancode
            /// </summary>
            SdlScancodePagedown = 78,

            /// <summary>
            ///     The sdl scancode right sdl scancode
            /// </summary>
            SdlScancodeRight = 79,

            /// <summary>
            ///     The sdl scancode left sdl scancode
            /// </summary>
            SdlScancodeLeft = 80,

            /// <summary>
            ///     The sdl scancode down sdl scancode
            /// </summary>
            SdlScancodeDown = 81,

            /// <summary>
            ///     The sdl scancode up sdl scancode
            /// </summary>
            SdlScancodeUp = 82,

            /// <summary>
            ///     The sdl scancode numlockclear sdl scancode
            /// </summary>
            SdlScancodeNumlockclear = 83,

            /// <summary>
            ///     The sdl scancode kp divide sdl scancode
            /// </summary>
            SdlScancodeKpDivide = 84,

            /// <summary>
            ///     The sdl scancode kp multiply sdl scancode
            /// </summary>
            SdlScancodeKpMultiply = 85,

            /// <summary>
            ///     The sdl scancode kp minus sdl scancode
            /// </summary>
            SdlScancodeKpMinus = 86,

            /// <summary>
            ///     The sdl scancode kp plus sdl scancode
            /// </summary>
            SdlScancodeKpPlus = 87,

            /// <summary>
            ///     The sdl scancode kp enter sdl scancode
            /// </summary>
            SdlScancodeKpEnter = 88,

            /// <summary>
            ///     The sdl scancode kp sdl scancode
            /// </summary>
            SdlScancodeKp1 = 89,

            /// <summary>
            ///     The sdl scancode kp sdl scancode
            /// </summary>
            SdlScancodeKp2 = 90,

            /// <summary>
            ///     The sdl scancode kp sdl scancode
            /// </summary>
            SdlScancodeKp3 = 91,

            /// <summary>
            ///     The sdl scancode kp sdl scancode
            /// </summary>
            SdlScancodeKp4 = 92,

            /// <summary>
            ///     The sdl scancode kp sdl scancode
            /// </summary>
            SdlScancodeKp5 = 93,

            /// <summary>
            ///     The sdl scancode kp sdl scancode
            /// </summary>
            SdlScancodeKp6 = 94,

            /// <summary>
            ///     The sdl scancode kp sdl scancode
            /// </summary>
            SdlScancodeKp7 = 95,

            /// <summary>
            ///     The sdl scancode kp sdl scancode
            /// </summary>
            SdlScancodeKp8 = 96,

            /// <summary>
            ///     The sdl scancode kp sdl scancode
            /// </summary>
            SdlScancodeKp9 = 97,

            /// <summary>
            ///     The sdl scancode kp sdl scancode
            /// </summary>
            SdlScancodeKp0 = 98,

            /// <summary>
            ///     The sdl scancode kp period sdl scancode
            /// </summary>
            SdlScancodeKpPeriod = 99,

            /// <summary>
            ///     The sdl scancode nonusbackslash sdl scancode
            /// </summary>
            SdlScancodeNonusbackslash = 100,

            /// <summary>
            ///     The sdl scancode application sdl scancode
            /// </summary>
            SdlScancodeApplication = 101,

            /// <summary>
            ///     The sdl scancode power sdl scancode
            /// </summary>
            SdlScancodePower = 102,

            /// <summary>
            ///     The sdl scancode kp equals sdl scancode
            /// </summary>
            SdlScancodeKpEquals = 103,

            /// <summary>
            ///     The sdl scancode f13 sdl scancode
            /// </summary>
            SdlScancodeF13 = 104,

            /// <summary>
            ///     The sdl scancode f14 sdl scancode
            /// </summary>
            SdlScancodeF14 = 105,

            /// <summary>
            ///     The sdl scancode f15 sdl scancode
            /// </summary>
            SdlScancodeF15 = 106,

            /// <summary>
            ///     The sdl scancode f16 sdl scancode
            /// </summary>
            SdlScancodeF16 = 107,

            /// <summary>
            ///     The sdl scancode f17 sdl scancode
            /// </summary>
            SdlScancodeF17 = 108,

            /// <summary>
            ///     The sdl scancode f18 sdl scancode
            /// </summary>
            SdlScancodeF18 = 109,

            /// <summary>
            ///     The sdl scancode f19 sdl scancode
            /// </summary>
            SdlScancodeF19 = 110,

            /// <summary>
            ///     The sdl scancode f20 sdl scancode
            /// </summary>
            SdlScancodeF20 = 111,

            /// <summary>
            ///     The sdl scancode f21 sdl scancode
            /// </summary>
            SdlScancodeF21 = 112,

            /// <summary>
            ///     The sdl scancode f22 sdl scancode
            /// </summary>
            SdlScancodeF22 = 113,

            /// <summary>
            ///     The sdl scancode f23 sdl scancode
            /// </summary>
            SdlScancodeF23 = 114,

            /// <summary>
            ///     The sdl scancode f24 sdl scancode
            /// </summary>
            SdlScancodeF24 = 115,

            /// <summary>
            ///     The sdl scancode execute sdl scancode
            /// </summary>
            SdlScancodeExecute = 116,

            /// <summary>
            ///     The sdl scancode help sdl scancode
            /// </summary>
            SdlScancodeHelp = 117,

            /// <summary>
            ///     The sdl scancode menu sdl scancode
            /// </summary>
            SdlScancodeMenu = 118,

            /// <summary>
            ///     The sdl scancode select sdl scancode
            /// </summary>
            SdlScancodeSelect = 119,

            /// <summary>
            ///     The sdl scancode stop sdl scancode
            /// </summary>
            SdlScancodeStop = 120,

            /// <summary>
            ///     The sdl scancode again sdl scancode
            /// </summary>
            SdlScancodeAgain = 121,

            /// <summary>
            ///     The sdl scancode undo sdl scancode
            /// </summary>
            SdlScancodeUndo = 122,

            /// <summary>
            ///     The sdl scancode cut sdl scancode
            /// </summary>
            SdlScancodeCut = 123,

            /// <summary>
            ///     The sdl scancode copy sdl scancode
            /// </summary>
            SdlScancodeCopy = 124,

            /// <summary>
            ///     The sdl scancode paste sdl scancode
            /// </summary>
            SdlScancodePaste = 125,

            /// <summary>
            ///     The sdl scancode find sdl scancode
            /// </summary>
            SdlScancodeFind = 126,

            /// <summary>
            ///     The sdl scancode mute sdl scancode
            /// </summary>
            SdlScancodeMute = 127,

            /// <summary>
            ///     The sdl scancode volumeup sdl scancode
            /// </summary>
            SdlScancodeVolumeup = 128,

            /// <summary>
            ///     The sdl scancode volumedown sdl scancode
            /// </summary>
            SdlScancodeVolumedown = 129,

            /* not sure whether there's a reason to enable these */
            /*	SDL_SCANCODE_LOCKINGCAPSLOCK = 130, */
            /*	SDL_SCANCODE_LOCKINGNUMLOCK = 131, */
            /*	SDL_SCANCODE_LOCKINGSCROLLLOCK = 132, */
            /// <summary>
            ///     The sdl scancode kp comma sdl scancode
            /// </summary>
            SdlScancodeKpComma = 133,

            /// <summary>
            ///     The sdl scancode kp equalsas400 sdl scancode
            /// </summary>
            SdlScancodeKpEqualsas400 = 134,

            /// <summary>
            ///     The sdl scancode international1 sdl scancode
            /// </summary>
            SdlScancodeInternational1 = 135,

            /// <summary>
            ///     The sdl scancode international2 sdl scancode
            /// </summary>
            SdlScancodeInternational2 = 136,

            /// <summary>
            ///     The sdl scancode international3 sdl scancode
            /// </summary>
            SdlScancodeInternational3 = 137,

            /// <summary>
            ///     The sdl scancode international4 sdl scancode
            /// </summary>
            SdlScancodeInternational4 = 138,

            /// <summary>
            ///     The sdl scancode international5 sdl scancode
            /// </summary>
            SdlScancodeInternational5 = 139,

            /// <summary>
            ///     The sdl scancode international6 sdl scancode
            /// </summary>
            SdlScancodeInternational6 = 140,

            /// <summary>
            ///     The sdl scancode international7 sdl scancode
            /// </summary>
            SdlScancodeInternational7 = 141,

            /// <summary>
            ///     The sdl scancode international8 sdl scancode
            /// </summary>
            SdlScancodeInternational8 = 142,

            /// <summary>
            ///     The sdl scancode international9 sdl scancode
            /// </summary>
            SdlScancodeInternational9 = 143,

            /// <summary>
            ///     The sdl scancode lang1 sdl scancode
            /// </summary>
            SdlScancodeLang1 = 144,

            /// <summary>
            ///     The sdl scancode lang2 sdl scancode
            /// </summary>
            SdlScancodeLang2 = 145,

            /// <summary>
            ///     The sdl scancode lang3 sdl scancode
            /// </summary>
            SdlScancodeLang3 = 146,

            /// <summary>
            ///     The sdl scancode lang4 sdl scancode
            /// </summary>
            SdlScancodeLang4 = 147,

            /// <summary>
            ///     The sdl scancode lang5 sdl scancode
            /// </summary>
            SdlScancodeLang5 = 148,

            /// <summary>
            ///     The sdl scancode lang6 sdl scancode
            /// </summary>
            SdlScancodeLang6 = 149,

            /// <summary>
            ///     The sdl scancode lang7 sdl scancode
            /// </summary>
            SdlScancodeLang7 = 150,

            /// <summary>
            ///     The sdl scancode lang8 sdl scancode
            /// </summary>
            SdlScancodeLang8 = 151,

            /// <summary>
            ///     The sdl scancode lang9 sdl scancode
            /// </summary>
            SdlScancodeLang9 = 152,

            /// <summary>
            ///     The sdl scancode alterase sdl scancode
            /// </summary>
            SdlScancodeAlterase = 153,

            /// <summary>
            ///     The sdl scancode sysreq sdl scancode
            /// </summary>
            SdlScancodeSysreq = 154,

            /// <summary>
            ///     The sdl scancode cancel sdl scancode
            /// </summary>
            SdlScancodeCancel = 155,

            /// <summary>
            ///     The sdl scancode clear sdl scancode
            /// </summary>
            SdlScancodeClear = 156,

            /// <summary>
            ///     The sdl scancode prior sdl scancode
            /// </summary>
            SdlScancodePrior = 157,

            /// <summary>
            ///     The sdl scancode return2 sdl scancode
            /// </summary>
            SdlScancodeReturn2 = 158,

            /// <summary>
            ///     The sdl scancode separator sdl scancode
            /// </summary>
            SdlScancodeSeparator = 159,

            /// <summary>
            ///     The sdl scancode out sdl scancode
            /// </summary>
            SdlScancodeOut = 160,

            /// <summary>
            ///     The sdl scancode oper sdl scancode
            /// </summary>
            SdlScancodeOper = 161,

            /// <summary>
            ///     The sdl scancode clearagain sdl scancode
            /// </summary>
            SdlScancodeClearagain = 162,

            /// <summary>
            ///     The sdl scancode crsel sdl scancode
            /// </summary>
            SdlScancodeCrsel = 163,

            /// <summary>
            ///     The sdl scancode exsel sdl scancode
            /// </summary>
            SdlScancodeExsel = 164,

            /// <summary>
            ///     The sdl scancode kp 00 sdl scancode
            /// </summary>
            SdlScancodeKp00 = 176,

            /// <summary>
            ///     The sdl scancode kp 000 sdl scancode
            /// </summary>
            SdlScancodeKp000 = 177,

            /// <summary>
            ///     The sdl scancode thousandsseparator sdl scancode
            /// </summary>
            SdlScancodeThousandsseparator = 178,

            /// <summary>
            ///     The sdl scancode decimalseparator sdl scancode
            /// </summary>
            SdlScancodeDecimalseparator = 179,

            /// <summary>
            ///     The sdl scancode currencyunit sdl scancode
            /// </summary>
            SdlScancodeCurrencyunit = 180,

            /// <summary>
            ///     The sdl scancode currencysubunit sdl scancode
            /// </summary>
            SdlScancodeCurrencysubunit = 181,

            /// <summary>
            ///     The sdl scancode kp leftparen sdl scancode
            /// </summary>
            SdlScancodeKpLeftparen = 182,

            /// <summary>
            ///     The sdl scancode kp rightparen sdl scancode
            /// </summary>
            SdlScancodeKpRightparen = 183,

            /// <summary>
            ///     The sdl scancode kp leftbrace sdl scancode
            /// </summary>
            SdlScancodeKpLeftbrace = 184,

            /// <summary>
            ///     The sdl scancode kp rightbrace sdl scancode
            /// </summary>
            SdlScancodeKpRightbrace = 185,

            /// <summary>
            ///     The sdl scancode kp tab sdl scancode
            /// </summary>
            SdlScancodeKpTab = 186,

            /// <summary>
            ///     The sdl scancode kp backspace sdl scancode
            /// </summary>
            SdlScancodeKpBackspace = 187,

            /// <summary>
            ///     The sdl scancode kp sdl scancode
            /// </summary>
            SdlScancodeKpA = 188,

            /// <summary>
            ///     The sdl scancode kp sdl scancode
            /// </summary>
            SdlScancodeKpB = 189,

            /// <summary>
            ///     The sdl scancode kp sdl scancode
            /// </summary>
            SdlScancodeKpC = 190,

            /// <summary>
            ///     The sdl scancode kp sdl scancode
            /// </summary>
            SdlScancodeKpD = 191,

            /// <summary>
            ///     The sdl scancode kp sdl scancode
            /// </summary>
            SdlScancodeKpE = 192,

            /// <summary>
            ///     The sdl scancode kp sdl scancode
            /// </summary>
            SdlScancodeKpF = 193,

            /// <summary>
            ///     The sdl scancode kp xor sdl scancode
            /// </summary>
            SdlScancodeKpXor = 194,

            /// <summary>
            ///     The sdl scancode kp power sdl scancode
            /// </summary>
            SdlScancodeKpPower = 195,

            /// <summary>
            ///     The sdl scancode kp percent sdl scancode
            /// </summary>
            SdlScancodeKpPercent = 196,

            /// <summary>
            ///     The sdl scancode kp less sdl scancode
            /// </summary>
            SdlScancodeKpLess = 197,

            /// <summary>
            ///     The sdl scancode kp greater sdl scancode
            /// </summary>
            SdlScancodeKpGreater = 198,

            /// <summary>
            ///     The sdl scancode kp ampersand sdl scancode
            /// </summary>
            SdlScancodeKpAmpersand = 199,

            /// <summary>
            ///     The sdl scancode kp dblampersand sdl scancode
            /// </summary>
            SdlScancodeKpDblampersand = 200,

            /// <summary>
            ///     The sdl scancode kp verticalbar sdl scancode
            /// </summary>
            SdlScancodeKpVerticalbar = 201,

            /// <summary>
            ///     The sdl scancode kp dblverticalbar sdl scancode
            /// </summary>
            SdlScancodeKpDblverticalbar = 202,

            /// <summary>
            ///     The sdl scancode kp colon sdl scancode
            /// </summary>
            SdlScancodeKpColon = 203,

            /// <summary>
            ///     The sdl scancode kp hash sdl scancode
            /// </summary>
            SdlScancodeKpHash = 204,

            /// <summary>
            ///     The sdl scancode kp space sdl scancode
            /// </summary>
            SdlScancodeKpSpace = 205,

            /// <summary>
            ///     The sdl scancode kp at sdl scancode
            /// </summary>
            SdlScancodeKpAt = 206,

            /// <summary>
            ///     The sdl scancode kp exclam sdl scancode
            /// </summary>
            SdlScancodeKpExclam = 207,

            /// <summary>
            ///     The sdl scancode kp memstore sdl scancode
            /// </summary>
            SdlScancodeKpMemstore = 208,

            /// <summary>
            ///     The sdl scancode kp memrecall sdl scancode
            /// </summary>
            SdlScancodeKpMemrecall = 209,

            /// <summary>
            ///     The sdl scancode kp memclear sdl scancode
            /// </summary>
            SdlScancodeKpMemclear = 210,

            /// <summary>
            ///     The sdl scancode kp memadd sdl scancode
            /// </summary>
            SdlScancodeKpMemadd = 211,

            /// <summary>
            ///     The sdl scancode kp memsubtract sdl scancode
            /// </summary>
            SdlScancodeKpMemsubtract = 212,

            /// <summary>
            ///     The sdl scancode kp memmultiply sdl scancode
            /// </summary>
            SdlScancodeKpMemmultiply = 213,

            /// <summary>
            ///     The sdl scancode kp memdivide sdl scancode
            /// </summary>
            SdlScancodeKpMemdivide = 214,

            /// <summary>
            ///     The sdl scancode kp plusminus sdl scancode
            /// </summary>
            SdlScancodeKpPlusminus = 215,

            /// <summary>
            ///     The sdl scancode kp clear sdl scancode
            /// </summary>
            SdlScancodeKpClear = 216,

            /// <summary>
            ///     The sdl scancode kp clearentry sdl scancode
            /// </summary>
            SdlScancodeKpClearentry = 217,

            /// <summary>
            ///     The sdl scancode kp binary sdl scancode
            /// </summary>
            SdlScancodeKpBinary = 218,

            /// <summary>
            ///     The sdl scancode kp octal sdl scancode
            /// </summary>
            SdlScancodeKpOctal = 219,

            /// <summary>
            ///     The sdl scancode kp decimal sdl scancode
            /// </summary>
            SdlScancodeKpDecimal = 220,

            /// <summary>
            ///     The sdl scancode kp hexadecimal sdl scancode
            /// </summary>
            SdlScancodeKpHexadecimal = 221,

            /// <summary>
            ///     The sdl scancode lctrl sdl scancode
            /// </summary>
            SdlScancodeLctrl = 224,

            /// <summary>
            ///     The sdl scancode lshift sdl scancode
            /// </summary>
            SdlScancodeLshift = 225,

            /// <summary>
            ///     The sdl scancode lalt sdl scancode
            /// </summary>
            SdlScancodeLalt = 226,

            /// <summary>
            ///     The sdl scancode lgui sdl scancode
            /// </summary>
            SdlScancodeLgui = 227,

            /// <summary>
            ///     The sdl scancode rctrl sdl scancode
            /// </summary>
            SdlScancodeRctrl = 228,

            /// <summary>
            ///     The sdl scancode rshift sdl scancode
            /// </summary>
            SdlScancodeRshift = 229,

            /// <summary>
            ///     The sdl scancode ralt sdl scancode
            /// </summary>
            SdlScancodeRalt = 230,

            /// <summary>
            ///     The sdl scancode rgui sdl scancode
            /// </summary>
            SdlScancodeRgui = 231,

            /// <summary>
            ///     The sdl scancode mode sdl scancode
            /// </summary>
            SdlScancodeMode = 257,

            /* These come from the USB consumer page (0x0C) */
            /// <summary>
            ///     The sdl scancode audionext sdl scancode
            /// </summary>
            SdlScancodeAudionext = 258,

            /// <summary>
            ///     The sdl scancode audioprev sdl scancode
            /// </summary>
            SdlScancodeAudioprev = 259,

            /// <summary>
            ///     The sdl scancode audiostop sdl scancode
            /// </summary>
            SdlScancodeAudiostop = 260,

            /// <summary>
            ///     The sdl scancode audioplay sdl scancode
            /// </summary>
            SdlScancodeAudioplay = 261,

            /// <summary>
            ///     The sdl scancode audiomute sdl scancode
            /// </summary>
            SdlScancodeAudiomute = 262,

            /// <summary>
            ///     The sdl scancode mediaselect sdl scancode
            /// </summary>
            SdlScancodeMediaselect = 263,

            /// <summary>
            ///     The sdl scancode www sdl scancode
            /// </summary>
            SdlScancodeWww = 264,

            /// <summary>
            ///     The sdl scancode mail sdl scancode
            /// </summary>
            SdlScancodeMail = 265,

            /// <summary>
            ///     The sdl scancode calculator sdl scancode
            /// </summary>
            SdlScancodeCalculator = 266,

            /// <summary>
            ///     The sdl scancode computer sdl scancode
            /// </summary>
            SdlScancodeComputer = 267,

            /// <summary>
            ///     The sdl scancode ac search sdl scancode
            /// </summary>
            SdlScancodeAcSearch = 268,

            /// <summary>
            ///     The sdl scancode ac home sdl scancode
            /// </summary>
            SdlScancodeAcHome = 269,

            /// <summary>
            ///     The sdl scancode ac back sdl scancode
            /// </summary>
            SdlScancodeAcBack = 270,

            /// <summary>
            ///     The sdl scancode ac forward sdl scancode
            /// </summary>
            SdlScancodeAcForward = 271,

            /// <summary>
            ///     The sdl scancode ac stop sdl scancode
            /// </summary>
            SdlScancodeAcStop = 272,

            /// <summary>
            ///     The sdl scancode ac refresh sdl scancode
            /// </summary>
            SdlScancodeAcRefresh = 273,

            /// <summary>
            ///     The sdl scancode ac bookmarks sdl scancode
            /// </summary>
            SdlScancodeAcBookmarks = 274,

            /* These come from other sources, and are mostly mac related */
            /// <summary>
            ///     The sdl scancode brightnessdown sdl scancode
            /// </summary>
            SdlScancodeBrightnessdown = 275,

            /// <summary>
            ///     The sdl scancode brightnessup sdl scancode
            /// </summary>
            SdlScancodeBrightnessup = 276,

            /// <summary>
            ///     The sdl scancode displayswitch sdl scancode
            /// </summary>
            SdlScancodeDisplayswitch = 277,

            /// <summary>
            ///     The sdl scancode kbdillumtoggle sdl scancode
            /// </summary>
            SdlScancodeKbdillumtoggle = 278,

            /// <summary>
            ///     The sdl scancode kbdillumdown sdl scancode
            /// </summary>
            SdlScancodeKbdillumdown = 279,

            /// <summary>
            ///     The sdl scancode kbdillumup sdl scancode
            /// </summary>
            SdlScancodeKbdillumup = 280,

            /// <summary>
            ///     The sdl scancode eject sdl scancode
            /// </summary>
            SdlScancodeEject = 281,

            /// <summary>
            ///     The sdl scancode sleep sdl scancode
            /// </summary>
            SdlScancodeSleep = 282,

            /// <summary>
            ///     The sdl scancode app1 sdl scancode
            /// </summary>
            SdlScancodeApp1 = 283,

            /// <summary>
            ///     The sdl scancode app2 sdl scancode
            /// </summary>
            SdlScancodeApp2 = 284,

            /* These come from the USB consumer page (0x0C) */
            /// <summary>
            ///     The sdl scancode audiorewind sdl scancode
            /// </summary>
            SdlScancodeAudiorewind = 285,

            /// <summary>
            ///     The sdl scancode audiofastforward sdl scancode
            /// </summary>
            SdlScancodeAudiofastforward = 286,

            /* This is not a key, simply marks the number of scancodes
             * so that you know how big to make your arrays. */
            /// <summary>
            ///     The sdl num scancodes sdl scancode
            /// </summary>
            SdlNumScancodes = 512
        }

        #endregion

        #region SDL2# Variables

        /// <summary>
        ///     The native lib name
        /// </summary>
        private const string NativeLibName = "sdl2";

        #endregion

        #region UTF8 Marshaling

        /* Used for stack allocated string marshaling. */
        /// <summary>
        ///     Utfs the 8 size using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        /// <returns>The int</returns>
        internal static int Utf8Size(string str)
        {
            if (str == null)
            {
                return 0;
            }

            return str.Length * 4 + 1;
        }

        /// <summary>
        ///     Utfs the 8 encode using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <returns>The buffer</returns>
        internal static unsafe byte* Utf8Encode(string str, byte* buffer, int bufferSize)
        {
            if (str == null)
            {
                return (byte*) 0;
            }

            fixed (char* strPtr = str)
            {
                Encoding.UTF8.GetBytes(strPtr, str.Length + 1, buffer, bufferSize);
            }

            return buffer;
        }

        /* Used for heap allocated string marshaling.
         * Returned byte* must be free'd with FreeHGlobal.
         */
        /// <summary>
        ///     Utfs the 8 encode heap using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        /// <returns>The buffer</returns>
        internal static unsafe byte* Utf8EncodeHeap(string str)
        {
            if (str == null)
            {
                return (byte*) 0;
            }

            int bufferSize = Utf8Size(str);
            byte* buffer = (byte*) Marshal.AllocHGlobal(bufferSize);
            fixed (char* strPtr = str)
            {
                Encoding.UTF8.GetBytes(strPtr, str.Length + 1, buffer, bufferSize);
            }

            return buffer;
        }

        /* This is public because SDL_DropEvent needs it! */
        /// <summary>
        ///     Utfs the 8 to managed using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="freePtr">The free ptr</param>
        /// <returns>The result</returns>
        public static unsafe string UTF8_ToManaged(IntPtr s, bool freePtr = false)
        {
            if (s == IntPtr.Zero)
            {
                return null;
            }

            /* We get to do strlen ourselves! */
            byte* ptr = (byte*) s;
            while (*ptr != 0)
            {
                ptr++;
            }

            /* TODO: This #ifdef is only here because the equivalent
             * .NET 2.0 constructor appears to be less efficient?
             * Here's the pretty version, maybe steal this instead:
             *
            string result = new string(
                (sbyte*) s, // Also, why sbyte???
                0,
                (int) (ptr - (byte*) s),
                System.Text.Encoding.UTF8
            );
             * See the CoreCLR source for more info.
             * -flibit
             */
#if NETSTANDARD2_0
			/* Modern C# lets you just send the byte*, nice! */
			string result = System.Text.Encoding.UTF8.GetString(
				(byte*) s,
				(int) (ptr - (byte*) s)
			);
#else
            /* Old C# requires an extra memcpy, bleh! */
            int len = (int) (ptr - (byte*) s);
            if (len == 0)
            {
                return string.Empty;
            }

            char* chars = stackalloc char[len];
            int strLen = Encoding.UTF8.GetChars((byte*) s, len, chars, len);
            string result = new string(chars, 0, strLen);
#endif

            /* Some SDL functions will malloc, we have to free! */
            if (freePtr)
            {
                SDL_free(s);
            }

            return result;
        }

        #endregion

        #region SDL_stdinc.h

        /// <summary>
        ///     Sdls the fourcc using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <returns>The uint</returns>
        public static uint SDL_FOURCC(byte a, byte b, byte c, byte d) => (uint) (a | (b << 8) | (c << 16) | (d << 24));

        /// <summary>
        ///     The sdl bool enum
        /// </summary>
        public enum SdlBool
        {
            /// <summary>
            ///     The sdl false sdl bool
            /// </summary>
            SdlFalse = 0,

            /// <summary>
            ///     The sdl true sdl bool
            /// </summary>
            SdlTrue = 1
        }

        /* malloc/free are used by the marshaler! -flibit */

        /// <summary>
        ///     Sdls the malloc using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr SDL_malloc(IntPtr size);

        /// <summary>
        ///     Sdls the free using the specified memblock
        /// </summary>
        /// <param name="memblock">The memblock</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SDL_free(IntPtr memblock);

        /* Buffer.BlockCopy is not available in every runtime yet. Also,
         * using memcpy directly can be a compatibility issue in other
         * strange ways. So, we expose this to get around all that.
         * -flibit
         */
        /// <summary>
        ///     Sdls the memcpy using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="len">The len</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_memcpy(IntPtr dst, IntPtr src, IntPtr len);

        #endregion

        #region SDL_rwops.h

        /// <summary>
        ///     The rw seek set
        /// </summary>
        public const int RwSeekSet = 0;

        /// <summary>
        ///     The rw seek cur
        /// </summary>
        public const int RwSeekCur = 1;

        /// <summary>
        ///     The rw seek end
        /// </summary>
        public const int RwSeekEnd = 2;

        /// <summary>
        ///     The sdl rwops unknown
        /// </summary>
        public const uint SdlRwopsUnknown = 0; /* Unknown stream type */

        /// <summary>
        ///     The sdl rwops winfile
        /// </summary>
        public const uint SdlRwopsWinfile = 1; /* Win32 file */

        /// <summary>
        ///     The sdl rwops stdfile
        /// </summary>
        public const uint SdlRwopsStdfile = 2; /* Stdio file */

        /// <summary>
        ///     The sdl rwops jnifile
        /// </summary>
        public const uint SdlRwopsJnifile = 3; /* Android asset */

        /// <summary>
        ///     The sdl rwops memory
        /// </summary>
        public const uint SdlRwopsMemory = 4; /* Memory stream */

        /// <summary>
        ///     The sdl rwops memory ro
        /// </summary>
        public const uint SdlRwopsMemoryRo = 5; /* Read-Only memory stream */

        /// <summary>
        ///     The sdlr wops size callback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long SdlrWopsSizeCallback(IntPtr context);

        /// <summary>
        ///     The sdlr wops seek callback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long SdlrWopsSeekCallback(
            IntPtr context,
            long offset,
            int whence
        );

        /// <summary>
        ///     The sdlr wops read callback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr SdlrWopsReadCallback(
            IntPtr context,
            IntPtr ptr,
            IntPtr size,
            IntPtr maxnum
        );

        /// <summary>
        ///     The sdlr wops write callback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr SdlrWopsWriteCallback(
            IntPtr context,
            IntPtr ptr,
            IntPtr size,
            IntPtr num
        );

        /// <summary>
        ///     The sdlr wops close callback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int SdlrWopsCloseCallback(
            IntPtr context
        );

        /// <summary>
        ///     The sdl rwops
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlRWops
        {
            /// <summary>
            ///     The size
            /// </summary>
            public IntPtr size;

            /// <summary>
            ///     The seek
            /// </summary>
            public IntPtr seek;

            /// <summary>
            ///     The read
            /// </summary>
            public IntPtr read;

            /// <summary>
            ///     The write
            /// </summary>
            public IntPtr write;

            /// <summary>
            ///     The close
            /// </summary>
            public IntPtr close;

            /// <summary>
            ///     The type
            /// </summary>
            public uint type;

            /* NOTE: This isn't the full structure since
             * the native SDL_RWops contains a hidden union full of
             * internal information and platform-specific stuff depending
             * on what conditions the native library was built with
             */
        }

        /* IntPtr refers to an SDL_RWops* */
        /// <summary>
        ///     Internals the sdl rw from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RWFromFile", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe IntPtr INTERNAL_SDL_RWFromFile(
            byte* file,
            byte* mode
        );

        /// <summary>
        ///     Sdls the rw from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="mode">The mode</param>
        /// <returns>The rw ops</returns>
        public static unsafe IntPtr SDL_RWFromFile(
            string file,
            string mode
        )
        {
            byte* utf8File = Utf8EncodeHeap(file);
            byte* utf8Mode = Utf8EncodeHeap(mode);
            IntPtr rwOps = INTERNAL_SDL_RWFromFile(
                utf8File,
                utf8Mode
            );
            Marshal.FreeHGlobal((IntPtr) utf8Mode);
            Marshal.FreeHGlobal((IntPtr) utf8File);
            return rwOps;
        }

        /* IntPtr refers to an SDL_RWops* */
        /// <summary>
        ///     Sdls the alloc rw
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_AllocRW();

        /* area refers to an SDL_RWops* */
        /// <summary>
        ///     Sdls the free rw using the specified area
        /// </summary>
        /// <param name="area">The area</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeRW(IntPtr area);

        /* fp refers to a void* */
        /// <summary>
        ///     Sdls the rw from fp using the specified fp
        /// </summary>
        /// <param name="fp">The fp</param>
        /// <param name="autoclose">The autoclose</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_RWFromFP(IntPtr fp, SdlBool autoclose);

        /* mem refers to a void*, IntPtr to an SDL_RWops* */
        /// <summary>
        ///     Sdls the rw from mem using the specified mem
        /// </summary>
        /// <param name="mem">The mem</param>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_RWFromMem(IntPtr mem, int size);

        /* mem refers to a const void*, IntPtr to an SDL_RWops* */
        /// <summary>
        ///     Sdls the rw from const mem using the specified mem
        /// </summary>
        /// <param name="mem">The mem</param>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_RWFromConstMem(IntPtr mem, int size);

        /* context refers to an SDL_RWops*.
         * Only available in SDL 2.0.10 or higher.
         */
        /// <summary>
        ///     Sdls the r wsize using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long SDL_RWsize(IntPtr context);

        /* context refers to an SDL_RWops*.
         * Only available in SDL 2.0.10 or higher.
         */
        /// <summary>
        ///     Sdls the r wseek using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="offset">The offset</param>
        /// <param name="whence">The whence</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long SDL_RWseek(
            IntPtr context,
            long offset,
            int whence
        );

        /* context refers to an SDL_RWops*.
         * Only available in SDL 2.0.10 or higher.
         */
        /// <summary>
        ///     Sdls the r wtell using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long SDL_RWtell(IntPtr context);

        /* context refers to an SDL_RWops*, ptr refers to a void*.
         * Only available in SDL 2.0.10 or higher.
         */
        /// <summary>
        ///     Sdls the r wread using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="ptr">The ptr</param>
        /// <param name="size">The size</param>
        /// <param name="maxnum">The maxnum</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long SDL_RWread(
            IntPtr context,
            IntPtr ptr,
            IntPtr size,
            IntPtr maxnum
        );

        /* context refers to an SDL_RWops*, ptr refers to a const void*.
         * Only available in SDL 2.0.10 or higher.
         */
        /// <summary>
        ///     Sdls the r wwrite using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="ptr">The ptr</param>
        /// <param name="size">The size</param>
        /// <param name="maxnum">The maxnum</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long SDL_RWwrite(
            IntPtr context,
            IntPtr ptr,
            IntPtr size,
            IntPtr maxnum
        );

        /* Read endian functions */

        /// <summary>
        ///     Sdls the read u 8 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_ReadU8(IntPtr src);

        /// <summary>
        ///     Sdls the read le 16 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 16</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_ReadLE16(IntPtr src);

        /// <summary>
        ///     Sdls the read be 16 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 16</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_ReadBE16(IntPtr src);

        /// <summary>
        ///     Sdls the read le 32 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_ReadLE32(IntPtr src);

        /// <summary>
        ///     Sdls the read be 32 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_ReadBE32(IntPtr src);

        /// <summary>
        ///     Sdls the read le 64 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong SDL_ReadLE64(IntPtr src);

        /// <summary>
        ///     Sdls the read be 64 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong SDL_ReadBE64(IntPtr src);

        /* Write endian functions */

        /// <summary>
        ///     Sdls the write u 8 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WriteU8(IntPtr dst, byte value);

        /// <summary>
        ///     Sdls the write le 16 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WriteLE16(IntPtr dst, ushort value);

        /// <summary>
        ///     Sdls the write be 16 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WriteBE16(IntPtr dst, ushort value);

        /// <summary>
        ///     Sdls the write le 32 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WriteLE32(IntPtr dst, uint value);

        /// <summary>
        ///     Sdls the write be 32 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WriteBE32(IntPtr dst, uint value);

        /// <summary>
        ///     Sdls the write le 64 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WriteLE64(IntPtr dst, ulong value);

        /// <summary>
        ///     Sdls the write be 64 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WriteBE64(IntPtr dst, ulong value);

        /* context refers to an SDL_RWops*
         * Only available in SDL 2.0.10 or higher.
         */
        /// <summary>
        ///     Sdls the r wclose using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long SDL_RWclose(IntPtr context);

        /* datasize refers to a size_t*
         * IntPtr refers to a void*
         * Only available in SDL 2.0.10 or higher.
         */
        /// <summary>
        ///     Internals the sdl load file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="datasize">The datasize</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LoadFile", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe IntPtr INTERNAL_SDL_LoadFile(byte* file, out IntPtr datasize);

        /// <summary>
        ///     Sdls the load file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="datasize">The datasize</param>
        /// <returns>The result</returns>
        public static unsafe IntPtr SDL_LoadFile(string file, out IntPtr datasize)
        {
            byte* utf8File = Utf8EncodeHeap(file);
            IntPtr result = INTERNAL_SDL_LoadFile(utf8File, out datasize);
            Marshal.FreeHGlobal((IntPtr) utf8File);
            return result;
        }

        #endregion

        #region SDL_main.h

        /// <summary>
        ///     Sdls the set main ready
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetMainReady();

        /* This is used as a function pointer to a C main() function */
        /// <summary>
        ///     The sdl main func
        /// </summary>
        public delegate int SdlMainFunc(int argc, IntPtr argv);

        /* Use this function with UWP to call your C# Main() function! */
        /// <summary>
        ///     Sdls the win rt run app using the specified main function
        /// </summary>
        /// <param name="mainFunction">The main function</param>
        /// <param name="reserved">The reserved</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_WinRTRunApp(
            SdlMainFunc mainFunction,
            IntPtr reserved
        );

        /* Use this function with iOS to call your C# Main() function!
         * Only available in SDL 2.0.10 or higher.
         */
        /// <summary>
        ///     Sdls the ui kit run app using the specified argc
        /// </summary>
        /// <param name="argc">The argc</param>
        /// <param name="argv">The argv</param>
        /// <param name="mainFunction">The main function</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UIKitRunApp(
            int argc,
            IntPtr argv,
            SdlMainFunc mainFunction
        );

        #endregion

        #region SDL.h

        /// <summary>
        ///     The sdl init timer
        /// </summary>
        public const uint SdlInitTimer = 0x00000001;

        /// <summary>
        ///     The sdl init audio
        /// </summary>
        public const uint SdlInitAudio = 0x00000010;

        /// <summary>
        ///     The sdl init video
        /// </summary>
        public const uint SdlInitVideo = 0x00000020;

        /// <summary>
        ///     The sdl init joystick
        /// </summary>
        public const uint SdlInitJoystick = 0x00000200;

        /// <summary>
        ///     The sdl init haptic
        /// </summary>
        public const uint SdlInitHaptic = 0x00001000;

        /// <summary>
        ///     The sdl init gamecontroller
        /// </summary>
        public const uint SdlInitGamecontroller = 0x00002000;

        /// <summary>
        ///     The sdl init events
        /// </summary>
        public const uint SdlInitEvents = 0x00004000;

        /// <summary>
        ///     The sdl init sensor
        /// </summary>
        public const uint SdlInitSensor = 0x00008000;

        /// <summary>
        ///     The sdl init noparachute
        /// </summary>
        public const uint SdlInitNoparachute = 0x00100000;

        /// <summary>
        ///     The sdl init sensor
        /// </summary>
        public const uint SdlInitEverything = SdlInitTimer | SdlInitAudio | SdlInitVideo |
                                                SdlInitEvents | SdlInitJoystick | SdlInitHaptic |
                                                SdlInitGamecontroller | SdlInitSensor;

        /// <summary>
        ///     Sdls the init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_Init(uint flags);

        /// <summary>
        ///     Sdls the init sub system using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_InitSubSystem(uint flags);

        /// <summary>
        ///     Sdls the quit
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Quit();

        /// <summary>
        ///     Sdls the quit sub system using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_QuitSubSystem(uint flags);

        /// <summary>
        ///     Sdls the was init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WasInit(uint flags);

        #endregion

        #region SDL_platform.h

        /// <summary>
        ///     Internals the sdl get platform
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPlatform", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetPlatform();

        /// <summary>
        ///     Sdls the get platform
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_GetPlatform() => UTF8_ToManaged(INTERNAL_SDL_GetPlatform());

        #endregion

        #region SDL_hints.h

        /// <summary>
        ///     The sdl hint framebuffer acceleration
        /// </summary>
        public const string SdlHintFramebufferAcceleration =
            "SDL_FRAMEBUFFER_ACCELERATION";

        /// <summary>
        ///     The sdl hint render driver
        /// </summary>
        public const string SdlHintRenderDriver =
            "SDL_RENDER_DRIVER";

        /// <summary>
        ///     The sdl hint render opengl shaders
        /// </summary>
        public const string SdlHintRenderOpenglShaders =
            "SDL_RENDER_OPENGL_SHADERS";

        /// <summary>
        ///     The sdl hint render direct3d threadsafe
        /// </summary>
        public const string SdlHintRenderDirect3DThreadsafe =
            "SDL_RENDER_DIRECT3D_THREADSAFE";

        /// <summary>
        ///     The sdl hint render vsync
        /// </summary>
        public const string SdlHintRenderVsync =
            "SDL_RENDER_VSYNC";

        /// <summary>
        ///     The sdl hint video x11 xvidmode
        /// </summary>
        public const string SdlHintVideoX11Xvidmode =
            "SDL_VIDEO_X11_XVIDMODE";

        /// <summary>
        ///     The sdl hint video x11 xinerama
        /// </summary>
        public const string SdlHintVideoX11Xinerama =
            "SDL_VIDEO_X11_XINERAMA";

        /// <summary>
        ///     The sdl hint video x11 xrandr
        /// </summary>
        public const string SdlHintVideoX11Xrandr =
            "SDL_VIDEO_X11_XRANDR";

        /// <summary>
        ///     The sdl hint grab keyboard
        /// </summary>
        public const string SdlHintGrabKeyboard =
            "SDL_GRAB_KEYBOARD";

        /// <summary>
        ///     The sdl hint video minimize on focus loss
        /// </summary>
        public const string SdlHintVideoMinimizeOnFocusLoss =
            "SDL_VIDEO_MINIMIZE_ON_FOCUS_LOSS";

        /// <summary>
        ///     The sdl hint idle timer disabled
        /// </summary>
        public const string SdlHintIdleTimerDisabled =
            "SDL_IOS_IDLE_TIMER_DISABLED";

        /// <summary>
        ///     The sdl hint orientations
        /// </summary>
        public const string SdlHintOrientations =
            "SDL_IOS_ORIENTATIONS";

        /// <summary>
        ///     The sdl hint xinput enabled
        /// </summary>
        public const string SdlHintXinputEnabled =
            "SDL_XINPUT_ENABLED";

        /// <summary>
        ///     The sdl hint gamecontrollerconfig
        /// </summary>
        public const string SdlHintGamecontrollerconfig =
            "SDL_GAMECONTROLLERCONFIG";

        /// <summary>
        ///     The sdl hint joystick allow background events
        /// </summary>
        public const string SdlHintJoystickAllowBackgroundEvents =
            "SDL_JOYSTICK_ALLOW_BACKGROUND_EVENTS";

        /// <summary>
        ///     The sdl hint allow topmost
        /// </summary>
        public const string SdlHintAllowTopmost =
            "SDL_ALLOW_TOPMOST";

        /// <summary>
        ///     The sdl hint timer resolution
        /// </summary>
        public const string SdlHintTimerResolution =
            "SDL_TIMER_RESOLUTION";

        /// <summary>
        ///     The sdl hint render scale quality
        /// </summary>
        public const string SdlHintRenderScaleQuality =
            "SDL_RENDER_SCALE_QUALITY";

        /* Only available in SDL 2.0.1 or higher. */
        /// <summary>
        ///     The sdl hint video highdpi disabled
        /// </summary>
        public const string SdlHintVideoHighdpiDisabled =
            "SDL_VIDEO_HIGHDPI_DISABLED";

        /* Only available in SDL 2.0.2 or higher. */
        /// <summary>
        ///     The sdl hint ctrl click emulate right click
        /// </summary>
        public const string SdlHintCtrlClickEmulateRightClick =
            "SDL_CTRL_CLICK_EMULATE_RIGHT_CLICK";

        /// <summary>
        ///     The sdl hint video win d3dcompiler
        /// </summary>
        public const string SdlHintVideoWinD3Dcompiler =
            "SDL_VIDEO_WIN_D3DCOMPILER";

        /// <summary>
        ///     The sdl hint mouse relative mode warp
        /// </summary>
        public const string SdlHintMouseRelativeModeWarp =
            "SDL_MOUSE_RELATIVE_MODE_WARP";

        /// <summary>
        ///     The sdl hint video window share pixel format
        /// </summary>
        public const string SdlHintVideoWindowSharePixelFormat =
            "SDL_VIDEO_WINDOW_SHARE_PIXEL_FORMAT";

        /// <summary>
        ///     The sdl hint video allow screensaver
        /// </summary>
        public const string SdlHintVideoAllowScreensaver =
            "SDL_VIDEO_ALLOW_SCREENSAVER";

        /// <summary>
        ///     The sdl hint accelerometer as joystick
        /// </summary>
        public const string SdlHintAccelerometerAsJoystick =
            "SDL_ACCELEROMETER_AS_JOYSTICK";

        /// <summary>
        ///     The sdl hint video mac fullscreen spaces
        /// </summary>
        public const string SdlHintVideoMacFullscreenSpaces =
            "SDL_VIDEO_MAC_FULLSCREEN_SPACES";

        /* Only available in SDL 2.0.3 or higher. */
        /// <summary>
        ///     The sdl hint winrt privacy policy url
        /// </summary>
        public const string SdlHintWinrtPrivacyPolicyUrl =
            "SDL_WINRT_PRIVACY_POLICY_URL";

        /// <summary>
        ///     The sdl hint winrt privacy policy label
        /// </summary>
        public const string SdlHintWinrtPrivacyPolicyLabel =
            "SDL_WINRT_PRIVACY_POLICY_LABEL";

        /// <summary>
        ///     The sdl hint winrt handle back button
        /// </summary>
        public const string SdlHintWinrtHandleBackButton =
            "SDL_WINRT_HANDLE_BACK_BUTTON";

        /* Only available in SDL 2.0.4 or higher. */
        /// <summary>
        ///     The sdl hint no signal handlers
        /// </summary>
        public const string SdlHintNoSignalHandlers =
            "SDL_NO_SIGNAL_HANDLERS";

        /// <summary>
        ///     The sdl hint ime internal editing
        /// </summary>
        public const string SdlHintImeInternalEditing =
            "SDL_IME_INTERNAL_EDITING";

        /// <summary>
        ///     The sdl hint android separate mouse and touch
        /// </summary>
        public const string SdlHintAndroidSeparateMouseAndTouch =
            "SDL_ANDROID_SEPARATE_MOUSE_AND_TOUCH";

        /// <summary>
        ///     The sdl hint emscripten keyboard element
        /// </summary>
        public const string SdlHintEmscriptenKeyboardElement =
            "SDL_EMSCRIPTEN_KEYBOARD_ELEMENT";

        /// <summary>
        ///     The sdl hint thread stack size
        /// </summary>
        public const string SdlHintThreadStackSize =
            "SDL_THREAD_STACK_SIZE";

        /// <summary>
        ///     The sdl hint window frame usable while cursor hidden
        /// </summary>
        public const string SdlHintWindowFrameUsableWhileCursorHidden =
            "SDL_WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN";

        /// <summary>
        ///     The sdl hint windows enable messageloop
        /// </summary>
        public const string SdlHintWindowsEnableMessageloop =
            "SDL_WINDOWS_ENABLE_MESSAGELOOP";

        /// <summary>
        ///     The sdl hint windows no close on alt f4
        /// </summary>
        public const string SdlHintWindowsNoCloseOnAltF4 =
            "SDL_WINDOWS_NO_CLOSE_ON_ALT_F4";

        /// <summary>
        ///     The sdl hint xinput use old joystick mapping
        /// </summary>
        public const string SdlHintXinputUseOldJoystickMapping =
            "SDL_XINPUT_USE_OLD_JOYSTICK_MAPPING";

        /// <summary>
        ///     The sdl hint mac background app
        /// </summary>
        public const string SdlHintMacBackgroundApp =
            "SDL_MAC_BACKGROUND_APP";

        /// <summary>
        ///     The sdl hint video x11 net wm ping
        /// </summary>
        public const string SdlHintVideoX11NetWmPing =
            "SDL_VIDEO_X11_NET_WM_PING";

        /// <summary>
        ///     The sdl hint android apk expansion main file version
        /// </summary>
        public const string SdlHintAndroidApkExpansionMainFileVersion =
            "SDL_ANDROID_APK_EXPANSION_MAIN_FILE_VERSION";

        /// <summary>
        ///     The sdl hint android apk expansion patch file version
        /// </summary>
        public const string SdlHintAndroidApkExpansionPatchFileVersion =
            "SDL_ANDROID_APK_EXPANSION_PATCH_FILE_VERSION";

        /* Only available in 2.0.5 or higher. */
        /// <summary>
        ///     The sdl hint mouse focus clickthrough
        /// </summary>
        public const string SdlHintMouseFocusClickthrough =
            "SDL_MOUSE_FOCUS_CLICKTHROUGH";

        /// <summary>
        ///     The sdl hint bmp save legacy format
        /// </summary>
        public const string SdlHintBmpSaveLegacyFormat =
            "SDL_BMP_SAVE_LEGACY_FORMAT";

        /// <summary>
        ///     The sdl hint windows disable thread naming
        /// </summary>
        public const string SdlHintWindowsDisableThreadNaming =
            "SDL_WINDOWS_DISABLE_THREAD_NAMING";

        /// <summary>
        ///     The sdl hint apple tv remote allow rotation
        /// </summary>
        public const string SdlHintAppleTvRemoteAllowRotation =
            "SDL_APPLE_TV_REMOTE_ALLOW_ROTATION";

        /* Only available in 2.0.6 or higher. */
        /// <summary>
        ///     The sdl hint audio resampling mode
        /// </summary>
        public const string SdlHintAudioResamplingMode =
            "SDL_AUDIO_RESAMPLING_MODE";

        /// <summary>
        ///     The sdl hint render logical size mode
        /// </summary>
        public const string SdlHintRenderLogicalSizeMode =
            "SDL_RENDER_LOGICAL_SIZE_MODE";

        /// <summary>
        ///     The sdl hint mouse normal speed scale
        /// </summary>
        public const string SdlHintMouseNormalSpeedScale =
            "SDL_MOUSE_NORMAL_SPEED_SCALE";

        /// <summary>
        ///     The sdl hint mouse relative speed scale
        /// </summary>
        public const string SdlHintMouseRelativeSpeedScale =
            "SDL_MOUSE_RELATIVE_SPEED_SCALE";

        /// <summary>
        ///     The sdl hint touch mouse events
        /// </summary>
        public const string SdlHintTouchMouseEvents =
            "SDL_TOUCH_MOUSE_EVENTS";

        /// <summary>
        ///     The sdl hint windows intresource icon
        /// </summary>
        public const string SdlHintWindowsIntresourceIcon =
            "SDL_WINDOWS_INTRESOURCE_ICON";

        /// <summary>
        ///     The sdl hint windows intresource icon small
        /// </summary>
        public const string SdlHintWindowsIntresourceIconSmall =
            "SDL_WINDOWS_INTRESOURCE_ICON_SMALL";

        /* Only available in 2.0.8 or higher. */
        /// <summary>
        ///     The sdl hint ios hide home indicator
        /// </summary>
        public const string SdlHintIosHideHomeIndicator =
            "SDL_IOS_HIDE_HOME_INDICATOR";

        /// <summary>
        ///     The sdl hint tv remote as joystick
        /// </summary>
        public const string SdlHintTvRemoteAsJoystick =
            "SDL_TV_REMOTE_AS_JOYSTICK";

        /// <summary>
        ///     The sdl video x11 net wm bypass compositor
        /// </summary>
        public const string SdlVideoX11NetWmBypassCompositor =
            "SDL_VIDEO_X11_NET_WM_BYPASS_COMPOSITOR";

        /* Only available in 2.0.9 or higher. */
        /// <summary>
        ///     The sdl hint mouse double click time
        /// </summary>
        public const string SdlHintMouseDoubleClickTime =
            "SDL_MOUSE_DOUBLE_CLICK_TIME";

        /// <summary>
        ///     The sdl hint mouse double click radius
        /// </summary>
        public const string SdlHintMouseDoubleClickRadius =
            "SDL_MOUSE_DOUBLE_CLICK_RADIUS";

        /// <summary>
        ///     The sdl hint joystick hidapi
        /// </summary>
        public const string SdlHintJoystickHidapi =
            "SDL_JOYSTICK_HIDAPI";

        /// <summary>
        ///     The sdl hint joystick hidapi ps4
        /// </summary>
        public const string SdlHintJoystickHidapiPs4 =
            "SDL_JOYSTICK_HIDAPI_PS4";

        /// <summary>
        ///     The sdl hint joystick hidapi ps4 rumble
        /// </summary>
        public const string SdlHintJoystickHidapiPs4Rumble =
            "SDL_JOYSTICK_HIDAPI_PS4_RUMBLE";

        /// <summary>
        ///     The sdl hint joystick hidapi steam
        /// </summary>
        public const string SdlHintJoystickHidapiSteam =
            "SDL_JOYSTICK_HIDAPI_STEAM";

        /// <summary>
        ///     The sdl hint joystick hidapi switch
        /// </summary>
        public const string SdlHintJoystickHidapiSwitch =
            "SDL_JOYSTICK_HIDAPI_SWITCH";

        /// <summary>
        ///     The sdl hint joystick hidapi xbox
        /// </summary>
        public const string SdlHintJoystickHidapiXbox =
            "SDL_JOYSTICK_HIDAPI_XBOX";

        /// <summary>
        ///     The sdl hint enable steam controllers
        /// </summary>
        public const string SdlHintEnableSteamControllers =
            "SDL_ENABLE_STEAM_CONTROLLERS";

        /// <summary>
        ///     The sdl hint android trap back button
        /// </summary>
        public const string SdlHintAndroidTrapBackButton =
            "SDL_ANDROID_TRAP_BACK_BUTTON";

        /* Only available in 2.0.10 or higher. */
        /// <summary>
        ///     The sdl hint mouse touch events
        /// </summary>
        public const string SdlHintMouseTouchEvents =
            "SDL_MOUSE_TOUCH_EVENTS";

        /// <summary>
        ///     The sdl hint gamecontrollerconfig file
        /// </summary>
        public const string SdlHintGamecontrollerconfigFile =
            "SDL_GAMECONTROLLERCONFIG_FILE";

        /// <summary>
        ///     The sdl hint android block on pause
        /// </summary>
        public const string SdlHintAndroidBlockOnPause =
            "SDL_ANDROID_BLOCK_ON_PAUSE";

        /// <summary>
        ///     The sdl hint render batching
        /// </summary>
        public const string SdlHintRenderBatching =
            "SDL_RENDER_BATCHING";

        /// <summary>
        ///     The sdl hint event logging
        /// </summary>
        public const string SdlHintEventLogging =
            "SDL_EVENT_LOGGING";

        /// <summary>
        ///     The sdl hint wave riff chunk size
        /// </summary>
        public const string SdlHintWaveRiffChunkSize =
            "SDL_WAVE_RIFF_CHUNK_SIZE";

        /// <summary>
        ///     The sdl hint wave truncation
        /// </summary>
        public const string SdlHintWaveTruncation =
            "SDL_WAVE_TRUNCATION";

        /// <summary>
        ///     The sdl hint wave fact chunk
        /// </summary>
        public const string SdlHintWaveFactChunk =
            "SDL_WAVE_FACT_CHUNK";

        /* Only available in 2.0.11 or higher. */
        /// <summary>
        ///     The sdl hint vido x11 window visualid
        /// </summary>
        public const string SdlHintVidoX11WindowVisualid =
            "SDL_VIDEO_X11_WINDOW_VISUALID";

        /// <summary>
        ///     The sdl hint gamecontroller use button labels
        /// </summary>
        public const string SdlHintGamecontrollerUseButtonLabels =
            "SDL_GAMECONTROLLER_USE_BUTTON_LABELS";

        /// <summary>
        ///     The sdl hint video external context
        /// </summary>
        public const string SdlHintVideoExternalContext =
            "SDL_VIDEO_EXTERNAL_CONTEXT";

        /// <summary>
        ///     The sdl hint joystick hidapi gamecube
        /// </summary>
        public const string SdlHintJoystickHidapiGamecube =
            "SDL_JOYSTICK_HIDAPI_GAMECUBE";

        /// <summary>
        ///     The sdl hint display usable bounds
        /// </summary>
        public const string SdlHintDisplayUsableBounds =
            "SDL_DISPLAY_USABLE_BOUNDS";

        /// <summary>
        ///     The sdl hint video x11 force egl
        /// </summary>
        public const string SdlHintVideoX11ForceEgl =
            "SDL_VIDEO_X11_FORCE_EGL";

        /// <summary>
        ///     The sdl hint gamecontrollertype
        /// </summary>
        public const string SdlHintGamecontrollertype =
            "SDL_GAMECONTROLLERTYPE";

        /* Only available in 2.0.14 or higher. */
        /// <summary>
        ///     The sdl hint joystick hidapi correlate xinput
        /// </summary>
        public const string SdlHintJoystickHidapiCorrelateXinput =
            "SDL_JOYSTICK_HIDAPI_CORRELATE_XINPUT"; /* NOTE: This was removed in 2.0.16. */

        /// <summary>
        ///     The sdl hint joystick rawinput
        /// </summary>
        public const string SdlHintJoystickRawinput =
            "SDL_JOYSTICK_RAWINPUT";

        /// <summary>
        ///     The sdl hint audio device app name
        /// </summary>
        public const string SdlHintAudioDeviceAppName =
            "SDL_AUDIO_DEVICE_APP_NAME";

        /// <summary>
        ///     The sdl hint audio device stream name
        /// </summary>
        public const string SdlHintAudioDeviceStreamName =
            "SDL_AUDIO_DEVICE_STREAM_NAME";

        /// <summary>
        ///     The sdl hint preferred locales
        /// </summary>
        public const string SdlHintPreferredLocales =
            "SDL_PREFERRED_LOCALES";

        /// <summary>
        ///     The sdl hint thread priority policy
        /// </summary>
        public const string SdlHintThreadPriorityPolicy =
            "SDL_THREAD_PRIORITY_POLICY";

        /// <summary>
        ///     The sdl hint emscripten asyncify
        /// </summary>
        public const string SdlHintEmscriptenAsyncify =
            "SDL_EMSCRIPTEN_ASYNCIFY";

        /// <summary>
        ///     The sdl hint linux joystick deadzones
        /// </summary>
        public const string SdlHintLinuxJoystickDeadzones =
            "SDL_LINUX_JOYSTICK_DEADZONES";

        /// <summary>
        ///     The sdl hint android block on pause pauseaudio
        /// </summary>
        public const string SdlHintAndroidBlockOnPausePauseaudio =
            "SDL_ANDROID_BLOCK_ON_PAUSE_PAUSEAUDIO";

        /// <summary>
        ///     The sdl hint joystick hidapi ps5
        /// </summary>
        public const string SdlHintJoystickHidapiPs5 =
            "SDL_JOYSTICK_HIDAPI_PS5";

        /// <summary>
        ///     The sdl hint thread force realtime time critical
        /// </summary>
        public const string SdlHintThreadForceRealtimeTimeCritical =
            "SDL_THREAD_FORCE_REALTIME_TIME_CRITICAL";

        /// <summary>
        ///     The sdl hint joystick thread
        /// </summary>
        public const string SdlHintJoystickThread =
            "SDL_JOYSTICK_THREAD";

        /// <summary>
        ///     The sdl hint auto update joysticks
        /// </summary>
        public const string SdlHintAutoUpdateJoysticks =
            "SDL_AUTO_UPDATE_JOYSTICKS";

        /// <summary>
        ///     The sdl hint auto update sensors
        /// </summary>
        public const string SdlHintAutoUpdateSensors =
            "SDL_AUTO_UPDATE_SENSORS";

        /// <summary>
        ///     The sdl hint mouse relative scaling
        /// </summary>
        public const string SdlHintMouseRelativeScaling =
            "SDL_MOUSE_RELATIVE_SCALING";

        /// <summary>
        ///     The sdl hint joystick hidapi ps5 rumble
        /// </summary>
        public const string SdlHintJoystickHidapiPs5Rumble =
            "SDL_JOYSTICK_HIDAPI_PS5_RUMBLE";

        /* Only available in 2.0.16 or higher. */
        /// <summary>
        ///     The sdl hint windows force mutex critical sections
        /// </summary>
        public const string SdlHintWindowsForceMutexCriticalSections =
            "SDL_WINDOWS_FORCE_MUTEX_CRITICAL_SECTIONS";

        /// <summary>
        ///     The sdl hint windows force semaphore kernel
        /// </summary>
        public const string SdlHintWindowsForceSemaphoreKernel =
            "SDL_WINDOWS_FORCE_SEMAPHORE_KERNEL";

        /// <summary>
        ///     The sdl hint joystick hidapi ps5 player led
        /// </summary>
        public const string SdlHintJoystickHidapiPs5PlayerLed =
            "SDL_JOYSTICK_HIDAPI_PS5_PLAYER_LED";

        /// <summary>
        ///     The sdl hint windows use d3d9ex
        /// </summary>
        public const string SdlHintWindowsUseD3D9Ex =
            "SDL_WINDOWS_USE_D3D9EX";

        /// <summary>
        ///     The sdl hint joystick hidapi joy cons
        /// </summary>
        public const string SdlHintJoystickHidapiJoyCons =
            "SDL_JOYSTICK_HIDAPI_JOY_CONS";

        /// <summary>
        ///     The sdl hint joystick hidapi stadia
        /// </summary>
        public const string SdlHintJoystickHidapiStadia =
            "SDL_JOYSTICK_HIDAPI_STADIA";

        /// <summary>
        ///     The sdl hint joystick hidapi switch home led
        /// </summary>
        public const string SdlHintJoystickHidapiSwitchHomeLed =
            "SDL_JOYSTICK_HIDAPI_SWITCH_HOME_LED";

        /// <summary>
        ///     The sdl hint allow alt tab while grabbed
        /// </summary>
        public const string SdlHintAllowAltTabWhileGrabbed =
            "SDL_ALLOW_ALT_TAB_WHILE_GRABBED";

        /// <summary>
        ///     The sdl hint kmsdrm require drm master
        /// </summary>
        public const string SdlHintKmsdrmRequireDrmMaster =
            "SDL_KMSDRM_REQUIRE_DRM_MASTER";

        /// <summary>
        ///     The sdl hint audio device stream role
        /// </summary>
        public const string SdlHintAudioDeviceStreamRole =
            "SDL_AUDIO_DEVICE_STREAM_ROLE";

        /// <summary>
        ///     The sdl hint x11 force override redirect
        /// </summary>
        public const string SdlHintX11ForceOverrideRedirect =
            "SDL_X11_FORCE_OVERRIDE_REDIRECT";

        /// <summary>
        ///     The sdl hint joystick hidapi luna
        /// </summary>
        public const string SdlHintJoystickHidapiLuna =
            "SDL_JOYSTICK_HIDAPI_LUNA";

        /// <summary>
        ///     The sdl hint joystick rawinput correlate xinput
        /// </summary>
        public const string SdlHintJoystickRawinputCorrelateXinput =
            "SDL_JOYSTICK_RAWINPUT_CORRELATE_XINPUT";

        /// <summary>
        ///     The sdl hint audio include monitors
        /// </summary>
        public const string SdlHintAudioIncludeMonitors =
            "SDL_AUDIO_INCLUDE_MONITORS";

        /// <summary>
        ///     The sdl hint video wayland allow libdecor
        /// </summary>
        public const string SdlHintVideoWaylandAllowLibdecor =
            "SDL_VIDEO_WAYLAND_ALLOW_LIBDECOR";

        /* Only available in 2.0.18 or higher. */
        /// <summary>
        ///     The sdl hint video egl allow transparency
        /// </summary>
        public const string SdlHintVideoEglAllowTransparency =
            "SDL_VIDEO_EGL_ALLOW_TRANSPARENCY";

        /// <summary>
        ///     The sdl hint app name
        /// </summary>
        public const string SdlHintAppName =
            "SDL_APP_NAME";

        /// <summary>
        ///     The sdl hint screensaver inhibit activity name
        /// </summary>
        public const string SdlHintScreensaverInhibitActivityName =
            "SDL_SCREENSAVER_INHIBIT_ACTIVITY_NAME";

        /// <summary>
        ///     The sdl hint ime show ui
        /// </summary>
        public const string SdlHintImeShowUi =
            "SDL_IME_SHOW_UI";

        /// <summary>
        ///     The sdl hint window no activation when shown
        /// </summary>
        public const string SdlHintWindowNoActivationWhenShown =
            "SDL_WINDOW_NO_ACTIVATION_WHEN_SHOWN";

        /// <summary>
        ///     The sdl hint poll sentinel
        /// </summary>
        public const string SdlHintPollSentinel =
            "SDL_POLL_SENTINEL";

        /// <summary>
        ///     The sdl hint joystick device
        /// </summary>
        public const string SdlHintJoystickDevice =
            "SDL_JOYSTICK_DEVICE";

        /// <summary>
        ///     The sdl hint linux joystick classic
        /// </summary>
        public const string SdlHintLinuxJoystickClassic =
            "SDL_LINUX_JOYSTICK_CLASSIC";

        /// <summary>
        ///     The sdl hintpriority enum
        /// </summary>
        public enum SdlHintPriority
        {
            /// <summary>
            ///     The sdl hint default sdl hintpriority
            /// </summary>
            SdlHintDefault,

            /// <summary>
            ///     The sdl hint normal sdl hintpriority
            /// </summary>
            SdlHintNormal,

            /// <summary>
            ///     The sdl hint override sdl hintpriority
            /// </summary>
            SdlHintOverride
        }

        /// <summary>
        ///     Sdls the clear hints
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ClearHints();

        /// <summary>
        ///     Internals the sdl get hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetHint", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe IntPtr INTERNAL_SDL_GetHint(byte* name);

        /// <summary>
        ///     Sdls the get hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The string</returns>
        public static unsafe string SDL_GetHint(string name)
        {
            int utf8NameBufSize = Utf8Size(name);
            byte* utf8Name = stackalloc byte[utf8NameBufSize];
            return UTF8_ToManaged(
                INTERNAL_SDL_GetHint(
                    Utf8Encode(name, utf8Name, utf8NameBufSize)
                )
            );
        }

        /// <summary>
        ///     Internals the sdl set hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetHint", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe SdlBool INTERNAL_SDL_SetHint(
            byte* name,
            byte* value
        );

        /// <summary>
        ///     Sdls the set hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <returns>The sdl bool</returns>
        public static unsafe SdlBool SDL_SetHint(string name, string value)
        {
            int utf8NameBufSize = Utf8Size(name);
            byte* utf8Name = stackalloc byte[utf8NameBufSize];

            int utf8ValueBufSize = Utf8Size(value);
            byte* utf8Value = stackalloc byte[utf8ValueBufSize];

            return INTERNAL_SDL_SetHint(
                Utf8Encode(name, utf8Name, utf8NameBufSize),
                Utf8Encode(value, utf8Value, utf8ValueBufSize)
            );
        }

        /// <summary>
        ///     Internals the sdl set hint with priority using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="priority">The priority</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetHintWithPriority", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe SdlBool INTERNAL_SDL_SetHintWithPriority(
            byte* name,
            byte* value,
            SdlHintPriority priority
        );

        /// <summary>
        ///     Sdls the set hint with priority using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="priority">The priority</param>
        /// <returns>The sdl bool</returns>
        public static unsafe SdlBool SDL_SetHintWithPriority(
            string name,
            string value,
            SdlHintPriority priority
        )
        {
            int utf8NameBufSize = Utf8Size(name);
            byte* utf8Name = stackalloc byte[utf8NameBufSize];

            int utf8ValueBufSize = Utf8Size(value);
            byte* utf8Value = stackalloc byte[utf8ValueBufSize];

            return INTERNAL_SDL_SetHintWithPriority(
                Utf8Encode(name, utf8Name, utf8NameBufSize),
                Utf8Encode(value, utf8Value, utf8ValueBufSize),
                priority
            );
        }

        /* Only available in 2.0.5 or higher. */
        /// <summary>
        ///     Internals the sdl get hint boolean using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetHintBoolean", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe SdlBool INTERNAL_SDL_GetHintBoolean(
            byte* name,
            SdlBool defaultValue
        );

        /// <summary>
        ///     Sdls the get hint boolean using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The sdl bool</returns>
        public static unsafe SdlBool SDL_GetHintBoolean(
            string name,
            SdlBool defaultValue
        )
        {
            int utf8NameBufSize = Utf8Size(name);
            byte* utf8Name = stackalloc byte[utf8NameBufSize];
            return INTERNAL_SDL_GetHintBoolean(
                Utf8Encode(name, utf8Name, utf8NameBufSize),
                defaultValue
            );
        }

        #endregion

        #region SDL_error.h

        /// <summary>
        ///     Sdls the clear error
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ClearError();

        /// <summary>
        ///     Internals the sdl get error
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetError", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetError();

        /// <summary>
        ///     Sdls the get error
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_GetError() => UTF8_ToManaged(INTERNAL_SDL_GetError());

        /* Use string.Format for arglists */
        /// <summary>
        ///     Internals the sdl set error using the specified fmt and arglist
        /// </summary>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetError", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void INTERNAL_SDL_SetError(byte* fmtAndArglist);

        /// <summary>
        ///     Sdls the set error using the specified fmt and arglist
        /// </summary>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static unsafe void SDL_SetError(string fmtAndArglist)
        {
            int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
            byte* utf8FmtAndArglist = stackalloc byte[utf8FmtAndArglistBufSize];
            INTERNAL_SDL_SetError(
                Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
            );
        }

        /* IntPtr refers to a char*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Sdls the get error msg using the specified errstr
        /// </summary>
        /// <param name="errstr">The errstr</param>
        /// <param name="maxlength">The maxlength</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetErrorMsg(IntPtr errstr, int maxlength);

        #endregion

        #region SDL_log.h

        /// <summary>
        ///     The sdl logcategory enum
        /// </summary>
        public enum SdlLogCategory
        {
            /// <summary>
            ///     The sdl log category application sdl logcategory
            /// </summary>
            SdlLogCategoryApplication,

            /// <summary>
            ///     The sdl log category error sdl logcategory
            /// </summary>
            SdlLogCategoryError,

            /// <summary>
            ///     The sdl log category assert sdl logcategory
            /// </summary>
            SdlLogCategoryAssert,

            /// <summary>
            ///     The sdl log category system sdl logcategory
            /// </summary>
            SdlLogCategorySystem,

            /// <summary>
            ///     The sdl log category audio sdl logcategory
            /// </summary>
            SdlLogCategoryAudio,

            /// <summary>
            ///     The sdl log category video sdl logcategory
            /// </summary>
            SdlLogCategoryVideo,

            /// <summary>
            ///     The sdl log category render sdl logcategory
            /// </summary>
            SdlLogCategoryRender,

            /// <summary>
            ///     The sdl log category input sdl logcategory
            /// </summary>
            SdlLogCategoryInput,

            /// <summary>
            ///     The sdl log category test sdl logcategory
            /// </summary>
            SdlLogCategoryTest,

            /* Reserved for future SDL library use */
            /// <summary>
            ///     The sdl log category reserved1 sdl logcategory
            /// </summary>
            SdlLogCategoryReserved1,

            /// <summary>
            ///     The sdl log category reserved2 sdl logcategory
            /// </summary>
            SdlLogCategoryReserved2,

            /// <summary>
            ///     The sdl log category reserved3 sdl logcategory
            /// </summary>
            SdlLogCategoryReserved3,

            /// <summary>
            ///     The sdl log category reserved4 sdl logcategory
            /// </summary>
            SdlLogCategoryReserved4,

            /// <summary>
            ///     The sdl log category reserved5 sdl logcategory
            /// </summary>
            SdlLogCategoryReserved5,

            /// <summary>
            ///     The sdl log category reserved6 sdl logcategory
            /// </summary>
            SdlLogCategoryReserved6,

            /// <summary>
            ///     The sdl log category reserved7 sdl logcategory
            /// </summary>
            SdlLogCategoryReserved7,

            /// <summary>
            ///     The sdl log category reserved8 sdl logcategory
            /// </summary>
            SdlLogCategoryReserved8,

            /// <summary>
            ///     The sdl log category reserved9 sdl logcategory
            /// </summary>
            SdlLogCategoryReserved9,

            /// <summary>
            ///     The sdl log category reserved10 sdl logcategory
            /// </summary>
            SdlLogCategoryReserved10,

            /* Beyond this point is reserved for application use, e.g.
            enum {
                MYAPP_CATEGORY_AWESOME1 = SDL_LOG_CATEGORY_CUSTOM,
                MYAPP_CATEGORY_AWESOME2,
                MYAPP_CATEGORY_AWESOME3,
                ...
            };
            */
            /// <summary>
            ///     The sdl log category custom sdl logcategory
            /// </summary>
            SdlLogCategoryCustom
        }

        /// <summary>
        ///     The sdl logpriority enum
        /// </summary>
        public enum SdlLogPriority
        {
            /// <summary>
            ///     The sdl log priority verbose sdl logpriority
            /// </summary>
            SdlLogPriorityVerbose = 1,

            /// <summary>
            ///     The sdl log priority debug sdl logpriority
            /// </summary>
            SdlLogPriorityDebug,

            /// <summary>
            ///     The sdl log priority info sdl logpriority
            /// </summary>
            SdlLogPriorityInfo,

            /// <summary>
            ///     The sdl log priority warn sdl logpriority
            /// </summary>
            SdlLogPriorityWarn,

            /// <summary>
            ///     The sdl log priority error sdl logpriority
            /// </summary>
            SdlLogPriorityError,

            /// <summary>
            ///     The sdl log priority critical sdl logpriority
            /// </summary>
            SdlLogPriorityCritical,

            /// <summary>
            ///     The sdl num log priorities sdl logpriority
            /// </summary>
            SdlNumLogPriorities
        }

        /* userdata refers to a void*, message to a const char* */
        /// <summary>
        ///     The sdl logoutputfunction
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SdlLogOutputFunction(
            IntPtr userdata,
            int category,
            SdlLogPriority priority,
            IntPtr message
        );

        /* Use string.Format for arglists */
        /// <summary>
        ///     Internals the sdl log using the specified fmt and arglist
        /// </summary>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_Log", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void INTERNAL_SDL_Log(byte* fmtAndArglist);

        /// <summary>
        ///     Sdls the log using the specified fmt and arglist
        /// </summary>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static unsafe void SDL_Log(string fmtAndArglist)
        {
            int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
            byte* utf8FmtAndArglist = stackalloc byte[utf8FmtAndArglistBufSize];
            INTERNAL_SDL_Log(
                Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
            );
        }

        /* Use string.Format for arglists */
        /// <summary>
        ///     Internals the sdl log verbose using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogVerbose", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void INTERNAL_SDL_LogVerbose(
            int category,
            byte* fmtAndArglist
        );

        /// <summary>
        ///     Sdls the log verbose using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static unsafe void SDL_LogVerbose(
            int category,
            string fmtAndArglist
        )
        {
            int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
            byte* utf8FmtAndArglist = stackalloc byte[utf8FmtAndArglistBufSize];
            INTERNAL_SDL_LogVerbose(
                category,
                Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
            );
        }

        /* Use string.Format for arglists */
        /// <summary>
        ///     Internals the sdl log debug using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogDebug", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void INTERNAL_SDL_LogDebug(
            int category,
            byte* fmtAndArglist
        );

        /// <summary>
        ///     Sdls the log debug using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static unsafe void SDL_LogDebug(
            int category,
            string fmtAndArglist
        )
        {
            int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
            byte* utf8FmtAndArglist = stackalloc byte[utf8FmtAndArglistBufSize];
            INTERNAL_SDL_LogDebug(
                category,
                Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
            );
        }

        /* Use string.Format for arglists */
        /// <summary>
        ///     Internals the sdl log info using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogInfo", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void INTERNAL_SDL_LogInfo(
            int category,
            byte* fmtAndArglist
        );

        /// <summary>
        ///     Sdls the log info using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static unsafe void SDL_LogInfo(
            int category,
            string fmtAndArglist
        )
        {
            int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
            byte* utf8FmtAndArglist = stackalloc byte[utf8FmtAndArglistBufSize];
            INTERNAL_SDL_LogInfo(
                category,
                Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
            );
        }

        /* Use string.Format for arglists */
        /// <summary>
        ///     Internals the sdl log warn using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogWarn", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void INTERNAL_SDL_LogWarn(
            int category,
            byte* fmtAndArglist
        );

        /// <summary>
        ///     Sdls the log warn using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static unsafe void SDL_LogWarn(
            int category,
            string fmtAndArglist
        )
        {
            int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
            byte* utf8FmtAndArglist = stackalloc byte[utf8FmtAndArglistBufSize];
            INTERNAL_SDL_LogWarn(
                category,
                Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
            );
        }

        /* Use string.Format for arglists */
        /// <summary>
        ///     Internals the sdl log error using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogError", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void INTERNAL_SDL_LogError(
            int category,
            byte* fmtAndArglist
        );

        /// <summary>
        ///     Sdls the log error using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static unsafe void SDL_LogError(
            int category,
            string fmtAndArglist
        )
        {
            int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
            byte* utf8FmtAndArglist = stackalloc byte[utf8FmtAndArglistBufSize];
            INTERNAL_SDL_LogError(
                category,
                Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
            );
        }

        /* Use string.Format for arglists */
        /// <summary>
        ///     Internals the sdl log critical using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogCritical", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void INTERNAL_SDL_LogCritical(
            int category,
            byte* fmtAndArglist
        );

        /// <summary>
        ///     Sdls the log critical using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static unsafe void SDL_LogCritical(
            int category,
            string fmtAndArglist
        )
        {
            int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
            byte* utf8FmtAndArglist = stackalloc byte[utf8FmtAndArglistBufSize];
            INTERNAL_SDL_LogCritical(
                category,
                Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
            );
        }

        /* Use string.Format for arglists */
        /// <summary>
        ///     Internals the sdl log message using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="priority">The priority</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogMessage", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void INTERNAL_SDL_LogMessage(
            int category,
            SdlLogPriority priority,
            byte* fmtAndArglist
        );

        /// <summary>
        ///     Sdls the log message using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="priority">The priority</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static unsafe void SDL_LogMessage(
            int category,
            SdlLogPriority priority,
            string fmtAndArglist
        )
        {
            int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
            byte* utf8FmtAndArglist = stackalloc byte[utf8FmtAndArglistBufSize];
            INTERNAL_SDL_LogMessage(
                category,
                priority,
                Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
            );
        }

        /* Use string.Format for arglists */
        /// <summary>
        ///     Internals the sdl log message v using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="priority">The priority</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogMessageV", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void INTERNAL_SDL_LogMessageV(
            int category,
            SdlLogPriority priority,
            byte* fmtAndArglist
        );

        /// <summary>
        ///     Sdls the log message v using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="priority">The priority</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static unsafe void SDL_LogMessageV(
            int category,
            SdlLogPriority priority,
            string fmtAndArglist
        )
        {
            int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
            byte* utf8FmtAndArglist = stackalloc byte[utf8FmtAndArglistBufSize];
            INTERNAL_SDL_LogMessageV(
                category,
                priority,
                Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
            );
        }

        /// <summary>
        ///     Sdls the log get priority using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <returns>The sdl log priority</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlLogPriority SDL_LogGetPriority(
            int category
        );

        /// <summary>
        ///     Sdls the log set priority using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="priority">The priority</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogSetPriority(
            int category,
            SdlLogPriority priority
        );

        /// <summary>
        ///     Sdls the log set all priority using the specified priority
        /// </summary>
        /// <param name="priority">The priority</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogSetAllPriority(
            SdlLogPriority priority
        );

        /// <summary>
        ///     Sdls the log reset priorities
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogResetPriorities();

        /* userdata refers to a void* */
        /// <summary>
        ///     Sdls the log get output function using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SDL_LogGetOutputFunction(
            out IntPtr callback,
            out IntPtr userdata
        );

        /// <summary>
        ///     Sdls the log get output function using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="userdata">The userdata</param>
        public static void SDL_LogGetOutputFunction(
            out SdlLogOutputFunction callback,
            out IntPtr userdata
        )
        {
            IntPtr result = IntPtr.Zero;
            SDL_LogGetOutputFunction(
                out result,
                out userdata
            );
            if (result != IntPtr.Zero)
            {
                callback = (SdlLogOutputFunction) Marshal.GetDelegateForFunctionPointer(
                    result,
                    typeof(SdlLogOutputFunction)
                );
            }
            else
            {
                callback = null;
            }
        }

        /* userdata refers to a void* */
        /// <summary>
        ///     Sdls the log set output function using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogSetOutputFunction(
            SdlLogOutputFunction callback,
            IntPtr userdata
        );

        #endregion

        #region SDL_messagebox.h

        /// <summary>
        ///     The sdl messageboxflags enum
        /// </summary>
        [Flags]
        public enum SdlMessageBoxFlags : uint
        {
            /// <summary>
            ///     The sdl messagebox error sdl messageboxflags
            /// </summary>
            SdlMessageboxError = 0x00000010,

            /// <summary>
            ///     The sdl messagebox warning sdl messageboxflags
            /// </summary>
            SdlMessageboxWarning = 0x00000020,

            /// <summary>
            ///     The sdl messagebox information sdl messageboxflags
            /// </summary>
            SdlMessageboxInformation = 0x00000040
        }

        /// <summary>
        ///     The sdl messageboxbuttonflags enum
        /// </summary>
        [Flags]
        public enum SdlMessageBoxButtonFlags : uint
        {
            /// <summary>
            ///     The sdl messagebox button returnkey default sdl messageboxbuttonflags
            /// </summary>
            SdlMessageboxButtonReturnkeyDefault = 0x00000001,

            /// <summary>
            ///     The sdl messagebox button escapekey default sdl messageboxbuttonflags
            /// </summary>
            SdlMessageboxButtonEscapekeyDefault = 0x00000002
        }

        /// <summary>
        ///     The internal sdl messageboxbuttondata
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct InternalSdlMessageBoxButtonData
        {
            /// <summary>
            ///     The flags
            /// </summary>
            public SdlMessageBoxButtonFlags flags;

            /// <summary>
            ///     The buttonid
            /// </summary>
            public int buttonid;

            /// <summary>
            ///     The text
            /// </summary>
            public IntPtr text; /* The UTF-8 button text */
        }

        /// <summary>
        ///     The sdl messageboxbuttondata
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlMessageBoxButtonData
        {
            /// <summary>
            ///     The flags
            /// </summary>
            public SdlMessageBoxButtonFlags flags;

            /// <summary>
            ///     The buttonid
            /// </summary>
            public int buttonid;

            /// <summary>
            ///     The text
            /// </summary>
            public string text; /* The UTF-8 button text */
        }

        /// <summary>
        ///     The sdl messageboxcolor
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlMessageBoxColor
        {
            /// <summary>
            ///     The
            /// </summary>
            public byte r, g, b;
        }

        /// <summary>
        ///     The sdl messageboxcolortype enum
        /// </summary>
        public enum SdlMessageBoxColorType
        {
            /// <summary>
            ///     The sdl messagebox color background sdl messageboxcolortype
            /// </summary>
            SdlMessageboxColorBackground,

            /// <summary>
            ///     The sdl messagebox color text sdl messageboxcolortype
            /// </summary>
            SdlMessageboxColorText,

            /// <summary>
            ///     The sdl messagebox color button border sdl messageboxcolortype
            /// </summary>
            SdlMessageboxColorButtonBorder,

            /// <summary>
            ///     The sdl messagebox color button background sdl messageboxcolortype
            /// </summary>
            SdlMessageboxColorButtonBackground,

            /// <summary>
            ///     The sdl messagebox color button selected sdl messageboxcolortype
            /// </summary>
            SdlMessageboxColorButtonSelected,

            /// <summary>
            ///     The sdl messagebox color max sdl messageboxcolortype
            /// </summary>
            SdlMessageboxColorMax
        }

        /// <summary>
        ///     The sdl messageboxcolorscheme
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlMessageBoxColorScheme
        {
            /// <summary>
            ///     The colors
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = (int) SdlMessageBoxColorType.SdlMessageboxColorMax)]
            public SdlMessageBoxColor[] colors;
        }

        /// <summary>
        ///     The internal sdl messageboxdata
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct InternalSdlMessageBoxData
        {
            /// <summary>
            ///     The flags
            /// </summary>
            public SdlMessageBoxFlags flags;

            /// <summary>
            ///     The window
            /// </summary>
            public IntPtr window; /* Parent window, can be NULL */

            /// <summary>
            ///     The title
            /// </summary>
            public IntPtr title; /* UTF-8 title */

            /// <summary>
            ///     The message
            /// </summary>
            public IntPtr message; /* UTF-8 message text */

            /// <summary>
            ///     The numbuttons
            /// </summary>
            public int numbuttons;

            /// <summary>
            ///     The buttons
            /// </summary>
            public IntPtr buttons;

            /// <summary>
            ///     The color scheme
            /// </summary>
            public IntPtr colorScheme; /* Can be NULL to use system settings */
        }

        /// <summary>
        ///     The sdl messageboxdata
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlMessageBoxData
        {
            /// <summary>
            ///     The flags
            /// </summary>
            public SdlMessageBoxFlags flags;

            /// <summary>
            ///     The window
            /// </summary>
            public IntPtr window; /* Parent window, can be NULL */

            /// <summary>
            ///     The title
            /// </summary>
            public string title; /* UTF-8 title */

            /// <summary>
            ///     The message
            /// </summary>
            public string message; /* UTF-8 message text */

            /// <summary>
            ///     The numbuttons
            /// </summary>
            public int numbuttons;

            /// <summary>
            ///     The buttons
            /// </summary>
            public SdlMessageBoxButtonData[] buttons;

            /// <summary>
            ///     The color scheme
            /// </summary>
            public SdlMessageBoxColorScheme? colorScheme; /* Can be NULL to use system settings */
        }

        /// <summary>
        ///     Internals the sdl show message box using the specified messageboxdata
        /// </summary>
        /// <param name="messageboxdata">The messageboxdata</param>
        /// <param name="buttonid">The buttonid</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ShowMessageBox", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_SDL_ShowMessageBox([In] ref InternalSdlMessageBoxData messageboxdata, out int buttonid);

        /* Ripped from Jameson's LpUtf8StrMarshaler */
        /// <summary>
        ///     Internals the alloc utf 8 using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        /// <returns>The mem</returns>
        private static IntPtr INTERNAL_AllocUTF8(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return IntPtr.Zero;
            }

            byte[] bytes = Encoding.UTF8.GetBytes(str + '\0');
            IntPtr mem = SDL_malloc((IntPtr) bytes.Length);
            Marshal.Copy(bytes, 0, mem, bytes.Length);
            return mem;
        }

        /// <summary>
        ///     Sdls the show message box using the specified messageboxdata
        /// </summary>
        /// <param name="messageboxdata">The messageboxdata</param>
        /// <param name="buttonid">The buttonid</param>
        /// <returns>The result</returns>
        public static unsafe int SDL_ShowMessageBox([In] ref SdlMessageBoxData messageboxdata, out int buttonid)
        {
            InternalSdlMessageBoxData data = new InternalSdlMessageBoxData
            {
                flags = messageboxdata.flags,
                window = messageboxdata.window,
                title = INTERNAL_AllocUTF8(messageboxdata.title),
                message = INTERNAL_AllocUTF8(messageboxdata.message),
                numbuttons = messageboxdata.numbuttons
            };

            InternalSdlMessageBoxButtonData[] buttons = new InternalSdlMessageBoxButtonData[messageboxdata.numbuttons];
            for (int i = 0; i < messageboxdata.numbuttons; i++)
            {
                buttons[i] = new InternalSdlMessageBoxButtonData
                {
                    flags = messageboxdata.buttons[i].flags,
                    buttonid = messageboxdata.buttons[i].buttonid,
                    text = INTERNAL_AllocUTF8(messageboxdata.buttons[i].text)
                };
            }

            if (messageboxdata.colorScheme != null)
            {
                data.colorScheme = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SdlMessageBoxColorScheme)));
                Marshal.StructureToPtr(messageboxdata.colorScheme.Value, data.colorScheme, false);
            }

            int result;
            fixed (InternalSdlMessageBoxButtonData* buttonsPtr = &buttons[0])
            {
                data.buttons = (IntPtr) buttonsPtr;
                result = INTERNAL_SDL_ShowMessageBox(ref data, out buttonid);
            }

            Marshal.FreeHGlobal(data.colorScheme);
            for (int i = 0; i < messageboxdata.numbuttons; i++)
            {
                SDL_free(buttons[i].text);
            }

            SDL_free(data.message);
            SDL_free(data.title);

            return result;
        }

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Internals the sdl show simple message box using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="title">The title</param>
        /// <param name="message">The message</param>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ShowSimpleMessageBox", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int INTERNAL_SDL_ShowSimpleMessageBox(
            SdlMessageBoxFlags flags,
            byte* title,
            byte* message,
            IntPtr window
        );

        /// <summary>
        ///     Sdls the show simple message box using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="title">The title</param>
        /// <param name="message">The message</param>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        public static unsafe int SDL_ShowSimpleMessageBox(
            SdlMessageBoxFlags flags,
            string title,
            string message,
            IntPtr window
        )
        {
            int utf8TitleBufSize = Utf8Size(title);
            byte* utf8Title = stackalloc byte[utf8TitleBufSize];

            int utf8MessageBufSize = Utf8Size(message);
            byte* utf8Message = stackalloc byte[utf8MessageBufSize];

            return INTERNAL_SDL_ShowSimpleMessageBox(
                flags,
                Utf8Encode(title, utf8Title, utf8TitleBufSize),
                Utf8Encode(message, utf8Message, utf8MessageBufSize),
                window
            );
        }

        #endregion

        #region SDL_version.h, SDL_revision.h

        /* Similar to the headers, this is the version we're expecting to be
         * running with. You will likely want to check this somewhere in your
         * program!
         */
        /// <summary>
        ///     The sdl major version
        /// </summary>
        public const int SdlMajorVersion = 2;

        /// <summary>
        ///     The sdl minor version
        /// </summary>
        public const int SdlMinorVersion = 0;

        /// <summary>
        ///     The sdl patchlevel
        /// </summary>
        public const int SdlPatchlevel = 18;

        /// <summary>
        ///     The sdl patchlevel
        /// </summary>
        public static readonly int SdlCompiledversion = SDL_VERSIONNUM(
            SdlMajorVersion,
            SdlMinorVersion,
            SdlPatchlevel
        );

        /// <summary>
        ///     The sdl version
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlVersion
        {
            /// <summary>
            ///     The major
            /// </summary>
            public byte major;

            /// <summary>
            ///     The minor
            /// </summary>
            public byte minor;

            /// <summary>
            ///     The patch
            /// </summary>
            public byte patch;
        }

        /// <summary>
        ///     Sdls the version using the specified x
        /// </summary>
        /// <param name="x">The </param>
        public static void SDL_VERSION(out SdlVersion x)
        {
            x.major = SdlMajorVersion;
            x.minor = SdlMinorVersion;
            x.patch = SdlPatchlevel;
        }

        /// <summary>
        ///     Sdls the versionnum using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="z">The </param>
        /// <returns>The int</returns>
        public static int SDL_VERSIONNUM(int x, int y, int z) => x * 1000 + y * 100 + z;

        /// <summary>
        ///     Describes whether sdl version atleast
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="z">The </param>
        /// <returns>The bool</returns>
        public static bool SDL_VERSION_ATLEAST(int x, int y, int z) => SdlCompiledversion >= SDL_VERSIONNUM(x, y, z);

        /// <summary>
        ///     Sdls the get version using the specified ver
        /// </summary>
        /// <param name="ver">The ver</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetVersion(out SdlVersion ver);

        /// <summary>
        ///     Internals the sdl get revision
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRevision", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetRevision();

        /// <summary>
        ///     Sdls the get revision
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_GetRevision() => UTF8_ToManaged(INTERNAL_SDL_GetRevision());

        /// <summary>
        ///     Sdls the get revision number
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRevisionNumber();

        #endregion

        #region SDL_video.h

        /// <summary>
        ///     The sdl glattr enum
        /// </summary>
        public enum SdlGLattr
        {
            /// <summary>
            ///     The sdl gl red size sdl glattr
            /// </summary>
            SdlGlRedSize,

            /// <summary>
            ///     The sdl gl green size sdl glattr
            /// </summary>
            SdlGlGreenSize,

            /// <summary>
            ///     The sdl gl blue size sdl glattr
            /// </summary>
            SdlGlBlueSize,

            /// <summary>
            ///     The sdl gl alpha size sdl glattr
            /// </summary>
            SdlGlAlphaSize,

            /// <summary>
            ///     The sdl gl buffer size sdl glattr
            /// </summary>
            SdlGlBufferSize,

            /// <summary>
            ///     The sdl gl doublebuffer sdl glattr
            /// </summary>
            SdlGlDoublebuffer,

            /// <summary>
            ///     The sdl gl depth size sdl glattr
            /// </summary>
            SdlGlDepthSize,

            /// <summary>
            ///     The sdl gl stencil size sdl glattr
            /// </summary>
            SdlGlStencilSize,

            /// <summary>
            ///     The sdl gl accum red size sdl glattr
            /// </summary>
            SdlGlAccumRedSize,

            /// <summary>
            ///     The sdl gl accum green size sdl glattr
            /// </summary>
            SdlGlAccumGreenSize,

            /// <summary>
            ///     The sdl gl accum blue size sdl glattr
            /// </summary>
            SdlGlAccumBlueSize,

            /// <summary>
            ///     The sdl gl accum alpha size sdl glattr
            /// </summary>
            SdlGlAccumAlphaSize,

            /// <summary>
            ///     The sdl gl stereo sdl glattr
            /// </summary>
            SdlGlStereo,

            /// <summary>
            ///     The sdl gl multisamplebuffers sdl glattr
            /// </summary>
            SdlGlMultisamplebuffers,

            /// <summary>
            ///     The sdl gl multisamplesamples sdl glattr
            /// </summary>
            SdlGlMultisamplesamples,

            /// <summary>
            ///     The sdl gl accelerated visual sdl glattr
            /// </summary>
            SdlGlAcceleratedVisual,

            /// <summary>
            ///     The sdl gl retained backing sdl glattr
            /// </summary>
            SdlGlRetainedBacking,

            /// <summary>
            ///     The sdl gl context major version sdl glattr
            /// </summary>
            SdlGlContextMajorVersion,

            /// <summary>
            ///     The sdl gl context minor version sdl glattr
            /// </summary>
            SdlGlContextMinorVersion,

            /// <summary>
            ///     The sdl gl context egl sdl glattr
            /// </summary>
            SdlGlContextEgl,

            /// <summary>
            ///     The sdl gl context flags sdl glattr
            /// </summary>
            SdlGlContextFlags,

            /// <summary>
            ///     The sdl gl context profile mask sdl glattr
            /// </summary>
            SdlGlContextProfileMask,

            /// <summary>
            ///     The sdl gl share with current context sdl glattr
            /// </summary>
            SdlGlShareWithCurrentContext,

            /// <summary>
            ///     The sdl gl framebuffer srgb capable sdl glattr
            /// </summary>
            SdlGlFramebufferSrgbCapable,

            /// <summary>
            ///     The sdl gl context release behavior sdl glattr
            /// </summary>
            SdlGlContextReleaseBehavior,

            /// <summary>
            ///     The sdl gl context reset notification sdl glattr
            /// </summary>
            SdlGlContextResetNotification, /* Requires >= 2.0.6 */

            /// <summary>
            ///     The sdl gl context no error sdl glattr
            /// </summary>
            SdlGlContextNoError /* Requires >= 2.0.6 */
        }

        /// <summary>
        ///     The sdl glprofile enum
        /// </summary>
        [Flags]
        public enum SdlGLprofile
        {
            /// <summary>
            ///     The sdl gl context profile core sdl glprofile
            /// </summary>
            SdlGlContextProfileCore = 0x0001,

            /// <summary>
            ///     The sdl gl context profile compatibility sdl glprofile
            /// </summary>
            SdlGlContextProfileCompatibility = 0x0002,

            /// <summary>
            ///     The sdl gl context profile es sdl glprofile
            /// </summary>
            SdlGlContextProfileEs = 0x0004
        }

        /// <summary>
        ///     The sdl glcontext enum
        /// </summary>
        [Flags]
        public enum SdlGLcontext
        {
            /// <summary>
            ///     The sdl gl context debug flag sdl glcontext
            /// </summary>
            SdlGlContextDebugFlag = 0x0001,

            /// <summary>
            ///     The sdl gl context forward compatible flag sdl glcontext
            /// </summary>
            SdlGlContextForwardCompatibleFlag = 0x0002,

            /// <summary>
            ///     The sdl gl context robust access flag sdl glcontext
            /// </summary>
            SdlGlContextRobustAccessFlag = 0x0004,

            /// <summary>
            ///     The sdl gl context reset isolation flag sdl glcontext
            /// </summary>
            SdlGlContextResetIsolationFlag = 0x0008
        }

        /// <summary>
        ///     The sdl windoweventid enum
        /// </summary>
        public enum SdlWindowEventId : byte
        {
            /// <summary>
            ///     The sdl windowevent none sdl windoweventid
            /// </summary>
            SdlWindoweventNone,

            /// <summary>
            ///     The sdl windowevent shown sdl windoweventid
            /// </summary>
            SdlWindoweventShown,

            /// <summary>
            ///     The sdl windowevent hidden sdl windoweventid
            /// </summary>
            SdlWindoweventHidden,

            /// <summary>
            ///     The sdl windowevent exposed sdl windoweventid
            /// </summary>
            SdlWindoweventExposed,

            /// <summary>
            ///     The sdl windowevent moved sdl windoweventid
            /// </summary>
            SdlWindoweventMoved,

            /// <summary>
            ///     The sdl windowevent resized sdl windoweventid
            /// </summary>
            SdlWindoweventResized,

            /// <summary>
            ///     The sdl windowevent size changed sdl windoweventid
            /// </summary>
            SdlWindoweventSizeChanged,

            /// <summary>
            ///     The sdl windowevent minimized sdl windoweventid
            /// </summary>
            SdlWindoweventMinimized,

            /// <summary>
            ///     The sdl windowevent maximized sdl windoweventid
            /// </summary>
            SdlWindoweventMaximized,

            /// <summary>
            ///     The sdl windowevent restored sdl windoweventid
            /// </summary>
            SdlWindoweventRestored,

            /// <summary>
            ///     The sdl windowevent enter sdl windoweventid
            /// </summary>
            SdlWindoweventEnter,

            /// <summary>
            ///     The sdl windowevent leave sdl windoweventid
            /// </summary>
            SdlWindoweventLeave,

            /// <summary>
            ///     The sdl windowevent focus gained sdl windoweventid
            /// </summary>
            SdlWindoweventFocusGained,

            /// <summary>
            ///     The sdl windowevent focus lost sdl windoweventid
            /// </summary>
            SdlWindoweventFocusLost,

            /// <summary>
            ///     The sdl windowevent close sdl windoweventid
            /// </summary>
            SdlWindoweventClose,

            /* Only available in 2.0.5 or higher. */
            /// <summary>
            ///     The sdl windowevent take focus sdl windoweventid
            /// </summary>
            SdlWindoweventTakeFocus,

            /// <summary>
            ///     The sdl windowevent hit test sdl windoweventid
            /// </summary>
            SdlWindoweventHitTest,

            /* Only available in 2.0.18 or higher. */
            /// <summary>
            ///     The sdl windowevent iccprof changed sdl windoweventid
            /// </summary>
            SdlWindoweventIccprofChanged,

            /// <summary>
            ///     The sdl windowevent display changed sdl windoweventid
            /// </summary>
            SdlWindoweventDisplayChanged
        }

        /// <summary>
        ///     The sdl displayeventid enum
        /// </summary>
        public enum SdlDisplayEventId : byte
        {
            /// <summary>
            ///     The sdl displayevent none sdl displayeventid
            /// </summary>
            SdlDisplayeventNone,

            /// <summary>
            ///     The sdl displayevent orientation sdl displayeventid
            /// </summary>
            SdlDisplayeventOrientation,

            /// <summary>
            ///     The sdl displayevent connected sdl displayeventid
            /// </summary>
            SdlDisplayeventConnected, /* Requires >= 2.0.14 */

            /// <summary>
            ///     The sdl displayevent disconnected sdl displayeventid
            /// </summary>
            SdlDisplayeventDisconnected /* Requires >= 2.0.14 */
        }

        /// <summary>
        ///     The sdl displayorientation enum
        /// </summary>
        public enum SdlDisplayOrientation
        {
            /// <summary>
            ///     The sdl orientation unknown sdl displayorientation
            /// </summary>
            SdlOrientationUnknown,

            /// <summary>
            ///     The sdl orientation landscape sdl displayorientation
            /// </summary>
            SdlOrientationLandscape,

            /// <summary>
            ///     The sdl orientation landscape flipped sdl displayorientation
            /// </summary>
            SdlOrientationLandscapeFlipped,

            /// <summary>
            ///     The sdl orientation portrait sdl displayorientation
            /// </summary>
            SdlOrientationPortrait,

            /// <summary>
            ///     The sdl orientation portrait flipped sdl displayorientation
            /// </summary>
            SdlOrientationPortraitFlipped
        }

        /* Only available in 2.0.16 or higher. */
        /// <summary>
        ///     The sdl flashoperation enum
        /// </summary>
        public enum SdlFlashOperation
        {
            /// <summary>
            ///     The sdl flash cancel sdl flashoperation
            /// </summary>
            SdlFlashCancel,

            /// <summary>
            ///     The sdl flash briefly sdl flashoperation
            /// </summary>
            SdlFlashBriefly,

            /// <summary>
            ///     The sdl flash until focused sdl flashoperation
            /// </summary>
            SdlFlashUntilFocused
        }

        /// <summary>
        ///     The sdl windowflags enum
        /// </summary>
        [Flags]
        public enum SdlWindowFlags : uint
        {
            /// <summary>
            ///     The sdl window fullscreen sdl windowflags
            /// </summary>
            SdlWindowFullscreen = 0x00000001,

            /// <summary>
            ///     The sdl window opengl sdl windowflags
            /// </summary>
            SdlWindowOpengl = 0x00000002,

            /// <summary>
            ///     The sdl window shown sdl windowflags
            /// </summary>
            SdlWindowShown = 0x00000004,

            /// <summary>
            ///     The sdl window hidden sdl windowflags
            /// </summary>
            SdlWindowHidden = 0x00000008,

            /// <summary>
            ///     The sdl window borderless sdl windowflags
            /// </summary>
            SdlWindowBorderless = 0x00000010,

            /// <summary>
            ///     The sdl window resizable sdl windowflags
            /// </summary>
            SdlWindowResizable = 0x00000020,

            /// <summary>
            ///     The sdl window minimized sdl windowflags
            /// </summary>
            SdlWindowMinimized = 0x00000040,

            /// <summary>
            ///     The sdl window maximized sdl windowflags
            /// </summary>
            SdlWindowMaximized = 0x00000080,

            /// <summary>
            ///     The sdl window mouse grabbed sdl windowflags
            /// </summary>
            SdlWindowMouseGrabbed = 0x00000100,

            /// <summary>
            ///     The sdl window input focus sdl windowflags
            /// </summary>
            SdlWindowInputFocus = 0x00000200,

            /// <summary>
            ///     The sdl window mouse focus sdl windowflags
            /// </summary>
            SdlWindowMouseFocus = 0x00000400,

            /// <summary>
            ///     The sdl window fullscreen desktop sdl windowflags
            /// </summary>
            SdlWindowFullscreenDesktop =
                SdlWindowFullscreen | 0x00001000,

            /// <summary>
            ///     The sdl window foreign sdl windowflags
            /// </summary>
            SdlWindowForeign = 0x00000800,

            /// <summary>
            ///     The sdl window allow highdpi sdl windowflags
            /// </summary>
            SdlWindowAllowHighdpi = 0x00002000, /* Requires >= 2.0.1 */

            /// <summary>
            ///     The sdl window mouse capture sdl windowflags
            /// </summary>
            SdlWindowMouseCapture = 0x00004000, /* Requires >= 2.0.4 */

            /// <summary>
            ///     The sdl window always on top sdl windowflags
            /// </summary>
            SdlWindowAlwaysOnTop = 0x00008000, /* Requires >= 2.0.5 */

            /// <summary>
            ///     The sdl window skip taskbar sdl windowflags
            /// </summary>
            SdlWindowSkipTaskbar = 0x00010000, /* Requires >= 2.0.5 */

            /// <summary>
            ///     The sdl window utility sdl windowflags
            /// </summary>
            SdlWindowUtility = 0x00020000, /* Requires >= 2.0.5 */

            /// <summary>
            ///     The sdl window tooltip sdl windowflags
            /// </summary>
            SdlWindowTooltip = 0x00040000, /* Requires >= 2.0.5 */

            /// <summary>
            ///     The sdl window popup menu sdl windowflags
            /// </summary>
            SdlWindowPopupMenu = 0x00080000, /* Requires >= 2.0.5 */

            /// <summary>
            ///     The sdl window keyboard grabbed sdl windowflags
            /// </summary>
            SdlWindowKeyboardGrabbed = 0x00100000, /* Requires >= 2.0.16 */

            /// <summary>
            ///     The sdl window vulkan sdl windowflags
            /// </summary>
            SdlWindowVulkan = 0x10000000, /* Requires >= 2.0.6 */

            /// <summary>
            ///     The sdl window metal sdl windowflags
            /// </summary>
            SdlWindowMetal = 0x2000000, /* Requires >= 2.0.14 */

            /// <summary>
            ///     The sdl window input grabbed sdl windowflags
            /// </summary>
            SdlWindowInputGrabbed =
                SdlWindowMouseGrabbed
        }

        /* Only available in 2.0.4 or higher. */
        /// <summary>
        ///     The sdl hittestresult enum
        /// </summary>
        public enum SdlHitTestResult
        {
            /// <summary>
            ///     The sdl hittest normal sdl hittestresult
            /// </summary>
            SdlHittestNormal, /* Region is normal. No special properties. */

            /// <summary>
            ///     The sdl hittest draggable sdl hittestresult
            /// </summary>
            SdlHittestDraggable, /* Region can drag entire window. */

            /// <summary>
            ///     The sdl hittest resize topleft sdl hittestresult
            /// </summary>
            SdlHittestResizeTopleft,

            /// <summary>
            ///     The sdl hittest resize top sdl hittestresult
            /// </summary>
            SdlHittestResizeTop,

            /// <summary>
            ///     The sdl hittest resize topright sdl hittestresult
            /// </summary>
            SdlHittestResizeTopright,

            /// <summary>
            ///     The sdl hittest resize right sdl hittestresult
            /// </summary>
            SdlHittestResizeRight,

            /// <summary>
            ///     The sdl hittest resize bottomright sdl hittestresult
            /// </summary>
            SdlHittestResizeBottomright,

            /// <summary>
            ///     The sdl hittest resize bottom sdl hittestresult
            /// </summary>
            SdlHittestResizeBottom,

            /// <summary>
            ///     The sdl hittest resize bottomleft sdl hittestresult
            /// </summary>
            SdlHittestResizeBottomleft,

            /// <summary>
            ///     The sdl hittest resize left sdl hittestresult
            /// </summary>
            SdlHittestResizeLeft
        }

        /// <summary>
        ///     The sdl windowpos undefined mask
        /// </summary>
        public const int SdlWindowposUndefinedMask = 0x1FFF0000;

        /// <summary>
        ///     The sdl windowpos centered mask
        /// </summary>
        public const int SdlWindowposCenteredMask = 0x2FFF0000;

        /// <summary>
        ///     The sdl windowpos undefined
        /// </summary>
        public const int SdlWindowposUndefined = 0x1FFF0000;

        /// <summary>
        ///     The sdl windowpos centered
        /// </summary>
        public const int SdlWindowposCentered = 0x2FFF0000;

        /// <summary>
        ///     Sdls the windowpos undefined display using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The int</returns>
        public static int SDL_WINDOWPOS_UNDEFINED_DISPLAY(int x) => SdlWindowposUndefinedMask | x;

        /// <summary>
        ///     Describes whether sdl windowpos isundefined
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SDL_WINDOWPOS_ISUNDEFINED(int x) => (x & 0xFFFF0000) == SdlWindowposUndefinedMask;

        /// <summary>
        ///     Sdls the windowpos centered display using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The int</returns>
        public static int SDL_WINDOWPOS_CENTERED_DISPLAY(int x) => SdlWindowposCenteredMask | x;

        /// <summary>
        ///     Describes whether sdl windowpos iscentered
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SDL_WINDOWPOS_ISCENTERED(int x) => (x & 0xFFFF0000) == SdlWindowposCenteredMask;

        /// <summary>
        ///     The sdl displaymode
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlDisplayMode
        {
            /// <summary>
            ///     The format
            /// </summary>
            public uint format;

            /// <summary>
            ///     The
            /// </summary>
            public int w;

            /// <summary>
            ///     The
            /// </summary>
            public int h;

            /// <summary>
            ///     The refresh rate
            /// </summary>
            public int refresh_rate;

            /// <summary>
            ///     The driverdata
            /// </summary>
            public IntPtr driverdata; // void*
        }

        /* win refers to an SDL_Window*, area to a const SDL_Point*, data to a void*.
         * Only available in 2.0.4 or higher.
         */
        /// <summary>
        ///     The sdl hittest
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate SdlHitTestResult SdlHitTest(IntPtr win, IntPtr area, IntPtr data);

        /* IntPtr refers to an SDL_Window* */
        /// <summary>
        ///     Internals the sdl create window using the specified title
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateWindow", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe IntPtr INTERNAL_SDL_CreateWindow(
            byte* title,
            int x,
            int y,
            int w,
            int h,
            SdlWindowFlags flags
        );

        /// <summary>
        ///     Sdls the create window using the specified title
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        public static unsafe IntPtr SDL_CreateWindow(
            string title,
            int x,
            int y,
            int w,
            int h,
            SdlWindowFlags flags
        )
        {
            int utf8TitleBufSize = Utf8Size(title);
            byte* utf8Title = stackalloc byte[utf8TitleBufSize];
            return INTERNAL_SDL_CreateWindow(
                Utf8Encode(title, utf8Title, utf8TitleBufSize),
                x, y, w, h,
                flags
            );
        }

        /* window refers to an SDL_Window*, renderer to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the create window and renderer using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="windowFlags">The window flags</param>
        /// <param name="window">The window</param>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_CreateWindowAndRenderer(
            int width,
            int height,
            SdlWindowFlags windowFlags,
            out IntPtr window,
            out IntPtr renderer
        );

        /* data refers to some native window type, IntPtr to an SDL_Window* */
        /// <summary>
        ///     Sdls the create window from using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateWindowFrom(IntPtr data);

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the destroy window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DestroyWindow(IntPtr window);

        /// <summary>
        ///     Sdls the disable screen saver
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DisableScreenSaver();

        /// <summary>
        ///     Sdls the enable screen saver
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_EnableScreenSaver();

        /* IntPtr refers to an SDL_DisplayMode. Just use closest. */
        /// <summary>
        ///     Sdls the get closest display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <param name="closest">The closest</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetClosestDisplayMode(
            int displayIndex,
            ref SdlDisplayMode mode,
            out SdlDisplayMode closest
        );

        /// <summary>
        ///     Sdls the get current display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetCurrentDisplayMode(
            int displayIndex,
            out SdlDisplayMode mode
        );

        /// <summary>
        ///     Internals the sdl get current video driver
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetCurrentVideoDriver", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetCurrentVideoDriver();

        /// <summary>
        ///     Sdls the get current video driver
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_GetCurrentVideoDriver() => UTF8_ToManaged(INTERNAL_SDL_GetCurrentVideoDriver());

        /// <summary>
        ///     Sdls the get desktop display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDesktopDisplayMode(
            int displayIndex,
            out SdlDisplayMode mode
        );

        /// <summary>
        ///     Internals the sdl get display name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetDisplayName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetDisplayName(int index);

        /// <summary>
        ///     Sdls the get display name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        public static string SDL_GetDisplayName(int index) => UTF8_ToManaged(INTERNAL_SDL_GetDisplayName(index));

        /// <summary>
        ///     Sdls the get display bounds using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDisplayBounds(
            int displayIndex,
            out SdlRect rect
        );

        /* Only available in 2.0.4 or higher. */
        /// <summary>
        ///     Sdls the get display dpi using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="ddpi">The ddpi</param>
        /// <param name="hdpi">The hdpi</param>
        /// <param name="vdpi">The vdpi</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDisplayDPI(
            int displayIndex,
            out float ddpi,
            out float hdpi,
            out float vdpi
        );

        /* Only available in 2.0.9 or higher. */
        /// <summary>
        ///     Sdls the get display orientation using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <returns>The sdl display orientation</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlDisplayOrientation SDL_GetDisplayOrientation(
            int displayIndex
        );

        /// <summary>
        ///     Sdls the get display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="modeIndex">The mode index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDisplayMode(
            int displayIndex,
            int modeIndex,
            out SdlDisplayMode mode
        );

        /* Only available in 2.0.5 or higher. */
        /// <summary>
        ///     Sdls the get display usable bounds using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDisplayUsableBounds(
            int displayIndex,
            out SdlRect rect
        );

        /// <summary>
        ///     Sdls the get num display modes using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumDisplayModes(
            int displayIndex
        );

        /// <summary>
        ///     Sdls the get num video displays
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumVideoDisplays();

        /// <summary>
        ///     Sdls the get num video drivers
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumVideoDrivers();

        /// <summary>
        ///     Internals the sdl get video driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetVideoDriver", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetVideoDriver(
            int index
        );

        /// <summary>
        ///     Sdls the get video driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        public static string SDL_GetVideoDriver(int index) => UTF8_ToManaged(INTERNAL_SDL_GetVideoDriver(index));

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the get window brightness using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The float</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float SDL_GetWindowBrightness(
            IntPtr window
        );

        /* window refers to an SDL_Window*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Sdls the set window opacity using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="opacity">The opacity</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowOpacity(
            IntPtr window,
            float opacity
        );

        /* window refers to an SDL_Window*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Sdls the get window opacity using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="outOpacity">The out opacity</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowOpacity(
            IntPtr window,
            out float outOpacity
        );

        /* modal_window and parent_window refer to an SDL_Window*s
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Sdls the set window modal for using the specified modal window
        /// </summary>
        /// <param name="modalWindow">The modal window</param>
        /// <param name="parentWindow">The parent window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowModalFor(
            IntPtr modalWindow,
            IntPtr parentWindow
        );

        /* window refers to an SDL_Window*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Sdls the set window input focus using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowInputFocus(IntPtr window);

        /* window refers to an SDL_Window*, IntPtr to a void* */
        /// <summary>
        ///     Internals the sdl get window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowData", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe IntPtr INTERNAL_SDL_GetWindowData(
            IntPtr window,
            byte* name
        );

        /// <summary>
        ///     Sdls the get window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        public static unsafe IntPtr SDL_GetWindowData(
            IntPtr window,
            string name
        )
        {
            int utf8NameBufSize = Utf8Size(name);
            byte* utf8Name = stackalloc byte[utf8NameBufSize];
            return INTERNAL_SDL_GetWindowData(
                window,
                Utf8Encode(name, utf8Name, utf8NameBufSize)
            );
        }

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the get window display index using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowDisplayIndex(
            IntPtr window
        );

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the get window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowDisplayMode(
            IntPtr window,
            out SdlDisplayMode mode
        );

        /* IntPtr refers to a void*
         * window refers to an SDL_Window*
         * mode refers to a size_t*
         * Only available in 2.0.18 or higher.
         */
        /// <summary>
        ///     Sdls the get window icc profile using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetWindowICCProfile(
            IntPtr window,
            out IntPtr mode
        );

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the get window flags using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetWindowFlags(IntPtr window);

        /* IntPtr refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the get window from id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetWindowFromID(uint id);

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the get window gamma ramp using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowGammaRamp(
            IntPtr window,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] red,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] green,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] blue
        );

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the get window grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GetWindowGrab(IntPtr window);

        /* window refers to an SDL_Window*
         * Only available in 2.0.16 or higher.
         */
        /// <summary>
        ///     Sdls the get window keyboard grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GetWindowKeyboardGrab(IntPtr window);

        /* window refers to an SDL_Window*
         * Only available in 2.0.16 or higher.
         */
        /// <summary>
        ///     Sdls the get window mouse grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GetWindowMouseGrab(IntPtr window);

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the get window id using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetWindowID(IntPtr window);

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the get window pixel format using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetWindowPixelFormat(
            IntPtr window
        );

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the get window maximum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="maxW">The max</param>
        /// <param name="maxH">The max</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetWindowMaximumSize(
            IntPtr window,
            out int maxW,
            out int maxH
        );

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the get window minimum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="minW">The min</param>
        /// <param name="minH">The min</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetWindowMinimumSize(
            IntPtr window,
            out int minW,
            out int minH
        );

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the get window position using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetWindowPosition(
            IntPtr window,
            out int x,
            out int y
        );

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the get window size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetWindowSize(
            IntPtr window,
            out int w,
            out int h
        );

        /* IntPtr refers to an SDL_Surface*, window to an SDL_Window* */
        /// <summary>
        ///     Sdls the get window surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetWindowSurface(IntPtr window);

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Internals the sdl get window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowTitle", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetWindowTitle(
            IntPtr window
        );

        /// <summary>
        ///     Sdls the get window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The string</returns>
        public static string SDL_GetWindowTitle(IntPtr window) => UTF8_ToManaged(
            INTERNAL_SDL_GetWindowTitle(window)
        );

        /* texture refers to an SDL_Texture* */
        /// <summary>
        ///     Sdls the gl bind texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="texw">The texw</param>
        /// <param name="texh">The texh</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_BindTexture(
            IntPtr texture,
            out float texw,
            out float texh
        );

        /* IntPtr and window refer to an SDL_GLContext and SDL_Window* */
        /// <summary>
        ///     Sdls the gl create context using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GL_CreateContext(IntPtr window);

        /* context refers to an SDL_GLContext */
        /// <summary>
        ///     Sdls the gl delete context using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_DeleteContext(IntPtr context);

        /// <summary>
        ///     Internals the sdl gl load library using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_LoadLibrary", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int INTERNAL_SDL_GL_LoadLibrary(byte* path);

        /// <summary>
        ///     Sdls the gl load library using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The result</returns>
        public static unsafe int SDL_GL_LoadLibrary(string path)
        {
            byte* utf8Path = Utf8EncodeHeap(path);
            int result = INTERNAL_SDL_GL_LoadLibrary(
                utf8Path
            );
            Marshal.FreeHGlobal((IntPtr) utf8Path);
            return result;
        }

        /* IntPtr refers to a function pointer, proc to a const char* */
        /// <summary>
        ///     Sdls the gl get proc address using the specified proc
        /// </summary>
        /// <param name="proc">The proc</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GL_GetProcAddress(IntPtr proc);

        /* IntPtr refers to a function pointer */
        /// <summary>
        ///     Sdls the gl get proc address using the specified proc
        /// </summary>
        /// <param name="proc">The proc</param>
        /// <returns>The int ptr</returns>
        public static unsafe IntPtr SDL_GL_GetProcAddress(string proc)
        {
            int utf8ProcBufSize = Utf8Size(proc);
            byte* utf8Proc = stackalloc byte[utf8ProcBufSize];
            return SDL_GL_GetProcAddress(
                (IntPtr) Utf8Encode(proc, utf8Proc, utf8ProcBufSize)
            );
        }

        /// <summary>
        ///     Sdls the gl unload library
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_UnloadLibrary();

        /// <summary>
        ///     Internals the sdl gl extension supported using the specified extension
        /// </summary>
        /// <param name="extension">The extension</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_ExtensionSupported", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe SdlBool INTERNAL_SDL_GL_ExtensionSupported(
            byte* extension
        );

        /// <summary>
        ///     Sdls the gl extension supported using the specified extension
        /// </summary>
        /// <param name="extension">The extension</param>
        /// <returns>The sdl bool</returns>
        public static unsafe SdlBool SDL_GL_ExtensionSupported(string extension)
        {
            int utf8ExtensionBufSize = Utf8Size(extension);
            byte* utf8Extension = stackalloc byte[utf8ExtensionBufSize];
            return INTERNAL_SDL_GL_ExtensionSupported(
                Utf8Encode(extension, utf8Extension, utf8ExtensionBufSize)
            );
        }

        /* Only available in SDL 2.0.2 or higher. */
        /// <summary>
        ///     Sdls the gl reset attributes
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_ResetAttributes();

        /// <summary>
        ///     Sdls the gl get attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_GetAttribute(
            SdlGLattr attr,
            out int value
        );

        /// <summary>
        ///     Sdls the gl get swap interval
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_GetSwapInterval();

        /* window and context refer to an SDL_Window* and SDL_GLContext */
        /// <summary>
        ///     Sdls the gl make current using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="context">The context</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_MakeCurrent(
            IntPtr window,
            IntPtr context
        );

        /* IntPtr refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the gl get current window
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GL_GetCurrentWindow();

        /* IntPtr refers to an SDL_Context */
        /// <summary>
        ///     Sdls the gl get current context
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GL_GetCurrentContext();

        /* window refers to an SDL_Window*.
         * Only available in SDL 2.0.1 or higher.
         */
        /// <summary>
        ///     Sdls the gl get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_GetDrawableSize(
            IntPtr window,
            out int w,
            out int h
        );

        /// <summary>
        ///     Sdls the gl set attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_SetAttribute(
            SdlGLattr attr,
            int value
        );

        /// <summary>
        ///     Sdls the gl set attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="profile">The profile</param>
        /// <returns>The int</returns>
        public static int SDL_GL_SetAttribute(
            SdlGLattr attr,
            SdlGLprofile profile
        )
            => SDL_GL_SetAttribute(attr, (int) profile);

        /// <summary>
        ///     Sdls the gl set swap interval using the specified interval
        /// </summary>
        /// <param name="interval">The interval</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_SetSwapInterval(int interval);

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the gl swap window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_SwapWindow(IntPtr window);

        /* texture refers to an SDL_Texture* */
        /// <summary>
        ///     Sdls the gl unbind texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_UnbindTexture(IntPtr texture);

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the hide window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_HideWindow(IntPtr window);

        /// <summary>
        ///     Sdls the is screen saver enabled
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IsScreenSaverEnabled();

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the maximize window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MaximizeWindow(IntPtr window);

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the minimize window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MinimizeWindow(IntPtr window);

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the raise window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RaiseWindow(IntPtr window);

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the restore window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RestoreWindow(IntPtr window);

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the set window brightness using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="brightness">The brightness</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowBrightness(
            IntPtr window,
            float brightness
        );

        /* IntPtr and userdata are void*, window is an SDL_Window* */
        /// <summary>
        ///     Internals the sdl set window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowData", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe IntPtr INTERNAL_SDL_SetWindowData(
            IntPtr window,
            byte* name,
            IntPtr userdata
        );

        /// <summary>
        ///     Sdls the set window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The int ptr</returns>
        public static unsafe IntPtr SDL_SetWindowData(
            IntPtr window,
            string name,
            IntPtr userdata
        )
        {
            int utf8NameBufSize = Utf8Size(name);
            byte* utf8Name = stackalloc byte[utf8NameBufSize];
            return INTERNAL_SDL_SetWindowData(
                window,
                Utf8Encode(name, utf8Name, utf8NameBufSize),
                userdata
            );
        }

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the set window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowDisplayMode(
            IntPtr window,
            ref SdlDisplayMode mode
        );

        /* window refers to an SDL_Window* */
        /* NULL overload - use the window's dimensions and the desktop's format and refresh rate */
        /// <summary>
        ///     Sdls the set window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowDisplayMode(
            IntPtr window,
            IntPtr mode
        );

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the set window fullscreen using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowFullscreen(
            IntPtr window,
            uint flags
        );

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the set window gamma ramp using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowGammaRamp(
            IntPtr window,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] red,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] green,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] blue
        );

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the set window grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowGrab(
            IntPtr window,
            SdlBool grabbed
        );

        /* window refers to an SDL_Window*
         * Only available in 2.0.16 or higher.
         */
        /// <summary>
        ///     Sdls the set window keyboard grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowKeyboardGrab(
            IntPtr window,
            SdlBool grabbed
        );

        /* window refers to an SDL_Window*
         * Only available in 2.0.16 or higher.
         */
        /// <summary>
        ///     Sdls the set window mouse grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowMouseGrab(
            IntPtr window,
            SdlBool grabbed
        );


        /* window refers to an SDL_Window*, icon to an SDL_Surface* */
        /// <summary>
        ///     Sdls the set window icon using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="icon">The icon</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowIcon(
            IntPtr window,
            IntPtr icon
        );

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the set window maximum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="maxW">The max</param>
        /// <param name="maxH">The max</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowMaximumSize(
            IntPtr window,
            int maxW,
            int maxH
        );

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the set window minimum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="minW">The min</param>
        /// <param name="minH">The min</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowMinimumSize(
            IntPtr window,
            int minW,
            int minH
        );

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the set window position using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowPosition(
            IntPtr window,
            int x,
            int y
        );

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the set window size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowSize(
            IntPtr window,
            int w,
            int h
        );

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the set window bordered using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="bordered">The bordered</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowBordered(
            IntPtr window,
            SdlBool bordered
        );

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the get window borders size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="top">The top</param>
        /// <param name="left">The left</param>
        /// <param name="bottom">The bottom</param>
        /// <param name="right">The right</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowBordersSize(
            IntPtr window,
            out int top,
            out int left,
            out int bottom,
            out int right
        );

        /* window refers to an SDL_Window*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Sdls the set window resizable using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="resizable">The resizable</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowResizable(
            IntPtr window,
            SdlBool resizable
        );

        /* window refers to an SDL_Window*
         * Only available in 2.0.16 or higher.
         */
        /// <summary>
        ///     Sdls the set window always on top using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="onTop">The on top</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowAlwaysOnTop(
            IntPtr window,
            SdlBool onTop
        );

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Internals the sdl set window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="title">The title</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowTitle", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void INTERNAL_SDL_SetWindowTitle(
            IntPtr window,
            byte* title
        );

        /// <summary>
        ///     Sdls the set window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="title">The title</param>
        public static unsafe void SDL_SetWindowTitle(
            IntPtr window,
            string title
        )
        {
            int utf8TitleBufSize = Utf8Size(title);
            byte* utf8Title = stackalloc byte[utf8TitleBufSize];
            INTERNAL_SDL_SetWindowTitle(
                window,
                Utf8Encode(title, utf8Title, utf8TitleBufSize)
            );
        }

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the show window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ShowWindow(IntPtr window);

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the update window surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateWindowSurface(IntPtr window);

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the update window surface rects using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rects">The rects</param>
        /// <param name="numrects">The numrects</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateWindowSurfaceRects(
            IntPtr window,
            [In] SdlRect[] rects,
            int numrects
        );

        /// <summary>
        ///     Internals the sdl video init using the specified driver name
        /// </summary>
        /// <param name="driverName">The driver name</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_VideoInit", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int INTERNAL_SDL_VideoInit(
            byte* driverName
        );

        /// <summary>
        ///     Sdls the video init using the specified driver name
        /// </summary>
        /// <param name="driverName">The driver name</param>
        /// <returns>The int</returns>
        public static unsafe int SDL_VideoInit(string driverName)
        {
            int utf8DriverNameBufSize = Utf8Size(driverName);
            byte* utf8DriverName = stackalloc byte[utf8DriverNameBufSize];
            return INTERNAL_SDL_VideoInit(
                Utf8Encode(driverName, utf8DriverName, utf8DriverNameBufSize)
            );
        }

        /// <summary>
        ///     Sdls the video quit
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_VideoQuit();

        /* window refers to an SDL_Window*, callback_data to a void*
         * Only available in 2.0.4 or higher.
         */
        /// <summary>
        ///     Sdls the set window hit test using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="callback">The callback</param>
        /// <param name="callbackData">The callback data</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowHitTest(
            IntPtr window,
            SdlHitTest callback,
            IntPtr callbackData
        );

        /* IntPtr refers to an SDL_Window*
         * Only available in 2.0.4 or higher.
         */
        /// <summary>
        ///     Sdls the get grabbed window
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetGrabbedWindow();

        /* window refers to an SDL_Window*
         * Only available in 2.0.18 or higher.
         */
        /// <summary>
        ///     Sdls the set window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowMouseRect(
            IntPtr window,
            ref SdlRect rect
        );

        /* window refers to an SDL_Window*
         * rect refers to an SDL_Rect*
         * This overload allows for IntPtr.Zero (null) to be passed for rect.
         * Only available in 2.0.18 or higher.
         */
        /// <summary>
        ///     Sdls the set window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowMouseRect(
            IntPtr window,
            IntPtr rect
        );

        /* window refers to an SDL_Window*
         * IntPtr refers to an SDL_Rect*
         * Only available in 2.0.18 or higher.
         */
        /// <summary>
        ///     Sdls the get window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetWindowMouseRect(
            IntPtr window
        );

        /* window refers to an SDL_Window*
         * Only available in 2.0.16 or higher.
         */
        /// <summary>
        ///     Sdls the flash window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="operation">The operation</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_FlashWindow(
            IntPtr window,
            SdlFlashOperation operation
        );

        #endregion

        #region SDL_blendmode.h

        /// <summary>
        ///     The sdl blendmode enum
        /// </summary>
        [Flags]
        public enum SdlBlendMode
        {
            /// <summary>
            ///     The sdl blendmode none sdl blendmode
            /// </summary>
            SdlBlendmodeNone = 0x00000000,

            /// <summary>
            ///     The sdl blendmode blend sdl blendmode
            /// </summary>
            SdlBlendmodeBlend = 0x00000001,

            /// <summary>
            ///     The sdl blendmode add sdl blendmode
            /// </summary>
            SdlBlendmodeAdd = 0x00000002,

            /// <summary>
            ///     The sdl blendmode mod sdl blendmode
            /// </summary>
            SdlBlendmodeMod = 0x00000004,

            /// <summary>
            ///     The sdl blendmode mul sdl blendmode
            /// </summary>
            SdlBlendmodeMul = 0x00000008, /* >= 2.0.11 */

            /// <summary>
            ///     The sdl blendmode invalid sdl blendmode
            /// </summary>
            SdlBlendmodeInvalid = 0x7FFFFFFF
        }

        /// <summary>
        ///     The sdl blendoperation enum
        /// </summary>
        public enum SdlBlendOperation
        {
            /// <summary>
            ///     The sdl blendoperation add sdl blendoperation
            /// </summary>
            SdlBlendoperationAdd = 0x1,

            /// <summary>
            ///     The sdl blendoperation subtract sdl blendoperation
            /// </summary>
            SdlBlendoperationSubtract = 0x2,

            /// <summary>
            ///     The sdl blendoperation rev subtract sdl blendoperation
            /// </summary>
            SdlBlendoperationRevSubtract = 0x3,

            /// <summary>
            ///     The sdl blendoperation minimum sdl blendoperation
            /// </summary>
            SdlBlendoperationMinimum = 0x4,

            /// <summary>
            ///     The sdl blendoperation maximum sdl blendoperation
            /// </summary>
            SdlBlendoperationMaximum = 0x5
        }

        /// <summary>
        ///     The sdl blendfactor enum
        /// </summary>
        public enum SdlBlendFactor
        {
            /// <summary>
            ///     The sdl blendfactor zero sdl blendfactor
            /// </summary>
            SdlBlendfactorZero = 0x1,

            /// <summary>
            ///     The sdl blendfactor one sdl blendfactor
            /// </summary>
            SdlBlendfactorOne = 0x2,

            /// <summary>
            ///     The sdl blendfactor src color sdl blendfactor
            /// </summary>
            SdlBlendfactorSrcColor = 0x3,

            /// <summary>
            ///     The sdl blendfactor one minus src color sdl blendfactor
            /// </summary>
            SdlBlendfactorOneMinusSrcColor = 0x4,

            /// <summary>
            ///     The sdl blendfactor src alpha sdl blendfactor
            /// </summary>
            SdlBlendfactorSrcAlpha = 0x5,

            /// <summary>
            ///     The sdl blendfactor one minus src alpha sdl blendfactor
            /// </summary>
            SdlBlendfactorOneMinusSrcAlpha = 0x6,

            /// <summary>
            ///     The sdl blendfactor dst color sdl blendfactor
            /// </summary>
            SdlBlendfactorDstColor = 0x7,

            /// <summary>
            ///     The sdl blendfactor one minus dst color sdl blendfactor
            /// </summary>
            SdlBlendfactorOneMinusDstColor = 0x8,

            /// <summary>
            ///     The sdl blendfactor dst alpha sdl blendfactor
            /// </summary>
            SdlBlendfactorDstAlpha = 0x9,

            /// <summary>
            ///     The sdl blendfactor one minus dst alpha sdl blendfactor
            /// </summary>
            SdlBlendfactorOneMinusDstAlpha = 0xA
        }

        /* Only available in 2.0.6 or higher. */
        /// <summary>
        ///     Sdls the compose custom blend mode using the specified src color factor
        /// </summary>
        /// <param name="srcColorFactor">The src color factor</param>
        /// <param name="dstColorFactor">The dst color factor</param>
        /// <param name="colorOperation">The color operation</param>
        /// <param name="srcAlphaFactor">The src alpha factor</param>
        /// <param name="dstAlphaFactor">The dst alpha factor</param>
        /// <param name="alphaOperation">The alpha operation</param>
        /// <returns>The sdl blend mode</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBlendMode SDL_ComposeCustomBlendMode(
            SdlBlendFactor srcColorFactor,
            SdlBlendFactor dstColorFactor,
            SdlBlendOperation colorOperation,
            SdlBlendFactor srcAlphaFactor,
            SdlBlendFactor dstAlphaFactor,
            SdlBlendOperation alphaOperation
        );

        #endregion

        #region SDL_vulkan.h

        /* Only available in 2.0.6 or higher. */
        /// <summary>
        ///     Internals the sdl vulkan load library using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_Vulkan_LoadLibrary", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int INTERNAL_SDL_Vulkan_LoadLibrary(
            byte* path
        );

        /// <summary>
        ///     Sdls the vulkan load library using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The result</returns>
        public static unsafe int SDL_Vulkan_LoadLibrary(string path)
        {
            byte* utf8Path = Utf8EncodeHeap(path);
            int result = INTERNAL_SDL_Vulkan_LoadLibrary(
                utf8Path
            );
            Marshal.FreeHGlobal((IntPtr) utf8Path);
            return result;
        }

        /* Only available in 2.0.6 or higher. */
        /// <summary>
        ///     Sdls the vulkan get vk get instance proc addr
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_Vulkan_GetVkGetInstanceProcAddr();

        /* Only available in 2.0.6 or higher. */
        /// <summary>
        ///     Sdls the vulkan unload library
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Vulkan_UnloadLibrary();

        /* window refers to an SDL_Window*, pNames to a const char**.
         * Only available in 2.0.6 or higher.
         * This overload allows for IntPtr.Zero (null) to be passed for pNames.
         */
        /// <summary>
        ///     Sdls the vulkan get instance extensions using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="pCount">The count</param>
        /// <param name="pNames">The names</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_Vulkan_GetInstanceExtensions(
            IntPtr window,
            out uint pCount,
            IntPtr pNames
        );

        /* window refers to an SDL_Window*, pNames to a const char**.
         * Only available in 2.0.6 or higher.
         */
        /// <summary>
        ///     Sdls the vulkan get instance extensions using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="pCount">The count</param>
        /// <param name="pNames">The names</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_Vulkan_GetInstanceExtensions(
            IntPtr window,
            out uint pCount,
            IntPtr[] pNames
        );

        /* window refers to an SDL_Window.
         * instance refers to a VkInstance.
         * surface refers to a VkSurfaceKHR.
         * Only available in 2.0.6 or higher.
         */
        /// <summary>
        ///     Sdls the vulkan create surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="instance">The instance</param>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_Vulkan_CreateSurface(
            IntPtr window,
            IntPtr instance,
            out ulong surface
        );

        /* window refers to an SDL_Window*.
         * Only available in 2.0.6 or higher.
         */
        /// <summary>
        ///     Sdls the vulkan get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Vulkan_GetDrawableSize(
            IntPtr window,
            out int w,
            out int h
        );

        #endregion

        #region SDL_metal.h

        /* Only available in 2.0.11 or higher. */
        /// <summary>
        ///     Sdls the metal create view using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_Metal_CreateView(
            IntPtr window
        );

        /* Only available in 2.0.11 or higher. */
        /// <summary>
        ///     Sdls the metal destroy view using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Metal_DestroyView(
            IntPtr view
        );

        /* view refers to an SDL_MetalView.
         * Only available in 2.0.14 or higher. */
        /// <summary>
        ///     Sdls the metal get layer using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_Metal_GetLayer(
            IntPtr view
        );

        /* window refers to an SDL_Window*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Sdls the metal get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Metal_GetDrawableSize(
            IntPtr window,
            out int w,
            out int h
        );

        #endregion

        #region SDL_render.h

        /// <summary>
        ///     The sdl rendererflags enum
        /// </summary>
        [Flags]
        public enum SdlRendererFlags : uint
        {
            /// <summary>
            ///     The sdl renderer software sdl rendererflags
            /// </summary>
            SdlRendererSoftware = 0x00000001,

            /// <summary>
            ///     The sdl renderer accelerated sdl rendererflags
            /// </summary>
            SdlRendererAccelerated = 0x00000002,

            /// <summary>
            ///     The sdl renderer presentvsync sdl rendererflags
            /// </summary>
            SdlRendererPresentvsync = 0x00000004,

            /// <summary>
            ///     The sdl renderer targettexture sdl rendererflags
            /// </summary>
            SdlRendererTargettexture = 0x00000008
        }

        /// <summary>
        ///     The sdl rendererflip enum
        /// </summary>
        [Flags]
        public enum SdlRendererFlip
        {
            /// <summary>
            ///     The sdl flip none sdl rendererflip
            /// </summary>
            SdlFlipNone = 0x00000000,

            /// <summary>
            ///     The sdl flip horizontal sdl rendererflip
            /// </summary>
            SdlFlipHorizontal = 0x00000001,

            /// <summary>
            ///     The sdl flip vertical sdl rendererflip
            /// </summary>
            SdlFlipVertical = 0x00000002
        }

        /// <summary>
        ///     The sdl textureaccess enum
        /// </summary>
        public enum SdlTextureAccess
        {
            /// <summary>
            ///     The sdl textureaccess static sdl textureaccess
            /// </summary>
            SdlTextureaccessStatic,

            /// <summary>
            ///     The sdl textureaccess streaming sdl textureaccess
            /// </summary>
            SdlTextureaccessStreaming,

            /// <summary>
            ///     The sdl textureaccess target sdl textureaccess
            /// </summary>
            SdlTextureaccessTarget
        }

        /// <summary>
        ///     The sdl texturemodulate enum
        /// </summary>
        [Flags]
        public enum SdlTextureModulate
        {
            /// <summary>
            ///     The sdl texturemodulate none sdl texturemodulate
            /// </summary>
            SdlTexturemodulateNone = 0x00000000,

            /// <summary>
            ///     The sdl texturemodulate horizontal sdl texturemodulate
            /// </summary>
            SdlTexturemodulateHorizontal = 0x00000001,

            /// <summary>
            ///     The sdl texturemodulate vertical sdl texturemodulate
            /// </summary>
            SdlTexturemodulateVertical = 0x00000002
        }

        /// <summary>
        ///     The sdl rendererinfo
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SdlRendererInfo
        {
            /// <summary>
            ///     The name
            /// </summary>
            public IntPtr name; // const char*

            /// <summary>
            ///     The flags
            /// </summary>
            public uint flags;

            /// <summary>
            ///     The num texture formats
            /// </summary>
            public uint num_texture_formats;

            /// <summary>
            ///     The texture formats
            /// </summary>
            public fixed uint texture_formats[16];

            /// <summary>
            ///     The max texture width
            /// </summary>
            public int max_texture_width;

            /// <summary>
            ///     The max texture height
            /// </summary>
            public int max_texture_height;
        }

        /* Only available in 2.0.11 or higher. */
        /// <summary>
        ///     The sdl scalemode enum
        /// </summary>
        public enum SdlScaleMode
        {
            /// <summary>
            ///     The sdl scalemodenearest sdl scalemode
            /// </summary>
            SdlScaleModeNearest,

            /// <summary>
            ///     The sdl scalemodelinear sdl scalemode
            /// </summary>
            SdlScaleModeLinear,

            /// <summary>
            ///     The sdl scalemodebest sdl scalemode
            /// </summary>
            SdlScaleModeBest
        }

        /* Only available in 2.0.18 or higher. */
        /// <summary>
        ///     The sdl vertex
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlVertex
        {
            /// <summary>
            ///     The position
            /// </summary>
            public SdlFPoint position;

            /// <summary>
            ///     The color
            /// </summary>
            public SdlColor color;

            /// <summary>
            ///     The tex coord
            /// </summary>
            public SdlFPoint tex_coord;
        }

        /* IntPtr refers to an SDL_Renderer*, window to an SDL_Window* */
        /// <summary>
        ///     Sdls the create renderer using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="index">The index</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateRenderer(
            IntPtr window,
            int index,
            SdlRendererFlags flags
        );

        /* IntPtr refers to an SDL_Renderer*, surface to an SDL_Surface* */
        /// <summary>
        ///     Sdls the create software renderer using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateSoftwareRenderer(IntPtr surface);

        /* IntPtr refers to an SDL_Texture*, renderer to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the create texture using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="format">The format</param>
        /// <param name="access">The access</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateTexture(
            IntPtr renderer,
            uint format,
            int access,
            int w,
            int h
        );

        /* IntPtr refers to an SDL_Texture*
         * renderer refers to an SDL_Renderer*
         * surface refers to an SDL_Surface*
         */
        /// <summary>
        ///     Sdls the create texture from surface using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateTextureFromSurface(
            IntPtr renderer,
            IntPtr surface
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the destroy renderer using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DestroyRenderer(IntPtr renderer);

        /* texture refers to an SDL_Texture* */
        /// <summary>
        ///     Sdls the destroy texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DestroyTexture(IntPtr texture);

        /// <summary>
        ///     Sdls the get num render drivers
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumRenderDrivers();

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the get render draw blend mode using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRenderDrawBlendMode(
            IntPtr renderer,
            out SdlBlendMode blendMode
        );

        /* texture refers to an SDL_Texture*
         * Only available in 2.0.11 or higher.
         */
        /// <summary>
        ///     Sdls the set texture scale mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="scaleMode">The scale mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetTextureScaleMode(
            IntPtr texture,
            SdlScaleMode scaleMode
        );

        /* texture refers to an SDL_Texture*
         * Only available in 2.0.11 or higher.
         */
        /// <summary>
        ///     Sdls the get texture scale mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="scaleMode">The scale mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetTextureScaleMode(
            IntPtr texture,
            out SdlScaleMode scaleMode
        );

        /* texture refers to an SDL_Texture*
         * userdata refers to a void*
         * Only available in 2.0.18 or higher.
         */
        /// <summary>
        ///     Sdls the set texture user data using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetTextureUserData(
            IntPtr texture,
            IntPtr userdata
        );

        /* IntPtr refers to a void*, texture refers to an SDL_Texture*
         * Only available in 2.0.18 or higher.
         */
        /// <summary>
        ///     Sdls the get texture user data using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetTextureUserData(IntPtr texture);

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the get render draw color using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRenderDrawColor(
            IntPtr renderer,
            out byte r,
            out byte g,
            out byte b,
            out byte a
        );

        /// <summary>
        ///     Sdls the get render driver info using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="info">The info</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRenderDriverInfo(
            int index,
            out SdlRendererInfo info
        );

        /* IntPtr refers to an SDL_Renderer*, window to an SDL_Window* */
        /// <summary>
        ///     Sdls the get renderer using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetRenderer(IntPtr window);

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the get renderer info using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="info">The info</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRendererInfo(
            IntPtr renderer,
            out SdlRendererInfo info
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the get renderer output size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRendererOutputSize(
            IntPtr renderer,
            out int w,
            out int h
        );

        /* texture refers to an SDL_Texture* */
        /// <summary>
        ///     Sdls the get texture alpha mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetTextureAlphaMod(
            IntPtr texture,
            out byte alpha
        );

        /* texture refers to an SDL_Texture* */
        /// <summary>
        ///     Sdls the get texture blend mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetTextureBlendMode(
            IntPtr texture,
            out SdlBlendMode blendMode
        );

        /* texture refers to an SDL_Texture* */
        /// <summary>
        ///     Sdls the get texture color mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetTextureColorMod(
            IntPtr texture,
            out byte r,
            out byte g,
            out byte b
        );

        /* texture refers to an SDL_Texture*, pixels to a void* */
        /// <summary>
        ///     Sdls the lock texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LockTexture(
            IntPtr texture,
            ref SdlRect rect,
            out IntPtr pixels,
            out int pitch
        );

        /* texture refers to an SDL_Texture*, pixels to a void*.
         * Internally, this function contains logic to use default values when
         * the rectangle is passed as NULL.
         * This overload allows for IntPtr.Zero to be passed for rect.
         */
        /// <summary>
        ///     Sdls the lock texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LockTexture(
            IntPtr texture,
            IntPtr rect,
            out IntPtr pixels,
            out int pitch
        );

        /* texture refers to an SDL_Texture*, surface to an SDL_Surface*
         * Only available in 2.0.11 or higher.
         */
        /// <summary>
        ///     Sdls the lock texture to surface using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LockTextureToSurface(
            IntPtr texture,
            ref SdlRect rect,
            out IntPtr surface
        );

        /* texture refers to an SDL_Texture*, surface to an SDL_Surface*
         * Internally, this function contains logic to use default values when
         * the rectangle is passed as NULL.
         * This overload allows for IntPtr.Zero to be passed for rect.
         * Only available in 2.0.11 or higher.
         */
        /// <summary>
        ///     Sdls the lock texture to surface using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LockTextureToSurface(
            IntPtr texture,
            IntPtr rect,
            out IntPtr surface
        );

        /* texture refers to an SDL_Texture* */
        /// <summary>
        ///     Sdls the query texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="format">The format</param>
        /// <param name="access">The access</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_QueryTexture(
            IntPtr texture,
            out uint format,
            out int access,
            out int w,
            out int h
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render clear using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderClear(IntPtr renderer);

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture* */
        /// <summary>
        ///     Sdls the render copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopy(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcrect,
            ref SdlRect dstrect
        );

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
         * Internally, this function contains logic to use default values when
         * source and destination rectangles are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for srcrect.
         */
        /// <summary>
        ///     Sdls the render copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopy(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            ref SdlRect dstrect
        );

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
         * Internally, this function contains logic to use default values when
         * source and destination rectangles are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for dstrect.
         */
        /// <summary>
        ///     Sdls the render copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopy(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcrect,
            IntPtr dstrect
        );

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
         * Internally, this function contains logic to use default values when
         * source and destination rectangles are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for both SDL_Rects.
         */
        /// <summary>
        ///     Sdls the render copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopy(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            IntPtr dstrect
        );

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture* */
        /// <summary>
        ///     Sdls the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcrect,
            ref SdlRect dstrect,
            double angle,
            ref SdlPoint center,
            SdlRendererFlip flip
        );

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
         * Internally, this function contains logic to use default values when
         * source, destination, and/or center are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for srcrect.
         */
        /// <summary>
        ///     Sdls the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            ref SdlRect dstrect,
            double angle,
            ref SdlPoint center,
            SdlRendererFlip flip
        );

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
         * Internally, this function contains logic to use default values when
         * source, destination, and/or center are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for dstrect.
         */
        /// <summary>
        ///     Sdls the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcrect,
            IntPtr dstrect,
            double angle,
            ref SdlPoint center,
            SdlRendererFlip flip
        );

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
         * Internally, this function contains logic to use default values when
         * source, destination, and/or center are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for center.
         */
        /// <summary>
        ///     Sdls the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcrect,
            ref SdlRect dstrect,
            double angle,
            IntPtr center,
            SdlRendererFlip flip
        );

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
         * Internally, this function contains logic to use default values when
         * source, destination, and/or center are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for both
         * srcrect and dstrect.
         */
        /// <summary>
        ///     Sdls the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            IntPtr dstrect,
            double angle,
            ref SdlPoint center,
            SdlRendererFlip flip
        );

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
         * Internally, this function contains logic to use default values when
         * source, destination, and/or center are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for both
         * srcrect and center.
         */
        /// <summary>
        ///     Sdls the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            ref SdlRect dstrect,
            double angle,
            IntPtr center,
            SdlRendererFlip flip
        );

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
         * Internally, this function contains logic to use default values when
         * source, destination, and/or center are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for both
         * dstrect and center.
         */
        /// <summary>
        ///     Sdls the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcrect,
            IntPtr dstrect,
            double angle,
            IntPtr center,
            SdlRendererFlip flip
        );

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
         * Internally, this function contains logic to use default values when
         * source, destination, and/or center are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for all
         * three parameters.
         */
        /// <summary>
        ///     Sdls the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            IntPtr dstrect,
            double angle,
            IntPtr center,
            SdlRendererFlip flip
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render draw line using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawLine(
            IntPtr renderer,
            int x1,
            int y1,
            int x2,
            int y2
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render draw lines using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawLines(
            IntPtr renderer,
            [In] SdlPoint[] points,
            int count
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render draw point using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawPoint(
            IntPtr renderer,
            int x,
            int y
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render draw points using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawPoints(
            IntPtr renderer,
            [In] SdlPoint[] points,
            int count
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render draw rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawRect(
            IntPtr renderer,
            ref SdlRect rect
        );

        /* renderer refers to an SDL_Renderer*, rect to an SDL_Rect*.
         * This overload allows for IntPtr.Zero (null) to be passed for rect.
         */
        /// <summary>
        ///     Sdls the render draw rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawRect(
            IntPtr renderer,
            IntPtr rect
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render draw rects using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawRects(
            IntPtr renderer,
            [In] SdlRect[] rects,
            int count
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render fill rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFillRect(
            IntPtr renderer,
            ref SdlRect rect
        );

        /* renderer refers to an SDL_Renderer*, rect to an SDL_Rect*.
         * This overload allows for IntPtr.Zero (null) to be passed for rect.
         */
        /// <summary>
        ///     Sdls the render fill rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFillRect(
            IntPtr renderer,
            IntPtr rect
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render fill rects using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFillRects(
            IntPtr renderer,
            [In] SdlRect[] rects,
            int count
        );

        #region Floating Point Render Functions

        /* This region only available in SDL 2.0.10 or higher. */

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture* */
        /// <summary>
        ///     Sdls the render copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyF(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcrect,
            ref SdlFRect dstrect
        );

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
         * Internally, this function contains logic to use default values when
         * source and destination rectangles are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for srcrect.
         */
        /// <summary>
        ///     Sdls the render copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyF(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            ref SdlFRect dstrect
        );

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
         * Internally, this function contains logic to use default values when
         * source and destination rectangles are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for dstrect.
         */
        /// <summary>
        ///     Sdls the render copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyF(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcrect,
            IntPtr dstrect
        );

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
         * Internally, this function contains logic to use default values when
         * source and destination rectangles are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for both SDL_Rects.
         */
        /// <summary>
        ///     Sdls the render copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyF(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            IntPtr dstrect
        );

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture* */
        /// <summary>
        ///     Sdls the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcrect,
            ref SdlFRect dstrect,
            double angle,
            ref SdlFPoint center,
            SdlRendererFlip flip
        );

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
         * Internally, this function contains logic to use default values when
         * source, destination, and/or center are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for srcrect.
         */
        /// <summary>
        ///     Sdls the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            ref SdlFRect dstrect,
            double angle,
            ref SdlFPoint center,
            SdlRendererFlip flip
        );

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
         * Internally, this function contains logic to use default values when
         * source, destination, and/or center are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for dstrect.
         */
        /// <summary>
        ///     Sdls the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyExF(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcrect,
            IntPtr dstrect,
            double angle,
            ref SdlFPoint center,
            SdlRendererFlip flip
        );

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
         * Internally, this function contains logic to use default values when
         * source, destination, and/or center are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for center.
         */
        /// <summary>
        ///     Sdls the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyExF(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcrect,
            ref SdlFRect dstrect,
            double angle,
            IntPtr center,
            SdlRendererFlip flip
        );

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
         * Internally, this function contains logic to use default values when
         * source, destination, and/or center are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for both
         * srcrect and dstrect.
         */
        /// <summary>
        ///     Sdls the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyExF(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            IntPtr dstrect,
            double angle,
            ref SdlFPoint center,
            SdlRendererFlip flip
        );

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
         * Internally, this function contains logic to use default values when
         * source, destination, and/or center are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for both
         * srcrect and center.
         */
        /// <summary>
        ///     Sdls the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyExF(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            ref SdlFRect dstrect,
            double angle,
            IntPtr center,
            SdlRendererFlip flip
        );

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
         * Internally, this function contains logic to use default values when
         * source, destination, and/or center are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for both
         * dstrect and center.
         */
        /// <summary>
        ///     Sdls the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyExF(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcrect,
            IntPtr dstrect,
            double angle,
            IntPtr center,
            SdlRendererFlip flip
        );

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
         * Internally, this function contains logic to use default values when
         * source, destination, and/or center are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for all
         * three parameters.
         */
        /// <summary>
        ///     Sdls the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyExF(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            IntPtr dstrect,
            double angle,
            IntPtr center,
            SdlRendererFlip flip
        );

        /* renderer refers to an SDL_Renderer*
         * texture refers to an SDL_Texture*
         * Only available in 2.0.18 or higher.
         */
        /// <summary>
        ///     Sdls the render geometry using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="vertices">The vertices</param>
        /// <param name="numVertices">The num vertices</param>
        /// <param name="indices">The indices</param>
        /// <param name="numIndices">The num indices</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderGeometry(
            IntPtr renderer,
            IntPtr texture,
            [In] SdlVertex[] vertices,
            int numVertices,
            [In] int[] indices,
            int numIndices
        );

        /* renderer refers to an SDL_Renderer*
         * texture refers to an SDL_Texture*
         * indices refers to a void*
         * Only available in 2.0.18 or higher.
         */
        /// <summary>
        ///     Sdls the render geometry raw using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="xy">The xy</param>
        /// <param name="xyStride">The xy stride</param>
        /// <param name="color">The color</param>
        /// <param name="colorStride">The color stride</param>
        /// <param name="uv">The uv</param>
        /// <param name="uvStride">The uv stride</param>
        /// <param name="numVertices">The num vertices</param>
        /// <param name="indices">The indices</param>
        /// <param name="numIndices">The num indices</param>
        /// <param name="sizeIndices">The size indices</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderGeometryRaw(
            IntPtr renderer,
            IntPtr texture,
            [In] float[] xy,
            int xyStride,
            [In] int[] color,
            int colorStride,
            [In] float[] uv,
            int uvStride,
            int numVertices,
            IntPtr indices,
            int numIndices,
            int sizeIndices
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render draw point f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawPointF(
            IntPtr renderer,
            float x,
            float y
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render draw points f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawPointsF(
            IntPtr renderer,
            [In] SdlFPoint[] points,
            int count
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render draw line f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawLineF(
            IntPtr renderer,
            float x1,
            float y1,
            float x2,
            float y2
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render draw lines f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawLinesF(
            IntPtr renderer,
            [In] SdlFPoint[] points,
            int count
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render draw rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawRectF(
            IntPtr renderer,
            ref SdlFRect rect
        );

        /* renderer refers to an SDL_Renderer*, rect to an SDL_Rect*.
         * This overload allows for IntPtr.Zero (null) to be passed for rect.
         */
        /// <summary>
        ///     Sdls the render draw rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawRectF(
            IntPtr renderer,
            IntPtr rect
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render draw rects f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawRectsF(
            IntPtr renderer,
            [In] SdlFRect[] rects,
            int count
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render fill rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFillRectF(
            IntPtr renderer,
            ref SdlFRect rect
        );

        /* renderer refers to an SDL_Renderer*, rect to an SDL_Rect*.
         * This overload allows for IntPtr.Zero (null) to be passed for rect.
         */
        /// <summary>
        ///     Sdls the render fill rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFillRectF(
            IntPtr renderer,
            IntPtr rect
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render fill rects f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFillRectsF(
            IntPtr renderer,
            [In] SdlFRect[] rects,
            int count
        );

        #endregion

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render get clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderGetClipRect(
            IntPtr renderer,
            out SdlRect rect
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render get logical size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderGetLogicalSize(
            IntPtr renderer,
            out int w,
            out int h
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render get scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="scaleX">The scale</param>
        /// <param name="scaleY">The scale</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderGetScale(
            IntPtr renderer,
            out float scaleX,
            out float scaleY
        );

        /* renderer refers to an SDL_Renderer*
         * Only available in 2.0.18 or higher.
         */
        /// <summary>
        ///     Sdls the render window to logical using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="windowX">The window</param>
        /// <param name="windowY">The window</param>
        /// <param name="logicalX">The logical</param>
        /// <param name="logicalY">The logical</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderWindowToLogical(
            IntPtr renderer,
            int windowX,
            int windowY,
            out float logicalX,
            out float logicalY
        );

        /* renderer refers to an SDL_Renderer*
         * Only available in 2.0.18 or higher.
         */
        /// <summary>
        ///     Sdls the render logical to window using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="logicalX">The logical</param>
        /// <param name="logicalY">The logical</param>
        /// <param name="windowX">The window</param>
        /// <param name="windowY">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderLogicalToWindow(
            IntPtr renderer,
            float logicalX,
            float logicalY,
            out int windowX,
            out int windowY
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render get viewport using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderGetViewport(
            IntPtr renderer,
            out SdlRect rect
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render present using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderPresent(IntPtr renderer);

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render read pixels using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <param name="format">The format</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderReadPixels(
            IntPtr renderer,
            ref SdlRect rect,
            uint format,
            IntPtr pixels,
            int pitch
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render set clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetClipRect(
            IntPtr renderer,
            ref SdlRect rect
        );

        /* renderer refers to an SDL_Renderer*
         * This overload allows for IntPtr.Zero (null) to be passed for rect.
         */
        /// <summary>
        ///     Sdls the render set clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetClipRect(
            IntPtr renderer,
            IntPtr rect
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render set logical size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetLogicalSize(
            IntPtr renderer,
            int w,
            int h
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render set scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="scaleX">The scale</param>
        /// <param name="scaleY">The scale</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetScale(
            IntPtr renderer,
            float scaleX,
            float scaleY
        );

        /* renderer refers to an SDL_Renderer*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Sdls the render set integer scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="enable">The enable</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetIntegerScale(
            IntPtr renderer,
            SdlBool enable
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render set viewport using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetViewport(
            IntPtr renderer,
            ref SdlRect rect
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the set render draw blend mode using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetRenderDrawBlendMode(
            IntPtr renderer,
            SdlBlendMode blendMode
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the set render draw color using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetRenderDrawColor(
            IntPtr renderer,
            byte r,
            byte g,
            byte b,
            byte a
        );

        /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture* */
        /// <summary>
        ///     Sdls the set render target using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetRenderTarget(
            IntPtr renderer,
            IntPtr texture
        );

        /* texture refers to an SDL_Texture* */
        /// <summary>
        ///     Sdls the set texture alpha mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetTextureAlphaMod(
            IntPtr texture,
            byte alpha
        );

        /* texture refers to an SDL_Texture* */
        /// <summary>
        ///     Sdls the set texture blend mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetTextureBlendMode(
            IntPtr texture,
            SdlBlendMode blendMode
        );

        /* texture refers to an SDL_Texture* */
        /// <summary>
        ///     Sdls the set texture color mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetTextureColorMod(
            IntPtr texture,
            byte r,
            byte g,
            byte b
        );

        /* texture refers to an SDL_Texture* */
        /// <summary>
        ///     Sdls the unlock texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockTexture(IntPtr texture);

        /* texture refers to an SDL_Texture* */
        /// <summary>
        ///     Sdls the update texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateTexture(
            IntPtr texture,
            ref SdlRect rect,
            IntPtr pixels,
            int pitch
        );

        /* texture refers to an SDL_Texture* */
        /// <summary>
        ///     Sdls the update texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateTexture(
            IntPtr texture,
            IntPtr rect,
            IntPtr pixels,
            int pitch
        );

        /* texture refers to an SDL_Texture*
         * Only available in 2.0.1 or higher.
         */
        /// <summary>
        ///     Sdls the update yuv texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="yPlane">The plane</param>
        /// <param name="yPitch">The pitch</param>
        /// <param name="uPlane">The plane</param>
        /// <param name="uPitch">The pitch</param>
        /// <param name="vPlane">The plane</param>
        /// <param name="vPitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateYUVTexture(
            IntPtr texture,
            ref SdlRect rect,
            IntPtr yPlane,
            int yPitch,
            IntPtr uPlane,
            int uPitch,
            IntPtr vPlane,
            int vPitch
        );

        /* texture refers to an SDL_Texture*.
         * yPlane and uvPlane refer to const Uint*.
         * Only available in 2.0.16 or higher.
         */
        /// <summary>
        ///     Sdls the update nv texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="yPlane">The plane</param>
        /// <param name="yPitch">The pitch</param>
        /// <param name="uvPlane">The uv plane</param>
        /// <param name="uvPitch">The uv pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateNVTexture(
            IntPtr texture,
            ref SdlRect rect,
            IntPtr yPlane,
            int yPitch,
            IntPtr uvPlane,
            int uvPitch
        );

        /* renderer refers to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the render target supported using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_RenderTargetSupported(
            IntPtr renderer
        );

        /* IntPtr refers to an SDL_Texture*, renderer to an SDL_Renderer* */
        /// <summary>
        ///     Sdls the get render target using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetRenderTarget(IntPtr renderer);

        /* renderer refers to an SDL_Renderer*
         * Only available in 2.0.8 or higher.
         */
        /// <summary>
        ///     Sdls the render get metal layer using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_RenderGetMetalLayer(
            IntPtr renderer
        );

        /* renderer refers to an SDL_Renderer*
         * Only available in 2.0.8 or higher.
         */
        /// <summary>
        ///     Sdls the render get metal command encoder using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_RenderGetMetalCommandEncoder(
            IntPtr renderer
        );

        /* renderer refers to an SDL_Renderer*
         * Only available in 2.0.18 or higher.
         */
        /// <summary>
        ///     Sdls the render set v sync using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="vsync">The vsync</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetVSync(IntPtr renderer, int vsync);

        /* renderer refers to an SDL_Renderer*
         * Only available in 2.0.4 or higher.
         */
        /// <summary>
        ///     Sdls the render is clip enabled using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_RenderIsClipEnabled(IntPtr renderer);

        /* renderer refers to an SDL_Renderer*
         * Only available in 2.0.10 or higher.
         */
        /// <summary>
        ///     Sdls the render flush using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFlush(IntPtr renderer);

        #endregion

        #region SDL_pixels.h

        /// <summary>
        ///     Sdls the define pixelfourcc using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <returns>The uint</returns>
        public static uint SDL_DEFINE_PIXELFOURCC(byte a, byte b, byte c, byte d) => SDL_FOURCC(a, b, c, d);

        /// <summary>
        ///     Sdls the define pixelformat using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="order">The order</param>
        /// <param name="layout">The layout</param>
        /// <param name="bits">The bits</param>
        /// <param name="bytes">The bytes</param>
        /// <returns>The uint</returns>
        public static uint SDL_DEFINE_PIXELFORMAT(
            SdlPixelType type,
            uint order,
            SdlPackedLayout layout,
            byte bits,
            byte bytes
        )
            => (uint) (
                (1 << 28) |
                ((byte) type << 24) |
                ((byte) order << 20) |
                ((byte) layout << 16) |
                (bits << 8) |
                bytes
            );

        /// <summary>
        ///     Sdls the pixelflag using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        public static byte SDL_PIXELFLAG(uint x) => (byte) ((x >> 28) & 0x0F);

        /// <summary>
        ///     Sdls the pixeltype using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        public static byte SDL_PIXELTYPE(uint x) => (byte) ((x >> 24) & 0x0F);

        /// <summary>
        ///     Sdls the pixelorder using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        public static byte SDL_PIXELORDER(uint x) => (byte) ((x >> 20) & 0x0F);

        /// <summary>
        ///     Sdls the pixellayout using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        public static byte SDL_PIXELLAYOUT(uint x) => (byte) ((x >> 16) & 0x0F);

        /// <summary>
        ///     Sdls the bitsperpixel using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        public static byte SDL_BITSPERPIXEL(uint x) => (byte) ((x >> 8) & 0xFF);

        /// <summary>
        ///     Sdls the bytesperpixel using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        public static byte SDL_BYTESPERPIXEL(uint x)
        {
            if (SDL_ISPIXELFORMAT_FOURCC(x))
            {
                if (x == SdlPixelformatYuy2 ||
                    x == SdlPixelformatUyvy ||
                    x == SdlPixelformatYvyu)
                {
                    return 2;
                }

                return 1;
            }

            return (byte) (x & 0xFF);
        }

        /// <summary>
        ///     Describes whether sdl ispixelformat indexed
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SDL_ISPIXELFORMAT_INDEXED(uint format)
        {
            if (SDL_ISPIXELFORMAT_FOURCC(format))
            {
                return false;
            }

            SdlPixelType pType =
                (SdlPixelType) SDL_PIXELTYPE(format);
            return pType == SdlPixelType.SdlPixeltypeIndex1 ||
                   pType == SdlPixelType.SdlPixeltypeIndex4 ||
                   pType == SdlPixelType.SdlPixeltypeIndex8;
        }

        /// <summary>
        ///     Describes whether sdl ispixelformat packed
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SDL_ISPIXELFORMAT_PACKED(uint format)
        {
            if (SDL_ISPIXELFORMAT_FOURCC(format))
            {
                return false;
            }

            SdlPixelType pType =
                (SdlPixelType) SDL_PIXELTYPE(format);
            return pType == SdlPixelType.SdlPixeltypePacked8 ||
                   pType == SdlPixelType.SdlPixeltypePacked16 ||
                   pType == SdlPixelType.SdlPixeltypePacked32;
        }

        /// <summary>
        ///     Describes whether sdl ispixelformat array
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SDL_ISPIXELFORMAT_ARRAY(uint format)
        {
            if (SDL_ISPIXELFORMAT_FOURCC(format))
            {
                return false;
            }

            SdlPixelType pType =
                (SdlPixelType) SDL_PIXELTYPE(format);
            return pType == SdlPixelType.SdlPixeltypeArrayu8 ||
                   pType == SdlPixelType.SdlPixeltypeArrayu16 ||
                   pType == SdlPixelType.SdlPixeltypeArrayu32 ||
                   pType == SdlPixelType.SdlPixeltypeArrayf16 ||
                   pType == SdlPixelType.SdlPixeltypeArrayf32;
        }

        /// <summary>
        ///     Describes whether sdl ispixelformat alpha
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SDL_ISPIXELFORMAT_ALPHA(uint format)
        {
            if (SDL_ISPIXELFORMAT_PACKED(format))
            {
                SdlPackedOrder pOrder =
                    (SdlPackedOrder) SDL_PIXELORDER(format);
                return pOrder == SdlPackedOrder.SdlPackedorderArgb ||
                       pOrder == SdlPackedOrder.SdlPackedorderRgba ||
                       pOrder == SdlPackedOrder.SdlPackedorderAbgr ||
                       pOrder == SdlPackedOrder.SdlPackedorderBgra;
            }

            if (SDL_ISPIXELFORMAT_ARRAY(format))
            {
                SdlArrayOrder aOrder =
                    (SdlArrayOrder) SDL_PIXELORDER(format);
                return aOrder == SdlArrayOrder.SdlArrayorderArgb ||
                       aOrder == SdlArrayOrder.SdlArrayorderRgba ||
                       aOrder == SdlArrayOrder.SdlArrayorderAbgr ||
                       aOrder == SdlArrayOrder.SdlArrayorderBgra;
            }

            return false;
        }

        /// <summary>
        ///     Describes whether sdl ispixelformat fourcc
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SDL_ISPIXELFORMAT_FOURCC(uint format) => (format == 0) && (SDL_PIXELFLAG(format) != 1);

        /// <summary>
        ///     The sdl pixeltype enum
        /// </summary>
        public enum SdlPixelType
        {
            /// <summary>
            ///     The sdl pixeltype unknown sdl pixeltype
            /// </summary>
            SdlPixeltypeUnknown,

            /// <summary>
            ///     The sdl pixeltype index1 sdl pixeltype
            /// </summary>
            SdlPixeltypeIndex1,

            /// <summary>
            ///     The sdl pixeltype index4 sdl pixeltype
            /// </summary>
            SdlPixeltypeIndex4,

            /// <summary>
            ///     The sdl pixeltype index8 sdl pixeltype
            /// </summary>
            SdlPixeltypeIndex8,

            /// <summary>
            ///     The sdl pixeltype packed8 sdl pixeltype
            /// </summary>
            SdlPixeltypePacked8,

            /// <summary>
            ///     The sdl pixeltype packed16 sdl pixeltype
            /// </summary>
            SdlPixeltypePacked16,

            /// <summary>
            ///     The sdl pixeltype packed32 sdl pixeltype
            /// </summary>
            SdlPixeltypePacked32,

            /// <summary>
            ///     The sdl pixeltype arrayu8 sdl pixeltype
            /// </summary>
            SdlPixeltypeArrayu8,

            /// <summary>
            ///     The sdl pixeltype arrayu16 sdl pixeltype
            /// </summary>
            SdlPixeltypeArrayu16,

            /// <summary>
            ///     The sdl pixeltype arrayu32 sdl pixeltype
            /// </summary>
            SdlPixeltypeArrayu32,

            /// <summary>
            ///     The sdl pixeltype arrayf16 sdl pixeltype
            /// </summary>
            SdlPixeltypeArrayf16,

            /// <summary>
            ///     The sdl pixeltype arrayf32 sdl pixeltype
            /// </summary>
            SdlPixeltypeArrayf32
        }

        /// <summary>
        ///     The sdl bitmaporder enum
        /// </summary>
        public enum SdlBitmapOrder
        {
            /// <summary>
            ///     The sdl bitmaporder none sdl bitmaporder
            /// </summary>
            SdlBitmaporderNone,

            /// <summary>
            ///     The sdl bitmaporder 4321 sdl bitmaporder
            /// </summary>
            SdlBitmaporder4321,

            /// <summary>
            ///     The sdl bitmaporder 1234 sdl bitmaporder
            /// </summary>
            SdlBitmaporder1234
        }

        /// <summary>
        ///     The sdl packedorder enum
        /// </summary>
        public enum SdlPackedOrder
        {
            /// <summary>
            ///     The sdl packedorder none sdl packedorder
            /// </summary>
            SdlPackedorderNone,

            /// <summary>
            ///     The sdl packedorder xrgb sdl packedorder
            /// </summary>
            SdlPackedorderXrgb,

            /// <summary>
            ///     The sdl packedorder rgbx sdl packedorder
            /// </summary>
            SdlPackedorderRgbx,

            /// <summary>
            ///     The sdl packedorder argb sdl packedorder
            /// </summary>
            SdlPackedorderArgb,

            /// <summary>
            ///     The sdl packedorder rgba sdl packedorder
            /// </summary>
            SdlPackedorderRgba,

            /// <summary>
            ///     The sdl packedorder xbgr sdl packedorder
            /// </summary>
            SdlPackedorderXbgr,

            /// <summary>
            ///     The sdl packedorder bgrx sdl packedorder
            /// </summary>
            SdlPackedorderBgrx,

            /// <summary>
            ///     The sdl packedorder abgr sdl packedorder
            /// </summary>
            SdlPackedorderAbgr,

            /// <summary>
            ///     The sdl packedorder bgra sdl packedorder
            /// </summary>
            SdlPackedorderBgra
        }

        /// <summary>
        ///     The sdl arrayorder enum
        /// </summary>
        public enum SdlArrayOrder
        {
            /// <summary>
            ///     The sdl arrayorder none sdl arrayorder
            /// </summary>
            SdlArrayorderNone,

            /// <summary>
            ///     The sdl arrayorder rgb sdl arrayorder
            /// </summary>
            SdlArrayorderRgb,

            /// <summary>
            ///     The sdl arrayorder rgba sdl arrayorder
            /// </summary>
            SdlArrayorderRgba,

            /// <summary>
            ///     The sdl arrayorder argb sdl arrayorder
            /// </summary>
            SdlArrayorderArgb,

            /// <summary>
            ///     The sdl arrayorder bgr sdl arrayorder
            /// </summary>
            SdlArrayorderBgr,

            /// <summary>
            ///     The sdl arrayorder bgra sdl arrayorder
            /// </summary>
            SdlArrayorderBgra,

            /// <summary>
            ///     The sdl arrayorder abgr sdl arrayorder
            /// </summary>
            SdlArrayorderAbgr
        }

        /// <summary>
        ///     The sdl packedlayout enum
        /// </summary>
        public enum SdlPackedLayout
        {
            /// <summary>
            ///     The sdl packedlayout none sdl packedlayout
            /// </summary>
            SdlPackedlayoutNone,

            /// <summary>
            ///     The sdl packedlayout 332 sdl packedlayout
            /// </summary>
            SdlPackedlayout332,

            /// <summary>
            ///     The sdl packedlayout 4444 sdl packedlayout
            /// </summary>
            SdlPackedlayout4444,

            /// <summary>
            ///     The sdl packedlayout 1555 sdl packedlayout
            /// </summary>
            SdlPackedlayout1555,

            /// <summary>
            ///     The sdl packedlayout 5551 sdl packedlayout
            /// </summary>
            SdlPackedlayout5551,

            /// <summary>
            ///     The sdl packedlayout 565 sdl packedlayout
            /// </summary>
            SdlPackedlayout565,

            /// <summary>
            ///     The sdl packedlayout 8888 sdl packedlayout
            /// </summary>
            SdlPackedlayout8888,

            /// <summary>
            ///     The sdl packedlayout 2101010 sdl packedlayout
            /// </summary>
            SdlPackedlayout2101010,

            /// <summary>
            ///     The sdl packedlayout 1010102 sdl packedlayout
            /// </summary>
            SdlPackedlayout1010102
        }

        /// <summary>
        ///     The sdl pixelformat unknown
        /// </summary>
        public static readonly uint SdlPixelformatUnknown = 0;

        /// <summary>
        ///     The sdl bitmaporder 4321
        /// </summary>
        public static readonly uint SdlPixelformatIndex1Lsb =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypeIndex1,
                (uint) SdlBitmapOrder.SdlBitmaporder4321,
                0,
                1, 0
            );

        /// <summary>
        ///     The sdl bitmaporder 1234
        /// </summary>
        public static readonly uint SdlPixelformatIndex1Msb =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypeIndex1,
                (uint) SdlBitmapOrder.SdlBitmaporder1234,
                0,
                1, 0
            );

        /// <summary>
        ///     The sdl bitmaporder 4321
        /// </summary>
        public static readonly uint SdlPixelformatIndex4Lsb =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypeIndex4,
                (uint) SdlBitmapOrder.SdlBitmaporder4321,
                0,
                4, 0
            );

        /// <summary>
        ///     The sdl bitmaporder 1234
        /// </summary>
        public static readonly uint SdlPixelformatIndex4Msb =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypeIndex4,
                (uint) SdlBitmapOrder.SdlBitmaporder1234,
                0,
                4, 0
            );

        /// <summary>
        ///     The sdl pixeltype index8
        /// </summary>
        public static readonly uint SdlPixelformatIndex8 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypeIndex8,
                0,
                0,
                8, 1
            );

        /// <summary>
        ///     The sdl packedlayout 332
        /// </summary>
        public static readonly uint SdlPixelformatRgb332 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked8,
                (uint) SdlPackedOrder.SdlPackedorderXrgb,
                SdlPackedLayout.SdlPackedlayout332,
                8, 1
            );

        /// <summary>
        ///     The sdl packedlayout 4444
        /// </summary>
        public static readonly uint SdlPixelformatXrgb444 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderXrgb,
                SdlPackedLayout.SdlPackedlayout4444,
                12, 2
            );

        /// <summary>
        ///     The sdl pixelformat xrgb444
        /// </summary>
        public static readonly uint SdlPixelformatRgb444 =
            SdlPixelformatXrgb444;

        /// <summary>
        ///     The sdl packedlayout 4444
        /// </summary>
        public static readonly uint SdlPixelformatXbgr444 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderXbgr,
                SdlPackedLayout.SdlPackedlayout4444,
                12, 2
            );

        /// <summary>
        ///     The sdl pixelformat xbgr444
        /// </summary>
        public static readonly uint SdlPixelformatBgr444 =
            SdlPixelformatXbgr444;

        /// <summary>
        ///     The sdl packedlayout 1555
        /// </summary>
        public static readonly uint SdlPixelformatXrgb1555 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderXrgb,
                SdlPackedLayout.SdlPackedlayout1555,
                15, 2
            );

        /// <summary>
        ///     The sdl pixelformat xrgb1555
        /// </summary>
        public static readonly uint SdlPixelformatRgb555 =
            SdlPixelformatXrgb1555;

        /// <summary>
        ///     The sdl packedlayout 1555
        /// </summary>
        public static readonly uint SdlPixelformatXbgr1555 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypeIndex1,
                (uint) SdlBitmapOrder.SdlBitmaporder4321,
                SdlPackedLayout.SdlPackedlayout1555,
                15, 2
            );

        /// <summary>
        ///     The sdl pixelformat xbgr1555
        /// </summary>
        public static readonly uint SdlPixelformatBgr555 =
            SdlPixelformatXbgr1555;

        /// <summary>
        ///     The sdl packedlayout 4444
        /// </summary>
        public static readonly uint SdlPixelformatArgb4444 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderArgb,
                SdlPackedLayout.SdlPackedlayout4444,
                16, 2
            );

        /// <summary>
        ///     The sdl packedlayout 4444
        /// </summary>
        public static readonly uint SdlPixelformatRgba4444 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderRgba,
                SdlPackedLayout.SdlPackedlayout4444,
                16, 2
            );

        /// <summary>
        ///     The sdl packedlayout 4444
        /// </summary>
        public static readonly uint SdlPixelformatAbgr4444 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderAbgr,
                SdlPackedLayout.SdlPackedlayout4444,
                16, 2
            );

        /// <summary>
        ///     The sdl packedlayout 4444
        /// </summary>
        public static readonly uint SdlPixelformatBgra4444 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderBgra,
                SdlPackedLayout.SdlPackedlayout4444,
                16, 2
            );

        /// <summary>
        ///     The sdl packedlayout 1555
        /// </summary>
        public static readonly uint SdlPixelformatArgb1555 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderArgb,
                SdlPackedLayout.SdlPackedlayout1555,
                16, 2
            );

        /// <summary>
        ///     The sdl packedlayout 5551
        /// </summary>
        public static readonly uint SdlPixelformatRgba5551 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderRgba,
                SdlPackedLayout.SdlPackedlayout5551,
                16, 2
            );

        /// <summary>
        ///     The sdl packedlayout 1555
        /// </summary>
        public static readonly uint SdlPixelformatAbgr1555 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderAbgr,
                SdlPackedLayout.SdlPackedlayout1555,
                16, 2
            );

        /// <summary>
        ///     The sdl packedlayout 5551
        /// </summary>
        public static readonly uint SdlPixelformatBgra5551 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderBgra,
                SdlPackedLayout.SdlPackedlayout5551,
                16, 2
            );

        /// <summary>
        ///     The sdl packedlayout 565
        /// </summary>
        public static readonly uint SdlPixelformatRgb565 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderXrgb,
                SdlPackedLayout.SdlPackedlayout565,
                16, 2
            );

        /// <summary>
        ///     The sdl packedlayout 565
        /// </summary>
        public static readonly uint SdlPixelformatBgr565 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderXbgr,
                SdlPackedLayout.SdlPackedlayout565,
                16, 2
            );

        /// <summary>
        ///     The sdl arrayorder rgb
        /// </summary>
        public static readonly uint SdlPixelformatRgb24 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypeArrayu8,
                (uint) SdlArrayOrder.SdlArrayorderRgb,
                0,
                24, 3
            );

        /// <summary>
        ///     The sdl arrayorder bgr
        /// </summary>
        public static readonly uint SdlPixelformatBgr24 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypeArrayu8,
                (uint) SdlArrayOrder.SdlArrayorderBgr,
                0,
                24, 3
            );

        /// <summary>
        ///     The sdl packedlayout 8888
        /// </summary>
        public static readonly uint SdlPixelformatXrgb888 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderXrgb,
                SdlPackedLayout.SdlPackedlayout8888,
                24, 4
            );

        /// <summary>
        ///     The sdl pixelformat xrgb888
        /// </summary>
        public static readonly uint SdlPixelformatRgb888 =
            SdlPixelformatXrgb888;

        /// <summary>
        ///     The sdl packedlayout 8888
        /// </summary>
        public static readonly uint SdlPixelformatRgbx8888 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderRgbx,
                SdlPackedLayout.SdlPackedlayout8888,
                24, 4
            );

        /// <summary>
        ///     The sdl packedlayout 8888
        /// </summary>
        public static readonly uint SdlPixelformatXbgr888 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderXbgr,
                SdlPackedLayout.SdlPackedlayout8888,
                24, 4
            );

        /// <summary>
        ///     The sdl pixelformat xbgr888
        /// </summary>
        public static readonly uint SdlPixelformatBgr888 =
            SdlPixelformatXbgr888;

        /// <summary>
        ///     The sdl packedlayout 8888
        /// </summary>
        public static readonly uint SdlPixelformatBgrx8888 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderBgrx,
                SdlPackedLayout.SdlPackedlayout8888,
                24, 4
            );

        /// <summary>
        ///     The sdl packedlayout 8888
        /// </summary>
        public static readonly uint SdlPixelformatArgb8888 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderArgb,
                SdlPackedLayout.SdlPackedlayout8888,
                32, 4
            );

        /// <summary>
        ///     The sdl packedlayout 8888
        /// </summary>
        public static readonly uint SdlPixelformatRgba8888 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderRgba,
                SdlPackedLayout.SdlPackedlayout8888,
                32, 4
            );

        /// <summary>
        ///     The sdl packedlayout 8888
        /// </summary>
        public static readonly uint SdlPixelformatAbgr8888 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderAbgr,
                SdlPackedLayout.SdlPackedlayout8888,
                32, 4
            );

        /// <summary>
        ///     The sdl packedlayout 8888
        /// </summary>
        public static readonly uint SdlPixelformatBgra8888 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderBgra,
                SdlPackedLayout.SdlPackedlayout8888,
                32, 4
            );

        /// <summary>
        ///     The sdl packedlayout 2101010
        /// </summary>
        public static readonly uint SdlPixelformatArgb2101010 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderArgb,
                SdlPackedLayout.SdlPackedlayout2101010,
                32, 4
            );

        /// <summary>
        ///     The sdl define pixelfourcc
        /// </summary>
        public static readonly uint SdlPixelformatYv12 =
            SDL_DEFINE_PIXELFOURCC(
                (byte) 'Y', (byte) 'V', (byte) '1', (byte) '2'
            );

        /// <summary>
        ///     The sdl define pixelfourcc
        /// </summary>
        public static readonly uint SdlPixelformatIyuv =
            SDL_DEFINE_PIXELFOURCC(
                (byte) 'I', (byte) 'Y', (byte) 'U', (byte) 'V'
            );

        /// <summary>
        ///     The sdl define pixelfourcc
        /// </summary>
        public static readonly uint SdlPixelformatYuy2 =
            SDL_DEFINE_PIXELFOURCC(
                (byte) 'Y', (byte) 'U', (byte) 'Y', (byte) '2'
            );

        /// <summary>
        ///     The sdl define pixelfourcc
        /// </summary>
        public static readonly uint SdlPixelformatUyvy =
            SDL_DEFINE_PIXELFOURCC(
                (byte) 'U', (byte) 'Y', (byte) 'V', (byte) 'Y'
            );

        /// <summary>
        ///     The sdl define pixelfourcc
        /// </summary>
        public static readonly uint SdlPixelformatYvyu =
            SDL_DEFINE_PIXELFOURCC(
                (byte) 'Y', (byte) 'V', (byte) 'Y', (byte) 'U'
            );

        /// <summary>
        ///     The sdl color
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlColor
        {
            /// <summary>
            ///     The
            /// </summary>
            public byte r;

            /// <summary>
            ///     The
            /// </summary>
            public byte g;

            /// <summary>
            ///     The
            /// </summary>
            public byte b;

            /// <summary>
            ///     The
            /// </summary>
            public byte a;
        }

        /// <summary>
        ///     The sdl palette
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlPalette
        {
            /// <summary>
            ///     The ncolors
            /// </summary>
            public int ncolors;

            /// <summary>
            ///     The colors
            /// </summary>
            public IntPtr colors;

            /// <summary>
            ///     The version
            /// </summary>
            public int version;

            /// <summary>
            ///     The refcount
            /// </summary>
            public int refcount;
        }

        /// <summary>
        ///     The sdl pixelformat
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlPixelFormat
        {
            /// <summary>
            ///     The format
            /// </summary>
            public uint format;

            /// <summary>
            ///     The palette
            /// </summary>
            public IntPtr palette; // SDL_Palette*

            /// <summary>
            ///     The bits per pixel
            /// </summary>
            public byte BitsPerPixel;

            /// <summary>
            ///     The bytes per pixel
            /// </summary>
            public byte BytesPerPixel;

            /// <summary>
            ///     The rmask
            /// </summary>
            public uint Rmask;

            /// <summary>
            ///     The gmask
            /// </summary>
            public uint Gmask;

            /// <summary>
            ///     The bmask
            /// </summary>
            public uint Bmask;

            /// <summary>
            ///     The amask
            /// </summary>
            public uint Amask;

            /// <summary>
            ///     The rloss
            /// </summary>
            public byte Rloss;

            /// <summary>
            ///     The gloss
            /// </summary>
            public byte Gloss;

            /// <summary>
            ///     The bloss
            /// </summary>
            public byte Bloss;

            /// <summary>
            ///     The aloss
            /// </summary>
            public byte Aloss;

            /// <summary>
            ///     The rshift
            /// </summary>
            public byte Rshift;

            /// <summary>
            ///     The gshift
            /// </summary>
            public byte Gshift;

            /// <summary>
            ///     The bshift
            /// </summary>
            public byte Bshift;

            /// <summary>
            ///     The ashift
            /// </summary>
            public byte Ashift;

            /// <summary>
            ///     The refcount
            /// </summary>
            public int refcount;

            /// <summary>
            ///     The next
            /// </summary>
            public IntPtr next; // SDL_PixelFormat*
        }

        /* IntPtr refers to an SDL_PixelFormat* */
        /// <summary>
        ///     Sdls the alloc format using the specified pixel format
        /// </summary>
        /// <param name="pixelFormat">The pixel format</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_AllocFormat(uint pixelFormat);

        /* IntPtr refers to an SDL_Palette* */
        /// <summary>
        ///     Sdls the alloc palette using the specified ncolors
        /// </summary>
        /// <param name="ncolors">The ncolors</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_AllocPalette(int ncolors);

        /// <summary>
        ///     Sdls the calculate gamma ramp using the specified gamma
        /// </summary>
        /// <param name="gamma">The gamma</param>
        /// <param name="ramp">The ramp</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_CalculateGammaRamp(
            float gamma,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] ramp
        );

        /* format refers to an SDL_PixelFormat* */
        /// <summary>
        ///     Sdls the free format using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeFormat(IntPtr format);

        /* palette refers to an SDL_Palette* */
        /// <summary>
        ///     Sdls the free palette using the specified palette
        /// </summary>
        /// <param name="palette">The palette</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreePalette(IntPtr palette);

        /// <summary>
        ///     Internals the sdl get pixel format name using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPixelFormatName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetPixelFormatName(
            uint format
        );

        /// <summary>
        ///     Sdls the get pixel format name using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The string</returns>
        public static string SDL_GetPixelFormatName(uint format) => UTF8_ToManaged(
            INTERNAL_SDL_GetPixelFormatName(format)
        );

        /* format refers to an SDL_PixelFormat* */
        /// <summary>
        ///     Sdls the get rgb using the specified pixel
        /// </summary>
        /// <param name="pixel">The pixel</param>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetRGB(
            uint pixel,
            IntPtr format,
            out byte r,
            out byte g,
            out byte b
        );

        /* format refers to an SDL_PixelFormat* */
        /// <summary>
        ///     Sdls the get rgba using the specified pixel
        /// </summary>
        /// <param name="pixel">The pixel</param>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetRGBA(
            uint pixel,
            IntPtr format,
            out byte r,
            out byte g,
            out byte b,
            out byte a
        );

        /* format refers to an SDL_PixelFormat* */
        /// <summary>
        ///     Sdls the map rgb using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_MapRGB(
            IntPtr format,
            byte r,
            byte g,
            byte b
        );

        /* format refers to an SDL_PixelFormat* */
        /// <summary>
        ///     Sdls the map rgba using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_MapRGBA(
            IntPtr format,
            byte r,
            byte g,
            byte b,
            byte a
        );

        /// <summary>
        ///     Sdls the masks to pixel format enum using the specified bpp
        /// </summary>
        /// <param name="bpp">The bpp</param>
        /// <param name="rmask">The rmask</param>
        /// <param name="gmask">The gmask</param>
        /// <param name="bmask">The bmask</param>
        /// <param name="amask">The amask</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_MasksToPixelFormatEnum(
            int bpp,
            uint rmask,
            uint gmask,
            uint bmask,
            uint amask
        );

        /// <summary>
        ///     Sdls the pixel format enum to masks using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="bpp">The bpp</param>
        /// <param name="rmask">The rmask</param>
        /// <param name="gmask">The gmask</param>
        /// <param name="bmask">The bmask</param>
        /// <param name="amask">The amask</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_PixelFormatEnumToMasks(
            uint format,
            out int bpp,
            out uint rmask,
            out uint gmask,
            out uint bmask,
            out uint amask
        );

        /* palette refers to an SDL_Palette* */
        /// <summary>
        ///     Sdls the set palette colors using the specified palette
        /// </summary>
        /// <param name="palette">The palette</param>
        /// <param name="colors">The colors</param>
        /// <param name="firstcolor">The firstcolor</param>
        /// <param name="ncolors">The ncolors</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetPaletteColors(
            IntPtr palette,
            [In] SdlColor[] colors,
            int firstcolor,
            int ncolors
        );

        /* format and palette refer to an SDL_PixelFormat* and SDL_Palette* */
        /// <summary>
        ///     Sdls the set pixel format palette using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="palette">The palette</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetPixelFormatPalette(
            IntPtr format,
            IntPtr palette
        );

        #endregion

        #region SDL_rect.h

        /// <summary>
        ///     The sdl point
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlPoint
        {
            /// <summary>
            ///     The
            /// </summary>
            public int x;

            /// <summary>
            ///     The
            /// </summary>
            public int y;
        }

        /// <summary>
        ///     The sdl rect
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlRect
        {
            /// <summary>
            ///     The
            /// </summary>
            public int x;

            /// <summary>
            ///     The
            /// </summary>
            public int y;

            /// <summary>
            ///     The
            /// </summary>
            public int w;

            /// <summary>
            ///     The
            /// </summary>
            public int h;
        }

        /* Only available in 2.0.10 or higher. */
        /// <summary>
        ///     The sdl fpoint
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlFPoint
        {
            /// <summary>
            ///     The
            /// </summary>
            public float x;

            /// <summary>
            ///     The
            /// </summary>
            public float y;
        }

        /* Only available in 2.0.10 or higher. */
        /// <summary>
        ///     The sdl frect
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlFRect
        {
            /// <summary>
            ///     The
            /// </summary>
            public float x;

            /// <summary>
            ///     The
            /// </summary>
            public float y;

            /// <summary>
            ///     The
            /// </summary>
            public float w;

            /// <summary>
            ///     The
            /// </summary>
            public float h;
        }

        /* Only available in 2.0.4 or higher. */
        /// <summary>
        ///     Sdls the point in rect using the specified p
        /// </summary>
        /// <param name="p">The </param>
        /// <param name="r">The </param>
        /// <returns>The sdl bool</returns>
        public static SdlBool SDL_PointInRect(ref SdlPoint p, ref SdlRect r) => (p.x >= r.x) &&
                                                                                   (p.x < r.x + r.w) &&
                                                                                   (p.y >= r.y) &&
                                                                                   (p.y < r.y + r.h)
            ? SdlBool.SdlTrue
            : SdlBool.SdlFalse;

        /// <summary>
        ///     Sdls the enclose points using the specified points
        /// </summary>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <param name="clip">The clip</param>
        /// <param name="result">The result</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_EnclosePoints(
            [In] SdlPoint[] points,
            int count,
            ref SdlRect clip,
            out SdlRect result
        );

        /// <summary>
        ///     Sdls the has intersection using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasIntersection(
            ref SdlRect a,
            ref SdlRect b
        );

        /// <summary>
        ///     Sdls the intersect rect using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="result">The result</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IntersectRect(
            ref SdlRect a,
            ref SdlRect b,
            out SdlRect result
        );

        /// <summary>
        ///     Sdls the intersect rect and line using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IntersectRectAndLine(
            ref SdlRect rect,
            ref int x1,
            ref int y1,
            ref int x2,
            ref int y2
        );

        /// <summary>
        ///     Sdls the rect empty using the specified r
        /// </summary>
        /// <param name="r">The </param>
        /// <returns>The sdl bool</returns>
        public static SdlBool SDL_RectEmpty(ref SdlRect r) => r.w <= 0 || r.h <= 0 ? SdlBool.SdlTrue : SdlBool.SdlFalse;

        /// <summary>
        ///     Sdls the rect equals using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The sdl bool</returns>
        public static SdlBool SDL_RectEquals(
            ref SdlRect a,
            ref SdlRect b
        )
            => (a.x == b.x) &&
               (a.y == b.y) &&
               (a.w == b.w) &&
               (a.h == b.h)
                ? SdlBool.SdlTrue
                : SdlBool.SdlFalse;

        /// <summary>
        ///     Sdls the union rect using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="result">The result</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnionRect(
            ref SdlRect a,
            ref SdlRect b,
            out SdlRect result
        );

        #endregion

        #region SDL_surface.h

        /// <summary>
        ///     The sdl swsurface
        /// </summary>
        public const uint SdlSwsurface = 0x00000000;

        /// <summary>
        ///     The sdl prealloc
        /// </summary>
        public const uint SdlPrealloc = 0x00000001;

        /// <summary>
        ///     The sdl rleaccel
        /// </summary>
        public const uint SdlRleaccel = 0x00000002;

        /// <summary>
        ///     The sdl dontfree
        /// </summary>
        public const uint SdlDontfree = 0x00000004;

        /// <summary>
        ///     The sdl surface
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlSurface
        {
            /// <summary>
            ///     The flags
            /// </summary>
            public uint flags;

            /// <summary>
            ///     The format
            /// </summary>
            public IntPtr format; // SDL_PixelFormat*

            /// <summary>
            ///     The
            /// </summary>
            public int w;

            /// <summary>
            ///     The
            /// </summary>
            public int h;

            /// <summary>
            ///     The pitch
            /// </summary>
            public int pitch;

            /// <summary>
            ///     The pixels
            /// </summary>
            public IntPtr pixels; // void*

            /// <summary>
            ///     The userdata
            /// </summary>
            public IntPtr userdata; // void*

            /// <summary>
            ///     The locked
            /// </summary>
            public int locked;

            /// <summary>
            ///     The list blitmap
            /// </summary>
            public IntPtr list_blitmap; // void*

            /// <summary>
            ///     The clip rect
            /// </summary>
            public SdlRect clip_rect;

            /// <summary>
            ///     The map
            /// </summary>
            public IntPtr map; // SDL_BlitMap*

            /// <summary>
            ///     The refcount
            /// </summary>
            public int refcount;
        }

        /* surface refers to an SDL_Surface* */
        /// <summary>
        ///     Describes whether sdl mustlock
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The bool</returns>
        public static bool SDL_MUSTLOCK(IntPtr surface)
        {
            SdlSurface sur;
            sur = (SdlSurface) Marshal.PtrToStructure(
                surface,
                typeof(SdlSurface)
            );
            return (sur.flags & SdlRleaccel) != 0;
        }

        /* src and dst refer to an SDL_Surface* */
        /// <summary>
        ///     Sdls the blit surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_BlitSurface(
            IntPtr src,
            ref SdlRect srcrect,
            IntPtr dst,
            ref SdlRect dstrect
        );

        /* src and dst refer to an SDL_Surface*
         * Internally, this function contains logic to use default values when
         * source and destination rectangles are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for srcrect.
         */
        /// <summary>
        ///     Sdls the blit surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_BlitSurface(
            IntPtr src,
            IntPtr srcrect,
            IntPtr dst,
            ref SdlRect dstrect
        );

        /* src and dst refer to an SDL_Surface*
         * Internally, this function contains logic to use default values when
         * source and destination rectangles are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for dstrect.
         */
        /// <summary>
        ///     Sdls the blit surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_BlitSurface(
            IntPtr src,
            ref SdlRect srcrect,
            IntPtr dst,
            IntPtr dstrect
        );

        /* src and dst refer to an SDL_Surface*
         * Internally, this function contains logic to use default values when
         * source and destination rectangles are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for both SDL_Rects.
         */
        /// <summary>
        ///     Sdls the blit surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_BlitSurface(
            IntPtr src,
            IntPtr srcrect,
            IntPtr dst,
            IntPtr dstrect
        );

        /* src and dst refer to an SDL_Surface* */
        /// <summary>
        ///     Sdls the blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_BlitScaled(
            IntPtr src,
            ref SdlRect srcrect,
            IntPtr dst,
            ref SdlRect dstrect
        );

        /* src and dst refer to an SDL_Surface*
         * Internally, this function contains logic to use default values when
         * source and destination rectangles are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for srcrect.
         */
        /// <summary>
        ///     Sdls the blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_BlitScaled(
            IntPtr src,
            IntPtr srcrect,
            IntPtr dst,
            ref SdlRect dstrect
        );

        /* src and dst refer to an SDL_Surface*
         * Internally, this function contains logic to use default values when
         * source and destination rectangles are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for dstrect.
         */
        /// <summary>
        ///     Sdls the blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_BlitScaled(
            IntPtr src,
            ref SdlRect srcrect,
            IntPtr dst,
            IntPtr dstrect
        );

        /* src and dst refer to an SDL_Surface*
         * Internally, this function contains logic to use default values when
         * source and destination rectangles are passed as NULL.
         * This overload allows for IntPtr.Zero (null) to be passed for both SDL_Rects.
         */
        /// <summary>
        ///     Sdls the blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_BlitScaled(
            IntPtr src,
            IntPtr srcrect,
            IntPtr dst,
            IntPtr dstrect
        );

        /* src and dst are void* pointers */
        /// <summary>
        ///     Sdls the convert pixels using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="srcFormat">The src format</param>
        /// <param name="src">The src</param>
        /// <param name="srcPitch">The src pitch</param>
        /// <param name="dstFormat">The dst format</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstPitch">The dst pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_ConvertPixels(
            int width,
            int height,
            uint srcFormat,
            IntPtr src,
            int srcPitch,
            uint dstFormat,
            IntPtr dst,
            int dstPitch
        );

        /* src and dst are void* pointers
         * Only available in 2.0.18 or higher.
         */
        /// <summary>
        ///     Sdls the premultiply alpha using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="srcFormat">The src format</param>
        /// <param name="src">The src</param>
        /// <param name="srcPitch">The src pitch</param>
        /// <param name="dstFormat">The dst format</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstPitch">The dst pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_PremultiplyAlpha(
            int width,
            int height,
            uint srcFormat,
            IntPtr src,
            int srcPitch,
            uint dstFormat,
            IntPtr dst,
            int dstPitch
        );

        /* IntPtr refers to an SDL_Surface*
         * src refers to an SDL_Surface*
         * fmt refers to an SDL_PixelFormat*
         */
        /// <summary>
        ///     Sdls the convert surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="fmt">The fmt</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_ConvertSurface(
            IntPtr src,
            IntPtr fmt,
            uint flags
        );

        /* IntPtr refers to an SDL_Surface*, src to an SDL_Surface* */
        /// <summary>
        ///     Sdls the convert surface format using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="pixelFormat">The pixel format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_ConvertSurfaceFormat(
            IntPtr src,
            uint pixelFormat,
            uint flags
        );

        /* IntPtr refers to an SDL_Surface* */
        /// <summary>
        ///     Sdls the create rgb surface using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="rmask">The rmask</param>
        /// <param name="gmask">The gmask</param>
        /// <param name="bmask">The bmask</param>
        /// <param name="amask">The amask</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateRGBSurface(
            uint flags,
            int width,
            int height,
            int depth,
            uint rmask,
            uint gmask,
            uint bmask,
            uint amask
        );

        /* IntPtr refers to an SDL_Surface*, pixels to a void* */
        /// <summary>
        ///     Sdls the create rgb surface from using the specified pixels
        /// </summary>
        /// <param name="pixels">The pixels</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="pitch">The pitch</param>
        /// <param name="rmask">The rmask</param>
        /// <param name="gmask">The gmask</param>
        /// <param name="bmask">The bmask</param>
        /// <param name="amask">The amask</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateRGBSurfaceFrom(
            IntPtr pixels,
            int width,
            int height,
            int depth,
            int pitch,
            uint rmask,
            uint gmask,
            uint bmask,
            uint amask
        );

        /* IntPtr refers to an SDL_Surface*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Sdls the create rgb surface with format using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="format">The format</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateRGBSurfaceWithFormat(
            uint flags,
            int width,
            int height,
            int depth,
            uint format
        );

        /* IntPtr refers to an SDL_Surface*, pixels to a void*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Sdls the create rgb surface with format from using the specified pixels
        /// </summary>
        /// <param name="pixels">The pixels</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="pitch">The pitch</param>
        /// <param name="format">The format</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateRGBSurfaceWithFormatFrom(
            IntPtr pixels,
            int width,
            int height,
            int depth,
            int pitch,
            uint format
        );

        /* dst refers to an SDL_Surface* */
        /// <summary>
        ///     Sdls the fill rect using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rect">The rect</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_FillRect(
            IntPtr dst,
            ref SdlRect rect,
            uint color
        );

        /* dst refers to an SDL_Surface*.
         * This overload allows passing NULL to rect.
         */
        /// <summary>
        ///     Sdls the fill rect using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rect">The rect</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_FillRect(
            IntPtr dst,
            IntPtr rect,
            uint color
        );

        /* dst refers to an SDL_Surface* */
        /// <summary>
        ///     Sdls the fill rects using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_FillRects(
            IntPtr dst,
            [In] SdlRect[] rects,
            int count,
            uint color
        );

        /* surface refers to an SDL_Surface* */
        /// <summary>
        ///     Sdls the free surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeSurface(IntPtr surface);

        /* surface refers to an SDL_Surface* */
        /// <summary>
        ///     Sdls the get clip rect using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="rect">The rect</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetClipRect(
            IntPtr surface,
            out SdlRect rect
        );

        /* surface refers to an SDL_Surface*.
         * Only available in 2.0.9 or higher.
         */
        /// <summary>
        ///     Sdls the has color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasColorKey(IntPtr surface);

        /* surface refers to an SDL_Surface* */
        /// <summary>
        ///     Sdls the get color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="key">The key</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetColorKey(
            IntPtr surface,
            out uint key
        );

        /* surface refers to an SDL_Surface* */
        /// <summary>
        ///     Sdls the get surface alpha mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetSurfaceAlphaMod(
            IntPtr surface,
            out byte alpha
        );

        /* surface refers to an SDL_Surface* */
        /// <summary>
        ///     Sdls the get surface blend mode using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetSurfaceBlendMode(
            IntPtr surface,
            out SdlBlendMode blendMode
        );

        /* surface refers to an SDL_Surface* */
        /// <summary>
        ///     Sdls the get surface color mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetSurfaceColorMod(
            IntPtr surface,
            out byte r,
            out byte g,
            out byte b
        );

        /* These are for SDL_LoadBMP, which is a macro in the SDL headers. */
        /* IntPtr refers to an SDL_Surface* */
        /* THIS IS AN RWops FUNCTION! */
        /// <summary>
        ///     Internals the sdl load bmp rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LoadBMP_RW", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_LoadBMP_RW(
            IntPtr src,
            int freesrc
        );

        /// <summary>
        ///     Sdls the load bmp using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        public static IntPtr SDL_LoadBMP(string file)
        {
            IntPtr rwops = SDL_RWFromFile(file, "rb");
            return INTERNAL_SDL_LoadBMP_RW(rwops, 1);
        }

        /* surface refers to an SDL_Surface* */
        /// <summary>
        ///     Sdls the lock surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LockSurface(IntPtr surface);

        /* src and dst refer to an SDL_Surface* */
        /// <summary>
        ///     Sdls the lower blit using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LowerBlit(
            IntPtr src,
            ref SdlRect srcrect,
            IntPtr dst,
            ref SdlRect dstrect
        );

        /* src and dst refer to an SDL_Surface* */
        /// <summary>
        ///     Sdls the lower blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LowerBlitScaled(
            IntPtr src,
            ref SdlRect srcrect,
            IntPtr dst,
            ref SdlRect dstrect
        );

        /* These are for SDL_SaveBMP, which is a macro in the SDL headers. */
        /* IntPtr refers to an SDL_Surface* */
        /* THIS IS AN RWops FUNCTION! */
        /// <summary>
        ///     Internals the sdl save bmp rw using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SaveBMP_RW", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_SDL_SaveBMP_RW(
            IntPtr surface,
            IntPtr src,
            int freesrc
        );

        /// <summary>
        ///     Sdls the save bmp using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="file">The file</param>
        /// <returns>The int</returns>
        public static int SDL_SaveBMP(IntPtr surface, string file)
        {
            IntPtr rwops = SDL_RWFromFile(file, "wb");
            return INTERNAL_SDL_SaveBMP_RW(surface, rwops, 1);
        }

        /* surface refers to an SDL_Surface* */
        /// <summary>
        ///     Sdls the set clip rect using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="rect">The rect</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_SetClipRect(
            IntPtr surface,
            ref SdlRect rect
        );

        /* surface refers to an SDL_Surface* */
        /// <summary>
        ///     Sdls the set color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="flag">The flag</param>
        /// <param name="key">The key</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetColorKey(
            IntPtr surface,
            int flag,
            uint key
        );

        /* surface refers to an SDL_Surface* */
        /// <summary>
        ///     Sdls the set surface alpha mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfaceAlphaMod(
            IntPtr surface,
            byte alpha
        );

        /* surface refers to an SDL_Surface* */
        /// <summary>
        ///     Sdls the set surface blend mode using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfaceBlendMode(
            IntPtr surface,
            SdlBlendMode blendMode
        );

        /* surface refers to an SDL_Surface* */
        /// <summary>
        ///     Sdls the set surface color mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfaceColorMod(
            IntPtr surface,
            byte r,
            byte g,
            byte b
        );

        /* surface refers to an SDL_Surface*, palette to an SDL_Palette* */
        /// <summary>
        ///     Sdls the set surface palette using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="palette">The palette</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfacePalette(
            IntPtr surface,
            IntPtr palette
        );

        /* surface refers to an SDL_Surface* */
        /// <summary>
        ///     Sdls the set surface rle using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="flag">The flag</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfaceRLE(
            IntPtr surface,
            int flag
        );

        /* surface refers to an SDL_Surface*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Sdls the has surface rle using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasSurfaceRLE(
            IntPtr surface
        );

        /* src and dst refer to an SDL_Surface* */
        /// <summary>
        ///     Sdls the soft stretch using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SoftStretch(
            IntPtr src,
            ref SdlRect srcrect,
            IntPtr dst,
            ref SdlRect dstrect
        );

        /* src and dst refer to an SDL_Surface*
         * Only available in 2.0.16 or higher.
         */
        /// <summary>
        ///     Sdls the soft stretch linear using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SoftStretchLinear(
            IntPtr src,
            ref SdlRect srcrect,
            IntPtr dst,
            ref SdlRect dstrect
        );

        /* surface refers to an SDL_Surface* */
        /// <summary>
        ///     Sdls the unlock surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockSurface(IntPtr surface);

        /* src and dst refer to an SDL_Surface* */
        /// <summary>
        ///     Sdls the upper blit using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpperBlit(
            IntPtr src,
            ref SdlRect srcrect,
            IntPtr dst,
            ref SdlRect dstrect
        );

        /* src and dst refer to an SDL_Surface* */
        /// <summary>
        ///     Sdls the upper blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpperBlitScaled(
            IntPtr src,
            ref SdlRect srcrect,
            IntPtr dst,
            ref SdlRect dstrect
        );

        /* surface and IntPtr refer to an SDL_Surface* */
        /// <summary>
        ///     Sdls the duplicate surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_DuplicateSurface(IntPtr surface);

        #endregion

        #region SDL_clipboard.h

        /// <summary>
        ///     Sdls the has clipboard text
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasClipboardText();

        /// <summary>
        ///     Internals the sdl get clipboard text
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetClipboardText", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetClipboardText();

        /// <summary>
        ///     Sdls the get clipboard text
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_GetClipboardText() => UTF8_ToManaged(INTERNAL_SDL_GetClipboardText(), true);

        /// <summary>
        ///     Internals the sdl set clipboard text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetClipboardText", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int INTERNAL_SDL_SetClipboardText(
            byte* text
        );

        /// <summary>
        ///     Sdls the set clipboard text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The result</returns>
        public static unsafe int SDL_SetClipboardText(
            string text
        )
        {
            byte* utf8Text = Utf8EncodeHeap(text);
            int result = INTERNAL_SDL_SetClipboardText(
                utf8Text
            );
            Marshal.FreeHGlobal((IntPtr) utf8Text);
            return result;
        }

        #endregion

        #region SDL_events.h

        /* General keyboard/mouse state definitions. */
        /// <summary>
        ///     The sdl pressed
        /// </summary>
        public const byte SdlPressed = 1;

        /// <summary>
        ///     The sdl released
        /// </summary>
        public const byte SdlReleased = 0;

        /* Default size is according to SDL2 default. */
        /// <summary>
        ///     The sdl texteditingevent text size
        /// </summary>
        public const int SdlTexteditingeventTextSize = 32;

        /// <summary>
        ///     The sdl textinputevent text size
        /// </summary>
        public const int SdlTextinputeventTextSize = 32;

        /* The types of events that can be delivered. */
        /// <summary>
        ///     The sdl eventtype enum
        /// </summary>
        public enum SdlEventType : uint
        {
            /// <summary>
            ///     The sdl firstevent sdl eventtype
            /// </summary>
            SdlFirstevent = 0,

            /* Application events */
            /// <summary>
            ///     The sdl quit sdl eventtype
            /// </summary>
            SdlQuit = 0x100,

            /* iOS/Android/WinRT app events */
            /// <summary>
            ///     The sdl app terminating sdl eventtype
            /// </summary>
            SdlAppTerminating,

            /// <summary>
            ///     The sdl app lowmemory sdl eventtype
            /// </summary>
            SdlAppLowmemory,

            /// <summary>
            ///     The sdl app willenterbackground sdl eventtype
            /// </summary>
            SdlAppWillenterbackground,

            /// <summary>
            ///     The sdl app didenterbackground sdl eventtype
            /// </summary>
            SdlAppDidenterbackground,

            /// <summary>
            ///     The sdl app willenterforeground sdl eventtype
            /// </summary>
            SdlAppWillenterforeground,

            /// <summary>
            ///     The sdl app didenterforeground sdl eventtype
            /// </summary>
            SdlAppDidenterforeground,

            /* Only available in SDL 2.0.14 or higher. */
            /// <summary>
            ///     The sdl localechanged sdl eventtype
            /// </summary>
            SdlLocalechanged,

            /* Display events */
            /* Only available in SDL 2.0.9 or higher. */
            /// <summary>
            ///     The sdl displayevent sdl eventtype
            /// </summary>
            SdlDisplayevent = 0x150,

            /* Window events */
            /// <summary>
            ///     The sdl windowevent sdl eventtype
            /// </summary>
            SdlWindowevent = 0x200,

            /// <summary>
            ///     The sdl syswmevent sdl eventtype
            /// </summary>
            SdlSyswmevent,

            /* Keyboard events */
            /// <summary>
            ///     The sdl keydown sdl eventtype
            /// </summary>
            SdlKeydown = 0x300,

            /// <summary>
            ///     The sdl keyup sdl eventtype
            /// </summary>
            SdlKeyup,

            /// <summary>
            ///     The sdl textediting sdl eventtype
            /// </summary>
            SdlTextediting,

            /// <summary>
            ///     The sdl textinput sdl eventtype
            /// </summary>
            SdlTextinput,

            /// <summary>
            ///     The sdl keymapchanged sdl eventtype
            /// </summary>
            SdlKeymapchanged,

            /* Mouse events */
            /// <summary>
            ///     The sdl mousemotion sdl eventtype
            /// </summary>
            SdlMousemotion = 0x400,

            /// <summary>
            ///     The sdl mousebuttondown sdl eventtype
            /// </summary>
            SdlMousebuttondown,

            /// <summary>
            ///     The sdl mousebuttonup sdl eventtype
            /// </summary>
            SdlMousebuttonup,

            /// <summary>
            ///     The sdl mousewheel sdl eventtype
            /// </summary>
            SdlMousewheel,

            /* Joystick events */
            /// <summary>
            ///     The sdl joyaxismotion sdl eventtype
            /// </summary>
            SdlJoyaxismotion = 0x600,

            /// <summary>
            ///     The sdl joyballmotion sdl eventtype
            /// </summary>
            SdlJoyballmotion,

            /// <summary>
            ///     The sdl joyhatmotion sdl eventtype
            /// </summary>
            SdlJoyhatmotion,

            /// <summary>
            ///     The sdl joybuttondown sdl eventtype
            /// </summary>
            SdlJoybuttondown,

            /// <summary>
            ///     The sdl joybuttonup sdl eventtype
            /// </summary>
            SdlJoybuttonup,

            /// <summary>
            ///     The sdl joydeviceadded sdl eventtype
            /// </summary>
            SdlJoydeviceadded,

            /// <summary>
            ///     The sdl joydeviceremoved sdl eventtype
            /// </summary>
            SdlJoydeviceremoved,

            /* Game controller events */
            /// <summary>
            ///     The sdl controlleraxismotion sdl eventtype
            /// </summary>
            SdlControlleraxismotion = 0x650,

            /// <summary>
            ///     The sdl controllerbuttondown sdl eventtype
            /// </summary>
            SdlControllerbuttondown,

            /// <summary>
            ///     The sdl controllerbuttonup sdl eventtype
            /// </summary>
            SdlControllerbuttonup,

            /// <summary>
            ///     The sdl controllerdeviceadded sdl eventtype
            /// </summary>
            SdlControllerdeviceadded,

            /// <summary>
            ///     The sdl controllerdeviceremoved sdl eventtype
            /// </summary>
            SdlControllerdeviceremoved,

            /// <summary>
            ///     The sdl controllerdeviceremapped sdl eventtype
            /// </summary>
            SdlControllerdeviceremapped,

            /// <summary>
            ///     The sdl controllertouchpaddown sdl eventtype
            /// </summary>
            SdlControllertouchpaddown, /* Requires >= 2.0.14 */

            /// <summary>
            ///     The sdl controllertouchpadmotion sdl eventtype
            /// </summary>
            SdlControllertouchpadmotion, /* Requires >= 2.0.14 */

            /// <summary>
            ///     The sdl controllertouchpadup sdl eventtype
            /// </summary>
            SdlControllertouchpadup, /* Requires >= 2.0.14 */

            /// <summary>
            ///     The sdl controllersensorupdate sdl eventtype
            /// </summary>
            SdlControllersensorupdate, /* Requires >= 2.0.14 */

            /* Touch events */
            /// <summary>
            ///     The sdl fingerdown sdl eventtype
            /// </summary>
            SdlFingerdown = 0x700,

            /// <summary>
            ///     The sdl fingerup sdl eventtype
            /// </summary>
            SdlFingerup,

            /// <summary>
            ///     The sdl fingermotion sdl eventtype
            /// </summary>
            SdlFingermotion,

            /* Gesture events */
            /// <summary>
            ///     The sdl dollargesture sdl eventtype
            /// </summary>
            SdlDollargesture = 0x800,

            /// <summary>
            ///     The sdl dollarrecord sdl eventtype
            /// </summary>
            SdlDollarrecord,

            /// <summary>
            ///     The sdl multigesture sdl eventtype
            /// </summary>
            SdlMultigesture,

            /* Clipboard events */
            /// <summary>
            ///     The sdl clipboardupdate sdl eventtype
            /// </summary>
            SdlClipboardupdate = 0x900,

            /* Drag and drop events */
            /// <summary>
            ///     The sdl dropfile sdl eventtype
            /// </summary>
            SdlDropfile = 0x1000,

            /* Only available in 2.0.4 or higher. */
            /// <summary>
            ///     The sdl droptext sdl eventtype
            /// </summary>
            SdlDroptext,

            /// <summary>
            ///     The sdl dropbegin sdl eventtype
            /// </summary>
            SdlDropbegin,

            /// <summary>
            ///     The sdl dropcomplete sdl eventtype
            /// </summary>
            SdlDropcomplete,

            /* Audio hotplug events */
            /* Only available in SDL 2.0.4 or higher. */
            /// <summary>
            ///     The sdl audiodeviceadded sdl eventtype
            /// </summary>
            SdlAudiodeviceadded = 0x1100,

            /// <summary>
            ///     The sdl audiodeviceremoved sdl eventtype
            /// </summary>
            SdlAudiodeviceremoved,

            /* Sensor events */
            /* Only available in SDL 2.0.9 or higher. */
            /// <summary>
            ///     The sdl sensorupdate sdl eventtype
            /// </summary>
            SdlSensorupdate = 0x1200,

            /* Render events */
            /* Only available in SDL 2.0.2 or higher. */
            /// <summary>
            ///     The sdl render targets reset sdl eventtype
            /// </summary>
            SdlRenderTargetsReset = 0x2000,

            /* Only available in SDL 2.0.4 or higher. */
            /// <summary>
            ///     The sdl render device reset sdl eventtype
            /// </summary>
            SdlRenderDeviceReset,

            /* Internal events */
            /* Only available in 2.0.18 or higher. */
            /// <summary>
            ///     The sdl pollsentinel sdl eventtype
            /// </summary>
            SdlPollsentinel = 0x7F00,

            /* Events SDL_USEREVENT through SDL_LASTEVENT are for
             * your use, and should be allocated with
             * SDL_RegisterEvents()
             */
            /// <summary>
            ///     The sdl userevent sdl eventtype
            /// </summary>
            SdlUserevent = 0x8000,

            /* The last event, used for bouding arrays. */
            /// <summary>
            ///     The sdl lastevent sdl eventtype
            /// </summary>
            SdlLastevent = 0xFFFF
        }

        /* Only available in 2.0.4 or higher. */
        /// <summary>
        ///     The sdl mousewheeldirection enum
        /// </summary>
        public enum SdlMouseWheelDirection : uint
        {
            /// <summary>
            ///     The sdl mousewheel normal sdl mousewheeldirection
            /// </summary>
            SdlMousewheelNormal,

            /// <summary>
            ///     The sdl mousewheel flipped sdl mousewheeldirection
            /// </summary>
            SdlMousewheelFlipped
        }

        /* Fields shared by every event */
        /// <summary>
        ///     The sdl genericevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlGenericEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public SdlEventType type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;
        }

// Ignore private members used for padding in this struct
#pragma warning disable 0169
        /// <summary>
        ///     The sdl displayevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlDisplayEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public SdlEventType type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The display
            /// </summary>
            public uint display;

            /// <summary>
            ///     The display event
            /// </summary>
            public SdlDisplayEventId displayEvent; // event, lolC#

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding1;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding2;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding3;

            /// <summary>
            ///     The data
            /// </summary>
            public int data1;
        }
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
        /* Window state change event data (event.window.*) */
        /// <summary>
        ///     The sdl windowevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlWindowEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public SdlEventType type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The window id
            /// </summary>
            public uint windowID;

            /// <summary>
            ///     The window event
            /// </summary>
            public SdlWindowEventId windowEvent; // event, lolC#

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding1;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding2;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding3;

            /// <summary>
            ///     The data
            /// </summary>
            public int data1;

            /// <summary>
            ///     The data
            /// </summary>
            public int data2;
        }
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
        /* Keyboard button event structure (event.key.*) */
        /// <summary>
        ///     The sdl keyboardevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlKeyboardEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public SdlEventType type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The window id
            /// </summary>
            public uint windowID;

            /// <summary>
            ///     The state
            /// </summary>
            public byte state;

            /// <summary>
            ///     The repeat
            /// </summary>
            public byte repeat; /* non-zero if this is a repeat */

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding2;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding3;

            /// <summary>
            ///     The keysym
            /// </summary>
            public SdlKeysym keysym;
        }
#pragma warning restore 0169

        /// <summary>
        ///     The sdl texteditingevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SdlTextEditingEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public SdlEventType type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The window id
            /// </summary>
            public uint windowID;

            /// <summary>
            ///     The sdl texteditingevent text size
            /// </summary>
            public fixed byte text[SdlTexteditingeventTextSize];

            /// <summary>
            ///     The start
            /// </summary>
            public int start;

            /// <summary>
            ///     The length
            /// </summary>
            public int length;
        }

        /// <summary>
        ///     The sdl textinputevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SdlTextInputEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public SdlEventType type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The window id
            /// </summary>
            public uint windowID;

            /// <summary>
            ///     The sdl textinputevent text size
            /// </summary>
            public fixed byte text[SdlTextinputeventTextSize];
        }

// Ignore private members used for padding in this struct
#pragma warning disable 0169
        /* Mouse motion event structure (event.motion.*) */
        /// <summary>
        ///     The sdl mousemotionevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlMouseMotionEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public SdlEventType type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The window id
            /// </summary>
            public uint windowID;

            /// <summary>
            ///     The which
            /// </summary>
            public uint which;

            /// <summary>
            ///     The state
            /// </summary>
            public byte state; /* bitmask of buttons */

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding1;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding2;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding3;

            /// <summary>
            ///     The
            /// </summary>
            public int x;

            /// <summary>
            ///     The
            /// </summary>
            public int y;

            /// <summary>
            ///     The xrel
            /// </summary>
            public int xrel;

            /// <summary>
            ///     The yrel
            /// </summary>
            public int yrel;
        }
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
        /* Mouse button event structure (event.button.*) */
        /// <summary>
        ///     The sdl mousebuttonevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlMouseButtonEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public SdlEventType type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The window id
            /// </summary>
            public uint windowID;

            /// <summary>
            ///     The which
            /// </summary>
            public uint which;

            /// <summary>
            ///     The button
            /// </summary>
            public byte button; /* button id */

            /// <summary>
            ///     The state
            /// </summary>
            public byte state; /* SDL_PRESSED or SDL_RELEASED */

            /// <summary>
            ///     The clicks
            /// </summary>
            public byte clicks; /* 1 for single-click, 2 for double-click, etc. */

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding1;

            /// <summary>
            ///     The
            /// </summary>
            public int x;

            /// <summary>
            ///     The
            /// </summary>
            public int y;
        }
#pragma warning restore 0169

        /* Mouse wheel event structure (event.wheel.*) */
        /// <summary>
        ///     The sdl mousewheelevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlMouseWheelEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public SdlEventType type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The window id
            /// </summary>
            public uint windowID;

            /// <summary>
            ///     The which
            /// </summary>
            public uint which;

            /// <summary>
            ///     The
            /// </summary>
            public int x; /* amount scrolled horizontally */

            /// <summary>
            ///     The
            /// </summary>
            public int y; /* amount scrolled vertically */

            /// <summary>
            ///     The direction
            /// </summary>
            public uint direction; /* Set to one of the SDL_MOUSEWHEEL_* defines */

            /// <summary>
            ///     The precise
            /// </summary>
            public float preciseX; /* Requires >= 2.0.18 */

            /// <summary>
            ///     The precise
            /// </summary>
            public float preciseY; /* Requires >= 2.0.18 */
        }

// Ignore private members used for padding in this struct
#pragma warning disable 0169
        /* Joystick axis motion event structure (event.jaxis.*) */
        /// <summary>
        ///     The sdl joyaxisevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlJoyAxisEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public SdlEventType type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The which
            /// </summary>
            public int which; /* SDL_JoystickID */

            /// <summary>
            ///     The axis
            /// </summary>
            public byte axis;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding1;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding2;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding3;

            /// <summary>
            ///     The axis value
            /// </summary>
            public short axisValue; /* value, lolC# */

            /// <summary>
            ///     The padding
            /// </summary>
            public ushort padding4;
        }
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
        /* Joystick trackball motion event structure (event.jball.*) */
        /// <summary>
        ///     The sdl joyballevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlJoyBallEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public SdlEventType type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The which
            /// </summary>
            public int which; /* SDL_JoystickID */

            /// <summary>
            ///     The ball
            /// </summary>
            public byte ball;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding1;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding2;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding3;

            /// <summary>
            ///     The xrel
            /// </summary>
            public short xrel;

            /// <summary>
            ///     The yrel
            /// </summary>
            public short yrel;
        }
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
        /* Joystick hat position change event struct (event.jhat.*) */
        /// <summary>
        ///     The sdl joyhatevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlJoyHatEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public SdlEventType type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The which
            /// </summary>
            public int which; /* SDL_JoystickID */

            /// <summary>
            ///     The hat
            /// </summary>
            public byte hat; /* index of the hat */

            /// <summary>
            ///     The hat value
            /// </summary>
            public byte hatValue; /* value, lolC# */

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding1;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding2;
        }
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
        /* Joystick button event structure (event.jbutton.*) */
        /// <summary>
        ///     The sdl joybuttonevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlJoyButtonEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public SdlEventType type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The which
            /// </summary>
            public int which; /* SDL_JoystickID */

            /// <summary>
            ///     The button
            /// </summary>
            public byte button;

            /// <summary>
            ///     The state
            /// </summary>
            public byte state; /* SDL_PRESSED or SDL_RELEASED */

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding1;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding2;
        }
#pragma warning restore 0169

        /* Joystick device event structure (event.jdevice.*) */
        /// <summary>
        ///     The sdl joydeviceevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlJoyDeviceEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public SdlEventType type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The which
            /// </summary>
            public int which; /* SDL_JoystickID */
        }

// Ignore private members used for padding in this struct
#pragma warning disable 0169
        /* Game controller axis motion event (event.caxis.*) */
        /// <summary>
        ///     The sdl controlleraxisevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlControllerAxisEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public SdlEventType type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The which
            /// </summary>
            public int which; /* SDL_JoystickID */

            /// <summary>
            ///     The axis
            /// </summary>
            public byte axis;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding1;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding2;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding3;

            /// <summary>
            ///     The axis value
            /// </summary>
            public short axisValue; /* value, lolC# */

            /// <summary>
            ///     The padding
            /// </summary>
            private ushort padding4;
        }
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
        /* Game controller button event (event.cbutton.*) */
        /// <summary>
        ///     The sdl controllerbuttonevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlControllerButtonEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public SdlEventType type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The which
            /// </summary>
            public int which; /* SDL_JoystickID */

            /// <summary>
            ///     The button
            /// </summary>
            public byte button;

            /// <summary>
            ///     The state
            /// </summary>
            public byte state;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding1;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding2;
        }
#pragma warning restore 0169

        /* Game controller device event (event.cdevice.*) */
        /// <summary>
        ///     The sdl controllerdeviceevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlControllerDeviceEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public SdlEventType type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The which
            /// </summary>
            public int which; /* joystick id for ADDED,
						 * else instance id
						 */
        }

        /* Game controller touchpad event structure (event.ctouchpad.*) */
        /// <summary>
        ///     The sdl controllertouchpadevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlControllerTouchpadEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public uint type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The which
            /// </summary>
            public int which; /* SDL_JoystickID */

            /// <summary>
            ///     The touchpad
            /// </summary>
            public int touchpad;

            /// <summary>
            ///     The finger
            /// </summary>
            public int finger;

            /// <summary>
            ///     The
            /// </summary>
            public float x;

            /// <summary>
            ///     The
            /// </summary>
            public float y;

            /// <summary>
            ///     The pressure
            /// </summary>
            public float pressure;
        }

        /* Game controller sensor event structure (event.csensor.*) */
        /// <summary>
        ///     The sdl controllersensorevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlControllerSensorEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public uint type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The which
            /// </summary>
            public int which; /* SDL_JoystickID */

            /// <summary>
            ///     The sensor
            /// </summary>
            public int sensor;

            /// <summary>
            ///     The data
            /// </summary>
            public float data1;

            /// <summary>
            ///     The data
            /// </summary>
            public float data2;

            /// <summary>
            ///     The data
            /// </summary>
            public float data3;
        }

// Ignore private members used for padding in this struct
#pragma warning disable 0169
        /* Audio device event (event.adevice.*) */
        /// <summary>
        ///     The sdl audiodeviceevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlAudioDeviceEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public uint type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The which
            /// </summary>
            public uint which;

            /// <summary>
            ///     The iscapture
            /// </summary>
            public byte iscapture;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding1;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding2;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding3;
        }
#pragma warning restore 0169

        /// <summary>
        ///     The sdl touchfingerevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlTouchFingerEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public uint type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The touch id
            /// </summary>
            public long touchId; // SDL_TouchID

            /// <summary>
            ///     The finger id
            /// </summary>
            public long fingerId; // SDL_GestureID

            /// <summary>
            ///     The
            /// </summary>
            public float x;

            /// <summary>
            ///     The
            /// </summary>
            public float y;

            /// <summary>
            ///     The dx
            /// </summary>
            public float dx;

            /// <summary>
            ///     The dy
            /// </summary>
            public float dy;

            /// <summary>
            ///     The pressure
            /// </summary>
            public float pressure;

            /// <summary>
            ///     The window id
            /// </summary>
            public uint windowID;
        }

        /// <summary>
        ///     The sdl multigestureevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlMultiGestureEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public uint type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The touch id
            /// </summary>
            public long touchId; // SDL_TouchID

            /// <summary>
            ///     The theta
            /// </summary>
            public float dTheta;

            /// <summary>
            ///     The dist
            /// </summary>
            public float dDist;

            /// <summary>
            ///     The
            /// </summary>
            public float x;

            /// <summary>
            ///     The
            /// </summary>
            public float y;

            /// <summary>
            ///     The num fingers
            /// </summary>
            public ushort numFingers;

            /// <summary>
            ///     The padding
            /// </summary>
            public ushort padding;
        }

        /// <summary>
        ///     The sdl dollargestureevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlDollarGestureEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public uint type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The touch id
            /// </summary>
            public long touchId; // SDL_TouchID

            /// <summary>
            ///     The gesture id
            /// </summary>
            public long gestureId; // SDL_GestureID

            /// <summary>
            ///     The num fingers
            /// </summary>
            public uint numFingers;

            /// <summary>
            ///     The error
            /// </summary>
            public float error;

            /// <summary>
            ///     The
            /// </summary>
            public float x;

            /// <summary>
            ///     The
            /// </summary>
            public float y;
        }

        /* File open request by system (event.drop.*), enabled by
         * default
         */
        /// <summary>
        ///     The sdl dropevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlDropEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public SdlEventType type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /* char* filename, to be freed.
             * Access the variable EXACTLY ONCE like this:
             * string s = SDL.UTF8_ToManaged(evt.drop.file, true);
             */
            /// <summary>
            ///     The file
            /// </summary>
            public IntPtr file;

            /// <summary>
            ///     The window id
            /// </summary>
            public uint windowID;
        }

        /// <summary>
        ///     The sdl sensorevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SdlSensorEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public SdlEventType type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The which
            /// </summary>
            public int which;

            /// <summary>
            ///     The data
            /// </summary>
            public fixed float data[6];
        }

        /* The "quit requested" event */
        /// <summary>
        ///     The sdl quitevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlQuitEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public SdlEventType type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;
        }

        /* A user defined event (event.user.*) */
        /// <summary>
        ///     The sdl userevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlUserEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public uint type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The window id
            /// </summary>
            public uint windowID;

            /// <summary>
            ///     The code
            /// </summary>
            public int code;

            /// <summary>
            ///     The data
            /// </summary>
            public IntPtr data1; /* user-defined */

            /// <summary>
            ///     The data
            /// </summary>
            public IntPtr data2; /* user-defined */
        }

        /* A video driver dependent event (event.syswm.*), disabled */
        /// <summary>
        ///     The sdl syswmevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlSysWmEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public SdlEventType type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The msg
            /// </summary>
            public IntPtr msg; /* SDL_SysWMmsg*, system-dependent*/
        }

        /* General event structure */
        // C# doesn't do unions, so we do this ugly thing. */
        /// <summary>
        ///     The sdl event
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public unsafe struct SdlEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            [FieldOffset(0)] public SdlEventType type;

            /// <summary>
            ///     The type sharp
            /// </summary>
            [FieldOffset(0)] public SdlEventType typeFSharp;

            /// <summary>
            ///     The display
            /// </summary>
            [FieldOffset(0)] public SdlDisplayEvent display;

            /// <summary>
            ///     The window
            /// </summary>
            [FieldOffset(0)] public SdlWindowEvent window;

            /// <summary>
            ///     The key
            /// </summary>
            [FieldOffset(0)] public SdlKeyboardEvent key;

            /// <summary>
            ///     The edit
            /// </summary>
            [FieldOffset(0)] public SdlTextEditingEvent edit;

            /// <summary>
            ///     The text
            /// </summary>
            [FieldOffset(0)] public SdlTextInputEvent text;

            /// <summary>
            ///     The motion
            /// </summary>
            [FieldOffset(0)] public SdlMouseMotionEvent motion;

            /// <summary>
            ///     The button
            /// </summary>
            [FieldOffset(0)] public SdlMouseButtonEvent button;

            /// <summary>
            ///     The wheel
            /// </summary>
            [FieldOffset(0)] public SdlMouseWheelEvent wheel;

            /// <summary>
            ///     The jaxis
            /// </summary>
            [FieldOffset(0)] public SdlJoyAxisEvent jaxis;

            /// <summary>
            ///     The jball
            /// </summary>
            [FieldOffset(0)] public SdlJoyBallEvent jball;

            /// <summary>
            ///     The jhat
            /// </summary>
            [FieldOffset(0)] public SdlJoyHatEvent jhat;

            /// <summary>
            ///     The jbutton
            /// </summary>
            [FieldOffset(0)] public SdlJoyButtonEvent jbutton;

            /// <summary>
            ///     The jdevice
            /// </summary>
            [FieldOffset(0)] public SdlJoyDeviceEvent jdevice;

            /// <summary>
            ///     The caxis
            /// </summary>
            [FieldOffset(0)] public SdlControllerAxisEvent caxis;

            /// <summary>
            ///     The cbutton
            /// </summary>
            [FieldOffset(0)] public SdlControllerButtonEvent cbutton;

            /// <summary>
            ///     The cdevice
            /// </summary>
            [FieldOffset(0)] public SdlControllerDeviceEvent cdevice;

            /// <summary>
            ///     The ctouchpad
            /// </summary>
            [FieldOffset(0)] public SdlControllerTouchpadEvent ctouchpad;

            /// <summary>
            ///     The csensor
            /// </summary>
            [FieldOffset(0)] public SdlControllerSensorEvent csensor;

            /// <summary>
            ///     The adevice
            /// </summary>
            [FieldOffset(0)] public SdlAudioDeviceEvent adevice;

            /// <summary>
            ///     The sensor
            /// </summary>
            [FieldOffset(0)] public SdlSensorEvent sensor;

            /// <summary>
            ///     The quit
            /// </summary>
            [FieldOffset(0)] public SdlQuitEvent quit;

            /// <summary>
            ///     The user
            /// </summary>
            [FieldOffset(0)] public SdlUserEvent user;

            /// <summary>
            ///     The syswm
            /// </summary>
            [FieldOffset(0)] public SdlSysWmEvent syswm;

            /// <summary>
            ///     The tfinger
            /// </summary>
            [FieldOffset(0)] public SdlTouchFingerEvent tfinger;

            /// <summary>
            ///     The mgesture
            /// </summary>
            [FieldOffset(0)] public SdlMultiGestureEvent mgesture;

            /// <summary>
            ///     The dgesture
            /// </summary>
            [FieldOffset(0)] public SdlDollarGestureEvent dgesture;

            /// <summary>
            ///     The drop
            /// </summary>
            [FieldOffset(0)] public SdlDropEvent drop;

            /// <summary>
            ///     The padding
            /// </summary>
            [FieldOffset(0)] private fixed byte padding[56];
        }

        /// <summary>
        ///     The sdl eventfilter
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int SdlEventFilter(
            IntPtr userdata, // void*
            IntPtr sdlevent // SDL_Event* event, lolC#
        );

        /* Pump the event loop, getting events from the input devices*/
        /// <summary>
        ///     Sdls the pump events
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_PumpEvents();

        /// <summary>
        ///     The sdl eventaction enum
        /// </summary>
        public enum SdlEventaction
        {
            /// <summary>
            ///     The sdl addevent sdl eventaction
            /// </summary>
            SdlAddevent,

            /// <summary>
            ///     The sdl peekevent sdl eventaction
            /// </summary>
            SdlPeekevent,

            /// <summary>
            ///     The sdl getevent sdl eventaction
            /// </summary>
            SdlGetevent
        }

        /// <summary>
        ///     Sdls the peep events using the specified events
        /// </summary>
        /// <param name="events">The events</param>
        /// <param name="numevents">The numevents</param>
        /// <param name="action">The action</param>
        /// <param name="minType">The min type</param>
        /// <param name="maxType">The max type</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_PeepEvents(
            [Out] SdlEvent[] events,
            int numevents,
            SdlEventaction action,
            SdlEventType minType,
            SdlEventType maxType
        );

        /* Checks to see if certain events are in the event queue */
        /// <summary>
        ///     Sdls the has event using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasEvent(SdlEventType type);

        /// <summary>
        ///     Sdls the has events using the specified min type
        /// </summary>
        /// <param name="minType">The min type</param>
        /// <param name="maxType">The max type</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasEvents(
            SdlEventType minType,
            SdlEventType maxType
        );

        /* Clears events from the event queue */
        /// <summary>
        ///     Sdls the flush event using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FlushEvent(SdlEventType type);

        /// <summary>
        ///     Sdls the flush events using the specified min
        /// </summary>
        /// <param name="min">The min</param>
        /// <param name="max">The max</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FlushEvents(
            SdlEventType min,
            SdlEventType max
        );

        /* Polls for currently pending events */
        /// <summary>
        ///     Sdls the poll event using the specified  event
        /// </summary>
        /// <param name="event">The event</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_PollEvent(out SdlEvent @event);

        /* Waits indefinitely for the next event */
        /// <summary>
        ///     Sdls the wait event using the specified  event
        /// </summary>
        /// <param name="event">The event</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_WaitEvent(out SdlEvent @event);

        /* Waits until the specified timeout (in ms) for the next event
         */
        /// <summary>
        ///     Sdls the wait event timeout using the specified  event
        /// </summary>
        /// <param name="event">The event</param>
        /// <param name="timeout">The timeout</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_WaitEventTimeout(out SdlEvent @event, int timeout);

        /* Add an event to the event queue */
        /// <summary>
        ///     Sdls the push event using the specified  event
        /// </summary>
        /// <param name="event">The event</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_PushEvent(ref SdlEvent @event);

        /* userdata refers to a void* */
        /// <summary>
        ///     Sdls the set event filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetEventFilter(
            SdlEventFilter filter,
            IntPtr userdata
        );

        /* userdata refers to a void* */
        /// <summary>
        ///     Sdls the get event filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern SdlBool SDL_GetEventFilter(
            out IntPtr filter,
            out IntPtr userdata
        );

        /// <summary>
        ///     Sdls the get event filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The retval</returns>
        public static SdlBool SDL_GetEventFilter(
            out SdlEventFilter filter,
            out IntPtr userdata
        )
        {
            IntPtr result = IntPtr.Zero;
            SdlBool retval = SDL_GetEventFilter(out result, out userdata);
            if (result != IntPtr.Zero)
            {
                filter = (SdlEventFilter) Marshal.GetDelegateForFunctionPointer(
                    result,
                    typeof(SdlEventFilter)
                );
            }
            else
            {
                filter = null;
            }

            return retval;
        }

        /* userdata refers to a void* */
        /// <summary>
        ///     Sdls the add event watch using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_AddEventWatch(
            SdlEventFilter filter,
            IntPtr userdata
        );

        /* userdata refers to a void* */
        /// <summary>
        ///     Sdls the del event watch using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DelEventWatch(
            SdlEventFilter filter,
            IntPtr userdata
        );

        /* userdata refers to a void* */
        /// <summary>
        ///     Sdls the filter events using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FilterEvents(
            SdlEventFilter filter,
            IntPtr userdata
        );

        /* These are for SDL_EventState() */
        /// <summary>
        ///     The sdl query
        /// </summary>
        public const int SdlQuery = -1;

        /// <summary>
        ///     The sdl ignore
        /// </summary>
        public const int SdlIgnore = 0;

        /// <summary>
        ///     The sdl disable
        /// </summary>
        public const int SdlDisable = 0;

        /// <summary>
        ///     The sdl enable
        /// </summary>
        public const int SdlEnable = 1;

        /* This function allows you to enable/disable certain events */
        /// <summary>
        ///     Sdls the event state using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="state">The state</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_EventState(SdlEventType type, int state);

        /* Get the state of an event */
        /// <summary>
        ///     Sdls the get event state using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The byte</returns>
        public static byte SDL_GetEventState(SdlEventType type) => SDL_EventState(type, SdlQuery);

        /* Allocate a set of user-defined events */
        /// <summary>
        ///     Sdls the register events using the specified numevents
        /// </summary>
        /// <param name="numevents">The numevents</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_RegisterEvents(int numevents);

        #endregion

        #region SDL_keycode.h

        /// <summary>
        ///     The sdlk scancode mask
        /// </summary>
        public const int SdlkScancodeMask = 1 << 30;

        /// <summary>
        ///     Sdls the scancode to keycode using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The sdl keycode</returns>
        public static SdlKeycode SDL_SCANCODE_TO_KEYCODE(SdlScancode x) => (SdlKeycode) ((int) x | SdlkScancodeMask);

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
            SdlkCapslock = SdlScancode.SdlScancodeCapslock | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk f1 sdl keycode
            /// </summary>
            SdlkF1 = SdlScancode.SdlScancodeF1 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk f2 sdl keycode
            /// </summary>
            SdlkF2 = SdlScancode.SdlScancodeF2 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk f3 sdl keycode
            /// </summary>
            SdlkF3 = SdlScancode.SdlScancodeF3 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk f4 sdl keycode
            /// </summary>
            SdlkF4 = SdlScancode.SdlScancodeF4 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk f5 sdl keycode
            /// </summary>
            SdlkF5 = SdlScancode.SdlScancodeF5 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk f6 sdl keycode
            /// </summary>
            SdlkF6 = SdlScancode.SdlScancodeF6 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk f7 sdl keycode
            /// </summary>
            SdlkF7 = SdlScancode.SdlScancodeF7 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk f8 sdl keycode
            /// </summary>
            SdlkF8 = SdlScancode.SdlScancodeF8 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk f9 sdl keycode
            /// </summary>
            SdlkF9 = SdlScancode.SdlScancodeF9 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk f10 sdl keycode
            /// </summary>
            SdlkF10 = SdlScancode.SdlScancodeF10 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk f11 sdl keycode
            /// </summary>
            SdlkF11 = SdlScancode.SdlScancodeF11 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk f12 sdl keycode
            /// </summary>
            SdlkF12 = SdlScancode.SdlScancodeF12 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk printscreen sdl keycode
            /// </summary>
            SdlkPrintscreen = SdlScancode.SdlScancodePrintscreen | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk scrolllock sdl keycode
            /// </summary>
            SdlkScrolllock = SdlScancode.SdlScancodeScrolllock | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk pause sdl keycode
            /// </summary>
            SdlkPause = SdlScancode.SdlScancodePause | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk insert sdl keycode
            /// </summary>
            SdlkInsert = SdlScancode.SdlScancodeInsert | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk home sdl keycode
            /// </summary>
            SdlkHome = SdlScancode.SdlScancodeHome | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk pageup sdl keycode
            /// </summary>
            SdlkPageup = SdlScancode.SdlScancodePageup | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk delete sdl keycode
            /// </summary>
            SdlkDelete = 127,

            /// <summary>
            ///     The sdlk end sdl keycode
            /// </summary>
            SdlkEnd = SdlScancode.SdlScancodeEnd | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk pagedown sdl keycode
            /// </summary>
            SdlkPagedown = SdlScancode.SdlScancodePagedown | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk right sdl keycode
            /// </summary>
            SdlkRight = SdlScancode.SdlScancodeRight | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk left sdl keycode
            /// </summary>
            SdlkLeft = SdlScancode.SdlScancodeLeft | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk down sdl keycode
            /// </summary>
            SdlkDown = SdlScancode.SdlScancodeDown | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk up sdl keycode
            /// </summary>
            SdlkUp = SdlScancode.SdlScancodeUp | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk numlockclear sdl keycode
            /// </summary>
            SdlkNumlockclear = SdlScancode.SdlScancodeNumlockclear | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp divide sdl keycode
            /// </summary>
            SdlkKpDivide = SdlScancode.SdlScancodeKpDivide | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp multiply sdl keycode
            /// </summary>
            SdlkKpMultiply = SdlScancode.SdlScancodeKpMultiply | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp minus sdl keycode
            /// </summary>
            SdlkKpMinus = SdlScancode.SdlScancodeKpMinus | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp plus sdl keycode
            /// </summary>
            SdlkKpPlus = SdlScancode.SdlScancodeKpPlus | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp enter sdl keycode
            /// </summary>
            SdlkKpEnter = SdlScancode.SdlScancodeKpEnter | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp sdl keycode
            /// </summary>
            SdlkKp1 = SdlScancode.SdlScancodeKp1 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp sdl keycode
            /// </summary>
            SdlkKp2 = SdlScancode.SdlScancodeKp2 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp sdl keycode
            /// </summary>
            SdlkKp3 = SdlScancode.SdlScancodeKp3 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp sdl keycode
            /// </summary>
            SdlkKp4 = SdlScancode.SdlScancodeKp4 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp sdl keycode
            /// </summary>
            SdlkKp5 = SdlScancode.SdlScancodeKp5 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp sdl keycode
            /// </summary>
            SdlkKp6 = SdlScancode.SdlScancodeKp6 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp sdl keycode
            /// </summary>
            SdlkKp7 = SdlScancode.SdlScancodeKp7 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp sdl keycode
            /// </summary>
            SdlkKp8 = SdlScancode.SdlScancodeKp8 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp sdl keycode
            /// </summary>
            SdlkKp9 = SdlScancode.SdlScancodeKp9 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp sdl keycode
            /// </summary>
            SdlkKp0 = SdlScancode.SdlScancodeKp0 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp period sdl keycode
            /// </summary>
            SdlkKpPeriod = SdlScancode.SdlScancodeKpPeriod | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk application sdl keycode
            /// </summary>
            SdlkApplication = SdlScancode.SdlScancodeApplication | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk power sdl keycode
            /// </summary>
            SdlkPower = SdlScancode.SdlScancodePower | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp equals sdl keycode
            /// </summary>
            SdlkKpEquals = SdlScancode.SdlScancodeKpEquals | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk f13 sdl keycode
            /// </summary>
            SdlkF13 = SdlScancode.SdlScancodeF13 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk f14 sdl keycode
            /// </summary>
            SdlkF14 = SdlScancode.SdlScancodeF14 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk f15 sdl keycode
            /// </summary>
            SdlkF15 = SdlScancode.SdlScancodeF15 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk f16 sdl keycode
            /// </summary>
            SdlkF16 = SdlScancode.SdlScancodeF16 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk f17 sdl keycode
            /// </summary>
            SdlkF17 = SdlScancode.SdlScancodeF17 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk f18 sdl keycode
            /// </summary>
            SdlkF18 = SdlScancode.SdlScancodeF18 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk f19 sdl keycode
            /// </summary>
            SdlkF19 = SdlScancode.SdlScancodeF19 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk f20 sdl keycode
            /// </summary>
            SdlkF20 = SdlScancode.SdlScancodeF20 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk f21 sdl keycode
            /// </summary>
            SdlkF21 = SdlScancode.SdlScancodeF21 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk f22 sdl keycode
            /// </summary>
            SdlkF22 = SdlScancode.SdlScancodeF22 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk f23 sdl keycode
            /// </summary>
            SdlkF23 = SdlScancode.SdlScancodeF23 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk f24 sdl keycode
            /// </summary>
            SdlkF24 = SdlScancode.SdlScancodeF24 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk execute sdl keycode
            /// </summary>
            SdlkExecute = SdlScancode.SdlScancodeExecute | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk help sdl keycode
            /// </summary>
            SdlkHelp = SdlScancode.SdlScancodeHelp | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk menu sdl keycode
            /// </summary>
            SdlkMenu = SdlScancode.SdlScancodeMenu | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk select sdl keycode
            /// </summary>
            SdlkSelect = SdlScancode.SdlScancodeSelect | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk stop sdl keycode
            /// </summary>
            SdlkStop = SdlScancode.SdlScancodeStop | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk again sdl keycode
            /// </summary>
            SdlkAgain = SdlScancode.SdlScancodeAgain | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk undo sdl keycode
            /// </summary>
            SdlkUndo = SdlScancode.SdlScancodeUndo | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk cut sdl keycode
            /// </summary>
            SdlkCut = SdlScancode.SdlScancodeCut | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk copy sdl keycode
            /// </summary>
            SdlkCopy = SdlScancode.SdlScancodeCopy | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk paste sdl keycode
            /// </summary>
            SdlkPaste = SdlScancode.SdlScancodePaste | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk find sdl keycode
            /// </summary>
            SdlkFind = SdlScancode.SdlScancodeFind | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk mute sdl keycode
            /// </summary>
            SdlkMute = SdlScancode.SdlScancodeMute | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk volumeup sdl keycode
            /// </summary>
            SdlkVolumeup = SdlScancode.SdlScancodeVolumeup | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk volumedown sdl keycode
            /// </summary>
            SdlkVolumedown = SdlScancode.SdlScancodeVolumedown | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp comma sdl keycode
            /// </summary>
            SdlkKpComma = SdlScancode.SdlScancodeKpComma | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp equalsas400 sdl keycode
            /// </summary>
            SdlkKpEqualsas400 =
                SdlScancode.SdlScancodeKpEqualsas400 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk alterase sdl keycode
            /// </summary>
            SdlkAlterase = SdlScancode.SdlScancodeAlterase | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk sysreq sdl keycode
            /// </summary>
            SdlkSysreq = SdlScancode.SdlScancodeSysreq | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk cancel sdl keycode
            /// </summary>
            SdlkCancel = SdlScancode.SdlScancodeCancel | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk clear sdl keycode
            /// </summary>
            SdlkClear = SdlScancode.SdlScancodeClear | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk prior sdl keycode
            /// </summary>
            SdlkPrior = SdlScancode.SdlScancodePrior | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk return2 sdl keycode
            /// </summary>
            SdlkReturn2 = SdlScancode.SdlScancodeReturn2 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk separator sdl keycode
            /// </summary>
            SdlkSeparator = SdlScancode.SdlScancodeSeparator | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk out sdl keycode
            /// </summary>
            SdlkOut = SdlScancode.SdlScancodeOut | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk oper sdl keycode
            /// </summary>
            SdlkOper = SdlScancode.SdlScancodeOper | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk clearagain sdl keycode
            /// </summary>
            SdlkClearagain = SdlScancode.SdlScancodeClearagain | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk crsel sdl keycode
            /// </summary>
            SdlkCrsel = SdlScancode.SdlScancodeCrsel | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk exsel sdl keycode
            /// </summary>
            SdlkExsel = SdlScancode.SdlScancodeExsel | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp 00 sdl keycode
            /// </summary>
            SdlkKp00 = SdlScancode.SdlScancodeKp00 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp 000 sdl keycode
            /// </summary>
            SdlkKp000 = SdlScancode.SdlScancodeKp000 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk thousandsseparator sdl keycode
            /// </summary>
            SdlkThousandsseparator =
                SdlScancode.SdlScancodeThousandsseparator | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk decimalseparator sdl keycode
            /// </summary>
            SdlkDecimalseparator =
                SdlScancode.SdlScancodeDecimalseparator | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk currencyunit sdl keycode
            /// </summary>
            SdlkCurrencyunit = SdlScancode.SdlScancodeCurrencyunit | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk currencysubunit sdl keycode
            /// </summary>
            SdlkCurrencysubunit =
                SdlScancode.SdlScancodeCurrencysubunit | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp leftparen sdl keycode
            /// </summary>
            SdlkKpLeftparen = SdlScancode.SdlScancodeKpLeftparen | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp rightparen sdl keycode
            /// </summary>
            SdlkKpRightparen = SdlScancode.SdlScancodeKpRightparen | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp leftbrace sdl keycode
            /// </summary>
            SdlkKpLeftbrace = SdlScancode.SdlScancodeKpLeftbrace | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp rightbrace sdl keycode
            /// </summary>
            SdlkKpRightbrace = SdlScancode.SdlScancodeKpRightbrace | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp tab sdl keycode
            /// </summary>
            SdlkKpTab = SdlScancode.SdlScancodeKpTab | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp backspace sdl keycode
            /// </summary>
            SdlkKpBackspace = SdlScancode.SdlScancodeKpBackspace | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp sdl keycode
            /// </summary>
            SdlkKpA = SdlScancode.SdlScancodeKpA | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp sdl keycode
            /// </summary>
            SdlkKpB = SdlScancode.SdlScancodeKpB | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp sdl keycode
            /// </summary>
            SdlkKpC = SdlScancode.SdlScancodeKpC | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp sdl keycode
            /// </summary>
            SdlkKpD = SdlScancode.SdlScancodeKpD | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp sdl keycode
            /// </summary>
            SdlkKpE = SdlScancode.SdlScancodeKpE | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp sdl keycode
            /// </summary>
            SdlkKpF = SdlScancode.SdlScancodeKpF | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp xor sdl keycode
            /// </summary>
            SdlkKpXor = SdlScancode.SdlScancodeKpXor | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp power sdl keycode
            /// </summary>
            SdlkKpPower = SdlScancode.SdlScancodeKpPower | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp percent sdl keycode
            /// </summary>
            SdlkKpPercent = SdlScancode.SdlScancodeKpPercent | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp less sdl keycode
            /// </summary>
            SdlkKpLess = SdlScancode.SdlScancodeKpLess | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp greater sdl keycode
            /// </summary>
            SdlkKpGreater = SdlScancode.SdlScancodeKpGreater | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp ampersand sdl keycode
            /// </summary>
            SdlkKpAmpersand = SdlScancode.SdlScancodeKpAmpersand | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp dblampersand sdl keycode
            /// </summary>
            SdlkKpDblampersand =
                SdlScancode.SdlScancodeKpDblampersand | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp verticalbar sdl keycode
            /// </summary>
            SdlkKpVerticalbar =
                SdlScancode.SdlScancodeKpVerticalbar | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp dblverticalbar sdl keycode
            /// </summary>
            SdlkKpDblverticalbar =
                SdlScancode.SdlScancodeKpDblverticalbar | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp colon sdl keycode
            /// </summary>
            SdlkKpColon = SdlScancode.SdlScancodeKpColon | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp hash sdl keycode
            /// </summary>
            SdlkKpHash = SdlScancode.SdlScancodeKpHash | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp space sdl keycode
            /// </summary>
            SdlkKpSpace = SdlScancode.SdlScancodeKpSpace | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp at sdl keycode
            /// </summary>
            SdlkKpAt = SdlScancode.SdlScancodeKpAt | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp exclam sdl keycode
            /// </summary>
            SdlkKpExclam = SdlScancode.SdlScancodeKpExclam | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp memstore sdl keycode
            /// </summary>
            SdlkKpMemstore = SdlScancode.SdlScancodeKpMemstore | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp memrecall sdl keycode
            /// </summary>
            SdlkKpMemrecall = SdlScancode.SdlScancodeKpMemrecall | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp memclear sdl keycode
            /// </summary>
            SdlkKpMemclear = SdlScancode.SdlScancodeKpMemclear | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp memadd sdl keycode
            /// </summary>
            SdlkKpMemadd = SdlScancode.SdlScancodeKpMemadd | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp memsubtract sdl keycode
            /// </summary>
            SdlkKpMemsubtract =
                SdlScancode.SdlScancodeKpMemsubtract | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp memmultiply sdl keycode
            /// </summary>
            SdlkKpMemmultiply =
                SdlScancode.SdlScancodeKpMemmultiply | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp memdivide sdl keycode
            /// </summary>
            SdlkKpMemdivide = SdlScancode.SdlScancodeKpMemdivide | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp plusminus sdl keycode
            /// </summary>
            SdlkKpPlusminus = SdlScancode.SdlScancodeKpPlusminus | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp clear sdl keycode
            /// </summary>
            SdlkKpClear = SdlScancode.SdlScancodeKpClear | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp clearentry sdl keycode
            /// </summary>
            SdlkKpClearentry = SdlScancode.SdlScancodeKpClearentry | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp binary sdl keycode
            /// </summary>
            SdlkKpBinary = SdlScancode.SdlScancodeKpBinary | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp octal sdl keycode
            /// </summary>
            SdlkKpOctal = SdlScancode.SdlScancodeKpOctal | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp decimal sdl keycode
            /// </summary>
            SdlkKpDecimal = SdlScancode.SdlScancodeKpDecimal | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kp hexadecimal sdl keycode
            /// </summary>
            SdlkKpHexadecimal =
                SdlScancode.SdlScancodeKpHexadecimal | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk lctrl sdl keycode
            /// </summary>
            SdlkLctrl = SdlScancode.SdlScancodeLctrl | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk lshift sdl keycode
            /// </summary>
            SdlkLshift = SdlScancode.SdlScancodeLshift | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk lalt sdl keycode
            /// </summary>
            SdlkLalt = SdlScancode.SdlScancodeLalt | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk lgui sdl keycode
            /// </summary>
            SdlkLgui = SdlScancode.SdlScancodeLgui | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk rctrl sdl keycode
            /// </summary>
            SdlkRctrl = SdlScancode.SdlScancodeRctrl | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk rshift sdl keycode
            /// </summary>
            SdlkRshift = SdlScancode.SdlScancodeRshift | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk ralt sdl keycode
            /// </summary>
            SdlkRalt = SdlScancode.SdlScancodeRalt | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk rgui sdl keycode
            /// </summary>
            SdlkRgui = SdlScancode.SdlScancodeRgui | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk mode sdl keycode
            /// </summary>
            SdlkMode = SdlScancode.SdlScancodeMode | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk audionext sdl keycode
            /// </summary>
            SdlkAudionext = SdlScancode.SdlScancodeAudionext | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk audioprev sdl keycode
            /// </summary>
            SdlkAudioprev = SdlScancode.SdlScancodeAudioprev | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk audiostop sdl keycode
            /// </summary>
            SdlkAudiostop = SdlScancode.SdlScancodeAudiostop | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk audioplay sdl keycode
            /// </summary>
            SdlkAudioplay = SdlScancode.SdlScancodeAudioplay | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk audiomute sdl keycode
            /// </summary>
            SdlkAudiomute = SdlScancode.SdlScancodeAudiomute | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk mediaselect sdl keycode
            /// </summary>
            SdlkMediaselect = SdlScancode.SdlScancodeMediaselect | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk www sdl keycode
            /// </summary>
            SdlkWww = SdlScancode.SdlScancodeWww | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk mail sdl keycode
            /// </summary>
            SdlkMail = SdlScancode.SdlScancodeMail | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk calculator sdl keycode
            /// </summary>
            SdlkCalculator = SdlScancode.SdlScancodeCalculator | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk computer sdl keycode
            /// </summary>
            SdlkComputer = SdlScancode.SdlScancodeComputer | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk ac search sdl keycode
            /// </summary>
            SdlkAcSearch = SdlScancode.SdlScancodeAcSearch | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk ac home sdl keycode
            /// </summary>
            SdlkAcHome = SdlScancode.SdlScancodeAcHome | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk ac back sdl keycode
            /// </summary>
            SdlkAcBack = SdlScancode.SdlScancodeAcBack | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk ac forward sdl keycode
            /// </summary>
            SdlkAcForward = SdlScancode.SdlScancodeAcForward | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk ac stop sdl keycode
            /// </summary>
            SdlkAcStop = SdlScancode.SdlScancodeAcStop | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk ac refresh sdl keycode
            /// </summary>
            SdlkAcRefresh = SdlScancode.SdlScancodeAcRefresh | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk ac bookmarks sdl keycode
            /// </summary>
            SdlkAcBookmarks = SdlScancode.SdlScancodeAcBookmarks | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk brightnessdown sdl keycode
            /// </summary>
            SdlkBrightnessdown =
                SdlScancode.SdlScancodeBrightnessdown | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk brightnessup sdl keycode
            /// </summary>
            SdlkBrightnessup = SdlScancode.SdlScancodeBrightnessup | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk displayswitch sdl keycode
            /// </summary>
            SdlkDisplayswitch = SdlScancode.SdlScancodeDisplayswitch | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kbdillumtoggle sdl keycode
            /// </summary>
            SdlkKbdillumtoggle =
                SdlScancode.SdlScancodeKbdillumtoggle | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kbdillumdown sdl keycode
            /// </summary>
            SdlkKbdillumdown = SdlScancode.SdlScancodeKbdillumdown | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk kbdillumup sdl keycode
            /// </summary>
            SdlkKbdillumup = SdlScancode.SdlScancodeKbdillumup | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk eject sdl keycode
            /// </summary>
            SdlkEject = SdlScancode.SdlScancodeEject | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk sleep sdl keycode
            /// </summary>
            SdlkSleep = SdlScancode.SdlScancodeSleep | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk app1 sdl keycode
            /// </summary>
            SdlkApp1 = SdlScancode.SdlScancodeApp1 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk app2 sdl keycode
            /// </summary>
            SdlkApp2 = SdlScancode.SdlScancodeApp2 | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk audiorewind sdl keycode
            /// </summary>
            SdlkAudiorewind = SdlScancode.SdlScancodeAudiorewind | SdlkScancodeMask,

            /// <summary>
            ///     The sdlk audiofastforward sdl keycode
            /// </summary>
            SdlkAudiofastforward = SdlScancode.SdlScancodeAudiofastforward | SdlkScancodeMask
        }

        /* Key modifiers (bitfield) */
        /// <summary>
        ///     The sdl keymod enum
        /// </summary>
        [Flags]
        public enum SdlKeymod : ushort
        {
            /// <summary>
            ///     The kmod none sdl keymod
            /// </summary>
            KmodNone = 0x0000,

            /// <summary>
            ///     The kmod lshift sdl keymod
            /// </summary>
            KmodLshift = 0x0001,

            /// <summary>
            ///     The kmod rshift sdl keymod
            /// </summary>
            KmodRshift = 0x0002,

            /// <summary>
            ///     The kmod lctrl sdl keymod
            /// </summary>
            KmodLctrl = 0x0040,

            /// <summary>
            ///     The kmod rctrl sdl keymod
            /// </summary>
            KmodRctrl = 0x0080,

            /// <summary>
            ///     The kmod lalt sdl keymod
            /// </summary>
            KmodLalt = 0x0100,

            /// <summary>
            ///     The kmod ralt sdl keymod
            /// </summary>
            KmodRalt = 0x0200,

            /// <summary>
            ///     The kmod lgui sdl keymod
            /// </summary>
            KmodLgui = 0x0400,

            /// <summary>
            ///     The kmod rgui sdl keymod
            /// </summary>
            KmodRgui = 0x0800,

            /// <summary>
            ///     The kmod num sdl keymod
            /// </summary>
            KmodNum = 0x1000,

            /// <summary>
            ///     The kmod caps sdl keymod
            /// </summary>
            KmodCaps = 0x2000,

            /// <summary>
            ///     The kmod mode sdl keymod
            /// </summary>
            KmodMode = 0x4000,

            /// <summary>
            ///     The kmod scroll sdl keymod
            /// </summary>
            KmodScroll = 0x8000,

            /* These are defines in the SDL headers */
            /// <summary>
            ///     The kmod ctrl sdl keymod
            /// </summary>
            KmodCtrl = KmodLctrl | KmodRctrl,

            /// <summary>
            ///     The kmod shift sdl keymod
            /// </summary>
            KmodShift = KmodLshift | KmodRshift,

            /// <summary>
            ///     The kmod alt sdl keymod
            /// </summary>
            KmodAlt = KmodLalt | KmodRalt,

            /// <summary>
            ///     The kmod gui sdl keymod
            /// </summary>
            KmodGui = KmodLgui | KmodRgui,

            /// <summary>
            ///     The kmod reserved sdl keymod
            /// </summary>
            KmodReserved = KmodScroll
        }

        #endregion

        #region SDL_keyboard.h

        /// <summary>
        ///     The sdl keysym
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlKeysym
        {
            /// <summary>
            ///     The scancode
            /// </summary>
            public SdlScancode scancode;

            /// <summary>
            ///     The sym
            /// </summary>
            public SdlKeycode sym;

            /// <summary>
            ///     The mod
            /// </summary>
            public SdlKeymod mod; /* UInt16 */

            /// <summary>
            ///     The unicode
            /// </summary>
            public uint unicode; /* Deprecated */
        }

        /* Get the window which has kbd focus */
        /* Return type is an SDL_Window pointer */
        /// <summary>
        ///     Sdls the get keyboard focus
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetKeyboardFocus();

        /* Get a snapshot of the keyboard state. */
        /* Return value is a pointer to a UInt8 array */
        /* Numkeys returns the size of the array if non-null */
        /// <summary>
        ///     Sdls the get keyboard state using the specified numkeys
        /// </summary>
        /// <param name="numkeys">The numkeys</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetKeyboardState(out int numkeys);

        /* Get the current key modifier state for the keyboard. */
        /// <summary>
        ///     Sdls the get mod state
        /// </summary>
        /// <returns>The sdl keymod</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlKeymod SDL_GetModState();

        /* Set the current key modifier state */
        /// <summary>
        ///     Sdls the set mod state using the specified modstate
        /// </summary>
        /// <param name="modstate">The modstate</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetModState(SdlKeymod modstate);

        /* Get the key code corresponding to the given scancode
         * with the current keyboard layout.
         */
        /// <summary>
        ///     Sdls the get key from scancode using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The sdl keycode</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlKeycode SDL_GetKeyFromScancode(SdlScancode scancode);

        /* Get the scancode for the given keycode */
        /// <summary>
        ///     Sdls the get scancode from key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The sdl scancode</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlScancode SDL_GetScancodeFromKey(SdlKeycode key);

        /* Wrapper for SDL_GetScancodeName */
        /// <summary>
        ///     Internals the sdl get scancode name using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetScancodeName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetScancodeName(SdlScancode scancode);

        /// <summary>
        ///     Sdls the get scancode name using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The string</returns>
        public static string SDL_GetScancodeName(SdlScancode scancode) => UTF8_ToManaged(
            INTERNAL_SDL_GetScancodeName(scancode)
        );

        /* Get a scancode from a human-readable name */
        /// <summary>
        ///     Internals the sdl get scancode from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl scancode</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetScancodeFromName", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe SdlScancode INTERNAL_SDL_GetScancodeFromName(
            byte* name
        );

        /// <summary>
        ///     Sdls the get scancode from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl scancode</returns>
        public static unsafe SdlScancode SDL_GetScancodeFromName(string name)
        {
            int utf8NameBufSize = Utf8Size(name);
            byte* utf8Name = stackalloc byte[utf8NameBufSize];
            return INTERNAL_SDL_GetScancodeFromName(
                Utf8Encode(name, utf8Name, utf8NameBufSize)
            );
        }

        /* Wrapper for SDL_GetKeyName */
        /// <summary>
        ///     Internals the sdl get key name using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetKeyName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetKeyName(SdlKeycode key);

        /// <summary>
        ///     Sdls the get key name using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The string</returns>
        public static string SDL_GetKeyName(SdlKeycode key) => UTF8_ToManaged(INTERNAL_SDL_GetKeyName(key));

        /* Get a key code from a human-readable name */
        /// <summary>
        ///     Internals the sdl get key from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl keycode</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetKeyFromName", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe SdlKeycode INTERNAL_SDL_GetKeyFromName(
            byte* name
        );

        /// <summary>
        ///     Sdls the get key from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl keycode</returns>
        public static unsafe SdlKeycode SDL_GetKeyFromName(string name)
        {
            int utf8NameBufSize = Utf8Size(name);
            byte* utf8Name = stackalloc byte[utf8NameBufSize];
            return INTERNAL_SDL_GetKeyFromName(
                Utf8Encode(name, utf8Name, utf8NameBufSize)
            );
        }

        /* Start accepting Unicode text input events, show keyboard */
        /// <summary>
        ///     Sdls the start text input
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_StartTextInput();

        /* Check if unicode input events are enabled */
        /// <summary>
        ///     Sdls the is text input active
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IsTextInputActive();

        /* Stop receiving any text input events, hide onscreen kbd */
        /// <summary>
        ///     Sdls the stop text input
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_StopTextInput();

        /* Set the rectangle used for text input, hint for IME */
        /// <summary>
        ///     Sdls the set text input rect using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetTextInputRect(ref SdlRect rect);

        /* Does the platform support an on-screen keyboard? */
        /// <summary>
        ///     Sdls the has screen keyboard support
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasScreenKeyboardSupport();

        /* Is the on-screen keyboard shown for a given window? */
        /* window is an SDL_Window pointer */
        /// <summary>
        ///     Sdls the is screen keyboard shown using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IsScreenKeyboardShown(IntPtr window);

        #endregion

        #region SDL_mouse.c

        /* Note: SDL_Cursor is a typedef normally. We'll treat it as
         * an IntPtr, because C# doesn't do typedefs. Yay!
         */

        /* System cursor types */
        /// <summary>
        ///     The sdl systemcursor enum
        /// </summary>
        public enum SdlSystemCursor
        {
            /// <summary>
            ///     The sdl system cursor arrow sdl systemcursor
            /// </summary>
            SdlSystemCursorArrow, // Arrow

            /// <summary>
            ///     The sdl system cursor ibeam sdl systemcursor
            /// </summary>
            SdlSystemCursorIbeam, // I-beam

            /// <summary>
            ///     The sdl system cursor wait sdl systemcursor
            /// </summary>
            SdlSystemCursorWait, // Wait

            /// <summary>
            ///     The sdl system cursor crosshair sdl systemcursor
            /// </summary>
            SdlSystemCursorCrosshair, // Crosshair

            /// <summary>
            ///     The sdl system cursor waitarrow sdl systemcursor
            /// </summary>
            SdlSystemCursorWaitarrow, // Small wait cursor (or Wait if not available)

            /// <summary>
            ///     The sdl system cursor sizenwse sdl systemcursor
            /// </summary>
            SdlSystemCursorSizenwse, // Double arrow pointing northwest and southeast

            /// <summary>
            ///     The sdl system cursor sizenesw sdl systemcursor
            /// </summary>
            SdlSystemCursorSizenesw, // Double arrow pointing northeast and southwest

            /// <summary>
            ///     The sdl system cursor sizewe sdl systemcursor
            /// </summary>
            SdlSystemCursorSizewe, // Double arrow pointing west and east

            /// <summary>
            ///     The sdl system cursor sizens sdl systemcursor
            /// </summary>
            SdlSystemCursorSizens, // Double arrow pointing north and south

            /// <summary>
            ///     The sdl system cursor sizeall sdl systemcursor
            /// </summary>
            SdlSystemCursorSizeall, // Four pointed arrow pointing north, south, east, and west

            /// <summary>
            ///     The sdl system cursor no sdl systemcursor
            /// </summary>
            SdlSystemCursorNo, // Slashed circle or crossbones

            /// <summary>
            ///     The sdl system cursor hand sdl systemcursor
            /// </summary>
            SdlSystemCursorHand, // Hand

            /// <summary>
            ///     The sdl num system cursors sdl systemcursor
            /// </summary>
            SdlNumSystemCursors
        }

        /* Get the window which currently has mouse focus */
        /* Return value is an SDL_Window pointer */
        /// <summary>
        ///     Sdls the get mouse focus
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetMouseFocus();

        /* Get the current state of the mouse */
        /// <summary>
        ///     Sdls the get mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetMouseState(out int x, out int y);

        /* Get the current state of the mouse */
        /* This overload allows for passing NULL to x */
        /// <summary>
        ///     Sdls the get mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetMouseState(IntPtr x, out int y);

        /* Get the current state of the mouse */
        /* This overload allows for passing NULL to y */
        /// <summary>
        ///     Sdls the get mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetMouseState(out int x, IntPtr y);

        /* Get the current state of the mouse */
        /* This overload allows for passing NULL to both x and y */
        /// <summary>
        ///     Sdls the get mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetMouseState(IntPtr x, IntPtr y);

        /* Get the current state of the mouse, in relation to the desktop.
         * Only available in 2.0.4 or higher.
         */
        /// <summary>
        ///     Sdls the get global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetGlobalMouseState(out int x, out int y);

        /* Get the current state of the mouse, in relation to the desktop.
         * Only available in 2.0.4 or higher.
         * This overload allows for passing NULL to x.
         */
        /// <summary>
        ///     Sdls the get global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetGlobalMouseState(IntPtr x, out int y);

        /* Get the current state of the mouse, in relation to the desktop.
         * Only available in 2.0.4 or higher.
         * This overload allows for passing NULL to y.
         */
        /// <summary>
        ///     Sdls the get global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetGlobalMouseState(out int x, IntPtr y);

        /* Get the current state of the mouse, in relation to the desktop.
         * Only available in 2.0.4 or higher.
         * This overload allows for passing NULL to both x and y
         */
        /// <summary>
        ///     Sdls the get global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetGlobalMouseState(IntPtr x, IntPtr y);

        /* Get the mouse state with relative coords*/
        /// <summary>
        ///     Sdls the get relative mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetRelativeMouseState(out int x, out int y);

        /* Set the mouse cursor's position (within a window) */
        /* window is an SDL_Window pointer */
        /// <summary>
        ///     Sdls the warp mouse in window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_WarpMouseInWindow(IntPtr window, int x, int y);

        /* Set the mouse cursor's position in global screen space.
         * Only available in 2.0.4 or higher.
         */
        /// <summary>
        ///     Sdls the warp mouse global using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_WarpMouseGlobal(int x, int y);

        /* Enable/Disable relative mouse mode (grabs mouse, rel coords) */
        /// <summary>
        ///     Sdls the set relative mouse mode using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetRelativeMouseMode(SdlBool enabled);

        /* Capture the mouse, to track input outside an SDL window.
         * Only available in 2.0.4 or higher.
         */
        /// <summary>
        ///     Sdls the capture mouse using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_CaptureMouse(SdlBool enabled);

        /* Query if the relative mouse mode is enabled */
        /// <summary>
        ///     Sdls the get relative mouse mode
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GetRelativeMouseMode();

        /* Create a cursor from bitmap data (amd mask) in MSB format.
         * data and mask are byte arrays, and w must be a multiple of 8.
         * return value is an SDL_Cursor pointer.
         */
        /// <summary>
        ///     Sdls the create cursor using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="mask">The mask</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="hotX">The hot</param>
        /// <param name="hotY">The hot</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateCursor(
            IntPtr data,
            IntPtr mask,
            int w,
            int h,
            int hotX,
            int hotY
        );

        /* Create a cursor from an SDL_Surface.
         * IntPtr refers to an SDL_Cursor*, surface to an SDL_Surface*
         */
        /// <summary>
        ///     Sdls the create color cursor using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="hotX">The hot</param>
        /// <param name="hotY">The hot</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateColorCursor(
            IntPtr surface,
            int hotX,
            int hotY
        );

        /* Create a cursor from a system cursor id.
         * return value is an SDL_Cursor pointer
         */
        /// <summary>
        ///     Sdls the create system cursor using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateSystemCursor(SdlSystemCursor id);

        /* Set the active cursor.
         * cursor is an SDL_Cursor pointer
         */
        /// <summary>
        ///     Sdls the set cursor using the specified cursor
        /// </summary>
        /// <param name="cursor">The cursor</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetCursor(IntPtr cursor);

        /* Return the active cursor
         * return value is an SDL_Cursor pointer
         */
        /// <summary>
        ///     Sdls the get cursor
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetCursor();

        /* Frees a cursor created with one of the CreateCursor functions.
         * cursor in an SDL_Cursor pointer
         */
        /// <summary>
        ///     Sdls the free cursor using the specified cursor
        /// </summary>
        /// <param name="cursor">The cursor</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeCursor(IntPtr cursor);

        /* Toggle whether or not the cursor is shown */
        /// <summary>
        ///     Sdls the show cursor using the specified toggle
        /// </summary>
        /// <param name="toggle">The toggle</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_ShowCursor(int toggle);

        /// <summary>
        ///     Sdls the button using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The uint</returns>
        public static uint SDL_BUTTON(uint x) =>
            // If only there were a better way of doing this in C#
            (uint) (1 << ((int) x - 1));

        /// <summary>
        ///     The sdl button left
        /// </summary>
        public const uint SdlButtonLeft = 1;

        /// <summary>
        ///     The sdl button middle
        /// </summary>
        public const uint SdlButtonMiddle = 2;

        /// <summary>
        ///     The sdl button right
        /// </summary>
        public const uint SdlButtonRight = 3;

        /// <summary>
        ///     The sdl button x1
        /// </summary>
        public const uint SdlButtonX1 = 4;

        /// <summary>
        ///     The sdl button x2
        /// </summary>
        public const uint SdlButtonX2 = 5;

        /// <summary>
        ///     The sdl button left
        /// </summary>
        public static readonly uint SdlButtonLmask = SDL_BUTTON(SdlButtonLeft);

        /// <summary>
        ///     The sdl button middle
        /// </summary>
        public static readonly uint SdlButtonMmask = SDL_BUTTON(SdlButtonMiddle);

        /// <summary>
        ///     The sdl button right
        /// </summary>
        public static readonly uint SdlButtonRmask = SDL_BUTTON(SdlButtonRight);

        /// <summary>
        ///     The sdl button x1
        /// </summary>
        public static readonly uint SdlButtonX1Mask = SDL_BUTTON(SdlButtonX1);

        /// <summary>
        ///     The sdl button x2
        /// </summary>
        public static readonly uint SdlButtonX2Mask = SDL_BUTTON(SdlButtonX2);

        #endregion

        #region SDL_touch.h

        /// <summary>
        ///     The max value
        /// </summary>
        public const uint SdlTouchMouseid = uint.MaxValue;

        /// <summary>
        ///     The sdl finger
        /// </summary>
        public struct SdlFinger
        {
            /// <summary>
            ///     The id
            /// </summary>
            public long Id; // SDL_FingerID

            /// <summary>
            ///     The
            /// </summary>
            public float X;

            /// <summary>
            ///     The
            /// </summary>
            public float Y;

            /// <summary>
            ///     The pressure
            /// </summary>
            public float Pressure;
        }

        /* Only available in 2.0.10 or higher. */
        /// <summary>
        ///     The sdl touchdevicetype enum
        /// </summary>
        public enum SdlTouchDeviceType
        {
            /// <summary>
            ///     The sdl touch device invalid sdl touchdevicetype
            /// </summary>
            SdlTouchDeviceInvalid = -1,

            /// <summary>
            ///     The sdl touch device direct sdl touchdevicetype
            /// </summary>
            SdlTouchDeviceDirect, /* touch screen with window-relative coordinates */

            /// <summary>
            ///     The sdl touch device indirect absolute sdl touchdevicetype
            /// </summary>
            SdlTouchDeviceIndirectAbsolute, /* trackpad with absolute device coordinates */

            /// <summary>
            ///     The sdl touch device indirect relative sdl touchdevicetype
            /// </summary>
            SdlTouchDeviceIndirectRelative /* trackpad with screen cursor-relative coordinates */
        }

        /**
         * \brief Get the number of registered touch devices.
         */
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumTouchDevices();

        /**
         * \brief Get the touch ID with the given index, or 0 if the index is invalid.
         */
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long SDL_GetTouchDevice(int index);

        /**
         * \brief Get the number of active fingers for a given touch device.
         */
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumTouchFingers(long touchId);

        /**
         * \brief Get the finger object of the given touch, with the given index.
         * Returns pointer to SDL_Finger.
         */
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetTouchFinger(long touchId, int index);

        /* Only available in 2.0.10 or higher. */
        /// <summary>
        ///     Sdls the get touch device type using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <returns>The sdl touch device type</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlTouchDeviceType SDL_GetTouchDeviceType(long touchId);

        #endregion

        #region SDL_joystick.h

        /// <summary>
        ///     The sdl hat centered
        /// </summary>
        public const byte SdlHatCentered = 0x00;

        /// <summary>
        ///     The sdl hat up
        /// </summary>
        public const byte SdlHatUp = 0x01;

        /// <summary>
        ///     The sdl hat right
        /// </summary>
        public const byte SdlHatRight = 0x02;

        /// <summary>
        ///     The sdl hat down
        /// </summary>
        public const byte SdlHatDown = 0x04;

        /// <summary>
        ///     The sdl hat left
        /// </summary>
        public const byte SdlHatLeft = 0x08;

        /// <summary>
        ///     The sdl hat up
        /// </summary>
        public const byte SdlHatRightup = SdlHatRight | SdlHatUp;

        /// <summary>
        ///     The sdl hat down
        /// </summary>
        public const byte SdlHatRightdown = SdlHatRight | SdlHatDown;

        /// <summary>
        ///     The sdl hat up
        /// </summary>
        public const byte SdlHatLeftup = SdlHatLeft | SdlHatUp;

        /// <summary>
        ///     The sdl hat down
        /// </summary>
        public const byte SdlHatLeftdown = SdlHatLeft | SdlHatDown;

        /// <summary>
        ///     The sdl joystickpowerlevel enum
        /// </summary>
        public enum SdlJoystickPowerLevel
        {
            /// <summary>
            ///     The sdl joystick power unknown sdl joystickpowerlevel
            /// </summary>
            SdlJoystickPowerUnknown = -1,

            /// <summary>
            ///     The sdl joystick power empty sdl joystickpowerlevel
            /// </summary>
            SdlJoystickPowerEmpty,

            /// <summary>
            ///     The sdl joystick power low sdl joystickpowerlevel
            /// </summary>
            SdlJoystickPowerLow,

            /// <summary>
            ///     The sdl joystick power medium sdl joystickpowerlevel
            /// </summary>
            SdlJoystickPowerMedium,

            /// <summary>
            ///     The sdl joystick power full sdl joystickpowerlevel
            /// </summary>
            SdlJoystickPowerFull,

            /// <summary>
            ///     The sdl joystick power wired sdl joystickpowerlevel
            /// </summary>
            SdlJoystickPowerWired,

            /// <summary>
            ///     The sdl joystick power max sdl joystickpowerlevel
            /// </summary>
            SdlJoystickPowerMax
        }

        /// <summary>
        ///     The sdl joysticktype enum
        /// </summary>
        public enum SdlJoystickType
        {
            /// <summary>
            ///     The sdl joystick type unknown sdl joysticktype
            /// </summary>
            SdlJoystickTypeUnknown,

            /// <summary>
            ///     The sdl joystick type gamecontroller sdl joysticktype
            /// </summary>
            SdlJoystickTypeGamecontroller,

            /// <summary>
            ///     The sdl joystick type wheel sdl joysticktype
            /// </summary>
            SdlJoystickTypeWheel,

            /// <summary>
            ///     The sdl joystick type arcade stick sdl joysticktype
            /// </summary>
            SdlJoystickTypeArcadeStick,

            /// <summary>
            ///     The sdl joystick type flight stick sdl joysticktype
            /// </summary>
            SdlJoystickTypeFlightStick,

            /// <summary>
            ///     The sdl joystick type dance pad sdl joysticktype
            /// </summary>
            SdlJoystickTypeDancePad,

            /// <summary>
            ///     The sdl joystick type guitar sdl joysticktype
            /// </summary>
            SdlJoystickTypeGuitar,

            /// <summary>
            ///     The sdl joystick type drum kit sdl joysticktype
            /// </summary>
            SdlJoystickTypeDrumKit,

            /// <summary>
            ///     The sdl joystick type arcade pad sdl joysticktype
            /// </summary>
            SdlJoystickTypeArcadePad
        }

        /* Only available in 2.0.14 or higher. */
        /// <summary>
        ///     The sdl iphone max gforce
        /// </summary>
        public const float SdlIphoneMaxGforce = 5.0f;

        /* joystick refers to an SDL_Joystick*.
         * Only available in 2.0.9 or higher.
         */
        /// <summary>
        ///     Sdls the joystick rumble using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="lowFrequencyRumble">The low frequency rumble</param>
        /// <param name="highFrequencyRumble">The high frequency rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickRumble(
            IntPtr joystick,
            ushort lowFrequencyRumble,
            ushort highFrequencyRumble,
            uint durationMs
        );

        /* joystick refers to an SDL_Joystick*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Sdls the joystick rumble triggers using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="leftRumble">The left rumble</param>
        /// <param name="rightRumble">The right rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickRumbleTriggers(
            IntPtr joystick,
            ushort leftRumble,
            ushort rightRumble,
            uint durationMs
        );

        /* joystick refers to an SDL_Joystick* */
        /// <summary>
        ///     Sdls the joystick close using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickClose(IntPtr joystick);

        /// <summary>
        ///     Sdls the joystick event state using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickEventState(int state);

        /* joystick refers to an SDL_Joystick* */
        /// <summary>
        ///     Sdls the joystick get axis using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <returns>The short</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern short SDL_JoystickGetAxis(
            IntPtr joystick,
            int axis
        );

        /* joystick refers to an SDL_Joystick*.
         * Only available in 2.0.6 or higher.
         */
        /// <summary>
        ///     Sdls the joystick get axis initial state using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <param name="state">The state</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_JoystickGetAxisInitialState(
            IntPtr joystick,
            int axis,
            out ushort state
        );

        /* joystick refers to an SDL_Joystick* */
        /// <summary>
        ///     Sdls the joystick get ball using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="ball">The ball</param>
        /// <param name="dx">The dx</param>
        /// <param name="dy">The dy</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickGetBall(
            IntPtr joystick,
            int ball,
            out int dx,
            out int dy
        );

        /* joystick refers to an SDL_Joystick* */
        /// <summary>
        ///     Sdls the joystick get button using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_JoystickGetButton(
            IntPtr joystick,
            int button
        );

        /* joystick refers to an SDL_Joystick* */
        /// <summary>
        ///     Sdls the joystick get hat using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="hat">The hat</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_JoystickGetHat(
            IntPtr joystick,
            int hat
        );

        /* joystick refers to an SDL_Joystick* */
        /// <summary>
        ///     Internals the sdl joystick name using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_JoystickName(
            IntPtr joystick
        );

        /// <summary>
        ///     Sdls the joystick name using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The string</returns>
        public static string SDL_JoystickName(IntPtr joystick) => UTF8_ToManaged(
            INTERNAL_SDL_JoystickName(joystick)
        );

        /// <summary>
        ///     Internals the sdl joystick name for index using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickNameForIndex", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_JoystickNameForIndex(
            int deviceIndex
        );

        /// <summary>
        ///     Sdls the joystick name for index using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The string</returns>
        public static string SDL_JoystickNameForIndex(int deviceIndex) => UTF8_ToManaged(
            INTERNAL_SDL_JoystickNameForIndex(deviceIndex)
        );

        /* joystick refers to an SDL_Joystick* */
        /// <summary>
        ///     Sdls the joystick num axes using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumAxes(IntPtr joystick);

        /* joystick refers to an SDL_Joystick* */
        /// <summary>
        ///     Sdls the joystick num balls using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumBalls(IntPtr joystick);

        /* joystick refers to an SDL_Joystick* */
        /// <summary>
        ///     Sdls the joystick num buttons using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumButtons(IntPtr joystick);

        /* joystick refers to an SDL_Joystick* */
        /// <summary>
        ///     Sdls the joystick num hats using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumHats(IntPtr joystick);

        /* IntPtr refers to an SDL_Joystick* */
        /// <summary>
        ///     Sdls the joystick open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_JoystickOpen(int deviceIndex);

        /* joystick refers to an SDL_Joystick* */
        /// <summary>
        ///     Sdls the joystick update
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickUpdate();

        /* joystick refers to an SDL_Joystick* */
        /// <summary>
        ///     Sdls the num joysticks
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_NumJoysticks();

        /// <summary>
        ///     Sdls the joystick get device guid using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The guid</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Guid SDL_JoystickGetDeviceGUID(
            int deviceIndex
        );

        /* joystick refers to an SDL_Joystick* */
        /// <summary>
        ///     Sdls the joystick get guid using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The guid</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Guid SDL_JoystickGetGUID(
            IntPtr joystick
        );

        /// <summary>
        ///     Sdls the joystick get guid string using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="pszGuid">The psz guid</param>
        /// <param name="cbGuid">The cb guid</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickGetGUIDString(
            Guid guid,
            byte[] pszGuid,
            int cbGuid
        );

        /// <summary>
        ///     Internals the sdl joystick get guid from string using the specified pch guid
        /// </summary>
        /// <param name="pchGuid">The pch guid</param>
        /// <returns>The guid</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetGUIDFromString", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe Guid INTERNAL_SDL_JoystickGetGUIDFromString(
            byte* pchGuid
        );

        /// <summary>
        ///     Sdls the joystick get guid from string using the specified pch guid
        /// </summary>
        /// <param name="pchGuid">The pch guid</param>
        /// <returns>The guid</returns>
        public static unsafe Guid SDL_JoystickGetGUIDFromString(string pchGuid)
        {
            int utf8PchGuidBufSize = Utf8Size(pchGuid);
            byte* utf8PchGuid = stackalloc byte[utf8PchGuidBufSize];
            return INTERNAL_SDL_JoystickGetGUIDFromString(
                Utf8Encode(pchGuid, utf8PchGuid, utf8PchGuidBufSize)
            );
        }

        /* Only available in 2.0.6 or higher. */
        /// <summary>
        ///     Sdls the joystick get device vendor using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetDeviceVendor(int deviceIndex);

        /* Only available in 2.0.6 or higher. */
        /// <summary>
        ///     Sdls the joystick get device product using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetDeviceProduct(int deviceIndex);

        /* Only available in 2.0.6 or higher. */
        /// <summary>
        ///     Sdls the joystick get device product version using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetDeviceProductVersion(int deviceIndex);

        /* Only available in 2.0.6 or higher. */
        /// <summary>
        ///     Sdls the joystick get device type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl joystick type</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlJoystickType SDL_JoystickGetDeviceType(int deviceIndex);

        /* int refers to an SDL_JoystickID.
         * Only available in 2.0.6 or higher.
         */
        /// <summary>
        ///     Sdls the joystick get device instance id using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickGetDeviceInstanceID(int deviceIndex);

        /* joystick refers to an SDL_Joystick*.
         * Only available in 2.0.6 or higher.
         */
        /// <summary>
        ///     Sdls the joystick get vendor using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetVendor(IntPtr joystick);

        /* joystick refers to an SDL_Joystick*.
         * Only available in 2.0.6 or higher.
         */
        /// <summary>
        ///     Sdls the joystick get product using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetProduct(IntPtr joystick);

        /* joystick refers to an SDL_Joystick*.
         * Only available in 2.0.6 or higher.
         */
        /// <summary>
        ///     Sdls the joystick get product version using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetProductVersion(IntPtr joystick);

        /* joystick refers to an SDL_Joystick*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Internals the sdl joystick get serial using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetSerial", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_JoystickGetSerial(
            IntPtr joystick
        );

        /// <summary>
        ///     Sdls the joystick get serial using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The string</returns>
        public static string SDL_JoystickGetSerial(
            IntPtr joystick
        )
            => UTF8_ToManaged(
                INTERNAL_SDL_JoystickGetSerial(joystick)
            );

        /* joystick refers to an SDL_Joystick*.
         * Only available in 2.0.6 or higher.
         */
        /// <summary>
        ///     Sdls the joystick get type using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl joystick type</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlJoystickType SDL_JoystickGetType(IntPtr joystick);

        /* joystick refers to an SDL_Joystick* */
        /// <summary>
        ///     Sdls the joystick get attached using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_JoystickGetAttached(IntPtr joystick);

        /* int refers to an SDL_JoystickID, joystick to an SDL_Joystick* */
        /// <summary>
        ///     Sdls the joystick instance id using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickInstanceID(IntPtr joystick);

        /* joystick refers to an SDL_Joystick*.
         * Only available in 2.0.4 or higher.
         */
        /// <summary>
        ///     Sdls the joystick current power level using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl joystick power level</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlJoystickPowerLevel SDL_JoystickCurrentPowerLevel(
            IntPtr joystick
        );

        /* int refers to an SDL_JoystickID, IntPtr to an SDL_Joystick*.
         * Only available in 2.0.4 or higher.
         */
        /// <summary>
        ///     Sdls the joystick from instance id using the specified instance id
        /// </summary>
        /// <param name="instanceId">The instance id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_JoystickFromInstanceID(int instanceId);

        /* Only available in 2.0.7 or higher. */
        /// <summary>
        ///     Sdls the lock joysticks
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LockJoysticks();

        /* Only available in 2.0.7 or higher. */
        /// <summary>
        ///     Sdls the unlock joysticks
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockJoysticks();

        /* IntPtr refers to an SDL_Joystick*.
         * Only available in 2.0.11 or higher.
         */
        /// <summary>
        ///     Sdls the joystick from player index using the specified player index
        /// </summary>
        /// <param name="playerIndex">The player index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_JoystickFromPlayerIndex(int playerIndex);

        /* IntPtr refers to an SDL_Joystick*.
         * Only available in 2.0.11 or higher.
         */
        /// <summary>
        ///     Sdls the joystick set player index using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="playerIndex">The player index</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickSetPlayerIndex(
            IntPtr joystick,
            int playerIndex
        );

        /* Int32 refers to an SDL_JoystickType.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Sdls the joystick attach virtual using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="naxes">The naxes</param>
        /// <param name="nbuttons">The nbuttons</param>
        /// <param name="nhats">The nhats</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickAttachVirtual(
            int type,
            int naxes,
            int nbuttons,
            int nhats
        );

        /* Only available in 2.0.14 or higher. */
        /// <summary>
        ///     Sdls the joystick detach virtual using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickDetachVirtual(int deviceIndex);

        /* Only available in 2.0.14 or higher. */
        /// <summary>
        ///     Sdls the joystick is virtual using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_JoystickIsVirtual(int deviceIndex);

        /* IntPtr refers to an SDL_Joystick*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Sdls the joystick set virtual axis using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickSetVirtualAxis(
            IntPtr joystick,
            int axis,
            short value
        );

        /* IntPtr refers to an SDL_Joystick*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Sdls the joystick set virtual button using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="button">The button</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickSetVirtualButton(
            IntPtr joystick,
            int button,
            byte value
        );

        /* IntPtr refers to an SDL_Joystick*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Sdls the joystick set virtual hat using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="hat">The hat</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickSetVirtualHat(
            IntPtr joystick,
            int hat,
            byte value
        );

        /* IntPtr refers to an SDL_Joystick*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Sdls the joystick has led using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_JoystickHasLED(IntPtr joystick);

        /* IntPtr refers to an SDL_Joystick*.
         * Only available in 2.0.18 or higher.
         */
        /// <summary>
        ///     Sdls the joystick has rumble using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_JoystickHasRumble(IntPtr joystick);

        /* IntPtr refers to an SDL_Joystick*.
         * Only available in 2.0.18 or higher.
         */
        /// <summary>
        ///     Sdls the joystick has rumble triggers using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_JoystickHasRumbleTriggers(IntPtr joystick);

        /* IntPtr refers to an SDL_Joystick*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Sdls the joystick set led using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickSetLED(
            IntPtr joystick,
            byte red,
            byte green,
            byte blue
        );

        /* joystick refers to an SDL_Joystick*.
         * data refers to a const void*.
         * Only available in 2.0.16 or higher.
         */
        /// <summary>
        ///     Sdls the joystick send effect using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="data">The data</param>
        /// <param name="size">The size</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickSendEffect(
            IntPtr joystick,
            IntPtr data,
            int size
        );

        #endregion

        #region SDL_gamecontroller.h

        /// <summary>
        ///     The sdl gamecontrollerbindtype enum
        /// </summary>
        public enum SdlGameControllerBindType
        {
            /// <summary>
            ///     The sdl controller bindtype none sdl gamecontrollerbindtype
            /// </summary>
            SdlControllerBindtypeNone,

            /// <summary>
            ///     The sdl controller bindtype button sdl gamecontrollerbindtype
            /// </summary>
            SdlControllerBindtypeButton,

            /// <summary>
            ///     The sdl controller bindtype axis sdl gamecontrollerbindtype
            /// </summary>
            SdlControllerBindtypeAxis,

            /// <summary>
            ///     The sdl controller bindtype hat sdl gamecontrollerbindtype
            /// </summary>
            SdlControllerBindtypeHat
        }

        /// <summary>
        ///     The sdl gamecontrolleraxis enum
        /// </summary>
        public enum SdlGameControllerAxis
        {
            /// <summary>
            ///     The sdl controller axis invalid sdl gamecontrolleraxis
            /// </summary>
            SdlControllerAxisInvalid = -1,

            /// <summary>
            ///     The sdl controller axis leftx sdl gamecontrolleraxis
            /// </summary>
            SdlControllerAxisLeftx,

            /// <summary>
            ///     The sdl controller axis lefty sdl gamecontrolleraxis
            /// </summary>
            SdlControllerAxisLefty,

            /// <summary>
            ///     The sdl controller axis rightx sdl gamecontrolleraxis
            /// </summary>
            SdlControllerAxisRightx,

            /// <summary>
            ///     The sdl controller axis righty sdl gamecontrolleraxis
            /// </summary>
            SdlControllerAxisRighty,

            /// <summary>
            ///     The sdl controller axis triggerleft sdl gamecontrolleraxis
            /// </summary>
            SdlControllerAxisTriggerleft,

            /// <summary>
            ///     The sdl controller axis triggerright sdl gamecontrolleraxis
            /// </summary>
            SdlControllerAxisTriggerright,

            /// <summary>
            ///     The sdl controller axis max sdl gamecontrolleraxis
            /// </summary>
            SdlControllerAxisMax
        }

        /// <summary>
        ///     The sdl gamecontrollerbutton enum
        /// </summary>
        public enum SdlGameControllerButton
        {
            /// <summary>
            ///     The sdl controller button invalid sdl gamecontrollerbutton
            /// </summary>
            SdlControllerButtonInvalid = -1,

            /// <summary>
            ///     The sdl controller button sdl gamecontrollerbutton
            /// </summary>
            SdlControllerButtonA,

            /// <summary>
            ///     The sdl controller button sdl gamecontrollerbutton
            /// </summary>
            SdlControllerButtonB,

            /// <summary>
            ///     The sdl controller button sdl gamecontrollerbutton
            /// </summary>
            SdlControllerButtonX,

            /// <summary>
            ///     The sdl controller button sdl gamecontrollerbutton
            /// </summary>
            SdlControllerButtonY,

            /// <summary>
            ///     The sdl controller button back sdl gamecontrollerbutton
            /// </summary>
            SdlControllerButtonBack,

            /// <summary>
            ///     The sdl controller button guide sdl gamecontrollerbutton
            /// </summary>
            SdlControllerButtonGuide,

            /// <summary>
            ///     The sdl controller button start sdl gamecontrollerbutton
            /// </summary>
            SdlControllerButtonStart,

            /// <summary>
            ///     The sdl controller button leftstick sdl gamecontrollerbutton
            /// </summary>
            SdlControllerButtonLeftstick,

            /// <summary>
            ///     The sdl controller button rightstick sdl gamecontrollerbutton
            /// </summary>
            SdlControllerButtonRightstick,

            /// <summary>
            ///     The sdl controller button leftshoulder sdl gamecontrollerbutton
            /// </summary>
            SdlControllerButtonLeftshoulder,

            /// <summary>
            ///     The sdl controller button rightshoulder sdl gamecontrollerbutton
            /// </summary>
            SdlControllerButtonRightshoulder,

            /// <summary>
            ///     The sdl controller button dpad up sdl gamecontrollerbutton
            /// </summary>
            SdlControllerButtonDpadUp,

            /// <summary>
            ///     The sdl controller button dpad down sdl gamecontrollerbutton
            /// </summary>
            SdlControllerButtonDpadDown,

            /// <summary>
            ///     The sdl controller button dpad left sdl gamecontrollerbutton
            /// </summary>
            SdlControllerButtonDpadLeft,

            /// <summary>
            ///     The sdl controller button dpad right sdl gamecontrollerbutton
            /// </summary>
            SdlControllerButtonDpadRight,

            /// <summary>
            ///     The sdl controller button misc1 sdl gamecontrollerbutton
            /// </summary>
            SdlControllerButtonMisc1,

            /// <summary>
            ///     The sdl controller button paddle1 sdl gamecontrollerbutton
            /// </summary>
            SdlControllerButtonPaddle1,

            /// <summary>
            ///     The sdl controller button paddle2 sdl gamecontrollerbutton
            /// </summary>
            SdlControllerButtonPaddle2,

            /// <summary>
            ///     The sdl controller button paddle3 sdl gamecontrollerbutton
            /// </summary>
            SdlControllerButtonPaddle3,

            /// <summary>
            ///     The sdl controller button paddle4 sdl gamecontrollerbutton
            /// </summary>
            SdlControllerButtonPaddle4,

            /// <summary>
            ///     The sdl controller button touchpad sdl gamecontrollerbutton
            /// </summary>
            SdlControllerButtonTouchpad,

            /// <summary>
            ///     The sdl controller button max sdl gamecontrollerbutton
            /// </summary>
            SdlControllerButtonMax
        }

        /// <summary>
        ///     The sdl gamecontrollertype enum
        /// </summary>
        public enum SdlGameControllerType
        {
            /// <summary>
            ///     The sdl controller type unknown sdl gamecontrollertype
            /// </summary>
            SdlControllerTypeUnknown = 0,

            /// <summary>
            ///     The sdl controller type xbox360 sdl gamecontrollertype
            /// </summary>
            SdlControllerTypeXbox360,

            /// <summary>
            ///     The sdl controller type xboxone sdl gamecontrollertype
            /// </summary>
            SdlControllerTypeXboxone,

            /// <summary>
            ///     The sdl controller type ps3 sdl gamecontrollertype
            /// </summary>
            SdlControllerTypePs3,

            /// <summary>
            ///     The sdl controller type ps4 sdl gamecontrollertype
            /// </summary>
            SdlControllerTypePs4,

            /// <summary>
            ///     The sdl controller type nintendo switch pro sdl gamecontrollertype
            /// </summary>
            SdlControllerTypeNintendoSwitchPro,

            /// <summary>
            ///     The sdl controller type virtual sdl gamecontrollertype
            /// </summary>
            SdlControllerTypeVirtual, /* Requires >= 2.0.14 */

            /// <summary>
            ///     The sdl controller type ps5 sdl gamecontrollertype
            /// </summary>
            SdlControllerTypePs5, /* Requires >= 2.0.14 */

            /// <summary>
            ///     The sdl controller type amazon luna sdl gamecontrollertype
            /// </summary>
            SdlControllerTypeAmazonLuna, /* Requires >= 2.0.16 */

            /// <summary>
            ///     The sdl controller type google stadia sdl gamecontrollertype
            /// </summary>
            SdlControllerTypeGoogleStadia /* Requires >= 2.0.16 */
        }

        // FIXME: I'd rather this somehow be private...
        /// <summary>
        ///     The internal gamecontrollerbuttonbind hat
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct InternalGameControllerButtonBindHat
        {
            /// <summary>
            ///     The hat
            /// </summary>
            public int hat;

            /// <summary>
            ///     The hat mask
            /// </summary>
            public int hat_mask;
        }

        // FIXME: I'd rather this somehow be private...
        /// <summary>
        ///     The internal gamecontrollerbuttonbind union
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct InternalGameControllerButtonBindUnion
        {
            /// <summary>
            ///     The button
            /// </summary>
            [FieldOffset(0)] public int button;

            /// <summary>
            ///     The axis
            /// </summary>
            [FieldOffset(0)] public int axis;

            /// <summary>
            ///     The hat
            /// </summary>
            [FieldOffset(0)] public InternalGameControllerButtonBindHat hat;
        }

        /// <summary>
        ///     The sdl gamecontrollerbuttonbind
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlGameControllerButtonBind
        {
            /// <summary>
            ///     The bind type
            /// </summary>
            public SdlGameControllerBindType bindType;

            /// <summary>
            ///     The value
            /// </summary>
            public InternalGameControllerButtonBindUnion value;
        }

        /* This exists to deal with C# being stupid about blittable types. */
        /// <summary>
        ///     The internal sdl gamecontrollerbuttonbind
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct InternalSdlGameControllerButtonBind
        {
            /// <summary>
            ///     The bind type
            /// </summary>
            public int bindType;

            /* Largest data type in the union is two ints in size */
            /// <summary>
            ///     The union val
            /// </summary>
            public int unionVal0;

            /// <summary>
            ///     The union val
            /// </summary>
            public int unionVal1;
        }

        /// <summary>
        ///     Internals the sdl game controller add mapping using the specified mapping string
        /// </summary>
        /// <param name="mappingString">The mapping string</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerAddMapping", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int INTERNAL_SDL_GameControllerAddMapping(
            byte* mappingString
        );

        /// <summary>
        ///     Sdls the game controller add mapping using the specified mapping string
        /// </summary>
        /// <param name="mappingString">The mapping string</param>
        /// <returns>The result</returns>
        public static unsafe int SDL_GameControllerAddMapping(
            string mappingString
        )
        {
            byte* utf8MappingString = Utf8EncodeHeap(mappingString);
            int result = INTERNAL_SDL_GameControllerAddMapping(
                utf8MappingString
            );
            Marshal.FreeHGlobal((IntPtr) utf8MappingString);
            return result;
        }

        /* Only available in 2.0.6 or higher. */
        /// <summary>
        ///     Sdls the game controller num mappings
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerNumMappings();

        /* Only available in 2.0.6 or higher. */
        /// <summary>
        ///     Internals the sdl game controller mapping for index using the specified mapping index
        /// </summary>
        /// <param name="mappingIndex">The mapping index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerMappingForIndex", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerMappingForIndex(int mappingIndex);

        /// <summary>
        ///     Sdls the game controller mapping for index using the specified mapping index
        /// </summary>
        /// <param name="mappingIndex">The mapping index</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerMappingForIndex(int mappingIndex) => UTF8_ToManaged(
            INTERNAL_SDL_GameControllerMappingForIndex(
                mappingIndex
            ),
            true
        );

        /* THIS IS AN RWops FUNCTION! */
        /// <summary>
        ///     Internals the sdl game controller add mappings from rw using the specified rw
        /// </summary>
        /// <param name="rw">The rw</param>
        /// <param name="freerw">The freerw</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerAddMappingsFromRW", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_SDL_GameControllerAddMappingsFromRW(
            IntPtr rw,
            int freerw
        );

        /// <summary>
        ///     Sdls the game controller add mappings from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int</returns>
        public static int SDL_GameControllerAddMappingsFromFile(string file)
        {
            IntPtr rwops = SDL_RWFromFile(file, "rb");
            return INTERNAL_SDL_GameControllerAddMappingsFromRW(rwops, 1);
        }

        /// <summary>
        ///     Internals the sdl game controller mapping for guid using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerMappingForGUID", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerMappingForGUID(
            Guid guid
        );

        /// <summary>
        ///     Sdls the game controller mapping for guid using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerMappingForGUID(Guid guid) => UTF8_ToManaged(
            INTERNAL_SDL_GameControllerMappingForGUID(guid),
            true
        );

        /* gamecontroller refers to an SDL_GameController* */
        /// <summary>
        ///     Internals the sdl game controller mapping using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerMapping", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerMapping(
            IntPtr gamecontroller
        );

        /// <summary>
        ///     Sdls the game controller mapping using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerMapping(
            IntPtr gamecontroller
        )
            => UTF8_ToManaged(
                INTERNAL_SDL_GameControllerMapping(
                    gamecontroller
                ),
                true
            );

        /// <summary>
        ///     Sdls the is game controller using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IsGameController(int joystickIndex);

        /// <summary>
        ///     Internals the sdl game controller name for index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerNameForIndex", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerNameForIndex(
            int joystickIndex
        );

        /// <summary>
        ///     Sdls the game controller name for index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerNameForIndex(
            int joystickIndex
        )
            => UTF8_ToManaged(
                INTERNAL_SDL_GameControllerNameForIndex(joystickIndex)
            );

        /* Only available in 2.0.9 or higher. */
        /// <summary>
        ///     Internals the sdl game controller mapping for device index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerMappingForDeviceIndex", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerMappingForDeviceIndex(
            int joystickIndex
        );

        /// <summary>
        ///     Sdls the game controller mapping for device index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerMappingForDeviceIndex(
            int joystickIndex
        )
            => UTF8_ToManaged(
                INTERNAL_SDL_GameControllerMappingForDeviceIndex(joystickIndex),
                true
            );

        /* IntPtr refers to an SDL_GameController* */
        /// <summary>
        ///     Sdls the game controller open using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GameControllerOpen(int joystickIndex);

        /* gamecontroller refers to an SDL_GameController* */
        /// <summary>
        ///     Internals the sdl game controller name using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerName(
            IntPtr gamecontroller
        );

        /// <summary>
        ///     Sdls the game controller name using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerName(
            IntPtr gamecontroller
        )
            => UTF8_ToManaged(
                INTERNAL_SDL_GameControllerName(gamecontroller)
            );

        /* gamecontroller refers to an SDL_GameController*.
         * Only available in 2.0.6 or higher.
         */
        /// <summary>
        ///     Sdls the game controller get vendor using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_GameControllerGetVendor(
            IntPtr gamecontroller
        );

        /* gamecontroller refers to an SDL_GameController*.
         * Only available in 2.0.6 or higher.
         */
        /// <summary>
        ///     Sdls the game controller get product using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_GameControllerGetProduct(
            IntPtr gamecontroller
        );

        /* gamecontroller refers to an SDL_GameController*.
         * Only available in 2.0.6 or higher.
         */
        /// <summary>
        ///     Sdls the game controller get product version using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_GameControllerGetProductVersion(
            IntPtr gamecontroller
        );

        /* gamecontroller refers to an SDL_GameController*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Internals the sdl game controller get serial using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetSerial", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerGetSerial(
            IntPtr gamecontroller
        );

        /// <summary>
        ///     Sdls the game controller get serial using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerGetSerial(
            IntPtr gamecontroller
        )
            => UTF8_ToManaged(
                INTERNAL_SDL_GameControllerGetSerial(gamecontroller)
            );

        /* gamecontroller refers to an SDL_GameController* */
        /// <summary>
        ///     Sdls the game controller get attached using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GameControllerGetAttached(
            IntPtr gamecontroller
        );

        /* IntPtr refers to an SDL_Joystick*
         * gamecontroller refers to an SDL_GameController*
         */
        /// <summary>
        ///     Sdls the game controller get joystick using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GameControllerGetJoystick(
            IntPtr gamecontroller
        );

        /// <summary>
        ///     Sdls the game controller event state using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerEventState(int state);

        /// <summary>
        ///     Sdls the game controller update
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GameControllerUpdate();

        /// <summary>
        ///     Internals the sdl game controller get axis from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller axis</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetAxisFromString", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe SdlGameControllerAxis INTERNAL_SDL_GameControllerGetAxisFromString(
            byte* pchString
        );

        /// <summary>
        ///     Sdls the game controller get axis from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller axis</returns>
        public static unsafe SdlGameControllerAxis SDL_GameControllerGetAxisFromString(
            string pchString
        )
        {
            int utf8PchStringBufSize = Utf8Size(pchString);
            byte* utf8PchString = stackalloc byte[utf8PchStringBufSize];
            return INTERNAL_SDL_GameControllerGetAxisFromString(
                Utf8Encode(pchString, utf8PchString, utf8PchStringBufSize)
            );
        }

        /// <summary>
        ///     Internals the sdl game controller get string for axis using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetStringForAxis", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerGetStringForAxis(
            SdlGameControllerAxis axis
        );

        /// <summary>
        ///     Sdls the game controller get string for axis using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerGetStringForAxis(
            SdlGameControllerAxis axis
        )
            => UTF8_ToManaged(
                INTERNAL_SDL_GameControllerGetStringForAxis(
                    axis
                )
            );

        /* gamecontroller refers to an SDL_GameController* */
        /// <summary>
        ///     Internals the sdl game controller get bind for axis using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The internal sdl game controller button bind</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetBindForAxis", CallingConvention = CallingConvention.Cdecl)]
        private static extern InternalSdlGameControllerButtonBind INTERNAL_SDL_GameControllerGetBindForAxis(
            IntPtr gamecontroller,
            SdlGameControllerAxis axis
        );

        /// <summary>
        ///     Sdls the game controller get bind for axis using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The result</returns>
        public static SdlGameControllerButtonBind SDL_GameControllerGetBindForAxis(
            IntPtr gamecontroller,
            SdlGameControllerAxis axis
        )
        {
            // This is guaranteed to never be null
            InternalSdlGameControllerButtonBind dumb = INTERNAL_SDL_GameControllerGetBindForAxis(
                gamecontroller,
                axis
            );
            SdlGameControllerButtonBind result = new SdlGameControllerButtonBind();
            result.bindType = (SdlGameControllerBindType) dumb.bindType;
            result.value.hat.hat = dumb.unionVal0;
            result.value.hat.hat_mask = dumb.unionVal1;
            return result;
        }

        /* gamecontroller refers to an SDL_GameController* */
        /// <summary>
        ///     Sdls the game controller get axis using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The short</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern short SDL_GameControllerGetAxis(
            IntPtr gamecontroller,
            SdlGameControllerAxis axis
        );

        /// <summary>
        ///     Internals the sdl game controller get button from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller button</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetButtonFromString", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe SdlGameControllerButton INTERNAL_SDL_GameControllerGetButtonFromString(
            byte* pchString
        );

        /// <summary>
        ///     Sdls the game controller get button from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller button</returns>
        public static unsafe SdlGameControllerButton SDL_GameControllerGetButtonFromString(
            string pchString
        )
        {
            int utf8PchStringBufSize = Utf8Size(pchString);
            byte* utf8PchString = stackalloc byte[utf8PchStringBufSize];
            return INTERNAL_SDL_GameControllerGetButtonFromString(
                Utf8Encode(pchString, utf8PchString, utf8PchStringBufSize)
            );
        }

        /// <summary>
        ///     Internals the sdl game controller get string for button using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetStringForButton", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerGetStringForButton(
            SdlGameControllerButton button
        );

        /// <summary>
        ///     Sdls the game controller get string for button using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerGetStringForButton(
            SdlGameControllerButton button
        )
            => UTF8_ToManaged(
                INTERNAL_SDL_GameControllerGetStringForButton(button)
            );

        /* gamecontroller refers to an SDL_GameController* */
        /// <summary>
        ///     Internals the sdl game controller get bind for button using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="button">The button</param>
        /// <returns>The internal sdl game controller button bind</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetBindForButton", CallingConvention = CallingConvention.Cdecl)]
        private static extern InternalSdlGameControllerButtonBind INTERNAL_SDL_GameControllerGetBindForButton(
            IntPtr gamecontroller,
            SdlGameControllerButton button
        );

        /// <summary>
        ///     Sdls the game controller get bind for button using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="button">The button</param>
        /// <returns>The result</returns>
        public static SdlGameControllerButtonBind SDL_GameControllerGetBindForButton(
            IntPtr gamecontroller,
            SdlGameControllerButton button
        )
        {
            // This is guaranteed to never be null
            InternalSdlGameControllerButtonBind dumb = INTERNAL_SDL_GameControllerGetBindForButton(
                gamecontroller,
                button
            );
            SdlGameControllerButtonBind result = new SdlGameControllerButtonBind();
            result.bindType = (SdlGameControllerBindType) dumb.bindType;
            result.value.hat.hat = dumb.unionVal0;
            result.value.hat.hat_mask = dumb.unionVal1;
            return result;
        }

        /* gamecontroller refers to an SDL_GameController* */
        /// <summary>
        ///     Sdls the game controller get button using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_GameControllerGetButton(
            IntPtr gamecontroller,
            SdlGameControllerButton button
        );

        /* gamecontroller refers to an SDL_GameController*.
         * Only available in 2.0.9 or higher.
         */
        /// <summary>
        ///     Sdls the game controller rumble using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="lowFrequencyRumble">The low frequency rumble</param>
        /// <param name="highFrequencyRumble">The high frequency rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerRumble(
            IntPtr gamecontroller,
            ushort lowFrequencyRumble,
            ushort highFrequencyRumble,
            uint durationMs
        );

        /* gamecontroller refers to an SDL_GameController*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Sdls the game controller rumble triggers using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="leftRumble">The left rumble</param>
        /// <param name="rightRumble">The right rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerRumbleTriggers(
            IntPtr gamecontroller,
            ushort leftRumble,
            ushort rightRumble,
            uint durationMs
        );

        /* gamecontroller refers to an SDL_GameController* */
        /// <summary>
        ///     Sdls the game controller close using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GameControllerClose(
            IntPtr gamecontroller
        );

        /* gamecontroller refers to an SDL_GameController*
         * Only available in 2.0.18 or higher.
         */
        /// <summary>
        ///     Internals the sdl game controller get apple sf symbols name for button using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="button">The button</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetAppleSFSymbolsNameForButton", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerGetAppleSFSymbolsNameForButton(
            IntPtr gamecontroller,
            SdlGameControllerButton button
        );

        /// <summary>
        ///     Sdls the game controller get apple sf symbols name for button using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="button">The button</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerGetAppleSFSymbolsNameForButton(
            IntPtr gamecontroller,
            SdlGameControllerButton button
        )
            => UTF8_ToManaged(
                INTERNAL_SDL_GameControllerGetAppleSFSymbolsNameForButton(gamecontroller, button)
            );

        /* gamecontroller refers to an SDL_GameController*
         * Only available in 2.0.18 or higher.
         */
        /// <summary>
        ///     Internals the sdl game controller get apple sf symbols name for axis using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetAppleSFSymbolsNameForAxis", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerGetAppleSFSymbolsNameForAxis(
            IntPtr gamecontroller,
            SdlGameControllerAxis axis
        );

        /// <summary>
        ///     Sdls the game controller get apple sf symbols name for axis using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerGetAppleSFSymbolsNameForAxis(
            IntPtr gamecontroller,
            SdlGameControllerAxis axis
        )
            => UTF8_ToManaged(
                INTERNAL_SDL_GameControllerGetAppleSFSymbolsNameForAxis(gamecontroller, axis)
            );

        /* int refers to an SDL_JoystickID, IntPtr to an SDL_GameController*.
         * Only available in 2.0.4 or higher.
         */
        /// <summary>
        ///     Sdls the game controller from instance id using the specified joyid
        /// </summary>
        /// <param name="joyid">The joyid</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GameControllerFromInstanceID(int joyid);

        /* Only available in 2.0.11 or higher. */
        /// <summary>
        ///     Sdls the game controller type for index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The sdl game controller type</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlGameControllerType SDL_GameControllerTypeForIndex(
            int joystickIndex
        );

        /* IntPtr refers to an SDL_GameController*.
         * Only available in 2.0.11 or higher.
         */
        /// <summary>
        ///     Sdls the game controller get type using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The sdl game controller type</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlGameControllerType SDL_GameControllerGetType(
            IntPtr gamecontroller
        );

        /* IntPtr refers to an SDL_GameController*.
         * Only available in 2.0.11 or higher.
         */
        /// <summary>
        ///     Sdls the game controller from player index using the specified player index
        /// </summary>
        /// <param name="playerIndex">The player index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GameControllerFromPlayerIndex(
            int playerIndex
        );

        /* IntPtr refers to an SDL_GameController*.
         * Only available in 2.0.11 or higher.
         */
        /// <summary>
        ///     Sdls the game controller set player index using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="playerIndex">The player index</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GameControllerSetPlayerIndex(
            IntPtr gamecontroller,
            int playerIndex
        );

        /* gamecontroller refers to an SDL_GameController*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Sdls the game controller has led using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GameControllerHasLED(
            IntPtr gamecontroller
        );

        /* gamecontroller refers to an SDL_GameController*.
         * Only available in 2.0.18 or higher.
         */
        /// <summary>
        ///     Sdls the game controller has rumble using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GameControllerHasRumble(
            IntPtr gamecontroller
        );

        /* gamecontroller refers to an SDL_GameController*.
         * Only available in 2.0.18 or higher.
         */
        /// <summary>
        ///     Sdls the game controller has rumble triggers using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GameControllerHasRumbleTriggers(
            IntPtr gamecontroller
        );

        /* gamecontroller refers to an SDL_GameController*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Sdls the game controller set led using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerSetLED(
            IntPtr gamecontroller,
            byte red,
            byte green,
            byte blue
        );

        /* gamecontroller refers to an SDL_GameController*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Sdls the game controller has axis using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GameControllerHasAxis(
            IntPtr gamecontroller,
            SdlGameControllerAxis axis
        );

        /* gamecontroller refers to an SDL_GameController*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Sdls the game controller has button using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="button">The button</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GameControllerHasButton(
            IntPtr gamecontroller,
            SdlGameControllerButton button
        );

        /* gamecontroller refers to an SDL_GameController*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Sdls the game controller get num touchpads using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerGetNumTouchpads(
            IntPtr gamecontroller
        );

        /* gamecontroller refers to an SDL_GameController*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Sdls the game controller get num touchpad fingers using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="touchpad">The touchpad</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerGetNumTouchpadFingers(
            IntPtr gamecontroller,
            int touchpad
        );

        /* gamecontroller refers to an SDL_GameController*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Sdls the game controller get touchpad finger using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="touchpad">The touchpad</param>
        /// <param name="finger">The finger</param>
        /// <param name="state">The state</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="pressure">The pressure</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerGetTouchpadFinger(
            IntPtr gamecontroller,
            int touchpad,
            int finger,
            out byte state,
            out float x,
            out float y,
            out float pressure
        );

        /* gamecontroller refers to an SDL_GameController*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Sdls the game controller has sensor using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GameControllerHasSensor(
            IntPtr gamecontroller,
            SdlSensorType type
        );

        /* gamecontroller refers to an SDL_GameController*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Sdls the game controller set sensor enabled using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="type">The type</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerSetSensorEnabled(
            IntPtr gamecontroller,
            SdlSensorType type,
            SdlBool enabled
        );

        /* gamecontroller refers to an SDL_GameController*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Sdls the game controller is sensor enabled using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GameControllerIsSensorEnabled(
            IntPtr gamecontroller,
            SdlSensorType type
        );

        /* gamecontroller refers to an SDL_GameController*.
         * data refers to a float*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Sdls the game controller get sensor data using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="type">The type</param>
        /// <param name="data">The data</param>
        /// <param name="numValues">The num values</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerGetSensorData(
            IntPtr gamecontroller,
            SdlSensorType type,
            IntPtr data,
            int numValues
        );

        /* gamecontroller refers to an SDL_GameController*.
         * Only available in 2.0.16 or higher.
         */
        /// <summary>
        ///     Sdls the game controller get sensor data rate using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="type">The type</param>
        /// <returns>The float</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float SDL_GameControllerGetSensorDataRate(
            IntPtr gamecontroller,
            SdlSensorType type
        );

        /* gamecontroller refers to an SDL_GameController*.
         * data refers to a const void*.
         * Only available in 2.0.16 or higher.
         */
        /// <summary>
        ///     Sdls the game controller send effect using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="data">The data</param>
        /// <param name="size">The size</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerSendEffect(
            IntPtr gamecontroller,
            IntPtr data,
            int size
        );

        #endregion

        #region SDL_haptic.h

        /* SDL_HapticEffect type */
        /// <summary>
        ///     The sdl haptic constant
        /// </summary>
        public const ushort SdlHapticConstant = 1 << 0;

        /// <summary>
        ///     The sdl haptic sine
        /// </summary>
        public const ushort SdlHapticSine = 1 << 1;

        /// <summary>
        ///     The sdl haptic leftright
        /// </summary>
        public const ushort SdlHapticLeftright = 1 << 2;

        /// <summary>
        ///     The sdl haptic triangle
        /// </summary>
        public const ushort SdlHapticTriangle = 1 << 3;

        /// <summary>
        ///     The sdl haptic sawtoothup
        /// </summary>
        public const ushort SdlHapticSawtoothup = 1 << 4;

        /// <summary>
        ///     The sdl haptic sawtoothdown
        /// </summary>
        public const ushort SdlHapticSawtoothdown = 1 << 5;

        /// <summary>
        ///     The sdl haptic spring
        /// </summary>
        public const ushort SdlHapticSpring = 1 << 7;

        /// <summary>
        ///     The sdl haptic damper
        /// </summary>
        public const ushort SdlHapticDamper = 1 << 8;

        /// <summary>
        ///     The sdl haptic inertia
        /// </summary>
        public const ushort SdlHapticInertia = 1 << 9;

        /// <summary>
        ///     The sdl haptic friction
        /// </summary>
        public const ushort SdlHapticFriction = 1 << 10;

        /// <summary>
        ///     The sdl haptic custom
        /// </summary>
        public const ushort SdlHapticCustom = 1 << 11;

        /// <summary>
        ///     The sdl haptic gain
        /// </summary>
        public const ushort SdlHapticGain = 1 << 12;

        /// <summary>
        ///     The sdl haptic autocenter
        /// </summary>
        public const ushort SdlHapticAutocenter = 1 << 13;

        /// <summary>
        ///     The sdl haptic status
        /// </summary>
        public const ushort SdlHapticStatus = 1 << 14;

        /// <summary>
        ///     The sdl haptic pause
        /// </summary>
        public const ushort SdlHapticPause = 1 << 15;

        /* SDL_HapticDirection type */
        /// <summary>
        ///     The sdl haptic polar
        /// </summary>
        public const byte SdlHapticPolar = 0;

        /// <summary>
        ///     The sdl haptic cartesian
        /// </summary>
        public const byte SdlHapticCartesian = 1;

        /// <summary>
        ///     The sdl haptic spherical
        /// </summary>
        public const byte SdlHapticSpherical = 2;

        /// <summary>
        ///     The sdl haptic steering axis
        /// </summary>
        public const byte SdlHapticSteeringAxis = 3; /* Requires >= 2.0.14 */

        /* SDL_HapticRunEffect */
        /// <summary>
        ///     The sdl haptic infinity
        /// </summary>
        public const uint SdlHapticInfinity = 4294967295U;

        /// <summary>
        ///     The sdl hapticdirection
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SdlHapticDirection
        {
            /// <summary>
            ///     The type
            /// </summary>
            public byte type;

            /// <summary>
            ///     The dir
            /// </summary>
            public fixed int dir[3];
        }

        /// <summary>
        ///     The sdl hapticconstant
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlHapticConstant
        {
            // Header
            /// <summary>
            ///     The type
            /// </summary>
            public ushort type;

            /// <summary>
            ///     The direction
            /// </summary>
            public SdlHapticDirection direction;

            // Replay
            /// <summary>
            ///     The length
            /// </summary>
            public uint length;

            /// <summary>
            ///     The delay
            /// </summary>
            public ushort delay;

            // Trigger
            /// <summary>
            ///     The button
            /// </summary>
            public ushort button;

            /// <summary>
            ///     The interval
            /// </summary>
            public ushort interval;

            // Constant
            /// <summary>
            ///     The level
            /// </summary>
            public short level;

            // Envelope
            /// <summary>
            ///     The attack length
            /// </summary>
            public ushort attack_length;

            /// <summary>
            ///     The attack level
            /// </summary>
            public ushort attack_level;

            /// <summary>
            ///     The fade length
            /// </summary>
            public ushort fade_length;

            /// <summary>
            ///     The fade level
            /// </summary>
            public ushort fade_level;
        }

        /// <summary>
        ///     The sdl hapticperiodic
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlHapticPeriodic
        {
            // Header
            /// <summary>
            ///     The type
            /// </summary>
            public ushort type;

            /// <summary>
            ///     The direction
            /// </summary>
            public SdlHapticDirection direction;

            // Replay
            /// <summary>
            ///     The length
            /// </summary>
            public uint length;

            /// <summary>
            ///     The delay
            /// </summary>
            public ushort delay;

            // Trigger
            /// <summary>
            ///     The button
            /// </summary>
            public ushort button;

            /// <summary>
            ///     The interval
            /// </summary>
            public ushort interval;

            // Periodic
            /// <summary>
            ///     The period
            /// </summary>
            public ushort period;

            /// <summary>
            ///     The magnitude
            /// </summary>
            public short magnitude;

            /// <summary>
            ///     The offset
            /// </summary>
            public short offset;

            /// <summary>
            ///     The phase
            /// </summary>
            public ushort phase;

            // Envelope
            /// <summary>
            ///     The attack length
            /// </summary>
            public ushort attack_length;

            /// <summary>
            ///     The attack level
            /// </summary>
            public ushort attack_level;

            /// <summary>
            ///     The fade length
            /// </summary>
            public ushort fade_length;

            /// <summary>
            ///     The fade level
            /// </summary>
            public ushort fade_level;
        }

        /// <summary>
        ///     The sdl hapticcondition
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SdlHapticCondition
        {
            // Header
            /// <summary>
            ///     The type
            /// </summary>
            public ushort type;

            /// <summary>
            ///     The direction
            /// </summary>
            public SdlHapticDirection direction;

            // Replay
            /// <summary>
            ///     The length
            /// </summary>
            public uint length;

            /// <summary>
            ///     The delay
            /// </summary>
            public ushort delay;

            // Trigger
            /// <summary>
            ///     The button
            /// </summary>
            public ushort button;

            /// <summary>
            ///     The interval
            /// </summary>
            public ushort interval;

            // Condition
            /// <summary>
            ///     The right sat
            /// </summary>
            public fixed ushort right_sat[3];

            /// <summary>
            ///     The left sat
            /// </summary>
            public fixed ushort left_sat[3];

            /// <summary>
            ///     The right coeff
            /// </summary>
            public fixed short right_coeff[3];

            /// <summary>
            ///     The left coeff
            /// </summary>
            public fixed short left_coeff[3];

            /// <summary>
            ///     The deadband
            /// </summary>
            public fixed ushort deadband[3];

            /// <summary>
            ///     The center
            /// </summary>
            public fixed short center[3];
        }

        /// <summary>
        ///     The sdl hapticramp
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlHapticRamp
        {
            // Header
            /// <summary>
            ///     The type
            /// </summary>
            public ushort type;

            /// <summary>
            ///     The direction
            /// </summary>
            public SdlHapticDirection direction;

            // Replay
            /// <summary>
            ///     The length
            /// </summary>
            public uint length;

            /// <summary>
            ///     The delay
            /// </summary>
            public ushort delay;

            // Trigger
            /// <summary>
            ///     The button
            /// </summary>
            public ushort button;

            /// <summary>
            ///     The interval
            /// </summary>
            public ushort interval;

            // Ramp
            /// <summary>
            ///     The start
            /// </summary>
            public short start;

            /// <summary>
            ///     The end
            /// </summary>
            public short end;

            // Envelope
            /// <summary>
            ///     The attack length
            /// </summary>
            public ushort attack_length;

            /// <summary>
            ///     The attack level
            /// </summary>
            public ushort attack_level;

            /// <summary>
            ///     The fade length
            /// </summary>
            public ushort fade_length;

            /// <summary>
            ///     The fade level
            /// </summary>
            public ushort fade_level;
        }

        /// <summary>
        ///     The sdl hapticleftright
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlHapticLeftRight
        {
            // Header
            /// <summary>
            ///     The type
            /// </summary>
            public ushort type;

            // Replay
            /// <summary>
            ///     The length
            /// </summary>
            public uint length;

            // Rumble
            /// <summary>
            ///     The large magnitude
            /// </summary>
            public ushort large_magnitude;

            /// <summary>
            ///     The small magnitude
            /// </summary>
            public ushort small_magnitude;
        }

        /// <summary>
        ///     The sdl hapticcustom
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlHapticCustom
        {
            // Header
            /// <summary>
            ///     The type
            /// </summary>
            public ushort type;

            /// <summary>
            ///     The direction
            /// </summary>
            public SdlHapticDirection direction;

            // Replay
            /// <summary>
            ///     The length
            /// </summary>
            public uint length;

            /// <summary>
            ///     The delay
            /// </summary>
            public ushort delay;

            // Trigger
            /// <summary>
            ///     The button
            /// </summary>
            public ushort button;

            /// <summary>
            ///     The interval
            /// </summary>
            public ushort interval;

            // Custom
            /// <summary>
            ///     The channels
            /// </summary>
            public byte channels;

            /// <summary>
            ///     The period
            /// </summary>
            public ushort period;

            /// <summary>
            ///     The samples
            /// </summary>
            public ushort samples;

            /// <summary>
            ///     The data
            /// </summary>
            public IntPtr data; // Uint16*

            // Envelope
            /// <summary>
            ///     The attack length
            /// </summary>
            public ushort attack_length;

            /// <summary>
            ///     The attack level
            /// </summary>
            public ushort attack_level;

            /// <summary>
            ///     The fade length
            /// </summary>
            public ushort fade_length;

            /// <summary>
            ///     The fade level
            /// </summary>
            public ushort fade_level;
        }

        /// <summary>
        ///     The sdl hapticeffect
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct SdlHapticEffect
        {
            /// <summary>
            ///     The type
            /// </summary>
            [FieldOffset(0)] public ushort type;

            /// <summary>
            ///     The constant
            /// </summary>
            [FieldOffset(0)] public SdlHapticConstant constant;

            /// <summary>
            ///     The periodic
            /// </summary>
            [FieldOffset(0)] public SdlHapticPeriodic periodic;

            /// <summary>
            ///     The condition
            /// </summary>
            [FieldOffset(0)] public SdlHapticCondition condition;

            /// <summary>
            ///     The ramp
            /// </summary>
            [FieldOffset(0)] public SdlHapticRamp ramp;

            /// <summary>
            ///     The leftright
            /// </summary>
            [FieldOffset(0)] public SdlHapticLeftRight leftright;

            /// <summary>
            ///     The custom
            /// </summary>
            [FieldOffset(0)] public SdlHapticCustom custom;
        }

        /* haptic refers to an SDL_Haptic* */
        /// <summary>
        ///     Sdls the haptic close using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_HapticClose(IntPtr haptic);

        /* haptic refers to an SDL_Haptic* */
        /// <summary>
        ///     Sdls the haptic destroy effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_HapticDestroyEffect(
            IntPtr haptic,
            int effect
        );

        /* haptic refers to an SDL_Haptic* */
        /// <summary>
        ///     Sdls the haptic effect supported using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticEffectSupported(
            IntPtr haptic,
            ref SdlHapticEffect effect
        );

        /* haptic refers to an SDL_Haptic* */
        /// <summary>
        ///     Sdls the haptic get effect status using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticGetEffectStatus(
            IntPtr haptic,
            int effect
        );

        /* haptic refers to an SDL_Haptic* */
        /// <summary>
        ///     Sdls the haptic index using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticIndex(IntPtr haptic);

        /* haptic refers to an SDL_Haptic* */
        /// <summary>
        ///     Internals the sdl haptic name using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_HapticName(int deviceIndex);

        /// <summary>
        ///     Sdls the haptic name using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The string</returns>
        public static string SDL_HapticName(int deviceIndex) => UTF8_ToManaged(INTERNAL_SDL_HapticName(deviceIndex));

        /* haptic refers to an SDL_Haptic* */
        /// <summary>
        ///     Sdls the haptic new effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticNewEffect(
            IntPtr haptic,
            ref SdlHapticEffect effect
        );

        /* haptic refers to an SDL_Haptic* */
        /// <summary>
        ///     Sdls the haptic num axes using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticNumAxes(IntPtr haptic);

        /* haptic refers to an SDL_Haptic* */
        /// <summary>
        ///     Sdls the haptic num effects using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticNumEffects(IntPtr haptic);

        /* haptic refers to an SDL_Haptic* */
        /// <summary>
        ///     Sdls the haptic num effects playing using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticNumEffectsPlaying(IntPtr haptic);

        /* IntPtr refers to an SDL_Haptic* */
        /// <summary>
        ///     Sdls the haptic open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_HapticOpen(int deviceIndex);

        /// <summary>
        ///     Sdls the haptic opened using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticOpened(int deviceIndex);

        /* IntPtr refers to an SDL_Haptic*, joystick to an SDL_Joystick* */
        /// <summary>
        ///     Sdls the haptic open from joystick using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_HapticOpenFromJoystick(
            IntPtr joystick
        );

        /* IntPtr refers to an SDL_Haptic* */
        /// <summary>
        ///     Sdls the haptic open from mouse
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_HapticOpenFromMouse();

        /* haptic refers to an SDL_Haptic* */
        /// <summary>
        ///     Sdls the haptic pause using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticPause(IntPtr haptic);

        /* haptic refers to an SDL_Haptic* */
        /// <summary>
        ///     Sdls the haptic query using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_HapticQuery(IntPtr haptic);

        /* haptic refers to an SDL_Haptic* */
        /// <summary>
        ///     Sdls the haptic rumble init using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticRumbleInit(IntPtr haptic);

        /* haptic refers to an SDL_Haptic* */
        /// <summary>
        ///     Sdls the haptic rumble play using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="strength">The strength</param>
        /// <param name="length">The length</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticRumblePlay(
            IntPtr haptic,
            float strength,
            uint length
        );

        /* haptic refers to an SDL_Haptic* */
        /// <summary>
        ///     Sdls the haptic rumble stop using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticRumbleStop(IntPtr haptic);

        /* haptic refers to an SDL_Haptic* */
        /// <summary>
        ///     Sdls the haptic rumble supported using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticRumbleSupported(IntPtr haptic);

        /* haptic refers to an SDL_Haptic* */
        /// <summary>
        ///     Sdls the haptic run effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <param name="iterations">The iterations</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticRunEffect(
            IntPtr haptic,
            int effect,
            uint iterations
        );

        /* haptic refers to an SDL_Haptic* */
        /// <summary>
        ///     Sdls the haptic set autocenter using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="autocenter">The autocenter</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticSetAutocenter(
            IntPtr haptic,
            int autocenter
        );

        /* haptic refers to an SDL_Haptic* */
        /// <summary>
        ///     Sdls the haptic set gain using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="gain">The gain</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticSetGain(
            IntPtr haptic,
            int gain
        );

        /* haptic refers to an SDL_Haptic* */
        /// <summary>
        ///     Sdls the haptic stop all using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticStopAll(IntPtr haptic);

        /* haptic refers to an SDL_Haptic* */
        /// <summary>
        ///     Sdls the haptic stop effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticStopEffect(
            IntPtr haptic,
            int effect
        );

        /* haptic refers to an SDL_Haptic* */
        /// <summary>
        ///     Sdls the haptic unpause using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticUnpause(IntPtr haptic);

        /* haptic refers to an SDL_Haptic* */
        /// <summary>
        ///     Sdls the haptic update effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <param name="data">The data</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticUpdateEffect(
            IntPtr haptic,
            int effect,
            ref SdlHapticEffect data
        );

        /* joystick refers to an SDL_Joystick* */
        /// <summary>
        ///     Sdls the joystick is haptic using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickIsHaptic(IntPtr joystick);

        /// <summary>
        ///     Sdls the mouse is haptic
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_MouseIsHaptic();

        /// <summary>
        ///     Sdls the num haptics
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_NumHaptics();

        #endregion

        #region SDL_sensor.h

        /* This region is only available in 2.0.9 or higher. */

        /// <summary>
        ///     The sdl sensortype enum
        /// </summary>
        public enum SdlSensorType
        {
            /// <summary>
            ///     The sdl sensor invalid sdl sensortype
            /// </summary>
            SdlSensorInvalid = -1,

            /// <summary>
            ///     The sdl sensor unknown sdl sensortype
            /// </summary>
            SdlSensorUnknown,

            /// <summary>
            ///     The sdl sensor accel sdl sensortype
            /// </summary>
            SdlSensorAccel,

            /// <summary>
            ///     The sdl sensor gyro sdl sensortype
            /// </summary>
            SdlSensorGyro
        }

        /// <summary>
        ///     The sdl standard gravity
        /// </summary>
        public const float SdlStandardGravity = 9.80665f;

        /// <summary>
        ///     Sdls the num sensors
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_NumSensors();

        /// <summary>
        ///     Internals the sdl sensor get device name using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorGetDeviceName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_SensorGetDeviceName(int deviceIndex);

        /// <summary>
        ///     Sdls the sensor get device name using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The string</returns>
        public static string SDL_SensorGetDeviceName(int deviceIndex) => UTF8_ToManaged(INTERNAL_SDL_SensorGetDeviceName(deviceIndex));

        /// <summary>
        ///     Sdls the sensor get device type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl sensor type</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlSensorType SDL_SensorGetDeviceType(int deviceIndex);

        /// <summary>
        ///     Sdls the sensor get device non portable type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SensorGetDeviceNonPortableType(int deviceIndex);

        /// <summary>
        ///     Sdls the sensor get device instance id using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SensorGetDeviceInstanceID(int deviceIndex);

        /* IntPtr refers to an SDL_Sensor* */
        /// <summary>
        ///     Sdls the sensor open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_SensorOpen(int deviceIndex);

        /* IntPtr refers to an SDL_Sensor* */
        /// <summary>
        ///     Sdls the sensor from instance id using the specified instance id
        /// </summary>
        /// <param name="instanceId">The instance id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_SensorFromInstanceID(
            int instanceId
        );

        /* sensor refers to an SDL_Sensor* */
        /// <summary>
        ///     Internals the sdl sensor get name using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorGetName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_SensorGetName(IntPtr sensor);

        /// <summary>
        ///     Sdls the sensor get name using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The string</returns>
        public static string SDL_SensorGetName(IntPtr sensor) => UTF8_ToManaged(INTERNAL_SDL_SensorGetName(sensor));

        /* sensor refers to an SDL_Sensor* */
        /// <summary>
        ///     Sdls the sensor get type using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The sdl sensor type</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlSensorType SDL_SensorGetType(IntPtr sensor);

        /* sensor refers to an SDL_Sensor* */
        /// <summary>
        ///     Sdls the sensor get non portable type using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SensorGetNonPortableType(IntPtr sensor);

        /* sensor refers to an SDL_Sensor* */
        /// <summary>
        ///     Sdls the sensor get instance id using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SensorGetInstanceID(IntPtr sensor);

        /* sensor refers to an SDL_Sensor* */
        /// <summary>
        ///     Sdls the sensor get data using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <param name="data">The data</param>
        /// <param name="numValues">The num values</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SensorGetData(
            IntPtr sensor,
            float[] data,
            int numValues
        );

        /* sensor refers to an SDL_Sensor* */
        /// <summary>
        ///     Sdls the sensor close using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SensorClose(IntPtr sensor);

        /// <summary>
        ///     Sdls the sensor update
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SensorUpdate();

        /* Only available in 2.0.14 or higher. */
        /// <summary>
        ///     Sdls the lock sensors
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LockSensors();

        /* Only available in 2.0.14 or higher. */
        /// <summary>
        ///     Sdls the unlock sensors
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockSensors();

        #endregion

        #region SDL_audio.h

        /// <summary>
        ///     The sdl audio mask bitsize
        /// </summary>
        public const ushort SdlAudioMaskBitsize = 0xFF;

        /// <summary>
        ///     The sdl audio mask datatype
        /// </summary>
        public const ushort SdlAudioMaskDatatype = 1 << 8;

        /// <summary>
        ///     The sdl audio mask endian
        /// </summary>
        public const ushort SdlAudioMaskEndian = 1 << 12;

        /// <summary>
        ///     The sdl audio mask signed
        /// </summary>
        public const ushort SdlAudioMaskSigned = 1 << 15;

        /// <summary>
        ///     Sdls the audio bitsize using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The ushort</returns>
        public static ushort SDL_AUDIO_BITSIZE(ushort x) => (ushort) (x & SdlAudioMaskBitsize);

        /// <summary>
        ///     Describes whether sdl audio isfloat
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SDL_AUDIO_ISFLOAT(ushort x) => (x & SdlAudioMaskDatatype) != 0;

        /// <summary>
        ///     Describes whether sdl audio isbigendian
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SDL_AUDIO_ISBIGENDIAN(ushort x) => (x & SdlAudioMaskEndian) != 0;

        /// <summary>
        ///     Describes whether sdl audio issigned
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SDL_AUDIO_ISSIGNED(ushort x) => (x & SdlAudioMaskSigned) != 0;

        /// <summary>
        ///     Describes whether sdl audio isint
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SDL_AUDIO_ISINT(ushort x) => (x & SdlAudioMaskDatatype) == 0;

        /// <summary>
        ///     Describes whether sdl audio islittleendian
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SDL_AUDIO_ISLITTLEENDIAN(ushort x) => (x & SdlAudioMaskEndian) == 0;

        /// <summary>
        ///     Describes whether sdl audio isunsigned
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SDL_AUDIO_ISUNSIGNED(ushort x) => (x & SdlAudioMaskSigned) == 0;

        /// <summary>
        ///     The audio u8
        /// </summary>
        public const ushort AudioU8 = 0x0008;

        /// <summary>
        ///     The audio s8
        /// </summary>
        public const ushort AudioS8 = 0x8008;

        /// <summary>
        ///     The audio u16lsb
        /// </summary>
        public const ushort AudioU16Lsb = 0x0010;

        /// <summary>
        ///     The audio s16lsb
        /// </summary>
        public const ushort AudioS16Lsb = 0x8010;

        /// <summary>
        ///     The audio u16msb
        /// </summary>
        public const ushort AudioU16Msb = 0x1010;

        /// <summary>
        ///     The audio s16msb
        /// </summary>
        public const ushort AudioS16Msb = 0x9010;

        /// <summary>
        ///     The audio u16lsb
        /// </summary>
        public const ushort AudioU16 = AudioU16Lsb;

        /// <summary>
        ///     The audio s16lsb
        /// </summary>
        public const ushort AudioS16 = AudioS16Lsb;

        /// <summary>
        ///     The audio s32lsb
        /// </summary>
        public const ushort AudioS32Lsb = 0x8020;

        /// <summary>
        ///     The audio s32msb
        /// </summary>
        public const ushort AudioS32Msb = 0x9020;

        /// <summary>
        ///     The audio s32lsb
        /// </summary>
        public const ushort AudioS32 = AudioS32Lsb;

        /// <summary>
        ///     The audio f32lsb
        /// </summary>
        public const ushort AudioF32Lsb = 0x8120;

        /// <summary>
        ///     The audio f32msb
        /// </summary>
        public const ushort AudioF32Msb = 0x9120;

        /// <summary>
        ///     The audio f32lsb
        /// </summary>
        public const ushort AudioF32 = AudioF32Lsb;

        /// <summary>
        ///     The audio u16msb
        /// </summary>
        public static readonly ushort AudioU16Sys =
            BitConverter.IsLittleEndian ? AudioU16Lsb : AudioU16Msb;

        /// <summary>
        ///     The audio s16msb
        /// </summary>
        public static readonly ushort AudioS16Sys =
            BitConverter.IsLittleEndian ? AudioS16Lsb : AudioS16Msb;

        /// <summary>
        ///     The audio s32msb
        /// </summary>
        public static readonly ushort AudioS32Sys =
            BitConverter.IsLittleEndian ? AudioS32Lsb : AudioS32Msb;

        /// <summary>
        ///     The audio f32msb
        /// </summary>
        public static readonly ushort AudioF32Sys =
            BitConverter.IsLittleEndian ? AudioF32Lsb : AudioF32Msb;

        /// <summary>
        ///     The sdl audio allow frequency change
        /// </summary>
        public const uint SdlAudioAllowFrequencyChange = 0x00000001;

        /// <summary>
        ///     The sdl audio allow format change
        /// </summary>
        public const uint SdlAudioAllowFormatChange = 0x00000002;

        /// <summary>
        ///     The sdl audio allow channels change
        /// </summary>
        public const uint SdlAudioAllowChannelsChange = 0x00000004;

        /// <summary>
        ///     The sdl audio allow samples change
        /// </summary>
        public const uint SdlAudioAllowSamplesChange = 0x00000008;

        /// <summary>
        ///     The sdl audio allow samples change
        /// </summary>
        public const uint SdlAudioAllowAnyChange = SdlAudioAllowFrequencyChange |
                                                       SdlAudioAllowFormatChange |
                                                       SdlAudioAllowChannelsChange |
                                                       SdlAudioAllowSamplesChange;

        /// <summary>
        ///     The sdl mix maxvolume
        /// </summary>
        public const int SdlMixMaxvolume = 128;

        /// <summary>
        ///     The sdl audiostatus enum
        /// </summary>
        public enum SdlAudioStatus
        {
            /// <summary>
            ///     The sdl audio stopped sdl audiostatus
            /// </summary>
            SdlAudioStopped,

            /// <summary>
            ///     The sdl audio playing sdl audiostatus
            /// </summary>
            SdlAudioPlaying,

            /// <summary>
            ///     The sdl audio paused sdl audiostatus
            /// </summary>
            SdlAudioPaused
        }

        /// <summary>
        ///     The sdl audiospec
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlAudioSpec
        {
            /// <summary>
            ///     The freq
            /// </summary>
            public int freq;

            /// <summary>
            ///     The format
            /// </summary>
            public ushort format; // SDL_AudioFormat

            /// <summary>
            ///     The channels
            /// </summary>
            public byte channels;

            /// <summary>
            ///     The silence
            /// </summary>
            public byte silence;

            /// <summary>
            ///     The samples
            /// </summary>
            public ushort samples;

            /// <summary>
            ///     The size
            /// </summary>
            public uint size;

            /// <summary>
            ///     The callback
            /// </summary>
            public SdlAudioCallback callback;

            /// <summary>
            ///     The userdata
            /// </summary>
            public IntPtr userdata; // void*
        }

        /* userdata refers to a void*, stream to a Uint8 */
        /// <summary>
        ///     The sdl audiocallback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SdlAudioCallback(
            IntPtr userdata,
            IntPtr stream,
            int len
        );

        /// <summary>
        ///     Internals the sdl audio init using the specified driver name
        /// </summary>
        /// <param name="driverName">The driver name</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AudioInit", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int INTERNAL_SDL_AudioInit(
            byte* driverName
        );

        /// <summary>
        ///     Sdls the audio init using the specified driver name
        /// </summary>
        /// <param name="driverName">The driver name</param>
        /// <returns>The int</returns>
        public static unsafe int SDL_AudioInit(string driverName)
        {
            int utf8DriverNameBufSize = Utf8Size(driverName);
            byte* utf8DriverName = stackalloc byte[utf8DriverNameBufSize];
            return INTERNAL_SDL_AudioInit(
                Utf8Encode(driverName, utf8DriverName, utf8DriverNameBufSize)
            );
        }

        /// <summary>
        ///     Sdls the audio quit
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_AudioQuit();

        /// <summary>
        ///     Sdls the close audio
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_CloseAudio();

        /* dev refers to an SDL_AudioDeviceID */
        /// <summary>
        ///     Sdls the close audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_CloseAudioDevice(uint dev);

        /* audio_buf refers to a malloc()'d buffer from SDL_LoadWAV */
        /// <summary>
        ///     Sdls the free wav using the specified audio buf
        /// </summary>
        /// <param name="audioBuf">The audio buf</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeWAV(IntPtr audioBuf);

        /// <summary>
        ///     Internals the sdl get audio device name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="iscapture">The iscapture</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetAudioDeviceName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetAudioDeviceName(
            int index,
            int iscapture
        );

        /// <summary>
        ///     Sdls the get audio device name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="iscapture">The iscapture</param>
        /// <returns>The string</returns>
        public static string SDL_GetAudioDeviceName(
            int index,
            int iscapture
        )
            => UTF8_ToManaged(
                INTERNAL_SDL_GetAudioDeviceName(index, iscapture)
            );

        /* dev refers to an SDL_AudioDeviceID */
        /// <summary>
        ///     Sdls the get audio device status using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <returns>The sdl audio status</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlAudioStatus SDL_GetAudioDeviceStatus(
            uint dev
        );

        /// <summary>
        ///     Internals the sdl get audio driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetAudioDriver", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetAudioDriver(int index);

        /// <summary>
        ///     Sdls the get audio driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        public static string SDL_GetAudioDriver(int index) => UTF8_ToManaged(
            INTERNAL_SDL_GetAudioDriver(index)
        );

        /// <summary>
        ///     Sdls the get audio status
        /// </summary>
        /// <returns>The sdl audio status</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlAudioStatus SDL_GetAudioStatus();

        /// <summary>
        ///     Internals the sdl get current audio driver
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetCurrentAudioDriver", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetCurrentAudioDriver();

        /// <summary>
        ///     Sdls the get current audio driver
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_GetCurrentAudioDriver() => UTF8_ToManaged(INTERNAL_SDL_GetCurrentAudioDriver());

        /// <summary>
        ///     Sdls the get num audio devices using the specified iscapture
        /// </summary>
        /// <param name="iscapture">The iscapture</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumAudioDevices(int iscapture);

        /// <summary>
        ///     Sdls the get num audio drivers
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumAudioDrivers();

        /* audio_buf refers to a malloc()'d buffer, IntPtr to an SDL_AudioSpec* */
        /* THIS IS AN RWops FUNCTION! */
        /// <summary>
        ///     Internals the sdl load wav rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <param name="spec">The spec</param>
        /// <param name="audioBuf">The audio buf</param>
        /// <param name="audioLen">The audio len</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LoadWAV_RW", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_LoadWAV_RW(
            IntPtr src,
            int freesrc,
            out SdlAudioSpec spec,
            out IntPtr audioBuf,
            out uint audioLen
        );

        /// <summary>
        ///     Sdls the load wav using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="spec">The spec</param>
        /// <param name="audioBuf">The audio buf</param>
        /// <param name="audioLen">The audio len</param>
        /// <returns>The int ptr</returns>
        public static IntPtr SDL_LoadWAV(
            string file,
            out SdlAudioSpec spec,
            out IntPtr audioBuf,
            out uint audioLen
        )
        {
            IntPtr rwops = SDL_RWFromFile(file, "rb");
            return INTERNAL_SDL_LoadWAV_RW(
                rwops,
                1,
                out spec,
                out audioBuf,
                out audioLen
            );
        }

        /// <summary>
        ///     Sdls the lock audio
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LockAudio();

        /* dev refers to an SDL_AudioDeviceID */
        /// <summary>
        ///     Sdls the lock audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LockAudioDevice(uint dev);

        /// <summary>
        ///     Sdls the mix audio using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MixAudio(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)]
            byte[] dst,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)]
            byte[] src,
            uint len,
            int volume
        );

        /* format refers to an SDL_AudioFormat */
        /* This overload allows raw pointers to be passed for dst and src. */
        /// <summary>
        ///     Sdls the mix audio format using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="format">The format</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MixAudioFormat(
            IntPtr dst,
            IntPtr src,
            ushort format,
            uint len,
            int volume
        );

        /* format refers to an SDL_AudioFormat */
        /// <summary>
        ///     Sdls the mix audio format using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="format">The format</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MixAudioFormat(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)]
            byte[] dst,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)]
            byte[] src,
            ushort format,
            uint len,
            int volume
        );

        /// <summary>
        ///     Sdls the open audio using the specified desired
        /// </summary>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_OpenAudio(
            ref SdlAudioSpec desired,
            out SdlAudioSpec obtained
        );

        /// <summary>
        ///     Sdls the open audio using the specified desired
        /// </summary>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_OpenAudio(
            ref SdlAudioSpec desired,
            IntPtr obtained
        );

        /* uint refers to an SDL_AudioDeviceID */
        /* This overload allows for IntPtr.Zero (null) to be passed for device. */
        /// <summary>
        ///     Sdls the open audio device using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="iscapture">The iscapture</param>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <param name="allowedChanges">The allowed changes</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_OpenAudioDevice(
            IntPtr device,
            int iscapture,
            ref SdlAudioSpec desired,
            out SdlAudioSpec obtained,
            int allowedChanges
        );

        /* uint refers to an SDL_AudioDeviceID */
        /// <summary>
        ///     Internals the sdl open audio device using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="iscapture">The iscapture</param>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <param name="allowedChanges">The allowed changes</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_OpenAudioDevice", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe uint INTERNAL_SDL_OpenAudioDevice(
            byte* device,
            int iscapture,
            ref SdlAudioSpec desired,
            out SdlAudioSpec obtained,
            int allowedChanges
        );

        /// <summary>
        ///     Sdls the open audio device using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="iscapture">The iscapture</param>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <param name="allowedChanges">The allowed changes</param>
        /// <returns>The uint</returns>
        public static unsafe uint SDL_OpenAudioDevice(
            string device,
            int iscapture,
            ref SdlAudioSpec desired,
            out SdlAudioSpec obtained,
            int allowedChanges
        )
        {
            int utf8DeviceBufSize = Utf8Size(device);
            byte* utf8Device = stackalloc byte[utf8DeviceBufSize];
            return INTERNAL_SDL_OpenAudioDevice(
                Utf8Encode(device, utf8Device, utf8DeviceBufSize),
                iscapture,
                ref desired,
                out obtained,
                allowedChanges
            );
        }

        /// <summary>
        ///     Sdls the pause audio using the specified pause on
        /// </summary>
        /// <param name="pauseOn">The pause on</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_PauseAudio(int pauseOn);

        /* dev refers to an SDL_AudioDeviceID */
        /// <summary>
        ///     Sdls the pause audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <param name="pauseOn">The pause on</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_PauseAudioDevice(
            uint dev,
            int pauseOn
        );

        /// <summary>
        ///     Sdls the unlock audio
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockAudio();

        /* dev refers to an SDL_AudioDeviceID */
        /// <summary>
        ///     Sdls the unlock audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockAudioDevice(uint dev);

        /* dev refers to an SDL_AudioDeviceID, data to a void*
         * Only available in 2.0.4 or higher.
         */
        /// <summary>
        ///     Sdls the queue audio using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <param name="data">The data</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_QueueAudio(
            uint dev,
            IntPtr data,
            uint len
        );

        /* dev refers to an SDL_AudioDeviceID, data to a void*
         * Only available in 2.0.5 or higher.
         */
        /// <summary>
        ///     Sdls the dequeue audio using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <param name="data">The data</param>
        /// <param name="len">The len</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_DequeueAudio(
            uint dev,
            IntPtr data,
            uint len
        );

        /* dev refers to an SDL_AudioDeviceID
         * Only available in 2.0.4 or higher.
         */
        /// <summary>
        ///     Sdls the get queued audio size using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetQueuedAudioSize(uint dev);

        /* dev refers to an SDL_AudioDeviceID
         * Only available in 2.0.4 or higher.
         */
        /// <summary>
        ///     Sdls the clear queued audio using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ClearQueuedAudio(uint dev);

        /* src_format and dst_format refer to SDL_AudioFormats.
         * IntPtr refers to an SDL_AudioStream*.
         * Only available in 2.0.7 or higher.
         */
        /// <summary>
        ///     Sdls the new audio stream using the specified src format
        /// </summary>
        /// <param name="srcFormat">The src format</param>
        /// <param name="srcChannels">The src channels</param>
        /// <param name="srcRate">The src rate</param>
        /// <param name="dstFormat">The dst format</param>
        /// <param name="dstChannels">The dst channels</param>
        /// <param name="dstRate">The dst rate</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_NewAudioStream(
            ushort srcFormat,
            byte srcChannels,
            int srcRate,
            ushort dstFormat,
            byte dstChannels,
            int dstRate
        );

        /* stream refers to an SDL_AudioStream*, buf to a void*.
         * Only available in 2.0.7 or higher.
         */
        /// <summary>
        ///     Sdls the audio stream put using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="buf">The buf</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_AudioStreamPut(
            IntPtr stream,
            IntPtr buf,
            int len
        );

        /* stream refers to an SDL_AudioStream*, buf to a void*.
         * Only available in 2.0.7 or higher.
         */
        /// <summary>
        ///     Sdls the audio stream get using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="buf">The buf</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_AudioStreamGet(
            IntPtr stream,
            IntPtr buf,
            int len
        );

        /* stream refers to an SDL_AudioStream*.
         * Only available in 2.0.7 or higher.
         */
        /// <summary>
        ///     Sdls the audio stream available using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_AudioStreamAvailable(IntPtr stream);

        /* stream refers to an SDL_AudioStream*.
         * Only available in 2.0.7 or higher.
         */
        /// <summary>
        ///     Sdls the audio stream clear using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_AudioStreamClear(IntPtr stream);

        /* stream refers to an SDL_AudioStream*.
         * Only available in 2.0.7 or higher.
         */
        /// <summary>
        ///     Sdls the free audio stream using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeAudioStream(IntPtr stream);

        /* Only available in 2.0.16 or higher. */
        /// <summary>
        ///     Sdls the get audio device spec using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="iscapture">The iscapture</param>
        /// <param name="spec">The spec</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetAudioDeviceSpec(
            int index,
            int iscapture,
            out SdlAudioSpec spec
        );

        #endregion

        #region SDL_timer.h

        /* System timers rely on different OS mechanisms depending on
         * which operating system SDL2 is compiled against.
         */

        /* Compare tick values, return true if A has passed B. Introduced in SDL 2.0.1,
         * but does not require it (it was a macro).
         */
        /// <summary>
        ///     Describes whether sdl ticks passed
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The bool</returns>
        public static bool SDL_TICKS_PASSED(uint a, uint b) => (int) (b - a) <= 0;

        /* Delays the thread's processing based on the milliseconds parameter */
        /// <summary>
        ///     Sdls the delay using the specified ms
        /// </summary>
        /// <param name="ms">The ms</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Delay(uint ms);

        /* Returns the milliseconds that have passed since SDL was initialized */
        /// <summary>
        ///     Sdls the get ticks
        /// </summary>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetTicks();

        /* Returns the milliseconds that have passed since SDL was initialized
         * Only available in 2.0.18 or higher.
         */
        /// <summary>
        ///     Sdls the get ticks 64
        /// </summary>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong SDL_GetTicks64();

        /* Get the current value of the high resolution counter */
        /// <summary>
        ///     Sdls the get performance counter
        /// </summary>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong SDL_GetPerformanceCounter();

        /* Get the count per second of the high resolution counter */
        /// <summary>
        ///     Sdls the get performance frequency
        /// </summary>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong SDL_GetPerformanceFrequency();

        /* param refers to a void* */
        /// <summary>
        ///     The sdl timercallback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint SdlTimerCallback(uint interval, IntPtr param);

        /* int refers to an SDL_TimerID, param to a void* */
        /// <summary>
        ///     Sdls the add timer using the specified interval
        /// </summary>
        /// <param name="interval">The interval</param>
        /// <param name="callback">The callback</param>
        /// <param name="param">The param</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_AddTimer(
            uint interval,
            SdlTimerCallback callback,
            IntPtr param
        );

        /* id refers to an SDL_TimerID */
        /// <summary>
        ///     Sdls the remove timer using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_RemoveTimer(int id);

        #endregion

        #region SDL_system.h

        /* Windows */

        /// <summary>
        ///     The sdl windowsmessagehook
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr SdlWindowsMessageHook(
            IntPtr userdata,
            IntPtr hWnd,
            uint message,
            ulong wParam,
            long lParam
        );

        /// <summary>
        ///     Sdls the set windows message hook using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowsMessageHook(
            SdlWindowsMessageHook callback,
            IntPtr userdata
        );

        /* renderer refers to an SDL_Renderer*
         * IntPtr refers to an IDirect3DDevice9*
         * Only available in 2.0.1 or higher.
         */
        /// <summary>
        ///     Sdls the render get d 3 d 9 device using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_RenderGetD3D9Device(IntPtr renderer);

        /* renderer refers to an SDL_Renderer*
         * IntPtr refers to an ID3D11Device*
         * Only available in 2.0.16 or higher.
         */
        /// <summary>
        ///     Sdls the render get d 3 d 11 device using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_RenderGetD3D11Device(IntPtr renderer);

        /* iOS */

        /// <summary>
        ///     The sdl iphoneanimationcallback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SdlIPhoneAnimationCallback(IntPtr p);

        /// <summary>
        ///     Sdls the i phone set animation callback using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="interval">The interval</param>
        /// <param name="callback">The callback</param>
        /// <param name="callbackParam">The callback param</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_iPhoneSetAnimationCallback(
            IntPtr window, /* SDL_Window* */
            int interval,
            SdlIPhoneAnimationCallback callback,
            IntPtr callbackParam
        );

        /// <summary>
        ///     Sdls the i phone set event pump using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_iPhoneSetEventPump(SdlBool enabled);

        /* Android */

        /// <summary>
        ///     The sdl android external storage read
        /// </summary>
        public const int SdlAndroidExternalStorageRead = 0x01;

        /// <summary>
        ///     The sdl android external storage write
        /// </summary>
        public const int SdlAndroidExternalStorageWrite = 0x02;

        /* IntPtr refers to a JNIEnv* */
        /// <summary>
        ///     Sdls the android get jni env
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_AndroidGetJNIEnv();

        /* IntPtr refers to a jobject */
        /// <summary>
        ///     Sdls the android get activity
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_AndroidGetActivity();

        /// <summary>
        ///     Sdls the is android tv
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IsAndroidTV();

        /// <summary>
        ///     Sdls the is chromebook
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IsChromebook();

        /// <summary>
        ///     Sdls the is de x mode
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IsDeXMode();

        /// <summary>
        ///     Sdls the android back button
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_AndroidBackButton();

        /// <summary>
        ///     Internals the sdl android get internal storage path
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AndroidGetInternalStoragePath", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_AndroidGetInternalStoragePath();

        /// <summary>
        ///     Sdls the android get internal storage path
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_AndroidGetInternalStoragePath() => UTF8_ToManaged(
            INTERNAL_SDL_AndroidGetInternalStoragePath()
        );

        /// <summary>
        ///     Sdls the android get external storage state
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_AndroidGetExternalStorageState();

        /// <summary>
        ///     Internals the sdl android get external storage path
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AndroidGetExternalStoragePath", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_AndroidGetExternalStoragePath();

        /// <summary>
        ///     Sdls the android get external storage path
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_AndroidGetExternalStoragePath() => UTF8_ToManaged(
            INTERNAL_SDL_AndroidGetExternalStoragePath()
        );

        /// <summary>
        ///     Sdls the get android sdk version
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetAndroidSDKVersion();

        /* Only available in 2.0.14 or higher. */
        /// <summary>
        ///     Internals the sdl android request permission using the specified permission
        /// </summary>
        /// <param name="permission">The permission</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AndroidRequestPermission", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe SdlBool INTERNAL_SDL_AndroidRequestPermission(
            byte* permission
        );

        /// <summary>
        ///     Sdls the android request permission using the specified permission
        /// </summary>
        /// <param name="permission">The permission</param>
        /// <returns>The result</returns>
        public static unsafe SdlBool SDL_AndroidRequestPermission(
            string permission
        )
        {
            byte* permissionPtr = Utf8EncodeHeap(permission);
            SdlBool result = INTERNAL_SDL_AndroidRequestPermission(
                permissionPtr
            );
            Marshal.FreeHGlobal((IntPtr) permissionPtr);
            return result;
        }

        /* Only available in 2.0.16 or higher. */
        /// <summary>
        ///     Internals the sdl android show toast using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="duration">The duration</param>
        /// <param name="gravity">The gravity</param>
        /// <param name="xOffset">The offset</param>
        /// <param name="yOffset">The offset</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AndroidShowToast", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int INTERNAL_SDL_AndroidShowToast(
            byte* message,
            int duration,
            int gravity,
            int xOffset,
            int yOffset
        );

        /// <summary>
        ///     Sdls the android show toast using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="duration">The duration</param>
        /// <param name="gravity">The gravity</param>
        /// <param name="xOffset">The offset</param>
        /// <param name="yOffset">The offset</param>
        /// <returns>The result</returns>
        public static unsafe int SDL_AndroidShowToast(
            string message,
            int duration,
            int gravity,
            int xOffset,
            int yOffset
        )
        {
            byte* messagePtr = Utf8EncodeHeap(message);
            int result = INTERNAL_SDL_AndroidShowToast(
                messagePtr,
                duration,
                gravity,
                xOffset,
                yOffset
            );
            Marshal.FreeHGlobal((IntPtr) messagePtr);
            return result;
        }

        /* WinRT */

        /// <summary>
        ///     The sdl winrt devicefamily enum
        /// </summary>
        public enum SdlWinRtDeviceFamily
        {
            /// <summary>
            ///     The sdl winrt devicefamily unknown sdl winrt devicefamily
            /// </summary>
            SdlWinrtDevicefamilyUnknown,

            /// <summary>
            ///     The sdl winrt devicefamily desktop sdl winrt devicefamily
            /// </summary>
            SdlWinrtDevicefamilyDesktop,

            /// <summary>
            ///     The sdl winrt devicefamily mobile sdl winrt devicefamily
            /// </summary>
            SdlWinrtDevicefamilyMobile,

            /// <summary>
            ///     The sdl winrt devicefamily xbox sdl winrt devicefamily
            /// </summary>
            SdlWinrtDevicefamilyXbox
        }

        /// <summary>
        ///     Sdls the win rt get device family
        /// </summary>
        /// <returns>The sdl win rt device family</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlWinRtDeviceFamily SDL_WinRTGetDeviceFamily();

        /// <summary>
        ///     Sdls the is tablet
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IsTablet();

        #endregion

        #region SDL_syswm.h

        /// <summary>
        ///     The sdl syswm type enum
        /// </summary>
        public enum SdlSyswmType
        {
            /// <summary>
            ///     The sdl syswm unknown sdl syswm type
            /// </summary>
            SdlSyswmUnknown,

            /// <summary>
            ///     The sdl syswm windows sdl syswm type
            /// </summary>
            SdlSyswmWindows,

            /// <summary>
            ///     The sdl syswm x11 sdl syswm type
            /// </summary>
            SdlSyswmX11,

            /// <summary>
            ///     The sdl syswm directfb sdl syswm type
            /// </summary>
            SdlSyswmDirectfb,

            /// <summary>
            ///     The sdl syswm cocoa sdl syswm type
            /// </summary>
            SdlSyswmCocoa,

            /// <summary>
            ///     The sdl syswm uikit sdl syswm type
            /// </summary>
            SdlSyswmUikit,

            /// <summary>
            ///     The sdl syswm wayland sdl syswm type
            /// </summary>
            SdlSyswmWayland,

            /// <summary>
            ///     The sdl syswm mir sdl syswm type
            /// </summary>
            SdlSyswmMir,

            /// <summary>
            ///     The sdl syswm winrt sdl syswm type
            /// </summary>
            SdlSyswmWinrt,

            /// <summary>
            ///     The sdl syswm android sdl syswm type
            /// </summary>
            SdlSyswmAndroid,

            /// <summary>
            ///     The sdl syswm vivante sdl syswm type
            /// </summary>
            SdlSyswmVivante,

            /// <summary>
            ///     The sdl syswm os2 sdl syswm type
            /// </summary>
            SdlSyswmOs2,

            /// <summary>
            ///     The sdl syswm haiku sdl syswm type
            /// </summary>
            SdlSyswmHaiku,

            /// <summary>
            ///     The sdl syswm kmsdrm sdl syswm type
            /// </summary>
            SdlSyswmKmsdrm /* requires >= 2.0.16 */
        }

        // FIXME: I wish these weren't public...
        /// <summary>
        ///     The internal windows wminfo
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct InternalWindowsWminfo
        {
            /// <summary>
            ///     The window
            /// </summary>
            public IntPtr window; // Refers to an HWND

            /// <summary>
            ///     The hdc
            /// </summary>
            public IntPtr hdc; // Refers to an HDC

            /// <summary>
            ///     The hinstance
            /// </summary>
            public IntPtr hinstance; // Refers to an HINSTANCE
        }

        /// <summary>
        ///     The internal winrt wminfo
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct InternalWinrtWminfo
        {
            /// <summary>
            ///     The window
            /// </summary>
            public IntPtr window; // Refers to an IInspectable*
        }

        /// <summary>
        ///     The internal x11 wminfo
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct InternalX11Wminfo
        {
            /// <summary>
            ///     The display
            /// </summary>
            public IntPtr display; // Refers to a Display*

            /// <summary>
            ///     The window
            /// </summary>
            public IntPtr window; // Refers to a Window (XID, use ToInt64!)
        }

        /// <summary>
        ///     The internal directfb wminfo
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct InternalDirectfbWminfo
        {
            /// <summary>
            ///     The dfb
            /// </summary>
            public IntPtr dfb; // Refers to an IDirectFB*

            /// <summary>
            ///     The window
            /// </summary>
            public IntPtr window; // Refers to an IDirectFBWindow*

            /// <summary>
            ///     The surface
            /// </summary>
            public IntPtr surface; // Refers to an IDirectFBSurface*
        }

        /// <summary>
        ///     The internal cocoa wminfo
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct InternalCocoaWminfo
        {
            /// <summary>
            ///     The window
            /// </summary>
            public IntPtr window; // Refers to an NSWindow*
        }

        /// <summary>
        ///     The internal uikit wminfo
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct InternalUikitWminfo
        {
            /// <summary>
            ///     The window
            /// </summary>
            public IntPtr window; // Refers to a UIWindow*

            /// <summary>
            ///     The framebuffer
            /// </summary>
            public uint framebuffer;

            /// <summary>
            ///     The colorbuffer
            /// </summary>
            public uint colorbuffer;

            /// <summary>
            ///     The resolve framebuffer
            /// </summary>
            public uint resolveFramebuffer;
        }

        /// <summary>
        ///     The internal wayland wminfo
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct InternalWaylandWminfo
        {
            /// <summary>
            ///     The display
            /// </summary>
            public IntPtr display; // Refers to a wl_display*

            /// <summary>
            ///     The surface
            /// </summary>
            public IntPtr surface; // Refers to a wl_surface*

            /// <summary>
            ///     The shell surface
            /// </summary>
            public IntPtr shell_surface; // Refers to a wl_shell_surface*

            /// <summary>
            ///     The egl window
            /// </summary>
            public IntPtr egl_window; // Refers to an egl_window*, requires >= 2.0.16

            /// <summary>
            ///     The xdg surface
            /// </summary>
            public IntPtr xdg_surface; // Refers to an xdg_surface*, requires >= 2.0.16

            /// <summary>
            ///     The xdg toplevel
            /// </summary>
            public IntPtr xdg_toplevel; // Referes to an xdg_toplevel*, requires >= 2.0.18
        }

        /// <summary>
        ///     The internal mir wminfo
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct InternalMirWminfo
        {
            /// <summary>
            ///     The connection
            /// </summary>
            public IntPtr connection; // Refers to a MirConnection*

            /// <summary>
            ///     The surface
            /// </summary>
            public IntPtr surface; // Refers to a MirSurface*
        }

        /// <summary>
        ///     The internal android wminfo
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct InternalAndroidWminfo
        {
            /// <summary>
            ///     The window
            /// </summary>
            public IntPtr window; // Refers to an ANativeWindow

            /// <summary>
            ///     The surface
            /// </summary>
            public IntPtr surface; // Refers to an EGLSurface
        }

        /// <summary>
        ///     The internal vivante wminfo
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct InternalVivanteWminfo
        {
            /// <summary>
            ///     The display
            /// </summary>
            public IntPtr display; // Refers to an EGLNativeDisplayType

            /// <summary>
            ///     The window
            /// </summary>
            public IntPtr window; // Refers to an EGLNativeWindowType
        }

        /* Only available in 2.0.14 or higher. */
        /// <summary>
        ///     The internal os2 wminfo
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct InternalOs2Wminfo
        {
            /// <summary>
            ///     The hwnd
            /// </summary>
            public IntPtr hwnd; // Refers to an HWND

            /// <summary>
            ///     The hwnd frame
            /// </summary>
            public IntPtr hwndFrame; // Refers to an HWND
        }

        /* Only available in 2.0.16 or higher. */
        /// <summary>
        ///     The internal kmsdrm wminfo
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct InternalKmsdrmWminfo
        {
            /// <summary>
            ///     The dev index
            /// </summary>
            private int dev_index;

            /// <summary>
            ///     The drm fd
            /// </summary>
            private int drm_fd;

            /// <summary>
            ///     The gbm dev
            /// </summary>
            private IntPtr gbm_dev; // Refers to a gbm_device*
        }

        /// <summary>
        ///     The internal syswmdriverunion
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct InternalSysWmDriverUnion
        {
            /// <summary>
            ///     The win
            /// </summary>
            [FieldOffset(0)] public InternalWindowsWminfo win;

            /// <summary>
            ///     The winrt
            /// </summary>
            [FieldOffset(0)] public InternalWinrtWminfo winrt;

            /// <summary>
            ///     The 11
            /// </summary>
            [FieldOffset(0)] public InternalX11Wminfo x11;

            /// <summary>
            ///     The dfb
            /// </summary>
            [FieldOffset(0)] public InternalDirectfbWminfo dfb;

            /// <summary>
            ///     The cocoa
            /// </summary>
            [FieldOffset(0)] public InternalCocoaWminfo cocoa;

            /// <summary>
            ///     The uikit
            /// </summary>
            [FieldOffset(0)] public InternalUikitWminfo uikit;

            /// <summary>
            ///     The wl
            /// </summary>
            [FieldOffset(0)] public InternalWaylandWminfo wl;

            /// <summary>
            ///     The mir
            /// </summary>
            [FieldOffset(0)] public InternalMirWminfo mir;

            /// <summary>
            ///     The android
            /// </summary>
            [FieldOffset(0)] public InternalAndroidWminfo android;

            /// <summary>
            ///     The os
            /// </summary>
            [FieldOffset(0)] public InternalOs2Wminfo os2;

            /// <summary>
            ///     The vivante
            /// </summary>
            [FieldOffset(0)] public InternalVivanteWminfo vivante;

            /// <summary>
            ///     The ksmdrm
            /// </summary>
            [FieldOffset(0)] public InternalKmsdrmWminfo ksmdrm;
            // private int dummy;
        }

        /// <summary>
        ///     The sdl syswminfo
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlSysWMinfo
        {
            /// <summary>
            ///     The version
            /// </summary>
            public SdlVersion version;

            /// <summary>
            ///     The subsystem
            /// </summary>
            public SdlSyswmType subsystem;

            /// <summary>
            ///     The info
            /// </summary>
            public InternalSysWmDriverUnion info;
        }

        /* window refers to an SDL_Window* */
        /// <summary>
        ///     Sdls the get window wm info using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="info">The info</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GetWindowWMInfo(
            IntPtr window,
            ref SdlSysWMinfo info
        );

        #endregion

        #region SDL_filesystem.h

        /* Only available in 2.0.1 or higher. */
        /// <summary>
        ///     Internals the sdl get base path
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetBasePath", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetBasePath();

        /// <summary>
        ///     Sdls the get base path
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_GetBasePath() => UTF8_ToManaged(INTERNAL_SDL_GetBasePath(), true);

        /* Only available in 2.0.1 or higher. */
        /// <summary>
        ///     Internals the sdl get pref path using the specified org
        /// </summary>
        /// <param name="org">The org</param>
        /// <param name="app">The app</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPrefPath", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe IntPtr INTERNAL_SDL_GetPrefPath(
            byte* org,
            byte* app
        );

        /// <summary>
        ///     Sdls the get pref path using the specified org
        /// </summary>
        /// <param name="org">The org</param>
        /// <param name="app">The app</param>
        /// <returns>The string</returns>
        public static unsafe string SDL_GetPrefPath(string org, string app)
        {
            int utf8OrgBufSize = Utf8Size(org);
            byte* utf8Org = stackalloc byte[utf8OrgBufSize];

            int utf8AppBufSize = Utf8Size(app);
            byte* utf8App = stackalloc byte[utf8AppBufSize];

            return UTF8_ToManaged(
                INTERNAL_SDL_GetPrefPath(
                    Utf8Encode(org, utf8Org, utf8OrgBufSize),
                    Utf8Encode(app, utf8App, utf8AppBufSize)
                ),
                true
            );
        }

        #endregion

        #region SDL_power.h

        /// <summary>
        ///     The sdl powerstate enum
        /// </summary>
        public enum SdlPowerState
        {
            /// <summary>
            ///     The sdl powerstate unknown sdl powerstate
            /// </summary>
            SdlPowerstateUnknown = 0,

            /// <summary>
            ///     The sdl powerstate on battery sdl powerstate
            /// </summary>
            SdlPowerstateOnBattery,

            /// <summary>
            ///     The sdl powerstate no battery sdl powerstate
            /// </summary>
            SdlPowerstateNoBattery,

            /// <summary>
            ///     The sdl powerstate charging sdl powerstate
            /// </summary>
            SdlPowerstateCharging,

            /// <summary>
            ///     The sdl powerstate charged sdl powerstate
            /// </summary>
            SdlPowerstateCharged
        }

        /// <summary>
        ///     Sdls the get power info using the specified secs
        /// </summary>
        /// <param name="secs">The secs</param>
        /// <param name="pct">The pct</param>
        /// <returns>The sdl power state</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlPowerState SDL_GetPowerInfo(
            out int secs,
            out int pct
        );

        #endregion

        #region SDL_cpuinfo.h

        /// <summary>
        ///     Sdls the get cpu count
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetCPUCount();

        /// <summary>
        ///     Sdls the get cpu cache line size
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetCPUCacheLineSize();

        /// <summary>
        ///     Sdls the has rdtsc
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasRDTSC();

        /// <summary>
        ///     Sdls the has alti vec
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasAltiVec();

        /// <summary>
        ///     Sdls the has mmx
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasMMX();

        /// <summary>
        ///     Sdls the has 3 d now
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_Has3DNow();

        /// <summary>
        ///     Sdls the has sse
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasSSE();

        /// <summary>
        ///     Sdls the has sse 2
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasSSE2();

        /// <summary>
        ///     Sdls the has sse 3
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasSSE3();

        /// <summary>
        ///     Sdls the has sse 41
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasSSE41();

        /// <summary>
        ///     Sdls the has sse 42
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasSSE42();

        /// <summary>
        ///     Sdls the has avx
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasAVX();

        /// <summary>
        ///     Sdls the has avx 2
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasAVX2();

        /// <summary>
        ///     Sdls the has avx 512 f
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasAVX512F();

        /// <summary>
        ///     Sdls the has neon
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasNEON();

        /* Only available in 2.0.1 or higher. */
        /// <summary>
        ///     Sdls the get system ram
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetSystemRAM();

        /* Only available in SDL 2.0.10 or higher. */
        /// <summary>
        ///     Sdls the simd get alignment
        /// </summary>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_SIMDGetAlignment();

        /* Only available in SDL 2.0.10 or higher. */
        /// <summary>
        ///     Sdls the simd alloc using the specified len
        /// </summary>
        /// <param name="len">The len</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_SIMDAlloc(uint len);

        /* Only available in SDL 2.0.14 or higher. */
        /// <summary>
        ///     Sdls the simd realloc using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        /// <param name="len">The len</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_SIMDRealloc(IntPtr ptr, uint len);

        /* Only available in SDL 2.0.10 or higher. */
        /// <summary>
        ///     Sdls the simd free using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SIMDFree(IntPtr ptr);

        /* Only available in SDL 2.0.11 or higher. */
        /// <summary>
        ///     Sdls the has armsimd
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_HasARMSIMD();

        #endregion

        #region SDL_locale.h

        /// <summary>
        ///     The sdl locale
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlLocale
        {
            /// <summary>
            ///     The language
            /// </summary>
            private IntPtr language;

            /// <summary>
            ///     The country
            /// </summary>
            private IntPtr country;
        }

        /* IntPtr refers to an SDL_Locale*.
         * Only available in 2.0.14 or higher.
         */
        /// <summary>
        ///     Sdls the get preferred locales
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetPreferredLocales();

        #endregion

        #region SDL_misc.h

        /* Only available in 2.0.14 or higher. */
        /// <summary>
        ///     Internals the sdl open url using the specified url
        /// </summary>
        /// <param name="url">The url</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_OpenURL", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int INTERNAL_SDL_OpenURL(byte* url);

        /// <summary>
        ///     Sdls the open url using the specified url
        /// </summary>
        /// <param name="url">The url</param>
        /// <returns>The result</returns>
        public static unsafe int SDL_OpenURL(string url)
        {
            byte* urlPtr = Utf8EncodeHeap(url);
            int result = INTERNAL_SDL_OpenURL(urlPtr);
            Marshal.FreeHGlobal((IntPtr) urlPtr);
            return result;
        }

        #endregion
    }
}