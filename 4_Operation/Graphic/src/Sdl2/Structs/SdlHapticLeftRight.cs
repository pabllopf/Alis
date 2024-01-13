// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: SdlHapticLeftRight.cs
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
    ///     The sdl haptic left right
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlHapticLeftRight
    {
        // Header
        /// <summary>
        ///     The type
        /// </summary>
        public readonly ushort type;

        // Replay
        /// <summary>
        ///     The length
        /// </summary>
        public readonly uint length;

        // Rumble
        /// <summary>
        ///     The large magnitude
        /// </summary>
        public readonly ushort large_magnitude;

        /// <summary>
        ///     The small magnitude
        /// </summary>
        public readonly ushort small_magnitude;
    }
}