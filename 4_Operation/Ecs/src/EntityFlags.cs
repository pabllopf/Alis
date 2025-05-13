using System;

namespace Alis.Core.Ecs;

[Flags]
internal enum EntityFlags : ushort
{
    None = 0,

    Tagged = 1 << 0,
    Detach = 1 << 1,

    AddComp = 1 << 2,

    AddGenericComp = 1 << 3,
    RemoveComp = 1 << 4,

    RemoveGenericComp = 1 << 5,

    OnDelete = 1 << 6,

    Events = Tagged | Detach | AddComp | RemoveComp | OnDelete | WorldCreate,

    WorldCreate = 1 << 7,

    HasWorldCommandBufferRemove = 1 << 8,

    HasWorldCommandBufferAdd = 1 << 9,

    HasWorldCommandBufferDelete = 1 << 10,

    IsUnmergedEntity = 1 << 11,
}