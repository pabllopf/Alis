

using System.Runtime.InteropServices;
using Alis.Core.Physic.Collisions;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     This proxy is used internally to connect fixtures to the broad-phase.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FixtureProxy
    {
        /// <summary>
        ///     The aabb
        /// </summary>
        public Aabb Aabb;

        /// <summary>
        ///     The child index
        /// </summary>
        public int ChildIndex;

        /// <summary>
        ///     The fixture
        /// </summary>
        public Fixture Fixture;

        /// <summary>
        ///     The proxy id
        /// </summary>
        public int ProxyId;
    }
}