using System.Linq;
using System.Runtime.CompilerServices;
using Alis.Benchmark.EntityComponentSystem.Contexts;
using Alis.Benchmark.EntityComponentSystem.Contexts.Arch_Components;
using Arch.Core;
using Arch.Core.Utils;
using Arch.System;
using BenchmarkDotNet.Attributes;
using Schedulers;
using World = Arch.Core.World;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithTwoComponentsMultipleComposition
{
    /// <summary>
    /// The system with two components multiple composition class
    /// </summary>
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        /// <summary>
        /// The for each
        /// </summary>
        private struct ForEach2 : IForEach<Component1, Component2>
        {
            /// <summary>
            /// Updates the t 0
            /// </summary>
            /// <param name="t0">The </param>
            /// <param name="t1">The </param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Update(ref Component1 t0, ref Component2 t1)
            {
                t0.Value += t1.Value;
            }
        }
        
        /// <summary>
        /// Fors the each using the specified t 0
        /// </summary>
        /// <param name="t0">The </param>
        /// <param name="t1">The </param>
        [Query]
        private static void ForEach(ref Component1 t0, Component2 t1)
        {
            t0.Value += t1.Value;
        }

        /// <summary>
        /// The arch context class
        /// </summary>
        /// <seealso cref="ArchBaseContext"/>
        private sealed class ArchContext : ArchBaseContext
        {
            private record struct Padding1();

            private record struct Padding2();

            private record struct Padding3();

            private record struct Padding4();

            /// <summary>
            /// Initializes a new instance of the <see cref="ArchContext"/> class
            /// </summary>
            /// <param name="entityCount">The entity count</param>
            public ArchContext(int entityCount)
            {
                JobScheduler = new JobScheduler( new JobScheduler.Config
                {
                    ThreadPrefixName = "Arch.Benchmark",
                    ThreadCount = 0,
                    MaxExpectedConcurrentJobs = 64,
                    StrictAllocationMode = false,
                });
                World.SharedJobScheduler = JobScheduler;
                
                ComponentType[] paddingTypes = [
                    typeof(Padding1),
                    typeof(Padding2),
                    typeof(Padding3),
                    typeof(Padding4)
                ];

                ComponentType[][] archetypes = paddingTypes.Select(t => _filter.Concat(Enumerable.Repeat(t, 1)).ToArray()).ToArray();

                foreach (ComponentType[] archetype in archetypes)
                {
                    World.Reserve(archetype, entityCount / 4);
                }

                for (int index = 0; index < entityCount; index++)
                {
                    World.Create(archetypes[index % archetypes.Length]);
                }
            }
        }

        /// <summary>
        /// The component
        /// </summary>
        private static readonly ComponentType[] _filter = [typeof(Component1), typeof(Component2)];
        /// <summary>
        /// The filter
        /// </summary>
        private static readonly QueryDescription _queryDescription = new() { All = _filter };

        /// <summary>
        /// The arch
        /// </summary>
        [Context]
        private readonly ArchContext _arch;
        /// <summary>
        /// The for each
        /// </summary>
        private ForEach2 _forEach2;

        /// <summary>
        /// Arches this instance
        /// </summary>
        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch()
        {
            World world = _arch.World;
            world.InlineQuery<ForEach2, Component1, Component2>(in _queryDescription, ref _forEach2);
        }
        
        /// <summary>
        /// Arches the mono thread source generated
        /// </summary>
        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch_MonoThread_SourceGenerated()
        {
           SystemWithTwoComponentsMultipleComposition.ForEachQuery(_arch.World);
        }
        
        /// <summary>
        /// Arches the multi thread
        /// </summary>
        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch_MultiThread()
        {
            World world = _arch.World;
            world.InlineParallelQuery<ForEach2, Component1, Component2>(in _queryDescription, ref _forEach2);
        }
    }
}
