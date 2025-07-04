using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetype;
using Alis.Core.Ecs.Redifinition;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The gameObject extensions class
    /// </summary>
    partial class GameObjectExtensions
    {
        /// <summary>
        ///     Gets the comp using the specified archetype table
        /// </summary>
        /// <typeparam name="TC">The tc</typeparam>
        /// <param name="archetypeTable">The archetype table</param>
        /// <param name="comps">The comps</param>
        /// <param name="index">The index</param>
        /// <returns>A ref of tc</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Ref<TC> GetComp<TC>(byte[] archetypeTable, ComponentStorageBase[] comps, int index)
        {
            int compIndex = archetypeTable.XxUnsafeArrayIndex(Component<TC>.Id.RawIndex) & GlobalWorldTables.IndexBits;
            return new Ref<TC>( Unsafe.As<ComponentStorage<TC>>(comps.XxUnsafeArrayIndex(compIndex)), index);
        }
    }
}