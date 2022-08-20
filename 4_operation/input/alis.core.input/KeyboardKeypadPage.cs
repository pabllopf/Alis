// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyboardKeypadPage.cs
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

using System.ComponentModel;

namespace Alis.Core.Input
{
#pragma warning disable CS0108
    /// <summary>
    ///     Keyboard/Keypad Usage Page.
    /// </summary>
    [Description("Keyboard/Keypad Usage Page")]
    public enum KeyboardKeypadPage : uint
    {
        /// <summary>
        ///     Undefined Usage.
        /// </summary>
        [Description("Undefined")] Undefined = 0x00070000,

        /// <summary>
        ///     ErrorRollOver Usage.
        /// </summary>
        [Description("ErrorRollOver")] ErrorRollOver = 0x00070001,

        /// <summary>
        ///     POSTFail Usage.
        /// </summary>
        [Description("POSTFail")] POSTFail = 0x00070002,

        /// <summary>
        ///     ErrorUndefined Usage.
        /// </summary>
        [Description("ErrorUndefined")] ErrorUndefined = 0x00070003,

        /// <summary>
        ///     a A Usage.
        /// </summary>
        [Description("a A")] AA = 0x00070004,

        /// <summary>
        ///     b B Usage.
        /// </summary>
        [Description("b B")] BB = 0x00070005,

        /// <summary>
        ///     c C Usage.
        /// </summary>
        [Description("c C")] CC = 0x00070006,

        /// <summary>
        ///     d D Usage.
        /// </summary>
        [Description("d D")] DD = 0x00070007,

        /// <summary>
        ///     e E Usage.
        /// </summary>
        [Description("e E")] EE = 0x00070008,

        /// <summary>
        ///     f F Usage.
        /// </summary>
        [Description("f F")] FF = 0x00070009,

        /// <summary>
        ///     g G Usage.
        /// </summary>
        [Description("g G")] GG = 0x0007000a,

        /// <summary>
        ///     h H Usage.
        /// </summary>
        [Description("h H")] HH = 0x0007000b,

        /// <summary>
        ///     i I Usage.
        /// </summary>
        [Description("i I")] II = 0x0007000c,

        /// <summary>
        ///     j J Usage.
        /// </summary>
        [Description("j J")] JJ = 0x0007000d,

        /// <summary>
        ///     k K Usage.
        /// </summary>
        [Description("k K")] KK = 0x0007000e,

        /// <summary>
        ///     l L Usage.
        /// </summary>
        [Description("l L")] LL = 0x0007000f,

        /// <summary>
        ///     m M Usage.
        /// </summary>
        [Description("m M")] MM = 0x00070010,

        /// <summary>
        ///     n N Usage.
        /// </summary>
        [Description("n N")] NN = 0x00070011,

        /// <summary>
        ///     o O Usage.
        /// </summary>
        [Description("o O")] OO = 0x00070012,

        /// <summary>
        ///     p P Usage.
        /// </summary>
        [Description("p P")] PP = 0x00070013,

        /// <summary>
        ///     q Q Usage.
        /// </summary>
        [Description("q Q")] QQ = 0x00070014,

        /// <summary>
        ///     r R Usage.
        /// </summary>
        [Description("r R")] RR = 0x00070015,

        /// <summary>
        ///     s S Usage.
        /// </summary>
        [Description("s S")] SS = 0x00070016,

        /// <summary>
        ///     t T Usage.
        /// </summary>
        [Description("t T")] TT = 0x00070017,

        /// <summary>
        ///     u U Usage.
        /// </summary>
        [Description("u U")] UU = 0x00070018,

        /// <summary>
        ///     v V Usage.
        /// </summary>
        [Description("v V")] VV = 0x00070019,

        /// <summary>
        ///     w W Usage.
        /// </summary>
        [Description("w W")] WW = 0x0007001a,

        /// <summary>
        ///     x X Usage.
        /// </summary>
        [Description("x X")] XX = 0x0007001b,

