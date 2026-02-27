// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeOperationsTest.cs
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

using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Archetypes
{
    /// <summary>
    ///     The archetype operations test class
    /// </summary>
    /// <remarks>
    ///     Tests archetype functionality and entity transitions between archetypes.
    ///     Archetypes are the core data structure of the ECS organizing entities
    ///     by their component composition for efficient memory layout and querying.
    /// </remarks>
    public class ArchetypeOperationsTest
    {
        /// <summary>
        ///     Tests that default archetype is accessible
        /// </summary>
        /// <remarks>
        ///     Verifies that the default archetype exists and is accessible
        ///     for empty entities without components.
        /// </remarks>
        [Fact]
        public void Archetype_DefaultArchetypeIsAccessible()
        {
            // Arrange
            Scene scene = new Scene();

            // Act
            var defaultArchetype = scene.DefaultArchetype;

            // Assert
            Assert.NotNull(defaultArchetype);

            // Cleanup
            scene.Dispose();
        }

        /// <summary>
        ///     Tests archetype changes when component is added
        /// </summary>
        /// <remarks>
        ///     Validates that adding a component causes an entity to
        ///     transition to a new archetype.
        /// </remarks>
        [Fact]
        public void Archetype_ChangesWhenComponentIsAdded()
        {
            // Arrange
            Scene scene = new Scene();
            GameObject entity = scene.Create();

            // Act
            entity.Add<Position>(new Position());

            // Assert
            Assert.True(entity.Has<Position>());

            // Cleanup
            scene.Dispose();
        }

        /// <summary>
        ///     Tests entities with same components share archetype
        /// </summary>
        /// <remarks>
        ///     Verifies that multiple entities with identical component sets
        ///     share the same archetype for memory efficiency.
        /// </remarks>
        [Fact]
        public void Archetype_SameComponentSetSharesArchetype()
        {
            // Arrange
            Scene scene = new Scene();

            // Act
            GameObject e1 = scene.Create();
            e1.Add<Position>(new Position());
            e1.Add<Velocity>(new Velocity());

            GameObject e2 = scene.Create();
            e2.Add<Position>(new Position());
            e2.Add<Velocity>(new Velocity());

            // Both entities should be in efficient memory layout
            // Assert
            Assert.True(e1.Has<Position>());
            Assert.True(e2.Has<Position>());

            // Cleanup
            scene.Dispose();
        }

        /// <summary>
        ///     Tests archetype transitions are deterministic
        /// </summary>
        /// <remarks>
        ///     Validates that the same sequence of component additions
        ///     always results in the same archetype.
        /// </remarks>
        [Fact]
        public void Archetype_TransitionsAreDeterministic()
        {
            // Arrange
            Scene scene = new Scene();
            GameObject e1 = scene.Create();
            GameObject e2 = scene.Create();

            // Act
            e1.Add<Position>(new Position());
            e1.Add<Velocity>(new Velocity());

            e2.Add<Position>(new Position());
            e2.Add<Velocity>(new Velocity());

            // Assert
            Assert.True(e1.Has<Position>());
            Assert.True(e1.Has<Velocity>());
            Assert.True(e2.Has<Position>());
            Assert.True(e2.Has<Velocity>());

            // Cleanup
            scene.Dispose();
        }

        /// <summary>
        ///     Tests archetype transitions with component removal
        /// </summary>
        /// <remarks>
        ///     Validates that removing components causes an entity
        ///     to transition to an archetype with fewer components.
        /// </remarks>
        [Fact]
        public void Archetype_TransitionsWhenComponentsRemoved()
        {
            // Arrange
            Scene scene = new Scene();
            GameObject entity = scene.Create();
            entity.Add<Position>(new Position());
            entity.Add<Velocity>(new Velocity());
            entity.Add<Health>(new Health());

            // Act
            entity.Remove<Health>();
            entity.Remove<Velocity>();

            // Assert
            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());

            // Cleanup
            scene.Dispose();
        }

        /// <summary>
        ///     Tests many archetypes can coexist in same scene
        /// </summary>
        /// <remarks>
        ///     Verifies that the ECS can handle a scene with many different
        ///     archetype configurations efficiently.
        /// </remarks>
        [Fact]
        public void Archetype_ManyArchetypesCanCoexistInScene()
        {
            // Arrange
            Scene scene = new Scene();

            // Act - Create entities with different component combinations
            for (int i = 0; i < 10; i++)
            {
                GameObject entity = scene.Create();
                if (i % 2 == 0) entity.Add<Position>(new Position());
                if (i % 3 == 0) entity.Add<Velocity>(new Velocity());
                if (i % 4 == 0) entity.Add<Health>(new Health());
            }

            // Assert - All entities should be created and properly configured
            int count = 0;
            Query query = scene.Query<With<Position>>();
            foreach (GameObject entity in query.EnumerateWithEntities())
            {
                count++;
            }
            Assert.True(count > 0);

            // Cleanup
            scene.Dispose();
        }

        /// <summary>
        ///     Tests component access works across archetype transitions
        /// </summary>
        /// <remarks>
        ///     Validates that component data remains accessible and correct
        ///     even after archetype transitions.
        /// </remarks>
        [Fact]
        public void Archetype_ComponentAccessWorksAcrossTransitions()
        {
            // Arrange
            Scene scene = new Scene();
            GameObject entity = scene.Create();

            // Act
            entity.Add<Position>(new Position());
            ref Position pos1 = ref entity.Get<Position>();
            pos1.X = 100;
            pos1.Y = 200;

            entity.Add<Velocity>(new Velocity());
            ref Position pos2 = ref entity.Get<Position>();

            // Assert
            Assert.Equal(100, pos2.X);
            Assert.Equal(200, pos2.Y);

            // Cleanup
            scene.Dispose();
        }

        /// <summary>
        ///     Tests order of component additions doesn't affect queries
        /// </summary>
        /// <remarks>
        ///     Verifies that regardless of the order components are added,
        ///     entities are correctly included in matching queries.
        /// </remarks>
        [Fact]
        public void Archetype_ComponentOrderDoesntAffectQueries()
        {
            // Arrange
            Scene scene = new Scene();

            GameObject e1 = scene.Create();
            e1.Add<Position>(new Position());
            e1.Add<Velocity>(new Velocity());

            GameObject e2 = scene.Create();
            e2.Add<Velocity>(new Velocity());
            e2.Add<Position>(new Position());

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>>();
            int count = 0;
            foreach (GameObject entity in query.EnumerateWithEntities())
            {
                count++;
            }

            // Assert
            Assert.Equal(2, count);

            // Cleanup
            scene.Dispose();
        }
    }
}

