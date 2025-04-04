using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Kernel
{
    /// <summary>
    ///     The entity world info access
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct EntityWorldInfoAccess
    {
        /// <summary>
        ///     The entity id only
        /// </summary>
        internal EntityIdOnly EntityIDOnly;

        /// <summary>
        ///     The world id
        /// </summary>
        internal ushort WorldID;
    }
}