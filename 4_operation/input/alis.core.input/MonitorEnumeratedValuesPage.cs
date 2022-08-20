// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MonitorEnumeratedValuesPage.cs
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
    ///     Monitor Enumerated Values Usage Page.
    /// </summary>
    [Description("Monitor Enumerated Values Usage Page")]
    public enum MonitorEnumeratedValuesPage : uint
    {
        /// <summary>
        ///     Undefined Usage.
        /// </summary>
        [Description("Undefined")] Undefined = 0x00810000,

        /*
         * Range: 0x0001 -> 0xffff
         * ENUM_{n}
         */

        /// <summary>
        ///     ENUM_0 Usage.
        /// </summary>
        [Description("ENUM_0")] ENUM_0 = 0x00810001,

        /// <summary>
        ///     ENUM_1 Usage.
        /// </summary>
        [Description("ENUM_1")] ENUM_1 = 0x00810002,

        /// <summary>
        ///     ENUM_2 Usage.
        /// </summary>
        [Description("ENUM_2")] ENUM_2 = 0x00810003,

        /// <summary>
        ///     ENUM_3 Usage.
        /// </summary>
        [Description("ENUM_3")] ENUM_3 = 0x00810004,

        /// <summary>
        ///     ENUM_4 Usage.
        /// </summary>
        [Description("ENUM_4")] ENUM_4 = 0x00810005,

        /// <summary>
        ///     ENUM_5 Usage.
        /// </summary>
        [Description("ENUM_5")] ENUM_5 = 0x00810006,

        /// <summary>
        ///     ENUM_6 Usage.
        /// </summary>
        [Description("ENUM_6")] ENUM_6 = 0x00810007,

        /// <summary>
        ///     ENUM_7 Usage.
        /// </summary>
        [Description("ENUM_7")] ENUM_7 = 0x00810008,

        /// <summary>
        ///     ENUM_8 Usage.
        /// </summary>
        [Description("ENUM_8")] ENUM_8 = 0x00810009,

        /// <summary>
        ///     ENUM_9 Usage.
        /// </summary>
        [Description("ENUM_9")] ENUM_9 = 0x0081000a,

        /// <summary>
        ///     ENUM_10 Usage.
        /// </summary>
        [Description("ENUM_10")] ENUM_10 = 0x0081000b,

        /// <summary>
        ///     ENUM_11 Usage.
        /// </summary>
        [Description("ENUM_11")] ENUM_11 = 0x0081000c,

        /// <summary>
        ///     ENUM_12 Usage.
        /// </summary>
        [Description("ENUM_12")] ENUM_12 = 0x0081000d,

        /// <summary>
        ///     ENUM_13 Usage.
        /// </summary>
        [Description("ENUM_13")] ENUM_13 = 0x0081000e,

        /// <summary>
        ///     ENUM_14 Usage.
        /// </summary>
        [Description("ENUM_14")] ENUM_14 = 0x0081000f,

        /// <summary>
        ///     ENUM_15 Usage.
        /// </summary>
        [Description("ENUM_15")] ENUM_15 = 0x00810010
    }
}