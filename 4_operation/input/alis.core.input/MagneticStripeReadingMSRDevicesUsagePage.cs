// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   MagneticStripeReadingMSRDevicesUsagePage.cs
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
    public sealed class MagneticStripeReadingMSRDevicesUsagePage : UsagePage
    {
        /// <summary>
        ///     Singleton instance of MagneticStripeReadingMSRDevices Usage Page.
        /// </summary>
        public static readonly MagneticStripeReadingMSRDevicesUsagePage Instance =
            new MagneticStripeReadingMSRDevicesUsagePage();

        /// <summary>
        ///     Initializes a new instance of the <see cref="MagneticStripeReadingMSRDevicesUsagePage" /> class
        /// </summary>
        private MagneticStripeReadingMSRDevicesUsagePage() : base(0x008e, "MagneticStripeReadingMSRDevices")
        {
        }

        /// <inheritdoc />
        protected override Usage CreateUsage(ushort id)
        {
            switch (id)
            {
                case 0x0000: return new Usage(this, id, "Undefined", UsageTypes.None);
                case 0x0001: return new Usage(this, id, "MSR Device Read-Only", UsageTypes.CA);
                case 0x0011:
                    return new Usage(this, id, "Track 1 Length", UsageTypes.SF | UsageTypes.DF | UsageTypes.Sel);
                case 0x0012:
                    return new Usage(this, id, "Track 2 Length", UsageTypes.SF | UsageTypes.DF | UsageTypes.Sel);
                case 0x0013:
                    return new Usage(this, id, "Track 3 Length", UsageTypes.SF | UsageTypes.DF | UsageTypes.Sel);
                case 0x0014:
                    return new Usage(this, id, "Track JIS Length", UsageTypes.SF | UsageTypes.DF | UsageTypes.Sel);
                case 0x0020: return new Usage(this, id, "Track Data", UsageTypes.SF | UsageTypes.DF | UsageTypes.Sel);
                case 0x0021: return new Usage(this, id, "Track 1 Data", UsageTypes.SF | UsageTypes.DF | UsageTypes.Sel);
                case 0x0022: return new Usage(this, id, "Track 2 Data", UsageTypes.SF | UsageTypes.DF | UsageTypes.Sel);
                case 0x0023: return new Usage(this, id, "Track 3 Data", UsageTypes.SF | UsageTypes.DF | UsageTypes.Sel);
                case 0x0024:
                    return new Usage(this, id, "Track JIS Data", UsageTypes.SF | UsageTypes.DF | UsageTypes.Sel);
            }

            return base.CreateUsage(id);
        }
    }
}