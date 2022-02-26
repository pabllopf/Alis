// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   EFXSourceInteger3.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

namespace Alis.Core.Audio.Extensions.Creative.EFX.Enums
{
    /// <summary>
    ///     A list of valid <see cref="int" /> Source/GetSource parameters.
    /// </summary>
    public enum EFXSourceInteger3
    {
        /// <summary>
        ///     This Source property is used to establish connections between Sources and Auxiliary Effect
        ///     Slots. For a Source to feed an Effect that has been loaded into an Auxiliary Effect Slot the application must
        ///     configure one of the Source’s auxiliary sends. This process involves setting 3 variables – the destination
        ///     Auxiliary Effect Slot ID, the Auxiliary Send number, and an optional Filter ID.
        /// </summary>
        AuxiliarySendFilter = 0x20006
    }
}