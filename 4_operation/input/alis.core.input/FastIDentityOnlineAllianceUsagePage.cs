// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   FastIDentityOnlineAllianceUsagePage.cs
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
    public sealed class FastIDentityOnlineAllianceUsagePage : UsagePage
    {
        /// <summary>
        ///     Singleton instance of FastIDentityOnlineAlliance Usage Page.
        /// </summary>
        public static readonly FastIDentityOnlineAllianceUsagePage Instance = new FastIDentityOnlineAllianceUsagePage();

        /// <summary>
        /// Initializes a new instance of the <see cref="FastIDentityOnlineAllianceUsagePage"/> class
        /// </summary>
        private FastIDentityOnlineAllianceUsagePage() : base(0xf1d0, "FastIDentityOnlineAlliance")
        {
        }

        /// <inheritdoc />
        protected override Usage CreateUsage(ushort id) 
        {
            switch (id)
            {
                case 0x0000: return new Usage(this, id, "Undefined", UsageTypes.None);
                case 0x0001: return new Usage(this, id, "U2F Authenticator Device", UsageTypes.CA);
                case 0x0020: return new Usage(this, id, "Input Report Data", UsageTypes.DV);
                case 0x0021: return new Usage(this, id, "Output Report Data", UsageTypes.DV);
            }

            return base.CreateUsage(id);
        }
    }
}