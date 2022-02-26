// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   SourceInteger64.cs
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

using Alis.Core.Audio.AL;

namespace Alis.Core.Audio.Extensions.SOFT.DeviceClock.Enums
{
    /// <summary>
    /// The source integer 64 enum
    /// </summary>
    public enum SourceInteger64
    {
        /// <summary>
        ///     AL_SAMPLE_OFFSET_CLOCK_SOFT
        ///     <br />
        ///     The playback position, expressed in fixed-point samples, along with the device clock, expressed in nanoseconds.
        ///     This attribute is read-only.
        ///     <br />
        ///     The first value in the returned vector is the sample offset, which is a 32.32 fixed-point value.
        ///     The whole number is stored in the upper 32 bits and the fractional component is in the lower 32 bits.
        ///     The value is similar to that returned by <see cref="ALSourcei.SampleOffset" />, just with more precision.
        ///     <br />
        ///     The second value is the device clock, in nanoseconds.
        ///     This updates at the same rate as the offset, and both are measured atomically with respect to one another.
        /// </summary>
        SampleOffsetClock = 0x1202
    }
}