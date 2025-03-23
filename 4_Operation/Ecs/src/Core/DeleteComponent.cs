namespace Alis.Core.Ecs.Core
{
    internal record struct DeleteComponent(EntityIDOnly Entity, ComponentID ComponentID);
}