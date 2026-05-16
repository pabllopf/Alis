// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalSdlGameControllerButtonBind.cs
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
    ///     Internal SDL representation of a game controller button binding, storing the bind type and union data as raw integers.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct InternalSdlGameControllerButtonBind
    {
        /// <summary>
        ///     The binding type, indicating how the button is mapped.
        /// </summary>
        public readonly int bindType;

        /// <summary>
        ///     The first component of the union data (button, axis, or hat index).
        /// </summary>
        public readonly int unionVal0;

        /// <summary>
        ///     The second component of the union data (hat mask when bind type is hat).
        /// </summary>
        public readonly int unionVal1;
    }
}