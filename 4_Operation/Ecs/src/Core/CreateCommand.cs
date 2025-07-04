using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Core
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public record struct CreateCommand(GameObjectIdOnly Entity, int BufferIndex, int BufferLength);
}