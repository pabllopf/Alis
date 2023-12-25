// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: SdlInputConst.cs
// 
//  Author: Pablo Perdomo Falcón
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

namespace Alis.Core.Aspect.Base.Mapping
{
    /// <summary>
    ///     The sdl input const class
    /// </summary>
    public class SdlInputConst
    {
        /// <summary>
        ///     The sdl scancode mask
        /// </summary>
        public const int KScancodeMask = 1 << 30;

        /// <summary>
        ///     The sdl button left
        /// </summary>
        public const uint ButtonLeft = 1;

        /// <summary>
        ///     The sdl button middle
        /// </summary>
        public const uint ButtonMiddle = 2;

        /// <summary>
        ///     The sdl button right
        /// </summary>
        public const uint ButtonRight = 3;

        /// <summary>
        ///     The sdl button x1
        /// </summary>
        private const uint ButtonX1 = 4;

        /// <summary>
        ///     The sdl button x2
        /// </summary>
        private const uint ButtonX2 = 5;

        /// <summary>
        ///     The max value
        /// </summary>
        public const uint TouchMouseId = uint.MaxValue;

        /// <summary>
        ///     The sdl hat centered
        /// </summary>
        public const byte HatCentered = 0x00;

        /// <summary>
        ///     The sdl hat up
        /// </summary>
        private const byte HatUp = 0x01;

        /// <summary>
        ///     The sdl hat right
        /// </summary>
        private const byte HatRight = 0x02;

        /// <summary>
        ///     The sdl hat down
        /// </summary>
        private const byte HatDown = 0x04;

        /// <summary>
        ///     The sdl hat left
        /// </summary>
        private const byte HatLeft = 0x08;

        /// <summary>
        ///     The sdl hat up
        /// </summary>
        public const byte HatRightUp = HatRight | HatUp;

        /// <summary>
        ///     The sdl hat down
        /// </summary>
        public const byte HatRightDown = HatRight | HatDown;

        /// <summary>
        ///     The sdl hat up
        /// </summary>
        public const byte HatLeftUp = HatLeft | HatUp;

        /// <summary>
        ///     The sdl hat down
        /// </summary>
        public const byte HatLeftDown = HatLeft | HatDown;


        /// <summary>
        ///     The sdl iphone max g force
        /// </summary>
        public const float IphoneMaxGForce = 5.0f;

        /// <summary>
        ///     The sdl haptic constant
        /// </summary>
        public const ushort HapticConstant = 1 << 0;

        /// <summary>
        ///     The sdl haptic sine
        /// </summary>
        public const ushort HapticSine = 1 << 1;

        /// <summary>
        ///     The sdl haptic left right
        /// </summary>
        public const ushort HapticLeftRight = 1 << 2;

        /// <summary>
        ///     The sdl haptic triangle
        /// </summary>
        public const ushort HapticTriangle = 1 << 3;

        /// <summary>
        ///     The sdl haptic saw tooth up
        /// </summary>
        public const ushort HapticSawToothUp = 1 << 4;

        /// <summary>
        ///     The sdl haptic saw tooth down
        /// </summary>
        public const ushort HapticSawToothDown = 1 << 5;

        /// <summary>
        ///     The sdl haptic spring
        /// </summary>
        public const ushort HapticSpring = 1 << 7;

        /// <summary>
        ///     The sdl haptic damper
        /// </summary>
        public const ushort HapticDamper = 1 << 8;

        /// <summary>
        ///     The sdl haptic inertia
        /// </summary>
        public const ushort HapticInertia = 1 << 9;

        /// <summary>
        ///     The sdl haptic friction
        /// </summary>
        public const ushort HapticFriction = 1 << 10;

        /// <summary>
        ///     The sdl haptic custom
        /// </summary>
        public const ushort HapticCustom = 1 << 11;

        /// <summary>
        ///     The sdl haptic gain
        /// </summary>
        public const ushort HapticGain = 1 << 12;

        /// <summary>
        ///     The sdl haptic auto center
        /// </summary>
        public const ushort HapticAutoCenter = 1 << 13;

        /// <summary>
        ///     The sdl haptic status
        /// </summary>
        public const ushort HapticStatus = 1 << 14;

        /// <summary>
        ///     The sdl haptic pause
        /// </summary>
        public const ushort HapticPauseVar = 1 << 15;

        /// <summary>
        ///     The sdl haptic polar
        /// </summary>
        public const byte HapticPolar = 0;

        /// <summary>
        ///     The sdl haptic cartesian
        /// </summary>
        public const byte HapticCartesian = 1;

        /// <summary>
        ///     The sdl haptic spherical
        /// </summary>
        public const byte HapticSpherical = 2;

        /// <summary>
        ///     The sdl haptic steering axis
        /// </summary>
        public const byte HapticSteeringAxis = 3;
    }
}