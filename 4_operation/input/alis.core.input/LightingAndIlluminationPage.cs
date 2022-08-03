// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   LightingAndIlluminationPage.cs
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
    ///     Lighting and Illumination Usage Page.
    /// </summary>
    [Description("Lighting and Illumination Usage Page")]
    public enum LightingAndIlluminationPage : uint
    {
        /// <summary>
        ///     Undefined Usage.
        /// </summary>
        [Description("Undefined")] Undefined = 0x00590000,

        /// <summary>
        ///     Lamp Array Usage.
        /// </summary>
        [Description("Lamp Array")] LampArray = 0x00590001,

        /// <summary>
        ///     Lamp Array Attributes Report Usage.
        /// </summary>
        [Description("Lamp Array Attributes Report")]
        LampArrayAttributesReport = 0x00590002,

        /// <summary>
        ///     Lamp Count Usage.
        /// </summary>
        [Description("Lamp Count")] LampCount = 0x00590003,

        /// <summary>
        ///     Bounding Box Width (um) Usage.
        /// </summary>
        [Description("Bounding Box Width (um)")]
        BoundingBoxWidthUm = 0x00590004,

        /// <summary>
        ///     Bounding Box Height (um) Usage.
        /// </summary>
        [Description("Bounding Box Height (um)")]
        BoundingBoxHeightUm = 0x00590005,

        /// <summary>
        ///     Bounding Box Depth (um) Usage.
        /// </summary>
        [Description("Bounding Box Depth (um)")]
        BoundingBoxDepthUm = 0x00590006,

        /// <summary>
        ///     Lamp Array Kind Usage.
        /// </summary>
        [Description("Lamp Array Kind")] LampArrayKind = 0x00590007,

        /// <summary>
        ///     Minimal Update Interval (us) Usage.
        /// </summary>
        [Description("Minimal Update Interval (us)")]
        MinimalUpdateIntervalUs = 0x00590008,

        /// <summary>
        ///     Lamp Attributes Request Report Usage.
        /// </summary>
        [Description("Lamp Attributes Request Report")]
        LampAttributesRequestReport = 0x00590020,

        /// <summary>
        ///     Lamp ID Usage.
        /// </summary>
        [Description("Lamp ID")] LampID = 0x00590021,

        /// <summary>
        ///     Lamp Attributes Response Report Usage.
        /// </summary>
        [Description("Lamp Attributes Response Report")]
        LampAttributesResponseReport = 0x00590022,

        /// <summary>
        ///     Position X (um) Usage.
        /// </summary>
        [Description("Position X (um)")] PositionXUm = 0x00590023,

        /// <summary>
        ///     Position Y (um) Usage.
        /// </summary>
        [Description("Position Y (um)")] PositionYUm = 0x00590024,

        /// <summary>
        ///     Position Z (um) Usage.
        /// </summary>
        [Description("Position Z (um)")] PositionZUm = 0x00590025,

        /// <summary>
        ///     Lamp Purposes Usage.
        /// </summary>
        [Description("Lamp Purposes")] LampPurposes = 0x00590026,

        /// <summary>
        ///     Update Latency (us) Usage.
        /// </summary>
        [Description("Update Latency (us)")] UpdateLatencyUs = 0x00590027,

        /// <summary>
        ///     Red Level Count Usage.
        /// </summary>
        [Description("Red Level Count")] RedLevelCount = 0x00590028,

        /// <summary>
        ///     Green Level Count Usage.
        /// </summary>
        [Description("Green Level Count")] GreenLevelCount = 0x00590029,

        /// <summary>
        ///     Blue Level Count Usage.
        /// </summary>
        [Description("Blue Level Count")] BlueLevelCount = 0x0059002a,

        /// <summary>
        ///     Intensity Level Count Usage.
        /// </summary>
        [Description("Intensity Level Count")] IntensityLevelCount = 0x0059002b,

        /// <summary>
        ///     Programmable Usage.
        /// </summary>
        [Description("Programmable")] Programmable = 0x0059002c,

        /// <summary>
        ///     Input Binding Usage.
        /// </summary>
        [Description("Input Binding")] InputBinding = 0x0059002d,

        /// <summary>
        ///     Lamp Multi Update Report Usage.
        /// </summary>
        [Description("Lamp Multi Update Report")]
        LampMultiUpdateReport = 0x00590050,

        /// <summary>
        ///     Red Update Channel Usage.
        /// </summary>
        [Description("Red Update Channel")] RedUpdateChannel = 0x00590051,

        /// <summary>
        ///     Green Update Channel Usage.
        /// </summary>
        [Description("Green Update Channel")] GreenUpdateChannel = 0x00590052,

        /// <summary>
        ///     Blue Update Channel Usage.
        /// </summary>
        [Description("Blue Update Channel")] BlueUpdateChannel = 0x00590053,

        /// <summary>
        ///     Intensity Update Channel Usage.
        /// </summary>
        [Description("Intensity Update Channel")]
        IntensityUpdateChannel = 0x00590054,

        /// <summary>
        ///     Lamp Update Flags Usage.
        /// </summary>
        [Description("Lamp Update Flags")] LampUpdateFlags = 0x00590055,

        /// <summary>
        ///     Lamp Range Update Report Usage.
        /// </summary>
        [Description("Lamp Range Update Report")]
        LampRangeUpdateReport = 0x00590060,

        /// <summary>
        ///     Lamp ID Start Usage.
        /// </summary>
        [Description("Lamp ID Start")] LampIDStart = 0x00590061,

        /// <summary>
        ///     Lamp ID End Usage.
        /// </summary>
        [Description("Lamp ID End")] LampIDEnd = 0x00590062,

        /// <summary>
        ///     Lamp Array Control Report Usage.
        /// </summary>
        [Description("Lamp Array Control Report")]
        LampArrayControlReport = 0x00590070,

        /// <summary>
        ///     Autonomous Mode Usage.
        /// </summary>
        [Description("Autonomous Mode")] AutonomousMode = 0x00590071,

        /// <summary>
        ///     Lamp Array Kind Keyboard Usage.
        /// </summary>
        [Description("Lamp Array Kind Keyboard")]
        LampArrayKindKeyboard = 0x00591000,

        /// <summary>
        ///     Lamp Array Kind Mouse Usage.
        /// </summary>
        [Description("Lamp Array Kind Mouse")] LampArrayKindMouse = 0x00591000,

        /// <summary>
        ///     Lamp Array Kind Game Controller Usage.
        /// </summary>
        [Description("Lamp Array Kind Game Controller")]
        LampArrayKindGameController = 0x00591000,

        /// <summary>
        ///     Lamp Array Kind Peripheral Usage.
        /// </summary>
        [Description("Lamp Array Kind Peripheral")]
        LampArrayKindPeripheral = 0x00591000,

        /// <summary>
        ///     Lamp Array Kind Scene Usage.
        /// </summary>
        [Description("Lamp Array Kind Scene")] LampArrayKindScene = 0x00591000,

        /// <summary>
        ///     Lamp Array Kind Notification Usage.
        /// </summary>
        [Description("Lamp Array Kind Notification")]
        LampArrayKindNotification = 0x00591000,

        /// <summary>
        ///     Lamp Array Kind Chassis Usage.
        /// </summary>
        [Description("Lamp Array Kind Chassis")]
        LampArrayKindChassis = 0x00591000,

        /// <summary>
        ///     Lamp Array Kind Wearable Usage.
        /// </summary>
        [Description("Lamp Array Kind Wearable")]
        LampArrayKindWearable = 0x00591000,

        /// <summary>
        ///     Lamp Array Kind Furniture Usage.
        /// </summary>
        [Description("Lamp Array Kind Furniture")]
        LampArrayKindFurniture = 0x00591000,

        /// <summary>
        ///     Lamp Array Kind Art Usage.
        /// </summary>
        [Description("Lamp Array Kind Art")] LampArrayKindArt = 0x00591000,

        /// <summary>
        ///     Lamp Purpose Control Usage.
        /// </summary>
        [Description("Lamp Purpose Control")] LampPurposeControl = 0x00592000,

        /// <summary>
        ///     Lamp Purpose Accent Usage.
        /// </summary>
        [Description("Lamp Purpose Accent")] LampPurposeAccent = 0x00592000,

        /// <summary>
        ///     Lamp Purpose Branding Usage.
        /// </summary>
        [Description("Lamp Purpose Branding")] LampPurposeBranding = 0x00592000,

        /// <summary>
        ///     Lamp Purpose Status Usage.
        /// </summary>
        [Description("Lamp Purpose Status")] LampPurposeStatus = 0x00592000,

        /// <summary>
        ///     Lamp Purpose Illumination Usage.
        /// </summary>
        [Description("Lamp Purpose Illumination")]
        LampPurposeIllumination = 0x00592000,

        /// <summary>
        ///     Lamp Purpose Presentation Usage.
        /// </summary>
        [Description("Lamp Purpose Presentation")]
        LampPurposePresentation = 0x00592000
    }
}