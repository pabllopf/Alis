

using System;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The component lifecycle test class
    /// </summary>
    /// <remarks>
    ///     Tests component lifecycle operations including addition, removal,
    ///     access, and modification of components on entities.
    /// </remarks>
    public class ComponentLifecycleTest
    {
        /// <summary>
        ///     Tests that components can be added to entities
        /// </summary>
        /// <remarks>
        ///     Validates that components can be added after entity creation.
        /// </remarks>
        [Fact]
        public void Component_CanBeAddedAfterCreation()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 0, Y = 0});

            entity.Add(new Health {Value = 100});

            Assert.True(entity.Has<Health>());
            Assert.Equal(100, entity.Get<Health>().Value);
        }

        /// <summary>
        ///     Tests that components can be removed from entities
        /// </summary>
        /// <remarks>
        ///     Tests that components can be removed and will not be accessible.
        /// </remarks>
        [Fact]
        public void Component_CanBeRemoved()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 0, Y = 0}, new Health {Value = 100});

            entity.Remove<Health>();

            Assert.False(entity.Has<Health>());
            Assert.True(entity.Has<Position>());
        }

        /// <summary>
        ///     Tests that component data can be accessed
        /// </summary>
        /// <remarks>
        ///     Validates that component data can be retrieved from entities.
        /// </remarks>
        [Fact]
        public void Component_DataCanBeAccessed()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 10, Y = 20});

            Position pos = entity.Get<Position>();

            Assert.Equal(10, pos.X);
            Assert.Equal(20, pos.Y);
        }

        /// <summary>
        ///     Tests that TryGet works correctly
        /// </summary>
        /// <remarks>
        ///     Tests that TryGet returns true for present components
        ///     and false for absent ones.
        /// </remarks>
        [Fact]
        public void Component_TryGetWorks()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 5, Y = 10});

            bool hasPos = entity.TryGet(out Ref<Position> posRef);
            bool hasHealth = entity.TryGet(out Ref<Health> healthRef);

            Assert.True(hasPos);
            Assert.Equal(5, posRef.Value.X);
            Assert.False(hasHealth);
        }

        /// <summary>
        ///     Tests that multiple component types can coexist
        /// </summary>
        /// <remarks>
        ///     Validates that entities can have multiple components simultaneously.
        /// </remarks>
        [Fact]
        public void Component_MultipleComponentsCanCoexist()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Health {Value = 75},
                new Velocity {X = 1.5f, Y = 2.5f}
            );

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Velocity>());
        }

        /// <summary>
        ///     Tests that dead entities cannot access components
        /// </summary>
        /// <remarks>
        ///     Validates that accessing components on deleted entities throws.
        /// </remarks>
        [Fact]
        public void Component_DeadEntityThrowsOnAccess()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 0, Y = 0});

            entity.Delete();

            Assert.ThrowsAny<InvalidOperationException>(() => entity.Get<Position>());
        }
    }
}