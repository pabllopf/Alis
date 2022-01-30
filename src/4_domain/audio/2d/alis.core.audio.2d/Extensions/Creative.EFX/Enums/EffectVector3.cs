// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   EffectVector3.cs
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
    ///     A list of valid Math.Vector3 Effect/GetEffect parameters.
    /// </summary>
    public enum EffectVector3
    {
        /// <summary>
        ///     Reverb Pan does for the Reverb what Reflections Pan does for the Reflections. Unit: Vector3 of length 0f to 1f
        ///     Default: {0.0f, 0.0f, 0.0f}
        /// </summary>
        EaxReverbLateReverbPan = 0x000E,

        /// <summary>
        ///     This Vector3 controls the spatial distribution of the cluster of early reflections. The direction of this
        ///     vector controls the global direction of the reflections, while its magnitude controls how focused the reflections
        ///     are towards this direction. For legacy reasons this Vector3 follows a left-handed co-ordinate system! Note that
        ///     OpenAL uses a right-handed coordinate system. Unit: Vector3 of length 0f to 1f Default: {0.0f, 0.0f, 0.0f}
        /// </summary>
        EaxReverbReflectionsPan = 0x000B
    }
}