        /// <summary>
        ///     y Y Usage.
        /// </summary>
        [Description("y Y")] YY = 0x0007001c,

        /// <summary>
        ///     z Z Usage.
        /// </summary>
        [Description("z Z")] ZZ = 0x0007001d,

        /// <summary>
        ///     1 ! Usage.
        /// </summary>
        [Description("1 !")] KeyboardKeypad_1 = 0x0007001e,

        /// <summary>
        ///     2 @ Usage.
        /// </summary>
        [Description("2 @")] KeyboardKeypad_2 = 0x0007001f,

        /// <summary>
        ///     3 # Usage.
        /// </summary>
        [Description("3 #")] KeyboardKeypad_3 = 0x00070020,

        /// <summary>
        ///     4 $ Usage.
        /// </summary>
        [Description("4 $")] KeyboardKeypad_4 = 0x00070021,

        /// <summary>
        ///     5 % Usage.
        /// </summary>
        [Description("5 %")] KeyboardKeypad_5 = 0x00070022,

        /// <summary>
        ///     6 ^ Usage.
        /// </summary>
        [Description("6 ^")] KeyboardKeypad_6 = 0x00070023,

        /// <summary>
        ///     7 & Usage.
        /// </summary>
        [Description("7 &")] KeyboardKeypad_7 = 0x00070024,

        /// <summary>
        ///     8 * Usage.
        /// </summary>
        [Description("8 *")] KeyboardKeypad_8 = 0x00070025,

        /// <summary>
        ///     9 ( Usage.
        /// </summary>
        [Description("9 (")] KeyboardKeypad_9 = 0x00070026,

        /// <summary>
        ///     0 ) Usage.
        /// </summary>
        [Description("0 )")] KeyboardKeypad_0 = 0x00070027,

        /// <summary>
        ///     Enter Usage.
        /// </summary>
        [Description("Enter")] Enter = 0x00070028,

        /// <summary>
        ///     Esc Usage.
        /// </summary>
        [Description("Esc")] Esc = 0x00070029,

        /// <summary>
        ///     Backspace Usage.
        /// </summary>
        [Description("Backspace")] Backspace = 0x0007002a,

        /// <summary>
        ///     Tab Usage.
        /// </summary>
        [Description("Tab")] Tab = 0x0007002b,

        /// <summary>
        ///     Space Usage.
        /// </summary>
        [Description("Space")] Space = 0x0007002c,

        /// <summary>
        ///     - _ Usage.
        /// </summary>
        [Description("- _")] _ = 0x0007002d,

        /// <summary>
        ///     = + Usage.
        /// </summary>
        [Description("= +")] KeyboardKeypad_ = 0x0007002e,

        /// <summary>
        ///     [ { Usage.
        /// </summary>
        [Description("[ {")] KeyboardKeypad_10 = 0x0007002f,

        /// <summary>
        ///     ] } Usage.
        /// </summary>
        [Description("] }")] KeyboardKeypad_11 = 0x00070030,

        /// <summary>
        ///     \ | Usage.
        /// </summary>
        [Description("\\ |")] KeyboardKeypad_12 = 0x00070031,

        /// <summary>
        ///     # ~ Usage.
        /// </summary>
        [Description("# ~")] KeyboardKeypad_13 = 0x00070032,

        /// <summary>
        ///     ; : Usage.
        /// </summary>
        [Description("; :")] KeyboardKeypad_14 = 0x00070033,

        /// <summary>
        ///     ' " Usage.
        /// </summary>
        [Description("' \"")] KeyboardKeypad_15 = 0x00070034,

        /// <summary>
        ///     ` ´ Usage.
        /// </summary>
        [Description("` ´")] KeyboardKeypad_16 = 0x00070035,

        /// <summary>
        ///     , < Usage.
        /// </summary>
        [Description(", <")] KeyboardKeypad_17 = 0x00070036,

