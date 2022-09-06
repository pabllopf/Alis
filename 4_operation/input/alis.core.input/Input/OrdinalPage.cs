// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:OrdinalPage.cs
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
    ///     Ordinal Usage Page.
    /// </summary>
    [Description("Ordinal Usage Page")]
    public enum OrdinalPage : uint
    {
        /// <summary>
        ///     Undefined Usage.
        /// </summary>
        [Description("Undefined")] Undefined = 0x000a0000,

        /*
         * Range: 0x0001 -> 0xffff
         * Instance {n}
         */

        /// <summary>
        ///     Instance 0 Usage.
        /// </summary>
        [Description("Instance 0")] Instance0 = 0x000a0001,

        /// <summary>
        ///     Instance 1 Usage.
        /// </summary>
        [Description("Instance 1")] Instance1 = 0x000a0002,

        /// <summary>
        ///     Instance 2 Usage.
        /// </summary>
        [Description("Instance 2")] Instance2 = 0x000a0003,

        /// <summary>
        ///     Instance 3 Usage.
        /// </summary>
        [Description("Instance 3")] Instance3 = 0x000a0004,

        /// <summary>
        ///     Instance 4 Usage.
        /// </summary>
        [Description("Instance 4")] Instance4 = 0x000a0005,

        /// <summary>
        ///     Instance 5 Usage.
        /// </summary>
        [Description("Instance 5")] Instance5 = 0x000a0006,

        /// <summary>
        ///     Instance 6 Usage.
        /// </summary>
        [Description("Instance 6")] Instance6 = 0x000a0007,

        /// <summary>
        ///     Instance 7 Usage.
        /// </summary>
        [Description("Instance 7")] Instance7 = 0x000a0008,

        /// <summary>
        ///     Instance 8 Usage.
        /// </summary>
        [Description("Instance 8")] Instance8 = 0x000a0009,

        /// <summary>
        ///     Instance 9 Usage.
        /// </summary>
        [Description("Instance 9")] Instance9 = 0x000a000a,

        /// <summary>
        ///     Instance 10 Usage.
        /// </summary>
        [Description("Instance 10")] Instance10 = 0x000a000b,

        /// <summary>
        ///     Instance 11 Usage.
        /// </summary>
        [Description("Instance 11")] Instance11 = 0x000a000c,

        /// <summary>
        ///     Instance 12 Usage.
        /// </summary>
        [Description("Instance 12")] Instance12 = 0x000a000d,

        /// <summary>
        ///     Instance 13 Usage.
        /// </summary>
        [Description("Instance 13")] Instance13 = 0x000a000e,

        /// <summary>
        ///     Instance 14 Usage.
        /// </summary>
        [Description("Instance 14")] Instance14 = 0x000a000f,

        /// <summary>
        ///     Instance 15 Usage.
        /// </summary>
        [Description("Instance 15")] Instance15 = 0x000a0010
    }
}