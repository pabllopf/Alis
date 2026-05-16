// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:HapticDirection.cs
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

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     Represents an SDL haptic direction, specifying the direction of a haptic effect using Cartesian or polar/spherical coordinates.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct HapticDirection
    {
        /// <summary>
        ///     The direction type, specifying the coordinate system (e.g. SDL_HAPTIC_POLAR, SDL_HAPTIC_CARTESIAN, SDL_HAPTIC_SPHERICAL).
        /// </summary>
        public readonly byte type;

        /// <summary>
        ///     The direction vector values (3 elements), interpreted according to the direction type.
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 3)]
        public readonly int[] dir;
    }
}