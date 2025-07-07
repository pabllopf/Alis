using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Kernel
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public record struct CreateCommand(GameObjectIdOnly Entity, int BufferIndex, int BufferLength);
}