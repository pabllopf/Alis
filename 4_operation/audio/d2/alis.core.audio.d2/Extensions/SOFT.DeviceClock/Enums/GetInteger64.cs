// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   GetInteger64.cs
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

namespace Alis.Core.Audio.D2.Extensions.SOFT.DeviceClock.Enums
{
    /// <summary>
    ///     The get integer 64 enum
    /// </summary>
    public enum GetInteger64
    {
        /// <summary>
        ///     The audio device clock time, expressed
        ///     in nanoseconds.
        ///     NULL is an invalid device.
        ///     ALC_DEVICE_CLOCK_SOFT
        /// </summary>
        DeviceClock = 0x1600,

        /// <summary>
        ///     The current audio device latency, in nanoseconds.
        ///     This is effectively the delay for the samples rendered at the the device's current clock time from reaching the
        ///     physical output.
        ///     NULL is an invalid device.
        ///     ALC_DEVICE_LATENCY_SOFT
        /// </summary>
        DeviceLatency = 0x1601,

        /// <summary>
        ///     Expects a destination size of 2, and provides both the audio device clock time and latency, both in nanoseconds.
        ///     The two values are measured atomically with respect to one another (i.e. the latency value was measured at the same
        ///     time the device clock value was retrieved).
        ///     NULL is an invalid device.
        ///     ALC_DEVICE_CLOCK_LATENCY_SOFT
        /// </summary>
        DeviceClockLatency = 0x1602
    }
}