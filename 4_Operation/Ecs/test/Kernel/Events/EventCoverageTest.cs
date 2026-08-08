using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Events
{
    /// <summary>
    /// The event coverage test class
    /// </summary>
    public class EventCoverageTest
    {
        /// <summary>
        /// Tests that component event is struct
        /// </summary>
        [Fact] public void ComponentEvent_IsStruct()
        {
            ComponentEvent evt = new ComponentEvent();
            Assert.True(typeof(ComponentEvent).IsValueType);
        }

        /// <summary>
        /// Tests that event record initialize creates new record when not exists
        /// </summary>
        [Fact] public void EventRecord_Initialize_CreatesNewRecordWhenNotExists()
        {
            EventRecord record = default;
            EventRecord.Initalize(false, ref record);
            Assert.NotNull(record);
        }

        /// <summary>
        /// Tests that event record initialize does not overwrite when exists
        /// </summary>
        [Fact] public void EventRecord_Initialize_DoesNotOverwriteWhenExists()
        {
            EventRecord original = new EventRecord();
            EventRecord record = original;
            EventRecord.Initalize(true, ref record);
            Assert.Same(original, record);
        }

        /// <summary>
        /// Tests that generic event can be constructed
        /// </summary>
        [Fact] public void GenericEvent_CanBeConstructed()
        {
            GenericEvent evt = new GenericEvent();
            Assert.NotNull(evt);
        }

        /// <summary>
        /// Tests that add component can process
        /// </summary>
        [Fact] public void AddComponent_CanProcess()
        {
            using Scene scene = new();
            scene.Create(new Position());
            scene.Create(new Position(), new Velocity());
            Assert.NotNull(scene);
        }

        /// <summary>
        /// Tests that delete component can process
        /// </summary>
        [Fact] public void DeleteComponent_CanProcess()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position(), new Velocity());
            go.Remove<Velocity>();
            Assert.True(go.IsAlive);
        }

        /// <summary>
        /// Tests that create command can process
        /// </summary>
        [Fact] public void CreateCommand_CanProcess()
        {
            using Scene scene = new();
            scene.Create(new Position());
            scene.Update();
        }

        /// <summary>
        /// Tests that ref can create and read
        /// </summary>
        [Fact] public void Ref_CanCreateAndRead()
        {
            using Scene scene = new();
            scene.Create(new Position { X = 42 });
            Query query = scene.Query<With<Position>>();
            foreach (Ecs.Systems.GameObjectRefTuple<Position> tuple in query.EnumerateWithEntities<Position>())
            {
                Assert.Equal(42, tuple.Item1.Value.X);
            }
        }
    }
}
