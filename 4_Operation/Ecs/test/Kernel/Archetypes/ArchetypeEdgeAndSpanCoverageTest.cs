// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeEdgeAndSpanCoverageTest.cs
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

using System;
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Archetypes
{
    /// <summary>
    ///     Tests targeting the remaining uncovered paths of Archetype.cs:
    ///     GetComponentSpan missing-component throw, Update with range on empty archetype,
    ///     and GetAdjacentArchetypeLookup cached and cold resolution paths.
    /// </summary>
    public class ArchetypeEdgeAndSpanCoverageTest
    {
        /// <summary>
        ///     Tests that GetComponentSpan throws when the archetype does not contain the requested component.
        ///     Covers the index == 0 throw branch.
        /// </summary>
        [Fact] public void Archetype_GetComponentSpan_WhenComponentNotPresent_ThrowsComponentNotFoundException()
        {
            using Scene scene = new Scene();
            scene.Create(new Position());

            Archetype archetype = Archetype<Position>.CreateNewOrGetExistingArchetypes(scene).Archetype;

            ComponentNotFoundException ex = Assert.Throws<ComponentNotFoundException>(() => archetype.GetComponentSpan<Velocity>());
            Assert.Contains("Component not found", ex.Message);
        }

        /// <summary>
        ///     Tests that GetComponentSpan returns a span with length equal to the entity count.
        /// </summary>
        [Fact] public void Archetype_GetComponentSpan_WhenComponentPresent_ReturnsSpanOfEntityCount()
        {
            using Scene scene = new Scene();
            scene.Create(new Position());
            scene.Create(new Position());

            Archetype archetype = Archetype<Position>.CreateNewOrGetExistingArchetypes(scene).Archetype;

            Span<Position> span = archetype.GetComponentSpan<Position>();

            Assert.Equal(archetype.EntityCount, span.Length);
            Assert.Equal(2, span.Length);
        }

        /// <summary>
        ///     Tests that GetComponentSpan throws on the empty default archetype for any component type.
        ///     Covers the throw branch on the null archetype.
        /// </summary>
        [Fact] public void Archetype_GetComponentSpan_OnEmptyDefaultArchetype_ThrowsComponentNotFoundException()
        {
            using Scene scene = new Scene();
            scene.Create();

            Archetype archetype = scene.DefaultArchetype;

            Assert.Throws<ComponentNotFoundException>(() => archetype.GetComponentSpan<Position>());
        }

        /// <summary>
        ///     Tests that Update with a range returns early when the archetype has no entities.
        ///     Covers the NextComponentIndex == 0 guard of the range overload.
        /// </summary>
        [Fact] public void Archetype_Update_WithRange_OnEmptyArchetype_ReturnsEarly()
        {
            using Scene scene = new Scene();

            Archetype archetype = scene.DefaultArchetype;
            Assert.Equal(0, archetype.EntityCount);

            archetype.Update(scene, 0, 0);

            Assert.Equal(0, archetype.EntityCount);
        }

        /// <summary>
        ///     Tests that Update with a range runs the component storages of a non-empty archetype.
        /// </summary>
        [Fact] public void Archetype_Update_WithRange_OnNonEmptyArchetype_RunsComponentStorages()
        {
            using Scene scene = new Scene();
            scene.Create(new Position());

            Archetype archetype = Archetype<Position>.CreateNewOrGetExistingArchetypes(scene).Archetype;

            archetype.Update(scene, 0, archetype.EntityCount);

            Assert.Equal(1, archetype.EntityCount);
        }

        /// <summary>
        ///     Tests that GetAdjacentArchetypeLookup returns the cached archetype when the edge is present.
        ///     Covers the TryGetValue success branch.
        /// </summary>
        [Fact] public void Archetype_GetAdjacentArchetypeLookup_WhenEdgeCached_ReturnsCachedArchetype()
        {
            using Scene scene = new Scene();

            Archetype from = Archetype<Position>.CreateNewOrGetExistingArchetypes(scene).Archetype;
            Archetype expected = Archetype<Position, Velocity>.CreateNewOrGetExistingArchetypes(scene).Archetype;
            ArchetypeEdgeKey edge = ArchetypeEdgeKey.Component(Component<Velocity>.Id, from.Id, ArchetypeEdgeType.AddComponent);
            scene.ArchetypeGraphEdges[edge] = expected;

            Archetype result = Archetype.GetAdjacentArchetypeLookup(scene, edge);

            Assert.Same(expected, result);
        }

        /// <summary>
        ///     Tests that GetAdjacentArchetypeLookup resolves through the cold path when the edge is missing.
        ///     Covers the AddComponent cold resolution branch.
        /// </summary>
        [Fact] public void Archetype_GetAdjacentArchetypeLookup_WhenEdgeMissing_ResolvesColdPath()
        {
            using Scene scene = new Scene();

            Archetype from = Archetype<Position>.CreateNewOrGetExistingArchetypes(scene).Archetype;
            ArchetypeEdgeKey edge = ArchetypeEdgeKey.Component(Component<Velocity>.Id, from.Id, ArchetypeEdgeType.AddComponent);

            Archetype result = Archetype.GetAdjacentArchetypeLookup(scene, edge);

            Assert.True(result.GetComponentIndex(Component<Position>.Id) > 0);
            Assert.True(result.GetComponentIndex(Component<Velocity>.Id) > 0);
        }

        /// <summary>
        ///     Tests that GetAdjacentArchetypeLookup resolves through the cold path for a remove component edge.
        ///     Covers the RemoveComponent cold resolution branch.
        /// </summary>
        [Fact] public void Archetype_GetAdjacentArchetypeLookup_WithRemoveComponentEdge_ResolvesColdPath()
        {
            using Scene scene = new Scene();

            Archetype from = Archetype<Position, Velocity>.CreateNewOrGetExistingArchetypes(scene).Archetype;
            ArchetypeEdgeKey edge = ArchetypeEdgeKey.Component(Component<Velocity>.Id, from.Id, ArchetypeEdgeType.RemoveComponent);

            Archetype result = Archetype.GetAdjacentArchetypeLookup(scene, edge);

            Assert.True(result.GetComponentIndex(Component<Position>.Id) > 0);
            Assert.Equal(0, result.GetComponentIndex(Component<Velocity>.Id));
        }

        /// <summary>
        ///     Tests that the generic Archetype T create or get existing archetype with a span
        ///     creates and registers the archetype when it does not exist yet.
        /// </summary>
        [Fact] public void Archetype_T_CreateOrGetExistingArchetype_WithSpan_WhenMissing_CreatesAndRegisters()
        {
            using Scene scene = new Scene();

            ReadOnlySpan<ComponentId> types = new[] { Component<Position>.Id };

            Archetype result = Archetype<Position>.CreateOrGetExistingArchetype(types, scene);

            Assert.True(result.GetComponentIndex(Component<Position>.Id) > 0);
            Assert.Equal(0, result.GetComponentIndex(Component<Velocity>.Id));
        }

        /// <summary>
        ///     Tests that the generic Archetype T create or get existing archetype with a span
        ///     returns the existing archetype on a cache hit.
        /// </summary>
        [Fact] public void Archetype_T_CreateOrGetExistingArchetype_WithSpan_WhenExisting_ReturnsSameArchetype()
        {
            using Scene scene = new Scene();

            ReadOnlySpan<ComponentId> types = new[] { Component<Position>.Id };

            Archetype first = Archetype<Position>.CreateOrGetExistingArchetype(types, scene);
            Archetype second = Archetype<Position>.CreateOrGetExistingArchetype(types, scene);

            Assert.Same(first, second);
        }

        /// <summary>
        ///     Tests that the generic Archetype T create or get existing archetype with an id returns the archetype.
        /// </summary>
        [Fact] public void Archetype_T_CreateOrGetExistingArchetype_WithId_ReturnsArchetype()
        {
            using Scene scene = new Scene();

            GameObjectType id = Archetype<Position>.Id;

            Archetype result = Archetype<Position>.CreateOrGetExistingArchetype(id, scene);

            Assert.True(result.GetComponentIndex(Component<Position>.Id) > 0);
        }

        /// <summary>
        ///     Tests that the generic Archetype T get adjacent archetype lookup returns the cached archetype.
        /// </summary>
        [Fact] public void Archetype_T_GetAdjacentArchetypeLookup_WhenEdgeCached_ReturnsCachedArchetype()
        {
            using Scene scene = new Scene();

            Archetype from = Archetype<Position>.CreateNewOrGetExistingArchetypes(scene).Archetype;
            Archetype expected = Archetype<Position, Velocity>.CreateNewOrGetExistingArchetypes(scene).Archetype;
            ArchetypeEdgeKey edge = ArchetypeEdgeKey.Component(Component<Velocity>.Id, from.Id, ArchetypeEdgeType.AddComponent);
            scene.ArchetypeGraphEdges[edge] = expected;

            Archetype result = Archetype<Position>.GetAdjacentArchetypeLookup(scene, edge);

            Assert.Same(expected, result);
        }

        /// <summary>
        ///     Tests that the generic Archetype T get adjacent archetype lookup resolves through the cold path.
        /// </summary>
        [Fact] public void Archetype_T_GetAdjacentArchetypeLookup_WhenEdgeMissing_ResolvesColdPath()
        {
            using Scene scene = new Scene();

            Archetype from = Archetype<Position>.CreateNewOrGetExistingArchetypes(scene).Archetype;
            ArchetypeEdgeKey edge = ArchetypeEdgeKey.Component(Component<Velocity>.Id, from.Id, ArchetypeEdgeType.AddComponent);

            Archetype result = Archetype<Position>.GetAdjacentArchetypeLookup(scene, edge);

            Assert.True(result.GetComponentIndex(Component<Position>.Id) > 0);
            Assert.True(result.GetComponentIndex(Component<Velocity>.Id) > 0);
        }

        /// <summary>
        ///     Tests that the generic Archetype T get adjacent archetype cold handles the add component edge type.
        /// </summary>
        [Fact] public void Archetype_T_GetAdjacentArchetypeCold_WithAddComponentEdge_CreatesArchetype()
        {
            using Scene scene = new Scene();

            Archetype from = Archetype<Position>.CreateNewOrGetExistingArchetypes(scene).Archetype;
            ArchetypeEdgeKey edge = ArchetypeEdgeKey.Component(Component<Velocity>.Id, from.Id, ArchetypeEdgeType.AddComponent);

            Archetype result = Archetype<Position>.GetAdjacentArchetypeCold(scene, edge);

            Assert.True(result.GetComponentIndex(Component<Position>.Id) > 0);
            Assert.True(result.GetComponentIndex(Component<Velocity>.Id) > 0);
        }

        /// <summary>
        ///     Tests that the generic Archetype T get adjacent archetype cold handles the remove component edge type.
        /// </summary>
        [Fact] public void Archetype_T_GetAdjacentArchetypeCold_WithRemoveComponentEdge_CreatesArchetype()
        {
            using Scene scene = new Scene();

            Archetype from = Archetype<Position, Velocity>.CreateNewOrGetExistingArchetypes(scene).Archetype;
            ArchetypeEdgeKey edge = ArchetypeEdgeKey.Component(Component<Velocity>.Id, from.Id, ArchetypeEdgeType.RemoveComponent);

            Archetype result = Archetype<Position>.GetAdjacentArchetypeCold(scene, edge);

            Assert.True(result.GetComponentIndex(Component<Position>.Id) > 0);
            Assert.Equal(0, result.GetComponentIndex(Component<Velocity>.Id));
        }

        /// <summary>
        ///     Tests that the generic Archetype T get adjacent archetype cold keeps the component set for a tag edge type.
        ///     Covers the default branch of the edge type switch.
        /// </summary>
        [Fact] public void Archetype_T_GetAdjacentArchetypeCold_WithAddTagEdge_KeepsComponentSet()
        {
            using Scene scene = new Scene();

            Archetype from = Archetype<Position>.CreateNewOrGetExistingArchetypes(scene).Archetype;
            ArchetypeEdgeKey edge = ArchetypeEdgeKey.Component(Component<Velocity>.Id, from.Id, ArchetypeEdgeType.AddTag);

            Archetype result = Archetype<Position>.GetAdjacentArchetypeCold(scene, edge);

            Assert.True(result.GetComponentIndex(Component<Position>.Id) > 0);
            Assert.Equal(0, result.GetComponentIndex(Component<Velocity>.Id));
        }
    }
}
