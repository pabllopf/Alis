// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlHapticCondition.cs
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

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl hapticcondition
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlHapticCondition
    {
        // Header
        /// <summary>
        ///     The type
        /// </summary>
        public ushort type;

        /// <summary>
        ///     The direction
        /// </summary>
        public SdlHapticDirection direction;

        // Replay
        /// <summary>
        ///     The length
        /// </summary>
        public uint length;

        /// <summary>
        ///     The delay
        /// </summary>
        public ushort delay;

        // Trigger
        /// <summary>
        ///     The button
        /// </summary>
        public ushort button;

        /// <summary>
        ///     The interval
        /// </summary>
        public ushort interval;

        // Condition
        /// <summary>
        ///     The right sat
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 3)]
        public ushort[] right_sat;

        /// <summary>
        ///     The left sat
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 3)]
        public ushort[] left_sat;

        /// <summary>
        ///     The right coeff
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 3)]
        public short[] right_coeff;

        /// <summary>
        ///     The left coeff
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 3)]
        public short[] left_coeff;

        /// <summary>
        ///     The deadband
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 3)]
        public ushort[] deadband;

        /// <summary>
        ///     The center
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 3)]
        public short[] center;
    }
}