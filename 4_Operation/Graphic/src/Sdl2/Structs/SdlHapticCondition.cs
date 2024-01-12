// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: SdlHapticCondition.cs
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
    ///     The sdl haptic condition
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlHapticCondition
    {
        // Header
        /// <summary>
        ///     The type
        /// </summary>
        public readonly ushort type;

        /// <summary>
        ///     The direction
        /// </summary>
        public SdlHapticDirection direction;

        // Replay
        /// <summary>
        ///     The length
        /// </summary>
        public readonly uint length;

        /// <summary>
        ///     The delay
        /// </summary>
        public readonly ushort delay;

        // Trigger
        /// <summary>
        ///     The button
        /// </summary>
        public readonly ushort button;

        /// <summary>
        ///     The interval
        /// </summary>
        public readonly ushort interval;

        // Condition
        /// <summary>
        ///     The right sat
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 3)]
        public readonly ushort[] right_sat;

        /// <summary>
        ///     The left sat
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 3)]
        public readonly ushort[] left_sat;

        /// <summary>
        ///     The right Coefficient
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 3)]
        public readonly short[] rightCoefficient;

        /// <summary>
        ///     The left Coefficient
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 3)]
        public readonly short[] leftCoefficient;

        /// <summary>
        ///     The dead band
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 3)]
        public readonly ushort[] deadBand;

        /// <summary>
        ///     The center
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 3)]
        public readonly short[] center;
    }
}