        /// <summary>
        ///     . > Usage.
        /// </summary>
        [Description(". >")] KeyboardKeypad_18 = 0x00070037,

        /// <summary>
        ///     / ? Usage.
        /// </summary>
        [Description("/ ?")] KeyboardKeypad_19 = 0x00070038,

        /// <summary>
        ///     CapsLock Usage.
        /// </summary>
        [Description("CapsLock")] CapsLock = 0x00070039,

        /// <summary>
        ///     F1 Usage.
        /// </summary>
        [Description("F1")] F1 = 0x0007003a,

        /// <summary>
        ///     F2 Usage.
        /// </summary>
        [Description("F2")] F2 = 0x0007003b,

        /// <summary>
        ///     F3 Usage.
        /// </summary>
        [Description("F3")] F3 = 0x0007003c,

        /// <summary>
        ///     F4 Usage.
        /// </summary>
        [Description("F4")] F4 = 0x0007003d,

        /// <summary>
        ///     F5 Usage.
        /// </summary>
        [Description("F5")] F5 = 0x0007003e,

        /// <summary>
        ///     F6 Usage.
        /// </summary>
        [Description("F6")] F6 = 0x0007003f,

        /// <summary>
        ///     F7 Usage.
        /// </summary>
        [Description("F7")] F7 = 0x00070040,

        /// <summary>
        ///     F8 Usage.
        /// </summary>
        [Description("F8")] F8 = 0x00070041,

        /// <summary>
        ///     F9 Usage.
        /// </summary>
        [Description("F9")] F9 = 0x00070042,

        /// <summary>
        ///     F10 Usage.
        /// </summary>
        [Description("F10")] F10 = 0x00070043,

        /// <summary>
        ///     F11 Usage.
        /// </summary>
        [Description("F11")] F11 = 0x00070044,

        /// <summary>
        ///     F12 Usage.
        /// </summary>
        [Description("F12")] F12 = 0x00070045,

        /// <summary>
        ///     PrintScreen SysRq Usage.
        /// </summary>
        [Description("PrintScreen SysRq")] PrintScreenSysRq = 0x00070046,

        /// <summary>
        ///     ScrollLock Usage.
        /// </summary>
        [Description("ScrollLock")] ScrollLock = 0x00070047,

        /// <summary>
        ///     Pause Usage.
        /// </summary>
        [Description("Pause")] Pause = 0x00070048,

        /// <summary>
        ///     Insert Usage.
        /// </summary>
        [Description("Insert")] Insert = 0x00070049,

        /// <summary>
        ///     Home Usage.
        /// </summary>
        [Description("Home")] Home = 0x0007004a,

        /// <summary>
        ///     PageUp Usage.
        /// </summary>
        [Description("PageUp")] PageUp = 0x0007004b,

        /// <summary>
        ///     Delete Usage.
        /// </summary>
        [Description("Delete")] Delete = 0x0007004c,

        /// <summary>
        ///     End Usage.
        /// </summary>
        [Description("End")] End = 0x0007004d,

        /// <summary>
        ///     PageDown Usage.
        /// </summary>
        [Description("PageDown")] PageDown = 0x0007004e,

        /// <summary>
        ///     RightArrow Usage.
        /// </summary>
        [Description("RightArrow")] RightArrow = 0x0007004f,

        /// <summary>
        ///     LeftArrow Usage.
        /// </summary>
        [Description("LeftArrow")] LeftArrow = 0x00070050,

        /// <summary>
        ///     DownArrow Usage.
        /// </summary>
        [Description("DownArrow")] DownArrow = 0x00070051,

        /// <summary>
        ///     UpArrow Usage.
        /// </summary>
        [Description("UpArrow")] UpArrow = 0x00070052,

        /// <summary>
        ///     NumLock Clear Usage.
        /// </summary>
        [Description("NumLock Clear")] NumLockClear = 0x00070053,

