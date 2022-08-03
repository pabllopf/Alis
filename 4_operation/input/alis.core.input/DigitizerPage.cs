// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   DigitizerPage.cs
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
    ///     Digitizer Usage Page.
    /// </summary>
    [Description("Digitizer Usage Page")]
    public enum DigitizerPage : uint
    {
        /// <summary>
        ///     Undefined Usage.
        /// </summary>
        [Description("Undefined")]
        Undefined = 0x000d0000,

        /// <summary>
        ///     Digitizer Usage.
        /// </summary>
        [Description("Digitizer")]
        Digitizer = 0x000d0001,

        /// <summary>
        ///     Pen Usage.
        /// </summary>
        [Description("Pen")]
        Pen = 0x000d0002,

        /// <summary>
        ///     Light Pen Usage.
        /// </summary>
        [Description("Light Pen")]
        LightPen = 0x000d0003,

        /// <summary>
        ///     Touch Screen Usage.
        /// </summary>
        [Description("Touch Screen")]
        TouchScreen = 0x000d0004,

        /// <summary>
        ///     Touch Pad Usage.
        /// </summary>
        [Description("Touch Pad")]
        TouchPad = 0x000d0005,

        /// <summary>
        ///     White Board Usage.
        /// </summary>
        [Description("White Board")]
        WhiteBoard = 0x000d0006,

        /// <summary>
        ///     Coordinate Measuring Machine Usage.
        /// </summary>
        [Description("Coordinate Measuring Machine")]
        CoordinateMeasuringMachine = 0x000d0007,

        /// <summary>
        ///     3D Digitizer Usage.
        /// </summary>
        [Description("3D Digitizer")]
        DDigitizer = 0x000d0008,

        /// <summary>
        ///     Stereo Plotter Usage.
        /// </summary>
        [Description("Stereo Plotter")]
        StereoPlotter = 0x000d0009,

        /// <summary>
        ///     Articulated Arm Usage.
        /// </summary>
        [Description("Articulated Arm")]
        ArticulatedArm = 0x000d000a,

        /// <summary>
        ///     Armature Usage.
        /// </summary>
        [Description("Armature")]
        Armature = 0x000d000b,

        /// <summary>
        ///     Multiple Point Digitizer Usage.
        /// </summary>
        [Description("Multiple Point Digitizer")]
        MultiplePointDigitizer = 0x000d000c,

        /// <summary>
        ///     Free Space Wand Usage.
        /// </summary>
        [Description("Free Space Wand")]
        FreeSpaceWand = 0x000d000d,

        /// <summary>
        ///     Device Configuration Usage.
        /// </summary>
        [Description("Device Configuration")]
        DeviceConfiguration = 0x000d000e,

        /// <summary>
        ///     Capacitive Heat Map Digitizer Usage.
        /// </summary>
        [Description("Capacitive Heat Map Digitizer")]
        CapacitiveHeatMapDigitizer = 0x000d000f,

        /// <summary>
        ///     Stylus Usage.
        /// </summary>
        [Description("Stylus")]
        Stylus = 0x000d0020,

        /// <summary>
        ///     Puck Usage.
        /// </summary>
        [Description("Puck")]
        Puck = 0x000d0021,

        /// <summary>
        ///     Finger Usage.
        /// </summary>
        [Description("Finger")]
        Finger = 0x000d0022,

        /// <summary>
        ///     Device Settings Usage.
        /// </summary>
        [Description("Device Settings")]
        DeviceSettings = 0x000d0023,

        /// <summary>
        ///     Character Gesture Usage.
        /// </summary>
        [Description("Character Gesture")]
        CharacterGesture = 0x000d0024,

        /// <summary>
        ///     Tip Pressure Usage.
        /// </summary>
        [Description("Tip Pressure")]
        TipPressure = 0x000d0030,

        /// <summary>
        ///     Barrel Pressure Usage.
        /// </summary>
        [Description("Barrel Pressure")]
        BarrelPressure = 0x000d0031,

        /// <summary>
        ///     In Range Usage.
        /// </summary>
        [Description("In Range")]
        InRange = 0x000d0032,

        /// <summary>
        ///     Touch Usage.
        /// </summary>
        [Description("Touch")]
        Touch = 0x000d0033,

        /// <summary>
        ///     Untouch Usage.
        /// </summary>
        [Description("Untouch")]
        Untouch = 0x000d0034,

        /// <summary>
        ///     Tap Usage.
        /// </summary>
        [Description("Tap")]
        Tap = 0x000d0035,

        /// <summary>
        ///     Quality Usage.
        /// </summary>
        [Description("Quality")]
        Quality = 0x000d0036,

        /// <summary>
        ///     Data Valid Usage.
        /// </summary>
        [Description("Data Valid")]
        DataValid = 0x000d0037,

        /// <summary>
        ///     Transducer Index Usage.
        /// </summary>
        [Description("Transducer Index")]
        TransducerIndex = 0x000d0038,

        /// <summary>
        ///     Tablet Function Keys Usage.
        /// </summary>
        [Description("Tablet Function Keys")]
        TabletFunctionKeys = 0x000d0039,

        /// <summary>
        ///     Program Change Keys Usage.
        /// </summary>
        [Description("Program Change Keys")]
        ProgramChangeKeys = 0x000d003a,

        /// <summary>
        ///     Battery Strength Usage.
        /// </summary>
        [Description("Battery Strength")]
        BatteryStrength = 0x000d003b,

        /// <summary>
        ///     Invert Usage.
        /// </summary>
        [Description("Invert")]
        Invert = 0x000d003c,

        /// <summary>
        ///     X Tilt Usage.
        /// </summary>
        [Description("X Tilt")]
        XTilt = 0x000d003d,

        /// <summary>
        ///     Y Tilt Usage.
        /// </summary>
        [Description("Y Tilt")]
        YTilt = 0x000d003e,

        /// <summary>
        ///     Azimuth Usage.
        /// </summary>
        [Description("Azimuth")]
        Azimuth = 0x000d003f,

        /// <summary>
        ///     Altitude Usage.
        /// </summary>
        [Description("Altitude")]
        Altitude = 0x000d0040,

        /// <summary>
        ///     Twist Usage.
        /// </summary>
        [Description("Twist")]
        Twist = 0x000d0041,

        /// <summary>
        ///     Tip Switch Usage.
        /// </summary>
        [Description("Tip Switch")]
        TipSwitch = 0x000d0042,

        /// <summary>
        ///     Secondary Tip Switch Usage.
        /// </summary>
        [Description("Secondary Tip Switch")]
        SecondaryTipSwitch = 0x000d0043,

        /// <summary>
        ///     Barrel Switch Usage.
        /// </summary>
        [Description("Barrel Switch")]
        BarrelSwitch = 0x000d0044,

        /// <summary>
        ///     Eraser Usage.
        /// </summary>
        [Description("Eraser")]
        Eraser = 0x000d0045,

        /// <summary>
        ///     Tablet Pick Usage.
        /// </summary>
        [Description("Tablet Pick")]
        TabletPick = 0x000d0046,

        /// <summary>
        ///     Touch Valid Usage.
        /// </summary>
        [Description("Touch Valid")]
        TouchValid = 0x000d0047,

        /// <summary>
        ///     Width Usage.
        /// </summary>
        [Description("Width")]
        Width = 0x000d0048,

        /// <summary>
        ///     Height Usage.
        /// </summary>
        [Description("Height")]
        Height = 0x000d0049,

        /// <summary>
        ///     Contact Identifier Usage.
        /// </summary>
        [Description("Contact Identifier")]
        ContactIdentifier = 0x000d0051,

        /// <summary>
        ///     Device Mode Usage.
        /// </summary>
        [Description("Device Mode")]
        DeviceMode = 0x000d0052,

        /// <summary>
        ///     Device Identifier Usage.
        /// </summary>
        [Description("Device Identifier")]
        DeviceIdentifier = 0x000d0053,

        /// <summary>
        ///     Contact Count Usage.
        /// </summary>
        [Description("Contact Count")]
        ContactCount = 0x000d0054,

        /// <summary>
        ///     Contact Count Maximum Usage.
        /// </summary>
        [Description("Contact Count Maximum")]
        ContactCountMaximum = 0x000d0055,

        /// <summary>
        ///     Scan Time Usage.
        /// </summary>
        [Description("Scan Time")]
        ScanTime = 0x000d0056,

        /// <summary>
        ///     Surface Width Usage.
        /// </summary>
        [Description("Surface Width")]
        SurfaceWidth = 0x000d0057,

        /// <summary>
        ///     Button Switch Usage.
        /// </summary>
        [Description("Button Switch")]
        ButtonSwitch = 0x000d0058,

        /// <summary>
        ///     Pad Type Usage.
        /// </summary>
        [Description("Pad Type")]
        PadType = 0x000d0059,

        /// <summary>
        ///     Secondary Barrel Switch Usage.
        /// </summary>
        [Description("Secondary Barrel Switch")]
        SecondaryBarrelSwitch = 0x000d005a,

        /// <summary>
        ///     Transducer Serial Number Usage.
        /// </summary>
        [Description("Transducer Serial Number")]
        TransducerSerialNumber = 0x000d005b,

        /// <summary>
        ///     Preferred Color Usage.
        /// </summary>
        [Description("Preferred Color")]
        PreferredColor = 0x000d005c,

        /// <summary>
        ///     Latency Mode Usage.
        /// </summary>
        [Description("Latency Mode")]
        LatencyMode = 0x000d0060,

        /// <summary>
        ///     Gesture Character Quality Usage.
        /// </summary>
        [Description("Gesture Character Quality")]
        GestureCharacterQuality = 0x000d0061,

        /// <summary>
        ///     Character Gesture Data Length Usage.
        /// </summary>
        [Description("Character Gesture Data Length")]
        CharacterGestureDataLength = 0x000d0062,

        /// <summary>
        ///     Character Gesture Data Usage.
        /// </summary>
        [Description("Character Gesture Data")]
        CharacterGestureData = 0x000d0063,

        /// <summary>
        ///     Gesture Character Encoding Usage.
        /// </summary>
        [Description("Gesture Character Encoding")]
        GestureCharacterEncoding = 0x000d0064,

        /// <summary>
        ///     UTF8 Character Gesture Encoding Usage.
        /// </summary>
        [Description("UTF8 Character Gesture Encoding")]
        UTF8CharacterGestureEncoding = 0x000d0065,

        /// <summary>
        ///     UTF16 Little Endian Character Gesture Encoding Usage.
        /// </summary>
        [Description("UTF16 Little Endian Character Gesture Encoding")]
        UTF16LittleEndianCharacterGestureEncoding = 0x000d0066,

        /// <summary>
        ///     UTF16 Big Endian Character Gesture Encoding Usage.
        /// </summary>
        [Description("UTF16 Big Endian Character Gesture Encoding")]
        UTF16BigEndianCharacterGestureEncoding = 0x000d0067,

        /// <summary>
        ///     UTF32 Little Endian Character Gesture Encoding Usage.
        /// </summary>
        [Description("UTF32 Little Endian Character Gesture Encoding")]
        UTF32LittleEndianCharacterGestureEncoding = 0x000d0068,

        /// <summary>
        ///     UTF32 Big Endian Character Gesture Encoding Usage.
        /// </summary>
        [Description("UTF32 Big Endian Character Gesture Encoding")]
        UTF32BigEndianCharacterGestureEncoding = 0x000d0069,

        /// <summary>
        ///     Capacitive Heat Map Protocol Vendor ID Usage.
        /// </summary>
        [Description("Capacitive Heat Map Protocol Vendor ID")]
        CapacitiveHeatMapProtocolVendorID = 0x000d006a,

        /// <summary>
        ///     Capacitive Heat Map Protocol Version Usage.
        /// </summary>
        [Description("Capacitive Heat Map Protocol Version")]
        CapacitiveHeatMapProtocolVersion = 0x000d006b,

        /// <summary>
        ///     Capacitive Heat Map Frame Data Usage.
        /// </summary>
        [Description("Capacitive Heat Map Frame Data")]
        CapacitiveHeatMapFrameData = 0x000d006c,

        /// <summary>
        ///     Gesture Character Enable Usage.
        /// </summary>
        [Description("Gesture Character Enable")]
        GestureCharacterEnable = 0x000d006d,

        /// <summary>
        ///     Transducer Serial Number Part 2 Usage.
        /// </summary>
        [Description("Transducer Serial Number Part 2")]
        TransducerSerialNumberPart2 = 0x000d006e,

        /// <summary>
        ///     No Preferred Color Usage.
        /// </summary>
        [Description("No Preferred Color")]
        NoPreferredColor = 0x000d006f,

        /// <summary>
        ///     Transducer Software Info Usage.
        /// </summary>
        [Description("Transducer Software Info")]
        TransducerSoftwareInfo = 0x000d0090,

        /// <summary>
        ///     Transducer Vendor ID Usage.
        /// </summary>
        [Description("Transducer Vendor ID")]
        TransducerVendorID = 0x000d0091,

        /// <summary>
        ///     Transducer Product ID Usage.
        /// </summary>
        [Description("Transducer Product ID")]
        TransducerProductID = 0x000d0092,

        /// <summary>
        ///     Device Supported Protocols Usage.
        /// </summary>
        [Description("Device Supported Protocols")]
        DeviceSupportedProtocols = 0x000d0093,

        /// <summary>
        ///     Transducer Supported Protocols Usage.
        /// </summary>
        [Description("Transducer Supported Protocols")]
        TransducerSupportedProtocols = 0x000d0094,

        /// <summary>
        ///     No Protocol Usage.
        /// </summary>
        [Description("No Protocol")]
        NoProtocol = 0x000d0095,

        /// <summary>
        ///     Wacom AES Protocol Usage.
        /// </summary>
        [Description("Wacom AES Protocol")]
        WacomAESProtocol = 0x000d0096,

        /// <summary>
        ///     USI Protocol Usage.
        /// </summary>
        [Description("USI Protocol")]
        USIProtocol = 0x000d0097,

        /// <summary>
        ///     Microsoft Pen Protocol Usage.
        /// </summary>
        [Description("Microsoft Pen Protocol")]
        MicrosoftPenProtocol = 0x000d0098,

        /// <summary>
        ///     Supported Report Rates Usage.
        /// </summary>
        [Description("Supported Report Rates")]
        SupportedReportRates = 0x000d00a0,

        /// <summary>
        ///     Report Rate Usage.
        /// </summary>
        [Description("Report Rate")]
        ReportRate = 0x000d00a1,

        /// <summary>
        ///     Transducer Connected Usage.
        /// </summary>
        [Description("Transducer Connected")]
        TransducerConnected = 0x000d00a2,

        /// <summary>
        ///     Switch Disabled Usage.
        /// </summary>
        [Description("Switch Disabled")]
        SwitchDisabled = 0x000d00a3,

        /// <summary>
        ///     Switch Unimplemented Usage.
        /// </summary>
        [Description("Switch Unimplemented")]
        SwitchUnimplemented = 0x000d00a4,

        /// <summary>
        ///     Transducer Switches Usage.
        /// </summary>
        [Description("Transducer Switches")]
        TransducerSwitches = 0x000d00a5
    }
}