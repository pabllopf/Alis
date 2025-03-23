using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Core
{
    [StructLayout( LayoutKind.Auto )]
    internal record struct DeleteComponent(EntityIDOnly Entity, ComponentID ComponentID);
}