using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Kernel.Archetypes
{
    /// <summary>
    ///     The fields
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
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