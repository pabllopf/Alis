// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:HapticConstant.cs
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

namespace Alis.Core.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The haptic constant enum
    /// </summary>
    public enum HapticConstant : ushort
    {
        /// <summary>
        ///     The sdl haptic constant
        /// </summary>
        HapticConstant = 1 << 0,

        /// <summary>
        ///     The sdl haptic sine
        /// </summary>
        HapticSine = 1 << 1,

        /// <summary>
        ///     The sdl haptic left right
        /// </summary>
        HapticLeftRight = 1 << 2,

        /// <summary>
        ///     The sdl haptic triangle
        /// </summary>
        HapticTriangle = 1 << 3,

        /// <summary>
        ///     The sdl haptic saw tooth up
        /// </summary>
        HapticSawToothUp = 1 << 4,

        /// <summary>
        ///     The sdl haptic saw tooth down
        /// </summary>
        HapticSawToothDown = 1 << 5,

        /// <summary>
        ///     The sdl haptic spring
        /// </summary>
        HapticSpring = 1 << 7,

        /// <summary>
        ///     The sdl haptic damper
        /// </summary>
        HapticDamper = 1 << 8,

        /// <summary>
        ///     The sdl haptic inertia
        /// </summary>
        HapticInertia = 1 << 9,

        /// <summary>
        ///     The sdl haptic friction
        /// </summary>
        HapticFriction = 1 << 10,

        /// <summary>
        ///     The sdl haptic custom
        /// </summary>
        HapticCustom = 1 << 11,

        /// <summary>
        ///     The sdl haptic gain
        /// </summary>
        HapticGain = 1 << 12,

        /// <summary>
        ///     The sdl haptic auto center
        /// </summary>
        HapticAutoCenter = 1 << 13,

        /// <summary>
        ///     The sdl haptic status
        /// </summary>
        HapticStatus = 1 << 14,

        /// <summary>
        ///     The sdl haptic pause
        /// </summary>
        HapticPauseVar = 1 << 15
    }
}