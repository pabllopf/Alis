using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Updating
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ToIndex"></param>
    /// <param name="FromIndex"></param>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public record struct DeleteComponentData(int ToIndex, int FromIndex);
}