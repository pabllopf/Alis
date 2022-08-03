// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   GenericDeviceUsagePage.cs
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
    public sealed class GenericDeviceUsagePage : UsagePage
    {
        /// <summary>
        ///     Singleton instance of GenericDevice Usage Page.
        /// </summary>
        public static readonly GenericDeviceUsagePage Instance = new GenericDeviceUsagePage();

        /// <summary>
        ///     Initializes a new instance of the <see cref="GenericDeviceUsagePage" /> class
        /// </summary>
        private GenericDeviceUsagePage() : base(0x0006, "GenericDevice")
        {
        }

        /// <inheritdoc />
        protected override Usage CreateUsage(ushort id)
        {
            switch (id)
            {
                case 0x0000: return new Usage(this, id, "Undefined", UsageTypes.None);
                case 0x0001: return new Usage(this, id, "Background Controls", UsageTypes.CA);
                case 0x0020: return new Usage(this, id, "Battery Strength", UsageTypes.DV);
                case 0x0021: return new Usage(this, id, "Wireless Channel", UsageTypes.DV);
                case 0x0022: return new Usage(this, id, "Wireless ID", UsageTypes.DV);
                case 0x0023: return new Usage(this, id, "Discover Wireless Control", UsageTypes.OSC);
                case 0x0024: return new Usage(this, id, "Security Code Character Entered", UsageTypes.OSC);
                case 0x0025: return new Usage(this, id, "Security Code Character Erased", UsageTypes.OSC);
                case 0x0026: return new Usage(this, id, "Security Code Cleared", UsageTypes.OSC);
                case 0x0027: return new Usage(this, id, "Sequence ID", UsageTypes.DV);
                case 0x0028: return new Usage(this, id, "Sequence ID Reset", UsageTypes.DF);
                case 0x0029: return new Usage(this, id, "RF Signal Strength", UsageTypes.DV);
                case 0x002a: return new Usage(this, id, "Software Version", UsageTypes.CL);
                case 0x002b: return new Usage(this, id, "Protocol Version", UsageTypes.CL);
                case 0x002c: return new Usage(this, id, "Hardware Version", UsageTypes.CL);
                case 0x002d: return new Usage(this, id, "Major", UsageTypes.SV);
                case 0x002e: return new Usage(this, id, "Minor", UsageTypes.SV);
                case 0x002f: return new Usage(this, id, "Revision", UsageTypes.SV);
                case 0x0030: return new Usage(this, id, "Handedness", UsageTypes.NAry);
                case 0x0031: return new Usage(this, id, "Either Hand", UsageTypes.Sel);
                case 0x0032: return new Usage(this, id, "Left Hand", UsageTypes.Sel);
                case 0x0033: return new Usage(this, id, "Right Hand", UsageTypes.Sel);
                case 0x0034: return new Usage(this, id, "Both Hands", UsageTypes.Sel);
                case 0x0040: return new Usage(this, id, "Grip Pose Offset", UsageTypes.CP);
                case 0x0041: return new Usage(this, id, "Pointer Pose Offset", UsageTypes.CP);
            }

            return base.CreateUsage(id);
        }
    }
}