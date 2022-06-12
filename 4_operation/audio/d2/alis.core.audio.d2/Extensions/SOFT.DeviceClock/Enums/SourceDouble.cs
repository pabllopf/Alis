// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   SourceDouble.cs
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
    ///     The source double enum
    /// </summary>
    public enum SourceDouble
    {
        /// <summary>
        ///     AL_SEC_OFFSET_LATENCY_SOFT
        ///     <br />
        ///     The playback position, along with the device clock, both expressed in seconds.
        ///     This attribute is read-only.
        ///     <br />
        ///     The first value in the returned vector is the offset in seconds.
        ///     The value is similar to that returned by <see cref="ALSourcef.SecOffset" />, just with more precision.
        ///     <br />
        ///     The second value is the device clock, in seconds.
        ///     This updates at the same rate as the offset, and both are measured atomically with respect to one another.
        ///     Be aware that this value may be subtly different from the other device clock queries due to the variable precision
        ///     of floating-point values.
        /// </summary>
        SecOffsetClock = 0x1203
    }
}