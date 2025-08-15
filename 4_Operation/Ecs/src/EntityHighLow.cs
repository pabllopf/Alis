using System.Runtime.InteropServices;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The gameObject high low
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]

    public struct EntityHighLow
    {
        /// <summary>
        ///     The gameObject id
        /// </summary>
        internal int EntityID;

        /// <summary>
        ///     The gameObject low
        /// </summary>
        internal int EntityLow;
    }
}