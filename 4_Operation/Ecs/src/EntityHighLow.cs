// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityHighLow.cs
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

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     Represents an entity identifier split into high and low integer components.
    /// </summary>
    /// <remarks>
    ///     This struct is used internally for efficient entity ID storage and comparison.
    ///     Memory layout optimized: 8 bytes total (two ints, 4 bytes each).
    ///     Pack = 1 for minimal memory footprint, naturally aligned.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EntityHighLow
    {
        /// <summary>
        ///     The high part of the entity identifier, typically containing the entity index or ID.
        /// </summary>
        internal int EntityID;

        /// <summary>
        ///     The low part of the entity identifier, typically containing a version or secondary index.
        /// </summary>
        internal int EntityLow;
    }
}