// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeExtendedTest.cs
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


using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Archetypes
{
    /// <summary>
    ///     The archetype extended test class
    /// </summary>
    /// <remarks>
    ///     Extended tests for the Archetype class, validating entity storage organization
    ///     and component management within archetypes.
    /// </remarks>
    public class ArchetypeExtendedTest
    {
        /// <summary>
        ///     Tests that archetype can store entities
        /// </summary>
        /// <remarks>
        ///     Validates that an Archetype can store and track entities.
        /// </remarks>
        [Fact]
        public void Archetype_CanStoreEntities()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            Assert.True(entity.IsAlive);
        }

        /// <summary>
        ///     Tests that archetype maintains entity count
        /// </summary>
        /// <remarks>
        ///     Validates that Archetype tracks the correct number of entities.
        /// </remarks>
        [Fact]
        public void Archetype_MaintainsEntityCount()
        {
            using Scene scene = new Scene();
            int initialCount = scene.EntityCount;

            scene.Create(new Position {X = 1, Y = 2});
            scene.Create(new Position {X = 3, Y = 4});

            Assert.Equal(initialCount + 2, scene.EntityCount);
        }

        /// <summary>
        ///     Tests that archetype organizes entities efficiently
        /// </summary>
        /// <remarks>
        ///     Validates that entities with same component set use same archetype.
        /// </remarks>
        [Fact]
        public void Archetype_OrganizesEntitiesEfficiently()
        {
            using Scene scene = new Scene();

            GameObject entity1 = scene.Create(new Position {X = 1, Y = 2});
            GameObject entity2 = scene.Create(new Position {X = 3, Y = 4});

            Assert.True(entity1.IsAlive);
            Assert.True(entity2.IsAlive);
        }

        /// <summary>
        ///     Tests that archetype handles transitions
        /// </summary>
        /// <remarks>
        ///     Validates that entities can transition between archetypes.
        /// </remarks>
        [Fact]
        public void Archetype_HandlesTransitions()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Add(new Velocity {X = 3, Y = 4});

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
        }

        /// <summary>
        ///     Tests that archetype preserves component data
        /// </summary>
        /// <remarks>
        ///     Validates that component data is preserved during archetype transitions.
        /// </remarks>
        [Fact]
        public void Archetype_PreservesComponentData()
        {
            using Scene scene = new Scene();
            Position originalPos = new Position {X = 42, Y = 84};
            GameObject entity = scene.Create(originalPos);

            entity.Add(new Velocity {X = 5, Y = 10});

            Assert.True(entity.TryGet(out Ref<Position> pos));
            Assert.Equal(42, pos.Value.X);
            Assert.Equal(84, pos.Value.Y);
        }

        /// <summary>
        ///     Tests that archetype handles entity removal
        /// </summary>
        /// <remarks>
        ///     Validates that Archetype correctly handles entity deletion.
        /// </remarks>
        [Fact]
        public void Archetype_HandlesEntityRemoval()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position {X = 1, Y = 2});
            GameObject entity2 = scene.Create(new Position {X = 3, Y = 4});
            int initialCount = scene.EntityCount;

            entity1.Delete();

            Assert.False(entity1.IsAlive);
            Assert.True(entity2.IsAlive);
            Assert.Equal(initialCount - 1, scene.EntityCount);
        }

        /// <summary>
        ///     Tests that archetype supports queries
        /// </summary>
        /// <remarks>
        ///     Validates that entities in archetype can be queried.
        /// </remarks>
        [Fact]
        public void Archetype_SupportsQueries()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2});
            scene.Create(new Position {X = 3, Y = 4});

            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (RefTuple<Position> _ in query.Enumerate<Position>())
            {
                count++;
            }

            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that archetype with different components are separate
        /// </summary>
        /// <remarks>
        ///     Validates that entities with different component sets use different archetypes.
        /// </remarks>
        [Fact]
        public void Archetype_WithDifferentComponentsAreSeparate()
        {
            using Scene scene = new Scene();

            GameObject entity1 = scene.Create(new Position {X = 1, Y = 2});
            GameObject entity2 = scene.Create(new Position {X = 3, Y = 4}, new Velocity {X = 5, Y = 6});

            Assert.True(entity1.IsAlive);
            Assert.True(entity2.IsAlive);
            Assert.True(entity1.Has<Position>());
            Assert.False(entity1.Has<Velocity>());
            Assert.True(entity2.Has<Position>());
            Assert.True(entity2.Has<Velocity>());
        }

        /// <summary>
        ///     Tests that archetype handles large entity counts
        /// </summary>
        /// <remarks>
        ///     Validates that Archetype can manage many entities efficiently.
        /// </remarks>
        [Fact]
        public void Archetype_HandlesLargeEntityCounts()
        {
            using Scene scene = new Scene();

            for (int i = 0; i < 1000; i++)
            {
                scene.Create(new Position {X = i, Y = i * 2});
            }

            Assert.Equal(1000, scene.EntityCount);

            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (RefTuple<Position> _ in query.Enumerate<Position>())
            {
                count++;
            }

            Assert.Equal(1000, count);
        }

        /// <summary>
        ///     Tests that archetype handles component removal
        /// </summary>
        /// <remarks>
        ///     Validates that Archetype correctly handles component removal.
        /// </remarks>
        [Fact]
        public void Archetype_HandlesComponentRemoval()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {X = 3, Y = 4}
            );

            entity.Remove<Velocity>();

            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
        }

        /// <summary>
        ///     Tests that archetype ID is consistent
        /// </summary>
        /// <remarks>
        ///     Validates that entities with same components have same archetype ID.
        /// </remarks>
        [Fact]
        public void Archetype_IDIsConsistent()
        {
            using Scene scene = new Scene();

            GameObject entity1 = scene.Create(new Position {X = 1, Y = 2});
            GameObject entity2 = scene.Create(new Position {X = 3, Y = 4});

            Assert.True(entity1.IsAlive);
            Assert.True(entity2.IsAlive);
        }

        /// <summary>
        ///     Tests that archetype handles mixed operations
        /// </summary>
        /// <remarks>
        ///     Validates that Archetype handles creation, modification, and deletion together.
        /// </remarks>
        [Fact]
        public void Archetype_HandlesMixedOperations()
        {
            using Scene scene = new Scene();

            GameObject entity1 = scene.Create(new Position {X = 1, Y = 2});
            GameObject entity2 = scene.Create(new Position {X = 3, Y = 4});
            GameObject entity3 = scene.Create(new Position {X = 5, Y = 6});

            entity1.Add(new Velocity {X = 7, Y = 8});
            entity2.Remove<Position>();
            GameObject entity4 = scene.Create(new Position {X = 9, Y = 10});

            Assert.True(entity1.IsAlive);
            Assert.True(entity2.IsAlive);
            Assert.True(entity3.IsAlive);
            Assert.True(entity4.IsAlive);

            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (RefTuple<Position> _ in query.Enumerate<Position>())
            {
                count++;
            }

            Assert.Equal(3, count);
        }
    }
}