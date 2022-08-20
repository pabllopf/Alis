// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EyeAndHeadTrackersUsagePage.cs
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
    public sealed class EyeAndHeadTrackersUsagePage : UsagePage
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EyeAndHeadTrackersUsagePage" /> class
        /// </summary>
        private EyeAndHeadTrackersUsagePage() : base(0x0012, "EyeAndHeadTrackers")
        {
        }

        /// <summary>
        ///     Singleton instance of EyeAndHeadTrackers Usage Page.
        /// </summary>
        public static readonly EyeAndHeadTrackersUsagePage Instance = new EyeAndHeadTrackersUsagePage();

        /// <inheritdoc />
        protected override Usage CreateUsage(ushort id)
        {
            switch (id)
            {
                case 0x0000: return new Usage(this, id, "Undefined", UsageTypes.None);
                case 0x0001: return new Usage(this, id, "Eye Tracker", UsageTypes.CA);
                case 0x0002: return new Usage(this, id, "Head Tracker", UsageTypes.CA);
                case 0x0010: return new Usage(this, id, "Tracking Data", UsageTypes.CP);
                case 0x0011: return new Usage(this, id, "Capabilities", UsageTypes.CL);
                case 0x0012: return new Usage(this, id, "Configuration", UsageTypes.CL);
                case 0x0013: return new Usage(this, id, "Status", UsageTypes.CL);
                case 0x0014: return new Usage(this, id, "Control", UsageTypes.CL);
                case 0x0020: return new Usage(this, id, "Sensor Timestamp", UsageTypes.DV);
                case 0x0021: return new Usage(this, id, "Position X", UsageTypes.DV);
                case 0x0022: return new Usage(this, id, "Position Y", UsageTypes.DV);
                case 0x0023: return new Usage(this, id, "Position Z", UsageTypes.DV);
                case 0x0024: return new Usage(this, id, "Gaze Point", UsageTypes.CP);
                case 0x0025: return new Usage(this, id, "Left Eye Position", UsageTypes.CP);
                case 0x0026: return new Usage(this, id, "Right Eye Position", UsageTypes.CP);
                case 0x0027: return new Usage(this, id, "Head Position", UsageTypes.CP);
                case 0x0028: return new Usage(this, id, "Head Direction Point", UsageTypes.CP);
                case 0x0029: return new Usage(this, id, "Rotation about X axis", UsageTypes.DV);
                case 0x002a: return new Usage(this, id, "Rotation about Y axis", UsageTypes.DV);
                case 0x002b: return new Usage(this, id, "Rotation about Z axis", UsageTypes.DV);
                case 0x0100: return new Usage(this, id, "Tracker Quality", UsageTypes.SV);
                case 0x0101: return new Usage(this, id, "Minimum Tracking Distance", UsageTypes.SV);
                case 0x0102: return new Usage(this, id, "Optimum Tracking Distance", UsageTypes.SV);
                case 0x0103: return new Usage(this, id, "Maximum Tracking Distance", UsageTypes.SV);
                case 0x0104: return new Usage(this, id, "Maximum Screen Plane Width", UsageTypes.SV);
                case 0x0105: return new Usage(this, id, "Maximum Screen Plane Height", UsageTypes.SV);
                case 0x0200: return new Usage(this, id, "Display Manufacturer ID", UsageTypes.SV);
                case 0x0201: return new Usage(this, id, "Display Product ID", UsageTypes.SV);
                case 0x0202: return new Usage(this, id, "Display Serial Number", UsageTypes.SV);
                case 0x0203: return new Usage(this, id, "Display Manufacturer Date", UsageTypes.SV);
                case 0x0204: return new Usage(this, id, "Calibrated Screen Width", UsageTypes.SV);
                case 0x0205: return new Usage(this, id, "Calibrated Screen Height", UsageTypes.SV);
                case 0x0300: return new Usage(this, id, "Sampling Frequency", UsageTypes.DV);
                case 0x0301: return new Usage(this, id, "Configuration Status", UsageTypes.DV);
                case 0x0400: return new Usage(this, id, "Device Mode Request", UsageTypes.DV);
            }

            return base.CreateUsage(id);
        }
    }
}