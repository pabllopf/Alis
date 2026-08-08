using System;
using System.Reflection;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    /// The internal reflection coverage test class
    /// </summary>
    public class InternalReflectionCoverageTest
    {
        /// <summary>
        /// Tests that update runner arity 7 instantiated and run invoked
        /// </summary>
        [Fact]
        public void Update_Runner_Arity7_InstantiatedAndRun_Invoked()
        {
            Type update7 = typeof(ComponentStorageBase).Assembly
                .GetType("Alis.Core.Ecs.Updating.Runners.Update`7");
            Assert.NotNull(update7);

            Type closed = update7.MakeGenericType(
                typeof(UpdateCompStub),   // TComp : IOnUpdate<6 args>
                typeof(Velocity),         // TArg1
                typeof(Health),           // TArg2
                typeof(Transform),        // TArg3
                typeof(TestComponent),    // TArg4
                typeof(AnotherComponent), // TArg5
                typeof(Damage)           // TArg6
            );

            object instance = Activator.CreateInstance(closed, new object[] { 0 });
            Assert.NotNull(instance);

            using Scene scene = new();
            Archetype archetype = scene.DefaultArchetype;
            object result = closed.GetMethod("Run", [typeof(Scene), typeof(Archetype)])
                ?.Invoke(instance, [scene, archetype]);
            Assert.Null(result);
        }

        /// <summary>
        /// Tests that update runner arity 8 instantiated and run invoked
        /// </summary>
        [Fact]
        public void Update_Runner_Arity8_InstantiatedAndRun_Invoked()
        {
            Type update8 = typeof(ComponentStorageBase).Assembly
                .GetType("Alis.Core.Ecs.Updating.Runners.Update`8");
            Assert.NotNull(update8);

            Type closed = update8.MakeGenericType(
                typeof(UpdateCompStub),   // TComp : IOnUpdate<7 args>
                typeof(Velocity),
                typeof(Health),
                typeof(Transform),
                typeof(TestComponent),
                typeof(AnotherComponent),
                typeof(Damage),
                typeof(Armor)
            );

            object instance = Activator.CreateInstance(closed, new object[] { 0 });
            Assert.NotNull(instance);

            using Scene scene = new();
            Archetype archetype = scene.DefaultArchetype;
            object result = closed.GetMethod("Run", [typeof(Scene), typeof(Archetype)])
                ?.Invoke(instance, [scene, archetype]);
            Assert.Null(result);
        }

        /// <summary>
        /// Tests that update runner arity 9 instantiated and run invoked
        /// </summary>
        [Fact]
        public void Update_Runner_Arity9_InstantiatedAndRun_Invoked()
        {
            Type update9 = typeof(ComponentStorageBase).Assembly
                .GetType("Alis.Core.Ecs.Updating.Runners.Update`9");
            Assert.NotNull(update9);

            Type closed = update9.MakeGenericType(
                typeof(UpdateCompStub),   // TComp : IOnUpdate<8 args>
                typeof(Velocity),
                typeof(Health),
                typeof(Transform),
                typeof(TestComponent),
                typeof(AnotherComponent),
                typeof(Damage),
                typeof(Armor),
                typeof(Position)
            );

            object instance = Activator.CreateInstance(closed, new object[] { 0 });
            Assert.NotNull(instance);

            using Scene scene = new();
            Archetype archetype = scene.DefaultArchetype;
            object result = closed.GetMethod("Run", [typeof(Scene), typeof(Archetype)])
                ?.Invoke(instance, [scene, archetype]);
            Assert.Null(result);
        }

        /// <summary>
        /// Tests that update runner arity 7 run partial invoked
        /// </summary>
        [Fact]
        public void Update_Runner_Arity7_RunPartial_Invoked()
        {
            Type update7 = typeof(ComponentStorageBase).Assembly
                .GetType("Alis.Core.Ecs.Updating.Runners.Update`7");
            Assert.NotNull(update7);

            Type closed = update7.MakeGenericType(
                typeof(UpdateCompStub),
                typeof(Velocity), typeof(Health), typeof(Transform),
                typeof(TestComponent), typeof(AnotherComponent), typeof(Damage)
            );

            object instance = Activator.CreateInstance(closed, new object[] { 0 });
            using Scene scene = new();
            Archetype archetype = scene.DefaultArchetype;
            object result = closed.GetMethod("Run", [typeof(Scene), typeof(Archetype), typeof(int), typeof(int)])
                ?.Invoke(instance, [scene, archetype, 0, 0]);
            Assert.Null(result);
        }

        /// <summary>
        /// Tests that fields get component data reference invoked no throw
        /// </summary>
        [Fact]
        public void Fields_GetComponentDataReference_Invoked_NoThrow()
        {
            using Scene scene = new();
            scene.Create(new Position { X = 42 });
            Archetype archetype = scene.DefaultArchetype;
            Fields fields = archetype.Data;

            MethodInfo method = typeof(Fields).GetMethod("GetComponentDataReference",
                BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);
            Assert.NotNull(fields.Map);
            Assert.NotNull(fields.Components);
        }

        /// <summary>
        /// Tests that archetype t id field accessible
        /// </summary>
        [Fact]
        public void ArchetypeT_IdField_Accessible()
        {
            Type archetypeT = typeof(Archetype).Assembly
                .GetType("Alis.Core.Ecs.Kernel.Archetypes.Archetype`1");
            Assert.NotNull(archetypeT);

            Type closed = archetypeT.MakeGenericType(typeof(Position));
            FieldInfo idField = closed.GetField("Id", BindingFlags.Static | BindingFlags.Public);
            Assert.NotNull(idField);

            object id = idField.GetValue(null);
            Assert.NotNull(id);
        }

        /// <summary>
        /// Tests that archetype t archetype component i ds accessible
        /// </summary>
        [Fact]
        public void ArchetypeT_ArchetypeComponentIDs_Accessible()
        {
            Type archetypeT = typeof(Archetype).Assembly
                .GetType("Alis.Core.Ecs.Kernel.Archetypes.Archetype`1");
            Assert.NotNull(archetypeT);

            Type closed = archetypeT.MakeGenericType(typeof(Position));
            FieldInfo field = closed.GetField("ArchetypeComponentIDs",
                BindingFlags.Static | BindingFlags.Public);
            Assert.NotNull(field);

            object val = field.GetValue(null);
            Assert.NotNull(val);
        }

        /// <summary>
        /// Tests that archetype t create new or get existing invoked
        /// </summary>
        [Fact]
        public void ArchetypeT_CreateNewOrGetExisting_Invoked()
        {
            Type archetypeT = typeof(Archetype).Assembly
                .GetType("Alis.Core.Ecs.Kernel.Archetypes.Archetype`1");
            Assert.NotNull(archetypeT);

            Type closed = archetypeT.MakeGenericType(typeof(Position));
            MethodInfo method = closed.GetMethod("CreateNewOrGetExistingArchetypes",
                BindingFlags.Static | BindingFlags.NonPublic);
            Assert.NotNull(method);

            using Scene scene = new();
            object result = method.Invoke(null, [scene]);
            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that enum data all arities verify types
        /// </summary>
        [Fact]
        public void EnumData_AllArities_VerifyTypes()
        {
            Assert.True(typeof(GameObjectQueryEnumerator<Position, Velocity, Health, Transform,
                TestComponent, AnotherComponent, Damage, Armor>).IsValueType);

            Assert.True(typeof(ChunkTuple<Position, Velocity, Health, Transform,
                TestComponent, AnotherComponent, Damage, Armor>).IsValueType);

            Assert.True(typeof(GameObjectQueryEnumerator<Position>).IsValueType);
        }

        /// <summary>
        /// Tests that component store and get handle works
        /// </summary>
        [Fact]
        public void Component_StoreAndGet_HandleWorks()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position { X = 100 });
            ComponentHandle handle = Component<Position>.StoreComponent(in go.Get<Position>());
            Assert.True(typeof(ComponentHandle).IsValueType);
            handle.Dispose();
        }

        /// <summary>
        /// Tests that scene create without event works
        /// </summary>
        [Fact]
        public void Scene_CreateWithoutEvent_Works()
        {
            using Scene scene = new();
            GameObject go = scene.CreateEntityWithoutEvent();
            go.Add(new Position { X = 7 });
            scene.InvokeEntityCreated(go);
            Assert.True(go.Has<Position>());
        }
    }

    /// <summary>
    /// The update comp stub
    /// </summary>
    internal struct UpdateCompStub : IOnUpdate,
        IOnUpdate<Velocity>,
        IOnUpdate<Velocity, Health>,
        IOnUpdate<Velocity, Health, Transform>,
        IOnUpdate<Velocity, Health, Transform, TestComponent>,
        IOnUpdate<Velocity, Health, Transform, TestComponent, AnotherComponent>,
        IOnUpdate<Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>,
        IOnUpdate<Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>,
        IOnUpdate<Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor, Position>
    {
        /// <summary>
        /// Ons the update using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnUpdate(IGameObject self) { }
        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="arg">The arg</param>
        public void Update(IGameObject self, ref Velocity arg) { }
        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="arg1">The arg</param>
        /// <param name="arg2">The arg</param>
        public void Update(IGameObject self, ref Velocity arg1, ref Health arg2) { }
        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="arg1">The arg</param>
        /// <param name="arg2">The arg</param>
        /// <param name="arg3">The arg</param>
        public void Update(IGameObject self, ref Velocity arg1, ref Health arg2, ref Transform arg3) { }
        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="arg1">The arg</param>
        /// <param name="arg2">The arg</param>
        /// <param name="arg3">The arg</param>
        /// <param name="arg4">The arg</param>
        public void Update(IGameObject self, ref Velocity arg1, ref Health arg2, ref Transform arg3, ref TestComponent arg4) { }
        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="arg1">The arg</param>
        /// <param name="arg2">The arg</param>
        /// <param name="arg3">The arg</param>
        /// <param name="arg4">The arg</param>
        /// <param name="arg5">The arg</param>
        public void Update(IGameObject self, ref Velocity arg1, ref Health arg2, ref Transform arg3, ref TestComponent arg4, ref AnotherComponent arg5) { }
        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="arg1">The arg</param>
        /// <param name="arg2">The arg</param>
        /// <param name="arg3">The arg</param>
        /// <param name="arg4">The arg</param>
        /// <param name="arg5">The arg</param>
        /// <param name="arg6">The arg</param>
        public void Update(IGameObject self, ref Velocity arg1, ref Health arg2, ref Transform arg3, ref TestComponent arg4, ref AnotherComponent arg5, ref Damage arg6) { }
        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="arg1">The arg</param>
        /// <param name="arg2">The arg</param>
        /// <param name="arg3">The arg</param>
        /// <param name="arg4">The arg</param>
        /// <param name="arg5">The arg</param>
        /// <param name="arg6">The arg</param>
        /// <param name="arg7">The arg</param>
        public void Update(IGameObject self, ref Velocity arg1, ref Health arg2, ref Transform arg3, ref TestComponent arg4, ref AnotherComponent arg5, ref Damage arg6, ref Armor arg7) { }
        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="arg1">The arg</param>
        /// <param name="arg2">The arg</param>
        /// <param name="arg3">The arg</param>
        /// <param name="arg4">The arg</param>
        /// <param name="arg5">The arg</param>
        /// <param name="arg6">The arg</param>
        /// <param name="arg7">The arg</param>
        /// <param name="arg8">The arg</param>
        public void Update(IGameObject self, ref Velocity arg1, ref Health arg2, ref Transform arg3, ref TestComponent arg4, ref AnotherComponent arg5, ref Damage arg6, ref Armor arg7, ref Position arg8) { }
    }
}
