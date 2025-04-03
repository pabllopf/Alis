using System;

namespace Alis.Core.Ecs.Kernel
{
    /// <summary>
    ///     The entity flags enum
    /// </summary>
    [Flags]
    internal enum EntityFlags : ushort
    {
        /// <summary>
        ///     The none entity flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The tagged entity flags
        /// </summary>
        Tagged = 1 << 0,

        /// <summary>
        ///     The detach entity flags
        /// </summary>
        Detach = 1 << 1,

        /// <summary>
        ///     The add comp entity flags
        /// </summary>
        AddComp = 1 << 2,

        /// <summary>
        ///     The add generic comp entity flags
        /// </summary>
        AddGenericComp = 1 << 3,

        /// <summary>
        ///     The remove comp entity flags
        /// </summary>
        RemoveComp = 1 << 4,

        /// <summary>
        ///     The remove generic comp entity flags
        /// </summary>
        RemoveGenericComp = 1 << 5,

        /// <summary>
        ///     The on delete entity flags
        /// </summary>
        OnDelete = 1 << 6,

        /// <summary>
        ///     The events entity flags
        /// </summary>
        Events = Tagged | Detach | AddComp | RemoveComp | OnDelete | WorldCreate,

        /// <summary>
        ///     The world create entity flags
        /// </summary>
        WorldCreate = 1 << 7,

        /// <summary>
        ///     The has world command buffer remove entity flags
        /// </summary>
        HasWorldCommandBufferRemove = 1 << 8,

        /// <summary>
        ///     The has world command buffer add entity flags
        /// </summary>
        HasWorldCommandBufferAdd = 1 << 9,

        /// <summary>
        ///     The has world command buffer delete entity flags
        /// </summary>
        HasWorldCommandBufferDelete = 1 << 10,

        /// <summary>
        ///     The is unmerged entity entity flags
        /// </summary>
        IsUnmergedEntity = 1 << 11
    }
}