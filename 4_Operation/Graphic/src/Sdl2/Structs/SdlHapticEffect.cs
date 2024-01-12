// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: SdlHapticEffect.cs
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

using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl hapticeffect
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct SdlHapticEffect
    {
        /// <summary>
        ///     The type
        /// </summary>
        [FieldOffset(0)] public readonly ushort type;

        /// <summary>
        ///     The constant
        /// </summary>
        [FieldOffset(0)] public SdlHapticConstant constant;

        /// <summary>
        ///     The periodic
        /// </summary>
        [FieldOffset(0)] public SdlHapticPeriodic periodic;

        /// <summary>
        ///     The condition
        /// </summary>
        [FieldOffset(0)] public SdlHapticCondition condition;

        /// <summary>
        ///     The ramp
        /// </summary>
        [FieldOffset(0)] public SdlHapticRamp ramp;

        /// <summary>
        ///     The leftright
        /// </summary>
        [FieldOffset(0)] public SdlHapticLeftRight leftright;

        /// <summary>
        ///     The custom
        /// </summary>
        [FieldOffset(0)] public SdlHapticCustom custom;
    }
}