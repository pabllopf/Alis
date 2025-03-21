using System.Runtime.InteropServices;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The entity high low
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct EntityHighLow
    {
        /// <summary>
        ///     The entity id
        /// </summary>
        internal int EntityID;

        /// <summary>
        ///     The entity low
        /// </summary>
        internal int EntityLow;
    }
}