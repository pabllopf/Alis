using System;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Test.Updating.Runners;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    /// Broad API coverage for Scene public methods, properties and events.
    /// </summary>
    public partial class SceneApiCoverageTest
    {
        /// <summary>
        /// Tests that scene shared countdown returns stable instance
        /// </summary>
        [Fact]
        public void Scene_SharedCountdown_ReturnsStableInstance()
        {
            using Scene scene = new Scene();

            Assert.Same(scene.SharedCountdown, scene.SharedCountdown);
            Assert.NotNull(scene.SharedCountdown);
        }

        /// <summary>
        /// Tests that scene entity created event toggles world event flag
        /// </summary>
        [Fact]
        public void Scene_EntityCreatedEvent_TogglesWorldEventFlag()
        {
            using Scene scene = new Scene();
            Action<GameObject> handler = _ => { };

            scene.EntityCreated += handler;
            Assert.True((scene.WorldEventFlags & GameObjectFlags.WorldCreate) != 0);

            scene.EntityCreated -= handler;
            Assert.True((scene.WorldEventFlags & GameObjectFlags.WorldCreate) == 0);
        }

        /// <summary>
        /// Tests that scene entity deleted event toggles world event flag
        /// </summary>
        [Fact]
        public void Scene_EntityDeletedEvent_TogglesWorldEventFlag()
        {
            using Scene scene = new Scene();
            Action<GameObject> handler = _ => { };

            scene.EntityDeleted += handler;
            Assert.True((scene.WorldEventFlags & GameObjectFlags.OnDelete) != 0);

            scene.EntityDeleted -= handler;
            Assert.True((scene.WorldEventFlags & GameObjectFlags.OnDelete) == 0);
        }

        /// <summary>
        /// Tests that scene component added event toggles world event flag
        /// </summary>
        [Fact]
        public void Scene_ComponentAddedEvent_TogglesWorldEventFlag()
        {
            using Scene scene = new Scene();
            Action<GameObject, ComponentId> handler = (_, _) => { };

            scene.ComponentAdded += handler;
            Assert.True((scene.WorldEventFlags & GameObjectFlags.AddComp) != 0);

            scene.ComponentAdded -= handler;
            Assert.True((scene.WorldEventFlags & GameObjectFlags.AddComp) == 0);
        }

        /// <summary>
        /// Tests that scene component removed event toggles world event flag
        /// </summary>
        [Fact]
        public void Scene_ComponentRemovedEvent_TogglesWorldEventFlag()
        {
            using Scene scene = new Scene();
            Action<GameObject, ComponentId> handler = (_, _) => { };

            scene.ComponentRemoved += handler;
            Assert.True((scene.WorldEventFlags & GameObjectFlags.RemoveComp) != 0);

            scene.ComponentRemoved -= handler;
            Assert.True((scene.WorldEventFlags & GameObjectFlags.RemoveComp) == 0);
        }

        /// <summary>
        /// Tests that scene update generic attribute updates only components registered for attribute
        /// </summary>
        [Fact]
        public void Scene_UpdateGenericAttribute_UpdatesOnlyComponentsRegisteredForAttribute()
        {
            using Scene scene = new Scene();
            GenerationServices.RegisterUpdateMethodAttribute(typeof(SceneApiUpdateAttribute), typeof(UpdateComponent));

            GameObject tagged = scene.Create(new UpdateComponent {CallCount = 0});

            scene.Update<SceneApiUpdateAttribute>();

            Assert.Equal(1, tagged.Get<UpdateComponent>().CallCount);
        }

        /// <summary>
        /// Tests that scene update by type updates components registered for attribute
        /// </summary>
        [Fact]
        public void Scene_UpdateByType_UpdatesComponentsRegisteredForAttribute()
        {
            using Scene scene = new Scene();
            GenerationServices.RegisterUpdateMethodAttribute(typeof(SceneApiUpdateAttribute), typeof(UpdateComponent));

            GameObject tagged = scene.Create(new UpdateComponent {CallCount = 0});

            scene.Update(typeof(SceneApiUpdateAttribute));
            scene.Update(typeof(SceneApiUpdateAttribute));

            Assert.Equal(2, tagged.Get<UpdateComponent>().CallCount);
        }

        /// <summary>
        /// Tests that scene update component updates only specified component type
        /// </summary>
        [Fact]
        public void Scene_UpdateComponent_UpdatesOnlySpecifiedComponentType()
        {
            using Scene scene = new Scene();
            GameObject target = scene.Create(new UpdateComponent {CallCount = 0});
            GameObject nonTarget = scene.Create(
                new Update3Component {CallCount = 0},
                new Position {X = 1, Y = 1},
                new Velocity {X = 1, Y = 1},
                new Health {Value = 10}
            );

            scene.UpdateComponent(Component<UpdateComponent>.Id);

            Assert.Equal(1, target.Get<UpdateComponent>().CallCount);
            Assert.Equal(0, nonTarget.Get<Update3Component>().CallCount);
        }

        /// <summary>
        /// Tests that scene ensure capacity with zero or negative does nothing
        /// </summary>
        [Fact]
        public void Scene_EnsureCapacity_WithZeroOrNegative_DoesNothing()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 1});
            int before = scene.EntityCount;

            scene.EnsureCapacity(entity.Type, 0);
            scene.EnsureCapacity(entity.Type, -3);

            Assert.Equal(before, scene.EntityCount);
        }

        /// <summary>
        /// Tests that scene ensure capacity core with non positive count throws argument out of range exception
        /// </summary>
        [Fact]
        public void Scene_EnsureCapacityCore_WithNonPositiveCount_ThrowsArgumentOutOfRangeException()
        {
            using Scene scene = new Scene();

            Assert.Throws<ArgumentOutOfRangeException>(() => scene.EnsureCapacityCore(scene.DefaultArchetype, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => scene.EnsureCapacityCore(scene.DefaultArchetype, -1));
        }

        /// <summary>
        /// Tests that scene ensure capacity core with positive count does not throw
        /// </summary>
        [Fact]
        public void Scene_EnsureCapacityCore_WithPositiveCount_DoesNotThrow()
        {
            using Scene scene = new Scene();

            Exception ex = Record.Exception(() => scene.EnsureCapacityCore(scene.DefaultArchetype, 8));

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that scene create query and create query from span filter expected entities
        /// </summary>
        [Fact]
        public void Scene_CreateQuery_AndCreateQueryFromSpan_FilterExpectedEntities()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 1});
            scene.Create(new Position {X = 2, Y = 2}, new Velocity {X = 3, Y = 3});
            scene.Create(new Velocity {X = 4, Y = 4});

            Rule[] ruleArray = {new With<Position>().Rule};
            Query fromSpan = scene.CreateQueryFromSpan(ruleArray);
            Query fromImmutable = scene.CreateQuery(ToImmutable(ruleArray));

            int spanCount = 0;
            foreach (RefTuple<Position> _ in fromSpan.Enumerate<Position>())
            {
                spanCount++;
            }

            int immutableCount = 0;
            foreach (RefTuple<Position> _ in fromImmutable.Enumerate<Position>())
            {
                immutableCount++;
            }

            Assert.Equal(2, spanCount);
            Assert.Equal(2, immutableCount);
        }

        /// <summary>
        /// Returns the immutable using the specified rules
        /// </summary>
        /// <param name="rules">The rules</param>
        /// <returns>A fast immutable array of rule</returns>
        private static FastImmutableArray<Rule> ToImmutable(params Rule[] rules)
        {
            FastImmutableArray<Rule>.Builder builder = FastImmutableArray<Rule>.CreateBuilder<Rule>(rules.Length);
            foreach (Rule rule in rules)
            {
                builder.Add(rule);
            }

            return builder.ToImmutable();
        }

        /// <summary>
        /// The scene api update attribute class
        /// </summary>
        /// <seealso cref="UpdateTypeAttribute"/>
        private sealed class SceneApiUpdateAttribute : UpdateTypeAttribute
        {
        }

        // No extra local update structs are required here; we intentionally reuse
        // existing generated test components from Updating/Runners for stable behavior.
    }
}




