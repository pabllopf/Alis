// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   SensorPage.cs
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
    ///     Sensor Usage Page.
    /// </summary>
    [Description("Sensor Usage Page")]
    public enum SensorPage : uint
    {
        /// <summary>
        ///     Undefined Usage.
        /// </summary>
        [Description("Undefined")]
        Undefined = 0x00200000,

        /// <summary>
        ///     Sensor Usage.
        /// </summary>
        [Description("Sensor")]
        Sensor = 0x00200001,

        /// <summary>
        ///     Biometric Usage.
        /// </summary>
        [Description("Biometric")]
        Biometric = 0x00200010,

        /// <summary>
        ///     Biometric: Human Presence Usage.
        /// </summary>
        [Description("Biometric: Human Presence")]
        BiometricHumanPresence = 0x00200011,

        /// <summary>
        ///     Biometric: Human Proximity Usage.
        /// </summary>
        [Description("Biometric: Human Proximity")]
        BiometricHumanProximity = 0x00200012,

        /// <summary>
        ///     Biometric: Human Touch Usage.
        /// </summary>
        [Description("Biometric: Human Touch")]
        BiometricHumanTouch = 0x00200013,

        /// <summary>
        ///     Biometric: Blood Pressure Usage.
        /// </summary>
        [Description("Biometric: Blood Pressure")]
        BiometricBloodPressure = 0x00200014,

        /// <summary>
        ///     Biometric: Body Temperature Usage.
        /// </summary>
        [Description("Biometric: Body Temperature")]
        BiometricBodyTemperature = 0x00200015,

        /// <summary>
        ///     Biometric: Heart Rate Usage.
        /// </summary>
        [Description("Biometric: Heart Rate")]
        BiometricHeartRate = 0x00200016,

        /// <summary>
        ///     Biometric: Heart Rate Variability Usage.
        /// </summary>
        [Description("Biometric: Heart Rate Variability")]
        BiometricHeartRateVariability = 0x00200017,

        /// <summary>
        ///     Biometric: Peripheral Oxygen Saturation Usage.
        /// </summary>
        [Description("Biometric: Peripheral Oxygen Saturation")]
        BiometricPeripheralOxygenSaturation = 0x00200018,

        /// <summary>
        ///     Biometric: Respiratory Rate Usage.
        /// </summary>
        [Description("Biometric: Respiratory Rate")]
        BiometricRespiratoryRate = 0x00200019,

        /// <summary>
        ///     Electrical Usage.
        /// </summary>
        [Description("Electrical")]
        Electrical = 0x00200020,

        /// <summary>
        ///     Electrical: Capacitance Usage.
        /// </summary>
        [Description("Electrical: Capacitance")]
        ElectricalCapacitance = 0x00200021,

        /// <summary>
        ///     Electrical: Current Usage.
        /// </summary>
        [Description("Electrical: Current")]
        ElectricalCurrent = 0x00200022,

        /// <summary>
        ///     Electrical: Power Usage.
        /// </summary>
        [Description("Electrical: Power")]
        ElectricalPower = 0x00200023,

        /// <summary>
        ///     Electrical: Inductance Usage.
        /// </summary>
        [Description("Electrical: Inductance")]
        ElectricalInductance = 0x00200024,

        /// <summary>
        ///     Electrical: Resistance Usage.
        /// </summary>
        [Description("Electrical: Resistance")]
        ElectricalResistance = 0x00200025,

        /// <summary>
        ///     Electrical: Voltage Usage.
        /// </summary>
        [Description("Electrical: Voltage")]
        ElectricalVoltage = 0x00200026,

        /// <summary>
        ///     Electrical: Potentiometer Usage.
        /// </summary>
        [Description("Electrical: Potentiometer")]
        ElectricalPotentiometer = 0x00200027,

        /// <summary>
        ///     Electrical: Frequency Usage.
        /// </summary>
        [Description("Electrical: Frequency")]
        ElectricalFrequency = 0x00200028,

        /// <summary>
        ///     Electrical: Period Usage.
        /// </summary>
        [Description("Electrical: Period")]
        ElectricalPeriod = 0x00200029,

        /// <summary>
        ///     Environmental Usage.
        /// </summary>
        [Description("Environmental")]
        Environmental = 0x00200030,

        /// <summary>
        ///     Environmental: Atmospheric Pressure Usage.
        /// </summary>
        [Description("Environmental: Atmospheric Pressure")]
        EnvironmentalAtmosphericPressure = 0x00200031,

        /// <summary>
        ///     Environmental: Humidity Usage.
        /// </summary>
        [Description("Environmental: Humidity")]
        EnvironmentalHumidity = 0x00200032,

        /// <summary>
        ///     Environmental: Temperature Usage.
        /// </summary>
        [Description("Environmental: Temperature")]
        EnvironmentalTemperature = 0x00200033,

        /// <summary>
        ///     Environmental: Wind Direction Usage.
        /// </summary>
        [Description("Environmental: Wind Direction")]
        EnvironmentalWindDirection = 0x00200034,

        /// <summary>
        ///     Environmental: Wind Speed Usage.
        /// </summary>
        [Description("Environmental: Wind Speed")]
        EnvironmentalWindSpeed = 0x00200035,

        /// <summary>
        ///     Environmental: Air Quality Usage.
        /// </summary>
        [Description("Environmental: Air Quality")]
        EnvironmentalAirQuality = 0x00200036,

        /// <summary>
        ///     Environmental: Heat Index Usage.
        /// </summary>
        [Description("Environmental: Heat Index")]
        EnvironmentalHeatIndex = 0x00200037,

        /// <summary>
        ///     Environmental: Surface Temperature Usage.
        /// </summary>
        [Description("Environmental: Surface Temperature")]
        EnvironmentalSurfaceTemperature = 0x00200038,

        /// <summary>
        ///     Environmental: Volatile Organic Compounds Usage.
        /// </summary>
        [Description("Environmental: Volatile Organic Compounds")]
        EnvironmentalVolatileOrganicCompounds = 0x00200039,

        /// <summary>
        ///     Environmental: Object Presence Usage.
        /// </summary>
        [Description("Environmental: Object Presence")]
        EnvironmentalObjectPresence = 0x0020003a,

        /// <summary>
        ///     Environmental: Object Proximity Usage.
        /// </summary>
        [Description("Environmental: Object Proximity")]
        EnvironmentalObjectProximity = 0x0020003b,

        /// <summary>
        ///     Light Usage.
        /// </summary>
        [Description("Light")]
        Light = 0x00200040,

        /// <summary>
        ///     Light: Ambient Light Usage.
        /// </summary>
        [Description("Light: Ambient Light")]
        LightAmbientLight = 0x00200041,

        /// <summary>
        ///     Light: Consumer Infrared Usage.
        /// </summary>
        [Description("Light: Consumer Infrared")]
        LightConsumerInfrared = 0x00200042,

        /// <summary>
        ///     Light: Infrared Light Usage.
        /// </summary>
        [Description("Light: Infrared Light")]
        LightInfraredLight = 0x00200043,

        /// <summary>
        ///     Light: Visible Light Usage.
        /// </summary>
        [Description("Light: Visible Light")]
        LightVisibleLight = 0x00200044,

        /// <summary>
        ///     Light: Ultraviolet Light Usage.
        /// </summary>
        [Description("Light: Ultraviolet Light")]
        LightUltravioletLight = 0x00200045,

        /// <summary>
        ///     Location Usage.
        /// </summary>
        [Description("Location")]
        Location = 0x00200050,

        /// <summary>
        ///     Location: Broadcast Usage.
        /// </summary>
        [Description("Location: Broadcast")]
        LocationBroadcast = 0x00200051,

        /// <summary>
        ///     Location: Dead Reckoning Usage.
        /// </summary>
        [Description("Location: Dead Reckoning")]
        LocationDeadReckoning = 0x00200052,

        /// <summary>
        ///     Location: GPS Usage.
        /// </summary>
        [Description("Location: GPS")]
        LocationGPS = 0x00200053,

        /// <summary>
        ///     Location: Lookup Usage.
        /// </summary>
        [Description("Location: Lookup")]
        LocationLookup = 0x00200054,

        /// <summary>
        ///     Location: Other Usage.
        /// </summary>
        [Description("Location: Other")]
        LocationOther = 0x00200055,

        /// <summary>
        ///     Location: Static Usage.
        /// </summary>
        [Description("Location: Static")]
        LocationStatic = 0x00200056,

        /// <summary>
        ///     Location: Triangulation Usage.
        /// </summary>
        [Description("Location: Triangulation")]
        LocationTriangulation = 0x00200057,

        /// <summary>
        ///     Mechanical Usage.
        /// </summary>
        [Description("Mechanical")]
        Mechanical = 0x00200060,

        /// <summary>
        ///     Mechanical: Boolean Switch Usage.
        /// </summary>
        [Description("Mechanical: Boolean Switch")]
        MechanicalBooleanSwitch = 0x00200061,

        /// <summary>
        ///     Mechanical: Boolean Switch Array Usage.
        /// </summary>
        [Description("Mechanical: Boolean Switch Array")]
        MechanicalBooleanSwitchArray = 0x00200062,

        /// <summary>
        ///     Mechanical: Multivalue Switch Usage.
        /// </summary>
        [Description("Mechanical: Multivalue Switch")]
        MechanicalMultivalueSwitch = 0x00200063,

        /// <summary>
        ///     Mechanical: Force Usage.
        /// </summary>
        [Description("Mechanical: Force")]
        MechanicalForce = 0x00200064,

        /// <summary>
        ///     Mechanical: Pressure Usage.
        /// </summary>
        [Description("Mechanical: Pressure")]
        MechanicalPressure = 0x00200065,

        /// <summary>
        ///     Mechanical: Strain Usage.
        /// </summary>
        [Description("Mechanical: Strain")]
        MechanicalStrain = 0x00200066,

        /// <summary>
        ///     Mechanical: Weight Usage.
        /// </summary>
        [Description("Mechanical: Weight")]
        MechanicalWeight = 0x00200067,

        /// <summary>
        ///     Mechanical: Haptic Vibrator Usage.
        /// </summary>
        [Description("Mechanical: Haptic Vibrator")]
        MechanicalHapticVibrator = 0x00200068,

        /// <summary>
        ///     Mechanical: Hall Effect Switch Usage.
        /// </summary>
        [Description("Mechanical: Hall Effect Switch")]
        MechanicalHallEffectSwitch = 0x00200069,

        /// <summary>
        ///     Motion Usage.
        /// </summary>
        [Description("Motion")]
        Motion = 0x00200070,

        /// <summary>
        ///     Motion: Accelerometer 1D Usage.
        /// </summary>
        [Description("Motion: Accelerometer 1D")]
        MotionAccelerometer1D = 0x00200071,

        /// <summary>
        ///     Motion: Accelerometer 2D Usage.
        /// </summary>
        [Description("Motion: Accelerometer 2D")]
        MotionAccelerometer2D = 0x00200072,

        /// <summary>
        ///     Motion: Accelerometer 3D Usage.
        /// </summary>
        [Description("Motion: Accelerometer 3D")]
        MotionAccelerometer3D = 0x00200073,

        /// <summary>
        ///     Motion: Gyrometer 1D Usage.
        /// </summary>
        [Description("Motion: Gyrometer 1D")]
        MotionGyrometer1D = 0x00200074,

        /// <summary>
        ///     Motion: Gyrometer 2D Usage.
        /// </summary>
        [Description("Motion: Gyrometer 2D")]
        MotionGyrometer2D = 0x00200075,

        /// <summary>
        ///     Motion: Gyrometer 3D Usage.
        /// </summary>
        [Description("Motion: Gyrometer 3D")]
        MotionGyrometer3D = 0x00200076,

        /// <summary>
        ///     Motion: Motion Detector Usage.
        /// </summary>
        [Description("Motion: Motion Detector")]
        MotionMotionDetector = 0x00200077,

        /// <summary>
        ///     Motion: Speedometer Usage.
        /// </summary>
        [Description("Motion: Speedometer")]
        MotionSpeedometer = 0x00200078,

        /// <summary>
        ///     Motion: Accelerometer Usage.
        /// </summary>
        [Description("Motion: Accelerometer")]
        MotionAccelerometer = 0x00200079,

        /// <summary>
        ///     Motion: Gyrometer Usage.
        /// </summary>
        [Description("Motion: Gyrometer")]
        MotionGyrometer = 0x0020007a,

        /// <summary>
        ///     Motion: Gravity Vector Usage.
        /// </summary>
        [Description("Motion: Gravity Vector")]
        MotionGravityVector = 0x0020007b,

        /// <summary>
        ///     Motion: Linear Accelerometer Usage.
        /// </summary>
        [Description("Motion: Linear Accelerometer")]
        MotionLinearAccelerometer = 0x0020007c,

        /// <summary>
        ///     Orientation Usage.
        /// </summary>
        [Description("Orientation")]
        Orientation = 0x00200080,

        /// <summary>
        ///     Orientation: Compass 1D Usage.
        /// </summary>
        [Description("Orientation: Compass 1D")]
        OrientationCompass1D = 0x00200081,

        /// <summary>
        ///     Orientation: Compass 2D Usage.
        /// </summary>
        [Description("Orientation: Compass 2D")]
        OrientationCompass2D = 0x00200082,

        /// <summary>
        ///     Orientation: Compass 3D Usage.
        /// </summary>
        [Description("Orientation: Compass 3D")]
        OrientationCompass3D = 0x00200083,

        /// <summary>
        ///     Orientation: Inclinometer 1D Usage.
        /// </summary>
        [Description("Orientation: Inclinometer 1D")]
        OrientationInclinometer1D = 0x00200084,

        /// <summary>
        ///     Orientation: Inclinometer 2D Usage.
        /// </summary>
        [Description("Orientation: Inclinometer 2D")]
        OrientationInclinometer2D = 0x00200085,

        /// <summary>
        ///     Orientation: Inclinometer 3D Usage.
        /// </summary>
        [Description("Orientation: Inclinometer 3D")]
        OrientationInclinometer3D = 0x00200086,

        /// <summary>
        ///     Orientation: Distance 1D Usage.
        /// </summary>
        [Description("Orientation: Distance 1D")]
        OrientationDistance1D = 0x00200087,

        /// <summary>
        ///     Orientation: Distance 2D Usage.
        /// </summary>
        [Description("Orientation: Distance 2D")]
        OrientationDistance2D = 0x00200088,

        /// <summary>
        ///     Orientation: Distance 3D Usage.
        /// </summary>
        [Description("Orientation: Distance 3D")]
        OrientationDistance3D = 0x00200089,

        /// <summary>
        ///     Orientation: Device Orientation Usage.
        /// </summary>
        [Description("Orientation: Device Orientation")]
        OrientationDeviceOrientation = 0x0020008a,

        /// <summary>
        ///     Orientation: Compass Usage.
        /// </summary>
        [Description("Orientation: Compass")]
        OrientationCompass = 0x0020008b,

        /// <summary>
        ///     Orientation: Inclinometer Usage.
        /// </summary>
        [Description("Orientation: Inclinometer")]
        OrientationInclinometer = 0x0020008c,

        /// <summary>
        ///     Orientation: Distance Usage.
        /// </summary>
        [Description("Orientation: Distance")]
        OrientationDistance = 0x0020008d,

        /// <summary>
        ///     Orientation: Relative Orientation Usage.
        /// </summary>
        [Description("Orientation: Relative Orientation")]
        OrientationRelativeOrientation = 0x0020008e,

        /// <summary>
        ///     Orientation: Simple Orientation Usage.
        /// </summary>
        [Description("Orientation: Simple Orientation")]
        OrientationSimpleOrientation = 0x0020008f,

        /// <summary>
        ///     Scanner Usage.
        /// </summary>
        [Description("Scanner")]
        Scanner = 0x00200090,

        /// <summary>
        ///     Scanner: Barcode Usage.
        /// </summary>
        [Description("Scanner: Barcode")]
        ScannerBarcode = 0x00200091,

        /// <summary>
        ///     Scanner: RFID Usage.
        /// </summary>
        [Description("Scanner: RFID")]
        ScannerRFID = 0x00200092,

        /// <summary>
        ///     Scanner: NFC Usage.
        /// </summary>
        [Description("Scanner: NFC")]
        ScannerNFC = 0x00200093,

        /// <summary>
        ///     Time Usage.
        /// </summary>
        [Description("Time")]
        Time = 0x002000a0,

        /// <summary>
        ///     Time: Alarm Timer Usage.
        /// </summary>
        [Description("Time: Alarm Timer")]
        TimeAlarmTimer = 0x002000a1,

        /// <summary>
        ///     Time: Real Time Clock Usage.
        /// </summary>
        [Description("Time: Real Time Clock")]
        TimeRealTimeClock = 0x002000a2,

        /// <summary>
        ///     Personal Activity Usage.
        /// </summary>
        [Description("Personal Activity")]
        PersonalActivity = 0x002000b0,

        /// <summary>
        ///     Personal Activity: Activity Detection Usage.
        /// </summary>
        [Description("Personal Activity: Activity Detection")]
        PersonalActivityActivityDetection = 0x002000b1,

        /// <summary>
        ///     Personal Activity: Device Position Usage.
        /// </summary>
        [Description("Personal Activity: Device Position")]
        PersonalActivityDevicePosition = 0x002000b2,

        /// <summary>
        ///     Personal Activity: Pedometer Usage.
        /// </summary>
        [Description("Personal Activity: Pedometer")]
        PersonalActivityPedometer = 0x002000b3,

        /// <summary>
        ///     Personal Activity: Step Detection Usage.
        /// </summary>
        [Description("Personal Activity: Step Detection")]
        PersonalActivityStepDetection = 0x002000b4,

        /// <summary>
        ///     Orientation Extended Usage.
        /// </summary>
        [Description("Orientation Extended")]
        OrientationExtended = 0x002000c0,

        /// <summary>
        ///     Orientation Extended: Geomagnetic Orientation Usage.
        /// </summary>
        [Description("Orientation Extended: Geomagnetic Orientation")]
        OrientationExtendedGeomagneticOrientation = 0x002000c1,

        /// <summary>
        ///     Orientation Extended: Magnetometer Usage.
        /// </summary>
        [Description("Orientation Extended: Magnetometer")]
        OrientationExtendedMagnetometer = 0x002000c2,

        /// <summary>
        ///     Gesture Usage.
        /// </summary>
        [Description("Gesture")]
        Gesture = 0x002000d0,

        /// <summary>
        ///     Gesture: Chassis Flip Gesture Usage.
        /// </summary>
        [Description("Gesture: Chassis Flip Gesture")]
        GestureChassisFlipGesture = 0x002000d1,

        /// <summary>
        ///     Gesture: Hinge Fold Gesture Usage.
        /// </summary>
        [Description("Gesture: Hinge Fold Gesture")]
        GestureHingeFoldGesture = 0x002000d2,

        /// <summary>
        ///     Other Usage.
        /// </summary>
        [Description("Other")]
        Other = 0x002000e0,

        /// <summary>
        ///     Other: Custom Usage.
        /// </summary>
        [Description("Other: Custom")]
        OtherCustom = 0x002000e1,

        /// <summary>
        ///     Other: Generic Usage.
        /// </summary>
        [Description("Other: Generic")]
        OtherGeneric = 0x002000e2,

        /// <summary>
        ///     Other: Generic Enumerator Usage.
        /// </summary>
        [Description("Other: Generic Enumerator")]
        OtherGenericEnumerator = 0x002000e3,

        /// <summary>
        ///     Other: Hinge Angle Usage.
        /// </summary>
        [Description("Other: Hinge Angle")]
        OtherHingeAngle = 0x002000e4,

        /*
         * Range: 0x00f0 -> 0x00ff
         * Vendor Reserved {n+1}
         */

        /// <summary>
        ///     Vendor Reserved 1 Usage.
        /// </summary>
        [Description("Vendor Reserved 1")]
        VendorReserved1 = 0x002000f0,

        /// <summary>
        ///     Vendor Reserved 2 Usage.
        /// </summary>
        [Description("Vendor Reserved 2")]
        VendorReserved2 = 0x002000f1,

        /// <summary>
        ///     Vendor Reserved 3 Usage.
        /// </summary>
        [Description("Vendor Reserved 3")]
        VendorReserved3 = 0x002000f2,

        /// <summary>
        ///     Vendor Reserved 4 Usage.
        /// </summary>
        [Description("Vendor Reserved 4")]
        VendorReserved4 = 0x002000f3,

        /// <summary>
        ///     Vendor Reserved 5 Usage.
        /// </summary>
        [Description("Vendor Reserved 5")]
        VendorReserved5 = 0x002000f4,

        /// <summary>
        ///     Vendor Reserved 6 Usage.
        /// </summary>
        [Description("Vendor Reserved 6")]
        VendorReserved6 = 0x002000f5,

        /// <summary>
        ///     Vendor Reserved 7 Usage.
        /// </summary>
        [Description("Vendor Reserved 7")]
        VendorReserved7 = 0x002000f6,

        /// <summary>
        ///     Vendor Reserved 8 Usage.
        /// </summary>
        [Description("Vendor Reserved 8")]
        VendorReserved8 = 0x002000f7,

        /// <summary>
        ///     Vendor Reserved 9 Usage.
        /// </summary>
        [Description("Vendor Reserved 9")]
        VendorReserved9 = 0x002000f8,

        /// <summary>
        ///     Vendor Reserved 10 Usage.
        /// </summary>
        [Description("Vendor Reserved 10")]
        VendorReserved10 = 0x002000f9,

        /// <summary>
        ///     Vendor Reserved 11 Usage.
        /// </summary>
        [Description("Vendor Reserved 11")]
        VendorReserved11 = 0x002000fa,

        /// <summary>
        ///     Vendor Reserved 12 Usage.
        /// </summary>
        [Description("Vendor Reserved 12")]
        VendorReserved12 = 0x002000fb,

        /// <summary>
        ///     Vendor Reserved 13 Usage.
        /// </summary>
        [Description("Vendor Reserved 13")]
        VendorReserved13 = 0x002000fc,

        /// <summary>
        ///     Vendor Reserved 14 Usage.
        /// </summary>
        [Description("Vendor Reserved 14")]
        VendorReserved14 = 0x002000fd,

        /// <summary>
        ///     Vendor Reserved 15 Usage.
        /// </summary>
        [Description("Vendor Reserved 15")]
        VendorReserved15 = 0x002000fe,

        /// <summary>
        ///     Vendor Reserved 16 Usage.
        /// </summary>
        [Description("Vendor Reserved 16")]
        VendorReserved16 = 0x002000ff,

        /// <summary>
        ///     Event: Sensor State Usage.
        /// </summary>
        [Description("Event: Sensor State")]
        EventSensorState = 0x00200201,

        /// <summary>
        ///     Event: Sensor Event Usage.
        /// </summary>
        [Description("Event: Sensor Event")]
        EventSensorEvent = 0x00200202,

        /// <summary>
        ///     Property Usage.
        /// </summary>
        [Description("Property")]
        Property = 0x00200300,

        /// <summary>
        ///     Property: Friendly Name Usage.
        /// </summary>
        [Description("Property: Friendly Name")]
        PropertyFriendlyName = 0x00200301,

        /// <summary>
        ///     Property: Persistent Unique ID Usage.
        /// </summary>
        [Description("Property: Persistent Unique ID")]
        PropertyPersistentUniqueID = 0x00200302,

        /// <summary>
        ///     Property: Sensor Status Usage.
        /// </summary>
        [Description("Property: Sensor Status")]
        PropertySensorStatus = 0x00200303,

        /// <summary>
        ///     Property: Minimum Report Interval Usage.
        /// </summary>
        [Description("Property: Minimum Report Interval")]
        PropertyMinimumReportInterval = 0x00200304,

        /// <summary>
        ///     Property: Sensor Manufacturer Usage.
        /// </summary>
        [Description("Property: Sensor Manufacturer")]
        PropertySensorManufacturer = 0x00200305,

        /// <summary>
        ///     Property: Sensor Model Usage.
        /// </summary>
        [Description("Property: Sensor Model")]
        PropertySensorModel = 0x00200306,

        /// <summary>
        ///     Property: Sensor Serial Number Usage.
        /// </summary>
        [Description("Property: Sensor Serial Number")]
        PropertySensorSerialNumber = 0x00200307,

        /// <summary>
        ///     Property: Sensor Description Usage.
        /// </summary>
        [Description("Property: Sensor Description")]
        PropertySensorDescription = 0x00200308,

        /// <summary>
        ///     Property: Sensor Connection Type Usage.
        /// </summary>
        [Description("Property: Sensor Connection Type")]
        PropertySensorConnectionType = 0x00200309,

        /// <summary>
        ///     Property: Sensor Device Path Usage.
        /// </summary>
        [Description("Property: Sensor Device Path")]
        PropertySensorDevicePath = 0x0020030a,

        /// <summary>
        ///     Property: Sensor Hardware Revision Usage.
        /// </summary>
        [Description("Property: Sensor Hardware Revision")]
        PropertySensorHardwareRevision = 0x0020030b,

        /// <summary>
        ///     Property: Sensor Firmware Revision Usage.
        /// </summary>
        [Description("Property: Sensor Firmware Revision")]
        PropertySensorFirmwareRevision = 0x0020030c,

        /// <summary>
        ///     Property: Release Date Usage.
        /// </summary>
        [Description("Property: Release Date")]
        PropertyReleaseDate = 0x0020030d,

        /// <summary>
        ///     Property: Report Interval Usage.
        /// </summary>
        [Description("Property: Report Interval")]
        PropertyReportInterval = 0x0020030e,

        /// <summary>
        ///     Property: Change Sensitivity Absolute Usage.
        /// </summary>
        [Description("Property: Change Sensitivity Absolute")]
        PropertyChangeSensitivityAbsolute = 0x0020030f,

        /// <summary>
        ///     Property: Change Sensitivity Percent of Range Usage.
        /// </summary>
        [Description("Property: Change Sensitivity Percent of Range")]
        PropertyChangeSensitivityPercentOfRange = 0x00200310,

        /// <summary>
        ///     Property: Change Sensitivity Percent Relative Usage.
        /// </summary>
        [Description("Property: Change Sensitivity Percent Relative")]
        PropertyChangeSensitivityPercentRelative = 0x00200311,

        /// <summary>
        ///     Property: Accuracy Usage.
        /// </summary>
        [Description("Property: Accuracy")]
        PropertyAccuracy = 0x00200312,

        /// <summary>
        ///     Property: Resolution Usage.
        /// </summary>
        [Description("Property: Resolution")]
        PropertyResolution = 0x00200313,

        /// <summary>
        ///     Property: Maximum Usage.
        /// </summary>
        [Description("Property: Maximum")]
        PropertyMaximum = 0x00200314,

        /// <summary>
        ///     Property: Minimum Usage.
        /// </summary>
        [Description("Property: Minimum")]
        PropertyMinimum = 0x00200315,

        /// <summary>
        ///     Property: Reporting State Usage.
        /// </summary>
        [Description("Property: Reporting State")]
        PropertyReportingState = 0x00200316,

        /// <summary>
        ///     Property: Sampling Rate Usage.
        /// </summary>
        [Description("Property: Sampling Rate")]
        PropertySamplingRate = 0x00200317,

        /// <summary>
        ///     Property: Response Curve Usage.
        /// </summary>
        [Description("Property: Response Curve")]
        PropertyResponseCurve = 0x00200318,

        /// <summary>
        ///     Property: Power State Usage.
        /// </summary>
        [Description("Property: Power State")]
        PropertyPowerState = 0x00200319,

        /// <summary>
        ///     Property: Maximum FIFO Events Usage.
        /// </summary>
        [Description("Property: Maximum FIFO Events")]
        PropertyMaximumFIFOEvents = 0x0020031a,

        /// <summary>
        ///     Property: Report Latency Usage.
        /// </summary>
        [Description("Property: Report Latency")]
        PropertyReportLatency = 0x0020031b,

        /// <summary>
        ///     Property: Flush FIFO Events Usage.
        /// </summary>
        [Description("Property: Flush FIFO Events")]
        PropertyFlushFIFOEvents = 0x0020031c,

        /// <summary>
        ///     Property: Maximum Power Consumption Usage.
        /// </summary>
        [Description("Property: Maximum Power Consumption")]
        PropertyMaximumPowerConsumption = 0x0020031d,

        /// <summary>
        ///     Property: Is Primary Usage.
        /// </summary>
        [Description("Property: Is Primary")]
        PropertyIsPrimary = 0x0020031e,

        /// <summary>
        ///     Property: Human Presence Detection Type Usage.
        /// </summary>
        [Description("Property: Human Presence Detection Type")]
        PropertyHumanPresenceDetectionType = 0x0020031f,

        /// <summary>
        ///     Data Field: Location Usage.
        /// </summary>
        [Description("Data Field: Location")]
        DataFieldLocation = 0x00200400,

        /// <summary>
        ///     Data Field: Altitude Antenna Sea Level Usage.
        /// </summary>
        [Description("Data Field: Altitude Antenna Sea Level")]
        DataFieldAltitudeAntennaSeaLevel = 0x00200402,

        /// <summary>
        ///     Data Field: Differential Reference Station ID Usage.
        /// </summary>
        [Description("Data Field: Differential Reference Station ID")]
        DataFieldDifferentialReferenceStationID = 0x00200403,

        /// <summary>
        ///     Data Field: Altitude Ellipsoid Error Usage.
        /// </summary>
        [Description("Data Field: Altitude Ellipsoid Error")]
        DataFieldAltitudeEllipsoidError = 0x00200404,

        /// <summary>
        ///     Data Field: Altitude Ellipsoid Usage.
        /// </summary>
        [Description("Data Field: Altitude Ellipsoid")]
        DataFieldAltitudeEllipsoid = 0x00200405,

        /// <summary>
        ///     Data Field: Altitude Sea Level Error Usage.
        /// </summary>
        [Description("Data Field: Altitude Sea Level Error")]
        DataFieldAltitudeSeaLevelError = 0x00200406,

        /// <summary>
        ///     Data Field: Altitude Sea Level Usage.
        /// </summary>
        [Description("Data Field: Altitude Sea Level")]
        DataFieldAltitudeSeaLevel = 0x00200407,

        /// <summary>
        ///     Data Field: Differential GPS Data Age Usage.
        /// </summary>
        [Description("Data Field: Differential GPS Data Age")]
        DataFieldDifferentialGPSDataAge = 0x00200408,

        /// <summary>
        ///     Data Field: Error Radius Usage.
        /// </summary>
        [Description("Data Field: Error Radius")]
        DataFieldErrorRadius = 0x00200409,

        /// <summary>
        ///     Data Field: Fix Quality Usage.
        /// </summary>
        [Description("Data Field: Fix Quality")]
        DataFieldFixQuality = 0x0020040a,

        /// <summary>
        ///     Data Field: Fix Type Usage.
        /// </summary>
        [Description("Data Field: Fix Type")]
        DataFieldFixType = 0x0020040b,

        /// <summary>
        ///     Data Field: Geoidal Separation Usage.
        /// </summary>
        [Description("Data Field: Geoidal Separation")]
        DataFieldGeoidalSeparation = 0x0020040c,

        /// <summary>
        ///     Data Field: GPS Operation Mode Usage.
        /// </summary>
        [Description("Data Field: GPS Operation Mode")]
        DataFieldGPSOperationMode = 0x0020040d,

        /// <summary>
        ///     Data Field: GPS Selection Mode Usage.
        /// </summary>
        [Description("Data Field: GPS Selection Mode")]
        DataFieldGPSSelectionMode = 0x0020040e,

        /// <summary>
        ///     Data Field: GPS Status Usage.
        /// </summary>
        [Description("Data Field: GPS Status")]
        DataFieldGPSStatus = 0x0020040f,

        /// <summary>
        ///     Data Field: Position Dilution of Precision Usage.
        /// </summary>
        [Description("Data Field: Position Dilution of Precision")]
        DataFieldPositionDilutionOfPrecision = 0x00200410,

        /// <summary>
        ///     Data Field: Horizontal Dilution of Precision Usage.
        /// </summary>
        [Description("Data Field: Horizontal Dilution of Precision")]
        DataFieldHorizontalDilutionOfPrecision = 0x00200411,

        /// <summary>
        ///     Data Field: Vertical Dilution of Precision Usage.
        /// </summary>
        [Description("Data Field: Vertical Dilution of Precision")]
        DataFieldVerticalDilutionOfPrecision = 0x00200412,

        /// <summary>
        ///     Data Field: Latitude Usage.
        /// </summary>
        [Description("Data Field: Latitude")]
        DataFieldLatitude = 0x00200413,

        /// <summary>
        ///     Data Field: Longitude Usage.
        /// </summary>
        [Description("Data Field: Longitude")]
        DataFieldLongitude = 0x00200414,

        /// <summary>
        ///     Data Field: True Heading Usage.
        /// </summary>
        [Description("Data Field: True Heading")]
        DataFieldTrueHeading = 0x00200415,

        /// <summary>
        ///     Data Field: Magnetic Heading Usage.
        /// </summary>
        [Description("Data Field: Magnetic Heading")]
        DataFieldMagneticHeading = 0x00200416,

        /// <summary>
        ///     Data Field: Magnetic Variation Usage.
        /// </summary>
        [Description("Data Field: Magnetic Variation")]
        DataFieldMagneticVariation = 0x00200417,

        /// <summary>
        ///     Data Field: Speed Usage.
        /// </summary>
        [Description("Data Field: Speed")]
        DataFieldSpeed = 0x00200418,

        /// <summary>
        ///     Data Field: Satellites in View Usage.
        /// </summary>
        [Description("Data Field: Satellites in View")]
        DataFieldSatellitesInView = 0x00200419,

        /// <summary>
        ///     Data Field: Satellites in View Azimuth Usage.
        /// </summary>
        [Description("Data Field: Satellites in View Azimuth")]
        DataFieldSatellitesInViewAzimuth = 0x0020041a,

        /// <summary>
        ///     Data Field: Satellites in View Elevation Usage.
        /// </summary>
        [Description("Data Field: Satellites in View Elevation")]
        DataFieldSatellitesInViewElevation = 0x0020041b,

        /// <summary>
        ///     Data Field: Satellites in View IDs Usage.
        /// </summary>
        [Description("Data Field: Satellites in View IDs")]
        DataFieldSatellitesInViewIDs = 0x0020041c,

        /// <summary>
        ///     Data Field: Satellites in View PRNs Usage.
        /// </summary>
        [Description("Data Field: Satellites in View PRNs")]
        DataFieldSatellitesInViewPRNs = 0x0020041d,

        /// <summary>
        ///     Data Field: Satellites in View S/N Ratios Usage.
        /// </summary>
        [Description("Data Field: Satellites in View S/N Ratios")]
        DataFieldSatellitesInViewSNRatios = 0x0020041e,

        /// <summary>
        ///     Data Field: Satellites Used Count Usage.
        /// </summary>
        [Description("Data Field: Satellites Used Count")]
        DataFieldSatellitesUsedCount = 0x0020041f,

        /// <summary>
        ///     Data Field: Satellites Used PRNs Usage.
        /// </summary>
        [Description("Data Field: Satellites Used PRNs")]
        DataFieldSatellitesUsedPRNs = 0x00200420,

        /// <summary>
        ///     Data Field: NMEA Sentence Usage.
        /// </summary>
        [Description("Data Field: NMEA Sentence")]
        DataFieldNMEASentence = 0x00200421,

        /// <summary>
        ///     Data Field: Address Line 1 Usage.
        /// </summary>
        [Description("Data Field: Address Line 1")]
        DataFieldAddressLine1 = 0x00200422,

        /// <summary>
        ///     Data Field: Address Line 2 Usage.
        /// </summary>
        [Description("Data Field: Address Line 2")]
        DataFieldAddressLine2 = 0x00200423,

        /// <summary>
        ///     Data Field: City Usage.
        /// </summary>
        [Description("Data Field: City")]
        DataFieldCity = 0x00200424,

        /// <summary>
        ///     Data Field: State or Province Usage.
        /// </summary>
        [Description("Data Field: State or Province")]
        DataFieldStateOrProvince = 0x00200425,

        /// <summary>
        ///     Data Field: Country or Region (ISO 3166) Usage.
        /// </summary>
        [Description("Data Field: Country or Region (ISO 3166)")]
        DataFieldCountryOrRegionISO3166 = 0x00200426,

        /// <summary>
        ///     Data Field: Postal Code Usage.
        /// </summary>
        [Description("Data Field: Postal Code")]
        DataFieldPostalCode = 0x00200427,

        /// <summary>
        ///     Property: Location Desired Accuracy Usage.
        /// </summary>
        [Description("Property: Location Desired Accuracy")]
        PropertyLocationDesiredAccuracy = 0x0020042b,

        /// <summary>
        ///     Data Field: Environmental Usage.
        /// </summary>
        [Description("Data Field: Environmental")]
        DataFieldEnvironmental = 0x00200430,

        /// <summary>
        ///     Data Field: Atmospheric Pressure Usage.
        /// </summary>
        [Description("Data Field: Atmospheric Pressure")]
        DataFieldAtmosphericPressure = 0x00200431,

        /// <summary>
        ///     Data Field: Relative Humidity Usage.
        /// </summary>
        [Description("Data Field: Relative Humidity")]
        DataFieldRelativeHumidity = 0x00200433,

        /// <summary>
        ///     Data Field: Temperature Usage.
        /// </summary>
        [Description("Data Field: Temperature")]
        DataFieldTemperature = 0x00200434,

        /// <summary>
        ///     Data Field: Wind Direction Usage.
        /// </summary>
        [Description("Data Field: Wind Direction")]
        DataFieldWindDirection = 0x00200435,

        /// <summary>
        ///     Data Field: Wind Speed Usage.
        /// </summary>
        [Description("Data Field: Wind Speed")]
        DataFieldWindSpeed = 0x00200436,

        /// <summary>
        ///     Data Field: Air Quality Index Usage.
        /// </summary>
        [Description("Data Field: Air Quality Index")]
        DataFieldAirQualityIndex = 0x00200437,

        /// <summary>
        ///     Data Field: Equivalent CO2 Usage.
        /// </summary>
        [Description("Data Field: Equivalent CO2")]
        DataFieldEquivalentCO2 = 0x00200438,

        /// <summary>
        ///     Data Field: Volatile Organic Compound Concentration Usage.
        /// </summary>
        [Description("Data Field: Volatile Organic Compound Concentration")]
        DataFieldVolatileOrganicCompoundConcentration = 0x00200439,

        /// <summary>
        ///     Data Field: Object Presence Usage.
        /// </summary>
        [Description("Data Field: Object Presence")]
        DataFieldObjectPresence = 0x0020043a,

        /// <summary>
        ///     Data Field: Object Proximity Range Usage.
        /// </summary>
        [Description("Data Field: Object Proximity Range")]
        DataFieldObjectProximityRange = 0x0020043b,

        /// <summary>
        ///     Data Field: Object Proximity Out of Range Usage.
        /// </summary>
        [Description("Data Field: Object Proximity Out of Range")]
        DataFieldObjectProximityOutOfRange = 0x0020043c,

        /// <summary>
        ///     Property: Environmental Usage.
        /// </summary>
        [Description("Property: Environmental")]
        PropertyEnvironmental = 0x00200440,

        /// <summary>
        ///     Property: Reference Pressure (default Sel "Unit: bars) Usage.
        /// </summary>
        [Description("Property: Reference Pressure (default Sel \"Unit: bars)")]
        PropertyReferencePressureDefaultSelUnitBars = 0x00200441,

        /// <summary>
        ///     Data Field: Motion Usage.
        /// </summary>
        [Description("Data Field: Motion")]
        DataFieldMotion = 0x00200450,

        /// <summary>
        ///     Data Field: Motion State Usage.
        /// </summary>
        [Description("Data Field: Motion State")]
        DataFieldMotionState = 0x00200451,

        /// <summary>
        ///     Data Field: Acceleration Usage.
        /// </summary>
        [Description("Data Field: Acceleration")]
        DataFieldAcceleration = 0x00200452,

        /// <summary>
        ///     Data Field: Acceleration Axis X Usage.
        /// </summary>
        [Description("Data Field: Acceleration Axis X")]
        DataFieldAccelerationAxisX = 0x00200453,

        /// <summary>
        ///     Data Field: Acceleration Axis Y Usage.
        /// </summary>
        [Description("Data Field: Acceleration Axis Y")]
        DataFieldAccelerationAxisY = 0x00200454,

        /// <summary>
        ///     Data Field: Acceleration Axis Z Usage.
        /// </summary>
        [Description("Data Field: Acceleration Axis Z")]
        DataFieldAccelerationAxisZ = 0x00200455,

        /// <summary>
        ///     Data Field: Angular Velocity Usage.
        /// </summary>
        [Description("Data Field: Angular Velocity")]
        DataFieldAngularVelocity = 0x00200456,

        /// <summary>
        ///     Data Field: Angular Velocity X about Axis Usage.
        /// </summary>
        [Description("Data Field: Angular Velocity X about Axis")]
        DataFieldAngularVelocityXAboutAxis = 0x00200457,

        /// <summary>
        ///     Data Field: Angular Velocity Y about Axis Usage.
        /// </summary>
        [Description("Data Field: Angular Velocity Y about Axis")]
        DataFieldAngularVelocityYAboutAxis = 0x00200458,

        /// <summary>
        ///     Data Field: Angular Velocity Z about Axis Usage.
        /// </summary>
        [Description("Data Field: Angular Velocity Z about Axis")]
        DataFieldAngularVelocityZAboutAxis = 0x00200459,

        /// <summary>
        ///     Data Field: Angular Position Usage.
        /// </summary>
        [Description("Data Field: Angular Position")]
        DataFieldAngularPosition = 0x0020045a,

        /// <summary>
        ///     Data Field: Angular Position about X Axis Usage.
        /// </summary>
        [Description("Data Field: Angular Position about X Axis")]
        DataFieldAngularPositionAboutXAxis = 0x0020045b,

        /// <summary>
        ///     Data Field: Angular Position about Y Axis Usage.
        /// </summary>
        [Description("Data Field: Angular Position about Y Axis")]
        DataFieldAngularPositionAboutYAxis = 0x0020045c,

        /// <summary>
        ///     Data Field: Angular Position about Z Axis Usage.
        /// </summary>
        [Description("Data Field: Angular Position about Z Axis")]
        DataFieldAngularPositionAboutZAxis = 0x0020045d,

        /// <summary>
        ///     Data Field: Motion Speed Usage.
        /// </summary>
        [Description("Data Field: Motion Speed")]
        DataFieldMotionSpeed = 0x0020045e,

        /// <summary>
        ///     Data Field: Motion Intensity (percent) Usage.
        /// </summary>
        [Description("Data Field: Motion Intensity (percent)")]
        DataFieldMotionIntensityPercent = 0x0020045f,

        /// <summary>
        ///     Data Field: Orientation Usage.
        /// </summary>
        [Description("Data Field: Orientation")]
        DataFieldOrientation = 0x00200470,

        /// <summary>
        ///     Data Field: Heading Usage.
        /// </summary>
        [Description("Data Field: Heading")]
        DataFieldHeading = 0x00200471,

        /// <summary>
        ///     Data Field: Heading X Axis Usage.
        /// </summary>
        [Description("Data Field: Heading X Axis")]
        DataFieldHeadingXAxis = 0x00200472,

        /// <summary>
        ///     Data Field: Heading Y Axis Usage.
        /// </summary>
        [Description("Data Field: Heading Y Axis")]
        DataFieldHeadingYAxis = 0x00200473,

        /// <summary>
        ///     Data Field: Heading Z Axis Usage.
        /// </summary>
        [Description("Data Field: Heading Z Axis")]
        DataFieldHeadingZAxis = 0x00200474,

        /// <summary>
        ///     Data Field: Heading Compensated Magnetic North Usage.
        /// </summary>
        [Description("Data Field: Heading Compensated Magnetic North")]
        DataFieldHeadingCompensatedMagneticNorth = 0x00200475,

        /// <summary>
        ///     Data Field: Heading Compensated True North Usage.
        /// </summary>
        [Description("Data Field: Heading Compensated True North")]
        DataFieldHeadingCompensatedTrueNorth = 0x00200476,

        /// <summary>
        ///     Data Field: Heading Magnetic North Usage.
        /// </summary>
        [Description("Data Field: Heading Magnetic North")]
        DataFieldHeadingMagneticNorth = 0x00200477,

        /// <summary>
        ///     Data Field: Heading True North Usage.
        /// </summary>
        [Description("Data Field: Heading True North")]
        DataFieldHeadingTrueNorth = 0x00200478,

        /// <summary>
        ///     Data Field: Distance Usage.
        /// </summary>
        [Description("Data Field: Distance")]
        DataFieldDistance = 0x00200479,

        /// <summary>
        ///     Data Field: Distance X Axis Usage.
        /// </summary>
        [Description("Data Field: Distance X Axis")]
        DataFieldDistanceXAxis = 0x0020047a,

        /// <summary>
        ///     Data Field: Distance Y Axis Usage.
        /// </summary>
        [Description("Data Field: Distance Y Axis")]
        DataFieldDistanceYAxis = 0x0020047b,

        /// <summary>
        ///     Data Field: Distance Z Axis Usage.
        /// </summary>
        [Description("Data Field: Distance Z Axis")]
        DataFieldDistanceZAxis = 0x0020047c,

        /// <summary>
        ///     Data Field: Distance Out-of-Range Usage.
        /// </summary>
        [Description("Data Field: Distance Out-of-Range")]
        DataFieldDistanceOutofRange = 0x0020047d,

        /// <summary>
        ///     Data Field: Tilt Usage.
        /// </summary>
        [Description("Data Field: Tilt")]
        DataFieldTilt = 0x0020047e,

        /// <summary>
        ///     Data Field: Tilt X Axis Usage.
        /// </summary>
        [Description("Data Field: Tilt X Axis")]
        DataFieldTiltXAxis = 0x0020047f,

        /// <summary>
        ///     Data Field: Tilt Y Axis Usage.
        /// </summary>
        [Description("Data Field: Tilt Y Axis")]
        DataFieldTiltYAxis = 0x00200480,

        /// <summary>
        ///     Data Field: Tilt Z Axis Usage.
        /// </summary>
        [Description("Data Field: Tilt Z Axis")]
        DataFieldTiltZAxis = 0x00200481,

        /// <summary>
        ///     Data Field: Rotation Matrix Usage.
        /// </summary>
        [Description("Data Field: Rotation Matrix")]
        DataFieldRotationMatrix = 0x00200482,

        /// <summary>
        ///     Data Field: Quaternion Usage.
        /// </summary>
        [Description("Data Field: Quaternion")]
        DataFieldQuaternion = 0x00200483,

        /// <summary>
        ///     Data Field: Magnetic Flux Usage.
        /// </summary>
        [Description("Data Field: Magnetic Flux")]
        DataFieldMagneticFlux = 0x00200484,

        /// <summary>
        ///     Data Field: Magnetic Flux X Axis Usage.
        /// </summary>
        [Description("Data Field: Magnetic Flux X Axis")]
        DataFieldMagneticFluxXAxis = 0x00200485,

        /// <summary>
        ///     Data Field: Magnetic Flux Y Axis Usage.
        /// </summary>
        [Description("Data Field: Magnetic Flux Y Axis")]
        DataFieldMagneticFluxYAxis = 0x00200486,

        /// <summary>
        ///     Data Field: Magnetic Flux Z Axis Usage.
        /// </summary>
        [Description("Data Field: Magnetic Flux Z Axis")]
        DataFieldMagneticFluxZAxis = 0x00200487,

        /// <summary>
        ///     Data Field: Magnetometer Accuracy Usage.
        /// </summary>
        [Description("Data Field: Magnetometer Accuracy")]
        DataFieldMagnetometerAccuracy = 0x00200488,

        /// <summary>
        ///     Data Field: Simple Orientation Direction Usage.
        /// </summary>
        [Description("Data Field: Simple Orientation Direction")]
        DataFieldSimpleOrientationDirection = 0x00200489,

        /// <summary>
        ///     Data Field: Mechanical Usage.
        /// </summary>
        [Description("Data Field: Mechanical")]
        DataFieldMechanical = 0x00200490,

        /// <summary>
        ///     Data Field: Boolean Switch State Usage.
        /// </summary>
        [Description("Data Field: Boolean Switch State")]
        DataFieldBooleanSwitchState = 0x00200491,

        /// <summary>
        ///     Data Field: Boolean Switch Array States Usage.
        /// </summary>
        [Description("Data Field: Boolean Switch Array States")]
        DataFieldBooleanSwitchArrayStates = 0x00200492,

        /// <summary>
        ///     Data Field: Multivalue Switch Value Usage.
        /// </summary>
        [Description("Data Field: Multivalue Switch Value")]
        DataFieldMultivalueSwitchValue = 0x00200493,

        /// <summary>
        ///     Data Field: Force Usage.
        /// </summary>
        [Description("Data Field: Force")]
        DataFieldForce = 0x00200494,

        /// <summary>
        ///     Data Field: Absolute Pressure Usage.
        /// </summary>
        [Description("Data Field: Absolute Pressure")]
        DataFieldAbsolutePressure = 0x00200495,

        /// <summary>
        ///     Data Field: Gauge Pressure Usage.
        /// </summary>
        [Description("Data Field: Gauge Pressure")]
        DataFieldGaugePressure = 0x00200496,

        /// <summary>
        ///     Data Field: Strain Usage.
        /// </summary>
        [Description("Data Field: Strain")]
        DataFieldStrain = 0x00200497,

        /// <summary>
        ///     Data Field: Weight Usage.
        /// </summary>
        [Description("Data Field: Weight")]
        DataFieldWeight = 0x00200498,

        /// <summary>
        ///     Property: Mechanical Usage.
        /// </summary>
        [Description("Property: Mechanical")]
        PropertyMechanical = 0x002004a0,

        /// <summary>
        ///     Property: Vibration State Usage.
        /// </summary>
        [Description("Property: Vibration State")]
        PropertyVibrationState = 0x002004a1,

        /// <summary>
        ///     Property: Forward Vibration Speed (percent) Usage.
        /// </summary>
        [Description("Property: Forward Vibration Speed (percent)")]
        PropertyForwardVibrationSpeedPercent = 0x002004a2,

        /// <summary>
        ///     Property: Backward Vibration Speed (percent) Usage.
        /// </summary>
        [Description("Property: Backward Vibration Speed (percent)")]
        PropertyBackwardVibrationSpeedPercent = 0x002004a3,

        /// <summary>
        ///     Data Field: Biometric Usage.
        /// </summary>
        [Description("Data Field: Biometric")]
        DataFieldBiometric = 0x002004b0,

        /// <summary>
        ///     Data Field: Human Presence Usage.
        /// </summary>
        [Description("Data Field: Human Presence")]
        DataFieldHumanPresence = 0x002004b1,

        /// <summary>
        ///     Data Field: Human Proximity Range Usage.
        /// </summary>
        [Description("Data Field: Human Proximity Range")]
        DataFieldHumanProximityRange = 0x002004b2,

        /// <summary>
        ///     Data Field: Human Proximity Out of Range Usage.
        /// </summary>
        [Description("Data Field: Human Proximity Out of Range")]
        DataFieldHumanProximityOutOfRange = 0x002004b3,

        /// <summary>
        ///     Data Field: Human Touch State Usage.
        /// </summary>
        [Description("Data Field: Human Touch State")]
        DataFieldHumanTouchState = 0x002004b4,

        /// <summary>
        ///     Data Field: Blood Pressure Usage.
        /// </summary>
        [Description("Data Field: Blood Pressure")]
        DataFieldBloodPressure = 0x002004b5,

        /// <summary>
        ///     Data Field: Blood Pressure Diastolic Usage.
        /// </summary>
        [Description("Data Field: Blood Pressure Diastolic")]
        DataFieldBloodPressureDiastolic = 0x002004b6,

        /// <summary>
        ///     Data Field: Blood Pressure Systolic Usage.
        /// </summary>
        [Description("Data Field: Blood Pressure Systolic")]
        DataFieldBloodPressureSystolic = 0x002004b7,

        /// <summary>
        ///     Data Field: Heart Rate (HeartbeatsPM) Usage.
        /// </summary>
        [Description("Data Field: Heart Rate (HeartbeatsPM)")]
        DataFieldHeartRateHeartbeatsPM = 0x002004b8,

        /// <summary>
        ///     Data Field: Resting Heart Rate (HeartbeatsPM) Usage.
        /// </summary>
        [Description("Data Field: Resting Heart Rate (HeartbeatsPM)")]
        DataFieldRestingHeartRateHeartbeatsPM = 0x002004b9,

        /// <summary>
        ///     Data Field: Heartbeat Interval Usage.
        /// </summary>
        [Description("Data Field: Heartbeat Interval")]
        DataFieldHeartbeatInterval = 0x002004ba,

        /// <summary>
        ///     Data Field: Respiratory Rate Usage.
        /// </summary>
        [Description("Data Field: Respiratory Rate")]
        DataFieldRespiratoryRate = 0x002004bb,

        /// <summary>
        ///     Data Field: SpO2 (percent) Usage.
        /// </summary>
        [Description("Data Field: SpO2 (percent)")]
        DataFieldSpO2Percent = 0x002004bc,

        /// <summary>
        ///     Data Field: Human Attention Detected Usage.
        /// </summary>
        [Description("Data Field: Human Attention Detected")]
        DataFieldHumanAttentionDetected = 0x002004bd,

        /// <summary>
        ///     Data Field: Light Usage.
        /// </summary>
        [Description("Data Field: Light")]
        DataFieldLight = 0x002004d0,

        /// <summary>
        ///     Data Field: Illuminance Usage.
        /// </summary>
        [Description("Data Field: Illuminance")]
        DataFieldIlluminance = 0x002004d1,

        /// <summary>
        ///     Data Field: Color Temperature Usage.
        /// </summary>
        [Description("Data Field: Color Temperature")]
        DataFieldColorTemperature = 0x002004d2,

        /// <summary>
        ///     Data Field: Chromaticity Usage.
        /// </summary>
        [Description("Data Field: Chromaticity")]
        DataFieldChromaticity = 0x002004d3,

        /// <summary>
        ///     Data Field: Chromaticity X Usage.
        /// </summary>
        [Description("Data Field: Chromaticity X")]
        DataFieldChromaticityX = 0x002004d4,

        /// <summary>
        ///     Data Field: Chromaticity Y Usage.
        /// </summary>
        [Description("Data Field: Chromaticity Y")]
        DataFieldChromaticityY = 0x002004d5,

        /// <summary>
        ///     Data Field: Consumer IR Sentence Receive Usage.
        /// </summary>
        [Description("Data Field: Consumer IR Sentence Receive")]
        DataFieldConsumerIRSentenceReceive = 0x002004d6,

        /// <summary>
        ///     Data Field: Infrared Light Usage.
        /// </summary>
        [Description("Data Field: Infrared Light")]
        DataFieldInfraredLight = 0x002004d7,

        /// <summary>
        ///     Data Field: Red Light Usage.
        /// </summary>
        [Description("Data Field: Red Light")]
        DataFieldRedLight = 0x002004d8,

        /// <summary>
        ///     Data Field: Green Light Usage.
        /// </summary>
        [Description("Data Field: Green Light")]
        DataFieldGreenLight = 0x002004d9,

        /// <summary>
        ///     Data Field: Blue Light Usage.
        /// </summary>
        [Description("Data Field: Blue Light")]
        DataFieldBlueLight = 0x002004da,

        /// <summary>
        ///     Data Field: Ultraviolet A Light Usage.
        /// </summary>
        [Description("Data Field: Ultraviolet A Light")]
        DataFieldUltravioletALight = 0x002004db,

        /// <summary>
        ///     Data Field: Ultraviolet B Light Usage.
        /// </summary>
        [Description("Data Field: Ultraviolet B Light")]
        DataFieldUltravioletBLight = 0x002004dc,

        /// <summary>
        ///     Data Field: Ultraviolet Index Usage.
        /// </summary>
        [Description("Data Field: Ultraviolet Index")]
        DataFieldUltravioletIndex = 0x002004dd,

        /// <summary>
        ///     Data Field: Near Infrared Light Usage.
        /// </summary>
        [Description("Data Field: Near Infrared Light")]
        DataFieldNearInfraredLight = 0x002004de,

        /// <summary>
        ///     Property: Light Usage.
        /// </summary>
        [Description("Property: Light")]
        PropertyLight = 0x002004e0,

        /// <summary>
        ///     Property: Consumer IR Sentence Send Usage.
        /// </summary>
        [Description("Property: Consumer IR Sentence Send")]
        PropertyConsumerIRSentenceSend = 0x002004e1,

        /// <summary>
        ///     Property: Auto Brightness Preferred Usage.
        /// </summary>
        [Description("Property: Auto Brightness Preferred")]
        PropertyAutoBrightnessPreferred = 0x002004e2,

        /// <summary>
        ///     Property: Auto Color Preferred Usage.
        /// </summary>
        [Description("Property: Auto Color Preferred")]
        PropertyAutoColorPreferred = 0x002004e3,

        /// <summary>
        ///     Data Field: Scanner Usage.
        /// </summary>
        [Description("Data Field: Scanner")]
        DataFieldScanner = 0x002004f0,

        /// <summary>
        ///     Data Field: RFID Tag 40 Bit Usage.
        /// </summary>
        [Description("Data Field: RFID Tag 40 Bit")]
        DataFieldRFIDTag40Bit = 0x002004f1,

        /// <summary>
        ///     Data Field: NFC Sentence Receive Usage.
        /// </summary>
        [Description("Data Field: NFC Sentence Receive")]
        DataFieldNFCSentenceReceive = 0x002004f2,

        /// <summary>
        ///     Property: Scanner Usage.
        /// </summary>
        [Description("Property: Scanner")]
        PropertyScanner = 0x002004f8,

        /// <summary>
        ///     Property: NFC Sentence Send Usage.
        /// </summary>
        [Description("Property: NFC Sentence Send")]
        PropertyNFCSentenceSend = 0x002004f9,

        /// <summary>
        ///     Data Field: Electrical Usage.
        /// </summary>
        [Description("Data Field: Electrical")]
        DataFieldElectrical = 0x00200500,

        /// <summary>
        ///     Data Field: Capacitance Usage.
        /// </summary>
        [Description("Data Field: Capacitance")]
        DataFieldCapacitance = 0x00200501,

        /// <summary>
        ///     Data Field: Current Usage.
        /// </summary>
        [Description("Data Field: Current")]
        DataFieldCurrent = 0x00200502,

        /// <summary>
        ///     Data Field: Electrical Power Usage.
        /// </summary>
        [Description("Data Field: Electrical Power")]
        DataFieldElectricalPower = 0x00200503,

        /// <summary>
        ///     Data Field: Inductance Usage.
        /// </summary>
        [Description("Data Field: Inductance")]
        DataFieldInductance = 0x00200504,

        /// <summary>
        ///     Data Field: Resistance Usage.
        /// </summary>
        [Description("Data Field: Resistance")]
        DataFieldResistance = 0x00200505,

        /// <summary>
        ///     Data Field: Voltage Usage.
        /// </summary>
        [Description("Data Field: Voltage")]
        DataFieldVoltage = 0x00200506,

        /// <summary>
        ///     Data Field: Frequency Usage.
        /// </summary>
        [Description("Data Field: Frequency")]
        DataFieldFrequency = 0x00200507,

        /// <summary>
        ///     Data Field: Period Usage.
        /// </summary>
        [Description("Data Field: Period")]
        DataFieldPeriod = 0x00200508,

        /// <summary>
        ///     Data Field: Percent of Range Usage.
        /// </summary>
        [Description("Data Field: Percent of Range")]
        DataFieldPercentOfRange = 0x00200509,

        /// <summary>
        ///     Data Field: Time Usage.
        /// </summary>
        [Description("Data Field: Time")]
        DataFieldTime = 0x00200520,

        /// <summary>
        ///     Data Field: Year Usage.
        /// </summary>
        [Description("Data Field: Year")]
        DataFieldYear = 0x00200521,

        /// <summary>
        ///     Data Field: Month Usage.
        /// </summary>
        [Description("Data Field: Month")]
        DataFieldMonth = 0x00200522,

        /// <summary>
        ///     Data Field: Day Usage.
        /// </summary>
        [Description("Data Field: Day")]
        DataFieldDay = 0x00200523,

        /// <summary>
        ///     Data Field: Day of Week Usage.
        /// </summary>
        [Description("Data Field: Day of Week")]
        DataFieldDayOfWeek = 0x00200524,

        /// <summary>
        ///     Data Field: Minute Usage.
        /// </summary>
        [Description("Data Field: Minute")]
        DataFieldMinute = 0x00200526,

        /// <summary>
        ///     Data Field: Second Usage.
        /// </summary>
        [Description("Data Field: Second")]
        DataFieldSecond = 0x00200527,

        /// <summary>
        ///     Data Field: Millisecond Usage.
        /// </summary>
        [Description("Data Field: Millisecond")]
        DataFieldMillisecond = 0x00200528,

        /// <summary>
        ///     Data Field: Timestamp Usage.
        /// </summary>
        [Description("Data Field: Timestamp")]
        DataFieldTimestamp = 0x00200529,

        /// <summary>
        ///     Data Field: Julian Day of Year Usage.
        /// </summary>
        [Description("Data Field: Julian Day of Year")]
        DataFieldJulianDayOfYear = 0x0020052a,

        /// <summary>
        ///     Data Field: Time Since System Boot Usage.
        /// </summary>
        [Description("Data Field: Time Since System Boot")]
        DataFieldTimeSinceSystemBoot = 0x0020052b,

        /// <summary>
        ///     Property: Time Usage.
        /// </summary>
        [Description("Property: Time")]
        PropertyTime = 0x00200530,

        /// <summary>
        ///     Property: Time Zone Offset from UTC Usage.
        /// </summary>
        [Description("Property: Time Zone Offset from UTC")]
        PropertyTimeZoneOffsetFromUTC = 0x00200531,

        /// <summary>
        ///     Property: Time Zone Name Usage.
        /// </summary>
        [Description("Property: Time Zone Name")]
        PropertyTimeZoneName = 0x00200532,

        /// <summary>
        ///     Property: Daylight Savings Time Observed Usage.
        /// </summary>
        [Description("Property: Daylight Savings Time Observed")]
        PropertyDaylightSavingsTimeObserved = 0x00200533,

        /// <summary>
        ///     Property: Time Trim Adjustment Usage.
        /// </summary>
        [Description("Property: Time Trim Adjustment")]
        PropertyTimeTrimAdjustment = 0x00200534,

        /// <summary>
        ///     Property: Arm Alarm Usage.
        /// </summary>
        [Description("Property: Arm Alarm")]
        PropertyArmAlarm = 0x00200535,

        /// <summary>
        ///     Data Field: Custom Usage.
        /// </summary>
        [Description("Data Field: Custom")]
        DataFieldCustom = 0x00200540,

        /// <summary>
        ///     Data Field: Custom Usage Usage.
        /// </summary>
        [Description("Data Field: Custom Usage")]
        DataFieldCustomUsage = 0x00200541,

        /// <summary>
        ///     Data Field: Custom Boolean Array Usage.
        /// </summary>
        [Description("Data Field: Custom Boolean Array")]
        DataFieldCustomBooleanArray = 0x00200542,

        /// <summary>
        ///     Data Field: Custom Value Usage.
        /// </summary>
        [Description("Data Field: Custom Value")]
        DataFieldCustomValue = 0x00200543,

        /*
         * Range: 0x0544 -> 0x055f
         * Data Field: Custom Value {n+1}
         */

        /// <summary>
        ///     Data Field: Custom Value 1 Usage.
        /// </summary>
        [Description("Data Field: Custom Value 1")]
        DataFieldCustomValue1 = 0x00200544,

        /// <summary>
        ///     Data Field: Custom Value 2 Usage.
        /// </summary>
        [Description("Data Field: Custom Value 2")]
        DataFieldCustomValue2 = 0x00200545,

        /// <summary>
        ///     Data Field: Custom Value 3 Usage.
        /// </summary>
        [Description("Data Field: Custom Value 3")]
        DataFieldCustomValue3 = 0x00200546,

        /// <summary>
        ///     Data Field: Custom Value 4 Usage.
        /// </summary>
        [Description("Data Field: Custom Value 4")]
        DataFieldCustomValue4 = 0x00200547,

        /// <summary>
        ///     Data Field: Custom Value 5 Usage.
        /// </summary>
        [Description("Data Field: Custom Value 5")]
        DataFieldCustomValue5 = 0x00200548,

        /// <summary>
        ///     Data Field: Custom Value 6 Usage.
        /// </summary>
        [Description("Data Field: Custom Value 6")]
        DataFieldCustomValue6 = 0x00200549,

        /// <summary>
        ///     Data Field: Custom Value 7 Usage.
        /// </summary>
        [Description("Data Field: Custom Value 7")]
        DataFieldCustomValue7 = 0x0020054a,

        /// <summary>
        ///     Data Field: Custom Value 8 Usage.
        /// </summary>
        [Description("Data Field: Custom Value 8")]
        DataFieldCustomValue8 = 0x0020054b,

        /// <summary>
        ///     Data Field: Custom Value 9 Usage.
        /// </summary>
        [Description("Data Field: Custom Value 9")]
        DataFieldCustomValue9 = 0x0020054c,

        /// <summary>
        ///     Data Field: Custom Value 10 Usage.
        /// </summary>
        [Description("Data Field: Custom Value 10")]
        DataFieldCustomValue10 = 0x0020054d,

        /// <summary>
        ///     Data Field: Custom Value 11 Usage.
        /// </summary>
        [Description("Data Field: Custom Value 11")]
        DataFieldCustomValue11 = 0x0020054e,

        /// <summary>
        ///     Data Field: Custom Value 12 Usage.
        /// </summary>
        [Description("Data Field: Custom Value 12")]
        DataFieldCustomValue12 = 0x0020054f,

        /// <summary>
        ///     Data Field: Custom Value 13 Usage.
        /// </summary>
        [Description("Data Field: Custom Value 13")]
        DataFieldCustomValue13 = 0x00200550,

        /// <summary>
        ///     Data Field: Custom Value 14 Usage.
        /// </summary>
        [Description("Data Field: Custom Value 14")]
        DataFieldCustomValue14 = 0x00200551,

        /// <summary>
        ///     Data Field: Custom Value 15 Usage.
        /// </summary>
        [Description("Data Field: Custom Value 15")]
        DataFieldCustomValue15 = 0x00200552,

        /// <summary>
        ///     Data Field: Custom Value 16 Usage.
        /// </summary>
        [Description("Data Field: Custom Value 16")]
        DataFieldCustomValue16 = 0x00200553,

        /// <summary>
        ///     Data Field: Generic Usage.
        /// </summary>
        [Description("Data Field: Generic")]
        DataFieldGeneric = 0x00200560,

        /// <summary>
        ///     Data Field: Generic GUID or PROPERTYKEY Usage.
        /// </summary>
        [Description("Data Field: Generic GUID or PROPERTYKEY")]
        DataFieldGenericGUIDOrPROPERTYKEY = 0x00200561,

        /// <summary>
        ///     Data Field: Generic Category GUID Usage.
        /// </summary>
        [Description("Data Field: Generic Category GUID")]
        DataFieldGenericCategoryGUID = 0x00200562,

        /// <summary>
        ///     Data Field: Generic Type GUID Usage.
        /// </summary>
        [Description("Data Field: Generic Type GUID")]
        DataFieldGenericTypeGUID = 0x00200563,

        /// <summary>
        ///     Data Field: Generic Event PROPERTYKEY Usage.
        /// </summary>
        [Description("Data Field: Generic Event PROPERTYKEY")]
        DataFieldGenericEventPROPERTYKEY = 0x00200564,

        /// <summary>
        ///     Data Field: Generic Property PROPERTYKEY Usage.
        /// </summary>
        [Description("Data Field: Generic Property PROPERTYKEY")]
        DataFieldGenericPropertyPROPERTYKEY = 0x00200565,

        /// <summary>
        ///     Data Field: Generic Data Field PROPERTYKEY Usage.
        /// </summary>
        [Description("Data Field: Generic Data Field PROPERTYKEY")]
        DataFieldGenericDataFieldPROPERTYKEY = 0x00200566,

        /// <summary>
        ///     Data Field: Generic Event Usage.
        /// </summary>
        [Description("Data Field: Generic Event")]
        DataFieldGenericEvent = 0x00200567,

        /// <summary>
        ///     Data Field: Generic Property Usage.
        /// </summary>
        [Description("Data Field: Generic Property")]
        DataFieldGenericProperty = 0x00200568,

        /// <summary>
        ///     Data Field: Generic Data Field Usage.
        /// </summary>
        [Description("Data Field: Generic Data Field")]
        DataFieldGenericDataField = 0x00200569,

        /// <summary>
        ///     Data Field: Enumerator Table Row Index Usage.
        /// </summary>
        [Description("Data Field: Enumerator Table Row Index")]
        DataFieldEnumeratorTableRowIndex = 0x0020056a,

        /// <summary>
        ///     Data Field: Enumerator Table Row Count Usage.
        /// </summary>
        [Description("Data Field: Enumerator Table Row Count")]
        DataFieldEnumeratorTableRowCount = 0x0020056b,

        /// <summary>
        ///     Data Field: Generic GUID or PROPERTYKEY kind Usage.
        /// </summary>
        [Description("Data Field: Generic GUID or PROPERTYKEY kind")]
        DataFieldGenericGUIDOrPROPERTYKEYKind = 0x0020056c,

        /// <summary>
        ///     Data Field: Generic GUID Usage.
        /// </summary>
        [Description("Data Field: Generic GUID")]
        DataFieldGenericGUID = 0x0020056d,

        /// <summary>
        ///     Data Field: Generic PROPERTYKEY Usage.
        /// </summary>
        [Description("Data Field: Generic PROPERTYKEY")]
        DataFieldGenericPROPERTYKEY = 0x0020056e,

        /// <summary>
        ///     Data Field: Generic Top Level Collection ID Usage.
        /// </summary>
        [Description("Data Field: Generic Top Level Collection ID")]
        DataFieldGenericTopLevelCollectionID = 0x0020056f,

        /// <summary>
        ///     Data Field: Generic Report ID Usage.
        /// </summary>
        [Description("Data Field: Generic Report ID")]
        DataFieldGenericReportID = 0x00200570,

        /// <summary>
        ///     Data Field: Generic Report Item Position Index Usage.
        /// </summary>
        [Description("Data Field: Generic Report Item Position Index")]
        DataFieldGenericReportItemPositionIndex = 0x00200571,

        /// <summary>
        ///     Data Field: Generic Firmware VARTYPE Usage.
        /// </summary>
        [Description("Data Field: Generic Firmware VARTYPE")]
        DataFieldGenericFirmwareVARTYPE = 0x00200572,

        /// <summary>
        ///     Data Field: Generic Unit of Measure Usage.
        /// </summary>
        [Description("Data Field: Generic Unit of Measure")]
        DataFieldGenericUnitOfMeasure = 0x00200573,

        /// <summary>
        ///     Data Field: Generic Unit Exponent Usage.
        /// </summary>
        [Description("Data Field: Generic Unit Exponent")]
        DataFieldGenericUnitExponent = 0x00200574,

        /// <summary>
        ///     Data Field: Generic Report Size Usage.
        /// </summary>
        [Description("Data Field: Generic Report Size")]
        DataFieldGenericReportSize = 0x00200575,

        /// <summary>
        ///     Data Field: Generic Report Count Usage.
        /// </summary>
        [Description("Data Field: Generic Report Count")]
        DataFieldGenericReportCount = 0x00200576,

        /// <summary>
        ///     Property: Generic Usage.
        /// </summary>
        [Description("Property: Generic")]
        PropertyGeneric = 0x00200580,

        /// <summary>
        ///     Property: Enumerator Table Row Index Usage.
        /// </summary>
        [Description("Property: Enumerator Table Row Index")]
        PropertyEnumeratorTableRowIndex = 0x00200581,

        /// <summary>
        ///     Property: Enumerator Table Row Count Usage.
        /// </summary>
        [Description("Property: Enumerator Table Row Count")]
        PropertyEnumeratorTableRowCount = 0x00200582,

        /// <summary>
        ///     Data Field: Personal Activity Usage.
        /// </summary>
        [Description("Data Field: Personal Activity")]
        DataFieldPersonalActivity = 0x00200590,

        /// <summary>
        ///     Data Field: Activity Type Usage.
        /// </summary>
        [Description("Data Field: Activity Type")]
        DataFieldActivityType = 0x00200591,

        /// <summary>
        ///     Data Field: Activity State Usage.
        /// </summary>
        [Description("Data Field: Activity State")]
        DataFieldActivityState = 0x00200592,

        /// <summary>
        ///     Data Field: Device Position Usage.
        /// </summary>
        [Description("Data Field: Device Position")]
        DataFieldDevicePosition = 0x00200593,

        /// <summary>
        ///     Data Field: Step Count Usage.
        /// </summary>
        [Description("Data Field: Step Count")]
        DataFieldStepCount = 0x00200594,

        /// <summary>
        ///     Data Field: Step Count Reset Usage.
        /// </summary>
        [Description("Data Field: Step Count Reset")]
        DataFieldStepCountReset = 0x00200595,

        /// <summary>
        ///     Data Field: Step Duration Usage.
        /// </summary>
        [Description("Data Field: Step Duration")]
        DataFieldStepDuration = 0x00200596,

        /// <summary>
        ///     Data Field: Step Type Usage.
        /// </summary>
        [Description("Data Field: Step Type")]
        DataFieldStepType = 0x00200597,

        /// <summary>
        ///     Property: Minimum Activity Detection Interval Usage.
        /// </summary>
        [Description("Property: Minimum Activity Detection Interval")]
        PropertyMinimumActivityDetectionInterval = 0x002005a0,

        /// <summary>
        ///     Property: Supported Activity Types Usage.
        /// </summary>
        [Description("Property: Supported Activity Types")]
        PropertySupportedActivityTypes = 0x002005a1,

        /// <summary>
        ///     Property: Subscribed Activity Types Usage.
        /// </summary>
        [Description("Property: Subscribed Activity Types")]
        PropertySubscribedActivityTypes = 0x002005a2,

        /// <summary>
        ///     Property: Supported Step Types Usage.
        /// </summary>
        [Description("Property: Supported Step Types")]
        PropertySupportedStepTypes = 0x002005a3,

        /// <summary>
        ///     Property: Subscribed Step Types Usage.
        /// </summary>
        [Description("Property: Subscribed Step Types")]
        PropertySubscribedStepTypes = 0x002005a4,

        /// <summary>
        ///     Property: Floor Height Usage.
        /// </summary>
        [Description("Property: Floor Height")]
        PropertyFloorHeight = 0x002005a5,

        /// <summary>
        ///     Data Field: Custom Type ID Usage.
        /// </summary>
        [Description("Data Field: Custom Type ID")]
        DataFieldCustomTypeID = 0x002005b0,

        /// <summary>
        ///     Property: Custom Usage.
        /// </summary>
        [Description("Property: Custom")]
        PropertyCustom = 0x002005c0,

        /*
         * Range: 0x05c1 -> 0x05d0
         * Property: Custom Value {n+1}
         */

        /// <summary>
        ///     Property: Custom Value 1 Usage.
        /// </summary>
        [Description("Property: Custom Value 1")]
        PropertyCustomValue1 = 0x002005c1,

        /// <summary>
        ///     Property: Custom Value 2 Usage.
        /// </summary>
        [Description("Property: Custom Value 2")]
        PropertyCustomValue2 = 0x002005c2,

        /// <summary>
        ///     Property: Custom Value 3 Usage.
        /// </summary>
        [Description("Property: Custom Value 3")]
        PropertyCustomValue3 = 0x002005c3,

        /// <summary>
        ///     Property: Custom Value 4 Usage.
        /// </summary>
        [Description("Property: Custom Value 4")]
        PropertyCustomValue4 = 0x002005c4,

        /// <summary>
        ///     Property: Custom Value 5 Usage.
        /// </summary>
        [Description("Property: Custom Value 5")]
        PropertyCustomValue5 = 0x002005c5,

        /// <summary>
        ///     Property: Custom Value 6 Usage.
        /// </summary>
        [Description("Property: Custom Value 6")]
        PropertyCustomValue6 = 0x002005c6,

        /// <summary>
        ///     Property: Custom Value 7 Usage.
        /// </summary>
        [Description("Property: Custom Value 7")]
        PropertyCustomValue7 = 0x002005c7,

        /// <summary>
        ///     Property: Custom Value 8 Usage.
        /// </summary>
        [Description("Property: Custom Value 8")]
        PropertyCustomValue8 = 0x002005c8,

        /// <summary>
        ///     Property: Custom Value 9 Usage.
        /// </summary>
        [Description("Property: Custom Value 9")]
        PropertyCustomValue9 = 0x002005c9,

        /// <summary>
        ///     Property: Custom Value 10 Usage.
        /// </summary>
        [Description("Property: Custom Value 10")]
        PropertyCustomValue10 = 0x002005ca,

        /// <summary>
        ///     Property: Custom Value 11 Usage.
        /// </summary>
        [Description("Property: Custom Value 11")]
        PropertyCustomValue11 = 0x002005cb,

        /// <summary>
        ///     Property: Custom Value 12 Usage.
        /// </summary>
        [Description("Property: Custom Value 12")]
        PropertyCustomValue12 = 0x002005cc,

        /// <summary>
        ///     Property: Custom Value 13 Usage.
        /// </summary>
        [Description("Property: Custom Value 13")]
        PropertyCustomValue13 = 0x002005cd,

        /// <summary>
        ///     Property: Custom Value 14 Usage.
        /// </summary>
        [Description("Property: Custom Value 14")]
        PropertyCustomValue14 = 0x002005ce,

        /// <summary>
        ///     Property: Custom Value 15 Usage.
        /// </summary>
        [Description("Property: Custom Value 15")]
        PropertyCustomValue15 = 0x002005cf,

        /// <summary>
        ///     Property: Custom Value 16 Usage.
        /// </summary>
        [Description("Property: Custom Value 16")]
        PropertyCustomValue16 = 0x002005d0,

        /*
         * Range: 0x05d1 -> 0x05df
         * Property: Custom Reserved {n+1}
         */

        /// <summary>
        ///     Property: Custom Reserved 1 Usage.
        /// </summary>
        [Description("Property: Custom Reserved 1")]
        PropertyCustomReserved1 = 0x002005d1,

        /// <summary>
        ///     Property: Custom Reserved 2 Usage.
        /// </summary>
        [Description("Property: Custom Reserved 2")]
        PropertyCustomReserved2 = 0x002005d2,

        /// <summary>
        ///     Property: Custom Reserved 3 Usage.
        /// </summary>
        [Description("Property: Custom Reserved 3")]
        PropertyCustomReserved3 = 0x002005d3,

        /// <summary>
        ///     Property: Custom Reserved 4 Usage.
        /// </summary>
        [Description("Property: Custom Reserved 4")]
        PropertyCustomReserved4 = 0x002005d4,

        /// <summary>
        ///     Property: Custom Reserved 5 Usage.
        /// </summary>
        [Description("Property: Custom Reserved 5")]
        PropertyCustomReserved5 = 0x002005d5,

        /// <summary>
        ///     Property: Custom Reserved 6 Usage.
        /// </summary>
        [Description("Property: Custom Reserved 6")]
        PropertyCustomReserved6 = 0x002005d6,

        /// <summary>
        ///     Property: Custom Reserved 7 Usage.
        /// </summary>
        [Description("Property: Custom Reserved 7")]
        PropertyCustomReserved7 = 0x002005d7,

        /// <summary>
        ///     Property: Custom Reserved 8 Usage.
        /// </summary>
        [Description("Property: Custom Reserved 8")]
        PropertyCustomReserved8 = 0x002005d8,

        /// <summary>
        ///     Property: Custom Reserved 9 Usage.
        /// </summary>
        [Description("Property: Custom Reserved 9")]
        PropertyCustomReserved9 = 0x002005d9,

        /// <summary>
        ///     Property: Custom Reserved 10 Usage.
        /// </summary>
        [Description("Property: Custom Reserved 10")]
        PropertyCustomReserved10 = 0x002005da,

        /// <summary>
        ///     Property: Custom Reserved 11 Usage.
        /// </summary>
        [Description("Property: Custom Reserved 11")]
        PropertyCustomReserved11 = 0x002005db,

        /// <summary>
        ///     Property: Custom Reserved 12 Usage.
        /// </summary>
        [Description("Property: Custom Reserved 12")]
        PropertyCustomReserved12 = 0x002005dc,

        /// <summary>
        ///     Property: Custom Reserved 13 Usage.
        /// </summary>
        [Description("Property: Custom Reserved 13")]
        PropertyCustomReserved13 = 0x002005dd,

        /// <summary>
        ///     Property: Custom Reserved 14 Usage.
        /// </summary>
        [Description("Property: Custom Reserved 14")]
        PropertyCustomReserved14 = 0x002005de,

        /// <summary>
        ///     Property: Custom Reserved 15 Usage.
        /// </summary>
        [Description("Property: Custom Reserved 15")]
        PropertyCustomReserved15 = 0x002005df,

        /// <summary>
        ///     Data Field: Hinge Usage.
        /// </summary>
        [Description("Data Field: Hinge")]
        DataFieldHinge = 0x002005e0,

        /// <summary>
        ///     Data Field: Hinge Angle Usage.
        /// </summary>
        [Description("Data Field: Hinge Angle")]
        DataFieldHingeAngle = 0x002005e1,

        /// <summary>
        ///     Data Field: Gesture Sensor Usage.
        /// </summary>
        [Description("Data Field: Gesture Sensor")]
        DataFieldGestureSensor = 0x002005f0,

        /// <summary>
        ///     Data Field: Gesture State Usage.
        /// </summary>
        [Description("Data Field: Gesture State")]
        DataFieldGestureState = 0x002005f1,

        /// <summary>
        ///     Data Field: Hinge Fold Initial Angle Usage.
        /// </summary>
        [Description("Data Field: Hinge Fold Initial Angle")]
        DataFieldHingeFoldInitialAngle = 0x002005f2,

        /// <summary>
        ///     Data Field: Hinge Fold Final Angle Usage.
        /// </summary>
        [Description("Data Field: Hinge Fold Final Angle")]
        DataFieldHingeFoldFinalAngle = 0x002005f3,

        /// <summary>
        ///     Data Field: Hinge Fold Contributing Panel Usage.
        /// </summary>
        [Description("Data Field: Hinge Fold Contributing Panel")]
        DataFieldHingeFoldContributingPanel = 0x002005f4,

        /// <summary>
        ///     Data Field: Hinge Fold Type Usage.
        /// </summary>
        [Description("Data Field: Hinge Fold Type")]
        DataFieldHingeFoldType = 0x002005f5,

        /// <summary>
        ///     Sensor State: Undefined Usage.
        /// </summary>
        [Description("Sensor State: Undefined")]
        SensorStateUndefined = 0x00200800,

        /// <summary>
        ///     Sensor State: Ready Usage.
        /// </summary>
        [Description("Sensor State: Ready")]
        SensorStateReady = 0x00200801,

        /// <summary>
        ///     Sensor State: Not Available Usage.
        /// </summary>
        [Description("Sensor State: Not Available")]
        SensorStateNotAvailable = 0x00200802,

        /// <summary>
        ///     Sensor State: No Data Usage.
        /// </summary>
        [Description("Sensor State: No Data")]
        SensorStateNoData = 0x00200803,

        /// <summary>
        ///     Sensor State: Initializing Usage.
        /// </summary>
        [Description("Sensor State: Initializing")]
        SensorStateInitializing = 0x00200804,

        /// <summary>
        ///     Sensor State: Access Denied Usage.
        /// </summary>
        [Description("Sensor State: Access Denied")]
        SensorStateAccessDenied = 0x00200805,

        /// <summary>
        ///     Sensor State: Error Usage.
        /// </summary>
        [Description("Sensor State: Error")]
        SensorStateError = 0x00200806,

        /// <summary>
        ///     Sensor Event: Unknown Usage.
        /// </summary>
        [Description("Sensor Event: Unknown")]
        SensorEventUnknown = 0x00200810,

        /// <summary>
        ///     Sensor Event: State Changed Usage.
        /// </summary>
        [Description("Sensor Event: State Changed")]
        SensorEventStateChanged = 0x00200811,

        /// <summary>
        ///     Sensor Event: Property Changed Usage.
        /// </summary>
        [Description("Sensor Event: Property Changed")]
        SensorEventPropertyChanged = 0x00200812,

        /// <summary>
        ///     Sensor Event: Data Updated Usage.
        /// </summary>
        [Description("Sensor Event: Data Updated")]
        SensorEventDataUpdated = 0x00200813,

        /// <summary>
        ///     Sensor Event: Poll Response Usage.
        /// </summary>
        [Description("Sensor Event: Poll Response")]
        SensorEventPollResponse = 0x00200814,

        /// <summary>
        ///     Sensor Event: Change Sensitivity Usage.
        /// </summary>
        [Description("Sensor Event: Change Sensitivity")]
        SensorEventChangeSensitivity = 0x00200815,

        /// <summary>
        ///     Sensor Event: Range Maximum Reached Usage.
        /// </summary>
        [Description("Sensor Event: Range Maximum Reached")]
        SensorEventRangeMaximumReached = 0x00200816,

        /// <summary>
        ///     Sensor Event: Range Minimum Reached Usage.
        /// </summary>
        [Description("Sensor Event: Range Minimum Reached")]
        SensorEventRangeMinimumReached = 0x00200817,

        /// <summary>
        ///     Sensor Event: High Threshold Cross Upward Usage.
        /// </summary>
        [Description("Sensor Event: High Threshold Cross Upward")]
        SensorEventHighThresholdCrossUpward = 0x00200818,

        /// <summary>
        ///     Sensor Event: High Threshold Cross Downward Usage.
        /// </summary>
        [Description("Sensor Event: High Threshold Cross Downward")]
        SensorEventHighThresholdCrossDownward = 0x00200819,

        /// <summary>
        ///     Sensor Event: Low Threshold Cross Upward Usage.
        /// </summary>
        [Description("Sensor Event: Low Threshold Cross Upward")]
        SensorEventLowThresholdCrossUpward = 0x0020081a,

        /// <summary>
        ///     Sensor Event: Low Threshold Cross Downward Usage.
        /// </summary>
        [Description("Sensor Event: Low Threshold Cross Downward")]
        SensorEventLowThresholdCrossDownward = 0x0020081b,

        /// <summary>
        ///     Sensor Event: Zero Threshold Cross Upward Usage.
        /// </summary>
        [Description("Sensor Event: Zero Threshold Cross Upward")]
        SensorEventZeroThresholdCrossUpward = 0x0020081c,

        /// <summary>
        ///     Sensor Event: Zero Threshold Cross Downward Usage.
        /// </summary>
        [Description("Sensor Event: Zero Threshold Cross Downward")]
        SensorEventZeroThresholdCrossDownward = 0x0020081d,

        /// <summary>
        ///     Sensor Event: Period Exceeded Usage.
        /// </summary>
        [Description("Sensor Event: Period Exceeded")]
        SensorEventPeriodExceeded = 0x0020081e,

        /// <summary>
        ///     Sensor Event: Frequency Exceeded Usage.
        /// </summary>
        [Description("Sensor Event: Frequency Exceeded")]
        SensorEventFrequencyExceeded = 0x0020081f,

        /// <summary>
        ///     Sensor Event: Complex Trigger Usage.
        /// </summary>
        [Description("Sensor Event: Complex Trigger")]
        SensorEventComplexTrigger = 0x00200820,

        /// <summary>
        ///     Connection Type: Integrated Usage.
        /// </summary>
        [Description("Connection Type: Integrated")]
        ConnectionTypeIntegrated = 0x00200830,

        /// <summary>
        ///     Connection Type: Attached Usage.
        /// </summary>
        [Description("Connection Type: Attached")]
        ConnectionTypeAttached = 0x00200831,

        /// <summary>
        ///     Connection Type: External Usage.
        /// </summary>
        [Description("Connection Type: External")]
        ConnectionTypeExternal = 0x00200832,

        /// <summary>
        ///     Reporting State: Report No Events Usage.
        /// </summary>
        [Description("Reporting State: Report No Events")]
        ReportingStateReportNoEvents = 0x00200840,

        /// <summary>
        ///     Reporting State: Report All Events Usage.
        /// </summary>
        [Description("Reporting State: Report All Events")]
        ReportingStateReportAllEvents = 0x00200841,

        /// <summary>
        ///     Reporting State: Report Threshold Events Usage.
        /// </summary>
        [Description("Reporting State: Report Threshold Events")]
        ReportingStateReportThresholdEvents = 0x00200842,

        /// <summary>
        ///     Reporting State: Wake On No Events Usage.
        /// </summary>
        [Description("Reporting State: Wake On No Events")]
        ReportingStateWakeOnNoEvents = 0x00200843,

        /// <summary>
        ///     Reporting State: Wake On All Events Usage.
        /// </summary>
        [Description("Reporting State: Wake On All Events")]
        ReportingStateWakeOnAllEvents = 0x00200844,

        /// <summary>
        ///     Reporting State: Wake On Threshold Events Usage.
        /// </summary>
        [Description("Reporting State: Wake On Threshold Events")]
        ReportingStateWakeOnThresholdEvents = 0x00200845,

        /// <summary>
        ///     Power State: Undefined Usage.
        /// </summary>
        [Description("Power State: Undefined")]
        PowerStateUndefined = 0x00200850,

        /// <summary>
        ///     Power State: D0 Full Power Usage.
        /// </summary>
        [Description("Power State: D0 Full Power")]
        PowerStateD0FullPower = 0x00200851,

        /// <summary>
        ///     Power State: D1 Low Power Usage.
        /// </summary>
        [Description("Power State: D1 Low Power")]
        PowerStateD1LowPower = 0x00200852,

        /// <summary>
        ///     Power State: D2 Standby Power with Wakeup Usage.
        /// </summary>
        [Description("Power State: D2 Standby Power with Wakeup")]
        PowerStateD2StandbyPowerWithWakeup = 0x00200853,

        /// <summary>
        ///     Power State: D3 Sleep with Wakeup Usage.
        /// </summary>
        [Description("Power State: D3 Sleep with Wakeup")]
        PowerStateD3SleepWithWakeup = 0x00200854,

        /// <summary>
        ///     Power State: D4 Power Off Usage.
        /// </summary>
        [Description("Power State: D4 Power Off")]
        PowerStateD4PowerOff = 0x00200855,

        /// <summary>
        ///     Accuracy: Default Usage.
        /// </summary>
        [Description("Accuracy: Default")]
        AccuracyDefault = 0x00200860,

        /// <summary>
        ///     Accuracy: High Usage.
        /// </summary>
        [Description("Accuracy: High")]
        AccuracyHigh = 0x00200861,

        /// <summary>
        ///     Accuracy: Medium Usage.
        /// </summary>
        [Description("Accuracy: Medium")]
        AccuracyMedium = 0x00200862,

        /// <summary>
        ///     Accuracy: Low Usage.
        /// </summary>
        [Description("Accuracy: Low")]
        AccuracyLow = 0x00200863,

        /// <summary>
        ///     Fix Quality: No Fix Usage.
        /// </summary>
        [Description("Fix Quality: No Fix")]
        FixQualityNoFix = 0x00200870,

        /// <summary>
        ///     Fix Quality: GPS Usage.
        /// </summary>
        [Description("Fix Quality: GPS")]
        FixQualityGPS = 0x00200871,

        /// <summary>
        ///     Fix Quality: DGPS Usage.
        /// </summary>
        [Description("Fix Quality: DGPS")]
        FixQualityDGPS = 0x00200872,

        /// <summary>
        ///     Fix Type: No Fix Usage.
        /// </summary>
        [Description("Fix Type: No Fix")]
        FixTypeNoFix = 0x00200880,

        /// <summary>
        ///     Fix Type: GPS SPS Mode, Fix Valid Usage.
        /// </summary>
        [Description("Fix Type: GPS SPS Mode, Fix Valid")]
        FixTypeGPSSPSModeFixValid = 0x00200881,

        /// <summary>
        ///     Fix Type: DGPS SPS Mode, Fix Valid Usage.
        /// </summary>
        [Description("Fix Type: DGPS SPS Mode, Fix Valid")]
        FixTypeDGPSSPSModeFixValid = 0x00200882,

        /// <summary>
        ///     Fix Type: GPS PPS Mode, Fix Valid Usage.
        /// </summary>
        [Description("Fix Type: GPS PPS Mode, Fix Valid")]
        FixTypeGPSPPSModeFixValid = 0x00200883,

        /// <summary>
        ///     Fix Type: Real Time Kinematic Usage.
        /// </summary>
        [Description("Fix Type: Real Time Kinematic")]
        FixTypeRealTimeKinematic = 0x00200884,

        /// <summary>
        ///     Fix Type: Float RTK Usage.
        /// </summary>
        [Description("Fix Type: Float RTK")]
        FixTypeFloatRTK = 0x00200885,

        /// <summary>
        ///     Fix Type: Estimated (dead reckoned) Usage.
        /// </summary>
        [Description("Fix Type: Estimated (dead reckoned)")]
        FixTypeEstimatedDeadReckoned = 0x00200886,

        /// <summary>
        ///     Fix Type: Manual Input Mode Usage.
        /// </summary>
        [Description("Fix Type: Manual Input Mode")]
        FixTypeManualInputMode = 0x00200887,

        /// <summary>
        ///     Fix Type: Simulator Mode Usage.
        /// </summary>
        [Description("Fix Type: Simulator Mode")]
        FixTypeSimulatorMode = 0x00200888,

        /// <summary>
        ///     GPS Operation Mode: Manual Usage.
        /// </summary>
        [Description("GPS Operation Mode: Manual")]
        GPSOperationModeManual = 0x00200890,

        /// <summary>
        ///     GPS Operation Mode: Automatic Usage.
        /// </summary>
        [Description("GPS Operation Mode: Automatic")]
        GPSOperationModeAutomatic = 0x00200891,

        /// <summary>
        ///     GPS Selection Mode: Autonomous Usage.
        /// </summary>
        [Description("GPS Selection Mode: Autonomous")]
        GPSSelectionModeAutonomous = 0x002008a0,

        /// <summary>
        ///     GPS Selection Mode: DGPS Usage.
        /// </summary>
        [Description("GPS Selection Mode: DGPS")]
        GPSSelectionModeDGPS = 0x002008a1,

        /// <summary>
        ///     GPS Selection Mode: Estimated (dead reckoned) Usage.
        /// </summary>
        [Description("GPS Selection Mode: Estimated (dead reckoned)")]
        GPSSelectionModeEstimatedDeadReckoned = 0x002008a2,

        /// <summary>
        ///     GPS Selection Mode: Manual Input Usage.
        /// </summary>
        [Description("GPS Selection Mode: Manual Input")]
        GPSSelectionModeManualInput = 0x002008a3,

        /// <summary>
        ///     GPS Selection Mode: Simulator Usage.
        /// </summary>
        [Description("GPS Selection Mode: Simulator")]
        GPSSelectionModeSimulator = 0x002008a4,

        /// <summary>
        ///     GPS Selection Mode: Data Not Valid Usage.
        /// </summary>
        [Description("GPS Selection Mode: Data Not Valid")]
        GPSSelectionModeDataNotValid = 0x002008a5,

        /// <summary>
        ///     GPS Status: Data Valid Usage.
        /// </summary>
        [Description("GPS Status: Data Valid")]
        GPSStatusDataValid = 0x002008b0,

        /// <summary>
        ///     GPS Status: Data Not Valid Usage.
        /// </summary>
        [Description("GPS Status: Data Not Valid")]
        GPSStatusDataNotValid = 0x002008b1,

        /// <summary>
        ///     Day of Week: Sunday Usage.
        /// </summary>
        [Description("Day of Week: Sunday")]
        DayOfWeekSunday = 0x002008c0,

        /// <summary>
        ///     Day of Week: Monday Usage.
        /// </summary>
        [Description("Day of Week: Monday")]
        DayOfWeekMonday = 0x002008c1,

        /// <summary>
        ///     Day of Week: Tuesday Usage.
        /// </summary>
        [Description("Day of Week: Tuesday")]
        DayOfWeekTuesday = 0x002008c2,

        /// <summary>
        ///     Day of Week: Wednesday Usage.
        /// </summary>
        [Description("Day of Week: Wednesday")]
        DayOfWeekWednesday = 0x002008c3,

        /// <summary>
        ///     Day of Week: Thursday Usage.
        /// </summary>
        [Description("Day of Week: Thursday")]
        DayOfWeekThursday = 0x002008c4,

        /// <summary>
        ///     Day of Week: Friday Usage.
        /// </summary>
        [Description("Day of Week: Friday")]
        DayOfWeekFriday = 0x002008c5,

        /// <summary>
        ///     Day of Week: Saturday Usage.
        /// </summary>
        [Description("Day of Week: Saturday")]
        DayOfWeekSaturday = 0x002008c6,

        /// <summary>
        ///     Kind: Category Usage.
        /// </summary>
        [Description("Kind: Category")]
        KindCategory = 0x002008d0,

        /// <summary>
        ///     Kind: Type Usage.
        /// </summary>
        [Description("Kind: Type")]
        KindType = 0x002008d1,

        /// <summary>
        ///     Kind: Event Usage.
        /// </summary>
        [Description("Kind: Event")]
        KindEvent = 0x002008d2,

        /// <summary>
        ///     Kind: Property Usage.
        /// </summary>
        [Description("Kind: Property")]
        KindProperty = 0x002008d3,

        /// <summary>
        ///     Kind: Data Field Usage.
        /// </summary>
        [Description("Kind: Data Field")]
        KindDataField = 0x002008d4,

        /// <summary>
        ///     Magnetometer Accuracy: Low Usage.
        /// </summary>
        [Description("Magnetometer Accuracy: Low")]
        MagnetometerAccuracyLow = 0x002008e0,

        /// <summary>
        ///     Magnetometer Accuracy: Medium Usage.
        /// </summary>
        [Description("Magnetometer Accuracy: Medium")]
        MagnetometerAccuracyMedium = 0x002008e1,

        /// <summary>
        ///     Magnetometer Accuracy: High Usage.
        /// </summary>
        [Description("Magnetometer Accuracy: High")]
        MagnetometerAccuracyHigh = 0x002008e2,

        /// <summary>
        ///     Simple Orientation Direction: Not Rotated Usage.
        /// </summary>
        [Description("Simple Orientation Direction: Not Rotated")]
        SimpleOrientationDirectionNotRotated = 0x002008f0,

        /// <summary>
        ///     Simple Orientation Direction: Rotated 90 Degrees CCW Usage.
        /// </summary>
        [Description("Simple Orientation Direction: Rotated 90 Degrees CCW")]
        SimpleOrientationDirectionRotated90DegreesCCW = 0x002008f1,

        /// <summary>
        ///     Simple Orientation Direction: Rotated 180 Degrees CCW Usage.
        /// </summary>
        [Description("Simple Orientation Direction: Rotated 180 Degrees CCW")]
        SimpleOrientationDirectionRotated180DegreesCCW = 0x002008f2,

        /// <summary>
        ///     Simple Orientation Direction: Rotated 270 Degrees CCW Usage.
        /// </summary>
        [Description("Simple Orientation Direction: Rotated 270 Degrees CCW")]
        SimpleOrientationDirectionRotated270DegreesCCW = 0x002008f3,

        /// <summary>
        ///     Simple Orientation Direction: Face Up Usage.
        /// </summary>
        [Description("Simple Orientation Direction: Face Up")]
        SimpleOrientationDirectionFaceUp = 0x002008f4,

        /// <summary>
        ///     Simple Orientation Direction: Face Down Usage.
        /// </summary>
        [Description("Simple Orientation Direction: Face Down")]
        SimpleOrientationDirectionFaceDown = 0x002008f5,

        /// <summary>
        ///     VT_NULL: Empty Usage.
        /// </summary>
        [Description("VT_NULL: Empty")]
        VT_NULLEmpty = 0x00200900,

        /// <summary>
        ///     VT_BOOL: Boolean Usage.
        /// </summary>
        [Description("VT_BOOL: Boolean")]
        VT_BOOLBoolean = 0x00200901,

        /// <summary>
        ///     VT_UI1: Byte Usage.
        /// </summary>
        [Description("VT_UI1: Byte")]
        VT_UI1Byte = 0x00200902,

        /// <summary>
        ///     VT_I1: Character Usage.
        /// </summary>
        [Description("VT_I1: Character")]
        VT_I1Character = 0x00200903,

        /// <summary>
        ///     VT_UI2: Unsigned Short Usage.
        /// </summary>
        [Description("VT_UI2: Unsigned Short")]
        VT_UI2UnsignedShort = 0x00200904,

        /// <summary>
        ///     VT_I2: Short Usage.
        /// </summary>
        [Description("VT_I2: Short")]
        VT_I2Short = 0x00200905,

        /// <summary>
        ///     VT_UI4: Unsigned Long Usage.
        /// </summary>
        [Description("VT_UI4: Unsigned Long")]
        VT_UI4UnsignedLong = 0x00200906,

        /// <summary>
        ///     VT_I4: Long Usage.
        /// </summary>
        [Description("VT_I4: Long")]
        VT_I4Long = 0x00200907,

        /// <summary>
        ///     VT_UI8: Unsigned Long Long Usage.
        /// </summary>
        [Description("VT_UI8: Unsigned Long Long")]
        VT_UI8UnsignedLongLong = 0x00200908,

        /// <summary>
        ///     VT_I8: Long Long Usage.
        /// </summary>
        [Description("VT_I8: Long Long")]
        VT_I8LongLong = 0x00200909,

        /// <summary>
        ///     VT_R4: Float Usage.
        /// </summary>
        [Description("VT_R4: Float")]
        VT_R4Float = 0x0020090a,

        /// <summary>
        ///     VT_R8: Double Usage.
        /// </summary>
        [Description("VT_R8: Double")]
        VT_R8Double = 0x0020090b,

        /// <summary>
        ///     VT_WSTR: Wide String Usage.
        /// </summary>
        [Description("VT_WSTR: Wide String")]
        VT_WSTRWideString = 0x0020090c,

        /// <summary>
        ///     VT_STR: Narrow String Usage.
        /// </summary>
        [Description("VT_STR: Narrow String")]
        VT_STRNarrowString = 0x0020090d,

        /// <summary>
        ///     VT_CLSID: Guid Usage.
        /// </summary>
        [Description("VT_CLSID: Guid")]
        VT_CLSIDGuid = 0x0020090e,

        /// <summary>
        ///     VT_VECTOR|VT_UI1: Opaque Structure Usage.
        /// </summary>
        [Description("VT_VECTOR|VT_UI1: Opaque Structure")]
        VT_VECTORVT_UI1OpaqueStructure = 0x0020090f,

        /// <summary>
        ///     VT_F16E0: HID 16-bit Float e0 Usage.
        /// </summary>
        [Description("VT_F16E0: HID 16-bit Float e0")]
        VT_F16E0HID16bitFloatE0 = 0x00200910,

        /// <summary>
        ///     VT_F16E1: HID 16-bit Float e1 Usage.
        /// </summary>
        [Description("VT_F16E1: HID 16-bit Float e1")]
        VT_F16E1HID16bitFloatE1 = 0x00200911,

        /// <summary>
        ///     VT_F16E2: HID 16-bit Float e2 Usage.
        /// </summary>
        [Description("VT_F16E2: HID 16-bit Float e2")]
        VT_F16E2HID16bitFloatE2 = 0x00200912,

        /// <summary>
        ///     VT_F16E3: HID 16-bit Float e3 Usage.
        /// </summary>
        [Description("VT_F16E3: HID 16-bit Float e3")]
        VT_F16E3HID16bitFloatE3 = 0x00200913,

        /// <summary>
        ///     VT_F16E4: HID 16-bit Float e4 Usage.
        /// </summary>
        [Description("VT_F16E4: HID 16-bit Float e4")]
        VT_F16E4HID16bitFloatE4 = 0x00200914,

        /// <summary>
        ///     VT_F16E5: HID 16-bit Float e5 Usage.
        /// </summary>
        [Description("VT_F16E5: HID 16-bit Float e5")]
        VT_F16E5HID16bitFloatE5 = 0x00200915,

        /// <summary>
        ///     VT_F16E6: HID 16-bit Float e6 Usage.
        /// </summary>
        [Description("VT_F16E6: HID 16-bit Float e6")]
        VT_F16E6HID16bitFloatE6 = 0x00200916,

        /// <summary>
        ///     VT_F16E7: HID 16-bit Float e7 Usage.
        /// </summary>
        [Description("VT_F16E7: HID 16-bit Float e7")]
        VT_F16E7HID16bitFloatE7 = 0x00200917,

        /// <summary>
        ///     VT_F16E8: HID 16-bit Float e-8 Usage.
        /// </summary>
        [Description("VT_F16E8: HID 16-bit Float e-8")]
        VT_F16E8HID16bitFloatE8 = 0x00200918,

        /// <summary>
        ///     VT_F16E9: HID 16-bit Float e-7 Usage.
        /// </summary>
        [Description("VT_F16E9: HID 16-bit Float e-7")]
        VT_F16E9HID16bitFloatE7 = 0x00200919,

        /// <summary>
        ///     VT_F16EA: HID 16-bit Float e-6 Usage.
        /// </summary>
        [Description("VT_F16EA: HID 16-bit Float e-6")]
        VT_F16EAHID16bitFloatE6 = 0x0020091a,

        /// <summary>
        ///     VT_F16EB: HID 16-bit Float e-5 Usage.
        /// </summary>
        [Description("VT_F16EB: HID 16-bit Float e-5")]
        VT_F16EBHID16bitFloatE5 = 0x0020091b,

        /// <summary>
        ///     VT_F16EC: HID 16-bit Float e-4 Usage.
        /// </summary>
        [Description("VT_F16EC: HID 16-bit Float e-4")]
        VT_F16ECHID16bitFloatE4 = 0x0020091c,

        /// <summary>
        ///     VT_F16ED: HID 16-bit Float e-3 Usage.
        /// </summary>
        [Description("VT_F16ED: HID 16-bit Float e-3")]
        VT_F16EDHID16bitFloatE3 = 0x0020091d,

        /// <summary>
        ///     VT_F16EE: HID 16-bit Float e-2 Usage.
        /// </summary>
        [Description("VT_F16EE: HID 16-bit Float e-2")]
        VT_F16EEHID16bitFloatE2 = 0x0020091e,

        /// <summary>
        ///     VT_F16EF: HID 16-bit Float e-1 Usage.
        /// </summary>
        [Description("VT_F16EF: HID 16-bit Float e-1")]
        VT_F16EFHID16bitFloatE1 = 0x0020091f,

        /// <summary>
        ///     VT_F32E0: HID 32-bit Float e0 Usage.
        /// </summary>
        [Description("VT_F32E0: HID 32-bit Float e0")]
        VT_F32E0HID32bitFloatE0 = 0x00200920,

        /// <summary>
        ///     VT_F32E1: HID 32-bit Float e1 Usage.
        /// </summary>
        [Description("VT_F32E1: HID 32-bit Float e1")]
        VT_F32E1HID32bitFloatE1 = 0x00200921,

        /// <summary>
        ///     VT_F32E2: HID 32-bit Float e2 Usage.
        /// </summary>
        [Description("VT_F32E2: HID 32-bit Float e2")]
        VT_F32E2HID32bitFloatE2 = 0x00200922,

        /// <summary>
        ///     VT_F32E3: HID 32-bit Float e3 Usage.
        /// </summary>
        [Description("VT_F32E3: HID 32-bit Float e3")]
        VT_F32E3HID32bitFloatE3 = 0x00200923,

        /// <summary>
        ///     VT_F32E4: HID 32-bit Float e4 Usage.
        /// </summary>
        [Description("VT_F32E4: HID 32-bit Float e4")]
        VT_F32E4HID32bitFloatE4 = 0x00200924,

        /// <summary>
        ///     VT_F32E5: HID 32-bit Float e5 Usage.
        /// </summary>
        [Description("VT_F32E5: HID 32-bit Float e5")]
        VT_F32E5HID32bitFloatE5 = 0x00200925,

        /// <summary>
        ///     VT_F32E6: HID 32-bit Float e6 Usage.
        /// </summary>
        [Description("VT_F32E6: HID 32-bit Float e6")]
        VT_F32E6HID32bitFloatE6 = 0x00200926,

        /// <summary>
        ///     VT_F32E7: HID 32-bit Float e7 Usage.
        /// </summary>
        [Description("VT_F32E7: HID 32-bit Float e7")]
        VT_F32E7HID32bitFloatE7 = 0x00200927,

        /// <summary>
        ///     VT_F32E8: HID 32-bit Float e-8 Usage.
        /// </summary>
        [Description("VT_F32E8: HID 32-bit Float e-8")]
        VT_F32E8HID32bitFloatE8 = 0x00200928,

        /// <summary>
        ///     VT_F32E9: HID 32-bit Float e-7 Usage.
        /// </summary>
        [Description("VT_F32E9: HID 32-bit Float e-7")]
        VT_F32E9HID32bitFloatE7 = 0x00200929,

        /// <summary>
        ///     VT_F32EA: HID 32-bit Float e-6 Usage.
        /// </summary>
        [Description("VT_F32EA: HID 32-bit Float e-6")]
        VT_F32EAHID32bitFloatE6 = 0x0020092a,

        /// <summary>
        ///     VT_F32EB: HID 32-bit Float e-5 Usage.
        /// </summary>
        [Description("VT_F32EB: HID 32-bit Float e-5")]
        VT_F32EBHID32bitFloatE5 = 0x0020092b,

        /// <summary>
        ///     VT_F32EC: HID 32-bit Float e-4 Usage.
        /// </summary>
        [Description("VT_F32EC: HID 32-bit Float e-4")]
        VT_F32ECHID32bitFloatE4 = 0x0020092c,

        /// <summary>
        ///     VT_F32ED: HID 32-bit Float e-3 Usage.
        /// </summary>
        [Description("VT_F32ED: HID 32-bit Float e-3")]
        VT_F32EDHID32bitFloatE3 = 0x0020092d,

        /// <summary>
        ///     VT_F32EE: HID 32-bit Float e-2 Usage.
        /// </summary>
        [Description("VT_F32EE: HID 32-bit Float e-2")]
        VT_F32EEHID32bitFloatE2 = 0x0020092e,

        /// <summary>
        ///     VT_F32EF: HID 32-bit Float e-1 Usage.
        /// </summary>
        [Description("VT_F32EF: HID 32-bit Float e-1")]
        VT_F32EFHID32bitFloatE1 = 0x0020092f,

        /// <summary>
        ///     Activity Type: Unknown Usage.
        /// </summary>
        [Description("Activity Type: Unknown")]
        ActivityTypeUnknown = 0x00200930,

        /// <summary>
        ///     Activity Type: Stationary Usage.
        /// </summary>
        [Description("Activity Type: Stationary")]
        ActivityTypeStationary = 0x00200931,

        /// <summary>
        ///     Activity Type: Fidgeting Usage.
        /// </summary>
        [Description("Activity Type: Fidgeting")]
        ActivityTypeFidgeting = 0x00200932,

        /// <summary>
        ///     Activity Type: Walking Usage.
        /// </summary>
        [Description("Activity Type: Walking")]
        ActivityTypeWalking = 0x00200933,

        /// <summary>
        ///     Activity Type: Running Usage.
        /// </summary>
        [Description("Activity Type: Running")]
        ActivityTypeRunning = 0x00200934,

        /// <summary>
        ///     Activity Type: In Vehicle Usage.
        /// </summary>
        [Description("Activity Type: In Vehicle")]
        ActivityTypeInVehicle = 0x00200935,

        /// <summary>
        ///     Activity Type: Biking Usage.
        /// </summary>
        [Description("Activity Type: Biking")]
        ActivityTypeBiking = 0x00200936,

        /// <summary>
        ///     Activity Type: Idle Usage.
        /// </summary>
        [Description("Activity Type: Idle")]
        ActivityTypeIdle = 0x00200937,

        /// <summary>
        ///     Unit: Not Specified Usage.
        /// </summary>
        [Description("Unit: Not Specified")]
        UnitNotSpecified = 0x00200940,

        /// <summary>
        ///     Unit: Lux Usage.
        /// </summary>
        [Description("Unit: Lux")]
        UnitLux = 0x00200941,

        /// <summary>
        ///     Unit: Degrees Kelvin Usage.
        /// </summary>
        [Description("Unit: Degrees Kelvin")]
        UnitDegreesKelvin = 0x00200942,

        /// <summary>
        ///     Unit: Degrees Celsius Usage.
        /// </summary>
        [Description("Unit: Degrees Celsius")]
        UnitDegreesCelsius = 0x00200943,

        /// <summary>
        ///     Unit: Pascal Usage.
        /// </summary>
        [Description("Unit: Pascal")]
        UnitPascal = 0x00200944,

        /// <summary>
        ///     Unit: Newton Usage.
        /// </summary>
        [Description("Unit: Newton")]
        UnitNewton = 0x00200945,

        /// <summary>
        ///     Unit: Meters/Second Usage.
        /// </summary>
        [Description("Unit: Meters/Second")]
        UnitMetersSecond = 0x00200946,

        /// <summary>
        ///     Unit: Kilogram Usage.
        /// </summary>
        [Description("Unit: Kilogram")]
        UnitKilogram = 0x00200947,

        /// <summary>
        ///     Unit: Meter Usage.
        /// </summary>
        [Description("Unit: Meter")]
        UnitMeter = 0x00200948,

        /// <summary>
        ///     Unit: Meters/Second/Second Usage.
        /// </summary>
        [Description("Unit: Meters/Second/Second")]
        UnitMetersSecondSecond = 0x00200949,

        /// <summary>
        ///     Unit: Farad Usage.
        /// </summary>
        [Description("Unit: Farad")]
        UnitFarad = 0x0020094a,

        /// <summary>
        ///     Unit: Ampere Usage.
        /// </summary>
        [Description("Unit: Ampere")]
        UnitAmpere = 0x0020094b,

        /// <summary>
        ///     Unit: Watt Usage.
        /// </summary>
        [Description("Unit: Watt")]
        UnitWatt = 0x0020094c,

        /// <summary>
        ///     Unit: Henry Usage.
        /// </summary>
        [Description("Unit: Henry")]
        UnitHenry = 0x0020094d,

        /// <summary>
        ///     Unit: Ohm Usage.
        /// </summary>
        [Description("Unit: Ohm")]
        UnitOhm = 0x0020094e,

        /// <summary>
        ///     Unit: Volt Usage.
        /// </summary>
        [Description("Unit: Volt")]
        UnitVolt = 0x0020094f,

        /// <summary>
        ///     Unit: Hertz Usage.
        /// </summary>
        [Description("Unit: Hertz")]
        UnitHertz = 0x00200950,

        /// <summary>
        ///     Unit: Bar Usage.
        /// </summary>
        [Description("Unit: Bar")]
        UnitBar = 0x00200951,

        /// <summary>
        ///     Unit: Degrees Anti-clockwise Usage.
        /// </summary>
        [Description("Unit: Degrees Anti-clockwise")]
        UnitDegreesAnticlockwise = 0x00200952,

        /// <summary>
        ///     Unit: Degrees Clockwise Usage.
        /// </summary>
        [Description("Unit: Degrees Clockwise")]
        UnitDegreesClockwise = 0x00200953,

        /// <summary>
        ///     Unit: Degrees Usage.
        /// </summary>
        [Description("Unit: Degrees")]
        UnitDegrees = 0x00200954,

        /// <summary>
        ///     Unit: Degrees/Second Usage.
        /// </summary>
        [Description("Unit: Degrees/Second")]
        UnitDegreesSecond = 0x00200955,

        /// <summary>
        ///     Unit: Degrees/Second/Second Usage.
        /// </summary>
        [Description("Unit: Degrees/Second/Second")]
        UnitDegreesSecondSecond = 0x00200956,

        /// <summary>
        ///     Unit: Knot Usage.
        /// </summary>
        [Description("Unit: Knot")]
        UnitKnot = 0x00200957,

        /// <summary>
        ///     Unit: Percent Usage.
        /// </summary>
        [Description("Unit: Percent")]
        UnitPercent = 0x00200958,

        /// <summary>
        ///     Unit: Second Usage.
        /// </summary>
        [Description("Unit: Second")]
        UnitSecond = 0x00200959,

        /// <summary>
        ///     Unit: Millisecond Usage.
        /// </summary>
        [Description("Unit: Millisecond")]
        UnitMillisecond = 0x0020095a,

        /// <summary>
        ///     Unit: G Usage.
        /// </summary>
        [Description("Unit: G")]
        UnitG = 0x0020095b,

        /// <summary>
        ///     Unit: Bytes Usage.
        /// </summary>
        [Description("Unit: Bytes")]
        UnitBytes = 0x0020095c,

        /// <summary>
        ///     Unit: Milligauss Usage.
        /// </summary>
        [Description("Unit: Milligauss")]
        UnitMilligauss = 0x0020095d,

        /// <summary>
        ///     Unit: Bits Usage.
        /// </summary>
        [Description("Unit: Bits")]
        UnitBits = 0x0020095e,

        /// <summary>
        ///     Activity State: No State Change Usage.
        /// </summary>
        [Description("Activity State: No State Change")]
        ActivityStateNoStateChange = 0x00200960,

        /// <summary>
        ///     Activity State: Start Activity Usage.
        /// </summary>
        [Description("Activity State: Start Activity")]
        ActivityStateStartActivity = 0x00200961,

        /// <summary>
        ///     Activity State: End Activity Usage.
        /// </summary>
        [Description("Activity State: End Activity")]
        ActivityStateEndActivity = 0x00200962,

        /// <summary>
        ///     Exponent 0: 1 Usage.
        /// </summary>
        [Description("Exponent 0: 1")]
        Exponent01 = 0x00200970,

        /// <summary>
        ///     Exponent 1: 10 Usage.
        /// </summary>
        [Description("Exponent 1: 10")]
        Exponent110 = 0x00200971,

        /// <summary>
        ///     Exponent 2: 100 Usage.
        /// </summary>
        [Description("Exponent 2: 100")]
        Exponent2100 = 0x00200972,

        /// <summary>
        ///     Exponent 3: 1 000 Usage.
        /// </summary>
        [Description("Exponent 3: 1 000")]
        Exponent31000 = 0x00200973,

        /// <summary>
        ///     Exponent 4: 10 000 Usage.
        /// </summary>
        [Description("Exponent 4: 10 000")]
        Exponent410000 = 0x00200974,

        /// <summary>
        ///     Exponent 5: 100 000 Usage.
        /// </summary>
        [Description("Exponent 5: 100 000")]
        Exponent5100000 = 0x00200975,

        /// <summary>
        ///     Exponent 6: 1 000 000 Usage.
        /// </summary>
        [Description("Exponent 6: 1 000 000")]
        Exponent61000000 = 0x00200976,

        /// <summary>
        ///     Exponent 7: 10 000 000 Usage.
        /// </summary>
        [Description("Exponent 7: 10 000 000")]
        Exponent710000000 = 0x00200977,

        /// <summary>
        ///     Exponent 8: 0.00 000 001 Usage.
        /// </summary>
        [Description("Exponent 8: 0.00 000 001")]
        Exponent8000000001 = 0x00200978,

        /// <summary>
        ///     Exponent 9: 0.0 000 001 Usage.
        /// </summary>
        [Description("Exponent 9: 0.0 000 001")]
        Exponent900000001 = 0x00200979,

        /// <summary>
        ///     Exponent A: 0.000 001 Usage.
        /// </summary>
        [Description("Exponent A: 0.000 001")]
        ExponentA0000001 = 0x0020097a,

        /// <summary>
        ///     Exponent B: 0.00 001 Usage.
        /// </summary>
        [Description("Exponent B: 0.00 001")]
        ExponentB000001 = 0x0020097b,

        /// <summary>
        ///     Exponent C: 0.0 001 Usage.
        /// </summary>
        [Description("Exponent C: 0.0 001")]
        ExponentC00001 = 0x0020097c,

        /// <summary>
        ///     Exponent D: 0.001 Usage.
        /// </summary>
        [Description("Exponent D: 0.001")]
        ExponentD0001 = 0x0020097d,

        /// <summary>
        ///     Exponent E: 0.01 Usage.
        /// </summary>
        [Description("Exponent E: 0.01")]
        ExponentE001 = 0x0020097e,

        /// <summary>
        ///     Exponent F: 0.1 Usage.
        /// </summary>
        [Description("Exponent F: 0.1")]
        ExponentF01 = 0x0020097f,

        /// <summary>
        ///     Device Position: Unknown Usage.
        /// </summary>
        [Description("Device Position: Unknown")]
        DevicePositionUnknown = 0x00200980,

        /// <summary>
        ///     Device Position: Unchanged Usage.
        /// </summary>
        [Description("Device Position: Unchanged")]
        DevicePositionUnchanged = 0x00200981,

        /// <summary>
        ///     Device Position: On Desk Usage.
        /// </summary>
        [Description("Device Position: On Desk")]
        DevicePositionOnDesk = 0x00200982,

        /// <summary>
        ///     Device Position: In Hand Usage.
        /// </summary>
        [Description("Device Position: In Hand")]
        DevicePositionInHand = 0x00200983,

        /// <summary>
        ///     Device Position: Moving in Bag Usage.
        /// </summary>
        [Description("Device Position: Moving in Bag")]
        DevicePositionMovingInBag = 0x00200984,

        /// <summary>
        ///     Device Position: Stationary in Bag Usage.
        /// </summary>
        [Description("Device Position: Stationary in Bag")]
        DevicePositionStationaryInBag = 0x00200985,

        /// <summary>
        ///     Step Type: Unknown Usage.
        /// </summary>
        [Description("Step Type: Unknown")]
        StepTypeUnknown = 0x00200990,

        /// <summary>
        ///     Step Type: Running Usage.
        /// </summary>
        [Description("Step Type: Running")]
        StepTypeRunning = 0x00200991,

        /// <summary>
        ///     Step Type: Walking Usage.
        /// </summary>
        [Description("Step Type: Walking")]
        StepTypeWalking = 0x00200992,

        /// <summary>
        ///     Gesture State: Unknown Usage.
        /// </summary>
        [Description("Gesture State: Unknown")]
        GestureStateUnknown = 0x002009a0,

        /// <summary>
        ///     Gesture State: Started Usage.
        /// </summary>
        [Description("Gesture State: Started")]
        GestureStateStarted = 0x002009a1,

        /// <summary>
        ///     Gesture State: Completed Usage.
        /// </summary>
        [Description("Gesture State: Completed")]
        GestureStateCompleted = 0x002009a2,

        /// <summary>
        ///     Gesture State: Cancelled Usage.
        /// </summary>
        [Description("Gesture State: Cancelled")]
        GestureStateCancelled = 0x002009a3,

        /// <summary>
        ///     Contributing Panel: Unknown Usage.
        /// </summary>
        [Description("Contributing Panel: Unknown")]
        ContributingPanelUnknown = 0x002009b0,

        /// <summary>
        ///     Contributing Panel: Panel1 Usage.
        /// </summary>
        [Description("Contributing Panel: Panel1")]
        ContributingPanelPanel1 = 0x002009b1,

        /// <summary>
        ///     Contributing Panel: Panel2 Usage.
        /// </summary>
        [Description("Contributing Panel: Panel2")]
        ContributingPanelPanel2 = 0x002009b2,

        /// <summary>
        ///     Contributing Panel: Both Usage.
        /// </summary>
        [Description("Contributing Panel: Both")]
        ContributingPanelBoth = 0x002009b3,

        /// <summary>
        ///     Fold Type: Unknown Usage.
        /// </summary>
        [Description("Fold Type: Unknown")]
        FoldTypeUnknown = 0x002009b4,

        /// <summary>
        ///     Fold Type: Increasing Usage.
        /// </summary>
        [Description("Fold Type: Increasing")]
        FoldTypeIncreasing = 0x002009b5,

        /// <summary>
        ///     Fold Type: Decreasing Usage.
        /// </summary>
        [Description("Fold Type: Decreasing")]
        FoldTypeDecreasing = 0x002009b6,

        /// <summary>
        ///     Human Presence Detection Type: Vendor-Defined Non-Biometric Usage.
        /// </summary>
        [Description("Human Presence Detection Type: Vendor-Defined Non-Biometric")]
        HumanPresenceDetectionTypeVendorDefinedNonBiometric = 0x002009c0,

        /// <summary>
        ///     Human Presence Detection Type: Vendor-Defined Biometric Usage.
        /// </summary>
        [Description("Human Presence Detection Type: Vendor-Defined Biometric")]
        HumanPresenceDetectionTypeVendorDefinedBiometric = 0x002009c1,

        /// <summary>
        ///     Human Presence Detection Type: Facial Biometric Usage.
        /// </summary>
        [Description("Human Presence Detection Type: Facial Biometric")]
        HumanPresenceDetectionTypeFacialBiometric = 0x002009c2,

        /// <summary>
        ///     Human Presence Detection Type: Audio Biometric Usage.
        /// </summary>
        [Description("Human Presence Detection Type: Audio Biometric")]
        HumanPresenceDetectionTypeAudioBiometric = 0x002009c3,

        /*
         * Range: 0x1000 -> 0x1fff
         * Change Sensitivity Absolute
         */

        /// <summary>
        ///     Change Sensitivity Absolute Usage.
        /// </summary>
        [Description("Change Sensitivity Absolute")]
        ChangeSensitivityAbsolute = 0x00201000,

        /// <summary>
        ///     Change Sensitivity Absolute Usage.
        /// </summary>
        [Description("Change Sensitivity Absolute")]
        ChangeSensitivityAbsolute2 = 0x00201001,

        /// <summary>
        ///     Change Sensitivity Absolute Usage.
        /// </summary>
        [Description("Change Sensitivity Absolute")]
        ChangeSensitivityAbsolute3 = 0x00201002,

        /// <summary>
        ///     Change Sensitivity Absolute Usage.
        /// </summary>
        [Description("Change Sensitivity Absolute")]
        ChangeSensitivityAbsolute4 = 0x00201003,

        /// <summary>
        ///     Change Sensitivity Absolute Usage.
        /// </summary>
        [Description("Change Sensitivity Absolute")]
        ChangeSensitivityAbsolute5 = 0x00201004,

        /// <summary>
        ///     Change Sensitivity Absolute Usage.
        /// </summary>
        [Description("Change Sensitivity Absolute")]
        ChangeSensitivityAbsolute6 = 0x00201005,

        /// <summary>
        ///     Change Sensitivity Absolute Usage.
        /// </summary>
        [Description("Change Sensitivity Absolute")]
        ChangeSensitivityAbsolute7 = 0x00201006,

        /// <summary>
        ///     Change Sensitivity Absolute Usage.
        /// </summary>
        [Description("Change Sensitivity Absolute")]
        ChangeSensitivityAbsolute8 = 0x00201007,

        /// <summary>
        ///     Change Sensitivity Absolute Usage.
        /// </summary>
        [Description("Change Sensitivity Absolute")]
        ChangeSensitivityAbsolute9 = 0x00201008,

        /// <summary>
        ///     Change Sensitivity Absolute Usage.
        /// </summary>
        [Description("Change Sensitivity Absolute")]
        ChangeSensitivityAbsolute10 = 0x00201009,

        /// <summary>
        ///     Change Sensitivity Absolute Usage.
        /// </summary>
        [Description("Change Sensitivity Absolute")]
        ChangeSensitivityAbsolute11 = 0x0020100a,

        /// <summary>
        ///     Change Sensitivity Absolute Usage.
        /// </summary>
        [Description("Change Sensitivity Absolute")]
        ChangeSensitivityAbsolute12 = 0x0020100b,

        /// <summary>
        ///     Change Sensitivity Absolute Usage.
        /// </summary>
        [Description("Change Sensitivity Absolute")]
        ChangeSensitivityAbsolute13 = 0x0020100c,

        /// <summary>
        ///     Change Sensitivity Absolute Usage.
        /// </summary>
        [Description("Change Sensitivity Absolute")]
        ChangeSensitivityAbsolute14 = 0x0020100d,

        /// <summary>
        ///     Change Sensitivity Absolute Usage.
        /// </summary>
        [Description("Change Sensitivity Absolute")]
        ChangeSensitivityAbsolute15 = 0x0020100e,

        /// <summary>
        ///     Change Sensitivity Absolute Usage.
        /// </summary>
        [Description("Change Sensitivity Absolute")]
        ChangeSensitivityAbsolute16 = 0x0020100f,

        /*
         * Range: 0x2000 -> 0x2fff
         * Maximum
         */

        /// <summary>
        ///     Maximum Usage.
        /// </summary>
        [Description("Maximum")]
        Maximum = 0x00202000,

        /// <summary>
        ///     Maximum Usage.
        /// </summary>
        [Description("Maximum")]
        Maximum2 = 0x00202001,

        /// <summary>
        ///     Maximum Usage.
        /// </summary>
        [Description("Maximum")]
        Maximum3 = 0x00202002,

        /// <summary>
        ///     Maximum Usage.
        /// </summary>
        [Description("Maximum")]
        Maximum4 = 0x00202003,

        /// <summary>
        ///     Maximum Usage.
        /// </summary>
        [Description("Maximum")]
        Maximum5 = 0x00202004,

        /// <summary>
        ///     Maximum Usage.
        /// </summary>
        [Description("Maximum")]
        Maximum6 = 0x00202005,

        /// <summary>
        ///     Maximum Usage.
        /// </summary>
        [Description("Maximum")]
        Maximum7 = 0x00202006,

        /// <summary>
        ///     Maximum Usage.
        /// </summary>
        [Description("Maximum")]
        Maximum8 = 0x00202007,

        /// <summary>
        ///     Maximum Usage.
        /// </summary>
        [Description("Maximum")]
        Maximum9 = 0x00202008,

        /// <summary>
        ///     Maximum Usage.
        /// </summary>
        [Description("Maximum")]
        Maximum10 = 0x00202009,

        /// <summary>
        ///     Maximum Usage.
        /// </summary>
        [Description("Maximum")]
        Maximum11 = 0x0020200a,

        /// <summary>
        ///     Maximum Usage.
        /// </summary>
        [Description("Maximum")]
        Maximum12 = 0x0020200b,

        /// <summary>
        ///     Maximum Usage.
        /// </summary>
        [Description("Maximum")]
        Maximum13 = 0x0020200c,

        /// <summary>
        ///     Maximum Usage.
        /// </summary>
        [Description("Maximum")]
        Maximum14 = 0x0020200d,

        /// <summary>
        ///     Maximum Usage.
        /// </summary>
        [Description("Maximum")]
        Maximum15 = 0x0020200e,

        /// <summary>
        ///     Maximum Usage.
        /// </summary>
        [Description("Maximum")]
        Maximum16 = 0x0020200f,

        /*
         * Range: 0x3000 -> 0x3fff
         * Minimum
         */

        /// <summary>
        ///     Minimum Usage.
        /// </summary>
        [Description("Minimum")]
        Minimum = 0x00203000,

        /// <summary>
        ///     Minimum Usage.
        /// </summary>
        [Description("Minimum")]
        Minimum2 = 0x00203001,

        /// <summary>
        ///     Minimum Usage.
        /// </summary>
        [Description("Minimum")]
        Minimum3 = 0x00203002,

        /// <summary>
        ///     Minimum Usage.
        /// </summary>
        [Description("Minimum")]
        Minimum4 = 0x00203003,

        /// <summary>
        ///     Minimum Usage.
        /// </summary>
        [Description("Minimum")]
        Minimum5 = 0x00203004,

        /// <summary>
        ///     Minimum Usage.
        /// </summary>
        [Description("Minimum")]
        Minimum6 = 0x00203005,

        /// <summary>
        ///     Minimum Usage.
        /// </summary>
        [Description("Minimum")]
        Minimum7 = 0x00203006,

        /// <summary>
        ///     Minimum Usage.
        /// </summary>
        [Description("Minimum")]
        Minimum8 = 0x00203007,

        /// <summary>
        ///     Minimum Usage.
        /// </summary>
        [Description("Minimum")]
        Minimum9 = 0x00203008,

        /// <summary>
        ///     Minimum Usage.
        /// </summary>
        [Description("Minimum")]
        Minimum10 = 0x00203009,

        /// <summary>
        ///     Minimum Usage.
        /// </summary>
        [Description("Minimum")]
        Minimum11 = 0x0020300a,

        /// <summary>
        ///     Minimum Usage.
        /// </summary>
        [Description("Minimum")]
        Minimum12 = 0x0020300b,

        /// <summary>
        ///     Minimum Usage.
        /// </summary>
        [Description("Minimum")]
        Minimum13 = 0x0020300c,

        /// <summary>
        ///     Minimum Usage.
        /// </summary>
        [Description("Minimum")]
        Minimum14 = 0x0020300d,

        /// <summary>
        ///     Minimum Usage.
        /// </summary>
        [Description("Minimum")]
        Minimum15 = 0x0020300e,

        /// <summary>
        ///     Minimum Usage.
        /// </summary>
        [Description("Minimum")]
        Minimum16 = 0x0020300f,

        /*
         * Range: 0x4000 -> 0x4fff
         * Accuracy
         */

        /// <summary>
        ///     Accuracy Usage.
        /// </summary>
        [Description("Accuracy")]
        Accuracy = 0x00204000,

        /// <summary>
        ///     Accuracy Usage.
        /// </summary>
        [Description("Accuracy")]
        Accuracy2 = 0x00204001,

        /// <summary>
        ///     Accuracy Usage.
        /// </summary>
        [Description("Accuracy")]
        Accuracy3 = 0x00204002,

        /// <summary>
        ///     Accuracy Usage.
        /// </summary>
        [Description("Accuracy")]
        Accuracy4 = 0x00204003,

        /// <summary>
        ///     Accuracy Usage.
        /// </summary>
        [Description("Accuracy")]
        Accuracy5 = 0x00204004,

        /// <summary>
        ///     Accuracy Usage.
        /// </summary>
        [Description("Accuracy")]
        Accuracy6 = 0x00204005,

        /// <summary>
        ///     Accuracy Usage.
        /// </summary>
        [Description("Accuracy")]
        Accuracy7 = 0x00204006,

        /// <summary>
        ///     Accuracy Usage.
        /// </summary>
        [Description("Accuracy")]
        Accuracy8 = 0x00204007,

        /// <summary>
        ///     Accuracy Usage.
        /// </summary>
        [Description("Accuracy")]
        Accuracy9 = 0x00204008,

        /// <summary>
        ///     Accuracy Usage.
        /// </summary>
        [Description("Accuracy")]
        Accuracy10 = 0x00204009,

        /// <summary>
        ///     Accuracy Usage.
        /// </summary>
        [Description("Accuracy")]
        Accuracy11 = 0x0020400a,

        /// <summary>
        ///     Accuracy Usage.
        /// </summary>
        [Description("Accuracy")]
        Accuracy12 = 0x0020400b,

        /// <summary>
        ///     Accuracy Usage.
        /// </summary>
        [Description("Accuracy")]
        Accuracy13 = 0x0020400c,

        /// <summary>
        ///     Accuracy Usage.
        /// </summary>
        [Description("Accuracy")]
        Accuracy14 = 0x0020400d,

        /// <summary>
        ///     Accuracy Usage.
        /// </summary>
        [Description("Accuracy")]
        Accuracy15 = 0x0020400e,

        /// <summary>
        ///     Accuracy Usage.
        /// </summary>
        [Description("Accuracy")]
        Accuracy16 = 0x0020400f,

        /*
         * Range: 0x5000 -> 0x5fff
         * Resolution
         */

        /// <summary>
        ///     Resolution Usage.
        /// </summary>
        [Description("Resolution")]
        Resolution = 0x00205000,

        /// <summary>
        ///     Resolution Usage.
        /// </summary>
        [Description("Resolution")]
        Resolution2 = 0x00205001,

        /// <summary>
        ///     Resolution Usage.
        /// </summary>
        [Description("Resolution")]
        Resolution3 = 0x00205002,

        /// <summary>
        ///     Resolution Usage.
        /// </summary>
        [Description("Resolution")]
        Resolution4 = 0x00205003,

        /// <summary>
        ///     Resolution Usage.
        /// </summary>
        [Description("Resolution")]
        Resolution5 = 0x00205004,

        /// <summary>
        ///     Resolution Usage.
        /// </summary>
        [Description("Resolution")]
        Resolution6 = 0x00205005,

        /// <summary>
        ///     Resolution Usage.
        /// </summary>
        [Description("Resolution")]
        Resolution7 = 0x00205006,

        /// <summary>
        ///     Resolution Usage.
        /// </summary>
        [Description("Resolution")]
        Resolution8 = 0x00205007,

        /// <summary>
        ///     Resolution Usage.
        /// </summary>
        [Description("Resolution")]
        Resolution9 = 0x00205008,

        /// <summary>
        ///     Resolution Usage.
        /// </summary>
        [Description("Resolution")]
        Resolution10 = 0x00205009,

        /// <summary>
        ///     Resolution Usage.
        /// </summary>
        [Description("Resolution")]
        Resolution11 = 0x0020500a,

        /// <summary>
        ///     Resolution Usage.
        /// </summary>
        [Description("Resolution")]
        Resolution12 = 0x0020500b,

        /// <summary>
        ///     Resolution Usage.
        /// </summary>
        [Description("Resolution")]
        Resolution13 = 0x0020500c,

        /// <summary>
        ///     Resolution Usage.
        /// </summary>
        [Description("Resolution")]
        Resolution14 = 0x0020500d,

        /// <summary>
        ///     Resolution Usage.
        /// </summary>
        [Description("Resolution")]
        Resolution15 = 0x0020500e,

        /// <summary>
        ///     Resolution Usage.
        /// </summary>
        [Description("Resolution")]
        Resolution16 = 0x0020500f,

        /*
         * Range: 0x6000 -> 0x6fff
         * Threshold High
         */

        /// <summary>
        ///     Threshold High Usage.
        /// </summary>
        [Description("Threshold High")]
        ThresholdHigh = 0x00206000,

        /// <summary>
        ///     Threshold High Usage.
        /// </summary>
        [Description("Threshold High")]
        ThresholdHigh2 = 0x00206001,

        /// <summary>
        ///     Threshold High Usage.
        /// </summary>
        [Description("Threshold High")]
        ThresholdHigh3 = 0x00206002,

        /// <summary>
        ///     Threshold High Usage.
        /// </summary>
        [Description("Threshold High")]
        ThresholdHigh4 = 0x00206003,

        /// <summary>
        ///     Threshold High Usage.
        /// </summary>
        [Description("Threshold High")]
        ThresholdHigh5 = 0x00206004,

        /// <summary>
        ///     Threshold High Usage.
        /// </summary>
        [Description("Threshold High")]
        ThresholdHigh6 = 0x00206005,

        /// <summary>
        ///     Threshold High Usage.
        /// </summary>
        [Description("Threshold High")]
        ThresholdHigh7 = 0x00206006,

        /// <summary>
        ///     Threshold High Usage.
        /// </summary>
        [Description("Threshold High")]
        ThresholdHigh8 = 0x00206007,

        /// <summary>
        ///     Threshold High Usage.
        /// </summary>
        [Description("Threshold High")]
        ThresholdHigh9 = 0x00206008,

        /// <summary>
        ///     Threshold High Usage.
        /// </summary>
        [Description("Threshold High")]
        ThresholdHigh10 = 0x00206009,

        /// <summary>
        ///     Threshold High Usage.
        /// </summary>
        [Description("Threshold High")]
        ThresholdHigh11 = 0x0020600a,

        /// <summary>
        ///     Threshold High Usage.
        /// </summary>
        [Description("Threshold High")]
        ThresholdHigh12 = 0x0020600b,

        /// <summary>
        ///     Threshold High Usage.
        /// </summary>
        [Description("Threshold High")]
        ThresholdHigh13 = 0x0020600c,

        /// <summary>
        ///     Threshold High Usage.
        /// </summary>
        [Description("Threshold High")]
        ThresholdHigh14 = 0x0020600d,

        /// <summary>
        ///     Threshold High Usage.
        /// </summary>
        [Description("Threshold High")]
        ThresholdHigh15 = 0x0020600e,

        /// <summary>
        ///     Threshold High Usage.
        /// </summary>
        [Description("Threshold High")]
        ThresholdHigh16 = 0x0020600f,

        /*
         * Range: 0x7000 -> 0x7fff
         * Threshold Low
         */

        /// <summary>
        ///     Threshold Low Usage.
        /// </summary>
        [Description("Threshold Low")]
        ThresholdLow = 0x00207000,

        /// <summary>
        ///     Threshold Low Usage.
        /// </summary>
        [Description("Threshold Low")]
        ThresholdLow2 = 0x00207001,

        /// <summary>
        ///     Threshold Low Usage.
        /// </summary>
        [Description("Threshold Low")]
        ThresholdLow3 = 0x00207002,

        /// <summary>
        ///     Threshold Low Usage.
        /// </summary>
        [Description("Threshold Low")]
        ThresholdLow4 = 0x00207003,

        /// <summary>
        ///     Threshold Low Usage.
        /// </summary>
        [Description("Threshold Low")]
        ThresholdLow5 = 0x00207004,

        /// <summary>
        ///     Threshold Low Usage.
        /// </summary>
        [Description("Threshold Low")]
        ThresholdLow6 = 0x00207005,

        /// <summary>
        ///     Threshold Low Usage.
        /// </summary>
        [Description("Threshold Low")]
        ThresholdLow7 = 0x00207006,

        /// <summary>
        ///     Threshold Low Usage.
        /// </summary>
        [Description("Threshold Low")]
        ThresholdLow8 = 0x00207007,

        /// <summary>
        ///     Threshold Low Usage.
        /// </summary>
        [Description("Threshold Low")]
        ThresholdLow9 = 0x00207008,

        /// <summary>
        ///     Threshold Low Usage.
        /// </summary>
        [Description("Threshold Low")]
        ThresholdLow10 = 0x00207009,

        /// <summary>
        ///     Threshold Low Usage.
        /// </summary>
        [Description("Threshold Low")]
        ThresholdLow11 = 0x0020700a,

        /// <summary>
        ///     Threshold Low Usage.
        /// </summary>
        [Description("Threshold Low")]
        ThresholdLow12 = 0x0020700b,

        /// <summary>
        ///     Threshold Low Usage.
        /// </summary>
        [Description("Threshold Low")]
        ThresholdLow13 = 0x0020700c,

        /// <summary>
        ///     Threshold Low Usage.
        /// </summary>
        [Description("Threshold Low")]
        ThresholdLow14 = 0x0020700d,

        /// <summary>
        ///     Threshold Low Usage.
        /// </summary>
        [Description("Threshold Low")]
        ThresholdLow15 = 0x0020700e,

        /// <summary>
        ///     Threshold Low Usage.
        /// </summary>
        [Description("Threshold Low")]
        ThresholdLow16 = 0x0020700f,

        /*
         * Range: 0x8000 -> 0x8fff
         * Calibration Offset
         */

        /// <summary>
        ///     Calibration Offset Usage.
        /// </summary>
        [Description("Calibration Offset")]
        CalibrationOffset = 0x00208000,

        /// <summary>
        ///     Calibration Offset Usage.
        /// </summary>
        [Description("Calibration Offset")]
        CalibrationOffset2 = 0x00208001,

        /// <summary>
        ///     Calibration Offset Usage.
        /// </summary>
        [Description("Calibration Offset")]
        CalibrationOffset3 = 0x00208002,

        /// <summary>
        ///     Calibration Offset Usage.
        /// </summary>
        [Description("Calibration Offset")]
        CalibrationOffset4 = 0x00208003,

        /// <summary>
        ///     Calibration Offset Usage.
        /// </summary>
        [Description("Calibration Offset")]
        CalibrationOffset5 = 0x00208004,

        /// <summary>
        ///     Calibration Offset Usage.
        /// </summary>
        [Description("Calibration Offset")]
        CalibrationOffset6 = 0x00208005,

        /// <summary>
        ///     Calibration Offset Usage.
        /// </summary>
        [Description("Calibration Offset")]
        CalibrationOffset7 = 0x00208006,

        /// <summary>
        ///     Calibration Offset Usage.
        /// </summary>
        [Description("Calibration Offset")]
        CalibrationOffset8 = 0x00208007,

        /// <summary>
        ///     Calibration Offset Usage.
        /// </summary>
        [Description("Calibration Offset")]
        CalibrationOffset9 = 0x00208008,

        /// <summary>
        ///     Calibration Offset Usage.
        /// </summary>
        [Description("Calibration Offset")]
        CalibrationOffset10 = 0x00208009,

        /// <summary>
        ///     Calibration Offset Usage.
        /// </summary>
        [Description("Calibration Offset")]
        CalibrationOffset11 = 0x0020800a,

        /// <summary>
        ///     Calibration Offset Usage.
        /// </summary>
        [Description("Calibration Offset")]
        CalibrationOffset12 = 0x0020800b,

        /// <summary>
        ///     Calibration Offset Usage.
        /// </summary>
        [Description("Calibration Offset")]
        CalibrationOffset13 = 0x0020800c,

        /// <summary>
        ///     Calibration Offset Usage.
        /// </summary>
        [Description("Calibration Offset")]
        CalibrationOffset14 = 0x0020800d,

        /// <summary>
        ///     Calibration Offset Usage.
        /// </summary>
        [Description("Calibration Offset")]
        CalibrationOffset15 = 0x0020800e,

        /// <summary>
        ///     Calibration Offset Usage.
        /// </summary>
        [Description("Calibration Offset")]
        CalibrationOffset16 = 0x0020800f,

        /*
         * Range: 0x9000 -> 0x9fff
         * Calibration Multiplier
         */

        /// <summary>
        ///     Calibration Multiplier Usage.
        /// </summary>
        [Description("Calibration Multiplier")]
        CalibrationMultiplier = 0x00209000,

        /// <summary>
        ///     Calibration Multiplier Usage.
        /// </summary>
        [Description("Calibration Multiplier")]
        CalibrationMultiplier2 = 0x00209001,

        /// <summary>
        ///     Calibration Multiplier Usage.
        /// </summary>
        [Description("Calibration Multiplier")]
        CalibrationMultiplier3 = 0x00209002,

        /// <summary>
        ///     Calibration Multiplier Usage.
        /// </summary>
        [Description("Calibration Multiplier")]
        CalibrationMultiplier4 = 0x00209003,

        /// <summary>
        ///     Calibration Multiplier Usage.
        /// </summary>
        [Description("Calibration Multiplier")]
        CalibrationMultiplier5 = 0x00209004,

        /// <summary>
        ///     Calibration Multiplier Usage.
        /// </summary>
        [Description("Calibration Multiplier")]
        CalibrationMultiplier6 = 0x00209005,

        /// <summary>
        ///     Calibration Multiplier Usage.
        /// </summary>
        [Description("Calibration Multiplier")]
        CalibrationMultiplier7 = 0x00209006,

        /// <summary>
        ///     Calibration Multiplier Usage.
        /// </summary>
        [Description("Calibration Multiplier")]
        CalibrationMultiplier8 = 0x00209007,

        /// <summary>
        ///     Calibration Multiplier Usage.
        /// </summary>
        [Description("Calibration Multiplier")]
        CalibrationMultiplier9 = 0x00209008,

        /// <summary>
        ///     Calibration Multiplier Usage.
        /// </summary>
        [Description("Calibration Multiplier")]
        CalibrationMultiplier10 = 0x00209009,

        /// <summary>
        ///     Calibration Multiplier Usage.
        /// </summary>
        [Description("Calibration Multiplier")]
        CalibrationMultiplier11 = 0x0020900a,

        /// <summary>
        ///     Calibration Multiplier Usage.
        /// </summary>
        [Description("Calibration Multiplier")]
        CalibrationMultiplier12 = 0x0020900b,

        /// <summary>
        ///     Calibration Multiplier Usage.
        /// </summary>
        [Description("Calibration Multiplier")]
        CalibrationMultiplier13 = 0x0020900c,

        /// <summary>
        ///     Calibration Multiplier Usage.
        /// </summary>
        [Description("Calibration Multiplier")]
        CalibrationMultiplier14 = 0x0020900d,

        /// <summary>
        ///     Calibration Multiplier Usage.
        /// </summary>
        [Description("Calibration Multiplier")]
        CalibrationMultiplier15 = 0x0020900e,

        /// <summary>
        ///     Calibration Multiplier Usage.
        /// </summary>
        [Description("Calibration Multiplier")]
        CalibrationMultiplier16 = 0x0020900f,

        /*
         * Range: 0xa000 -> 0xafff
         * Report Interval
         */

        /// <summary>
        ///     Report Interval Usage.
        /// </summary>
        [Description("Report Interval")]
        ReportInterval = 0x0020a000,

        /// <summary>
        ///     Report Interval Usage.
        /// </summary>
        [Description("Report Interval")]
        ReportInterval2 = 0x0020a001,

        /// <summary>
        ///     Report Interval Usage.
        /// </summary>
        [Description("Report Interval")]
        ReportInterval3 = 0x0020a002,

        /// <summary>
        ///     Report Interval Usage.
        /// </summary>
        [Description("Report Interval")]
        ReportInterval4 = 0x0020a003,

        /// <summary>
        ///     Report Interval Usage.
        /// </summary>
        [Description("Report Interval")]
        ReportInterval5 = 0x0020a004,

        /// <summary>
        ///     Report Interval Usage.
        /// </summary>
        [Description("Report Interval")]
        ReportInterval6 = 0x0020a005,

        /// <summary>
        ///     Report Interval Usage.
        /// </summary>
        [Description("Report Interval")]
        ReportInterval7 = 0x0020a006,

        /// <summary>
        ///     Report Interval Usage.
        /// </summary>
        [Description("Report Interval")]
        ReportInterval8 = 0x0020a007,

        /// <summary>
        ///     Report Interval Usage.
        /// </summary>
        [Description("Report Interval")]
        ReportInterval9 = 0x0020a008,

        /// <summary>
        ///     Report Interval Usage.
        /// </summary>
        [Description("Report Interval")]
        ReportInterval10 = 0x0020a009,

        /// <summary>
        ///     Report Interval Usage.
        /// </summary>
        [Description("Report Interval")]
        ReportInterval11 = 0x0020a00a,

        /// <summary>
        ///     Report Interval Usage.
        /// </summary>
        [Description("Report Interval")]
        ReportInterval12 = 0x0020a00b,

        /// <summary>
        ///     Report Interval Usage.
        /// </summary>
        [Description("Report Interval")]
        ReportInterval13 = 0x0020a00c,

        /// <summary>
        ///     Report Interval Usage.
        /// </summary>
        [Description("Report Interval")]
        ReportInterval14 = 0x0020a00d,

        /// <summary>
        ///     Report Interval Usage.
        /// </summary>
        [Description("Report Interval")]
        ReportInterval15 = 0x0020a00e,

        /// <summary>
        ///     Report Interval Usage.
        /// </summary>
        [Description("Report Interval")]
        ReportInterval16 = 0x0020a00f,

        /*
         * Range: 0xb000 -> 0xbfff
         * Frequency Max
         */

        /// <summary>
        ///     Frequency Max Usage.
        /// </summary>
        [Description("Frequency Max")]
        FrequencyMax = 0x0020b000,

        /// <summary>
        ///     Frequency Max Usage.
        /// </summary>
        [Description("Frequency Max")]
        FrequencyMax2 = 0x0020b001,

        /// <summary>
        ///     Frequency Max Usage.
        /// </summary>
        [Description("Frequency Max")]
        FrequencyMax3 = 0x0020b002,

        /// <summary>
        ///     Frequency Max Usage.
        /// </summary>
        [Description("Frequency Max")]
        FrequencyMax4 = 0x0020b003,

        /// <summary>
        ///     Frequency Max Usage.
        /// </summary>
        [Description("Frequency Max")]
        FrequencyMax5 = 0x0020b004,

        /// <summary>
        ///     Frequency Max Usage.
        /// </summary>
        [Description("Frequency Max")]
        FrequencyMax6 = 0x0020b005,

        /// <summary>
        ///     Frequency Max Usage.
        /// </summary>
        [Description("Frequency Max")]
        FrequencyMax7 = 0x0020b006,

        /// <summary>
        ///     Frequency Max Usage.
        /// </summary>
        [Description("Frequency Max")]
        FrequencyMax8 = 0x0020b007,

        /// <summary>
        ///     Frequency Max Usage.
        /// </summary>
        [Description("Frequency Max")]
        FrequencyMax9 = 0x0020b008,

        /// <summary>
        ///     Frequency Max Usage.
        /// </summary>
        [Description("Frequency Max")]
        FrequencyMax10 = 0x0020b009,

        /// <summary>
        ///     Frequency Max Usage.
        /// </summary>
        [Description("Frequency Max")]
        FrequencyMax11 = 0x0020b00a,

        /// <summary>
        ///     Frequency Max Usage.
        /// </summary>
        [Description("Frequency Max")]
        FrequencyMax12 = 0x0020b00b,

        /// <summary>
        ///     Frequency Max Usage.
        /// </summary>
        [Description("Frequency Max")]
        FrequencyMax13 = 0x0020b00c,

        /// <summary>
        ///     Frequency Max Usage.
        /// </summary>
        [Description("Frequency Max")]
        FrequencyMax14 = 0x0020b00d,

        /// <summary>
        ///     Frequency Max Usage.
        /// </summary>
        [Description("Frequency Max")]
        FrequencyMax15 = 0x0020b00e,

        /// <summary>
        ///     Frequency Max Usage.
        /// </summary>
        [Description("Frequency Max")]
        FrequencyMax16 = 0x0020b00f,

        /*
         * Range: 0xc000 -> 0xcfff
         * Period Max
         */

        /// <summary>
        ///     Period Max Usage.
        /// </summary>
        [Description("Period Max")]
        PeriodMax = 0x0020c000,

        /// <summary>
        ///     Period Max Usage.
        /// </summary>
        [Description("Period Max")]
        PeriodMax2 = 0x0020c001,

        /// <summary>
        ///     Period Max Usage.
        /// </summary>
        [Description("Period Max")]
        PeriodMax3 = 0x0020c002,

        /// <summary>
        ///     Period Max Usage.
        /// </summary>
        [Description("Period Max")]
        PeriodMax4 = 0x0020c003,

        /// <summary>
        ///     Period Max Usage.
        /// </summary>
        [Description("Period Max")]
        PeriodMax5 = 0x0020c004,

        /// <summary>
        ///     Period Max Usage.
        /// </summary>
        [Description("Period Max")]
        PeriodMax6 = 0x0020c005,

        /// <summary>
        ///     Period Max Usage.
        /// </summary>
        [Description("Period Max")]
        PeriodMax7 = 0x0020c006,

        /// <summary>
        ///     Period Max Usage.
        /// </summary>
        [Description("Period Max")]
        PeriodMax8 = 0x0020c007,

        /// <summary>
        ///     Period Max Usage.
        /// </summary>
        [Description("Period Max")]
        PeriodMax9 = 0x0020c008,

        /// <summary>
        ///     Period Max Usage.
        /// </summary>
        [Description("Period Max")]
        PeriodMax10 = 0x0020c009,

        /// <summary>
        ///     Period Max Usage.
        /// </summary>
        [Description("Period Max")]
        PeriodMax11 = 0x0020c00a,

        /// <summary>
        ///     Period Max Usage.
        /// </summary>
        [Description("Period Max")]
        PeriodMax12 = 0x0020c00b,

        /// <summary>
        ///     Period Max Usage.
        /// </summary>
        [Description("Period Max")]
        PeriodMax13 = 0x0020c00c,

        /// <summary>
        ///     Period Max Usage.
        /// </summary>
        [Description("Period Max")]
        PeriodMax14 = 0x0020c00d,

        /// <summary>
        ///     Period Max Usage.
        /// </summary>
        [Description("Period Max")]
        PeriodMax15 = 0x0020c00e,

        /// <summary>
        ///     Period Max Usage.
        /// </summary>
        [Description("Period Max")]
        PeriodMax16 = 0x0020c00f,

        /*
         * Range: 0xd000 -> 0xdfff
         * Change Sensitivity Percent of Range
         */

        /// <summary>
        ///     Change Sensitivity Percent of Range Usage.
        /// </summary>
        [Description("Change Sensitivity Percent of Range")]
        ChangeSensitivityPercentOfRange = 0x0020d000,

        /// <summary>
        ///     Change Sensitivity Percent of Range Usage.
        /// </summary>
        [Description("Change Sensitivity Percent of Range")]
        ChangeSensitivityPercentOfRange2 = 0x0020d001,

        /// <summary>
        ///     Change Sensitivity Percent of Range Usage.
        /// </summary>
        [Description("Change Sensitivity Percent of Range")]
        ChangeSensitivityPercentOfRange3 = 0x0020d002,

        /// <summary>
        ///     Change Sensitivity Percent of Range Usage.
        /// </summary>
        [Description("Change Sensitivity Percent of Range")]
        ChangeSensitivityPercentOfRange4 = 0x0020d003,

        /// <summary>
        ///     Change Sensitivity Percent of Range Usage.
        /// </summary>
        [Description("Change Sensitivity Percent of Range")]
        ChangeSensitivityPercentOfRange5 = 0x0020d004,

        /// <summary>
        ///     Change Sensitivity Percent of Range Usage.
        /// </summary>
        [Description("Change Sensitivity Percent of Range")]
        ChangeSensitivityPercentOfRange6 = 0x0020d005,

        /// <summary>
        ///     Change Sensitivity Percent of Range Usage.
        /// </summary>
        [Description("Change Sensitivity Percent of Range")]
        ChangeSensitivityPercentOfRange7 = 0x0020d006,

        /// <summary>
        ///     Change Sensitivity Percent of Range Usage.
        /// </summary>
        [Description("Change Sensitivity Percent of Range")]
        ChangeSensitivityPercentOfRange8 = 0x0020d007,

        /// <summary>
        ///     Change Sensitivity Percent of Range Usage.
        /// </summary>
        [Description("Change Sensitivity Percent of Range")]
        ChangeSensitivityPercentOfRange9 = 0x0020d008,

        /// <summary>
        ///     Change Sensitivity Percent of Range Usage.
        /// </summary>
        [Description("Change Sensitivity Percent of Range")]
        ChangeSensitivityPercentOfRange10 = 0x0020d009,

        /// <summary>
        ///     Change Sensitivity Percent of Range Usage.
        /// </summary>
        [Description("Change Sensitivity Percent of Range")]
        ChangeSensitivityPercentOfRange11 = 0x0020d00a,

        /// <summary>
        ///     Change Sensitivity Percent of Range Usage.
        /// </summary>
        [Description("Change Sensitivity Percent of Range")]
        ChangeSensitivityPercentOfRange12 = 0x0020d00b,

        /// <summary>
        ///     Change Sensitivity Percent of Range Usage.
        /// </summary>
        [Description("Change Sensitivity Percent of Range")]
        ChangeSensitivityPercentOfRange13 = 0x0020d00c,

        /// <summary>
        ///     Change Sensitivity Percent of Range Usage.
        /// </summary>
        [Description("Change Sensitivity Percent of Range")]
        ChangeSensitivityPercentOfRange14 = 0x0020d00d,

        /// <summary>
        ///     Change Sensitivity Percent of Range Usage.
        /// </summary>
        [Description("Change Sensitivity Percent of Range")]
        ChangeSensitivityPercentOfRange15 = 0x0020d00e,

        /// <summary>
        ///     Change Sensitivity Percent of Range Usage.
        /// </summary>
        [Description("Change Sensitivity Percent of Range")]
        ChangeSensitivityPercentOfRange16 = 0x0020d00f,

        /*
         * Range: 0xe000 -> 0xefff
         * Change Sensitivity Percent Relative
         */

        /// <summary>
        ///     Change Sensitivity Percent Relative Usage.
        /// </summary>
        [Description("Change Sensitivity Percent Relative")]
        ChangeSensitivityPercentRelative = 0x0020e000,

        /// <summary>
        ///     Change Sensitivity Percent Relative Usage.
        /// </summary>
        [Description("Change Sensitivity Percent Relative")]
        ChangeSensitivityPercentRelative2 = 0x0020e001,

        /// <summary>
        ///     Change Sensitivity Percent Relative Usage.
        /// </summary>
        [Description("Change Sensitivity Percent Relative")]
        ChangeSensitivityPercentRelative3 = 0x0020e002,

        /// <summary>
        ///     Change Sensitivity Percent Relative Usage.
        /// </summary>
        [Description("Change Sensitivity Percent Relative")]
        ChangeSensitivityPercentRelative4 = 0x0020e003,

        /// <summary>
        ///     Change Sensitivity Percent Relative Usage.
        /// </summary>
        [Description("Change Sensitivity Percent Relative")]
        ChangeSensitivityPercentRelative5 = 0x0020e004,

        /// <summary>
        ///     Change Sensitivity Percent Relative Usage.
        /// </summary>
        [Description("Change Sensitivity Percent Relative")]
        ChangeSensitivityPercentRelative6 = 0x0020e005,

        /// <summary>
        ///     Change Sensitivity Percent Relative Usage.
        /// </summary>
        [Description("Change Sensitivity Percent Relative")]
        ChangeSensitivityPercentRelative7 = 0x0020e006,

        /// <summary>
        ///     Change Sensitivity Percent Relative Usage.
        /// </summary>
        [Description("Change Sensitivity Percent Relative")]
        ChangeSensitivityPercentRelative8 = 0x0020e007,

        /// <summary>
        ///     Change Sensitivity Percent Relative Usage.
        /// </summary>
        [Description("Change Sensitivity Percent Relative")]
        ChangeSensitivityPercentRelative9 = 0x0020e008,

        /// <summary>
        ///     Change Sensitivity Percent Relative Usage.
        /// </summary>
        [Description("Change Sensitivity Percent Relative")]
        ChangeSensitivityPercentRelative10 = 0x0020e009,

        /// <summary>
        ///     Change Sensitivity Percent Relative Usage.
        /// </summary>
        [Description("Change Sensitivity Percent Relative")]
        ChangeSensitivityPercentRelative11 = 0x0020e00a,

        /// <summary>
        ///     Change Sensitivity Percent Relative Usage.
        /// </summary>
        [Description("Change Sensitivity Percent Relative")]
        ChangeSensitivityPercentRelative12 = 0x0020e00b,

        /// <summary>
        ///     Change Sensitivity Percent Relative Usage.
        /// </summary>
        [Description("Change Sensitivity Percent Relative")]
        ChangeSensitivityPercentRelative13 = 0x0020e00c,

        /// <summary>
        ///     Change Sensitivity Percent Relative Usage.
        /// </summary>
        [Description("Change Sensitivity Percent Relative")]
        ChangeSensitivityPercentRelative14 = 0x0020e00d,

        /// <summary>
        ///     Change Sensitivity Percent Relative Usage.
        /// </summary>
        [Description("Change Sensitivity Percent Relative")]
        ChangeSensitivityPercentRelative15 = 0x0020e00e,

        /// <summary>
        ///     Change Sensitivity Percent Relative Usage.
        /// </summary>
        [Description("Change Sensitivity Percent Relative")]
        ChangeSensitivityPercentRelative16 = 0x0020e00f
    }
}