// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PowerDeviceUsagePage.cs
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
    public sealed class PowerDeviceUsagePage : UsagePage
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PowerDeviceUsagePage" /> class
        /// </summary>
        private PowerDeviceUsagePage() : base(0x0084, "PowerDevice")
        {
        }

        /// <summary>
        ///     Singleton instance of PowerDevice Usage Page.
        /// </summary>
        public static readonly PowerDeviceUsagePage Instance = new PowerDeviceUsagePage();

        /// <inheritdoc />
        protected override Usage CreateUsage(ushort id)
        {
            switch (id)
            {
                case 0x0000: return new Usage(this, id, "Undefined", UsageTypes.None);
                case 0x0001: return new Usage(this, id, "iName", UsageTypes.Sv);
                case 0x0002: return new Usage(this, id, "Present Status", UsageTypes.Cl);
                case 0x0003: return new Usage(this, id, "Changed Status", UsageTypes.Cl);
                case 0x0004: return new Usage(this, id, "UPS", UsageTypes.Ca);
                case 0x0005: return new Usage(this, id, "Power Supply", UsageTypes.Ca);
                case 0x0006: return new Usage(this, id, "Peripheral Device", UsageTypes.Ca);
                case 0x0010: return new Usage(this, id, "Battery System", UsageTypes.Cp);
                case 0x0011: return new Usage(this, id, "Battery System ID", UsageTypes.Sv);
                case 0x0012: return new Usage(this, id, "Battery", UsageTypes.Cp);
                case 0x0013: return new Usage(this, id, "Battery ID", UsageTypes.Sv);
                case 0x0014: return new Usage(this, id, "Charger", UsageTypes.Cp);
                case 0x0015: return new Usage(this, id, "Charger ID", UsageTypes.Sv);
                case 0x0016: return new Usage(this, id, "Power Converter", UsageTypes.Cp);
                case 0x0017: return new Usage(this, id, "Power Converter ID", UsageTypes.Sv);
                case 0x0018: return new Usage(this, id, "Outlet System", UsageTypes.Cp);
                case 0x0019: return new Usage(this, id, "Outlet System ID", UsageTypes.Sv);
                case 0x001a: return new Usage(this, id, "Input", UsageTypes.Cp);
                case 0x001b: return new Usage(this, id, "Input ID", UsageTypes.Sv);
                case 0x001c: return new Usage(this, id, "Output", UsageTypes.Cp);
                case 0x001d: return new Usage(this, id, "Output ID", UsageTypes.Sv);
                case 0x001e: return new Usage(this, id, "Flow", UsageTypes.Cp);
                case 0x001f: return new Usage(this, id, "Flow ID", UsageTypes.Sv);
                case 0x0020: return new Usage(this, id, "Outlet", UsageTypes.Cp);
                case 0x0021: return new Usage(this, id, "Outlet ID", UsageTypes.Sv);
                case 0x0022: return new Usage(this, id, "Gang", UsageTypes.Cp);
                case 0x0023: return new Usage(this, id, "Gang ID", UsageTypes.Sv);
                case 0x0030: return new Usage(this, id, "Voltage", UsageTypes.Dv);
                case 0x0031: return new Usage(this, id, "Current", UsageTypes.Dv);
                case 0x0032: return new Usage(this, id, "Frequency", UsageTypes.Dv);
                case 0x0033: return new Usage(this, id, "Apparent Power", UsageTypes.Dv);
                case 0x0034: return new Usage(this, id, "Active Power", UsageTypes.Dv);
                case 0x0035: return new Usage(this, id, "Load (percent)", UsageTypes.Dv);
                case 0x0036: return new Usage(this, id, "Temperature", UsageTypes.Dv);
                case 0x0037: return new Usage(this, id, "Humidity", UsageTypes.Dv);
                case 0x0038: return new Usage(this, id, "Bad Count", UsageTypes.Dv);
                case 0x0040: return new Usage(this, id, "Nominal Voltage", UsageTypes.Sv | UsageTypes.Dv);
                case 0x0041: return new Usage(this, id, "Nominal Current", UsageTypes.Sv | UsageTypes.Dv);
                case 0x0042: return new Usage(this, id, "Nominal Frequency", UsageTypes.Sv | UsageTypes.Dv);
                case 0x0043: return new Usage(this, id, "Nominal Apparent Power", UsageTypes.Sv | UsageTypes.Dv);
                case 0x0044: return new Usage(this, id, "Nominal Active Power", UsageTypes.Sv | UsageTypes.Dv);
                case 0x0045: return new Usage(this, id, "Nominal Load (percent)", UsageTypes.Sv | UsageTypes.Dv);
                case 0x0046: return new Usage(this, id, "Nominal Temperature", UsageTypes.Sv | UsageTypes.Dv);
                case 0x0047: return new Usage(this, id, "Nominal Humidity", UsageTypes.Sv | UsageTypes.Dv);
                case 0x0050: return new Usage(this, id, "Switch On Control", UsageTypes.Dv);
                case 0x0051: return new Usage(this, id, "Switch Off Control", UsageTypes.Dv);
                case 0x0052: return new Usage(this, id, "Toggle Control", UsageTypes.Dv);
                case 0x0053: return new Usage(this, id, "Low Voltage Transfer", UsageTypes.Dv);
                case 0x0054: return new Usage(this, id, "High Voltage Transfer", UsageTypes.Dv);
                case 0x0055: return new Usage(this, id, "Delay Before Reboot", UsageTypes.Dv);
                case 0x0056: return new Usage(this, id, "Delay Before Startup", UsageTypes.Dv);
                case 0x0057: return new Usage(this, id, "Delay Before Shutdown", UsageTypes.Dv);
                case 0x0058: return new Usage(this, id, "Test", UsageTypes.Dv);
                case 0x0059: return new Usage(this, id, "Module Reset", UsageTypes.Dv);
                case 0x005a: return new Usage(this, id, "Audible Alarm Control", UsageTypes.Dv);
                case 0x0060: return new Usage(this, id, "Present", UsageTypes.Df);
                case 0x0061: return new Usage(this, id, "Good", UsageTypes.Df);
                case 0x0062: return new Usage(this, id, "Internal Failure", UsageTypes.Df);
                case 0x0063: return new Usage(this, id, "Voltage Out Of Range", UsageTypes.Df);
                case 0x0064: return new Usage(this, id, "Frequency Out Of Range", UsageTypes.Df);
                case 0x0065: return new Usage(this, id, "Overload", UsageTypes.Df);
                case 0x0066: return new Usage(this, id, "Overcharged", UsageTypes.Df);
                case 0x0067: return new Usage(this, id, "Over Temperature", UsageTypes.Df);
                case 0x0068: return new Usage(this, id, "Shutdown Requested", UsageTypes.Df);
                case 0x0069: return new Usage(this, id, "Shutdown Imminent", UsageTypes.Df);
                case 0x006b: return new Usage(this, id, "Switch On/Off", UsageTypes.Df);
                case 0x006c: return new Usage(this, id, "Switchable", UsageTypes.Df);
                case 0x006d: return new Usage(this, id, "Used", UsageTypes.Df);
                case 0x006e: return new Usage(this, id, "Boost", UsageTypes.Df);
                case 0x006f: return new Usage(this, id, "Buck", UsageTypes.Df);
                case 0x0070: return new Usage(this, id, "Initialized", UsageTypes.Df);
                case 0x0071: return new Usage(this, id, "Tested", UsageTypes.Df);
                case 0x0072: return new Usage(this, id, "Awaiting Power", UsageTypes.Df);
                case 0x0073: return new Usage(this, id, "Communication Lost", UsageTypes.Df);
                case 0x00fd: return new Usage(this, id, "iManufacturer", UsageTypes.Sv);
                case 0x00fe: return new Usage(this, id, "iProduct", UsageTypes.Sv);
                case 0x00ff: return new Usage(this, id, "iSerialNumber", UsageTypes.Sv);
            }

            return base.CreateUsage(id);
        }
    }
}