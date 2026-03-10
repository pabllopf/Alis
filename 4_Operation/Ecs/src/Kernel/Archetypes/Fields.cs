using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Kernel.Archetypes
{
    /// <summary>
    ///     The fields
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: 16 bytes total (two array references, 8 bytes each)
    ///     Pack = 8 for optimal alignment with reference types on 64-bit architectures
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct Fields
    {
        /// <summary>
        ///     The map
        /// </summary>
        internal byte[] Map;

        /// <summary>
        ///     The components
        /// </summary>
        internal ComponentStorageBase[] Components;

        /// <summary>
        ///     Gets the component data reference
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The ref</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal ref T GetComponentDataReference<T>()
        {
            int index = Unsafe.Add(ref Map[0], Component<T>.Id.RawIndex);
            return ref Unsafe.As<ComponentStorage<T>>(Unsafe.Add(ref Components[0], index))
                .GetComponentStorageDataReference();
        }
    }
}