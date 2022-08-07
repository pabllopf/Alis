// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   UsagePage.cs
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

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Alis.Core.Input
{
#pragma warning disable CS0108
    /// <summary>
    ///     Base class for all usage pages.
    /// </summary>
    public partial class UsagePage
    {
        /// <summary>
        ///     Dictionary of all defined usage pages.
        /// </summary>
        private static ConcurrentDictionary<ushort, UsagePage> s_pages =
            new ConcurrentDictionary<ushort, UsagePage>
            {
                [0x0001] = GenericDesktopUsagePage.Instance,
                [0x0002] = SimulationUsagePage.Instance,
                [0x0003] = VRUsagePage.Instance,
                [0x0004] = SportUsagePage.Instance,
                [0x0005] = GameUsagePage.Instance,
                [0x0006] = GenericDeviceUsagePage.Instance,
                [0x0007] = KeyboardKeypadUsagePage.Instance,
                [0x0008] = LEDsUsagePage.Instance,
                [0x0009] = ButtonUsagePage.Instance,
                [0x000a] = OrdinalUsagePage.Instance,
                [0x000b] = TelephonyUsagePage.Instance,
                [0x000c] = ConsumerUsagePage.Instance,
                [0x000d] = DigitizerUsagePage.Instance,
                [0x000e] = HapticsUsagePage.Instance,
                [0x000f] = PhysicalInterfaceDeviceUsagePage.Instance,
                [0x0010] = UnicodeUsagePage.Instance,
                [0x0012] = EyeAndHeadTrackersUsagePage.Instance,
                [0x0014] = AuxiliaryDisplayUsagePage.Instance,
                [0x0020] = SensorUsagePage.Instance,
                [0x0040] = MedicalInstrumentsUsagePage.Instance,
                [0x0041] = BrailleDisplayUsagePage.Instance,
                [0x0059] = LightingAndIlluminationUsagePage.Instance,
                [0x0080] = MonitorUsagePage.Instance,
                [0x0081] = MonitorEnumeratedValuesUsagePage.Instance,
                [0x0082] = VESAVirtualUsagePage.Instance,
                [0x0083] = MonitorReservedUsagePage.Instance,
                [0x0084] = PowerDeviceUsagePage.Instance,
                [0x0085] = BatterySystemUsagePage.Instance,
                [0x008c] = BarCodeScannerUsagePage.Instance,
                [0x008d] = WeighingDevicesUsagePage.Instance,
                [0x008e] = MagneticStripeReadingMSRDevicesUsagePage.Instance,
                [0x008f] = ReservedPointOfSaleUsagePage.Instance,
                [0x0090] = CameraControlUsagePage.Instance,
                [0x0091] = ArcadeUsagePage.Instance,
                [0xf1d0] = FastIDentityOnlineAllianceUsagePage.Instance
            };

        /// <summary>
        ///     Generic Desktop Controls Usage Page.
        /// </summary>
        public static readonly GenericDesktopUsagePage GenericDesktop = GenericDesktopUsagePage.Instance;

        /// <summary>
        ///     Simulation Controls Usage Page.
        /// </summary>
        public static readonly SimulationUsagePage Simulation = SimulationUsagePage.Instance;

        /// <summary>
        ///     VR Controls Usage Page.
        /// </summary>
        public static readonly VRUsagePage VR = VRUsagePage.Instance;

        /// <summary>
        ///     Sport Controls Usage Page.
        /// </summary>
        public static readonly SportUsagePage Sport = SportUsagePage.Instance;

        /// <summary>
        ///     Game Controls Usage Page.
        /// </summary>
        public static readonly GameUsagePage Game = GameUsagePage.Instance;

        /// <summary>
        ///     Generic Device Controls Usage Page.
        /// </summary>
        public static readonly GenericDeviceUsagePage GenericDevice = GenericDeviceUsagePage.Instance;

        /// <summary>
        ///     Keyboard/Keypad Usage Page.
        /// </summary>
        public static readonly KeyboardKeypadUsagePage KeyboardKeypad = KeyboardKeypadUsagePage.Instance;

        /// <summary>
        ///     LEDs Usage Page.
        /// </summary>
        public static readonly LEDsUsagePage LEDs = LEDsUsagePage.Instance;

        /// <summary>
        ///     Button Usage Page.
        /// </summary>
        public static readonly ButtonUsagePage Button = ButtonUsagePage.Instance;

        /// <summary>
        ///     Ordinal Usage Page.
        /// </summary>
        public static readonly OrdinalUsagePage Ordinal = OrdinalUsagePage.Instance;

        /// <summary>
        ///     Telephony Usage Page.
        /// </summary>
        public static readonly TelephonyUsagePage Telephony = TelephonyUsagePage.Instance;

        /// <summary>
        ///     Consumer Usage Page.
        /// </summary>
        public static readonly ConsumerUsagePage Consumer = ConsumerUsagePage.Instance;

        /// <summary>
        ///     Digitizer Usage Page.
        /// </summary>
        public static readonly DigitizerUsagePage Digitizer = DigitizerUsagePage.Instance;

        /// <summary>
        ///     Haptics Usage Page.
        /// </summary>
        public static readonly HapticsUsagePage Haptics = HapticsUsagePage.Instance;

        /// <summary>
        ///     Physical Interface Device Usage Page.
        /// </summary>
        public static readonly PhysicalInterfaceDeviceUsagePage PhysicalInterfaceDevice =
            PhysicalInterfaceDeviceUsagePage.Instance;

        /// <summary>
        ///     Unicode Usage Page.
        /// </summary>
        public static readonly UnicodeUsagePage Unicode = UnicodeUsagePage.Instance;

        /// <summary>
        ///     Eye and Head Trackers Usage Page.
        /// </summary>
        public static readonly EyeAndHeadTrackersUsagePage EyeAndHeadTrackers = EyeAndHeadTrackersUsagePage.Instance;

        /// <summary>
        ///     Auxiliary Display Usage Page.
        /// </summary>
        public static readonly AuxiliaryDisplayUsagePage AuxiliaryDisplay = AuxiliaryDisplayUsagePage.Instance;

        /// <summary>
        ///     Sensor Usage Page.
        /// </summary>
        public static readonly SensorUsagePage Sensor = SensorUsagePage.Instance;

        /// <summary>
        ///     Medical Instruments Usage Page.
        /// </summary>
        public static readonly MedicalInstrumentsUsagePage MedicalInstruments = MedicalInstrumentsUsagePage.Instance;

        /// <summary>
        ///     Braille Display Usage Page.
        /// </summary>
        public static readonly BrailleDisplayUsagePage BrailleDisplay = BrailleDisplayUsagePage.Instance;

        /// <summary>
        ///     Lighting and Illumination Usage Page.
        /// </summary>
        public static readonly LightingAndIlluminationUsagePage LightingAndIllumination =
            LightingAndIlluminationUsagePage.Instance;

        /// <summary>
        ///     Monitor Usage Page.
        /// </summary>
        public static readonly MonitorUsagePage Monitor = MonitorUsagePage.Instance;

        /// <summary>
        ///     Monitor Enumerated Values Usage Page.
        /// </summary>
        public static readonly MonitorEnumeratedValuesUsagePage MonitorEnumeratedValues =
            MonitorEnumeratedValuesUsagePage.Instance;

        /// <summary>
        ///     VESA Virtual Controls Usage Page.
        /// </summary>
        public static readonly VESAVirtualUsagePage VESAVirtual = VESAVirtualUsagePage.Instance;

        /// <summary>
        ///     Monitor Reserved Usage Page.
        /// </summary>
        public static readonly MonitorReservedUsagePage MonitorReserved = MonitorReservedUsagePage.Instance;

        /// <summary>
        ///     Power Device Usage Page.
        /// </summary>
        public static readonly PowerDeviceUsagePage PowerDevice = PowerDeviceUsagePage.Instance;

        /// <summary>
        ///     Battery System Usage Page.
        /// </summary>
        public static readonly BatterySystemUsagePage BatterySystem = BatterySystemUsagePage.Instance;

        /// <summary>
        ///     Bar Code Scanner Usage Page.
        /// </summary>
        public static readonly BarCodeScannerUsagePage BarCodeScanner = BarCodeScannerUsagePage.Instance;

        /// <summary>
        ///     Weighing Devices Usage Page.
        /// </summary>
        public static readonly WeighingDevicesUsagePage WeighingDevices = WeighingDevicesUsagePage.Instance;

        /// <summary>
        ///     Magnetic Stripe Reading (MSR) Devices Usage Page.
        /// </summary>
        public static readonly MagneticStripeReadingMSRDevicesUsagePage MagneticStripeReadingMSRDevices =
            MagneticStripeReadingMSRDevicesUsagePage.Instance;

        /// <summary>
        ///     Reserved Point of Sale Usage Page.
        /// </summary>
        public static readonly ReservedPointOfSaleUsagePage ReservedPointOfSale = ReservedPointOfSaleUsagePage.Instance;

        /// <summary>
        ///     Camera Control Usage Page.
        /// </summary>
        public static readonly CameraControlUsagePage CameraControl = CameraControlUsagePage.Instance;

        /// <summary>
        ///     Arcade Usage Page.
        /// </summary>
        public static readonly ArcadeUsagePage Arcade = ArcadeUsagePage.Instance;

        /// <summary>
        ///     Fast IDentity Online Alliance Usage Page.
        /// </summary>
        public static readonly FastIDentityOnlineAllianceUsagePage FastIDentityOnlineAlliance =
            FastIDentityOnlineAllianceUsagePage.Instance;
    }
#pragma warning restore CS0108

    /// <summary>
    ///     Class UsagePage. This class cannot be inherited.
    ///     Implements the <see cref="IEnumerable{T}" /> interface.
    ///     Implements the <see cref="IEquatable{T}" /> interface.
    ///     Base class for a collection of Usages.
    /// </summary>
    /// <seealso cref="IEnumerable{T}" />
    /// <seealso cref="IEquatable{T}" />
    /// <see href="https://www.usb.org/document-library/hid-usage-tables-112" />
    public partial class UsagePage : IEnumerable<Usage>, IEquatable<UsagePage>
    {
        /// <summary>
        ///     The usage
        /// </summary>
        protected readonly ConcurrentDictionary<ushort, Usage> Usages = new ConcurrentDictionary<ushort, Usage>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="UsagePage" /> class
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="name">The name</param>
        protected UsagePage(ushort id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        ///     Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public ushort Id { get; }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; }

        /// <summary>
        ///     Gets all currently available usage pages.
        /// </summary>
        /// <returns>A collection of usage pages.</returns>
        public static ICollection<UsagePage> All => s_pages.Values;

        /// <inheritdoc />
        public IEnumerator<Usage> GetEnumerator()
        {
            return Usages.Values.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <inheritdoc />
        public bool Equals(UsagePage other)
        {
            return !(other is null) && (ReferenceEquals(this, other) || Id == other.Id);
        }


        /// <summary>
        ///     Gets the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The usage page</returns>
        public static UsagePage Get(ushort id)
        {
            return s_pages.GetOrAdd(id, i => i < 0xFF00
                ? new UsagePage(i, $"Reserved (0x{id:X2})")
                : new UsagePage(i, $"Vendor-defined (0x{id:X2})"));
        }


        /// <summary>
        ///     Gets the usage
        /// </summary>
        /// <param name="usage">The usage</param>
        /// <returns>The usage page</returns>
        public static UsagePage Get(Enum usage)
        {
            return Get((ushort)(Convert.ToUInt32(usage) >> 16));
        }


        /// <summary>
        ///     Gets the full id
        /// </summary>
        /// <param name="fullId">The full id</param>
        /// <returns>The usage page</returns>
        public static UsagePage Get(uint fullId)
        {
            return Get((ushort)(fullId >> 16));
        }


        /// <summary>
        ///     Gets the usage using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The usage</returns>
        public Usage GetUsage(ushort id)
        {
            return Usages.GetOrAdd(id, CreateUsage);
        }


        /// <summary>
        ///     Creates the usage using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The usage</returns>
        protected virtual Usage CreateUsage(ushort id)
        {
            return new Usage(this, id, $"Undefined (0x{id:X2})", UsageTypes.None);
        }

        /// <summary>
        ///     EXAMPLE
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is UsagePage other && Equals(other));
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Id;
        }

        /// <summary>
        ///     Implements the == operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(UsagePage left, UsagePage right)
        {
            return Equals(left, right);
        }

        /// <summary>
        ///     Implements the != operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(UsagePage left, UsagePage right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        ///     Performs an implicit conversion from <see cref="UsagePage" /> to <see cref="System.UInt16" />.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator ushort(UsagePage page)
        {
            return page.Id;
        }

        /// <summary>
        ///     Performs an implicit conversion from <see cref="System.UInt16" /> to <see cref="UsagePage" />.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator UsagePage(ushort page)
        {
            return Get(page);
        }

        /// <summary>
        ///     Performs an implicit conversion from <see cref="Enum" /> to <see cref="UsagePage" />.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator UsagePage(Enum page)
        {
            return Get(page);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Name;
        }
    }
}