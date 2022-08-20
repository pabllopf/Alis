// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyboardKeypadUsagePage.cs
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

namespace Alis.Core.Input
{
#pragma warning disable CS0108
    /// <summary>
    ///     Base class for all usage pages.
    /// </summary>
    public sealed class KeyboardKeypadUsagePage : UsagePage
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="KeyboardKeypadUsagePage" /> class
        /// </summary>
        private KeyboardKeypadUsagePage() : base(0x0007, "KeyboardKeypad")
        {
        }

        /// <summary>
        ///     Singleton instance of KeyboardKeypad Usage Page.
        /// </summary>
        public static readonly KeyboardKeypadUsagePage Instance = new KeyboardKeypadUsagePage();

        /// <inheritdoc />
        protected override Usage CreateUsage(ushort id)
        {
            switch (id)
            {
                case 0x0000: return new Usage(this, id, "Undefined", UsageTypes.None);
                case 0x0001: return new Usage(this, id, "ErrorRollOver", UsageTypes.Sel);
                case 0x0002: return new Usage(this, id, "POSTFail", UsageTypes.Sel);
                case 0x0003: return new Usage(this, id, "ErrorUndefined", UsageTypes.Sel);
                case 0x0004: return new Usage(this, id, "a A", UsageTypes.Sel);
                case 0x0005: return new Usage(this, id, "b B", UsageTypes.Sel);
                case 0x0006: return new Usage(this, id, "c C", UsageTypes.Sel);
                case 0x0007: return new Usage(this, id, "d D", UsageTypes.Sel);
                case 0x0008: return new Usage(this, id, "e E", UsageTypes.Sel);
                case 0x0009: return new Usage(this, id, "f F", UsageTypes.Sel);
                case 0x000a: return new Usage(this, id, "g G", UsageTypes.Sel);
                case 0x000b: return new Usage(this, id, "h H", UsageTypes.Sel);
                case 0x000c: return new Usage(this, id, "i I", UsageTypes.Sel);
                case 0x000d: return new Usage(this, id, "j J", UsageTypes.Sel);
                case 0x000e: return new Usage(this, id, "k K", UsageTypes.Sel);
                case 0x000f: return new Usage(this, id, "l L", UsageTypes.Sel);
                case 0x0010: return new Usage(this, id, "m M", UsageTypes.Sel);
                case 0x0011: return new Usage(this, id, "n N", UsageTypes.Sel);
                case 0x0012: return new Usage(this, id, "o O", UsageTypes.Sel);
                case 0x0013: return new Usage(this, id, "p P", UsageTypes.Sel);
                case 0x0014: return new Usage(this, id, "q Q", UsageTypes.Sel);
                case 0x0015: return new Usage(this, id, "r R", UsageTypes.Sel);
                case 0x0016: return new Usage(this, id, "s S", UsageTypes.Sel);
                case 0x0017: return new Usage(this, id, "t T", UsageTypes.Sel);
                case 0x0018: return new Usage(this, id, "u U", UsageTypes.Sel);
                case 0x0019: return new Usage(this, id, "v V", UsageTypes.Sel);
                case 0x001a: return new Usage(this, id, "w W", UsageTypes.Sel);
                case 0x001b: return new Usage(this, id, "x X", UsageTypes.Sel);
                case 0x001c: return new Usage(this, id, "y Y", UsageTypes.Sel);
                case 0x001d: return new Usage(this, id, "z Z", UsageTypes.Sel);
                case 0x001e: return new Usage(this, id, "1 !", UsageTypes.Sel);
                case 0x001f: return new Usage(this, id, "2 @", UsageTypes.Sel);
                case 0x0020: return new Usage(this, id, "3 #", UsageTypes.Sel);
                case 0x0021: return new Usage(this, id, "4 $", UsageTypes.Sel);
                case 0x0022: return new Usage(this, id, "5 %", UsageTypes.Sel);
                case 0x0023: return new Usage(this, id, "6 ^", UsageTypes.Sel);
                case 0x0024: return new Usage(this, id, "7 &", UsageTypes.Sel);
                case 0x0025: return new Usage(this, id, "8 *", UsageTypes.Sel);
                case 0x0026: return new Usage(this, id, "9 (", UsageTypes.Sel);
                case 0x0027: return new Usage(this, id, "0 )", UsageTypes.Sel);
                case 0x0028: return new Usage(this, id, "Enter", UsageTypes.Sel);
                case 0x0029: return new Usage(this, id, "Esc", UsageTypes.Sel);
                case 0x002a: return new Usage(this, id, "Backspace", UsageTypes.Sel);
                case 0x002b: return new Usage(this, id, "Tab", UsageTypes.Sel);
                case 0x002c: return new Usage(this, id, "Space", UsageTypes.Sel);
                case 0x002d: return new Usage(this, id, "- _", UsageTypes.Sel);
                case 0x002e: return new Usage(this, id, "= +", UsageTypes.Sel);
                case 0x002f: return new Usage(this, id, "[ {", UsageTypes.Sel);
                case 0x0030: return new Usage(this, id, "] }", UsageTypes.Sel);
                case 0x0031: return new Usage(this, id, "\\ |", UsageTypes.Sel);
                case 0x0032: return new Usage(this, id, "# ~", UsageTypes.Sel);
                case 0x0033: return new Usage(this, id, "; :", UsageTypes.Sel);
                case 0x0034: return new Usage(this, id, "' \"", UsageTypes.Sel);
                case 0x0035: return new Usage(this, id, "` ´", UsageTypes.Sel);
                case 0x0036: return new Usage(this, id, ", <", UsageTypes.Sel);
                case 0x0037: return new Usage(this, id, ". >", UsageTypes.Sel);
                case 0x0038: return new Usage(this, id, "/ ?", UsageTypes.Sel);
                case 0x0039: return new Usage(this, id, "CapsLock", UsageTypes.Sel);
                case 0x003a: return new Usage(this, id, "F1", UsageTypes.Sel);
                case 0x003b: return new Usage(this, id, "F2", UsageTypes.Sel);
                case 0x003c: return new Usage(this, id, "F3", UsageTypes.Sel);
                case 0x003d: return new Usage(this, id, "F4", UsageTypes.Sel);
                case 0x003e: return new Usage(this, id, "F5", UsageTypes.Sel);
                case 0x003f: return new Usage(this, id, "F6", UsageTypes.Sel);
                case 0x0040: return new Usage(this, id, "F7", UsageTypes.Sel);
                case 0x0041: return new Usage(this, id, "F8", UsageTypes.Sel);
                case 0x0042: return new Usage(this, id, "F9", UsageTypes.Sel);
                case 0x0043: return new Usage(this, id, "F10", UsageTypes.Sel);
                case 0x0044: return new Usage(this, id, "F11", UsageTypes.Sel);
                case 0x0045: return new Usage(this, id, "F12", UsageTypes.Sel);
                case 0x0046: return new Usage(this, id, "PrintScreen SysRq", UsageTypes.Sel);
                case 0x0047: return new Usage(this, id, "ScrollLock", UsageTypes.Sel);
                case 0x0048: return new Usage(this, id, "Pause", UsageTypes.Sel);
                case 0x0049: return new Usage(this, id, "Insert", UsageTypes.Sel);
                case 0x004a: return new Usage(this, id, "Home", UsageTypes.Sel);
                case 0x004b: return new Usage(this, id, "PageUp", UsageTypes.Sel);
                case 0x004c: return new Usage(this, id, "Delete", UsageTypes.Sel);
                case 0x004d: return new Usage(this, id, "End", UsageTypes.Sel);
                case 0x004e: return new Usage(this, id, "PageDown", UsageTypes.Sel);
                case 0x004f: return new Usage(this, id, "RightArrow", UsageTypes.Sel);
                case 0x0050: return new Usage(this, id, "LeftArrow", UsageTypes.Sel);
                case 0x0051: return new Usage(this, id, "DownArrow", UsageTypes.Sel);
                case 0x0052: return new Usage(this, id, "UpArrow", UsageTypes.Sel);
                case 0x0053: return new Usage(this, id, "NumLock Clear", UsageTypes.Sel);
                case 0x0054: return new Usage(this, id, "Keypad /", UsageTypes.Sel);
                case 0x0055: return new Usage(this, id, "Keypad *", UsageTypes.Sel);
                case 0x0056: return new Usage(this, id, "Keypad -", UsageTypes.Sel);
                case 0x0057: return new Usage(this, id, "Keypad +", UsageTypes.Sel);
                case 0x0058: return new Usage(this, id, "Keypad Enter", UsageTypes.Sel);
                case 0x0059: return new Usage(this, id, "Keypad 1", UsageTypes.Sel);
                case 0x005a: return new Usage(this, id, "Keypad 2", UsageTypes.Sel);
                case 0x005b: return new Usage(this, id, "Keypad 3", UsageTypes.Sel);
                case 0x005c: return new Usage(this, id, "Keypad 4", UsageTypes.Sel);
                case 0x005d: return new Usage(this, id, "Keypad 5", UsageTypes.Sel);
                case 0x005e: return new Usage(this, id, "Keypad 6", UsageTypes.Sel);
                case 0x005f: return new Usage(this, id, "Keypad 7", UsageTypes.Sel);
                case 0x0060: return new Usage(this, id, "Keypad 8", UsageTypes.Sel);
                case 0x0061: return new Usage(this, id, "Keypad 9", UsageTypes.Sel);
                case 0x0062: return new Usage(this, id, "Keypad 0", UsageTypes.Sel);
                case 0x0063: return new Usage(this, id, "Keypad .", UsageTypes.Sel);
                case 0x0064: return new Usage(this, id, "Non-US \\|", UsageTypes.Sel);
                case 0x0065: return new Usage(this, id, "Application", UsageTypes.Sel);
                case 0x0066: return new Usage(this, id, "Power", UsageTypes.Sel);
                case 0x0067: return new Usage(this, id, "Keypad =", UsageTypes.Sel);
                case 0x0068: return new Usage(this, id, "F13", UsageTypes.Sel);
                case 0x0069: return new Usage(this, id, "F14", UsageTypes.Sel);
                case 0x006a: return new Usage(this, id, "F15", UsageTypes.Sel);
                case 0x006b: return new Usage(this, id, "F16", UsageTypes.Sel);
                case 0x006c: return new Usage(this, id, "F17", UsageTypes.Sel);
                case 0x006d: return new Usage(this, id, "F18", UsageTypes.Sel);
                case 0x006e: return new Usage(this, id, "F19", UsageTypes.Sel);
                case 0x006f: return new Usage(this, id, "F20", UsageTypes.Sel);
                case 0x0070: return new Usage(this, id, "F21", UsageTypes.Sel);
                case 0x0071: return new Usage(this, id, "F22", UsageTypes.Sel);
                case 0x0072: return new Usage(this, id, "F23", UsageTypes.Sel);
                case 0x0073: return new Usage(this, id, "F24", UsageTypes.Sel);
                case 0x0074: return new Usage(this, id, "Execute", UsageTypes.Sel);
                case 0x0075: return new Usage(this, id, "Help", UsageTypes.Sel);
                case 0x0076: return new Usage(this, id, "Menu", UsageTypes.Sel);
                case 0x0077: return new Usage(this, id, "Select", UsageTypes.Sel);
                case 0x0078: return new Usage(this, id, "Stop", UsageTypes.Sel);
                case 0x0079: return new Usage(this, id, "Again", UsageTypes.Sel);
                case 0x007a: return new Usage(this, id, "Undo", UsageTypes.Sel);
                case 0x007b: return new Usage(this, id, "Cut", UsageTypes.Sel);
                case 0x007c: return new Usage(this, id, "Copy", UsageTypes.Sel);
                case 0x007d: return new Usage(this, id, "Paste", UsageTypes.Sel);
                case 0x007e: return new Usage(this, id, "Find", UsageTypes.Sel);
                case 0x007f: return new Usage(this, id, "Mute", UsageTypes.Sel);
                case 0x0080: return new Usage(this, id, "VolumeUp", UsageTypes.Sel);
                case 0x0081: return new Usage(this, id, "VolumeDown", UsageTypes.Sel);
                case 0x0082: return new Usage(this, id, "LockingCapsLock", UsageTypes.Sel);
                case 0x0083: return new Usage(this, id, "LockingNumLock", UsageTypes.Sel);
                case 0x0084: return new Usage(this, id, "LockingScrollLock", UsageTypes.Sel);
                case 0x0085: return new Usage(this, id, "Keypad ,", UsageTypes.Sel);
                case 0x0086: return new Usage(this, id, "Keypad ==", UsageTypes.Sel);
                case 0x0087: return new Usage(this, id, "International1", UsageTypes.Sel);
                case 0x0088: return new Usage(this, id, "International2", UsageTypes.Sel);
                case 0x0089: return new Usage(this, id, "International3", UsageTypes.Sel);
                case 0x008a: return new Usage(this, id, "International4", UsageTypes.Sel);
                case 0x008b: return new Usage(this, id, "International5", UsageTypes.Sel);
                case 0x008c: return new Usage(this, id, "International6", UsageTypes.Sel);
                case 0x008d: return new Usage(this, id, "International7", UsageTypes.Sel);
                case 0x008e: return new Usage(this, id, "International8", UsageTypes.Sel);
                case 0x008f: return new Usage(this, id, "International9", UsageTypes.Sel);
                case 0x0090: return new Usage(this, id, "LANG1", UsageTypes.Sel);
                case 0x0091: return new Usage(this, id, "LANG2", UsageTypes.Sel);
                case 0x0092: return new Usage(this, id, "LANG3", UsageTypes.Sel);
                case 0x0093: return new Usage(this, id, "LANG4", UsageTypes.Sel);
                case 0x0094: return new Usage(this, id, "LANG5", UsageTypes.Sel);
                case 0x0095: return new Usage(this, id, "LANG6", UsageTypes.Sel);
                case 0x0096: return new Usage(this, id, "LANG7", UsageTypes.Sel);
                case 0x0097: return new Usage(this, id, "LANG8", UsageTypes.Sel);
                case 0x0098: return new Usage(this, id, "LANG9", UsageTypes.Sel);
                case 0x0099: return new Usage(this, id, "Alternate Erase", UsageTypes.Sel);
                case 0x009a: return new Usage(this, id, "SysReq Attention", UsageTypes.Sel);
                case 0x009b: return new Usage(this, id, "Cancel", UsageTypes.Sel);
                case 0x009c: return new Usage(this, id, "Clear", UsageTypes.Sel);
                case 0x009d: return new Usage(this, id, "Prior", UsageTypes.Sel);
                case 0x009e: return new Usage(this, id, "Return", UsageTypes.Sel);
                case 0x009f: return new Usage(this, id, "Separator", UsageTypes.Sel);
                case 0x00a0: return new Usage(this, id, "Out", UsageTypes.Sel);
                case 0x00a1: return new Usage(this, id, "Oper", UsageTypes.Sel);
                case 0x00a2: return new Usage(this, id, "Clear Again", UsageTypes.Sel);
                case 0x00a3: return new Usage(this, id, "CrSel Props", UsageTypes.Sel);
                case 0x00a4: return new Usage(this, id, "ExSel", UsageTypes.Sel);
                case 0x00b0: return new Usage(this, id, "Keypad 00", UsageTypes.Sel);
                case 0x00b1: return new Usage(this, id, "Keypad 000", UsageTypes.Sel);
                case 0x00b2: return new Usage(this, id, "1000sSeparator", UsageTypes.Sel);
                case 0x00b3: return new Usage(this, id, "DecimalSeparator", UsageTypes.Sel);
                case 0x00b4: return new Usage(this, id, "CurrencyUnit", UsageTypes.Sel);
                case 0x00b5: return new Usage(this, id, "CurrencySubunit", UsageTypes.Sel);
                case 0x00b6: return new Usage(this, id, "Keypad (", UsageTypes.Sel);
                case 0x00b7: return new Usage(this, id, "Keypad )", UsageTypes.Sel);
                case 0x00b8: return new Usage(this, id, "Keypad {", UsageTypes.Sel);
                case 0x00b9: return new Usage(this, id, "Keypad }", UsageTypes.Sel);
                case 0x00ba: return new Usage(this, id, "Keypad Tab", UsageTypes.Sel);
                case 0x00bb: return new Usage(this, id, "Keypad Backspace", UsageTypes.Sel);
                case 0x00bc: return new Usage(this, id, "Keypad A", UsageTypes.Sel);
                case 0x00bd: return new Usage(this, id, "Keypad B", UsageTypes.Sel);
                case 0x00be: return new Usage(this, id, "Keypad C", UsageTypes.Sel);
                case 0x00bf: return new Usage(this, id, "Keypad D", UsageTypes.Sel);
                case 0x00c0: return new Usage(this, id, "Keypad E", UsageTypes.Sel);
                case 0x00c1: return new Usage(this, id, "Keypad F", UsageTypes.Sel);
                case 0x00c2: return new Usage(this, id, "Keypad XOR", UsageTypes.Sel);
                case 0x00c3: return new Usage(this, id, "Keypad ^", UsageTypes.Sel);
                case 0x00c4: return new Usage(this, id, "Keypad %", UsageTypes.Sel);
                case 0x00c5: return new Usage(this, id, "Keypad <", UsageTypes.Sel);
                case 0x00c6: return new Usage(this, id, "Keypad >", UsageTypes.Sel);
                case 0x00c7: return new Usage(this, id, "Keypad &", UsageTypes.Sel);
                case 0x00c8: return new Usage(this, id, "Keypad &&", UsageTypes.Sel);
                case 0x00c9: return new Usage(this, id, "Keypad |", UsageTypes.Sel);
                case 0x00ca: return new Usage(this, id, "Keypad ||", UsageTypes.Sel);
                case 0x00cb: return new Usage(this, id, "Keypad :", UsageTypes.Sel);
                case 0x00cc: return new Usage(this, id, "Keypad #", UsageTypes.Sel);
                case 0x00cd: return new Usage(this, id, "Keypad Space", UsageTypes.Sel);
                case 0x00ce: return new Usage(this, id, "Keypad @", UsageTypes.Sel);
                case 0x00cf: return new Usage(this, id, "Keypad !", UsageTypes.Sel);
                case 0x00d0: return new Usage(this, id, "Keypad MemoryStore", UsageTypes.Sel);
                case 0x00d1: return new Usage(this, id, "Keypad MemoryRecall", UsageTypes.Sel);
                case 0x00d2: return new Usage(this, id, "Keypad MemoryClear", UsageTypes.Sel);
                case 0x00d3: return new Usage(this, id, "Keypad MemoryAdd", UsageTypes.Sel);
                case 0x00d4: return new Usage(this, id, "Keypad MemorySubtract", UsageTypes.Sel);
                case 0x00d5: return new Usage(this, id, "Keypad MemoryMultiply", UsageTypes.Sel);
                case 0x00d6: return new Usage(this, id, "Keypad MemoryDivide", UsageTypes.Sel);
                case 0x00d7: return new Usage(this, id, "Keypad +/-", UsageTypes.Sel);
                case 0x00d8: return new Usage(this, id, "Keypad Clear", UsageTypes.Sel);
                case 0x00d9: return new Usage(this, id, "Keypad ClearEntry", UsageTypes.Sel);
                case 0x00da: return new Usage(this, id, "Keypad Binary", UsageTypes.Sel);
                case 0x00db: return new Usage(this, id, "Keypad Octal", UsageTypes.Sel);
                case 0x00dc: return new Usage(this, id, "Keypad Decimal", UsageTypes.Sel);
                case 0x00dd: return new Usage(this, id, "Keypad Hexadecimal", UsageTypes.Sel);
                case 0x00e0: return new Usage(this, id, "LeftCtrl", UsageTypes.DF);
                case 0x00e1: return new Usage(this, id, "LeftShift", UsageTypes.DF);
                case 0x00e2: return new Usage(this, id, "LeftAlt", UsageTypes.DF);
                case 0x00e3: return new Usage(this, id, "LeftGUI", UsageTypes.DF);
                case 0x00e4: return new Usage(this, id, "RightCtrl", UsageTypes.DF);
                case 0x00e5: return new Usage(this, id, "RightShift", UsageTypes.DF);
                case 0x00e6: return new Usage(this, id, "RightAlt", UsageTypes.DF);
                case 0x00e7: return new Usage(this, id, "RightGUI", UsageTypes.DF);
            }

            return base.CreateUsage(id);
        }
    }
}