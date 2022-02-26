// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   EFXSourceFloat.cs
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

namespace Alis.Core.Audio.Extensions.Creative.EFX.Enums
{
    /// <summary>
    ///     A list of valid <see cref="float" /> Source/GetSource parameters.
    /// </summary>
    public enum EFXSourceFloat
    {
        /// <summary>
        ///     Range [0.0f .. 10.0f]
        ///     Default: 0.0f
        ///     This property is a multiplier on the amount of Air Absorption applied to the Source. The
        ///     AL_AIR_ABSORPTION_FACTOR is multiplied by an internal Air Absorption Gain HF value of 0.994 (-0.05dB) per meter
        ///     which represents normal atmospheric humidity and temperature.
        /// </summary>
        AirAbsorptionFactor = 0x20007,

        /// <summary>
        ///     Range [0.0f .. 10.0f]
        ///     Default: 0.0f
        ///     This property is defined the same way as the Reverb Room Rolloff property: it is one of two
        ///     methods available in the Effect Extension to attenuate the reflected sound (early reflections and reverberation)
        ///     according to source-listener distance.
        /// </summary>
        RoomRolloffFactor = 0x20008,

        /// <summary>
        ///     Range [0.0f .. 1.0f]
        ///     Default: 1.0f
        ///     A directed Source points in a specified direction. The Source sounds at full volume when the
        ///     listener is directly in front of the source; it is attenuated as the listener circles the Source away from the
        ///     front.
        /// </summary>
        ConeOuterGainHighFrequency = 0x20009
    }
}