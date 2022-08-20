// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MagneticStripeReadingMSRDevicesPage.cs
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
    ///     Magnetic Stripe Reading (MSR) Devices Usage Page.
    /// </summary>
    [Description("Magnetic Stripe Reading (MSR) Devices Usage Page")]
    public enum MagneticStripeReadingMsrDevicesPage : uint
    {
        /// <summary>
        ///     Undefined Usage.
        /// </summary>
        [Description("Undefined")] Undefined = 0x008e0000,

        /// <summary>
        ///     MSR Device Read-Only Usage.
        /// </summary>
        [Description("MSR Device Read-Only")] MsrDeviceReadOnly = 0x008e0001,

        /*
         * Range: 0x0011 -> 0x0013
         * Track {n+1} Length
         */

        /// <summary>
        ///     Track 1 Length Usage.
        /// </summary>
        [Description("Track 1 Length")] Track1Length = 0x008e0011,

        /// <summary>
        ///     Track 2 Length Usage.
        /// </summary>
        [Description("Track 2 Length")] Track2Length = 0x008e0012,

        /// <summary>
        ///     Track 3 Length Usage.
        /// </summary>
        [Description("Track 3 Length")] Track3Length = 0x008e0013,

        /// <summary>
        ///     Track JIS Length Usage.
        /// </summary>
        [Description("Track JIS Length")] TrackJisLength = 0x008e0014,

        /// <summary>
        ///     Track Data Usage.
        /// </summary>
        [Description("Track Data")] TrackData = 0x008e0020,

        /*
         * Range: 0x0021 -> 0x0023
         * Track {n+1} Data
         */

        /// <summary>
        ///     Track 1 Data Usage.
        /// </summary>
        [Description("Track 1 Data")] Track1Data = 0x008e0021,

        /// <summary>
        ///     Track 2 Data Usage.
        /// </summary>
        [Description("Track 2 Data")] Track2Data = 0x008e0022,

        /// <summary>
        ///     Track 3 Data Usage.
        /// </summary>
        [Description("Track 3 Data")] Track3Data = 0x008e0023,

        /// <summary>
        ///     Track JIS Data Usage.
        /// </summary>
        [Description("Track JIS Data")] TrackJisData = 0x008e0024
    }
}