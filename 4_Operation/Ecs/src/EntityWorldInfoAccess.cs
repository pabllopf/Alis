// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityWorldInfoAccess.cs
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
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The gameObject scene info access
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: 8 bytes total (GameObjectIdOnly 6 bytes + ushort 2 bytes)
    ///     Pack = 1 for minimal memory footprint
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EntityWorldInfoAccess
    {
        /// <summary>
        ///     The gameObject id only
        /// </summary>
        internal GameObjectIdOnly EntityIDOnly;

        /// <summary>
        ///     The scene id
        /// </summary>
        internal ushort WorldID;
    }
}