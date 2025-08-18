using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Updating
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public record struct DeleteComponentData(int ToIndex, int FromIndex);
}