        /// <summary>
        ///     Keypad / Usage.
        /// </summary>
        [Description("Keypad /")] Keypad = 0x00070054,

        /// <summary>
        ///     Keypad * Usage.
        /// </summary>
        [Description("Keypad *")] Keypad2 = 0x00070055,

        /// <summary>
        ///     Keypad - Usage.
        /// </summary>
        [Description("Keypad -")] Keypad3 = 0x00070056,

        /// <summary>
        ///     Keypad + Usage.
        /// </summary>
        [Description("Keypad +")] Keypad4 = 0x00070057,

        /// <summary>
        ///     Keypad Enter Usage.
        /// </summary>
        [Description("Keypad Enter")] KeypadEnter = 0x00070058,

        /// <summary>
        ///     Keypad 1 Usage.
        /// </summary>
        [Description("Keypad 1")] Keypad1 = 0x00070059,

        /// <summary>
        ///     Keypad 2 Usage.
        /// </summary>
        [Description("Keypad 2")] Keypad22 = 0x0007005a,

        /// <summary>
        ///     Keypad 3 Usage.
        /// </summary>
        [Description("Keypad 3")] Keypad32 = 0x0007005b,

        /// <summary>
        ///     Keypad 4 Usage.
        /// </summary>
        [Description("Keypad 4")] Keypad42 = 0x0007005c,

        /// <summary>
        ///     Keypad 5 Usage.
        /// </summary>
        [Description("Keypad 5")] Keypad5 = 0x0007005d,

        /// <summary>
        ///     Keypad 6 Usage.
        /// </summary>
        [Description("Keypad 6")] Keypad6 = 0x0007005e,

        /// <summary>
        ///     Keypad 7 Usage.
        /// </summary>
        [Description("Keypad 7")] Keypad7 = 0x0007005f,

        /// <summary>
        ///     Keypad 8 Usage.
        /// </summary>
        [Description("Keypad 8")] Keypad8 = 0x00070060,

        /// <summary>
        ///     Keypad 9 Usage.
        /// </summary>
        [Description("Keypad 9")] Keypad9 = 0x00070061,

        /// <summary>
        ///     Keypad 0 Usage.
        /// </summary>
        [Description("Keypad 0")] Keypad0 = 0x00070062,

        /// <summary>
        ///     Keypad . Usage.
        /// </summary>
        [Description("Keypad .")] Keypad10 = 0x00070063,

        /// <summary>
        ///     Non-US \| Usage.
        /// </summary>
        [Description("Non-US \\|")] NonUS = 0x00070064,

        /// <summary>
        ///     Application Usage.
        /// </summary>
        [Description("Application")] Application = 0x00070065,

        /// <summary>
        ///     Power Usage.
        /// </summary>
        [Description("Power")] Power = 0x00070066,

        /// <summary>
        ///     Keypad = Usage.
        /// </summary>
        [Description("Keypad =")] Keypad11 = 0x00070067,

        /// <summary>
        ///     F13 Usage.
        /// </summary>
        [Description("F13")] F13 = 0x00070068,

        /// <summary>
        ///     F14 Usage.
        /// </summary>
        [Description("F14")] F14 = 0x00070069,

        /// <summary>
        ///     F15 Usage.
        /// </summary>
        [Description("F15")] F15 = 0x0007006a,

        /// <summary>
        ///     F16 Usage.
        /// </summary>
        [Description("F16")] F16 = 0x0007006b,

        /// <summary>
        ///     F17 Usage.
        /// </summary>
        [Description("F17")] F17 = 0x0007006c,

        /// <summary>
        ///     F18 Usage.
        /// </summary>
        [Description("F18")] F18 = 0x0007006d,

        /// <summary>
        ///     F19 Usage.
        /// </summary>
        [Description("F19")] F19 = 0x0007006e,

        /// <summary>
        ///     F20 Usage.
        /// </summary>
        [Description("F20")] F20 = 0x0007006f,

