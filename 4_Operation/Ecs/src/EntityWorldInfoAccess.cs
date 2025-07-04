using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Core;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The gameObject scene info access
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]

    public struct EntityWorldInfoAccess
    {
        /// <summary>
        ///     The gameObject id only
        /// </summary>
        internal GameObjectIdOnly EntityIDOnly;

        /// <summary>
        ///     The scene id
        /// </summary>
        internal ushort WorldID;
    }
}