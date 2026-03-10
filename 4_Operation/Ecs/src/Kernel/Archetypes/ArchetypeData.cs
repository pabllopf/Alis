// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeData.cs
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
using Alis.Core.Aspect.Math.Collections;

namespace Alis.Core.Ecs.Kernel.Archetypes
{
    /// <summary>
    ///     Archetype metadata
    /// </summary>
    /// <param name="Id">The archetype ID</param>
    /// <param name="ComponentTypes">The component types in this archetype</param>
    /// <remarks>
    ///     Memory layout optimized: GameObjectType (2 bytes) + FastImmutableArray struct (variable size, contains reference)
    ///     Pack = 4 for balanced alignment with mixed types
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public record struct ArchetypeData(GameObjectType Id, FastImmutableArray<ComponentId> ComponentTypes);
}