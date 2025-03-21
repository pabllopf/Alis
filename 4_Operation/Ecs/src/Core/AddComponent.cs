using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Core
{
    [StructLayout( LayoutKind.Auto )]
    internal record struct AddComponent(EntityIDOnly Entity, ComponentHandle ComponentHandle);
}