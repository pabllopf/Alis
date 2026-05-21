

using System;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The component lifecycle advanced test class
    /// </summary>
    /// <remarks>
    ///     Tests complex component lifecycle scenarios including
    ///     initialization, modification, removal, and edge cases.
    /// </remarks>
    public class ComponentLifecycleAdvancedTest
    {
        /// <summary>
        ///     Tests component initialization with default values
        /// </summary>
        /// <remarks>
        ///     Validates that newly added components are properly initialized
        ///     with appropriate default values.
        /// </remarks>
        [Fact]
        public void Component_InitializesWithDefaultValues()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(new Position());

            Assert.Equal(0, entity.Get<Position>().X);
            Assert.Equal(0, entity.Get<Position>().Y);
        }

        /// <summary>
        ///     Tests getting non-existent component
        /// </summary>
        /// <remarks>
        ///     Validates that attempting to get a component
        ///     that doesn't exist handles appropriately.
        /// </remarks>
        [Fact]
        public void Component_GettingNonExistentThrowsException()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            Assert.Throws<NullReferenceException>(() => { _ = entity.Get<Position>(); });
        }

        /// <summary>
        ///     Tests component presence check accuracy
        /// </summary>
        /// <remarks>
        ///     Validates that HasComponent correctly reports the presence
        ///     of components throughout their lifecycle.
        /// </remarks>
        [Fact]
        public void Component_HasComponentAccuracyThroughLifecycle()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            Assert.False(entity.Has<Position>());

            entity.Add(new Position());
            Assert.True(entity.Has<Position>());

            entity.Remove<Position>();
            Assert.False(entity.Has<Position>());
        }

        /// <summary>
        ///     Tests component data persistence across multiple scenes
        /// </summary>
        /// <remarks>
        ///     Validates that component data is properly isolated
        ///     between different scene instances.
        /// </remarks>
        [Fact]
        public void Component_DataIsolatedAcrossScenes()
        {
            using Scene scene1 = new Scene();
            using Scene scene2 = new Scene();

            GameObject e1 = scene1.Create(new Health {Value = 100});
            GameObject e2 = scene2.Create(new Health {Value = 50});

            ref Health h1 = ref e1.Get<Health>();
            h1.Value = 200;

            Assert.Equal(200, e1.Get<Health>().Value);
            Assert.Equal(50, e2.Get<Health>().Value);
        }

        /// <summary>
        ///     Tests component lifecycle during rapid entity creation/destruction
        /// </summary>
        /// <remarks>
        ///     Validates that components are properly managed during
        ///     rapid entity lifecycle operations.
        /// </remarks>
        [Fact]
        public void Component_HandlesRapidEntityLifecycle()
        {
            using Scene scene = new Scene();
            const int iterations = 100;

            for (int i = 0; i < iterations; i++)
            {
                GameObject entity = scene.Create(new Position {X = i, Y = i * 2});
                Assert.True(entity.Has<Position>());
                Assert.Equal(i, entity.Get<Position>().X);
                Assert.Equal(i * 2, entity.Get<Position>().Y);

                entity.Delete();
            }
        }

        /// <summary>
        ///     Tests component modification through reference
        /// </summary>
        /// <remarks>
        ///     Validates that modifications made through component references
        ///     are properly reflected in the entity.
        /// </remarks>
        [Fact]
        public void Component_ModificationsThroughReferenceWork()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position());

            ref Position pos = ref entity.Get<Position>();
            pos.X = 42;
            pos.Y = 84;

            Position retrieved = entity.Get<Position>();
            Assert.Equal(42, retrieved.X);
            Assert.Equal(84, retrieved.Y);
        }

        /// <summary>
        ///     Tests component integrity after multiple archetype transitions
        /// </summary>
        /// <remarks>
        ///     Validates that component data remains intact through
        ///     multiple archetype transitions.
        /// </remarks>
        [Fact]
        public void Component_IntegrityThroughMultipleTransitions()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 100, Y = 200});

            entity.Add(new Velocity());
            Assert.Equal(100, entity.Get<Position>().X);

            entity.Add(new Health());
            Assert.Equal(100, entity.Get<Position>().X);

            entity.Remove<Velocity>();
            Assert.Equal(100, entity.Get<Position>().X);

            entity.Add(new Velocity());
            Assert.Equal(100, entity.Get<Position>().X);

            Assert.Equal(100, entity.Get<Position>().X);
            Assert.Equal(200, entity.Get<Position>().Y);
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
        }

        /// <summary>
        ///     Tests component count limits per entity
        /// </summary>
        /// <remarks>
        ///     Validates that an entity can have multiple different
        ///     component types simultaneously.
        /// </remarks>
        [Fact]
        public void Component_EntityCanHaveMultipleComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(new Position());
            entity.Add(new Velocity());
            entity.Add(new Health());

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
        }

        /// <summary>
        ///     Tests component default values after creation
        /// </summary>
        /// <remarks>
        ///     Validates that components have their default values
        ///     immediately after being added to an entity.
        /// </remarks>
        [Fact]
        public void Component_HasDefaultValuesAfterCreation()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(new Health());

            Health health = entity.Get<Health>();
            Assert.Equal(0, health.Value);
        }

        /// <summary>
        ///     Tests component query performance with many components
        /// </summary>
        /// <remarks>
        ///     Validates that querying entities with specific components
        ///     performs well even with many entities.
        /// </remarks>
        [Fact]
        public void Component_QueryPerformanceWithManyEntities()
        {
            using Scene scene = new Scene();
            const int entityCount = 1000;

            for (int i = 0; i < entityCount; i++)
            {
                GameObject entity = scene.Create(new Position {X = i, Y = i});
            }

            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (GameObject entity in query.EnumerateWithEntities())
            {
                Assert.True(entity.Has<Position>());
                count++;
            }

            Assert.Equal(entityCount, count);
        }
    }
}