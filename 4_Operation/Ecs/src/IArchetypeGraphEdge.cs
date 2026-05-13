// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IArchetypeGraphEdge.cs
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

using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     Defines an interface for modifying component lists during archetype graph traversal.
    /// </summary>
    /// <remarks>
    ///     This internal interface is used by the archetype graph to add or remove components
    ///     when entities are created with or without specific component types. Implementations
    ///     represent edges in the archetype graph that connect archetypes differing by one component.
    /// </remarks>
    internal interface IArchetypeGraphEdge
    {
        /// <summary>
        ///     Modifies the component list by either adding or removing a component type.
        /// </summary>
        /// <param name="components">A reference to the list of component IDs that will be modified in place.</param>
        /// <param name="add">
        ///     <see langword="true"/> to add the component represented by this edge;
        ///     <see langword="false"/> to remove it.
        /// </param>
        void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add);
    }
}