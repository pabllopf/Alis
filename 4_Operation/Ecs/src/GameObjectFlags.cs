using System;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The gameObject flags enum
    /// </summary>
    [Flags]
    public enum GameObjectFlags
    {
        /// <summary>
        ///     The none gameObject flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The tagged gameObject flags
        /// </summary>
        Tagged = 1 << 0,

        /// <summary>
        ///     The detach gameObject flags
        /// </summary>
        Detach = 1 << 1,

        /// <summary>
        ///     The add comp gameObject flags
        /// </summary>
        AddComp = 1 << 2,

        /// <summary>
        ///     The add generic comp gameObject flags
        /// </summary>
        AddGenericComp = 1 << 3,

        /// <summary>
        ///     The remove comp gameObject flags
        /// </summary>
        RemoveComp = 1 << 4,

        /// <summary>
        ///     The remove generic comp gameObject flags
        /// </summary>
        RemoveGenericComp = 1 << 5,

        /// <summary>
        ///     The on delete gameObject flags
        /// </summary>
        OnDelete = 1 << 6,

        /// <summary>
        ///     The events gameObject flags
        /// </summary>
        Events = Tagged | Detach | AddComp | RemoveComp | OnDelete | WorldCreate,

        /// <summary>
        ///     The scene create gameObject flags
        /// </summary>
        WorldCreate = 1 << 7,

        /// <summary>
        ///     The has scene command buffer remove gameObject flags
        /// </summary>
        HasWorldCommandBufferRemove = 1 << 8,

        /// <summary>
        ///     The has scene command buffer add gameObject flags
        /// </summary>
        HasWorldCommandBufferAdd = 1 << 9,

        /// <summary>
        ///     The has scene command buffer delete gameObject flags
        /// </summary>
        HasWorldCommandBufferDelete = 1 << 10,

        /// <summary>
        ///     The is unmerged gameObject gameObject flags
        /// </summary>
        IsUnmergedEntity = 1 << 11
    }
}