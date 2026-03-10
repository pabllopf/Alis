// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeDeferredUpdateRecord.cs
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
using Alis.Core.Ecs.Kernel.Archetypes;

namespace Alis.Core.Ecs.Updating
{
    /// <summary>
    ///     Archetype deferred update record
    /// </summary>
    /// <param name="Archetype">The archetype</param>
    /// <param name="TemporaryBuffers">The temporary buffers</param>
    /// <param name="InitEntityCount">The initial entity count</param>
    /// <remarks>
    ///     Memory layout optimized: 20 bytes total (two Archetype references 16 bytes + int 4 bytes)
    ///     Pack = 8 for optimal alignment with reference types
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public record struct ArchetypeDeferredUpdateRecord(
        Archetype Archetype,
        Archetype TemporaryBuffers,
        int InitEntityCount);
}