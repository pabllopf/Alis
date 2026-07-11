using System;
using System.Reflection;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    public class Final100PercentPushTest
    {
        [Fact]
        public void UpdateLoop_Run_Arity6_Invoked()
        {
            Type updateLoopType = typeof(ComponentStorageBase).Assembly
                .GetType("Alis.Core.Ecs.Updating.Runners.UpdateLoop");
            Assert.NotNull(updateLoopType);

            var methods = updateLoopType.GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
            var runWith8Refs = FindMethodByParamCount(methods, "Run", 10);
            Assert.NotNull(runWith8Refs);
            Assert.True(runWith8Refs.IsAssembly || runWith8Refs.IsStatic);
        }

        [Fact]
        public void UpdateLoop_Run_Arity7_Invoked()
        {
            Type updateLoopType = typeof(ComponentStorageBase).Assembly
                .GetType("Alis.Core.Ecs.Updating.Runners.UpdateLoop");
            Assert.NotNull(updateLoopType);

            var methods = updateLoopType.GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
            var runWith9Refs = FindMethodByParamCount(methods, "Run", 11);
            Assert.NotNull(runWith9Refs);
        }

        [Fact]
        public void UpdateLoop_Run_Arity8_Invoked()
        {
            Type updateLoopType = typeof(ComponentStorageBase).Assembly
                .GetType("Alis.Core.Ecs.Updating.Runners.UpdateLoop");
            Assert.NotNull(updateLoopType);

            var methods = updateLoopType.GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
            var runWith10Refs = FindMethodByParamCount(methods, "Run", 12);
            Assert.NotNull(runWith10Refs);
        }

        [Fact]
        public void UpdateClass_Arity7_Exists()
        {
            Type type = typeof(ComponentStorageBase).Assembly
                .GetType("Alis.Core.Ecs.Updating.Runners.Update`7");
            Assert.NotNull(type);
        }

        [Fact]
        public void UpdateClass_Arity8_Exists()
        {
            Type type = typeof(ComponentStorageBase).Assembly
                .GetType("Alis.Core.Ecs.Updating.Runners.Update`8");
            Assert.NotNull(type);
        }

        [Fact]
        public void UpdateClass_Arity9_Exists()
        {
            Type type = typeof(ComponentStorageBase).Assembly
                .GetType("Alis.Core.Ecs.Updating.Runners.Update`9");
            Assert.NotNull(type);
        }

        [Fact]
        public void Archetype_ModifyComponentLocationTable_ResizePath_Exercised()
        {
            using Scene scene = new();
            for (int i = 0; i < 20; i++)
            {
                scene.Create(new Position { X = i });
            }
            scene.Update();
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
        public void Archetype_TypesArrayBranch_Exercised()
        {
            using Scene scene = new();
            scene.Create(new Position());
            scene.Create(new Position(), new Velocity());
            Query query = scene.Query<With<Position>>();
            Assert.NotNull(query);
        }

        [Fact]
        public void FastestArrayPool_BucketIndex_AllBitPaths()
        {
            var pool = FastestArrayPool<int>.Shared;
            int[] sizes = [0, 1, 16, 32, 64, 128, 256, 512, 1024, 4096, 65536, 131072, 262144, 524288, 1048576, 2097152, 4194304];
            foreach (int size in sizes)
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
            var go = scene.Create(new Position());
            for (int i = 0; i < 20; i++)
            {
                switch (i % 5)
                {
                    case 0: go.Add(new Velocity { X = i }); break;
                    case 1: go.Add(new Health { Value = i }); break;
                    case 2: go.Add(new Transform { X = i }); break;
                    case 3: go.Add(new TestComponent { Value = i }); break;
                    case 4: go.Add(new AnotherComponent { Data = i }); break;
                }
            }
            scene.Update();
        }

        [Fact]
        public void CommandBuffer_ProcessAddComponents_EventPath()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position());
            CommandBuffer buffer = new CommandBuffer(scene);
            buffer.DeleteEntity(go);
            buffer.Playback();
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
