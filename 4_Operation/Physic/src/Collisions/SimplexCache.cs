

using System.Runtime.InteropServices;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Caches simplex state between GJK calls to enable warm-starting.
    /// </summary>
    /// <remarks>
    ///     By reusing the simplex from the previous frame, GJK can converge faster for
    ///     shapes that haven't moved significantly. The metric is used to validate that
    ///     the cached state is still relevant—if shapes have moved too much, the cache is discarded.
    ///     
    ///     Set <see cref="Count"/> to zero on the first call to force a fresh GJK start.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SimplexCache
    {
        /// <summary>
        ///     Gets or sets the number of vertices in the cached simplex.
        /// </summary>
        /// <value>
        ///     An <see cref="ushort"/> between 0 and 3. Zero indicates an invalid/empty cache.
        /// </value>
        /// <remarks>
        ///     Set to zero on the first call to force a fresh GJK start.
        /// </remarks>
        public ushort Count;

        /// <summary>
        ///     Gets or sets the vertex indices on shape A for each simplex vertex.
        /// </summary>
        /// <value>
        ///     A <see cref="FixedArray3{T}"/> of byte values representing vertex indices in shape A's vertex array.
        /// </value>
        public FixedArray3<byte> IndexA;

        /// <summary>
        ///     Gets or sets the vertex indices on shape B for each simplex vertex.
        /// </summary>
        /// <value>
        ///     A <see cref="FixedArray3{T}"/> of byte values representing vertex indices in shape B's vertex array.
        /// </value>
        public FixedArray3<byte> IndexB;

        /// <summary>
        ///     Gets or sets the metric value for cache validation.
        /// </summary>
        /// <value>
        ///     A <see cref="float"/> representing the simplex size (distance for 2 vertices, area for 3).
        /// </value>
        /// <remarks>
        ///     Used to detect when shapes have moved significantly enough to invalidate the cache.
        ///     If the new metric differs substantially from this value, the cache is discarded.
        /// </remarks>
        public float Metric;
    }
}