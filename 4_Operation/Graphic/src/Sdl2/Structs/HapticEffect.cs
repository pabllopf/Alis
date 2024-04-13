// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:HapticEffect.cs
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

using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl haptic effect
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct HapticEffect
    {
        /// <summary>
        ///     The type
        /// </summary>
        [FieldOffset(0)] public readonly ushort type;
        
        /// <summary>
        ///     The constant
        /// </summary>
        [FieldOffset(0)] public HapticConstant constant;
        
        /// <summary>
        ///     The periodic
        /// </summary>
        [FieldOffset(0)] public HapticPeriodic periodic;
        
        /// <summary>
        ///     The condition
        /// </summary>
        [FieldOffset(0)] public HapticCondition condition;
        
        /// <summary>
        ///     The ramp
        /// </summary>
        [FieldOffset(0)] public HapticRamp ramp;
        
        /// <summary>
        ///     The left right
        /// </summary>
        [FieldOffset(0)] public HapticLeftRight leftRight;
        
        /// <summary>
        ///     The custom
        /// </summary>
        [FieldOffset(0)] public HapticCustom custom;
    }
}