        /// <summary>
        ///     F21 Usage.
        /// </summary>
        [Description("F21")] F21 = 0x00070070,

        /// <summary>
        ///     F22 Usage.
        /// </summary>
        [Description("F22")] F22 = 0x00070071,

        /// <summary>
        ///     F23 Usage.
        /// </summary>
        [Description("F23")] F23 = 0x00070072,

        /// <summary>
        ///     F24 Usage.
        /// </summary>
        [Description("F24")] F24 = 0x00070073,

        /// <summary>
        ///     Execute Usage.
        /// </summary>
        [Description("Execute")] Execute = 0x00070074,

        /// <summary>
        ///     Help Usage.
        /// </summary>
        [Description("Help")] Help = 0x00070075,

        /// <summary>
        ///     Menu Usage.
        /// </summary>
        [Description("Menu")] Menu = 0x00070076,

        /// <summary>
        ///     Select Usage.
        /// </summary>
        [Description("Select")] Select = 0x00070077,

        /// <summary>
        ///     Stop Usage.
        /// </summary>
        [Description("Stop")] Stop = 0x00070078,

        /// <summary>
        ///     Again Usage.
        /// </summary>
        [Description("Again")] Again = 0x00070079,

        /// <summary>
        ///     Undo Usage.
        /// </summary>
        [Description("Undo")] Undo = 0x0007007a,

        /// <summary>
        ///     Cut Usage.
        /// </summary>
        [Description("Cut")] Cut = 0x0007007b,

        /// <summary>
        ///     Copy Usage.
        /// </summary>
        [Description("Copy")] Copy = 0x0007007c,

        /// <summary>
        ///     Paste Usage.
        /// </summary>
        [Description("Paste")] Paste = 0x0007007d,

        /// <summary>
        ///     Find Usage.
        /// </summary>
        [Description("Find")] Find = 0x0007007e,

        /// <summary>
        ///     Mute Usage.
        /// </summary>
        [Description("Mute")] Mute = 0x0007007f,

        /// <summary>
        ///     VolumeUp Usage.
        /// </summary>
        [Description("VolumeUp")] VolumeUp = 0x00070080,

        /// <summary>
        ///     VolumeDown Usage.
        /// </summary>
        [Description("VolumeDown")] VolumeDown = 0x00070081,

        /// <summary>
        ///     LockingCapsLock Usage.
        /// </summary>
        [Description("LockingCapsLock")] LockingCapsLock = 0x00070082,

        /// <summary>
        ///     LockingNumLock Usage.
        /// </summary>
        [Description("LockingNumLock")] LockingNumLock = 0x00070083,

        /// <summary>
        ///     LockingScrollLock Usage.
        /// </summary>
        [Description("LockingScrollLock")] LockingScrollLock = 0x00070084,

        /// <summary>
        ///     Keypad , Usage.
        /// </summary>
        [Description("Keypad ,")] Keypad12 = 0x00070085,

        /// <summary>
        ///     Keypad == Usage.
        /// </summary>
        [Description("Keypad ==")] Keypad13 = 0x00070086,

        /*
         * Range: 0x0087 -> 0x008f
         * International{n+1}
         */

        /// <summary>
        ///     International1 Usage.
        /// </summary>
        [Description("International1")] International1 = 0x00070087,

        /// <summary>
        ///     International2 Usage.
        /// </summary>
        [Description("International2")] International2 = 0x00070088,

        /// <summary>
        ///     International3 Usage.
        /// </summary>
        [Description("International3")] International3 = 0x00070089,

        /// <summary>
        ///     International4 Usage.
        /// </summary>
        [Description("International4")] International4 = 0x0007008a,

        /// <summary>
        ///     International5 Usage.
        /// </summary>
        [Description("International5")] International5 = 0x0007008b,

        /// <summary>
        ///     International6 Usage.
        /// </summary>
        [Description("International6")] International6 = 0x0007008c,

        /// <summary>
        ///     International7 Usage.
        /// </summary>
        [Description("International7")] International7 = 0x0007008d,

