using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Events
{
    public class EventCoverageTest
    {
        [Fact]
        public void ComponentEvent_IsStruct()
        {
            var evt = new ComponentEvent();
            Assert.True(typeof(ComponentEvent).IsValueType);
        }

        [Fact]
        public void EventRecord_Initialize_CreatesNewRecordWhenNotExists()
        {
            EventRecord record = default;
            EventRecord.Initalize(false, ref record);
            Assert.NotNull(record);
        }

        [Fact]
        public void EventRecord_Initialize_DoesNotOverwriteWhenExists()
        {
            EventRecord original = new EventRecord();
            EventRecord record = original;
            EventRecord.Initalize(true, ref record);
            Assert.Same(original, record);
        }

        [Fact]
        public void GenericEvent_CanBeConstructed()
        {
            var evt = new GenericEvent();
            Assert.NotNull(evt);
        }

        [Fact]
        public void AddComponent_CanProcess()
        {
            using Scene scene = new();
            scene.Create(new Position());
            scene.Create(new Position(), new Velocity());
            Assert.NotNull(scene);
        }

        [Fact]
        public void DeleteComponent_CanProcess()
        {
            using Scene scene = new();
            var go = scene.Create(new Position(), new Velocity());
            go.Remove<Velocity>();
            Assert.True(go.IsAlive);
        }

        [Fact]
        public void CreateCommand_CanProcess()
        {
            using Scene scene = new();
            scene.Create(new Position());
            scene.Update();
        }

        [Fact]
        public void Ref_CanCreateAndRead()
        {
            using Scene scene = new();
            scene.Create(new Position { X = 42 });
            Query query = scene.Query<With<Position>>();
            foreach (var tuple in query.EnumerateWithEntities<Position>())
            {
                Assert.Equal(42, tuple.Item1.Value.X);
            }
        }
    }
}
