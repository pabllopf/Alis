using System.Runtime.InteropServices;
using Alis.Core.Ecs.Core;

namespace Alis.Core.Ecs
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
        internal EntityIDOnly EntityIDOnly;

        /// <summary>
        ///     The world id
        /// </summary>
        internal ushort WorldID;
    }
}