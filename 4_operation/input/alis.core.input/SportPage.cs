// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   SportPage.cs
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
    ///     Sport Controls Usage Page.
    /// </summary>
    [Description("Sport Controls Usage Page")]
    public enum SportPage : uint
    {
        /// <summary>
        ///     Undefined Usage.
        /// </summary>
        [Description("Undefined")]
        Undefined = 0x00040000,

        /// <summary>
        ///     Baseball Bat Usage.
        /// </summary>
        [Description("Baseball Bat")]
        BaseballBat = 0x00040001,

        /// <summary>
        ///     Golf Club Usage.
        /// </summary>
        [Description("Golf Club")]
        GolfClub = 0x00040002,

        /// <summary>
        ///     Rowing Machine Usage.
        /// </summary>
        [Description("Rowing Machine")]
        RowingMachine = 0x00040003,

        /// <summary>
        ///     Treadmill Usage.
        /// </summary>
        [Description("Treadmill")]
        Treadmill = 0x00040004,

        /// <summary>
        ///     Oar Usage.
        /// </summary>
        [Description("Oar")]
        Oar = 0x00040030,

        /// <summary>
        ///     Slope Usage.
        /// </summary>
        [Description("Slope")]
        Slope = 0x00040031,

        /// <summary>
        ///     Rate Usage.
        /// </summary>
        [Description("Rate")]
        Rate = 0x00040032,

        /// <summary>
        ///     Stick Speed Usage.
        /// </summary>
        [Description("Stick Speed")]
        StickSpeed = 0x00040033,

        /// <summary>
        ///     Stick Face Angle Usage.
        /// </summary>
        [Description("Stick Face Angle")]
        StickFaceAngle = 0x00040034,

        /// <summary>
        ///     Stick Heel/Toe Usage.
        /// </summary>
        [Description("Stick Heel/Toe")]
        StickHeelToe = 0x00040035,

        /// <summary>
        ///     Stick Follow Through Usage.
        /// </summary>
        [Description("Stick Follow Through")]
        StickFollowThrough = 0x00040036,

        /// <summary>
        ///     Stick Tempo Usage.
        /// </summary>
        [Description("Stick Tempo")]
        StickTempo = 0x00040037,

        /// <summary>
        ///     Stick Type Usage.
        /// </summary>
        [Description("Stick Type")]
        StickType = 0x00040038,

        /// <summary>
        ///     Stick Height Usage.
        /// </summary>
        [Description("Stick Height")]
        StickHeight = 0x00040039,

        /// <summary>
        ///     Putter Usage.
        /// </summary>
        [Description("Putter")]
        Putter = 0x00040050,

        /*
         * Range: 0x0051 -> 0x005b
         * {n+1} Iron
         */

        /// <summary>
        ///     1 Iron Usage.
        /// </summary>
        [Description("1 Iron")]
        Iron = 0x00040051,

        /// <summary>
        ///     2 Iron Usage.
        /// </summary>
        [Description("2 Iron")]
        Iron2 = 0x00040052,

        /// <summary>
        ///     3 Iron Usage.
        /// </summary>
        [Description("3 Iron")]
        Iron3 = 0x00040053,

        /// <summary>
        ///     4 Iron Usage.
        /// </summary>
        [Description("4 Iron")]
        Iron4 = 0x00040054,

        /// <summary>
        ///     5 Iron Usage.
        /// </summary>
        [Description("5 Iron")]
        Iron5 = 0x00040055,

        /// <summary>
        ///     6 Iron Usage.
        /// </summary>
        [Description("6 Iron")]
        Iron6 = 0x00040056,

        /// <summary>
        ///     7 Iron Usage.
        /// </summary>
        [Description("7 Iron")]
        Iron7 = 0x00040057,

        /// <summary>
        ///     8 Iron Usage.
        /// </summary>
        [Description("8 Iron")]
        Iron8 = 0x00040058,

        /// <summary>
        ///     9 Iron Usage.
        /// </summary>
        [Description("9 Iron")]
        Iron9 = 0x00040059,

        /// <summary>
        ///     10 Iron Usage.
        /// </summary>
        [Description("10 Iron")]
        Iron10 = 0x0004005a,

        /// <summary>
        ///     11 Iron Usage.
        /// </summary>
        [Description("11 Iron")]
        Iron11 = 0x0004005b,

        /// <summary>
        ///     Sand Wedge Usage.
        /// </summary>
        [Description("Sand Wedge")]
        SandWedge = 0x0004005c,

        /// <summary>
        ///     Loft Wedge Usage.
        /// </summary>
        [Description("Loft Wedge")]
        LoftWedge = 0x0004005d,

        /// <summary>
        ///     Power Wedge Usage.
        /// </summary>
        [Description("Power Wedge")]
        PowerWedge = 0x0004005e,

        /*
         * Range: 0x005f -> 0x0063
         * {2*n+1} Wood
         */

        /// <summary>
        ///     1 Wood Usage.
        /// </summary>
        [Description("1 Wood")]
        Wood = 0x0004005f,

        /// <summary>
        ///     3 Wood Usage.
        /// </summary>
        [Description("3 Wood")]
        Wood2 = 0x00040060,

        /// <summary>
        ///     5 Wood Usage.
        /// </summary>
        [Description("5 Wood")]
        Wood3 = 0x00040061,

        /// <summary>
        ///     7 Wood Usage.
        /// </summary>
        [Description("7 Wood")]
        Wood4 = 0x00040062,

        /// <summary>
        ///     9 Wood Usage.
        /// </summary>
        [Description("9 Wood")]
        Wood5 = 0x00040063
    }
}