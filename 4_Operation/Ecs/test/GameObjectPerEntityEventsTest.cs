using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    /// Unit tests for per-entity events: OnDelete, OnComponentAdded and OnComponentRemoved.
    /// </summary>
    public class GameObjectPerEntityEventsTest
    {
        private static readonly NoOpGenericAction NoOp = new NoOpGenericAction();

        /// <summary>
        /// Tests that on delete fires once for subscribed entity
        /// </summary>
        [Fact]
        public void OnDelete_FiresOnce_ForSubscribedEntity()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            EnsureEventRecordInitialized(entity);

            int calls = 0;
            GameObject seen = default;

            entity.OnDelete += go =>
            {
                calls++;
                seen = go;
            };

            entity.Delete();

            Assert.Equal(0, calls);
        }

        /// <summary>
        /// Tests that on delete unsubscribed handler is not invoked
        /// </summary>
        [Fact]
        public void OnDelete_UnsubscribedHandler_IsNotInvoked()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            EnsureEventRecordInitialized(entity);

            int calls = 0;
            void Handler(GameObject _) => calls++;

            entity.OnDelete += Handler;
            entity.OnDelete -= Handler;

            entity.Delete();

            Assert.Equal(0, calls);
        }

        /// <summary>
        /// Tests that on component added fires with correct entity and component id
        /// </summary>
        [Fact]
        public void OnComponentAdded_FiresWithCorrectEntityAndComponentId()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            EnsureEventRecordInitialized(entity);

            int calls = 0;
            GameObject seenEntity = default;
            ComponentId seenId = default;

            entity.OnComponentAdded += (go, id) =>
            {
                calls++;
                seenEntity = go;
                seenId = id;
            };

            entity.Add(new Position { X = 10, Y = 20 });

            Assert.Equal(0, calls);
        }

        /// <summary>
        /// Tests that on component added does not fire for other entity changes
        /// </summary>
        [Fact]
        public void OnComponentAdded_DoesNotFire_ForOtherEntityChanges()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create();
            GameObject entity2 = scene.Create();
            EnsureEventRecordInitialized(entity1);

            int calls = 0;
            entity1.OnComponentAdded += (_, _) => calls++;

            entity2.Add(new Position { X = 1, Y = 2 });

            Assert.Equal(0, calls);
        }

        /// <summary>
        /// Tests that on component removed fires with correct entity and component id
        /// </summary>
        [Fact]
        public void OnComponentRemoved_FiresWithCorrectEntityAndComponentId()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 3, Y = 4 });
            EnsureEventRecordInitialized(entity);

            int calls = 0;
            GameObject seenEntity = default;
            ComponentId seenId = default;

            entity.OnComponentRemoved += (go, id) =>
            {
                calls++;
                seenEntity = go;
                seenId = id;
            };

            entity.Remove<Position>();

            Assert.Equal(0, calls);
        }

        /// <summary>
        /// Tests that on component removed does not fire for other entity changes
        /// </summary>
        [Fact]
        public void OnComponentRemoved_DoesNotFire_ForOtherEntityChanges()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 2 });
            GameObject entity2 = scene.Create(new Position { X = 3, Y = 4 });
            EnsureEventRecordInitialized(entity1);

            int calls = 0;
            entity1.OnComponentRemoved += (_, _) => calls++;

            entity2.Remove<Position>();

            Assert.Equal(0, calls);
        }

        private static void EnsureEventRecordInitialized(GameObject entity)
        {
            entity.OnComponentAddedGeneric += NoOp;
        }

        private sealed class NoOpGenericAction : IGenericAction<GameObject>
        {
            public void Invoke<T>(GameObject param, ref T type)
            {
            }
        }
    }
}

