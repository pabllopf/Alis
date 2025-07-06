using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Kernel
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public record struct AddComponent(GameObjectIdOnly Entity, ComponentHandle ComponentHandle);
}