        /// <summary>
        ///     International8 Usage.
        /// </summary>
        [Description("International8")] International8 = 0x0007008e,

        /// <summary>
        ///     International9 Usage.
        /// </summary>
        [Description("International9")] International9 = 0x0007008f,

        /*
         * Range: 0x0090 -> 0x0098
         * LANG{n+1}
         */

        /// <summary>
        ///     LANG1 Usage.
        /// </summary>
        [Description("LANG1")] LANG1 = 0x00070090,

        /// <summary>
        ///     LANG2 Usage.
        /// </summary>
        [Description("LANG2")] LANG2 = 0x00070091,

        /// <summary>
        ///     LANG3 Usage.
        /// </summary>
        [Description("LANG3")] LANG3 = 0x00070092,

        /// <summary>
        ///     LANG4 Usage.
        /// </summary>
        [Description("LANG4")] LANG4 = 0x00070093,

        /// <summary>
        ///     LANG5 Usage.
        /// </summary>
        [Description("LANG5")] LANG5 = 0x00070094,

        /// <summary>
        ///     LANG6 Usage.
        /// </summary>
        [Description("LANG6")] LANG6 = 0x00070095,

        /// <summary>
        ///     LANG7 Usage.
        /// </summary>
        [Description("LANG7")] LANG7 = 0x00070096,

        /// <summary>
        ///     LANG8 Usage.
        /// </summary>
        [Description("LANG8")] LANG8 = 0x00070097,

        /// <summary>
        ///     LANG9 Usage.
        /// </summary>
        [Description("LANG9")] LANG9 = 0x00070098,

        /// <summary>
        ///     Alternate Erase Usage.
        /// </summary>
        [Description("Alternate Erase")] AlternateErase = 0x00070099,

        /// <summary>
        ///     SysReq Attention Usage.
        /// </summary>
        [Description("SysReq Attention")] SysReqAttention = 0x0007009a,

        /// <summary>
        ///     Cancel Usage.
        /// </summary>
        [Description("Cancel")] Cancel = 0x0007009b,

        /// <summary>
        ///     Clear Usage.
        /// </summary>
        [Description("Clear")] Clear = 0x0007009c,

        /// <summary>
        ///     Prior Usage.
        /// </summary>
        [Description("Prior")] Prior = 0x0007009d,

        /// <summary>
        ///     Return Usage.
        /// </summary>
        [Description("Return")] Return = 0x0007009e,

        /// <summary>
        ///     Separator Usage.
        /// </summary>
        [Description("Separator")] Separator = 0x0007009f,

        /// <summary>
        ///     Out Usage.
        /// </summary>
        [Description("Out")] Out = 0x000700a0,

        /// <summary>
        ///     Oper Usage.
        /// </summary>
        [Description("Oper")] Oper = 0x000700a1,

        /// <summary>
        ///     Clear Again Usage.
        /// </summary>
        [Description("Clear Again")] ClearAgain = 0x000700a2,

        /// <summary>
        ///     CrSel Props Usage.
        /// </summary>
        [Description("CrSel Props")] CrSelProps = 0x000700a3,

        /// <summary>
        ///     ExSel Usage.
        /// </summary>
        [Description("ExSel")] ExSel = 0x000700a4,

        /// <summary>
        ///     Keypad 00 Usage.
        /// </summary>
        [Description("Keypad 00")] Keypad00 = 0x000700b0,

        /// <summary>
        ///     Keypad 000 Usage.
        /// </summary>
        [Description("Keypad 000")] Keypad000 = 0x000700b1,

        /// <summary>
        ///     1000sSeparator Usage.
        /// </summary>
        [Description("1000sSeparator")] SSeparator = 0x000700b2,

        /// <summary>
        ///     DecimalSeparator Usage.
        /// </summary>
        [Description("DecimalSeparator")] DecimalSeparator = 0x000700b3,

