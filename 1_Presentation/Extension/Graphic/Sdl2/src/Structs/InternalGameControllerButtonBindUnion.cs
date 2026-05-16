// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalGameControllerButtonBindUnion.cs
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
    ///     A union type used internally by SDL game controller bindings, overlaying button, axis, and hat fields at the same memory offset.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct InternalGameControllerButtonBindUnion
    {
        /// <summary>
        ///     The button index, valid when the bind type is button.
        /// </summary>
        [FieldOffset(0)] public readonly int button;

        /// <summary>
        ///     The axis index, valid when the bind type is axis.
        /// </summary>
        [FieldOffset(0)] public readonly int axis;

        /// <summary>
        ///     The hat binding data, valid when the bind type is hat.
        /// </summary>
        [FieldOffset(0)] public InternalGameControllerButtonBindHat hat;
    }
}