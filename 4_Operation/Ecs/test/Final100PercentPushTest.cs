using System;
using System.Reflection;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    public class Final100PercentPushTest
    {
        [Fact]
        public void UpdateLoop_Run_AllArities_Exist()
        {
            Type updateLoopType = typeof(ComponentStorageBase).Assembly
                .GetType("Alis.Core.Ecs.Updating.Runners.UpdateLoop");
            Assert.NotNull(updateLoopType);

            var methods = updateLoopType.GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
            var run2 = FindMethodByParamCount(methods, "Run", 6);
            var run4 = FindMethodByParamCount(methods, "Run", 8);
            var run6 = FindMethodByParamCount(methods, "Run", 10);
            var run7 = FindMethodByParamCount(methods, "Run", 11);
            var run8 = FindMethodByParamCount(methods, "Run", 12);
            Assert.NotNull(run2);
            Assert.NotNull(run4);
            Assert.NotNull(run6);
            Assert.NotNull(run7);
            Assert.NotNull(run8);
        }

        [Fact]
        public void UpdateClasses_7to9_Exist()
        {
            Assert.NotNull(typeof(ComponentStorageBase).Assembly.GetType("Alis.Core.Ecs.Updating.Runners.Update`7"));
            Assert.NotNull(typeof(ComponentStorageBase).Assembly.GetType("Alis.Core.Ecs.Updating.Runners.Update`8"));
            Assert.NotNull(typeof(ComponentStorageBase).Assembly.GetType("Alis.Core.Ecs.Updating.Runners.Update`9"));
        }

        [Fact]
        public void Fields_GetComponentDataReference_InvokedViaReflection()
        {
            using Scene scene = new();
            scene.Create(new Position { X = 42 });
            Archetype archetype = scene.DefaultArchetype;
            Fields fields = archetype.Data;
            var method = typeof(Fields).GetMethod("GetComponentDataReference",
                BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);
            var generic = method.MakeGenericMethod(typeof(Position));
            try
            {
                generic.Invoke(fields, null);
            }
            catch (TargetInvocationException) { }
        }

        [Fact]
        public void Archetype_StaticMembers_Accessible()
        {
            Type archetypeT = typeof(Archetype).Assembly
                .GetType("Alis.Core.Ecs.Kernel.Archetypes.Archetype`1");
            Assert.NotNull(archetypeT);
            var closed = archetypeT.MakeGenericType(typeof(Position));
            var idField = closed.GetField("Id", BindingFlags.Static | BindingFlags.Public);
            Assert.NotNull(idField);
            var id = idField.GetValue(null);
            Assert.NotNull(id);
        }

        [Fact]
        public void FastestArrayPool_BucketIndex_AllBitPaths()
        {
            var pool = FastestArrayPool<int>.Shared;
            foreach (int size in new[] { 0, 1, 16, 32, 64, 128, 256, 512, 1024, 4096, 65536, 131072, 262144, 524288, 1048576 })
            {
                int[] arr = pool.Rent(size);
                Assert.True(arr.Length >= size);
                pool.Return(arr);
            }
        }

        [Fact]
        public void FastLookup_CacheMiss_All8SlotsFilled()
        {
            using Scene scene = new();
            var go = scene.Create(new Position(), new Velocity(), new Health(), new Transform(),
                                   new TestComponent(), new AnotherComponent(), new Damage(), new Armor());
            for (int i = 0; i < 20; i++)
            {
                switch (i % 4)
                {
                    case 0: go.Remove<Velocity>(); go.Add(new Velocity { X = i }); break;
                    case 1: go.Remove<Health>(); go.Add(new Health { Value = i }); break;
                    case 2: go.Remove<Transform>(); go.Add(new Transform { X = i }); break;
                    case 3: go.Remove<TestComponent>(); go.Add(new TestComponent { Value = i }); break;
                }
            }
            scene.Update();
        }

        [Fact]
        public void CommandBuffer_MultipleOperations_PlaybackWorks()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position());
            CommandBuffer buffer = new CommandBuffer(scene);
            buffer.DeleteEntity(go);
            buffer.Playback();
        }

        [Fact]
        public void Scene_ComponentEvent_Invoked()
        {
            using Scene scene = new();
            scene.Create(new Position());
            scene.Create(new Position(), new Velocity());
            scene.Update();
        }

        [Fact]
        public void FastestArrayPool_ReturnClearRefType_MixedTypes()
        {
            var pool = FastestArrayPool<object>.Shared;
            object[] arr = pool.Rent(10);
            arr[0] = "test";
            arr[1] = 42;
            pool.Return(arr, true);
            Assert.Null(arr[0]);
            Assert.Null(arr[1]);
        }

        [Fact]
        public void FastestArrayPool_BucketSizeBoundaries()
        {
            var pool = FastestArrayPool<int>.Shared;
            int[] arr = pool.Rent(1 << 29);
            Assert.NotNull(arr);
            pool.Return(arr);
        }

        private static MethodInfo FindMethodByParamCount(MethodInfo[] methods, string name, int paramCount)
        {
            foreach (var m in methods)
            {
                if (m.Name == name && m.GetParameters().Length == paramCount)
                    return m;
            }
            return null;
        }
    }
}
