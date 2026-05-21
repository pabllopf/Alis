

using System;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     Defines bitwise flags that track the state and event subscription status of entities within a scene.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     This flags enum is used internally by the ECS system to track which events are active for
    ///     each entity and to manage structural changes. The flags are stored in entity metadata
    ///     and checked during system execution to determine whether event handlers should be invoked.
    ///     </para>
    ///     <para>
    ///     Some flags (like AddComp, RemoveComp, OnDelete) indicate that event listeners exist
    ///     for specific entity events. Others (like HasWorldCommandBufferAdd) indicate pending
    ///     structural changes that need to be processed.
    ///     </para>
    /// </remarks>
    [Flags]
    public enum GameObjectFlags
    {
        /// <summary>
        ///     No flags set - the entity has no active event subscriptions or pending operations.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Indicates that there are registered listeners for component-added events on this entity.
        /// </summary>
        AddComp = 1 << 2,

        /// <summary>
        ///     Indicates that there are registered generic component-added event listeners on this entity.
        /// </summary>
        AddGenericComp = 1 << 3,

        /// <summary>
        ///     Indicates that there are registered listeners for component-removed events on this entity.
        /// </summary>
        RemoveComp = 1 << 4,

        /// <summary>
        ///     Indicates that there are registered generic component-removed event listeners on this entity.
        /// </summary>
        RemoveGenericComp = 1 << 5,

        /// <summary>
        ///     Indicates that there are registered listeners for entity-deleted events on this entity.
        /// </summary>
        OnDelete = 1 << 6,

        /// <summary>
        ///     A composite flag combining AddComp, RemoveComp, OnDelete, and WorldCreate.
        /// </summary>
        /// <value>
        ///     Convenience flag for checking if any standard entity events are active.
        /// </value>
        Events = AddComp | RemoveComp | OnDelete | WorldCreate,

        /// <summary>
        ///     Indicates there are registered listeners for entity-created events in this scene.
        /// </summary>
        WorldCreate = 1 << 7,

        /// <summary>
        ///     Indicates there is a pending component removal in the scene's command buffer for this entity.
        /// </summary>
        HasWorldCommandBufferRemove = 1 << 8,

        /// <summary>
        ///     Indicates there is a pending component addition in the scene's command buffer for this entity.
        /// </summary>
        HasWorldCommandBufferAdd = 1 << 9,

        /// <summary>
        ///     Indicates there is a pending entity deletion in the scene's command buffer for this entity.
        /// </summary>
        HasWorldCommandBufferDelete = 1 << 10,

        /// <summary>
        ///     Indicates that this entity was created during a structural change and hasn't been merged into
        ///     the main entity storage yet.
        /// </summary>
        IsUnmergedEntity = 1 << 11
    }
}