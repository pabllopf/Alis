using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Kernel
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Entity"></param>
    /// <param name="ComponentId"></param>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public record struct DeleteComponent(GameObjectIdOnly Entity, ComponentId ComponentId);
}