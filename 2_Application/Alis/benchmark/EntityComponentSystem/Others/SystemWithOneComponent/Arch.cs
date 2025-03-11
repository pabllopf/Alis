using System.Runtime.CompilerServices;
using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using Alis.Benchmark.EntityComponentSystem.Others.Contexts.Arch_Components;
using Arch.Core;
using Arch.Core.Utils;
using Arch.System;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.EntityComponentSystem.Others.SystemWithOneComponent
{
    /// <summary>
    /// The system with one component class
    /// </summary>
    public partial class SystemWithOneComponent
    {
        /// <summary>
        /// The for each
        /// </summary>
        private struct ForEach1 : IForEach<Component1>
        {
            /// <summary>
            /// Updates the t 0
            /// </summary>
            /// <param name="t0">The </param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Update(ref Component1 t0)
            {
                ++t0.Value;
            }
        }

        /// <summary>
        /// Fors the each using the specified t 0
        /// </summary>
        /// <param name="t0">The </param>
        [Query]
        private static void ForEach(ref Component1 t0)
        {
            ++t0.Value;
        }

        /// <summary>
        /// The arch context class
        /// </summary>
        /// <seealso cref="ArchBaseContext"/>
        private sealed class ArchContext : ArchBaseContext
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ArchContext"/> class
            /// </summary>
            /// <param name="entityCount">The entity count</param>
            /// <param name="_">The </param>
            public ArchContext(int entityCount, int _)
                : base(_filter, entityCount)
            { }
        }

        /// <summary>
        /// The component
        /// </summary>
        private static readonly ComponentType[] _filter = [typeof(Component1)];
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
        private ForEach1 _forEach;

        /// <summary>
        /// Arches the mono thread
        /// </summary>
        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch_MonoThread()
        {
            World world = _arch.World;
            world.InlineQuery<ForEach1, Component1>(_queryDescription, ref _forEach);
        }
        
        /// <summary>
        /// Arches the mono thread source generated
        /// </summary>
        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch_MonoThread_SourceGenerated()
        {
           SystemWithOneComponent.ForEachQuery(_arch.World);
        }
        
        /// <summary>
        /// Arches the multi thread
        /// </summary>
        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch_MultiThread()
        {
            World world = _arch.World;
            world.InlineParallelQuery<ForEach1, Component1>(_queryDescription, ref _forEach);
        }
    }
}
