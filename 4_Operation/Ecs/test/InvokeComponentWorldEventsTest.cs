using System.Collections.Generic;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    /// Unit tests for all GameObject.InvokeComponentWorldEvents overloads (arity 1..8).
    /// </summary>
    public class InvokeComponentWorldEventsTest
    {
        /// <summary>
        /// Tests that arity 1 invokes single component id for same entity
        /// </summary>
        [Fact]
        public void Arity1_InvokesSingleComponentIdForSameEntity()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            Event<ComponentId> worldEvent = new Event<ComponentId>();
            List<ComponentId> componentIds = new List<ComponentId>();
            List<GameObject> entities = new List<GameObject>();
            worldEvent.Add((go, id) =>
            {
                entities.Add(go);
                componentIds.Add(id);
            });

            GameObject.InvokeComponentWorldEvents<Position>(ref worldEvent, entity);

            Assert.Single(componentIds);
            Assert.Equal(Component<Position>.Id, componentIds[0]);
            Assert.Single(entities);
            Assert.Equal(entity, entities[0]);
        }

        /// <summary>
        /// Tests that arity 2 invokes both component ids in order
        /// </summary>
        [Fact]
        public void Arity2_InvokesBothComponentIdsInOrder()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            Event<ComponentId> worldEvent = new Event<ComponentId>();
            List<ComponentId> componentIds = new List<ComponentId>();
            List<GameObject> entities = new List<GameObject>();
            worldEvent.Add((go, id) =>
            {
                entities.Add(go);
                componentIds.Add(id);
            });

            GameObject.InvokeComponentWorldEvents<Position, Velocity>(ref worldEvent, entity);

            Assert.Equal(2, componentIds.Count);
            Assert.Equal(Component<Position>.Id, componentIds[0]);
            Assert.Equal(Component<Velocity>.Id, componentIds[1]);
            Assert.Equal(2, entities.Count);
            Assert.All(entities, e => Assert.Equal(entity, e));
        }

        /// <summary>
        /// Tests that arity 3 invokes three component ids in order
        /// </summary>
        [Fact]
        public void Arity3_InvokesThreeComponentIdsInOrder()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            Event<ComponentId> worldEvent = new Event<ComponentId>();
            List<ComponentId> componentIds = new List<ComponentId>();
            worldEvent.Add((go, id) => componentIds.Add(id));

            GameObject.InvokeComponentWorldEvents<Position, Velocity, Health>(ref worldEvent, entity);

            Assert.Equal(3, componentIds.Count);
            Assert.Equal(Component<Position>.Id, componentIds[0]);
            Assert.Equal(Component<Velocity>.Id, componentIds[1]);
            Assert.Equal(Component<Health>.Id, componentIds[2]);
        }

        /// <summary>
        /// Tests that arity 4 invokes four component ids in order
        /// </summary>
        [Fact]
        public void Arity4_InvokesFourComponentIdsInOrder()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            Event<ComponentId> worldEvent = new Event<ComponentId>();
            List<ComponentId> componentIds = new List<ComponentId>();
            worldEvent.Add((go, id) => componentIds.Add(id));

            GameObject.InvokeComponentWorldEvents<Position, Velocity, Health, Armor>(ref worldEvent, entity);

            Assert.Equal(4, componentIds.Count);
            Assert.Equal(Component<Position>.Id, componentIds[0]);
            Assert.Equal(Component<Velocity>.Id, componentIds[1]);
            Assert.Equal(Component<Health>.Id, componentIds[2]);
            Assert.Equal(Component<Armor>.Id, componentIds[3]);
        }

        /// <summary>
        /// Tests that arity 5 invokes five component ids in order
        /// </summary>
        [Fact]
        public void Arity5_InvokesFiveComponentIdsInOrder()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            Event<ComponentId> worldEvent = new Event<ComponentId>();
            List<ComponentId> componentIds = new List<ComponentId>();
            worldEvent.Add((go, id) => componentIds.Add(id));

            GameObject.InvokeComponentWorldEvents<Position, Velocity, Health, Armor, Damage>(
                ref worldEvent,
                entity);

            Assert.Equal(5, componentIds.Count);
            Assert.Equal(Component<Position>.Id, componentIds[0]);
            Assert.Equal(Component<Velocity>.Id, componentIds[1]);
            Assert.Equal(Component<Health>.Id, componentIds[2]);
            Assert.Equal(Component<Armor>.Id, componentIds[3]);
            Assert.Equal(Component<Damage>.Id, componentIds[4]);
        }

        /// <summary>
        /// Tests that arity 6 invokes six component ids in order
        /// </summary>
        [Fact]
        public void Arity6_InvokesSixComponentIdsInOrder()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            Event<ComponentId> worldEvent = new Event<ComponentId>();
            List<ComponentId> componentIds = new List<ComponentId>();
            worldEvent.Add((go, id) => componentIds.Add(id));

            GameObject.InvokeComponentWorldEvents<Position, Velocity, Health, Armor, Damage, Transform>(
                ref worldEvent,
                entity);

            Assert.Equal(6, componentIds.Count);
            Assert.Equal(Component<Position>.Id, componentIds[0]);
            Assert.Equal(Component<Velocity>.Id, componentIds[1]);
            Assert.Equal(Component<Health>.Id, componentIds[2]);
            Assert.Equal(Component<Armor>.Id, componentIds[3]);
            Assert.Equal(Component<Damage>.Id, componentIds[4]);
            Assert.Equal(Component<Transform>.Id, componentIds[5]);
        }

        /// <summary>
        /// Tests that arity 7 invokes seven component ids in order
        /// </summary>
        [Fact]
        public void Arity7_InvokesSevenComponentIdsInOrder()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            Event<ComponentId> worldEvent = new Event<ComponentId>();
            List<ComponentId> componentIds = new List<ComponentId>();
            worldEvent.Add((go, id) => componentIds.Add(id));

            GameObject.InvokeComponentWorldEvents<Position, Velocity, Health, Armor, Damage, Transform, TestComponent>(
                ref worldEvent,
                entity);

            Assert.Equal(7, componentIds.Count);
            Assert.Equal(Component<Position>.Id, componentIds[0]);
            Assert.Equal(Component<Velocity>.Id, componentIds[1]);
            Assert.Equal(Component<Health>.Id, componentIds[2]);
            Assert.Equal(Component<Armor>.Id, componentIds[3]);
            Assert.Equal(Component<Damage>.Id, componentIds[4]);
            Assert.Equal(Component<Transform>.Id, componentIds[5]);
            Assert.Equal(Component<TestComponent>.Id, componentIds[6]);
        }

        /// <summary>
        /// Tests that arity 8 invokes eight component ids in order
        /// </summary>
        [Fact]
        public void Arity8_InvokesEightComponentIdsInOrder()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            Event<ComponentId> worldEvent = new Event<ComponentId>();
            List<ComponentId> componentIds = new List<ComponentId>();
            worldEvent.Add((go, id) => componentIds.Add(id));

            GameObject.InvokeComponentWorldEvents<
                Position,
                Velocity,
                Health,
                Armor,
                Damage,
                Transform,
                TestComponent,
                AnotherComponent>(ref worldEvent, entity);

            Assert.Equal(8, componentIds.Count);
            Assert.Equal(Component<Position>.Id, componentIds[0]);
            Assert.Equal(Component<Velocity>.Id, componentIds[1]);
            Assert.Equal(Component<Health>.Id, componentIds[2]);
            Assert.Equal(Component<Armor>.Id, componentIds[3]);
            Assert.Equal(Component<Damage>.Id, componentIds[4]);
            Assert.Equal(Component<Transform>.Id, componentIds[5]);
            Assert.Equal(Component<TestComponent>.Id, componentIds[6]);
            Assert.Equal(Component<AnotherComponent>.Id, componentIds[7]);
        }
    }
}

