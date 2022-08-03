// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   BatterySystemUsagePage.cs
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
    public sealed class BatterySystemUsagePage : UsagePage
    {
        /// <summary>
        ///     Singleton instance of BatterySystem Usage Page.
        /// </summary>
        public static readonly BatterySystemUsagePage Instance = new BatterySystemUsagePage();

        /// <summary>
        /// Initializes a new instance of the <see cref="BatterySystemUsagePage"/> class
        /// </summary>
        private BatterySystemUsagePage() : base(0x0085, "BatterySystem")
        {
        }

        /// <inheritdoc />
        protected override Usage CreateUsage(ushort id) 
        {
            switch (id)
            {
                case 0x0000: return new Usage(this, id, "Undefined", UsageTypes.None);
                case 0x0001: return new Usage(this, id, "SMB Battery Mode", UsageTypes.CL);
                case 0x0002: return new Usage(this, id, "SMB Battery Status", UsageTypes.CL);
                case 0x0003: return new Usage(this, id, "SMB Alarm Warning", UsageTypes.CL);
                case 0x0004: return new Usage(this, id, "SMB Charger Mode", UsageTypes.CL);
                case 0x0005: return new Usage(this, id, "SMB Charger Status", UsageTypes.CL);
                case 0x0006: return new Usage(this, id, "SMB Charger Spec Info", UsageTypes.CL);
                case 0x0007: return new Usage(this, id, "SMB Selector State", UsageTypes.CL);
                case 0x0008: return new Usage(this, id, "SMB Selector Presets", UsageTypes.CL);
                case 0x0009: return new Usage(this, id, "SMB Selector Info", UsageTypes.CL);
                case 0x0010: return new Usage(this, id, "Optional Mfg Function 1", UsageTypes.DV);
                case 0x0011: return new Usage(this, id, "Optional Mfg Function 2", UsageTypes.DV);
                case 0x0012: return new Usage(this, id, "Optional Mfg Function 3", UsageTypes.DV);
                case 0x0013: return new Usage(this, id, "Optional Mfg Function 4", UsageTypes.DV);
                case 0x0014: return new Usage(this, id, "Optional Mfg Function 5", UsageTypes.DV);
                case 0x0015: return new Usage(this, id, "Connection To SMBus", UsageTypes.DF);
                case 0x0016: return new Usage(this, id, "Output Connection", UsageTypes.DF);
                case 0x0017: return new Usage(this, id, "Charger Connection", UsageTypes.DF);
                case 0x0018: return new Usage(this, id, "Battery Insertion", UsageTypes.DF);
                case 0x0019: return new Usage(this, id, "Use Next", UsageTypes.DF);
                case 0x001a: return new Usage(this, id, "OK To Use", UsageTypes.DF);
                case 0x001b: return new Usage(this, id, "Battery Supported", UsageTypes.DF);
                case 0x001c: return new Usage(this, id, "Selector Revision", UsageTypes.DF);
                case 0x001d: return new Usage(this, id, "Charging Indicator", UsageTypes.DF);
                case 0x0028: return new Usage(this, id, "Manufacturer Access", UsageTypes.DV);
                case 0x0029: return new Usage(this, id, "Remaining Capacity Limit", UsageTypes.DV);
                case 0x002a: return new Usage(this, id, "Remaining Time Limit", UsageTypes.DV);
                case 0x002b: return new Usage(this, id, "At Rate", UsageTypes.DV);
                case 0x002c: return new Usage(this, id, "Capacity Mode", UsageTypes.DV);
                case 0x002d: return new Usage(this, id, "Broadcast To Charger", UsageTypes.DV);
                case 0x002e: return new Usage(this, id, "Primary Battery", UsageTypes.DV);
                case 0x002f: return new Usage(this, id, "Charge Controller", UsageTypes.DV);
                case 0x0040: return new Usage(this, id, "Terminate Charge", UsageTypes.DF);
                case 0x0041: return new Usage(this, id, "Terminate Discharge", UsageTypes.DF);
                case 0x0042: return new Usage(this, id, "Below Remaining Capacity Limit", UsageTypes.DF);
                case 0x0043: return new Usage(this, id, "Remaining Time Limit Expired", UsageTypes.DF);
                case 0x0044: return new Usage(this, id, "Charging", UsageTypes.DF);
                case 0x0045: return new Usage(this, id, "Discharging", UsageTypes.DV);
                case 0x0046: return new Usage(this, id, "Fully Charged", UsageTypes.DF);
                case 0x0047: return new Usage(this, id, "Fully Discharged", UsageTypes.DV);
                case 0x0048: return new Usage(this, id, "Conditioning Flag", UsageTypes.DV);
                case 0x0049: return new Usage(this, id, "At Rate OK", UsageTypes.DV);
                case 0x004a: return new Usage(this, id, "SMB Error Code", UsageTypes.DF);
                case 0x004b: return new Usage(this, id, "Need Replacement", UsageTypes.DF);
                case 0x0060: return new Usage(this, id, "At Rate Time To Full", UsageTypes.DV);
                case 0x0061: return new Usage(this, id, "At Rate Time To Empty", UsageTypes.DV);
                case 0x0062: return new Usage(this, id, "Average Current", UsageTypes.DV);
                case 0x0063: return new Usage(this, id, "Max Error", UsageTypes.DV);
                case 0x0064: return new Usage(this, id, "Relative State Of Charge", UsageTypes.DV);
                case 0x0065: return new Usage(this, id, "Absolute State Of Charge", UsageTypes.DV);
                case 0x0066: return new Usage(this, id, "Remaining Capacity", UsageTypes.DV);
                case 0x0067: return new Usage(this, id, "Full Charge Capacity", UsageTypes.DV);
                case 0x0068: return new Usage(this, id, "Run Time To Empty", UsageTypes.DV);
                case 0x0069: return new Usage(this, id, "Average Time To Empty", UsageTypes.DV);
                case 0x006a: return new Usage(this, id, "Average Time To Full", UsageTypes.DV);
                case 0x006b: return new Usage(this, id, "Cycle Count", UsageTypes.DV);
                case 0x0080: return new Usage(this, id, "Battery Pack Model Level", UsageTypes.SV);
                case 0x0081: return new Usage(this, id, "Internal Charge Controller", UsageTypes.SF);
                case 0x0082: return new Usage(this, id, "Primary Battery Support", UsageTypes.SF);
                case 0x0083: return new Usage(this, id, "Design Capacity", UsageTypes.SV);
                case 0x0084: return new Usage(this, id, "Specification Info", UsageTypes.SV);
                case 0x0085: return new Usage(this, id, "Manufacturer Date", UsageTypes.SV);
                case 0x0086: return new Usage(this, id, "Serial Number", UsageTypes.SV);
                case 0x0087: return new Usage(this, id, "iManufacturer", UsageTypes.SV);
                case 0x0088: return new Usage(this, id, "iDeviceName", UsageTypes.SV);
                case 0x0089: return new Usage(this, id, "iDeviceChemistry", UsageTypes.SV);
                case 0x008a: return new Usage(this, id, "Manufacturer Data", UsageTypes.SV);
                case 0x008b: return new Usage(this, id, "Rechargeable", UsageTypes.SV);
                case 0x008c: return new Usage(this, id, "Warning Capacity Limit", UsageTypes.SV);
                case 0x008d: return new Usage(this, id, "Capacity Granularity 1", UsageTypes.SV);
                case 0x008e: return new Usage(this, id, "Capacity Granularity 2", UsageTypes.SV);
                case 0x008f: return new Usage(this, id, "iOEMInformation", UsageTypes.SV);
                case 0x00c0: return new Usage(this, id, "Inhibit Charge", UsageTypes.DF);
                case 0x00c1: return new Usage(this, id, "Enable Polling", UsageTypes.DF);
                case 0x00c2: return new Usage(this, id, "Reset To Zero", UsageTypes.DF);
                case 0x00d0: return new Usage(this, id, "AC Present", UsageTypes.DF);
                case 0x00d1: return new Usage(this, id, "Battery Present", UsageTypes.DF);
                case 0x00d2: return new Usage(this, id, "Power Fail", UsageTypes.DF);
                case 0x00d3: return new Usage(this, id, "Alarm Inhibited", UsageTypes.DF);
                case 0x00d4: return new Usage(this, id, "Thermistor Under Range", UsageTypes.DF);
                case 0x00d5: return new Usage(this, id, "Thermistor Hot", UsageTypes.DF);
                case 0x00d6: return new Usage(this, id, "Thermistor Cold", UsageTypes.DF);
                case 0x00d7: return new Usage(this, id, "Thermistor Over Range", UsageTypes.DF);
                case 0x00d8: return new Usage(this, id, "Voltage Out Of Range", UsageTypes.DF);
                case 0x00d9: return new Usage(this, id, "Current Out Of Range", UsageTypes.DF);
                case 0x00da: return new Usage(this, id, "Current Not Regulated", UsageTypes.DF);
                case 0x00db: return new Usage(this, id, "Voltage Not Regulated", UsageTypes.DF);
                case 0x00dc: return new Usage(this, id, "Master Mode", UsageTypes.DF);
                case 0x00f0: return new Usage(this, id, "Charger Selector Support", UsageTypes.SF);
                case 0x00f1: return new Usage(this, id, "Charger Spec", UsageTypes.SV);
                case 0x00f2: return new Usage(this, id, "Level 2", UsageTypes.SF);
                case 0x00f3: return new Usage(this, id, "Level 3", UsageTypes.SF);
            }

            return base.CreateUsage(id);
        }
    }
}