// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   SourceLatencyVector2.cs
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

namespace Alis.Core.Audio.Extensions.SOFT.SourceLatency.Enums
{
    /// <summary>
    ///     The source latency vector 2i enum
    /// </summary>
    public enum SourceLatencyVector2i
    {
        /// <summary>
        ///     The playback position, expressed in fixed-point samples,
        ///     along with the playback latency, expressed in nanoseconds (1/1000000000ths
        ///     of a second). This attribute is read-only.
        ///     AL_SAMPLE_OFFSET_LATENCY_SOFT
        /// </summary>
        SampleOffsetLatency = 0x1200
    }

#pragma warning disable SA1402 // File may only contain a single type
    /// <summary>
    ///     The source latency vector 2d enum
    /// </summary>
    public enum SourceLatencyVector2d
#pragma warning restore SA1402 // File may only contain a single type
    {
        /// <summary>
        ///     The playback position, along with the playback latency, both
        ///     expressed in seconds. This attribute is read-only.
        ///     AL_SEC_OFFSET_LATENCY_SOFT
        /// </summary>
        SecOffsetLatency = 0x1201
    }
}