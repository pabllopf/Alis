using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The gameObject data
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]

    public struct EntityData
    {
        /// <summary>
        ///     The gameObject id
        /// </summary>
        internal int EntityID;

        /// <summary>
        ///     The gameObject version
        /// </summary>
        internal ushort EntityVersion;

        /// <summary>
        ///     The scene id
        /// </summary>
        internal ushort WorldID;
    }
}