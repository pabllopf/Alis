using System.Runtime.InteropServices;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The entity data
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct EntityData
    {
        /// <summary>
        ///     The entity id
        /// </summary>
        internal int EntityID;

        /// <summary>
        ///     The entity version
        /// </summary>
        internal ushort EntityVersion;

        /// <summary>
        ///     The world id
        /// </summary>
        internal ushort WorldID;
    }
}