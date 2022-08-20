// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UsageTypes.cs
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

using System;
using System.ComponentModel;

namespace Alis.Core.Input
{
    /// <summary>
    ///     Enum UsageTypes defines usage types.
    /// </summary>
    /// <seealso href="https://www.usb.org/document-library/hid-usage-tables-112" />
    [Flags]
    public enum UsageTypes : ushort
    {
        /// <summary>
        ///     Indicates no usage types specified.
        /// </summary>
        None = 0,

        /// <summary>
        ///     The Linear Control usage type.
        /// </summary>
        [Description("Linear Control")] LC,

        /// <summary>
        ///     The On/Off Control usage type.
        /// </summary>
        [Description("On/Off Control")] OOC,

        /// <summary>
        ///     The Momentary Control usage type.
        /// </summary>
        [Description("Momentary Control")] MC,

        /// <summary>
        ///     The One Shot Control usage type.
        /// </summary>
        [Description("One Shot Control")] OSC,

        /// <summary>
        ///     The Re-trigger Control usage type.
        /// </summary>
        [Description("Re-trigger Control")] RTC,

        /// <summary>
        ///     The Selector usage type.
        /// </summary>
        [Description("Selector")] Sel,

        /// <summary>
        ///     The Static Value usage type.
        /// </summary>
        [Description("Static Value")] SV,

        /// <summary>
        ///     The Static Flag usage type.
        /// </summary>
        [Description("Static Flag")] SF,

        /// <summary>
        ///     The Dynamic Value usage type.
        /// </summary>
        [Description("Dynamic Value")] DV,

        /// <summary>
        ///     The Dynamic Flag usage type.
        /// </summary>
        [Description("Dynamic Flag")] DF,

        /// <summary>
        ///     The Named Array usage type.
        /// </summary>
        [Description("Named Array")] NAry,

        /// <summary>
        ///     The Application Collection usage type.
        /// </summary>
        [Description("Application Collection")]
        CA,

        /// <summary>
        ///     The Logical Collection usage type.
        /// </summary>
        [Description("Logical Collection")] CL,

        /// <summary>
        ///     The Physical Collection usage type.
        /// </summary>
        [Description("Physical Collection")] CP,

        /// <summary>
        ///     The Usage Switch usage type.
        /// </summary>
        [Description("Usage Switch")] US,

        /// <summary>
        ///     The Usage Modifier usage type.
        /// </summary>
        [Description("Usage Modifier")] UM
    }
}