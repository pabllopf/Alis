using System;
using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Backends
{
    /// <summary>
    /// The bound resource set info
    /// </summary>
    internal struct BoundResourceSetInfo : IEquatable<BoundResourceSetInfo>
    {
        /// <summary>
        /// The set
        /// </summary>
        public ResourceSet Set;
        /// <summary>
        /// The offsets
        /// </summary>
        public SmallFixedOrDynamicArray Offsets;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoundResourceSetInfo"/> class
        /// </summary>
        /// <param name="set">The set</param>
        /// <param name="offsetsCount">The offsets count</param>
        /// <param name="offsets">The offsets</param>
        public BoundResourceSetInfo(ResourceSet set, uint offsetsCount, ref uint offsets)
        {
            Set = set;
            Offsets = new SmallFixedOrDynamicArray(offsetsCount, ref offsets);
        }

        /// <summary>
        /// Describes whether this instance equals
        /// </summary>
        /// <param name="set">The set</param>
        /// <param name="offsetsCount">The offsets count</param>
        /// <param name="offsets">The offsets</param>
        /// <returns>The bool</returns>
        public bool Equals(ResourceSet set, uint offsetsCount, ref uint offsets)
        {
            if (set != Set || offsetsCount != Offsets.Count) { return false; }

            for (uint i = 0; i < Offsets.Count; i++)
            {
                if (Unsafe.Add(ref offsets, (int)i) != Offsets.Get(i)) { return false; }
            }

            return true;
        }

        /// <summary>
        /// Describes whether this instance equals
        /// </summary>
        /// <param name="other">The other</param>
        /// <returns>The bool</returns>
        public bool Equals(BoundResourceSetInfo other)
        {
            if (Set != other.Set || Offsets.Count != other.Offsets.Count)
            {
                return false;
            }

            for (uint i = 0; i < Offsets.Count; i++)
            {
                if (Offsets.Get(i) != other.Offsets.Get(i))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
