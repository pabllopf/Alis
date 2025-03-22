using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Alis.Core.Ecs.Collections
{
    //160 bits, 20 bytes
    /// <summary>
    /// The archetype neighbor cache
    /// </summary>
    internal struct ArchetypeNeighborCache
    {
        //128 bits
        /// <summary>
        /// The keys and values
        /// </summary>
        private InlineArray8<ushort> _keysAndValues;
        //32
        /// <summary>
        /// The next index
        /// </summary>
        private int _nextIndex;

        /// <summary>
        /// Traverses the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Traverse(ushort value)
        {
            if (value == _keysAndValues._0)
                return 0;
            if (value == _keysAndValues._1)
                return 1;
            if (value == _keysAndValues._2)
                return 2;
            if (value == _keysAndValues._3)
                return 3;

            return 32;
        }

        /// <summary>
        /// Lookups the index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ushort</returns>
        public ushort Lookup(int index)
        {
            Debug.Assert(index < 4);
            return Unsafe.Add(ref _keysAndValues._4, index);
        }

        /// <summary>
        /// Sets the key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The value</param>
        public void Set(ushort key, ushort value)
        {
            Unsafe.Add(ref _keysAndValues._4, _nextIndex) = value;
            Unsafe.Add(ref _keysAndValues._0, _nextIndex) = key;
            _nextIndex = (_nextIndex + 1) & 3;
        }
    }
}