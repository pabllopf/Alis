// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeRemainingCoverage.cs
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
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Archetypes
{
    /// <summary>
    ///     The archetype remaining coverage class
    /// </summary>
    /// <remarks>
    ///     Targets uncovered SonarCloud paths in Archetype.cs: GetComponentSpan and GetComponentDataReference
    ///     error/happy paths, CreateEntityLocations new and recycled id branches, Update(scene, start, length)
    ///     empty and non-empty branches, non generic and generic GetAdjacentArchetypeLookup cache hit and cold
    ///     paths, and the generic Archetype<T>.CreateOrGetExistingArchetype overloads.
    /// </remarks>
    public class ArchetypeRemainingCoverage
    {
        /// <summary>
        ///     Tests that GetComponentSpan throws when the component is not present in the archetype.
        /// </summary>
        [Fact]
        public void Archetype_GetComponentSpan_MissingComponent_ThrowsComponentNotFound()
        {
            using Scene scene = new Scene();
            Archetype archetype = Archetype<Position>.CreateNewOrGetExistingArchetypes(scene).Archetype;

            ComponentNotFoundException ex = Assert.Throws<ComponentNotFoundException>(() =>
                archetype.GetComponentSpan<Velocity>());

            Assert.NotNull(ex);
        }

        /// <summary>
        ///     Tests that GetComponentDataReference returns a reference to the first entity component storage slot.
        /// </summary>
        [Fact]
        public void Archetype_GetComponentDataReference_ReturnsComponentRef()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 10, Y = 20 });
            Archetype archetype = Archetype<Position>.CreateNewOrGetExistingArchetypes(scene).Archetype;

            ref Position pos = ref archetype.GetComponentDataReference<Position>();

            Assert.Equal(10, pos.X);
            Assert.Equal(20, pos.Y);

            pos.X = 99;
            Assert.Equal(99, pos.X);
        }

        /// <summary>
        ///     Tests that GetComponentDataReference throws when the component is not present in the archetype.
        /// </summary>
        [Fact]
        public void Archetype_GetComponentDataReference_MissingComponent_ThrowsComponentNotFound()
        {
            using Scene scene = new Scene();
            Archetype archetype = Archetype<Position>.CreateNewOrGetExistingArchetypes(scene).Archetype;

            ComponentNotFoundException ex = Assert.Throws<ComponentNotFoundException>(() =>
                archetype.GetComponentDataReference<Velocity>());

            Assert.NotNull(ex);
        }

        /// <summary>
        ///     Tests that CreateEntityLocations creates new entity ids when the recycled stack is empty.
        /// </summary>
        [Fact]
        public void Archetype_CreateEntityLocations_NewIds_AllocatesFreshEntities()
        {
            using Scene scene = new Scene();
            ChunkTuple<Position> tuple = scene.CreateMany<Position>(5);

            Assert.Equal(5, scene.EntityCount);
            Assert.Equal(5, tuple.Span.Length);

            tuple.Span[0].X = 42;
            tuple.Span[1].X = 84;
            Assert.Equal(42, tuple.Span[0].X);
            Assert.Equal(84, tuple.Span[1].X);
        }

        /// <summary>
        ///     Tests that CreateEntityLocations reuses recycled entity ids from the scene recycled stack.
        /// </summary>
        [Fact]
        public void Archetype_CreateEntityLocations_RecycledIds_AreReused()
        {
            using Scene scene = new Scene();
            GameObject e1 = scene.Create(new Position());
            GameObject e2 = scene.Create(new Position());
            e1.Delete();
            e2.Delete();

            Assert.Equal(0, scene.EntityCount);

            ChunkTuple<Position> tuple = scene.CreateMany<Position>(3);

            Assert.Equal(3, scene.EntityCount);
            Assert.Equal(3, tuple.Span.Length);
        }

        /// <summary>
        ///     Tests that Update with a range on an empty archetype returns early without throwing.
        /// </summary>
        [Fact]
        public void Archetype_Update_Range_EmptyArchetype_ReturnsEarly()
        {
            using Scene scene = new Scene();
            Archetype archetype = scene.DefaultArchetype;

            Assert.Equal(0, archetype.EntityCount);

            archetype.Update(scene, 0, 0);

            Assert.Equal(0, archetype.EntityCount);
        }

        /// <summary>
        ///     Tests that Update with a range processes entities after deferred creation resolution.
        /// </summary>
        [Fact]
        public void Archetype_Update_Range_NonEmptyArchetype_ProcessesEntities()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            scene.Create(new Position { X = 1, Y = 2 });
            scene.Create(new Position { X = 3, Y = 4 });
            scene.ExitDisallowState(null, true);

            Assert.Equal(2, scene.EntityCount);

            Archetype archetype = Archetype<Position>.CreateNewOrGetExistingArchetypes(scene).Archetype;
            Assert.Equal(2, archetype.EntityCount);
        }

        /// <summary>
        ///     Tests that GetAdjacentArchetypeLookup cold path creates a new archetype for an add component edge.
        /// </summary>
        [Fact]
        public void Archetype_GetAdjacentArchetypeLookup_ColdPath_AddsComponent()
        {
            using Scene scene = new Scene();
            ArchetypeEdgeKey edge = ArchetypeEdgeKey.Component(Component<Velocity>.Id, Archetype<Position>.Id,
                ArchetypeEdgeType.AddComponent);

            Archetype adjacent = Archetype.GetAdjacentArchetypeLookup(scene, edge);

            Assert.Equal(2, adjacent.ArchetypeTypeArray.Length);
            Assert.True(adjacent.GetComponentIndex<Velocity>() > 0);
        }

        /// <summary>
        ///     Tests that GetAdjacentArchetypeLookup returns the cached archetype on a graph edge hit.
        /// </summary>
        [Fact]
        public void Archetype_GetAdjacentArchetypeLookup_CacheHit_ReturnsCached()
        {
            using Scene scene = new Scene();
            ArchetypeEdgeKey edge = ArchetypeEdgeKey.Component(Component<Velocity>.Id, Archetype<Position>.Id,
                ArchetypeEdgeType.AddComponent);
            Archetype expected =
                Archetype.CreateOrGetExistingArchetype(new[] {Component<Position>.Id, Component<Velocity>.Id}.AsSpan(),
                    scene);
            scene.ArchetypeGraphEdges[edge] = expected;

            Archetype result = Archetype.GetAdjacentArchetypeLookup(scene, edge);

            Assert.Same(expected, result);
        }

        /// <summary>
        ///     Tests that the generic GetAdjacentArchetypeLookup cold path creates a new archetype for an add component edge.
        /// </summary>
        [Fact]
        public void Archetype_T_GetAdjacentArchetypeLookup_ColdPath_AddsComponent()
        {
            using Scene scene = new Scene();
            ArchetypeEdgeKey edge = ArchetypeEdgeKey.Component(Component<Velocity>.Id, Archetype<Position>.Id,
                ArchetypeEdgeType.AddComponent);

            Archetype adjacent = Archetype<Position>.GetAdjacentArchetypeLookup(scene, edge);

            Assert.Equal(2, adjacent.ArchetypeTypeArray.Length);
            Assert.True(adjacent.GetComponentIndex<Velocity>() > 0);
        }

        /// <summary>
        ///     Tests that the generic GetAdjacentArchetypeLookup returns the cached archetype on a graph edge hit.
        /// </summary>
        [Fact]
        public void Archetype_T_GetAdjacentArchetypeLookup_CacheHit_ReturnsCached()
        {
            using Scene scene = new Scene();
            ArchetypeEdgeKey edge = ArchetypeEdgeKey.Component(Component<Velocity>.Id, Archetype<Position>.Id,
                ArchetypeEdgeType.AddComponent);
            Archetype expected = Archetype<Position, Velocity>.CreateNewOrGetExistingArchetypes(scene).Archetype;
            scene.ArchetypeGraphEdges[edge] = expected;

            Archetype result = Archetype<Position>.GetAdjacentArchetypeLookup(scene, edge);

            Assert.Same(expected, result);
        }

        /// <summary>
        ///     Tests that the generic GetAdjacentArchetypeCold removes the component for a remove edge.
        /// </summary>
        [Fact]
        public void Archetype_T_GetAdjacentArchetypeCold_RemoveComponent()
        {
            using Scene scene = new Scene();
            ArchetypeEdgeKey edge = ArchetypeEdgeKey.Component(Component<Position>.Id,
                Archetype<Position, Velocity>.Id, ArchetypeEdgeType.RemoveComponent);

            Archetype adjacent = Archetype<Position>.GetAdjacentArchetypeCold(scene, edge);

            Assert.Equal(1, adjacent.ArchetypeTypeArray.Length);
            Assert.Equal(0, adjacent.GetComponentIndex<Position>());
            Assert.True(adjacent.GetComponentIndex<Velocity>() > 0);
        }

        /// <summary>
        ///     Tests that the generic CreateOrGetExistingArchetype creates a new archetype on cache miss.
        /// </summary>
        [Fact]
        public void Archetype_T_CreateOrGetExistingArchetype_ById_CacheMiss_Creates()
        {
            using Scene scene = new Scene();

            Archetype result = Archetype<Position>.CreateOrGetExistingArchetype(Archetype<Position>.Id, scene);

            Assert.NotNull(result);
            Assert.Equal(0, result.EntityCount);
            Assert.True(result.GetComponentIndex<Position>() > 0);
        }

        /// <summary>
        ///     Tests that the generic CreateOrGetExistingArchetype returns the existing archetype on cache hit.
        /// </summary>
        [Fact]
        public void Archetype_T_CreateOrGetExistingArchetype_ById_CacheHit_ReturnsExisting()
        {
            using Scene scene = new Scene();

            Archetype first = Archetype<Position>.CreateOrGetExistingArchetype(Archetype<Position>.Id, scene);
            Archetype second = Archetype<Position>.CreateOrGetExistingArchetype(Archetype<Position>.Id, scene);

            Assert.Same(first, second);
        }

        /// <summary>
        ///     Tests that the generic CreateOrGetExistingArchetype creates an archetype from a component id span.
        /// </summary>
        [Fact]
        public void Archetype_T_CreateOrGetExistingArchetype_BySpan_Creates()
        {
            using Scene scene = new Scene();
            ReadOnlySpan<ComponentId> types = new[] {Component<Position>.Id, Component<Velocity>.Id};

            Archetype result = Archetype<Position>.CreateOrGetExistingArchetype(types, scene);

            Assert.NotNull(result);
            Assert.Equal(2, result.ArchetypeTypeArray.Length);
            Assert.True(result.GetComponentIndex<Position>() > 0);
            Assert.True(result.GetComponentIndex<Velocity>() > 0);
        }
    }
}
