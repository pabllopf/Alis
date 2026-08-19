using System;
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
            using (Scene scene = new())
            {
                GameObject go = scene.Create(new Position {X = 100});
                ComponentHandle handle = Component<Position>.StoreComponent(in go.Get<Position>());
                Assert.True(typeof(ComponentHandle).IsValueType);
                handle.Dispose();
            }
        }

        /// <summary>
        /// Tests that scene create without event works
        /// </summary>
        [Fact]
        public void Scene_CreateWithoutEvent_Works()
        {
            using (Scene scene = new())
            {
                GameObject go = scene.CreateEntityWithoutEvent();
                go.Add(new Position {X = 7});
                scene.InvokeEntityCreated(go);
                Assert.True(go.Has<Position>());
            }
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
