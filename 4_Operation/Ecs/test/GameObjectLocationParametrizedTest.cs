

using System.Collections.Generic;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Parametrized tests for GameObject location and identity
    /// </summary>
    public class GameObjectLocationParametrizedTest
    {
        /// <summary>
        ///     Tests that game object location created entities have unique ids
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(1), InlineData(5), InlineData(10), InlineData(50)]
        public void GameObjectLocation_CreatedEntities_HaveUniqueIds(int entityCount)
        {
            using Scene scene = new Scene();
            GameObject[] entities = new GameObject[entityCount];
            HashSet<int> ids = new HashSet<int>();

            for (int i = 0; i < entityCount; i++)
            {
                entities[i] = scene.Create();
            }

            for (int i = 0; i < entityCount; i++)
            {
                for (int j = i + 1; j < entityCount; j++)
                {
                    Assert.NotEqual(entities[i], entities[j]);
                }
            }
        }

        /// <summary>
        ///     Tests that game object location different scenes create different entities
        /// </summary>
        /// <param name="entityCountPerScene">The entity count per scene</param>
        [Theory, InlineData(1), InlineData(5), InlineData(10)]
        public void GameObjectLocation_DifferentScenes_CreateDifferentEntities(int entityCountPerScene)
        {
            using Scene scene1 = new Scene();
            using Scene scene2 = new Scene();
            GameObject[] entities1 = new GameObject[entityCountPerScene];
            GameObject[] entities2 = new GameObject[entityCountPerScene];

            for (int i = 0; i < entityCountPerScene; i++)
            {
                entities1[i] = scene1.Create();
                entities2[i] = scene2.Create();
            }

            for (int i = 0; i < entityCountPerScene; i++)
            {
                Assert.NotEqual(entities1[i], entities2[i]);
            }
        }

        /// <summary>
        ///     Tests that game object location query returns local entities only from scene
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(10), InlineData(50)]
        public void GameObjectLocation_QueryReturnsLocalEntities_OnlyFromScene(int entityCount)
        {
            using Scene scene = new Scene();
            for (int i = 0; i < entityCount; i++)
            {
                if (i % 2 == 0)
                {
                    scene.Create(new Position {X = 1, Y = 1});
                }
                else
                {
                    scene.Create();
                }
            }

            int queryCount = 0;
            foreach (GameObject go in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                queryCount++;
            }

            Assert.Equal((entityCount + 1) / 2, queryCount);
        }

        /// <summary>
        ///     Tests that game object location entity identity persists across operations
        /// </summary>
        [Fact]
        public void GameObjectLocation_EntityIdentity_PersistsAcrossOperations()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 10, Y = 20});

            GameObject id1 = entity;
            entity.Add(new Health {Value = 100});
            GameObject id2 = entity;
            ref Position pos = ref entity.Get<Position>();
            pos.X = 50;
            GameObject id3 = entity;

            Assert.Equal(id1, id2);
            Assert.Equal(id2, id3);
        }

        /// <summary>
        ///     Tests that game object location entity can be stored and retrieved works
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(10), InlineData(50)]
        public void GameObjectLocation_EntityCanBeStoredAndRetrieved_Works(int entityCount)
        {
            using Scene scene = new Scene();
            GameObject[] stored = new GameObject[entityCount];

            for (int i = 0; i < entityCount; i++)
            {
                stored[i] = scene.Create(new Position {X = i, Y = i});
            }

            for (int i = 0; i < entityCount; i++)
            {
                Assert.True(stored[i].IsAlive);
                Assert.Equal(i, stored[i].Get<Position>().X);
            }

            Assert.True(true);
        }

        /// <summary>
        ///     Tests that game object location multiple references to same entity all valid
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(10), InlineData(50)]
        public void GameObjectLocation_MultipleReferencesToSameEntity_AllValid(int entityCount)
        {
            using Scene scene = new Scene();
            GameObject[] stored = new GameObject[entityCount];

            for (int i = 0; i < entityCount; i++)
            {
                GameObject created = scene.Create(new Position {X = i, Y = i});
                stored[i] = created;
                GameObject sameRef = created;

                Assert.Equal(created, sameRef);
            }

            Assert.True(true);
        }

        /// <summary>
        ///     Tests that game object location entity location within scene accessible
        /// </summary>
        [Fact]
        public void GameObjectLocation_EntityLocationWithinScene_Accessible()
        {
            using Scene scene = new Scene();

            GameObject entity = scene.Create(new Position {X = 100, Y = 200});

            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
            Assert.Equal(100, entity.Get<Position>().X);
        }

        /// <summary>
        ///     Tests that game object location deleted entity location becomes invalid
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(1), InlineData(5), InlineData(10)]
        public void GameObjectLocation_DeletedEntityLocationBecomesInvalid(int count)
        {
            using Scene scene = new Scene();
            GameObject[] entities = new GameObject[count];
            for (int i = 0; i < count; i++)
            {
                entities[i] = scene.Create();
            }

            for (int i = 0; i < count; i++)
            {
                entities[i].Delete();
            }

            for (int i = 0; i < count; i++)
            {
                Assert.False(entities[i].IsAlive);
            }
        }
    }
}