        /// <summary>
        ///     CurrencyUnit Usage.
        /// </summary>
        [Description("CurrencyUnit")] CurrencyUnit = 0x000700b4,

        /// <summary>
        ///     CurrencySubunit Usage.
        /// </summary>
        [Description("CurrencySubunit")] CurrencySubunit = 0x000700b5,

        /// <summary>
        ///     Keypad ( Usage.
        /// </summary>
        [Description("Keypad (")] Keypad14 = 0x000700b6,

        /// <summary>
        ///     Keypad ) Usage.
        /// </summary>
        [Description("Keypad )")] Keypad15 = 0x000700b7,

        /// <summary>
        ///     Keypad { Usage.
        /// </summary>
        [Description("Keypad {")] Keypad16 = 0x000700b8,

        /// <summary>
        ///     Keypad } Usage.
        /// </summary>
        [Description("Keypad }")] Keypad17 = 0x000700b9,

        /// <summary>
        ///     Keypad Tab Usage.
        /// </summary>
        [Description("Keypad Tab")] KeypadTab = 0x000700ba,

        /// <summary>
        ///     Keypad Backspace Usage.
        /// </summary>
        [Description("Keypad Backspace")] KeypadBackspace = 0x000700bb,

        /// <summary>
        ///     Keypad A Usage.
        /// </summary>
        [Description("Keypad A")] KeypadA = 0x000700bc,

        /// <summary>
        ///     Keypad B Usage.
        /// </summary>
        [Description("Keypad B")] KeypadB = 0x000700bd,

        /// <summary>
        ///     Keypad C Usage.
        /// </summary>
        [Description("Keypad C")] KeypadC = 0x000700be,

        /// <summary>
        ///     Keypad D Usage.
        /// </summary>
        [Description("Keypad D")] KeypadD = 0x000700bf,

        /// <summary>
        ///     Keypad E Usage.
        /// </summary>
        [Description("Keypad E")] KeypadE = 0x000700c0,

        /// <summary>
        ///     Keypad F Usage.
        /// </summary>
        [Description("Keypad F")] KeypadF = 0x000700c1,

        /// <summary>
        ///     Keypad XOR Usage.
        /// </summary>
        [Description("Keypad XOR")] KeypadXOR = 0x000700c2,

        /// <summary>
        ///     Keypad ^ Usage.
        /// </summary>
        [Description("Keypad ^")] Keypad18 = 0x000700c3,

        /// <summary>
        ///     Keypad % Usage.
        /// </summary>
        [Description("Keypad %")] Keypad19 = 0x000700c4,

        /// <summary>
        ///     Keypad < Usage.
        /// </summary>
        [Description("Keypad <")] Keypad20 = 0x000700c5,

        /// <summary>
        ///     Keypad > Usage.
        /// </summary>
        [Description("Keypad >")] Keypad21 = 0x000700c6,

        /// <summary>
        ///     Keypad & Usage.
        /// </summary>
        [Description("Keypad &")] Keypad23 = 0x000700c7,

        /// <summary>
        ///     Keypad && Usage.
        /// </summary>
        [Description("Keypad &&")] Keypad24 = 0x000700c8,

        /// <summary>
        ///     Keypad | Usage.
        /// </summary>
        [Description("Keypad |")] Keypad25 = 0x000700c9,

        /// <summary>
        ///     Keypad || Usage.
        /// </summary>
        [Description("Keypad ||")] Keypad26 = 0x000700ca,

        /// <summary>
        ///     Keypad : Usage.
        /// </summary>
        [Description("Keypad :")] Keypad27 = 0x000700cb,

        /// <summary>
        ///     Keypad # Usage.
        /// </summary>
        [Description("Keypad #")] Keypad28 = 0x000700cc,

        /// <summary>
        ///     Keypad Space Usage.
        /// </summary>
        [Description("Keypad Space")] KeypadSpace = 0x000700cd,

