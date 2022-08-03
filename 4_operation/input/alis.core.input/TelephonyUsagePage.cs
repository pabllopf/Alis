// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   TelephonyUsagePage.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Input;

namespace DevDecoder.HIDDevices.Pages
{
#pragma warning disable CS0108
    /// <summary>
    ///     Base class for all usage pages.
    /// </summary>
    public sealed class TelephonyUsagePage : UsagePage
    {
        /// <summary>
        ///     Singleton instance of Telephony Usage Page.
        /// </summary>
        public static readonly TelephonyUsagePage Instance = new TelephonyUsagePage();

        /// <summary>
        ///     Initializes a new instance of the <see cref="TelephonyUsagePage" /> class
        /// </summary>
        private TelephonyUsagePage() : base(0x000b, "Telephony")
        {
        }

        /// <inheritdoc />
        protected override Usage CreateUsage(ushort id)
        {
            switch (id)
            {
                case 0x0000: return new Usage(this, id, "Undefined", UsageTypes.None);
                case 0x0001: return new Usage(this, id, "Phone", UsageTypes.CA);
                case 0x0002: return new Usage(this, id, "Answering Machine", UsageTypes.CA);
                case 0x0003: return new Usage(this, id, "Message Controls", UsageTypes.CL);
                case 0x0004: return new Usage(this, id, "Handset", UsageTypes.CL);
                case 0x0005: return new Usage(this, id, "Headset", UsageTypes.CL);
                case 0x0006: return new Usage(this, id, "Telephony Key Pad", UsageTypes.NAry);
                case 0x0007: return new Usage(this, id, "Programmable Button", UsageTypes.NAry);
                case 0x0020: return new Usage(this, id, "Hook Switch", UsageTypes.OOC);
                case 0x0021: return new Usage(this, id, "Flash", UsageTypes.MC);
                case 0x0022: return new Usage(this, id, "Feature", UsageTypes.OSC);
                case 0x0023: return new Usage(this, id, "Hold", UsageTypes.OOC);
                case 0x0024: return new Usage(this, id, "Redial", UsageTypes.OSC);
                case 0x0025: return new Usage(this, id, "Transfer", UsageTypes.OSC);
                case 0x0026: return new Usage(this, id, "Drop", UsageTypes.OSC);
                case 0x0027: return new Usage(this, id, "Park", UsageTypes.OOC);
                case 0x0028: return new Usage(this, id, "Forward Calls", UsageTypes.OOC);
                case 0x0029: return new Usage(this, id, "Alternate  Function", UsageTypes.MC);
                case 0x002a: return new Usage(this, id, "Line", UsageTypes.OSC | UsageTypes.NAry);
                case 0x002b: return new Usage(this, id, "Speaker Phone", UsageTypes.OOC);
                case 0x002c: return new Usage(this, id, "Conference", UsageTypes.OOC);
                case 0x002d: return new Usage(this, id, "Ring Enable", UsageTypes.OOC);
                case 0x002e: return new Usage(this, id, "Ring Select", UsageTypes.OSC);
                case 0x002f: return new Usage(this, id, "Phone Mute", UsageTypes.OOC);
                case 0x0030: return new Usage(this, id, "Caller ID", UsageTypes.MC);
                case 0x0050: return new Usage(this, id, "Speed Dial", UsageTypes.OSC);
                case 0x0051: return new Usage(this, id, "Store Number", UsageTypes.OSC);
                case 0x0052: return new Usage(this, id, "Recall Number", UsageTypes.OSC);
                case 0x0053: return new Usage(this, id, "Phone Directory", UsageTypes.OOC);
                case 0x0070: return new Usage(this, id, "Voice Mail", UsageTypes.OOC);
                case 0x0071: return new Usage(this, id, "Screen Calls", UsageTypes.OOC);
                case 0x0072: return new Usage(this, id, "Do Not Disturb", UsageTypes.OOC);
                case 0x0073: return new Usage(this, id, "Message", UsageTypes.OSC);
                case 0x0074: return new Usage(this, id, "Answer On/Off", UsageTypes.OOC);
                case 0x0090: return new Usage(this, id, "Inside Dial Tone", UsageTypes.MC);
                case 0x0091: return new Usage(this, id, "Outside Dial Tone", UsageTypes.MC);
                case 0x0092: return new Usage(this, id, "Inside Ring Tone", UsageTypes.MC);
                case 0x0093: return new Usage(this, id, "Outside Ring Tone", UsageTypes.MC);
                case 0x0094: return new Usage(this, id, "Priority Ring Tone", UsageTypes.MC);
                case 0x0095: return new Usage(this, id, "Inside Ringback", UsageTypes.MC);
                case 0x0096: return new Usage(this, id, "Priority Ringback", UsageTypes.MC);
                case 0x0097: return new Usage(this, id, "Line Busy Tone", UsageTypes.MC);
                case 0x0098: return new Usage(this, id, "Reorder Tone", UsageTypes.MC);
                case 0x0099: return new Usage(this, id, "Call Waiting Tone", UsageTypes.MC);
                case 0x009a: return new Usage(this, id, "Confirmation Tone 1", UsageTypes.MC);
                case 0x009b: return new Usage(this, id, "Confirmation Tone 2", UsageTypes.MC);
                case 0x009c: return new Usage(this, id, "Tones Off", UsageTypes.OOC);
                case 0x009d: return new Usage(this, id, "Outside Ringback", UsageTypes.MC);
                case 0x009e: return new Usage(this, id, "Ringer", UsageTypes.OOC);
                case 0x00b0: return new Usage(this, id, "Phone Key 0", UsageTypes.Sel);
                case 0x00b1: return new Usage(this, id, "Phone Key 1", UsageTypes.Sel);
                case 0x00b2: return new Usage(this, id, "Phone Key 2", UsageTypes.Sel);
                case 0x00b3: return new Usage(this, id, "Phone Key 3", UsageTypes.Sel);
                case 0x00b4: return new Usage(this, id, "Phone Key 4", UsageTypes.Sel);
                case 0x00b5: return new Usage(this, id, "Phone Key 5", UsageTypes.Sel);
                case 0x00b6: return new Usage(this, id, "Phone Key 6", UsageTypes.Sel);
                case 0x00b7: return new Usage(this, id, "Phone Key 7", UsageTypes.Sel);
                case 0x00b8: return new Usage(this, id, "Phone Key 8", UsageTypes.Sel);
                case 0x00b9: return new Usage(this, id, "Phone Key 9", UsageTypes.Sel);
                case 0x00ba: return new Usage(this, id, "Phone Key Star", UsageTypes.Sel);
                case 0x00bb: return new Usage(this, id, "Phone Key Pound", UsageTypes.Sel);
                case 0x00bc: return new Usage(this, id, "Phone Key A", UsageTypes.Sel);
                case 0x00bd: return new Usage(this, id, "Phone Key B", UsageTypes.Sel);
                case 0x00be: return new Usage(this, id, "Phone Key C", UsageTypes.Sel);
                case 0x00bf: return new Usage(this, id, "Phone Key D", UsageTypes.Sel);
                case 0x00c0: return new Usage(this, id, "Phone Key Call History", UsageTypes.Sel);
                case 0x00c1: return new Usage(this, id, "Phone Key Caller ID", UsageTypes.Sel);
                case 0x00c2: return new Usage(this, id, "Phone Key Settings", UsageTypes.Sel);
                case 0x00f0: return new Usage(this, id, "Host Control", UsageTypes.OOC);
                case 0x00f1: return new Usage(this, id, "Host Available", UsageTypes.OOC);
                case 0x00f2: return new Usage(this, id, "Host Call Active", UsageTypes.OOC);
                case 0x00f3: return new Usage(this, id, "Activate Handset Audio", UsageTypes.OOC);
                case 0x00f4: return new Usage(this, id, "Ring Type", UsageTypes.NAry);
                case 0x00f5: return new Usage(this, id, "Re-dialable Phone Number", UsageTypes.OOC);
                case 0x00f8: return new Usage(this, id, "Stop Ring Tone", UsageTypes.Sel);
                case 0x00f9: return new Usage(this, id, "PSTN Ring Tone", UsageTypes.Sel);
                case 0x00fa: return new Usage(this, id, "Host Ring Tone", UsageTypes.Sel);
                case 0x00fb: return new Usage(this, id, "Alert Sound Error", UsageTypes.Sel);
                case 0x00fc: return new Usage(this, id, "Alert Sound Confirm", UsageTypes.Sel);
                case 0x00fd: return new Usage(this, id, "Alert Sound Notification", UsageTypes.Sel);
                case 0x00fe: return new Usage(this, id, "Silent Ring", UsageTypes.Sel);
                case 0x0108: return new Usage(this, id, "Email Message Waiting", UsageTypes.OOC);
                case 0x0109: return new Usage(this, id, "Voicemail Message Waiting", UsageTypes.OOC);
                case 0x010a: return new Usage(this, id, "Host Hold", UsageTypes.OOC);
                case 0x0110: return new Usage(this, id, "Incoming Call History Count", UsageTypes.DV);
                case 0x0111: return new Usage(this, id, "Outgoing Call History Count", UsageTypes.DV);
                case 0x0112: return new Usage(this, id, "Incoming Call History", UsageTypes.CL);
                case 0x0113: return new Usage(this, id, "Outgoing Call History", UsageTypes.CL);
                case 0x0114: return new Usage(this, id, "Phone Locale", UsageTypes.DV);
                case 0x0140: return new Usage(this, id, "Phone Time Second", UsageTypes.DV);
                case 0x0141: return new Usage(this, id, "Phone Time Minute", UsageTypes.DV);
                case 0x0142: return new Usage(this, id, "Phone Time Hour", UsageTypes.DV);
                case 0x0143: return new Usage(this, id, "Phone Time Day", UsageTypes.DV);
                case 0x0144: return new Usage(this, id, "Phone Time Month", UsageTypes.DV);
                case 0x0145: return new Usage(this, id, "Phone Time Year", UsageTypes.DV);
                case 0x0146: return new Usage(this, id, "Handset Nickname", UsageTypes.DV);
                case 0x0147: return new Usage(this, id, "Address Book ID", UsageTypes.DV);
                case 0x014a: return new Usage(this, id, "Call Duration", UsageTypes.DV);
                case 0x014b: return new Usage(this, id, "Dual Mode Phone", UsageTypes.CA);
            }

            return base.CreateUsage(id);
        }
    }
}