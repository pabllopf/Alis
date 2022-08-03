// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ButtonPage.cs
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

using System.ComponentModel;

namespace DevDecoder.HIDDevices.Usages
{
#pragma warning disable CS0108
    /// <summary>
    ///     Button Usage Page.
    /// </summary>
    [Description("Button Usage Page")]
    public enum ButtonPage : uint
    {
        /// <summary>
        ///     Undefined Usage.
        /// </summary>
        [Description("Undefined")]
        Undefined = 0x00090000,

        /*
         * Range: 0x0001 -> 0xffff
         * Button {n}
         */

        /// <summary>
        ///     Button 0 Usage.
        /// </summary>
        [Description("Button 0")]
        Button0 = 0x00090001,

        /// <summary>
        ///     Button 1 Usage.
        /// </summary>
        [Description("Button 1")]
        Button1 = 0x00090002,

        /// <summary>
        ///     Button 2 Usage.
        /// </summary>
        [Description("Button 2")]
        Button2 = 0x00090003,

        /// <summary>
        ///     Button 3 Usage.
        /// </summary>
        [Description("Button 3")]
        Button3 = 0x00090004,

        /// <summary>
        ///     Button 4 Usage.
        /// </summary>
        [Description("Button 4")]
        Button4 = 0x00090005,

        /// <summary>
        ///     Button 5 Usage.
        /// </summary>
        [Description("Button 5")]
        Button5 = 0x00090006,

        /// <summary>
        ///     Button 6 Usage.
        /// </summary>
        [Description("Button 6")]
        Button6 = 0x00090007,

        /// <summary>
        ///     Button 7 Usage.
        /// </summary>
        [Description("Button 7")]
        Button7 = 0x00090008,

        /// <summary>
        ///     Button 8 Usage.
        /// </summary>
        [Description("Button 8")]
        Button8 = 0x00090009,

        /// <summary>
        ///     Button 9 Usage.
        /// </summary>
        [Description("Button 9")]
        Button9 = 0x0009000a,

        /// <summary>
        ///     Button 10 Usage.
        /// </summary>
        [Description("Button 10")]
        Button10 = 0x0009000b,

        /// <summary>
        ///     Button 11 Usage.
        /// </summary>
        [Description("Button 11")]
        Button11 = 0x0009000c,

        /// <summary>
        ///     Button 12 Usage.
        /// </summary>
        [Description("Button 12")]
        Button12 = 0x0009000d,

        /// <summary>
        ///     Button 13 Usage.
        /// </summary>
        [Description("Button 13")]
        Button13 = 0x0009000e,

        /// <summary>
        ///     Button 14 Usage.
        /// </summary>
        [Description("Button 14")]
        Button14 = 0x0009000f,

        /// <summary>
        ///     Button 15 Usage.
        /// </summary>
        [Description("Button 15")]
        Button15 = 0x00090010
    }
}