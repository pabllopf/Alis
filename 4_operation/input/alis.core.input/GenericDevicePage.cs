// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   GenericDevicePage.cs
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
    ///     Generic Device Controls Usage Page.
    /// </summary>
    [Description("Generic Device Controls Usage Page")]
    public enum GenericDevicePage : uint
    {
        /// <summary>
        ///     Undefined Usage.
        /// </summary>
        [Description("Undefined")] Undefined = 0x00060000,

        /// <summary>
        ///     Background Controls Usage.
        /// </summary>
        [Description("Background Controls")] BackgroundControls = 0x00060001,

        /// <summary>
        ///     Battery Strength Usage.
        /// </summary>
        [Description("Battery Strength")] BatteryStrength = 0x00060020,

        /// <summary>
        ///     Wireless Channel Usage.
        /// </summary>
        [Description("Wireless Channel")] WirelessChannel = 0x00060021,

        /// <summary>
        ///     Wireless ID Usage.
        /// </summary>
        [Description("Wireless ID")] WirelessID = 0x00060022,

        /// <summary>
        ///     Discover Wireless Control Usage.
        /// </summary>
        [Description("Discover Wireless Control")]
        DiscoverWirelessControl = 0x00060023,

        /// <summary>
        ///     Security Code Character Entered Usage.
        /// </summary>
        [Description("Security Code Character Entered")]
        SecurityCodeCharacterEntered = 0x00060024,

        /// <summary>
        ///     Security Code Character Erased Usage.
        /// </summary>
        [Description("Security Code Character Erased")]
        SecurityCodeCharacterErased = 0x00060025,

        /// <summary>
        ///     Security Code Cleared Usage.
        /// </summary>
        [Description("Security Code Cleared")] SecurityCodeCleared = 0x00060026,

        /// <summary>
        ///     Sequence ID Usage.
        /// </summary>
        [Description("Sequence ID")] SequenceID = 0x00060027,

        /// <summary>
        ///     Sequence ID Reset Usage.
        /// </summary>
        [Description("Sequence ID Reset")] SequenceIDReset = 0x00060028,

        /// <summary>
        ///     RF Signal Strength Usage.
        /// </summary>
        [Description("RF Signal Strength")] RFSignalStrength = 0x00060029,

        /// <summary>
        ///     Software Version Usage.
        /// </summary>
        [Description("Software Version")] SoftwareVersion = 0x0006002a,

        /// <summary>
        ///     Protocol Version Usage.
        /// </summary>
        [Description("Protocol Version")] ProtocolVersion = 0x0006002b,

        /// <summary>
        ///     Hardware Version Usage.
        /// </summary>
        [Description("Hardware Version")] HardwareVersion = 0x0006002c,

        /// <summary>
        ///     Major Usage.
        /// </summary>
        [Description("Major")] Major = 0x0006002d,

        /// <summary>
        ///     Minor Usage.
        /// </summary>
        [Description("Minor")] Minor = 0x0006002e,

        /// <summary>
        ///     Revision Usage.
        /// </summary>
        [Description("Revision")] Revision = 0x0006002f,

        /// <summary>
        ///     Handedness Usage.
        /// </summary>
        [Description("Handedness")] Handedness = 0x00060030,

        /// <summary>
        ///     Either Hand Usage.
        /// </summary>
        [Description("Either Hand")] EitherHand = 0x00060031,

        /// <summary>
        ///     Left Hand Usage.
        /// </summary>
        [Description("Left Hand")] LeftHand = 0x00060032,

        /// <summary>
        ///     Right Hand Usage.
        /// </summary>
        [Description("Right Hand")] RightHand = 0x00060033,

        /// <summary>
        ///     Both Hands Usage.
        /// </summary>
        [Description("Both Hands")] BothHands = 0x00060034,

        /// <summary>
        ///     Grip Pose Offset Usage.
        /// </summary>
        [Description("Grip Pose Offset")] GripPoseOffset = 0x00060040,

        /// <summary>
        ///     Pointer Pose Offset Usage.
        /// </summary>
        [Description("Pointer Pose Offset")] PointerPoseOffset = 0x00060041
    }
}