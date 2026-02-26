// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AdvancedQueryTest.cs
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

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests for advanced query scenarios and filtering
    /// </summary>
    /// <remarks>
    ///     Validates complex query scenarios including large entity counts,
    ///     performance characteristics, and query consistency.
    /// </remarks>
    public class AdvancedQueryTest
    {
        /// <summary>
        ///     Tests query with many entities
        /// </summary>
        [Fact]
        public void Query_WorksWithLargeEntityCount()
        {
            // Arrange
            using var scene = new Scene();
            const int entityCount = 100;
            for (int i = 0; i < entityCount; i++)
            {
                scene.Create(new Position { X = i, Y = i * 2 });
            }

            // Act
            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (var _ in query.EnumerateWithEntities<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(entityCount, count);
        }

        /// <summary>
        ///     Tests query filters entities correctly with mixed components
        /// </summary>
        [Fact]
        public void Query_CorrectlyFiltersWithMixedComponents()
        {
            // Arrange
            using var scene = new Scene();
            scene.Create(new Position { X = 1 });
            scene.Create(new Position { X = 2 }, new Health { Value = 100 });
            scene.Create(new Health { Value = 50 });
            scene.Create(new Position { X = 3 }, new Health { Value = 75 }, new Velocity { VX = 1, VY = 1 });

            // Act
            Query positionOnly = scene.Query<With<Position>>();
            Query positionAndHealth = scene.Query<With<Position>, With<Health>>();
            Query positionHealthVelocity = scene.Query<With<Position>, With<Health>, With<Velocity>>();

            int pos = 0;
            foreach (var _ in positionOnly.EnumerateWithEntities<Position>())
                pos++;

            int posHealth = 0;
            foreach (var _ in positionAndHealth.EnumerateWithEntities<Position, Health>())
                posHealth++;

            int posHealthVel = 0;
            foreach (var _ in positionHealthVelocity.EnumerateWithEntities<Position, Health, Velocity>())
                posHealthVel++;

            // Assert
            Assert.Equal(3, pos);
            Assert.Equal(2, posHealth);
            Assert.Equal(1, posHealthVel);
        }

        /// <summary>
        ///     Tests query state after entity modifications
        /// </summary>
        [Fact]
        public void Query_StateReflectsEntityModifications()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1 });
            GameObject entity2 = scene.Create(new Position { X = 2 });

            Query query = scene.Query<With<Position>, With<Health>>();

            // Act - Initially no entities with both
            int count1 = 0;
            foreach (var _ in query.EnumerateWithEntities<Position, Health>())
                count1++;

            entity1.Add(new Health { Value = 100 });

            // Assert - Now one entity has both
            int count2 = 0;
            foreach (var _ in query.EnumerateWithEntities<Position, Health>())
                count2++;

            Assert.Equal(0, count1);
            Assert.Equal(1, count2);
        }

        /// <summary>
        ///     Tests creating and deleting many entities in sequence
        /// </summary>
        [Fact]
        public void Scene_CanCreateAndDeleteManyEntitiesInSequence()
        {
            // Arrange
            using var scene = new Scene();
            const int operationCount = 50;

            // Act
            var entities = new GameObject[operationCount];
            for (int i = 0; i < operationCount; i++)
            {
                entities[i] = scene.Create(new Position { X = i });
            }

            for (int i = 0; i < operationCount / 2; i++)
            {
                entities[i].Delete();
            }

            // Assert
            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (var _ in query.EnumerateWithEntities<Position>())
                count++;

            Assert.Equal(operationCount / 2, count);
        }

        /// <summary>
        ///     Tests accessing component data in queries
        /// </summary>
        [Fact]
        public void Query_CanAccessComponentData()
        {
            // Arrange
            using var scene = new Scene();
            scene.Create(new Position { X = 10, Y = 20 });
            scene.Create(new Position { X = 30, Y = 40 });

            // Act
            Query query = scene.Query<With<Position>>();
            int count = 0;
            
            foreach (var (_, _) in query.EnumerateWithEntities<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests query performance with repeated filtering
        /// </summary>
        [Fact]
        public void Query_RepeatedFilteringIsConsistent()
        {
            // Arrange
            using var scene = new Scene();
            for (int i = 0; i < 50; i++)
            {
                if (i % 2 == 0)
                    scene.Create(new Position { X = i });
                else
                    scene.Create(new Health { Value = i });
            }

            // Act
            Query query = scene.Query<With<Position>>();
            var counts = new int[5];
            
            for (int iteration = 0; iteration < 5; iteration++)
            {
                int count = 0;
                foreach (var _ in query.EnumerateWithEntities<Position>())
                    count++;
                counts[iteration] = count;
            }

            // Assert - All iterations should have same count
            for (int i = 0; i < 5; i++)
                Assert.Equal(25, counts[i]);
        }
    }
}

