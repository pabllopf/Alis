// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VRPage.cs
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
    ///     VR Controls Usage Page.
    /// </summary>
    [Description("VR Controls Usage Page")]
    public enum VRPage : uint
    {
        /// <summary>
        ///     Undefined Usage.
        /// </summary>
        [Description("Undefined")] Undefined = 0x00030000,

        /// <summary>
        ///     Belt Usage.
        /// </summary>
        [Description("Belt")] Belt = 0x00030001,

        /// <summary>
        ///     Body Suit Usage.
        /// </summary>
        [Description("Body Suit")] BodySuit = 0x00030002,

        /// <summary>
        ///     Flexor Usage.
        /// </summary>
        [Description("Flexor")] Flexor = 0x00030003,

        /// <summary>
        ///     Glove Usage.
        /// </summary>
        [Description("Glove")] Glove = 0x00030004,

        /// <summary>
        ///     Head Tracker Usage.
        /// </summary>
        [Description("Head Tracker")] HeadTracker = 0x00030005,

        /// <summary>
        ///     Head Mounted Display Usage.
        /// </summary>
        [Description("Head Mounted Display")] HeadMountedDisplay = 0x00030006,

        /// <summary>
        ///     Hand Tracker Usage.
        /// </summary>
        [Description("Hand Tracker")] HandTracker = 0x00030007,

        /// <summary>
        ///     Oculometer Usage.
        /// </summary>
        [Description("Oculometer")] Oculometer = 0x00030008,

        /// <summary>
        ///     Vest Usage.
        /// </summary>
        [Description("Vest")] Vest = 0x00030009,

        /// <summary>
        ///     Animatronic Device Usage.
        /// </summary>
        [Description("Animatronic Device")] AnimatronicDevice = 0x0003000a,

        /// <summary>
        ///     Stereo Enable Usage.
        /// </summary>
        [Description("Stereo Enable")] StereoEnable = 0x00030020,

        /// <summary>
        ///     Display Enable Usage.
        /// </summary>
        [Description("Display Enable")] DisplayEnable = 0x00030021
    }
}