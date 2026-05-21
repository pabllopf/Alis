

using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests for entity deletion and lifecycle
    /// </summary>
    /// <remarks>
    ///     Validates that entities can be deleted and that queries
    ///     correctly reflect deletions.
    /// </remarks>
    public class EntityDeletionTest
    {
        /// <summary>
        ///     Tests that entity can be deleted
        /// </summary>
        [Fact]
        public void GameObject_CanBeDeleted()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 10});
            Assert.True(entity.IsAlive);

            int entityDeletedCount = 0;
            scene.EntityDeleted += _ => entityDeletedCount++;
            entity.Delete();

            Assert.False(entity.IsAlive);
            Assert.Equal(1, entityDeletedCount);
        }

        /// <summary>
        ///     Tests that deleted entity is not in queries
        /// </summary>
        [Fact]
        public void Query_ExcludesDeletedEntities()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position {X = 1});
            GameObject entity2 = scene.Create(new Position {X = 2});
            GameObject entity3 = scene.Create(new Position {X = 3});

            entity2.Delete();

            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (Ecs.Systems.GameObjectRefTuple<Position> _ in query.EnumerateWithEntities<Position>())
            {
                count++;
            }

            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests deleting multiple entities
        /// </summary>
        [Fact]
        public void Scene_CanDeleteMultipleEntities()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position {X = 1});
            GameObject entity2 = scene.Create(new Position {X = 2});
            GameObject entity3 = scene.Create(new Position {X = 3});
            GameObject entity4 = scene.Create(new Position {X = 4});

            entity1.Delete();
            entity3.Delete();

            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (Ecs.Systems.GameObjectRefTuple<Position> _ in query.EnumerateWithEntities<Position>())
            {
                count++;
            }

            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests entity deleted event fires
        /// </summary>
        [Fact]
        public void Scene_EntityDeletedEventFires()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position());
            int eventCount = 0;

            scene.EntityDeleted += _ => eventCount++;

            entity.Delete();

            Assert.Equal(1, eventCount);
        }

        /// <summary>
        ///     Tests that deleted entity raises event with correct entity
        /// </summary>
        [Fact]
        public void Scene_EntityDeletedEventIncludesCorrectEntity()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position());
            GameObject deletedEntity = default(GameObject);

            scene.EntityDeleted += go => deletedEntity = go;

            entity.Delete();

            Assert.Equal(entity.EntityID, deletedEntity.EntityID);
        }

        /// <summary>
        ///     Tests that all entities can be deleted
        /// </summary>
        [Fact]
        public void Scene_CanDeleteAllEntities()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position());
            GameObject entity2 = scene.Create(new Position());
            GameObject entity3 = scene.Create(new Position());

            entity1.Delete();
            entity2.Delete();
            entity3.Delete();

            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (Ecs.Systems.GameObjectRefTuple<Position> _ in query.EnumerateWithEntities<Position>())
            {
                count++;
            }

            Assert.Equal(0, count);
        }
    }
}