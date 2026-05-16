// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Haptic.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The haptic enum
    /// </summary>
    public enum Haptic : byte
    {
    /// <summary>
    ///     Haptic direction is specified in polar coordinates (angle and distance)
    /// </summary>
    HapticPolar = 0,

    /// <summary>
    ///     Haptic direction is specified in Cartesian coordinates (x, y)
    /// </summary>
    HapticCartesian = 1,

    /// <summary>
    ///     Haptic direction is specified in spherical coordinates (azimuth, elevation)
    /// </summary>
    HapticSpherical = 2,

    /// <summary>
    ///     Haptic effect is applied to a steering axis input
    /// </summary>
    HapticSteeringAxis = 3
    }
}