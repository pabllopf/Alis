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

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The haptic constant enum
    /// </summary>
    public enum HapticConstant : ushort
    {
    /// <summary>
    ///     Constant force feedback effect (steady force in a fixed direction)
    /// </summary>
    HapticConstant = 1 << 0,

    /// <summary>
    ///     Sine wave force feedback effect (oscillating force)
    /// </summary>
    HapticSine = 1 << 1,

    /// <summary>
    ///     Left-right (periodic) force feedback effect for gamepads
    /// </summary>
    HapticLeftRight = 1 << 2,

    /// <summary>
    ///     Triangle wave force feedback effect
    /// </summary>
    HapticTriangle = 1 << 3,

    /// <summary>
    ///     Sawtooth-up wave force feedback effect (ramping up)
    /// </summary>
    HapticSawToothUp = 1 << 4,

    /// <summary>
    ///     Sawtooth-down wave force feedback effect (ramping down)
    /// </summary>
    HapticSawToothDown = 1 << 5,

    /// <summary>
    ///     Spring effect that simulates resistance proportional to displacement
    /// </summary>
    HapticSpring = 1 << 7,

    /// <summary>
    ///     Damper effect that simulates resistance proportional to velocity
    /// </summary>
    HapticDamper = 1 << 8,

    /// <summary>
    ///     Inertia effect that simulates resistance to acceleration
    /// </summary>
    HapticInertia = 1 << 9,

    /// <summary>
    ///     Friction effect that simulates resistance to movement
    /// </summary>
    HapticFriction = 1 << 10,

    /// <summary>
    ///     Custom force feedback effect defined by user data
    /// </summary>
    HapticCustom = 1 << 11,

    /// <summary>
    ///     Ability to adjust the global gain of the haptic device
    /// </summary>
    HapticGain = 1 << 12,

    /// <summary>
    ///     Ability to enable automatic centering of the haptic device
    /// </summary>
    HapticAutoCenter = 1 << 13,

    /// <summary>
    ///     Ability to query the status of a haptic effect
    /// </summary>
    HapticStatus = 1 << 14,

    /// <summary>
    ///     Ability to pause and resume haptic effects
    /// </summary>
    HapticPauseVar = 1 << 15
    }
}