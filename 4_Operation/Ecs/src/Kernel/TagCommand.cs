using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Kernel
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Entity"></param>
    /// <param name="TagId"></param>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public record struct TagCommand(GameObjectIdOnly Entity, TagId TagId);
}