        /// <summary>
        ///     Keypad @ Usage.
        /// </summary>
        [Description("Keypad @")] Keypad29 = 0x000700ce,

        /// <summary>
        ///     Keypad ! Usage.
        /// </summary>
        [Description("Keypad !")] Keypad30 = 0x000700cf,

        /// <summary>
        ///     Keypad MemoryStore Usage.
        /// </summary>
        [Description("Keypad MemoryStore")] KeypadMemoryStore = 0x000700d0,

        /// <summary>
        ///     Keypad MemoryRecall Usage.
        /// </summary>
        [Description("Keypad MemoryRecall")] KeypadMemoryRecall = 0x000700d1,

        /// <summary>
        ///     Keypad MemoryClear Usage.
        /// </summary>
        [Description("Keypad MemoryClear")] KeypadMemoryClear = 0x000700d2,

        /// <summary>
        ///     Keypad MemoryAdd Usage.
        /// </summary>
        [Description("Keypad MemoryAdd")] KeypadMemoryAdd = 0x000700d3,

        /// <summary>
        ///     Keypad MemorySubtract Usage.
        /// </summary>
        [Description("Keypad MemorySubtract")] KeypadMemorySubtract = 0x000700d4,

        /// <summary>
        ///     Keypad MemoryMultiply Usage.
        /// </summary>
        [Description("Keypad MemoryMultiply")] KeypadMemoryMultiply = 0x000700d5,

        /// <summary>
        ///     Keypad MemoryDivide Usage.
        /// </summary>
        [Description("Keypad MemoryDivide")] KeypadMemoryDivide = 0x000700d6,

        /// <summary>
        ///     Keypad +/- Usage.
        /// </summary>
        [Description("Keypad +/-")] Keypad31 = 0x000700d7,

        /// <summary>
        ///     Keypad Clear Usage.
        /// </summary>
        [Description("Keypad Clear")] KeypadClear = 0x000700d8,

        /// <summary>
        ///     Keypad ClearEntry Usage.
        /// </summary>
        [Description("Keypad ClearEntry")] KeypadClearEntry = 0x000700d9,

        /// <summary>
        ///     Keypad Binary Usage.
        /// </summary>
        [Description("Keypad Binary")] KeypadBinary = 0x000700da,

        /// <summary>
        ///     Keypad Octal Usage.
        /// </summary>
        [Description("Keypad Octal")] KeypadOctal = 0x000700db,

        /// <summary>
        ///     Keypad Decimal Usage.
        /// </summary>
        [Description("Keypad Decimal")] KeypadDecimal = 0x000700dc,

        /// <summary>
        ///     Keypad Hexadecimal Usage.
        /// </summary>
        [Description("Keypad Hexadecimal")] KeypadHexadecimal = 0x000700dd,

        /// <summary>
        ///     LeftCtrl Usage.
        /// </summary>
        [Description("LeftCtrl")] LeftCtrl = 0x000700e0,

        /// <summary>
        ///     LeftShift Usage.
        /// </summary>
        [Description("LeftShift")] LeftShift = 0x000700e1,

        /// <summary>
        ///     LeftAlt Usage.
        /// </summary>
        [Description("LeftAlt")] LeftAlt = 0x000700e2,

        /// <summary>
        ///     LeftGUI Usage.
        /// </summary>
        [Description("LeftGUI")] LeftGUI = 0x000700e3,

        /// <summary>
        ///     RightCtrl Usage.
        /// </summary>
        [Description("RightCtrl")] RightCtrl = 0x000700e4,

        /// <summary>
        ///     RightShift Usage.
        /// </summary>
        [Description("RightShift")] RightShift = 0x000700e5,

        /// <summary>
        ///     RightAlt Usage.
        /// </summary>
        [Description("RightAlt")] RightAlt = 0x000700e6,

        /// <summary>
        ///     RightGUI Usage.
        /// </summary>
        [Description("RightGUI")] RightGUI = 0x000700e7
    }
}