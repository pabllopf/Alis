using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Kernel
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Entity"></param>
    /// <param name="BufferIndex"></param>
    /// <param name="BufferLength"></param>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public record struct CreateCommand(GameObjectIdOnly Entity, int BufferIndex, int BufferLength);
}