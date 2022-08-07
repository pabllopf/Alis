// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ArcadePage.cs
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

namespace Alis.Core.Input
{
#pragma warning disable CS0108
    /// <summary>
    ///     Arcade Usage Page.
    /// </summary>
    [Description("Arcade Usage Page")]
    public enum ArcadePage : uint
    {
        /// <summary>
        ///     Undefined Usage.
        /// </summary>
        [Description("Undefined")] Undefined = 0x00910000,

        /// <summary>
        ///     General Purpose IO Card Usage.
        /// </summary>
        [Description("General Purpose IO Card")]
        GeneralPurposeIOCard = 0x00910001,

        /// <summary>
        ///     Coin Door Usage.
        /// </summary>
        [Description("Coin Door")] CoinDoor = 0x00910002,

        /// <summary>
        ///     Watchdog Timer Usage.
        /// </summary>
        [Description("Watchdog Timer")] WatchdogTimer = 0x00910003,

        /// <summary>
        ///     General Purpose Analog Input State Usage.
        /// </summary>
        [Description("General Purpose Analog Input State")]
        GeneralPurposeAnalogInputState = 0x00910030,

        /// <summary>
        ///     General Purpose Digital Input State Usage.
        /// </summary>
        [Description("General Purpose Digital Input State")]
        GeneralPurposeDigitalInputState = 0x00910031,

        /// <summary>
        ///     General Purpose Optical Input State Usage.
        /// </summary>
        [Description("General Purpose Optical Input State")]
        GeneralPurposeOpticalInputState = 0x00910032,

        /// <summary>
        ///     General Purpose Digital Output State Usage.
        /// </summary>
        [Description("General Purpose Digital Output State")]
        GeneralPurposeDigitalOutputState = 0x00910033,

        /// <summary>
        ///     Number of Coin Doors Usage.
        /// </summary>
        [Description("Number of Coin Doors")] NumberOfCoinDoors = 0x00910034,

        /// <summary>
        ///     Coin Drawer Drop Count Usage.
        /// </summary>
        [Description("Coin Drawer Drop Count")]
        CoinDrawerDropCount = 0x00910035,

        /// <summary>
        ///     Coin Drawer Start Usage.
        /// </summary>
        [Description("Coin Drawer Start")] CoinDrawerStart = 0x00910036,

        /// <summary>
        ///     Coin Drawer Service Usage.
        /// </summary>
        [Description("Coin Drawer Service")] CoinDrawerService = 0x00910037,

        /// <summary>
        ///     Coin Drawer Tilt Usage.
        /// </summary>
        [Description("Coin Drawer Tilt")] CoinDrawerTilt = 0x00910038,

        /// <summary>
        ///     Coin Door Test Usage.
        /// </summary>
        [Description("Coin Door Test")] CoinDoorTest = 0x00910039,

        /// <summary>
        ///     Coin Door Lockout Usage.
        /// </summary>
        [Description("Coin Door Lockout")] CoinDoorLockout = 0x00910040,

        /// <summary>
        ///     Watchdog Timeout Usage.
        /// </summary>
        [Description("Watchdog Timeout")] WatchdogTimeout = 0x00910041,

        /// <summary>
        ///     Watchdog Action Usage.
        /// </summary>
        [Description("Watchdog Action")] WatchdogAction = 0x00910042,

        /// <summary>
        ///     Watchdog Reboot Usage.
        /// </summary>
        [Description("Watchdog Reboot")] WatchdogReboot = 0x00910043,

        /// <summary>
        ///     Watchdog Restart Usage.
        /// </summary>
        [Description("Watchdog Restart")] WatchdogRestart = 0x00910044,

        /// <summary>
        ///     Alarm Input Usage.
        /// </summary>
        [Description("Alarm Input")] AlarmInput = 0x00910045,

        /// <summary>
        ///     Coin Door Counter Usage.
        /// </summary>
        [Description("Coin Door Counter")] CoinDoorCounter = 0x00910046,

        /// <summary>
        ///     I/O Direction Mapping Usage.
        /// </summary>
        [Description("I/O Direction Mapping")] IODirectionMapping = 0x00910047,

        /// <summary>
        ///     Set I/O Direction Usage.
        /// </summary>
        [Description("Set I/O Direction")] SetIODirection = 0x00910048,

        /// <summary>
        ///     Extended Optical Input State Usage.
        /// </summary>
        [Description("Extended Optical Input State")]
        ExtendedOpticalInputState = 0x00910049,

        /// <summary>
        ///     Pin Pad Input State Usage.
        /// </summary>
        [Description("Pin Pad Input State")] PinPadInputState = 0x0091004a,

        /// <summary>
        ///     Pin Pad Status Usage.
        /// </summary>
        [Description("Pin Pad Status")] PinPadStatus = 0x0091004b,

        /// <summary>
        ///     Pin Pad Output Usage.
        /// </summary>
        [Description("Pin Pad Output")] PinPadOutput = 0x0091004c,

        /// <summary>
        ///     Pin Pad Command Usage.
        /// </summary>
        [Description("Pin Pad Command")] PinPadCommand = 0x0091004d
    }
}