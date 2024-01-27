// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: SdlHapticCustom.cs
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

using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl haptic custom
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlHapticCustom
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

        // Custom
        /// <summary>
        ///     The channels
        /// </summary>
        public readonly byte channels;

        /// <summary>
        ///     The period
        /// </summary>
        public readonly ushort period;

        /// <summary>
        ///     The samples
        /// </summary>
        public readonly ushort samples;

        /// <summary>
        ///     The data
        /// </summary>
        public IntPtr data;

        // Envelope
        /// <summary>
        ///     The attack length
        /// </summary>
        public readonly ushort attackLength;

        /// <summary>
        ///     The attack level
        /// </summary>
        public readonly ushort attackLevel;

        /// <summary>
        ///     The fade length
        /// </summary>
        public readonly ushort fadeLength;

        /// <summary>
        ///     The fade level
        /// </summary>
        public readonly ushort fadeLevel;
    }
}