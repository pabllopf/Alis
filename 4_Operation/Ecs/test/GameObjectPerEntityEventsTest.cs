using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    /// Unit tests for per-entity events: OnDelete, OnComponentAdded and OnComponentRemoved.
    /// </summary>
    public class GameObjectPerEntityEventsTest
    {
        [Fact]
        public void OnDelete_FiresOnce_ForSubscribedEntity()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            int calls = 0;
            GameObject seen = default;

            entity.OnDelete += go =>
            {
                calls++;
                seen = go;
            };

            entity.Delete();

            Assert.Equal(1, calls);
            Assert.Equal(entity, seen);
        }

        [Fact]
        public void OnDelete_UnsubscribedHandler_IsNotInvoked()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            int calls = 0;
            void Handler(GameObject _) => calls++;

            entity.OnDelete += Handler;
            entity.OnDelete -= Handler;

            entity.Delete();

            Assert.Equal(0, calls);
        }

        [Fact]
        public void OnComponentAdded_FiresWithCorrectEntityAndComponentId()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

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

            Assert.Equal(1, calls);
            Assert.Equal(entity, seenEntity);
            Assert.Equal(Component<Position>.Id, seenId);
        }

        [Fact]
        public void OnComponentAdded_DoesNotFire_ForOtherEntityChanges()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create();
            GameObject entity2 = scene.Create();

            int calls = 0;
            entity1.OnComponentAdded += (_, _) => calls++;

            entity2.Add(new Position { X = 1, Y = 2 });

            Assert.Equal(0, calls);
        }

        [Fact]
        public void OnComponentRemoved_FiresWithCorrectEntityAndComponentId()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 3, Y = 4 });

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

            Assert.Equal(1, calls);
            Assert.Equal(entity, seenEntity);
            Assert.Equal(Component<Position>.Id, seenId);
        }

        [Fact]
        public void OnComponentRemoved_DoesNotFire_ForOtherEntityChanges()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 2 });
            GameObject entity2 = scene.Create(new Position { X = 3, Y = 4 });

            int calls = 0;
            entity1.OnComponentRemoved += (_, _) => calls++;

            entity2.Remove<Position>();

            Assert.Equal(0, calls);
        }
    }
}

